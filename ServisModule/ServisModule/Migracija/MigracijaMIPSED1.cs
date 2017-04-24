using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using System.Data.SqlClient;
using Mipsed7.DataAccessLayer;
using System.IO;
using System.Data.OleDb;

namespace ServisModule.ServisModule.Migracija
{
    [SmartPart]
    public partial class MigracijaMIPSED1 : UserControl
    {
        private bool DoMigracija_FINPOS { get; set; }
        private bool DoMigracija_OD { get; set; }
        private bool DoMigracija_OS { get; set; }
        private bool DoMigracijaSI { get; set; }
        private bool DoMigracijaHonorari { get; set; }

        private string SQLConnectionString_FINPOS { get; set; }
        private string SQLConnectionString_OD { get; set; }
        private string SQLConnectionString_OS { get; set; }
        private string SQLConnectionStringSI { get; set; }
        private string Honorair_baza = "";

        private OleDbConnection aConnection = new OleDbConnection();

        private List<Tuple<string, string>> ExceptionMessageCollection { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MigracijaMIPSED1()
        {
            InitializeComponent();
        }

        private void MigracijaMIPSED1_Load(object sender, EventArgs e)
        {

        }

        private void btnPrikaziBaze_FINPOS_Click(object sender, EventArgs e)
        {
            ProvjeriBaze(txtSQLinstanca_FINPOS, txtSQLkorisnik_FINPOS, txtSQLlozinka_FINPOS, cmbSQLbaza_FINPOS, lblKonekcijaStatus_FINPOS, true);
        }

        private void btnPrikaziBaze_OD_Click(object sender, EventArgs e)
        {
            ProvjeriBaze(txtSQLinstanca_OD, txtSQLkorisnik_OD, txtSQLlozinka_OD, cmbSQLbaza_OD, lblKonekcijaStatus_OD, true);
        }

        private void btnPrikaziBaze_OS_Click(object sender, EventArgs e)
        {
            ProvjeriBaze(txtSQLinstanca_OS, txtSQLkorisnik_OS, txtSQLlozinka_OS, cmbSQLbaza_OS, lblKonekcijaStatus_OS, true);
        }

        enum ConnectionStatus
        {
            None,
            Success,
            Error
        }

        /// <summary>
        /// Univerzalna funkcija za prikaz uspješnosti konekcije.
        /// </summary>
        /// <param name="connectionStatus"></param>
        /// <param name="controlToDisplayMessage"></param>
        private void DisplayConnectionStatus(ConnectionStatus connectionStatus, Label controlToDisplayMessage)
        {
            switch (connectionStatus)
            {
                case ConnectionStatus.Success:
                    controlToDisplayMessage.Text = "Konekcija uspješna!";
                    controlToDisplayMessage.ForeColor = System.Drawing.Color.Green;
                    break;
                case ConnectionStatus.Error:
                    controlToDisplayMessage.Text = "Konekcija nije uspjela!";
                    controlToDisplayMessage.ForeColor = System.Drawing.Color.Red;
                    break;
                case ConnectionStatus.None:
                    controlToDisplayMessage.Text = "-";
                    controlToDisplayMessage.ForeColor = System.Drawing.SystemColors.ControlText;
                    break;
            }
        }

        /// <summary>
        /// Univerzalna funkcija za provjeru konekcije i podataka u bazi
        /// </summary>
        /// <param name="txtSQLinstanca"></param>
        /// <param name="txtSQLkorisnik"></param>
        /// <param name="txtSQLlozinka"></param>
        /// <param name="cmdSQLbaza"></param>
        /// <param name="lblKonekcijaStatus"></param>
        private void ProvjeriBaze(TextBox txtSQLinstanca, TextBox txtSQLkorisnik, TextBox txtSQLlozinka, ComboBox cmdSQLbaza, Label lblKonekcijaStatus, bool overrideSelectedDatabase)
        {
            // polja su prazna
            if (string.IsNullOrWhiteSpace(txtSQLinstanca.Text) && string.IsNullOrWhiteSpace(txtSQLkorisnik.Text) && string.IsNullOrWhiteSpace(txtSQLlozinka.Text))
            {
                DisplayConnectionStatus(ConnectionStatus.None, lblKonekcijaStatus);
                return;
            }

            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                string sqlConnectionString = string.Format("Data Source={0};User ID={1};Password={2};", txtSQLinstanca.Text, txtSQLkorisnik.Text, txtSQLlozinka.Text);

                SqlClient db = new SqlClient(sqlConnectionString);

                SqlCommand sqlCommand = new SqlCommand("sp_helpdb");
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // ukoliko je ovaj parametar TRUE, zanemarujemo odabranu bazu
                if (overrideSelectedDatabase)
                {
                    DataSet dsDatabases = new DataSet();
                    dsDatabases = db.GetDataSet(sqlCommand);

                    cmdSQLbaza.DisplayMember = "name";
                    cmdSQLbaza.ValueMember = "name";
                    cmdSQLbaza.DataSource = dsDatabases.Tables[0];
                }

                DisplayConnectionStatus(ConnectionStatus.Success, lblKonekcijaStatus);

                this.btnProvjeriPodatke.Enabled = true;
            }
            catch (Exception exception)
            {
                cmdSQLbaza.DataSource = null;
                DisplayConnectionStatus(ConnectionStatus.Error, lblKonekcijaStatus);
                MessageBox.Show(exception.Message, "GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void txtSQLinstanca_FINPOS_TextChanged(object sender, EventArgs e)
        {
            this.txtSQLinstanca_OD.Text = this.txtSQLinstanca_FINPOS.Text;
            this.txtSQLinstanca_OS.Text = this.txtSQLinstanca_FINPOS.Text;
            txtSQLInstancaSI.Text = txtSQLinstanca_FINPOS.Text;
        }

        private void txtSQLkorisnik_FINPOS_TextChanged(object sender, EventArgs e)
        {
            this.txtSQLkorisnik_OD.Text = this.txtSQLkorisnik_FINPOS.Text;
            this.txtSQLkorisnik_OS.Text = this.txtSQLkorisnik_FINPOS.Text;
            txtSQLKorisnikSI.Text = txtSQLkorisnik_FINPOS.Text;
        }

        private void txtSQLlozinka_FINPOS_TextChanged(object sender, EventArgs e)
        {
            this.txtSQLlozinka_OD.Text = this.txtSQLlozinka_FINPOS.Text;
            this.txtSQLlozinka_OS.Text = this.txtSQLlozinka_FINPOS.Text;
            txtSQLLozinkaSI.Text = txtSQLlozinka_FINPOS.Text;
        }

        private void btnProvjeriPodatke_Click(object sender, EventArgs e)
        {
            ProvjeriPodatke_FINPOS();

            ProvjeriPodatke_OD();

            ProvjeriPodatke_OS();

            ProvjeriPodatkeSI();

            ProvjeriPodatkeHonorari();

            this.btnMigrirajPodatke.Enabled = true;
        }

        /// <summary>
        /// Provjera podataka za FINPOS
        /// </summary>
        private void ProvjeriPodatke_FINPOS()
        {
            this.DoMigracija_FINPOS = false;

            try
            {
                // provjeri connection opet
                ProvjeriBaze(txtSQLinstanca_FINPOS, txtSQLkorisnik_FINPOS, txtSQLlozinka_FINPOS, cmbSQLbaza_FINPOS, lblKonekcijaStatus_FINPOS, false);

                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                string poruka = "Početak provjere..." + Environment.NewLine + Environment.NewLine;

                // ako postoji odabrana baza
                if (this.cmbSQLbaza_FINPOS.SelectedValue != null)
                {
                    this.SQLConnectionString_FINPOS = string.Format("Data Source={0};User ID={1};Password={2};Initial Catalog={3};", this.txtSQLinstanca_FINPOS.Text, this.txtSQLkorisnik_FINPOS.Text, this.txtSQLlozinka_FINPOS.Text, this.cmbSQLbaza_FINPOS.SelectedValue);

                    SqlClient db = new SqlClient(this.SQLConnectionString_FINPOS);

                    // ----------------------------
                    // Amount of data to transfer!
                    // 
                    // dbo.PARTNER
                    string provjera_dbo_PARTNER_count = db.ExecuteScalar("SELECT COUNT(1) FROM dbo.PARTNER").ToString();

                    poruka += "dbo.PARTNER - " + provjera_dbo_PARTNER_count +
                        Environment.NewLine + Environment.NewLine + "------------------------------------------";

                    this.DoMigracija_FINPOS = true;

                    DisplayProvjeraStatus(ProvjeraStatus.Success, this.lblProvjera_FINPOS, poruka);
                }
                else
                {
                    DisplayProvjeraStatus(ProvjeraStatus.None, this.lblProvjera_FINPOS, null);
                }
            }
            catch (Exception exception)
            {
                DisplayProvjeraStatus(ProvjeraStatus.Error, this.lblProvjera_FINPOS, exception.Message);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        /// <summary>
        /// Provjera podataka za OD
        /// </summary>
        private void ProvjeriPodatke_OD()
        {
            this.DoMigracija_OD = false;

            try
            {
                // provjeri connection opet
                ProvjeriBaze(txtSQLinstanca_OD, txtSQLkorisnik_OD, txtSQLlozinka_OD, cmbSQLbaza_OD, lblKonekcijaStatus_OD, false);

                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                string poruka = "Početak provjere..." + Environment.NewLine + Environment.NewLine;

                // ako postoji odabrana baza
                if (this.cmbSQLbaza_OD.SelectedValue != null)
                {
                    this.SQLConnectionString_OD = string.Format("Data Source={0};User ID={1};Password={2};Initial Catalog={3};", this.txtSQLinstanca_OD.Text, this.txtSQLkorisnik_OD.Text, this.txtSQLlozinka_OD.Text, this.cmbSQLbaza_OD.SelectedValue);

                    SqlClient db = new SqlClient(this.SQLConnectionString_OD);

                    // ----------------------------
                    // Amount of data to transfer!
                    // 
                    // dbo.RADNIK
                    string provjera_dbo_RADNIK_count = db.ExecuteScalar("SELECT COUNT(1) FROM dbo.RADNIK WHERE AKTIVAN = 1").ToString();

                    poruka += "dbo.RADNIK - " + provjera_dbo_RADNIK_count +
                        Environment.NewLine + Environment.NewLine + "------------------------------------------";

                    this.DoMigracija_OD = true;

                    DisplayProvjeraStatus(ProvjeraStatus.Success, this.lblProvjera_OD, poruka);
                }
                else
                {
                    DisplayProvjeraStatus(ProvjeraStatus.None, this.lblProvjera_OD, null);
                }
            }
            catch (Exception exception)
            {
                DisplayProvjeraStatus(ProvjeraStatus.Error, this.lblProvjera_OD, exception.Message);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        /// <summary>
        /// Provjera podataka za OS
        /// </summary>
        private void ProvjeriPodatke_OS()
        {
            this.DoMigracija_OS = false;

            try
            {
                // provjeri connection opet
                ProvjeriBaze(txtSQLinstanca_OS, txtSQLkorisnik_OS, txtSQLlozinka_OS, cmbSQLbaza_OS, lblKonekcijaStatus_OS, false);

                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                string poruka = "Početak provjere..." + Environment.NewLine + Environment.NewLine;

                // ako postoji odabrana baza
                if (this.cmbSQLbaza_OS.SelectedValue != null)
                {
                    this.SQLConnectionString_OS = string.Format("Data Source={0};User ID={1};Password={2};Initial Catalog={3};", this.txtSQLinstanca_OS.Text, this.txtSQLkorisnik_OS.Text, this.txtSQLlozinka_OS.Text, this.cmbSQLbaza_OS.SelectedValue);

                    SqlClient db = new SqlClient(this.SQLConnectionString_OS);

                    // ----------------------------
                    // Amount of data to transfer!
                    // 
                    // dbo.OSNOVNASREDSTVA
                    string provjera_dbo_OSNOVNASREDSTVA_count = db.ExecuteScalar("SELECT COUNT(1) FROM dbo.OSNOVNASREDSTVA").ToString();

                    poruka += "dbo.OSNOVNASREDSTVA - " + provjera_dbo_OSNOVNASREDSTVA_count +
                        Environment.NewLine + Environment.NewLine + "------------------------------------------";

                    this.DoMigracija_OS = true;

                    DisplayProvjeraStatus(ProvjeraStatus.Success, this.lblProvjera_OS, poruka);
                }
                else
                {
                    DisplayProvjeraStatus(ProvjeraStatus.None, this.lblProvjera_OS, null);
                }
            }
            catch (Exception exception)
            {
                DisplayProvjeraStatus(ProvjeraStatus.Error, this.lblProvjera_OS, exception.Message);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void ProvjeriPodatkeSI()
        {
            this.DoMigracijaSI = false;

            try
            {
                // provjeri connection opet
                ProvjeriBaze(txtSQLInstancaSI, txtSQLKorisnikSI, txtSQLLozinkaSI, cmbBazaSitni, lblKonekcijaStatusSI, false);

                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                string poruka = "Početak provjere..." + Environment.NewLine + Environment.NewLine;

                // ako postoji odabrana baza
                if (this.cmbBazaSitni.SelectedValue != null)
                {
                    SQLConnectionStringSI = string.Format("Data Source={0};User ID={1};Password={2};Initial Catalog={3};", this.txtSQLInstancaSI.Text, this.txtSQLKorisnikSI.Text, this.txtSQLLozinkaSI.Text, this.cmbBazaSitni.SelectedValue);

                    SqlClient db = new SqlClient(SQLConnectionStringSI);

                    // ----------------------------
                    // Amount of data to transfer!
                    // 
                    // dbo.SitniInventar
                    string provjera_dbo_SI_count = db.ExecuteScalar("SELECT COUNT(1) FROM dbo.OSNOVNASREDSTVA").ToString();

                    poruka += "dbo.OSNOVNASREDSTVA - " + provjera_dbo_SI_count +
                        Environment.NewLine + Environment.NewLine + "------------------------------------------";

                    DoMigracijaSI = true;

                    DisplayProvjeraStatus(ProvjeraStatus.Success, this.lblProvjeraSI, poruka);
                }
                else
                {
                    DisplayProvjeraStatus(ProvjeraStatus.None, this.lblProvjeraSI, null);
                }
            }
            catch (Exception exception)
            {
                DisplayProvjeraStatus(ProvjeraStatus.Error, this.lblProvjeraSI, exception.Message);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void ProvjeriPodatkeHonorari()
        {
            this.DoMigracijaHonorari = false;

            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                if (lblHonorariPutanjaBaza.Text.Length != 0)
                {
                    // provjeri connection opet
                    try
                    {
                        aConnection = new OleDbConnection(String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", Honorair_baza));
                        aConnection.Open();
                    }
                    catch
                    {
                        aConnection = new OleDbConnection(String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}", Honorair_baza));
                        aConnection.Open();
                    }

                    string poruka = "Početak provjere..." + Environment.NewLine + Environment.NewLine;

                    OleDbCommand aCommand = new OleDbCommand();

                    aCommand = new OleDbCommand(String.Format("Select * from {0}", "Radnici"), aConnection);

                    OleDbDataAdapter adapter = new OleDbDataAdapter(aCommand);
                    DataTable tblRadnici = new DataTable();
                    adapter.Fill(tblRadnici);

                    poruka += "dbo.Honorari - " + tblRadnici.Rows.Count.ToString() +
                            Environment.NewLine + Environment.NewLine + "------------------------------------------";

                    DoMigracijaHonorari = true;

                    DisplayProvjeraStatus(ProvjeraStatus.Success, lblProvjeraHonorari, poruka);
                }

            }
            catch (Exception exception)
            {
                DisplayProvjeraStatus(ProvjeraStatus.Error, lblProvjeraHonorari, exception.Message);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        enum ProvjeraStatus
        {
            None,
            Success,
            Error
        }

        /// <summary>
        /// Univerzalna funkcija za prikaz uspješnosti konekcije.
        /// </summary>
        /// <param name="provjeraStatus"></param>
        /// <param name="controlToDisplayMessage"></param>
        /// <param name="poruka"></param>
        private void DisplayProvjeraStatus(ProvjeraStatus provjeraStatus, Label controlToDisplayMessage, string poruka)
        {
            switch (provjeraStatus)
            {
                case ProvjeraStatus.Success:
                    controlToDisplayMessage.Text = poruka;
                    controlToDisplayMessage.ForeColor = System.Drawing.Color.Green;
                    break;
                case ProvjeraStatus.Error:
                    controlToDisplayMessage.Text = poruka;
                    controlToDisplayMessage.ForeColor = System.Drawing.Color.Red;
                    break;
                case ProvjeraStatus.None:
                    controlToDisplayMessage.Text = "-";
                    controlToDisplayMessage.ForeColor = System.Drawing.SystemColors.ControlText;
                    break;
            }
        }

        /// <summary>
        /// MIGRACIJA podataka
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMigrirajPodatke_Click(object sender, EventArgs e)
        {
            ExceptionMessageCollection = new List<Tuple<string, string>>();

            // Prije migracija iniciramo button "Provjeri podatke"
            this.btnProvjeriPodatke_Click(sender, e);


            MigrirajPodatke_FINPOS();

            MigrirajPodatke_OD();

            MigrirajPodatke_OS();

            MigrirajPodatkeSI();

            MigrirajPodatkeHonorari();

            // Kreiraj log file
            LogException();
        }

        /// <summary>
        /// MIGRACIJA podataka za FINPOS
        /// </summary>
        private void MigrirajPodatke_FINPOS()
        {
            if (this.DoMigracija_FINPOS)
            {
                // Konektiramo se na bazi MIPSED.1 FINPOS
                SqlClient dbMIPSED1_FINPOS = new SqlClient(this.SQLConnectionString_FINPOS);

                // Konektiramo se na bazu MIPSED.7 (ujedno i defaultna konekcija)
                SqlClient dbMIPSED7 = new SqlClient();

                // MIPSED.1 FINPOS -> čitanje podataka iz tablice dbo.PARTNER
                DataTable dtPARTNER = new DataTable();
                dtPARTNER = dbMIPSED1_FINPOS.GetDataTable("SELECT * FROM dbo.PARTNER");

                // Counter za brojanje uspješnih/neuspješnih prijenosa
                int countSuccess = 0;
                int countError = 0;

                foreach (DataRow drRow in dtPARTNER.Rows)
                {
                    string sqlInsertCommand = string.Empty;

                    try
                    {
                        // INSERT
                        sqlInsertCommand = string.Format("INSERT INTO dbo.PARTNER (IDPARTNER, NAZIVPARTNER, MB, PARTNERFAX, PARTNERTELEFON, PARTNERMJESTO, PARTNERULICA, PARTNERZIRO1, PARTNERZIRO2, PARTNEROIB) " +
                            "VALUES ({0}, '{1}', {2}, '{3}', '{4}', '{5}', '{6}', '{7}', {8}, '{9}')",
                            drRow["IDPARTNER"],
                            drRow["NAZIVPARTNER"].ToString().Replace("'", string.Empty).Trim(),
                            DBNullToNull(drRow["MB"]),
                            IsNull(drRow["partnerfax"], "-"),
                            IsNull(drRow["partnertel"], "-"),
                            IsNull(drRow["partnermjesto"], "-"),
                            IsNull(drRow["partnerulica"], "-"),
                            IsNull(drRow["partnerziro1"], "-"),
                            DBNullToNull(drRow["partnerziro2"]),
                            IsNull(drRow["OIB"], "-"));

                        dbMIPSED7.ExecuteNonQuery(sqlInsertCommand);
                        countSuccess++;
                    }
                    catch (Exception exception)
                    {
                        countError++;
                        ExceptionMessageCollection.Add(new Tuple<string, string>(exception.Message, sqlInsertCommand));
                    }
                    finally
                    {
                        DisplayMigrationStatus(this.lblMigracija_FINPOS, countSuccess, countError, dtPARTNER.Rows.Count);
                    }
                }
            }
        }

        /// <summary>
        /// MIGRACIJA podataka za OD
        /// </summary>
        private void MigrirajPodatke_OD()
        {
            if (this.DoMigracija_OD)
            {
                // Konektiramo se na bazi MIPSED.1 OD
                SqlClient dbMIPSED1_OD = new SqlClient(this.SQLConnectionString_OD);

                // Konektiramo se na bazu MIPSED.7 (ujedno i defaultna konekcija)
                SqlClient dbMIPSED7 = new SqlClient();

                // MIPSED.1 OD -> čitanje podataka iz tablice dbo.RADNIK, ali samo AKTIVNIH!
                DataTable dtRADNIK = new DataTable();
                dtRADNIK = dbMIPSED1_OD.GetDataTable("SELECT * FROM dbo.RADNIK WHERE AKTIVAN = 1");

                // Counter za brojanje uspješnih/neuspješnih prijenosa
                int countSuccess = 0;
                int countError = 0;
                string datum_rodenja = string.Empty;
                string datum_zaposlenja = string.Empty;
                string datum_prestanka = string.Empty;

                foreach (DataRow drRow in dtRADNIK.Rows)
                {
                    string sqlInsertCommand = string.Empty;

                    try
                    {
                        // Data FIX-evi
                        
                        // ---------------------------------------------------------------------------------------------------
                        // #1
                        // ---------------------------------------------------------------------------------------------------
                        // Postoji mogučnost da svaka škola ima neki svoj šifrarnik SkupinePorezaIDoprinosa.
                        // Da bi se riješio taj problem, nepostojeće šifre SkupinePorezaIDoprinosa u našem sustavu, postavljamo na 0;
                        int RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = Convert.ToInt32(drRow["RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA"]);

                        // Trenutno ugrađen šifrarnik
                        if (RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA != 1 &&
                            RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA != 2 &&
                            RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA != 96 &&
                            RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA != 97 &&
                            RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA != 98 &&
                            RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA != 99)
                            // podesi na 0 - NEDEFINIRANO
                            RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = 0;
                        // ***************************************************************************************************
                        // ***************************************************************************************************

                        
                        // ---------------------------------------------------------------------------------------------------
                        // #2
                        // ---------------------------------------------------------------------------------------------------
                        // Postoji mogučnost sa svaka škola ima svoj šifrarnik Banaka, ili da imaju više npr. unosa za istu banku.
                        // Npr. određen djelatnik ima neke svoje specifične postavke, te se za njega koristi banka "ZABA - Ivo Ivić"...
                        // Da bi se riješio taj problem, nepostojeće šifre Banaka u našem sustavu tražimo po VBDI-u.
                        
                        // ... uzimamo ID banke...
                        int IDBANKE = Convert.ToInt32(drRow["IDBANKE"]);

                        // ... za tu banku u MIPSED.1 tražimo VBDI...
                        string VBDI = dbMIPSED1_OD.ExecuteScalar("SELECT VBDIBANKE FROM dbo.BANKE WHERE IDBANKE = " + IDBANKE).ToString();

                        try
                        {
                            // ... po tom VBDI-u iz MIPSED.1, u MIPSED.7 tražimo ID banke
                            IDBANKE = int.Parse(dbMIPSED7.ExecuteScalar(string.Format("SELECT IDBANKE FROM dbo.BANKE WHERE VBDIBANKE = '{0}'", VBDI)).ToString());
                        }
                        catch (Exception)
                        {
                            // ... ukoliko išta pukne, postavljamo banku na nedefiniranu
                            IDBANKE = 0;
                        }
                        // ***************************************************************************************************
                        // ***************************************************************************************************


                        // INSERT
                        //sqlInsertCommand = string.Format("INSERT INTO dbo.RADNIK (IDRADNIK, PREZIME, IME, JMBG, DATUMRODJENJA, IDSPOL, OPCINARADAIDOPCINE, OPCINASTANOVANJAIDOPCINE, IDBENEFICIRANI, " + 
                        //                                 "IDBANKE, TEKUCI, SIFRAOPISAPLACANJANETO, OPISPLACANJANETO, BROJMIROVINSKOG, BROJZDRAVSTVENOG, MBO, POSTOTAKOSLOBODJENJAODPOREZA, " + 
                        //                                 "TJEDNIFONDSATI, TJEDNIFONDSATISTAZ, KOEFICIJENT, IDRADNOMJESTO, TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA, POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, " + 
                        //                                 "IDSTRUKA, AKTIVAN, GODINESTAZA, MJESECISTAZA, DANISTAZA, DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, DATUMPRESTANKARADNOGODNOSA, IDTITULA, " +
                        //                                 "RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, ulica, kucnibroj, mjesto, ZBIRNINETO, UZIMAUOBZIROSNOVICEDOPRINOSA, IDORGDIO, IDBRACNOSTANJE, " + 
                        //                                 "IDIPIDENT, OIB, GODINESTAZAPRO, MJESECISTAZAPRO, DANISTAZAPRO) " +
                        //                                 "VALUES ({0}, '{1}', '{2}', '{3}', '{4}', {5}, '{6}', '{7}', '{8}', {9}, '{10}', " +
                        //                                 "'{11}', '{12}', {13}, {14}, {15}, {16}, {17}, {18}, '{19}', {20}, " +
                        //                                 "{21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, " +
                        //                                 "{31}, '{32}', '{33}', '{34}', {35}, {36}, {37}, {38}, {39}, {40}, " +
                        //                                 "{41}, {42}, {43})",
                        //    drRow["IDRADNIK"], Substring(drRow["PREZIME"].ToString(), 50), drRow["IME"], drRow["JMBG"], FixDateTime(drRow["DATUMRODJENJA"]), FixSpol(drRow["SPOL"]), 
                        //    drRow["OPCINARADAIDOPCINE"], drRow["OPCINASTANOVANJAIDOPCINE"], drRow["IDBENEFICIRANI"], IDBANKE, drRow["TEKUCI"],
                        //    drRow["SIFRAOPISAPLACANJANETO"], drRow["OPISPLACANJANETO"], DBNullToNull(drRow["BROJMIROVINSKOG"]), DBNullToNull(drRow["BROJZDRAVSTVENOG"]), DBNullToNull(drRow["MBO"]), 
                        //    DecimalToString(drRow["POSTOTAKOSLOBODJENJAODPOREZA"]), DecimalToString(drRow["TJEDNIFONDSATI"]), DecimalToString(drRow["TJEDNIFONDSATISTAZ"]), 
                        //    DecimalToString(drRow["KOEFICIJENT"]), "NULL", "NULL", "NULL", "NULL", Boolean_TrueFalse_to_1_0(drRow["AKTIVAN"]), drRow["GODINESTAZA"], 
                        //    drRow["MJESECISTAZA"], drRow["DANISTAZA"], FixDateTime(drRow["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"]), FixDateTime(drRow["DATUMPRESTANKARADNOGODNOSA"]), "NULL",
                        //    RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, drRow["ulica"], drRow["kucnibroj"], drRow["mjesto"], Boolean_TrueFalse_to_1_0(drRow["ZBIRNINETO"]), 
                        //    Boolean_TrueFalse_to_1_0(drRow["UZIMAUOBZIROSNOVICEDOPRINOSA"]), "NULL", DBNullToNull(drRow["IDBRACNOSTANJE"]), drRow["IPIDENTIFIKATOR"], DBNullToNull(drRow["OIB"]),
                        //    0, 0, 0);


                        //convert datuma u string zbog pucanja prilikom migracije 
                        try
                        {
                            datum_rodenja = Convert.ToDateTime(drRow["DATUMRODJENJA"]).ToString("yyyy.MM.dd");
                        }
                        catch
                        {
                            datum_rodenja = DateTime.Now.ToString("yyyy.MM.dd");
                        }
                        try
                        {
                            datum_zaposlenja = Convert.ToDateTime(drRow["DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI"]).ToString("yyyy.MM.dd");
                        }
                        catch
                        {
                            datum_zaposlenja = DateTime.Now.ToString("yyyy.MM.dd");
                        }
                        try
                        {
                            datum_prestanka = Convert.ToDateTime(drRow["DATUMPRESTANKARADNOGODNOSA"]).ToString("yyyy.MM.dd");
                        }
                        catch
                        {
                            datum_prestanka = DateTime.Now.ToString("yyyy.MM.dd");
                        }

                        sqlInsertCommand = string.Format("INSERT INTO dbo.RADNIK (IDRADNIK, PREZIME, IME, JMBG, DATUMRODJENJA, IDSPOL, OPCINARADAIDOPCINE, OPCINASTANOVANJAIDOPCINE, IDBENEFICIRANI, " +
                                                         "IDBANKE, TEKUCI, SIFRAOPISAPLACANJANETO, OPISPLACANJANETO, BROJMIROVINSKOG, BROJZDRAVSTVENOG, MBO, POSTOTAKOSLOBODJENJAODPOREZA, " +
                                                         "TJEDNIFONDSATI, TJEDNIFONDSATISTAZ, KOEFICIJENT, IDRADNOMJESTO, TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA, POTREBNASTRUCNASPREMAIDSTRUCNASPREMA, " +
                                                         "IDSTRUKA, AKTIVAN, GODINESTAZA, MJESECISTAZA, DANISTAZA, DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, DATUMPRESTANKARADNOGODNOSA, IDTITULA, " +
                                                         "RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, ulica, kucnibroj, mjesto, ZBIRNINETO, UZIMAUOBZIROSNOVICEDOPRINOSA, IDORGDIO, IDBRACNOSTANJE, " +
                                                         "IDIPIDENT, OIB, GODINESTAZAPRO, MJESECISTAZAPRO, DANISTAZAPRO) " +
                                                         "VALUES ({0}, '{1}', '{2}', '{3}', '{4}', {5}, '{6}', '{7}', '{8}', {9}, '{10}', " +
                                                         "'{11}', '{12}', {13}, {14}, {15}, {16}, {17}, {18}, '{19}', {20}, " +
                                                         "{21}, {22}, {23}, {24}, {25}, {26}, {27}, '{28}', '{29}', {30}, " +
                                                         "{31}, '{32}', '{33}', '{34}', {35}, {36}, {37}, {38}, {39}, {40}, " +
                                                         "{41}, {42}, {43})",
                        drRow["IDRADNIK"], Substring(drRow["PREZIME"].ToString(), 50), drRow["IME"], drRow["JMBG"], datum_rodenja, FixSpol(drRow["SPOL"]),
                        drRow["OPCINARADAIDOPCINE"], drRow["OPCINASTANOVANJAIDOPCINE"], drRow["IDBENEFICIRANI"], IDBANKE, drRow["TEKUCI"],
                        drRow["SIFRAOPISAPLACANJANETO"], drRow["OPISPLACANJANETO"], DBNullToNull(drRow["BROJMIROVINSKOG"]), DBNullToNull(drRow["BROJZDRAVSTVENOG"]), DBNullToNull(drRow["MBO"]),
                        DecimalToString(drRow["POSTOTAKOSLOBODJENJAODPOREZA"]), DecimalToString(drRow["TJEDNIFONDSATI"]), DecimalToString(drRow["TJEDNIFONDSATISTAZ"]),
                        DecimalToString(drRow["KOEFICIJENT"]), "NULL", "NULL", "NULL", "NULL", Boolean_TrueFalse_to_1_0(drRow["AKTIVAN"]), drRow["GODINESTAZA"],
                        drRow["MJESECISTAZA"], drRow["DANISTAZA"], datum_zaposlenja, datum_prestanka, "NULL",
                        RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, drRow["ulica"], drRow["kucnibroj"], drRow["mjesto"], Boolean_TrueFalse_to_1_0(drRow["ZBIRNINETO"]),
                        Boolean_TrueFalse_to_1_0(drRow["UZIMAUOBZIROSNOVICEDOPRINOSA"]), "NULL", DBNullToNull(drRow["IDBRACNOSTANJE"]), drRow["IPIDENTIFIKATOR"], DBNullToNull(drRow["OIB"]),
                        0, 0, 0);

                        dbMIPSED7.ExecuteNonQuery(sqlInsertCommand);
                        countSuccess++;
                    }
                    catch (Exception exception)
                    {
                        countError++;
                        ExceptionMessageCollection.Add(new Tuple<string, string>(exception.Message, sqlInsertCommand));
                    }
                    finally
                    {
                        DisplayMigrationStatus(this.lblMigracija_OD, countSuccess, countError, dtRADNIK.Rows.Count);
                    }
                }
            }
        }

        /// <summary>
        /// MIGRACIJA podataka za OS
        /// </summary>
        private void MigrirajPodatke_OS()
        {
            if (this.DoMigracija_OS)
            {
                // Konektiramo se na bazi MIPSED.1 OS
                SqlClient dbMIPSED1_OS = new SqlClient(this.SQLConnectionString_OS);

                // Konektiramo se na bazu MIPSED.7 (ujedno i defaultna konekcija)
                SqlClient dbMIPSED7 = new SqlClient();

                // MIPSED.1 OS -> čitanje podataka iz tablice dbo.OSNOVNASREDSTVA
                DataTable dtOSNOVNA_SREDSTVA = new DataTable();
                dtOSNOVNA_SREDSTVA = dbMIPSED1_OS.GetDataTable("SELECT * FROM dbo.OSNOVNASREDSTVA");

                // Counter za brojanje uspješnih/neuspješnih prijenosa
                int countSuccess = 0;
                int countError = 0;

                // ukoliko 
                Int64 INVBROJ = 0;
                DateTime dtNabave = DateTime.Now;
                DateTime dtUporabe = DateTime.Now;
                int kolicinaUlaza = 0;
                decimal osnovica = 0;
                decimal ispravak = 0;
                string napomena = string.Empty;
                int IDOSVRSTA = 1; // defaultno je OSNOVNO SREDSTVO
                string inventarni_broj = string.Empty;

                // Zadnji inventurni broj
                inventarni_broj = dbMIPSED7.ExecuteScalar("Select Max(INVBROJ) From OS").ToString();
                if (inventarni_broj.Length == 0)
                {
                    INVBROJ = 0;
                }
                else
                {
                    INVBROJ = Convert.ToInt64(inventarni_broj);
                }


                foreach (DataRow drRow in dtOSNOVNA_SREDSTVA.Rows)
                {
                    string sqlInsertCommand = string.Empty;

                    try
                    {
                        INVBROJ++;

                        // fix #2
                        if (drRow["datnab"] != DBNull.Value)
                        {
                            dtNabave = DateTime.Parse(drRow["datnab"].ToString());
                        }
                        else // ukoliko podatak ne postoji, uzimamo DATUMUPORABE ili trenutni datum ukoliko niti taj ne postoji
                        {
                            if (drRow["datupo"] != DBNull.Value)
                                dtNabave = DateTime.Parse(drRow["datnab"].ToString());
                            else
                                dtNabave = DateTime.Today;
                        }

                        // fix #3
                        if (drRow["datupo"] != DBNull.Value)
                        {
                            dtUporabe = DateTime.Parse(drRow["datupo"].ToString());
                        }
                        else // ukoliko podatak ne postoji, uzimamo DATUMNABAVKE ili trenutni datum ukoliko niti taj ne postoji
                        {
                            if (drRow["datnab"] != DBNull.Value)
                                dtUporabe = DateTime.Parse(drRow["datnab"].ToString());
                            else
                                dtUporabe = DateTime.Today;
                        }

                        // fix #4
                        //if (drRow["datnab"] != DBNull.Value)
                        //{
                        //    decimal stopaAmortizacije = Convert.ToDecimal(dbMIPSED1_OS.ExecuteScalar(string.Format("SELECT ISNULL(STOPA, 0) FROM dbo.SkupineAmortizacije WHERE sifska = '{0}'", drRow["sifska"])));

                        //    // "ako je datumnabavke OVE godine i postotak amortizacije 100%"
                        //    if (((DateTime)drRow["datnab"]).Year == DateTime.Today.Year && stopaAmortizacije == 100M)
                        //    {
                        //        IDOSVRSTA = 2; // SITAN INVENTAR
                        //    }
                        //}

                        // fix #5
                        if(drRow["kol"] != DBNull.Value)
                            if (!int.TryParse(drRow["kol"].ToString(), out kolicinaUlaza)) { kolicinaUlaza = 0; }

                        // fix #6
                        if (drRow["osnovica"] != DBNull.Value)
                            if (!decimal.TryParse(drRow["osnovica"].ToString(), out osnovica)) { osnovica = 0; }

                        // fix #7
                        if (drRow["ispravak"] != DBNull.Value)
                            if (!decimal.TryParse(drRow["ispravak"].ToString(), out ispravak)) { ispravak = 0; }


                        if (drRow["napomena"].ToString().Length > 50)
                        {
                            napomena = drRow["napomena"].ToString().Substring(0,50);
                        }
                        else
                        {
                            napomena = drRow["napomena"].ToString();
                        }
                        
                        // INSERT
                        sqlInsertCommand = string.Format("INSERT INTO dbo.OS (INVBROJ, NAZIVOS, DATUMNABAVKE, DATUMUPORABE, NAPOMENAOS, IDAMSKUPINE, IDOSVRSTA) " +
                            "VALUES ({0}, '{1}', '{2}', '{3}', '{4}', {5}, {6})",
                            INVBROJ,
                            Substring(drRow["nazos"].ToString(), 50),
                            dtNabave.ToString("yyyy.MM.dd"),
                            dtUporabe.ToString("yyyy.MM.dd"),
                            napomena,
                            0, // AM skupina - NEDEFINIRANO
                            IDOSVRSTA);

                        dbMIPSED7.ExecuteNonQuery(sqlInsertCommand);


                        // INSERT u temeljnicu
                        // NABAVNA
                        sqlInsertCommand = string.Format("INSERT INTO dbo.OSTEMELJNICA (INVBROJ, IDOSDOKUMENT, OSBROJDOKUMENTA, OSDATUMDOK, OSKOLICINA, OSSTOPA, OSOSNOVICA, OSDUGUJE, OSPOTRAZUJE, RASHODLOKACIJEIDLOKACIJE, OSOPIS) " +
                            "VALUES ({0}, {1}, {2}, '{3}', {4}, {5}, {6}, {7}, {8}, {9}, '{10}')",
                            INVBROJ,
                            1, // Nabava
                            0,
                            DateTime.Now.ToString("yyy.MM.dd"),
                            kolicinaUlaza,
                            0,
                            osnovica.ToString().Replace(",", "."), // osnovica
                            (osnovica * kolicinaUlaza).ToString().Replace(",", "."), //Ukupna vrijednost
                            0, // ispravak
                            "NULL",
                            "PS-Nabavna");

                        dbMIPSED7.ExecuteNonQuery(sqlInsertCommand);



                        // AMORTIZACIJA
                        sqlInsertCommand = string.Format("INSERT INTO dbo.OSTEMELJNICA (INVBROJ, IDOSDOKUMENT, OSBROJDOKUMENTA, OSDATUMDOK, OSKOLICINA, OSSTOPA, OSOSNOVICA, OSDUGUJE, OSPOTRAZUJE, RASHODLOKACIJEIDLOKACIJE, OSOPIS) " +
                            "VALUES ({0}, {1}, {2}, '{3}', {4}, {5}, {6}, {7}, {8}, {9}, '{10}')",
                            INVBROJ,
                            2, // Amortizacija
                            0,
                            DateTime.Now.ToString("yyy.MM.dd"),
                            kolicinaUlaza,
                            0,
                            osnovica.ToString().Replace(",", "."), // osnovica
                            (osnovica * kolicinaUlaza).ToString().Replace(",", "."), //Ukupna vrijednost
                            (ispravak).ToString().Replace(",", "."), // ispravak
                            "NULL",
                            "PS-Ispravak");

                        dbMIPSED7.ExecuteNonQuery(sqlInsertCommand);

                        countSuccess++;
                    }
                    catch (Exception exception)
                    {
                        countError++;
                        ExceptionMessageCollection.Add(new Tuple<string, string>(exception.Message, sqlInsertCommand));
                    }
                    finally
                    {
                        DisplayMigrationStatus(this.lblMigracija_OS, countSuccess, countError, dtOSNOVNA_SREDSTVA.Rows.Count);
                    }
                }
            }
        }

        private void MigrirajPodatkeHonorari()
        {
            if (DoMigracijaHonorari)
            {
                OleDbCommand aCommand = new OleDbCommand(String.Format("select * from {0}", "Radnici"), aConnection);
                OleDbDataAdapter adapter = new OleDbDataAdapter(aCommand);
                DataTable tblRadnici = new DataTable();
                adapter.Fill(tblRadnici);

                aCommand = new OleDbCommand(String.Format("select * from {0}", "Banke"), aConnection);
                adapter = new OleDbDataAdapter(aCommand);
                DataTable tblBanka = new DataTable();
                adapter.Fill(tblBanka);

                SqlClient dbMIPSED7 = new SqlClient();
                int max_id = 0;
                try
                {
                    max_id = Convert.ToInt32(dbMIPSED7.ExecuteScalar("Select Max(DDIDRADNIK) From DDRADNIK"));
                }
                catch 
                {
                    max_id = 0;
                }
                string sqlInsertCommand = "";
                string ime = "";
                string prezime = "";
                string [] ime_prezime = null;
                string adresa = "";
                string kucni_broj = "-";
                string mjesto = "-";
                string ddzrn = "";
                string id_opcine_rada = "";
                string id_opcine_stanovanja = "";
                DataTable tbltemp = new DataTable();
                string id_banke = "";
                string dd_jmbg = "";
                string dd_oib = "";
                string sifra_opisa_placanja = "16";
                string opis_placanja_neto = "Isplata honorara";
                string obveznik_pdv = "";
                string drugi_stup = "";
                string zbrirni_neto = "false";
                int countSuccess = 0;
                int countError = 0;
                int brojradnika = tblRadnici.Rows.Count;
                string provjera_postojeceg = "";

                foreach (DataRow radnik in tblRadnici.Rows)
                {
                    ime = "";
                    prezime = "";
                    adresa = "";
                    ddzrn = "";
                    id_opcine_rada = "";
                    id_opcine_stanovanja = "";
                    id_banke = "";
                    dd_jmbg = "";
                    max_id++;

                    try
                    {
                        dd_jmbg = radnik["JMBG"].ToString();
                        if (dd_jmbg.Length < 1)
                            dd_jmbg = "0";

                        try
                        {
                            provjera_postojeceg = dbMIPSED7.ExecuteScalar("Select DDIDRADNIK From DDRADNIK Where DDJMBG = '" + radnik["JMBG"].ToString() + "'").ToString();
                        }
                        catch
                        {
                            provjera_postojeceg = "";
                        }

                        if (provjera_postojeceg.Length == 0)
                        {

                            ime_prezime = radnik["Prezime_Ime"].ToString().Split(' ');
                            ime = ime_prezime[ime_prezime.Length - 1];

                            for (int i = 0; i < ime_prezime.Length - 1; i++)
                            {
                                prezime += ime_prezime[i];
                            }

                            if (radnik["Adresa"].ToString().Length > 50)
                                adresa = radnik["Adresa"].ToString().Substring(0, 50);
                            else
                                adresa = radnik["Adresa"].ToString();

                            ddzrn = radnik["Tekuci"].ToString();

                            if (ddzrn.Length > 10)
                                ddzrn = "0";

                            aCommand = new OleDbCommand(String.Format("Select Sifra From Opcine_Stanovanja Where ID_Opcine_Stanovanja = {0}", radnik["IDGRADARADA"].ToString()), aConnection);
                            adapter = new OleDbDataAdapter(aCommand);
                            tbltemp.Rows.Clear();
                            adapter.Fill(tbltemp);
                            if (tbltemp.Rows.Count > 0)
                                id_opcine_rada = tbltemp.Rows[0][0].ToString();
                            else
                                id_opcine_rada = "0";

                            aCommand = new OleDbCommand(String.Format("Select Sifra From Opcine_Stanovanja Where ID_Opcine_Stanovanja = {0}", radnik["ID_Opcine_Stanovanja"].ToString()), aConnection);
                            adapter = new OleDbDataAdapter(aCommand);
                            tbltemp.Rows.Clear();
                            adapter.Fill(tbltemp);
                            if (tbltemp.Rows.Count > 0)
                                id_opcine_stanovanja = tbltemp.Rows[0][0].ToString();
                            else
                                id_opcine_stanovanja = "0";

                            try
                            {
                                aCommand = new OleDbCommand(String.Format("Select zirozatekuce From bANKE Where id = {0}", radnik["ID_Banke"].ToString()), aConnection);
                                adapter = new OleDbDataAdapter(aCommand);
                                tbltemp.Rows.Clear();
                                adapter.Fill(tbltemp);
                                if (tbltemp.Rows.Count > 0)
                                    id_banke = tbltemp.Rows[0][1].ToString();
                                else
                                    id_banke = "0";

                                if (id_banke != "0")
                                {
                                    id_banke = id_banke.Split('-')[0];
                                    id_banke = dbMIPSED7.ExecuteScalar("Select IDBANKE From Banke Where VBDIBANKE = '" + id_banke + "'").ToString();
                                }
                            }
                            catch
                            {
                                id_banke = "0";
                            }

                            dd_oib = radnik["OIB"].ToString();
                            if (dd_oib.Length < 1)
                                dd_oib = "0";

                            obveznik_pdv = radnik["Obveznik_PDV"].ToString();
                            drugi_stup = radnik["Clan_Drugog_MIO"].ToString();

                            sqlInsertCommand = "INSERT INTO DDRADNIK (DDIDRADNIK, DDPREZIME, DDIME, DDADRESA, DDKUCNIBROJ, DDMJESTO, DDZRN, OPCINARADAIDOPCINE, " +
                                               "OPCINASTANOVANJAIDOPCINE, IDBANKE, DDJMBG, DDOIB, DDSIFRAOPISAPLACANJANETO, DDOPISPLACANJANETO, DDPDVOBVEZNIK, DDDRUGISTUP, " +
                                               "DDZBIRNINETO) Values ('" + max_id + "', '" + prezime + "', '" + ime + "', '" + adresa + "', '" + kucni_broj + "', " +
                                               "'" + mjesto + "', '" + ddzrn + "', '" + id_opcine_rada + "', '" + id_opcine_stanovanja + "', '" + id_banke + "', " +
                                               "'" + dd_jmbg + "', '" + dd_oib + "', '" + sifra_opisa_placanja + "', '" + opis_placanja_neto + "', '" + obveznik_pdv + "', " +
                                               "'" + drugi_stup + "', '" + zbrirni_neto + "')";

                            dbMIPSED7.ExecuteNonQuery(sqlInsertCommand);
                            countSuccess++;
                        }
                        else
                        {
                            countError++;
                            ExceptionMessageCollection.Add(new Tuple<string, string>("Radnik sa JMBG-om " + dd_jmbg + " već postoji", sqlInsertCommand));
                        }
                    }
                    catch (Exception exception)
                    {
                        countError++;
                        ExceptionMessageCollection.Add(new Tuple<string, string>(exception.Message, sqlInsertCommand));
                    }
                    finally
                    {
                        DisplayMigrationStatus(this.lblMigracijaHonorari, countSuccess, countError, brojradnika);
                    }
                }


            }
        }

        private void MigrirajPodatkeSI()
        {
            if (DoMigracijaSI)
            {
                // Konektiramo se na bazi MIPSED.1 OS
                SqlClient dbMIPSED1SI = new SqlClient(SQLConnectionStringSI);

                // Konektiramo se na bazu MIPSED.7 (ujedno i defaultna konekcija)
                SqlClient dbMIPSED7 = new SqlClient();

                // MIPSED.1 OS -> čitanje podataka iz tablice dbo.OSNOVNASREDSTVA
                DataTable dtSitniInventar = new DataTable();
                dtSitniInventar = dbMIPSED1SI.GetDataTable("SELECT * FROM dbo.OSNOVNASREDSTVA");

                // Counter za brojanje uspješnih/neuspješnih prijenosa
                int countSuccess = 0;
                int countError = 0;

                // ukoliko 
                Int64 INVBROJ = 0;
                DateTime dtNabave = DateTime.Now;
                DateTime dtUporabe = DateTime.Now;
                int kolicinaUlaza = 0;
                decimal osnovica = 0;
                decimal ispravak = 0;
                string napomena = string.Empty;
                int IDOSVRSTA = 2;
                string inventarni_broj = string.Empty;


                // Zadnji inventurni broj
                inventarni_broj = dbMIPSED7.ExecuteScalar("Select Max(INVBROJ) From OS").ToString();
                if (inventarni_broj.Length == 0)
                {
                    INVBROJ = 0;
                }
                else
                {
                    INVBROJ = Convert.ToInt64(inventarni_broj);
                }

                foreach (DataRow drRow in dtSitniInventar.Rows)
                {
                    string sqlInsertCommand = string.Empty;

                    try
                    {
                        INVBROJ++;

                        // fix #2
                        if (drRow["datnab"] != DBNull.Value)
                        {
                            dtNabave = DateTime.Parse(drRow["datnab"].ToString());
                        }
                        else // ukoliko podatak ne postoji, uzimamo DATUMUPORABE ili trenutni datum ukoliko niti taj ne postoji
                        {
                            if (drRow["datupo"] != DBNull.Value)
                                dtNabave = DateTime.Parse(drRow["datnab"].ToString());
                            else
                                dtNabave = DateTime.Today;
                        }

                        // fix #3
                        if (drRow["datupo"] != DBNull.Value)
                        {
                            dtUporabe = DateTime.Parse(drRow["datupo"].ToString());
                        }
                        else // ukoliko podatak ne postoji, uzimamo DATUMNABAVKE ili trenutni datum ukoliko niti taj ne postoji
                        {
                            if (drRow["datnab"] != DBNull.Value)
                                dtUporabe = DateTime.Parse(drRow["datnab"].ToString());
                            else
                                dtUporabe = DateTime.Today;
                        }

                        // fix #4
                        //if (drRow["datnab"] != DBNull.Value)
                        //{
                        //    decimal stopaAmortizacije = Convert.ToDecimal(dbMIPSED1SI.ExecuteScalar(string.Format("SELECT ISNULL(STOPA, 0) FROM dbo.SkupineAmortizacije WHERE sifska = '{0}'", drRow["sifska"])));

                        //    // "ako je datumnabavke OVE godine i postotak amortizacije 100%"
                        //    if (((DateTime)drRow["datnab"]).Year == DateTime.Today.Year && stopaAmortizacije == 100M)
                        //    {
                        //        IDOSVRSTA = 2; // SITAN INVENTAR
                        //    }
                        //}

                        // fix #5
                        if (drRow["kol"] != DBNull.Value)
                            if (!int.TryParse(drRow["kol"].ToString(), out kolicinaUlaza)) { kolicinaUlaza = 0; }

                        // fix #6
                        if (drRow["osnovica"] != DBNull.Value)
                            if (!decimal.TryParse(drRow["osnovica"].ToString(), out osnovica)) { osnovica = 0; }

                        // fix #7
                        if (drRow["ispravak"] != DBNull.Value)
                            if (!decimal.TryParse(drRow["ispravak"].ToString(), out ispravak)) { ispravak = 0; }


                        if (drRow["napomena"].ToString().Length > 50)
                        {
                            napomena = drRow["napomena"].ToString().Substring(0, 50);
                        }
                        else
                        {
                            napomena = drRow["napomena"].ToString();
                        }


                        // INSERT
                        sqlInsertCommand = string.Format("INSERT INTO dbo.OS (INVBROJ, NAZIVOS, DATUMNABAVKE, DATUMUPORABE, NAPOMENAOS, IDAMSKUPINE, IDOSVRSTA) " +
                            "VALUES ({0}, '{1}', '{2}', '{3}', '{4}', {5}, {6})",
                            INVBROJ,
                            Substring(drRow["nazos"].ToString(), 50),
                            dtNabave.ToString("yyyy.MM.dd"),
                            dtUporabe.ToString("yyyy.MM.dd"),
                            napomena,
                            0, // AM skupina - NEDEFINIRANO
                            IDOSVRSTA);


                        dbMIPSED7.ExecuteNonQuery(sqlInsertCommand);

                        // INSERT u temeljnicu
                        // NABAVNA
                        sqlInsertCommand = string.Format("INSERT INTO dbo.OSTEMELJNICA (INVBROJ, IDOSDOKUMENT, OSBROJDOKUMENTA, OSDATUMDOK, OSKOLICINA, OSSTOPA, OSOSNOVICA, OSDUGUJE, OSPOTRAZUJE, RASHODLOKACIJEIDLOKACIJE, OSOPIS) " +
                            "VALUES ({0}, {1}, {2}, '{3}', {4}, {5}, {6}, {7}, {8}, {9}, '{10}')",
                            INVBROJ,
                            1, // Nabava
                            0,
                            DateTime.Now.ToString("yyy.MM.dd"),
                            kolicinaUlaza,
                            29,
                            0, // ovdje ne ide osnovica - ovo je defaultno 0 (nula)
                            osnovica.ToString().Replace(",", "."), // osnovica
                            0, // ispravak
                            "NULL",
                            "PS-Nabavna");

                        dbMIPSED7.ExecuteNonQuery(sqlInsertCommand);


                        // AMORTIZACIJA
                        sqlInsertCommand = string.Format("INSERT INTO dbo.OSTEMELJNICA (INVBROJ, IDOSDOKUMENT, OSBROJDOKUMENTA, OSDATUMDOK, OSKOLICINA, OSSTOPA, OSOSNOVICA, OSDUGUJE, OSPOTRAZUJE, RASHODLOKACIJEIDLOKACIJE, OSOPIS) " +
                            "VALUES ({0}, {1}, {2}, '{3}', {4}, {5}, {6}, {7}, {8}, {9}, '{10}')",
                            INVBROJ,
                            2, // Amortizacija
                            0,
                            DateTime.Now.ToString("yyy.MM.dd"),
                            kolicinaUlaza,
                            29,
                            0, // ovdje ne ide osnovica - ovo je defaultno 0 (nula)
                            0, // osnovica
                            ispravak.ToString().Replace(",", "."), // ispravak
                            "NULL",
                            "PS-Ispravak");

                        dbMIPSED7.ExecuteNonQuery(sqlInsertCommand);

                        countSuccess++;
                    }
                    catch (Exception exception)
                    {
                        countError++;
                        ExceptionMessageCollection.Add(new Tuple<string, string>(exception.Message, sqlInsertCommand));
                    }
                    finally
                    {
                        DisplayMigrationStatus(this.lblMigracijaSI, countSuccess, countError, dtSitniInventar.Rows.Count);
                    }
                }
            }
        }

        private void DisplayMigrationStatus(Label lblMigracijaStatus, int countSuccess, int countError, int total)
        {
            lblMigracijaStatus.ForeColor = System.Drawing.SystemColors.ControlText;

            lblMigracijaStatus.Text = "Početak migracije..." + Environment.NewLine + Environment.NewLine;
            lblMigracijaStatus.Text += "Migrirano: " + countSuccess + " od " + total + Environment.NewLine;

            if (countError > 0)
                lblMigracijaStatus.Text += "NIJE migrirano: " + countError + " od " + total + Environment.NewLine;

            // Ako smo došli do kraja sa migracijom, prikaži finalan status
            if (countSuccess + countError == total)
            {
                if (countSuccess == total)
                {
                    lblMigracijaStatus.ForeColor = System.Drawing.Color.Green;

                    lblMigracijaStatus.Text += Environment.NewLine;
                    lblMigracijaStatus.Text += "------------------------------------------";
                    lblMigracijaStatus.Text += Environment.NewLine;
                    lblMigracijaStatus.Text += "Podaci su USPJEŠNO migrirani!!";
                    lblMigracijaStatus.Text += Environment.NewLine;
                    lblMigracijaStatus.Text += "------------------------------------------";
                }
                else
                {
                    lblMigracijaStatus.ForeColor = System.Drawing.Color.Red;

                    lblMigracijaStatus.Text += Environment.NewLine;
                    lblMigracijaStatus.Text += "------------------------------------------";
                    lblMigracijaStatus.Text += Environment.NewLine;
                    lblMigracijaStatus.Text += "GREŠKA u migraciji podataka!!";
                    lblMigracijaStatus.Text += Environment.NewLine;
                    lblMigracijaStatus.Text += "------------------------------------------";
                }
            }

            lblMigracijaStatus.Refresh();
            lblMigracijaStatus.Update();
        }

        private void LogException()
        {
            // ako nema exceptiona, izađi
            if (this.ExceptionMessageCollection.Count == 0)
                return;

            string fileName = string.Format("MigracijaLogException_{0:yyyy}_{0:MM}_{0:dd}__{0:HH}_{0:mm}_{0:ss}.txt", DateTime.Now);

            StreamWriter streamWriter = new StreamWriter(fileName);

            string emailMessage = string.Empty;

            foreach (var data in this.ExceptionMessageCollection)
            {
                streamWriter.WriteLine(data.Item1);
                streamWriter.WriteLine(data.Item2);
                streamWriter.WriteLine("---------------------------------------------------------------------------------------------------");

                emailMessage += data.Item1 + "<br />";
                emailMessage += data.Item2 + "<br />";
                emailMessage += "---------------------------------------------------------------------------------------------------<br />";
            }

            streamWriter.Flush();
            streamWriter.Close();

            System.Diagnostics.Process.Start(fileName);

            new Mipsed7.Emailing.SendException(new Exception("GREŠKA - Migracija MIPSED.1", new Exception(emailMessage))).Send();
        }

        /// <summary>
        /// Ukoliko je podatak NULL, vrati defaultni vrijednost.
        /// Funkcija se koristi kada je izvorno polje NULL, a targetirano polje NOT NULL.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private string IsNull(object value, string defaultValue)
        {
            if (value == DBNull.Value)
                return defaultValue;

            return value.ToString().Trim();
        }

        /// <summary>
        /// Konvertiranje vrijednosti DBNULL u "NULL"
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string DBNullToNull(object value)
        {
            if (value == DBNull.Value)
                return "NULL";

            return string.Format("'{0}'", value.ToString().Trim());
        }

        /// <summary>
        /// Konvertiranje vrijednosti DECIMAL u string (riješava problem zareza i decimalne točke)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string DecimalToString(object value)
        {
            // ukoliko vrijednost nije DBNULL
            if (value != DBNull.Value)
            {
                return value.ToString().Replace(",", ".");
            }

            return "NULL";
        }

        /// <summary>
        /// Konvertiranje vrijednosti BOOL, True ili False u 1 ili 0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string Boolean_TrueFalse_to_1_0(object value)
        {
            // ukoliko vrijednost nije DBNULL
            if (value != DBNull.Value)
            {
                try
                {
                    return Convert.ToInt32((bool)value).ToString();
                }
                catch (Exception)
                {
                    return "NULL";
                }
            }

            return "NULL";
        }

        /// <summary>
        /// Konvertiranje datuma u format podoban za insertiranje
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string FixDateTime(object value)
        {
            // ukoliko vrijednost nije DBNULL
            if (value != DBNull.Value)
            {
                return string.Format("CONVERT(DateTime, '{0}', 103)", value);
            }

            return "NULL";
        }

        /// <summary>
        /// Funkcija se koristi kada je izvorno polje DULJE od targetiranog polja
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLimit"></param>
        /// <returns></returns>
        private string Substring(string value, int maxLimit)
        {
            if (maxLimit < value.Length)
                return value.Substring(0, maxLimit);

            return value;
        }

        private string FixSpol(object value)
        {
            switch (value.ToString().ToUpper())
            {
                case "M":
                    return "1"; // MUŠKO
                case "Ž":
                    return "2"; // ŽENSKO
                case "Z": // (za svaki slučaj)
                    return "2"; // ŽENSKO
                default:
                    return "1"; // MUŠKO
            }
        }

        private void btnPrikaziBazeSI_Click(object sender, EventArgs e)
        {
            ProvjeriBaze(txtSQLInstancaSI, txtSQLKorisnikSI, txtSQLLozinkaSI, cmbBazaSitni, lblKonekcijaStatusSI, true);
        }

        private void btnHonoraribaza_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdHonorari = new OpenFileDialog();

            if (ofdHonorari.ShowDialog() == DialogResult.OK)
            {
                Honorair_baza = ofdHonorari.FileName;
                lblHonorariPutanjaBaza.Text = Honorair_baza;
                btnProvjeriPodatke.Enabled = true;
            }
        }
    }
}
