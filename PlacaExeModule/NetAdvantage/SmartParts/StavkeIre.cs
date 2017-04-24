namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI.Workspaces;
    using Hlp;
    using Infragistics.Win;
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
    using mipsed.application.framework;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using NetAdvantage.WorkItems;

    public class StavkeIre : UserControl
    {
        [AccessedThroughProperty("_StavkeUreAutoHideControl")]
        private AutoHideControl __StavkeUreAutoHideControl;
        [AccessedThroughProperty("_StavkeUreUnpinnedTabAreaBottom")]
        private UnpinnedTabArea __StavkeUreUnpinnedTabAreaBottom;
        [AccessedThroughProperty("_StavkeUreUnpinnedTabAreaLeft")]
        private UnpinnedTabArea __StavkeUreUnpinnedTabAreaLeft;
        [AccessedThroughProperty("_StavkeUreUnpinnedTabAreaRight")]
        private UnpinnedTabArea __StavkeUreUnpinnedTabAreaRight;
        [AccessedThroughProperty("_StavkeUreUnpinnedTabAreaTop")]
        private UnpinnedTabArea __StavkeUreUnpinnedTabAreaTop;
        [AccessedThroughProperty("DockableWindow1")]
        private DockableWindow _DockableWindow1;
        [AccessedThroughProperty("DockableWindow2")]
        private DockableWindow _DockableWindow2;
        [AccessedThroughProperty("GkstavkaDataSet1")]
        private GKSTAVKADataSet _GkstavkaDataSet1;
        [AccessedThroughProperty("ImageList1")]
        private ImageList _ImageList1;
        [AccessedThroughProperty("KONTO")]
        private UltraDropDown _KONTO;
        [AccessedThroughProperty("KontoDataSet1")]
        private KONTODataSet _KontoDataSet1;
        [AccessedThroughProperty("m_cm")]
        private CurrencyManager _m_cm;
        [AccessedThroughProperty("MjestotroskaDataSet1")]
        private MJESTOTROSKADataSet _MjestotroskaDataSet1;
        [AccessedThroughProperty("MT")]
        private UltraDropDown _MT;
        [AccessedThroughProperty("OJ")]
        private UltraDropDown _OJ;
        [AccessedThroughProperty("OrgjedDataSet1")]
        private ORGJEDDataSet _OrgjedDataSet1;
        [AccessedThroughProperty("Panel1")]
        private Panel _Panel1;
        [AccessedThroughProperty("Panel2")]
        private Panel _Panel2;
        [AccessedThroughProperty("ToolBar1")]
        private ToolBar _ToolBar1;
        [AccessedThroughProperty("ToolBarButton1")]
        private ToolBarButton _ToolBarButton1;

        #region MBS.Complete
        [AccessedThroughProperty("ToolBarButtonKontiranje")]
        private ToolBarButton _ToolBarButtonKontiranje;
        #endregion

        [AccessedThroughProperty("ToolBarButton2")]
        private ToolBarButton _ToolBarButton2;
        [AccessedThroughProperty("ToolBarButton4")]
        private ToolBarButton _ToolBarButton4;
        [AccessedThroughProperty("UltraDockManager1")]
        private UltraDockManager _UltraDockManager1;
        [AccessedThroughProperty("UltraGrid1")]
        private UltraGrid _UltraGrid1;
        [AccessedThroughProperty("WindowDockingArea1")]
        private WindowDockingArea _WindowDockingArea1;
        [AccessedThroughProperty("WindowDockingArea2")]
        private WindowDockingArea _WindowDockingArea2;
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

        public StavkeIre()
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
                            current.Delete();
                            this.Spremi_Promjene();
                            this.GkstavkaDataSet1.Clear();
                            this.dagk.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(this.GkstavkaDataSet1, Conversions.ToInteger(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRADOKIDDOKUMENT"]), Conversions.ToInteger(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRABROJ"]), mipsed.application.framework.Application.ActiveYear);
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
            this.dagk.Update(this.GkstavkaDataSet1);
            this.ProvjerePrijeSpremanja();
            ExtendedWindowWorkspace workspace = (ExtendedWindowWorkspace) sender;
            if (workspace.ActiveSmartPart.ToString() == "NetAdvantage.SmartParts.PARTNERFormUserControl")
            {
                e.Cancel = false;
            }
            else
            {
                if (workspace.ActiveSmartPart.ToString() == "NetAdvantage.SmartParts.IRAFormUserControl")
                {
                    IRAFormUserControl activeSmartPart = (IRAFormUserControl) workspace.ActiveSmartPart;
                    if (activeSmartPart.ParentForm.DialogResult == DialogResult.Cancel)
                    {
                        e.Cancel = false;
                        ((ExtendedWindowWorkspace) this.IraControlerfORM.WorkItem.Workspaces.Get("window")).SmartPartClosing -= new EventHandler<WorkspaceCancelEventArgs>(this.Closing);
                        return;
                    }
                }
                if (workspace.ActiveSmartPart.ToString() == "NetAdvantage.SmartParts.PARTNERWorkWith")
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
                            ((ExtendedWindowWorkspace) this.IraControlerfORM.WorkItem.Workspaces.Get("window")).SmartPartClosing -= new EventHandler<WorkspaceCancelEventArgs>(this.Closing);
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        ((ExtendedWindowWorkspace) this.IraControlerfORM.WorkItem.Workspaces.Get("window")).SmartPartClosing -= new EventHandler<WorkspaceCancelEventArgs>(this.Closing);
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
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(StavkeIre));
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("GKSTAVKA", -1);
            UltraGridColumn column = new UltraGridColumn("IDGKSTAVKA");
            UltraGridColumn column12 = new UltraGridColumn("IDAKTIVNOST");
            UltraGridColumn column23 = new UltraGridColumn("DATUMDOKUMENTA");
            UltraGridColumn column31 = new UltraGridColumn("BROJDOKUMENTA");
            UltraGridColumn column32 = new UltraGridColumn("BROJSTAVKE");
            UltraGridColumn column33 = new UltraGridColumn("IDDOKUMENT");
            UltraGridColumn column34 = new UltraGridColumn("NAZIVDOKUMENT");
            UltraGridColumn column35 = new UltraGridColumn("IDMJESTOTROSKA", -1, "MT");
            UltraGridColumn column36 = new UltraGridColumn("NAZIVMJESTOTROSKA");
            UltraGridColumn column2 = new UltraGridColumn("IDORGJED", -1, "OJ");
            UltraGridColumn column3 = new UltraGridColumn("NAZIVORGJED");
            UltraGridColumn column4 = new UltraGridColumn("IDKONTO", -1, "KONTO");
            UltraGridColumn column5 = new UltraGridColumn("NAZIVKONTO");
            UltraGridColumn column6 = new UltraGridColumn("NAZIVAKTIVNOST");
            UltraGridColumn column7 = new UltraGridColumn("OPIS");
            UltraGridColumn column8 = new UltraGridColumn("duguje");
            UltraGridColumn column9 = new UltraGridColumn("POTRAZUJE");
            UltraGridColumn column10 = new UltraGridColumn("DATUMPRIJAVE");
            UltraGridColumn column11 = new UltraGridColumn("IDPARTNER");
            UltraGridColumn column13 = new UltraGridColumn("NAZIVPARTNER");
            UltraGridColumn column14 = new UltraGridColumn("ZATVORENIIZNOS");
            UltraGridColumn column15 = new UltraGridColumn("GKDATUMVALUTE");
            UltraGridColumn column16 = new UltraGridColumn("statusgk");
            UltraGridColumn column17 = new UltraGridColumn("ORIGINALNIDOKUMENT");
            UltraGridColumn column18 = new UltraGridColumn("GKGODIDGODINE");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            UltraGridBand band2 = new UltraGridBand("KONTO", -1);
            UltraGridColumn column19 = new UltraGridColumn("IDKONTO");
            UltraGridColumn column20 = new UltraGridColumn("NAZIVKONTO");
            UltraGridColumn column21 = new UltraGridColumn("IDAKTIVNOST");
            UltraGridColumn column22 = new UltraGridColumn("NAZIVAKTIVNOST");
            UltraGridColumn column24 = new UltraGridColumn("KONT");
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            UltraGridBand band3 = new UltraGridBand("MJESTOTROSKA", -1);
            UltraGridColumn column25 = new UltraGridColumn("IDMJESTOTROSKA");
            UltraGridColumn column26 = new UltraGridColumn("NAZIVMJESTOTROSKA");
            UltraGridColumn column27 = new UltraGridColumn("mt");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            UltraGridBand band4 = new UltraGridBand("ORGJED", -1);
            UltraGridColumn column28 = new UltraGridColumn("IDORGJED");
            UltraGridColumn column29 = new UltraGridColumn("NAZIVORGJED");
            UltraGridColumn column30 = new UltraGridColumn("oj");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Guid internalId = new Guid("d8ff4695-09eb-4541-9eaa-de2d94b0cbed");
            DockAreaPane pane3 = new DockAreaPane(DockedLocation.DockedTop, internalId);
            internalId = new Guid("b3d2da6f-682c-44d3-9598-b9bca26e00e0");
            Guid floatingParentId = new Guid("00000000-0000-0000-0000-000000000000");
            Guid dockedParentId = new Guid("d8ff4695-09eb-4541-9eaa-de2d94b0cbed");
            DockableControlPane pane = new DockableControlPane(internalId, floatingParentId, -1, dockedParentId, -1);
            dockedParentId = new Guid("37aee908-76f3-4136-a3bc-c8ee56a4964f");
            DockAreaPane pane4 = new DockAreaPane(DockedLocation.DockedTop, dockedParentId);
            dockedParentId = new Guid("4e078597-d3d2-46b1-926e-7e88320782ae");
            floatingParentId = new Guid("00000000-0000-0000-0000-000000000000");
            internalId = new Guid("37aee908-76f3-4136-a3bc-c8ee56a4964f");
            DockableControlPane pane2 = new DockableControlPane(dockedParentId, floatingParentId, -1, internalId, -1);
            this.Panel1 = new Panel();
            this.ToolBar1 = new ToolBar();
            this.ToolBarButton1 = new ToolBarButton();

            #region MBS.Complete
            this.ToolBarButtonKontiranje = new ToolBarButton();
            #endregion

            this.ToolBarButton2 = new ToolBarButton();
            this.ToolBarButton4 = new ToolBarButton();
            this.ImageList1 = new ImageList(this.components);
            this.Panel2 = new Panel();
            this.UltraGrid1 = new UltraGrid();
            this.GkstavkaDataSet1 = new GKSTAVKADataSet();
            this.KONTO = new UltraDropDown();
            this.KontoDataSet1 = new KONTODataSet();
            this.MT = new UltraDropDown();
            this.MjestotroskaDataSet1 = new MJESTOTROSKADataSet();
            this.OJ = new UltraDropDown();
            this.OrgjedDataSet1 = new ORGJEDDataSet();
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._StavkeUreUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._StavkeUreUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._StavkeUreUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._StavkeUreUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._StavkeUreAutoHideControl = new AutoHideControl();
            this.WindowDockingArea1 = new WindowDockingArea();
            this.DockableWindow1 = new DockableWindow();
            this.WindowDockingArea2 = new WindowDockingArea();
            this.DockableWindow2 = new DockableWindow();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((ISupportInitialize) this.UltraGrid1).BeginInit();
            this.GkstavkaDataSet1.BeginInit();
            ((ISupportInitialize) this.KONTO).BeginInit();
            this.KontoDataSet1.BeginInit();
            ((ISupportInitialize) this.MT).BeginInit();
            this.MjestotroskaDataSet1.BeginInit();
            ((ISupportInitialize) this.OJ).BeginInit();
            this.OrgjedDataSet1.BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.WindowDockingArea2.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.SuspendLayout();
            this.Panel1.Controls.Add(this.ToolBar1);
            System.Drawing.Point point = new System.Drawing.Point(0, 0x12);
            this.Panel1.Location = point;
            this.Panel1.Name = "Panel1";
            Size size = new System.Drawing.Size(0x4ed, 0x3f);
            this.Panel1.Size = size;
            this.Panel1.TabIndex = 15;
            this.ToolBar1.Buttons.AddRange(new ToolBarButton[] { this.ToolBarButton1, this.ToolBarButton2, this.ToolBarButton4, ToolBarButtonKontiranje });
            size = new System.Drawing.Size(0x20, 0x20);
            this.ToolBar1.ButtonSize = size;
            this.ToolBar1.Dock = DockStyle.Fill;
            this.ToolBar1.DropDownArrows = true;
            this.ToolBar1.Font = new System.Drawing.Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0xee);
            this.ToolBar1.ImageList = this.ImageList1;
            point = new System.Drawing.Point(0, 0);
            this.ToolBar1.Location = point;
            size = new System.Drawing.Size(0, 60);
            this.ToolBar1.MinimumSize = size;
            this.ToolBar1.Name = "ToolBar1";
            this.ToolBar1.ShowToolTips = true;
            size = new System.Drawing.Size(0x4ed, 60);
            this.ToolBar1.Size = size;
            this.ToolBar1.TabIndex = 14;
            this.ToolBarButton1.ImageIndex = 1;
            this.ToolBarButton1.Name = "ToolBarButton1";
            this.ToolBarButton1.Text = "Unesi stavku";

            #region MBS.Complete
            this.ToolBarButtonKontiranje.ImageIndex = 6;
            this.ToolBarButtonKontiranje.Name = "ToolBarButtonKontiranje";
            this.ToolBarButtonKontiranje.Text = "Kontiranje po shemi";
            #endregion

            this.ToolBarButton2.ImageIndex = 2;
            this.ToolBarButton2.Name = "ToolBarButton2";
            this.ToolBarButton2.Text = "Briši stavku";
            this.ToolBarButton4.ImageIndex = 3;
            this.ToolBarButton4.Name = "ToolBarButton4";
            this.ToolBarButton4.Text = "Proknjiži";
            this.ImageList1.ImageStream = (ImageListStreamer) manager.GetObject("ImageList1.ImageStream");
            this.ImageList1.TransparentColor = Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "spoi.png");
            this.ImageList1.Images.SetKeyName(1, "add.png");
            this.ImageList1.Images.SetKeyName(2, "delete.png");
            this.ImageList1.Images.SetKeyName(3, "knizi.png");
            this.ImageList1.Images.SetKeyName(4, "otvorene.png");
            this.ImageList1.Images.SetKeyName(5, "printer.png");
            this.ImageList1.Images.SetKeyName(6, "renum.png");
            this.ImageList1.Images.SetKeyName(7, "Edit32.png");
            this.Panel2.Controls.Add(this.UltraGrid1);
            point = new System.Drawing.Point(0, 0x12);
            this.Panel2.Location = point;
            this.Panel2.Name = "Panel2";
            size = new System.Drawing.Size(0x4ed, 0x102);
            this.Panel2.Size = size;
            this.Panel2.TabIndex = 0x16;
            this.UltraGrid1.DataMember = "GKSTAVKA";
            this.UltraGrid1.DataSource = this.GkstavkaDataSet1;
            appearance12.BackColor = Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance12;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.CellActivation = Activation.Disabled;
            column.Header.VisiblePosition = 10;
            column.Hidden = true;
            column12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column12.CellActivation = Activation.Disabled;
            column12.Header.VisiblePosition = 11;
            column12.Hidden = true;
            column23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column23.CellActivation = Activation.Disabled;
            column23.Header.VisiblePosition = 12;
            column23.Hidden = true;
            column31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column31.CellActivation = Activation.Disabled;
            column31.Header.VisiblePosition = 13;
            column31.Hidden = true;
            column32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column32.CellActivation = Activation.Disabled;
            column32.Header.VisiblePosition = 14;
            column33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column33.CellActivation = Activation.Disabled;
            column33.Header.VisiblePosition = 15;
            column33.Hidden = true;
            column34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column34.CellActivation = Activation.Disabled;
            column34.Header.VisiblePosition = 0x10;
            column34.Hidden = true;
            column35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column35.Header.VisiblePosition = 1;
            column35.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            column36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column36.CellActivation = Activation.Disabled;
            column36.Header.VisiblePosition = 8;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column2.Header.VisiblePosition = 0;
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            column2.Width = 0x3d;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column3.CellActivation = Activation.Disabled;
            column3.Header.VisiblePosition = 7;
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column4.Header.VisiblePosition = 2;
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            column4.Width = 0x5d;
            column5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column5.CellActivation = Activation.Disabled;
            column5.Header.VisiblePosition = 9;
            column6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column6.CellActivation = Activation.Disabled;
            column6.Header.VisiblePosition = 0x11;
            column7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column7.Header.Caption = "Opis";
            column7.Header.VisiblePosition = 3;
            column7.Width = 0xce;
            column8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column8.Header.Caption = "Duguje";
            column8.Header.VisiblePosition = 4;
            column8.MaskInput = "-nnnnnnnnn.nn";
            column9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column9.Header.Caption = "Potražuje";
            column9.Header.VisiblePosition = 5;
            column9.MaskInput = "-nnnnnnnnn.nn";
            column10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column10.CellActivation = Activation.NoEdit;
            column10.Header.VisiblePosition = 0x12;
            column11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column11.Header.VisiblePosition = 0x13;
            column13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column13.CellActivation = Activation.NoEdit;
            column13.Header.VisiblePosition = 20;
            column14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column14.CellActivation = Activation.Disabled;
            column14.Header.Caption = "Zatvoreno";
            column14.Header.VisiblePosition = 6;
            column14.MaskInput = "nnnnnnnnn.nn";
            column15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column15.CellActivation = Activation.Disabled;
            column15.Header.VisiblePosition = 0x15;
            column16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column16.CellActivation = Activation.Disabled;
            column16.Header.VisiblePosition = 0x16;
            column17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column17.CellActivation = Activation.Disabled;
            column17.Header.VisiblePosition = 0x17;
            column18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column18.CellActivation = Activation.Disabled;
            column18.Header.VisiblePosition = 0x18;
            band.Columns.AddRange(new object[] { 
                column, column12, column23, column31, column32, column33, column34, column35, column36, column2, column3, column4, column5, column6, column7, column8, 
                column9, column10, column11, column13, column14, column15, column16, column17, column18
             });
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance13.BackColor = Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance13;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance14.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance14;
            appearance15.BorderColor = Color.LightGray;
            appearance15.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance15;
            this.UltraGrid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
            appearance16.BackColor = Color.LightSteelBlue;
            appearance16.BorderColor = Color.Black;
            appearance16.ForeColor = Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance16;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.UltraGrid1.Dock = DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this.UltraGrid1.Location = point;
            this.UltraGrid1.Name = "UltraGrid1";
            size = new System.Drawing.Size(0x4ed, 0x102);
            this.UltraGrid1.Size = size;
            this.UltraGrid1.TabIndex = 10;
            this.UltraGrid1.UseAppStyling = false;
            this.GkstavkaDataSet1.DataSetName = "GKSTAVKADataSet";
            this.KONTO.DataMember = "KONTO";
            this.KONTO.DataSource = this.KontoDataSet1;
            appearance17.BackColor = Color.White;
            this.KONTO.DisplayLayout.Appearance = appearance17;
            column19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column19.Header.VisiblePosition = 0;
            column19.RowLayoutColumnInfo.OriginX = 0;
            column19.RowLayoutColumnInfo.OriginY = 0;
            size = new System.Drawing.Size(0x87, 0);
            column19.RowLayoutColumnInfo.PreferredCellSize = size;
            column19.RowLayoutColumnInfo.SpanX = 2;
            column19.RowLayoutColumnInfo.SpanY = 2;
            column20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column20.Header.VisiblePosition = 1;
            column20.RowLayoutColumnInfo.OriginX = 2;
            column20.RowLayoutColumnInfo.OriginY = 0;
            size = new System.Drawing.Size(0x17e, 0);
            column20.RowLayoutColumnInfo.PreferredCellSize = size;
            column20.RowLayoutColumnInfo.SpanX = 3;
            column20.RowLayoutColumnInfo.SpanY = 2;
            column21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column21.Header.VisiblePosition = 2;
            column21.Hidden = true;
            column22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column22.Header.VisiblePosition = 3;
            column22.RowLayoutColumnInfo.OriginX = 5;
            column22.RowLayoutColumnInfo.OriginY = 0;
            column22.RowLayoutColumnInfo.SpanX = 2;
            column22.RowLayoutColumnInfo.SpanY = 2;
            column24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column24.Header.VisiblePosition = 4;
            band2.Columns.AddRange(new object[] { column19, column20, column21, column22, column24 });
            band2.UseRowLayout = true;
            this.KONTO.DisplayLayout.BandsSerializer.Add(band2);
            this.KONTO.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance18.BackColor = Color.Transparent;
            this.KONTO.DisplayLayout.Override.CardAreaAppearance = appearance18;
            this.KONTO.DisplayLayout.Override.CellPadding = 3;
            appearance19.TextHAlignAsString = "Left";
            this.KONTO.DisplayLayout.Override.HeaderAppearance = appearance19;
            appearance20.BorderColor = Color.LightGray;
            appearance20.TextVAlignAsString = "Middle";
            this.KONTO.DisplayLayout.Override.RowAppearance = appearance20;
            this.KONTO.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance.BackColor = Color.LightSteelBlue;
            appearance.BorderColor = Color.Black;
            appearance.ForeColor = Color.Black;
            this.KONTO.DisplayLayout.Override.SelectedRowAppearance = appearance;
            this.KONTO.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            point = new System.Drawing.Point(0x193, 0x123);
            this.KONTO.Location = point;
            this.KONTO.Name = "KONTO";
            size = new System.Drawing.Size(160, 80);
            this.KONTO.Size = size;
            this.KONTO.TabIndex = 13;
            this.KONTO.ValueMember = "IDKONTO";
            this.KONTO.Visible = false;
            this.KontoDataSet1.DataSetName = "KONTODataSet";
            this.MT.DataMember = "MJESTOTROSKA";
            this.MT.DataSource = this.MjestotroskaDataSet1;
            appearance2.BackColor = Color.White;
            this.MT.DisplayLayout.Appearance = appearance2;
            column25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column25.Header.VisiblePosition = 0;
            size = new System.Drawing.Size(0x88, 0);
            column25.RowLayoutColumnInfo.PreferredCellSize = size;
            column26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column26.Header.VisiblePosition = 1;
            size = new System.Drawing.Size(0x1a7, 0);
            column26.RowLayoutColumnInfo.PreferredCellSize = size;
            column27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column27.Header.VisiblePosition = 2;
            band3.Columns.AddRange(new object[] { column25, column26, column27 });
            band3.UseRowLayout = true;
            this.MT.DisplayLayout.BandsSerializer.Add(band3);
            this.MT.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance3.BackColor = Color.Transparent;
            this.MT.DisplayLayout.Override.CardAreaAppearance = appearance3;
            this.MT.DisplayLayout.Override.CellPadding = 3;
            appearance4.TextHAlignAsString = "Left";
            this.MT.DisplayLayout.Override.HeaderAppearance = appearance4;
            appearance5.BorderColor = Color.LightGray;
            appearance5.TextVAlignAsString = "Middle";
            this.MT.DisplayLayout.Override.RowAppearance = appearance5;
            this.MT.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance6.BackColor = Color.LightSteelBlue;
            appearance6.BorderColor = Color.Black;
            appearance6.ForeColor = Color.Black;
            this.MT.DisplayLayout.Override.SelectedRowAppearance = appearance6;
            this.MT.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            point = new System.Drawing.Point(0xc5, 0x123);
            this.MT.Location = point;
            this.MT.Name = "MT";
            size = new System.Drawing.Size(160, 80);
            this.MT.Size = size;
            this.MT.TabIndex = 12;
            this.MT.ValueMember = "IDMJESTOTROSKA";
            this.MT.Visible = false;
            this.MjestotroskaDataSet1.DataSetName = "MJESTOTROSKADataSet";
            this.OJ.DataMember = "ORGJED";
            this.OJ.DataSource = this.OrgjedDataSet1;
            appearance7.BackColor = Color.White;
            this.OJ.DisplayLayout.Appearance = appearance7;
            column28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column28.Header.VisiblePosition = 0;
            column28.RowLayoutColumnInfo.OriginX = 0;
            column28.RowLayoutColumnInfo.OriginY = 0;
            size = new System.Drawing.Size(0x8e, 0);
            column28.RowLayoutColumnInfo.PreferredCellSize = size;
            column28.RowLayoutColumnInfo.SpanX = 3;
            column28.RowLayoutColumnInfo.SpanY = 2;
            column29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column29.Header.VisiblePosition = 1;
            column29.RowLayoutColumnInfo.OriginX = 3;
            column29.RowLayoutColumnInfo.OriginY = 0;
            size = new System.Drawing.Size(420, 0);
            column29.RowLayoutColumnInfo.PreferredCellSize = size;
            column29.RowLayoutColumnInfo.SpanX = 10;
            column29.RowLayoutColumnInfo.SpanY = 2;
            column30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column30.Header.VisiblePosition = 2;
            band4.Columns.AddRange(new object[] { column28, column29, column30 });
            band4.UseRowLayout = true;
            this.OJ.DisplayLayout.BandsSerializer.Add(band4);
            this.OJ.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance8.BackColor = Color.Transparent;
            this.OJ.DisplayLayout.Override.CardAreaAppearance = appearance8;
            this.OJ.DisplayLayout.Override.CellPadding = 3;
            appearance9.TextHAlignAsString = "Left";
            this.OJ.DisplayLayout.Override.HeaderAppearance = appearance9;
            appearance10.BorderColor = Color.LightGray;
            appearance10.TextVAlignAsString = "Middle";
            this.OJ.DisplayLayout.Override.RowAppearance = appearance10;
            this.OJ.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance11.BackColor = Color.LightSteelBlue;
            appearance11.BorderColor = Color.Black;
            appearance11.ForeColor = Color.Black;
            this.OJ.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.OJ.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            point = new System.Drawing.Point(0x12, 0x123);
            this.OJ.Location = point;
            this.OJ.Name = "OJ";
            size = new System.Drawing.Size(160, 80);
            this.OJ.Size = size;
            this.OJ.TabIndex = 11;
            this.OJ.ValueMember = "IDORGJED";
            this.OJ.Visible = false;
            this.OrgjedDataSet1.DataSetName = "ORGJEDDataSet";
            dockedParentId = new Guid("37aee908-76f3-4136-a3bc-c8ee56a4964f");
            pane3.DockedBefore = dockedParentId;
            pane.Control = this.Panel1;
            Rectangle rectangle = new Rectangle(0x9a, 0x31, 0x375, 0x41);
            pane.OriginalControlBounds = rectangle;
            size = new System.Drawing.Size(100, 100);
            pane.Size = size;
            pane.Text = "Rad sa stavkama IRE";
            pane3.Panes.AddRange(new DockablePaneBase[] { pane });
            size = new System.Drawing.Size(0x4ed, 0x51);
            pane3.Size = size;
            pane2.Control = this.Panel2;
            rectangle = new Rectangle(0x19c, 0x66, 0x2b9, 0xea);
            pane2.OriginalControlBounds = rectangle;
            size = new System.Drawing.Size(100, 100);
            pane2.Size = size;
            pane2.Text = "Stavke IRE";
            pane4.Panes.AddRange(new DockablePaneBase[] { pane2 });
            size = new System.Drawing.Size(0x4ed, 0x114);
            pane4.Size = size;
            this.UltraDockManager1.DockAreas.AddRange(new DockAreaPane[] { pane3, pane4 });
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.WindowStyle = WindowStyle.Office2007;
            this._StavkeUreUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._StavkeUreUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._StavkeUreUnpinnedTabAreaLeft.Location = point;
            this._StavkeUreUnpinnedTabAreaLeft.Name = "_StavkeUreUnpinnedTabAreaLeft";
            this._StavkeUreUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 0x17d);
            this._StavkeUreUnpinnedTabAreaLeft.Size = size;
            this._StavkeUreUnpinnedTabAreaLeft.TabIndex = 0x10;
            this._StavkeUreUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._StavkeUreUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x4ed, 0);
            this._StavkeUreUnpinnedTabAreaRight.Location = point;
            this._StavkeUreUnpinnedTabAreaRight.Name = "_StavkeUreUnpinnedTabAreaRight";
            this._StavkeUreUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 0x17d);
            this._StavkeUreUnpinnedTabAreaRight.Size = size;
            this._StavkeUreUnpinnedTabAreaRight.TabIndex = 0x11;
            this._StavkeUreUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._StavkeUreUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._StavkeUreUnpinnedTabAreaTop.Location = point;
            this._StavkeUreUnpinnedTabAreaTop.Name = "_StavkeUreUnpinnedTabAreaTop";
            this._StavkeUreUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x4ed, 0);
            this._StavkeUreUnpinnedTabAreaTop.Size = size;
            this._StavkeUreUnpinnedTabAreaTop.TabIndex = 0x12;
            this._StavkeUreUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._StavkeUreUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0x17d);
            this._StavkeUreUnpinnedTabAreaBottom.Location = point;
            this._StavkeUreUnpinnedTabAreaBottom.Name = "_StavkeUreUnpinnedTabAreaBottom";
            this._StavkeUreUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x4ed, 0);
            this._StavkeUreUnpinnedTabAreaBottom.Size = size;
            this._StavkeUreUnpinnedTabAreaBottom.TabIndex = 0x13;
            this._StavkeUreAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._StavkeUreAutoHideControl.Location = point;
            this._StavkeUreAutoHideControl.Name = "_StavkeUreAutoHideControl";
            this._StavkeUreAutoHideControl.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 0x17d);
            this._StavkeUreAutoHideControl.Size = size;
            this._StavkeUreAutoHideControl.TabIndex = 20;
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Location = point;
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x4ed, 0x56);
            this.WindowDockingArea1.Size = size;
            this.WindowDockingArea1.TabIndex = 0x15;
            this.DockableWindow1.Controls.Add(this.Panel1);
            point = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Location = point;
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x4ed, 0x51);
            this.DockableWindow1.Size = size;
            this.DockableWindow1.TabIndex = 0x18;
            this.WindowDockingArea2.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea2.Dock = DockStyle.Top;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0x56);
            this.WindowDockingArea2.Location = point;
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x4ed, 0x119);
            this.WindowDockingArea2.Size = size;
            this.WindowDockingArea2.TabIndex = 0x17;
            this.DockableWindow2.Controls.Add(this.Panel2);
            point = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Location = point;
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x4ed, 0x114);
            this.DockableWindow2.Size = size;
            this.DockableWindow2.TabIndex = 0x19;
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
            this.Name = "StavkeIre";
            size = new System.Drawing.Size(0x4ed, 0x17d);
            this.Size = size;
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            ((ISupportInitialize) this.UltraGrid1).EndInit();
            this.GkstavkaDataSet1.EndInit();
            ((ISupportInitialize) this.KONTO).EndInit();
            this.KontoDataSet1.EndInit();
            ((ISupportInitialize) this.MT).EndInit();
            this.MjestotroskaDataSet1.EndInit();
            ((ISupportInitialize) this.OJ).EndInit();
            this.OrgjedDataSet1.EndInit();
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.WindowDockingArea2.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
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
                if (Conversions.ToInteger(this.KONTO.SelectedRow.Cells["idaktivnost"].Value) == 3)
                {
                    current["idpartner"] = RuntimeHelpers.GetObjectValue(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRAPARTNERIDPARTNER"]);
                    current["GKDATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRAvaluta"]);
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
            this.cmboPARTNER = (PARTNERComboBox)this.IraControlerfORM.IRAFormDefinition.GetControl("comboirapartnerIDPARTNER");

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
                    if (Conversions.ToInteger(current["idaktivnost"]) == 3)
                    {
                        current["GKDATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.ds.Tables[0].Rows[0]["IRAvaluta"]);
                        current["idpartner"] = RuntimeHelpers.GetObjectValue(this.cmboPARTNER.SelectedItem.DataValue);
                    }
                    else
                    {
                        current["GKDATUMVALUTE"] = DBNull.Value;
                        current["idpartner"] = DBNull.Value;
                    }
                    current["DATUMDOKUMENTA"] = RuntimeHelpers.GetObjectValue(((UltraDateTimeEditor) this.IraControlerfORM.IRAFormDefinition.GetControl("DATEPICKERiraDATUM")).Value);
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
            this.IraControlerfORM.IRAFormDefinition.GetControl("TEXTIRAbroj").Visible = true;
            DOKUMENTComboBox control = (DOKUMENTComboBox) this.IraControlerfORM.IRAFormDefinition.GetControl("comboIRADOKIDDOKUMENT");
            control.ComboBox.Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textIRAGODIDGODINE").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("label1IRAGODIDGODINE").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("label1IRADOKIDDOKUMENT").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("label1IRABROJ").Visible = true;
            ((UltraNumericEditor) this.IraControlerfORM.IRAFormDefinition.GetControl("textIRABROJ")).Enabled = true;
            ((UltraDateTimeEditor) this.IraControlerfORM.IRAFormDefinition.GetControl("DATEPICKERiraDATUM")).MinDate = mipsed.application.framework.Application.Pocetni;
            ((UltraDateTimeEditor)this.IraControlerfORM.IRAFormDefinition.GetControl("DATEPICKERiraDATUM")).MaxDate = mipsed.application.framework.Application.Zavrsni;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textIRAGODIDGODINE").TabIndex = 0;
            this.IraControlerfORM.IRAFormDefinition.GetControl("comboIRADOKIDDOKUMENT").TabIndex = 1;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textIRABROJ").TabIndex = 2;
            this.IraControlerfORM.IRAFormDefinition.GetControl("comboIRApartnerIDPARTNER").TabIndex = 3;
            this.IraControlerfORM.IRAFormDefinition.GetControl("datePickerIRADATUM").TabIndex = 4;
            this.IraControlerfORM.IRAFormDefinition.GetControl("datePickerIRAVALUTA").TabIndex = 5;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textIRANAPOMENA").TabIndex = 6;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textIRAUKUPNO").TabIndex = 7;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textNEPODLEZE").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("label1NEPODLEZE").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textNEPODLEZE").Enabled = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textIDTIPIRA").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("label1IDTIPIRA").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textIDTIPIRA").Enabled = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textIZVOZ").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("label1IZVOZ").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textIZVOZ").Enabled = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textOSTALO").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("label1OSTALO").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textOSTALO").Enabled = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textMEDJTRANS").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("label1MEDJTRANS").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textMEDJTRANS").Enabled = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textTUZEMSTVO").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("label1TUZEMSTVO").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textTUZEMSTVO").Enabled = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("textNULA").Visible = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("label1NULA").Visible = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("textNULA").Enabled = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textOSN10").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("label1OSN10").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textOSN10").Enabled = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("textOSN22").Visible = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("label1OSN22").Visible = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("textOSN22").Enabled = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("textOSN23").Visible = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("label1OSN23").Visible = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("textOSN23").Enabled = true;

            this.IraControlerfORM.IRAFormDefinition.GetControl("label1OSN25").Visible = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("textOSN25").Enabled = true;

            this.IraControlerfORM.IRAFormDefinition.GetControl("textPDV10").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("label1PDV10").Visible = true;
            this.IraControlerfORM.IRAFormDefinition.GetControl("textPDV10").Enabled = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("textPDV22").Visible = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("label1PDV22").Visible = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("textPDV22").Enabled = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("textPDV23").Visible = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("label1PDV23").Visible = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("textPDV23").Enabled = true;

            this.IraControlerfORM.IRAFormDefinition.GetControl("label1PDV25").Visible = true;
            //this.IraControlerfORM.IRAFormDefinition.GetControl("textPDV25").Enabled = true;

            if (this.IraControlerfORM.DataSet.IRA.Rows.Count != 0)
            {
                this.dagk.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(this.GkstavkaDataSet1, Conversions.ToInteger(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRADOKIDDOKUMENT"]), Conversions.ToInteger(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRABROJ"]), mipsed.application.framework.Application.ActiveYear);
                ((ExtendedWindowWorkspace) this.IraControlerfORM.WorkItem.Workspaces.Get("window")).SmartPartClosing += new EventHandler<WorkspaceCancelEventArgs>(this.Closing);
                this.ds = this.IraControlerfORM.DataSet;
                this.src = this.IraControlerfORM.IRAFormDefinition.GetBindingSource("IRA");
                decimal num = new decimal();
                bool flag = false;
                if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0)
                {
                    num = Conversions.ToDecimal(this.GkstavkaDataSet1.GKSTAVKA.Compute("SUM(zatvoreniiznos)", ""));
                    flag = Conversions.ToBoolean(this.GkstavkaDataSet1.GKSTAVKA.Rows[0]["statusgk"]);
                }
                this.cmboPARTNER = (PARTNERComboBox) this.IraControlerfORM.IRAFormDefinition.GetControl("comboirapartnerIDPARTNER");
                if ((decimal.Compare(num, decimal.Zero) > 0) | flag)
                {
                    this.cmboPARTNER.ComboBox.ReadOnly = true;
                    this.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
                }
                else
                {
                    this.IraControlerfORM.IRAFormDefinition.GetControl("comboirapartnerIDPARTNER");
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
            if (e.Button.Name == "ToolBarButtonKontiranje")
            {
                using (FinPosModule.OdabirShemaIRA objekt = new FinPosModule.OdabirShemaIRA())
                {
                    if (objekt.ShowDialogForm("Odabir sheme") == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        //upis redova u kontiranje stavka
                        foreach (DataRow row in GetShemaIRA(objekt.idShema).Rows)
                        {
                            Unos(row["ID_KONTO"].ToString().Trim(), (int)row["ID_ORG_JED"], (int)row["ID_MJESTO_TROSKA"], (int)row["ID_STRANE_KNJIZENJA"]);
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private DataTable GetShemaIRA(int idShema)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            DataTable dtShemaKontiranja = client.GetDataTable("SELECT dbo.KONTO.IDKONTO AS ID_KONTO, dbo.STRANEKNJIZENJA.IDSTRANEKNJIZENJA AS ID_STRANE_KNJIZENJA, " +
                        "dbo.IRAVRSTAIZNOSA.IDIRAVRSTAIZNOSA AS ID_IRA_VRSTA_IZNOSA, dbo.MJESTOTROSKA.IDMJESTOTROSKA AS ID_MJESTO_TROSKA, dbo.ORGJED.IDORGJED AS ID_ORG_JED, " +
                        "(RTRIM(dbo.Konto.IDKONTO) + ' | ' + dbo.Konto.NAZIVKONTO) AS Konto, dbo.STRANEKNJIZENJA.NAZIVSTRANEKNJIZENJA AS StranaKnjizenja, " +
                        "dbo.IRAVRSTAIZNOSA.IRAVRSTAIZNOSANAZIV AS VrstaIznosa, (dbo.MJESTOTROSKA.NAZIVMJESTOTROSKA + ' | ' + Convert(nvarchar, dbo.MJESTOTROSKA.IDMJESTOTROSKA)) AS SifraMT, " +
                        "(dbo.ORGJED.NAZIVORGJED + ' | ' + Convert(nvarchar, dbo.ORGJED.IDORGJED)) AS SifraOJ FROM dbo.SHEMAIRASHEMAIRAKONTIRANJE " +
                        "INNER JOIN dbo.STRANEKNJIZENJA ON dbo.SHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRASTRANEIDSTRANEKNJIZENJA = dbo.STRANEKNJIZENJA.IDSTRANEKNJIZENJA " +
                        "INNER JOIN dbo.IRAVRSTAIZNOSA ON dbo.SHEMAIRASHEMAIRAKONTIRANJE.IDIRAVRSTAIZNOSA = dbo.IRAVRSTAIZNOSA.IDIRAVRSTAIZNOSA " +
                        "INNER JOIN dbo.ORGJED ON dbo.SHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAOJIDORGJED = dbo.ORGJED.IDORGJED " +
                        "INNER JOIN dbo.MJESTOTROSKA ON dbo.SHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAMTIDMJESTOTROSKA = dbo.MJESTOTROSKA.IDMJESTOTROSKA " +
                        "INNER JOIN dbo.KONTO ON dbo.SHEMAIRASHEMAIRAKONTIRANJE.SHEMAIRAKONTOIDKONTO = dbo.KONTO.IDKONTO " +
                        "WHERE (dbo.SHEMAIRASHEMAIRAKONTIRANJE.IDSHEMAIRA = '" + idShema + "')");
            return dtShemaKontiranja;
        }


        public void Unos(string konto, int orgJed, int mjTroska, int stranaKnjizenja)
        {
            BindingSource bindingSource = this.IraControlerfORM.IRAFormDefinition.GetBindingSource("IRA");
            bindingSource.EndEdit();

            this.IraControlerfORM.Update(this.Parent.Parent);

            this.UltraGrid1.UpdateData();
            this.dagk.Update(this.GkstavkaDataSet1);


            this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].AddNew();
            this.drv = (DataRowView)this.BindingContext[this.GkstavkaDataSet1, "GKSTAVKA"].Current;
            if (this.GkstavkaDataSet1.GKSTAVKA.Rows.Count > 0)
            {
                this.drv["datumdokumenta"] = RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Rows[this.GkstavkaDataSet1.GKSTAVKA.Rows.Count - 1]["DATUMDOKUMENTA"]);
                this.drv["brojdokumenta"] = RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Rows[this.GkstavkaDataSet1.GKSTAVKA.Rows.Count - 1]["BROJDOKUMENTA"]);
                this.drv["brojstavke"] = this.GkstavkaDataSet1.GKSTAVKA.Rows.Count + 1;
                this.drv["IDORGJED"] = orgJed;
                this.drv["IDMJESTOTROSKA"] = mjTroska;
                this.drv["IDKONTO"] = konto;
                this.drv["iddokument"] = RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Rows[this.GkstavkaDataSet1.GKSTAVKA.Rows.Count - 1]["IDDOKUMENT"]);
                this.drv["OPIS"] = RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Rows[this.GkstavkaDataSet1.GKSTAVKA.Rows.Count - 1]["OPIS"]);
                this.drv["zatvoreniiznos"] = 0;
                this.drv["statusgk"] = 0;
                decimal num = DB.N20(RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Compute("SUM(DUGUJE)", "")));
                decimal num2 = DB.N20(RuntimeHelpers.GetObjectValue(this.GkstavkaDataSet1.GKSTAVKA.Compute("SUM(POTRAZUJE)", "")));
                if (decimal.Compare(num2, num) > 0)
                {
                    this.drv["potrazuje"] = 0;
                    this.drv["DUGUJE"] = decimal.Subtract(num2, num);
                }
                else if (decimal.Compare(num, num2) > 0)
                {
                    this.drv["potrazuje"] = decimal.Subtract(num, num2);
                    this.drv["DUGUJE"] = 0;
                }
                else if (decimal.Compare(num, num2) == 0)
                {
                    this.drv["potrazuje"] = 0;
                    this.drv["DUGUJE"] = 0;
                }
                this.drv["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[this.UltraGrid1.Rows.Count - 1];
                this.UltraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                this.UltraGrid1.PerformAction(UltraGridAction.ActivateCell);
                this.UltraGrid1.PerformAction(UltraGridAction.NextCell);
                this.UltraGrid1.PerformAction(UltraGridAction.NextCell);
                this.UltraGrid1.PerformAction(UltraGridAction.ActivateCell);
                this.UltraGrid1.PerformAction(UltraGridAction.EnterEditModeAndDropdown);

                drv.EndEdit();
                GkstavkaDataSet1.AcceptChanges();

                this.dagk.UpdateKonto(this.GkstavkaDataSet1);
            }
            else
            {
                this.drv["datumdokumenta"] = RuntimeHelpers.GetObjectValue(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRADATUM"]);
                this.drv["brojdokumenta"] = RuntimeHelpers.GetObjectValue(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRABROJ"]);
                this.drv["brojstavke"] = this.GkstavkaDataSet1.GKSTAVKA.Rows.Count + 1;
                this.drv["iddokument"] = RuntimeHelpers.GetObjectValue(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRADOKIDDOKUMENT"]);
                this.drv["OPIS"] = Strings.Left(this.IraControlerfORM.IRAFormDefinition.GetControl("comboIRADOKIDDOKUMENT").Controls[0].Text + " " + Conversions.ToString(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRABROJ"]) + " " + Conversions.ToString(this.IraControlerfORM.DataSet.IRA.Rows[0]["iraNAPOMENA"]) + " " + ((PARTNERComboBox)this.IraControlerfORM.IRAFormDefinition.GetControl("comboirapartnerIDPARTNER")).ComboBox.Text, 0x95);
                this.drv["zatvoreniiznos"] = 0;
                this.drv["statusgk"] = 0;
                this.drv["potrazuje"] = 0;
                this.drv["DUGUJE"] = RuntimeHelpers.GetObjectValue(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRAUKUPNO"]);
                this.drv["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                this.drv["IDORGJED"] = orgJed;
                this.drv["IDMJESTOTROSKA"] = mjTroska;
                this.drv["IDKONTO"] = konto;
                this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[this.UltraGrid1.Rows.Count - 1];
                this.UltraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                this.UltraGrid1.PerformAction(UltraGridAction.ActivateCell);
                this.UltraGrid1.PerformAction(UltraGridAction.EnterEditModeAndDropdown);

                drv.EndEdit();
                GkstavkaDataSet1.AcceptChanges();
            }
            this.PostaviStatus();
        }


        private void UltraGrid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == "IDKONTO")
            {
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
                    this.drv["idpartner"] = RuntimeHelpers.GetObjectValue(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRAPARTNERIDPARTNER"]);
                    this.drv["GKDATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRAvaluta"]);
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
        }

        private void UltraGrid1_AfterRowUpdate(object sender, RowEventArgs e)
        {
            this.Spremi_Promjene();
            this.PostaviStatus();
        }

        private void UltraGrid1_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if ((decimal.Compare(Conversions.ToDecimal(this.UltraGrid1.ActiveRow.Cells["ZATVORENIIZNOS"].Value), decimal.Zero) > 0) & (((((this.UltraGrid1.ActiveCell.Column.Key == "IDPARTNER") | (this.UltraGrid1.ActiveCell.Column.Key == "IDKONTO")) | (this.UltraGrid1.ActiveCell.Column.Key == "duguje")) | (this.UltraGrid1.ActiveCell.Column.Key == "POTRAZUJE")) | (this.UltraGrid1.ActiveCell.Column.Key == "ZATVORENIIZNOS")))
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
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
            BindingSource bindingSource = this.IraControlerfORM.IRAFormDefinition.GetBindingSource("IRA");
            bindingSource.EndEdit();

            this.IraControlerfORM.Update(this.Parent.Parent);
            
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
                if (decimal.Compare(num, num2) > 0)
                {
                    this.drv["potrazuje"] = decimal.Subtract(num, num2);
                    this.drv["DUGUJE"] = 0;
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
                this.UltraGrid1.PerformAction(UltraGridAction.NextCell);
                this.UltraGrid1.PerformAction(UltraGridAction.NextCell);
                this.UltraGrid1.PerformAction(UltraGridAction.ActivateCell);
                this.UltraGrid1.PerformAction(UltraGridAction.EnterEditModeAndDropdown);
            }
            else
            {
                this.drv["datumdokumenta"] = RuntimeHelpers.GetObjectValue(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRADATUM"]);
                this.drv["brojdokumenta"] = RuntimeHelpers.GetObjectValue(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRABROJ"]);
                this.drv["brojstavke"] = this.GkstavkaDataSet1.GKSTAVKA.Rows.Count + 1;
                this.drv["iddokument"] = RuntimeHelpers.GetObjectValue(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRADOKIDDOKUMENT"]);
                this.drv["OPIS"] = Strings.Left(this.IraControlerfORM.IRAFormDefinition.GetControl("comboIRADOKIDDOKUMENT").Controls[0].Text + " " + Conversions.ToString(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRABROJ"]) + " " + Conversions.ToString(this.IraControlerfORM.DataSet.IRA.Rows[0]["iraNAPOMENA"]) + " " + ((PARTNERComboBox) this.IraControlerfORM.IRAFormDefinition.GetControl("comboirapartnerIDPARTNER")).ComboBox.Text, 0x95);
                this.drv["zatvoreniiznos"] = 0;
                this.drv["statusgk"] = 0;
                this.drv["potrazuje"] = RuntimeHelpers.GetObjectValue(this.IraControlerfORM.DataSet.IRA.Rows[0]["IRAUKUPNO"]);
                this.drv["DUGUJE"] = 0;
                this.drv["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[this.UltraGrid1.Rows.Count - 1];
                this.UltraGrid1.PerformAction(UltraGridAction.EnterEditMode);
                this.UltraGrid1.PerformAction(UltraGridAction.ActivateCell);
                this.UltraGrid1.PerformAction(UltraGridAction.EnterEditModeAndDropdown);
            }
            this.PostaviStatus();
        }

        internal AutoHideControl _StavkeUreAutoHideControl
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__StavkeUreAutoHideControl;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__StavkeUreAutoHideControl = value;
            }
        }

        internal UnpinnedTabArea _StavkeUreUnpinnedTabAreaBottom
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__StavkeUreUnpinnedTabAreaBottom;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__StavkeUreUnpinnedTabAreaBottom = value;
            }
        }

        internal UnpinnedTabArea _StavkeUreUnpinnedTabAreaLeft
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__StavkeUreUnpinnedTabAreaLeft;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__StavkeUreUnpinnedTabAreaLeft = value;
            }
        }

        internal UnpinnedTabArea _StavkeUreUnpinnedTabAreaRight
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__StavkeUreUnpinnedTabAreaRight;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__StavkeUreUnpinnedTabAreaRight = value;
            }
        }

        internal UnpinnedTabArea _StavkeUreUnpinnedTabAreaTop
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__StavkeUreUnpinnedTabAreaTop;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__StavkeUreUnpinnedTabAreaTop = value;
            }
        }

        internal DockableWindow DockableWindow1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._DockableWindow1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._DockableWindow1 = value;
            }
        }

        internal DockableWindow DockableWindow2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._DockableWindow2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._DockableWindow2 = value;
            }
        }

        internal GKSTAVKADataSet GkstavkaDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._GkstavkaDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._GkstavkaDataSet1 = value;
            }
        }

        internal ImageList ImageList1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ImageList1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._ImageList1 = value;
            }
        }

        [CreateNew]
        public IRAController IraControlerfORM { get; set; }

        internal UltraDropDown KONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._KONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.KONTO_TextChanged);
                DropDownEventHandler handler2 = new DropDownEventHandler(this.KONTO_AfterCloseUp);
                if (this._KONTO != null)
                {
                    this._KONTO.TextChanged -= handler;
                    this._KONTO.AfterCloseUp -= handler2;
                }
                this._KONTO = value;
                if (this._KONTO != null)
                {
                    this._KONTO.TextChanged += handler;
                    this._KONTO.AfterCloseUp += handler2;
                }
            }
        }

        internal KONTODataSet KontoDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._KontoDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._KontoDataSet1 = value;
            }
        }

        private CurrencyManager m_cm
        {
            [DebuggerNonUserCode]
            get
            {
                return this._m_cm;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._m_cm = value;
            }
        }

        internal MJESTOTROSKADataSet MjestotroskaDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._MjestotroskaDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._MjestotroskaDataSet1 = value;
            }
        }

        internal UltraDropDown MT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._MT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._MT = value;
            }
        }

        internal UltraDropDown OJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._OJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._OJ = value;
            }
        }

        internal ORGJEDDataSet OrgjedDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._OrgjedDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._OrgjedDataSet1 = value;
            }
        }

        private Panel Panel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Panel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Panel1 = value;
            }
        }

        private Panel Panel2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Panel2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Panel2 = value;
            }
        }

        internal ToolBar ToolBar1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ToolBar1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                ToolBarButtonClickEventHandler handler = new ToolBarButtonClickEventHandler(this.ToolBar1_ButtonClick);
                if (this._ToolBar1 != null)
                {
                    this._ToolBar1.ButtonClick -= handler;
                }
                this._ToolBar1 = value;
                if (this._ToolBar1 != null)
                {
                    this._ToolBar1.ButtonClick += handler;
                }
            }
        }

        internal ToolBarButton ToolBarButton1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ToolBarButton1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._ToolBarButton1 = value;
            }
        }

        #region MBS.Complete
        internal ToolBarButton ToolBarButtonKontiranje
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ToolBarButtonKontiranje;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._ToolBarButtonKontiranje = value;
            }
        }
        #endregion

        internal ToolBarButton ToolBarButton2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ToolBarButton2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._ToolBarButton2 = value;
            }
        }

        internal ToolBarButton ToolBarButton4
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ToolBarButton4;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._ToolBarButton4 = value;
            }
        }

        private UltraDockManager UltraDockManager1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraDockManager1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraDockManager1 = value;
            }
        }

        private UltraGrid UltraGrid1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGrid1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                KeyEventHandler handler = new KeyEventHandler(this.UltraGrid1_KeyDown);
                CancelEventHandler handler2 = new CancelEventHandler(this.UltraGrid1_BeforeEnterEditMode);
                CellDataErrorEventHandler handler3 = new CellDataErrorEventHandler(this.UltraGrid1_CellDataError);
                EventHandler handler4 = new EventHandler(this.UltraGrid1_AfterEnterEditMode);
                CellEventHandler handler5 = new CellEventHandler(this.UltraGrid1_AfterCellUpdate);
                InitializeLayoutEventHandler handler6 = new InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
                RowEventHandler handler7 = new RowEventHandler(this.UltraGrid1_AfterRowUpdate);
                EventHandler handler8 = new EventHandler(this.UltraGrid1_AfterRowsDeleted);
                if (this._UltraGrid1 != null)
                {
                    this._UltraGrid1.KeyDown -= handler;
                    this._UltraGrid1.BeforeEnterEditMode -= handler2;
                    this._UltraGrid1.CellDataError -= handler3;
                    this._UltraGrid1.AfterEnterEditMode -= handler4;
                    this._UltraGrid1.AfterCellUpdate -= handler5;
                    this._UltraGrid1.InitializeLayout -= handler6;
                    this._UltraGrid1.AfterRowUpdate -= handler7;
                    this._UltraGrid1.AfterRowsDeleted -= handler8;
                }
                this._UltraGrid1 = value;
                if (this._UltraGrid1 != null)
                {
                    this._UltraGrid1.KeyDown += handler;
                    this._UltraGrid1.BeforeEnterEditMode += handler2;
                    this._UltraGrid1.CellDataError += handler3;
                    this._UltraGrid1.AfterEnterEditMode += handler4;
                    this._UltraGrid1.AfterCellUpdate += handler5;
                    this._UltraGrid1.InitializeLayout += handler6;
                    this._UltraGrid1.AfterRowUpdate += handler7;
                    this._UltraGrid1.AfterRowsDeleted += handler8;
                }
            }
        }

        internal WindowDockingArea WindowDockingArea1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._WindowDockingArea1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._WindowDockingArea1 = value;
            }
        }

        internal WindowDockingArea WindowDockingArea2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._WindowDockingArea2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._WindowDockingArea2 = value;
            }
        }
    }
}

