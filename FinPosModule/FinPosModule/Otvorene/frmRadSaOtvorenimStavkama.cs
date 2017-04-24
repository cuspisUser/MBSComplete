using FinPosModule;
using FinPosModule.GK;
using My.Resources;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinGrid;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using mipsed.application.framework;
using Placa;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FinPosModule.Otvorene
{
    public class frmRadSaOtvorenimStavkama : Form
    {
        private string __aktivnost;
        private string __idpartner;
        private decimal __iznos;
        private string __konto;
        public GKSmartPart __ParentForm;
        private string __strana;
        private IContainer components;
        private DateTime pocetni;
        private const string STR_DM = "DM";
        private const string STR_DP = "DP";
        private const string STR_PM = "PM";
        private const string STR_PP = "PP";
        private const string STR_S_FIN_OTVORENE_STAVKE = "S_FIN_OTVORENE_STAVKE";
        private DateTime zavrsni;

        public frmRadSaOtvorenimStavkama(string strana = null, decimal iznos = 0, string konto = null, string aktivnost = null, string partner = null)
        {
            base.Load += new EventHandler(this.frmRadSaOtvorenimStavkama_Load);
            this.__strana = strana;
            this.__iznos = iznos;
            this.__konto = konto;
            this.__aktivnost = aktivnost;
            this.__idpartner = partner;
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmRadSaOtvorenimStavkama_Load(object sender, EventArgs e)
        {
            this.pocetni = mipsed.application.framework.Application.Pocetni;
            this.zavrsni = mipsed.application.framework.Application.Zavrsni;
            this.dsOTVORENESTAVKE.EnforceConstraints = false;
            if ((this.__strana == null) & (decimal.Compare(this.__iznos, decimal.Zero) == 0))
            {
                this.dsOTVORENESTAVKE.Merge(this.OtvoreneSve, false);
            }
            if ((this.__strana == "D") & (decimal.Compare(this.__iznos, decimal.Zero) > 0))
            {
                this.dsOTVORENESTAVKE.Merge(this.OtvorenePotraznePlus, false);
                this.dsOTVORENESTAVKE.Merge(this.OtvorenePotrazneMinus, false);
            }
            if ((this.__strana == "D") & (decimal.Compare(this.__iznos, decimal.Zero) < 0))
            {
                this.dsOTVORENESTAVKE.Merge(this.OtvorenePotrazneMinus, false);
                this.dsOTVORENESTAVKE.Merge(this.OtvoreneDugovnePlus, false);
            }
            if ((this.__strana == "P") & (decimal.Compare(this.__iznos, decimal.Zero) > 0))
            {
                this.dsOTVORENESTAVKE.Merge(this.OtvorenePotrazneMinus, false);
                this.dsOTVORENESTAVKE.Merge(this.OtvoreneDugovnePlus, false);
            }
            if ((this.__strana == "P") & (decimal.Compare(this.__iznos, decimal.Zero) < 0))
            {
                this.dsOTVORENESTAVKE.Merge(this.OtvorenePotraznePlus, false);
                this.dsOTVORENESTAVKE.Merge(this.OtvoreneDugovneMinus, false);
            }
            this.UltraGrid1.DisplayLayout.Bands[0].ColHeaderLines = 2;
        }

        private static DataRowView GetDrv(CurrencyManager cm)
        {
            return (DataRowView) cm.Current;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem ultraExplorerBarItem1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRadSaOtvorenimStavkama));
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem ultraExplorerBarItem2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedRight, new System.Guid("9288cdc5-c408-41af-8ea8-d5617cbbcfcb"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("bd13783c-ebb4-4589-a032-37c455f483d2"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("9288cdc5-c408-41af-8ea8-d5617cbbcfcb"), -1);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("2cbd207e-95a5-43cc-aa24-1144d5a16f0d"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("5e93e747-fcfd-4f84-96b9-96df18210ceb"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("2cbd207e-95a5-43cc-aa24-1144d5a16f0d"), -1);
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("S_FIN_OTVORENE_STAVKE", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("duguje");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POTRAZUJE");
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("konto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMDVO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMVALUTE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMDOK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SKRACENI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJDOK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJSTAVKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISKNJIZENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPARTNER");
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OTVORENO");
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIV");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNEROIB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MB");
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERMJESTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTNERULICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGKSTAVKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ORIGINALNIDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOJ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVMT");
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.UltraExplorerBar1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.UltraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmRadSaOtvorenimStavkamaAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.dsOTVORENESTAVKE = new Placa.S_FIN_OTVORENE_STAVKEDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.UltraExplorerBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.WindowDockingArea2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOTVORENESTAVKE)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraExplorerBar1
            // 
            ultraExplorerBarItem1.Checked = true;
            ultraExplorerBarItem1.Key = "Zatvori";
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            ultraExplorerBarItem1.Settings.AppearancesSmall.Appearance = appearance1;
            ultraExplorerBarItem1.Text = "Zatvori stavku";
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
            this.UltraExplorerBar1.Size = new System.Drawing.Size(216, 546);
            this.UltraExplorerBar1.TabIndex = 103;
            this.UltraExplorerBar1.ItemClick += new Infragistics.Win.UltraWinExplorerBar.ItemClickEventHandler(this.UltraExplorerBar1_ItemClick);
            // 
            // UltraGroupBox1
            // 
            this.UltraGroupBox1.Controls.Add(this.UltraGrid1);
            this.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGroupBox1.Location = new System.Drawing.Point(0, 20);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(969, 541);
            this.UltraGroupBox1.TabIndex = 110;
            // 
            // UltraDockManager1
            // 
            dockAreaPane1.DockedBefore = new System.Guid("2cbd207e-95a5-43cc-aa24-1144d5a16f0d");
            dockableControlPane1.Control = this.UltraExplorerBar1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(8, 8, 171, 568);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Odabir radnje";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(216, 566);
            dockableControlPane2.Control = this.UltraGroupBox1;
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(81, 102, 670, 216);
            dockableControlPane2.Size = new System.Drawing.Size(100, 100);
            dockableControlPane2.Text = "Lista otvorenih stavaka";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Size = new System.Drawing.Size(969, 561);
            dockAreaPane2.Text = "Lista otvorenih stavaka";
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2});
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.VisualStudio2008;
            // 
            // _frmRadSaOtvorenimStavkamaUnpinnedTabAreaLeft
            // 
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaLeft.Name = "_frmRadSaOtvorenimStavkamaUnpinnedTabAreaLeft";
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 566);
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaLeft.TabIndex = 104;
            // 
            // _frmRadSaOtvorenimStavkamaUnpinnedTabAreaRight
            // 
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaRight.Location = new System.Drawing.Point(1190, 0);
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaRight.Name = "_frmRadSaOtvorenimStavkamaUnpinnedTabAreaRight";
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 566);
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaRight.TabIndex = 105;
            // 
            // _frmRadSaOtvorenimStavkamaUnpinnedTabAreaTop
            // 
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaTop.Name = "_frmRadSaOtvorenimStavkamaUnpinnedTabAreaTop";
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaTop.Size = new System.Drawing.Size(1190, 0);
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaTop.TabIndex = 106;
            // 
            // _frmRadSaOtvorenimStavkamaUnpinnedTabAreaBottom
            // 
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 566);
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaBottom.Name = "_frmRadSaOtvorenimStavkamaUnpinnedTabAreaBottom";
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1190, 0);
            this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaBottom.TabIndex = 107;
            // 
            // _frmRadSaOtvorenimStavkamaAutoHideControl
            // 
            this._frmRadSaOtvorenimStavkamaAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._frmRadSaOtvorenimStavkamaAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._frmRadSaOtvorenimStavkamaAutoHideControl.Name = "_frmRadSaOtvorenimStavkamaAutoHideControl";
            this._frmRadSaOtvorenimStavkamaAutoHideControl.Owner = this.UltraDockManager1;
            this._frmRadSaOtvorenimStavkamaAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._frmRadSaOtvorenimStavkamaAutoHideControl.TabIndex = 108;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Right;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(969, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(221, 566);
            this.WindowDockingArea1.TabIndex = 109;
            // 
            // DockableWindow2
            // 
            this.DockableWindow2.Controls.Add(this.UltraGroupBox1);
            this.DockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.DockableWindow2.Size = new System.Drawing.Size(969, 561);
            this.DockableWindow2.TabIndex = 113;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Controls.Add(this.UltraExplorerBar1);
            this.DockableWindow1.Location = new System.Drawing.Point(5, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(216, 566);
            this.DockableWindow1.TabIndex = 112;
            // 
            // WindowDockingArea2
            // 
            this.WindowDockingArea2.Controls.Add(this.DockableWindow2);
            this.WindowDockingArea2.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea2.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(969, 566);
            this.WindowDockingArea2.TabIndex = 111;
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataMember = "S_FIN_OTVORENE_STAVKE";
            this.UltraGrid1.DataSource = this.dsOTVORENESTAVKE;
            appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            appearance.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Appearance = appearance;
            ultraGridBand1.ColHeaderLines = 2;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance16.TextHAlignAsString = "Right";
            ultraGridColumn1.CellAppearance = appearance16;
            ultraGridColumn1.Format = "#,##0.00";
            ultraGridColumn1.Header.Caption = "Duguje";
            ultraGridColumn1.Header.VisiblePosition = 9;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance17.TextHAlignAsString = "Right";
            ultraGridColumn2.CellAppearance = appearance17;
            ultraGridColumn2.Format = "#,##0.00";
            ultraGridColumn2.Header.Caption = "Potražuje";
            ultraGridColumn2.Header.VisiblePosition = 10;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.Caption = "Konto";
            ultraGridColumn3.Header.VisiblePosition = 4;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(96, 0);
            ultraGridColumn3.Width = 80;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.Caption = "dtPocetni";
            ultraGridColumn4.Header.VisiblePosition = 11;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.Header.Caption = "dtZavrsni";
            ultraGridColumn5.Header.VisiblePosition = 13;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.Caption = "Datum\r\ndokumenta";
            ultraGridColumn6.Header.TextOrientation = new Infragistics.Win.TextOrientationInfo(0, Infragistics.Win.TextFlowDirection.Horizontal);
            ultraGridColumn6.Header.VisiblePosition = 3;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(70, 0);
            ultraGridColumn6.Width = 81;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn7.Header.Caption = "Dokument";
            ultraGridColumn7.Header.VisiblePosition = 0;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(64, 0);
            ultraGridColumn7.Width = 93;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn8.Header.Caption = "Broj";
            ultraGridColumn8.Header.VisiblePosition = 1;
            ultraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(48, 0);
            ultraGridColumn8.Width = 65;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn9.Header.Caption = "Stavka";
            ultraGridColumn9.Header.VisiblePosition = 2;
            ultraGridColumn9.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(43, 0);
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn10.Header.Caption = "Opis";
            ultraGridColumn10.Header.VisiblePosition = 16;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance18.ForeColorDisabled = System.Drawing.Color.MidnightBlue;
            appearance18.TextHAlignAsString = "Right";
            ultraGridColumn11.CellAppearance = appearance18;
            ultraGridColumn11.Format = "";
            appearance19.BackColor = System.Drawing.Color.MidnightBlue;
            appearance19.ForeColor = System.Drawing.Color.WhiteSmoke;
            appearance19.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            ultraGridColumn11.Header.Appearance = appearance19;
            ultraGridColumn11.Header.Caption = "Šif.part";
            ultraGridColumn11.Header.VisiblePosition = 5;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn11.MaskInput = "{LOC}-nnnnnnn";
            ultraGridColumn11.PromptChar = ' ';
            ultraGridColumn11.Width = 71;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance20.TextHAlignAsString = "Right";
            ultraGridColumn12.CellAppearance = appearance20;
            ultraGridColumn12.Format = "#,##0.00";
            ultraGridColumn12.Header.Caption = "Otvoreni\r\niznos";
            ultraGridColumn12.Header.VisiblePosition = 8;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 18;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.VisiblePosition = 14;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn15.Format = "";
            ultraGridColumn15.Header.Caption = "Partner";
            ultraGridColumn15.Header.VisiblePosition = 6;
            ultraGridColumn15.Width = 234;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 7;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.VisiblePosition = 19;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.VisiblePosition = 20;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance21.ForeColorDisabled = System.Drawing.Color.MidnightBlue;
            ultraGridColumn19.CellAppearance = appearance21;
            ultraGridColumn19.Format = "";
            appearance22.BackColor = System.Drawing.Color.MidnightBlue;
            appearance22.ForeColor = System.Drawing.Color.WhiteSmoke;
            appearance22.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            ultraGridColumn19.Header.Appearance = appearance22;
            ultraGridColumn19.Header.VisiblePosition = 17;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn19.Width = 98;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn20.Format = "";
            ultraGridColumn20.Header.Caption = "Partner\r\nmjesto";
            ultraGridColumn20.Header.VisiblePosition = 12;
            ultraGridColumn20.Width = 188;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn21.Format = "";
            ultraGridColumn21.Header.Caption = "Partner\r\nulica";
            ultraGridColumn21.Header.VisiblePosition = 15;
            ultraGridColumn21.Width = 194;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn22.Header.VisiblePosition = 21;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn23.Header.VisiblePosition = 23;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn24.Header.Caption = "Organizacijska \r\njedinica";
            ultraGridColumn24.Header.VisiblePosition = 22;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn25.Header.Caption = "Mjesto \r\ntroška";
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
            appearance23.FontData.BoldAsString = "True";
            appearance23.FontData.Name = "Tahoma";
            appearance23.FontData.SizeInPoints = 9F;
            appearance23.ForeColor = System.Drawing.Color.WhiteSmoke;
            ultraGridBand1.Header.Appearance = appearance23;
            appearance24.BackColor = System.Drawing.Color.MidnightBlue;
            appearance24.ForeColor = System.Drawing.Color.WhiteSmoke;
            ultraGridBand1.Override.HeaderAppearance = appearance24;
            appearance25.BackColor = System.Drawing.Color.Lavender;
            ultraGridBand1.Override.RowAlternateAppearance = appearance25;
            appearance26.BorderColor = System.Drawing.Color.DarkGray;
            ultraGridBand1.Override.RowAppearance = appearance26;
            appearance27.BackColor = System.Drawing.Color.CadetBlue;
            appearance27.ForeColor = System.Drawing.Color.WhiteSmoke;
            ultraGridBand1.Override.SelectedRowAppearance = appearance27;
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance3.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance3.ForeColor = System.Drawing.Color.MidnightBlue;
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.UltraGrid1.DisplayLayout.CaptionAppearance = appearance3;
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            this.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(3, 0);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(963, 538);
            this.UltraGrid1.TabIndex = 1;
            this.UltraGrid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
            this.UltraGrid1.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGrid1_DoubleClickRow);
            // 
            // dsOTVORENESTAVKE
            // 
            this.dsOTVORENESTAVKE.DataSetName = "KARTICEPARTNERA";
            this.dsOTVORENESTAVKE.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // frmRadSaOtvorenimStavkama
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1190, 566);
            this.Controls.Add(this._frmRadSaOtvorenimStavkamaAutoHideControl);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaTop);
            this.Controls.Add(this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaBottom);
            this.Controls.Add(this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaLeft);
            this.Controls.Add(this._frmRadSaOtvorenimStavkamaUnpinnedTabAreaRight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRadSaOtvorenimStavkama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rad s otvorenim stavkama";
            ((System.ComponentModel.ISupportInitialize)(this.UltraExplorerBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox1)).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.WindowDockingArea2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsOTVORENESTAVKE)).EndInit();
            this.ResumeLayout(false);

        }

        private void KreirajZatvaranja(decimal iznos, DataRowView drv, DataRow novired)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command2 = new SqlCommand {
                CommandType = CommandType.Text,
                Connection = connection,
                CommandText = "INSERT INTO ZATVARANJA (GK1IDGKSTAVKA,GK2IDGKSTAVKA,ZATVARANJAIZNOS) VALUES (@GK1IDGKSTAVKA,@GK2IDGKSTAVKA,@IZNOS)"
            };
            using (SqlCommand command = command2)
            {
                AppSettingsReader reader = new AppSettingsReader();
                connection.ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString;
                if (Operators.ConditionalCompareObjectGreater(iznos, drv["otvoreno"], false))
                {
                    command.Parameters.Add("@IZNOS", SqlDbType.Money).Value = RuntimeHelpers.GetObjectValue(drv["otvoreno"]);
                }
                else
                {
                    command.Parameters.Add("@IZNOS", SqlDbType.Money).Value = iznos;
                }
                command.Parameters.Add("@GK1IDGKSTAVKA", SqlDbType.BigInt).Value = RuntimeHelpers.GetObjectValue(novired["idgkstavka"]);
                command.Parameters.Add("@GK2IDGKSTAVKA", SqlDbType.BigInt).Value = RuntimeHelpers.GetObjectValue(drv["idgkstavka"]);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                    
                }
            }
        }

        public void OsvjeziOtvorene(string m_STRANA)
        {
            this.dsOTVORENESTAVKE.S_FIN_OTVORENE_STAVKE.Clear();
            if ((m_STRANA == null) & (decimal.Compare(this.__iznos, decimal.Zero) == 0))
            {
                this.dsOTVORENESTAVKE.Merge(this.OtvoreneSve, false);
            }
            if ((m_STRANA == "D") & (decimal.Compare(this.__iznos, decimal.Zero) > 0))
            {
                this.dsOTVORENESTAVKE.Merge(this.OtvorenePotraznePlus, false);
                this.dsOTVORENESTAVKE.Merge(this.OtvorenePotrazneMinus, false);
            }
            if ((m_STRANA == "D") & (decimal.Compare(this.__iznos, decimal.Zero) < 0))
            {
                this.dsOTVORENESTAVKE.Merge(this.OtvorenePotrazneMinus, false);
                this.dsOTVORENESTAVKE.Merge(this.OtvoreneDugovnePlus, false);
            }
            if ((m_STRANA == "P") & (decimal.Compare(this.__iznos, decimal.Zero) > 0))
            {
                this.dsOTVORENESTAVKE.Merge(this.OtvorenePotrazneMinus, false);
                this.dsOTVORENESTAVKE.Merge(this.OtvoreneDugovnePlus, false);
            }
            if ((m_STRANA == "P") & (decimal.Compare(this.__iznos, decimal.Zero) < 0))
            {
                this.dsOTVORENESTAVKE.Merge(this.OtvorenePotraznePlus, false);
                this.dsOTVORENESTAVKE.Merge(this.OtvoreneDugovneMinus, false);
            }
        }

        private void PrihodiDodajDugovnu(DataRowView drv, DataRow[] a, frmObracunPrihodaProracun frmobr, decimal iznos)
        {
            DataRow noviPrihodDugovna = this.NoviPrihodDugovna;
            if (a.Length == 1)
            {
                noviPrihodDugovna["iddokument"] = this.__ParentForm.txtSifrDokumenta.Text;
                noviPrihodDugovna["brojdokumenta"] = this.__ParentForm.txtBrojDokumenta.Text;
                noviPrihodDugovna["brojstavke"] = this.__ParentForm.GkstavkaDataSet1.GKSTAVKA.Rows.Count + 1;
                noviPrihodDugovna["datumdokumenta"] = RuntimeHelpers.GetObjectValue(this.__ParentForm.dteDatumDokumenta.Value);
                noviPrihodDugovna["idmjestotroska"] = RuntimeHelpers.GetObjectValue(drv["idmjestotroska"]);
                noviPrihodDugovna["idorgjed"] = RuntimeHelpers.GetObjectValue(drv["idorgjed"]);
                noviPrihodDugovna["idkonto"] = RuntimeHelpers.GetObjectValue(frmobr.GetDugovniKonto());
                noviPrihodDugovna["idpartner"] = DBNull.Value;
                noviPrihodDugovna["zatvoreniiznos"] = 0;
                noviPrihodDugovna["opis"] = string.Format("{0}-{1}", Strings.Trim(Conversions.ToString(drv["skraceni"])), Strings.Trim(Conversions.ToString(drv["brojdok"])));
                noviPrihodDugovna["duguje"] = iznos;
                noviPrihodDugovna["potrazuje"] = 0;
                noviPrihodDugovna["statusgk"] = 0;
                noviPrihodDugovna["GKGODIDGODINE"] = DateAndTime.Year(this.zavrsni);
                this.__ParentForm.GkstavkaDataSet1.GKSTAVKA.Rows.Add(noviPrihodDugovna);
            }
            else
            {
                noviPrihodDugovna["iddokument"] = this.__ParentForm.txtSifrDokumenta.Text;
                noviPrihodDugovna["brojdokumenta"] = this.__ParentForm.txtBrojDokumenta.Text;
                noviPrihodDugovna["brojstavke"] = this.__ParentForm.GkstavkaDataSet1.GKSTAVKA.Rows.Count + 1;
                noviPrihodDugovna["datumdokumenta"] = RuntimeHelpers.GetObjectValue(this.__ParentForm.dteDatumDokumenta.Value);
                noviPrihodDugovna["idmjestotroska"] = RuntimeHelpers.GetObjectValue(drv["idmjestotroska"]);
                noviPrihodDugovna["idorgjed"] = RuntimeHelpers.GetObjectValue(drv["idorgjed"]);
                noviPrihodDugovna["idkonto"] = RuntimeHelpers.GetObjectValue(frmobr.GetDugovniKonto());
                noviPrihodDugovna["idpartner"] = DBNull.Value;
                noviPrihodDugovna["zatvoreniiznos"] = 0;
                noviPrihodDugovna["opis"] = string.Format("{0}-{1}", Strings.Trim(Conversions.ToString(drv["skraceni"])), Strings.Trim(Conversions.ToString(drv["brojdok"])));
                noviPrihodDugovna["duguje"] = iznos;
                noviPrihodDugovna["potrazuje"] = 0;
                noviPrihodDugovna["statusgk"] = 0;
                noviPrihodDugovna["GKGODIDGODINE"] = DateAndTime.Year(this.zavrsni);
                this.__ParentForm.GkstavkaDataSet1.GKSTAVKA.Rows.Add(noviPrihodDugovna);
            }
        }

        private void PrihodiDodajPotraznu(DataRowView drv, DataRow[] a, frmObracunPrihodaProracun frmobr, decimal iznos)
        {
            DataRow noviPrihodPotrazna = this.NoviPrihodPotrazna;
            if (a.Length == 1)
            {
                noviPrihodPotrazna["iddokument"] = this.__ParentForm.txtSifrDokumenta.Text;
                noviPrihodPotrazna["brojdokumenta"] = this.__ParentForm.txtBrojDokumenta.Text;
                noviPrihodPotrazna["brojstavke"] = this.__ParentForm.GkstavkaDataSet1.GKSTAVKA.Rows.Count + 1;
                noviPrihodPotrazna["datumdokumenta"] = RuntimeHelpers.GetObjectValue(this.__ParentForm.dteDatumDokumenta.Value);
                noviPrihodPotrazna["idmjestotroska"] = RuntimeHelpers.GetObjectValue(drv["idmjestotroska"]);
                noviPrihodPotrazna["idorgjed"] = RuntimeHelpers.GetObjectValue(drv["idorgjed"]);
                noviPrihodPotrazna["idkonto"] = RuntimeHelpers.GetObjectValue(frmobr.GetPotrazniKonto());
                noviPrihodPotrazna["idpartner"] = DBNull.Value;
                noviPrihodPotrazna["zatvoreniiznos"] = 0;
                noviPrihodPotrazna["opis"] = string.Format("{0}-{1}", Strings.Trim(Conversions.ToString(drv["SKRACENI"])), Strings.Trim(Conversions.ToString(drv["brojdok"])));
                noviPrihodPotrazna["duguje"] = 0;
                noviPrihodPotrazna["potrazuje"] = iznos;
                noviPrihodPotrazna["statusgk"] = 0;
                noviPrihodPotrazna["GKGODIDGODINE"] = DateAndTime.Year(this.zavrsni);
                this.__ParentForm.GkstavkaDataSet1.GKSTAVKA.Rows.Add(noviPrihodPotrazna);
            }
            else
            {
                noviPrihodPotrazna["iddokument"] = this.__ParentForm.txtSifrDokumenta.Text;
                noviPrihodPotrazna["brojdokumenta"] = this.__ParentForm.txtBrojDokumenta.Text;
                noviPrihodPotrazna["brojstavke"] = this.__ParentForm.GkstavkaDataSet1.GKSTAVKA.Rows.Count + 1;
                noviPrihodPotrazna["datumdokumenta"] = RuntimeHelpers.GetObjectValue(this.__ParentForm.dteDatumDokumenta.Value);
                noviPrihodPotrazna["idmjestotroska"] = RuntimeHelpers.GetObjectValue(drv["idmjestotroska"]);
                noviPrihodPotrazna["idorgjed"] = RuntimeHelpers.GetObjectValue(drv["idorgjed"]);
                noviPrihodPotrazna["idkonto"] = RuntimeHelpers.GetObjectValue(frmobr.GetPotrazniKonto());
                noviPrihodPotrazna["idpartner"] = DBNull.Value;
                noviPrihodPotrazna["zatvoreniiznos"] = 0;
                noviPrihodPotrazna["opis"] = string.Format("{0}-{1}", Strings.Trim(Conversions.ToString(drv["SKRACENI"])), Strings.Trim(Conversions.ToString(drv["brojdok"])));
                noviPrihodPotrazna["duguje"] = 0;
                noviPrihodPotrazna["potrazuje"] = iznos;
                noviPrihodPotrazna["statusgk"] = 0;
                noviPrihodPotrazna["GKGODIDGODINE"] = DateAndTime.Year(this.zavrsni);
                this.__ParentForm.GkstavkaDataSet1.GKSTAVKA.Rows.Add(noviPrihodPotrazna);
            }
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
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UltraExplorerBar1_ItemClick(object sender, ItemEventArgs e)
        {
            switch (e.Item.Key)
            {
                case "Zatvori":
                    this.Zatvori_Stavku();
                    break;

                case "Izlaz":
                    this.Close();
                    break;
            }
        }

        private void UltraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            this.Zatvori_Stavku();
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        public void Zatvori_Stavku()
        {
            CurrencyManager cm = (CurrencyManager) this.BindingContext[this.dsOTVORENESTAVKE, "S_FIN_OTVORENE_STAVKE"];
            int iDDOKUMENT = Conversions.ToInteger(GetDrv(cm)["IDDOKUMENT"]);
            DOKUMENTDataAdapter adapter = new DOKUMENTDataAdapter();
            DOKUMENTDataSet dataSet = new DOKUMENTDataSet();
            adapter.FillByIDDOKUMENT(dataSet, iDDOKUMENT);
            int num3 = Conversions.ToInteger(dataSet.DOKUMENT.Rows[0]["IDTIPDOKUMENTA"]);
            decimal iznos = new decimal();
            frmIznosZatvaranjaForma forma = new frmIznosZatvaranjaForma {
                Iznos = { Value = RuntimeHelpers.GetObjectValue(GetDrv(cm)["otvoreno"]) }
            };
            forma.ShowDialog();
            if (!Operators.ConditionalCompareObjectEqual(forma.UneseniIznos, 0, false))
            {
                frmObracunPrihodaProracun proracun;
                string str = Conversions.ToString(GetDrv(cm)["konto"]);
                DataRow row = this.__ParentForm.GkstavkaDataSet1.GKSTAVKA.NewRow();
                row["iddokument"] = this.__ParentForm.txtSifrDokumenta.Text;
                row["brojdokumenta"] = this.__ParentForm.txtBrojDokumenta.Text;
                row["brojstavke"] = this.__ParentForm.GkstavkaDataSet1.GKSTAVKA.Rows.Count + 1;
                row["datumdokumenta"] = RuntimeHelpers.GetObjectValue(this.__ParentForm.dteDatumDokumenta.Value);
                row["idmjestotroska"] = RuntimeHelpers.GetObjectValue(GetDrv(cm)["idmjestotroska"]);
                row["idorgjed"] = RuntimeHelpers.GetObjectValue(GetDrv(cm)["idorgjed"]);
                row["idkonto"] = RuntimeHelpers.GetObjectValue(GetDrv(cm)["konto"]);
                row["idpartner"] = RuntimeHelpers.GetObjectValue(GetDrv(cm)["idpartner"]);
                row["zatvoreniiznos"] = 0;
                row["opis"] = string.Format("{0}-{1}", Strings.Trim(Conversions.ToString(GetDrv(cm)["skraceni"])), Strings.Trim(Conversions.ToString(GetDrv(cm)["brojdok"])));
                row["GKGODIDGODINE"] = DateAndTime.Year(this.zavrsni);
                if (Operators.ConditionalCompareObjectGreater(GetDrv(cm)["duguje"], 0, false))
                {
                    row["potrazuje"] = RuntimeHelpers.GetObjectValue(forma.UneseniIznos);
                    row["duguje"] = 0;
                    iznos = Conversions.ToDecimal(forma.UneseniIznos);
                }
                if (Operators.ConditionalCompareObjectGreater(GetDrv(cm)["potrazuje"], 0, false))
                {
                    row["duguje"] = RuntimeHelpers.GetObjectValue(forma.UneseniIznos);
                    row["potrazuje"] = 0;
                    iznos = Conversions.ToDecimal(forma.UneseniIznos);
                }
                if (Operators.ConditionalCompareObjectGreater(GetDrv(cm)["duguje"], 0, false))
                {
                    row["potrazuje"] = RuntimeHelpers.GetObjectValue(forma.UneseniIznos);
                    row["duguje"] = 0;
                    iznos = Conversions.ToDecimal(forma.UneseniIznos);
                }
                if (Operators.ConditionalCompareObjectGreater(GetDrv(cm)["potrazuje"], 0, false))
                {
                    row["duguje"] = RuntimeHelpers.GetObjectValue(forma.UneseniIznos);
                    row["potrazuje"] = 0;
                    iznos = Conversions.ToDecimal(forma.UneseniIznos);
                }
                row["statusgk"] = 0;
                this.__ParentForm.GkstavkaDataSet1.GKSTAVKA.Rows.Add(row);
                GKSTAVKADataAdapter adapter2 = new GKSTAVKADataAdapter();
                adapter2.Update(this.__ParentForm.GkstavkaDataSet1);
                this.KreirajZatvaranja(iznos, GetDrv(cm), row);
                GKSTAVKADataSet set3 = new GKSTAVKADataSet();
                adapter2.FillByIDGKSTAVKA(set3, Conversions.ToInteger(row["idgkstavka"]));
                SqlCommand command = new SqlCommand();
                SqlConnection connection = new SqlConnection();
                GKSTAVKADataSet set = new GKSTAVKADataSet();
                adapter2.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(set, iDDOKUMENT, Conversions.ToInteger(GetDrv(cm)["brojdok"]), (short) DateAndTime.Year(this.zavrsni));
                int count = set.GKSTAVKA.Rows.Count;

                //10.03.15 razdvojena logika zbog uf-a jer nije dobro radilo na irama i uf-u
                DataRow[] a = null;
                if (iDDOKUMENT == 997)
                {
                    a = set.GKSTAVKA.Select("idkonto like '9%' And IDPARTNER = " + row["idpartner"].ToString());
                }
                else
                {
                    a = set.GKSTAVKA.Select("idkonto like '9%'");
                }
                    
                if ((num3 == 1) & (str.Substring(0, 1) == "1"))
                {
                    proracun = new frmObracunPrihodaProracun(Conversions.ToString(9), Conversions.ToString(6));
                    proracun.ShowDialog();
                    if ((proracun.GetDugovniKonto() != null) & (proracun.GetPotrazniKonto() != null))
                    {
                        this.PrihodiDodajDugovnu(GetDrv(cm), a, proracun, iznos);
                        this.PrihodiDodajPotraznu(GetDrv(cm), a, proracun, iznos);
                    }
                    this.__ParentForm.GkstavkaDataSet1.Merge(set3, false);
                    this.OsvjeziOtvorene(this.__strana);
                }
                else if (a.Length == 0)
                {
                    adapter2.Update(this.__ParentForm.GkstavkaDataSet1);
                    this.__ParentForm.GkstavkaDataSet1.Merge(set3, false);
                    this.OsvjeziOtvorene(this.__strana);
                }
                else if ((a.Length > 0) & (num3 == 3))
                {
                    proracun = new frmObracunPrihodaProracun(Conversions.ToString(a[0]["idkonto"]), Conversions.ToString(6));
                    proracun.ShowDialog();
                    if ((proracun.GetDugovniKonto() != null) & (proracun.GetPotrazniKonto() != null))
                    {
                        decimal num5 = Conversions.ToDecimal(a[0]["POTRAZUJE"]);
                        if (decimal.Compare(num5, iznos) > 0)
                        {
                            this.PrihodiDodajDugovnu(GetDrv(cm), a, proracun, iznos);
                            this.PrihodiDodajPotraznu(GetDrv(cm), a, proracun, iznos);
                        }
                        else
                        {
                            this.PrihodiDodajDugovnu(GetDrv(cm), a, proracun, num5);
                            this.PrihodiDodajPotraznu(GetDrv(cm), a, proracun, num5);
                        }
                    }
                    adapter2.Update(this.__ParentForm.GkstavkaDataSet1);
                    this.__ParentForm.GkstavkaDataSet1.Merge(set3, false);
                    this.OsvjeziOtvorene(this.__strana);
                }
                else
                {
                    adapter2.Update(this.__ParentForm.GkstavkaDataSet1);
                    this.__ParentForm.GkstavkaDataSet1.Merge(set3, false);
                    this.OsvjeziOtvorene(this.__strana);
                }
            }
        }

        private AutoHideControl _frmRadSaOtvorenimStavkamaAutoHideControl;

        private UnpinnedTabArea _frmRadSaOtvorenimStavkamaUnpinnedTabAreaBottom;

        private UnpinnedTabArea _frmRadSaOtvorenimStavkamaUnpinnedTabAreaLeft;

        private UnpinnedTabArea _frmRadSaOtvorenimStavkamaUnpinnedTabAreaRight;

        private UnpinnedTabArea _frmRadSaOtvorenimStavkamaUnpinnedTabAreaTop;

        public SqlParameter[] ArParms1
        {
            get
            {
                return new SqlParameter[12];
            }
        }

        private DockableWindow DockableWindow1;

        private DockableWindow DockableWindow2;

        private S_FIN_OTVORENE_STAVKEDataSet dsOTVORENESTAVKE;

        private DataRow NoviPrihodDugovna
        {
            get
            {
                return this.__ParentForm.GkstavkaDataSet1.GKSTAVKA.NewRow();
            }
        }

        private DataRow NoviPrihodPotrazna
        {
            get
            {
                return this.__ParentForm.GkstavkaDataSet1.GKSTAVKA.NewRow();
            }
        }

        public S_FIN_OTVORENE_STAVKEDataSet OtvoreneDugovneMinus
        {
            get
            {
                DateTime pocetni = this.pocetni;
                DateTime zavrsni = this.zavrsni;
                int oRG = -1;
                int mT = -1;
                int dOK = -1;
                int iDAKTIVNOST = -1;
                int iDPARTNER = -1;
                string pOCETNIKONTO = " ";
                string zAVRSNIKONTO = " ";
                int activeYear = mipsed.application.framework.Application.ActiveYear;
                string dODATNIUVJET = "DMS";
                SqlParameter[] parameterArray = new SqlParameter[12];
                S_FIN_OTVORENE_STAVKEDataSet set = new S_FIN_OTVORENE_STAVKEDataSet();
                try
                {
                    new S_FIN_OTVORENE_STAVKEDataAdapter().Fill(this.dsOTVORENESTAVKE, oRG, mT, dOK, pocetni, zavrsni, pOCETNIKONTO, zAVRSNIKONTO, iDAKTIVNOST, iDPARTNER, dODATNIUVJET, (short) activeYear);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
                return set;
            }
        }

        public S_FIN_OTVORENE_STAVKEDataSet OtvoreneDugovnePlus
        {
            get
            {
                DateTime pocetni = this.pocetni;
                DateTime zavrsni = this.zavrsni;
                int oRG = -1;
                int mT = -1;
                int dOK = -1;
                int iDAKTIVNOST = -1;
                int iDPARTNER = -1;
                string pOCETNIKONTO = " ";
                string zAVRSNIKONTO = " ";
                int activeYear = mipsed.application.framework.Application.ActiveYear;
                string dODATNIUVJET = "DPS";
                SqlParameter[] parameterArray = new SqlParameter[12];
                S_FIN_OTVORENE_STAVKEDataSet set = new S_FIN_OTVORENE_STAVKEDataSet();
                try
                {
                    new S_FIN_OTVORENE_STAVKEDataAdapter().Fill(this.dsOTVORENESTAVKE, oRG, mT, dOK, pocetni, zavrsni, pOCETNIKONTO, zAVRSNIKONTO, iDAKTIVNOST, iDPARTNER, dODATNIUVJET, (short) activeYear);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
                return set;
            }
        }

        public S_FIN_OTVORENE_STAVKEDataSet OtvorenePotrazneMinus
        {
            get
            {
                DateTime pocetni = this.pocetni;
                DateTime zavrsni = this.zavrsni;
                int oRG = -1;
                int mT = -1;
                int dOK = -1;
                int iDAKTIVNOST = -1;
                int iDPARTNER = -1;
                string pOCETNIKONTO = " ";
                string zAVRSNIKONTO = " ";
                int activeYear = mipsed.application.framework.Application.ActiveYear;
                string dODATNIUVJET = "PMS";
                SqlParameter[] parameterArray = new SqlParameter[12];
                S_FIN_OTVORENE_STAVKEDataSet set = new S_FIN_OTVORENE_STAVKEDataSet();
                try
                {
                    new S_FIN_OTVORENE_STAVKEDataAdapter().Fill(this.dsOTVORENESTAVKE, oRG, mT, dOK, pocetni, zavrsni, pOCETNIKONTO, zAVRSNIKONTO, iDAKTIVNOST, iDPARTNER, dODATNIUVJET, (short) activeYear);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
                return set;
            }
        }

        public S_FIN_OTVORENE_STAVKEDataSet OtvorenePotraznePlus
        {
            get
            {
                DateTime pocetni = this.pocetni;
                DateTime zavrsni = this.zavrsni;
                int oRG = -1;
                int mT = -1;
                int dOK = -1;
                int iDAKTIVNOST = -1;
                int iDPARTNER = -1;
                string pOCETNIKONTO = " ";
                string zAVRSNIKONTO = " ";
                int activeYear = mipsed.application.framework.Application.ActiveYear;
                string dODATNIUVJET = "PPS";
                SqlParameter[] parameterArray = new SqlParameter[12];
                S_FIN_OTVORENE_STAVKEDataSet set = new S_FIN_OTVORENE_STAVKEDataSet();
                try
                {
                    new S_FIN_OTVORENE_STAVKEDataAdapter().Fill(this.dsOTVORENESTAVKE, oRG, mT, dOK, pocetni, zavrsni, pOCETNIKONTO, zAVRSNIKONTO, iDAKTIVNOST, iDPARTNER, dODATNIUVJET, (short) activeYear);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                    
                }
                return set;
            }
        }

        public S_FIN_OTVORENE_STAVKEDataSet OtvoreneSve
        {
            get
            {
                DateTime pocetni = this.pocetni;
                DateTime zavrsni = this.zavrsni;
                int oRG = -1;
                int mT = -1;
                int dOK = -1;
                //zbog prikaza konta 9 u otvorenim stavkama maknuto da se salje fiksna id aktivnosti u proceduru, gledaju se sva konta koja imaju id aktivnosti vece od 1 isalje se idaktivnosti -10 zbog ostalog rada sa procedurom
                int iDAKTIVNOST = -10;
                int iDPARTNER = -1;
                string pOCETNIKONTO = " ";
                string zAVRSNIKONTO = " ";
                int activeYear = mipsed.application.framework.Application.ActiveYear;
                string dODATNIUVJET = "S";
                SqlParameter[] parameterArray = new SqlParameter[12];
                S_FIN_OTVORENE_STAVKEDataSet set = new S_FIN_OTVORENE_STAVKEDataSet();
                try
                {
                    new S_FIN_OTVORENE_STAVKEDataAdapter().Fill(this.dsOTVORENESTAVKE, oRG, mT, dOK, pocetni, zavrsni, pOCETNIKONTO, zAVRSNIKONTO, iDAKTIVNOST, iDPARTNER, dODATNIUVJET, (short) activeYear);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
                return set;
            }
        }

        private UltraDockManager UltraDockManager1;

        private UltraExplorerBar UltraExplorerBar1;

        private UltraGrid UltraGrid1;

        private UltraGroupBox UltraGroupBox1;

        private WindowDockingArea WindowDockingArea1;

        private WindowDockingArea WindowDockingArea2;
    }
}

