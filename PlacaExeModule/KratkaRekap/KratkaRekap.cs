namespace KratkaRekapNamespace
{
    using CrystalDecisions.CrystalReports.Engine;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Workspaces;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.UltraWinDock;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.WorkItems;
    using mipsed.application.framework;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class KratkaRekap : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components;
        private string GODINAOBRACUNA;
        private SmartPartInfoProvider infoProvider;
        
        private string m_opisobracuna;
        private string m_Sifra_Obracuna;
        private string MJESECOBRACUNA;
        private string OPIS;
        private SmartPartInfo smartPartInfo1;

        public KratkaRekapWorkItem KratkaRekapWorkItem;

        public KratkaRekap()
        {
            base.Load += new EventHandler(this.KratkaRekap_Load);
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo("Rekapitulacija obračuna", "Rekapitulacija obračuna");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            ISmartPartInfo info = null;
            return info;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(KratkaRekapNamespace.KratkaRekap));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("dsRekapitulacija", -1);
            UltraGridColumn column = new UltraGridColumn("opis");
            UltraGridColumn column2 = new UltraGridColumn("iznos");
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            UltraGridColumn column3 = new UltraGridColumn("sati");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.daTotaliUstanove = new SqlDataAdapter();
            this.SqlCommand2 = new SqlCommand();
            this.SqlConnection1 = new SqlConnection();
            this.dbcomElementiObracuna = new SqlCommand();
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._KratkaRekapUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this._KratkaRekapUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._KratkaRekapUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._KratkaRekapUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._KratkaRekapAutoHideControl = new AutoHideControl();
            this.UltraGrid3 = new UltraGrid();
            this.dsKratkaRekap = new datasetKratkaRekap();
            this.DsTotaliUstanove1 = new dsTotaliUstanove();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            ((ISupportInitialize) this.UltraGrid3).BeginInit();
            this.dsKratkaRekap.BeginInit();
            this.DsTotaliUstanove1.BeginInit();
            this.SuspendLayout();
            this.daTotaliUstanove.SelectCommand = this.SqlCommand2;
            this.daTotaliUstanove.TableMappings.AddRange(new DataTableMapping[] { new DataTableMapping("Table", "V_OD_OBRACUN_RADNIK_TOTALI", new DataColumnMapping[] { 
                new DataColumnMapping("IDOBRACUN", "IDOBRACUN"), new DataColumnMapping("UKUPNOBRUTO", "UKUPNOBRUTO"), new DataColumnMapping("UKUPNOOSNOVICAZADOPRINOS", "UKUPNOOSNOVICAZADOPRINOS"), new DataColumnMapping("UKUPNODOPRINOSI", "UKUPNODOPRINOSI"), new DataColumnMapping("UKUPNOOO", "UKUPNOOO"), new DataColumnMapping("UKUPNOOLAKSICE", "UKUPNOOLAKSICE"), new DataColumnMapping("UKUPNOPOREZNOPRIZNATEOLAKSICE", "UKUPNOPOREZNOPRIZNATEOLAKSICE"), new DataColumnMapping("POREZNAOSNOVICA", "POREZNAOSNOVICA"), new DataColumnMapping("UKUPNOPOREZ", "UKUPNOPOREZ"), new DataColumnMapping("UKUPNOPRIREZ", "UKUPNOPRIREZ"), new DataColumnMapping("UKUPNOPOREZIPRIREZ", "UKUPNOPOREZIPRIREZ"), new DataColumnMapping("NETOPLACA", "NETOPLACA"), new DataColumnMapping("UKUPNONETONAKNADE", "UKUPNONETONAKNADE"), new DataColumnMapping("NETOPRIMANJA", "NETOPRIMANJA"), new DataColumnMapping("UKUPNOOBUSTAVE", "UKUPNOOBUSTAVE"), new DataColumnMapping("UKUPNOZAISPLATU", "UKUPNOZAISPLATU"), 
                new DataColumnMapping("UKUPNODOPRINOSINA", "UKUPNODOPRINOSINA")
             }) });
            this.SqlCommand2.CommandText = "SELECT     IDOBRACUN, SUM(UKUPNOBRUTO) AS UKUPNOBRUTO, SUM(UKUPNOOSNOVICAZADOPRINOS) AS UKUPNOOSNOVICAZADOPRINOS, SUM(UKUPNODOPRINOSI) AS UKUPNODOPRINOSI, SUM(UKUPNOOO) AS UKUPNOOO, SUM(UKUPNOOLAKSICE) AS UKUPNOOLAKSICE, SUM(UKUPNOPOREZNOPRIZNATEOLAKSICE) AS UKUPNOPOREZNOPRIZNATEOLAKSICE, SUM(POREZNAOSNOVICA) AS POREZNAOSNOVICA, SUM(UKUPNOPOREZ) AS UKUPNOPOREZ, SUM(UKUPNOPRIREZ) AS UKUPNOPRIREZ, SUM(UKUPNOPOREZIPRIREZ) AS UKUPNOPOREZIPRIREZ, SUM(NETOPLACA) AS NETOPLACA, SUM(UKUPNONETONAKNADE) AS UKUPNONETONAKNADE, SUM(NETOPRIMANJA) AS NETOPRIMANJA, SUM(UKUPNOOBUSTAVE) AS UKUPNOOBUSTAVE, SUM(UKUPNOZAISPLATU) AS UKUPNOZAISPLATU, SUM(UKUPNODOPRINOSINA) AS UKUPNODOPRINOSINA, MJESECOBRACUNA, GODINAOBRACUNA, SUM(porezkrizni) AS UKUPNOKRIZNI FROM         VW_PLACA_ZAPOSLENIK_UKUPNO GROUP BY IDOBRACUN, MJESECOBRACUNA, GODINAOBRACUNA HAVING      (IDOBRACUN = @IDOBRACUN)";
            this.SqlCommand2.Connection = this.SqlConnection1;
            this.SqlCommand2.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@IDOBRACUN", SqlDbType.NVarChar, 11, "IDOBRACUN") });
            this.SqlConnection1.ConnectionString = @"Data Source=SRECKO\SQLEXPRESS;Initial Catalog=Rudes;Integrated Security=True";
            this.SqlConnection1.FireInfoMessageEventOnUserErrors = false;
            this.dbcomElementiObracuna.CommandText = "S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA";
            this.dbcomElementiObracuna.CommandType = CommandType.StoredProcedure;
            this.dbcomElementiObracuna.Connection = this.SqlConnection1;
            this.dbcomElementiObracuna.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@IDOBRACUN", SqlDbType.NVarChar) });
            this.UltraDockManager1.HostControl = this;
            this._KratkaRekapUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._KratkaRekapUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._KratkaRekapUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._KratkaRekapUnpinnedTabAreaLeft.Name = "_KratkaRekapUnpinnedTabAreaLeft";
            this._KratkaRekapUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this._KratkaRekapUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 0x284);
            this._KratkaRekapUnpinnedTabAreaLeft.TabIndex = 0xcb;
            this._KratkaRekapUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._KratkaRekapUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._KratkaRekapUnpinnedTabAreaRight.Location = new System.Drawing.Point(0x25e, 0);
            this._KratkaRekapUnpinnedTabAreaRight.Name = "_KratkaRekapUnpinnedTabAreaRight";
            this._KratkaRekapUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this._KratkaRekapUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 0x284);
            this._KratkaRekapUnpinnedTabAreaRight.TabIndex = 0xcc;
            this._KratkaRekapUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._KratkaRekapUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._KratkaRekapUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._KratkaRekapUnpinnedTabAreaTop.Name = "_KratkaRekapUnpinnedTabAreaTop";
            this._KratkaRekapUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this._KratkaRekapUnpinnedTabAreaTop.Size = new System.Drawing.Size(0x25e, 0);
            this._KratkaRekapUnpinnedTabAreaTop.TabIndex = 0xcd;
            this._KratkaRekapUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._KratkaRekapUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._KratkaRekapUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 0x284);
            this._KratkaRekapUnpinnedTabAreaBottom.Name = "_KratkaRekapUnpinnedTabAreaBottom";
            this._KratkaRekapUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this._KratkaRekapUnpinnedTabAreaBottom.Size = new System.Drawing.Size(0x25e, 0);
            this._KratkaRekapUnpinnedTabAreaBottom.TabIndex = 0xce;
            this._KratkaRekapAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this._KratkaRekapAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._KratkaRekapAutoHideControl.Name = "_KratkaRekapAutoHideControl";
            this._KratkaRekapAutoHideControl.Owner = this.UltraDockManager1;
            this._KratkaRekapAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._KratkaRekapAutoHideControl.TabIndex = 0xcf;
            this.UltraGrid3.DataMember = "dsRekapitulacija";
            this.UltraGrid3.DataSource = this.dsKratkaRekap;
            appearance2.BackColor = Color.WhiteSmoke;
            appearance2.ForeColor = Color.MidnightBlue;
            appearance2.TextHAlignAsString = "Left";
            this.UltraGrid3.DisplayLayout.Appearance = appearance2;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.Header.Caption = "Opis iznosa";
            column.Header.VisiblePosition = 0;
            column.Width = 0x12f;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column2.CellActivation = Activation.NoEdit;
            appearance.TextHAlignAsString = "Right";
            column2.CellAppearance = appearance;
            column2.Header.Caption = "Iznos";
            column2.Header.VisiblePosition = 1;
            column2.MaskInput = "{LOC}nnnnnnn.nn";
            column2.Width = 0x89;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance6.TextHAlignAsString = "Right";
            column3.CellAppearance = appearance6;
            column3.Header.Caption = "Sati";
            column3.Header.VisiblePosition = 2;
            column3.Width = 0xa5;
            band.Columns.AddRange(new object[] { column, column2, column3 });
            appearance7.FontData.BoldAsString = "True";
            appearance7.FontData.Name = "Verdana";
            appearance7.FontData.SizeInPoints = 8f;
            appearance7.ForeColor = Color.WhiteSmoke;
            band.Header.Appearance = appearance7;
            appearance8.BackColor = Color.MidnightBlue;
            appearance8.ForeColor = Color.WhiteSmoke;
            band.Override.HeaderAppearance = appearance8;
            appearance9.BackColor = Color.Lavender;
            band.Override.RowAlternateAppearance = appearance9;
            appearance10.BorderColor = Color.DarkGray;
            band.Override.RowAppearance = appearance10;
            band.Override.RowSelectors = DefaultableBoolean.False;
            appearance11.BackColor = Color.CadetBlue;
            appearance11.ForeColor = Color.WhiteSmoke;
            band.Override.SelectedRowAppearance = appearance11;
            this.UltraGrid3.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid3.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            appearance3.BackColor = Color.LightSteelBlue;
            appearance3.ForeColor = Color.MidnightBlue;
            appearance3.ThemedElementAlpha = Alpha.Transparent;
            this.UltraGrid3.DisplayLayout.CaptionAppearance = appearance3;
            appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientStyle = GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraGrid3.DisplayLayout.GroupByBox.Appearance = appearance4;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraGrid3.DisplayLayout.GroupByBox.BandLabelAppearance = appearance5;
            this.UltraGrid3.DisplayLayout.MaxBandDepth = 1;
            this.UltraGrid3.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.UltraGrid3.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.UltraGrid3.DisplayLayout.ViewStyle = ViewStyle.SingleBand;
            this.UltraGrid3.Dock = DockStyle.Fill;
            this.UltraGrid3.Font = new System.Drawing.Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.UltraGrid3.Location = new System.Drawing.Point(0, 0);
            this.UltraGrid3.Name = "UltraGrid3";
            this.UltraGrid3.Size = new System.Drawing.Size(0x25e, 0x284);
            this.UltraGrid3.TabIndex = 0xca;
            this.UltraGrid3.TabStop = false;
            this.UltraGrid3.UseOsThemes = DefaultableBoolean.False;
            this.dsKratkaRekap.DataSetName = "datasetKratkaRekap";
            this.dsKratkaRekap.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.DsTotaliUstanove1.DataSetName = "dsTotaliUstanove";
            this.DsTotaliUstanove1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.Controls.Add(this._KratkaRekapAutoHideControl);
            this.Controls.Add(this.UltraGrid3);
            this.Controls.Add(this._KratkaRekapUnpinnedTabAreaTop);
            this.Controls.Add(this._KratkaRekapUnpinnedTabAreaBottom);
            this.Controls.Add(this._KratkaRekapUnpinnedTabAreaLeft);
            this.Controls.Add(this._KratkaRekapUnpinnedTabAreaRight);
            this.Name = "KratkaRekap";
            this.Size = new System.Drawing.Size(0x25e, 0x284);


            this.UltraGrid3.InitializeLayout += new InitializeLayoutEventHandler(this.UltraGrid3_InitializeLayout);


            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            ((ISupportInitialize) this.UltraGrid3).EndInit();
            this.dsKratkaRekap.EndInit();
            this.DsTotaliUstanove1.EndInit();
            this.ResumeLayout(false);
        }

        public void Ispisi()
        {
            ReportDocument document = new ReportDocument();
            document.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptRekapitulacijaObracun.rpt");
            document.SetDataSource(this.dsKratkaRekap);
            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
            if (item == null)
            {
                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
            }
            int nMjesec = Conversions.ToInteger(this.m_Sifra_Obracuna.Substring(5, 2));
            int num = Conversions.ToInteger(this.m_Sifra_Obracuna.Substring(0, 4));
            nMjesec = Conversions.ToInteger(this.DsTotaliUstanove1.Tables[0].Rows[0]["MJESECOBRACUNA"]);
            num = Conversions.ToInteger(this.DsTotaliUstanove1.Tables[0].Rows[0]["GODINAOBRACUNA"]);
            document.SetParameterValue(0, this.m_Sifra_Obracuna + " -isplata plaće za " + DB.MjesecNazivPlatna(nMjesec) + "/" + Conversions.ToString(num) + ".");
            KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            adapter.Fill(dataSet);
            document.SetParameterValue("naziv", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
            document.SetParameterValue("ADRESA", Operators.AddObject(Operators.AddObject(dataSet.KORISNIK.Rows[0]["KORISNIK1ADRESA"], " "), dataSet.KORISNIK.Rows[0]["KORISNIK1MJESTO"]));
            document.SetParameterValue("oib", RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["KORISNIKOIB"]));
            document.SetParameterValue("TELEFONfax", Operators.AddObject(Operators.AddObject(dataSet.KORISNIK.Rows[0]["KONTAKTTELEFON"], " "), dataSet.KORISNIK.Rows[0]["KONTAKTFAX"]));
            document.SetParameterValue("opisobracuna", this.m_opisobracuna);
            item.Izvjestaj = document;
            item.Activate();
            item.Show(item.Workspaces["main"]);
        }

        [LocalCommandHandler("IspisiCommand")]
        public void IspisiHandler(object sender, EventArgs e)
        {
            this.Ispisi();
        }

        [LocalCommandHandler("IzlazCommand")]
        public void IzlazHandler(object sender, EventArgs e)
        {
            this.Controller.WorkItem.Workspaces["main"].Close(RuntimeHelpers.GetObjectValue(this.Controller.WorkItem.Workspaces["main"].ActiveSmartPart));
        }

        [LocalCommandHandler("KontirajCommand")]
        public void KontirajHandler(object sender, EventArgs e)
        {
            SHEMAPLACADataAdapter adapter = new SHEMAPLACADataAdapter();
            SHEMAPLACADataSet dataSet = new SHEMAPLACADataSet();
            GKSTAVKADataSet set2 = new GKSTAVKADataSet();
            GKSTAVKADataAdapter adapter3 = new GKSTAVKADataAdapter();
            int num = Conversions.ToInteger(Operators.AddObject(this.Zadnji_Broj_Dokumenta(), 1));
            SHEMAPLACASelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<SHEMAPLACASelectionListWorkItem>("test");
            DataRow row3 = item.ShowModal(true, "", null);
            item.Terminate();
            if (row3 != null)
            {
                DataRow row2;
                decimal num3 = 0;
                IEnumerator enumerator = null;
                this.OPIS = this.m_opisobracuna + " " + this.MJESECOBRACUNA + "/" + this.GODINAOBRACUNA + " šifra obr. " + this.m_Sifra_Obracuna;
                adapter.FillByIDSHEMAPLACA(dataSet, Conversions.ToInteger(row3["idshemaplaca"]));
                decimal num2 = Conversions.ToDecimal(this.DsTotaliUstanove1.Tables[0].Rows[0]["uKUPNOBRUTO"]);
                foreach (DataRow row in dataSet.SHEMAPLACASHEMAPLACAELEMENT.Select("SHEMAPLELEMENTIDVRSTAELEMENTA= 2"))
                {
                    if (this.dsKratkaRekap.totalsati.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("idelement='", row["SHEMAPLELEMENTIDELEMENT"]), "'"))).Length > 0)
                    {
                        num3 = Conversions.ToDecimal(Operators.AddObject(num3, this.dsKratkaRekap.totalsati.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("idelement='", row["SHEMAPLELEMENTIDELEMENT"]), "'")))[0]["iznos"]));
                        row2 = set2.GKSTAVKA.NewRow();
                        row2["datumdokumenta"] = DateAndTime.Today;
                        row2["brojdokumenta"] = num;
                        row2["brojstavke"] = 1;
                        row2["iddokument"] = 0x3e7;
                        row2["OPIS"] = Operators.ConcatenateObject(this.OPIS + " ", this.dsKratkaRekap.totalsati.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("idelement='", row["SHEMAPLELEMENTIDELEMENT"]), "'")))[0][2]);
                        row2["zatvoreniiznos"] = 0;
                        row2["statusgk"] = 0;
                        row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(row["KONTOELEMENTIDKONTO"]);
                        row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["MTELEMENTIDMJESTOTROSKA"]);
                        row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMAPLACA.Rows[0]["SHEMAPLOJIDORGJED"]);
                        row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                        if (Operators.ConditionalCompareObjectEqual(row["STRANEELEMENTIDSTRANEKNJIZENJA"], 1, false))
                        {
                            row2["duguje"] = RuntimeHelpers.GetObjectValue(this.dsKratkaRekap.totalsati.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("idelement='", row["SHEMAPLELEMENTIDELEMENT"]), "'")))[0]["iznos"]);
                            row2["potrazuje"] = 0;
                        }
                        else
                        {
                            row2["potrazuje"] = RuntimeHelpers.GetObjectValue(this.dsKratkaRekap.totalsati.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("idelement='", row["SHEMAPLELEMENTIDELEMENT"]), "'")))[0]["iznos"]);
                            row2["duguje"] = 0;
                        }
                        set2.GKSTAVKA.Rows.Add(row2);
                    }
                }
                if (dataSet.SHEMAPLACASHEMAPLACASTANDARD.Select("idplvrsteiznosa=1").Length > 0)
                {
                    row2 = set2.GKSTAVKA.NewRow();
                    row2["datumdokumenta"] = DateAndTime.Today;
                    row2["brojdokumenta"] = num;
                    row2["brojstavke"] = 1;
                    row2["iddokument"] = 0x3e7;
                    row2["OPIS"] = this.OPIS;
                    row2["zatvoreniiznos"] = 0;
                    row2["statusgk"] = 0;
                    row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMAPLACASHEMAPLACASTANDARD.Select("idplvrsteiznosa=1")[0]["KONTOPLACAVRSTAIZNOSAIDKONTO"]);
                    row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMAPLACASHEMAPLACASTANDARD.Select("idplvrsteiznosa=1")[0]["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"]);
                    row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMAPLACA.Rows[0]["SHEMAPLOJIDORGJED"]);
                    row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                    if (Operators.ConditionalCompareObjectEqual(dataSet.SHEMAPLACASHEMAPLACASTANDARD.Select("idplvrsteiznosa=1")[0]["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"], 1, false))
                    {
                        row2["duguje"] = Operators.SubtractObject(this.DsTotaliUstanove1.Tables[0].Rows[0]["uKUPNOBRUTO"], num3);
                        row2["potrazuje"] = 0;
                    }
                    else
                    {
                        row2["potrazuje"] = Operators.SubtractObject(this.DsTotaliUstanove1.Tables[0].Rows[0]["uKUPNOBRUTO"], num3);
                        row2["duguje"] = 0;
                    }
                    set2.GKSTAVKA.Rows.Add(row2);
                }
                s_od_rekap_doprinosDataAdapter adapter2 = new s_od_rekap_doprinosDataAdapter();
                s_od_rekap_doprinosDataSet set3 = new s_od_rekap_doprinosDataSet();
                adapter2.Fill(set3, this.m_Sifra_Obracuna);
                try
                {
                    DataRow current = null;
                    enumerator = dataSet.SHEMAPLACASHEMAPLACADOP.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        current = (DataRow)enumerator.Current;
                        if (set3.s_od_rekap_doprinos.Select(Conversions.ToString(Operators.ConcatenateObject("sifra = ", current["SHEMAPLDOPIDDOPRINOS"]))).Length > 0)
                        {
                            row2 = set2.GKSTAVKA.NewRow();
                            row2["datumdokumenta"] = DateAndTime.Today;
                            row2["brojdokumenta"] = num;
                            row2["brojstavke"] = 1;
                            row2["iddokument"] = 0x3e7;
                            row2["OPIS"] = this.OPIS;
                            row2["zatvoreniiznos"] = 0;
                            row2["statusgk"] = 0;
                            row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(current["KONTODOPIDKONTO"]);
                            row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(current["MTDOPIDMJESTOTROSKA"]);
                            row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMAPLACA.Rows[0]["SHEMAPLOJIDORGJED"]);
                            row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                            if (Operators.ConditionalCompareObjectEqual(current["STRANEDOPIDSTRANEKNJIZENJA"], 1, false))
                            {
                                row2["duguje"] = RuntimeHelpers.GetObjectValue(set3.s_od_rekap_doprinos.Select(Conversions.ToString(Operators.ConcatenateObject("sifra = ", current["SHEMAPLDOPIDDOPRINOS"])))[0]["iznos"]);
                                row2["potrazuje"] = 0;
                            }
                            else
                            {
                                row2["potrazuje"] = RuntimeHelpers.GetObjectValue(set3.s_od_rekap_doprinos.Select(Conversions.ToString(Operators.ConcatenateObject("sifra = ", current["SHEMAPLDOPIDDOPRINOS"])))[0]["iznos"]);
                                row2["duguje"] = 0;
                            }
                            set2.GKSTAVKA.Rows.Add(row2);
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
                foreach (DataRow row in dataSet.SHEMAPLACASHEMAPLACASTANDARD.Select("idplvrsteiznosa=2"))
                {
                    row2 = set2.GKSTAVKA.NewRow();
                    row2["datumdokumenta"] = DateAndTime.Today;
                    row2["brojdokumenta"] = num;
                    row2["brojstavke"] = 1;
                    row2["iddokument"] = 0x3e7;
                    row2["OPIS"] = this.OPIS;
                    row2["zatvoreniiznos"] = 0;
                    row2["statusgk"] = 0;
                    row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(row["KONTOPLACAVRSTAIZNOSAIDKONTO"]);
                    row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"]);
                    row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMAPLACA.Rows[0]["SHEMAPLOJIDORGJED"]);
                    row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                    if (Operators.ConditionalCompareObjectEqual(row["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"], 1, false))
                    {
                        row2["duguje"] = RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnoporez"]);
                        row2["potrazuje"] = 0;
                    }
                    else
                    {
                        row2["potrazuje"] = RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnoporez"]);
                        row2["duguje"] = 0;
                    }
                    set2.GKSTAVKA.Rows.Add(row2);
                }
                foreach (DataRow row in dataSet.SHEMAPLACASHEMAPLACASTANDARD.Select("idplvrsteiznosa=3"))
                {
                    row2 = set2.GKSTAVKA.NewRow();
                    row2["datumdokumenta"] = DateAndTime.Today;
                    row2["brojdokumenta"] = num;
                    row2["brojstavke"] = 1;
                    row2["iddokument"] = 0x3e7;
                    row2["OPIS"] = this.OPIS;
                    row2["zatvoreniiznos"] = 0;
                    row2["statusgk"] = 0;
                    row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(row["KONTOPLACAVRSTAIZNOSAIDKONTO"]);
                    row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"]);
                    row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMAPLACA.Rows[0]["SHEMAPLOJIDORGJED"]);
                    row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                    if (Operators.ConditionalCompareObjectEqual(row["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"], 1, false))
                    {
                        row2["duguje"] = RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnoprirez"]);
                        row2["potrazuje"] = 0;
                    }
                    else
                    {
                        row2["potrazuje"] = RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnoprirez"]);
                        row2["duguje"] = 0;
                    }
                    set2.GKSTAVKA.Rows.Add(row2);
                }
                foreach (DataRow row in dataSet.SHEMAPLACASHEMAPLACASTANDARD.Select("idplvrsteiznosa=4"))
                {
                    row2 = set2.GKSTAVKA.NewRow();
                    row2["datumdokumenta"] = DateAndTime.Today;
                    row2["brojdokumenta"] = num;
                    row2["brojstavke"] = 1;
                    row2["iddokument"] = 0x3e7;
                    row2["OPIS"] = this.OPIS;
                    row2["zatvoreniiznos"] = 0;
                    row2["statusgk"] = 0;
                    row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(row["KONTOPLACAVRSTAIZNOSAIDKONTO"]);
                    row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"]);
                    row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMAPLACA.Rows[0]["SHEMAPLOJIDORGJED"]);
                    row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                    if (Operators.ConditionalCompareObjectEqual(row["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"], 1, false))
                    {
                        row2["duguje"] = RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnokrizni"]);
                        row2["potrazuje"] = 0;
                    }
                    else
                    {
                        row2["potrazuje"] = RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnokrizni"]);
                        row2["duguje"] = 0;
                    }
                    set2.GKSTAVKA.Rows.Add(row2);
                }
                foreach (DataRow row in dataSet.SHEMAPLACASHEMAPLACASTANDARD.Select("idplvrsteiznosa=5"))
                {
                    row2 = set2.GKSTAVKA.NewRow();
                    row2["datumdokumenta"] = DateAndTime.Today;
                    row2["brojdokumenta"] = num;
                    row2["brojstavke"] = 1;
                    row2["iddokument"] = 0x3e7;
                    row2["OPIS"] = this.OPIS;
                    row2["zatvoreniiznos"] = 0;
                    row2["statusgk"] = 0;
                    row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(row["KONTOPLACAVRSTAIZNOSAIDKONTO"]);
                    row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"]);
                    row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMAPLACA.Rows[0]["SHEMAPLOJIDORGJED"]);
                    row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                    if (Operators.ConditionalCompareObjectEqual(row["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"], 1, false))
                    {
                        row2["duguje"] = Operators.SubtractObject(this.DsTotaliUstanove1.Tables[0].Rows[0]["netoplaca"], this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnokrizni"]);
                        row2["potrazuje"] = 0;
                    }
                    else
                    {
                        row2["potrazuje"] = Operators.SubtractObject(this.DsTotaliUstanove1.Tables[0].Rows[0]["netoplaca"], this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnokrizni"]);
                        row2["duguje"] = 0;
                    }
                    set2.GKSTAVKA.Rows.Add(row2);
                }
                foreach (DataRow row in dataSet.SHEMAPLACASHEMAPLACAELEMENT.Select("SHEMAPLELEMENTIDVRSTAELEMENTA= 1"))
                {
                    if (this.dsKratkaRekap.totalsati.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("idelement='", row["SHEMAPLELEMENTIDELEMENT"]), "'"))).Length > 0)
                    {
                        row2 = set2.GKSTAVKA.NewRow();
                        row2["datumdokumenta"] = DateAndTime.Today;
                        row2["brojdokumenta"] = num;
                        row2["brojstavke"] = 1;
                        row2["iddokument"] = 0x3e7;
                        row2["OPIS"] = Operators.ConcatenateObject(this.OPIS + " ", this.dsKratkaRekap.totalsati.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("idelement='", row["SHEMAPLELEMENTIDELEMENT"]), "'")))[0][2]);
                        row2["zatvoreniiznos"] = 0;
                        row2["statusgk"] = 0;
                        row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(row["KONTOELEMENTIDKONTO"]);
                        row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["MTELEMENTIDMJESTOTROSKA"]);
                        row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMAPLACA.Rows[0]["SHEMAPLOJIDORGJED"]);
                        row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                        if (Operators.ConditionalCompareObjectEqual(row["STRANEELEMENTIDSTRANEKNJIZENJA"], 1, false))
                        {
                            row2["duguje"] = RuntimeHelpers.GetObjectValue(this.dsKratkaRekap.totalsati.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("idelement='", row["SHEMAPLELEMENTIDELEMENT"]), "'")))[0]["iznos"]);
                            row2["potrazuje"] = 0;
                        }
                        else
                        {
                            row2["potrazuje"] = RuntimeHelpers.GetObjectValue(this.dsKratkaRekap.totalsati.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("idelement='", row["SHEMAPLELEMENTIDELEMENT"]), "'")))[0]["iznos"]);
                            row2["duguje"] = 0;
                        }
                        set2.GKSTAVKA.Rows.Add(row2);
                    }
                }
                foreach (DataRow row in dataSet.SHEMAPLACASHEMAPLACASTANDARD.Select("idplvrsteiznosa=6"))
                {
                    row2 = set2.GKSTAVKA.NewRow();
                    row2["datumdokumenta"] = DateAndTime.Today;
                    row2["brojdokumenta"] = num;
                    row2["brojstavke"] = 1;
                    row2["iddokument"] = 0x3e7;
                    row2["OPIS"] = this.OPIS;
                    row2["zatvoreniiznos"] = 0;
                    row2["statusgk"] = 0;
                    row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(row["KONTOPLACAVRSTAIZNOSAIDKONTO"]);
                    row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"]);
                    row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMAPLACA.Rows[0]["SHEMAPLOJIDORGJED"]);
                    row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                    if (Operators.ConditionalCompareObjectEqual(row["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"], 1, false))
                    {
                        row2["duguje"] = Operators.AddObject(this.DsTotaliUstanove1.Tables[0].Rows[0]["uKUPNOBRUTO"], this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnodoprinosina"]);
                        row2["potrazuje"] = 0;
                    }
                    else
                    {
                        row2["potrazuje"] = Operators.AddObject(this.DsTotaliUstanove1.Tables[0].Rows[0]["uKUPNOBRUTO"], this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnodoprinosina"]);
                        row2["duguje"] = 0;
                    }
                    set2.GKSTAVKA.Rows.Add(row2);
                }
                foreach (DataRow row in dataSet.SHEMAPLACASHEMAPLACASTANDARD.Select("idplvrsteiznosa=7"))
                {
                    row2 = set2.GKSTAVKA.NewRow();
                    row2["datumdokumenta"] = DateAndTime.Today;
                    row2["brojdokumenta"] = num;
                    row2["brojstavke"] = 1;
                    row2["iddokument"] = 0x3e7;
                    row2["OPIS"] = this.OPIS;
                    row2["zatvoreniiznos"] = 0;
                    row2["statusgk"] = 0;
                    row2["IDKONTO"] = RuntimeHelpers.GetObjectValue(row["KONTOPLACAVRSTAIZNOSAIDKONTO"]);
                    row2["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"]);
                    row2["IDORGJED"] = RuntimeHelpers.GetObjectValue(dataSet.SHEMAPLACA.Rows[0]["SHEMAPLOJIDORGJED"]);
                    row2["GKGODIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
                    if (Operators.ConditionalCompareObjectEqual(row["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"], 1, false))
                    {
                        row2["duguje"] = Operators.AddObject(Operators.AddObject(this.DsTotaliUstanove1.Tables[0].Rows[0]["uKUPNOBRUTO"], this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnodoprinosina"]), this.DsTotaliUstanove1.Tables[0].Rows[0]["UKUPNONETONAKNADE"]);
                        row2["potrazuje"] = 0;
                    }
                    else
                    {
                        row2["potrazuje"] = Operators.AddObject(Operators.AddObject(this.DsTotaliUstanove1.Tables[0].Rows[0]["uKUPNOBRUTO"], this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnodoprinosina"]), this.DsTotaliUstanove1.Tables[0].Rows[0]["UKUPNONETONAKNADE"]);
                        row2["duguje"] = 0;
                    }
                    set2.GKSTAVKA.Rows.Add(row2);
                }
                ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterParent,
                    Modal = true,
                    ControlBox = false,
                    Title = "Pretpregled temeljnice prije knjiženja",
                    Icon = ImageResourcesNew.mbs
                };
                ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                PregledTemeljnice smartPart = this.Controller.WorkItem.Items.AddNew<PregledTemeljnice>();
                smartPart.GkstavkaDataSet1.Merge(set2);
                workspace.Show(smartPart, smartPartInfo);
                if (smartPart.ParentForm.DialogResult == DialogResult.OK)
                {
                    IEnumerator enumerator2 = null;
                    try
                    {
                        enumerator2 = set2.GKSTAVKA.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            DataRow current = (DataRow) enumerator2.Current;
                            current.BeginEdit();
                            current["datumdokumenta"] = RuntimeHelpers.GetObjectValue(smartPart.datumdok.Value);
                            current.EndEdit();
                        }
                    }
                    finally
                    {
                        if (enumerator2 is IDisposable)
                        {
                            (enumerator2 as IDisposable).Dispose();
                        }
                    }
                    adapter3.Update(set2);
                    Interaction.MsgBox("Knjiženje uspješno izvršeno. Kreiran je broj dokumenta: " + Conversions.ToString(num), MsgBoxStyle.Information, "MBS.Complete");
                }
            }
        }

        private void KratkaRekap_Load(object sender, EventArgs e)
        {
            DataRow row = null;
            DataRow current;
            IEnumerator enumerator = null;
            IEnumerator enumerator2 = null;
            IEnumerator enumerator3 = null;
            IEnumerator enumerator4 = null;
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            this.m_Sifra_Obracuna = ((KratkaRekapWorkItem) this.Controller.WorkItem).Obracun;
            this.m_opisobracuna = ((KratkaRekapWorkItem) this.Controller.WorkItem).opisobracuna;
            this.dbcomElementiObracuna.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter {
                SelectCommand = this.dbcomElementiObracuna
            };
            adapter.SelectCommand.Connection = connection;
            adapter.SelectCommand.Parameters["@IDOBRACUN"].Value = this.m_Sifra_Obracuna;
            try
            {
                adapter.Fill(this.dsKratkaRekap, "TOTALSATI");
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
            this.Text = "Rekapitulacija plaće za obračun :" + this.m_Sifra_Obracuna + " <ESC za izlaz> <F4 za ispis> ";
            this.daTotaliUstanove.SelectCommand.Connection = connection;
            this.daTotaliUstanove.SelectCommand.Parameters[0].Value = this.m_Sifra_Obracuna;
            this.DsTotaliUstanove1.EnforceConstraints = false;
            this.daTotaliUstanove.Fill(this.DsTotaliUstanove1, "S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA");
            this.MJESECOBRACUNA = Conversions.ToString(this.DsTotaliUstanove1.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.Rows[0]["MJESECOBRACUNA"]);
            this.GODINAOBRACUNA = Conversions.ToString(this.DsTotaliUstanove1.S_PLACA_ELEMENTI_OBRACUNA_REKAPITULACIJA.Rows[0]["GODINAOBRACUNA"]);
            s_od_rekap_doprinosDataAdapter adapter2 = new s_od_rekap_doprinosDataAdapter();
            s_od_rekap_doprinosDataSet dataSet = new s_od_rekap_doprinosDataSet();
            adapter2.Fill(dataSet, this.m_Sifra_Obracuna);
            DataRow row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Ukupni bruto";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["uKUPNOBRUTO"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            try
            {
                enumerator = this.dsKratkaRekap.totalsati.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    current = (DataRow) enumerator.Current;
                    if (Operators.ConditionalCompareObjectEqual(current["idvrstaelementa"], 2, false))
                    {
                        row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
                        row4["OPIS"] = Operators.ConcatenateObject("---- ", current["nazivelement"]);
                        row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(current["iznos"]));
                        row4["sati"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(current["sati"]));
                        this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
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
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Osnovica za obračun doprinosa";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnoosnovicazadoprinos"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Ukupno doprinosi iz plaće";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnodoprinosi"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            try
            {
                enumerator2 = dataSet.s_od_rekap_doprinos.Rows.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    row = (DataRow) enumerator2.Current;
                    if (Operators.ConditionalCompareObjectEqual(row["vrstasifra"], 2, false))
                    {
                        row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
                        row4["OPIS"] = Operators.ConcatenateObject("---- ", row["nazivdoprinos"]);
                        row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(row["iznos"]));
                        this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
                    }
                }
            }
            finally
            {
                if (enumerator2 is IDisposable)
                {
                    (enumerator2 as IDisposable).Dispose();
                }
            }
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Osobni odbitak";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnooo"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Olakšice";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnoolaksice"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Porezno priznate olakšice";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["UKUPNOPOREZNOPRIZNATEOLAKSICE"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Porezna osnovica";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["poreznaosnovica"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Porez";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnoporez"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Prirez";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnoprirez"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Porez i prirez";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnoporeziprirez"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Neto plaća";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["netoplaca"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Posebni porez na neto plaće";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnokrizni"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Neto plaća umanjena za posebni porez";
            row4["IZNOS"] = string.Format("{0:0.00}", Operators.SubtractObject(this.DsTotaliUstanove1.Tables[0].Rows[0]["netoplaca"], this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnokrizni"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Neto naknade";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["UKUPNONETONAKNADE"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            try
            {
                enumerator3 = this.dsKratkaRekap.totalsati.Rows.GetEnumerator();
                while (enumerator3.MoveNext())
                {
                    current = (DataRow) enumerator3.Current;
                    if (Operators.ConditionalCompareObjectEqual(current["idvrstaelementa"], 1, false))
                    {
                        row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
                        row4["OPIS"] = Operators.ConcatenateObject("---- ", current["nazivelement"]);
                        row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(current["iznos"]));
                        row4["sati"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(current["sati"]));
                        this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
                    }
                }
            }
            finally
            {
                if (enumerator3 is IDisposable)
                {
                    (enumerator3 as IDisposable).Dispose();
                }
            }
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Neto primanja";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["netoprimanja"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Obustave";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnoobustave"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Ukupno za isplatu";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnozaisplatu"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Ukupno doprinosi na plaću";
            row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnodoprinosina"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
            try
            {
                enumerator4 = dataSet.s_od_rekap_doprinos.Rows.GetEnumerator();
                while (enumerator4.MoveNext())
                {
                    row = (DataRow) enumerator4.Current;
                    if (Operators.ConditionalCompareObjectEqual(row["vrstasifra"], 1, false))
                    {
                        row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
                        row4["OPIS"] = Operators.ConcatenateObject("---- ", row["nazivdoprinos"]);
                        row4["IZNOS"] = string.Format("{0:0.00}", RuntimeHelpers.GetObjectValue(row["iznos"]));
                        this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
                    }
                }
            }
            finally
            {
                if (enumerator4 is IDisposable)
                {
                    (enumerator4 as IDisposable).Dispose();
                }
            }
            row4 = this.dsKratkaRekap.dsRekapitulacija.NewRow();
            row4["OPIS"] = "Trošak obračuna (bruto plaća+neto naknade + doprinosi na plaću";
            row4["IZNOS"] = string.Format("{0:0.00}", Operators.AddObject(Operators.AddObject(this.DsTotaliUstanove1.Tables[0].Rows[0]["uKUPNOBRUTO"], this.DsTotaliUstanove1.Tables[0].Rows[0]["ukupnodoprinosina"]), this.DsTotaliUstanove1.Tables[0].Rows[0]["UKUPNONETONAKNADE"]));
            this.dsKratkaRekap.dsRekapitulacija.Rows.Add(row4);
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid3_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        public object Zadnji_Broj_Dokumenta()
        {
            object objectValue = new object();
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.Text,
                CommandText = "SELECT MAX(CAST(BROJDOKUMENTA AS INTEGER)) FROM GKSTAVKA WHERE IDDOKUMENT = @IDDOKUMENT AND gkgodidgodine =@GODINA"
            };
            command.Parameters.AddWithValue("@IDDOKUMENT", 0x3e7);
            command.Parameters.AddWithValue("@GODINA", SqlDbType.VarChar).Value = mipsed.application.framework.Application.ActiveYear;
            command.Connection = connection;
            connection.Open();
            try
            {
                objectValue = RuntimeHelpers.GetObjectValue(command.ExecuteScalar());
                if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(objectValue)))
                {
                    objectValue = 0;
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
            connection.Close();
            return objectValue;
        }

        private AutoHideControl _KratkaRekapAutoHideControl;

        private UnpinnedTabArea _KratkaRekapUnpinnedTabAreaBottom;

        private UnpinnedTabArea _KratkaRekapUnpinnedTabAreaLeft;

        private UnpinnedTabArea _KratkaRekapUnpinnedTabAreaRight;

        private UnpinnedTabArea _KratkaRekapUnpinnedTabAreaTop;

        [CreateNew]
        public KratkaRekapController Controller { get; set; }

        private SqlDataAdapter daTotaliUstanove;

        private SqlCommand dbcomElementiObracuna;

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

        private datasetKratkaRekap dsKratkaRekap;

        private dsTotaliUstanove DsTotaliUstanove1;

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

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private SqlCommand SqlCommand2;

        private SqlConnection SqlConnection1;

        private UltraDockManager UltraDockManager1;

        private UltraGrid UltraGrid3;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

