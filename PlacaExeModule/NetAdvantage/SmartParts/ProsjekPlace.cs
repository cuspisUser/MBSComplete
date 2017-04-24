namespace NetAdvantage.SmartParts
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Windows.Forms;
    using Deklarit.Practices.CompositeUI;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinDock;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinGrid.ExcelExport;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.Commands;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.Controllers;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class ProsjekPlace : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("_ProsjekgodisnjiAutoHideControl")]
        private AutoHideControl __ProsjekgodisnjiAutoHideControl;
        [AccessedThroughProperty("_ProsjekgodisnjiUnpinnedTabAreaBottom")]
        private UnpinnedTabArea __ProsjekgodisnjiUnpinnedTabAreaBottom;
        [AccessedThroughProperty("_ProsjekgodisnjiUnpinnedTabAreaLeft")]
        private UnpinnedTabArea __ProsjekgodisnjiUnpinnedTabAreaLeft;
        [AccessedThroughProperty("_ProsjekgodisnjiUnpinnedTabAreaRight")]
        private UnpinnedTabArea __ProsjekgodisnjiUnpinnedTabAreaRight;
        [AccessedThroughProperty("_ProsjekgodisnjiUnpinnedTabAreaTop")]
        private UnpinnedTabArea __ProsjekgodisnjiUnpinnedTabAreaTop;
        [AccessedThroughProperty("CrystalReportViewer1")]
        private CrystalReportViewer _CrystalReportViewer1;
        [AccessedThroughProperty("DockableWindow1")]
        private DockableWindow _DockableWindow1;
        [AccessedThroughProperty("m_cm")]
        private CurrencyManager _m_cm;
        [AccessedThroughProperty("S_OD_BOLOVANJE_FONDDataSet1")]
        private S_OD_BOLOVANJE_FONDDataSet _S_OD_BOLOVANJE_FONDDataSet1;
        [AccessedThroughProperty("UltraCombo1")]
        private UltraCombo _UltraCombo1;
        [AccessedThroughProperty("UltraCombo2")]
        private UltraCombo _UltraCombo2;
        [AccessedThroughProperty("UltraDockManager1")]
        private UltraDockManager _UltraDockManager1;
        [AccessedThroughProperty("UltraGridExcelExporter1")]
        private UltraGridExcelExporter _UltraGridExcelExporter1;
        [AccessedThroughProperty("UltraGroupBox1")]
        private UltraGroupBox _UltraGroupBox1;
        [AccessedThroughProperty("UltraLabel1")]
        private UltraLabel _UltraLabel1;
        [AccessedThroughProperty("UltraLabel2")]
        private UltraLabel _UltraLabel2;
        [AccessedThroughProperty("UltraTextEditor1")]
        private UltraTextEditor _UltraTextEditor1;
        [AccessedThroughProperty("WindowDockingArea1")]
        private WindowDockingArea _WindowDockingArea1;
        private IContainer components;
        private ELEMENTDataAdapter DAELEMENT;
        private PRPLACEDataAdapter dapriprema;
        private RadnikZaObracunDataAdapter daradnik;
        private SmartPartInfoProvider infoProvider;
        private SmartPartInfo smartPartInfo1;

        public ProsjekPlace()
        {
            base.Load += new EventHandler(this.Priprema_Load);
            this.dapriprema = new PRPLACEDataAdapter();
            this.DAELEMENT = new ELEMENTDataAdapter();
            this.daradnik = new RadnikZaObracunDataAdapter();
            this.smartPartInfo1 = new SmartPartInfo("Prosjek neto plaće", "ProsjekNetoPlace");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            EditorButton button = new EditorButton("zaposlenik");
            Guid internalId = new Guid("e230d3ae-cd86-4b13-aa19-126aab4fc95a");
            DockAreaPane pane2 = new DockAreaPane(DockedLocation.DockedTop, internalId);
            internalId = new Guid("92f6b63e-efa0-435d-af25-7decacd7f421");
            Guid floatingParentId = new Guid("00000000-0000-0000-0000-000000000000");
            Guid dockedParentId = new Guid("e230d3ae-cd86-4b13-aa19-126aab4fc95a");
            DockableControlPane pane = new DockableControlPane(internalId, floatingParentId, -1, dockedParentId, -1);
            this.UltraGroupBox1 = new UltraGroupBox();
            this.UltraTextEditor1 = new UltraTextEditor();
            this.UltraLabel2 = new UltraLabel();
            this.UltraLabel1 = new UltraLabel();
            this.UltraCombo2 = new UltraCombo();
            this.UltraCombo1 = new UltraCombo();
            this.S_OD_BOLOVANJE_FONDDataSet1 = new S_OD_BOLOVANJE_FONDDataSet();
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._ProsjekgodisnjiUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._ProsjekgodisnjiUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._ProsjekgodisnjiUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._ProsjekgodisnjiUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._ProsjekgodisnjiAutoHideControl = new AutoHideControl();
            this.WindowDockingArea1 = new WindowDockingArea();
            this.DockableWindow1 = new DockableWindow();
            this.UltraGridExcelExporter1 = new UltraGridExcelExporter(this.components);
            this.CrystalReportViewer1 = new CrystalReportViewer();
            ((ISupportInitialize) this.UltraGroupBox1).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((ISupportInitialize) this.UltraTextEditor1).BeginInit();
            ((ISupportInitialize) this.UltraCombo2).BeginInit();
            ((ISupportInitialize) this.UltraCombo1).BeginInit();
            this.S_OD_BOLOVANJE_FONDDataSet1.BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.SuspendLayout();
            this.UltraGroupBox1.Controls.Add(this.UltraTextEditor1);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel2);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel1);
            this.UltraGroupBox1.Controls.Add(this.UltraCombo2);
            this.UltraGroupBox1.Controls.Add(this.UltraCombo1);
            System.Drawing.Point point = new System.Drawing.Point(0, 0x12);
            this.UltraGroupBox1.Location = point;
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            Size size = new System.Drawing.Size(0x40d, 0x7c);
            this.UltraGroupBox1.Size = size;
            this.UltraGroupBox1.TabIndex = 1;
            this.UltraGroupBox1.Text = "Odabir razdoblja (godina i mjesec na koji se plaća odnosi)  i zaposlenika ";
            button.Key = "zaposlenik";
            button.Text = "Zaposlenik";
            this.UltraTextEditor1.ButtonsRight.Add(button);
            point = new System.Drawing.Point(0x15, 0x59);
            this.UltraTextEditor1.Location = point;
            this.UltraTextEditor1.Name = "UltraTextEditor1";
            this.UltraTextEditor1.ReadOnly = true;
            size = new System.Drawing.Size(0x191, 0x15);
            this.UltraTextEditor1.Size = size;
            this.UltraTextEditor1.TabIndex = 11;
            this.UltraTextEditor1.Text = "Odaberite zaposlenika";
            point = new System.Drawing.Point(0x15, 60);
            this.UltraLabel2.Location = point;
            this.UltraLabel2.Name = "UltraLabel2";
            size = new System.Drawing.Size(0xb8, 0x17);
            this.UltraLabel2.Size = size;
            this.UltraLabel2.TabIndex = 10;
            this.UltraLabel2.Text = "Do godine i mjeseca obračuna";
            point = new System.Drawing.Point(0x15, 0x20);
            this.UltraLabel1.Location = point;
            this.UltraLabel1.Name = "UltraLabel1";
            size = new System.Drawing.Size(0xb8, 0x17);
            this.UltraLabel1.Size = size;
            this.UltraLabel1.TabIndex = 9;
            this.UltraLabel1.Text = "Od godine i mjeseca obračuna";
            this.UltraCombo2.CharacterCasing = CharacterCasing.Normal;
            this.UltraCombo2.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.UltraCombo2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraCombo2.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            point = new System.Drawing.Point(0xde, 0x38);
            this.UltraCombo2.Location = point;
            this.UltraCombo2.Name = "UltraCombo2";
            size = new System.Drawing.Size(200, 0x16);
            this.UltraCombo2.Size = size;
            this.UltraCombo2.TabIndex = 7;
            this.UltraCombo2.Text = "UltraCombo2";
            this.UltraCombo1.CharacterCasing = CharacterCasing.Normal;
            this.UltraCombo1.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.UltraCombo1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraCombo1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            this.UltraCombo1.LimitToList = true;
            point = new System.Drawing.Point(0xde, 0x1c);
            this.UltraCombo1.Location = point;
            this.UltraCombo1.Name = "UltraCombo1";
            size = new System.Drawing.Size(200, 0x16);
            this.UltraCombo1.Size = size;
            this.UltraCombo1.TabIndex = 6;
            this.UltraCombo1.Text = "UltraCombo1";
            this.S_OD_BOLOVANJE_FONDDataSet1.DataSetName = "S_OD_BOLOVANJE_FONDDataSet";
            pane.Control = this.UltraGroupBox1;
            Rectangle rectangle = new Rectangle(-15, -15, 200, 110);
            pane.OriginalControlBounds = rectangle;
            size = new System.Drawing.Size(100, 100);
            pane.Size = size;
            pane.Text = "...";
            pane2.Panes.AddRange(new DockablePaneBase[] { pane });
            size = new System.Drawing.Size(0x40d, 0x8e);
            pane2.Size = size;
            this.UltraDockManager1.DockAreas.AddRange(new DockAreaPane[] { pane2 });
            this.UltraDockManager1.HostControl = this;
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Location = point;
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Name = "_ProsjekgodisnjiUnpinnedTabAreaLeft";
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 0x235);
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.Size = size;
            this._ProsjekgodisnjiUnpinnedTabAreaLeft.TabIndex = 2;
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x40d, 0);
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Location = point;
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Name = "_ProsjekgodisnjiUnpinnedTabAreaRight";
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 0x235);
            this._ProsjekgodisnjiUnpinnedTabAreaRight.Size = size;
            this._ProsjekgodisnjiUnpinnedTabAreaRight.TabIndex = 3;
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Location = point;
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Name = "_ProsjekgodisnjiUnpinnedTabAreaTop";
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x40d, 0);
            this._ProsjekgodisnjiUnpinnedTabAreaTop.Size = size;
            this._ProsjekgodisnjiUnpinnedTabAreaTop.TabIndex = 4;
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0x235);
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Location = point;
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Name = "_ProsjekgodisnjiUnpinnedTabAreaBottom";
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x40d, 0);
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.Size = size;
            this._ProsjekgodisnjiUnpinnedTabAreaBottom.TabIndex = 5;
            this._ProsjekgodisnjiAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._ProsjekgodisnjiAutoHideControl.Location = point;
            this._ProsjekgodisnjiAutoHideControl.Name = "_ProsjekgodisnjiAutoHideControl";
            this._ProsjekgodisnjiAutoHideControl.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 0);
            this._ProsjekgodisnjiAutoHideControl.Size = size;
            this._ProsjekgodisnjiAutoHideControl.TabIndex = 6;
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.WindowDockingArea1.Dock = DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Location = point;
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x40d, 0x93);
            this.WindowDockingArea1.Size = size;
            this.WindowDockingArea1.TabIndex = 7;
            this.DockableWindow1.Controls.Add(this.UltraGroupBox1);
            point = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Location = point;
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x40d, 0x8e);
            this.DockableWindow1.Size = size;
            this.DockableWindow1.TabIndex = 9;
            this.CrystalReportViewer1.ActiveViewIndex = -1;
            this.CrystalReportViewer1.BorderStyle = BorderStyle.FixedSingle;
            this.CrystalReportViewer1.Cursor = Cursors.Default;
            this.CrystalReportViewer1.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0x93);
            this.CrystalReportViewer1.Location = point;
            this.CrystalReportViewer1.Name = "CrystalReportViewer1";
            this.CrystalReportViewer1.ShowGotoPageButton = false;
            this.CrystalReportViewer1.ShowGroupTreeButton = false;
            this.CrystalReportViewer1.ShowParameterPanelButton = false;
            this.CrystalReportViewer1.ShowTextSearchButton = false;
            size = new System.Drawing.Size(0x40d, 0x1a2);
            this.CrystalReportViewer1.Size = size;
            this.CrystalReportViewer1.TabIndex = 8;
            this.CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
            this.Controls.Add(this._ProsjekgodisnjiAutoHideControl);
            this.Controls.Add(this.CrystalReportViewer1);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._ProsjekgodisnjiUnpinnedTabAreaTop);
            this.Controls.Add(this._ProsjekgodisnjiUnpinnedTabAreaBottom);
            this.Controls.Add(this._ProsjekgodisnjiUnpinnedTabAreaLeft);
            this.Controls.Add(this._ProsjekgodisnjiUnpinnedTabAreaRight);
            this.Name = "ProsjekPlace";
            size = new System.Drawing.Size(0x40d, 0x235);
            this.Size = size;
            ((ISupportInitialize) this.UltraGroupBox1).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((ISupportInitialize) this.UltraTextEditor1).EndInit();
            ((ISupportInitialize) this.UltraCombo2).EndInit();
            ((ISupportInitialize) this.UltraCombo1).EndInit();
            this.S_OD_BOLOVANJE_FONDDataSet1.EndInit();
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void Priprema_Load(object sender, EventArgs e)
        {
            GODINA_I_MJESEC_OBRACUNADataAdapter adapter = new GODINA_I_MJESEC_OBRACUNADataAdapter();
            GODINA_I_MJESEC_OBRACUNADataSet dataSet = new GODINA_I_MJESEC_OBRACUNADataSet();
            adapter.Fill(dataSet);

            this.UltraCombo1.DataSource = dataSet;
            this.UltraCombo2.DataSource = dataSet;
            this.UltraCombo1.DataMember = "GODINA_I_MJESEC_OBRACUNA";
            this.UltraCombo2.DataMember = "GODINA_I_MJESEC_OBRACUNA";

            if (this.UltraCombo1.Rows.Count > 0)
                this.UltraCombo1.SelectedRow = this.UltraCombo1.Rows[0];

            if (this.UltraCombo2.Rows.Count > 0)
                this.UltraCombo2.SelectedRow = this.UltraCombo2.Rows[0];
            
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
            this.UltraCombo1.ValueMember = "godinaimjesecobracuna";
            this.UltraCombo2.ValueMember = "godinaimjesecobracuna";
        }

        [CommandHandler("Snimi")]
        public void SnimiHandler(object sender, EventArgs e)
        {
        }

        [CommandHandler("Ucitaj")]
        public void UcitajHandler(object sender, EventArgs e)
        {
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGroupBox1_Click(object sender, EventArgs e)
        {
        }

        private void UltraTextEditor1_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            if (e.Button.Key == "zaposlenik")
            {
                RADNIKSelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<RADNIKSelectionListWorkItem>("test");
                DataRow row = item.ShowModal(true, "", null);
                item.Terminate();
                if (row != null)
                {
                    this.UltraTextEditor1.Text = Conversions.ToString(row["prezime"]) + "/" + Conversions.ToString(row["ime"]);
                    S_OD_PROSJEK_PLACEDataAdapter adapter2 = new S_OD_PROSJEK_PLACEDataAdapter();
                    S_OD_PROSJEK_PLACEDataSet dataSet = new S_OD_PROSJEK_PLACEDataSet();
                    adapter2.Fill(dataSet, Conversions.ToString(this.UltraCombo1.Value), Conversions.ToString(this.UltraCombo2.Value), Conversions.ToInteger(row["idradnik"]));
                    KORISNIKDataSet set = new KORISNIKDataSet();
                    new KORISNIKDataAdapter().Fill(set);
                    string str6 = Conversions.ToString(set.KORISNIK.Rows[0]["korisnik1naziv"]);
                    string str5 = Conversions.ToString(set.KORISNIK.Rows[0]["MBKORISNIK"]);
                    string str = Conversions.ToString(set.KORISNIK.Rows[0]["korisnik1adresa"]);
                    string str2 = Conversions.ToString(set.KORISNIK.Rows[0]["korisnik1mjesto"]);
                    string str7 = Conversions.ToString(set.KORISNIK.Rows[0]["KONTAKTTELEFON"]);
                    string str4 = Conversions.ToString(set.KORISNIK.Rows[0]["KONTAKTFAX"]);
                    string str3 = "";
                    ReportDocument document = new ReportDocument();
                    document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptProsjekPlace.rpt");
                    document.SetDataSource(dataSet);
                    document.SetParameterValue("BROJRACUNA", str3);
                    document.SetParameterValue("ADRESA2", str2);
                    document.SetParameterValue("ADRESA", str);
                    document.SetParameterValue("ustanova", str6);
                    this.CrystalReportViewer1.ReportSource = document;
                }
            }
        }

        private void UltraTextEditor1_ValueChanged(object sender, EventArgs e)
        {
        }

        internal AutoHideControl _ProsjekgodisnjiAutoHideControl
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__ProsjekgodisnjiAutoHideControl;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__ProsjekgodisnjiAutoHideControl = value;
            }
        }

        internal UnpinnedTabArea _ProsjekgodisnjiUnpinnedTabAreaBottom
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__ProsjekgodisnjiUnpinnedTabAreaBottom;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__ProsjekgodisnjiUnpinnedTabAreaBottom = value;
            }
        }

        internal UnpinnedTabArea _ProsjekgodisnjiUnpinnedTabAreaLeft
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__ProsjekgodisnjiUnpinnedTabAreaLeft;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__ProsjekgodisnjiUnpinnedTabAreaLeft = value;
            }
        }

        internal UnpinnedTabArea _ProsjekgodisnjiUnpinnedTabAreaRight
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__ProsjekgodisnjiUnpinnedTabAreaRight;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__ProsjekgodisnjiUnpinnedTabAreaRight = value;
            }
        }

        internal UnpinnedTabArea _ProsjekgodisnjiUnpinnedTabAreaTop
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__ProsjekgodisnjiUnpinnedTabAreaTop;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__ProsjekgodisnjiUnpinnedTabAreaTop = value;
            }
        }

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

        internal CrystalReportViewer CrystalReportViewer1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._CrystalReportViewer1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._CrystalReportViewer1 = value;
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

        internal S_OD_BOLOVANJE_FONDDataSet S_OD_BOLOVANJE_FONDDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._S_OD_BOLOVANJE_FONDDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._S_OD_BOLOVANJE_FONDDataSet1 = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraCombo UltraCombo1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraCombo1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraCombo1 = value;
            }
        }

        private UltraCombo UltraCombo2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraCombo2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraCombo2 = value;
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

        private UltraGridExcelExporter UltraGridExcelExporter1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGridExcelExporter1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraGridExcelExporter1 = value;
            }
        }

        private UltraGroupBox UltraGroupBox1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.UltraGroupBox1_Click);
                if (this._UltraGroupBox1 != null)
                {
                    this._UltraGroupBox1.Click -= handler;
                }
                this._UltraGroupBox1 = value;
                if (this._UltraGroupBox1 != null)
                {
                    this._UltraGroupBox1.Click += handler;
                }
            }
        }

        private UltraLabel UltraLabel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel1 = value;
            }
        }

        private UltraLabel UltraLabel2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel2 = value;
            }
        }

        internal UltraTextEditor UltraTextEditor1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraTextEditor1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.UltraTextEditor1_ValueChanged);
                EditorButtonEventHandler handler2 = new EditorButtonEventHandler(this.UltraTextEditor1_EditorButtonClick);
                if (this._UltraTextEditor1 != null)
                {
                    this._UltraTextEditor1.ValueChanged -= handler;
                    this._UltraTextEditor1.EditorButtonClick -= handler2;
                }
                this._UltraTextEditor1 = value;
                if (this._UltraTextEditor1 != null)
                {
                    this._UltraTextEditor1.ValueChanged += handler;
                    this._UltraTextEditor1.EditorButtonClick += handler2;
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

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

