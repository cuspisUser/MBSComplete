using DatotekeZaBanku;
using Hlp;
using Infragistics.Win.UltraWinTabControl;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using NetAdvantage;
using System.Data.SqlClient;

public class frmRadSaBankama : Form
{
    private IContainer components { get; set; }
    public string gm_sIDObracun;
    public string gm_sZiro;
    private Panel panel1;
    private RichTextBox richTextBox1;
    public Placa.VIRMANIDataSet VirmaniDataSet1;

    public frmRadSaBankama()
    {
        base.Load += new EventHandler(this.frmDisketaOdaberiBanku_Load);
        this.gm_sIDObracun = "";
        this.gm_sZiro = "";
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

    private void frmDisketaOdaberiBanku_Load(object sender, EventArgs e)
    {
        new BANKEDataAdapter().Fill(this.BankeDataSet1);
        DatotekaZaba zaba = new DatotekaZaba();
        DatotekaPBZ apbz = new DatotekaPBZ();
        DatotekaErste erste = new DatotekaErste();
        zaba.sifraObracuna = this.gm_sIDObracun;
        zaba.Ziro = this.gm_sZiro;
        apbz.sifraObracuna = this.gm_sIDObracun;
        apbz.Ziro = this.gm_sZiro;
        erste.SifraObracuna = this.gm_sIDObracun;
        erste.Ziro = this.gm_sZiro;
        DatotekaHYPO ahypo = new DatotekaHYPO {
            SifraObracuna = this.gm_sIDObracun,
            Ziro = this.gm_sZiro
        };
        DatotekaRAIF araif = new DatotekaRAIF {
            sifraObracuna = this.gm_sIDObracun,
            Ziro = this.gm_sZiro
        };
        DatotekaSplitska splitska = new DatotekaSplitska {
            sifraObracuna = this.gm_sIDObracun,
            Ziro = this.gm_sZiro
        };
        DatotekaPOBA apoba = new DatotekaPOBA {
            sifraObracuna = this.gm_sIDObracun,
            Ziro = this.gm_sZiro
        };
        DatotekaHPB ahpb = new DatotekaHPB {
            SifraObracuna = this.gm_sIDObracun,
            Ziro = this.gm_sZiro
        };
        DataRow[] rowArray = this.BankeDataSet1.BANKE.Select("vbdibanke = '2407000'");
        DatotekaOTP aotp = new DatotekaOTP();
        if (rowArray.Length > 0)
        {
            aotp.sifraObracuna = this.gm_sIDObracun;
            aotp.Model = DB.N2T(RuntimeHelpers.GetObjectValue(rowArray[0]["mobanka"]), "");
            aotp.Poziv = DB.N2T(RuntimeHelpers.GetObjectValue(rowArray[0]["pobanka"]), "");
            aotp.Ziro = this.gm_sZiro;
        }
        DatotekaMedj medj = new DatotekaMedj {
            sifraObracuna = this.gm_sIDObracun,
            Ziro = this.gm_sZiro
        };
        DatotekaKarlovacka karlovacka = new DatotekaKarlovacka {
            SifraObracuna = this.gm_sIDObracun,
            Ziro = this.gm_sZiro
        };
        DatotekaJadranska jadranska = new DatotekaJadranska {
            Obracun = this.gm_sIDObracun,
            Ziro = this.gm_sZiro
        };
        /*
         * Matija - 07.03.2013. - u dogovoru sa Mariom, ovaj dio je deaktiviran, pošto nije radio niti u Op-u.
         * Antun: "nikada to nije radilo, i nikada me to nitko nije pitao zašto to ne radi, niti da treba tu funkcionalnost"
        DatotekaHZZO ahzzo = new DatotekaHZZO {
            Obracun = this.gm_sIDObracun
        };
        */
        this.UltraTabPageControl2.Controls.Add(apbz);
        this.UltraTabPageControl3.Controls.Add(zaba);
        this.UltraTabPageControl4.Controls.Add(erste);
        this.UltraTabPageControl5.Controls.Add(araif);
        this.UltraTabPageControl6.Controls.Add(ahypo);
        this.UltraTabPageControl7.Controls.Add(splitska);
        this.UltraTabPageControl8.Controls.Add(apoba);
        this.UltraTabPageControl9.Controls.Add(ahpb);
        this.UltraTabPageControl10.Controls.Add(aotp);
        this.UltraTabPageControl11.Controls.Add(medj);
        this.UltraTabPageControl12.Controls.Add(karlovacka);
        this.UltraTabPageControl13.Controls.Add(jadranska);

        // this.UltraTabPageControl25.Controls.Add(ahzzo);
    }

    public void IzradiDatotekuZbrojnogNalogaPoBanci(string vbdi, DateTime? datumPredaje, string modelZaduzenjaParametar, string pozivNaBrojZaduzenjaParametar)
    {
        if (datumPredaje == null)
            datumPredaje = DateTime.Today;

        //
        DateTime datumIzvrsenja = datumPredaje.Value; // this.DATUMIZVRSENJA.Value;

        // Instanciramo korištenje datoteke
        DatotekaZbrojnogNaloga datoteka = new DatotekaZbrojnogNaloga();
        datoteka.InicijalizirajDatoteku();

        // Instanciramo generiranje IBAN-a
        IBAN iban = new IBAN();

        KORISNIKDataAdapter korisnikDataAdapter = new KORISNIKDataAdapter();
        KORISNIKDataSet korisnikDataSet = new KORISNIKDataSet();
        korisnikDataAdapter.Fill(korisnikDataSet);



        Mipsed7.DataAccessLayer.SqlClient sqlClient = new Mipsed7.DataAccessLayer.SqlClient();
        
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "dbo.S_PLACA_DATOTEKA_ZN_SPECIFIKACIJA";
        sqlCommand.Parameters.AddWithValue("IDOBRACUN", this.gm_sIDObracun);
        sqlCommand.Parameters.AddWithValue("VBDIBANKE", vbdi);

        DataTable dtZNspecifikacija = sqlClient.GetDataTable(sqlCommand);

        

        /*
        sp_diskete_za_bankuDataAdapter placaIsplataBankaAdapter = new sp_diskete_za_bankuDataAdapter();
        sp_diskete_za_bankuDataSet placaIsplataBankaDataSet = new sp_diskete_za_bankuDataSet();
        placaIsplataBankaAdapter.Fill(placaIsplataBankaDataSet, this.gm_sIDObracun, vbdi);
         * */

        // *************************************************************************
        // Generiranje sloga 300
        // *************************************************************************
        string vrstaNaloga = "4"; // 4 - plaće, ostala redovna i povremena primanja
        string izvorDokumenta = this.VirmaniDataSet1.VIRMANI.Rows[0]["izvordokumenta"].ToString();
        string nacinIzvrsenja = "1";
        string oibPoslodavca = korisnikDataSet.KORISNIK[0]["KORISNIKOIB"].ToString();
        string maticniBrojPoslodavca = korisnikDataSet.KORISNIK[0]["MBKORISNIK"].ToString();
        string oibUplatiteljaOsobnogPrimanja = string.Empty;


        // Marko K. (27.05.2013.):
        // "Plaća sa riznice uplatitelj OIB MZOS. Plaća sa vlastitog ŽRN OIB uplatitelja Korisnik"
        if (izvorDokumenta == "530")
            oibUplatiteljaOsobnogPrimanja = "49508397045"; // OIB MZOŠ-a
        else if (izvorDokumenta == "701")
            oibUplatiteljaOsobnogPrimanja = korisnikDataSet.KORISNIK[0]["KORISNIKOIB"].ToString();


        datoteka.GenerirajSLOG_300(datumPredaje.Value, vrstaNaloga, izvorDokumenta, nacinIzvrsenja, oibPoslodavca, maticniBrojPoslodavca, string.Empty, oibUplatiteljaOsobnogPrimanja, string.Empty);
        // -------------------------------------------------------------------------


        // *************************************************************************
        // Generiranje sloga 301
        // *************************************************************************
        string ibanPlatitelja = iban.GenerirajIBANIzBrojaRacuna(VirmaniDataSet1.VIRMANI.Rows[0]["BROJRACUNAPLA"].ToString(), true, false);
        string oznakaValutePlacanja = "HRK"; // za vrstu naloga, mora biti HRK
        string ukupanBrojNaloga = dtZNspecifikacija.Compute("count(IDRADNIK)", "VBDIBANKE LIKE '%" + vbdi + "%'").ToString();
        object ukupanIznosNalogaTemp = dtZNspecifikacija.Compute("SUM(UKUPNOZAISPLATU)", "VBDIBANKE LIKE '%" + vbdi + "%'");

        if (ukupanIznosNalogaTemp == DBNull.Value)
            ukupanIznosNalogaTemp = 0;

        string ukupanIznosNaloga = Decimal.Round(Convert.ToDecimal(ukupanIznosNalogaTemp), 2).ToString("n2").Replace(",", string.Empty).Replace(".", string.Empty);
        DateTime datumIzvrsenjaNaloga = datumIzvrsenja;

        datoteka.GenerirajSLOG_301(ibanPlatitelja, oznakaValutePlacanja, string.Empty, string.Empty, ukupanBrojNaloga, ukupanIznosNaloga, datumIzvrsenjaNaloga, string.Empty);

        // -------------------------------------------------------------------------


        // *************************************************************************
        // Generiranje sloga 309 - jedan redak za SVAKI redak u bazi
        // *************************************************************************

        bool primateljiPostoje = false;

        foreach (DataRow dr in dtZNspecifikacija.Rows)
        {
            if (dr["VBDIBANKE"].ToString().Contains(vbdi))
            {
                primateljiPostoje = true;

                string brojRacunaPrimatelja = string.Format("{0}-{1}", dr["VBDIBANKE"], dr["TEKUCI"].ToString());

                string ibanPrimatelja = iban.GenerirajIBANIzBrojaRacuna(brojRacunaPrimatelja.Trim(), true, false);
                string primatelj1 = string.Empty;
                string primatelj2 = string.Empty;
                string primatelj3 = string.Empty;
                string modelZaduzenja = string.Empty;
                string pozivZaduzenja = string.Empty;
                string modelOdobrenja = string.Empty;
                string pozivOdobrenja = string.Empty;
                string hub3_sifraNamjene = string.Empty;
                string hub3_hitnost = string.Empty;
                string opisPlacanja = string.Empty;
                string iznos = string.Empty;
                string sifraVrstaOsobnihPrimanja = "100"; // defaultno ćemo staviti šifru 100 - 

                hub3_hitnost = "0";

                primatelj1 = string.Format("{0} {1}", dr["IME"], dr["PREZIME"]);

                /*
                if (dr["MZBANKA"] != DBNull.Value)
                {
                    if (!string.IsNullOrWhiteSpace(dr["MZBANKA"].ToString()))
                    {
                        modelZaduzenja = "HR" + dr["MZBANKA"].Trim().ToString();
                    }
                }
                */
                if (!string.IsNullOrWhiteSpace(modelZaduzenjaParametar.Trim()))
                    modelZaduzenja = "HR" + modelZaduzenjaParametar;

                /*
                if (dr["PZBANKA"] != DBNull.Value)
                {
                    pozivZaduzenja = dr["PZBANKA"].ToString().Trim();
                }
                */
                pozivZaduzenja = pozivNaBrojZaduzenjaParametar;



                if (dr["MOBANKA"] != DBNull.Value)
                {
                    if (!string.IsNullOrWhiteSpace(dr["MOBANKA"].ToString()))
                    {
                        modelOdobrenja = "HR" + dr["MOBANKA"].ToString().Trim();
                    }
                }

                if (dr["POBANKA"] != DBNull.Value)
                {
                    pozivOdobrenja = dr["POBANKA"].ToString().Trim();
                }

                hub3_sifraNamjene = "SALA";
                hub3_hitnost = "0";

                if (dr["OPISPLACANJANETO"] != DBNull.Value)
                {
                    opisPlacanja = dr["OPISPLACANJANETO"].ToString().Replace("/", "-");
                }

                if (dr["UKUPNOZAISPLATU"] != DBNull.Value)
                {
                    iznos = Decimal.Round(Convert.ToDecimal(dr["UKUPNOZAISPLATU"]), 2).ToString("n2").Replace(",", string.Empty).Replace(".", string.Empty);
                }
                
                sifraVrstaOsobnihPrimanja = "100";


                datoteka.GenerirajSLOG_309(ibanPrimatelja, primatelj1, primatelj2, primatelj3, string.Empty,
                                           modelZaduzenja, pozivZaduzenja, hub3_sifraNamjene, opisPlacanja, iznos,
                                           modelOdobrenja, pozivOdobrenja, string.Empty, string.Empty, string.Empty,
                                           string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                           hub3_hitnost, sifraVrstaOsobnihPrimanja, string.Empty);

            }
        }

        if (!primateljiPostoje)
        {
            MessageBox.Show("Ne postoje primatelji za odabranu banku!", "Kreiranje datoteke", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            datoteka = null;
            return;
        }

        // -------------------------------------------------------------------------


        // *************************************************************************
        // Generiranje sloga 399
        // *************************************************************************
        datoteka.GenerirajSLOG_399(string.Empty);



        // SPREMANJE datoteke

        datoteka.SpremiDatoteku(datumPredaje.Value);
    }

    private void InitializeComponent()
    {
            Infragistics.Win.UltraWinTabControl.UltraTab tab7 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab tab8 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab tab9 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab tab10 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab tab11 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab tab12 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab tab13 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab tab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab tab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab tab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab tab5 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab tab6 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRadSaBankama));
            this.UltraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl5 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl6 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl7 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl8 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl9 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl10 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl11 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl12 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl13 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl25 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.BankeDataSet1 = new Placa.BANKEDataSet();
            this.UltraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.UltraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.UltraTabPageControl14 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl15 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl16 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl17 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl18 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl19 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl20 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl21 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl22 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl23 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl24 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.UltraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.BankeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraTabControl1)).BeginInit();
            this.UltraTabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UltraTabPageControl2
            // 
            this.UltraTabPageControl2.Location = new System.Drawing.Point(1, 22);
            this.UltraTabPageControl2.Name = "UltraTabPageControl2";
            this.UltraTabPageControl2.Size = new System.Drawing.Size(1002, 217);
            // 
            // UltraTabPageControl3
            // 
            this.UltraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl3.Name = "UltraTabPageControl3";
            this.UltraTabPageControl3.Size = new System.Drawing.Size(1002, 217);
            // 
            // UltraTabPageControl4
            // 
            this.UltraTabPageControl4.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl4.Name = "UltraTabPageControl4";
            this.UltraTabPageControl4.Size = new System.Drawing.Size(1002, 217);
            // 
            // UltraTabPageControl5
            // 
            this.UltraTabPageControl5.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl5.Name = "UltraTabPageControl5";
            this.UltraTabPageControl5.Size = new System.Drawing.Size(1002, 217);
            // 
            // UltraTabPageControl6
            // 
            this.UltraTabPageControl6.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl6.Name = "UltraTabPageControl6";
            this.UltraTabPageControl6.Size = new System.Drawing.Size(1002, 217);
            // 
            // UltraTabPageControl7
            // 
            this.UltraTabPageControl7.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl7.Name = "UltraTabPageControl7";
            this.UltraTabPageControl7.Size = new System.Drawing.Size(1002, 217);
            // 
            // UltraTabPageControl8
            // 
            this.UltraTabPageControl8.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl8.Name = "UltraTabPageControl8";
            this.UltraTabPageControl8.Size = new System.Drawing.Size(1002, 217);
            // 
            // UltraTabPageControl9
            // 
            this.UltraTabPageControl9.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl9.Name = "UltraTabPageControl9";
            this.UltraTabPageControl9.Size = new System.Drawing.Size(1002, 217);
            // 
            // UltraTabPageControl10
            // 
            this.UltraTabPageControl10.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl10.Name = "UltraTabPageControl10";
            this.UltraTabPageControl10.Size = new System.Drawing.Size(1002, 217);
            // 
            // UltraTabPageControl11
            // 
            this.UltraTabPageControl11.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl11.Name = "UltraTabPageControl11";
            this.UltraTabPageControl11.Size = new System.Drawing.Size(1002, 217);
            // 
            // UltraTabPageControl12
            // 
            this.UltraTabPageControl12.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl12.Name = "UltraTabPageControl12";
            this.UltraTabPageControl12.Size = new System.Drawing.Size(1002, 217);
            // 
            // UltraTabPageControl13
            // 
            this.UltraTabPageControl13.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl13.Name = "UltraTabPageControl13";
            this.UltraTabPageControl13.Size = new System.Drawing.Size(1002, 217);
            // 
            // UltraTabPageControl25
            // 
            this.UltraTabPageControl25.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl25.Name = "UltraTabPageControl25";
            this.UltraTabPageControl25.Size = new System.Drawing.Size(1002, 501);
            // 
            // BankeDataSet1
            // 
            this.BankeDataSet1.DataSetName = "BANKEDataSet";
            this.BankeDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // UltraTabControl1
            // 
            this.UltraTabControl1.Controls.Add(this.UltraTabSharedControlsPage1);
            this.UltraTabControl1.Controls.Add(this.UltraTabPageControl2);
            this.UltraTabControl1.Controls.Add(this.UltraTabPageControl3);
            this.UltraTabControl1.Controls.Add(this.UltraTabPageControl4);
            this.UltraTabControl1.Controls.Add(this.UltraTabPageControl5);
            this.UltraTabControl1.Controls.Add(this.UltraTabPageControl6);
            this.UltraTabControl1.Controls.Add(this.UltraTabPageControl7);
            this.UltraTabControl1.Controls.Add(this.UltraTabPageControl8);
            this.UltraTabControl1.Controls.Add(this.UltraTabPageControl9);
            this.UltraTabControl1.Controls.Add(this.UltraTabPageControl10);
            this.UltraTabControl1.Controls.Add(this.UltraTabPageControl11);
            this.UltraTabControl1.Controls.Add(this.UltraTabPageControl12);
            this.UltraTabControl1.Controls.Add(this.UltraTabPageControl13);
            this.UltraTabControl1.Controls.Add(this.UltraTabPageControl25);
            this.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.UltraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.UltraTabControl1.Name = "UltraTabControl1";
            this.UltraTabControl1.SharedControlsPage = this.UltraTabSharedControlsPage1;
            this.UltraTabControl1.Size = new System.Drawing.Size(1004, 240);
            this.UltraTabControl1.TabIndex = 0;
            tab7.Key = "ZABA";
            tab7.TabPage = this.UltraTabPageControl2;
            tab7.Text = "Pbz";
            tab8.Key = "PBZ";
            tab8.TabPage = this.UltraTabPageControl3;
            tab8.Text = "Zaba";
            tab9.TabPage = this.UltraTabPageControl4;
            tab9.Text = "Erste";
            tab10.TabPage = this.UltraTabPageControl5;
            tab10.Text = "Raif";
            tab11.TabPage = this.UltraTabPageControl6;
            tab11.Text = "Hypo";
            tab12.TabPage = this.UltraTabPageControl7;
            tab12.Text = "Splitska";
            tab13.TabPage = this.UltraTabPageControl8;
            tab13.Text = "Podravska";
            tab2.TabPage = this.UltraTabPageControl9;
            tab2.Text = "Hpb";
            tab3.TabPage = this.UltraTabPageControl10;
            tab3.Text = "Otp";
            tab4.TabPage = this.UltraTabPageControl11;
            tab4.Text = "Međimurska";
            tab5.TabPage = this.UltraTabPageControl12;
            tab5.Text = "Karlovačka";
            tab6.TabPage = this.UltraTabPageControl13;
            tab6.Text = "Jadranska";
            this.UltraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            tab7,
            tab8,
            tab9,
            tab10,
            tab11,
            tab12,
            tab13,
            tab2,
            tab3,
            tab4,
            tab5,
            tab6});
            this.UltraTabControl1.UseAppStyling = false;
            this.UltraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            // 
            // UltraTabSharedControlsPage1
            // 
            this.UltraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1";
            this.UltraTabSharedControlsPage1.Size = new System.Drawing.Size(1002, 217);
            // 
            // UltraTabPageControl14
            // 
            this.UltraTabPageControl14.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl14.Name = "UltraTabPageControl14";
            this.UltraTabPageControl14.Size = new System.Drawing.Size(1002, 501);
            // 
            // UltraTabPageControl15
            // 
            this.UltraTabPageControl15.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl15.Name = "UltraTabPageControl15";
            this.UltraTabPageControl15.Size = new System.Drawing.Size(1002, 501);
            // 
            // UltraTabPageControl16
            // 
            this.UltraTabPageControl16.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl16.Name = "UltraTabPageControl16";
            this.UltraTabPageControl16.Size = new System.Drawing.Size(1002, 501);
            // 
            // UltraTabPageControl17
            // 
            this.UltraTabPageControl17.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl17.Name = "UltraTabPageControl17";
            this.UltraTabPageControl17.Size = new System.Drawing.Size(1002, 501);
            // 
            // UltraTabPageControl18
            // 
            this.UltraTabPageControl18.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl18.Name = "UltraTabPageControl18";
            this.UltraTabPageControl18.Size = new System.Drawing.Size(1002, 501);
            // 
            // UltraTabPageControl19
            // 
            this.UltraTabPageControl19.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl19.Name = "UltraTabPageControl19";
            this.UltraTabPageControl19.Size = new System.Drawing.Size(1002, 501);
            // 
            // UltraTabPageControl20
            // 
            this.UltraTabPageControl20.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl20.Name = "UltraTabPageControl20";
            this.UltraTabPageControl20.Size = new System.Drawing.Size(1002, 501);
            // 
            // UltraTabPageControl21
            // 
            this.UltraTabPageControl21.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl21.Name = "UltraTabPageControl21";
            this.UltraTabPageControl21.Size = new System.Drawing.Size(1002, 501);
            // 
            // UltraTabPageControl22
            // 
            this.UltraTabPageControl22.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl22.Name = "UltraTabPageControl22";
            this.UltraTabPageControl22.Size = new System.Drawing.Size(1002, 501);
            // 
            // UltraTabPageControl23
            // 
            this.UltraTabPageControl23.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl23.Name = "UltraTabPageControl23";
            this.UltraTabPageControl23.Size = new System.Drawing.Size(1002, 501);
            // 
            // UltraTabPageControl24
            // 
            this.UltraTabPageControl24.Location = new System.Drawing.Point(-10000, -10000);
            this.UltraTabPageControl24.Name = "UltraTabPageControl24";
            this.UltraTabPageControl24.Size = new System.Drawing.Size(1002, 501);
            // 
            // UltraTabPageControl1
            // 
            this.UltraTabPageControl1.Location = new System.Drawing.Point(1, 22);
            this.UltraTabPageControl1.Name = "UltraTabPageControl1";
            this.UltraTabPageControl1.Size = new System.Drawing.Size(1002, 501);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 240);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1004, 392);
            this.panel1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(10, 10);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(984, 372);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // frmRadSaBankama
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1004, 632);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.UltraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRadSaBankama";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rad sa disketama za banke";
            ((System.ComponentModel.ISupportInitialize)(this.BankeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraTabControl1)).EndInit();
            this.UltraTabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private BANKEDataSet BankeDataSet1;

    private UltraTabControl UltraTabControl1;

    private UltraTabPageControl UltraTabPageControl1;

    private UltraTabPageControl UltraTabPageControl10;

    private UltraTabPageControl UltraTabPageControl11;

    private UltraTabPageControl UltraTabPageControl12;

    private UltraTabPageControl UltraTabPageControl13;

    private UltraTabPageControl UltraTabPageControl14;

    private UltraTabPageControl UltraTabPageControl15;

    private UltraTabPageControl UltraTabPageControl16;

    private UltraTabPageControl UltraTabPageControl17;

    private UltraTabPageControl UltraTabPageControl18;

    private UltraTabPageControl UltraTabPageControl19;

    private UltraTabPageControl UltraTabPageControl2;

    private UltraTabPageControl UltraTabPageControl20;

    private UltraTabPageControl UltraTabPageControl21;

    private UltraTabPageControl UltraTabPageControl22;

    private UltraTabPageControl UltraTabPageControl23;

    private UltraTabPageControl UltraTabPageControl24;

    private UltraTabPageControl UltraTabPageControl25;

    private UltraTabPageControl UltraTabPageControl3;

    private UltraTabPageControl UltraTabPageControl4;

    private UltraTabPageControl UltraTabPageControl5;

    private UltraTabPageControl UltraTabPageControl6;

    private UltraTabPageControl UltraTabPageControl7;

    private UltraTabPageControl UltraTabPageControl8;

    private UltraTabPageControl UltraTabPageControl9;

    private UltraTabSharedControlsPage UltraTabSharedControlsPage1;
}

