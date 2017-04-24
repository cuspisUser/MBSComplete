namespace MaticniKarton
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Windows.Forms;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Workspaces;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.UltraWinDock;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using My.Resources;
    using NetAdvantage.Controllers;
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [SmartPart]
    public class MaticniKarton : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private SqlDataAdapter dbAdapter;
        private sp_maticni_kartonDataSet ds;
        private SmartPartInfoProvider infoProvider;
        
        private SmartPartInfo smartPartInfo1;
        private bool suspend;

        public MaticniKarton()
        {
            base.Load += new EventHandler(this.MaticniKarton_Load);
            this.suspend = true;
            this.dbAdapter = new SqlDataAdapter();
            this.ds = new sp_maticni_kartonDataSet();
            this.smartPartInfo1 = new SmartPartInfo("Matični karton", "MaticniKartonRadnika");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        private void chkBruto_CheckedChanged(object sender, EventArgs e)
        {
            this.Ispis_Maticnog_Kartona();
        }

        private void chkDoprinosiIz_CheckedChanged(object sender, EventArgs e)
        {
            this.Ispis_Maticnog_Kartona();
        }

        private void chkDoprinosiNa_CheckedChanged(object sender, EventArgs e)
        {
            this.Ispis_Maticnog_Kartona();
        }

        private void chkNetoNaknade_CheckedChanged(object sender, EventArgs e)
        {
            this.Ispis_Maticnog_Kartona();
        }

        private void chkNetoPlaca_CheckedChanged(object sender, EventArgs e)
        {
            this.Ispis_Maticnog_Kartona();
        }

        private void chkObustave_CheckedChanged(object sender, EventArgs e)
        {
            this.Ispis_Maticnog_Kartona();
        }

        private void chkOlaksice_CheckedChanged(object sender, EventArgs e)
        {
            this.Ispis_Maticnog_Kartona();
        }

        private void chkOO_CheckedChanged(object sender, EventArgs e)
        {
            this.Ispis_Maticnog_Kartona();
        }

        private void chkPorezi_CheckedChanged(object sender, EventArgs e)
        {
            this.Ispis_Maticnog_Kartona();
        }

        private void chkZaIsplatu_CheckedChanged(object sender, EventArgs e)
        {
            this.Ispis_Maticnog_Kartona();
        }

        private void chkZbirniZaCijeluUstanovu_CheckedChanged(object sender, EventArgs e)
        {
            this.Ispis_Maticnog_Kartona();
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("c6a7f647-72f3-4eec-a931-92d8a69cc36c"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("9b5f772d-439c-4cce-9430-c7cf7ed41b87"), new System.Guid("ff1f3300-49fe-4274-bff3-127c5925e74d"), 0, new System.Guid("c6a7f647-72f3-4eec-a931-92d8a69cc36c"), 0);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, new System.Guid("ff1f3300-49fe-4274-bff3-127c5925e74d"));
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RADNIK", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("JMBG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PREZIME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AKTIVAN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGDIO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OIB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UKUPNIFAKTOR");
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RADNIK", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("JMBG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PREZIME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AKTIVAN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGDIO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OIB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UKUPNIFAKTOR");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.godinaisplate = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.chkZb = new System.Windows.Forms.CheckBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.PregledRadnikaSvihDataSet1 = new Placa.PregledRadnikaSvihDataSet();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.chkNeto = new System.Windows.Forms.CheckBox();
            this.chkIsplata = new System.Windows.Forms.CheckBox();
            this.chkOB = new System.Windows.Forms.CheckBox();
            this.chkOL = new System.Windows.Forms.CheckBox();
            this.chkOO = new System.Windows.Forms.CheckBox();
            this.chkDopNA = new System.Windows.Forms.CheckBox();
            this.chkNaknade = new System.Windows.Forms.CheckBox();
            this.chkPO = new System.Windows.Forms.CheckBox();
            this.chkDopIz = new System.Windows.Forms.CheckBox();
            this.chkBr = new System.Windows.Forms.CheckBox();
            this.CrystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.UltraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._MaticniKartonUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MaticniKartonUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MaticniKartonUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MaticniKartonUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MaticniKartonAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.WindowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.DockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.WindowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.cboRadnikDo = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.cboRadnikOd = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.PregledRadnikaDataSet1 = new Placa.PregledRadnikaDataSet();
            this.Panel1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.godinaisplate)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PregledRadnikaSvihDataSet1)).BeginInit();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRadnikDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRadnikOd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PregledRadnikaDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.GroupBox4);
            this.Panel1.Controls.Add(this.GroupBox1);
            this.Panel1.Controls.Add(this.GroupBox2);
            this.Panel1.Location = new System.Drawing.Point(0, 18);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1323, 131);
            this.Panel1.TabIndex = 11;
            // 
            // GroupBox4
            // 
            this.GroupBox4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GroupBox4.Controls.Add(this.godinaisplate);
            this.GroupBox4.Controls.Add(this.chkZb);
            this.GroupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.GroupBox4.Location = new System.Drawing.Point(3, 3);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(476, 42);
            this.GroupBox4.TabIndex = 6;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Godina obračuna";
            // 
            // godinaisplate
            // 
            this.godinaisplate.Location = new System.Drawing.Point(11, 16);
            this.godinaisplate.Name = "godinaisplate";
            this.godinaisplate.Size = new System.Drawing.Size(100, 21);
            this.godinaisplate.TabIndex = 14;
            // 
            // chkZb
            // 
            this.chkZb.Location = new System.Drawing.Point(122, 16);
            this.chkZb.Name = "chkZb";
            this.chkZb.Size = new System.Drawing.Size(250, 20);
            this.chkZb.TabIndex = 13;
            this.chkZb.Text = "Matični karton zbirni za cijelu ustanovu";
            this.chkZb.CheckedChanged += new System.EventHandler(this.chkZbirniZaCijeluUstanovu_CheckedChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GroupBox1.Controls.Add(this.cboRadnikDo);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.cboRadnikOd);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.GroupBox1.Location = new System.Drawing.Point(3, 51);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(486, 75);
            this.GroupBox1.TabIndex = 7;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Radnici";
            // 
            // PregledRadnikaSvihDataSet1
            // 
            this.PregledRadnikaSvihDataSet1.DataSetName = "PregledRadnikaSvihDataSet";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(254, 34);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(65, 17);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Do radnika:";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(12, 36);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(69, 20);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Od radnika:";
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GroupBox2.Controls.Add(this.chkNeto);
            this.GroupBox2.Controls.Add(this.chkIsplata);
            this.GroupBox2.Controls.Add(this.chkOB);
            this.GroupBox2.Controls.Add(this.chkOL);
            this.GroupBox2.Controls.Add(this.chkOO);
            this.GroupBox2.Controls.Add(this.chkDopNA);
            this.GroupBox2.Controls.Add(this.chkNaknade);
            this.GroupBox2.Controls.Add(this.chkPO);
            this.GroupBox2.Controls.Add(this.chkDopIz);
            this.GroupBox2.Controls.Add(this.chkBr);
            this.GroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.GroupBox2.Location = new System.Drawing.Point(497, 3);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(316, 123);
            this.GroupBox2.TabIndex = 8;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Sadržaj matičnog kartona";
            // 
            // chkNeto
            // 
            this.chkNeto.Checked = true;
            this.chkNeto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNeto.Location = new System.Drawing.Point(147, 57);
            this.chkNeto.Name = "chkNeto";
            this.chkNeto.Size = new System.Drawing.Size(144, 20);
            this.chkNeto.TabIndex = 7;
            this.chkNeto.Text = "Neto plaća";
            this.chkNeto.CheckedChanged += new System.EventHandler(this.chkNetoPlaca_CheckedChanged);
            // 
            // chkIsplata
            // 
            this.chkIsplata.Location = new System.Drawing.Point(147, 97);
            this.chkIsplata.Name = "chkIsplata";
            this.chkIsplata.Size = new System.Drawing.Size(144, 20);
            this.chkIsplata.TabIndex = 9;
            this.chkIsplata.Text = "Iznos za isplatu";
            this.chkIsplata.CheckedChanged += new System.EventHandler(this.chkZaIsplatu_CheckedChanged);
            // 
            // chkOB
            // 
            this.chkOB.Location = new System.Drawing.Point(147, 37);
            this.chkOB.Name = "chkOB";
            this.chkOB.Size = new System.Drawing.Size(144, 20);
            this.chkOB.TabIndex = 6;
            this.chkOB.Text = "Obustave";
            this.chkOB.CheckedChanged += new System.EventHandler(this.chkObustave_CheckedChanged);
            // 
            // chkOL
            // 
            this.chkOL.Location = new System.Drawing.Point(147, 17);
            this.chkOL.Name = "chkOL";
            this.chkOL.Size = new System.Drawing.Size(144, 20);
            this.chkOL.TabIndex = 5;
            this.chkOL.Text = "Olakšice";
            this.chkOL.CheckedChanged += new System.EventHandler(this.chkOlaksice_CheckedChanged);
            // 
            // chkOO
            // 
            this.chkOO.Location = new System.Drawing.Point(8, 98);
            this.chkOO.Name = "chkOO";
            this.chkOO.Size = new System.Drawing.Size(144, 20);
            this.chkOO.TabIndex = 4;
            this.chkOO.Text = "Osobni odbitak";
            this.chkOO.CheckedChanged += new System.EventHandler(this.chkOO_CheckedChanged);
            // 
            // chkDopNA
            // 
            this.chkDopNA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkDopNA.Location = new System.Drawing.Point(8, 58);
            this.chkDopNA.Name = "chkDopNA";
            this.chkDopNA.Size = new System.Drawing.Size(144, 20);
            this.chkDopNA.TabIndex = 2;
            this.chkDopNA.Text = "Doprinosi (na plaću)";
            this.chkDopNA.CheckedChanged += new System.EventHandler(this.chkDoprinosiNa_CheckedChanged);
            // 
            // chkNaknade
            // 
            this.chkNaknade.Checked = true;
            this.chkNaknade.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNaknade.Location = new System.Drawing.Point(147, 77);
            this.chkNaknade.Name = "chkNaknade";
            this.chkNaknade.Size = new System.Drawing.Size(144, 20);
            this.chkNaknade.TabIndex = 8;
            this.chkNaknade.Text = "Neto naknade";
            this.chkNaknade.CheckedChanged += new System.EventHandler(this.chkNetoNaknade_CheckedChanged);
            // 
            // chkPO
            // 
            this.chkPO.Location = new System.Drawing.Point(8, 78);
            this.chkPO.Name = "chkPO";
            this.chkPO.Size = new System.Drawing.Size(144, 20);
            this.chkPO.TabIndex = 3;
            this.chkPO.Text = "Porezi i prirez";
            this.chkPO.CheckedChanged += new System.EventHandler(this.chkPorezi_CheckedChanged);
            // 
            // chkDopIz
            // 
            this.chkDopIz.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkDopIz.Location = new System.Drawing.Point(8, 38);
            this.chkDopIz.Name = "chkDopIz";
            this.chkDopIz.Size = new System.Drawing.Size(144, 20);
            this.chkDopIz.TabIndex = 1;
            this.chkDopIz.Text = "Doprinosi (iz plaće)";
            this.chkDopIz.CheckedChanged += new System.EventHandler(this.chkDoprinosiIz_CheckedChanged);
            // 
            // chkBr
            // 
            this.chkBr.Checked = true;
            this.chkBr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBr.Location = new System.Drawing.Point(8, 18);
            this.chkBr.Name = "chkBr";
            this.chkBr.Size = new System.Drawing.Size(144, 20);
            this.chkBr.TabIndex = 0;
            this.chkBr.Text = "Bruto primici";
            this.chkBr.CheckedChanged += new System.EventHandler(this.chkBruto_CheckedChanged);
            // 
            // CrystalReportViewer1
            // 
            this.CrystalReportViewer1.ActiveViewIndex = -1;
            this.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrystalReportViewer1.Location = new System.Drawing.Point(0, 154);
            this.CrystalReportViewer1.Name = "CrystalReportViewer1";
            this.CrystalReportViewer1.ShowGotoPageButton = false;
            this.CrystalReportViewer1.ShowGroupTreeButton = false;
            this.CrystalReportViewer1.ShowParameterPanelButton = false;
            this.CrystalReportViewer1.ShowTextSearchButton = false;
            this.CrystalReportViewer1.Size = new System.Drawing.Size(1323, 347);
            this.CrystalReportViewer1.TabIndex = 10;
            this.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // UltraDockManager1
            // 
            dockAreaPane1.DockedBefore = new System.Guid("ff1f3300-49fe-4274-bff3-127c5925e74d");
            dockableControlPane1.Control = this.Panel1;
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(3, 3, 894, 271);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Panel1";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(1323, 149);
            dockAreaPane2.Size = new System.Drawing.Size(1323, 191);
            this.UltraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2});
            this.UltraDockManager1.HostControl = this;
            // 
            // _MaticniKartonUnpinnedTabAreaLeft
            // 
            this._MaticniKartonUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._MaticniKartonUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._MaticniKartonUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._MaticniKartonUnpinnedTabAreaLeft.Name = "_MaticniKartonUnpinnedTabAreaLeft";
            this._MaticniKartonUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._MaticniKartonUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 501);
            this._MaticniKartonUnpinnedTabAreaLeft.TabIndex = 12;
            // 
            // _MaticniKartonUnpinnedTabAreaRight
            // 
            this._MaticniKartonUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._MaticniKartonUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._MaticniKartonUnpinnedTabAreaRight.Location = new System.Drawing.Point(1323, 0);
            this._MaticniKartonUnpinnedTabAreaRight.Name = "_MaticniKartonUnpinnedTabAreaRight";
            this._MaticniKartonUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._MaticniKartonUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 501);
            this._MaticniKartonUnpinnedTabAreaRight.TabIndex = 13;
            // 
            // _MaticniKartonUnpinnedTabAreaTop
            // 
            this._MaticniKartonUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._MaticniKartonUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._MaticniKartonUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._MaticniKartonUnpinnedTabAreaTop.Name = "_MaticniKartonUnpinnedTabAreaTop";
            this._MaticniKartonUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._MaticniKartonUnpinnedTabAreaTop.Size = new System.Drawing.Size(1323, 0);
            this._MaticniKartonUnpinnedTabAreaTop.TabIndex = 14;
            // 
            // _MaticniKartonUnpinnedTabAreaBottom
            // 
            this._MaticniKartonUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._MaticniKartonUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._MaticniKartonUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 501);
            this._MaticniKartonUnpinnedTabAreaBottom.Name = "_MaticniKartonUnpinnedTabAreaBottom";
            this._MaticniKartonUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._MaticniKartonUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1323, 0);
            this._MaticniKartonUnpinnedTabAreaBottom.TabIndex = 15;
            // 
            // _MaticniKartonAutoHideControl
            // 
            this._MaticniKartonAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._MaticniKartonAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._MaticniKartonAutoHideControl.Name = "_MaticniKartonAutoHideControl";
            this._MaticniKartonAutoHideControl.Owner = this.UltraDockManager1;
            this._MaticniKartonAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._MaticniKartonAutoHideControl.TabIndex = 16;
            // 
            // WindowDockingArea1
            // 
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.WindowDockingArea1.Size = new System.Drawing.Size(1323, 154);
            this.WindowDockingArea1.TabIndex = 17;
            // 
            // DockableWindow1
            // 
            this.DockableWindow1.Controls.Add(this.Panel1);
            this.DockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.DockableWindow1.Size = new System.Drawing.Size(1323, 149);
            this.DockableWindow1.TabIndex = 18;
            // 
            // WindowDockingArea2
            // 
            this.WindowDockingArea2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WindowDockingArea2.Location = new System.Drawing.Point(4, 4);
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.WindowDockingArea2.Size = new System.Drawing.Size(1323, 191);
            this.WindowDockingArea2.TabIndex = 0;
            // 
            // cboRadnikDo
            // 
            appearance23.TextHAlignAsString = "Center";
            this.cboRadnikDo.ButtonAppearance = appearance23;
            appearance24.TextHAlignAsString = "Center";
            editorButton1.Appearance = appearance24;
            editorButton1.Text = "...";
            this.cboRadnikDo.ButtonsRight.Add(editorButton1);
            this.cboRadnikDo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cboRadnikDo.DataMember = "RADNIK";
            this.cboRadnikDo.DataSource = this.PregledRadnikaSvihDataSet1;
            appearance25.BackColor = System.Drawing.SystemColors.Window;
            appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboRadnikDo.DisplayLayout.Appearance = appearance25;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 3;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
            this.cboRadnikDo.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cboRadnikDo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboRadnikDo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance26.BorderColor = System.Drawing.SystemColors.Window;
            this.cboRadnikDo.DisplayLayout.GroupByBox.Appearance = appearance26;
            appearance27.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cboRadnikDo.DisplayLayout.GroupByBox.BandLabelAppearance = appearance27;
            this.cboRadnikDo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance28.BackColor2 = System.Drawing.SystemColors.Control;
            appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance28.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cboRadnikDo.DisplayLayout.GroupByBox.PromptAppearance = appearance28;
            this.cboRadnikDo.DisplayLayout.MaxColScrollRegions = 1;
            this.cboRadnikDo.DisplayLayout.MaxRowScrollRegions = 1;
            appearance.BackColor = System.Drawing.SystemColors.Window;
            appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboRadnikDo.DisplayLayout.Override.ActiveCellAppearance = appearance;
            appearance2.BackColor = System.Drawing.SystemColors.Highlight;
            appearance2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cboRadnikDo.DisplayLayout.Override.ActiveRowAppearance = appearance2;
            this.cboRadnikDo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cboRadnikDo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance3.BackColor = System.Drawing.SystemColors.Window;
            this.cboRadnikDo.DisplayLayout.Override.CardAreaAppearance = appearance3;
            appearance4.BorderColor = System.Drawing.Color.Silver;
            appearance4.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cboRadnikDo.DisplayLayout.Override.CellAppearance = appearance4;
            this.cboRadnikDo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cboRadnikDo.DisplayLayout.Override.CellPadding = 0;
            appearance5.BackColor = System.Drawing.SystemColors.Control;
            appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance5.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.BorderColor = System.Drawing.SystemColors.Window;
            this.cboRadnikDo.DisplayLayout.Override.GroupByRowAppearance = appearance5;
            appearance6.TextHAlignAsString = "Left";
            this.cboRadnikDo.DisplayLayout.Override.HeaderAppearance = appearance6;
            this.cboRadnikDo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cboRadnikDo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            appearance7.BorderColor = System.Drawing.Color.Silver;
            this.cboRadnikDo.DisplayLayout.Override.RowAppearance = appearance7;
            this.cboRadnikDo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cboRadnikDo.DisplayLayout.Override.TemplateAddRowAppearance = appearance8;
            this.cboRadnikDo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cboRadnikDo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cboRadnikDo.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cboRadnikDo.DisplayMember = "IDRADNIK";
            this.cboRadnikDo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cboRadnikDo.DropDownWidth = 400;
            this.cboRadnikDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboRadnikDo.Location = new System.Drawing.Point(325, 31);
            this.cboRadnikDo.MaxDropDownItems = 20;
            this.cboRadnikDo.Name = "cboRadnikDo";
            this.cboRadnikDo.Size = new System.Drawing.Size(117, 22);
            this.cboRadnikDo.TabIndex = 4;
            this.cboRadnikDo.ValueMember = "IDRADNIK";
            // 
            // cboRadnikOd
            // 
            appearance9.TextHAlignAsString = "Center";
            this.cboRadnikOd.ButtonAppearance = appearance9;
            appearance10.TextHAlignAsString = "Center";
            editorButton2.Appearance = appearance10;
            editorButton2.Text = "...";
            this.cboRadnikOd.ButtonsRight.Add(editorButton2);
            this.cboRadnikOd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cboRadnikOd.DataMember = "RADNIK";
            this.cboRadnikOd.DataSource = this.PregledRadnikaSvihDataSet1;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboRadnikOd.DisplayLayout.Appearance = appearance11;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 0;
            ultraGridColumn10.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn10.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 3;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn11.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn11.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn11.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn11.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 1;
            ultraGridColumn12.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn12.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn12.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(165, 0);
            ultraGridColumn12.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn12.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 2;
            ultraGridColumn13.RowLayoutColumnInfo.OriginX = 5;
            ultraGridColumn13.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn13.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(150, 0);
            ultraGridColumn13.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn13.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.VisiblePosition = 4;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.VisiblePosition = 5;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 6;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.VisiblePosition = 7;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.VisiblePosition = 8;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18});
            this.cboRadnikOd.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.cboRadnikOd.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboRadnikOd.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance12.BorderColor = System.Drawing.SystemColors.Window;
            this.cboRadnikOd.DisplayLayout.GroupByBox.Appearance = appearance12;
            appearance13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cboRadnikOd.DisplayLayout.GroupByBox.BandLabelAppearance = appearance13;
            this.cboRadnikOd.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance14.BackColor2 = System.Drawing.SystemColors.Control;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cboRadnikOd.DisplayLayout.GroupByBox.PromptAppearance = appearance14;
            this.cboRadnikOd.DisplayLayout.MaxColScrollRegions = 1;
            this.cboRadnikOd.DisplayLayout.MaxRowScrollRegions = 1;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            appearance15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboRadnikOd.DisplayLayout.Override.ActiveCellAppearance = appearance15;
            appearance16.BackColor = System.Drawing.SystemColors.Highlight;
            appearance16.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cboRadnikOd.DisplayLayout.Override.ActiveRowAppearance = appearance16;
            this.cboRadnikOd.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cboRadnikOd.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance17.BackColor = System.Drawing.SystemColors.Window;
            this.cboRadnikOd.DisplayLayout.Override.CardAreaAppearance = appearance17;
            appearance18.BorderColor = System.Drawing.Color.Silver;
            appearance18.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cboRadnikOd.DisplayLayout.Override.CellAppearance = appearance18;
            this.cboRadnikOd.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cboRadnikOd.DisplayLayout.Override.CellPadding = 0;
            appearance19.BackColor = System.Drawing.SystemColors.Control;
            appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance19.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance19.BorderColor = System.Drawing.SystemColors.Window;
            this.cboRadnikOd.DisplayLayout.Override.GroupByRowAppearance = appearance19;
            appearance20.TextHAlignAsString = "Left";
            this.cboRadnikOd.DisplayLayout.Override.HeaderAppearance = appearance20;
            this.cboRadnikOd.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cboRadnikOd.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance21.BackColor = System.Drawing.SystemColors.Window;
            appearance21.BorderColor = System.Drawing.Color.Silver;
            this.cboRadnikOd.DisplayLayout.Override.RowAppearance = appearance21;
            this.cboRadnikOd.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance22.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cboRadnikOd.DisplayLayout.Override.TemplateAddRowAppearance = appearance22;
            this.cboRadnikOd.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cboRadnikOd.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cboRadnikOd.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cboRadnikOd.DisplayMember = "IDRADNIK";
            this.cboRadnikOd.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
            this.cboRadnikOd.DropDownWidth = 400;
            this.cboRadnikOd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboRadnikOd.Location = new System.Drawing.Point(87, 31);
            this.cboRadnikOd.MaxDropDownItems = 20;
            this.cboRadnikOd.Name = "cboRadnikOd";
            this.cboRadnikOd.Size = new System.Drawing.Size(117, 22);
            this.cboRadnikOd.TabIndex = 1;
            this.cboRadnikOd.ValueMember = "IDRADNIK";
            // 
            // PregledRadnikaDataSet1
            // 
            this.PregledRadnikaDataSet1.DataSetName = "PregledRadnikaDataSet";
            // 
            // MaticniKarton
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this._MaticniKartonAutoHideControl);
            this.Controls.Add(this.CrystalReportViewer1);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._MaticniKartonUnpinnedTabAreaTop);
            this.Controls.Add(this._MaticniKartonUnpinnedTabAreaBottom);
            this.Controls.Add(this._MaticniKartonUnpinnedTabAreaLeft);
            this.Controls.Add(this._MaticniKartonUnpinnedTabAreaRight);
            this.Name = "MaticniKarton";
            this.Size = new System.Drawing.Size(1323, 501);
            this.Panel1.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.godinaisplate)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PregledRadnikaSvihDataSet1)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraDockManager1)).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboRadnikDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRadnikOd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PregledRadnikaDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        private void Ispis_Maticnog_Kartona()
        {
            if (!this.suspend)
            {
                if (Operators.ConditionalCompareObjectEqual(this.godinaisplate.Value, "9999", false))
                {
                    Interaction.MsgBox("Potrebno je otvoriti godinu!", MsgBoxStyle.OkOnly, null);
                }
                else
                {
                    this.ds.Clear();
                    ReportDocument document = new ReportDocument();
                    ExtendedWindowSmartPartInfo info = new ExtendedWindowSmartPartInfo {
                        StartPosition = FormStartPosition.CenterParent,
                        Modal = true,
                        Title = "Pregled izvještaja - Matični karton zaposlenika",
                        Description = "Pregled izvještaja - Matični karton zaposlenika",
                        Icon = ImageResourcesNew.mbs
                    };
                    if ((decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(this.godinaisplate.Value)), 1999M) < 0) | (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(this.godinaisplate.Value)), 2100M) > 0))
                    {
                        MessageBox.Show("Odaberite  godinu isplate za koju želite izvještaj!", "Ispis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.godinaisplate.Select();
                    }
                    else if (((((((((!this.chkBr.Checked & !this.chkDopIz.Checked) & !this.chkDopNA.Checked) & !this.chkPO.Checked) & !this.chkOO.Checked) & !this.chkOL.Checked) & !this.chkOB.Checked) & !this.chkNeto.Checked) & !this.chkNaknade.Checked) & !this.chkIsplata.Checked)
                    {
                        MessageBox.Show("Niste odabrali ni jedan parametar ispisa!", "Ispis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.chkBr.Select();
                    }
                    else
                    {
                        try
                        {
                            ParametriMaticnogKartona kartona = new ParametriMaticnogKartona();
                            this.PostaviParametre(ref kartona);
                            this.PuniPodatke(ref kartona);
                            if (this.ds.Tables[0].Rows.Count != 0)
                            {
                                // ---------------------------------
                                // OVO JE POLOŽENO!
                                // Dakle, bivši developer je report prikazan POLOŽENO nazvao USPRAVNO i obratno...
                                document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptMaticniUspravno.rpt");
                                // ---------------------------------
                                
                                document.SetDataSource(this.ds);
                                if (this.chkZb.Checked)
                                {
                                    ((TextObject) document.ReportDefinition.ReportObjects["txtNaslov"]).Text = "MATIČNI KARTON ZA USTANOVU" + this.godinaisplate.Text;
                                    ((TextObject) document.ReportDefinition.ReportObjects["txtRadnik"]).Text = " ---> uključeni svi zaposlenici u ispis <---";
                                }
                                KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
                                using (KORISNIKDataSet set = new KORISNIKDataSet())
                                {
                                    adapter.Fill(set);
                                    document.SetParameterValue("USTANOVA", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                                    document.SetParameterValue("ADRESA", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                                    document.SetParameterValue("ADRESA2", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
                                    document.SetParameterValue("MB", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KORISNIKOIB"]));
                                    document.SetParameterValue("TELEFON", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KONTAKTTELEFON"]));
                                    document.SetParameterValue("FAX", RuntimeHelpers.GetObjectValue(set.KORISNIK.Rows[0]["KONTAKTFAX"]));
                                }
                                document.SetParameterValue("GODINA", this.godinaisplate.Text);
                                this.CrystalReportViewer1.ReportSource = document;
                            }
                        }
                        catch (System.Exception exception1)
                        {
                            throw exception1;                            
                        }
                    }
                }
            }
        }

        [LocalCommandHandler("Ispisi")]
        public void IspisiHandler(object sender, EventArgs e)
        {
            this.Ispis_Maticnog_Kartona();
        }

        private void MaticniKarton_Load(object sender, EventArgs e)
        {
            this.godinaisplate.Value = "9999";
            PregledRadnikaSvihDataAdapter adapter = new PregledRadnikaSvihDataAdapter();
            PregledRadnikaSvihDataSet set = new PregledRadnikaSvihDataSet();
            adapter.Fill(this.PregledRadnikaSvihDataSet1);
            this.suspend = false;
        }

        [LocalCommandHandler("OtvoriGodinu")]
        public void OtvoriGodinuHandler(object sender, EventArgs e)
        {
            this.PregledGodina();
        }

        private void PostaviParametre(ref ParametriMaticnogKartona strParametri)
        {
            strParametri.nOdZaposlenika = Conversions.ToInteger((string.Compare(this.cboRadnikOd.Text.Trim(), "", false) != 0) ? this.cboRadnikOd.Text : null);
            strParametri.nDoZaposlenika = Conversions.ToInteger((string.Compare(this.cboRadnikDo.Text.Trim(), "", false) != 0) ? this.cboRadnikDo.Text : null);
            strParametri.bZbirni = Conversions.ToBoolean(Interaction.IIf(this.chkZb.Checked, 1, 0));
            strParametri.bBruto = Conversions.ToBoolean(Interaction.IIf(this.chkBr.Checked, 1, 0));
            strParametri.bDoprinosIZ = Conversions.ToBoolean(Interaction.IIf(this.chkDopIz.Checked, 1, 0));
            strParametri.bDoprinosNa = Conversions.ToBoolean(Interaction.IIf(this.chkDopNA.Checked, 1, 0));
            strParametri.bPorezPrirez = Conversions.ToBoolean(Interaction.IIf(this.chkPO.Checked, 1, 0));
            strParametri.bOsobniOdbitak = Conversions.ToBoolean(Interaction.IIf(this.chkOO.Checked, 1, 0));
            strParametri.bObustave = Conversions.ToBoolean(Interaction.IIf(this.chkOB.Checked, 1, 0));
            strParametri.bOlaksiceOsiguranja = Conversions.ToBoolean(Interaction.IIf(this.chkOL.Checked, 1, 0));
            strParametri.bNetoPlaca = Conversions.ToBoolean(Interaction.IIf(this.chkNeto.Checked, 1, 0));
            strParametri.bNetoNaknade = Conversions.ToBoolean(Interaction.IIf(this.chkNaknade.Checked, 1, 0));
            strParametri.bIsplata = Conversions.ToBoolean(Interaction.IIf(this.chkIsplata.Checked, 1, 0));
        }

        public void PregledGodina()
        {
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            frmPreglediGodinaObracuna obracuna = new frmPreglediGodinaObracuna();
            obracuna.ShowDialog();
            if ((obracuna.DialogResult != DialogResult.Cancel) && (obracuna.OdabraniGodinaObracuna != null))
            {
                this.godinaisplate.Value = RuntimeHelpers.GetObjectValue(obracuna.OdabraniGodinaObracuna);
                this.Ispis_Maticnog_Kartona();
            }
        }

        private void PuniPodatke(ref ParametriMaticnogKartona strParametri)
        {
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.StoredProcedure,
                CommandText = "S_PLACA_MATICNI_KARTON_ZAPOSLENIKA_ILI_USTANOVE"
            };
            SqlConnection connection2 = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            SqlConnection connection = connection2;
            this.dbAdapter.SelectCommand = command;
            this.dbAdapter.SelectCommand.Connection = connection;
            this.dbAdapter.SelectCommand.Parameters.AddWithValue("@godina", RuntimeHelpers.GetObjectValue(this.godinaisplate.Value));
            if (strParametri.nOdZaposlenika == 0)
            {
                this.dbAdapter.SelectCommand.Parameters.AddWithValue("@idradnik_od", DBNull.Value);
            }
            else
            {
                this.dbAdapter.SelectCommand.Parameters.AddWithValue("@idradnik_od", strParametri.nOdZaposlenika);
            }
            if (strParametri.nDoZaposlenika == 0)
            {
                this.dbAdapter.SelectCommand.Parameters.AddWithValue("@idradnik_do", DBNull.Value);
            }
            else
            {
                this.dbAdapter.SelectCommand.Parameters.AddWithValue("@idradnik_do", strParametri.nDoZaposlenika);
            }
            this.dbAdapter.SelectCommand.Parameters.AddWithValue("@zbirni", strParametri.bZbirni);
            this.dbAdapter.SelectCommand.Parameters.AddWithValue("@ukljucenobruto", strParametri.bBruto);
            this.dbAdapter.SelectCommand.Parameters.AddWithValue("@UKLJUCENODOPRINOSIIZ", strParametri.bDoprinosIZ);
            this.dbAdapter.SelectCommand.Parameters.AddWithValue("@UKLJUCENODOPRINOSINA", strParametri.bDoprinosNa);
            this.dbAdapter.SelectCommand.Parameters.AddWithValue("@UKLJUCENOPOREZI", strParametri.bPorezPrirez);
            this.dbAdapter.SelectCommand.Parameters.AddWithValue("@UKLJUCENOOO", strParametri.bOsobniOdbitak);
            this.dbAdapter.SelectCommand.Parameters.AddWithValue("@UKLJUCENOOBUSTAVE", strParametri.bObustave);
            this.dbAdapter.SelectCommand.Parameters.AddWithValue("@UKLJUCENOOLAKSICE", strParametri.bOlaksiceOsiguranja);
            this.dbAdapter.SelectCommand.Parameters.AddWithValue("@UKLJUCENONETOPLACA", strParametri.bNetoPlaca);
            this.dbAdapter.SelectCommand.Parameters.AddWithValue("@UKLJUCENONETONAKNADE", strParametri.bNetoNaknade);
            this.dbAdapter.SelectCommand.Parameters.AddWithValue("@UKLJUCENOISPLATA", strParametri.bIsplata);
            this.dbAdapter.Fill(this.ds, "sp_maticni_karton");
        }

        private AutoHideControl _MaticniKartonAutoHideControl;

        private UnpinnedTabArea _MaticniKartonUnpinnedTabAreaBottom;

        private UnpinnedTabArea _MaticniKartonUnpinnedTabAreaLeft;

        private UnpinnedTabArea _MaticniKartonUnpinnedTabAreaRight;

        private UnpinnedTabArea _MaticniKartonUnpinnedTabAreaTop;

        private UltraCombo cboRadnikDo;

        private UltraCombo cboRadnikOd;

        private CheckBox chkBr;

        private CheckBox chkDopIz;

        private CheckBox chkDopNA;

        private CheckBox chkIsplata;

        private CheckBox chkNaknade;

        private CheckBox chkNeto;

        private CheckBox chkOB;

        private CheckBox chkOL;

        private CheckBox chkOO;

        private CheckBox chkPO;

        private CheckBox chkZb;

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

        private CrystalReportViewer CrystalReportViewer1;

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

        private UltraNumericEditor godinaisplate;

        private GroupBox GroupBox1;

        private GroupBox GroupBox2;

        private GroupBox GroupBox4;

        private Label Label1;

        private Label Label2;

        private Panel Panel1;

        private PregledRadnikaDataSet PregledRadnikaDataSet1;

        private PregledRadnikaSvihDataSet PregledRadnikaSvihDataSet1;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraDockManager UltraDockManager1;

        private WindowDockingArea WindowDockingArea1;

        private WindowDockingArea WindowDockingArea2;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ParametriMaticnogKartona
        {
            public int nOdZaposlenika;
            public int nDoZaposlenika;
            public bool bZbirni;
            public bool bBruto;
            public bool bDoprinosIZ;
            public bool bDoprinosNa;
            public bool bPorezPrirez;
            public bool bOsobniOdbitak;
            public bool bObustave;
            public bool bOlaksiceOsiguranja;
            public bool bNetoPlaca;
            public bool bNetoNaknade;
            public bool bIsplata;
        }
    }
}

