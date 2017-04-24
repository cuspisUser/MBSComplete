namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI.Workspaces;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinDock;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using NetAdvantage.Controls;
    using NetAdvantage.WorkItems;
    using mipsed.application.framework;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class StavkeUre : UserControl
    {
        private IContainer components;
        private PARTNERComboBox cmboPARTNER;
        private GKSTAVKADataAdapter dagk;
        private DataRowView drv;
        private DataSet ds;
        private const int SC_CLOSE = 0xf060;
        private const int SC_MAXIMIZE = 0xf030;
        private const int SC_MINIMIZE = 0xf020;
        private const int SC_RESTORE = 0xf120;
        private BindingSource src;
        private const int WM_SYSCOMMAND = 0x112;

        public StavkeUre()
        {
            base.Load += new EventHandler(this.StavkeUre_Load);
            this.dagk = new GKSTAVKADataAdapter();
            this.ds = new DataSet();
            this.InitializeComponent();
        }

        public void BRISANJE_STAVKE()
        {
            if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count != 0)
            {
                if (Conversions.ToBoolean(this.GkstavkaDataSet1.GKSTAVKA.Rows[0]["statusgk"]))
                {
                    Interaction.MsgBox("Dokument je proknjižen u Glavnu knjigu", MsgBoxStyle.OkOnly, null);
                }
                else
                {
                    int index = 0;
                    if (this.UltraGrid1.ActiveRow != null)
                    {
                        index = this.UltraGrid1.ActiveRow.Index;
                    }
                    DataRowView current = (DataRowView) this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].Current;
                    if (decimal.Compare(Conversions.ToDecimal(current["zatvoreniiznos"]), decimal.Zero) != 0)
                    {
                        Interaction.MsgBox("Stavka korištena u vezama, brisanje nije moguće!", MsgBoxStyle.OkOnly, null);
                    }
                    else
                    {
                        if (Interaction.MsgBox("Želite li stvarno obrisati redak?", MsgBoxStyle.YesNo, "Potvrdite brisanje") == MsgBoxResult.Yes)
                        {
                            if (current.Row.RowState != DataRowState.Deleted)
                                current.Delete();

                            this.Spremi_Promjene();
                            this.GkstavkaDataSet1.Clear();
                            this.dagk.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(this.GkstavkaDataSet1, Conversions.ToInteger(this.UraControlerfORM.DataSet.URA.Rows[0]["URADOKIDDOKUMENT"]), Conversions.ToInteger(this.UraControlerfORM.DataSet.URA.Rows[0]["URABROJ"]), mipsed.application.framework.Application.ActiveYear);
                        }
                        try
                        {
                            this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[index];
                            this.UltraGrid1.ActiveRow.Selected = true;
                            this.UltraGrid1.Focus();
                        }
                        catch (System.Exception)
                        {
                            if (this.UltraGrid1.Rows.Count > 0)
                            {
                                this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[this.UltraGrid1.Rows.Count - 1];
                                this.UltraGrid1.ActiveRow.Selected = true;
                                this.UltraGrid1.Focus();
                            }
                        }
                    }
                }
            }
        }

        public void Closing(object sender, WorkspaceCancelEventArgs e)
        {
            this.UltraGrid1.UpdateData();
            this.ProvjerePrijeSpremanja();
            ExtendedWindowWorkspace workspace = (ExtendedWindowWorkspace) sender;
            if (workspace.ActiveSmartPart.ToString() == "Fin.SmartParts.PARTNERFormUserControl")
            {
                e.Cancel = false;
            }
            else
            {
                if (workspace.ActiveSmartPart.ToString() == "Fin.SmartParts.URAFormUserControl")
                {
                    URAFormUserControl activeSmartPart = (URAFormUserControl) workspace.ActiveSmartPart;
                    if (activeSmartPart.ParentForm.DialogResult == DialogResult.Cancel)
                    {
                        e.Cancel = false;
                        ((ExtendedWindowWorkspace) this.UraControlerfORM.WorkItem.Workspaces.Get("window")).SmartPartClosing -= new EventHandler<WorkspaceCancelEventArgs>(this.Closing);
                        return;
                    }
                }
                if (workspace.ActiveSmartPart.ToString() == "Fin.SmartParts.PARTNERWorkWith")
                {
                    e.Cancel = false;
                }
                else
                {
                    decimal num = 0;
                    decimal num2 = 0;
                    if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0)
                    {
                        num = DB.N20(RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Compute("SUM(DUGUJE)", "")));
                        num2 = DB.N20(RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Compute("SUM(POTRAZUJE)", "")));
                    }
                    if (decimal.Compare(num, num2) != 0)
                    {
                        if (Interaction.MsgBox("Saldo dokumenta nije na nuli, želite li stvarno izaći", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
                        {
                            e.Cancel = false;
                            ((ExtendedWindowWorkspace) this.UraControlerfORM.WorkItem.Workspaces.Get("window")).SmartPartClosing -= new EventHandler<WorkspaceCancelEventArgs>(this.Closing);
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        ((ExtendedWindowWorkspace) this.UraControlerfORM.WorkItem.Workspaces.Get("window")).SmartPartClosing -= new EventHandler<WorkspaceCancelEventArgs>(this.Closing);
                        e.Cancel = false;
                    }
                }
            }
        }

        public void DisableUnos()
        {
            this.ToolBar1.Buttons[0].Enabled = false;
            this.ToolBar1.Buttons[1].Enabled = false;
        }

        public void EnableUnos()
        {
            this.ToolBar1.Buttons[0].Enabled = true;
            this.ToolBar1.Buttons[1].Enabled = true;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("GKSTAVKA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGKSTAVKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMDOKUMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJDOKUMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJSTAVKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMJESTOTROSKA", -1, "MT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGJED", -1, "OJ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKONTO", -1, "KONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPIS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("duguje");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POTRAZUJE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMPRIJAVE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZATVORENIIZNOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GKDATUMVALUTE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("statusgk");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ORIGINALNIDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GKGODIDGODINE");
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "duguje", 15, true, "GKSTAVKA", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "duguje", 15, true);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings2 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "POTRAZUJE", 16, true, "GKSTAVKA", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "POTRAZUJE", 16, true);
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("d8ff4695-09eb-4541-9eaa-de2d94b0cbed"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("b3d2da6f-682c-44d3-9598-b9bca26e00e0"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("d8ff4695-09eb-4541-9eaa-de2d94b0cbed"), -1);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("37aee908-76f3-4136-a3bc-c8ee56a4964f"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("4e078597-d3d2-46b1-926e-7e88320782ae"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("37aee908-76f3-4136-a3bc-c8ee56a4964f"), -1);
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KONTO", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVAKTIVNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KONT");
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("MJESTOTROSKA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("mt");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ORGJED", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("oj");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.UltraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.sintetika = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.razlika = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.IZVRSENO = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.PLANIRANO = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ToolBar1 = new System.Windows.Forms.ToolBar();
            this.ToolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Panel2 = new System.Windows.Forms.Panel();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.GkstavkaDataSet1 = new Placa.GKSTAVKADataSet();
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._StavkeUreUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._StavkeUreUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._StavkeUreUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._StavkeUreUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._StavkeUreAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.KONTO = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.KontoDataSet1 = new Placa.KONTODataSet();
            this.MT = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.MjestotroskaDataSet1 = new Placa.MJESTOTROSKADataSet();
            this.OJ = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.OrgjedDataSet1 = new Placa.ORGJEDDataSet();
            this.S_FIN_IZVRSENJE_PLANADataSet1 = new Placa.S_FIN_IZVRSENJE_PLANADataSet();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sintetika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.razlika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IZVRSENO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLANIRANO)).BeginInit();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GkstavkaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.WindowDockingArea2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KONTO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MjestotroskaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OJ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgjedDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_FIN_IZVRSENJE_PLANADataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.UltraLabel4);
            this.Panel1.Controls.Add(this.sintetika);
            this.Panel1.Controls.Add(this.UltraLabel3);
            this.Panel1.Controls.Add(this.UltraLabel2);
            this.Panel1.Controls.Add(this.UltraLabel1);
            this.Panel1.Controls.Add(this.razlika);
            this.Panel1.Controls.Add(this.IZVRSENO);
            this.Panel1.Controls.Add(this.PLANIRANO);
            this.Panel1.Controls.Add(this.ToolBar1);
            this.Panel1.Location = new System.Drawing.Point(0, 18);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1261, 63);
            this.Panel1.TabIndex = 15;
            // 
            // UltraLabel4
            // 
            appearance22.FontData.BoldAsString = "True";
            appearance22.TextVAlignAsString = "Bottom";
            this.UltraLabel4.Appearance = appearance22;
            this.UltraLabel4.Location = new System.Drawing.Point(502, 10);
            this.UltraLabel4.Name = "UltraLabel4";
            this.UltraLabel4.Size = new System.Drawing.Size(100, 23);
            this.UltraLabel4.TabIndex = 22;
            this.UltraLabel4.Text = "Konto";
            // 
            // sintetika
            // 
            this.sintetika.Location = new System.Drawing.Point(502, 39);
            this.sintetika.Name = "sintetika";
            this.sintetika.Size = new System.Drawing.Size(100, 21);
            this.sintetika.TabIndex = 21;
            // 
            // UltraLabel3
            // 
            appearance19.FontData.BoldAsString = "True";
            appearance19.TextVAlignAsString = "Bottom";
            this.UltraLabel3.Appearance = appearance19;
            this.UltraLabel3.Location = new System.Drawing.Point(820, 10);
            this.UltraLabel3.Name = "UltraLabel3";
            this.UltraLabel3.Size = new System.Drawing.Size(100, 23);
            this.UltraLabel3.TabIndex = 20;
            this.UltraLabel3.Text = "Razlika";
            // 
            // UltraLabel2
            // 
            appearance21.FontData.BoldAsString = "True";
            appearance21.TextVAlignAsString = "Bottom";
            this.UltraLabel2.Appearance = appearance21;
            this.UltraLabel2.Location = new System.Drawing.Point(714, 10);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(100, 23);
            this.UltraLabel2.TabIndex = 19;
            this.UltraLabel2.Text = "Izvršeno";
            // 
            // UltraLabel1
            // 
            appearance23.FontData.BoldAsString = "True";
            appearance23.TextVAlignAsString = "Bottom";
            this.UltraLabel1.Appearance = appearance23;
            this.UltraLabel1.Location = new System.Drawing.Point(608, 10);
            this.UltraLabel1.Name = "UltraLabel1";
            this.UltraLabel1.Size = new System.Drawing.Size(100, 23);
            this.UltraLabel1.TabIndex = 18;
            this.UltraLabel1.Text = "Planirano";
            // 
            // razlika
            // 
            this.razlika.Location = new System.Drawing.Point(820, 39);
            this.razlika.MaskInput = "-nnnnnnnn.nn";
            this.razlika.Name = "razlika";
            this.razlika.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.razlika.Size = new System.Drawing.Size(100, 21);
            this.razlika.TabIndex = 17;
            // 
            // IZVRSENO
            // 
            this.IZVRSENO.Location = new System.Drawing.Point(714, 39);
            this.IZVRSENO.MaskInput = "-nnnnnnnn.nn";
            this.IZVRSENO.Name = "IZVRSENO";
            this.IZVRSENO.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.IZVRSENO.Size = new System.Drawing.Size(100, 21);
            this.IZVRSENO.TabIndex = 16;
            // 
            // PLANIRANO
            // 
            this.PLANIRANO.Location = new System.Drawing.Point(608, 39);
            this.PLANIRANO.MaskInput = "-nnnnnnnn.nn";
            this.PLANIRANO.Name = "PLANIRANO";
            this.PLANIRANO.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.PLANIRANO.Size = new System.Drawing.Size(100, 21);
            this.PLANIRANO.TabIndex = 15;
            // 
            // ToolBar1
            // 
            this.ToolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.ToolBarButton1,
            this.ToolBarButton2,
            this.ToolBarButton4,
            this.ToolBarButton3});
            this.ToolBar1.ButtonSize = new System.Drawing.Size(32, 32);
            this.ToolBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolBar1.DropDownArrows = true;
            this.ToolBar1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ToolBar1.ImageList = this.ImageList1;
            this.ToolBar1.Location = new System.Drawing.Point(0, 0);
            this.ToolBar1.MinimumSize = new System.Drawing.Size(0, 60);
            this.ToolBar1.Name = "ToolBar1";
            this.ToolBar1.ShowToolTips = true;
            this.ToolBar1.Size = new System.Drawing.Size(1261, 60);
            this.ToolBar1.TabIndex = 14;
            this.ToolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.ToolBar1_ButtonClick);
            // 
            // ToolBarButton1
            // 
            this.ToolBarButton1.ImageIndex = 1;
            this.ToolBarButton1.Name = "ToolBarButton1";
            this.ToolBarButton1.Text = "Unesi stavku";
            // 
            // ToolBarButton2
            // 
            this.ToolBarButton2.ImageIndex = 2;
            this.ToolBarButton2.Name = "ToolBarButton2";
            this.ToolBarButton2.Text = "Briši stavku";
            // 
            // ToolBarButton4
            // 
            this.ToolBarButton4.ImageIndex = 3;
            this.ToolBarButton4.Name = "ToolBarButton4";
            this.ToolBarButton4.Text = "Proknjiži";
            // 
            // ToolBarButton3
            // 
            this.ToolBarButton3.ImageIndex = 8;
            this.ToolBarButton3.Name = "ToolBarButton3";
            this.ToolBarButton3.Text = "Kontiraj po shemi";
            // 
            // ImageList1
            // 
            this.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.UltraGrid1);
            this.Panel2.Location = new System.Drawing.Point(0, 18);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1261, 258);
            this.Panel2.TabIndex = 22;
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataMember = "GKSTAVKA";
            this.UltraGrid1.DataSource = this.GkstavkaDataSet1;
            appearance14.BackColor = System.Drawing.Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance14;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn1.Header.VisiblePosition = 10;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn2.Header.VisiblePosition = 11;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn3.Header.VisiblePosition = 12;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn4.Header.VisiblePosition = 13;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn5.Header.VisiblePosition = 14;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn6.Header.VisiblePosition = 15;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn7.Header.VisiblePosition = 16;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 1;
            ultraGridColumn8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 0;
            ultraGridColumn10.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn11.Header.VisiblePosition = 7;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 2;
            ultraGridColumn12.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn13.Header.VisiblePosition = 9;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn14.Header.VisiblePosition = 17;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.Caption = "Opis";
            ultraGridColumn15.Header.VisiblePosition = 3;
            ultraGridColumn15.Width = 260;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.Caption = "Duguje";
            ultraGridColumn16.Header.VisiblePosition = 4;
            ultraGridColumn16.MaskInput = "-nnnnnnnnn.nn";
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.Caption = "Potražuje";
            ultraGridColumn17.Header.VisiblePosition = 5;
            ultraGridColumn17.MaskInput = "-nnnnnnnnn.nn";
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn18.Header.VisiblePosition = 18;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.Header.VisiblePosition = 19;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn20.Header.VisiblePosition = 20;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn21.Header.Caption = "Zatvoreno";
            ultraGridColumn21.Header.VisiblePosition = 6;
            ultraGridColumn21.MaskInput = "nnnnnnnnn.nn";
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn22.Header.VisiblePosition = 21;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn23.Header.VisiblePosition = 22;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn24.Header.VisiblePosition = 23;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn25.Header.VisiblePosition = 24;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25});
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            appearance1.FontData.BoldAsString = "True";
            summarySettings1.Appearance = appearance1;
            summarySettings1.DisplayFormat = "{0:#,##0.00}";
            summarySettings1.GroupBySummaryValueAppearance = appearance12;
            summarySettings1.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed;
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            appearance20.FontData.BoldAsString = "True";
            summarySettings2.Appearance = appearance20;
            summarySettings2.DisplayFormat = "{0:#,##0.00}";
            summarySettings2.GroupBySummaryValueAppearance = appearance24;
            summarySettings2.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed;
            ultraGridBand1.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings1,
            summarySettings2});
            ultraGridBand1.SummaryFooterCaption = "Ukupno";
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance15.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance15;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance16.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance16;
            appearance17.BorderColor = System.Drawing.Color.LightGray;
            appearance17.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance17;
            this.UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance18.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance18.BorderColor = System.Drawing.Color.Black;
            appearance18.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance18;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(0, 0);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(1261, 258);
            this.UltraGrid1.TabIndex = 10;
            this.UltraGrid1.UseAppStyling = false;
            this.UltraGrid1.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.UltraGrid1_AfterCellUpdate);
            this.UltraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
            this.UltraGrid1.AfterEnterEditMode += new System.EventHandler(this.UltraGrid1_AfterEnterEditMode);
            this.UltraGrid1.AfterRowsDeleted += new System.EventHandler(this.UltraGrid1_AfterRowsDeleted);
            this.UltraGrid1.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.UltraGrid1_AfterRowUpdate);
            this.UltraGrid1.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.UltraGrid1_BeforeCellActivate);
            this.UltraGrid1.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.UltraGrid1_BeforeEnterEditMode);
            this.UltraGrid1.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.UltraGrid1_CellDataError);
            this.UltraGrid1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UltraGrid1_KeyDown);
            // 
            // GkstavkaDataSet1
            // 
            this.GkstavkaDataSet1.DataSetName = "GKSTAVKADataSet";
            // 
            // UltraDockManager1
            // 
            dockAreaPane1.DockedBefore = new System.Guid("37aee908-76f3-4136-a3bc-c8ee56a4964f");
            dockableControlPane1.Control = this.Panel1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(154, 49, 885, 65);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Rad sa stavkama URE";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(1261, 81);
            dockableControlPane2.Control = this.Panel2;
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(412, 102, 697, 234);
            dockableControlPane2.Size = new System.Drawing.Size(100, 100);
            dockableControlPane2.Text = "Stavke URE";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Size = new System.Drawing.Size(1261, 276);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _StavkeUreUnpinnedTabAreaLeft
            // 
            this._StavkeUreUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._StavkeUreUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._StavkeUreUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._StavkeUreUnpinnedTabAreaLeft.Name = "_StavkeUreUnpinnedTabAreaLeft";
            this._StavkeUreUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._StavkeUreUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 381);
            this._StavkeUreUnpinnedTabAreaLeft.TabIndex = 16;
            // 
            // _StavkeUreUnpinnedTabAreaRight
            // 
            this._StavkeUreUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._StavkeUreUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._StavkeUreUnpinnedTabAreaRight.Location = new System.Drawing.Point(1261, 0);
            this._StavkeUreUnpinnedTabAreaRight.Name = "_StavkeUreUnpinnedTabAreaRight";
            this._StavkeUreUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._StavkeUreUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 381);
            this._StavkeUreUnpinnedTabAreaRight.TabIndex = 17;
            // 
            // _StavkeUreUnpinnedTabAreaTop
            // 
            this._StavkeUreUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._StavkeUreUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._StavkeUreUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._StavkeUreUnpinnedTabAreaTop.Name = "_StavkeUreUnpinnedTabAreaTop";
            this._StavkeUreUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._StavkeUreUnpinnedTabAreaTop.Size = new System.Drawing.Size(1261, 0);
            this._StavkeUreUnpinnedTabAreaTop.TabIndex = 18;
            // 
            // _StavkeUreUnpinnedTabAreaBottom
            // 
            this._StavkeUreUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._StavkeUreUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._StavkeUreUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 381);
            this._StavkeUreUnpinnedTabAreaBottom.Name = "_StavkeUreUnpinnedTabAreaBottom";
            this._StavkeUreUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._StavkeUreUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1261, 0);
            this._StavkeUreUnpinnedTabAreaBottom.TabIndex = 19;
            // 
            // _StavkeUreAutoHideControl
            // 
            this._StavkeUreAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._StavkeUreAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._StavkeUreAutoHideControl.Name = "_StavkeUreAutoHideControl";
            this._StavkeUreAutoHideControl.Owner = this.UltraDockManager1;
            this._StavkeUreAutoHideControl.Size = new System.Drawing.Size(0, 381);
            this._StavkeUreAutoHideControl.TabIndex = 20;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(1261, 86);
            this.WindowDockingArea1.TabIndex = 21;
            // 
            // DockableWindow2
            // 
            this.DockableWindow2.Controls.Add(this.Panel1);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(1261, 81);
            this.DockableWindow2.TabIndex = 24;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Controls.Add(this.Panel2);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(1261, 276);
            this.DockableWindow1.TabIndex = 25;
            // 
            // WindowDockingArea2
            // 
            this.WindowDockingArea2.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea2.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea2.Location = new System.Drawing.Point(0, 86);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(1261, 281);
            this.WindowDockingArea2.TabIndex = 23;
            // 
            // KONTO
            // 
            this.KONTO.DataMember = "KONTO";
            this.KONTO.DataSource = this.KontoDataSet1;
            appearance25.BackColor = System.Drawing.Color.White;
            this.KONTO.DisplayLayout.Appearance = appearance25;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn26.Header.VisiblePosition = 0;
            ultraGridColumn26.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn26.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn26.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(135, 0);
            ultraGridColumn26.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn26.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn27.Header.VisiblePosition = 1;
            ultraGridColumn27.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn27.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn27.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(382, 0);
            ultraGridColumn27.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn27.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn28.Header.VisiblePosition = 2;
            ultraGridColumn28.Hidden = true;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn29.Header.VisiblePosition = 3;
            ultraGridColumn29.RowLayoutColumnInfo.OriginX = 5;
            ultraGridColumn29.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn29.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn29.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn30.Header.VisiblePosition = 4;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30});
            ultraGridBand2.UseRowLayout = true;
            this.KONTO.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.KONTO.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance26.BackColor = System.Drawing.Color.Transparent;
            this.KONTO.DisplayLayout.Override.CardAreaAppearance = appearance26;
            this.KONTO.DisplayLayout.Override.CellPadding = 3;
            appearance27.TextHAlignAsString = "Left";
            this.KONTO.DisplayLayout.Override.HeaderAppearance = appearance27;
            appearance28.BorderColor = System.Drawing.Color.LightGray;
            appearance28.TextVAlignAsString = "Middle";
            this.KONTO.DisplayLayout.Override.RowAppearance = appearance28;
            this.KONTO.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance2.BorderColor = System.Drawing.Color.Black;
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.KONTO.DisplayLayout.Override.SelectedRowAppearance = appearance2;
            this.KONTO.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.KONTO.Location = new System.Drawing.Point(403, 291);
            this.KONTO.Name = "KONTO";
            this.KONTO.Size = new System.Drawing.Size(160, 80);
            this.KONTO.TabIndex = 13;
            this.KONTO.ValueMember = "IDKONTO";
            this.KONTO.Visible = false;
            this.KONTO.AfterCloseUp += new Infragistics.Win.UltraWinGrid.DropDownEventHandler(this.KONTO_AfterCloseUp);
            this.KONTO.TextChanged += new System.EventHandler(this.KONTO_TextChanged);
            // 
            // KontoDataSet1
            // 
            this.KontoDataSet1.DataSetName = "KONTODataSet";
            // 
            // MT
            // 
            this.MT.DataMember = "MJESTOTROSKA";
            this.MT.DataSource = this.MjestotroskaDataSet1;
            appearance3.BackColor = System.Drawing.Color.White;
            this.MT.DisplayLayout.Appearance = appearance3;
            ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn31.Header.VisiblePosition = 0;
            ultraGridColumn31.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(136, 0);
            ultraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn32.Header.VisiblePosition = 1;
            ultraGridColumn32.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(423, 0);
            ultraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn33.Header.VisiblePosition = 2;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33});
            ultraGridBand3.UseRowLayout = true;
            this.MT.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.MT.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.MT.DisplayLayout.Override.CardAreaAppearance = appearance4;
            this.MT.DisplayLayout.Override.CellPadding = 3;
            appearance5.TextHAlignAsString = "Left";
            this.MT.DisplayLayout.Override.HeaderAppearance = appearance5;
            appearance6.BorderColor = System.Drawing.Color.LightGray;
            appearance6.TextVAlignAsString = "Middle";
            this.MT.DisplayLayout.Override.RowAppearance = appearance6;
            this.MT.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance7.BorderColor = System.Drawing.Color.Black;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.MT.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.MT.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.MT.Location = new System.Drawing.Point(197, 291);
            this.MT.Name = "MT";
            this.MT.Size = new System.Drawing.Size(160, 80);
            this.MT.TabIndex = 12;
            this.MT.ValueMember = "IDMJESTOTROSKA";
            this.MT.Visible = false;
            // 
            // MjestotroskaDataSet1
            // 
            this.MjestotroskaDataSet1.DataSetName = "MJESTOTROSKADataSet";
            // 
            // OJ
            // 
            this.OJ.DataMember = "ORGJED";
            this.OJ.DataSource = this.OrgjedDataSet1;
            appearance8.BackColor = System.Drawing.Color.White;
            this.OJ.DisplayLayout.Appearance = appearance8;
            ultraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn34.Header.VisiblePosition = 0;
            ultraGridColumn34.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn34.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn34.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(142, 0);
            ultraGridColumn34.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn34.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn35.Header.VisiblePosition = 1;
            ultraGridColumn35.RowLayoutColumnInfo.OriginX = 3;
            ultraGridColumn35.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn35.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(420, 0);
            ultraGridColumn35.RowLayoutColumnInfo.SpanX = 10;
            ultraGridColumn35.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn36.Header.VisiblePosition = 2;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36});
            ultraGridBand4.UseRowLayout = true;
            this.OJ.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.OJ.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance9.BackColor = System.Drawing.Color.Transparent;
            this.OJ.DisplayLayout.Override.CardAreaAppearance = appearance9;
            this.OJ.DisplayLayout.Override.CellPadding = 3;
            appearance10.TextHAlignAsString = "Left";
            this.OJ.DisplayLayout.Override.HeaderAppearance = appearance10;
            appearance11.BorderColor = System.Drawing.Color.LightGray;
            appearance11.TextVAlignAsString = "Middle";
            this.OJ.DisplayLayout.Override.RowAppearance = appearance11;
            this.OJ.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance13.BorderColor = System.Drawing.Color.Black;
            appearance13.ForeColor = System.Drawing.Color.Black;
            this.OJ.DisplayLayout.Override.SelectedRowAppearance = appearance13;
            this.OJ.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.OJ.Location = new System.Drawing.Point(18, 291);
            this.OJ.Name = "OJ";
            this.OJ.Size = new System.Drawing.Size(160, 80);
            this.OJ.TabIndex = 11;
            this.OJ.ValueMember = "IDORGJED";
            this.OJ.Visible = false;
            // 
            // OrgjedDataSet1
            // 
            this.OrgjedDataSet1.DataSetName = "ORGJEDDataSet";
            // 
            // S_FIN_IZVRSENJE_PLANADataSet1
            // 
            this.S_FIN_IZVRSENJE_PLANADataSet1.DataSetName = "S_FIN_IZVRSENJE_PLANADataSet";
            // 
            // StavkeUre
            // 
            this.Controls.Add(this._StavkeUreAutoHideControl);
            this.Controls.Add(this.KONTO);
            this.Controls.Add(this.MT);
            this.Controls.Add(this.OJ);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._StavkeUreUnpinnedTabAreaTop);
            this.Controls.Add(this._StavkeUreUnpinnedTabAreaBottom);
            this.Controls.Add(this._StavkeUreUnpinnedTabAreaLeft);
            this.Controls.Add(this._StavkeUreUnpinnedTabAreaRight);
            this.Name = "StavkeUre";
            this.Size = new System.Drawing.Size(1261, 381);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sintetika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.razlika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IZVRSENO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLANIRANO)).EndInit();
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GkstavkaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.WindowDockingArea2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KONTO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KontoDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MjestotroskaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OJ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrgjedDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_FIN_IZVRSENJE_PLANADataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        public void Knizi()
        {
            if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count != 0)
            {
                decimal num = 0;
                decimal num2 = 0;
                this.UltraGrid1.UpdateData();
                this.Spremi_Promjene();
                if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0)
                {
                    num = DB.N20(RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Compute("SUM(DUGUJE)", "")));
                    num2 = DB.N20(RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Compute("SUM(POTRAZUJE)", "")));
                }
                if (decimal.Compare(num, num2) != 0)
                {
                    Interaction.MsgBox("Greška: Saldo dokumenta nije na nuli", MsgBoxStyle.OkOnly, null);
                }
                else
                {
                    IEnumerator enumerator = null;
                    try
                    {
                        enumerator = this.GkstavkaDataSet1.GKSTAVKA.Rows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            DataRow current = (DataRow) enumerator.Current;
                            current["statusgk"] = !Conversions.ToBoolean(current["statusgk"]);
                        }
                    }
                    finally
                    {
                        if (enumerator is IDisposable)
                        {
                            (enumerator as IDisposable).Dispose();
                        }
                    }
                    if (!Conversions.ToBoolean(this.GkstavkaDataSet1.GKSTAVKA.Rows[0]["statusgk"]))
                    {
                        this.EnableUnos();
                    }
                    else
                    {
                        this.DisableUnos();
                    }
                    this.Spremi_Promjene();
                    this.PostaviStatus();
                }
            }
        }

        public void KontirajPoShemi()
        {
            if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0)
            {
                Interaction.MsgBox("Za zadani dokument postoje stavke!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                BindingSource bindingSource = this.UraControlerfORM.URAFormDefinition.GetBindingSource("URA");
                try
                {
                    bindingSource.EndEdit();
                }
                catch (System.Exception exception1)
                {
                    throw exception1;                    
                    //return;
                }
                this.UraControlerfORM.Update(this.Parent.Parent);
                SHEMAURASelectionListWorkItem item = this.UraControlerfORM.WorkItem.Items.AddNew<SHEMAURASelectionListWorkItem>("test");
                SHEMAURADataSet set = new SHEMAURADataSet();
                DataRow fillByRow = set.SHEMAURA.NewSHEMAURARow();
                fillByRow["PARTNERSHEMAURAIDPARTNER"] = RuntimeHelpers.GetObjectValue(this.UraControlerfORM.DataSet.URA.Rows[0]["URAPARTNERIDPARTNER"]);
                DataRow row2 = item.ShowModal(true, "Fill", fillByRow);
                item.Terminate();
                if (row2 != null)
                {
                    int num = 0;
                    int num2 = 0;
                    int num5 = 0;
                    int num7 = row2.GetChildRows("SHEMAURA_SHEMAURASHEMAURAKONTIRANJE").Length - 1;
                    for (num5 = 0; num5 <= num7; num5++)
                    {
                        if (row2.GetChildRows("SHEMAURA_SHEMAURASHEMAURAKONTIRANJE")[num5]["SHEMAURAKONTOIDKONTO"].ToString().Substring(0, 1) == "2")
                        {
                            num++;
                        }
                        else if (row2.GetChildRows("SHEMAURA_SHEMAURASHEMAURAKONTIRANJE")[num5]["SHEMAURAKONTOIDKONTO"].ToString().Substring(0, 1) == "3")
                        {
                            num2++;
                        }
                    }
                    int num8 = row2.GetChildRows("SHEMAURA_SHEMAURASHEMAURAKONTIRANJE").Length - 1;
                    for (num5 = 0; num5 <= num8; num5++)
                    {
                        decimal num6 = 0;
                        this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].AddNew();
                        DataRowView current = (DataRowView) this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].Current;
                        current["datumdokumenta"] = RuntimeHelpers.GetObjectValue(this.UraControlerfORM.DataSet.URA.Rows[0]["URADATUM"]);
                        current["brojdokumenta"] = RuntimeHelpers.GetObjectValue(this.UraControlerfORM.DataSet.URA.Rows[0]["URABROJ"]);
                        current["brojstavke"] = num5 + 1;
                        current["iddokument"] = RuntimeHelpers.GetObjectValue(this.UraControlerfORM.DataSet.URA.Rows[0]["URADOKIDDOKUMENT"]);
                        current["OPIS"] = Strings.Left(this.UraControlerfORM.DataSet.URA.Rows[0]["URANAPOMENA"].ToString() + " " + this.UraControlerfORM.DataSet.URA.Rows[0]["URABROJRACUNADOBAVLJACA"].ToString() + " " + ((PARTNERComboBox) this.UraControlerfORM.URAFormDefinition.GetControl("combourapartnerIDPARTNER")).ComboBox.Text, 0x95);
                        current["zatvoreniiznos"] = 0;
                        current["statusgk"] = 0;

                        int idUraVrstaIznosa = Conversions.ToInteger(row2.GetChildRows("SHEMAURA_SHEMAURASHEMAURAKONTIRANJE")[num5]["IDURAVRSTAIZNOSA"]);

                        if (idUraVrstaIznosa == 1)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["URAUKUPNO"]);
                        }
                        else if (idUraVrstaIznosa == 2)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["OSNOVICA23"]);
                        }
                        else if (idUraVrstaIznosa == 3)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["OSNOVICA23NE"]);
                        }
                        else if (idUraVrstaIznosa == 4)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["OSNOVICA10"]);
                        }
                        else if (idUraVrstaIznosa == 5)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["OSNOVICA10NE"]);
                        }
                        else if (idUraVrstaIznosa == 6)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["PDV23DA"]);
                        }
                        else if (idUraVrstaIznosa == 7)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["PDV23NE"]);
                        }
                        else if (idUraVrstaIznosa == 8)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["PDV10DA"]);
                        }
                        else if (idUraVrstaIznosa == 9)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["PDV10NE"]);
                        }
                        else if (idUraVrstaIznosa == 10)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["OSNOVICA0"]);
                        }
                        else if (idUraVrstaIznosa == 11)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["OSNOVICA25"]);
                        }
                        else if (idUraVrstaIznosa == 12)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["OSNOVICA25NE"]);
                        }
                        else if (idUraVrstaIznosa == 13)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["PDV25DA"]);
                        }
                        else if (idUraVrstaIznosa == 14)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["PDV25NE"]);
                        }
                        else if (idUraVrstaIznosa == 1001)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["OSNOVICA5"]);
                        }
                        else if (idUraVrstaIznosa == 1002)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["OSNOVICA5NE"]);
                        }
                        else if (idUraVrstaIznosa == 1003)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["PDV5DA"]);
                        }
                        else if (idUraVrstaIznosa == 1004)
                        {
                            num6 = Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["PDV5NE"]);
                        }


                        // -----------------------------------------------------------------------------------------
                        // Matija Božičević - 14.08.2012. - zakomentirano
                        // -----------------------------------------------------------------------------------------
                        /*
                        else if (idUraVrstaIznosa == 11)
                        {
                            num6 = DB.RoundUP(decimal.Divide(Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["URAUKUPNO"]), new decimal(num)));
                        }
                        else if (idUraVrstaIznosa == 12)
                        {
                            num6 = DB.RoundUP(decimal.Divide(decimal.Subtract(Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["URAUKUPNO"]), Conversions.ToDecimal(this.UraControlerfORM.DataSet.URA.Rows[0]["PDV23DA"])), new decimal(num2)));
                        }
                        */

                        // SELECT * FROM [dbo].[STRANEKNJIZENJA]

                        int idStraneKnjizenja = Conversions.ToInteger(row2.GetChildRows("SHEMAURA_SHEMAURASHEMAURAKONTIRANJE")[num5]["SHEMAURASTRANEIDSTRANEKNJIZENJA"]);

                        // DUGUJE
                        if (idStraneKnjizenja == 1)
                        {
                            current["DUGUJE"] = num6;
                            current["POTRAZUJE"] = 0;
                        }
                        // -DUGUJE
                        else if (idStraneKnjizenja == 2)
                        {
                            current["DUGUJE"] = decimal.Negate(num6);
                            current["POTRAZUJE"] = 0;
                        }
                        // POTRAŽUJE
                        else if (idStraneKnjizenja == 3)
                        {
                            current["IDPARTNER"] = RuntimeHelpers.GetObjectValue(this.UraControlerfORM.DataSet.URA.Rows[0]["URAPARTNERIDPARTNER"]);
                            current["DUGUJE"] = 0;
                            current["POTRAZUJE"] = num6;
                        }
                        // -POTRAŽUJE
                        else if (idStraneKnjizenja == 4)
                        {
                            current["DUGUJE"] = 0;
                            current["POTRAZUJE"] = decimal.Negate(num6);
                        }

                        current["IDKONTO"] = RuntimeHelpers.GetObjectValue(row2.GetChildRows("SHEMAURA_SHEMAURASHEMAURAKONTIRANJE")[num5]["SHEMAURAKONTOIDKONTO"]);
                        current["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row2.GetChildRows("SHEMAURA_SHEMAURASHEMAURAKONTIRANJE")[num5]["SHEMAURAMTIDMJESTOTROSKA"]);
                        current["IDORGJED"] = RuntimeHelpers.GetObjectValue(row2.GetChildRows("SHEMAURA_SHEMAURASHEMAURAKONTIRANJE")[num5]["SHEMAURAOJIDORGJED"]);
                        current["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                        this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].EndCurrentEdit();
                    }
                    this.Spremi_Promjene();
                }
            }
        }

        private void KONTO_AfterCloseUp(object sender, DropDownEventArgs e)
        {
            DataRowView current = null;
            if (current == null)
            {
                if (this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].Position == -1)
                {
                    return;
                }
                current = (DataRowView) this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].Current;
            }
            if (this.KONTO.SelectedRow != null)
            {
                if (Conversions.ToInteger(this.KONTO.SelectedRow.Cells["idaktivnost"].Value) == 2)
                {
                    current["idpartner"] = RuntimeHelpers.GetObjectValue(this.UraControlerfORM.DataSet.URA.Rows[0]["URAPARTNERIDPARTNER"]);
                    current["GKDATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.UraControlerfORM.DataSet.URA.Rows[0]["uravaluta"]);
                }
                else
                {
                    current["idpartner"] = DBNull.Value;
                    current["GKDATUMVALUTE"] = DBNull.Value;
                }
            }
        }

        private void KONTO_TextChanged(object sender, EventArgs e)
        {
            this.Spremi_Promjene();
        }

        private void MakeEnterActLikeTab(UltraGrid Grid)
        {
            GridKeyActionMappings.GridKeyActionMappingEnumerator enumerator = Grid.KeyActionMappings.GetEnumerator();
            while (enumerator.MoveNext())
            {
                GridKeyActionMapping current = enumerator.Current;
                if (current.KeyCode == Keys.Tab)
                {
                    GridKeyActionMapping mapping = new GridKeyActionMapping(Keys.Return, current.ActionCode, current.StateDisallowed, current.StateRequired, current.SpecialKeysDisallowed, current.SpecialKeysRequired);
                    Grid.KeyActionMappings.Add(mapping);
                }
            }
        }

        public void PostaviStatus()
        {
            this.cmboPARTNER = (PARTNERComboBox)this.UraControlerfORM.URAFormDefinition.GetControl("combourapartnerIDPARTNER");

            bool flag = false;
            if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0)
            {
                bool flag2 = true;
                if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0)
                {
                    decimal num = DB.N20(RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Compute("SUM(zatvoreniiznos)", "")));
                    flag2 = Conversions.ToBoolean(this.GkstavkaDataSet1.GKSTAVKA.Rows[0]["statusgk"]);
                }
                if (flag2)
                {
                    flag = true;
                    try
                    {
                        this.cmboPARTNER.ComboBox.ReadOnly = true;
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;
                    }
                    this.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
                    this.DisableUnos();
                }
                else
                {
                    flag = false;
                    try
                    {
                        this.cmboPARTNER.ComboBox.ReadOnly = false;
                    }
                    catch (System.Exception exception3)
                    {
                        throw exception3;
                    }
                    this.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
                    this.EnableUnos();
                }
                if (flag)
                {
                    this.ToolBar1.Buttons[2].Text = "Odknjiži";
                }
                else
                {
                    this.ToolBar1.Buttons[2].Text = "Proknjiži";
                }
            }
            this.ProvjeriKnjizenje();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!((msg.Msg == 0x100) | (msg.Msg == 260)))
            {
                bool flag = false;
                return flag;
            }
            switch (keyData)
            {
                case Keys.Insert:
                    this.Unos();
                    return true;

                case Keys.Delete:
                    this.BRISANJE_STAVKE();
                    return true;

                case Keys.Escape:
                {
                    if (this.UltraGrid1.ActiveRow == null)
                    {
                        this.ParentForm.Close();
                        return true;
                    }
                    UltraGridRow activeRow = this.UltraGrid1.ActiveRow;
                    if (!((DataRowView) activeRow.ListObject).IsNew)
                    {
                        this.UltraGrid1.PerformAction(UltraGridAction.ExitEditMode);
                        this.UltraGrid1.ActiveRow = null;
                    }
                    if (((DataRowView) activeRow.ListObject).IsNew)
                    {
                        activeRow.CancelUpdate();
                        activeRow.Delete(false);
                        this.UltraGrid1.ActiveRow = null;
                        return true;
                    }
                    break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void ProvjerePrijeSpremanja()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.GkstavkaDataSet1.GKSTAVKA.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    if (Conversions.ToInteger(current["idaktivnost"]) == 2)
                    {
                        current["GKDATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.ds.Tables[0].Rows[0]["uravaluta"]);
                        current["idpartner"] = RuntimeHelpers.GetObjectValue(this.cmboPARTNER.SelectedItem.DataValue);
                    }
                    else
                    {
                        current["GKDATUMVALUTE"] = DBNull.Value;
                        current["idpartner"] = DBNull.Value;
                    }
                    current["DATUMDOKUMENTA"] = RuntimeHelpers.GetObjectValue(((UltraDateTimeEditor) this.UraControlerfORM.URAFormDefinition.GetControl("DATEPICKERURADATUM")).Value);
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            this.Spremi_Promjene();
        }

        public void ProvjeriKnjizenje()
        {
            if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0)
            {
                decimal num = DB.N20(RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Compute("SUM(DUGUJE)", "")));
                decimal num2 = DB.N20(RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Compute("SUM(POTRAZUJE)", "")));
                if (decimal.Compare(decimal.Subtract(num, num2), decimal.Zero) == 0)
                {
                    this.ToolBar1.Buttons[2].Enabled = true;
                }
                else
                {
                    this.ToolBar1.Buttons[2].Enabled = false;
                }
            }
            else
            {
                this.ToolBar1.Buttons[2].Enabled = false;
            }
        }

        public void Spremi_Promjene()
        {
            this.dagk.Update(this.GkstavkaDataSet1);
        }

        private void StavkeUre_Load(object sender, EventArgs e)
        {
            this.MakeEnterActLikeTab(this.UltraGrid1);
            KONTODataAdapter adapter = new KONTODataAdapter();
            ORGJEDDataAdapter adapter3 = new ORGJEDDataAdapter();
            MJESTOTROSKADataAdapter adapter2 = new MJESTOTROSKADataAdapter();
            adapter.Fill(this.KontoDataSet1);
            adapter3.Fill(this.OrgjedDataSet1);
            adapter2.Fill(this.MjestotroskaDataSet1);
            DOKUMENTComboBox control = (DOKUMENTComboBox)this.UraControlerfORM.URAFormDefinition.GetControl("comboURADOKIDDOKUMENT");
            control.ComboBox.Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textURAGODIDGODINE").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1URAGODIDGODINE").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1URADOKIDDOKUMENT").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1URABROJ").Visible = true;
            ((UltraDateTimeEditor) this.UraControlerfORM.URAFormDefinition.GetControl("DATEPICKERURADATUM")).MinDate = mipsed.application.framework.Application.Pocetni;
            ((UltraDateTimeEditor)this.UraControlerfORM.URAFormDefinition.GetControl("DATEPICKERURADATUM")).MaxDate = mipsed.application.framework.Application.Zavrsni;
            ((UltraNumericEditor) this.UraControlerfORM.URAFormDefinition.GetControl("textURABROJ")).Enabled = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("TEXTurabroj").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textURAGODIDGODINE").TabIndex = 0;
            this.UraControlerfORM.URAFormDefinition.GetControl("comboURADOKIDDOKUMENT").TabIndex = 1;
            this.UraControlerfORM.URAFormDefinition.GetControl("textURABROJ").TabIndex = 2;
            this.UraControlerfORM.URAFormDefinition.GetControl("combourapartnerIDPARTNER").TabIndex = 3;
            this.UraControlerfORM.URAFormDefinition.GetControl("textURABROJRACUNADOBAVLJACA").TabIndex = 4;
            this.UraControlerfORM.URAFormDefinition.GetControl("datePickerURADATUM").TabIndex = 5;
            this.UraControlerfORM.URAFormDefinition.GetControl("datePickerURAVALUTA").TabIndex = 6;
            this.UraControlerfORM.URAFormDefinition.GetControl("textURANAPOMENA").TabIndex = 7;
            this.UraControlerfORM.URAFormDefinition.GetControl("textURAMODEL").TabIndex = 8;
            this.UraControlerfORM.URAFormDefinition.GetControl("textURAPOZIVNABROJ").TabIndex = 9;
            this.UraControlerfORM.URAFormDefinition.GetControl("textURAUKUPNO").TabIndex = 10;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA0").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1OSNOVICA0").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA0").Enabled = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA23").Visible = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1OSNOVICA23").Visible = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA23").Enabled = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA23NE").Visible = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1OSNOVICA23NE").Visible = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA23NE").Enabled = false;

            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA22").Visible = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1OSNOVICA22").Visible = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA22").Enabled = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA22NE").Visible = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1OSNOVICA22NE").Visible = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA22NE").Enabled = false;

            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA25").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1OSNOVICA25").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA25").Enabled = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA25NE").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1OSNOVICA25NE").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA25NE").Enabled = true;

            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA10").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1OSNOVICA10").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA10").Enabled = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA10NE").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1OSNOVICA10NE").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA10NE").Enabled = true;

            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA5").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1OSNOVICA5").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA5").Enabled = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA5NE").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1OSNOVICA5NE").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textOSNOVICA5NE").Enabled = true;


            this.UraControlerfORM.URAFormDefinition.GetControl("textPDV10DA").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1PDV10DA").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textPDV10DA").Enabled = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textPDV10NE").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1PDV10NE").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textPDV10NE").Enabled = true;


            this.UraControlerfORM.URAFormDefinition.GetControl("textPDV5DA").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1PDV5DA").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textPDV5DA").Enabled = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textPDV5NE").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1PDV5NE").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textPDV5NE").Enabled = true;

            this.UraControlerfORM.URAFormDefinition.GetControl("textPDV22DA").Visible = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1PDV22DA").Visible = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("textPDV22DA").Enabled = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("textPDV22NE").Visible = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1PDV22NE").Visible = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("textPDV22NE").Enabled = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("textPDV23DA").Visible = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1PDV23DA").Visible = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("textPDV23DA").Enabled = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("textPDV23NE").Visible = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1PDV23NE").Visible = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("textPDV23NE").Enabled = false;
            this.UraControlerfORM.URAFormDefinition.GetControl("textIDTIPURA").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("label1IDTIPURA").Visible = true;
            this.UraControlerfORM.URAFormDefinition.GetControl("textIDTIPURA").Enabled = true;
            if (this.UraControlerfORM.DataSet.URA.Rows.Count != 0)
            {
                this.dagk.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(this.GkstavkaDataSet1, Conversions.ToInteger(this.UraControlerfORM.DataSet.URA.Rows[0]["URADOKIDDOKUMENT"]), Conversions.ToInteger(this.UraControlerfORM.DataSet.URA.Rows[0]["URABROJ"]), mipsed.application.framework.Application.ActiveYear);
                ((ExtendedWindowWorkspace) this.UraControlerfORM.WorkItem.Workspaces.Get("window")).SmartPartClosing += new EventHandler<WorkspaceCancelEventArgs>(this.Closing);
                this.ds = this.UraControlerfORM.DataSet;
                this.src = this.UraControlerfORM.URAFormDefinition.GetBindingSource("URA");
                decimal num = new decimal();
                bool flag = false;
                if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0)
                {
                    num = DB.N20(RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Compute("SUM(zatvoreniiznos)", "")));
                    flag = Conversions.ToBoolean(this.GkstavkaDataSet1.GKSTAVKA.Rows[0]["statusgk"]);
                }
                this.cmboPARTNER = (PARTNERComboBox) this.UraControlerfORM.URAFormDefinition.GetControl("combourapartnerIDPARTNER");
                if ((decimal.Compare(num, decimal.Zero) > 0) | flag)
                {
                    this.cmboPARTNER.ComboBox.ReadOnly = true;
                    this.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
                }
                else
                {
                    this.cmboPARTNER = (PARTNERComboBox) this.UraControlerfORM.URAFormDefinition.GetControl("combourapartnerIDPARTNER");
                    this.cmboPARTNER.SelectionChanged += new EventHandler(this.Test22);
                }
                this.PostaviStatus();
                InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
            }
        }

        private void Test2(object sender, EventArgs e)
        {
            this.ProvjerePrijeSpremanja();
        }

        private void Test22(object sender, EventArgs e)
        {
            this.ProvjerePrijeSpremanja();
        }

        private void ToolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Name == "ToolBarButton1")
            {
                this.Unos();
            }
            if (e.Button.Name == "ToolBarButton2")
            {
                this.BRISANJE_STAVKE();
            }
            if (e.Button.Name == "ToolBarButton4")
            {
                this.Knizi();
            }
            if (e.Button.Name == "ToolBarButton3")
            {
                this.KontirajPoShemi();
            }
        }

        private void UltraGrid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == "IDORGJED")
            {
                SqlParameter[] parameterArray = new SqlParameter[1];
                SqlConnection connection = new SqlConnection {
                    ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
                };
                SqlCommand command = new SqlCommand {
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection,
                    CommandText = "S_FIN_IZVRSENJE_PLANA"
                };
                command.Parameters.Add("@organizac", SqlDbType.Int).Value = RuntimeHelpers.GetObjectValue(e.Cell.Value);
                command.Parameters.Add("@godina", SqlDbType.Int).Value = mipsed.application.framework.Application.ActiveYear;
                SqlDataAdapter adapter = new SqlDataAdapter {
                    SelectCommand = command
                };
                adapter.SelectCommand.Connection = connection;
                this.S_FIN_IZVRSENJE_PLANADataSet1.EnforceConstraints = false;
                this.S_FIN_IZVRSENJE_PLANADataSet1.Clear();
                adapter.Fill(this.S_FIN_IZVRSENJE_PLANADataSet1, "S_FIN_IZVRSENJE_PLANA");
            }
            if (e.Cell.Column.Key == "IDKONTO")
            {
                DataRow[] rowArray2 = this.S_FIN_IZVRSENJE_PLANADataSet1.S_FIN_IZVRSENJE_PLANA.Select("KONTO LIKE '%" + e.Cell.Value.ToString().Substring(0, 4) + "'");
                if (rowArray2.Length > 0)
                {
                    this.PLANIRANO.Value = RuntimeHelpers.GetObjectValue(rowArray2[0]["PLANIRANO"]);
                    this.IZVRSENO.Value = RuntimeHelpers.GetObjectValue(rowArray2[0]["IZVRSENO"]);
                    this.razlika.Value = decimal.Subtract(Conversions.ToDecimal(rowArray2[0]["PLANIRANO"]), Conversions.ToDecimal(rowArray2[0]["IZVRSENO"]));
                    this.sintetika.Text = e.Cell.Value.ToString().Substring(0, 4);
                }
                else
                {
                    this.PLANIRANO.Value = 0;
                    this.IZVRSENO.Value = 0;
                    this.razlika.Value = 0;
                    this.sintetika.Text = "";
                }
                DataRow[] rowArray = this.KontoDataSet1.KONTO.Select("IDKONTO = '" + e.Cell.Value.ToString() + "'");
                if (rowArray.Length == 0)
                {
                    this.drv["idpartner"] = DBNull.Value;
                    this.drv["GKDATUMVALUTE"] = DBNull.Value;
                }
                else if ((Conversions.ToInteger(rowArray[0]["IDAKTIVNOST"]) == 2) | (Conversions.ToInteger(rowArray[0]["IDAKTIVNOST"]) == 3))
                {
                    if (this.drv == null)
                    {
                        if (this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].Position == -1)
                        {
                            return;
                        }
                        this.drv = (DataRowView) this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].Current;
                    }
                    this.drv["idpartner"] = RuntimeHelpers.GetObjectValue(this.UraControlerfORM.DataSet.URA.Rows[0]["URAPARTNERIDPARTNER"]);
                    this.drv["GKDATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.UraControlerfORM.DataSet.URA.Rows[0]["uravaluta"]);
                }
                else
                {
                    this.drv["idpartner"] = DBNull.Value;
                    this.drv["GKDATUMVALUTE"] = DBNull.Value;
                }
            }
            this.PostaviStatus();
        }

        private void UltraGrid1_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.UltraGrid1.ActiveCell.Column.Key == "IDKONTO")
            {
                this.UltraGrid1.ActiveCell.EditorResolved.DropDown();
            }
            if (this.UltraGrid1.ActiveCell.Column.Key == "IDORGJED")
            {
                this.UltraGrid1.ActiveCell.EditorResolved.DropDown();
            }
            if (this.UltraGrid1.ActiveCell.Column.Key == "IDMJESTOTROSKA")
            {
                this.UltraGrid1.ActiveCell.EditorResolved.DropDown();
            }
            if (this.UltraGrid1.ActiveCell.Column.Key == "duguje")
            {
                this.UltraGrid1.ActiveCell.SelectAll();
            }
            if (this.UltraGrid1.ActiveCell.Column.Key == "POTRAZUJE")
            {
                this.UltraGrid1.ActiveCell.SelectAll();
            }
            if (this.UltraGrid1.ActiveCell.Column.Key == "OPIS")
            {
                this.UltraGrid1.ActiveCell.SelectAll();
            }
        }

        private void UltraGrid1_AfterRowsDeleted(object sender, EventArgs e)
        {
            this.Spremi_Promjene();
            this.PostaviStatus();
            this.PLANIRANO.Value = 0;
            this.IZVRSENO.Value = 0;
            this.razlika.Value = 0;
            this.sintetika.Text = "";
        }

        private void UltraGrid1_AfterRowUpdate(object sender, RowEventArgs e)
        {
            this.Spremi_Promjene();
            this.PostaviStatus();
            this.PLANIRANO.Value = 0;
            this.IZVRSENO.Value = 0;
            this.razlika.Value = 0;
            this.sintetika.Text = "";
        }

        private void UltraGrid1_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if ((this.UltraGrid1.ActiveRow.Cells["ZATVORENIIZNOS"].Value != null) && (decimal.Compare(Conversions.ToDecimal(this.UltraGrid1.ActiveRow.Cells["ZATVORENIIZNOS"].Value), decimal.Zero) > 0))
            {
                e.Cancel = true;
            }
            else if ((this.UltraGrid1.ActiveRow.Cells["STATUSGK"].Value != null) && Conversions.ToBoolean(this.UltraGrid1.ActiveRow.Cells["STATUSGK"].Value))
            {
                e.Cancel = true;
            }
        }

        private void UltraGrid1_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
        }

        private void UltraGrid1_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (((UltraGrid) sender).ActiveCell.Column.Key == "IDKONTO")
            {
                Interaction.MsgBox("Ne postoji konto u kontnome planu", MsgBoxStyle.OkOnly, null);
                e.RaiseErrorEvent = false;
                e.StayInEditMode = true;
            }
            if (((UltraGrid) sender).ActiveCell.Column.Key == "IDMJESTOTROSKA")
            {
                Interaction.MsgBox("Ne postoji mjesto troška", MsgBoxStyle.OkOnly, null);
                e.RaiseErrorEvent = false;
                e.StayInEditMode = true;
            }
            if (((UltraGrid) sender).ActiveCell.Column.Key == "IDORGJED")
            {
                Interaction.MsgBox("Ne postoji organizacijska jedinica", MsgBoxStyle.OkOnly, null);
                e.RaiseErrorEvent = false;
                e.StayInEditMode = true;
            }
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((this.UltraGrid1.ActiveCell != null) && (((e.KeyCode == Keys.Tab) | (e.KeyCode == Keys.Return)) & (this.UltraGrid1.ActiveCell.Column.Key == "POTRAZUJE")))
            {
                this.Unos();
                e.Handled = true;
            }
        }

        public void Unos()
        {
            BindingSource bindingSource = this.UraControlerfORM.URAFormDefinition.GetBindingSource("URA");
            bindingSource.EndEdit();

            this.UraControlerfORM.Update(this.Parent.Parent);
            
            this.UltraGrid1.UpdateData();
            this.dagk.Update(this.GkstavkaDataSet1);


            this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].AddNew();
            this.drv = (DataRowView) this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].Current;
            if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0)
            {
                this.drv["datumdokumenta"] = RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Rows[this.GkstavkaDataSet1.GKSTAVKA.Rows.Count - 1]["DATUMDOKUMENTA"]);
                this.drv["brojdokumenta"] = RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Rows[this.GkstavkaDataSet1.GKSTAVKA.Rows.Count - 1]["BROJDOKUMENTA"]);
                this.drv["brojstavke"] = this.GkstavkaDataSet1.GKSTAVKA.Rows.Count + 1;
                this.drv["IDORGJED"] = RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Rows[this.GkstavkaDataSet1.GKSTAVKA.Rows.Count - 1]["IDORGJED"]);
                this.drv["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Rows[this.GkstavkaDataSet1.GKSTAVKA.Rows.Count - 1]["IDMJESTOTROSKA"]);
                this.drv["iddokument"] = RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Rows[this.GkstavkaDataSet1.GKSTAVKA.Rows.Count - 1]["IDDOKUMENT"]);
                this.drv["OPIS"] = RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Rows[this.GkstavkaDataSet1.GKSTAVKA.Rows.Count - 1]["OPIS"]);
                this.drv["zatvoreniiznos"] = 0;
                this.drv["statusgk"] = 0;
                decimal num = DB.N20(RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Compute("SUM(DUGUJE)", "")));
                decimal num2 = DB.N20(RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Compute("SUM(POTRAZUJE)", "")));
                if (decimal.Compare(Math.Abs(num), Math.Abs(num2)) > 0)
                {
                    if (decimal.Compare(num, decimal.Zero) < 0)
                    {
                        this.drv["potrazuje"] = decimal.Add(num2, num);
                        this.drv["DUGUJE"] = 0;
                    }
                    else
                    {
                        this.drv["potrazuje"] = decimal.Subtract(num, num2);
                        this.drv["DUGUJE"] = 0;
                    }
                }
                else if (decimal.Compare(num2, num) > 0)
                {
                    this.drv["potrazuje"] = 0;
                    this.drv["DUGUJE"] = decimal.Subtract(num2, num);
                }
                else if (decimal.Compare(num2, num) == 0)
                {
                    this.drv["potrazuje"] = 0;
                    this.drv["DUGUJE"] = 0;
                }
                this.drv["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[this.UltraGrid1.Rows.Count - 1];
                this.UltraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                this.UltraGrid1.PerformAction(UltraGridAction.ActivateCell);
                this.UltraGrid1.PerformAction(UltraGridAction.ActivateCell);
                this.UltraGrid1.PerformAction(UltraGridAction.EnterEditModeAndDropdown);
            }
            else
            {
                this.drv["datumdokumenta"] = RuntimeHelpers.GetObjectValue(this.UraControlerfORM.DataSet.URA.Rows[0]["URADATUM"]);
                this.drv["brojdokumenta"] = RuntimeHelpers.GetObjectValue(this.UraControlerfORM.DataSet.URA.Rows[0]["URABROJ"]);
                this.drv["brojstavke"] = this.GkstavkaDataSet1.GKSTAVKA.Rows.Count + 1;
                this.drv["iddokument"] = RuntimeHelpers.GetObjectValue(this.UraControlerfORM.DataSet.URA.Rows[0]["URADOKIDDOKUMENT"]);
                this.drv["OPIS"] = Strings.Left(this.UraControlerfORM.DataSet.URA.Rows[0]["URANAPOMENA"].ToString() + " " + this.UraControlerfORM.DataSet.URA.Rows[0]["URABROJRACUNADOBAVLJACA"].ToString() + " " + ((PARTNERComboBox) this.UraControlerfORM.URAFormDefinition.GetControl("combourapartnerIDPARTNER")).ComboBox.Text, 0x95);
                this.drv["zatvoreniiznos"] = 0;
                this.drv["statusgk"] = 0;
                this.drv["potrazuje"] = 0;
                this.drv["DUGUJE"] = RuntimeHelpers.GetObjectValue(this.UraControlerfORM.DataSet.URA.Rows[0]["URAUKUPNO"]);
                this.drv["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[this.UltraGrid1.Rows.Count - 1];
                this.UltraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                this.UltraGrid1.PerformAction(UltraGridAction.ActivateCell);
                this.UltraGrid1.PerformAction(UltraGridAction.EnterEditModeAndDropdown);
            }
            this.PostaviStatus();
        }

        private AutoHideControl _StavkeUreAutoHideControl;

        private UnpinnedTabArea _StavkeUreUnpinnedTabAreaBottom;

        private UnpinnedTabArea _StavkeUreUnpinnedTabAreaLeft;

        private UnpinnedTabArea _StavkeUreUnpinnedTabAreaRight;

        private UnpinnedTabArea _StavkeUreUnpinnedTabAreaTop;

        private DockableWindow DockableWindow1;

        private DockableWindow DockableWindow2;

        private GKSTAVKADataSet GkstavkaDataSet1;

        private ImageList ImageList1;

        private UltraNumericEditor IZVRSENO;

        private UltraDropDown KONTO;

        private KONTODataSet KontoDataSet1;

        private MJESTOTROSKADataSet MjestotroskaDataSet1;

        private UltraDropDown MT;

        private UltraDropDown OJ;

        private ORGJEDDataSet OrgjedDataSet1;

        private Panel Panel1;

        private Panel Panel2;

        private UltraNumericEditor PLANIRANO;

        private UltraNumericEditor razlika;

        private S_FIN_IZVRSENJE_PLANADataSet S_FIN_IZVRSENJE_PLANADataSet1;

        private UltraTextEditor sintetika;

        private ToolBar ToolBar1;

        private ToolBarButton ToolBarButton1;

        private ToolBarButton ToolBarButton2;

        private ToolBarButton ToolBarButton3;

        private ToolBarButton ToolBarButton4;

        public UltraDockManager UltraDockManager1;

        private UltraGrid UltraGrid1;

        private UltraLabel UltraLabel1;

        private UltraLabel UltraLabel2;

        private UltraLabel UltraLabel3;

        private UltraLabel UltraLabel4;

        [CreateNew, Browsable(true)]
        public URAController UraControlerfORM { get; set; }

        private WindowDockingArea WindowDockingArea1;

        private WindowDockingArea WindowDockingArea2;
    }
}

