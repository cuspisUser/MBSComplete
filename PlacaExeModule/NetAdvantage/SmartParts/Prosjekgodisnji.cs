namespace NetAdvantage.SmartParts
{
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
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.Controllers;
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

    [SmartPart]
    public class Prosjekgodisnji : UserControl, ISmartPartInfoProvider, IFilteredView
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
        [AccessedThroughProperty("DockableWindow1")]
        private DockableWindow _DockableWindow1;
        [AccessedThroughProperty("m_cm")]
        private CurrencyManager _m_cm;
        [AccessedThroughProperty("UltraCombo1")]
        private UltraCombo _UltraCombo1;
        [AccessedThroughProperty("UltraCombo2")]
        private UltraCombo _UltraCombo2;
        [AccessedThroughProperty("UltraDockManager1")]
        private UltraDockManager _UltraDockManager1;
        [AccessedThroughProperty("UltraGrid1")]
        private UltraGrid _UltraGrid1;
        [AccessedThroughProperty("UltraGridExcelExporter1")]
        private UltraGridExcelExporter _UltraGridExcelExporter1;
        [AccessedThroughProperty("UltraGroupBox1")]
        private UltraGroupBox _UltraGroupBox1;
        [AccessedThroughProperty("UltraLabel1")]
        private UltraLabel _UltraLabel1;
        [AccessedThroughProperty("UltraLabel2")]
        private UltraLabel _UltraLabel2;
        [AccessedThroughProperty("UltraLabel3")]
        private UltraLabel _UltraLabel3;
        [AccessedThroughProperty("UltraNumericEditor1")]
        private UltraNumericEditor _UltraNumericEditor1;
        [AccessedThroughProperty("WindowDockingArea1")]
        private WindowDockingArea _WindowDockingArea1;
        private IContainer components;
        private ELEMENTDataAdapter DAELEMENT;
        private PRPLACEDataAdapter dapriprema;
        private RadnikZaObracunDataAdapter daradnik;
        private SmartPartInfoProvider infoProvider;
        private SmartPartInfo smartPartInfo1;

        public Prosjekgodisnji()
        {
            base.Load += new EventHandler(this.Priprema_Load);
            this.dapriprema = new PRPLACEDataAdapter();
            this.DAELEMENT = new ELEMENTDataAdapter();
            this.daradnik = new RadnikZaObracunDataAdapter();
            this.smartPartInfo1 = new SmartPartInfo("Prosjek plaće za godišnji odmor", "ProsjekGodisnji");
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
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Guid internalId = new Guid("e230d3ae-cd86-4b13-aa19-126aab4fc95a");
            DockAreaPane pane2 = new DockAreaPane(DockedLocation.DockedTop, internalId);
            internalId = new Guid("92f6b63e-efa0-435d-af25-7decacd7f421");
            Guid floatingParentId = new Guid("00000000-0000-0000-0000-000000000000");
            Guid dockedParentId = new Guid("e230d3ae-cd86-4b13-aa19-126aab4fc95a");
            DockableControlPane pane = new DockableControlPane(internalId, floatingParentId, -1, dockedParentId, -1);
            this.UltraGroupBox1 = new UltraGroupBox();
            this.UltraLabel3 = new UltraLabel();
            this.UltraLabel2 = new UltraLabel();
            this.UltraLabel1 = new UltraLabel();
            this.UltraNumericEditor1 = new UltraNumericEditor();
            this.UltraCombo2 = new UltraCombo();
            this.UltraCombo1 = new UltraCombo();
            this.UltraGrid1 = new UltraGrid();
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._ProsjekgodisnjiUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._ProsjekgodisnjiUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._ProsjekgodisnjiUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._ProsjekgodisnjiUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._ProsjekgodisnjiAutoHideControl = new AutoHideControl();
            this.WindowDockingArea1 = new WindowDockingArea();
            this.DockableWindow1 = new DockableWindow();
            this.UltraGridExcelExporter1 = new UltraGridExcelExporter(this.components);
            ((ISupportInitialize) this.UltraGroupBox1).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((ISupportInitialize) this.UltraNumericEditor1).BeginInit();
            ((ISupportInitialize) this.UltraCombo2).BeginInit();
            ((ISupportInitialize) this.UltraCombo1).BeginInit();
            ((ISupportInitialize) this.UltraGrid1).BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.SuspendLayout();
            this.UltraGroupBox1.Controls.Add(this.UltraLabel3);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel2);
            this.UltraGroupBox1.Controls.Add(this.UltraLabel1);
            this.UltraGroupBox1.Controls.Add(this.UltraNumericEditor1);
            this.UltraGroupBox1.Controls.Add(this.UltraCombo2);
            this.UltraGroupBox1.Controls.Add(this.UltraCombo1);
            System.Drawing.Point point = new System.Drawing.Point(0, 0x12);
            this.UltraGroupBox1.Location = point;
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            Size size = new System.Drawing.Size(0x40d, 0x85);
            this.UltraGroupBox1.Size = size;
            this.UltraGroupBox1.TabIndex = 1;
            this.UltraGroupBox1.Text = "Odabir razdoblja za izračun prosjeka i broja sati u mjesecu za koji se računa prosjek";
            point = new System.Drawing.Point(0x11, 0x5e);
            this.UltraLabel3.Location = point;
            this.UltraLabel3.Name = "UltraLabel3";
            size = new System.Drawing.Size(0xcd, 0x17);
            this.UltraLabel3.Size = size;
            this.UltraLabel3.TabIndex = 5;
            this.UltraLabel3.Text = "Broj sati u mjesecu godišnjeg odmora";
            point = new System.Drawing.Point(0x11, 0x42);
            this.UltraLabel2.Location = point;
            this.UltraLabel2.Name = "UltraLabel2";
            size = new System.Drawing.Size(0xb8, 0x17);
            this.UltraLabel2.Size = size;
            this.UltraLabel2.TabIndex = 4;
            this.UltraLabel2.Text = "Do godine i mjeseca obračuna";
            point = new System.Drawing.Point(0x11, 0x26);
            this.UltraLabel1.Location = point;
            this.UltraLabel1.Name = "UltraLabel1";
            size = new System.Drawing.Size(0xb8, 0x17);
            this.UltraLabel1.Size = size;
            this.UltraLabel1.TabIndex = 3;
            this.UltraLabel1.Text = "Od godine i mjeseca obračuna";
            point = new System.Drawing.Point(0xe4, 90);
            this.UltraNumericEditor1.Location = point;
            this.UltraNumericEditor1.MaxValue = 200;
            this.UltraNumericEditor1.MinValue = 0;
            this.UltraNumericEditor1.Name = "UltraNumericEditor1";
            size = new System.Drawing.Size(200, 0x15);
            this.UltraNumericEditor1.Size = size;
            this.UltraNumericEditor1.SpinIncrement = 1;
            this.UltraNumericEditor1.TabIndex = 2;
            this.UltraCombo2.CharacterCasing = CharacterCasing.Normal;
            this.UltraCombo2.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.UltraCombo2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraCombo2.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            point = new System.Drawing.Point(0xe4, 0x3e);
            this.UltraCombo2.Location = point;
            this.UltraCombo2.Name = "UltraCombo2";
            size = new System.Drawing.Size(200, 0x16);
            this.UltraCombo2.Size = size;
            this.UltraCombo2.TabIndex = 1;
            this.UltraCombo2.Text = "UltraCombo2";
            this.UltraCombo1.CharacterCasing = CharacterCasing.Normal;
            this.UltraCombo1.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.UltraCombo1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraCombo1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            this.UltraCombo1.LimitToList = true;
            point = new System.Drawing.Point(0xe4, 0x22);
            this.UltraCombo1.Location = point;
            this.UltraCombo1.Name = "UltraCombo1";
            size = new System.Drawing.Size(200, 0x16);
            this.UltraCombo1.Size = size;
            this.UltraCombo1.TabIndex = 0;
            this.UltraCombo1.Text = "UltraCombo1";
            appearance.BackColor = Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance;
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance2.BackColor = Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance3.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance3;
            appearance4.BorderColor = Color.LightGray;
            appearance4.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance4;
            appearance5.BackColor = Color.LightSteelBlue;
            appearance5.BorderColor = Color.Black;
            appearance5.ForeColor = Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.UltraGrid1.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0x9c);
            this.UltraGrid1.Location = point;
            this.UltraGrid1.Name = "UltraGrid1";
            size = new System.Drawing.Size(0x40d, 0x199);
            this.UltraGrid1.Size = size;
            this.UltraGrid1.TabIndex = 0;
            pane.Control = this.UltraGroupBox1;
            Rectangle rectangle = new Rectangle(-15, -15, 200, 110);
            pane.OriginalControlBounds = rectangle;
            size = new System.Drawing.Size(100, 100);
            pane.Size = size;
            pane.Text = "....";
            pane2.Panes.AddRange(new DockablePaneBase[] { pane });
            size = new System.Drawing.Size(0x40d, 0x97);
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
            size = new System.Drawing.Size(0x40d, 0x9c);
            this.WindowDockingArea1.Size = size;
            this.WindowDockingArea1.TabIndex = 7;
            this.DockableWindow1.Controls.Add(this.UltraGroupBox1);
            point = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Location = point;
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            size = new System.Drawing.Size(0x40d, 0x97);
            this.DockableWindow1.Size = size;
            this.DockableWindow1.TabIndex = 8;
            this.Controls.Add(this._ProsjekgodisnjiAutoHideControl);
            this.Controls.Add(this.UltraGrid1);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._ProsjekgodisnjiUnpinnedTabAreaTop);
            this.Controls.Add(this._ProsjekgodisnjiUnpinnedTabAreaBottom);
            this.Controls.Add(this._ProsjekgodisnjiUnpinnedTabAreaLeft);
            this.Controls.Add(this._ProsjekgodisnjiUnpinnedTabAreaRight);
            this.Name = "Prosjekgodisnji";
            size = new System.Drawing.Size(0x40d, 0x235);
            this.Size = size;
            ((ISupportInitialize) this.UltraGroupBox1).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            this.UltraGroupBox1.PerformLayout();
            ((ISupportInitialize) this.UltraNumericEditor1).EndInit();
            ((ISupportInitialize) this.UltraCombo2).EndInit();
            ((ISupportInitialize) this.UltraCombo1).EndInit();
            ((ISupportInitialize) this.UltraGrid1).EndInit();
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
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            SaveFileDialog dialog2 = new SaveFileDialog {
                InitialDirectory = @"C:\Desktop",
                Filter = "Excel datoteke (*.xls)|*.xls|All files (*.*)|*.*",
                FileName = "Prosjek_godisnji_odmor",
                RestoreDirectory = true
            };
            dialog2.ShowDialog();
            try
            {
                this.UltraGridExcelExporter1.Export(this.UltraGrid1, dialog2.FileName);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
        }

        [CommandHandler("Ucitaj")]
        public void UcitajHandler(object sender, EventArgs e)
        {
            IEnumerator enumerator3 = null;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection();
            command.CommandType = CommandType.StoredProcedure;
            connection.ConnectionString = Configuration.ConnectionString;
            command.Connection = connection;
            command.CommandText = "S_PLACA_GODISNJI";
            SqlDataAdapter adapter = new SqlDataAdapter {
                SelectCommand = command
            };
            adapter.SelectCommand.Parameters.AddWithValue("@od", RuntimeHelpers.GetObjectValue(this.UltraCombo1.Value));
            adapter.SelectCommand.Parameters.AddWithValue("@do", RuntimeHelpers.GetObjectValue(this.UltraCombo2.Value));
            adapter.SelectCommand.Parameters.AddWithValue("@mjesecni", RuntimeHelpers.GetObjectValue(this.UltraNumericEditor1.Value));
            adapter.SelectCommand.Parameters.AddWithValue("@tjedni", 40);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            this.UltraGrid1.DataSource = dataSet;
            RADNIKDataSet set3 = new RADNIKDataSet();
            new RADNIKDataAdapter().Fill(set3);
            KORISNIKDataSet set2 = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(set2);
            if (Operators.ConditionalCompareObjectEqual(set2.KORISNIK.Rows[0]["STAZUKOEFICIJENTU"], false, false))
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = set3.RADNIK.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        int num2 = 0;
                        int num3 = 0;
                        int num4 = 0;
                        IEnumerator enumerator2 = null;
                        DataRow current = (DataRow) enumerator.Current;
                        placa.UkupanRadniStaz(Conversions.ToInteger(current["GODINESTAZA"]), Conversions.ToInteger(current["MJESECISTAZA"]), Conversions.ToInteger(current["DANISTAZA"]), Conversions.ToDate(current["datumzadnjegzaposlenjapromjenefondasati"]), DateAndTime.Today, Conversions.ToInteger(current["tjednifondsatistaz"]), 40, Conversions.ToDecimal(Operators.DivideObject(current["BROJPRIZNATIHMJESECI"], 12)), ref num3, ref num4, ref num2);
                        decimal num = Conversions.ToDecimal(Operators.MultiplyObject(4.65, current["TJEDNIFONDSATI"]));
                        try
                        {
                            enumerator2 = dataSet.Tables[0].Rows.GetEnumerator();
                            while (enumerator2.MoveNext())
                            {
                                DataRow row3 = (DataRow) enumerator2.Current;
                                if (Operators.ConditionalCompareObjectEqual(row3["idradnik"], current["idradnik"], false))
                                {
                                    double number = Conversions.ToDouble(Operators.MultiplyObject(current["koeficijent"], 1.0 + ((((double) num3) / 2.0) / 100.0)));
                                    row3["koeficijent"] = DB.RoundUpDecimale(number, 3);
                                }
                            }
                            continue;
                        }
                        finally
                        {
                            if (enumerator2 is IDisposable)
                            {
                                (enumerator2 as IDisposable).Dispose();
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
            }
            dataSet.Tables[0].Columns.Add("BROJ", Type.GetType("System.Int32"));
            dataSet.Tables[0].Columns.Add("ukupno", Type.GetType("System.Decimal"));
            dataSet.Tables[0].Columns.Add("prosjek", Type.GetType("System.Decimal"));
            dataSet.Tables[0].Columns.Add("prosjecnasatnicagodisnji", Type.GetType("System.Decimal"));
            dataSet.Tables[0].Columns.Add("placaredovna", Type.GetType("System.Decimal"));
            dataSet.Tables[0].Columns.Add("prosjecnasatnicaredovna", Type.GetType("System.Decimal"));
            dataSet.Tables[0].Columns.Add("satigodisnjeg", Type.GetType("System.Decimal"));
            dataSet.Tables[0].Columns.Add("satiredovnog", Type.GetType("System.Decimal"));
            dataSet.Tables[0].Columns.Add("brutogodisnjeg", Type.GetType("System.Decimal"), "satigodisnjeg*prosjecnasatnicagodisnji");
            dataSet.Tables[0].Columns.Add("brutoredovnog", Type.GetType("System.Decimal"), "satiredovnog*prosjecnasatnicaredovna");
            try
            {
                enumerator3 = dataSet.Tables[0].Rows.GetEnumerator();
                while (enumerator3.MoveNext())
                {
                    decimal num8 = 0;
                    DataRow row = (DataRow) enumerator3.Current;
                    int vNumber = 0;
                    int num10 = dataSet.Tables[0].Columns.Count - 1;
                    for (int i = 0; i <= num10; i++)
                    {
                        if (dataSet.Tables[0].Columns[i].ColumnName.ToString().StartsWith("20") & (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(row[i])), decimal.Zero) > 0))
                        {
                            vNumber++;
                            num8 = decimal.Add(num8, DB.N20(RuntimeHelpers.GetObjectValue(row[i])));
                        }
                    }
                    row["satigodisnjeg"] = 0;
                    row["satiredovnog"] = 0;
                    row["ukupno"] = num8;
                    try
                    {
                        row["prosjek"] = DB.RoundUpDecimale(decimal.Divide(num8, DB.N20(vNumber)), 2);
                    }
                    catch { row["prosjek"] = 0; }

                    row["BROJ"] = vNumber;

                    try
                    {
                        row["prosjecnasatnicagodisnji"] = DB.RoundUpDecimale(decimal.Divide(decimal.Divide(num8, new decimal(vNumber)), DB.N20(RuntimeHelpers.GetObjectValue(row["sati"]))), 2);
                    }
                    catch (Exception) { row["prosjecnasatnicagodisnji"] = 0; }

                    try
                    {
                        row["prosjecnasatnicaredovna"] = DB.RoundUpDecimale(Operators.DivideObject(Operators.MultiplyObject(row["koeficijent"], 5108.84), DB.N20(RuntimeHelpers.GetObjectValue(row["sati"]))), 2);
                    }
                    catch (Exception) { row["prosjecnasatnicaredovna"] = 0; }

                    row["placaredovna"] = DB.RoundUpDecimale(Operators.MultiplyObject(row["koeficijent"], 5108.84), 2);
                    row["satigodisnjeg"] = RuntimeHelpers.GetObjectValue(row["sati"]);
                    num8 = new decimal();
                    vNumber = 0;
                }
            }
            finally
            {
                if (enumerator3 is IDisposable)
                {
                    (enumerator3 as IDisposable).Dispose();
                }
            }
            dataSet.Tables[0].Columns.Add("ukupnopoobracunu", Type.GetType("System.Decimal"), "brutogodisnjeg+ brutoredovnog");
            dataSet.Tables[0].Columns.Add("razlika", Type.GetType("System.Decimal"), "ukupnopoobracunu- placaredovna");
            ColumnEnumerator enumerator4 = this.UltraGrid1.DisplayLayout.Bands[0].Columns.GetEnumerator();
            while (enumerator4.MoveNext())
            {
                UltraGridColumn column2 = enumerator4.Current;
                if (column2.DataType == Type.GetType("System.Decimal"))
                {
                    if (column2.Key != "koeficijent")
                    {
                        column2.MaskInput = "{double:9.2}";
                    }
                    else
                    {
                        column2.MaskInput = "{double:4.3}";
                    }
                }
            }
        }

        private void UltraGroupBox1_Click(object sender, EventArgs e)
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

        private UltraLabel UltraLabel3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel3 = value;
            }
        }

        internal UltraNumericEditor UltraNumericEditor1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraNumericEditor1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraNumericEditor1 = value;
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

