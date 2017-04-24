namespace NetAdvantage.SmartParts
{
    using Deklarit.Controls;
    using Infragistics.Win;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using NetAdvantage.Controls;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class RADNIKUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components;
        private string m_Description;
        private bool m_FillAtStartup;
        private string m_Title;
        private RADNIKDataGrid userControlDataGridRADNIK;

        public RADNIKUserDataGrid()
        {
            base.Load += new EventHandler(this.RADNIKUserDataGrid_Load1);
            this.components = null;
            this.m_FillAtStartup = true;
            this.m_Description = "Work with Zaposlenici";
            this.m_Title = "Work with Zaposlenici";
            this.InitializeComponent();
        }

        private static void CreateValueList(UltraGrid dataGrid1, string valueListName, System.Data.DataView dataList, string Id, string Name)
        {
            ValueList list = null;
            if (dataGrid1.DisplayLayout.ValueLists.Exists(valueListName) && (dataGrid1.DisplayLayout.ValueLists[valueListName].ValueListItems.Count != dataList.Count))
            {
                dataGrid1.DisplayLayout.ValueLists.Remove(valueListName);
                list = dataGrid1.DisplayLayout.ValueLists.Add(valueListName);
            }
            if (!dataGrid1.DisplayLayout.ValueLists.Exists(valueListName))
            {
                list = dataGrid1.DisplayLayout.ValueLists.Add(valueListName);
            }
            if (list != null)
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = dataList.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRowView current = (DataRowView) enumerator.Current;
                        DataRow row = current.Row;
                        ValueListItem item = new ValueListItem {
                            DataValue = RuntimeHelpers.GetObjectValue(row[Id]),
                            DisplayText = row[Name].ToString()
                        };
                        list.ValueListItems.Add(item);
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                list.Tag = dataList;
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

        public void Fill()
        {
            this.SetComboBoxColumnProperties(false);
            this.DataGrid.Fill();
        }

        private void InitializeComponent()
        {
            this.userControlDataGridRADNIK = new RADNIKDataGrid();
            ((ISupportInitialize) this.userControlDataGridRADNIK).BeginInit();
            UltraGridBand band = new UltraGridBand("RADNIK", -1);
            UltraGridColumn column26 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column165 = new UltraGridColumn("SPOJENOPREZIME");
            UltraGridColumn column = new UltraGridColumn("AKTIVAN");
            UltraGridColumn column155 = new UltraGridColumn("PREZIME");
            UltraGridColumn column33 = new UltraGridColumn("IME");
            UltraGridColumn column119 = new UltraGridColumn("OIB");
            UltraGridColumn column44 = new UltraGridColumn("JMBG");
            UltraGridColumn column16 = new UltraGridColumn("DATUMRODJENJA");
            UltraGridColumn column176 = new UltraGridColumn("ulica");
            UltraGridColumn column78 = new UltraGridColumn("mjesto");
            UltraGridColumn column70 = new UltraGridColumn("kucnibroj");
            UltraGridColumn column141 = new UltraGridColumn("OPCINARADAIDOPCINE");
            UltraGridColumn column142 = new UltraGridColumn("OPCINARADANAZIVOPCINE");
            UltraGridColumn column143 = new UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            UltraGridColumn column144 = new UltraGridColumn("OPCINASTANOVANJANAZIVOPCINE");
            UltraGridColumn column145 = new UltraGridColumn("OPCINASTANOVANJAPRIREZ");
            UltraGridColumn column146 = new UltraGridColumn("OPCINASTANOVANJAVBDIOPCINA");
            UltraGridColumn column147 = new UltraGridColumn("OPCINASTANOVANJAZRNOPCINA");
            UltraGridColumn column160 = new UltraGridColumn("RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA");
            UltraGridColumn column161 = new UltraGridColumn("RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA");
            UltraGridColumn column20 = new UltraGridColumn("IDBANKE");
            UltraGridColumn column80 = new UltraGridColumn("NAZIVBANKE1");
            UltraGridColumn column81 = new UltraGridColumn("NAZIVBANKE2");
            UltraGridColumn column82 = new UltraGridColumn("NAZIVBANKE3");
            UltraGridColumn column178 = new UltraGridColumn("VBDIBANKE");
            UltraGridColumn column186 = new UltraGridColumn("ZRNBANKE");
            UltraGridColumn column166 = new UltraGridColumn("TEKUCI");
            UltraGridColumn column185 = new UltraGridColumn("ZBIRNINETO");
            UltraGridColumn column164 = new UltraGridColumn("SIFRAOPISAPLACANJANETO");
            UltraGridColumn column148 = new UltraGridColumn("OPISPLACANJANETO");
            UltraGridColumn column167 = new UltraGridColumn("TJEDNIFONDSATI");
            UltraGridColumn column45 = new UltraGridColumn("KOEFICIJENT");
            UltraGridColumn column152 = new UltraGridColumn("POSTOTAKOSLOBODJENJAODPOREZA");
            UltraGridColumn column177 = new UltraGridColumn("UZIMAUOBZIROSNOVICEDOPRINOSA");
            UltraGridColumn column168 = new UltraGridColumn("TJEDNIFONDSATISTAZ");
            UltraGridColumn column17 = new UltraGridColumn("DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI");
            UltraGridColumn column18 = new UltraGridColumn("GODINESTAZA");
            UltraGridColumn column76 = new UltraGridColumn("MJESECISTAZA");
            UltraGridColumn column13 = new UltraGridColumn("DANISTAZA");
            UltraGridColumn column21 = new UltraGridColumn("IDBENEFICIRANI");
            UltraGridColumn column83 = new UltraGridColumn("NAZIVBENEFICIRANI");
            UltraGridColumn column15 = new UltraGridColumn("DATUMPRESTANKARADNOGODNOSA");
            UltraGridColumn column2 = new UltraGridColumn("BROJMIROVINSKOG");
            UltraGridColumn column4 = new UltraGridColumn("BROJZDRAVSTVENOG");
            UltraGridColumn column75 = new UltraGridColumn("MBO");
            UltraGridColumn column31 = new UltraGridColumn("IDTITULA");
            UltraGridColumn column91 = new UltraGridColumn("NAZIVTITULA");
            UltraGridColumn column27 = new UltraGridColumn("IDRADNOMJESTO");
            UltraGridColumn column88 = new UltraGridColumn("NAZIVRADNOMJESTO");
            UltraGridColumn column169 = new UltraGridColumn("TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA");
            UltraGridColumn column170 = new UltraGridColumn("TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA");
            UltraGridColumn column153 = new UltraGridColumn("POTREBNASTRUCNASPREMAIDSTRUCNASPREMA");
            UltraGridColumn column154 = new UltraGridColumn("POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA");
            UltraGridColumn column30 = new UltraGridColumn("IDSTRUKA");
            UltraGridColumn column90 = new UltraGridColumn("NAZIVSTRUKA");
            UltraGridColumn column22 = new UltraGridColumn("IDBRACNOSTANJE");
            UltraGridColumn column84 = new UltraGridColumn("NAZIVBRACNOSTANJE");
            UltraGridColumn column25 = new UltraGridColumn("IDORGDIO");
            UltraGridColumn column149 = new UltraGridColumn("ORGANIZACIJSKIDIO");
            UltraGridColumn column174 = new UltraGridColumn("UKUPNOGODINESTAZA");
            UltraGridColumn column175 = new UltraGridColumn("UKUPNOMJESECISTAZA");
            UltraGridColumn column173 = new UltraGridColumn("UKUPNODANASTAZA");
            UltraGridColumn column3 = new UltraGridColumn("BROJPRIZNATIHMJESECI");
            UltraGridColumn column79 = new UltraGridColumn("MO");
            UltraGridColumn column150 = new UltraGridColumn("PBO");
            UltraGridColumn column19 = new UltraGridColumn("GODINESTAZAPRO");
            UltraGridColumn column77 = new UltraGridColumn("MJESECISTAZAPRO");
            UltraGridColumn column14 = new UltraGridColumn("DANISTAZAPRO");
            UltraGridColumn column172 = new UltraGridColumn("UKUPNIFAKTOR");
            UltraGridColumn column23 = new UltraGridColumn("IDDRZAVLJANSTVO");
            UltraGridColumn column85 = new UltraGridColumn("NAZIVDRZAVLJANSTVO");
            UltraGridColumn column157 = new UltraGridColumn("RADNADOZVOLA");
            UltraGridColumn column184 = new UltraGridColumn("ZAVRSENASKOLA");
            UltraGridColumn column171 = new UltraGridColumn("UGOVOROD");
            UltraGridColumn column151 = new UltraGridColumn("POCETAKRADA");
            UltraGridColumn column87 = new UltraGridColumn("NAZIVPOSLA");
            UltraGridColumn column32 = new UltraGridColumn("IDUGOVORORADU");
            UltraGridColumn column92 = new UltraGridColumn("NAZIVUGOVORORADU");
            UltraGridColumn column181 = new UltraGridColumn("VRIJEMEPROBNOGRADA");
            UltraGridColumn column180 = new UltraGridColumn("VRIJEMEPRIPRAVNICKOG");
            UltraGridColumn column182 = new UltraGridColumn("VRIJEMESTRUCNI");
            UltraGridColumn column162 = new UltraGridColumn("RADUINOZEMSTVU");
            UltraGridColumn column158 = new UltraGridColumn("RADNASPOSOBNOST");
            UltraGridColumn column179 = new UltraGridColumn("VRIJEMEMIROVANJARADNOGODNOSA");
            UltraGridColumn column163 = new UltraGridColumn("RAZLOGPRESTANKA");
            UltraGridColumn column183 = new UltraGridColumn("ZABRANANATJECANJA");
            UltraGridColumn column156 = new UltraGridColumn("PRODUZENOMIROVINSKO");
            UltraGridColumn column159 = new UltraGridColumn("RADNIKNAPOMENA");
            UltraGridColumn column28 = new UltraGridColumn("IDRADNOVRIJEME");
            UltraGridColumn column29 = new UltraGridColumn("IDSPOL");
            UltraGridColumn column89 = new UltraGridColumn("NAZIVSPOL");
            UltraGridColumn column24 = new UltraGridColumn("IDIPIDENT");
            UltraGridColumn column86 = new UltraGridColumn("NAZIVIPIDENT");
            UltraGridBand band8 = new UltraGridBand("RADNIK_RADNIKOdbitak", 0);
            UltraGridColumn column116 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column118 = new UltraGridColumn("OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK");
            UltraGridColumn column117 = new UltraGridColumn("NAZIVOSOBNIODBITAK");
            UltraGridColumn column115 = new UltraGridColumn("FAKTOROSOBNOGODBITKA");
            UltraGridBand band9 = new UltraGridBand("RADNIK_RADNIKOlaksica", 0);
            UltraGridColumn column120 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column125 = new UltraGridColumn("ZADOLAKSICEIDOLAKSICE");
            UltraGridColumn column124 = new UltraGridColumn("ZADOLAKSICEIDGRUPEOLAKSICA");
            UltraGridColumn column127 = new UltraGridColumn("ZADOLAKSICEMAXIMALNIIZNOSGRUPE");
            UltraGridColumn column128 = new UltraGridColumn("ZADOLAKSICENAZIVGRUPEOLAKSICA");
            UltraGridColumn column129 = new UltraGridColumn("ZADOLAKSICENAZIVOLAKSICE");
            UltraGridColumn column126 = new UltraGridColumn("ZADOLAKSICEIDTIPOLAKSICE");
            UltraGridColumn column130 = new UltraGridColumn("ZADOLAKSICENAZIVTIPOLAKSICE");
            UltraGridColumn column134 = new UltraGridColumn("ZADOLAKSICEVBDIOLAKSICA");
            UltraGridColumn column135 = new UltraGridColumn("ZADOLAKSICEZRNOLAKSICA");
            UltraGridColumn column131 = new UltraGridColumn("ZADOLAKSICEPRIMATELJOLAKSICA1");
            UltraGridColumn column132 = new UltraGridColumn("ZADOLAKSICEPRIMATELJOLAKSICA2");
            UltraGridColumn column133 = new UltraGridColumn("ZADOLAKSICEPRIMATELJOLAKSICA3");
            UltraGridColumn column123 = new UltraGridColumn("ZADMZOLAKSICE");
            UltraGridColumn column139 = new UltraGridColumn("ZADPZOLAKSICE");
            UltraGridColumn column122 = new UltraGridColumn("ZADMOOLAKSICE");
            UltraGridColumn column138 = new UltraGridColumn("ZADPOOLAKSICE");
            UltraGridColumn column140 = new UltraGridColumn("ZADSIFRAOPISAPLACANJAOLAKSICE");
            UltraGridColumn column136 = new UltraGridColumn("ZADOPISPLACANJAOLAKSICE");
            UltraGridColumn column121 = new UltraGridColumn("ZADIZNOSOLAKSICE");
            UltraGridColumn column137 = new UltraGridColumn("ZADPOJEDINACNIPOZIV");
            UltraGridBand band4 = new UltraGridBand("RADNIK_RADNIKKrediti", 0);
            UltraGridColumn column47 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column60 = new UltraGridColumn("ZADKREDITIIDKREDITOR");
            UltraGridColumn column46 = new UltraGridColumn("DATUMUGOVORA");
            UltraGridColumn column48 = new UltraGridColumn("KREDITAKTIVAN");
            UltraGridColumn column61 = new UltraGridColumn("ZADKREDITINAZIVKREDITOR");
            UltraGridColumn column62 = new UltraGridColumn("ZADKREDITIPRIMATELJKREDITOR1");
            UltraGridColumn column63 = new UltraGridColumn("ZADKREDITIPRIMATELJKREDITOR2");
            UltraGridColumn column64 = new UltraGridColumn("ZADKREDITIPRIMATELJKREDITOR3");
            UltraGridColumn column57 = new UltraGridColumn("SIFRAOPISAPLACANJAKREDITOR");
            UltraGridColumn column53 = new UltraGridColumn("OPISPLACANJAKREDITOR");
            UltraGridColumn column51 = new UltraGridColumn("MOKREDITOR");
            UltraGridColumn column55 = new UltraGridColumn("POKREDITOR");
            UltraGridColumn column52 = new UltraGridColumn("MZKREDITOR");
            UltraGridColumn column56 = new UltraGridColumn("PZKREDITOR");
            UltraGridColumn column59 = new UltraGridColumn("ZADIZNOSRATEKREDITA");
            UltraGridColumn column58 = new UltraGridColumn("ZADBROJRATAOBUSTAVE");
            UltraGridColumn column67 = new UltraGridColumn("ZADUKUPNIZNOSKREDITA");
            UltraGridColumn column68 = new UltraGridColumn("ZADVECOTPLACENOBROJRATA");
            UltraGridColumn column69 = new UltraGridColumn("ZADVECOTPLACENOUKUPNIIZNOS");
            UltraGridColumn column49 = new UltraGridColumn("KREDITOTPLACENIIZNOS");
            UltraGridColumn column50 = new UltraGridColumn("KREDITOTPLACENORATA");
            UltraGridColumn column65 = new UltraGridColumn("ZADKREDITIVBDIKREDITOR");
            UltraGridColumn column66 = new UltraGridColumn("ZADKREDITIZRNKREDITOR");
            UltraGridColumn column54 = new UltraGridColumn("PARTIJAKREDITASPECIFIKACIJA");
            UltraGridBand band2 = new UltraGridBand("RADNIK_RADNIKBruto", 0);
            UltraGridColumn column12 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column5 = new UltraGridColumn("BRUTOELEMENTIDELEMENT");
            UltraGridColumn column6 = new UltraGridColumn("BRUTOELEMENTNAZIVELEMENT");
            UltraGridColumn column11 = new UltraGridColumn("BRUTOSATNICA");
            UltraGridColumn column10 = new UltraGridColumn("BRUTOSATI");
            UltraGridColumn column9 = new UltraGridColumn("BRUTOPOSTOTAK");
            UltraGridColumn column8 = new UltraGridColumn("BRUTOIZNOS");
            UltraGridColumn column7 = new UltraGridColumn("BRUTOELEMENTPOSTOTAK");
            UltraGridBand band6 = new UltraGridBand("RADNIK_RADNIKNeto", 0);
            UltraGridColumn column93 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column94 = new UltraGridColumn("NETOELEMENTIDELEMENT");
            UltraGridColumn column95 = new UltraGridColumn("NETOELEMENTNAZIVELEMENT");
            UltraGridColumn column99 = new UltraGridColumn("NETOSATNICA");
            UltraGridColumn column98 = new UltraGridColumn("NETOSATI");
            UltraGridColumn column97 = new UltraGridColumn("NETOPOSTOTAK");
            UltraGridColumn column96 = new UltraGridColumn("NETOIZNOS");
            UltraGridBand band7 = new UltraGridBand("RADNIK_RADNIKObustava", 0);
            UltraGridColumn column100 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column106 = new UltraGridColumn("ZADOBUSTAVAIDOBUSTAVA");
            UltraGridColumn column101 = new UltraGridColumn("OBUSTAVAAKTIVNA");
            UltraGridColumn column107 = new UltraGridColumn("ZADOBUSTAVANAZIVOBUSTAVA");
            UltraGridColumn column110 = new UltraGridColumn("ZADOBUSTAVAVRSTAOBUSTAVE");
            UltraGridColumn column108 = new UltraGridColumn("ZADOBUSTAVANAZIVVRSTAOBUSTAVE");
            UltraGridColumn column105 = new UltraGridColumn("ZADIZNOSOBUSTAVE");
            UltraGridColumn column112 = new UltraGridColumn("ZADPOSTOTAKOBUSTAVE");
            UltraGridColumn column113 = new UltraGridColumn("ZADPOSTOTNAODBRUTA");
            UltraGridColumn column104 = new UltraGridColumn("ZADISPLACENOKASA");
            UltraGridColumn column114 = new UltraGridColumn("ZADSALDOKASA");
            UltraGridColumn column103 = new UltraGridColumn("OTPLACENIIZNOS");
            UltraGridColumn column102 = new UltraGridColumn("OTPLACENIBROJRATA");
            UltraGridColumn column111 = new UltraGridColumn("ZADOBUSTAVAZRNOBUSTAVA");
            UltraGridColumn column109 = new UltraGridColumn("ZADOBUSTAVAVBDIOBUSTAVA");
            UltraGridBand band5 = new UltraGridBand("RADNIK_RADNIKLevel7", 0);
            UltraGridColumn column73 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column72 = new UltraGridColumn("IDGRUPEKOEF");
            UltraGridColumn column74 = new UltraGridColumn("NAZIVGRUPEKOEF");
            UltraGridColumn column71 = new UltraGridColumn("DODATNIKOEFICIJENT");
            UltraGridBand band3 = new UltraGridBand("RADNIK_RADNIKIzuzeceOdOvrhe", 0);
            UltraGridColumn column35 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column34 = new UltraGridColumn("BANKAZASTICENOIDBANKE");
            UltraGridColumn column42 = new UltraGridColumn("ZADSIFRAOPISAPLACANJAIZUZECE");
            UltraGridColumn column39 = new UltraGridColumn("ZADOPISPLACANJAIZUZECE");
            UltraGridColumn column43 = new UltraGridColumn("ZADTEKUCIIZUZECE");
            UltraGridColumn column37 = new UltraGridColumn("ZADMOIZUZECE");
            UltraGridColumn column40 = new UltraGridColumn("ZADPOIZUZECE");
            UltraGridColumn column38 = new UltraGridColumn("ZADMZIZUZECE");
            UltraGridColumn column41 = new UltraGridColumn("ZADPZIZUZECE");
            UltraGridColumn column36 = new UltraGridColumn("ZADIZNOSIZUZECA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.NoEdit;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column26.Width = 0x69;
            appearance26.TextHAlign = HAlign.Right;
            column26.MaskInput = "{LOC}-nnnnnnnn";
            column26.PromptChar = ' ';
            column26.Format = "";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance165 = new Infragistics.Win.Appearance();
            column165.CellActivation = Activation.NoEdit;
            column165.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column165.Header.Caption = StringResources.RADNIKSPOJENOPREZIMEDescription;
            column165.Width = 0x128;
            column165.Format = "";
            column165.CellAppearance = appearance165;
            column165.Hidden = true;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.RADNIKAKTIVANDescription;
            column.Width = 0x41;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance155 = new Infragistics.Win.Appearance();
            column155.CellActivation = Activation.NoEdit;
            column155.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column155.Header.Caption = StringResources.RADNIKPREZIMEDescription;
            column155.Width = 0x128;
            column155.Format = "";
            column155.CellAppearance = appearance155;
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            column33.CellActivation = Activation.NoEdit;
            column33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column33.Header.Caption = StringResources.RADNIKIMEDescription;
            column33.Width = 0x128;
            column33.Format = "";
            column33.CellAppearance = appearance33;
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            column119.CellActivation = Activation.NoEdit;
            column119.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column119.Header.Caption = StringResources.RADNIKOIBDescription;
            column119.Width = 0xd4;
            column119.Format = "";
            column119.CellAppearance = appearance119;
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            column44.CellActivation = Activation.NoEdit;
            column44.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column44.Header.Caption = StringResources.RADNIKJMBGDescription;
            column44.Width = 0x6b;
            column44.Format = "";
            column44.CellAppearance = appearance44;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.RADNIKDATUMRODJENJADescription;
            column16.Width = 0x6b;
            column16.MinValue = DateTime.MinValue;
            column16.MaxValue = DateTime.MaxValue;
            column16.Format = "d";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance176 = new Infragistics.Win.Appearance();
            column176.CellActivation = Activation.NoEdit;
            column176.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column176.Header.Caption = StringResources.RADNIKulicaDescription;
            column176.Width = 0x128;
            column176.Format = "";
            column176.CellAppearance = appearance176;
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            column78.CellActivation = Activation.NoEdit;
            column78.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column78.Header.Caption = StringResources.RADNIKmjestoDescription;
            column78.Width = 0x128;
            column78.Format = "";
            column78.CellAppearance = appearance78;
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            column70.CellActivation = Activation.NoEdit;
            column70.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column70.Header.Caption = StringResources.RADNIKkucnibrojDescription;
            column70.Width = 0x56;
            column70.Format = "";
            column70.CellAppearance = appearance70;
            Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
            column141.CellActivation = Activation.NoEdit;
            column141.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column141.Header.Caption = StringResources.RADNIKOPCINARADAIDOPCINEDescription;
            column141.Width = 0x87;
            column141.Format = "";
            column141.CellAppearance = appearance141;
            Infragistics.Win.Appearance appearance142 = new Infragistics.Win.Appearance();
            column142.CellActivation = Activation.NoEdit;
            column142.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column142.Header.Caption = StringResources.RADNIKOPCINARADANAZIVOPCINEDescription;
            column142.Width = 0x128;
            column142.Format = "";
            column142.CellAppearance = appearance142;
            Infragistics.Win.Appearance appearance143 = new Infragistics.Win.Appearance();
            column143.CellActivation = Activation.NoEdit;
            column143.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column143.Header.Caption = StringResources.RADNIKOPCINASTANOVANJAIDOPCINEDescription;
            column143.Width = 0xb1;
            column143.Format = "";
            column143.CellAppearance = appearance143;
            Infragistics.Win.Appearance appearance144 = new Infragistics.Win.Appearance();
            column144.CellActivation = Activation.NoEdit;
            column144.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column144.Header.Caption = StringResources.RADNIKOPCINASTANOVANJANAZIVOPCINEDescription;
            column144.Width = 0x128;
            column144.Format = "";
            column144.CellAppearance = appearance144;
            Infragistics.Win.Appearance appearance145 = new Infragistics.Win.Appearance();
            column145.CellActivation = Activation.NoEdit;
            column145.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column145.Header.Caption = StringResources.RADNIKOPCINASTANOVANJAPRIREZDescription;
            column145.Width = 0xb7;
            appearance145.TextHAlign = HAlign.Right;
            column145.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column145.PromptChar = ' ';
            column145.Format = "F2";
            column145.CellAppearance = appearance145;
            Infragistics.Win.Appearance appearance146 = new Infragistics.Win.Appearance();
            column146.CellActivation = Activation.NoEdit;
            column146.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column146.Header.Caption = StringResources.RADNIKOPCINASTANOVANJAVBDIOPCINADescription;
            column146.Width = 0xfe;
            column146.Format = "";
            column146.CellAppearance = appearance146;
            Infragistics.Win.Appearance appearance147 = new Infragistics.Win.Appearance();
            column147.CellActivation = Activation.NoEdit;
            column147.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column147.Header.Caption = StringResources.RADNIKOPCINASTANOVANJAZRNOPCINADescription;
            column147.Width = 0xfe;
            column147.Format = "";
            column147.CellAppearance = appearance147;
            Infragistics.Win.Appearance appearance160 = new Infragistics.Win.Appearance();
            column160.CellActivation = Activation.NoEdit;
            column160.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column160.Header.Caption = StringResources.RADNIKRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSADescription;
            column160.Width = 0xea;
            column160.Format = "";
            column160.CellAppearance = appearance160;
            Infragistics.Win.Appearance appearance161 = new Infragistics.Win.Appearance();
            column161.CellActivation = Activation.NoEdit;
            column161.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column161.Header.Caption = StringResources.RADNIKRADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSADescription;
            column161.Width = 0x128;
            column161.Format = "";
            column161.CellAppearance = appearance161;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.RADNIKIDBANKEDescription;
            column20.Width = 0x5c;
            appearance20.TextHAlign = HAlign.Right;
            column20.MaskInput = "{LOC}-nnnnn";
            column20.PromptChar = ' ';
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            column80.CellActivation = Activation.NoEdit;
            column80.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column80.Header.Caption = StringResources.RADNIKNAZIVBANKE1Description;
            column80.Width = 0x9c;
            column80.Format = "";
            column80.CellAppearance = appearance80;
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            column81.CellActivation = Activation.NoEdit;
            column81.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column81.Header.Caption = StringResources.RADNIKNAZIVBANKE2Description;
            column81.Width = 0x9c;
            column81.Format = "";
            column81.CellAppearance = appearance81;
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            column82.CellActivation = Activation.NoEdit;
            column82.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column82.Header.Caption = StringResources.RADNIKNAZIVBANKE3Description;
            column82.Width = 0x9c;
            column82.Format = "";
            column82.CellAppearance = appearance82;
            Infragistics.Win.Appearance appearance178 = new Infragistics.Win.Appearance();
            column178.CellActivation = Activation.NoEdit;
            column178.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column178.Header.Caption = StringResources.RADNIKVBDIBANKEDescription;
            column178.Width = 170;
            column178.Format = "";
            column178.CellAppearance = appearance178;
            Infragistics.Win.Appearance appearance186 = new Infragistics.Win.Appearance();
            column186.CellActivation = Activation.NoEdit;
            column186.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column186.Header.Caption = StringResources.RADNIKZRNBANKEDescription;
            column186.Width = 170;
            column186.Format = "";
            column186.CellAppearance = appearance186;
            Infragistics.Win.Appearance appearance166 = new Infragistics.Win.Appearance();
            column166.CellActivation = Activation.NoEdit;
            column166.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column166.Header.Caption = StringResources.RADNIKTEKUCIDescription;
            column166.Width = 100;
            column166.Format = "";
            column166.CellAppearance = appearance166;
            Infragistics.Win.Appearance appearance185 = new Infragistics.Win.Appearance();
            column185.CellActivation = Activation.NoEdit;
            column185.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column185.Header.Caption = StringResources.RADNIKZBIRNINETODescription;
            column185.Width = 170;
            column185.Format = "";
            column185.CellAppearance = appearance185;
            Infragistics.Win.Appearance appearance164 = new Infragistics.Win.Appearance();
            column164.CellActivation = Activation.NoEdit;
            column164.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column164.Header.Caption = StringResources.RADNIKSIFRAOPISAPLACANJANETODescription;
            column164.Width = 0x121;
            column164.Format = "";
            column164.CellAppearance = appearance164;
            Infragistics.Win.Appearance appearance148 = new Infragistics.Win.Appearance();
            column148.CellActivation = Activation.NoEdit;
            column148.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column148.Header.Caption = StringResources.RADNIKOPISPLACANJANETODescription;
            column148.Width = 0x10c;
            column148.Format = "";
            column148.CellAppearance = appearance148;
            Infragistics.Win.Appearance appearance167 = new Infragistics.Win.Appearance();
            column167.CellActivation = Activation.NoEdit;
            column167.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column167.Header.Caption = StringResources.RADNIKTJEDNIFONDSATIDescription;
            column167.Width = 0xd9;
            appearance167.TextHAlign = HAlign.Right;
            column167.MaskInput = "{LOC}-nnn.nn";
            column167.PromptChar = ' ';
            column167.Format = "F2";
            column167.CellAppearance = appearance167;
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            column45.CellActivation = Activation.NoEdit;
            column45.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column45.Header.Caption = StringResources.RADNIKKOEFICIJENTDescription;
            column45.Width = 0x88;
            appearance45.TextHAlign = HAlign.Right;
            column45.MaskInput = "{LOC}-nnnnnnn.nnnnnnnnnn";
            column45.PromptChar = ' ';
            column45.Format = "F10";
            column45.CellAppearance = appearance45;
            Infragistics.Win.Appearance appearance152 = new Infragistics.Win.Appearance();
            column152.CellActivation = Activation.NoEdit;
            column152.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column152.Header.Caption = StringResources.RADNIKPOSTOTAKOSLOBODJENJAODPOREZADescription;
            column152.Width = 0x123;
            appearance152.TextHAlign = HAlign.Right;
            column152.MaskInput = "{LOC}-nnn.nn";
            column152.PromptChar = ' ';
            column152.Format = "F2";
            column152.CellAppearance = appearance152;
            Infragistics.Win.Appearance appearance177 = new Infragistics.Win.Appearance();
            column177.CellActivation = Activation.NoEdit;
            column177.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column177.Header.Caption = StringResources.RADNIKUZIMAUOBZIROSNOVICEDOPRINOSADescription;
            column177.Width = 0x128;
            column177.Format = "";
            column177.CellAppearance = appearance177;
            Infragistics.Win.Appearance appearance168 = new Infragistics.Win.Appearance();
            column168.CellActivation = Activation.NoEdit;
            column168.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column168.Header.Caption = StringResources.RADNIKTJEDNIFONDSATISTAZDescription;
            column168.Width = 0x102;
            appearance168.TextHAlign = HAlign.Right;
            column168.MaskInput = "{LOC}-nnn.nn";
            column168.PromptChar = ' ';
            column168.Format = "F2";
            column168.CellAppearance = appearance168;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.RADNIKDATUMZADNJEGZAPOSLENJAPROMJENEFONDASATIDescription;
            column17.Width = 0x128;
            column17.MinValue = DateTime.MinValue;
            column17.MaxValue = DateTime.MaxValue;
            column17.Format = "d";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.RADNIKGODINESTAZADescription;
            column18.Width = 180;
            appearance18.TextHAlign = HAlign.Right;
            column18.MaskInput = "{LOC}-nn";
            column18.PromptChar = ' ';
            column18.Format = "";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            column76.CellActivation = Activation.NoEdit;
            column76.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column76.Header.Caption = StringResources.RADNIKMJESECISTAZADescription;
            column76.Width = 0xba;
            appearance76.TextHAlign = HAlign.Right;
            column76.MaskInput = "{LOC}-nn";
            column76.PromptChar = ' ';
            column76.Format = "";
            column76.CellAppearance = appearance76;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.RADNIKDANISTAZADescription;
            column13.Width = 0xa6;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnn";
            column13.PromptChar = ' ';
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.RADNIKIDBENEFICIRANIDescription;
            column21.Width = 240;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            column83.CellActivation = Activation.NoEdit;
            column83.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column83.Header.Caption = StringResources.RADNIKNAZIVBENEFICIRANIDescription;
            column83.Width = 0x128;
            column83.Format = "";
            column83.CellAppearance = appearance83;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.RADNIKDATUMPRESTANKARADNOGODNOSADescription;
            column15.Width = 0xdb;
            column15.MinValue = DateTime.MinValue;
            column15.MaxValue = DateTime.MaxValue;
            column15.Format = "d";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.RADNIKBROJMIROVINSKOGDescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.RADNIKBROJZDRAVSTVENOGDescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            column75.CellActivation = Activation.NoEdit;
            column75.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column75.Header.Caption = StringResources.RADNIKMBODescription;
            column75.Width = 0x128;
            column75.Format = "";
            column75.CellAppearance = appearance75;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column31.CellActivation = Activation.NoEdit;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.RADNIKIDTITULADescription;
            column31.Width = 0x63;
            column31.Format = "";
            column31.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            column91.CellActivation = Activation.NoEdit;
            column91.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column91.Header.Caption = StringResources.RADNIKNAZIVTITULADescription;
            column91.Width = 0x128;
            column91.Format = "";
            column91.CellAppearance = appearance91;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column27.CellActivation = Activation.NoEdit;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.RADNIKIDRADNOMJESTODescription;
            column27.Width = 0x92;
            column27.Format = "";
            column27.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            column88.CellActivation = Activation.NoEdit;
            column88.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column88.Header.Caption = StringResources.RADNIKNAZIVRADNOMJESTODescription;
            column88.Width = 0x128;
            column88.Format = "";
            column88.CellAppearance = appearance88;
            Infragistics.Win.Appearance appearance169 = new Infragistics.Win.Appearance();
            column169.CellActivation = Activation.NoEdit;
            column169.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column169.Header.Caption = StringResources.RADNIKTRENUTNASTRUCNASPREMAIDSTRUCNASPREMADescription;
            column169.Width = 0x99;
            column169.Format = "";
            column169.CellAppearance = appearance169;
            column169.Hidden = true;
            Infragistics.Win.Appearance appearance170 = new Infragistics.Win.Appearance();
            column170.CellActivation = Activation.NoEdit;
            column170.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column170.Header.Caption = StringResources.RADNIKTRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMADescription;
            column170.Width = 0x128;
            column170.Format = "";
            column170.CellAppearance = appearance170;
            column170.Hidden = true;
            Infragistics.Win.Appearance appearance153 = new Infragistics.Win.Appearance();
            column153.CellActivation = Activation.NoEdit;
            column153.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column153.Header.Caption = StringResources.RADNIKPOTREBNASTRUCNASPREMAIDSTRUCNASPREMADescription;
            column153.Width = 0xd5;
            column153.Format = "";
            column153.CellAppearance = appearance153;
            Infragistics.Win.Appearance appearance154 = new Infragistics.Win.Appearance();
            column154.CellActivation = Activation.NoEdit;
            column154.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column154.Header.Caption = StringResources.RADNIKPOTREBNASTRUCNASPREMANAZIVSTRUCNASPREMADescription;
            column154.Width = 0x128;
            column154.Format = "";
            column154.CellAppearance = appearance154;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column30.CellActivation = Activation.NoEdit;
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.RADNIKIDSTRUKADescription;
            column30.Width = 0x63;
            column30.Format = "";
            column30.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            column90.CellActivation = Activation.NoEdit;
            column90.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column90.Header.Caption = StringResources.RADNIKNAZIVSTRUKADescription;
            column90.Width = 0x128;
            column90.Format = "";
            column90.CellAppearance = appearance90;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.RADNIKIDBRACNOSTANJEDescription;
            column22.Width = 0x99;
            column22.Format = "";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            column84.CellActivation = Activation.NoEdit;
            column84.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column84.Header.Caption = StringResources.RADNIKNAZIVBRACNOSTANJEDescription;
            column84.Width = 0x128;
            column84.Format = "";
            column84.CellAppearance = appearance84;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.RADNIKIDORGDIODescription;
            column25.Width = 0xd5;
            column25.Format = "";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance149 = new Infragistics.Win.Appearance();
            column149.CellActivation = Activation.NoEdit;
            column149.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column149.Header.Caption = StringResources.RADNIKORGANIZACIJSKIDIODescription;
            column149.Width = 0x128;
            column149.Format = "";
            column149.CellAppearance = appearance149;
            Infragistics.Win.Appearance appearance174 = new Infragistics.Win.Appearance();
            column174.CellActivation = Activation.NoEdit;
            column174.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column174.Header.Caption = StringResources.RADNIKUKUPNOGODINESTAZADescription;
            column174.Width = 0x92;
            appearance174.TextHAlign = HAlign.Right;
            column174.MaskInput = "{LOC}-nn";
            column174.PromptChar = ' ';
            column174.Format = "";
            column174.CellAppearance = appearance174;
            column174.Hidden = true;
            Infragistics.Win.Appearance appearance175 = new Infragistics.Win.Appearance();
            column175.CellActivation = Activation.NoEdit;
            column175.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column175.Header.Caption = StringResources.RADNIKUKUPNOMJESECISTAZADescription;
            column175.Width = 0x99;
            appearance175.TextHAlign = HAlign.Right;
            column175.MaskInput = "{LOC}-nn";
            column175.PromptChar = ' ';
            column175.Format = "";
            column175.CellAppearance = appearance175;
            column175.Hidden = true;
            Infragistics.Win.Appearance appearance173 = new Infragistics.Win.Appearance();
            column173.CellActivation = Activation.NoEdit;
            column173.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column173.Header.Caption = StringResources.RADNIKUKUPNODANASTAZADescription;
            column173.Width = 0x84;
            appearance173.TextHAlign = HAlign.Right;
            column173.MaskInput = "{LOC}-nnn";
            column173.PromptChar = ' ';
            column173.Format = "";
            column173.CellAppearance = appearance173;
            column173.Hidden = true;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.RADNIKBROJPRIZNATIHMJESECIDescription;
            column3.Width = 0x120;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            column3.Hidden = true;
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            column79.CellActivation = Activation.NoEdit;
            column79.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column79.Header.Caption = StringResources.RADNIKMODescription;
            column79.Width = 0x128;
            column79.Format = "";
            column79.CellAppearance = appearance79;
            column79.Hidden = true;
            Infragistics.Win.Appearance appearance150 = new Infragistics.Win.Appearance();
            column150.CellActivation = Activation.NoEdit;
            column150.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column150.Header.Caption = StringResources.RADNIKPBODescription;
            column150.Width = 0x128;
            column150.Format = "";
            column150.CellAppearance = appearance150;
            column150.Hidden = true;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.RADNIKGODINESTAZAPRODescription;
            column19.Width = 0x10b;
            appearance19.TextHAlign = HAlign.Right;
            column19.MaskInput = "{LOC}-nn";
            column19.PromptChar = ' ';
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            column77.CellActivation = Activation.NoEdit;
            column77.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column77.Header.Caption = StringResources.RADNIKMJESECISTAZAPRODescription;
            column77.Width = 0x10b;
            appearance77.TextHAlign = HAlign.Right;
            column77.MaskInput = "{LOC}-nn";
            column77.PromptChar = ' ';
            column77.Format = "";
            column77.CellAppearance = appearance77;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.RADNIKDANISTAZAPRODescription;
            column14.Width = 0xf7;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnn";
            column14.PromptChar = ' ';
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance172 = new Infragistics.Win.Appearance();
            column172.CellActivation = Activation.NoEdit;
            column172.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column172.Header.Caption = StringResources.RADNIKUKUPNIFAKTORDescription;
            column172.Width = 0xd9;
            appearance172.TextHAlign = HAlign.Right;
            column172.MaskInput = "{LOC}-nnn.nn";
            column172.PromptChar = ' ';
            column172.Format = "F2";
            column172.CellAppearance = appearance172;
            column172.Hidden = true;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.RADNIKIDDRZAVLJANSTVODescription;
            column23.Width = 0x69;
            column23.Format = "";
            column23.CellAppearance = appearance23;
            column23.Hidden = true;
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            column85.CellActivation = Activation.NoEdit;
            column85.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column85.Header.Caption = StringResources.RADNIKNAZIVDRZAVLJANSTVODescription;
            column85.Width = 0x128;
            column85.Format = "";
            column85.CellAppearance = appearance85;
            column85.Hidden = true;
            Infragistics.Win.Appearance appearance157 = new Infragistics.Win.Appearance();
            column157.CellActivation = Activation.NoEdit;
            column157.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column157.Header.Caption = StringResources.RADNIKRADNADOZVOLADescription;
            column157.Width = 0x128;
            column157.Format = "";
            column157.CellAppearance = appearance157;
            column157.Hidden = true;
            Infragistics.Win.Appearance appearance184 = new Infragistics.Win.Appearance();
            column184.CellActivation = Activation.NoEdit;
            column184.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column184.Header.Caption = StringResources.RADNIKZAVRSENASKOLADescription;
            column184.Width = 0x128;
            column184.Format = "";
            column184.CellAppearance = appearance184;
            column184.Hidden = true;
            Infragistics.Win.Appearance appearance171 = new Infragistics.Win.Appearance();
            column171.CellActivation = Activation.NoEdit;
            column171.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column171.Header.Caption = StringResources.RADNIKUGOVORODDescription;
            column171.Width = 0xe2;
            column171.MinValue = DateTime.MinValue;
            column171.MaxValue = DateTime.MaxValue;
            column171.Format = "d";
            column171.CellAppearance = appearance171;
            column171.Hidden = true;
            Infragistics.Win.Appearance appearance151 = new Infragistics.Win.Appearance();
            column151.CellActivation = Activation.NoEdit;
            column151.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column151.Header.Caption = StringResources.RADNIKPOCETAKRADADescription;
            column151.Width = 0x8e;
            column151.MinValue = DateTime.MinValue;
            column151.MaxValue = DateTime.MaxValue;
            column151.Format = "d";
            column151.CellAppearance = appearance151;
            column151.Hidden = true;
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            column87.CellActivation = Activation.NoEdit;
            column87.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column87.Header.Caption = StringResources.RADNIKNAZIVPOSLADescription;
            column87.Width = 0x128;
            column87.Format = "";
            column87.CellAppearance = appearance87;
            column87.Hidden = true;
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column32.CellActivation = Activation.NoEdit;
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.RADNIKIDUGOVORORADUDescription;
            column32.Width = 0x92;
            column32.Format = "";
            column32.CellAppearance = appearance32;
            column32.Hidden = true;
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            column92.CellActivation = Activation.NoEdit;
            column92.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column92.Header.Caption = StringResources.RADNIKNAZIVUGOVORORADUDescription;
            column92.Width = 0x9c;
            column92.Format = "";
            column92.CellAppearance = appearance92;
            column92.Hidden = true;
            Infragistics.Win.Appearance appearance181 = new Infragistics.Win.Appearance();
            column181.CellActivation = Activation.NoEdit;
            column181.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column181.Header.Caption = StringResources.RADNIKVRIJEMEPROBNOGRADADescription;
            column181.Width = 0xe2;
            column181.Format = "";
            column181.CellAppearance = appearance181;
            column181.Hidden = true;
            Infragistics.Win.Appearance appearance180 = new Infragistics.Win.Appearance();
            column180.CellActivation = Activation.NoEdit;
            column180.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column180.Header.Caption = StringResources.RADNIKVRIJEMEPRIPRAVNICKOGDescription;
            column180.Width = 0xe2;
            column180.Format = "";
            column180.CellAppearance = appearance180;
            column180.Hidden = true;
            Infragistics.Win.Appearance appearance182 = new Infragistics.Win.Appearance();
            column182.CellActivation = Activation.NoEdit;
            column182.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column182.Header.Caption = StringResources.RADNIKVRIJEMESTRUCNIDescription;
            column182.Width = 0x128;
            column182.Format = "";
            column182.CellAppearance = appearance182;
            column182.Hidden = true;
            Infragistics.Win.Appearance appearance162 = new Infragistics.Win.Appearance();
            column162.CellActivation = Activation.NoEdit;
            column162.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column162.Header.Caption = StringResources.RADNIKRADUINOZEMSTVUDescription;
            column162.Width = 0x128;
            column162.Format = "";
            column162.CellAppearance = appearance162;
            column162.Hidden = true;
            Infragistics.Win.Appearance appearance158 = new Infragistics.Win.Appearance();
            column158.CellActivation = Activation.NoEdit;
            column158.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column158.Header.Caption = StringResources.RADNIKRADNASPOSOBNOSTDescription;
            column158.Width = 0x128;
            column158.Format = "";
            column158.CellAppearance = appearance158;
            column158.Hidden = true;
            Infragistics.Win.Appearance appearance179 = new Infragistics.Win.Appearance();
            column179.CellActivation = Activation.NoEdit;
            column179.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column179.Header.Caption = StringResources.RADNIKVRIJEMEMIROVANJARADNOGODNOSADescription;
            column179.Width = 0xe9;
            column179.Format = "";
            column179.CellAppearance = appearance179;
            column179.Hidden = true;
            Infragistics.Win.Appearance appearance163 = new Infragistics.Win.Appearance();
            column163.CellActivation = Activation.NoEdit;
            column163.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column163.Header.Caption = StringResources.RADNIKRAZLOGPRESTANKADescription;
            column163.Width = 0xe2;
            column163.Format = "";
            column163.CellAppearance = appearance163;
            column163.Hidden = true;
            Infragistics.Win.Appearance appearance183 = new Infragistics.Win.Appearance();
            column183.CellActivation = Activation.NoEdit;
            column183.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column183.Header.Caption = StringResources.RADNIKZABRANANATJECANJADescription;
            column183.Width = 0x128;
            column183.Format = "";
            column183.CellAppearance = appearance183;
            column183.Hidden = true;
            Infragistics.Win.Appearance appearance156 = new Infragistics.Win.Appearance();
            column156.CellActivation = Activation.NoEdit;
            column156.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column156.Header.Caption = StringResources.RADNIKPRODUZENOMIROVINSKODescription;
            column156.Width = 0x128;
            column156.Format = "";
            column156.CellAppearance = appearance156;
            column156.Hidden = true;
            Infragistics.Win.Appearance appearance159 = new Infragistics.Win.Appearance();
            column159.CellActivation = Activation.NoEdit;
            column159.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column159.Header.Caption = StringResources.RADNIKRADNIKNAPOMENADescription;
            column159.Width = 0x48;
            column159.Format = "";
            column159.CellAppearance = appearance159;
            column159.Hidden = true;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.NoEdit;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.RADNIKIDRADNOVRIJEMEDescription;
            column28.Width = 0x70;
            appearance28.TextHAlign = HAlign.Right;
            column28.MaskInput = "{LOC}-nnnnn";
            column28.PromptChar = ' ';
            column28.Format = "";
            column28.CellAppearance = appearance28;
            column28.Hidden = true;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.NoEdit;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.RADNIKIDSPOLDescription;
            column29.Width = 0x5c;
            column29.Format = "";
            column29.CellAppearance = appearance29;
            column29.Hidden = true;
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            column89.CellActivation = Activation.NoEdit;
            column89.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column89.Header.Caption = StringResources.RADNIKNAZIVSPOLDescription;
            column89.Width = 0x9c;
            column89.Format = "";
            column89.CellAppearance = appearance89;
            column89.Hidden = true;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.RADNIKIDIPIDENTDescription;
            column24.Width = 0x55;
            column24.Format = "";
            column24.CellAppearance = appearance24;
            column24.Hidden = true;
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            column86.CellActivation = Activation.NoEdit;
            column86.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column86.Header.Caption = StringResources.RADNIKNAZIVIPIDENTDescription;
            column86.Width = 0x9c;
            column86.Format = "";
            column86.CellAppearance = appearance86;
            column86.Hidden = true;
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            column116.CellActivation = Activation.NoEdit;
            column116.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column116.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column116.Width = 0x69;
            appearance116.TextHAlign = HAlign.Right;
            column116.MaskInput = "{LOC}-nnnnnnnn";
            column116.PromptChar = ' ';
            column116.Format = "";
            column116.CellAppearance = appearance116;
            column116.Hidden = true;
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            column118.CellActivation = Activation.NoEdit;
            column118.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column118.Header.Caption = StringResources.RADNIKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAKDescription;
            column118.Width = 0x33;
            appearance118.TextHAlign = HAlign.Right;
            column118.MaskInput = "{LOC}-nnnnn";
            column118.PromptChar = ' ';
            column118.Format = "";
            column118.CellAppearance = appearance118;
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
            column117.CellActivation = Activation.NoEdit;
            column117.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column117.Header.Caption = StringResources.RADNIKNAZIVOSOBNIODBITAKDescription;
            column117.Width = 0x128;
            column117.Format = "";
            column117.CellAppearance = appearance117;
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            column115.CellActivation = Activation.NoEdit;
            column115.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column115.Header.Caption = StringResources.RADNIKFAKTOROSOBNOGODBITKADescription;
            column115.Width = 0x3e;
            appearance115.TextHAlign = HAlign.Right;
            column115.MaskInput = "{LOC}-nnn.nn";
            column115.PromptChar = ' ';
            column115.Format = "F2";
            column115.CellAppearance = appearance115;
            band8.Columns.Add(column116);
            column116.Header.VisiblePosition = 0;
            band8.Columns.Add(column118);
            column118.Header.VisiblePosition = 1;
            band8.Columns.Add(column117);
            column117.Header.VisiblePosition = 2;
            band8.Columns.Add(column115);
            column115.Header.VisiblePosition = 3;
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            column120.CellActivation = Activation.NoEdit;
            column120.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column120.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column120.Width = 0x69;
            appearance120.TextHAlign = HAlign.Right;
            column120.MaskInput = "{LOC}-nnnnnnnn";
            column120.PromptChar = ' ';
            column120.Format = "";
            column120.CellAppearance = appearance120;
            column120.Hidden = true;
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            column125.CellActivation = Activation.NoEdit;
            column125.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column125.Header.Caption = StringResources.RADNIKZADOLAKSICEIDOLAKSICEDescription;
            column125.Width = 0x48;
            appearance125.TextHAlign = HAlign.Right;
            column125.MaskInput = "{LOC}-nnnnnnnn";
            column125.PromptChar = ' ';
            column125.Format = "";
            column125.CellAppearance = appearance125;
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            column124.CellActivation = Activation.NoEdit;
            column124.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column124.Header.Caption = StringResources.RADNIKZADOLAKSICEIDGRUPEOLAKSICADescription;
            column124.Width = 0x70;
            appearance124.TextHAlign = HAlign.Right;
            column124.MaskInput = "{LOC}-nnnnn";
            column124.PromptChar = ' ';
            column124.Format = "";
            column124.CellAppearance = appearance124;
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            column127.CellActivation = Activation.NoEdit;
            column127.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column127.Header.Caption = StringResources.RADNIKZADOLAKSICEMAXIMALNIIZNOSGRUPEDescription;
            column127.Width = 150;
            appearance127.TextHAlign = HAlign.Right;
            column127.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column127.PromptChar = ' ';
            column127.Format = "F2";
            column127.CellAppearance = appearance127;
            Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
            column128.CellActivation = Activation.NoEdit;
            column128.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column128.Header.Caption = StringResources.RADNIKZADOLAKSICENAZIVGRUPEOLAKSICADescription;
            column128.Width = 0x128;
            column128.Format = "";
            column128.CellAppearance = appearance128;
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
            column129.CellActivation = Activation.NoEdit;
            column129.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column129.Header.Caption = StringResources.RADNIKZADOLAKSICENAZIVOLAKSICEDescription;
            column129.Width = 0x128;
            column129.Format = "";
            column129.CellAppearance = appearance129;
            Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
            column126.CellActivation = Activation.NoEdit;
            column126.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column126.Header.Caption = StringResources.RADNIKZADOLAKSICEIDTIPOLAKSICEDescription;
            column126.Width = 0x33;
            appearance126.TextHAlign = HAlign.Right;
            column126.MaskInput = "{LOC}-nnnnn";
            column126.PromptChar = ' ';
            column126.Format = "";
            column126.CellAppearance = appearance126;
            column126.Hidden = true;
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            column130.CellActivation = Activation.NoEdit;
            column130.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column130.Header.Caption = StringResources.RADNIKZADOLAKSICENAZIVTIPOLAKSICEDescription;
            column130.Width = 0x128;
            column130.Format = "";
            column130.CellAppearance = appearance130;
            column130.Hidden = true;
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            column134.CellActivation = Activation.NoEdit;
            column134.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column134.Header.Caption = StringResources.RADNIKZADOLAKSICEVBDIOLAKSICADescription;
            column134.Width = 0xbf;
            column134.Format = "";
            column134.CellAppearance = appearance134;
            column134.Hidden = true;
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            column135.CellActivation = Activation.NoEdit;
            column135.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column135.Header.Caption = StringResources.RADNIKZADOLAKSICEZRNOLAKSICADescription;
            column135.Width = 0xbf;
            column135.Format = "";
            column135.CellAppearance = appearance135;
            column135.Hidden = true;
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            column131.CellActivation = Activation.NoEdit;
            column131.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column131.Header.Caption = StringResources.RADNIKZADOLAKSICEPRIMATELJOLAKSICA1Description;
            column131.Width = 170;
            column131.Format = "";
            column131.CellAppearance = appearance131;
            column131.Hidden = true;
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            column132.CellActivation = Activation.NoEdit;
            column132.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column132.Header.Caption = StringResources.RADNIKZADOLAKSICEPRIMATELJOLAKSICA2Description;
            column132.Width = 170;
            column132.Format = "";
            column132.CellAppearance = appearance132;
            column132.Hidden = true;
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            column133.CellActivation = Activation.NoEdit;
            column133.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column133.Header.Caption = StringResources.RADNIKZADOLAKSICEPRIMATELJOLAKSICA3Description;
            column133.Width = 170;
            column133.Format = "";
            column133.CellAppearance = appearance133;
            column133.Hidden = true;
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            column123.CellActivation = Activation.NoEdit;
            column123.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column123.Header.Caption = StringResources.RADNIKZADMZOLAKSICEDescription;
            column123.Width = 0x79;
            column123.Format = "";
            column123.CellAppearance = appearance123;
            column123.Hidden = true;
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            column139.CellActivation = Activation.NoEdit;
            column139.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column139.Header.Caption = StringResources.RADNIKZADPZOLAKSICEDescription;
            column139.Width = 0xb1;
            column139.Format = "";
            column139.CellAppearance = appearance139;
            column139.Hidden = true;
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            column122.CellActivation = Activation.NoEdit;
            column122.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column122.Header.Caption = StringResources.RADNIKZADMOOLAKSICEDescription;
            column122.Width = 0x79;
            column122.Format = "";
            column122.CellAppearance = appearance122;
            column122.Hidden = true;
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            column138.CellActivation = Activation.NoEdit;
            column138.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column138.Header.Caption = StringResources.RADNIKZADPOOLAKSICEDescription;
            column138.Width = 0xb1;
            column138.Format = "";
            column138.CellAppearance = appearance138;
            column138.Hidden = true;
            Infragistics.Win.Appearance appearance140 = new Infragistics.Win.Appearance();
            column140.CellActivation = Activation.NoEdit;
            column140.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column140.Header.Caption = StringResources.RADNIKZADSIFRAOPISAPLACANJAOLAKSICEDescription;
            column140.Width = 0x9c;
            column140.Format = "";
            column140.CellAppearance = appearance140;
            column140.Hidden = true;
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            column136.CellActivation = Activation.NoEdit;
            column136.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column136.Header.Caption = StringResources.RADNIKZADOPISPLACANJAOLAKSICEDescription;
            column136.Width = 0x10c;
            column136.Format = "";
            column136.CellAppearance = appearance136;
            column136.Hidden = true;
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            column121.CellActivation = Activation.NoEdit;
            column121.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column121.Header.Caption = StringResources.RADNIKZADIZNOSOLAKSICEDescription;
            column121.Width = 0x74;
            appearance121.TextHAlign = HAlign.Right;
            column121.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column121.PromptChar = ' ';
            column121.Format = "F2";
            column121.CellAppearance = appearance121;
            column121.Hidden = true;
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            column137.CellActivation = Activation.NoEdit;
            column137.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column137.Header.Caption = StringResources.RADNIKZADPOJEDINACNIPOZIVDescription;
            column137.Width = 0xd4;
            column137.Format = "";
            column137.CellAppearance = appearance137;
            column137.Hidden = true;
            band9.Columns.Add(column120);
            column120.Header.VisiblePosition = 0;
            band9.Columns.Add(column125);
            column125.Header.VisiblePosition = 1;
            band9.Columns.Add(column124);
            column124.Header.VisiblePosition = 2;
            band9.Columns.Add(column127);
            column127.Header.VisiblePosition = 3;
            band9.Columns.Add(column128);
            column128.Header.VisiblePosition = 4;
            band9.Columns.Add(column129);
            column129.Header.VisiblePosition = 5;
            band9.Columns.Add(column126);
            column126.Header.VisiblePosition = 6;
            band9.Columns.Add(column130);
            column130.Header.VisiblePosition = 7;
            band9.Columns.Add(column134);
            column134.Header.VisiblePosition = 8;
            band9.Columns.Add(column135);
            column135.Header.VisiblePosition = 9;
            band9.Columns.Add(column131);
            column131.Header.VisiblePosition = 10;
            band9.Columns.Add(column132);
            column132.Header.VisiblePosition = 11;
            band9.Columns.Add(column133);
            column133.Header.VisiblePosition = 12;
            band9.Columns.Add(column123);
            column123.Header.VisiblePosition = 13;
            band9.Columns.Add(column139);
            column139.Header.VisiblePosition = 14;
            band9.Columns.Add(column122);
            column122.Header.VisiblePosition = 15;
            band9.Columns.Add(column138);
            column138.Header.VisiblePosition = 0x10;
            band9.Columns.Add(column140);
            column140.Header.VisiblePosition = 0x11;
            band9.Columns.Add(column136);
            column136.Header.VisiblePosition = 0x12;
            band9.Columns.Add(column121);
            column121.Header.VisiblePosition = 0x13;
            band9.Columns.Add(column137);
            column137.Header.VisiblePosition = 20;
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            column47.CellActivation = Activation.NoEdit;
            column47.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column47.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column47.Width = 0x69;
            appearance47.TextHAlign = HAlign.Right;
            column47.MaskInput = "{LOC}-nnnnnnnn";
            column47.PromptChar = ' ';
            column47.Format = "";
            column47.CellAppearance = appearance47;
            column47.Hidden = true;
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            column60.CellActivation = Activation.NoEdit;
            column60.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column60.Header.Caption = StringResources.RADNIKZADKREDITIIDKREDITORDescription;
            column60.Width = 0x48;
            appearance60.TextHAlign = HAlign.Right;
            column60.MaskInput = "{LOC}-nnnnnnnn";
            column60.PromptChar = ' ';
            column60.Format = "";
            column60.CellAppearance = appearance60;
            column60.Hidden = true;
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            column46.CellActivation = Activation.NoEdit;
            column46.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column46.Header.Caption = StringResources.RADNIKDATUMUGOVORADescription;
            column46.Width = 100;
            column46.MinValue = DateTime.MinValue;
            column46.MaxValue = DateTime.MaxValue;
            column46.Format = "d";
            column46.CellAppearance = appearance46;
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            column48.CellActivation = Activation.NoEdit;
            column48.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column48.Header.Caption = StringResources.RADNIKKREDITAKTIVANDescription;
            column48.Width = 0x8e;
            column48.Format = "";
            column48.CellAppearance = appearance48;
            column48.Hidden = true;
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            column61.CellActivation = Activation.NoEdit;
            column61.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column61.Header.Caption = StringResources.RADNIKZADKREDITINAZIVKREDITORDescription;
            column61.Width = 0x9c;
            column61.Format = "";
            column61.CellAppearance = appearance61;
            column61.Hidden = true;
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            column62.CellActivation = Activation.NoEdit;
            column62.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column62.Header.Caption = StringResources.RADNIKZADKREDITIPRIMATELJKREDITOR1Description;
            column62.Width = 0xa3;
            column62.Format = "";
            column62.CellAppearance = appearance62;
            column62.Hidden = true;
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            column63.CellActivation = Activation.NoEdit;
            column63.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column63.Header.Caption = StringResources.RADNIKZADKREDITIPRIMATELJKREDITOR2Description;
            column63.Width = 0xa3;
            column63.Format = "";
            column63.CellAppearance = appearance63;
            column63.Hidden = true;
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            column64.CellActivation = Activation.NoEdit;
            column64.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column64.Header.Caption = StringResources.RADNIKZADKREDITIPRIMATELJKREDITOR3Description;
            column64.Width = 0xa3;
            column64.Format = "";
            column64.CellAppearance = appearance64;
            column64.Hidden = true;
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            column57.CellActivation = Activation.NoEdit;
            column57.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column57.Header.Caption = StringResources.RADNIKSIFRAOPISAPLACANJAKREDITORDescription;
            column57.Width = 0x9c;
            column57.Format = "";
            column57.CellAppearance = appearance57;
            column57.Hidden = true;
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            column53.CellActivation = Activation.NoEdit;
            column53.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column53.Header.Caption = StringResources.RADNIKOPISPLACANJAKREDITORDescription;
            column53.Width = 0x10c;
            column53.Format = "";
            column53.CellAppearance = appearance53;
            column53.Hidden = true;
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            column51.CellActivation = Activation.NoEdit;
            column51.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column51.Header.Caption = StringResources.RADNIKMOKREDITORDescription;
            column51.Width = 0x79;
            column51.Format = "";
            column51.CellAppearance = appearance51;
            column51.Hidden = true;
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            column55.CellActivation = Activation.NoEdit;
            column55.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column55.Header.Caption = StringResources.RADNIKPOKREDITORDescription;
            column55.Width = 0xb1;
            column55.Format = "";
            column55.CellAppearance = appearance55;
            column55.Hidden = true;
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            column52.CellActivation = Activation.NoEdit;
            column52.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column52.Header.Caption = StringResources.RADNIKMZKREDITORDescription;
            column52.Width = 0x79;
            column52.Format = "";
            column52.CellAppearance = appearance52;
            column52.Hidden = true;
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            column56.CellActivation = Activation.NoEdit;
            column56.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column56.Header.Caption = StringResources.RADNIKPZKREDITORDescription;
            column56.Width = 0xb1;
            column56.Format = "";
            column56.CellAppearance = appearance56;
            column56.Hidden = true;
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            column59.CellActivation = Activation.NoEdit;
            column59.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column59.Header.Caption = StringResources.RADNIKZADIZNOSRATEKREDITADescription;
            column59.Width = 0x8f;
            appearance59.TextHAlign = HAlign.Right;
            column59.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column59.PromptChar = ' ';
            column59.Format = "F2";
            column59.CellAppearance = appearance59;
            column59.Hidden = true;
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            column58.CellActivation = Activation.NoEdit;
            column58.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column58.Header.Caption = StringResources.RADNIKZADBROJRATAOBUSTAVEDescription;
            column58.Width = 0x88;
            appearance58.TextHAlign = HAlign.Right;
            column58.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column58.PromptChar = ' ';
            column58.Format = "F2";
            column58.CellAppearance = appearance58;
            column58.Hidden = true;
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            column67.CellActivation = Activation.NoEdit;
            column67.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column67.Header.Caption = StringResources.RADNIKZADUKUPNIZNOSKREDITADescription;
            column67.Width = 0x9c;
            appearance67.TextHAlign = HAlign.Right;
            column67.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column67.PromptChar = ' ';
            column67.Format = "F2";
            column67.CellAppearance = appearance67;
            column67.Hidden = true;
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            column68.CellActivation = Activation.NoEdit;
            column68.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column68.Header.Caption = StringResources.RADNIKZADVECOTPLACENOBROJRATADescription;
            column68.Width = 0x123;
            appearance68.TextHAlign = HAlign.Right;
            column68.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column68.PromptChar = ' ';
            column68.Format = "F2";
            column68.CellAppearance = appearance68;
            column68.Hidden = true;
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            column69.CellActivation = Activation.NoEdit;
            column69.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column69.Header.Caption = StringResources.RADNIKZADVECOTPLACENOUKUPNIIZNOSDescription;
            column69.Width = 0x123;
            appearance69.TextHAlign = HAlign.Right;
            column69.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column69.PromptChar = ' ';
            column69.Format = "F2";
            column69.CellAppearance = appearance69;
            column69.Hidden = true;
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            column49.CellActivation = Activation.NoEdit;
            column49.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column49.Header.Caption = StringResources.RADNIKKREDITOTPLACENIIZNOSDescription;
            column49.Width = 0xb7;
            appearance49.TextHAlign = HAlign.Right;
            column49.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column49.PromptChar = ' ';
            column49.Format = "F2";
            column49.CellAppearance = appearance49;
            column49.Hidden = true;
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            column50.CellActivation = Activation.NoEdit;
            column50.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column50.Header.Caption = StringResources.RADNIKKREDITOTPLACENORATADescription;
            column50.Width = 210;
            appearance50.TextHAlign = HAlign.Right;
            column50.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column50.PromptChar = ' ';
            column50.Format = "F2";
            column50.CellAppearance = appearance50;
            column50.Hidden = true;
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            column65.CellActivation = Activation.NoEdit;
            column65.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column65.Header.Caption = StringResources.RADNIKZADKREDITIVBDIKREDITORDescription;
            column65.Width = 100;
            column65.Format = "";
            column65.CellAppearance = appearance65;
            column65.Hidden = true;
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            column66.CellActivation = Activation.NoEdit;
            column66.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column66.Header.Caption = StringResources.RADNIKZADKREDITIZRNKREDITORDescription;
            column66.Width = 0x5d;
            column66.Format = "";
            column66.CellAppearance = appearance66;
            column66.Hidden = true;
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            column54.CellActivation = Activation.NoEdit;
            column54.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column54.Header.Caption = StringResources.RADNIKPARTIJAKREDITASPECIFIKACIJADescription;
            column54.Width = 240;
            column54.Format = "";
            column54.CellAppearance = appearance54;
            column54.Hidden = true;
            band4.Columns.Add(column47);
            column47.Header.VisiblePosition = 0;
            band4.Columns.Add(column46);
            column46.Header.VisiblePosition = 1;
            band4.Columns.Add(column60);
            column60.Header.VisiblePosition = 2;
            band4.Columns.Add(column48);
            column48.Header.VisiblePosition = 3;
            band4.Columns.Add(column61);
            column61.Header.VisiblePosition = 4;
            band4.Columns.Add(column62);
            column62.Header.VisiblePosition = 5;
            band4.Columns.Add(column63);
            column63.Header.VisiblePosition = 6;
            band4.Columns.Add(column64);
            column64.Header.VisiblePosition = 7;
            band4.Columns.Add(column57);
            column57.Header.VisiblePosition = 8;
            band4.Columns.Add(column53);
            column53.Header.VisiblePosition = 9;
            band4.Columns.Add(column51);
            column51.Header.VisiblePosition = 10;
            band4.Columns.Add(column55);
            column55.Header.VisiblePosition = 11;
            band4.Columns.Add(column52);
            column52.Header.VisiblePosition = 12;
            band4.Columns.Add(column56);
            column56.Header.VisiblePosition = 13;
            band4.Columns.Add(column59);
            column59.Header.VisiblePosition = 14;
            band4.Columns.Add(column58);
            column58.Header.VisiblePosition = 15;
            band4.Columns.Add(column67);
            column67.Header.VisiblePosition = 0x10;
            band4.Columns.Add(column68);
            column68.Header.VisiblePosition = 0x11;
            band4.Columns.Add(column69);
            column69.Header.VisiblePosition = 0x12;
            band4.Columns.Add(column49);
            column49.Header.VisiblePosition = 0x13;
            band4.Columns.Add(column50);
            column50.Header.VisiblePosition = 20;
            band4.Columns.Add(column65);
            column65.Header.VisiblePosition = 0x15;
            band4.Columns.Add(column66);
            column66.Header.VisiblePosition = 0x16;
            band4.Columns.Add(column54);
            column54.Header.VisiblePosition = 0x17;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column12.Width = 0x69;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnn";
            column12.PromptChar = ' ';
            column12.Format = "";
            column12.CellAppearance = appearance12;
            column12.Hidden = true;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.RADNIKBRUTOELEMENTIDELEMENTDescription;
            column5.Width = 0x48;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            column5.Hidden = true;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.RADNIKBRUTOELEMENTNAZIVELEMENTDescription;
            column6.Width = 0x128;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            column6.Hidden = true;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.RADNIKBRUTOSATNICADescription;
            column11.Width = 0x66;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnn.nnnnnnnn";
            column11.PromptChar = ' ';
            column11.Format = "F8";
            column11.CellAppearance = appearance11;
            column11.Hidden = true;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.RADNIKBRUTOSATIDescription;
            column10.Width = 0x37;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance10;
            column10.Hidden = true;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.RADNIKBRUTOPOSTOTAKDescription;
            column9.Width = 0x4b;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            column9.Hidden = true;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.RADNIKBRUTOIZNOSDescription;
            column8.Width = 0x66;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            column8.Hidden = true;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.RADNIKBRUTOELEMENTPOSTOTAKDescription;
            column7.Width = 0x37;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            column7.Hidden = true;
            band2.Columns.Add(column12);
            column12.Header.VisiblePosition = 0;
            band2.Columns.Add(column5);
            column5.Header.VisiblePosition = 1;
            band2.Columns.Add(column6);
            column6.Header.VisiblePosition = 2;
            band2.Columns.Add(column11);
            column11.Header.VisiblePosition = 3;
            band2.Columns.Add(column10);
            column10.Header.VisiblePosition = 4;
            band2.Columns.Add(column9);
            column9.Header.VisiblePosition = 5;
            band2.Columns.Add(column8);
            column8.Header.VisiblePosition = 6;
            band2.Columns.Add(column7);
            column7.Header.VisiblePosition = 7;
            band2.Hidden = true;
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            column93.CellActivation = Activation.NoEdit;
            column93.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column93.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column93.Width = 0x69;
            appearance93.TextHAlign = HAlign.Right;
            column93.MaskInput = "{LOC}-nnnnnnnn";
            column93.PromptChar = ' ';
            column93.Format = "";
            column93.CellAppearance = appearance93;
            column93.Hidden = true;
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            column94.CellActivation = Activation.NoEdit;
            column94.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column94.Header.Caption = StringResources.RADNIKNETOELEMENTIDELEMENTDescription;
            column94.Width = 0x48;
            column94.Format = "";
            column94.CellAppearance = appearance94;
            column94.Hidden = true;
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            column95.CellActivation = Activation.NoEdit;
            column95.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column95.Header.Caption = StringResources.RADNIKNETOELEMENTNAZIVELEMENTDescription;
            column95.Width = 0x128;
            column95.Format = "";
            column95.CellAppearance = appearance95;
            column95.Hidden = true;
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            column99.CellActivation = Activation.NoEdit;
            column99.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column99.Header.Caption = StringResources.RADNIKNETOSATNICADescription;
            column99.Width = 0x66;
            appearance99.TextHAlign = HAlign.Right;
            column99.MaskInput = "{LOC}-nnnn.nnnnnnnn";
            column99.PromptChar = ' ';
            column99.Format = "F8";
            column99.CellAppearance = appearance99;
            column99.Hidden = true;
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            column98.CellActivation = Activation.NoEdit;
            column98.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column98.Header.Caption = StringResources.RADNIKNETOSATIDescription;
            column98.Width = 0x37;
            appearance98.TextHAlign = HAlign.Right;
            column98.MaskInput = "{LOC}-nnn.nn";
            column98.PromptChar = ' ';
            column98.Format = "F2";
            column98.CellAppearance = appearance98;
            column98.Hidden = true;
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            column97.CellActivation = Activation.NoEdit;
            column97.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column97.Header.Caption = StringResources.RADNIKNETOPOSTOTAKDescription;
            column97.Width = 0x4b;
            appearance97.TextHAlign = HAlign.Right;
            column97.MaskInput = "{LOC}-nnn.nn";
            column97.PromptChar = ' ';
            column97.Format = "F2";
            column97.CellAppearance = appearance97;
            column97.Hidden = true;
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            column96.CellActivation = Activation.NoEdit;
            column96.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column96.Header.Caption = StringResources.RADNIKNETOIZNOSDescription;
            column96.Width = 0x66;
            appearance96.TextHAlign = HAlign.Right;
            column96.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column96.PromptChar = ' ';
            column96.Format = "F2";
            column96.CellAppearance = appearance96;
            column96.Hidden = true;
            band6.Columns.Add(column93);
            column93.Header.VisiblePosition = 0;
            band6.Columns.Add(column94);
            column94.Header.VisiblePosition = 1;
            band6.Columns.Add(column95);
            column95.Header.VisiblePosition = 2;
            band6.Columns.Add(column99);
            column99.Header.VisiblePosition = 3;
            band6.Columns.Add(column98);
            column98.Header.VisiblePosition = 4;
            band6.Columns.Add(column97);
            column97.Header.VisiblePosition = 5;
            band6.Columns.Add(column96);
            column96.Header.VisiblePosition = 6;
            band6.Hidden = true;
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            column100.CellActivation = Activation.NoEdit;
            column100.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column100.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column100.Width = 0x69;
            appearance100.TextHAlign = HAlign.Right;
            column100.MaskInput = "{LOC}-nnnnnnnn";
            column100.PromptChar = ' ';
            column100.Format = "";
            column100.CellAppearance = appearance100;
            column100.Hidden = true;
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            column106.CellActivation = Activation.NoEdit;
            column106.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column106.Header.Caption = StringResources.RADNIKZADOBUSTAVAIDOBUSTAVADescription;
            column106.Width = 0x48;
            appearance106.TextHAlign = HAlign.Right;
            column106.MaskInput = "{LOC}-nnnnnnnn";
            column106.PromptChar = ' ';
            column106.Format = "";
            column106.CellAppearance = appearance106;
            column106.Hidden = true;
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            column101.CellActivation = Activation.NoEdit;
            column101.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column101.Header.Caption = StringResources.RADNIKOBUSTAVAAKTIVNADescription;
            column101.Width = 0x9c;
            column101.Format = "";
            column101.CellAppearance = appearance101;
            column101.Hidden = true;
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            column107.CellActivation = Activation.NoEdit;
            column107.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column107.Header.Caption = StringResources.RADNIKZADOBUSTAVANAZIVOBUSTAVADescription;
            column107.Width = 0x128;
            column107.Format = "";
            column107.CellAppearance = appearance107;
            column107.Hidden = true;
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            column110.CellActivation = Activation.NoEdit;
            column110.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column110.Header.Caption = StringResources.RADNIKZADOBUSTAVAVRSTAOBUSTAVEDescription;
            column110.Width = 0x33;
            appearance110.TextHAlign = HAlign.Right;
            column110.MaskInput = "{LOC}-nn";
            column110.PromptChar = ' ';
            column110.Format = "";
            column110.CellAppearance = appearance110;
            column110.Hidden = true;
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            column108.CellActivation = Activation.NoEdit;
            column108.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column108.Header.Caption = StringResources.RADNIKZADOBUSTAVANAZIVVRSTAOBUSTAVEDescription;
            column108.Width = 0x128;
            column108.Format = "";
            column108.CellAppearance = appearance108;
            column108.Hidden = true;
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            column105.CellActivation = Activation.NoEdit;
            column105.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column105.Header.Caption = StringResources.RADNIKZADIZNOSOBUSTAVEDescription;
            column105.Width = 0x74;
            appearance105.TextHAlign = HAlign.Right;
            column105.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column105.PromptChar = ' ';
            column105.Format = "F2";
            column105.CellAppearance = appearance105;
            column105.Hidden = true;
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            column112.CellActivation = Activation.NoEdit;
            column112.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column112.Header.Caption = StringResources.RADNIKZADPOSTOTAKOBUSTAVEDescription;
            column112.Width = 0x88;
            appearance112.TextHAlign = HAlign.Right;
            column112.MaskInput = "{LOC}-nnn.nn";
            column112.PromptChar = ' ';
            column112.Format = "F2";
            column112.CellAppearance = appearance112;
            column112.Hidden = true;
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            column113.CellActivation = Activation.NoEdit;
            column113.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column113.Header.Caption = StringResources.RADNIKZADPOSTOTNAODBRUTADescription;
            column113.Width = 0xd4;
            column113.Format = "";
            column113.CellAppearance = appearance113;
            column113.Hidden = true;
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            column104.CellActivation = Activation.NoEdit;
            column104.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column104.Header.Caption = StringResources.RADNIKZADISPLACENOKASADescription;
            column104.Width = 0x88;
            appearance104.TextHAlign = HAlign.Right;
            column104.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column104.PromptChar = ' ';
            column104.Format = "F2";
            column104.CellAppearance = appearance104;
            column104.Hidden = true;
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            column114.CellActivation = Activation.NoEdit;
            column114.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column114.Header.Caption = StringResources.RADNIKZADSALDOKASADescription;
            column114.Width = 0xd9;
            appearance114.TextHAlign = HAlign.Right;
            column114.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column114.PromptChar = ' ';
            column114.Format = "F2";
            column114.CellAppearance = appearance114;
            column114.Hidden = true;
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            column103.CellActivation = Activation.NoEdit;
            column103.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column103.Header.Caption = StringResources.RADNIKOTPLACENIIZNOSDescription;
            column103.Width = 0xb7;
            appearance103.TextHAlign = HAlign.Right;
            column103.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column103.PromptChar = ' ';
            column103.Format = "F2";
            column103.CellAppearance = appearance103;
            column103.Hidden = true;
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            column102.CellActivation = Activation.NoEdit;
            column102.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column102.Header.Caption = StringResources.RADNIKOTPLACENIBROJRATADescription;
            column102.Width = 0xb1;
            appearance102.TextHAlign = HAlign.Right;
            column102.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column102.PromptChar = ' ';
            column102.Format = "F2";
            column102.CellAppearance = appearance102;
            column102.Hidden = true;
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            column111.CellActivation = Activation.NoEdit;
            column111.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column111.Header.Caption = StringResources.RADNIKZADOBUSTAVAZRNOBUSTAVADescription;
            column111.Width = 0xbf;
            column111.Format = "";
            column111.CellAppearance = appearance111;
            column111.Hidden = true;
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            column109.CellActivation = Activation.NoEdit;
            column109.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column109.Header.Caption = StringResources.RADNIKZADOBUSTAVAVBDIOBUSTAVADescription;
            column109.Width = 0xbf;
            column109.Format = "";
            column109.CellAppearance = appearance109;
            column109.Hidden = true;
            band7.Columns.Add(column100);
            column100.Header.VisiblePosition = 0;
            band7.Columns.Add(column106);
            column106.Header.VisiblePosition = 1;
            band7.Columns.Add(column101);
            column101.Header.VisiblePosition = 2;
            band7.Columns.Add(column107);
            column107.Header.VisiblePosition = 3;
            band7.Columns.Add(column110);
            column110.Header.VisiblePosition = 4;
            band7.Columns.Add(column108);
            column108.Header.VisiblePosition = 5;
            band7.Columns.Add(column105);
            column105.Header.VisiblePosition = 6;
            band7.Columns.Add(column112);
            column112.Header.VisiblePosition = 7;
            band7.Columns.Add(column113);
            column113.Header.VisiblePosition = 8;
            band7.Columns.Add(column104);
            column104.Header.VisiblePosition = 9;
            band7.Columns.Add(column114);
            column114.Header.VisiblePosition = 10;
            band7.Columns.Add(column103);
            column103.Header.VisiblePosition = 11;
            band7.Columns.Add(column102);
            column102.Header.VisiblePosition = 12;
            band7.Columns.Add(column111);
            column111.Header.VisiblePosition = 13;
            band7.Columns.Add(column109);
            column109.Header.VisiblePosition = 14;
            band7.Hidden = true;
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            column73.CellActivation = Activation.NoEdit;
            column73.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column73.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column73.Width = 0x69;
            appearance73.TextHAlign = HAlign.Right;
            column73.MaskInput = "{LOC}-nnnnnnnn";
            column73.PromptChar = ' ';
            column73.Format = "";
            column73.CellAppearance = appearance73;
            column73.Hidden = true;
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            column72.CellActivation = Activation.NoEdit;
            column72.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column72.Header.Caption = StringResources.RADNIKIDGRUPEKOEFDescription;
            column72.Width = 0x33;
            column72.Format = "";
            column72.CellAppearance = appearance72;
            column72.Hidden = true;
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            column74.CellActivation = Activation.NoEdit;
            column74.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column74.Header.Caption = StringResources.RADNIKNAZIVGRUPEKOEFDescription;
            column74.Width = 0x128;
            column74.Format = "";
            column74.CellAppearance = appearance74;
            column74.Hidden = true;
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            column71.CellActivation = Activation.NoEdit;
            column71.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column71.Header.Caption = StringResources.RADNIKDODATNIKOEFICIJENTDescription;
            column71.Width = 0x66;
            appearance71.TextHAlign = HAlign.Right;
            column71.MaskInput = "{LOC}-nnnn.nnnnnnnn";
            column71.PromptChar = ' ';
            column71.Format = "F8";
            column71.CellAppearance = appearance71;
            column71.Hidden = true;
            band5.Columns.Add(column73);
            column73.Header.VisiblePosition = 0;
            band5.Columns.Add(column72);
            column72.Header.VisiblePosition = 1;
            band5.Columns.Add(column74);
            column74.Header.VisiblePosition = 2;
            band5.Columns.Add(column71);
            column71.Header.VisiblePosition = 3;
            band5.Hidden = true;
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            column35.CellActivation = Activation.NoEdit;
            column35.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column35.Header.Caption = StringResources.RADNIKIDRADNIKDescription;
            column35.Width = 0x69;
            appearance35.TextHAlign = HAlign.Right;
            column35.MaskInput = "{LOC}-nnnnnnnn";
            column35.PromptChar = ' ';
            column35.Format = "";
            column35.CellAppearance = appearance35;
            column35.Hidden = true;
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            column34.CellActivation = Activation.NoEdit;
            column34.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column34.Header.Caption = StringResources.RADNIKBANKAZASTICENOIDBANKEDescription;
            column34.Width = 0x112;
            appearance34.TextHAlign = HAlign.Right;
            column34.MaskInput = "{LOC}-nnnnn";
            column34.PromptChar = ' ';
            column34.Format = "";
            column34.CellAppearance = appearance34;
            column34.Hidden = true;
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            column42.CellActivation = Activation.NoEdit;
            column42.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column42.Header.Caption = StringResources.RADNIKZADSIFRAOPISAPLACANJAIZUZECEDescription;
            column42.Width = 0x9c;
            column42.Format = "";
            column42.CellAppearance = appearance42;
            column42.Hidden = true;
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            column39.CellActivation = Activation.NoEdit;
            column39.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column39.Header.Caption = StringResources.RADNIKZADOPISPLACANJAIZUZECEDescription;
            column39.Width = 0x10c;
            column39.Format = "";
            column39.CellAppearance = appearance39;
            column39.Hidden = true;
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            column43.CellActivation = Activation.NoEdit;
            column43.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column43.Header.Caption = StringResources.RADNIKZADTEKUCIIZUZECEDescription;
            column43.Width = 170;
            column43.Format = "";
            column43.CellAppearance = appearance43;
            column43.Hidden = true;
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            column37.CellActivation = Activation.NoEdit;
            column37.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column37.Header.Caption = StringResources.RADNIKZADMOIZUZECEDescription;
            column37.Width = 0x79;
            column37.Format = "";
            column37.CellAppearance = appearance37;
            column37.Hidden = true;
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            column40.CellActivation = Activation.NoEdit;
            column40.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column40.Header.Caption = StringResources.RADNIKZADPOIZUZECEDescription;
            column40.Width = 0xb1;
            column40.Format = "";
            column40.CellAppearance = appearance40;
            column40.Hidden = true;
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            column38.CellActivation = Activation.NoEdit;
            column38.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column38.Header.Caption = StringResources.RADNIKZADMZIZUZECEDescription;
            column38.Width = 0x79;
            column38.Format = "";
            column38.CellAppearance = appearance38;
            column38.Hidden = true;
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            column41.CellActivation = Activation.NoEdit;
            column41.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column41.Header.Caption = StringResources.RADNIKZADPZIZUZECEDescription;
            column41.Width = 0xb1;
            column41.Format = "";
            column41.CellAppearance = appearance41;
            column41.Hidden = true;
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            column36.CellActivation = Activation.NoEdit;
            column36.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column36.Header.Caption = StringResources.RADNIKZADIZNOSIZUZECADescription;
            column36.Width = 0xa3;
            appearance36.TextHAlign = HAlign.Right;
            column36.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column36.PromptChar = ' ';
            column36.Format = "F2";
            column36.CellAppearance = appearance36;
            column36.Hidden = true;
            band3.Columns.Add(column35);
            column35.Header.VisiblePosition = 0;
            band3.Columns.Add(column34);
            column34.Header.VisiblePosition = 1;
            band3.Columns.Add(column42);
            column42.Header.VisiblePosition = 2;
            band3.Columns.Add(column39);
            column39.Header.VisiblePosition = 3;
            band3.Columns.Add(column43);
            column43.Header.VisiblePosition = 4;
            band3.Columns.Add(column37);
            column37.Header.VisiblePosition = 5;
            band3.Columns.Add(column40);
            column40.Header.VisiblePosition = 6;
            band3.Columns.Add(column38);
            column38.Header.VisiblePosition = 7;
            band3.Columns.Add(column41);
            column41.Header.VisiblePosition = 8;
            band3.Columns.Add(column36);
            column36.Header.VisiblePosition = 9;
            band3.Hidden = true;
            band.Columns.Add(column26);
            column26.Header.VisiblePosition = 0;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 1;
            band.Columns.Add(column155);
            column155.Header.VisiblePosition = 2;
            band.Columns.Add(column33);
            column33.Header.VisiblePosition = 3;
            band.Columns.Add(column119);
            column119.Header.VisiblePosition = 4;
            band.Columns.Add(column44);
            column44.Header.VisiblePosition = 5;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 6;
            band.Columns.Add(column176);
            column176.Header.VisiblePosition = 7;
            band.Columns.Add(column78);
            column78.Header.VisiblePosition = 8;
            band.Columns.Add(column70);
            column70.Header.VisiblePosition = 9;
            band.Columns.Add(column141);
            column141.Header.VisiblePosition = 10;
            band.Columns.Add(column142);
            column142.Header.VisiblePosition = 11;
            band.Columns.Add(column143);
            column143.Header.VisiblePosition = 12;
            band.Columns.Add(column144);
            column144.Header.VisiblePosition = 13;
            band.Columns.Add(column145);
            column145.Header.VisiblePosition = 14;
            band.Columns.Add(column146);
            column146.Header.VisiblePosition = 15;
            band.Columns.Add(column147);
            column147.Header.VisiblePosition = 0x10;
            band.Columns.Add(column160);
            column160.Header.VisiblePosition = 0x11;
            band.Columns.Add(column161);
            column161.Header.VisiblePosition = 0x12;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 0x13;
            band.Columns.Add(column80);
            column80.Header.VisiblePosition = 20;
            band.Columns.Add(column81);
            column81.Header.VisiblePosition = 0x15;
            band.Columns.Add(column82);
            column82.Header.VisiblePosition = 0x16;
            band.Columns.Add(column178);
            column178.Header.VisiblePosition = 0x17;
            band.Columns.Add(column186);
            column186.Header.VisiblePosition = 0x18;
            band.Columns.Add(column166);
            column166.Header.VisiblePosition = 0x19;
            band.Columns.Add(column185);
            column185.Header.VisiblePosition = 0x1a;
            band.Columns.Add(column164);
            column164.Header.VisiblePosition = 0x1b;
            band.Columns.Add(column148);
            column148.Header.VisiblePosition = 0x1c;
            band.Columns.Add(column167);
            column167.Header.VisiblePosition = 0x1d;
            band.Columns.Add(column45);
            column45.Header.VisiblePosition = 30;
            band.Columns.Add(column152);
            column152.Header.VisiblePosition = 0x1f;
            band.Columns.Add(column177);
            column177.Header.VisiblePosition = 0x20;
            band.Columns.Add(column168);
            column168.Header.VisiblePosition = 0x21;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 0x22;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 0x23;
            band.Columns.Add(column76);
            column76.Header.VisiblePosition = 0x24;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 0x25;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 0x26;
            band.Columns.Add(column83);
            column83.Header.VisiblePosition = 0x27;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 40;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0x29;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 0x2a;
            band.Columns.Add(column75);
            column75.Header.VisiblePosition = 0x2b;
            band.Columns.Add(column31);
            column31.Header.VisiblePosition = 0x2c;
            band.Columns.Add(column91);
            column91.Header.VisiblePosition = 0x2d;
            band.Columns.Add(column27);
            column27.Header.VisiblePosition = 0x2e;
            band.Columns.Add(column88);
            column88.Header.VisiblePosition = 0x2f;
            band.Columns.Add(column153);
            column153.Header.VisiblePosition = 0x30;
            band.Columns.Add(column154);
            column154.Header.VisiblePosition = 0x31;
            band.Columns.Add(column30);
            column30.Header.VisiblePosition = 50;
            band.Columns.Add(column90);
            column90.Header.VisiblePosition = 0x33;
            band.Columns.Add(column22);
            column22.Header.VisiblePosition = 0x34;
            band.Columns.Add(column84);
            column84.Header.VisiblePosition = 0x35;
            band.Columns.Add(column25);
            column25.Header.VisiblePosition = 0x36;
            band.Columns.Add(column149);
            column149.Header.VisiblePosition = 0x37;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 0x38;
            band.Columns.Add(column77);
            column77.Header.VisiblePosition = 0x39;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 0x3a;
            band.Columns.Add(column165);
            column165.Header.VisiblePosition = 0x3b;
            band.Columns.Add(column169);
            column169.Header.VisiblePosition = 60;
            band.Columns.Add(column170);
            column170.Header.VisiblePosition = 0x3d;
            band.Columns.Add(column174);
            column174.Header.VisiblePosition = 0x3e;
            band.Columns.Add(column175);
            column175.Header.VisiblePosition = 0x3f;
            band.Columns.Add(column173);
            column173.Header.VisiblePosition = 0x40;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0x41;
            band.Columns.Add(column79);
            column79.Header.VisiblePosition = 0x42;
            band.Columns.Add(column150);
            column150.Header.VisiblePosition = 0x43;
            band.Columns.Add(column172);
            column172.Header.VisiblePosition = 0x44;
            band.Columns.Add(column23);
            column23.Header.VisiblePosition = 0x45;
            band.Columns.Add(column85);
            column85.Header.VisiblePosition = 70;
            band.Columns.Add(column157);
            column157.Header.VisiblePosition = 0x47;
            band.Columns.Add(column184);
            column184.Header.VisiblePosition = 0x48;
            band.Columns.Add(column171);
            column171.Header.VisiblePosition = 0x49;
            band.Columns.Add(column151);
            column151.Header.VisiblePosition = 0x4a;
            band.Columns.Add(column87);
            column87.Header.VisiblePosition = 0x4b;
            band.Columns.Add(column32);
            column32.Header.VisiblePosition = 0x4c;
            band.Columns.Add(column92);
            column92.Header.VisiblePosition = 0x4d;
            band.Columns.Add(column181);
            column181.Header.VisiblePosition = 0x4e;
            band.Columns.Add(column180);
            column180.Header.VisiblePosition = 0x4f;
            band.Columns.Add(column182);
            column182.Header.VisiblePosition = 80;
            band.Columns.Add(column162);
            column162.Header.VisiblePosition = 0x51;
            band.Columns.Add(column158);
            column158.Header.VisiblePosition = 0x52;
            band.Columns.Add(column179);
            column179.Header.VisiblePosition = 0x53;
            band.Columns.Add(column163);
            column163.Header.VisiblePosition = 0x54;
            band.Columns.Add(column183);
            column183.Header.VisiblePosition = 0x55;
            band.Columns.Add(column156);
            column156.Header.VisiblePosition = 0x56;
            band.Columns.Add(column159);
            column159.Header.VisiblePosition = 0x57;
            band.Columns.Add(column28);
            column28.Header.VisiblePosition = 0x58;
            band.Columns.Add(column29);
            column29.Header.VisiblePosition = 0x59;
            band.Columns.Add(column89);
            column89.Header.VisiblePosition = 90;
            band.Columns.Add(column24);
            column24.Header.VisiblePosition = 0x5b;
            band.Columns.Add(column86);
            column86.Header.VisiblePosition = 0x5c;
            this.userControlDataGridRADNIK.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridRADNIK.Location = point;
            this.userControlDataGridRADNIK.Name = "userControlDataGridRADNIK";
            this.userControlDataGridRADNIK.Tag = "RADNIK";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridRADNIK.Size = size;
            this.userControlDataGridRADNIK.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridRADNIK.Dock = DockStyle.Fill;
            this.userControlDataGridRADNIK.FillAtStartup = false;
            this.userControlDataGridRADNIK.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridRADNIK.InitializeRow += new InitializeRowEventHandler(this.RADNIKUserDataGrid_InitializeRow);
            this.userControlDataGridRADNIK.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridRADNIK.DisplayLayout.BandsSerializer.Add(band8);
            this.userControlDataGridRADNIK.DisplayLayout.BandsSerializer.Add(band9);
            this.userControlDataGridRADNIK.DisplayLayout.BandsSerializer.Add(band4);
            this.userControlDataGridRADNIK.DisplayLayout.BandsSerializer.Add(band2);
            this.userControlDataGridRADNIK.DisplayLayout.BandsSerializer.Add(band6);
            this.userControlDataGridRADNIK.DisplayLayout.BandsSerializer.Add(band7);
            this.userControlDataGridRADNIK.DisplayLayout.BandsSerializer.Add(band5);
            this.userControlDataGridRADNIK.DisplayLayout.BandsSerializer.Add(band3);
            this.Controls.AddRange(new Control[] { this.userControlDataGridRADNIK });
            this.Name = "RADNIKUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.RADNIKUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridRADNIK).EndInit();
            this.ResumeLayout(false);
        }

        private void RADNIKUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void RADNIKUserDataGrid_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.SetComboBoxColumnProperties(true);
                if (this.FillAtStartup)
                {
                    this.DataGrid.Fill();
                }
            }
        }

        private void RADNIKUserDataGrid_Load1(object sender, EventArgs e)
        {
            this.userControlDataGridRADNIK.DisplayLayout.UseFixedHeaders = true;
            this.userControlDataGridRADNIK.DisplayLayout.Bands[0].Columns[0].Header.Fixed = true;
            this.userControlDataGridRADNIK.DisplayLayout.Bands[0].Columns[1].Header.Fixed = true;
            this.userControlDataGridRADNIK.DisplayLayout.Bands[0].Columns[2].Header.Fixed = true;
            this.userControlDataGridRADNIK.DisplayLayout.Bands[0].Columns[3].Header.Fixed = true;
            this.userControlDataGridRADNIK.DisplayLayout.Bands[0].Columns[4].Header.Fixed = true;
            this.userControlDataGridRADNIK.DisplayLayout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag;
            this.userControlDataGridRADNIK.DisplayLayout.Override.RowSelectorStyle = HeaderStyle.WindowsVista;
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
            if (DataAdapterFactory.Provider == null)
            {
                DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
            }
            DataSet dataSet = new SKUPPOREZAIDOPRINOSADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSKUPPOREZAIDOPRINOSADataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["SKUPPOREZAIDOPRINOSA"]) {
                Sort = "NAZIVSKUPPOREZAIDOPRINOSA"
            };
            CreateValueList(this.DataGrid, "SKUPPOREZAIDOPRINOSARADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", dataList, "IDSKUPPOREZAIDOPRINOSA", "NAZIVSKUPPOREZAIDOPRINOSA");
            UltraGridColumn column8 = this.DataGrid.DisplayLayout.Bands["RADNIK"].Columns["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"];
            column8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column8.ValueList = this.DataGrid.DisplayLayout.ValueLists["SKUPPOREZAIDOPRINOSARADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"];
            if (setColumnsWidth)
            {
                column8.Width = 370;
            }
            DataSet set = new BENEFICIRANIDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetBENEFICIRANIDataAdapter().Fill(set);
            }
            System.Data.DataView view = new System.Data.DataView(set.Tables["BENEFICIRANI"]) {
                Sort = "NAZIVBENEFICIRANI"
            };
            CreateValueList(this.DataGrid, "BENEFICIRANIIDBENEFICIRANI", view, "IDBENEFICIRANI", "NAZIVBENEFICIRANI");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["RADNIK"].Columns["IDBENEFICIRANI"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["BENEFICIRANIIDBENEFICIRANI"];
            if (setColumnsWidth)
            {
                column.Width = 370;
            }
            DataSet set6 = new TITULADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetTITULADataAdapter().Fill(set6);
            }
            System.Data.DataView view6 = new System.Data.DataView(set6.Tables["TITULA"]) {
                Sort = "NAZIVTITULA"
            };
            CreateValueList(this.DataGrid, "TITULAIDTITULA", view6, "IDTITULA", "NAZIVTITULA");
            UltraGridColumn column6 = this.DataGrid.DisplayLayout.Bands["RADNIK"].Columns["IDTITULA"];
            column6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column6.ValueList = this.DataGrid.DisplayLayout.ValueLists["TITULAIDTITULA"];
            if (setColumnsWidth)
            {
                column6.Width = 370;
            }
            DataSet set4 = new RADNOMJESTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetRADNOMJESTODataAdapter().Fill(set4);
            }
            System.Data.DataView view4 = new System.Data.DataView(set4.Tables["RADNOMJESTO"]) {
                Sort = "NAZIVRADNOMJESTO"
            };
            CreateValueList(this.DataGrid, "RADNOMJESTOIDRADNOMJESTO", view4, "IDRADNOMJESTO", "NAZIVRADNOMJESTO");
            UltraGridColumn column4 = this.DataGrid.DisplayLayout.Bands["RADNIK"].Columns["IDRADNOMJESTO"];
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column4.ValueList = this.DataGrid.DisplayLayout.ValueLists["RADNOMJESTOIDRADNOMJESTO"];
            if (setColumnsWidth)
            {
                column4.Width = 370;
            }
            DataSet set7 = new STRUCNASPREMADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRUCNASPREMADataAdapter().Fill(set7);
            }
            System.Data.DataView view7 = new System.Data.DataView(set7.Tables["STRUCNASPREMA"]) {
                Sort = "NAZIVSTRUCNASPREMA"
            };
            CreateValueList(this.DataGrid, "STRUCNASPREMAPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA", view7, "IDSTRUCNASPREMA", "NAZIVSTRUCNASPREMA");
            UltraGridColumn column7 = this.DataGrid.DisplayLayout.Bands["RADNIK"].Columns["POTREBNASTRUCNASPREMAIDSTRUCNASPREMA"];
            column7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column7.ValueList = this.DataGrid.DisplayLayout.ValueLists["STRUCNASPREMAPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA"];
            if (setColumnsWidth)
            {
                column7.Width = 370;
            }
            DataSet set5 = new STRUKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRUKADataAdapter().Fill(set5);
            }
            System.Data.DataView view5 = new System.Data.DataView(set5.Tables["STRUKA"]) {
                Sort = "NAZIVSTRUKA"
            };
            CreateValueList(this.DataGrid, "STRUKAIDSTRUKA", view5, "IDSTRUKA", "NAZIVSTRUKA");
            UltraGridColumn column5 = this.DataGrid.DisplayLayout.Bands["RADNIK"].Columns["IDSTRUKA"];
            column5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column5.ValueList = this.DataGrid.DisplayLayout.ValueLists["STRUKAIDSTRUKA"];
            if (setColumnsWidth)
            {
                column5.Width = 370;
            }
            DataSet set2 = new BRACNOSTANJEDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetBRACNOSTANJEDataAdapter().Fill(set2);
            }
            System.Data.DataView view2 = new System.Data.DataView(set2.Tables["BRACNOSTANJE"]) {
                Sort = "NAZIVBRACNOSTANJE"
            };
            CreateValueList(this.DataGrid, "BRACNOSTANJEIDBRACNOSTANJE", view2, "IDBRACNOSTANJE", "NAZIVBRACNOSTANJE");
            UltraGridColumn column2 = this.DataGrid.DisplayLayout.Bands["RADNIK"].Columns["IDBRACNOSTANJE"];
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.DataGrid.DisplayLayout.ValueLists["BRACNOSTANJEIDBRACNOSTANJE"];
            if (setColumnsWidth)
            {
                column2.Width = 370;
            }
            DataSet set3 = new ORGDIODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetORGDIODataAdapter().Fill(set3);
            }
            System.Data.DataView view3 = new System.Data.DataView(set3.Tables["ORGDIO"]) {
                Sort = "ORGANIZACIJSKIDIO"
            };
            CreateValueList(this.DataGrid, "ORGDIOIDORGDIO", view3, "IDORGDIO", "ORGANIZACIJSKIDIO");
            UltraGridColumn column3 = this.DataGrid.DisplayLayout.Bands["RADNIK"].Columns["IDORGDIO"];
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column3.ValueList = this.DataGrid.DisplayLayout.ValueLists["ORGDIOIDORGDIO"];
            if (setColumnsWidth)
            {
                column3.Width = 370;
            }
        }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.DataView[this.DataGrid.CurrentRowIndex].Row;
            }
        }

        [Browsable(false)]
        public virtual RADNIKDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridRADNIK;
            }
            set
            {
                this.userControlDataGridRADNIK = value;
            }
        }

        [Browsable(false), Category("Deklarit Work With ")]
        public virtual System.Data.DataView DataView
        {
            get
            {
                return this.DataGrid.DataView;
            }
        }

        public string Description
        {
            get
            {
                return this.m_Description;
            }
            set
            {
                this.m_Description = value;
            }
        }

        [DefaultValue(true), Category("Deklarit Work With "), Description("True= Fill at Startup. False= Not Fill")]
        public virtual bool FillAtStartup
        {
            get
            {
                return this.m_FillAtStartup;
            }
            set
            {
                this.m_FillAtStartup = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDBANKEIDBANKE
        {
            get
            {
                return this.DataGrid.FillByIDBANKEIDBANKE;
            }
            set
            {
                this.DataGrid.FillByIDBANKEIDBANKE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual string FillByIDBENEFICIRANIIDBENEFICIRANI
        {
            get
            {
                return this.DataGrid.FillByIDBENEFICIRANIIDBENEFICIRANI;
            }
            set
            {
                this.DataGrid.FillByIDBENEFICIRANIIDBENEFICIRANI = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDBRACNOSTANJEIDBRACNOSTANJE
        {
            get
            {
                return this.DataGrid.FillByIDBRACNOSTANJEIDBRACNOSTANJE;
            }
            set
            {
                this.DataGrid.FillByIDBRACNOSTANJEIDBRACNOSTANJE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDDRZAVLJANSTVOIDDRZAVLJANSTVO
        {
            get
            {
                return this.DataGrid.FillByIDDRZAVLJANSTVOIDDRZAVLJANSTVO;
            }
            set
            {
                this.DataGrid.FillByIDDRZAVLJANSTVOIDDRZAVLJANSTVO = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDIPIDENTIDIPIDENT
        {
            get
            {
                return this.DataGrid.FillByIDIPIDENTIDIPIDENT;
            }
            set
            {
                this.DataGrid.FillByIDIPIDENTIDIPIDENT = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDORGDIOIDORGDIO
        {
            get
            {
                return this.DataGrid.FillByIDORGDIOIDORGDIO;
            }
            set
            {
                this.DataGrid.FillByIDORGDIOIDORGDIO = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDRADNOMJESTOIDRADNOMJESTO
        {
            get
            {
                return this.DataGrid.FillByIDRADNOMJESTOIDRADNOMJESTO;
            }
            set
            {
                this.DataGrid.FillByIDRADNOMJESTOIDRADNOMJESTO = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDRADNOVRIJEMEIDRADNOVRIJEME
        {
            get
            {
                return this.DataGrid.FillByIDRADNOVRIJEMEIDRADNOVRIJEME;
            }
            set
            {
                this.DataGrid.FillByIDRADNOVRIJEMEIDRADNOVRIJEME = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDSPOLIDSPOL
        {
            get
            {
                return this.DataGrid.FillByIDSPOLIDSPOL;
            }
            set
            {
                this.DataGrid.FillByIDSPOLIDSPOL = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDSTRUKAIDSTRUKA
        {
            get
            {
                return this.DataGrid.FillByIDSTRUKAIDSTRUKA;
            }
            set
            {
                this.DataGrid.FillByIDSTRUKAIDSTRUKA = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDTITULAIDTITULA
        {
            get
            {
                return this.DataGrid.FillByIDTITULAIDTITULA;
            }
            set
            {
                this.DataGrid.FillByIDTITULAIDTITULA = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDUGOVORORADUIDUGOVORORADU
        {
            get
            {
                return this.DataGrid.FillByIDUGOVORORADUIDUGOVORORADU;
            }
            set
            {
                this.DataGrid.FillByIDUGOVORORADUIDUGOVORORADU = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual string FillByJMBGJMBG
        {
            get
            {
                return this.DataGrid.FillByJMBGJMBG;
            }
            set
            {
                this.DataGrid.FillByJMBGJMBG = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual string FillByOPCINARADAIDOPCINEOPCINARADAIDOPCINE
        {
            get
            {
                return this.DataGrid.FillByOPCINARADAIDOPCINEOPCINARADAIDOPCINE;
            }
            set
            {
                this.DataGrid.FillByOPCINARADAIDOPCINEOPCINARADAIDOPCINE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual string FillByOPCINASTANOVANJAIDOPCINEOPCINASTANOVANJAIDOPCINE
        {
            get
            {
                return this.DataGrid.FillByOPCINASTANOVANJAIDOPCINEOPCINASTANOVANJAIDOPCINE;
            }
            set
            {
                this.DataGrid.FillByOPCINASTANOVANJAIDOPCINEOPCINASTANOVANJAIDOPCINE = value;
            }
        }

        [Category("Deklarit Work With "), DefaultValue(true)]
        public virtual bool FillByPage
        {
            get
            {
                return this.DataGrid.FillByPage;
            }
            set
            {
                this.DataGrid.FillByPage = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMAPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA
        {
            get
            {
                return this.DataGrid.FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMAPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
            }
            set
            {
                this.DataGrid.FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMAPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA
        {
            get
            {
                return this.DataGrid.FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
            }
            set
            {
                this.DataGrid.FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMATRENUTNASTRUCNASPREMAIDSTRUCNASPREMA
        {
            get
            {
                return this.DataGrid.FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMATRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
            }
            set
            {
                this.DataGrid.FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMATRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = value;
            }
        }

        [DefaultValue("Fill"), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), Category("Deklarit Work With ")]
        public virtual string FillMethod
        {
            get
            {
                return this.DataGrid.FillMethod;
            }
            set
            {
                this.DataGrid.FillMethod = value;
            }
        }

        string Microsoft.Practices.CompositeUI.SmartParts.ISmartPartInfo.Description
        {
            get
            {
                return this.m_Description;
            }
            set
            {
                this.m_Description = value;
            }
        }

        string Microsoft.Practices.CompositeUI.SmartParts.ISmartPartInfo.Title
        {
            get
            {
                return this.m_Title;
            }
            set
            {
                this.m_Title = value;
            }
        }

        [DefaultValue(60), Category("Deklarit Work With ")]
        public virtual int PageSize
        {
            get
            {
                return this.DataGrid.PageSize;
            }
            set
            {
                this.DataGrid.PageSize = value;
            }
        }

        public string Title
        {
            get
            {
                return this.m_Title;
            }
            set
            {
                this.m_Title = value;
            }
        }
    }
}

