using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Placa;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace PlacaModule
{
    public class frmIspravakOsnovnihPodataka : Form
    {
        private IContainer components { get; set; }

        public frmIspravakOsnovnihPodataka()
        {
            base.Load += new EventHandler(this.frmIspravakOsnovnihPodataka_Load);
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (this.components != null))
                {
                    this.components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private void frmIspravakOsnovnihPodataka_Load(object sender, EventArgs e)
        {
            RADNIKDataAdapter adapter3 = new RADNIKDataAdapter();
            BANKEDataAdapter adapter = new BANKEDataAdapter();
            SKUPPOREZAIDOPRINOSADataAdapter adapter6 = new SKUPPOREZAIDOPRINOSADataAdapter();
            BENEFICIRANIDataAdapter adapter2 = new BENEFICIRANIDataAdapter();
            IPIDENTDataAdapter adapter4 = new IPIDENTDataAdapter();
            new OPCINADataAdapter().Fill(this.OpcinaDataSet1);
            adapter4.Fill(this.IpidentDataSet1);
            adapter2.Fill(this.BeneficiraniDataSet1);
            adapter6.Fill(this.SkupporezaidoprinosaDataSet1);
            adapter.Fill(this.BankeDataSet1);
            adapter3.Fill(this.RadnikDataSet1);
        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RADNIK", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SPOJENOPREZIME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AKTIVAN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PREZIME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OIB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("JMBG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMRODJENJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ulica");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("mjesto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("kucnibroj");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINARADAIDOPCINE", -1, "OPCINA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINARADANAZIVOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAIDOPCINE", -1, "OPCINA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJANAZIVOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAPRIREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAVBDIOPCINA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAZRNOPCINA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBANKE1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBANKE2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBANKE3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIBANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZRNBANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TEKUCI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZBIRNINETO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJANETO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJANETO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TJEDNIFONDSATI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KOEFICIJENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POSTOTAKOSLOBODJENJAODPOREZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UZIMAUOBZIROSNOVICEDOPRINOSA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TJEDNIFONDSATISTAZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GODINESTAZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MJESECISTAZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DANISTAZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBENEFICIRANI", -1, "BENEFICIRANI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBENEFICIRANI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMPRESTANKARADNOGODNOSA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJMIROVINSKOG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJZDRAVSTVENOG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MBO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDTITULA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVTITULA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNOMJESTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVRADNOMJESTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn51 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn52 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POTREBNASTRUCNASPREMAIDSTRUCNASPREMA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn53 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn54 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSTRUKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn55 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVSTRUKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn56 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBRACNOSTANJE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn57 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBRACNOSTANJE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn58 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGDIO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn59 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ORGANIZACIJSKIDIO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn60 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UKUPNOGODINESTAZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn61 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UKUPNOMJESECISTAZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn62 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UKUPNODANASTAZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn63 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJPRIZNATIHMJESECI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn64 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn65 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PBO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn66 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GODINESTAZAPRO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn67 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MJESECISTAZAPRO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn68 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DANISTAZAPRO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn69 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UKUPNIFAKTOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn70 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDRZAVLJANSTVO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn71 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVDRZAVLJANSTVO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn72 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADNADOZVOLA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn73 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZAVRSENASKOLA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn74 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UGOVOROD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn75 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POCETAKRADA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn76 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPOSLA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn77 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDUGOVORORADU");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn78 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVUGOVORORADU");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn79 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VRIJEMEPROBNOGRADA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn80 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VRIJEMEPRIPRAVNICKOG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn81 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VRIJEMESTRUCNI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn82 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADUINOZEMSTVU");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn83 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADNASPOSOBNOST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn84 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VRIJEMEMIROVANJARADNOGODNOSA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn85 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RAZLOGPRESTANKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn86 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZABRANANATJECANJA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn87 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRODUZENOMIROVINSKO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn88 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADNIKNAPOMENA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn89 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNOVRIJEME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn90 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSPOL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn91 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVSPOL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn92 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDIPIDENT", -1, "IPIDENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn93 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVIPIDENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn94 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADNIK_RADNIKIzuzeceOdOvrhe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn95 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADNIK_RADNIKLevel7");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn96 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADNIK_RADNIKObustava");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn97 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADNIK_RADNIKNeto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn98 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADNIK_RADNIKBruto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn99 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADNIK_RADNIKKrediti");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn100 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADNIK_RADNIKOlaksica");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn101 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RADNIK_RADNIKOdbitak");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RADNIK_RADNIKIzuzeceOdOvrhe", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn102 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn103 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BANKAZASTICENOIDBANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn104 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADSIFRAOPISAPLACANJAIZUZECE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn105 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOPISPLACANJAIZUZECE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn106 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADTEKUCIIZUZECE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn107 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADMOIZUZECE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn108 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADPOIZUZECE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn109 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADMZIZUZECE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn110 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADPZIZUZECE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn111 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADIZNOSIZUZECA");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RADNIK_RADNIKLevel7", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn112 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn113 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGRUPEKOEF");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn114 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVGRUPEKOEF");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn115 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DODATNIKOEFICIJENT");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RADNIK_RADNIKObustava", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn116 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn117 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOBUSTAVAIDOBUSTAVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn118 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBUSTAVAAKTIVNA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn119 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOBUSTAVANAZIVOBUSTAVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn120 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOBUSTAVAVRSTAOBUSTAVE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn121 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOBUSTAVANAZIVVRSTAOBUSTAVE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn122 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADIZNOSOBUSTAVE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn123 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADPOSTOTAKOBUSTAVE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn124 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADPOSTOTNAODBRUTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn125 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADISPLACENOKASA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn126 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADSALDOKASA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn127 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OTPLACENIIZNOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn128 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OTPLACENIBROJRATA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn129 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOBUSTAVAZRNOBUSTAVA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn130 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOBUSTAVAVBDIOBUSTAVA");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand5 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RADNIK_RADNIKNeto", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn131 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn132 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NETOELEMENTIDELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn133 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NETOELEMENTNAZIVELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn134 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NETOSATNICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn135 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NETOSATI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn136 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NETOPOSTOTAK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn137 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NETOIZNOS");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand6 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RADNIK_RADNIKBruto", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn138 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn139 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BRUTOELEMENTIDELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn140 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BRUTOELEMENTNAZIVELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn141 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BRUTOSATNICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn142 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BRUTOSATI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn143 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BRUTOPOSTOTAK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn144 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BRUTOIZNOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn145 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BRUTOELEMENTPOSTOTAK");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand7 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RADNIK_RADNIKKrediti", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn146 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn147 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADKREDITIIDKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn148 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMUGOVORA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn149 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KREDITAKTIVAN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn150 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADKREDITINAZIVKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn151 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADKREDITIPRIMATELJKREDITOR1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn152 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADKREDITIPRIMATELJKREDITOR2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn153 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADKREDITIPRIMATELJKREDITOR3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn154 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJAKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn155 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJAKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn156 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MOKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn157 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn158 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn159 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn160 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADIZNOSRATEKREDITA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn161 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADBROJRATAOBUSTAVE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn162 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADUKUPNIZNOSKREDITA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn163 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADVECOTPLACENOBROJRATA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn164 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADVECOTPLACENOUKUPNIIZNOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn165 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KREDITOTPLACENIIZNOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn166 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KREDITOTPLACENORATA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn167 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADKREDITIVBDIKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn168 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADKREDITIZRNKREDITOR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn169 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTIJAKREDITASPECIFIKACIJA");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand8 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RADNIK_RADNIKOlaksica", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn170 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn171 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOLAKSICEIDOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn172 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOLAKSICEIDGRUPEOLAKSICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn173 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOLAKSICEMAXIMALNIIZNOSGRUPE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn174 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOLAKSICENAZIVGRUPEOLAKSICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn175 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOLAKSICENAZIVOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn176 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOLAKSICEIDTIPOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn177 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOLAKSICENAZIVTIPOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn178 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOLAKSICEVBDIOLAKSICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn179 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOLAKSICEZRNOLAKSICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn180 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOLAKSICEPRIMATELJOLAKSICA1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn181 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOLAKSICEPRIMATELJOLAKSICA2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn182 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOLAKSICEPRIMATELJOLAKSICA3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn183 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADMZOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn184 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADPZOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn185 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADMOOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn186 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADPOOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn187 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADSIFRAOPISAPLACANJAOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn188 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADOPISPLACANJAOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn189 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADIZNOSOLAKSICE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn190 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZADPOJEDINACNIPOZIV");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand9 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RADNIK_RADNIKOdbitak", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn191 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn192 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn193 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOSOBNIODBITAK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn194 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FAKTOROSOBNOGODBITKA");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand10 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BANKE", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn195 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn196 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBANKE1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn197 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBANKE2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn198 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBANKE3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn199 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MOBANKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn200 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POBANKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn201 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZBANKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn202 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZBANKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn203 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISPLACANJABANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn204 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJABANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn205 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIBANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn206 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZRNBANKE");
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand11 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BENEFICIRANI", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn207 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBENEFICIRANI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn208 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBENEFICIRANI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn209 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJPRIZNATIHMJESECI");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand12 = new Infragistics.Win.UltraWinGrid.UltraGridBand("SKUPPOREZAIDOPRINOSA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn210 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSKUPPOREZAIDOPRINOSA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn211 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVSKUPPOREZAIDOPRINOSA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn212 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn213 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA1");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand13 = new Infragistics.Win.UltraWinGrid.UltraGridBand("SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA2", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn214 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSKUPPOREZAIDOPRINOSA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn215 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn216 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn217 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDVRSTADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn218 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVVRSTADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn219 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MODOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn220 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PODOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn221 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn222 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn223 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJDOPRINOS1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn224 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJDOPRINOS2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn225 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn226 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJADOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn227 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn228 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZRNDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn229 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MINDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn230 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MAXDOPRINOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn231 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("STOPA");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand14 = new Infragistics.Win.UltraWinGrid.UltraGridBand("SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA1", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn232 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSKUPPOREZAIDOPRINOSA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn233 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn234 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn235 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POREZMJESECNO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn236 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("STOPAPOREZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn237 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MOPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn238 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn239 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MZPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn240 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PZPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn241 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJPOREZ1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn242 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIMATELJPOREZ2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn243 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAOPISAPLACANJAPOREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn244 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPISPLACANJAPOREZ");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand15 = new Infragistics.Win.UltraWinGrid.UltraGridBand("OPCINA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn245 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn246 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn247 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PRIREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn248 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIOPCINA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn249 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZRNOPCINA");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand16 = new Infragistics.Win.UltraWinGrid.UltraGridBand("IPIDENT", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn250 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDIPIDENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn251 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVIPIDENT");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIspravakOsnovnihPodataka));
            this.ugrdGK = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.RadnikDataSet1 = new Placa.RADNIKDataSet();
            this.BankeDataSet1 = new Placa.BANKEDataSet();
            this.OpcinaDataSet1 = new Placa.OPCINADataSet();
            this.SkupporezaidoprinosaDataSet1 = new Placa.SKUPPOREZAIDOPRINOSADataSet();
            this.BANKE = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.BENEFICIRANI = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.BeneficiraniDataSet1 = new Placa.BENEFICIRANIDataSet();
            this.SKUPINA = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.OPCINA = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            this.IpidentDataSet1 = new Placa.IPIDENTDataSet();
            this.IPIDENT = new Infragistics.Win.UltraWinGrid.UltraDropDown();
            ((System.ComponentModel.ISupportInitialize)(this.ugrdGK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadnikDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BankeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpcinaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkupporezaidoprinosaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BANKE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BENEFICIRANI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeneficiraniDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SKUPINA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OPCINA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IpidentDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPIDENT)).BeginInit();
            this.SuspendLayout();
            // 
            // ugrdGK
            // 
            this.ugrdGK.DataMember = "RADNIK";
            this.ugrdGK.DataSource = this.RadnikDataSet1;
            appearance5.BackColor = System.Drawing.Color.White;
            this.ugrdGK.DisplayLayout.Appearance = appearance5;
            this.ugrdGK.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 42;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn2.Width = 8;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 69;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 56;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 53;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Width = 49;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Width = 49;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn8.Width = 17;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn9.Width = 8;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn10.Width = 8;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn11.Width = 8;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn12.Width = 49;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn13.Width = 8;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn14.Width = 49;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.VisiblePosition = 14;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn15.Width = 8;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 15;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn16.Width = 8;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.VisiblePosition = 16;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn17.Width = 8;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.VisiblePosition = 17;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn18.Width = 8;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.Header.VisiblePosition = 18;
            ultraGridColumn19.Width = 49;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.Header.VisiblePosition = 19;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn20.Width = 11;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.Header.VisiblePosition = 20;
            ultraGridColumn21.Width = 49;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn22.Header.VisiblePosition = 21;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn22.Width = 11;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn23.Header.VisiblePosition = 22;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn23.Width = 11;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn24.Header.VisiblePosition = 23;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn24.Width = 11;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn25.Header.VisiblePosition = 24;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn25.Width = 14;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn26.Header.VisiblePosition = 25;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn26.Width = 13;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn27.Header.VisiblePosition = 26;
            ultraGridColumn27.Width = 68;
            ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn28.Header.VisiblePosition = 27;
            ultraGridColumn28.Width = 105;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn29.Header.VisiblePosition = 28;
            ultraGridColumn29.Hidden = true;
            ultraGridColumn29.Width = 21;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn30.Header.VisiblePosition = 29;
            ultraGridColumn30.Hidden = true;
            ultraGridColumn30.Width = 18;
            ultraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn31.Header.VisiblePosition = 30;
            ultraGridColumn31.Width = 99;
            ultraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn32.Header.VisiblePosition = 31;
            ultraGridColumn32.Width = 55;
            ultraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn33.Header.VisiblePosition = 32;
            ultraGridColumn33.Hidden = true;
            ultraGridColumn33.Width = 24;
            ultraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn34.Header.VisiblePosition = 33;
            ultraGridColumn34.Hidden = true;
            ultraGridColumn34.Width = 29;
            ultraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn35.Header.VisiblePosition = 34;
            ultraGridColumn35.Width = 118;
            ultraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn36.Header.VisiblePosition = 35;
            ultraGridColumn36.Hidden = true;
            ultraGridColumn36.Width = 27;
            ultraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn37.Header.VisiblePosition = 36;
            ultraGridColumn37.Hidden = true;
            ultraGridColumn37.Width = 15;
            ultraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn38.Header.VisiblePosition = 37;
            ultraGridColumn38.Hidden = true;
            ultraGridColumn38.Width = 15;
            ultraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn39.Header.VisiblePosition = 38;
            ultraGridColumn39.Hidden = true;
            ultraGridColumn39.Width = 14;
            ultraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn40.Header.VisiblePosition = 39;
            ultraGridColumn40.Width = 112;
            ultraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn41.Header.VisiblePosition = 40;
            ultraGridColumn41.Hidden = true;
            ultraGridColumn41.Width = 19;
            ultraGridColumn42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn42.Header.VisiblePosition = 41;
            ultraGridColumn42.Hidden = true;
            ultraGridColumn42.Width = 19;
            ultraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn43.Header.VisiblePosition = 42;
            ultraGridColumn43.Hidden = true;
            ultraGridColumn43.Width = 16;
            ultraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn44.Header.VisiblePosition = 43;
            ultraGridColumn44.Hidden = true;
            ultraGridColumn44.Width = 17;
            ultraGridColumn45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn45.Header.VisiblePosition = 44;
            ultraGridColumn45.Hidden = true;
            ultraGridColumn45.Width = 14;
            ultraGridColumn46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn46.Header.VisiblePosition = 45;
            ultraGridColumn46.Hidden = true;
            ultraGridColumn46.Width = 8;
            ultraGridColumn47.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn47.Header.VisiblePosition = 46;
            ultraGridColumn47.Hidden = true;
            ultraGridColumn47.Width = 11;
            ultraGridColumn48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn48.Header.VisiblePosition = 47;
            ultraGridColumn48.Hidden = true;
            ultraGridColumn48.Width = 12;
            ultraGridColumn49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn49.Header.VisiblePosition = 48;
            ultraGridColumn49.Hidden = true;
            ultraGridColumn49.Width = 12;
            ultraGridColumn50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn50.Header.VisiblePosition = 49;
            ultraGridColumn50.Hidden = true;
            ultraGridColumn50.Width = 12;
            ultraGridColumn51.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn51.Header.VisiblePosition = 50;
            ultraGridColumn51.Hidden = true;
            ultraGridColumn51.Width = 13;
            ultraGridColumn52.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn52.Header.VisiblePosition = 51;
            ultraGridColumn52.Hidden = true;
            ultraGridColumn52.Width = 17;
            ultraGridColumn53.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn53.Header.VisiblePosition = 52;
            ultraGridColumn53.Hidden = true;
            ultraGridColumn53.Width = 18;
            ultraGridColumn54.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn54.Header.VisiblePosition = 53;
            ultraGridColumn54.Hidden = true;
            ultraGridColumn54.Width = 8;
            ultraGridColumn55.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn55.Header.VisiblePosition = 54;
            ultraGridColumn55.Hidden = true;
            ultraGridColumn55.Width = 11;
            ultraGridColumn56.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn56.Header.VisiblePosition = 55;
            ultraGridColumn56.Hidden = true;
            ultraGridColumn56.Width = 12;
            ultraGridColumn57.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn57.Header.VisiblePosition = 56;
            ultraGridColumn57.Hidden = true;
            ultraGridColumn57.Width = 13;
            ultraGridColumn58.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn58.Header.VisiblePosition = 57;
            ultraGridColumn58.Hidden = true;
            ultraGridColumn58.Width = 16;
            ultraGridColumn59.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn59.Header.VisiblePosition = 58;
            ultraGridColumn59.Hidden = true;
            ultraGridColumn59.Width = 17;
            ultraGridColumn60.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn60.Header.VisiblePosition = 59;
            ultraGridColumn60.Hidden = true;
            ultraGridColumn60.Width = 15;
            ultraGridColumn61.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn61.Header.VisiblePosition = 60;
            ultraGridColumn61.Hidden = true;
            ultraGridColumn61.Width = 15;
            ultraGridColumn62.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn62.Header.VisiblePosition = 61;
            ultraGridColumn62.Hidden = true;
            ultraGridColumn62.Width = 14;
            ultraGridColumn63.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn63.Header.VisiblePosition = 62;
            ultraGridColumn63.Hidden = true;
            ultraGridColumn63.Width = 23;
            ultraGridColumn64.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn64.Header.VisiblePosition = 63;
            ultraGridColumn64.Hidden = true;
            ultraGridColumn64.Width = 11;
            ultraGridColumn65.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn65.Header.VisiblePosition = 64;
            ultraGridColumn65.Hidden = true;
            ultraGridColumn65.Width = 11;
            ultraGridColumn66.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn66.Header.VisiblePosition = 65;
            ultraGridColumn66.Hidden = true;
            ultraGridColumn66.Width = 13;
            ultraGridColumn67.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn67.Header.VisiblePosition = 66;
            ultraGridColumn67.Hidden = true;
            ultraGridColumn67.Width = 13;
            ultraGridColumn68.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn68.Header.VisiblePosition = 67;
            ultraGridColumn68.Hidden = true;
            ultraGridColumn68.Width = 11;
            ultraGridColumn69.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn69.Header.VisiblePosition = 68;
            ultraGridColumn69.Hidden = true;
            ultraGridColumn69.Width = 11;
            ultraGridColumn70.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn70.Header.VisiblePosition = 69;
            ultraGridColumn70.Hidden = true;
            ultraGridColumn70.Width = 13;
            ultraGridColumn71.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn71.Header.VisiblePosition = 70;
            ultraGridColumn71.Hidden = true;
            ultraGridColumn71.Width = 15;
            ultraGridColumn72.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn72.Header.VisiblePosition = 71;
            ultraGridColumn72.Hidden = true;
            ultraGridColumn72.Width = 11;
            ultraGridColumn73.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn73.Header.VisiblePosition = 72;
            ultraGridColumn73.Hidden = true;
            ultraGridColumn73.Width = 12;
            ultraGridColumn74.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn74.Header.VisiblePosition = 73;
            ultraGridColumn74.Hidden = true;
            ultraGridColumn74.Width = 17;
            ultraGridColumn75.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn75.Header.VisiblePosition = 74;
            ultraGridColumn75.Hidden = true;
            ultraGridColumn75.Width = 17;
            ultraGridColumn76.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn76.Header.VisiblePosition = 75;
            ultraGridColumn76.Hidden = true;
            ultraGridColumn76.Width = 11;
            ultraGridColumn77.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn77.Header.VisiblePosition = 76;
            ultraGridColumn77.Hidden = true;
            ultraGridColumn77.Width = 12;
            ultraGridColumn78.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn78.Header.VisiblePosition = 77;
            ultraGridColumn78.Hidden = true;
            ultraGridColumn78.Width = 15;
            ultraGridColumn79.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn79.Header.VisiblePosition = 78;
            ultraGridColumn79.Hidden = true;
            ultraGridColumn79.Width = 16;
            ultraGridColumn80.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn80.Header.VisiblePosition = 79;
            ultraGridColumn80.Hidden = true;
            ultraGridColumn80.Width = 16;
            ultraGridColumn81.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn81.Header.VisiblePosition = 80;
            ultraGridColumn81.Hidden = true;
            ultraGridColumn81.Width = 12;
            ultraGridColumn82.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn82.Header.VisiblePosition = 81;
            ultraGridColumn82.Hidden = true;
            ultraGridColumn82.Width = 13;
            ultraGridColumn83.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn83.Header.VisiblePosition = 82;
            ultraGridColumn83.Hidden = true;
            ultraGridColumn83.Width = 14;
            ultraGridColumn84.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn84.Header.VisiblePosition = 83;
            ultraGridColumn84.Hidden = true;
            ultraGridColumn84.Width = 23;
            ultraGridColumn85.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn85.Header.VisiblePosition = 84;
            ultraGridColumn85.Hidden = true;
            ultraGridColumn85.Width = 14;
            ultraGridColumn86.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn86.Header.VisiblePosition = 85;
            ultraGridColumn86.Hidden = true;
            ultraGridColumn86.Width = 15;
            ultraGridColumn87.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn87.Header.VisiblePosition = 86;
            ultraGridColumn87.Hidden = true;
            ultraGridColumn87.Width = 17;
            ultraGridColumn88.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn88.Header.VisiblePosition = 87;
            ultraGridColumn88.Hidden = true;
            ultraGridColumn88.Width = 13;
            ultraGridColumn89.Header.VisiblePosition = 88;
            ultraGridColumn89.Width = 108;
            ultraGridColumn90.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn90.Header.VisiblePosition = 89;
            ultraGridColumn90.Hidden = true;
            ultraGridColumn90.Width = 8;
            ultraGridColumn91.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn91.Header.VisiblePosition = 90;
            ultraGridColumn91.Hidden = true;
            ultraGridColumn91.Width = 11;
            ultraGridColumn92.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn92.Header.VisiblePosition = 91;
            ultraGridColumn92.Width = 49;
            ultraGridColumn93.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn93.Header.VisiblePosition = 92;
            ultraGridColumn93.Hidden = true;
            ultraGridColumn93.Width = 11;
            ultraGridColumn94.Header.VisiblePosition = 94;
            ultraGridColumn95.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn95.Header.VisiblePosition = 93;
            ultraGridColumn96.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn96.Header.VisiblePosition = 95;
            ultraGridColumn97.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn97.Header.VisiblePosition = 96;
            ultraGridColumn98.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn98.Header.VisiblePosition = 97;
            ultraGridColumn99.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn99.Header.VisiblePosition = 98;
            ultraGridColumn100.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn100.Header.VisiblePosition = 99;
            ultraGridColumn101.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn101.Header.VisiblePosition = 100;
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
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38,
            ultraGridColumn39,
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn44,
            ultraGridColumn45,
            ultraGridColumn46,
            ultraGridColumn47,
            ultraGridColumn48,
            ultraGridColumn49,
            ultraGridColumn50,
            ultraGridColumn51,
            ultraGridColumn52,
            ultraGridColumn53,
            ultraGridColumn54,
            ultraGridColumn55,
            ultraGridColumn56,
            ultraGridColumn57,
            ultraGridColumn58,
            ultraGridColumn59,
            ultraGridColumn60,
            ultraGridColumn61,
            ultraGridColumn62,
            ultraGridColumn63,
            ultraGridColumn64,
            ultraGridColumn65,
            ultraGridColumn66,
            ultraGridColumn67,
            ultraGridColumn68,
            ultraGridColumn69,
            ultraGridColumn70,
            ultraGridColumn71,
            ultraGridColumn72,
            ultraGridColumn73,
            ultraGridColumn74,
            ultraGridColumn75,
            ultraGridColumn76,
            ultraGridColumn77,
            ultraGridColumn78,
            ultraGridColumn79,
            ultraGridColumn80,
            ultraGridColumn81,
            ultraGridColumn82,
            ultraGridColumn83,
            ultraGridColumn84,
            ultraGridColumn85,
            ultraGridColumn86,
            ultraGridColumn87,
            ultraGridColumn88,
            ultraGridColumn89,
            ultraGridColumn90,
            ultraGridColumn91,
            ultraGridColumn92,
            ultraGridColumn93,
            ultraGridColumn94,
            ultraGridColumn95,
            ultraGridColumn96,
            ultraGridColumn97,
            ultraGridColumn98,
            ultraGridColumn99,
            ultraGridColumn100,
            ultraGridColumn101});
            ultraGridBand1.SummaryFooterCaption = "Totali";
            ultraGridColumn102.Header.VisiblePosition = 0;
            ultraGridColumn102.Width = 82;
            ultraGridColumn103.Header.VisiblePosition = 1;
            ultraGridColumn104.Header.VisiblePosition = 2;
            ultraGridColumn105.Header.VisiblePosition = 3;
            ultraGridColumn106.Header.VisiblePosition = 4;
            ultraGridColumn107.Header.VisiblePosition = 5;
            ultraGridColumn108.Header.VisiblePosition = 6;
            ultraGridColumn109.Header.VisiblePosition = 7;
            ultraGridColumn110.Header.VisiblePosition = 8;
            ultraGridColumn111.Header.VisiblePosition = 9;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn102,
            ultraGridColumn103,
            ultraGridColumn104,
            ultraGridColumn105,
            ultraGridColumn106,
            ultraGridColumn107,
            ultraGridColumn108,
            ultraGridColumn109,
            ultraGridColumn110,
            ultraGridColumn111});
            ultraGridColumn112.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn112.Header.VisiblePosition = 0;
            ultraGridColumn112.Width = 221;
            ultraGridColumn113.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn113.Header.VisiblePosition = 1;
            ultraGridColumn113.Width = 271;
            ultraGridColumn114.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn114.Header.VisiblePosition = 2;
            ultraGridColumn114.Width = 331;
            ultraGridColumn115.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn115.Header.VisiblePosition = 3;
            ultraGridColumn115.Width = 386;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn112,
            ultraGridColumn113,
            ultraGridColumn114,
            ultraGridColumn115});
            ultraGridColumn116.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn116.Header.VisiblePosition = 0;
            ultraGridColumn116.Width = 40;
            ultraGridColumn117.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn117.Header.VisiblePosition = 1;
            ultraGridColumn117.Width = 57;
            ultraGridColumn118.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn118.Header.VisiblePosition = 2;
            ultraGridColumn118.Width = 80;
            ultraGridColumn119.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn119.Header.VisiblePosition = 3;
            ultraGridColumn119.Width = 65;
            ultraGridColumn120.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn120.Header.VisiblePosition = 4;
            ultraGridColumn120.Width = 59;
            ultraGridColumn121.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn121.Header.VisiblePosition = 5;
            ultraGridColumn121.Width = 74;
            ultraGridColumn122.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn122.Header.VisiblePosition = 6;
            ultraGridColumn122.Width = 86;
            ultraGridColumn123.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn123.Header.VisiblePosition = 7;
            ultraGridColumn123.Width = 103;
            ultraGridColumn124.Header.VisiblePosition = 8;
            ultraGridColumn124.Width = 139;
            ultraGridColumn125.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn125.Header.VisiblePosition = 9;
            ultraGridColumn125.Width = 85;
            ultraGridColumn126.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn126.Header.VisiblePosition = 10;
            ultraGridColumn126.Width = 69;
            ultraGridColumn127.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn127.Header.VisiblePosition = 11;
            ultraGridColumn127.Width = 74;
            ultraGridColumn128.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn128.Header.VisiblePosition = 12;
            ultraGridColumn128.Width = 90;
            ultraGridColumn129.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn129.Header.VisiblePosition = 13;
            ultraGridColumn129.Width = 92;
            ultraGridColumn130.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn130.Header.VisiblePosition = 14;
            ultraGridColumn130.Width = 96;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn116,
            ultraGridColumn117,
            ultraGridColumn118,
            ultraGridColumn119,
            ultraGridColumn120,
            ultraGridColumn121,
            ultraGridColumn122,
            ultraGridColumn123,
            ultraGridColumn124,
            ultraGridColumn125,
            ultraGridColumn126,
            ultraGridColumn127,
            ultraGridColumn128,
            ultraGridColumn129,
            ultraGridColumn130});
            ultraGridColumn131.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn131.Header.VisiblePosition = 0;
            ultraGridColumn131.Width = 153;
            ultraGridColumn132.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn132.Header.VisiblePosition = 1;
            ultraGridColumn132.Width = 167;
            ultraGridColumn133.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn133.Header.VisiblePosition = 2;
            ultraGridColumn133.Width = 191;
            ultraGridColumn134.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn134.Header.VisiblePosition = 3;
            ultraGridColumn134.Width = 182;
            ultraGridColumn135.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn135.Header.VisiblePosition = 4;
            ultraGridColumn135.Width = 156;
            ultraGridColumn136.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn136.Header.VisiblePosition = 5;
            ultraGridColumn136.Width = 204;
            ultraGridColumn137.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn137.Header.VisiblePosition = 6;
            ultraGridColumn137.Width = 156;
            ultraGridBand5.Columns.AddRange(new object[] {
            ultraGridColumn131,
            ultraGridColumn132,
            ultraGridColumn133,
            ultraGridColumn134,
            ultraGridColumn135,
            ultraGridColumn136,
            ultraGridColumn137});
            ultraGridColumn138.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn138.Header.VisiblePosition = 0;
            ultraGridColumn138.Width = 124;
            ultraGridColumn139.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn139.Header.VisiblePosition = 1;
            ultraGridColumn139.Width = 178;
            ultraGridColumn140.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn140.Header.VisiblePosition = 2;
            ultraGridColumn140.Width = 185;
            ultraGridColumn141.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn141.Header.VisiblePosition = 3;
            ultraGridColumn141.Width = 158;
            ultraGridColumn142.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn142.Header.VisiblePosition = 4;
            ultraGridColumn142.Width = 125;
            ultraGridColumn143.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn143.Header.VisiblePosition = 5;
            ultraGridColumn143.Width = 178;
            ultraGridColumn144.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn144.Header.VisiblePosition = 6;
            ultraGridColumn144.Width = 136;
            ultraGridColumn145.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn145.Header.VisiblePosition = 7;
            ultraGridColumn145.Width = 125;
            ultraGridBand6.Columns.AddRange(new object[] {
            ultraGridColumn138,
            ultraGridColumn139,
            ultraGridColumn140,
            ultraGridColumn141,
            ultraGridColumn142,
            ultraGridColumn143,
            ultraGridColumn144,
            ultraGridColumn145});
            ultraGridColumn146.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn146.Header.VisiblePosition = 0;
            ultraGridColumn146.Width = 8;
            ultraGridColumn147.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn147.Header.VisiblePosition = 1;
            ultraGridColumn147.Width = 24;
            ultraGridColumn148.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn148.Header.VisiblePosition = 2;
            ultraGridColumn148.Width = 39;
            ultraGridColumn149.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn149.Header.VisiblePosition = 3;
            ultraGridColumn149.Width = 37;
            ultraGridColumn150.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn150.Header.VisiblePosition = 4;
            ultraGridColumn150.Width = 38;
            ultraGridColumn151.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn151.Header.VisiblePosition = 5;
            ultraGridColumn151.Width = 50;
            ultraGridColumn152.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn152.Header.VisiblePosition = 6;
            ultraGridColumn152.Width = 50;
            ultraGridColumn153.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn153.Header.VisiblePosition = 7;
            ultraGridColumn153.Width = 50;
            ultraGridColumn154.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn154.Header.VisiblePosition = 8;
            ultraGridColumn154.Width = 69;
            ultraGridColumn155.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn155.Header.VisiblePosition = 9;
            ultraGridColumn155.Width = 55;
            ultraGridColumn156.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn156.Header.VisiblePosition = 10;
            ultraGridColumn156.Width = 36;
            ultraGridColumn157.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn157.Header.VisiblePosition = 11;
            ultraGridColumn157.Width = 36;
            ultraGridColumn158.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn158.Header.VisiblePosition = 12;
            ultraGridColumn158.Width = 36;
            ultraGridColumn159.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn159.Header.VisiblePosition = 13;
            ultraGridColumn159.Width = 36;
            ultraGridColumn160.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn160.Header.VisiblePosition = 14;
            ultraGridColumn160.Width = 53;
            ultraGridColumn161.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn161.Header.VisiblePosition = 15;
            ultraGridColumn161.Width = 33;
            ultraGridColumn162.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn162.Header.VisiblePosition = 16;
            ultraGridColumn162.Width = 41;
            ultraGridColumn163.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn163.Header.VisiblePosition = 17;
            ultraGridColumn163.Width = 81;
            ultraGridColumn164.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn164.Header.VisiblePosition = 18;
            ultraGridColumn164.Width = 87;
            ultraGridColumn165.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn165.Header.VisiblePosition = 19;
            ultraGridColumn165.Width = 54;
            ultraGridColumn166.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn166.Header.VisiblePosition = 20;
            ultraGridColumn166.Width = 55;
            ultraGridColumn167.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn167.Header.VisiblePosition = 21;
            ultraGridColumn167.Width = 36;
            ultraGridColumn168.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn168.Header.VisiblePosition = 22;
            ultraGridColumn168.Width = 36;
            ultraGridColumn169.Header.VisiblePosition = 23;
            ultraGridColumn169.Width = 169;
            ultraGridBand7.Columns.AddRange(new object[] {
            ultraGridColumn146,
            ultraGridColumn147,
            ultraGridColumn148,
            ultraGridColumn149,
            ultraGridColumn150,
            ultraGridColumn151,
            ultraGridColumn152,
            ultraGridColumn153,
            ultraGridColumn154,
            ultraGridColumn155,
            ultraGridColumn156,
            ultraGridColumn157,
            ultraGridColumn158,
            ultraGridColumn159,
            ultraGridColumn160,
            ultraGridColumn161,
            ultraGridColumn162,
            ultraGridColumn163,
            ultraGridColumn164,
            ultraGridColumn165,
            ultraGridColumn166,
            ultraGridColumn167,
            ultraGridColumn168,
            ultraGridColumn169});
            ultraGridColumn170.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn170.Header.VisiblePosition = 0;
            ultraGridColumn170.Width = 28;
            ultraGridColumn171.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn171.Header.VisiblePosition = 1;
            ultraGridColumn171.Width = 39;
            ultraGridColumn172.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn172.Header.VisiblePosition = 2;
            ultraGridColumn172.Width = 54;
            ultraGridColumn173.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn173.Header.VisiblePosition = 3;
            ultraGridColumn173.Width = 73;
            ultraGridColumn174.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn174.Header.VisiblePosition = 4;
            ultraGridColumn174.Width = 56;
            ultraGridColumn175.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn175.Header.VisiblePosition = 5;
            ultraGridColumn175.Width = 47;
            ultraGridColumn176.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn176.Header.VisiblePosition = 6;
            ultraGridColumn176.Width = 36;
            ultraGridColumn177.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn177.Header.VisiblePosition = 7;
            ultraGridColumn177.Width = 51;
            ultraGridColumn178.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn178.Header.VisiblePosition = 8;
            ultraGridColumn178.Width = 68;
            ultraGridColumn179.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn179.Header.VisiblePosition = 9;
            ultraGridColumn179.Width = 65;
            ultraGridColumn180.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn180.Header.VisiblePosition = 10;
            ultraGridColumn180.Width = 56;
            ultraGridColumn181.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn181.Header.VisiblePosition = 11;
            ultraGridColumn181.Width = 56;
            ultraGridColumn182.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn182.Header.VisiblePosition = 12;
            ultraGridColumn182.Width = 56;
            ultraGridColumn183.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn183.Header.VisiblePosition = 13;
            ultraGridColumn183.Width = 52;
            ultraGridColumn184.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn184.Header.VisiblePosition = 14;
            ultraGridColumn184.Width = 51;
            ultraGridColumn185.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn185.Header.VisiblePosition = 15;
            ultraGridColumn185.Width = 53;
            ultraGridColumn186.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn186.Header.VisiblePosition = 16;
            ultraGridColumn186.Width = 52;
            ultraGridColumn187.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn187.Header.VisiblePosition = 17;
            ultraGridColumn187.Width = 103;
            ultraGridColumn188.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn188.Header.VisiblePosition = 18;
            ultraGridColumn188.Width = 84;
            ultraGridColumn189.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn189.Header.VisiblePosition = 19;
            ultraGridColumn189.Width = 60;
            ultraGridColumn190.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn190.Header.VisiblePosition = 20;
            ultraGridColumn190.Width = 69;
            ultraGridBand8.Columns.AddRange(new object[] {
            ultraGridColumn170,
            ultraGridColumn171,
            ultraGridColumn172,
            ultraGridColumn173,
            ultraGridColumn174,
            ultraGridColumn175,
            ultraGridColumn176,
            ultraGridColumn177,
            ultraGridColumn178,
            ultraGridColumn179,
            ultraGridColumn180,
            ultraGridColumn181,
            ultraGridColumn182,
            ultraGridColumn183,
            ultraGridColumn184,
            ultraGridColumn185,
            ultraGridColumn186,
            ultraGridColumn187,
            ultraGridColumn188,
            ultraGridColumn189,
            ultraGridColumn190});
            ultraGridColumn191.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn191.Header.VisiblePosition = 0;
            ultraGridColumn191.Width = 207;
            ultraGridColumn192.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn192.Header.VisiblePosition = 1;
            ultraGridColumn192.Width = 323;
            ultraGridColumn193.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn193.Header.VisiblePosition = 2;
            ultraGridColumn193.Width = 336;
            ultraGridColumn194.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn194.Header.VisiblePosition = 3;
            ultraGridColumn194.Width = 343;
            ultraGridBand9.Columns.AddRange(new object[] {
            ultraGridColumn191,
            ultraGridColumn192,
            ultraGridColumn193,
            ultraGridColumn194});
            this.ugrdGK.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ugrdGK.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.ugrdGK.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.ugrdGK.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.ugrdGK.DisplayLayout.BandsSerializer.Add(ultraGridBand5);
            this.ugrdGK.DisplayLayout.BandsSerializer.Add(ultraGridBand6);
            this.ugrdGK.DisplayLayout.BandsSerializer.Add(ultraGridBand7);
            this.ugrdGK.DisplayLayout.BandsSerializer.Add(ultraGridBand8);
            this.ugrdGK.DisplayLayout.BandsSerializer.Add(ultraGridBand9);
            this.ugrdGK.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.ugrdGK.DisplayLayout.Override.CardAreaAppearance = appearance8;
            this.ugrdGK.DisplayLayout.Override.CellPadding = 3;
            appearance10.TextHAlignAsString = "Left";
            this.ugrdGK.DisplayLayout.Override.HeaderAppearance = appearance10;
            appearance17.BorderColor = System.Drawing.Color.LightGray;
            appearance17.TextVAlignAsString = "Middle";
            this.ugrdGK.DisplayLayout.Override.RowAppearance = appearance17;
            this.ugrdGK.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance18.BackColor = System.Drawing.Color.Navy;
            appearance18.BorderColor = System.Drawing.Color.Black;
            appearance18.ForeColor = System.Drawing.Color.White;
            this.ugrdGK.DisplayLayout.Override.SelectedRowAppearance = appearance18;
            this.ugrdGK.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.ugrdGK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ugrdGK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ugrdGK.Location = new System.Drawing.Point(0, 0);
            this.ugrdGK.Name = "ugrdGK";
            this.ugrdGK.Size = new System.Drawing.Size(1268, 545);
            this.ugrdGK.TabIndex = 4;
            this.ugrdGK.UseAppStyling = false;
            this.ugrdGK.AfterCellActivate += new System.EventHandler(this.ugrdGK_AfterCellActivate);
            this.ugrdGK.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.ugrdGK_AfterCellUpdate);
            this.ugrdGK.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ugrdGK_InitializeLayout);
            this.ugrdGK.AfterEnterEditMode += new System.EventHandler(this.ugrdGK_AfterEnterEditMode);
            this.ugrdGK.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.ugrdGK_AfterRowUpdate);
            // 
            // RadnikDataSet1
            // 
            this.RadnikDataSet1.DataSetName = "RADNIKDataSet";
            // 
            // BankeDataSet1
            // 
            this.BankeDataSet1.DataSetName = "BANKEDataSet";
            // 
            // OpcinaDataSet1
            // 
            this.OpcinaDataSet1.DataSetName = "OPCINADataSet";
            // 
            // SkupporezaidoprinosaDataSet1
            // 
            this.SkupporezaidoprinosaDataSet1.DataSetName = "SKUPPOREZAIDOPRINOSADataSet";
            // 
            // BANKE
            // 
            this.BANKE.DataMember = "BANKE";
            this.BANKE.DataSource = this.BankeDataSet1;
            ultraGridColumn195.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn195.Header.VisiblePosition = 0;
            ultraGridColumn196.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn196.Header.VisiblePosition = 1;
            ultraGridColumn197.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn197.Header.VisiblePosition = 2;
            ultraGridColumn198.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn198.Header.VisiblePosition = 3;
            ultraGridColumn199.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn199.Header.VisiblePosition = 4;
            ultraGridColumn200.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn200.Header.VisiblePosition = 5;
            ultraGridColumn201.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn201.Header.VisiblePosition = 6;
            ultraGridColumn202.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn202.Header.VisiblePosition = 7;
            ultraGridColumn203.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn203.Header.VisiblePosition = 8;
            ultraGridColumn204.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn204.Header.VisiblePosition = 9;
            ultraGridColumn205.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn205.Header.VisiblePosition = 10;
            ultraGridColumn206.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn206.Header.VisiblePosition = 11;
            ultraGridBand10.Columns.AddRange(new object[] {
            ultraGridColumn195,
            ultraGridColumn196,
            ultraGridColumn197,
            ultraGridColumn198,
            ultraGridColumn199,
            ultraGridColumn200,
            ultraGridColumn201,
            ultraGridColumn202,
            ultraGridColumn203,
            ultraGridColumn204,
            ultraGridColumn205,
            ultraGridColumn206});
            this.BANKE.DisplayLayout.BandsSerializer.Add(ultraGridBand10);
            this.BANKE.DisplayMember = "IDBANKE";
            this.BANKE.DropDownSearchMethod = Infragistics.Win.UltraWinGrid.DropDownSearchMethod.Linear;
            this.BANKE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BANKE.Location = new System.Drawing.Point(554, 232);
            this.BANKE.Name = "BANKE";
            this.BANKE.Size = new System.Drawing.Size(160, 80);
            this.BANKE.TabIndex = 8;
            this.BANKE.ValueMember = "IDBANKE";
            this.BANKE.Visible = false;
            // 
            // BENEFICIRANI
            // 
            this.BENEFICIRANI.DataMember = "BENEFICIRANI";
            this.BENEFICIRANI.DataSource = this.BeneficiraniDataSet1;
            appearance.BackColor = System.Drawing.Color.White;
            this.BENEFICIRANI.DisplayLayout.Appearance = appearance;
            ultraGridColumn207.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn207.Header.VisiblePosition = 0;
            ultraGridColumn208.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn208.Header.VisiblePosition = 1;
            ultraGridColumn209.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn209.Header.VisiblePosition = 2;
            ultraGridBand11.Columns.AddRange(new object[] {
            ultraGridColumn207,
            ultraGridColumn208,
            ultraGridColumn209});
            this.BENEFICIRANI.DisplayLayout.BandsSerializer.Add(ultraGridBand11);
            this.BENEFICIRANI.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance9.BackColor = System.Drawing.Color.Transparent;
            this.BENEFICIRANI.DisplayLayout.Override.CardAreaAppearance = appearance9;
            this.BENEFICIRANI.DisplayLayout.Override.CellPadding = 3;
            appearance16.TextHAlignAsString = "Left";
            this.BENEFICIRANI.DisplayLayout.Override.HeaderAppearance = appearance16;
            appearance19.BorderColor = System.Drawing.Color.LightGray;
            appearance19.TextVAlignAsString = "Middle";
            this.BENEFICIRANI.DisplayLayout.Override.RowAppearance = appearance19;
            this.BENEFICIRANI.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance20.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance20.BorderColor = System.Drawing.Color.Black;
            appearance20.ForeColor = System.Drawing.Color.Black;
            this.BENEFICIRANI.DisplayLayout.Override.SelectedRowAppearance = appearance20;
            this.BENEFICIRANI.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.BENEFICIRANI.DropDownSearchMethod = Infragistics.Win.UltraWinGrid.DropDownSearchMethod.Linear;
            this.BENEFICIRANI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BENEFICIRANI.Location = new System.Drawing.Point(766, 323);
            this.BENEFICIRANI.Name = "BENEFICIRANI";
            this.BENEFICIRANI.Size = new System.Drawing.Size(160, 80);
            this.BENEFICIRANI.TabIndex = 9;
            this.BENEFICIRANI.ValueMember = "IDBENEFICIRANI";
            this.BENEFICIRANI.Visible = false;
            // 
            // BeneficiraniDataSet1
            // 
            this.BeneficiraniDataSet1.DataSetName = "BENEFICIRANIDataSet";
            // 
            // SKUPINA
            // 
            this.SKUPINA.DataMember = "SKUPPOREZAIDOPRINOSA";
            this.SKUPINA.DataSource = this.SkupporezaidoprinosaDataSet1;
            appearance11.BackColor = System.Drawing.Color.White;
            this.SKUPINA.DisplayLayout.Appearance = appearance11;
            ultraGridColumn210.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn210.Header.VisiblePosition = 0;
            ultraGridColumn211.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn211.Header.VisiblePosition = 1;
            ultraGridColumn212.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn212.Header.VisiblePosition = 2;
            ultraGridColumn213.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn213.Header.VisiblePosition = 3;
            ultraGridBand12.Columns.AddRange(new object[] {
            ultraGridColumn210,
            ultraGridColumn211,
            ultraGridColumn212,
            ultraGridColumn213});
            ultraGridColumn214.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn214.Header.VisiblePosition = 0;
            ultraGridColumn215.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn215.Header.VisiblePosition = 1;
            ultraGridColumn216.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn216.Header.VisiblePosition = 2;
            ultraGridColumn217.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn217.Header.VisiblePosition = 3;
            ultraGridColumn218.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn218.Header.VisiblePosition = 4;
            ultraGridColumn219.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn219.Header.VisiblePosition = 5;
            ultraGridColumn220.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn220.Header.VisiblePosition = 6;
            ultraGridColumn221.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn221.Header.VisiblePosition = 7;
            ultraGridColumn222.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn222.Header.VisiblePosition = 8;
            ultraGridColumn223.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn223.Header.VisiblePosition = 9;
            ultraGridColumn224.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn224.Header.VisiblePosition = 10;
            ultraGridColumn225.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn225.Header.VisiblePosition = 11;
            ultraGridColumn226.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn226.Header.VisiblePosition = 12;
            ultraGridColumn227.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn227.Header.VisiblePosition = 13;
            ultraGridColumn228.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn228.Header.VisiblePosition = 14;
            ultraGridColumn229.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn229.Header.VisiblePosition = 15;
            ultraGridColumn230.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn230.Header.VisiblePosition = 16;
            ultraGridColumn231.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn231.Header.VisiblePosition = 17;
            ultraGridBand13.Columns.AddRange(new object[] {
            ultraGridColumn214,
            ultraGridColumn215,
            ultraGridColumn216,
            ultraGridColumn217,
            ultraGridColumn218,
            ultraGridColumn219,
            ultraGridColumn220,
            ultraGridColumn221,
            ultraGridColumn222,
            ultraGridColumn223,
            ultraGridColumn224,
            ultraGridColumn225,
            ultraGridColumn226,
            ultraGridColumn227,
            ultraGridColumn228,
            ultraGridColumn229,
            ultraGridColumn230,
            ultraGridColumn231});
            ultraGridColumn232.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn232.Header.VisiblePosition = 0;
            ultraGridColumn233.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn233.Header.VisiblePosition = 1;
            ultraGridColumn234.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn234.Header.VisiblePosition = 2;
            ultraGridColumn235.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn235.Header.VisiblePosition = 3;
            ultraGridColumn236.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn236.Header.VisiblePosition = 4;
            ultraGridColumn237.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn237.Header.VisiblePosition = 5;
            ultraGridColumn238.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn238.Header.VisiblePosition = 6;
            ultraGridColumn239.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn239.Header.VisiblePosition = 7;
            ultraGridColumn240.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn240.Header.VisiblePosition = 8;
            ultraGridColumn241.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn241.Header.VisiblePosition = 9;
            ultraGridColumn242.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn242.Header.VisiblePosition = 10;
            ultraGridColumn243.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn243.Header.VisiblePosition = 11;
            ultraGridColumn244.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn244.Header.VisiblePosition = 12;
            ultraGridBand14.Columns.AddRange(new object[] {
            ultraGridColumn232,
            ultraGridColumn233,
            ultraGridColumn234,
            ultraGridColumn235,
            ultraGridColumn236,
            ultraGridColumn237,
            ultraGridColumn238,
            ultraGridColumn239,
            ultraGridColumn240,
            ultraGridColumn241,
            ultraGridColumn242,
            ultraGridColumn243,
            ultraGridColumn244});
            this.SKUPINA.DisplayLayout.BandsSerializer.Add(ultraGridBand12);
            this.SKUPINA.DisplayLayout.BandsSerializer.Add(ultraGridBand13);
            this.SKUPINA.DisplayLayout.BandsSerializer.Add(ultraGridBand14);
            this.SKUPINA.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance12.BackColor = System.Drawing.Color.Transparent;
            this.SKUPINA.DisplayLayout.Override.CardAreaAppearance = appearance12;
            this.SKUPINA.DisplayLayout.Override.CellPadding = 3;
            appearance13.TextHAlignAsString = "Left";
            this.SKUPINA.DisplayLayout.Override.HeaderAppearance = appearance13;
            appearance14.BorderColor = System.Drawing.Color.LightGray;
            appearance14.TextVAlignAsString = "Middle";
            this.SKUPINA.DisplayLayout.Override.RowAppearance = appearance14;
            this.SKUPINA.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance15.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance15.BorderColor = System.Drawing.Color.Black;
            appearance15.ForeColor = System.Drawing.Color.Black;
            this.SKUPINA.DisplayLayout.Override.SelectedRowAppearance = appearance15;
            this.SKUPINA.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.SKUPINA.DisplayMember = "IDSKUPPOREZAIDOPRINOSA";
            this.SKUPINA.DropDownSearchMethod = Infragistics.Win.UltraWinGrid.DropDownSearchMethod.Linear;
            this.SKUPINA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SKUPINA.Location = new System.Drawing.Point(568, 383);
            this.SKUPINA.Name = "SKUPINA";
            this.SKUPINA.Size = new System.Drawing.Size(160, 80);
            this.SKUPINA.TabIndex = 10;
            this.SKUPINA.ValueMember = "IDSKUPPOREZAIDOPRINOSA";
            this.SKUPINA.Visible = false;
            // 
            // OPCINA
            // 
            this.OPCINA.DataMember = "OPCINA";
            this.OPCINA.DataSource = this.OpcinaDataSet1;
            ultraGridColumn245.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn245.Header.VisiblePosition = 0;
            ultraGridColumn246.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn246.Header.VisiblePosition = 1;
            ultraGridColumn247.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn247.Header.VisiblePosition = 2;
            ultraGridColumn248.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn248.Header.VisiblePosition = 3;
            ultraGridColumn249.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn249.Header.VisiblePosition = 4;
            ultraGridBand15.Columns.AddRange(new object[] {
            ultraGridColumn245,
            ultraGridColumn246,
            ultraGridColumn247,
            ultraGridColumn248,
            ultraGridColumn249});
            this.OPCINA.DisplayLayout.BandsSerializer.Add(ultraGridBand15);
            this.OPCINA.DisplayMember = "IDOPCINE";
            this.OPCINA.DropDownSearchMethod = Infragistics.Win.UltraWinGrid.DropDownSearchMethod.Linear;
            this.OPCINA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OPCINA.Location = new System.Drawing.Point(789, 222);
            this.OPCINA.Name = "OPCINA";
            this.OPCINA.Size = new System.Drawing.Size(160, 80);
            this.OPCINA.TabIndex = 11;
            this.OPCINA.ValueMember = "IDOPCINE";
            this.OPCINA.Visible = false;
            // 
            // IpidentDataSet1
            // 
            this.IpidentDataSet1.DataSetName = "IPIDENTDataSet";
            // 
            // IPIDENT
            // 
            this.IPIDENT.DataMember = "IPIDENT";
            this.IPIDENT.DataSource = this.IpidentDataSet1;
            appearance2.BackColor = System.Drawing.Color.White;
            this.IPIDENT.DisplayLayout.Appearance = appearance2;
            ultraGridColumn250.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn250.Header.VisiblePosition = 0;
            ultraGridColumn251.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn251.Header.VisiblePosition = 1;
            ultraGridBand16.Columns.AddRange(new object[] {
            ultraGridColumn250,
            ultraGridColumn251});
            this.IPIDENT.DisplayLayout.BandsSerializer.Add(ultraGridBand16);
            this.IPIDENT.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.IPIDENT.DisplayLayout.Override.CardAreaAppearance = appearance3;
            this.IPIDENT.DisplayLayout.Override.CellPadding = 3;
            appearance4.TextHAlignAsString = "Left";
            this.IPIDENT.DisplayLayout.Override.HeaderAppearance = appearance4;
            appearance6.BorderColor = System.Drawing.Color.LightGray;
            appearance6.TextVAlignAsString = "Middle";
            this.IPIDENT.DisplayLayout.Override.RowAppearance = appearance6;
            this.IPIDENT.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance7.BorderColor = System.Drawing.Color.Black;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.IPIDENT.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.IPIDENT.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.IPIDENT.DropDownSearchMethod = Infragistics.Win.UltraWinGrid.DropDownSearchMethod.Linear;
            this.IPIDENT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IPIDENT.Location = new System.Drawing.Point(1009, 302);
            this.IPIDENT.Name = "IPIDENT";
            this.IPIDENT.Size = new System.Drawing.Size(160, 80);
            this.IPIDENT.TabIndex = 12;
            this.IPIDENT.ValueMember = "IDIPIDENT";
            this.IPIDENT.Visible = false;
            // 
            // frmIspravakOsnovnihPodataka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 545);
            this.Controls.Add(this.IPIDENT);
            this.Controls.Add(this.OPCINA);
            this.Controls.Add(this.SKUPINA);
            this.Controls.Add(this.BENEFICIRANI);
            this.Controls.Add(this.BANKE);
            this.Controls.Add(this.ugrdGK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIspravakOsnovnihPodataka";
            this.Text = "Ispravak osnovnih matičnih podataka o radnicima";
            ((System.ComponentModel.ISupportInitialize)(this.ugrdGK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadnikDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BankeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpcinaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkupporezaidoprinosaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BANKE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BENEFICIRANI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeneficiraniDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SKUPINA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OPCINA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IpidentDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPIDENT)).EndInit();
            this.ResumeLayout(false);

        }

        private void ugrdGK_AfterCellActivate(object sender, EventArgs e)
        {
        }

        private void ugrdGK_AfterCellUpdate(object sender, CellEventArgs e)
        {
        }

        private void ugrdGK_AfterEnterEditMode(object sender, EventArgs e)
        {
            this.ugrdGK.ActiveCell.SelectAll();
        }

        private void ugrdGK_AfterRowUpdate(object sender, RowEventArgs e)
        {
            RADNIKDataAdapter adapter = new RADNIKDataAdapter();
            try
            {
                adapter.Update(this.RadnikDataSet1);
            }
            catch (System.Exception exception1)
            {
                throw exception1;                
            }
        }

        private void ugrdGK_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private UltraDropDown BANKE;

        private BANKEDataSet BankeDataSet1;

        private UltraDropDown BENEFICIRANI;

        private BENEFICIRANIDataSet BeneficiraniDataSet1;

        private UltraDropDown IPIDENT;

        private IPIDENTDataSet IpidentDataSet1;

        private UltraDropDown OPCINA;

        private OPCINADataSet OpcinaDataSet1;

        private RADNIKDataSet RadnikDataSet1;

        private UltraDropDown SKUPINA;

        private SKUPPOREZAIDOPRINOSADataSet SkupporezaidoprinosaDataSet1;

        private UltraGrid ugrdGK;
    }
}

