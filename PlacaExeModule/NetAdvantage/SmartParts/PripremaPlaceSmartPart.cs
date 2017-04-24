namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinDock;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinMaskedEdit;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
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
    public class PripremaPlaceSmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("_RSMObrazacAutoHideControl")]
        private AutoHideControl __RSMObrazacAutoHideControl;
        [AccessedThroughProperty("_RSMObrazacUnpinnedTabAreaBottom")]
        private UnpinnedTabArea __RSMObrazacUnpinnedTabAreaBottom;
        [AccessedThroughProperty("_RSMObrazacUnpinnedTabAreaLeft")]
        private UnpinnedTabArea __RSMObrazacUnpinnedTabAreaLeft;
        [AccessedThroughProperty("_RSMObrazacUnpinnedTabAreaRight")]
        private UnpinnedTabArea __RSMObrazacUnpinnedTabAreaRight;
        [AccessedThroughProperty("_RSMObrazacUnpinnedTabAreaTop")]
        private UnpinnedTabArea __RSMObrazacUnpinnedTabAreaTop;
        [AccessedThroughProperty("adresa")]
        private UltraMaskedEdit _adresa;
        [AccessedThroughProperty("brojosiguranika")]
        private UltraMaskedEdit _brojosiguranika;
        [AccessedThroughProperty("BROJSTRANICA")]
        private UltraNumericEditor _BROJSTRANICA;
        [AccessedThroughProperty("DockableWindow1")]
        private DockableWindow _DockableWindow1;
        [AccessedThroughProperty("DockableWindow2")]
        private DockableWindow _DockableWindow2;
        [AccessedThroughProperty("DockableWindow3")]
        private DockableWindow _DockableWindow3;
        [AccessedThroughProperty("ElementDataSet1")]
        private ELEMENTDataSet _ElementDataSet1;
        [AccessedThroughProperty("godinaisplate")]
        private UltraMaskedEdit _godinaisplate;
        [AccessedThroughProperty("GODINAOBRACUNA")]
        private UltraMaskedEdit _GODINAOBRACUNA;
        [AccessedThroughProperty("IDENTIFIKATOROBRASCA")]
        private UltraMaskedEdit _IDENTIFIKATOROBRASCA;
        [AccessedThroughProperty("iznosisplaceneplace")]
        private UltraMaskedEdit _iznosisplaceneplace;
        [AccessedThroughProperty("iznosobracunaneplace")]
        private UltraMaskedEdit _iznosobracunaneplace;
        [AccessedThroughProperty("iznososnovicezadoprinose")]
        private UltraMaskedEdit _iznososnovicezadoprinose;
        [AccessedThroughProperty("lblNazivVrsteObracuna")]
        private UltraLabel _lblNazivVrsteObracuna;
        [AccessedThroughProperty("lblNazivVrsteObveznika")]
        private UltraLabel _lblNazivVrsteObveznika;
        [AccessedThroughProperty("MBGOBVEZNIKA")]
        private UltraMaskedEdit _MBGOBVEZNIKA;
        [AccessedThroughProperty("MBOBVEZNIKA")]
        private UltraMaskedEdit _MBOBVEZNIKA;
        [AccessedThroughProperty("mio1")]
        private UltraMaskedEdit _mio1;
        [AccessedThroughProperty("mio2")]
        private UltraMaskedEdit _mio2;
        [AccessedThroughProperty("mjesecisplate")]
        private UltraMaskedEdit _mjesecisplate;
        [AccessedThroughProperty("MJESECOBRACUNA")]
        private UltraMaskedEdit _MJESECOBRACUNA;
        [AccessedThroughProperty("nazivobveznika")]
        private UltraMaskedEdit _nazivobveznika;
        [AccessedThroughProperty("PrplaceDataSet1")]
        private PRPLACEDataSet _PrplaceDataSet1;
        [AccessedThroughProperty("RadnikDataSet1")]
        private RADNIKDataSet _RadnikDataSet1;
        [AccessedThroughProperty("RsmaDataSet1")]
        private RSMADataSet _RsmaDataSet1;
        [AccessedThroughProperty("RsvrsteobracunaDataSet1")]
        private RSVRSTEOBRACUNADataSet _RsvrsteobracunaDataSet1;
        [AccessedThroughProperty("RsvrsteobveznikaDataSet1")]
        private RSVRSTEOBVEZNIKADataSet _RsvrsteobveznikaDataSet1;
        [AccessedThroughProperty("sifraobracuna")]
        private UltraMaskedEdit _sifraobracuna;
        [AccessedThroughProperty("ucboVrstaObracuna")]
        private UltraCombo _ucboVrstaObracuna;
        [AccessedThroughProperty("ucbVrstaObveznika")]
        private UltraCombo _ucbVrstaObveznika;
        [AccessedThroughProperty("UltraDockManager1")]
        private UltraDockManager _UltraDockManager1;
        [AccessedThroughProperty("UltraDropDown1")]
        private UltraDropDown _UltraDropDown1;
        [AccessedThroughProperty("UltraDropDown2")]
        private UltraDropDown _UltraDropDown2;
        [AccessedThroughProperty("UltraGrid1")]
        private UltraGrid _UltraGrid1;
        [AccessedThroughProperty("UltraGrid2")]
        private UltraGrid _UltraGrid2;
        [AccessedThroughProperty("UltraGrid3")]
        private UltraGrid _UltraGrid3;
        [AccessedThroughProperty("UltraGroupBox1")]
        private UltraGroupBox _UltraGroupBox1;
        [AccessedThroughProperty("UltraGroupBox2")]
        private UltraGroupBox _UltraGroupBox2;
        [AccessedThroughProperty("UltraGroupBox3")]
        private UltraGroupBox _UltraGroupBox3;
        [AccessedThroughProperty("UltraGroupBox4")]
        private UltraGroupBox _UltraGroupBox4;
        [AccessedThroughProperty("UltraLabel1")]
        private UltraLabel _UltraLabel1;
        [AccessedThroughProperty("UltraLabel10")]
        private UltraLabel _UltraLabel10;
        [AccessedThroughProperty("UltraLabel11")]
        private UltraLabel _UltraLabel11;
        [AccessedThroughProperty("UltraLabel12")]
        private UltraLabel _UltraLabel12;
        [AccessedThroughProperty("UltraLabel13")]
        private UltraLabel _UltraLabel13;
        [AccessedThroughProperty("UltraLabel14")]
        private UltraLabel _UltraLabel14;
        [AccessedThroughProperty("UltraLabel15")]
        private UltraLabel _UltraLabel15;
        [AccessedThroughProperty("UltraLabel16")]
        private UltraLabel _UltraLabel16;
        [AccessedThroughProperty("UltraLabel17")]
        private UltraLabel _UltraLabel17;
        [AccessedThroughProperty("UltraLabel18")]
        private UltraLabel _UltraLabel18;
        [AccessedThroughProperty("UltraLabel2")]
        private UltraLabel _UltraLabel2;
        [AccessedThroughProperty("UltraLabel3")]
        private UltraLabel _UltraLabel3;
        [AccessedThroughProperty("UltraLabel4")]
        private UltraLabel _UltraLabel4;
        [AccessedThroughProperty("UltraLabel5")]
        private UltraLabel _UltraLabel5;
        [AccessedThroughProperty("UltraLabel6")]
        private UltraLabel _UltraLabel6;
        [AccessedThroughProperty("UltraLabel7")]
        private UltraLabel _UltraLabel7;
        [AccessedThroughProperty("UltraLabel8")]
        private UltraLabel _UltraLabel8;
        [AccessedThroughProperty("UltraLabel9")]
        private UltraLabel _UltraLabel9;
        [AccessedThroughProperty("WindowDockingArea1")]
        private WindowDockingArea _WindowDockingArea1;
        [AccessedThroughProperty("WindowDockingArea2")]
        private WindowDockingArea _WindowDockingArea2;
        [AccessedThroughProperty("WindowDockingArea3")]
        private WindowDockingArea _WindowDockingArea3;
        private ELEMENTDataAdapter DAELEMENT;
        private KORISNIKDataAdapter dakorisnik;
        private PRPLACEDataAdapter dapriprema;
        private RadnikZaObracunDataAdapter daradnik;
        private RSMADataAdapter daRSM;
        private RSVRSTEOBRACUNADataAdapter darsvrsteobracuna;
        private RSVRSTEOBVEZNIKADataAdapter darsvrsteobveznika;
        private KORISNIKDataSet dskorisnik;
        private frmPregledObracuna frm;
        private SmartPartInfoProvider infoProvider;
        private SmartPartInfo smartPartInfo1;

        public PripremaPlaceSmartPart()
        {
            base.Load += new EventHandler(this.PripremaSmartPart_Load);
            this.darsvrsteobveznika = new RSVRSTEOBVEZNIKADataAdapter();
            this.darsvrsteobracuna = new RSVRSTEOBRACUNADataAdapter();
            this.dakorisnik = new KORISNIKDataAdapter();
            this.dskorisnik = new KORISNIKDataSet();
            this.daRSM = new RSMADataAdapter();
            this.dapriprema = new PRPLACEDataAdapter();
            this.DAELEMENT = new ELEMENTDataAdapter();
            this.daradnik = new RadnikZaObracunDataAdapter();
            this.smartPartInfo1 = new SmartPartInfo("PripremaPlace", "PripremaSmartpart");
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("PRPLACEPRPLACEELEMENTI", -1);
            UltraGridColumn column = new UltraGridColumn("PRPLACEZAMJESEC");
            UltraGridColumn column108 = new UltraGridColumn("PRPLACEZAGODINU");
            UltraGridColumn column119 = new UltraGridColumn("IDELEMENT", -1, "UltraDropDown2");
            UltraGridColumn column130 = new UltraGridColumn("NAZIVELEMENT");
            UltraGridColumn column141 = new UltraGridColumn("POSTOTAK");
            UltraGridColumn column152 = new UltraGridColumn("PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK");
            UltraGridBand band5 = new UltraGridBand("PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK", 0);
            UltraGridColumn column163 = new UltraGridColumn("PRPLACEZAMJESEC");
            UltraGridColumn column174 = new UltraGridColumn("PRPLACEZAGODINU");
            UltraGridColumn column185 = new UltraGridColumn("IDELEMENT");
            UltraGridColumn column2 = new UltraGridColumn("IDRADNIK", -1, "UltraDropDown1");
            UltraGridColumn column13 = new UltraGridColumn("PRPLACEODDATUMA");
            UltraGridColumn column24 = new UltraGridColumn("PRPLACEDODATUMA");
            UltraGridColumn column35 = new UltraGridColumn("PRPLACESATI");
            UltraGridColumn column46 = new UltraGridColumn("PRPLACESATNICA");
            UltraGridColumn column57 = new UltraGridColumn("PRPLACEPOSTOTAK");
            UltraGridColumn column68 = new UltraGridColumn("PRPLACEIZNOS");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            UltraGridBand band6 = new UltraGridBand("PRPLACEPRPLACEELEMENTIRADNIK", -1);
            UltraGridColumn column79 = new UltraGridColumn("PRPLACEZAMJESEC");
            UltraGridColumn column90 = new UltraGridColumn("PRPLACEZAGODINU");
            UltraGridColumn column101 = new UltraGridColumn("IDELEMENT");
            UltraGridColumn column109 = new UltraGridColumn("IDRADNIK", -1, "UltraDropDown1");
            UltraGridColumn column110 = new UltraGridColumn("PRPLACEODDATUMA");
            UltraGridColumn column111 = new UltraGridColumn("PRPLACEDODATUMA");
            UltraGridColumn column112 = new UltraGridColumn("PRPLACESATI");
            UltraGridColumn column113 = new UltraGridColumn("PRPLACESATNICA");
            UltraGridColumn column114 = new UltraGridColumn("PRPLACEPOSTOTAK");
            UltraGridColumn column115 = new UltraGridColumn("PRPLACEIZNOS");
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            UltraGridBand band7 = new UltraGridBand("RADNIK", -1);
            UltraGridColumn column116 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column117 = new UltraGridColumn("AKTIVAN");
            UltraGridColumn column118 = new UltraGridColumn("PREZIME");
            UltraGridColumn column120 = new UltraGridColumn("IME");
            UltraGridColumn column121 = new UltraGridColumn("JMBG");
            UltraGridColumn column122 = new UltraGridColumn("DATUMRODJENJA");
            UltraGridColumn column123 = new UltraGridColumn("ulica");
            UltraGridColumn column124 = new UltraGridColumn("mjesto");
            UltraGridColumn column125 = new UltraGridColumn("kucnibroj");
            UltraGridColumn column126 = new UltraGridColumn("OPCINARADAIDOPCINE");
            UltraGridColumn column127 = new UltraGridColumn("OPCINARADANAZIVOPCINE");
            UltraGridColumn column128 = new UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            UltraGridColumn column129 = new UltraGridColumn("OPCINASTANOVANJANAZIVOPCINE");
            UltraGridColumn column131 = new UltraGridColumn("OPCINASTANOVANJAPRIREZ");
            UltraGridColumn column132 = new UltraGridColumn("OPCINASTANOVANJAVBDIOPCINA");
            UltraGridColumn column133 = new UltraGridColumn("OPCINASTANOVANJAZRNOPCINA");
            UltraGridColumn column134 = new UltraGridColumn("RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA");
            UltraGridColumn column135 = new UltraGridColumn("RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA");
            UltraGridColumn column136 = new UltraGridColumn("IDBANKE");
            UltraGridColumn column137 = new UltraGridColumn("NAZIVBANKE1");
            UltraGridColumn column138 = new UltraGridColumn("NAZIVBANKE2");
            UltraGridColumn column139 = new UltraGridColumn("NAZIVBANKE3");
            UltraGridColumn column140 = new UltraGridColumn("VBDIBANKE");
            UltraGridColumn column142 = new UltraGridColumn("ZRNBANKE");
            UltraGridColumn column143 = new UltraGridColumn("TEKUCI");
            UltraGridColumn column144 = new UltraGridColumn("ZBIRNINETO");
            UltraGridColumn column145 = new UltraGridColumn("SIFRAOPISAPLACANJANETO");
            UltraGridColumn column146 = new UltraGridColumn("OPISPLACANJANETO");
            UltraGridColumn column147 = new UltraGridColumn("TJEDNIFONDSATI");
            UltraGridColumn column148 = new UltraGridColumn("KOEFICIJENT");
            UltraGridColumn column149 = new UltraGridColumn("POSTOTAKOSLOBODJENJAODPOREZA");
            UltraGridColumn column150 = new UltraGridColumn("UZIMAUOBZIROSNOVICEDOPRINOSA");
            UltraGridColumn column151 = new UltraGridColumn("TJEDNIFONDSATISTAZ");
            UltraGridColumn column153 = new UltraGridColumn("DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI");
            UltraGridColumn column154 = new UltraGridColumn("GODINESTAZA");
            UltraGridColumn column155 = new UltraGridColumn("MJESECISTAZA");
            UltraGridColumn column156 = new UltraGridColumn("DANISTAZA");
            UltraGridColumn column157 = new UltraGridColumn("IDBENEFICIRANI");
            UltraGridColumn column158 = new UltraGridColumn("NAZIVBENEFICIRANI");
            UltraGridColumn column159 = new UltraGridColumn("DATUMPRESTANKARADNOGODNOSA");
            UltraGridColumn column160 = new UltraGridColumn("BROJMIROVINSKOG");
            UltraGridColumn column161 = new UltraGridColumn("BROJZDRAVSTVENOG");
            UltraGridColumn column162 = new UltraGridColumn("MBO");
            UltraGridColumn column164 = new UltraGridColumn("IDTITULA");
            UltraGridColumn column165 = new UltraGridColumn("NAZIVTITULA");
            UltraGridColumn column166 = new UltraGridColumn("IDRADNOMJESTO");
            UltraGridColumn column167 = new UltraGridColumn("NAZIVRADNOMJESTO");
            UltraGridColumn column168 = new UltraGridColumn("TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA");
            UltraGridColumn column169 = new UltraGridColumn("TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA");
            UltraGridColumn column170 = new UltraGridColumn("POTREBNASTRUCNASPREMAIDSTRUCNASPREMA");
            UltraGridColumn column171 = new UltraGridColumn("POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA");
            UltraGridColumn column172 = new UltraGridColumn("IDSTRUKA");
            UltraGridColumn column173 = new UltraGridColumn("NAZIVSTRUKA");
            UltraGridColumn column175 = new UltraGridColumn("IDBRACNOSTANJE");
            UltraGridColumn column176 = new UltraGridColumn("NAZIVBRACNOSTANJE");
            UltraGridColumn column177 = new UltraGridColumn("IDORGDIO");
            UltraGridColumn column178 = new UltraGridColumn("ORGANIZACIJSKIDIO");
            UltraGridColumn column179 = new UltraGridColumn("OIB");
            UltraGridColumn column180 = new UltraGridColumn("UKUPNOGODINESTAZA");
            UltraGridColumn column181 = new UltraGridColumn("UKUPNOMJESECISTAZA");
            UltraGridColumn column182 = new UltraGridColumn("UKUPNODANASTAZA");
            UltraGridColumn column183 = new UltraGridColumn("BROJPRIZNATIHMJESECI");
            UltraGridColumn column184 = new UltraGridColumn("IDSPOL");
            UltraGridColumn column186 = new UltraGridColumn("NAZIVSPOL");
            UltraGridColumn column187 = new UltraGridColumn("IDIPIDENT");
            UltraGridColumn column188 = new UltraGridColumn("NAZIVIPIDENT");
            UltraGridColumn column189 = new UltraGridColumn("RADNIK_RADNIKLevel7");
            UltraGridColumn column190 = new UltraGridColumn("RADNIK_RADNIKObustava");
            UltraGridColumn column191 = new UltraGridColumn("RADNIK_RADNIKNeto");
            UltraGridColumn column192 = new UltraGridColumn("RADNIK_RADNIKBruto");
            UltraGridColumn column193 = new UltraGridColumn("RADNIK_RADNIKKrediti");
            UltraGridColumn column194 = new UltraGridColumn("RADNIK_RADNIKOlaksica");
            UltraGridColumn column195 = new UltraGridColumn("RADNIK_RADNIKOdbitak");
            UltraGridBand band8 = new UltraGridBand("RADNIK_RADNIKLevel7", 0);
            UltraGridColumn column3 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column4 = new UltraGridColumn("IDGRUPEKOEF");
            UltraGridColumn column5 = new UltraGridColumn("NAZIVGRUPEKOEF");
            UltraGridColumn column6 = new UltraGridColumn("DODATNIKOEFICIJENT");
            UltraGridBand band9 = new UltraGridBand("RADNIK_RADNIKObustava", 0);
            UltraGridColumn column7 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column8 = new UltraGridColumn("ZADOBUSTAVAIDOBUSTAVA");
            UltraGridColumn column9 = new UltraGridColumn("OBUSTAVAAKTIVNA");
            UltraGridColumn column10 = new UltraGridColumn("ZADOBUSTAVANAZIVOBUSTAVA");
            UltraGridColumn column11 = new UltraGridColumn("ZADOBUSTAVAVRSTAOBUSTAVE");
            UltraGridColumn column12 = new UltraGridColumn("ZADOBUSTAVANAZIVVRSTAOBUSTAVE");
            UltraGridColumn column14 = new UltraGridColumn("ZADIZNOSOBUSTAVE");
            UltraGridColumn column15 = new UltraGridColumn("ZADPOSTOTAKOBUSTAVE");
            UltraGridColumn column16 = new UltraGridColumn("ZADISPLACENOKASA");
            UltraGridColumn column17 = new UltraGridColumn("ZADSALDOKASA");
            UltraGridColumn column18 = new UltraGridColumn("OTPLACENIIZNOS");
            UltraGridColumn column19 = new UltraGridColumn("OTPLACENIBROJRATA");
            UltraGridColumn column20 = new UltraGridColumn("ZADOBUSTAVAZRNOBUSTAVA");
            UltraGridColumn column21 = new UltraGridColumn("ZADOBUSTAVAVBDIOBUSTAVA");
            UltraGridBand band10 = new UltraGridBand("RADNIK_RADNIKNeto", 0);
            UltraGridColumn column22 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column23 = new UltraGridColumn("NETOELEMENTIDELEMENT");
            UltraGridColumn column25 = new UltraGridColumn("NETOELEMENTNAZIVELEMENT");
            UltraGridColumn column26 = new UltraGridColumn("NETOSATNICA");
            UltraGridColumn column27 = new UltraGridColumn("NETOSATI");
            UltraGridColumn column28 = new UltraGridColumn("NETOPOSTOTAK");
            UltraGridColumn column29 = new UltraGridColumn("NETOIZNOS");
            UltraGridBand band11 = new UltraGridBand("RADNIK_RADNIKBruto", 0);
            UltraGridColumn column30 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column31 = new UltraGridColumn("BRUTOELEMENTIDELEMENT");
            UltraGridColumn column32 = new UltraGridColumn("BRUTOELEMENTNAZIVELEMENT");
            UltraGridColumn column33 = new UltraGridColumn("BRUTOSATNICA");
            UltraGridColumn column34 = new UltraGridColumn("BRUTOSATI");
            UltraGridColumn column36 = new UltraGridColumn("BRUTOPOSTOTAK");
            UltraGridColumn column37 = new UltraGridColumn("BRUTOIZNOS");
            UltraGridColumn column38 = new UltraGridColumn("BRUTOELEMENTPOSTOTAK");
            UltraGridBand band12 = new UltraGridBand("RADNIK_RADNIKKrediti", 0);
            UltraGridColumn column39 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column40 = new UltraGridColumn("ZADKREDITIIDKREDITOR");
            UltraGridColumn column41 = new UltraGridColumn("DatumUgovora");
            UltraGridColumn column42 = new UltraGridColumn("KREDITAKTIVAN");
            UltraGridColumn column43 = new UltraGridColumn("ZADKREDITINAZIVKREDITOR");
            UltraGridColumn column44 = new UltraGridColumn("ZADKREDITIPRIMATELJKREDITOR1");
            UltraGridColumn column45 = new UltraGridColumn("ZADKREDITIPRIMATELJKREDITOR2");
            UltraGridColumn column47 = new UltraGridColumn("ZADKREDITIPRIMATELJKREDITOR3");
            UltraGridColumn column48 = new UltraGridColumn("SIFRAOPISAPLACANJAKREDITOR");
            UltraGridColumn column49 = new UltraGridColumn("OPISPLACANJAKREDITOR");
            UltraGridColumn column50 = new UltraGridColumn("MOKREDITOR");
            UltraGridColumn column51 = new UltraGridColumn("POKREDITOR");
            UltraGridColumn column52 = new UltraGridColumn("MZKREDITOR");
            UltraGridColumn column53 = new UltraGridColumn("PZKREDITOR");
            UltraGridColumn column54 = new UltraGridColumn("ZADIZNOSRATEKREDITA");
            UltraGridColumn column55 = new UltraGridColumn("ZADBROJRATAOBUSTAVE");
            UltraGridColumn column56 = new UltraGridColumn("ZADUKUPNIZNOSKREDITA");
            UltraGridColumn column58 = new UltraGridColumn("ZADVECOTPLACENOBROJRATA");
            UltraGridColumn column59 = new UltraGridColumn("ZADVECOTPLACENOUKUPNIIZNOS");
            UltraGridColumn column60 = new UltraGridColumn("KREDITOTPLACENIIZNOS");
            UltraGridColumn column61 = new UltraGridColumn("KREDITOTPLACENORATA");
            UltraGridColumn column62 = new UltraGridColumn("ZADKREDITIVBDIKREDITOR");
            UltraGridColumn column63 = new UltraGridColumn("ZADKREDITIZRNKREDITOR");
            UltraGridBand band2 = new UltraGridBand("RADNIK_RADNIKOlaksica", 0);
            UltraGridColumn column64 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column65 = new UltraGridColumn("ZADOLAKSICEIDOLAKSICE");
            UltraGridColumn column66 = new UltraGridColumn("ZADOLAKSICEIDGRUPEOLAKSICA");
            UltraGridColumn column67 = new UltraGridColumn("ZADOLAKSICEMAXIMALNIIZNOSGRUPE");
            UltraGridColumn column69 = new UltraGridColumn("ZADOLAKSICENAZIVGRUPEOLAKSICA");
            UltraGridColumn column70 = new UltraGridColumn("ZADOLAKSICENAZIVOLAKSICE");
            UltraGridColumn column71 = new UltraGridColumn("ZADOLAKSICEIDTIPOLAKSICE");
            UltraGridColumn column72 = new UltraGridColumn("ZADOLAKSICENAZIVTIPOLAKSICE");
            UltraGridColumn column73 = new UltraGridColumn("ZADOLAKSICEVBDIOLAKSICA");
            UltraGridColumn column74 = new UltraGridColumn("ZADOLAKSICEZRNOLAKSICA");
            UltraGridColumn column75 = new UltraGridColumn("ZADOLAKSICEPRIMATELJOLAKSICA1");
            UltraGridColumn column76 = new UltraGridColumn("ZADOLAKSICEPRIMATELJOLAKSICA2");
            UltraGridColumn column77 = new UltraGridColumn("ZADOLAKSICEPRIMATELJOLAKSICA3");
            UltraGridColumn column78 = new UltraGridColumn("ZADMZOLAKSICE");
            UltraGridColumn column80 = new UltraGridColumn("ZADPZOLAKSICE");
            UltraGridColumn column81 = new UltraGridColumn("ZADMOOLAKSICE");
            UltraGridColumn column82 = new UltraGridColumn("ZADPOOLAKSICE");
            UltraGridColumn column83 = new UltraGridColumn("ZADSIFRAOPISAPLACANJAOLAKSICE");
            UltraGridColumn column84 = new UltraGridColumn("ZADOPISPLACANJAOLAKSICE");
            UltraGridColumn column85 = new UltraGridColumn("ZADIZNOSOLAKSICE");
            UltraGridBand band3 = new UltraGridBand("RADNIK_RADNIKOdbitak", 0);
            UltraGridColumn column86 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column87 = new UltraGridColumn("OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK");
            UltraGridColumn column88 = new UltraGridColumn("NAZIVOSOBNIODBITAK");
            UltraGridColumn column89 = new UltraGridColumn("FAKTOROSOBNOGODBITKA");
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            UltraGridBand band4 = new UltraGridBand("ELEMENT", -1);
            UltraGridColumn column91 = new UltraGridColumn("IDELEMENT", -1, null, 0, SortIndicator.Descending, false);
            UltraGridColumn column92 = new UltraGridColumn("NAZIVELEMENT");
            UltraGridColumn column93 = new UltraGridColumn("IDVRSTAELEMENTA");
            UltraGridColumn column94 = new UltraGridColumn("NAZIVVRSTAELEMENT");
            UltraGridColumn column95 = new UltraGridColumn("IDOSNOVAOSIGURANJA");
            UltraGridColumn column96 = new UltraGridColumn("NAZIVOSNOVAOSIGURANJA");
            UltraGridColumn column97 = new UltraGridColumn("RAZDOBLJESESMIJEPREKLAPATI");
            UltraGridColumn column98 = new UltraGridColumn("POSTOTAK");
            UltraGridColumn column99 = new UltraGridColumn("ZBRAJASATEUFONDSATI");
            UltraGridColumn column100 = new UltraGridColumn("MOELEMENT");
            UltraGridColumn column102 = new UltraGridColumn("POELEMENT");
            UltraGridColumn column103 = new UltraGridColumn("MZELEMENT");
            UltraGridColumn column104 = new UltraGridColumn("PZELEMENT");
            UltraGridColumn column105 = new UltraGridColumn("SIFRAOPISAPLACANJAELEMENT");
            UltraGridColumn column106 = new UltraGridColumn("OPISPLACANJAELEMENT");
            UltraGridColumn column107 = new UltraGridColumn("POSTAVLJAMZPZSVIMVIRMANIMA");
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            this.UltraGroupBox4 = new UltraGroupBox();
            this.UltraGrid2 = new UltraGrid();
            this.PrplaceDataSet1 = new PRPLACEDataSet();
            this.UltraGrid3 = new UltraGrid();
            this.RadnikDataSet1 = new RADNIKDataSet();
            this.ElementDataSet1 = new ELEMENTDataSet();
            this.UltraDropDown1 = new UltraDropDown();
            this.UltraDropDown2 = new UltraDropDown();
            ((ISupportInitialize) this.UltraGroupBox4).BeginInit();
            ((ISupportInitialize) this.UltraGrid2).BeginInit();
            this.PrplaceDataSet1.BeginInit();
            ((ISupportInitialize) this.UltraGrid3).BeginInit();
            this.RadnikDataSet1.BeginInit();
            this.ElementDataSet1.BeginInit();
            ((ISupportInitialize) this.UltraDropDown1).BeginInit();
            ((ISupportInitialize) this.UltraDropDown2).BeginInit();
            this.SuspendLayout();
            System.Drawing.Point point = new System.Drawing.Point(3, 3);
            this.UltraGroupBox4.Location = point;
            this.UltraGroupBox4.Name = "UltraGroupBox4";
            Size size = new System.Drawing.Size(200, 110);
            this.UltraGroupBox4.Size = size;
            this.UltraGroupBox4.TabIndex = 0;
            this.UltraGroupBox4.Text = "UltraGroupBox4";
            this.UltraGrid2.DataMember = "PRPLACEPRPLACEELEMENTI";
            this.UltraGrid2.DataSource = this.PrplaceDataSet1;
            appearance6.BackColor = Color.White;
            this.UltraGrid2.DisplayLayout.Appearance = appearance6;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.Header.VisiblePosition = 0;
            column.Hidden = true;
            column108.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column108.Header.VisiblePosition = 1;
            column108.Hidden = true;
            column119.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column119.Header.VisiblePosition = 2;
            column130.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column130.Header.VisiblePosition = 3;
            column130.Width = 220;
            column141.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column141.Header.VisiblePosition = 4;
            column152.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column152.Header.VisiblePosition = 5;
            band.Columns.AddRange(new object[] { column, column108, column119, column130, column141, column152 });
            column163.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column163.Header.VisiblePosition = 0;
            column174.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column174.Header.VisiblePosition = 1;
            column185.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column185.Header.VisiblePosition = 2;
            column185.Width = 220;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column2.Header.VisiblePosition = 3;
            column13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column13.Header.VisiblePosition = 4;
            column24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column24.Header.VisiblePosition = 5;
            column35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column35.Header.VisiblePosition = 6;
            column46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column46.Header.VisiblePosition = 7;
            column57.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column57.Header.VisiblePosition = 8;
            column68.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column68.Header.VisiblePosition = 9;
            band5.Columns.AddRange(new object[] { column163, column174, column185, column2, column13, column24, column35, column46, column57, column68 });
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(band5);
            this.UltraGrid2.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.UltraGrid2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraGrid2.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            this.UltraGrid2.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance7.BackColor = Color.Transparent;
            this.UltraGrid2.DisplayLayout.Override.CardAreaAppearance = appearance7;
            this.UltraGrid2.DisplayLayout.Override.CellPadding = 3;
            appearance8.TextHAlignAsString = "Left";
            this.UltraGrid2.DisplayLayout.Override.HeaderAppearance = appearance8;
            appearance9.BorderColor = Color.LightGray;
            appearance9.TextVAlignAsString = "Middle";
            this.UltraGrid2.DisplayLayout.Override.RowAppearance = appearance9;
            appearance10.BackColor = Color.LightSteelBlue;
            appearance10.BorderColor = Color.Black;
            appearance10.ForeColor = Color.Black;
            this.UltraGrid2.DisplayLayout.Override.SelectedRowAppearance = appearance10;
            this.UltraGrid2.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.UltraGrid2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(3, 0x77);
            this.UltraGrid2.Location = point;
            this.UltraGrid2.Name = "UltraGrid2";
            size = new System.Drawing.Size(0x24f, 0xe4);
            this.UltraGrid2.Size = size;
            this.UltraGrid2.TabIndex = 1;
            this.PrplaceDataSet1.DataSetName = "PRPLACEDataSet";
            this.UltraGrid3.DataMember = "PRPLACEPRPLACEELEMENTI.PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK";
            this.UltraGrid3.DataSource = this.PrplaceDataSet1;
            appearance30.BackColor = Color.White;
            this.UltraGrid3.DisplayLayout.Appearance = appearance30;
            column79.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column79.Header.VisiblePosition = 0;
            column79.Hidden = true;
            column90.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column90.Header.VisiblePosition = 1;
            column90.Hidden = true;
            column101.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column101.Header.VisiblePosition = 2;
            column101.Hidden = true;
            column109.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column109.Header.VisiblePosition = 3;
            column109.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column110.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column110.Header.VisiblePosition = 4;
            column111.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column111.Header.VisiblePosition = 5;
            column112.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column112.Format = "";
            column112.Header.VisiblePosition = 6;
            column112.MaskInput = "{LOC} n,nnn,nnn.nn";
            column113.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column113.Format = "";
            column113.Header.VisiblePosition = 7;
            column113.MaskInput = "{LOC} n,nnn,nnn.nn";
            column114.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column114.Format = "";
            column114.Header.VisiblePosition = 8;
            column114.MaskInput = "{LOC} n,nnn,nnn.nn";
            column115.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column115.Header.VisiblePosition = 9;
            band6.Columns.AddRange(new object[] { column79, column90, column101, column109, column110, column111, column112, column113, column114, column115 });
            this.UltraGrid3.DisplayLayout.BandsSerializer.Add(band6);
            this.UltraGrid3.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.UltraGrid3.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True;
            this.UltraGrid3.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True;
            this.UltraGrid3.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance31.BackColor = Color.Transparent;
            this.UltraGrid3.DisplayLayout.Override.CardAreaAppearance = appearance31;
            this.UltraGrid3.DisplayLayout.Override.CellPadding = 3;
            appearance32.TextHAlignAsString = "Left";
            this.UltraGrid3.DisplayLayout.Override.HeaderAppearance = appearance32;
            appearance33.BorderColor = Color.LightGray;
            appearance33.TextVAlignAsString = "Middle";
            this.UltraGrid3.DisplayLayout.Override.RowAppearance = appearance33;
            appearance34.BackColor = Color.LightSteelBlue;
            appearance34.BorderColor = Color.Black;
            appearance34.ForeColor = Color.Black;
            this.UltraGrid3.DisplayLayout.Override.SelectedRowAppearance = appearance34;
            this.UltraGrid3.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            point = new System.Drawing.Point(3, 0x161);
            this.UltraGrid3.Location = point;
            this.UltraGrid3.Name = "UltraGrid3";
            size = new System.Drawing.Size(0x365, 0xe4);
            this.UltraGrid3.Size = size;
            this.UltraGrid3.TabIndex = 2;
            this.RadnikDataSet1.DataSetName = "RADNIKDataSet";
            this.ElementDataSet1.DataSetName = "ELEMENTDataSet";
            this.UltraDropDown1.DataMember = "RADNIK";
            this.UltraDropDown1.DataSource = this.RadnikDataSet1;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            appearance18.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.UltraDropDown1.DisplayLayout.Appearance = appearance18;
            column116.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column116.Header.VisiblePosition = 0;
            column117.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column117.Header.VisiblePosition = 1;
            column118.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column118.Header.VisiblePosition = 2;
            column120.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column120.Header.VisiblePosition = 3;
            column121.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column121.Header.VisiblePosition = 4;
            column122.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column122.Header.VisiblePosition = 5;
            column123.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column123.Header.VisiblePosition = 6;
            column124.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column124.Header.VisiblePosition = 7;
            column125.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column125.Header.VisiblePosition = 8;
            column126.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column126.Header.VisiblePosition = 9;
            column127.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column127.Header.VisiblePosition = 10;
            column128.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column128.Header.VisiblePosition = 11;
            column129.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column129.Header.VisiblePosition = 12;
            column131.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column131.Header.VisiblePosition = 13;
            column132.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column132.Header.VisiblePosition = 14;
            column133.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column133.Header.VisiblePosition = 15;
            column134.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column134.Header.VisiblePosition = 0x10;
            column135.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column135.Header.VisiblePosition = 0x11;
            column136.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column136.Header.VisiblePosition = 0x12;
            column137.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column137.Header.VisiblePosition = 0x13;
            column138.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column138.Header.VisiblePosition = 20;
            column139.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column139.Header.VisiblePosition = 0x15;
            column140.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column140.Header.VisiblePosition = 0x16;
            column142.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column142.Header.VisiblePosition = 0x17;
            column143.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column143.Header.VisiblePosition = 0x18;
            column144.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column144.Header.VisiblePosition = 0x19;
            column145.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column145.Header.VisiblePosition = 0x1a;
            column146.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column146.Header.VisiblePosition = 0x1b;
            column147.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column147.Header.VisiblePosition = 0x1c;
            column148.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column148.Header.VisiblePosition = 0x1d;
            column149.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column149.Header.VisiblePosition = 30;
            column150.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column150.Header.VisiblePosition = 0x1f;
            column151.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column151.Header.VisiblePosition = 0x20;
            column153.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column153.Header.VisiblePosition = 0x21;
            column154.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column154.Header.VisiblePosition = 0x22;
            column155.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column155.Header.VisiblePosition = 0x23;
            column156.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column156.Header.VisiblePosition = 0x24;
            column157.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column157.Header.VisiblePosition = 0x25;
            column158.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column158.Header.VisiblePosition = 0x26;
            column159.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column159.Header.VisiblePosition = 0x27;
            column160.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column160.Header.VisiblePosition = 40;
            column161.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column161.Header.VisiblePosition = 0x29;
            column162.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column162.Header.VisiblePosition = 0x2a;
            column164.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column164.Header.VisiblePosition = 0x2b;
            column165.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column165.Header.VisiblePosition = 0x2c;
            column166.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column166.Header.VisiblePosition = 0x2d;
            column167.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column167.Header.VisiblePosition = 0x2e;
            column168.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column168.Header.VisiblePosition = 0x2f;
            column169.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column169.Header.VisiblePosition = 0x30;
            column170.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column170.Header.VisiblePosition = 0x31;
            column171.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column171.Header.VisiblePosition = 50;
            column172.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column172.Header.VisiblePosition = 0x33;
            column173.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column173.Header.VisiblePosition = 0x34;
            column175.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column175.Header.VisiblePosition = 0x35;
            column176.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column176.Header.VisiblePosition = 0x36;
            column177.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column177.Header.VisiblePosition = 0x37;
            column178.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column178.Header.VisiblePosition = 0x38;
            column179.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column179.Header.VisiblePosition = 0x39;
            column180.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column180.Header.VisiblePosition = 0x3a;
            column181.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column181.Header.VisiblePosition = 0x3b;
            column182.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column182.Header.VisiblePosition = 60;
            column183.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column183.Header.VisiblePosition = 0x3d;
            column184.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column184.Header.VisiblePosition = 0x3e;
            column186.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column186.Header.VisiblePosition = 0x3f;
            column187.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column187.Header.VisiblePosition = 0x40;
            column188.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column188.Header.VisiblePosition = 0x41;
            column189.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column189.Header.VisiblePosition = 0x42;
            column190.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column190.Header.VisiblePosition = 0x43;
            column191.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column191.Header.VisiblePosition = 0x44;
            column192.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column192.Header.VisiblePosition = 0x45;
            column193.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column193.Header.VisiblePosition = 70;
            column194.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column194.Header.VisiblePosition = 0x47;
            column195.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column195.Header.VisiblePosition = 0x48;
            band7.Columns.AddRange(new object[] { 
                column116, column117, column118, column120, column121, column122, column123, column124, column125, column126, column127, column128, column129, column131, column132, column133, 
                column134, column135, column136, column137, column138, column139, column140, column142, column143, column144, column145, column146, column147, column148, column149, column150, 
                column151, column153, column154, column155, column156, column157, column158, column159, column160, column161, column162, column164, column165, column166, column167, column168, 
                column169, column170, column171, column172, column173, column175, column176, column177, column178, column179, column180, column181, column182, column183, column184, column186, 
                column187, column188, column189, column190, column191, column192, column193, column194, column195
             });
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column3.Header.VisiblePosition = 0;
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column4.Header.VisiblePosition = 1;
            column5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column5.Header.VisiblePosition = 2;
            column6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column6.Header.VisiblePosition = 3;
            band8.Columns.AddRange(new object[] { column3, column4, column5, column6 });
            column7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column7.Header.VisiblePosition = 0;
            column8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column8.Header.VisiblePosition = 1;
            column9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column9.Header.VisiblePosition = 2;
            column10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column10.Header.VisiblePosition = 3;
            column11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column11.Header.VisiblePosition = 4;
            column12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column12.Header.VisiblePosition = 5;
            column14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column14.Header.VisiblePosition = 6;
            column15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column15.Header.VisiblePosition = 7;
            column16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column16.Header.VisiblePosition = 8;
            column17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column17.Header.VisiblePosition = 9;
            column18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column18.Header.VisiblePosition = 10;
            column19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column19.Header.VisiblePosition = 11;
            column20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column20.Header.VisiblePosition = 12;
            column21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column21.Header.VisiblePosition = 13;
            band9.Columns.AddRange(new object[] { column7, column8, column9, column10, column11, column12, column14, column15, column16, column17, column18, column19, column20, column21 });
            column22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column22.Header.VisiblePosition = 0;
            column23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column23.Header.VisiblePosition = 1;
            column25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column25.Header.VisiblePosition = 2;
            column26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column26.Header.VisiblePosition = 3;
            column27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column27.Header.VisiblePosition = 4;
            column28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column28.Header.VisiblePosition = 5;
            column29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column29.Header.VisiblePosition = 6;
            band10.Columns.AddRange(new object[] { column22, column23, column25, column26, column27, column28, column29 });
            column30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column30.Header.VisiblePosition = 0;
            column31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column31.Header.VisiblePosition = 1;
            column32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column32.Header.VisiblePosition = 2;
            column33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column33.Header.VisiblePosition = 3;
            column34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column34.Header.VisiblePosition = 4;
            column36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column36.Header.VisiblePosition = 5;
            column37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column37.Header.VisiblePosition = 6;
            column38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column38.Header.VisiblePosition = 7;
            band11.Columns.AddRange(new object[] { column30, column31, column32, column33, column34, column36, column37, column38 });
            column39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column39.Header.VisiblePosition = 0;
            column40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column40.Header.VisiblePosition = 1;
            column41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column41.Header.VisiblePosition = 2;
            column42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column42.Header.VisiblePosition = 3;
            column43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column43.Header.VisiblePosition = 4;
            column44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column44.Header.VisiblePosition = 5;
            column45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column45.Header.VisiblePosition = 6;
            column47.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column47.Header.VisiblePosition = 7;
            column48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column48.Header.VisiblePosition = 8;
            column49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column49.Header.VisiblePosition = 9;
            column50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column50.Header.VisiblePosition = 10;
            column51.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column51.Header.VisiblePosition = 11;
            column52.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column52.Header.VisiblePosition = 12;
            column53.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column53.Header.VisiblePosition = 13;
            column54.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column54.Header.VisiblePosition = 14;
            column55.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column55.Header.VisiblePosition = 15;
            column56.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column56.Header.VisiblePosition = 0x10;
            column58.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column58.Header.VisiblePosition = 0x11;
            column59.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column59.Header.VisiblePosition = 0x12;
            column60.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column60.Header.VisiblePosition = 0x13;
            column61.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column61.Header.VisiblePosition = 20;
            column62.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column62.Header.VisiblePosition = 0x15;
            column63.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column63.Header.VisiblePosition = 0x16;
            band12.Columns.AddRange(new object[] { 
                column39, column40, column41, column42, column43, column44, column45, column47, column48, column49, column50, column51, column52, column53, column54, column55, 
                column56, column58, column59, column60, column61, column62, column63
             });
            column64.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column64.Header.VisiblePosition = 0;
            column65.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column65.Header.VisiblePosition = 1;
            column66.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column66.Header.VisiblePosition = 2;
            column67.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column67.Header.VisiblePosition = 3;
            column69.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column69.Header.VisiblePosition = 4;
            column70.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column70.Header.VisiblePosition = 5;
            column71.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column71.Header.VisiblePosition = 6;
            column72.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column72.Header.VisiblePosition = 7;
            column73.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column73.Header.VisiblePosition = 8;
            column74.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column74.Header.VisiblePosition = 9;
            column75.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column75.Header.VisiblePosition = 10;
            column76.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column76.Header.VisiblePosition = 11;
            column77.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column77.Header.VisiblePosition = 12;
            column78.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column78.Header.VisiblePosition = 13;
            column80.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column80.Header.VisiblePosition = 14;
            column81.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column81.Header.VisiblePosition = 15;
            column82.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column82.Header.VisiblePosition = 0x10;
            column83.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column83.Header.VisiblePosition = 0x11;
            column84.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column84.Header.VisiblePosition = 0x12;
            column85.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column85.Header.VisiblePosition = 0x13;
            band2.Columns.AddRange(new object[] { 
                column64, column65, column66, column67, column69, column70, column71, column72, column73, column74, column75, column76, column77, column78, column80, column81, 
                column82, column83, column84, column85
             });
            column86.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column86.Header.VisiblePosition = 0;
            column87.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column87.Header.VisiblePosition = 1;
            column88.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column88.Header.VisiblePosition = 2;
            column89.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column89.Header.VisiblePosition = 3;
            band3.Columns.AddRange(new object[] { column86, column87, column88, column89 });
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(band7);
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(band8);
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(band9);
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(band10);
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(band11);
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(band12);
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(band2);
            this.UltraDropDown1.DisplayLayout.BandsSerializer.Add(band3);
            this.UltraDropDown1.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;
            this.UltraDropDown1.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
            appearance19.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance19.BackGradientStyle = GradientStyle.Vertical;
            appearance19.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraDropDown1.DisplayLayout.GroupByBox.Appearance = appearance19;
            appearance20.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraDropDown1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance20;
            this.UltraDropDown1.DisplayLayout.GroupByBox.BorderStyle = UIElementBorderStyle.Solid;
            appearance21.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance21.BackColor2 = System.Drawing.SystemColors.Control;
            appearance21.BackGradientStyle = GradientStyle.Horizontal;
            appearance21.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraDropDown1.DisplayLayout.GroupByBox.PromptAppearance = appearance21;
            this.UltraDropDown1.DisplayLayout.MaxColScrollRegions = 1;
            this.UltraDropDown1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            appearance22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UltraDropDown1.DisplayLayout.Override.ActiveCellAppearance = appearance22;
            appearance23.BackColor = System.Drawing.SystemColors.Highlight;
            appearance23.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.UltraDropDown1.DisplayLayout.Override.ActiveRowAppearance = appearance23;
            this.UltraDropDown1.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Dotted;
            this.UltraDropDown1.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Dotted;
            appearance24.BackColor = System.Drawing.SystemColors.Window;
            this.UltraDropDown1.DisplayLayout.Override.CardAreaAppearance = appearance24;
            appearance25.BorderColor = Color.Silver;
            appearance25.TextTrimming = TextTrimming.EllipsisCharacter;
            this.UltraDropDown1.DisplayLayout.Override.CellAppearance = appearance25;
            this.UltraDropDown1.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            this.UltraDropDown1.DisplayLayout.Override.CellPadding = 0;
            appearance26.BackColor = System.Drawing.SystemColors.Control;
            appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance26.BackGradientAlignment = GradientAlignment.Element;
            appearance26.BackGradientStyle = GradientStyle.Horizontal;
            appearance26.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraDropDown1.DisplayLayout.Override.GroupByRowAppearance = appearance26;
            appearance27.TextHAlignAsString = "Left";
            this.UltraDropDown1.DisplayLayout.Override.HeaderAppearance = appearance27;
            this.UltraDropDown1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            this.UltraDropDown1.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            appearance28.BackColor = System.Drawing.SystemColors.Window;
            appearance28.BorderColor = Color.Silver;
            this.UltraDropDown1.DisplayLayout.Override.RowAppearance = appearance28;
            this.UltraDropDown1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance29.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UltraDropDown1.DisplayLayout.Override.TemplateAddRowAppearance = appearance29;
            this.UltraDropDown1.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.UltraDropDown1.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.UltraDropDown1.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            point = new System.Drawing.Point(0x127, 0x16);
            this.UltraDropDown1.Location = point;
            this.UltraDropDown1.Name = "UltraDropDown1";
            size = new System.Drawing.Size(0xf6, 80);
            this.UltraDropDown1.Size = size;
            this.UltraDropDown1.TabIndex = 3;
            this.UltraDropDown1.Text = "UltraDropDown1";
            this.UltraDropDown1.ValueMember = "IDRADNIK";
            this.UltraDropDown1.Visible = false;
            this.UltraDropDown2.DataMember = "ELEMENT";
            this.UltraDropDown2.DataSource = this.ElementDataSet1;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.UltraDropDown2.DisplayLayout.Appearance = appearance4;
            column91.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column91.Header.VisiblePosition = 0;
            column92.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column92.Header.VisiblePosition = 1;
            column93.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column93.Header.VisiblePosition = 2;
            column93.Hidden = true;
            column94.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column94.Header.VisiblePosition = 3;
            column94.Hidden = true;
            column95.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column95.Header.VisiblePosition = 4;
            column95.Hidden = true;
            column96.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column96.Header.VisiblePosition = 5;
            column96.Hidden = true;
            column97.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column97.Header.VisiblePosition = 6;
            column97.Hidden = true;
            column98.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column98.Header.VisiblePosition = 7;
            column99.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column99.Header.VisiblePosition = 8;
            column99.Hidden = true;
            column100.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column100.Header.VisiblePosition = 9;
            column100.Hidden = true;
            column102.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column102.Header.VisiblePosition = 10;
            column102.Hidden = true;
            column103.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column103.Header.VisiblePosition = 11;
            column103.Hidden = true;
            column104.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column104.Header.VisiblePosition = 12;
            column104.Hidden = true;
            column105.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column105.Header.VisiblePosition = 13;
            column105.Hidden = true;
            column106.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column106.Header.VisiblePosition = 14;
            column106.Hidden = true;
            column107.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column107.Header.VisiblePosition = 15;
            column107.Hidden = true;
            band4.Columns.AddRange(new object[] { column91, column92, column93, column94, column95, column96, column97, column98, column99, column100, column102, column103, column104, column105, column106, column107 });
            this.UltraDropDown2.DisplayLayout.BandsSerializer.Add(band4);
            this.UltraDropDown2.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid;
            this.UltraDropDown2.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
            appearance.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance.BackGradientStyle = GradientStyle.Vertical;
            appearance.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraDropDown2.DisplayLayout.GroupByBox.Appearance = appearance;
            appearance2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraDropDown2.DisplayLayout.GroupByBox.BandLabelAppearance = appearance2;
            this.UltraDropDown2.DisplayLayout.GroupByBox.BorderStyle = UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UltraDropDown2.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.UltraDropDown2.DisplayLayout.MaxColScrollRegions = 1;
            this.UltraDropDown2.DisplayLayout.MaxRowScrollRegions = 1;
            appearance17.BackColor = System.Drawing.SystemColors.Window;
            appearance17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UltraDropDown2.DisplayLayout.Override.ActiveCellAppearance = appearance17;
            appearance12.BackColor = System.Drawing.SystemColors.Highlight;
            appearance12.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.UltraDropDown2.DisplayLayout.Override.ActiveRowAppearance = appearance12;
            this.UltraDropDown2.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Dotted;
            this.UltraDropDown2.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Dotted;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            this.UltraDropDown2.DisplayLayout.Override.CardAreaAppearance = appearance11;
            appearance5.BorderColor = Color.Silver;
            appearance5.TextTrimming = TextTrimming.EllipsisCharacter;
            this.UltraDropDown2.DisplayLayout.Override.CellAppearance = appearance5;
            this.UltraDropDown2.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText;
            this.UltraDropDown2.DisplayLayout.Override.CellPadding = 0;
            appearance14.BackColor = System.Drawing.SystemColors.Control;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientAlignment = GradientAlignment.Element;
            appearance14.BackGradientStyle = GradientStyle.Horizontal;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.UltraDropDown2.DisplayLayout.Override.GroupByRowAppearance = appearance14;
            appearance16.TextHAlignAsString = "Left";
            this.UltraDropDown2.DisplayLayout.Override.HeaderAppearance = appearance16;
            this.UltraDropDown2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            this.UltraDropDown2.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            appearance15.BorderColor = Color.Silver;
            this.UltraDropDown2.DisplayLayout.Override.RowAppearance = appearance15;
            this.UltraDropDown2.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UltraDropDown2.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.UltraDropDown2.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.UltraDropDown2.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.UltraDropDown2.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            point = new System.Drawing.Point(470, 3);
            this.UltraDropDown2.Location = point;
            this.UltraDropDown2.Name = "UltraDropDown2";
            size = new System.Drawing.Size(0xdf, 80);
            this.UltraDropDown2.Size = size;
            this.UltraDropDown2.TabIndex = 4;
            this.UltraDropDown2.Text = "UltraDropDown2";
            this.UltraDropDown2.ValueMember = "IDELEMENT";
            this.UltraDropDown2.Visible = false;
            this.Controls.Add(this.UltraDropDown2);
            this.Controls.Add(this.UltraDropDown1);
            this.Controls.Add(this.UltraGrid3);
            this.Controls.Add(this.UltraGrid2);
            this.Controls.Add(this.UltraGroupBox4);
            this.Name = "PripremaPlaceSmartPart";
            size = new System.Drawing.Size(0x3be, 0x289);
            this.Size = size;
            ((ISupportInitialize) this.UltraGroupBox4).EndInit();
            ((ISupportInitialize) this.UltraGrid2).EndInit();
            this.PrplaceDataSet1.EndInit();
            ((ISupportInitialize) this.UltraGrid3).EndInit();
            this.RadnikDataSet1.EndInit();
            this.ElementDataSet1.EndInit();
            ((ISupportInitialize) this.UltraDropDown1).EndInit();
            ((ISupportInitialize) this.UltraDropDown2).EndInit();
            this.ResumeLayout(false);
        }

        [LocalCommandHandler("Otvori")]
        public void OtvoriHandler(object sender, EventArgs e)
        {
            this.OtvoriObracun(null);
        }

        public void OtvoriObracun(string sifra = null)
        {
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            if (sifra == null)
            {
                this.frm = new frmPregledObracuna();
                this.frm.ShowDialog();
                if (this.frm.DialogResult != DialogResult.Cancel)
                {
                    sifra = Conversions.ToString(this.frm.ObracunSelected);
                }
            }
        }

        private void PripremaSmartPart_Load(object sender, EventArgs e)
        {
            this.dapriprema.Fill(this.PrplaceDataSet1);
            this.DAELEMENT.Fill(this.ElementDataSet1);
            this.daradnik.Fill(this.RadnikDataSet1);
        }

        private void UltraDropDown1_AfterCloseUp(object sender, DropDownEventArgs e)
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.PrplaceDataSet1, "PRPLACEPRPLACEELEMENTI"];
            DataRowView current = (DataRowView) manager.Current;
            if (this.UltraDropDown1.ActiveRow != null)
            {
                int idradnik = Conversions.ToInteger(this.UltraDropDown1.SelectedRow.Cells["IDRADNIK"].Value);
                int element = Conversions.ToInteger(current["IDELEMENT"]);
                this.UltraGrid3.ActiveRow.Cells["prplacesatnica"].Value = placa.Test(idradnik, element, Configuration.ConnectionString, 23M, 123M);
            }
        }

        private void UltraDropDown2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid2_AfterRowInsert(object sender, RowEventArgs e)
        {
            UltraGridCell cell = e.Row.Cells["PRPLACEZAMJESEC"];
            cell.Value = RuntimeHelpers.GetObjectValue(this.PrplaceDataSet1.PRPLACE.Rows[0]["prplacezamjesec"]);
            UltraGridCell cell2 = e.Row.Cells["PRPLACEZAGODINU"];
            cell2.Value = RuntimeHelpers.GetObjectValue(this.PrplaceDataSet1.PRPLACE.Rows[0]["prplacezagodinu"]);
        }

        private void UltraGrid2_AfterRowUpdate(object sender, RowEventArgs e)
        {
            new PRPLACEDataAdapter().Update(this.PrplaceDataSet1);
        }

        private void UltraGrid2_Error(object sender, ErrorEventArgs e)
        {
            if (e.DataErrorInfo.ErrorText.Contains("Nije"))
            {
                Interaction.MsgBox("Element u pripremi već postoji! Pritisnite tipku <ESC> da poništite unos reda!", MsgBoxStyle.OkOnly, null);
                e.Cancel = true;
            }
        }

        private void UltraGrid2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid3_AfterCellUpdate(object sender, CellEventArgs e)
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.PrplaceDataSet1, "PRPLACEPRPLACEELEMENTI"];
            DataRowView current = (DataRowView) manager.Current;
            if (this.UltraGrid3.ActiveRow != null)
            {
                if (e.Cell.Column.Key == "IDRADNIK")
                {
                    int idradnik = Conversions.ToInteger(e.Cell.Value);
                    int element = Conversions.ToInteger(current["IDELEMENT"]);
                    this.UltraGrid3.ActiveRow.Cells["prplacesatnica"].Value = placa.Test(idradnik, element, Configuration.ConnectionString, 23M, 123M);
                }
                if (e.Cell.Column.Key == "PRPLACESATI")
                {
                    decimal number = decimal.Divide(decimal.Multiply(decimal.Multiply(DB.N20(RuntimeHelpers.GetObjectValue(this.UltraGrid3.ActiveRow.Cells["prplacesatnica"].Value)), DB.N20(RuntimeHelpers.GetObjectValue(this.UltraGrid3.ActiveRow.Cells["prplaceSATI"].Value))), DB.N20(RuntimeHelpers.GetObjectValue(this.UltraGrid3.ActiveRow.Cells["prplacePOSTOTAK"].Value))), 100M);
                    this.UltraGrid3.ActiveRow.Cells["prplaceIZNOS"].Value = DB.RoundUP(number);
                }
                if (e.Cell.Column.Key == "PRPLACESATNICA")
                {
                    decimal num4 = decimal.Divide(decimal.Multiply(decimal.Multiply(DB.N20(RuntimeHelpers.GetObjectValue(this.UltraGrid3.ActiveRow.Cells["prplacesatnica"].Value)), DB.N20(RuntimeHelpers.GetObjectValue(this.UltraGrid3.ActiveRow.Cells["prplaceSATI"].Value))), DB.N20(RuntimeHelpers.GetObjectValue(this.UltraGrid3.ActiveRow.Cells["prplacePOSTOTAK"].Value))), 100M);
                    this.UltraGrid3.ActiveRow.Cells["prplaceIZNOS"].Value = DB.RoundUP(num4);
                }
                if (e.Cell.Column.Key == "PRPLACEPOSTOTAK")
                {
                    decimal num5 = decimal.Divide(decimal.Multiply(decimal.Multiply(DB.N20(RuntimeHelpers.GetObjectValue(this.UltraGrid3.ActiveRow.Cells["prplacesatnica"].Value)), DB.N20(RuntimeHelpers.GetObjectValue(this.UltraGrid3.ActiveRow.Cells["prplaceSATI"].Value))), DB.N20(RuntimeHelpers.GetObjectValue(this.UltraGrid3.ActiveRow.Cells["prplacePOSTOTAK"].Value))), 100M);
                    this.UltraGrid3.ActiveRow.Cells["prplaceIZNOS"].Value = DB.RoundUP(num5);
                }
            }
        }

        private void UltraGrid3_AfterRowInsert(object sender, RowEventArgs e)
        {
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.PrplaceDataSet1, "PRPLACEPRPLACEELEMENTI"];
            DataRowView current = (DataRowView) manager.Current;
            UltraGridCell cell = e.Row.Cells["PRPLACEODDATUMA"];
            UltraGridCell cell2 = e.Row.Cells["PRPLACEDODATUMA"];
            UltraGridCell cell3 = e.Row.Cells["PRPLACESATNICA"];
            cell3.Value = 0;
            UltraGridCell cell4 = e.Row.Cells["PRPLaCESATI"];
            cell4.Value = 0;
            UltraGridCell cell5 = e.Row.Cells["PRPLACEPOSTOTAK"];
            cell5.Value = RuntimeHelpers.GetObjectValue(current["postotak"]);
            UltraGridCell cell6 = e.Row.Cells["PRPLACEIZNOS"];
            cell6.Value = 0;
            UltraGridCell cell7 = e.Row.Cells["idelement"];
            cell7.Value = RuntimeHelpers.GetObjectValue(current["idelement"]);
            UltraGridCell cell8 = e.Row.Cells["PRPLACEZAMJESEC"];
            cell8.Value = RuntimeHelpers.GetObjectValue(current["prplacezamjesec"]);
            UltraGridCell cell9 = e.Row.Cells["PRPLACEZAGODINU"];
            cell9.Value = RuntimeHelpers.GetObjectValue(current["prplacezagodinu"]);
        }

        private void UltraGrid3_AfterRowUpdate(object sender, RowEventArgs e)
        {
            new PRPLACEDataAdapter().Update(this.PrplaceDataSet1);
        }

        private void UltraGrid3_Error(object sender, ErrorEventArgs e)
        {
            if (e.DataErrorInfo.ErrorText.Contains("Nije"))
            {
                Interaction.MsgBox("Radnik u pripremi već postoji! Pritisnite tipku <ESC> da poništite unos reda!", MsgBoxStyle.OkOnly, null);
                e.Cancel = true;
            }
        }

        internal AutoHideControl _RSMObrazacAutoHideControl
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__RSMObrazacAutoHideControl;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__RSMObrazacAutoHideControl = value;
            }
        }

        internal UnpinnedTabArea _RSMObrazacUnpinnedTabAreaBottom
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__RSMObrazacUnpinnedTabAreaBottom;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__RSMObrazacUnpinnedTabAreaBottom = value;
            }
        }

        internal UnpinnedTabArea _RSMObrazacUnpinnedTabAreaLeft
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__RSMObrazacUnpinnedTabAreaLeft;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__RSMObrazacUnpinnedTabAreaLeft = value;
            }
        }

        internal UnpinnedTabArea _RSMObrazacUnpinnedTabAreaRight
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__RSMObrazacUnpinnedTabAreaRight;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__RSMObrazacUnpinnedTabAreaRight = value;
            }
        }

        internal UnpinnedTabArea _RSMObrazacUnpinnedTabAreaTop
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__RSMObrazacUnpinnedTabAreaTop;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__RSMObrazacUnpinnedTabAreaTop = value;
            }
        }

        private UltraMaskedEdit adresa
        {
            [DebuggerNonUserCode]
            get
            {
                return this._adresa;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._adresa = value;
            }
        }

        private UltraMaskedEdit brojosiguranika
        {
            [DebuggerNonUserCode]
            get
            {
                return this._brojosiguranika;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._brojosiguranika = value;
            }
        }

        internal UltraNumericEditor BROJSTRANICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._BROJSTRANICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._BROJSTRANICA = value;
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

        internal DockableWindow DockableWindow2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._DockableWindow2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._DockableWindow2 = value;
            }
        }

        internal DockableWindow DockableWindow3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._DockableWindow3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._DockableWindow3 = value;
            }
        }

        internal ELEMENTDataSet ElementDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ElementDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._ElementDataSet1 = value;
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

        private UltraMaskedEdit godinaisplate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._godinaisplate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._godinaisplate = value;
            }
        }

        private UltraMaskedEdit GODINAOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._GODINAOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._GODINAOBRACUNA = value;
            }
        }

        private UltraMaskedEdit IDENTIFIKATOROBRASCA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._IDENTIFIKATOROBRASCA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._IDENTIFIKATOROBRASCA = value;
            }
        }

        private UltraMaskedEdit iznosisplaceneplace
        {
            [DebuggerNonUserCode]
            get
            {
                return this._iznosisplaceneplace;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._iznosisplaceneplace = value;
            }
        }

        private UltraMaskedEdit iznosobracunaneplace
        {
            [DebuggerNonUserCode]
            get
            {
                return this._iznosobracunaneplace;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._iznosobracunaneplace = value;
            }
        }

        private UltraMaskedEdit iznososnovicezadoprinose
        {
            [DebuggerNonUserCode]
            get
            {
                return this._iznososnovicezadoprinose;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._iznososnovicezadoprinose = value;
            }
        }

        private UltraLabel lblNazivVrsteObracuna
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lblNazivVrsteObracuna;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._lblNazivVrsteObracuna = value;
            }
        }

        private UltraLabel lblNazivVrsteObveznika
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lblNazivVrsteObveznika;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._lblNazivVrsteObveznika = value;
            }
        }

        private UltraMaskedEdit MBGOBVEZNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._MBGOBVEZNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._MBGOBVEZNIKA = value;
            }
        }

        private UltraMaskedEdit MBOBVEZNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._MBOBVEZNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._MBOBVEZNIKA = value;
            }
        }

        private UltraMaskedEdit mio1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._mio1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._mio1 = value;
            }
        }

        private UltraMaskedEdit mio2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._mio2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._mio2 = value;
            }
        }

        private UltraMaskedEdit mjesecisplate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._mjesecisplate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._mjesecisplate = value;
            }
        }

        private UltraMaskedEdit MJESECOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._MJESECOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._MJESECOBRACUNA = value;
            }
        }

        private UltraMaskedEdit nazivobveznika
        {
            [DebuggerNonUserCode]
            get
            {
                return this._nazivobveznika;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._nazivobveznika = value;
            }
        }

        internal PRPLACEDataSet PrplaceDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._PrplaceDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._PrplaceDataSet1 = value;
            }
        }

        internal RADNIKDataSet RadnikDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._RadnikDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._RadnikDataSet1 = value;
            }
        }

        internal RSMADataSet RsmaDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._RsmaDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._RsmaDataSet1 = value;
            }
        }

        internal RSVRSTEOBRACUNADataSet RsvrsteobracunaDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._RsvrsteobracunaDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._RsvrsteobracunaDataSet1 = value;
            }
        }

        internal RSVRSTEOBVEZNIKADataSet RsvrsteobveznikaDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._RsvrsteobveznikaDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._RsvrsteobveznikaDataSet1 = value;
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

        private UltraMaskedEdit sifraobracuna
        {
            [DebuggerNonUserCode]
            get
            {
                return this._sifraobracuna;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._sifraobracuna = value;
            }
        }

        private UltraCombo ucboVrstaObracuna
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ucboVrstaObracuna;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._ucboVrstaObracuna = value;
            }
        }

        private UltraCombo ucbVrstaObveznika
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ucbVrstaObveznika;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._ucbVrstaObveznika = value;
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

        internal UltraDropDown UltraDropDown1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraDropDown1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                DropDownEventHandler handler = new DropDownEventHandler(this.UltraDropDown1_AfterCloseUp);
                if (this._UltraDropDown1 != null)
                {
                    this._UltraDropDown1.AfterCloseUp -= handler;
                }
                this._UltraDropDown1 = value;
                if (this._UltraDropDown1 != null)
                {
                    this._UltraDropDown1.AfterCloseUp += handler;
                }
            }
        }

        internal UltraDropDown UltraDropDown2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraDropDown2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                InitializeLayoutEventHandler handler = new InitializeLayoutEventHandler(this.UltraDropDown2_InitializeLayout);
                if (this._UltraDropDown2 != null)
                {
                    this._UltraDropDown2.InitializeLayout -= handler;
                }
                this._UltraDropDown2 = value;
                if (this._UltraDropDown2 != null)
                {
                    this._UltraDropDown2.InitializeLayout += handler;
                }
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

        private UltraGrid UltraGrid2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGrid2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                InitializeLayoutEventHandler handler = new InitializeLayoutEventHandler(this.UltraGrid2_InitializeLayout);
                RowEventHandler handler2 = new RowEventHandler(this.UltraGrid2_AfterRowUpdate);
                RowEventHandler handler3 = new RowEventHandler(this.UltraGrid2_AfterRowInsert);
                ErrorEventHandler handler4 = new ErrorEventHandler(this.UltraGrid2_Error);
                if (this._UltraGrid2 != null)
                {
                    this._UltraGrid2.InitializeLayout -= handler;
                    this._UltraGrid2.AfterRowUpdate -= handler2;
                    this._UltraGrid2.AfterRowInsert -= handler3;
                    this._UltraGrid2.Error -= handler4;
                }
                this._UltraGrid2 = value;
                if (this._UltraGrid2 != null)
                {
                    this._UltraGrid2.InitializeLayout += handler;
                    this._UltraGrid2.AfterRowUpdate += handler2;
                    this._UltraGrid2.AfterRowInsert += handler3;
                    this._UltraGrid2.Error += handler4;
                }
            }
        }

        private UltraGrid UltraGrid3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGrid3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                ErrorEventHandler handler = new ErrorEventHandler(this.UltraGrid3_Error);
                RowEventHandler handler2 = new RowEventHandler(this.UltraGrid3_AfterRowUpdate);
                RowEventHandler handler3 = new RowEventHandler(this.UltraGrid3_AfterRowInsert);
                CellEventHandler handler4 = new CellEventHandler(this.UltraGrid3_AfterCellUpdate);
                if (this._UltraGrid3 != null)
                {
                    this._UltraGrid3.Error -= handler;
                    this._UltraGrid3.AfterRowUpdate -= handler2;
                    this._UltraGrid3.AfterRowInsert -= handler3;
                    this._UltraGrid3.AfterCellUpdate -= handler4;
                }
                this._UltraGrid3 = value;
                if (this._UltraGrid3 != null)
                {
                    this._UltraGrid3.Error += handler;
                    this._UltraGrid3.AfterRowUpdate += handler2;
                    this._UltraGrid3.AfterRowInsert += handler3;
                    this._UltraGrid3.AfterCellUpdate += handler4;
                }
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
                this._UltraGroupBox1 = value;
            }
        }

        private UltraGroupBox UltraGroupBox2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGroupBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraGroupBox2 = value;
            }
        }

        private UltraGroupBox UltraGroupBox3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGroupBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraGroupBox3 = value;
            }
        }

        private UltraGroupBox UltraGroupBox4
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGroupBox4;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraGroupBox4 = value;
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

        private UltraLabel UltraLabel10
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel10;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel10 = value;
            }
        }

        private UltraLabel UltraLabel11
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel11;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel11 = value;
            }
        }

        private UltraLabel UltraLabel12
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel12;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel12 = value;
            }
        }

        private UltraLabel UltraLabel13
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel13;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel13 = value;
            }
        }

        private UltraLabel UltraLabel14
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel14;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel14 = value;
            }
        }

        private UltraLabel UltraLabel15
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel15;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel15 = value;
            }
        }

        private UltraLabel UltraLabel16
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel16;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel16 = value;
            }
        }

        private UltraLabel UltraLabel17
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel17;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel17 = value;
            }
        }

        private UltraLabel UltraLabel18
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel18;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel18 = value;
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

        private UltraLabel UltraLabel4
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel4;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel4 = value;
            }
        }

        private UltraLabel UltraLabel5
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel5;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel5 = value;
            }
        }

        private UltraLabel UltraLabel6
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel6;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel6 = value;
            }
        }

        private UltraLabel UltraLabel7
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel7;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel7 = value;
            }
        }

        private UltraLabel UltraLabel8
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel8;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel8 = value;
            }
        }

        private UltraLabel UltraLabel9
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel9;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel9 = value;
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

        internal WindowDockingArea WindowDockingArea2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._WindowDockingArea2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._WindowDockingArea2 = value;
            }
        }

        internal WindowDockingArea WindowDockingArea3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._WindowDockingArea3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._WindowDockingArea3 = value;
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

