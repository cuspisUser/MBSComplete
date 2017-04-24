using CrystalDecisions.CrystalReports.Engine;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.Workspaces;
using Deklarit.Resources;
using Hlp;
using Infragistics.Practices.CompositeUI.WinForms;
using Infragistics.Win;
using Infragistics.Win.UltraWinCalcManager;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Office.Interop.Excel;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.Controllers;
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
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace FinPosModule
{
    [SmartPart]
    public class UraSmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private int dokument;
        private SmartPartInfoProvider infoProvider;
        private DateTime pocetni;
        private SmartPartInfo smartPartInfo1;
        private UltraExplorerBarWorkspace work;
        private DataColumn OSNOVICA25;
        private DataColumn dataColumn2;
        private DataColumn dataColumn3;
        private DataColumn dataColumn4;
        private DateTime zavrsni;

        private int od_ure { get; set; }
        private int do_ure { get; set; }
        private bool oznacen { get; set; }

        public UraSmartPart()
        {
            base.Leave += new EventHandler(this.UraSmartPart_Leave);
            base.Load += new EventHandler(this.TestSmartPart_Load);
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo("Knjiga ulaznih računa", "Knjiga ulaznih računa");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        public void Brisanje()
        {
            URADataSet dataSet = new URADataSet();
            URADataAdapter adapter = new URADataAdapter();
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.SP_FIN_URAPLACANJEDataSet1, "SP_FIN_URAPLACANJE"];
            if (manager.Count != 0)
            {
                if (this.UltraGrid1.ActiveRow != null)
                {
                    int index = this.UltraGrid1.ActiveRow.Index;
                }
                GKSTAVKADataAdapter adapter2 = new GKSTAVKADataAdapter();
                GKSTAVKADataSet set2 = new GKSTAVKADataSet();
                URADataAdapter adapter3 = new URADataAdapter();
                DataRowView current = (DataRowView) manager.Current;
                adapter2.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(set2, Conversions.ToInteger(current["URADOKIDDOKUMENT"]), Conversions.ToInteger(current["URABROJ"]), Conversions.ToShort(current["URAGODIDGODINE"]));
                if (set2.GKSTAVKA.Rows.Count > 0)
                {
                    Interaction.MsgBox("Ura je kontirana u glavnoj knjizi!", MsgBoxStyle.Information, "Financijsko poslovanje");
                }
                else
                {
                    adapter.FillByURAGODIDGODINEURADOKIDDOKUMENTURABROJ(dataSet, Conversions.ToShort(current["URAGODIDGODINE"]), Conversions.ToInteger(current["URADOKIDDOKUMENT"]), Conversions.ToInteger(current["URABROJ"]));
                    DataRow row = dataSet.URA.Rows[0];
                    this.Controller1.Delete(row);
                    current.Delete();
                    this.PuniPodatke(this.dokument, Conversions.ToInteger(current["URABROJ"]), Conversions.ToInteger(current["URABROJ"]));
                    this.Pre_sort();
                }
            }
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("b56d929b-39e7-4750-ada8-586c2c609b09"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("20f8bcb7-262e-4452-b055-13947ca15700"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("b56d929b-39e7-4750-ada8-586c2c609b09"), -1);
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("SP_FIN_URAPLACANJE", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZATVARANJE_IZNOS");
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZATVARANJE_DATUM");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("URABROJ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDTIPURA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("URABROJRACUNADOBAVLJACA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("urapartnerIDPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("URANAPOMENA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("URAVALUTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("URAUKUPNO");
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("URADATUM");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("URAGODIDGODINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("URADOKIDDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNEROIB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Status");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("URAMODEL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("URAPOZIVNABROJ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICA0");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICA5");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICA10");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICA22");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICA23");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICA25");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDV5DA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDV5NE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDV10DA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDV10NE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDV22DA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDV22NE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDV23DA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDV23NE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDV25DA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PDV25NE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICA5NE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICA10NE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICA23NE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICA22NE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVICA25NE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("R2");
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "URAUKUPNO", 8, true, "SP_FIN_URAPLACANJE", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, null, -1, false);
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings2 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "ZATVARANJE_IZNOS", 0, true, "SP_FIN_URAPLACANJE", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, null, -1, false);
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings3 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, null, null, -1, false, null, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.Left, null, -1, false);
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.ToolBar1 = new System.Windows.Forms.ToolBar();
            this.ToolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton7 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton8 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton9 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarButton10 = new System.Windows.Forms.ToolBarButton();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.UltraCalcManager1 = new Infragistics.Win.UltraWinCalcManager.UltraCalcManager(this.components);
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._TestSmartPartUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._TestSmartPartUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._TestSmartPartUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._TestSmartPartUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._TestSmartPartAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.OSNOVICA25 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.SP_FIN_URAPLACANJEDataSet1 = new Placa.SP_FIN_URAPLACANJEDataSet();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraCalcManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_FIN_URAPLACANJEDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.ToolBar1);
            this.Panel1.Location = new System.Drawing.Point(0, 18);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1208, 58);
            this.Panel1.TabIndex = 15;
            // 
            // ToolBar1
            // 
            this.ToolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.ToolBarButton1,
            this.ToolBarButton2,
            this.ToolBarButton4,
            this.ToolBarButton6,
            this.ToolBarButton3,
            this.ToolBarButton5,
            //this.ToolBarButton7,
            this.ToolBarButton8,
            this.ToolBarButton9,
            this.ToolBarButton10});
            this.ToolBar1.ButtonSize = new System.Drawing.Size(32, 32);
            this.ToolBar1.DropDownArrows = true;
            this.ToolBar1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ToolBar1.ImageList = this.ImageList1;
            this.ToolBar1.Location = new System.Drawing.Point(0, 0);
            this.ToolBar1.MinimumSize = new System.Drawing.Size(0, 60);
            this.ToolBar1.Name = "ToolBar1";
            this.ToolBar1.ShowToolTips = true;
            this.ToolBar1.Size = new System.Drawing.Size(1208, 60);
            this.ToolBar1.TabIndex = 1;
            this.ToolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.ToolBar1_ButtonClick);
            // 
            // ToolBarButton1
            // 
            this.ToolBarButton1.ImageIndex = 15;
            this.ToolBarButton1.Name = "ToolBarButton1";
            this.ToolBarButton1.Text = "Dodaj";
            // 
            // ToolBarButton2
            // 
            this.ToolBarButton2.ImageIndex = 14;
            this.ToolBarButton2.Name = "ToolBarButton2";
            this.ToolBarButton2.Text = "Briši";
            // 
            // ToolBarButton4
            // 
            this.ToolBarButton4.ImageIndex = 11;
            this.ToolBarButton4.Name = "ToolBarButton4";
            this.ToolBarButton4.Text = "Izmjeni";
            // 
            // ToolBarButton6
            // 
            this.ToolBarButton6.ImageKey = "printer.png";
            this.ToolBarButton6.Name = "ToolBarButton6";
            this.ToolBarButton6.Text = "Ispiši";
            // 
            // ToolBarButton3
            // 
            this.ToolBarButton3.ImageIndex = 8;
            this.ToolBarButton3.Name = "ToolBarButton3";
            this.ToolBarButton3.Text = "Proknjiži ";
            // 
            // ToolBarButton5
            // 
            this.ToolBarButton5.ImageIndex = 10;
            this.ToolBarButton5.Name = "ToolBarButton5";
            this.ToolBarButton5.Text = "Virmani";
            // 
            // ToolBarButton7
            // 
            this.ToolBarButton7.ImageIndex = 9;
            this.ToolBarButton7.Name = "ToolBarButton7";
            this.ToolBarButton7.Text = "Izradi shemu";
            // 
            // ToolBarButton8
            // 
            this.ToolBarButton8.ImageIndex = 5;
            this.ToolBarButton8.Name = "ToolBarButton8";
            this.ToolBarButton8.Text = "PDV Ura";
            // 
            // ToolBarButton9
            // 
            this.ToolBarButton9.ImageIndex = 4;
            this.ToolBarButton9.Name = "ToolBarButton9";
            this.ToolBarButton9.Text = "PDV obrazac";

            // 
            // ToolBarButton10
            // 
            this.ToolBarButton10.ImageIndex = 4;
            this.ToolBarButton10.Name = "ToolBarButton10";
            this.ToolBarButton10.Text = "PDV obrazac z.";

            // 
            // ImageList1
            // 
            this.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // UltraCalcManager1
            // 
            this.UltraCalcManager1.ContainingControl = this;
            // 
            // UltraDockManager1
            // 
            dockableControlPane1.Control = this.Panel1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(3, 3, 1110, 63);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Izbornik knjiga URA";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(1208, 76);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
            // 
            // _TestSmartPartUnpinnedTabAreaLeft
            // 
            this._TestSmartPartUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._TestSmartPartUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._TestSmartPartUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._TestSmartPartUnpinnedTabAreaLeft.Name = "_TestSmartPartUnpinnedTabAreaLeft";
            this._TestSmartPartUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._TestSmartPartUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 614);
            this._TestSmartPartUnpinnedTabAreaLeft.TabIndex = 16;
            // 
            // _TestSmartPartUnpinnedTabAreaRight
            // 
            this._TestSmartPartUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._TestSmartPartUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._TestSmartPartUnpinnedTabAreaRight.Location = new System.Drawing.Point(1208, 0);
            this._TestSmartPartUnpinnedTabAreaRight.Name = "_TestSmartPartUnpinnedTabAreaRight";
            this._TestSmartPartUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._TestSmartPartUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 614);
            this._TestSmartPartUnpinnedTabAreaRight.TabIndex = 17;
            // 
            // _TestSmartPartUnpinnedTabAreaTop
            // 
            this._TestSmartPartUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._TestSmartPartUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._TestSmartPartUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._TestSmartPartUnpinnedTabAreaTop.Name = "_TestSmartPartUnpinnedTabAreaTop";
            this._TestSmartPartUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._TestSmartPartUnpinnedTabAreaTop.Size = new System.Drawing.Size(1208, 0);
            this._TestSmartPartUnpinnedTabAreaTop.TabIndex = 18;
            // 
            // _TestSmartPartUnpinnedTabAreaBottom
            // 
            this._TestSmartPartUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._TestSmartPartUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._TestSmartPartUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 614);
            this._TestSmartPartUnpinnedTabAreaBottom.Name = "_TestSmartPartUnpinnedTabAreaBottom";
            this._TestSmartPartUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._TestSmartPartUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1208, 0);
            this._TestSmartPartUnpinnedTabAreaBottom.TabIndex = 19;
            // 
            // _TestSmartPartAutoHideControl
            // 
            this._TestSmartPartAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._TestSmartPartAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._TestSmartPartAutoHideControl.Name = "_TestSmartPartAutoHideControl";
            this._TestSmartPartAutoHideControl.Owner = this.UltraDockManager1;
            this._TestSmartPartAutoHideControl.Size = new System.Drawing.Size(0, 614);
            this._TestSmartPartAutoHideControl.TabIndex = 20;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(1208, 81);
            this.WindowDockingArea1.TabIndex = 21;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Controls.Add(this.Panel1);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(1208, 76);
            this.DockableWindow1.TabIndex = 22;
            // 
            // OSNOVICA25
            // 
            this.OSNOVICA25.Caption = "OSNOVIC A25";
            this.OSNOVICA25.ColumnName = "OSNOVICA25";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "PD V25 DA";
            this.dataColumn2.ColumnName = "PDV25DA";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "PD V25 NE";
            this.dataColumn3.ColumnName = "PDV25NE";
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "OSNOVIC A25 NE";
            this.dataColumn4.ColumnName = "OSNOVICA25NE";
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.CalcManager = this.UltraCalcManager1;
            this.UltraGrid1.DataMember = "SP_FIN_URAPLACANJE";
            this.UltraGrid1.DataSource = this.SP_FIN_URAPLACANJEDataSet1;
            appearance9.BackColor = System.Drawing.Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance9;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance21.TextHAlignAsString = "Right";
            ultraGridColumn1.CellAppearance = appearance21;
            ultraGridColumn1.Header.Caption = "Plaćeno";
            ultraGridColumn1.Header.VisiblePosition = 5;
            ultraGridColumn1.MaskInput = "{LOC} n,nnn,nnn.nn";
            ultraGridColumn1.PromptChar = ' ';
            ultraGridColumn1.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn1.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn1.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn1.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn1.Width = 107;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.Caption = "Datum plaćanja";
            ultraGridColumn2.Header.VisiblePosition = 6;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.Caption = "Broj";
            ultraGridColumn3.Header.VisiblePosition = 0;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.VisiblePosition = 9;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.Caption = "Br.rn.dob.";
            ultraGridColumn5.Header.VisiblePosition = 7;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.Width = 136;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.Caption = "Šif.part.";
            ultraGridColumn6.Header.VisiblePosition = 10;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.Caption = "Napomena";
            ultraGridColumn7.Header.VisiblePosition = 8;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.Width = 208;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.Caption = "Valuta";
            ultraGridColumn8.Header.VisiblePosition = 3;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 14;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance22.TextHAlignAsString = "Right";
            ultraGridColumn9.CellAppearance = appearance22;
            ultraGridColumn9.Header.Caption = "Ukupno";
            ultraGridColumn9.Header.VisiblePosition = 4;
            ultraGridColumn9.MaskInput = "-n,nnn,nnn.nn";
            ultraGridColumn9.RowLayoutColumnInfo.OriginX = 16;
            ultraGridColumn9.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn9.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn9.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn9.Width = 104;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.Caption = "Datum";
            ultraGridColumn10.Header.VisiblePosition = 2;
            ultraGridColumn10.RowLayoutColumnInfo.OriginX = 18;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn10.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 11;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn11.RowLayoutColumnInfo.OriginX = 20;
            ultraGridColumn11.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn11.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn11.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 1;
            ultraGridColumn12.RowLayoutColumnInfo.OriginX = 22;
            ultraGridColumn12.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn12.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn12.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn12.Width = 292;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn13.RowLayoutColumnInfo.OriginX = 24;
            ultraGridColumn13.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn13.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn13.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.Caption = "Dokument";
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn14.RowLayoutColumnInfo.OriginX = 26;
            ultraGridColumn14.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn14.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn14.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.Caption = "OIB";
            ultraGridColumn15.Header.VisiblePosition = 14;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn15.RowLayoutColumnInfo.OriginX = 28;
            ultraGridColumn15.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn15.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn15.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 15;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.VisiblePosition = 16;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.VisiblePosition = 17;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.Header.VisiblePosition = 18;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.Header.VisiblePosition = 19;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.Header.Caption = "Osnovica 13%";
            ultraGridColumn21.Header.VisiblePosition = 20;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn22.Header.VisiblePosition = 21;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn23.Header.VisiblePosition = 22;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn24.Header.VisiblePosition = 23;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn25.Header.VisiblePosition = 24;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn26.Header.VisiblePosition = 25;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn27.Header.Caption = "PD V13 DA";
            ultraGridColumn27.Header.VisiblePosition = 26;
            ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn28.Header.Caption = "PD V13 NE";
            ultraGridColumn28.Header.VisiblePosition = 27;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn29.Header.VisiblePosition = 28;
            ultraGridColumn29.Hidden = true;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn30.Header.VisiblePosition = 29;
            ultraGridColumn30.Hidden = true;
            ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn31.Header.VisiblePosition = 30;
            ultraGridColumn31.Hidden = true;
            ultraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn32.Header.VisiblePosition = 31;
            ultraGridColumn32.Hidden = true;
            ultraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn33.Header.VisiblePosition = 32;
            ultraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn34.Header.VisiblePosition = 33;
            ultraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn35.Header.VisiblePosition = 34;
            ultraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn36.Header.Caption = "OSNOVIC A13 NE";
            ultraGridColumn36.Header.VisiblePosition = 35;
            ultraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn37.Header.VisiblePosition = 36;
            ultraGridColumn37.Hidden = true;
            ultraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn38.Header.VisiblePosition = 37;
            ultraGridColumn38.Hidden = true;
            ultraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn39.Header.VisiblePosition = 38;
            ultraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn40.Header.VisiblePosition = 39;
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
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38,
            ultraGridColumn39,
            ultraGridColumn40});
            ultraGridBand1.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            appearance23.FontData.BoldAsString = "True";
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextHAlignAsString = "Right";
            summarySettings1.Appearance = appearance23;
            summarySettings1.DisplayFormat = "{0:#,##0.00}";
            summarySettings1.GroupBySummaryValueAppearance = appearance24;
            summarySettings1.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            appearance25.FontData.BoldAsString = "True";
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.TextHAlignAsString = "Right";
            summarySettings2.Appearance = appearance25;
            summarySettings2.DisplayFormat = "{0:#,##0.00}";
            summarySettings2.GroupBySummaryValueAppearance = appearance26;
            summarySettings2.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed;
            summarySettings3.GroupBySummaryValueAppearance = appearance27;
            ultraGridBand1.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings1,
            summarySettings2,
            summarySettings3});
            ultraGridBand1.SummaryFooterCaption = "Totali:";
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance17.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance17;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            this.UltraGrid1.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance18.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance18;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance19.BorderColor = System.Drawing.Color.LightGray;
            appearance19.FontData.BoldAsString = "True";
            appearance19.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance19;
            appearance20.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance20.BorderColor = System.Drawing.Color.Black;
            appearance20.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance20;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGrid1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.UltraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(0, 81);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(1208, 533);
            this.UltraGrid1.TabIndex = 11;
            this.UltraGrid1.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.UltraGrid1_AfterCellUpdate);
            this.UltraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
            this.UltraGrid1.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.UltraGrid1_InitializeRow);
            this.UltraGrid1.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGrid1_DoubleClickRow);
            // 
            // SP_FIN_URAPLACANJEDataSet1
            // 
            this.SP_FIN_URAPLACANJEDataSet1.DataSetName = "S_FIN_URA_PLACANJEDataSet";
            // 
            // UraSmartPart
            // 
            this.Controls.Add(this._TestSmartPartAutoHideControl);
            this.Controls.Add(this.UltraGrid1);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._TestSmartPartUnpinnedTabAreaTop);
            this.Controls.Add(this._TestSmartPartUnpinnedTabAreaBottom);
            this.Controls.Add(this._TestSmartPartUnpinnedTabAreaLeft);
            this.Controls.Add(this._TestSmartPartUnpinnedTabAreaRight);
            this.Name = "UraSmartPart";
            this.Size = new System.Drawing.Size(1208, 614);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraCalcManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_FIN_URAPLACANJEDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        public void Ispis_Ura()
        {
            frmParametriFakturiranja fakturiranja = new frmParametriFakturiranja("URA")
            {
                oddatuma = { Value = this.pocetni },
                dodatuma = { Value = this.zavrsni },
                uneOdURE = { Value = this.od_ure },
                uneDoURE = { Value = this.do_ure },
                rbrDatum = { Checked = true}
            };
            if (fakturiranja.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;

                    if (fakturiranja.rbrDatum.Checked)
                    {
                        command.CommandText = "S_FIN_URA_PLACANJE";

                        command.Parameters.AddWithValue("@dat1", RuntimeHelpers.GetObjectValue(fakturiranja.oddatuma.Value));
                        command.Parameters.AddWithValue("@dat2", RuntimeHelpers.GetObjectValue(fakturiranja.dodatuma.Value));
                        command.Parameters.AddWithValue("@IDDOKUMENT", this.dokument);
                    }
                    else
                    {
                        command.CommandText = "S_FIN_URA_PLACANJEPoBroju";

                        command.Parameters.AddWithValue("@od", RuntimeHelpers.GetObjectValue(fakturiranja.uneOdURE.Value));
                        command.Parameters.AddWithValue("@doo", RuntimeHelpers.GetObjectValue(fakturiranja.uneDoURE.Value));
                        command.Parameters.AddWithValue("@IDDOKUMENT", this.dokument);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter {
                        SelectCommand = command
                    };
                    SqlConnection connection = new SqlConnection {
                        ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
                    };
                    adapter.SelectCommand.Connection = connection;
                    SP_FIN_URAPLACANJEDataSet dataSet = new SP_FIN_URAPLACANJEDataSet();
                    adapter.Fill(dataSet, "SP_FIN_URAPLACANJE");

                    SP_FIN_URAPLACANJEDataSet set2 = new SP_FIN_URAPLACANJEDataSet();

                    //ispis neplacenih
                    if (fakturiranja.CheckBox1.Checked)
                    {
                        foreach (DataRow row2 in dataSet.SP_FIN_URAPLACANJE.Select("uraukupno - ZATVARANJE_IZNOS <> 0"))
                        {
                            set2.SP_FIN_URAPLACANJE.ImportRow(row2);
                        }
                    }
                    //ispis placenih
                    else if (fakturiranja.cbkPlaceni.Checked)
                    {
                        foreach (DataRow row2 in dataSet.SP_FIN_URAPLACANJE.Select("uraukupno - ZATVARANJE_IZNOS = 0"))
                        {
                            set2.SP_FIN_URAPLACANJE.ImportRow(row2);
                        }
                    }
                    else
                    {
                        foreach (DataRow row3 in dataSet.SP_FIN_URAPLACANJE.Select(""))
                        {
                            set2.SP_FIN_URAPLACANJE.ImportRow(row3);
                        }
                    }
                    ReportDocument rpt = new ReportDocument();
                    ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                        StartPosition = FormStartPosition.CenterParent,
                        Modal = true,
                        Title = "Pregled izvještaja",
                        Description = "Pregled",
                        Icon = ImageResourcesNew.mbs
                    };
                    rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\knjigauraproracun.rpt");

                    string str = string.Empty;
                    if (fakturiranja.rbrDatum.Checked)
                    {
                        str = "Knjiga primljenih računa za razdoblje: " + Conversions.ToString(fakturiranja.oddatuma.Value) + " - " + Conversions.ToString(fakturiranja.dodatuma.Value);
                    }
                    else
                    {
                        str = "Knjiga primljenih računa od broja: " + Conversions.ToString(fakturiranja.uneOdURE.Value) + " do broja " + Conversions.ToString(fakturiranja.uneDoURE.Value);
                    }

                    rpt.SetDataSource(set2);
                    rpt.SetParameterValue("NASLOV", str);
                    mipsed.application.framework.Application.PostaviParametreIzvjestaja(ref rpt);
                    ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                    PreviewReportWorkItem item = this.Controller1.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                    if (item == null)
                    {
                        item = this.Controller1.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                    }
                    item.Izvjestaj = rpt;
                    item.Show(item.Workspaces["main"], info);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                    
                }
                this.Cursor = Cursors.Default;
            }
        }

        public void Ispis_Ura_pdV()
        {
            frmParametriFakturiranja fakturiranja = new frmParametriFakturiranja("NotURA") {
                CheckBox1 = { Visible = false },
                oddatuma = { Value = this.pocetni },
                dodatuma = { Value = this.zavrsni }
            };

            if (fakturiranja.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (frmParametriFakturiranja.ppo)
                    {
                        SqlCommand command = new SqlCommand
                        {
                            CommandType = CommandType.StoredProcedure,
                            CommandText = "S_FIN_URA_PPO"
                        };
                        command.Parameters.AddWithValue("@dat1", RuntimeHelpers.GetObjectValue(fakturiranja.oddatuma.Value));
                        command.Parameters.AddWithValue("@dat2", RuntimeHelpers.GetObjectValue(fakturiranja.dodatuma.Value));
                        command.Parameters.AddWithValue("@IDDOKUMENT", this.dokument);
                        SqlDataAdapter adapter = new SqlDataAdapter
                        {
                            SelectCommand = command
                        };
                        SqlConnection connection = new SqlConnection
                        {
                            ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
                        };
                        adapter.SelectCommand.Connection = connection;
                        System.Data.DataTable tbl = new System.Data.DataTable();
                        adapter.Fill(tbl);
                        ReportDocument rpt = new ReportDocument();
                        ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
                        {
                            StartPosition = FormStartPosition.CenterParent,
                            Modal = true,
                            Title = "Pregled izvještaja",
                            Description = "Pregled",
                            Icon = ImageResourcesNew.mbs
                        };
                        rpt.Load(System.Windows.Forms.Application.StartupPath + @"\MBSReport\rptURAPPO.rpt");
                        string str = "Knjiga primljenih računa za razdoblje: " + Conversions.ToString(fakturiranja.oddatuma.Value) + " - " + Conversions.ToString(fakturiranja.dodatuma.Value);
                        rpt.SetDataSource(tbl);
                        rpt.SetParameterValue("NASLOV", str);
                        rpt.SetParameterValue("datumOd", RuntimeHelpers.GetObjectValue(fakturiranja.oddatuma.Value));
                        rpt.SetParameterValue("datumDo", RuntimeHelpers.GetObjectValue(fakturiranja.dodatuma.Value));
                        mipsed.application.framework.Application.PostaviParametreIzvjestaja(ref rpt);
                        ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                        PreviewReportWorkItem item = this.Controller1.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                        if (item == null)
                        {
                            item = this.Controller1.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                        }
                        item.Izvjestaj = rpt;
                        item.Show(item.Workspaces["main"], info);
                    }
                    else
                    {
                        SqlCommand command = new SqlCommand
                        {
                            CommandType = CommandType.StoredProcedure,
                            CommandText = "S_FIN_URA_PLACANJE"
                        };
                        command.Parameters.AddWithValue("@dat1", RuntimeHelpers.GetObjectValue(fakturiranja.oddatuma.Value));
                        command.Parameters.AddWithValue("@dat2", RuntimeHelpers.GetObjectValue(fakturiranja.dodatuma.Value));
                        command.Parameters.AddWithValue("@IDDOKUMENT", this.dokument);
                        SqlDataAdapter adapter = new SqlDataAdapter
                        {
                            SelectCommand = command
                        };
                        SqlConnection connection = new SqlConnection
                        {
                            ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
                        };
                        adapter.SelectCommand.Connection = connection;
                        SP_FIN_URAPLACANJEDataSet dataSet = new SP_FIN_URAPLACANJEDataSet();
                        adapter.Fill(dataSet, "SP_FIN_URAPLACANJE");
                        ReportDocument rpt = new ReportDocument();
                        ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo
                        {
                            StartPosition = FormStartPosition.CenterParent,
                            Modal = true,
                            Title = "Pregled izvještaja",
                            Description = "Pregled",
                            Icon = ImageResourcesNew.mbs
                        };
                        rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\knjigaura.rpt");
                        string str = "Knjiga primljenih računa za razdoblje: " + Conversions.ToString(fakturiranja.oddatuma.Value) + " - " + Conversions.ToString(fakturiranja.dodatuma.Value);
                        rpt.SetDataSource(dataSet);
                        rpt.SetParameterValue("NASLOV", str);
                        mipsed.application.framework.Application.PostaviParametreIzvjestaja(ref rpt);
                        ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                        PreviewReportWorkItem item = this.Controller1.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                        if (item == null)
                        {
                            item = this.Controller1.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                        }
                        item.Izvjestaj = rpt;
                        item.Show(item.Workspaces["main"], info);
                    }
                }
                catch (System.Exception exception1)
                {
                    throw exception1;                    
                }
                this.Cursor = Cursors.Default;
            }
        }

        public void Izmjena()
        {
            int index = 0;
            if (this.UltraGrid1.ActiveRow != null)
            {
                index = this.UltraGrid1.ActiveRow.Index;
            }
            URADataSet dataSet = new URADataSet();
            URADataAdapter adapter = new URADataAdapter();
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.SP_FIN_URAPLACANJEDataSet1, "SP_FIN_URAPLACANJE"];
            if (manager.Count != 0)
            {
                DataRowView current = (DataRowView) manager.Current;
                adapter.FillByURAGODIDGODINEURADOKIDDOKUMENTURABROJ(dataSet, Conversions.ToShort(current["URAGODIDGODINE"]), Conversions.ToInteger(current["URADOKIDDOKUMENT"]), Conversions.ToInteger(current["URABROJ"]));
                DataRow row = dataSet.URA.Rows[0];
                this.Controller1.Update(row);
                current.Delete();
                this.PuniPodatke(this.dokument, Conversions.ToInteger(current["URABROJ"]), Conversions.ToInteger(current["URABROJ"]));
                this.Pre_sort();
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

        public void IzradiShemu()
        {
            URADataSet set = new URADataSet();
            URADataAdapter adapter = new URADataAdapter();
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.SP_FIN_URAPLACANJEDataSet1, "SP_FIN_URAPLACANJE"];
            if (manager.Count != 0)
            {
                DataRow row = null;
                decimal num4 = 0;
                decimal num5 = 0;
                IEnumerator enumerator = null;
                IEnumerator enumerator2 = null;
                if (this.UltraGrid1.ActiveRow != null)
                {
                    int index = this.UltraGrid1.ActiveRow.Index;
                }
                GKSTAVKADataAdapter adapter2 = new GKSTAVKADataAdapter();
                GKSTAVKADataSet dataSet = new GKSTAVKADataSet();
                URADataAdapter adapter4 = new URADataAdapter();
                DataRowView current = (DataRowView) manager.Current;
                adapter2.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(dataSet, Conversions.ToInteger(current["URADOKIDDOKUMENT"]), Conversions.ToInteger(current["URABROJ"]), Conversions.ToShort(current["URAGODIDGODINE"]));
                SHEMAURADataSet set4 = new SHEMAURADataSet();
                SHEMAURADataSet set2 = new SHEMAURADataSet();
                SHEMAURADataAdapter adapter3 = new SHEMAURADataAdapter();
                adapter3.Fill(set2);
                try
                {
                    enumerator = dataSet.GKSTAVKA.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        row = (DataRow) enumerator.Current;
                        if (row["idkonto"].ToString().Substring(0, 1) == "2")
                        {
                            int num = 0;
                            num++;
                            num4 = Conversions.ToDecimal(Operators.AddObject(num4, row["potrazuje"]));
                        }
                        else if (row["idkonto"].ToString().Substring(0, 1) == "3")
                        {
                            int num2 = 0;
                            num2++;
                            num5 = Conversions.ToDecimal(Operators.AddObject(num5, row["duguje"]));
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                set4.EnforceConstraints = false;
                int num6 = Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(set2.SHEMAURA.Compute("max(idshemaura)", ""))));
                DataRow row3 = set4.SHEMAURA.NewRow();
                row3["idshemaura"] = num6 + 1;
                row3["nazivshemaura"] = Strings.Left(Conversions.ToString(Operators.AddObject(Operators.AddObject(current["nazivpartner"], "-"), current["uranapomena"])), 0x31);
                row3["PARTNERSHEMAURAIDPARTNER"] = RuntimeHelpers.GetObjectValue(current["urapartneridpartner"]);
                set4.SHEMAURA.Rows.Add(row3);
                try
                {
                    enumerator2 = dataSet.GKSTAVKA.Rows.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        decimal num7 = 0;
                        row = (DataRow) enumerator2.Current;
                        DataRow row4 = set4.SHEMAURASHEMAURAKONTIRANJE.NewRow();
                        row4["idshemaura"] = num6 + 1;
                        if (Operators.ConditionalCompareObjectGreater(row["duguje"], 0, false))
                        {
                            num7 = Conversions.ToDecimal(row["duguje"]);
                            row4["shemaurastraneidstraneknjizenja"] = 1;
                        }
                        else if (Operators.ConditionalCompareObjectLess(row["duguje"], 0, false))
                        {
                            row4["shemaurastraneidstraneknjizenja"] = 2;
                            num7 = Conversions.ToDecimal(row["duguje"]);
                        }
                        else if (Operators.ConditionalCompareObjectGreater(row["potrazuje"], 0, false))
                        {
                            num7 = Conversions.ToDecimal(row["potrazuje"]);
                            row4["shemaurastraneidstraneknjizenja"] = 3;
                        }
                        else if (Operators.ConditionalCompareObjectLess(row["potrazuje"], 0, false))
                        {
                            num7 = Conversions.ToDecimal(row["potrazuje"]);
                            row4["shemaurastraneidstraneknjizenja"] = 4;
                        }
                        if (Operators.ConditionalCompareObjectEqual(num7, current["uraukupno"], false))
                        {
                            row4["iduravrstaiznosa"] = 1;
                        }
                        else if (Operators.ConditionalCompareObjectEqual(num7, current["osnovica23"], false))
                        {
                            row4["iduravrstaiznosa"] = 2;
                        }
                        else if (Operators.ConditionalCompareObjectEqual(num7, current["osnovica23ne"], false))
                        {
                            row4["iduravrstaiznosa"] = 3;
                        }
                        else if (Operators.ConditionalCompareObjectEqual(num7, current["osnovica10"], false))
                        {
                            row4["iduravrstaiznosa"] = 4;
                        }
                        else if (Operators.ConditionalCompareObjectEqual(num7, current["osnovica10ne"], false))
                        {
                            row4["iduravrstaiznosa"] = 5;
                        }
                        else if (Operators.ConditionalCompareObjectEqual(num7, current["pdv23da"], false))
                        {
                            row4["iduravrstaiznosa"] = 6;
                        }
                        else if (Operators.ConditionalCompareObjectEqual(num7, current["pdv23ne"], false))
                        {
                            row4["iduravrstaiznosa"] = 7;
                        }
                        else if (Operators.ConditionalCompareObjectEqual(num7, current["pdv10da"], false))
                        {
                            row4["iduravrstaiznosa"] = 8;
                        }
                        else if (Operators.ConditionalCompareObjectEqual(num7, current["pdv10ne"], false))
                        {
                            row4["iduravrstaiznosa"] = 9;
                        }
                        else if (Operators.ConditionalCompareObjectEqual(num7, current["osnovica0"], false))
                        {
                            row4["iduravrstaiznosa"] = 10;
                        }
                        else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(num4, current["uraukupno"], false), row["idkonto"].ToString().Substring(0, 1) == "2")))
                        {
                            row4["iduravrstaiznosa"] = 11;
                        }
                        else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(num5, Operators.AddObject(Operators.AddObject(current["osnovica23"], current["osnovica23ne"]), current["pdv23ne"]), false), row["idkonto"].ToString().Substring(0, 1) == "3")))
                        {
                            row4["iduravrstaiznosa"] = 12;
                        }
                        row4["SHEMAURAMTIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["idmjestotroska"]);
                        row4["SHEMAURAOJIDORGJED"] = RuntimeHelpers.GetObjectValue(row["idorgjed"]);
                        row4["SHEMAURAKONTOIDKONTO"] = RuntimeHelpers.GetObjectValue(row["idkonto"]);
                        set4.SHEMAURASHEMAURAKONTIRANJE.Rows.Add(row4);
                    }
                }
                finally
                {
                    if (enumerator2 is IDisposable)
                    {
                        (enumerator2 as IDisposable).Dispose();
                    }
                }
                try
                {
                    adapter3.Update(set4);
                    Interaction.MsgBox("Shema kontiranja pod šifrom " + Conversions.ToString((int) (num6 + 1)) + " za partnera " + Strings.Left(Conversions.ToString(current["nazivpartner"]), 20) + "  spremljena!", MsgBoxStyle.OkOnly, null);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
            }
        }

        public void IzradiShemu_Komplikacija()
        {
            URADataSet set = new URADataSet();
            URADataAdapter adapter = new URADataAdapter();
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.SP_FIN_URAPLACANJEDataSet1, "SP_FIN_URAPLACANJE"];
            if (manager.Count != 0)
            {
                DataRow row = null;
                decimal num5 = 0;
                decimal num6 = 0;
                IEnumerator enumerator = null;
                IEnumerator enumerator2 = null;
                if (this.UltraGrid1.ActiveRow != null)
                {
                    int index = this.UltraGrid1.ActiveRow.Index;
                }
                GKSTAVKADataAdapter adapter2 = new GKSTAVKADataAdapter();
                GKSTAVKADataSet dataSet = new GKSTAVKADataSet();
                URADataAdapter adapter4 = new URADataAdapter();
                DataRowView current = (DataRowView) manager.Current;
                adapter2.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(dataSet, Conversions.ToInteger(current["URADOKIDDOKUMENT"]), Conversions.ToInteger(current["URABROJ"]), Conversions.ToShort(current["URAGODIDGODINE"]));
                try
                {
                    enumerator = dataSet.GKSTAVKA.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        row = (DataRow) enumerator.Current;
                        if (row["idkonto"].ToString().Substring(0, 1) == "2")
                        {
                            int num = 0;
                            num++;
                            num5 = Conversions.ToDecimal(Operators.AddObject(num5, row["potrazuje"]));
                        }
                        else if (row["idkonto"].ToString().Substring(0, 1) == "3")
                        {
                            int num3 = 0;
                            num3++;
                            num6 = Conversions.ToDecimal(Operators.AddObject(num6, row["duguje"]));
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                SHEMAURADataSet set4 = new SHEMAURADataSet();
                SHEMAURADataSet set2 = new SHEMAURADataSet();
                SHEMAURADataAdapter adapter3 = new SHEMAURADataAdapter();
                adapter3.Fill(set2);
                set4.EnforceConstraints = false;
                int num7 = Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(set2.SHEMAURA.Compute("max(idshemaura)", ""))));
                DataRow row2 = set4.SHEMAURA.NewRow();
                row2["idshemaura"] = num7 + 1;
                row2["nazivshemaura"] = Strings.Left(Conversions.ToString(Operators.AddObject(Operators.AddObject(current["nazivpartner"], "-"), current["uranapomena"])), 0x31);
                row2["PARTNERSHEMAURAIDPARTNER"] = RuntimeHelpers.GetObjectValue(current["urapartneridpartner"]);
                set4.SHEMAURA.Rows.Add(row2);
                int num2 = num7 + 1;
                try
                {
                    enumerator2 = dataSet.GKSTAVKA.Rows.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        decimal num8 = 0;
                        row = (DataRow) enumerator2.Current;
                        DataRow row3 = set4.SHEMAURASHEMAURAKONTIRANJE.NewRow();
                        row3["idshemaura"] = num7 + 1;
                        if (Operators.ConditionalCompareObjectGreater(row["duguje"], 0, false))
                        {
                            num8 = Conversions.ToDecimal(row["duguje"]);
                            row3["shemaurastraneidstraneknjizenja"] = 1;
                        }
                        else if (Operators.ConditionalCompareObjectLess(row["duguje"], 0, false))
                        {
                            row3["shemaurastraneidstraneknjizenja"] = 2;
                            num8 = Conversions.ToDecimal(row["duguje"]);
                        }
                        else if (Operators.ConditionalCompareObjectGreater(row["potrazuje"], 0, false))
                        {
                            num8 = Conversions.ToDecimal(row["potrazuje"]);
                            row3["shemaurastraneidstraneknjizenja"] = 3;
                        }
                        else if (Operators.ConditionalCompareObjectLess(row["potrazuje"], 0, false))
                        {
                            num8 = Conversions.ToDecimal(row["potrazuje"]);
                            row3["shemaurastraneidstraneknjizenja"] = 4;
                        }
                        if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(num5, current["uraukupno"], false), row["idkonto"].ToString().Substring(0, 1) == "2")))
                        {
                            row3["iduravrstaiznosa"] = 11;
                        }
                        else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(num6, Operators.AddObject(Operators.AddObject(current["osnovica23"], current["osnovica23ne"]), current["pdv23ne"]), false), row["idkonto"].ToString().Substring(0, 1) == "3")))
                        {
                            row3["iduravrstaiznosa"] = 12;
                        }
                        else if (Operators.ConditionalCompareObjectEqual(num8, current["osnovica10"], false))
                        {
                            row3["iduravrstaiznosa"] = 4;
                        }
                        else if (Operators.ConditionalCompareObjectEqual(num8, current["osnovica10ne"], false))
                        {
                            row3["iduravrstaiznosa"] = 5;
                        }
                        else if (Operators.ConditionalCompareObjectEqual(num8, current["pdv23da"], false))
                        {
                            row3["iduravrstaiznosa"] = 6;
                        }
                        else if (Operators.ConditionalCompareObjectEqual(num8, current["pdv10da"], false))
                        {
                            row3["iduravrstaiznosa"] = 8;
                        }
                        else if (Operators.ConditionalCompareObjectEqual(num8, current["pdv10ne"], false))
                        {
                            row3["iduravrstaiznosa"] = 9;
                        }
                        else if (Operators.ConditionalCompareObjectEqual(num8, current["osnovica0"], false))
                        {
                            row3["iduravrstaiznosa"] = 10;
                        }
                        row3["SHEMAURAMTIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["idmjestotroska"]);
                        row3["SHEMAURAOJIDORGJED"] = RuntimeHelpers.GetObjectValue(row["idorgjed"]);
                        row3["SHEMAURAKONTOIDKONTO"] = RuntimeHelpers.GetObjectValue(row["idkonto"]);
                        set4.SHEMAURASHEMAURAKONTIRANJE.Rows.Add(row3);
                    }
                }
                finally
                {
                    if (enumerator2 is IDisposable)
                    {
                        (enumerator2 as IDisposable).Dispose();
                    }
                }
                try
                {
                    adapter3.Update(set4);
                    Interaction.MsgBox("Shema kontiranja pod šifrom " + Conversions.ToString((int) (num7 + 1)) + " za partnera " + Strings.Left(Conversions.ToString(current["nazivpartner"]), 20) + "  spremljena!", MsgBoxStyle.OkOnly, null);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
            }
        }

        public void Nova()
        {
            int index = 0;
            if (this.UltraGrid1.ActiveRow != null)
            {
                index = this.UltraGrid1.ActiveRow.Index;
            }
            URADataSet set = new URADataSet();
            URADataAdapter adapter = new URADataAdapter();
            DataRow foreignKeys = set.URA.NewRow();
            foreignKeys["uragodidgodine"] = mipsed.application.framework.Application.ActiveYear;
            foreignKeys["URADOKIDDOKUMENT"] = this.dokument;
            foreignKeys["URABROJ"] = this.NUMERACIJA();
            this.Controller1.Insert(foreignKeys);
            this.PuniPodatke(this.dokument, Conversions.ToInteger(foreignKeys["URABROJ"]), Conversions.ToInteger(foreignKeys["URABROJ"]));
            this.Pre_sort();
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

        public int NUMERACIJA()
        {
            int num = 0;
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.Text,
                CommandText = "SELECT MAX(CAST(URABROJ AS INTEGER)) FROM URA WHERE uragodidgodine = @GODINA and URADOKIDDOKUMENT = @iddokument"
            };
            command.Parameters.AddWithValue("@GODINA", mipsed.application.framework.Application.ActiveYear);
            command.Parameters.AddWithValue("@iddokument", this.dokument);
            command.Connection = connection;
            connection.Open();
            try
            {
                num = Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(command.ExecuteScalar())));
                num++;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            connection.Close();
            return num;
        }

        public void PDV_Obrazac(bool stari)
        {
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);
            frmParametriFakturiranja parametriFakturiranja = new frmParametriFakturiranja("URA");
            parametriFakturiranja.CheckBox1.Visible = false;
            parametriFakturiranja.oddatuma.Value = this.pocetni;
            parametriFakturiranja.dodatuma.Value = this.zavrsni;
            if (parametriFakturiranja.ShowDialog() != DialogResult.OK)
                return;
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            sqlCommand1.CommandText = "S_FIN_URA_PLACANJE";
            sqlCommand1.Parameters.AddWithValue("@dat1", RuntimeHelpers.GetObjectValue(parametriFakturiranja.oddatuma.Value));
            sqlCommand1.Parameters.AddWithValue("@dat2", RuntimeHelpers.GetObjectValue(parametriFakturiranja.dodatuma.Value));
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter();
            sqlDataAdapter1.SelectCommand = sqlCommand1;
            sqlDataAdapter1.SelectCommand.Connection = new SqlConnection()
            {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            SP_FIN_URAPLACANJEDataSet uraplacanjeDataSet = new SP_FIN_URAPLACANJEDataSet();
            sqlDataAdapter1.Fill((DataSet)uraplacanjeDataSet, "SP_FIN_URAPLACANJE");
            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.CommandType = CommandType.StoredProcedure;
            sqlCommand2.CommandText = "S_FIN_IRA_PLACANJE";
            sqlCommand2.Parameters.AddWithValue("@dat1", RuntimeHelpers.GetObjectValue(parametriFakturiranja.oddatuma.Value));
            sqlCommand2.Parameters.AddWithValue("@dat2", RuntimeHelpers.GetObjectValue(parametriFakturiranja.dodatuma.Value));
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter();
            sqlDataAdapter2.SelectCommand = sqlCommand2;
            sqlDataAdapter2.SelectCommand.Connection = new SqlConnection()
            {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            S_FIN_IRA_PLACANJEDataSet iraPlacanjeDataSet = new S_FIN_IRA_PLACANJEDataSet();
            sqlDataAdapter2.Fill((DataSet)iraPlacanjeDataSet, "S_FIN_IRA_PLACANJE");
            
            Decimal ira_u_tuzemstvu = 0;
            Decimal ira_osnovica_10 = 0;
            //Decimal d1_1 = 0;
            //Decimal d2_1 = 0;
            Decimal ira_osnovica_25 = 0;
            Decimal ira_pdv_10 = 0;
            //Decimal d1_2 = 0;
            //Decimal d2_2 = 0;
            Decimal ira_pdv_25 = 0;
            Decimal ira_izvoz = 0;
            Decimal ira_osnovica_05 = 0;
            Decimal ira_pdv_05 = 0;
            Decimal ira_tuzemni_prijenos = 0;
            Decimal ira_neoporezivo_dobra = 0;
            Decimal ira_neoporezivo_usluga = 0;
            Decimal ira_ostalo = 0;

            try
            {
                foreach (DataRow dataRow in iraPlacanjeDataSet.S_FIN_IRA_PLACANJE.Rows)
                {
                    ira_u_tuzemstvu = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_u_tuzemstvu, dataRow["TUZEMSTVO"]));
                    ira_izvoz = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_izvoz, dataRow["IZVOZ"]));
                    ira_osnovica_05 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_osnovica_05, dataRow["OSN05"]));
                    ira_pdv_05 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_pdv_05, dataRow["PDV05"]));
                    ira_tuzemni_prijenos = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_tuzemni_prijenos, dataRow["MEDJTRANS"]));
                    ira_neoporezivo_dobra = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_neoporezivo_dobra, dataRow["NEPODLEZE"]));
                    ira_neoporezivo_usluga = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_neoporezivo_usluga, dataRow["NEPODLEZE_USLUGA"]));
                    ira_ostalo = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_ostalo, dataRow["OSTALO"]));
                    ira_osnovica_10 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_osnovica_10, dataRow["OSN10"]));
                    //d1_1 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(d1_1, dataRow["OSN22"]));
                    //d2_1 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(d2_1, dataRow["OSN23"]));
                    ira_osnovica_25 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_osnovica_25, dataRow["OSN25"]));
                    ira_pdv_10 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_pdv_10, dataRow["PDV10"]));
                    //d1_2 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(d1_2, dataRow["PDV22"]));
                    //d2_2 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(d2_2, dataRow["PDV23"]));
                    ira_pdv_25 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_pdv_25, dataRow["PDV25"]));
                }
            }
            finally
            {
                IEnumerator enumerator = null;
                if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
            }
            Decimal ura_osnovica_10 = 0;
            Decimal ura_pdv_10 = 0;
            Decimal ura_osnovica_25 = 0;
            Decimal ura_pdv_25 = 0;
            Decimal ura_osnovica_05 = 0;
            Decimal ura_pdv_05 = 0;
            Decimal osnovicaPPO = 0;
            Decimal mozePPO = 0;
            Decimal neMozePPO = 0;
            try
            {
                foreach (DataRow dataRow in uraplacanjeDataSet.SP_FIN_URAPLACANJE.Rows)
                {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["R2"], true, false))
                    {
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["ZATVARANJE_IZNOS"], dataRow["URAUKUPNO"], false))
                        {
                            ura_osnovica_05 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_osnovica_05, dataRow["OSNOVICA5"]));
                            ura_osnovica_10 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_osnovica_10, dataRow["OSNOVICA10"]));
                            ura_osnovica_25 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_osnovica_25, dataRow["OSNOVICA25"]));

                            ura_pdv_05 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_pdv_05, dataRow["PDV5DA"]));
                            ura_pdv_10 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_pdv_10, dataRow["PDV10DA"]));
                            ura_pdv_25 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_pdv_25, dataRow["PDV25DA"]));

                            osnovicaPPO = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(osnovicaPPO, dataRow["OsnovicaPPO"]));
                            mozePPO = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(mozePPO, dataRow["MozePPO"]));
                            neMozePPO = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(neMozePPO, dataRow["NeMozePPO"]));
                        }
                    }
                    else
                    {
                        ura_osnovica_05 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_osnovica_05, dataRow["OSNOVICA5"]));
                        ura_osnovica_10 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_osnovica_10, dataRow["OSNOVICA10"]));
                        ura_osnovica_25 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_osnovica_25, dataRow["OSNOVICA25"]));

                        ura_pdv_05 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_pdv_05, dataRow["PDV5DA"]));
                        ura_pdv_10 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_pdv_10, dataRow["PDV10DA"]));
                        ura_pdv_25 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_pdv_25, dataRow["PDV25DA"]));

                        osnovicaPPO = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(osnovicaPPO, dataRow["OsnovicaPPO"]));
                        mozePPO = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(mozePPO, dataRow["MozePPO"]));
                        neMozePPO = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(neMozePPO, dataRow["NeMozePPO"]));
                    }
                }
            }
            finally
            {
                IEnumerator enumerator = null;
                if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
            }
            this.Cursor = Cursors.Default;
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Interaction.CreateObject("Excel.Application", "");
            Workbook workbook;
            if (stari)
            {

                workbook = application.Workbooks.Open(System.Windows.Forms.Application.StartupPath + @"\App_Data\PDV_obrazac_2014.xls", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
            else
            {
                workbook = application.Workbooks.Open(System.Windows.Forms.Application.StartupPath + @"\App_Data\PDV_obrazac_2015.xls", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }

            Worksheet worksheet = (Worksheet)workbook.Sheets["Sheet 1"];
            application.DisplayAlerts = false;

            //tuzemni prijenos
            NewLateBinding.LateSetComplex(worksheet.Cells[14, 7], (System.Type)null, "value", new object[1] { ira_tuzemni_prijenos }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //neoporezivo dobra
            NewLateBinding.LateSetComplex(worksheet.Cells[16, 7], (System.Type)null, "value", new object[1] { ira_neoporezivo_dobra }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //neoporezivo usluge
            NewLateBinding.LateSetComplex(worksheet.Cells[17, 7], (System.Type)null, "value", new object[1] { ira_neoporezivo_usluga }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //u tuzemstvu
            NewLateBinding.LateSetComplex(worksheet.Cells[21, 7], (System.Type)null, "value", new object[1] { ira_u_tuzemstvu }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //izvoz
            NewLateBinding.LateSetComplex(worksheet.Cells[22, 7], (System.Type)null, "value", new object[1] { ira_izvoz }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //ostalo
            NewLateBinding.LateSetComplex(worksheet.Cells[23, 7], (System.Type)null, "value", new object[1] { ira_ostalo }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //osnovica 5%
            NewLateBinding.LateSetComplex(worksheet.Cells[25, 7], (System.Type)null, "value", new object[1] { ira_osnovica_05 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //pdv 5%
            NewLateBinding.LateSetComplex(worksheet.Cells[25, 8], (System.Type)null, "value", new object[1] { ira_pdv_05 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //osnovica 10%
            NewLateBinding.LateSetComplex(worksheet.Cells[26, 7], (System.Type)null, "value", new object[1] { ira_osnovica_10 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //pdv 10%
            NewLateBinding.LateSetComplex(worksheet.Cells[26, 8], (System.Type)null, "value", new object[1] { ira_pdv_10 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //osnovica 25%
            NewLateBinding.LateSetComplex(worksheet.Cells[27, 7], (System.Type)null, "value", new object[1] { ira_osnovica_25 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);

            //PPO
            NewLateBinding.LateSetComplex(worksheet.Cells[28, 7], (System.Type)null, "value", new object[1] { osnovicaPPO }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            NewLateBinding.LateSetComplex(worksheet.Cells[28, 8], (System.Type)null, "value", new object[1] { neMozePPO }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);

            //pdv 25%
            NewLateBinding.LateSetComplex(worksheet.Cells[27, 8], (System.Type)null, "value", new object[1] { ira_pdv_25 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //pretporez od primljenih isporuka u tuzemstvu
            if (stari)
            {
                NewLateBinding.LateSetComplex(worksheet.Cells[40, 7], (System.Type)null, "value", new object[1] { Math.Round(ura_pdv_05 / 0.05M, 2) }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
                NewLateBinding.LateSetComplex(worksheet.Cells[40, 8], (System.Type)null, "value", new object[1] { ura_pdv_05 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
                NewLateBinding.LateSetComplex(worksheet.Cells[41, 7], (System.Type)null, "value", new object[1] { Math.Round(ura_pdv_10 / 0.13M, 2) }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
                NewLateBinding.LateSetComplex(worksheet.Cells[41, 8], (System.Type)null, "value", new object[1] { ura_pdv_10 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
                NewLateBinding.LateSetComplex(worksheet.Cells[42, 7], (System.Type)null, "value", new object[1] { Math.Round(ura_pdv_25 / 0.25M, 2) }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
                NewLateBinding.LateSetComplex(worksheet.Cells[42, 8], (System.Type)null, "value", new object[1] { ura_pdv_25 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);

                NewLateBinding.LateSetComplex(worksheet.Cells[43, 7], (System.Type)null, "value", new object[1] { Math.Round(mozePPO / 0.25M, 2) }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
                NewLateBinding.LateSetComplex(worksheet.Cells[43, 8], (System.Type)null, "value", new object[1] { mozePPO }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            }
            else
            {
                NewLateBinding.LateSetComplex(worksheet.Cells[41, 7], (System.Type)null, "value", new object[1] { Math.Round(ura_pdv_05 / 0.05M, 2) }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
                NewLateBinding.LateSetComplex(worksheet.Cells[41, 8], (System.Type)null, "value", new object[1] { ura_pdv_05 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
                NewLateBinding.LateSetComplex(worksheet.Cells[42, 7], (System.Type)null, "value", new object[1] { Math.Round(ura_pdv_10 /0.13M, 2) }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
                NewLateBinding.LateSetComplex(worksheet.Cells[42, 8], (System.Type)null, "value", new object[1] { ura_pdv_10 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
                NewLateBinding.LateSetComplex(worksheet.Cells[43, 7], (System.Type)null, "value", new object[1] { Math.Round(ura_pdv_25/ 0.25M, 2) }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
                NewLateBinding.LateSetComplex(worksheet.Cells[43, 8], (System.Type)null, "value", new object[1] { ura_pdv_25 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);

                NewLateBinding.LateSetComplex(worksheet.Cells[44, 7], (System.Type)null, "value", new object[1] { Math.Round(mozePPO/ 0.25M, 2) }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
                NewLateBinding.LateSetComplex(worksheet.Cells[44, 8], (System.Type)null, "value", new object[1] { mozePPO }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            }

            //porezni obveznik
            string obveznik = RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]).ToString() + " " + 
                              RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"]) + " " + RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]);
            NewLateBinding.LateSetComplex(worksheet.Cells[4, 1], (System.Type)null, "VALUE", new object[1] { obveznik }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //oib
            NewLateBinding.LateSetComplex(worksheet.Cells[8, 1], (System.Type)null, "VALUE", new object[1] { RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]) }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //nadlezna ispostava porezne uprave
            NewLateBinding.LateSetComplex(worksheet.Cells[4, 7], (System.Type)null, "VALUE", new object[1] { RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["NADLEZNAPU"]) }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //prijava pdv-a za razdoblje
            string odDoDatuma = string.Format("OD {0:dd.MM.}     DO {1:dd.MM.}     GOD. {0:yyyy}", parametriFakturiranja.oddatuma.Value, parametriFakturiranja.dodatuma.Value);
            NewLateBinding.LateSetComplex(worksheet.Cells[8, 7], (System.Type)null, "VALUE", new object[1] { odDoDatuma }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //obracun sastavio
            if (stari)
            {
                NewLateBinding.LateSetComplex(worksheet.Cells[67, 1], (System.Type)null, "VALUE", new object[1] { RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["kontaktosoba"]) }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            }
            else
            {
                NewLateBinding.LateSetComplex(worksheet.Cells[88, 1], (System.Type)null, "VALUE", new object[1] { RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["kontaktosoba"]) }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            }
            application.Visible = false;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Conversions.ToString(0);
            saveFileDialog.Filter = "Excel datoteke (*.xls)|*.xls|All files (*.*)|*.*";
            saveFileDialog.FileName = "PDV_Obrazac";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                workbook.SaveAs(saveFileDialog.FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                
                Thread.CurrentThread.CurrentCulture = currentCulture;
                application.Quit();
                Interaction.MsgBox((object)("PDV obrazac uspješno spremljen u: " + saveFileDialog.FileName), MsgBoxStyle.OkOnly, null);
            }
            catch (System.Exception ex)
            {
                throw ex;

                //Thread.CurrentThread.CurrentCulture = currentCulture;
                //application.Quit();
            }
        }

        public void PDV_ObrazacZatvoreni()
        {
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);
            frmParametriFakturiranja parametriFakturiranja = new frmParametriFakturiranja("URA");
            parametriFakturiranja.CheckBox1.Visible = false;
            parametriFakturiranja.oddatuma.Value = this.pocetni;
            parametriFakturiranja.dodatuma.Value = this.zavrsni;
            if (parametriFakturiranja.ShowDialog() != DialogResult.OK)
                return;
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            sqlCommand1.CommandText = "S_FIN_URA_PLACANJE";
            sqlCommand1.Parameters.AddWithValue("@dat1", RuntimeHelpers.GetObjectValue(parametriFakturiranja.oddatuma.Value));
            sqlCommand1.Parameters.AddWithValue("@dat2", RuntimeHelpers.GetObjectValue(parametriFakturiranja.dodatuma.Value));
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter();
            sqlDataAdapter1.SelectCommand = sqlCommand1;
            sqlDataAdapter1.SelectCommand.Connection = new SqlConnection()
            {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            SP_FIN_URAPLACANJEDataSet uraplacanjeDataSet = new SP_FIN_URAPLACANJEDataSet();
            sqlDataAdapter1.Fill((DataSet)uraplacanjeDataSet, "SP_FIN_URAPLACANJE");
            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.CommandType = CommandType.StoredProcedure;
            sqlCommand2.CommandText = "S_FIN_IRA_PLACANJE";
            sqlCommand2.Parameters.AddWithValue("@dat1", RuntimeHelpers.GetObjectValue(parametriFakturiranja.oddatuma.Value));
            sqlCommand2.Parameters.AddWithValue("@dat2", RuntimeHelpers.GetObjectValue(parametriFakturiranja.dodatuma.Value));
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter();
            sqlDataAdapter2.SelectCommand = sqlCommand2;
            sqlDataAdapter2.SelectCommand.Connection = new SqlConnection()
            {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            S_FIN_IRA_PLACANJEDataSet iraPlacanjeDataSet = new S_FIN_IRA_PLACANJEDataSet();
            sqlDataAdapter2.Fill((DataSet)iraPlacanjeDataSet, "S_FIN_IRA_PLACANJE");

            Decimal ira_u_tuzemstvu = 0;
            Decimal ira_osnovica_10 = 0;
            //Decimal d1_1 = 0;
            //Decimal d2_1 = 0;
            Decimal ira_osnovica_25 = 0;
            Decimal ira_pdv_10 = 0;
            //Decimal d1_2 = 0;
            //Decimal d2_2 = 0;
            Decimal ira_pdv_25 = 0;
            Decimal ira_izvoz = 0;
            Decimal ira_osnovica_05 = 0;
            Decimal ira_pdv_05 = 0;
            Decimal ira_tuzemni_prijenos = 0;
            Decimal ira_neoporezivo_dobra = 0;
            Decimal ira_neoporezivo_usluga = 0;
            Decimal ira_ostalo = 0;

            decimal parser;

            try
            {
                foreach (DataRow dataRow in iraPlacanjeDataSet.S_FIN_IRA_PLACANJE.Rows)
                {
                    decimal.TryParse(dataRow["ZATVARANJE_IZNOS"].ToString(), out parser);

                    if(parser > 0)
                    {
                        ira_u_tuzemstvu = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_u_tuzemstvu, dataRow["TUZEMSTVO"]));
                        ira_izvoz = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_izvoz, dataRow["IZVOZ"]));
                        ira_osnovica_05 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_osnovica_05, dataRow["OSN05"]));
                        ira_pdv_05 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_pdv_05, dataRow["PDV05"]));
                        ira_tuzemni_prijenos = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_tuzemni_prijenos, dataRow["MEDJTRANS"]));
                        ira_neoporezivo_dobra = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_neoporezivo_dobra, dataRow["NEPODLEZE"]));
                        ira_neoporezivo_usluga = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_neoporezivo_usluga, dataRow["NEPODLEZE_USLUGA"]));
                        ira_ostalo = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_ostalo, dataRow["OSTALO"]));
                        ira_osnovica_10 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_osnovica_10, dataRow["OSN10"]));
                        ira_osnovica_25 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_osnovica_25, dataRow["OSN25"]));
                        ira_pdv_10 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_pdv_10, dataRow["PDV10"]));
                        ira_pdv_25 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ira_pdv_25, dataRow["PDV25"]));

                    }
                }
            }
            finally
            {
                IEnumerator enumerator = null;
                if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
            }
            Decimal ura_osnovica_10 = 0;
            Decimal ura_pdv_10 = 0;
            Decimal ura_osnovica_25 = 0;
            Decimal ura_pdv_25 = 0;
            Decimal ura_osnovica_05 = 0;
            Decimal ura_pdv_05 = 0;
            try
            {
                foreach (DataRow dataRow in uraplacanjeDataSet.SP_FIN_URAPLACANJE.Rows)
                {
                    decimal.TryParse(dataRow["ZATVARANJE_IZNOS"].ToString(), out parser);

                    if (parser > 0)
                    {

                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["R2"], true, false))
                        {
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["ZATVARANJE_IZNOS"], dataRow["URAUKUPNO"], false))
                            {
                                ura_osnovica_05 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_osnovica_05, dataRow["OSNOVICA5"]));
                                ura_osnovica_10 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_osnovica_10, dataRow["OSNOVICA10"]));
                                ura_osnovica_25 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_osnovica_25, dataRow["OSNOVICA25"]));
                                ura_pdv_05 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_pdv_05, dataRow["PDV5DA"]));
                                ura_pdv_10 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_pdv_10, dataRow["PDV10DA"]));
                                ura_pdv_25 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_pdv_25, dataRow["PDV25DA"]));
                            }
                        }
                        else
                        {
                            ura_osnovica_05 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_osnovica_05, dataRow["OSNOVICA5"]));
                            ura_osnovica_10 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_osnovica_10, dataRow["OSNOVICA10"]));
                            ura_osnovica_25 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_osnovica_25, dataRow["OSNOVICA25"]));
                            ura_pdv_05 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_pdv_05, dataRow["PDV5DA"]));
                            ura_pdv_10 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_pdv_10, dataRow["PDV10DA"]));
                            ura_pdv_25 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(ura_pdv_25, dataRow["PDV25DA"]));
                        }
                    }
                }
            }
            finally
            {
                IEnumerator enumerator = null;
                if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
            }
            this.Cursor = Cursors.Default;
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Interaction.CreateObject("Excel.Application", "");

            Workbook workbook = application.Workbooks.Open(System.Windows.Forms.Application.StartupPath + @"\App_Data\PDV_obrazac_2015.xls", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            Worksheet worksheet = (Worksheet)workbook.Sheets["Sheet 1"];
            application.DisplayAlerts = false;

            //tuzemni prijenos
            NewLateBinding.LateSetComplex(worksheet.Cells[14, 7], (System.Type)null, "value", new object[1] { ira_tuzemni_prijenos }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //neoporezivo dobra
            NewLateBinding.LateSetComplex(worksheet.Cells[16, 7], (System.Type)null, "value", new object[1] { ira_neoporezivo_dobra }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //neoporezivo usluge
            NewLateBinding.LateSetComplex(worksheet.Cells[17, 7], (System.Type)null, "value", new object[1] { ira_neoporezivo_usluga }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //u tuzemstvu
            NewLateBinding.LateSetComplex(worksheet.Cells[21, 7], (System.Type)null, "value", new object[1] { ira_u_tuzemstvu }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //izvoz
            NewLateBinding.LateSetComplex(worksheet.Cells[22, 7], (System.Type)null, "value", new object[1] { ira_izvoz }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //ostalo
            NewLateBinding.LateSetComplex(worksheet.Cells[23, 7], (System.Type)null, "value", new object[1] { ira_ostalo }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //osnovica 5%
            NewLateBinding.LateSetComplex(worksheet.Cells[25, 7], (System.Type)null, "value", new object[1] { ira_osnovica_05 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //pdv 5%
            NewLateBinding.LateSetComplex(worksheet.Cells[25, 8], (System.Type)null, "value", new object[1] { ira_pdv_05 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //osnovica 10%
            NewLateBinding.LateSetComplex(worksheet.Cells[26, 7], (System.Type)null, "value", new object[1] { ira_osnovica_10 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //pdv 10%
            NewLateBinding.LateSetComplex(worksheet.Cells[26, 8], (System.Type)null, "value", new object[1] { ira_pdv_10 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //osnovica 25%
            NewLateBinding.LateSetComplex(worksheet.Cells[27, 7], (System.Type)null, "value", new object[1] { ira_osnovica_25 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //pdv 25%
            NewLateBinding.LateSetComplex(worksheet.Cells[27, 8], (System.Type)null, "value", new object[1] { ira_pdv_25 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //pretporez od primljenih isporuka u tuzemstvu
            NewLateBinding.LateSetComplex(worksheet.Cells[41, 7], (System.Type)null, "value", new object[1] { ura_osnovica_05 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            NewLateBinding.LateSetComplex(worksheet.Cells[41, 8], (System.Type)null, "value", new object[1] { ura_pdv_05 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            NewLateBinding.LateSetComplex(worksheet.Cells[42, 7], (System.Type)null, "value", new object[1] { ura_osnovica_10 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            NewLateBinding.LateSetComplex(worksheet.Cells[42, 8], (System.Type)null, "value", new object[1] { ura_pdv_10 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            NewLateBinding.LateSetComplex(worksheet.Cells[43, 7], (System.Type)null, "value", new object[1] { ura_osnovica_25 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            NewLateBinding.LateSetComplex(worksheet.Cells[43, 8], (System.Type)null, "value", new object[1] { ura_pdv_25 }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);

            //porezni obveznik
            string obveznik = RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]).ToString() + " " +
                              RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"]) + " " + RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]);
            NewLateBinding.LateSetComplex(worksheet.Cells[4, 1], (System.Type)null, "VALUE", new object[1] { obveznik }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //oib
            NewLateBinding.LateSetComplex(worksheet.Cells[8, 1], (System.Type)null, "VALUE", new object[1] { RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]) }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //nadlezna ispostava porezne uprave
            NewLateBinding.LateSetComplex(worksheet.Cells[4, 7], (System.Type)null, "VALUE", new object[1] { RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["NADLEZNAPU"]) }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //prijava pdv-a za razdoblje
            string odDoDatuma = string.Format("OD {0:dd.MM.}     DO {1:dd.MM.}     GOD. {0:yyyy}", parametriFakturiranja.oddatuma.Value, parametriFakturiranja.dodatuma.Value);
            NewLateBinding.LateSetComplex(worksheet.Cells[8, 7], (System.Type)null, "VALUE", new object[1] { odDoDatuma }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);
            //obracun sastavio
            NewLateBinding.LateSetComplex(worksheet.Cells[88, 1], (System.Type)null, "VALUE", new object[1] { RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["kontaktosoba"]) }, (string[])null, (System.Type[])null, 0 != 0, 1 != 0);

            application.Visible = false;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Conversions.ToString(0);
            saveFileDialog.Filter = "Excel datoteke (*.xls)|*.xls|All files (*.*)|*.*";
            saveFileDialog.FileName = "PDV_Obrazac";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                workbook.SaveAs(saveFileDialog.FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                Thread.CurrentThread.CurrentCulture = currentCulture;
                application.Quit();
                Interaction.MsgBox((object)("PDV obrazac uspješno spremljen u: " + saveFileDialog.FileName), MsgBoxStyle.OkOnly, null);
            }
            catch (System.Exception ex)
            {
                throw ex;

                //Thread.CurrentThread.CurrentCulture = currentCulture;
                //application.Quit();
            }
        }

        public void Pre_sort()
        {
            this.UltraGrid1.DisplayLayout.Bands[0].Columns["URABROJ"].Band.SortedColumns.RefreshSort(true);
            this.UltraGrid1.Refresh();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!((msg.Msg == 0x100) | (msg.Msg == 260)))
            {
                bool flag = false;
                return flag;
            }
            if (keyData == Keys.Escape)
            {
                this.ParentForm.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void Proknjizi_sve_Dokumente()
        {
            IEnumerator enumerator = null;
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            connection.Open();
            try
            {
                enumerator = this.SP_FIN_URAPLACANJEDataSet1.SP_FIN_URAPLACANJE.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    if (current.RowState != DataRowState.Deleted)
                    {
                        SqlCommand command = new SqlCommand {
                            CommandType = CommandType.StoredProcedure,
                            Connection = connection,
                            CommandText = "S_FIN_PROMJENA_STATUSA"
                        };
                        command.Parameters.Add("@BROJDOKUMENTA", SqlDbType.Char, 5).Value = RuntimeHelpers.GetObjectValue(current["URABROJ"]);
                        command.Parameters.Add("@IDDOKUMENT", SqlDbType.Char, 5).Value = RuntimeHelpers.GetObjectValue(current["URADOKIDDOKUMENT"]);
                        command.Parameters.Add("@GODINA", SqlDbType.Int).Value = DateAndTime.Year(this.zavrsni);
                        command.Parameters.Add("@STATUSGK", SqlDbType.Bit).Value = true;
                        try
                        {
                            command.ExecuteNonQuery();
                            continue;
                        }
                        catch (System.Exception exception1)
                        {
                            throw exception1;
                            //continue;
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            Interaction.MsgBox("Svi dokumenti ulaznih računa kod kojih je saldo 0, proknjiženi u glavnu knjigu", MsgBoxStyle.Information, "Radnja izvršena");
            connection.Close();
        }

        public void PuniPodatke(int iddokument, int od, int doo)
        {
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.StoredProcedure,
                CommandText = "S_FIN_URA_PLACANJE"
            };
            command.Parameters.AddWithValue("@IDDOKUMENT", iddokument);
            command.Parameters.AddWithValue("@dat1", this.pocetni);
            command.Parameters.AddWithValue("@dat2", this.zavrsni);
            command.Parameters.AddWithValue("@od", od);
            command.Parameters.AddWithValue("@doo", doo);
            SqlDataAdapter adapter = new SqlDataAdapter {
                SelectCommand = command
            };
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            adapter.SelectCommand.Connection = connection;
            adapter.Fill(this.SP_FIN_URAPLACANJEDataSet1, "SP_FIN_URAPLACANJE");
        }

        private void SetSmartPartInfoInformation()
        {
            this.smartPartInfo1.Description = "Knjiga ulaznih računa";
        }

        private void TestSmartPart_Load(object sender, EventArgs e)
        {
            SP_FIN_URAPLACANJEDataAdapter adapter2 = new SP_FIN_URAPLACANJEDataAdapter();
            uraDocsDataAdapter adapter = new uraDocsDataAdapter();
            DOKUMENTDataSet dataSet = new DOKUMENTDataSet();
            adapter.Fill(dataSet);
            if (dataSet.DOKUMENT.Rows.Count == 1)
            {
                this.dokument = Conversions.ToInteger(dataSet.DOKUMENT.Rows[0]["iddokument"]);
            }
            else
            {
                //prikaz kontrole za odabir vrste dokumenta
                DOKUMENTSelectionListWorkItem item = this.Controller1.WorkItem.Items.AddNew<DOKUMENTSelectionListWorkItem>("test");
                DataRow row2 = item.ShowModal(true, "", null);
                item.Terminate();
                if (row2 == null)
                {
                    return;
                }
                this.dokument = Conversions.ToInteger(row2["iddokument"]);
            }


            this.pocetni = mipsed.application.framework.Application.Pocetni;
            this.zavrsni = mipsed.application.framework.Application.Zavrsni;
            this.PuniPodatke(this.dokument, 1, 0x1869f);
            this.work = (UltraExplorerBarWorkspace) this.Controller1.WorkItem.Workspaces["TaskPanel"];
            this.Controller1.WorkItem.Workspaces["Dock"].Hide(this.work);
            this.UltraGrid1.DisplayLayout.Bands[0].Columns["URABROJ"].SortIndicator = SortIndicator.Descending;
            this.UltraGrid1.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Bands[0].Override.FilterUIType = FilterUIType.FilterRow;
        }

        private void ToolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Name == "ToolBarButton1")
            {
                this.Nova();
            }
            if (e.Button.Name == "ToolBarButton2")
            {
                this.Brisanje();
            }
            if (e.Button.Name == "ToolBarButton4")
            {
                this.Izmjena();
            }
            if (e.Button.Name == "ToolBarButton6")
            {
                this.Ispis_Ura();
            }
            if (e.Button.Name == "ToolBarButton3")
            {
                this.Proknjizi_sve_Dokumente();
            }
            if (e.Button.Name == "ToolBarButton5")
            {
                this.Virmani();
            }
            if (e.Button.Name == "ToolBarButton7")
            {
                this.IzradiShemu();
            }
            if (e.Button.Name == "ToolBarButton8")
            {
                this.Ispis_Ura_pdV();
            }
            if (e.Button.Name == "ToolBarButton9")
            {
                DialogResult result = MessageBox.Show("Za obrazac 2014 odaberite Yes, a za obrazac 2015 odaberite No", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    this.PDV_Obrazac(true);
                }
                else
                {
                    this.PDV_Obrazac(false);
                }
            }
            if (e.Button.Name == "ToolBarButton10")
            {
                this.PDV_ObrazacZatvoreni();
            }
        }

        private void UltraGrid1_AfterCellUpdate(object sender, CellEventArgs e)
        {
        }

        private void UltraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            this.Izmjena();
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (decimal.Compare(decimal.Subtract(DB.N20(RuntimeHelpers.GetObjectValue(e.Row.Cells["URAUKUPNO"].Value)), DB.N20(RuntimeHelpers.GetObjectValue(e.Row.Cells["ZATVARANJE_IZNOS"].Value))), decimal.Zero) > 0)
            {
                e.Row.Appearance.ForeColor = Color.Red;
            }
            if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(e.Row.Cells["URAUKUPNO"].Value)), decimal.Zero) < 0)
            {
                e.Row.Appearance.ForeColor = Color.Green;
            }
        }

        private void UraSmartPart_Leave(object sender, EventArgs e)
        {
            try
            {
                UltraDockSmartPartInfo smartPartInfo = new UltraDockSmartPartInfo
                {
                    DefaultPaneStyle = ChildPaneStyle.VerticalSplit,
                    Description = Deklarit.Resources.Resources.Tasks
                };
                Size size = new System.Drawing.Size(210, 100);
                smartPartInfo.PreferredSize = size;
                smartPartInfo.Title = Deklarit.Resources.Resources.Tasks;
                smartPartInfo.DefaultLocation = DockedLocation.DockedRight;
                this.Controller1.WorkItem.Workspaces["Dock"].Show(this.work, smartPartInfo);
            }
            catch { }
        }

        public void Virmani()
        {
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            VirmaniWorkItemUser user = this.Controller1.WorkItem.Items.Get<VirmaniWorkItemUser>("Virmani");
            if (user == null)
            {
                user = this.Controller1.WorkItem.Items.AddNew<VirmaniWorkItemUser>("Virmani");
            }
            user.Show(user.Workspaces["main"]);
        }

        private AutoHideControl _TestSmartPartAutoHideControl;

        private UnpinnedTabArea _TestSmartPartUnpinnedTabAreaBottom;

        private UnpinnedTabArea _TestSmartPartUnpinnedTabAreaLeft;

        private UnpinnedTabArea _TestSmartPartUnpinnedTabAreaRight;

        private UnpinnedTabArea _TestSmartPartUnpinnedTabAreaTop;

        [CreateNew]
        public URAWorkWithController Controller1 { get; set; }

        [CreateNew]
        public BLAGAJNAController Controller2 { get; set; }

        [CreateNew]
        public SHEMAURAWorkWithController Controller3 { get; set; }

        public int CurrentRowIndex
        {
            get
            {
                if (this.UltraGrid1.ActiveRow == null)
                {
                    return -1;
                }
                UltraGridRow activeRow = this.UltraGrid1.ActiveRow;
                while ((activeRow.ParentRow != null) && !(activeRow.ParentRow is UltraGridGroupByRow))
                {
                    activeRow = activeRow.ParentRow;
                }
                return activeRow.ListIndex;
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.FillByRow
        {
            set
            {
            }
        }

        string Deklarit.Practices.CompositeUI.IFilteredView.FillMethod
        {
            set
            {
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode Deklarit.Practices.CompositeUI.IFilteredView.WorkWithMode
        {
            set
            {
            }
        }

        private DockableWindow DockableWindow1;

        public DataRow FillByRow
        {
            set
            {
            }
        }

        public string FillMethod
        {
            set
            {
            }
        }

        private ImageList ImageList1;

        private Panel Panel1;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private SP_FIN_URAPLACANJEDataSet SP_FIN_URAPLACANJEDataSet1;

        private ToolBar ToolBar1;

        private ToolBarButton ToolBarButton1;

        private ToolBarButton ToolBarButton2;

        private ToolBarButton ToolBarButton3;

        private ToolBarButton ToolBarButton4;

        private ToolBarButton ToolBarButton5;

        private ToolBarButton ToolBarButton6;

        private ToolBarButton ToolBarButton7;

        private ToolBarButton ToolBarButton8;

        private ToolBarButton ToolBarButton9;

        private ToolBarButton ToolBarButton10;

        private UltraCalcManager UltraCalcManager1;

        private UltraDockManager UltraDockManager1;

        private UltraGrid UltraGrid1;

        private WindowDockingArea WindowDockingArea1;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

