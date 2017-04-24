using Deklarit.Resources;
using FinPosModule;
using My.Resources;
using Infragistics.Win;
using Infragistics.Win.UltraWinCalcManager;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Placa;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


namespace FinPosModule.Pregledi
{
    public class frmPregledKontoKartica : Form
    {
        private IContainer components;
        public S_FIN_KONTO_KARTICEDataSet ds;
        private SmartPartInfoProvider infoProvider;
        private bool m_bDisablePosCHange { get; set; }
        private SmartPartInfo smartPartInfo1;

        public frmPregledKontoKartica()
        {
            base.Load += new EventHandler(this.frmPregledKontoKartica_Load);
            this.ds = new S_FIN_KONTO_KARTICEDataSet();
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(string.Format("Zatvaranje stavaka-saldakonti", "Zatvaranje stavaka"), string.Format(Deklarit.Resources.Resources.WorkWithTitle, "Zatvaranje stavaka"));
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void __cmManager_PositionChanged(object sender, EventArgs e)
        {
            if (!this.m_bDisablePosCHange && (this.__cmManager.Count != 0))
            {
                DataRowView current = (DataRowView) this.__cmManager.Current;
                this.UltraGrid1.DisplayLayout.Bands[0].ColumnFilters["KONTO"].FilterConditions.Clear();
                this.UltraGrid1.DisplayLayout.Bands[0].ColumnFilters["KONTO"].FilterConditions.Add(FilterComparisionOperator.Contains, RuntimeHelpers.GetObjectValue(current["KONTO"]));
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmPregledKontoKartica_Load(object sender, EventArgs e)
        {
            IEnumerator enumerator = null;
            this.UltraGrid1.DataSource = this.ds;
            this.UltraGrid1.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            DataView view = new DataView {
                Table = this.ds.S_FIN_KONTO_KARTICE
            };
            DataTable table = this.ds.S_FIN_KONTO_KARTICE.DefaultView.ToTable(true, new string[0]);
            try
            {
                enumerator = table.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    if (this.DsKonto1.KONTO.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("konto = '", current["konto"]), "'"))).Length == 0)
                    {
                        DataRow row = this.DsKonto1.KONTO.NewRow();
                        row["KONTO"] = RuntimeHelpers.GetObjectValue(current["KONTO"]);
                        this.DsKonto1.KONTO.Rows.Add(row);
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
            this.__cmManager = (CurrencyManager) this.BindingContext[this.DsKonto1, "KONTO"];
            this.__cmManager.PositionChanged += new EventHandler(this.__cmManager_PositionChanged);
            this.__cmManager_PositionChanged(null, null);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem ultraExplorerBarItem1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledKontoKartica));
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem ultraExplorerBarItem2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KONTO", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KONTO", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedRight, new System.Guid("645f327f-e173-48f9-ae04-fbb07b9a4fb0"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("30336444-8313-49b3-8c2b-3ff4576ac81a"), new System.Guid("62f8ee16-e4ff-48bb-810d-3cc617a37d9c"), 0, new System.Guid("645f327f-e173-48f9-ae04-fbb07b9a4fb0"), 0);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, new System.Guid("62f8ee16-e4ff-48bb-810d-3cc617a37d9c"));
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane3 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, new System.Guid("7630003f-4351-41cc-adad-dfc9ee74218b"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("0bcc809c-71bf-4eef-ac2e-91f8540e8c92"), new System.Guid("7630003f-4351-41cc-adad-dfc9ee74218b"), 0, new System.Guid("aa402c86-599b-467c-b2ea-8cb3e6c0deff"), 0);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane4 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, new System.Guid("c7784784-cc54-4f93-b256-3b980cb31e9e"));
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane5 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("dec3392f-6cc9-4593-8133-fd6421919867"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane3 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("371591bf-6fd7-4355-8b0a-5f799cebc201"), new System.Guid("c7784784-cc54-4f93-b256-3b980cb31e9e"), 0, new System.Guid("dec3392f-6cc9-4593-8133-fd6421919867"), 0);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane6 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("aa402c86-599b-467c-b2ea-8cb3e6c0deff"));
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("S_FIN_KONTO_KARTICE", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("duguje");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POTRAZUJE");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("konto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMDOK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SKRACENI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJDOK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJSTAVKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISKNJIZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ORIGINALNIDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOJ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVMT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PS");
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "duguje", 0, true, "S_FIN_KONTO_KARTICE", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "duguje", 0, true);
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings2 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "POTRAZUJE", 1, true, "S_FIN_KONTO_KARTICE", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "POTRAZUJE", 1, true);
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            this.UltraExplorerBar1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.UltraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.UltraCalcManager1 = new Infragistics.Win.UltraWinCalcManager.UltraCalcManager(this.components);
            this.DsKonto1 = new dsKonto();
            this.S_FIN_KONTO_KARTICEDataSet1 = new Placa.S_FIN_KONTO_KARTICEDataSet();
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ZatvaranjeSmartPartAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.WindowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea5 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.DockableWindow3 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea6 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.WindowDockingArea3 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.WindowDockingArea7 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.UltraExplorerBar1)).BeginInit();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraCalcManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsKonto1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_FIN_KONTO_KARTICEDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea2.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.DockableWindow3.SuspendLayout();
            this.WindowDockingArea6.SuspendLayout();
            this.WindowDockingArea7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraExplorerBar1
            // 
            ultraExplorerBarItem1.Key = "Nastavak";
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            ultraExplorerBarItem1.Settings.AppearancesSmall.Appearance = appearance1;
            ultraExplorerBarItem1.Text = "Nastavak ispisa";
            ultraExplorerBarItem2.Key = "Izlaz";
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            ultraExplorerBarItem2.Settings.AppearancesSmall.Appearance = appearance2;
            ultraExplorerBarItem2.Text = "Izlaz";
            ultraExplorerBarGroup1.Items.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem[] {
            ultraExplorerBarItem1,
            ultraExplorerBarItem2});
            ultraExplorerBarGroup1.Text = "Zadaci";
            this.UltraExplorerBar1.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1});
            this.UltraExplorerBar1.Location = new System.Drawing.Point(0, 20);
            this.UltraExplorerBar1.Name = "UltraExplorerBar1";
            this.UltraExplorerBar1.Size = new System.Drawing.Size(166, 705);
            this.UltraExplorerBar1.TabIndex = 104;
            this.UltraExplorerBar1.ItemClick += new Infragistics.Win.UltraWinExplorerBar.ItemClickEventHandler(this.UltraExplorerBar1_ItemClick);
            // 
            // Panel1
            // 
            this.Panel1.Location = new System.Drawing.Point(0, 16);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(157, 225);
            this.Panel1.TabIndex = 106;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.UltraGrid2);
            this.Panel2.Location = new System.Drawing.Point(0, 20);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(157, 705);
            this.Panel2.TabIndex = 3;
            // 
            // UltraGrid2
            // 
            this.UltraGrid2.CalcManager = this.UltraCalcManager1;
            this.UltraGrid2.DataMember = "KONTO";
            this.UltraGrid2.DataSource = this.DsKonto1;
            appearance4.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance4.ForeColor = System.Drawing.Color.MidnightBlue;
            appearance4.TextHAlignAsString = "Left";
            this.UltraGrid2.DisplayLayout.Appearance = appearance4;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.Caption = "Konto";
            ultraGridColumn17.Header.VisiblePosition = 0;
            ultraGridColumn17.Width = 140;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn17});
            ultraGridBand2.Header.Caption = "";
            ultraGridBand2.Header.Enabled = false;
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.UltraGrid2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance5.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance5.ForeColor = System.Drawing.Color.MidnightBlue;
            appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.UltraGrid2.DisplayLayout.CaptionAppearance = appearance5;
            this.UltraGrid2.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid2.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            this.UltraGrid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.UltraGrid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGrid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGrid2.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.UltraGrid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid2.Location = new System.Drawing.Point(0, 0);
            this.UltraGrid2.Name = "UltraGrid2";
            this.UltraGrid2.Size = new System.Drawing.Size(157, 705);
            this.UltraGrid2.TabIndex = 3;
            this.UltraGrid2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // UltraCalcManager1
            // 
            this.UltraCalcManager1.ContainingControl = this;
            // 
            // DsKonto1
            // 
            this.DsKonto1.DataSetName = "dsKonto";
            this.DsKonto1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // S_FIN_KONTO_KARTICEDataSet1
            // 
            this.S_FIN_KONTO_KARTICEDataSet1.DataSetName = "S_FIN_KONTO_KARTICEDataSet";
            // 
            // UltraDockManager1
            // 
            dockAreaPane1.DockedBefore = new System.Guid("62f8ee16-e4ff-48bb-810d-3cc617a37d9c");
            dockAreaPane1.FloatingLocation = new System.Drawing.Point(1220, 60);
            dockAreaPane1.MaximumSize = new System.Drawing.Size(166, 528);
            dockableControlPane1.Control = this.UltraExplorerBar1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(796, 3, 216, 546);
            dockableControlPane1.Size = new System.Drawing.Size(782, 548);
            dockableControlPane1.Text = "...";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(166, 528);
            dockAreaPane2.DockedBefore = new System.Guid("7630003f-4351-41cc-adad-dfc9ee74218b");
            dockAreaPane2.FloatingLocation = new System.Drawing.Point(1220, 60);
            dockAreaPane2.MaximumSize = new System.Drawing.Size(166, 528);
            dockAreaPane2.Size = new System.Drawing.Size(166, 271);
            dockAreaPane3.DockedBefore = new System.Guid("c7784784-cc54-4f93-b256-3b980cb31e9e");
            dockAreaPane3.FloatingLocation = new System.Drawing.Point(463, 378);
            dockAreaPane3.MaximumSize = new System.Drawing.Size(157, 548);
            dockableControlPane2.Closed = true;
            dockableControlPane2.Control = this.Panel1;
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(217, 187, 200, 100);
            dockableControlPane2.Size = new System.Drawing.Size(587, 548);
            dockableControlPane2.Text = "...";
            dockAreaPane3.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane3.Size = new System.Drawing.Size(157, 241);
            dockAreaPane3.UnfilledSize = new System.Drawing.Size(157, 241);
            dockAreaPane4.DockedBefore = new System.Guid("dec3392f-6cc9-4593-8133-fd6421919867");
            dockAreaPane4.FloatingLocation = new System.Drawing.Point(272, 325);
            dockAreaPane4.MaximumSize = new System.Drawing.Size(157, 548);
            dockAreaPane4.Size = new System.Drawing.Size(157, 241);
            dockAreaPane4.UnfilledSize = new System.Drawing.Size(100, 100);
            dockAreaPane5.DockedBefore = new System.Guid("aa402c86-599b-467c-b2ea-8cb3e6c0deff");
            dockAreaPane5.FloatingLocation = new System.Drawing.Point(272, 325);
            dockAreaPane5.MaximumSize = new System.Drawing.Size(157, 548);
            dockableControlPane3.Control = this.Panel2;
            dockableControlPane3.OriginalControlBounds = new System.Drawing.Rectangle(142, 251, 200, 100);
            dockableControlPane3.Size = new System.Drawing.Size(920, 236);
            dockableControlPane3.Text = "...";
            dockAreaPane5.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane3});
            dockAreaPane5.Size = new System.Drawing.Size(157, 548);
            dockAreaPane5.UnfilledSize = new System.Drawing.Size(100, 100);
            dockAreaPane6.FloatingLocation = new System.Drawing.Point(463, 378);
            dockAreaPane6.MaximumSize = new System.Drawing.Size(157, 548);
            dockAreaPane6.Size = new System.Drawing.Size(157, 548);
            dockAreaPane6.UnfilledSize = new System.Drawing.Size(100, 100);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2,
            dockAreaPane3,
            dockAreaPane4,
            dockAreaPane5,
            dockAreaPane6});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.VisualStudio2008;
            // 
            // _ZatvaranjeSmartPartUnpinnedTabAreaLeft
            // 
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft.Name = "_ZatvaranjeSmartPartUnpinnedTabAreaLeft";
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 725);
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft.TabIndex = 1;
            // 
            // _ZatvaranjeSmartPartUnpinnedTabAreaRight
            // 
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Location = new System.Drawing.Point(920, 0);
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Name = "_ZatvaranjeSmartPartUnpinnedTabAreaRight";
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 725);
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.TabIndex = 2;
            // 
            // _ZatvaranjeSmartPartUnpinnedTabAreaTop
            // 
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Name = "_ZatvaranjeSmartPartUnpinnedTabAreaTop";
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Size = new System.Drawing.Size(920, 0);
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.TabIndex = 3;
            // 
            // _ZatvaranjeSmartPartUnpinnedTabAreaBottom
            // 
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 725);
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Name = "_ZatvaranjeSmartPartUnpinnedTabAreaBottom";
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Size = new System.Drawing.Size(920, 0);
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.TabIndex = 4;
            // 
            // _ZatvaranjeSmartPartAutoHideControl
            // 
            this._ZatvaranjeSmartPartAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ZatvaranjeSmartPartAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._ZatvaranjeSmartPartAutoHideControl.Name = "_ZatvaranjeSmartPartAutoHideControl";
            this._ZatvaranjeSmartPartAutoHideControl.Owner = this.UltraDockManager1;
            this._ZatvaranjeSmartPartAutoHideControl.Size = new System.Drawing.Size(0, 801);
            this._ZatvaranjeSmartPartAutoHideControl.TabIndex = 5;
            // 
            // WindowDockingArea2
            // 
            this.WindowDockingArea2.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea2.Dock = System.Windows.Forms.DockStyle.Right;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea2.Location = new System.Drawing.Point(749, 0);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(171, 725);
            this.WindowDockingArea2.TabIndex = 110;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Controls.Add(this.UltraExplorerBar1);
            this.DockableWindow1.Location = new System.Drawing.Point(5, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(166, 725);
            this.DockableWindow1.TabIndex = 112;
            // 
            // WindowDockingArea5
            // 
            this.WindowDockingArea5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowDockingArea5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea5.Location = new System.Drawing.Point(4, 4);
            this.WindowDockingArea5.Name = "WindowDockingArea5";
            this.WindowDockingArea5.Owner = this.UltraDockManager1;
            this.WindowDockingArea5.Size = new System.Drawing.Size(166, 271);
            this.WindowDockingArea5.TabIndex = 112;
            // 
            // DockableWindow2
            // 
            this.DockableWindow2.Controls.Add(this.Panel1);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(157, 725);
            this.DockableWindow2.TabIndex = 113;
            // 
            // DockableWindow3
            // 
            this.DockableWindow3.Controls.Add(this.Panel2);
            this.DockableWindow3.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow3.Name = "DockableWindow3";
            this.DockableWindow3.Owner = this.UltraDockManager1;
            this.DockableWindow3.Size = new System.Drawing.Size(157, 725);
            this.DockableWindow3.TabIndex = 114;
            // 
            // WindowDockingArea6
            // 
            this.WindowDockingArea6.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowDockingArea6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea6.Location = new System.Drawing.Point(4, 4);
            this.WindowDockingArea6.Name = "WindowDockingArea6";
            this.WindowDockingArea6.Owner = this.UltraDockManager1;
            this.WindowDockingArea6.Size = new System.Drawing.Size(157, 241);
            this.WindowDockingArea6.TabIndex = 0;
            // 
            // WindowDockingArea3
            // 
            this.WindowDockingArea3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowDockingArea3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea3.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea3.Name = "WindowDockingArea3";
            this.WindowDockingArea3.Owner = this.UltraDockManager1;
            this.WindowDockingArea3.Size = new System.Drawing.Size(157, 241);
            this.WindowDockingArea3.TabIndex = 10;
            // 
            // WindowDockingArea7
            // 
            this.WindowDockingArea7.Controls.Add(this.DockableWindow3);
            this.WindowDockingArea7.Dock = System.Windows.Forms.DockStyle.Left;
            this.WindowDockingArea7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea7.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea7.Name = "WindowDockingArea7";
            this.WindowDockingArea7.Owner = this.UltraDockManager1;
            this.WindowDockingArea7.Size = new System.Drawing.Size(162, 725);
            this.WindowDockingArea7.TabIndex = 11;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(162, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(157, 553);
            this.WindowDockingArea1.TabIndex = 12;
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.CalcManager = this.UltraCalcManager1;
            this.UltraGrid1.DataMember = "S_FIN_KONTO_KARTICE";
            this.UltraGrid1.DataSource = this.S_FIN_KONTO_KARTICEDataSet1;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance3.FontData.BoldAsString = "True";
            appearance3.TextHAlignAsString = "Right";
            ultraGridColumn1.CellAppearance = appearance3;
            ultraGridColumn1.Header.Caption = "Duguje";
            ultraGridColumn1.Header.VisiblePosition = 4;
            ultraGridColumn1.MaskInput = "-n,nnn,nnn.nn";
            ultraGridColumn1.Width = 92;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance6.FontData.BoldAsString = "True";
            appearance6.TextHAlignAsString = "Right";
            ultraGridColumn2.CellAppearance = appearance6;
            ultraGridColumn2.Header.Caption = "Potražuje";
            ultraGridColumn2.Header.VisiblePosition = 5;
            ultraGridColumn2.MaskInput = "-n,nnn,nnn.nn";
            ultraGridColumn2.Width = 94;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 9;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.Caption = "Dat.";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 67;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.Caption = "Dok.";
            ultraGridColumn5.Header.VisiblePosition = 0;
            ultraGridColumn5.Width = 77;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.Caption = "Broj dok.";
            ultraGridColumn6.Header.VisiblePosition = 1;
            ultraGridColumn6.Width = 36;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.Caption = "Br.st.";
            ultraGridColumn7.Header.VisiblePosition = 2;
            ultraGridColumn7.Width = 43;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.Caption = "Opis";
            ultraGridColumn8.Header.VisiblePosition = 6;
            ultraGridColumn8.Width = 351;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 10;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 11;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 12;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 13;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 14;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.Caption = "OJ";
            ultraGridColumn14.Header.VisiblePosition = 7;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.Caption = "MT";
            ultraGridColumn15.Header.VisiblePosition = 8;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 15;
            ultraGridColumn16.Hidden = true;
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
            ultraGridColumn16});
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            appearance7.FontData.BoldAsString = "True";
            appearance7.TextHAlignAsString = "Right";
            summarySettings1.Appearance = appearance7;
            summarySettings1.DisplayFormat = "{0:#,##0.00}";
            summarySettings1.GroupBySummaryValueAppearance = appearance8;
            summarySettings1.Lines = 2;
            summarySettings1.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            appearance9.FontData.BoldAsString = "True";
            appearance9.TextHAlignAsString = "Right";
            summarySettings2.Appearance = appearance9;
            summarySettings2.DisplayFormat = "{0:#,##0.00}";
            summarySettings2.GroupBySummaryValueAppearance = appearance10;
            summarySettings2.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed;
            ultraGridBand1.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings1,
            summarySettings2});
            ultraGridBand1.SummaryFooterCaption = "";
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.UltraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGrid1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.UltraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(162, 0);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(587, 725);
            this.UltraGrid1.TabIndex = 111;
            this.UltraGrid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // frmPregledKontoKartica
            // 
            this.ClientSize = new System.Drawing.Size(920, 725);
            this.Controls.Add(this._ZatvaranjeSmartPartAutoHideControl);
            this.Controls.Add(this.UltraGrid1);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this.WindowDockingArea7);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this._ZatvaranjeSmartPartUnpinnedTabAreaTop);
            this.Controls.Add(this._ZatvaranjeSmartPartUnpinnedTabAreaBottom);
            this.Controls.Add(this._ZatvaranjeSmartPartUnpinnedTabAreaLeft);
            this.Controls.Add(this._ZatvaranjeSmartPartUnpinnedTabAreaRight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPregledKontoKartica";
            this.Text = "Pregled kartica konta prije ispisa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.UltraExplorerBar1)).EndInit();
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraCalcManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsKonto1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_FIN_KONTO_KARTICEDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea2.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
            this.DockableWindow3.ResumeLayout(false);
            this.WindowDockingArea6.ResumeLayout(false);
            this.WindowDockingArea7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            this.ResumeLayout(false);

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
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UltraExplorerBar1_ItemClick(object sender, ItemEventArgs e)
        {
            switch (e.Item.Key)
            {
                case "Nastavak":
                    this.Close();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    break;

                case "Izlaz":
                    this.Close();
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    break;
            }
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (Strings.Len(e.Row.Cells["KONTO"].Value.ToString()) == 1)
            {
                e.Row.Appearance.ForeColor = Color.Green;
                e.Row.Appearance.FontData.Bold = DefaultableBoolean.True;
            }
        }

        private CurrencyManager __cmManager;

        private AutoHideControl _ZatvaranjeSmartPartAutoHideControl;

        private UnpinnedTabArea _ZatvaranjeSmartPartUnpinnedTabAreaBottom;

        private UnpinnedTabArea _ZatvaranjeSmartPartUnpinnedTabAreaLeft;

        private UnpinnedTabArea _ZatvaranjeSmartPartUnpinnedTabAreaRight;

        private UnpinnedTabArea _ZatvaranjeSmartPartUnpinnedTabAreaTop;

        private DockableWindow DockableWindow1;

        private DockableWindow DockableWindow2;

        private DockableWindow DockableWindow3;

        private dsKonto DsKonto1;

        private Panel Panel1;

        private Panel Panel2;

        private S_FIN_KONTO_KARTICEDataSet S_FIN_KONTO_KARTICEDataSet1;

        private UltraCalcManager UltraCalcManager1;

        private UltraDockManager UltraDockManager1;

        private UltraExplorerBar UltraExplorerBar1;

        private UltraGrid UltraGrid1;

        private UltraGrid UltraGrid2;

        private WindowDockingArea WindowDockingArea1;

        private WindowDockingArea WindowDockingArea2;

        private WindowDockingArea WindowDockingArea3;

        private WindowDockingArea WindowDockingArea5;

        private WindowDockingArea WindowDockingArea6;

        private WindowDockingArea WindowDockingArea7;
    }
}

