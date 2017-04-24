using Deklarit.Resources;
using My.Resources;
using Infragistics.Win;
using Infragistics.Win.UltraWinCalcManager;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.VisualBasic;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


namespace FinPosModule
{

    public class frmPregledBilance : Form
    {
        private IContainer components;
        public DataSet ds;
        private SmartPartInfoProvider infoProvider;
        
        private SmartPartInfo smartPartInfo1;

        public frmPregledBilance()
        {
            base.Load += new EventHandler(this.frmPregledBilance_Load);
            this.ds = new DataSet();
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(string.Format("Zatvaranje stavaka-saldakonti", "Zatvaranje stavaka"), string.Format(Deklarit.Resources.Resources.WorkWithTitle, "Zatvaranje stavaka"));
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmPregledBilance_Load(object sender, EventArgs e)
        {
            this.UltraGrid1.DataSource = this.ds;
            this.UltraGrid1.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem ultraExplorerBarItem1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledBilance));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem ultraExplorerBarItem2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("S_FIN_BILANCA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("duguje");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POTRAZUJE");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("konto");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POCETNODUGUJE");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POCETNOPOTRAZUJE");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIV");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("potrazujepromet", 0);
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("dugujepromet", 1);
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedRight, new System.Guid("a195b272-9a36-45ea-882a-8f1a507084f5"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("c6004666-c520-4767-b350-a26271b74c8f"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("a195b272-9a36-45ea-882a-8f1a507084f5"), -1);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("bec07ad9-8b22-45b0-aae8-fd36be3ab9dc"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("0bcc809c-71bf-4eef-ac2e-91f8540e8c92"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("bec07ad9-8b22-45b0-aae8-fd36be3ab9dc"), -1);
            this.UltraExplorerBar1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.UltraCalcManager1 = new Infragistics.Win.UltraWinCalcManager.UltraCalcManager(this.components);
            this.S_FIN_BILANCADataSet1 = new Placa.S_FIN_BILANCADataSet();
            this.S_FIN_PARTNERI_SA_OTVORENIMADataSet1 = new Placa.S_FIN_PARTNERI_SA_OTVORENIMADataSet();
            this.DatasetKarticeGroup1 = new Placa.S_FIN_OTVORENE_STAVKEDataSet();
            this.DatasetKarticeGroup2 = new Placa.S_FIN_OTVORENE_STAVKEDataSet();
            this.PartnerDataSet1 = new Placa.PARTNERDataSet();
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._ZatvaranjeSmartPartAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.WindowDockingArea3 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            ((System.ComponentModel.ISupportInitialize)(this.UltraExplorerBar1)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraCalcManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_FIN_BILANCADataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_FIN_PARTNERI_SA_OTVORENIMADataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatasetKarticeGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatasetKarticeGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartnerDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea3.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.SuspendLayout();
            // 
            // UltraExplorerBar1
            // 
            ultraExplorerBarItem1.Key = "Nastavak";
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            ultraExplorerBarItem1.Settings.AppearancesLarge.EditAppearance = appearance2;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            ultraExplorerBarItem1.Settings.AppearancesSmall.Appearance = appearance3;
            ultraExplorerBarItem1.Text = "Nastavak ispisa";
            ultraExplorerBarItem2.Key = "Izlaz";
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            ultraExplorerBarItem2.Settings.AppearancesLarge.ActiveAppearance = appearance1;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            ultraExplorerBarItem2.Settings.AppearancesSmall.Appearance = appearance4;
            ultraExplorerBarItem2.Text = "Izlaz";
            ultraExplorerBarGroup1.Items.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem[] {
            ultraExplorerBarItem1,
            ultraExplorerBarItem2});
            ultraExplorerBarGroup1.Text = "Zadaci";
            this.UltraExplorerBar1.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1});
            this.UltraExplorerBar1.Location = new System.Drawing.Point(0, 20);
            this.UltraExplorerBar1.Name = "UltraExplorerBar1";
            this.UltraExplorerBar1.Size = new System.Drawing.Size(161, 528);
            this.UltraExplorerBar1.TabIndex = 104;
            this.UltraExplorerBar1.ItemClick += new Infragistics.Win.UltraWinExplorerBar.ItemClickEventHandler(this.UltraExplorerBar1_ItemClick);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.UltraGrid1);
            this.Panel1.Location = new System.Drawing.Point(0, 20);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(940, 528);
            this.Panel1.TabIndex = 106;
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.CalcManager = this.UltraCalcManager1;
            this.UltraGrid1.DataMember = "S_FIN_BILANCA";
            this.UltraGrid1.DataSource = this.S_FIN_BILANCADataSet1;
            appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            appearance.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Appearance = appearance;
            ultraGridBand1.ColHeaderLines = 3;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance5.TextHAlignAsString = "Right";
            ultraGridColumn1.CellAppearance = appearance5;
            ultraGridColumn1.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn1.Format = "#,##0.00";
            appearance6.TextHAlignAsString = "Center";
            ultraGridColumn1.Header.Appearance = appearance6;
            ultraGridColumn1.Header.Caption = "Ukupni promet\r\nDUGUJE";
            ultraGridColumn1.Header.VisiblePosition = 6;
            ultraGridColumn1.MaskInput = "-nnnnnnnnn.nn";
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance7.TextHAlignAsString = "Right";
            ultraGridColumn2.CellAppearance = appearance7;
            ultraGridColumn2.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn2.Format = "#,##0.00";
            appearance8.TextHAlignAsString = "Center";
            ultraGridColumn2.Header.Appearance = appearance8;
            ultraGridColumn2.Header.Caption = "Ukupni promet\r\nPOTRAŽUJE";
            ultraGridColumn2.Header.VisiblePosition = 7;
            ultraGridColumn2.MaskInput = "-nnnnnnnnn.nn";
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance9.TextHAlignAsString = "Center";
            ultraGridColumn3.Header.Appearance = appearance9;
            ultraGridColumn3.Header.Caption = "Konto";
            ultraGridColumn3.Header.VisiblePosition = 0;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance10.TextHAlignAsString = "Right";
            ultraGridColumn4.CellAppearance = appearance10;
            ultraGridColumn4.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn4.Format = "#,##0.00";
            appearance11.TextHAlignAsString = "Center";
            ultraGridColumn4.Header.Appearance = appearance11;
            ultraGridColumn4.Header.Caption = "Početno stanje\r\nDuguje";
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.MaskInput = "-nnnnnnnnn.nn";
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance12.TextHAlignAsString = "Right";
            ultraGridColumn5.CellAppearance = appearance12;
            ultraGridColumn5.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn5.Format = "#,##0.00";
            appearance14.TextHAlignAsString = "Center";
            ultraGridColumn5.Header.Appearance = appearance14;
            ultraGridColumn5.Header.Caption = "Početno stanje\r\nPotražuje";
            ultraGridColumn5.Header.VisiblePosition = 3;
            ultraGridColumn5.MaskInput = "-nnnnnnnnn.nn";
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance15.TextHAlignAsString = "Center";
            ultraGridColumn6.Header.Appearance = appearance15;
            ultraGridColumn6.Header.Caption = "Naziv konta";
            ultraGridColumn6.Header.VisiblePosition = 1;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance16.TextHAlignAsString = "Right";
            ultraGridColumn7.CellAppearance = appearance16;
            ultraGridColumn7.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn7.DataType = typeof(decimal);
            ultraGridColumn7.Format = "#,##0.00";
            ultraGridColumn7.Formula = "[POTRAZUJE] - [POCETNOPOTRAZUJE]";
            appearance17.TextHAlignAsString = "Center";
            ultraGridColumn7.Header.Appearance = appearance17;
            ultraGridColumn7.Header.Caption = "Promet bez\r\npočetnog stanja\r\nPOTRAŽUJE";
            ultraGridColumn7.Header.VisiblePosition = 5;
            ultraGridColumn7.MaskInput = "-nnnnnnnnn.nn";
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance18.TextHAlignAsString = "Right";
            ultraGridColumn8.CellAppearance = appearance18;
            ultraGridColumn8.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn8.DataType = typeof(decimal);
            ultraGridColumn8.Format = "#,##0.00";
            ultraGridColumn8.Formula = "[duguje] - [POCETNODUGUJE]";
            appearance19.TextHAlignAsString = "Center";
            ultraGridColumn8.Header.Appearance = appearance19;
            ultraGridColumn8.Header.Caption = "Promet bez\r\npočetnog stanja\r\nDUGUJE";
            ultraGridColumn8.Header.VisiblePosition = 4;
            ultraGridColumn8.MaskInput = "-nnnnnnnnn.nn";
            ultraGridColumn8.Width = 95;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance13.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance13.ForeColor = System.Drawing.Color.MidnightBlue;
            appearance13.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.UltraGrid1.DisplayLayout.CaptionAppearance = appearance13;
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            this.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(0, 0);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(940, 528);
            this.UltraGrid1.TabIndex = 2;
            this.UltraGrid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
            this.UltraGrid1.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.UltraGrid1_InitializeRow);
            // 
            // UltraCalcManager1
            // 
            this.UltraCalcManager1.ContainingControl = this;
            // 
            // S_FIN_BILANCADataSet1
            // 
            this.S_FIN_BILANCADataSet1.DataSetName = "S_FIN_BILANCADataSet";
            // 
            // S_FIN_PARTNERI_SA_OTVORENIMADataSet1
            // 
            this.S_FIN_PARTNERI_SA_OTVORENIMADataSet1.DataSetName = "S_FIN_PARTNERI_SA_OTVORENIMADataSet";
            // 
            // DatasetKarticeGroup1
            // 
            this.DatasetKarticeGroup1.DataSetName = "KarticePartnera";
            this.DatasetKarticeGroup1.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // DatasetKarticeGroup2
            // 
            this.DatasetKarticeGroup2.DataSetName = "KarticePartnera";
            this.DatasetKarticeGroup2.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // PartnerDataSet1
            // 
            this.PartnerDataSet1.DataSetName = "PARTNERDataSet";
            this.PartnerDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // UltraDockManager1
            // 
            dockAreaPane1.DockedBefore = new System.Guid("bec07ad9-8b22-45b0-aae8-fd36be3ab9dc");
            dockAreaPane1.MaximumSize = new System.Drawing.Size(166, 528);
            dockableControlPane1.Control = this.UltraExplorerBar1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(796, 3, 216, 546);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "...";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(161, 548);
            dockableControlPane2.Control = this.Panel1;
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(217, 187, 200, 100);
            dockableControlPane2.Size = new System.Drawing.Size(100, 100);
            dockableControlPane2.Text = "...";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane2.Settings.AllowDockAsTab = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane2.Settings.AllowPin = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane2.Size = new System.Drawing.Size(940, 548);
            dockAreaPane2.UnfilledSize = new System.Drawing.Size(100, 100);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.LayoutStyle = Infragistics.Win.UltraWinDock.DockAreaLayoutStyle.FillContainer;
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
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 548);
            this._ZatvaranjeSmartPartUnpinnedTabAreaLeft.TabIndex = 1;
            // 
            // _ZatvaranjeSmartPartUnpinnedTabAreaRight
            // 
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Location = new System.Drawing.Point(1106, 0);
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Name = "_ZatvaranjeSmartPartUnpinnedTabAreaRight";
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 548);
            this._ZatvaranjeSmartPartUnpinnedTabAreaRight.TabIndex = 2;
            // 
            // _ZatvaranjeSmartPartUnpinnedTabAreaTop
            // 
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Name = "_ZatvaranjeSmartPartUnpinnedTabAreaTop";
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.Size = new System.Drawing.Size(1106, 0);
            this._ZatvaranjeSmartPartUnpinnedTabAreaTop.TabIndex = 3;
            // 
            // _ZatvaranjeSmartPartUnpinnedTabAreaBottom
            // 
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 548);
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Name = "_ZatvaranjeSmartPartUnpinnedTabAreaBottom";
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._ZatvaranjeSmartPartUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1106, 0);
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
            // WindowDockingArea3
            // 
            this.WindowDockingArea3.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea3.Dock = System.Windows.Forms.DockStyle.Right;
            this.WindowDockingArea3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea3.Location = new System.Drawing.Point(940, 0);
            this.WindowDockingArea3.Name = "WindowDockingArea3";
            this.WindowDockingArea3.Owner = this.UltraDockManager1;
            this.WindowDockingArea3.Size = new System.Drawing.Size(166, 548);
            this.WindowDockingArea3.TabIndex = 108;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Controls.Add(this.UltraExplorerBar1);
            this.DockableWindow1.Location = new System.Drawing.Point(5, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(161, 548);
            this.DockableWindow1.TabIndex = 110;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(940, 548);
            this.WindowDockingArea1.TabIndex = 109;
            // 
            // DockableWindow2
            // 
            this.DockableWindow2.Controls.Add(this.Panel1);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(940, 548);
            this.DockableWindow2.TabIndex = 111;
            // 
            // frmPregledBilance
            // 
            this.ClientSize = new System.Drawing.Size(1106, 548);
            this.Controls.Add(this._ZatvaranjeSmartPartAutoHideControl);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this.WindowDockingArea3);
            this.Controls.Add(this._ZatvaranjeSmartPartUnpinnedTabAreaTop);
            this.Controls.Add(this._ZatvaranjeSmartPartUnpinnedTabAreaBottom);
            this.Controls.Add(this._ZatvaranjeSmartPartUnpinnedTabAreaLeft);
            this.Controls.Add(this._ZatvaranjeSmartPartUnpinnedTabAreaRight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPregledBilance";
            this.Text = "Pregled analitičke bruto bilance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.UltraExplorerBar1)).EndInit();
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraCalcManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_FIN_BILANCADataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_FIN_PARTNERI_SA_OTVORENIMADataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatasetKarticeGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatasetKarticeGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartnerDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea3.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
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
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
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

        private AutoHideControl _ZatvaranjeSmartPartAutoHideControl;

        private UnpinnedTabArea _ZatvaranjeSmartPartUnpinnedTabAreaBottom;

        private UnpinnedTabArea _ZatvaranjeSmartPartUnpinnedTabAreaLeft;

        private UnpinnedTabArea _ZatvaranjeSmartPartUnpinnedTabAreaRight;

        private UnpinnedTabArea _ZatvaranjeSmartPartUnpinnedTabAreaTop;

        private S_FIN_OTVORENE_STAVKEDataSet DatasetKarticeGroup1;

        private S_FIN_OTVORENE_STAVKEDataSet DatasetKarticeGroup2;

        private DockableWindow DockableWindow1;

        private DockableWindow DockableWindow2;

        private Panel Panel1;

        private PARTNERDataSet PartnerDataSet1;

        private S_FIN_BILANCADataSet S_FIN_BILANCADataSet1;

        private S_FIN_PARTNERI_SA_OTVORENIMADataSet S_FIN_PARTNERI_SA_OTVORENIMADataSet1;

        private UltraCalcManager UltraCalcManager1;

        private UltraDockManager UltraDockManager1;

        private UltraExplorerBar UltraExplorerBar1;

        private UltraGrid UltraGrid1;

        private WindowDockingArea WindowDockingArea1;

        private WindowDockingArea WindowDockingArea3;
    }
}

