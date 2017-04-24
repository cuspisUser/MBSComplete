namespace NetAdvantage.SmartParts
{
    using CrystalDecisions.CrystalReports.Engine;
    using Deklarit.Practices.CompositeUI.Workspaces;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinDock;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.Controllers;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class Doprinos : UserControl
    {
        [AccessedThroughProperty("_BrutoAutoHideControl")]
        private AutoHideControl __BrutoAutoHideControl;
        [AccessedThroughProperty("_BrutoUnpinnedTabAreaBottom")]
        private UnpinnedTabArea __BrutoUnpinnedTabAreaBottom;
        [AccessedThroughProperty("_BrutoUnpinnedTabAreaLeft")]
        private UnpinnedTabArea __BrutoUnpinnedTabAreaLeft;
        [AccessedThroughProperty("_BrutoUnpinnedTabAreaRight")]
        private UnpinnedTabArea __BrutoUnpinnedTabAreaRight;
        [AccessedThroughProperty("_BrutoUnpinnedTabAreaTop")]
        private UnpinnedTabArea __BrutoUnpinnedTabAreaTop;
        [AccessedThroughProperty("obracun")]
        private UltraTextEditor _obracun;
        [AccessedThroughProperty("S_od_rekap_brutoDataSet1")]
        private s_od_rekap_brutoDataSet _S_od_rekap_brutoDataSet1;
        [AccessedThroughProperty("S_od_rekap_doprinosDataSet1")]
        private s_od_rekap_doprinosDataSet _S_od_rekap_doprinosDataSet1;
        [AccessedThroughProperty("UltraButton1")]
        private UltraButton _UltraButton1;
        [AccessedThroughProperty("UltraButton2")]
        private UltraButton _UltraButton2;
        [AccessedThroughProperty("UltraDockManager1")]
        private UltraDockManager _UltraDockManager1;
        [AccessedThroughProperty("UltraGrid1")]
        private UltraGrid _UltraGrid1;
        private IContainer components;
        public int godina;
        
        public int mjesec;

        public Doprinos()
        {
            base.Load += new EventHandler(this.UserControl1_Load);
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("s_od_rekap_doprinos", -1);
            UltraGridColumn column = new UltraGridColumn("IZNOS");
            UltraGridColumn column2 = new UltraGridColumn("SIFRA");
            UltraGridColumn column3 = new UltraGridColumn("vrsta");
            UltraGridColumn column4 = new UltraGridColumn("NAZIVDOPRINOS");
            UltraGridColumn column5 = new UltraGridColumn("vrstasifra");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.UltraButton1 = new UltraButton();
            this.UltraGrid1 = new UltraGrid();
            this.S_od_rekap_doprinosDataSet1 = new s_od_rekap_doprinosDataSet();
            this.S_od_rekap_brutoDataSet1 = new s_od_rekap_brutoDataSet();
            this.obracun = new UltraTextEditor();
            this.UltraButton2 = new UltraButton();
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._BrutoUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._BrutoUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._BrutoUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._BrutoUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._BrutoAutoHideControl = new AutoHideControl();
            ((ISupportInitialize) this.UltraGrid1).BeginInit();
            this.S_od_rekap_doprinosDataSet1.BeginInit();
            this.S_od_rekap_brutoDataSet1.BeginInit();
            ((ISupportInitialize) this.obracun).BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.SuspendLayout();
            System.Drawing.Point point = new System.Drawing.Point(13, 10);
            this.UltraButton1.Location = point;
            this.UltraButton1.Name = "UltraButton1";
            Size size = new System.Drawing.Size(0x4b, 0x17);
            this.UltraButton1.Size = size;
            this.UltraButton1.TabIndex = 2;
            this.UltraButton1.Text = "Zatvori";
            this.UltraGrid1.DataMember = "s_od_rekap_doprinos";
            this.UltraGrid1.DataSource = this.S_od_rekap_doprinosDataSet1;
            appearance.BackColor = Color.AliceBlue;
            this.UltraGrid1.DisplayLayout.Appearance = appearance;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.Header.Caption = "Iznos";
            column.Header.VisiblePosition = 2;
            column.MaskInput = "{LOC} n,nnn,nnn.nn";
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column2.Header.Caption = "Šifra";
            column2.Header.VisiblePosition = 0;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column3.Header.Caption = "Vrsta dop.";
            column3.Header.VisiblePosition = 1;
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column4.Header.VisiblePosition = 3;
            column4.Width = 0x112;
            column5.Header.VisiblePosition = 4;
            column5.Hidden = true;
            band.Columns.AddRange(new object[] { column, column2, column3, column4, column5 });
            appearance6.FontData.BoldAsString = "True";
            appearance6.TextHAlignAsString = "Center";
            band.Header.Appearance = appearance6;
            band.Header.Caption = "REKAPITULACIJA DOPRINOSA";
            band.HeaderVisible = true;
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance2.BackColor = Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            this.UltraGrid1.DisplayLayout.Override.ColumnAutoSizeMode = ColumnAutoSizeMode.AllRowsInBand;
            appearance3.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            appearance4.BorderColor = Color.LightGray;
            appearance4.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance4;
            this.UltraGrid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance5.BackColor = Color.LightSteelBlue;
            appearance5.BorderColor = Color.Black;
            appearance5.ForeColor = Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCell = SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCol = SelectType.Single;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.UltraGrid1.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.UltraGrid1.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.UltraGrid1.DisplayLayout.TabNavigation = TabNavigation.NextControl;
            this.UltraGrid1.DisplayLayout.ViewStyle = ViewStyle.SingleBand;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0x2a);
            this.UltraGrid1.Location = point;
            this.UltraGrid1.Name = "UltraGrid1";
            size = new System.Drawing.Size(540, 0x176);
            this.UltraGrid1.Size = size;
            this.UltraGrid1.TabIndex = 3;
            this.UltraGrid1.UseAppStyling = false;
            this.S_od_rekap_doprinosDataSet1.DataSetName = "s_od_rekap_doprinosDataSet";
            this.S_od_rekap_brutoDataSet1.DataSetName = "s_od_rekap_brutoDataSet";
            point = new System.Drawing.Point(0xaf, 12);
            this.obracun.Location = point;
            this.obracun.Name = "obracun";
            size = new System.Drawing.Size(100, 0x15);
            this.obracun.Size = size;
            this.obracun.TabIndex = 4;
            point = new System.Drawing.Point(0x5e, 10);
            this.UltraButton2.Location = point;
            this.UltraButton2.Name = "UltraButton2";
            size = new System.Drawing.Size(0x4b, 0x17);
            this.UltraButton2.Size = size;
            this.UltraButton2.TabIndex = 5;
            this.UltraButton2.Text = "Ispiši";
            this.UltraDockManager1.HostControl = this;
            this._BrutoUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._BrutoUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._BrutoUnpinnedTabAreaLeft.Location = point;
            this._BrutoUnpinnedTabAreaLeft.Name = "_BrutoUnpinnedTabAreaLeft";
            this._BrutoUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 0x1aa);
            this._BrutoUnpinnedTabAreaLeft.Size = size;
            this._BrutoUnpinnedTabAreaLeft.TabIndex = 7;
            this._BrutoUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._BrutoUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x21f, 0);
            this._BrutoUnpinnedTabAreaRight.Location = point;
            this._BrutoUnpinnedTabAreaRight.Name = "_BrutoUnpinnedTabAreaRight";
            this._BrutoUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 0x1aa);
            this._BrutoUnpinnedTabAreaRight.Size = size;
            this._BrutoUnpinnedTabAreaRight.TabIndex = 8;
            this._BrutoUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._BrutoUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._BrutoUnpinnedTabAreaTop.Location = point;
            this._BrutoUnpinnedTabAreaTop.Name = "_BrutoUnpinnedTabAreaTop";
            this._BrutoUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x21f, 0);
            this._BrutoUnpinnedTabAreaTop.Size = size;
            this._BrutoUnpinnedTabAreaTop.TabIndex = 9;
            this._BrutoUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._BrutoUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0x1aa);
            this._BrutoUnpinnedTabAreaBottom.Location = point;
            this._BrutoUnpinnedTabAreaBottom.Name = "_BrutoUnpinnedTabAreaBottom";
            this._BrutoUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x21f, 0);
            this._BrutoUnpinnedTabAreaBottom.Size = size;
            this._BrutoUnpinnedTabAreaBottom.TabIndex = 10;
            this._BrutoAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._BrutoAutoHideControl.Location = point;
            this._BrutoAutoHideControl.Name = "_BrutoAutoHideControl";
            this._BrutoAutoHideControl.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0, 0);
            this._BrutoAutoHideControl.Size = size;
            this._BrutoAutoHideControl.TabIndex = 11;
            this.Controls.Add(this._BrutoAutoHideControl);
            this.Controls.Add(this.UltraButton1);
            this.Controls.Add(this.UltraGrid1);
            this.Controls.Add(this.obracun);
            this.Controls.Add(this.UltraButton2);
            this.Controls.Add(this._BrutoUnpinnedTabAreaTop);
            this.Controls.Add(this._BrutoUnpinnedTabAreaBottom);
            this.Controls.Add(this._BrutoUnpinnedTabAreaLeft);
            this.Controls.Add(this._BrutoUnpinnedTabAreaRight);
            this.Name = "Doprinos";
            size = new System.Drawing.Size(0x21f, 0x1aa);
            this.Size = size;
            ((ISupportInitialize) this.UltraGrid1).EndInit();
            this.S_od_rekap_doprinosDataSet1.EndInit();
            this.S_od_rekap_brutoDataSet1.EndInit();
            ((ISupportInitialize) this.obracun).EndInit();
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void obracun_ValueChanged(object sender, EventArgs e)
        {
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void UltraButton2_Click(object sender, EventArgs e)
        {
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dataSet);
            string str6 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1naziv"]);
            string str5 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["MBKORISNIK"]);
            string str = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1adresa"]);
            string str2 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["korisnik1mjesto"]);
            string str8 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"]);
            string str4 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]);
            string str3 = "";
            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptDoprinos.rpt");
            document.SetDataSource(this.S_od_rekap_doprinosDataSet1);
            document.SetParameterValue("OBRACUN", this.obracun.Text + " -isplata plaće za " + DB.MjesecNazivPlatna(this.mjesec) + "/" + Conversions.ToString(this.godina) + ".");
            document.SetParameterValue("BROJRACUNA", str3);
            document.SetParameterValue("ADRESA2", str2);
            document.SetParameterValue("ADRESA", str);
            document.SetParameterValue("USTANOVA", str6);
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            item.Izvjestaj = document;
            item.Activate();
            item.Show(item.Workspaces["main"]);
            this.ParentForm.Close();
        }

        private void UltraNumericEditor1_GotFocus(object sender, EventArgs e)
        {
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            new s_od_rekap_doprinosDataAdapter().Fill(this.S_od_rekap_doprinosDataSet1, this.obracun.Text);
            this.UltraGrid1.Text = "Broj radnika: " + this.S_od_rekap_doprinosDataSet1.Tables[0].Rows.Count;
        }

        internal AutoHideControl _BrutoAutoHideControl
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__BrutoAutoHideControl;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__BrutoAutoHideControl = value;
            }
        }

        internal UnpinnedTabArea _BrutoUnpinnedTabAreaBottom
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__BrutoUnpinnedTabAreaBottom;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__BrutoUnpinnedTabAreaBottom = value;
            }
        }

        internal UnpinnedTabArea _BrutoUnpinnedTabAreaLeft
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__BrutoUnpinnedTabAreaLeft;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__BrutoUnpinnedTabAreaLeft = value;
            }
        }

        internal UnpinnedTabArea _BrutoUnpinnedTabAreaRight
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__BrutoUnpinnedTabAreaRight;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__BrutoUnpinnedTabAreaRight = value;
            }
        }

        internal UnpinnedTabArea _BrutoUnpinnedTabAreaTop
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__BrutoUnpinnedTabAreaTop;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__BrutoUnpinnedTabAreaTop = value;
            }
        }

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

        internal UltraTextEditor obracun
        {
            [DebuggerNonUserCode]
            get
            {
                return this._obracun;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.obracun_ValueChanged);
                if (this._obracun != null)
                {
                    this._obracun.ValueChanged -= handler;
                }
                this._obracun = value;
                if (this._obracun != null)
                {
                    this._obracun.ValueChanged += handler;
                }
            }
        }

        internal s_od_rekap_brutoDataSet S_od_rekap_brutoDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._S_od_rekap_brutoDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._S_od_rekap_brutoDataSet1 = value;
            }
        }

        internal s_od_rekap_doprinosDataSet S_od_rekap_doprinosDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._S_od_rekap_doprinosDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._S_od_rekap_doprinosDataSet1 = value;
            }
        }

        private UltraButton UltraButton1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraButton1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.UltraButton1_Click);
                if (this._UltraButton1 != null)
                {
                    this._UltraButton1.Click -= handler;
                }
                this._UltraButton1 = value;
                if (this._UltraButton1 != null)
                {
                    this._UltraButton1.Click += handler;
                }
            }
        }

        private UltraButton UltraButton2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraButton2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.UltraButton2_Click);
                if (this._UltraButton2 != null)
                {
                    this._UltraButton2.Click -= handler;
                }
                this._UltraButton2 = value;
                if (this._UltraButton2 != null)
                {
                    this._UltraButton2.Click += handler;
                }
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
                this._UltraGrid1 = value;
            }
        }
    }
}

