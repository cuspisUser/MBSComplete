using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace JOPPD
{
    public class BusinessLogic
    {
        SqlClient client = null;
        public BusinessLogic()
            : base()
        {
            client = new SqlClient();
        }

        #region Svojstva

        //joppd svojstva
        public static int? pID
        {
            get;
            set;
        }
        public static string pOznaka
        {
            get;
            set;
        }
        public static string pKratkiOpis
        {
            get;
            set;
        }
        public static string pDugiOpis
        {
            get;
            set;
        }

        public static int? pJOPPDOznaka
        {
            get;
            set;
        }
        public static int? pElement
        {
            get;
            set;
        }

        //registar putnih naloga svojstva
        public static int? pID_Radnik
        {
            get;
            set;
        }
        public static DateTime? pDatumPutnogNaloga
        {
            get;
            set;
        }
        public static int? pID_Likvidator
        {
            get;
            set;
        }
        public static string pSifraPutnogNaloga
        {
            get;
            set;
        }
        public static decimal? pTroskoviPutovanja
        {
            get;
            set;
        }
        public static decimal? pTroskoviVlastitogVozila
        {
            get;
            set;
        }
        public static decimal? pOstaliTroskovi
        {
            get;
            set;
        }
        public static decimal? pDnevnice
        {
            get;
            set;
        }
        public static int? pID_NacinIsplate
        {
            get;
            set;
        }
        public static decimal? pTroskoviSmjestaja
        {
            get;
            set;
        }
        public static bool pIsTroskoviSmjestaja
        {
            get;
            set;
        }
        public static bool pIsTroskoviAutoputa
        {
            get;
            set;
        }
        public static bool pIsDrugiTroskovi
        {
            get;
            set;
        }
        public static decimal? pAkontacija
        {
            get;
            set;
        }
        public static DateTime? pDatumObracuna
        {
            get;
            set;
        }
        public static Int16? pVrstaRadnika
        {
            get;
            set;
        }

        public static int pSelectedIndex { get; set; }

        #endregion

        #region DohvatPodataka

        public DataTable GetMjesecOsiguranja()
        {
            DataTable dt = client.GetDataTable("Select ID, Oznaka, KratkiOpis, DugiOpis From JOPPDOznakaMjesecaOsiguranje");
            return dt;
        }

        public DataTable GetNacinIsplate()
        {
            DataTable dt = client.GetDataTable("Select ID, Oznaka, KratkiOpis, DugiOpis From JOPPDOznakaNacinaIsplate");
            return dt;
        }

        public DataTable GetNeoporeziviPrimitak()
        {
            DataTable dt = client.GetDataTable("Select ID, Oznaka, KratkiOpis, DugiOpis From JOPPDOznakaNeoporezivogPrimitka");
            return dt;
        }

        public DataTable GetRadnoVrijeme()
        {
            DataTable dt = client.GetDataTable("Select ID, Oznaka, KratkiOpis, DugiOpis From JOPPDOznakaRadnogVremena");
            return dt;
        }

        public DataTable GetStjecateljPrimitka()
        {
            DataTable dt = client.GetDataTable("Select ID, Oznaka, KratkiOpis, DugiOpis From JOPPDOznakaStjecateljaPrimitka");
            return dt;
        }

        public DataTable GetOznakaPrimitka()
        {
            DataTable dt = client.GetDataTable("Select ID, Oznaka, KratkiOpis, DugiOpis From JOPPDOznakaPrimitka");
            return dt;
        }

        public DataTable GetNacinIsplateElement()
        {
            DataTable dt = client.GetDataTable("Select JOPPDOznakaNacinaIsplateElement.ID, JOPPDOznakaNacinaIsplateElement.JOPPDOznakaNacinaIsplateID, JOPPDOznakaNacinaIsplate.Oznaka, " +
                                               "JOPPDOznakaNacinaIsplate.KratkiOpis, ELEMENT.NAZIVELEMENT, JOPPDOznakaNacinaIsplateElement.IDELEMENT From JOPPDOznakaNacinaIsplateElement " +
                                               "Inner Join JOPPDOznakaNacinaIsplate ON JOPPDOznakaNacinaIsplateElement.JOPPDOznakaNacinaIsplateID = JOPPDOznakaNacinaIsplate.ID " +
                                               "Inner Join ELEMENT ON JOPPDOznakaNacinaIsplateElement.IDELEMENT = ELEMENT.IDELEMENT");
            return dt;
        }

        public DataTable GetElement()
        {
            DataTable dt = client.GetDataTable("Select IDELEMENT As ID, NAZIVELEMENT As Naziv From ELEMENT");
            return dt;
        }

        public DataTable GetJOPPDOznakaNacinIsplate()
        {
            DataTable dt = client.GetDataTable("Select ID, (cast(Oznaka as nvarchar) + ' | ' + KratkiOpis) As Naziv From JOPPDOznakaNacinaIsplate");
            return dt;
        }

        public DataTable GetNeoporeziviPrimitakElement()
        {
            DataTable dt = client.GetDataTable("Select JOPPDOznakaNeoporezivogPrimitkaElement.ID, JOPPDOznakaNeoporezivogPrimitkaElement.JOPPDOznakaNeoporezivogPrimitkaID, " + 
                                               "JOPPDOznakaNeoporezivogPrimitka.Oznaka, JOPPDOznakaNeoporezivogPrimitka.KratkiOpis, ELEMENT.NAZIVELEMENT, " + 
                                               "JOPPDOznakaNeoporezivogPrimitkaElement.IDELEMENT From JOPPDOznakaNeoporezivogPrimitkaElement Inner Join "+ 
                                               "JOPPDOznakaNeoporezivogPrimitka ON JOPPDOznakaNeoporezivogPrimitkaElement.JOPPDOznakaNeoporezivogPrimitkaID = JOPPDOznakaNeoporezivogPrimitka.ID " +
                                               "Inner Join ELEMENT ON JOPPDOznakaNeoporezivogPrimitkaElement.IDELEMENT = ELEMENT.IDELEMENT");
            return dt;
        }

        public DataTable GetJOPPDOznakaNeoporeziviPrimitak()
        {
            DataTable dt = client.GetDataTable("Select ID, (cast(Oznaka as nvarchar) + ' | ' + KratkiOpis) As Naziv From JOPPDOznakaNeoporezivogPrimitka");
            return dt;
        }

        public DataTable GetOznakaPrimitkaElement()
        {
            DataTable dt = client.GetDataTable("Select JOPPDOznakaPrimitkaElement.ID, JOPPDOznakaPrimitkaElement.JOPPDOznakaPrimitkaID, JOPPDOznakaPrimitka.Oznaka, " + 
                                               "JOPPDOznakaPrimitka.KratkiOpis, ELEMENT.NAZIVELEMENT, JOPPDOznakaPrimitkaElement.IDELEMENT From JOPPDOznakaPrimitkaElement  " +
                                               "Inner Join JOPPDOznakaPrimitka ON JOPPDOznakaPrimitkaElement.JOPPDOznakaPrimitkaID = JOPPDOznakaPrimitka.ID " +
                                               "Inner Join ELEMENT ON JOPPDOznakaPrimitkaElement.IDELEMENT = ELEMENT.IDELEMENT");
            return dt;
        }

        public DataTable GetJOPPDOznakaPrimitka()
        {
            DataTable dt = client.GetDataTable("Select ID, (cast(Oznaka as nvarchar) + ' | ' + KratkiOpis) As Naziv From JOPPDOznakaPrimitka");
            return dt;
        }

        public DataTable GetStjecateljPrimitkaElement()
        {
            DataTable dt = client.GetDataTable("Select JOPPDOznakaStjecateljaPrimitkaElement.ID, JOPPDOznakaStjecateljaPrimitkaElement.JOPPDOznakaStjecateljaPrimitkaID, " +
                                               "JOPPDOznakaStjecateljaPrimitka.Oznaka, JOPPDOznakaStjecateljaPrimitka.KratkiOpis, ELEMENT.NAZIVELEMENT, " + 
                                               "JOPPDOznakaStjecateljaPrimitkaElement.IDELEMENT From JOPPDOznakaStjecateljaPrimitkaElement Inner Join " + 
                                               "JOPPDOznakaStjecateljaPrimitka ON JOPPDOznakaStjecateljaPrimitkaElement.JOPPDOznakaStjecateljaPrimitkaID = JOPPDOznakaStjecateljaPrimitka.ID " +
                                               "Inner Join ELEMENT ON JOPPDOznakaStjecateljaPrimitkaElement.IDELEMENT = ELEMENT.IDELEMENT");
            return dt;
        }

        public DataTable GetJOPPDStjecateljPrimitkaElement()
        {
            DataTable dt = client.GetDataTable("Select ID, (cast(Oznaka as nvarchar) + ' | ' + KratkiOpis) As Naziv From JOPPDOznakaStjecateljaPrimitka");
            return dt;
        }

        public DataTable GetRadnici()
        {
            DataTable dt = client.GetDataTable("Select IDRADNIK As ID, (IME + ' ' + PREZIME) As Naziv From RADNIK Where Aktivan = 1 Order by IME + ' ' + PREZIME");
            return dt;
        }

        public DataTable GetHonorari()
        {
            DataTable dt = client.GetDataTable("Select DDIDRADNIK As ID, (DDIME + ' ' + DDPREZIME) As Naziv From DDRADNIK Order by DDIME + ' ' + DDPREZIME");
            return dt;
        }

        public DataTable GetPutniNalog()
        {
            string active_year = client.ExecuteScalar("Select IDGODINE From GODINE Where GODINEAKTIVNA = 1").ToString();

            DataTable dt = client.GetDataTable("Select 'false' As Ozn, RegistarPutnihNaloga.ID, ID_Radnik As 'Šifra radnika', '' As 'Ime i Prezime', '' As 'Radno mjesto', " + 
                                               "DatumPutnogNaloga As 'Datum putnog naloga', '' As 'Likvidator', SifraPutnogNalog As 'Šifra putnog naloga', " +
                                               "'' As 'Trošak putnog naloga', JOPPDOznakaNacinaIsplate.KratkiOpis As 'Način isplate', " + 
                                               "JOPPD_OznakaIzvjesca As 'JOPPD ID', ID_Likvidator, '' As IDRADNOMJESTO, ID_NacinIsplate, "+
                                               "TroskoviPutovanja, TroskoviVlastitogVozila, OstaliTroskovi, Dnevnice, TroskoviSmjestaja, " +
                                               "IsTroskoviSmjestaja, IsTroskoviAutoputa, IsDrugiTroskovi, DatumObracuna, Akontacija, VrstaDjelatnika From RegistarPutnihNaloga " +
                                               "Inner Join JOPPDOznakaNacinaIsplate ON RegistarPutnihNaloga.ID_NacinIsplate = JOPPDOznakaNacinaIsplate.ID Where YEAR(DatumPutnogNaloga) = '" + active_year + "'");

            foreach (DataRow red in dt.Rows)
            {
                if (red["ID_Likvidator"].ToString() != "")
                {
                    red["Likvidator"] = GetLikvidatorID(red["ID_Likvidator"].ToString());
                }
                if (red["Šifra radnika"].ToString() != "")
                {
                    red["Ime i Prezime"] = GetRadnikID(red["Šifra radnika"].ToString(), red["VrstaDjelatnika"].ToString());
                }
                if (red["IDRADNOMJESTO"].ToString() != "")
                {
                    red["Radno mjesto"] = GetRadnoMjestoID(red["IDRADNOMJESTO"].ToString());
                }
                if (red["Trošak putnog naloga"].ToString() == "")
                {
                    red["Trošak putnog naloga"] = GetIznosZaIsplatu(red["ID"].ToString());
                }
            }

            return dt;
        }

        public string GetRadnikID(string id, string vrsta)
        {
            DataTable dt = new DataTable();
            if (vrsta == "1")
            {
                dt = client.GetDataTable("Select (IME + ' ' + PREZIME) As Naziv From RADNIK Where IDRADNIK = '" + id + "'");
            }
            else if (vrsta == "2")
            {
                dt = client.GetDataTable("Select (DDIME + ' ' + DDPREZIME) As Naziv From DDRADNIK Where DDIDRADNIK = '" + id + "'");
            }

            return dt.Rows[0]["Naziv"].ToString();
        }

        public string GetLikvidatorID(string id)
        {
            DataTable dt = client.GetDataTable("Select (IME + ' ' + PREZIME) As Naziv From RADNIK Where IDRADNIK = '" + id + "'");
            return dt.Rows[0]["Naziv"].ToString();
        }

        public string GetRadnoMjestoID(string id)
        {
            DataTable dt = client.GetDataTable("Select NAZIVRADNOMJESTO As Naziv From RADNOMJESTO Where IDRADNOMJESTO = '" + id + "'");
            return dt.Rows[0]["Naziv"].ToString();
        }

        public string GetIznosZaIsplatu(string id)
        {
            DataTable dt = client.GetDataTable("Select Sum(TroskoviPutovanja + TroskoviVlastitogVozila + OstaliTroskovi + Dnevnice + TroskoviSmjestaja - Akontacija) From RegistarPutnihNaloga Where ID = '" + id + "'");
            return dt.Rows[0][0].ToString();
        }


        public DataTable GetVrstaIzvjesca()
        {
            DataTable dt = client.GetDataTable("SELECT ID, Sifra, Naziv FROM dbo.JOPPDAVrstaIzvjesca");
            return dt;
        }

        public DataTable GetObracunPlace()
        {
            DataTable dt = client.GetDataTable("SELECT 'false' As 'Ozn', IDOBRACUN, SVRHAOBRACUNA, MJESECOBRACUNA FROM OBRACUN " +
                                               "Where IDOBRACUN NOT IN (Select Obracun_ID From JOPPDAObracun Where Vrsta = 0) And GODINAOBRACUNA > 2013");
            return dt;
        }

        public DataTable GetObracunPraksa()
        {
            DataTable dt = client.GetDataTable("SELECT 'false' As 'Ozn', CAST (UCOBRMJESEC AS nvarchar ) + '-' + CAST (UCOBRGODINA AS nvarchar) As IDOBRACUN, UCOBROPIS, OSNOVICAPODANU " +
                           "FROM UCENIKOBRACUN Where (CAST (UCOBRMJESEC AS nvarchar ) + '-' + CAST (UCOBRGODINA AS nvarchar)) NOT IN (Select Obracun_ID From JOPPDAObracun Where Vrsta = 3) And UCOBRGODINA > 2013");
            return dt;
        }

        public DataTable GetObracunHonorari()
        {
            DataTable dt = client.GetDataTable("Select 'false' As 'Ozn', DDOBRACUNIDOBRACUN As IDOBRACUN, DDOPISOBRACUN From DDOBRACUN " +
                                               "Where DDOBRACUNIDOBRACUN NOT IN (Select Obracun_ID From JOPPDAObracun Where Vrsta = 1) And YEAR(DDDATUMOBRACUNA) > 2013");
            return dt;
        }

        public DataTable GetVirmaniInvalidi()
        {
            DataTable dt = client.GetDataTable("Select 'false' As 'Ozn', SIFRAOBRACUNAVIRMAN As IDOBRACUN, OPISPLACANJAVIRMAN, IZNOS From VIRMANI " +
                                               "Where SIFRAOBRACUNAVIRMAN NOT IN (Select Obracun_ID From JOPPDAObracun Where Vrsta = 5) And SIFRAOBRACUNAVIRMAN Like 'INV-%'");
            return dt;
        }

        public DataTable GetObracunPutniNalog()
        {
            DataTable dt = client.GetDataTable("Select 'false' As 'Ozn', ID, '' As 'IME', RegistarPutnihNaloga.DatumPutnogNaloga, " + 
                                               "Sum(RegistarPutnihNaloga.TroskoviPutovanja + RegistarPutnihNaloga.TroskoviVlastitogVozila + " + 
                                               "RegistarPutnihNaloga.OstaliTroskovi + RegistarPutnihNaloga.Dnevnice + RegistarPutnihNaloga.TroskoviSmjestaja) " +
                                               "As 'Trošak putnog naloga', RegistarPutnihNaloga.VrstaDjelatnika, RegistarPutnihNaloga.ID_Radnik From RegistarPutnihNaloga " + 
                                               "Where MONTH(DatumObracuna) >= MONTH(GETDATE()) - 1 And RegistarPutnihNaloga.ID NOT IN (Select Obracun_ID From JOPPDAObracun Where Vrsta = 2)" +
                                               "group by RegistarPutnihNaloga.ID, RegistarPutnihNaloga.DatumPutnogNaloga, RegistarPutnihNaloga.VrstaDjelatnika, RegistarPutnihNaloga.ID_Radnik");


            foreach (DataRow red in dt.Rows)
            {
                if (red["IME"].ToString() == "")
                {
                    red["IME"] = GetRadnikID(red["ID_Radnik"].ToString(), red["VrstaDjelatnika"].ToString());
                }
            }

            return dt;
        }

        public DataTable GetObracunRazno()
        {
            DataTable dt = client.GetDataTable("Select 'false' As 'Ozn', Sifra, Naziv, VrstaObracuna From JOPPDObracunRazno " +
                                               "Where Sifra NOT IN (Select Obracun_ID From JOPPDAObracun Where Vrsta = 4)");
            return dt;
        }

        public DataTable GetOznakaPodnositelja()
        {
            DataTable dt = client.GetDataTable("Select ID, Oznaka, Naziv From JOPPDPodnositeljIzvjesca");
            return dt;
        }

        public DataTable GetRadniciDopuna(string joppda_id)
        {
            DataTable dt = client.GetDataTable("Select Distinct 'false' As 'Ozn', ImePrezimeStjecatelja, OIBStjecatelja From JOPPDB Where JOPPDAID = '" + joppda_id + "'");
            return dt;
        }

        public DataTable GetPostojeciObracun()
        {
            string active_year = client.ExecuteScalar("Select IDGODINE From GODINE Where GODINEAKTIVNA = 1").ToString();

            DataTable dt = client.GetDataTable("SELECT ID, OznakaIzvjesca, OznakaIzvjescaDatum, VrstaIzvjescaID FROM dbo.JOPPDA Where Year(OznakaIzvjescaDatum) = '" + active_year + "' " +
                                               "Order by OznakaIzvjesca desc");
            return dt;
        }

        public decimal GetSifraVrsteIzvjesca(int id)
        {
            DataTable dt = client.GetDataTable("SELECT [Sifra] FROM dbo.JOPPDAVrstaIzvjesca Where ID = '" + id +"'");
            return Convert.ToDecimal(dt.Rows[0][0]);
        }

        public DataRow GetJOPPDAByID(int id)
        {
            DataTable dt = client.GetDataTable("SELECT ID, OznakaIzvjesca, OznakaIzvjescaDatum, VrstaIzvjescaID FROM dbo.JOPPDA" + 
                                               " Where ID = '" + id + "'");
            return dt.Rows[0];
        }

        public int GetJOPPDAProvjeraByID(int id, string datum, int oznaka_podnositelja)
        {
            DataTable dt = client.GetDataTable("SELECT ID FROM dbo.JOPPDA Where OznakaIzvjescaDatum = '" + datum + "' And VrstaIzvjescaID = '" + id + 
                                                "' And OznakaPodnositelja = '" + oznaka_podnositelja + "'");
            return dt.Rows.Count;
        }

        #endregion

        #region RadSaPodacima

        public bool Insert(string tablica)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into " + tablica + " (Oznaka, KratkiOpis, DugiOpis) Values(@Oznaka, @KratkiOpis, @DugiOpis)";

            sqlUpit.Parameters.Add(new SqlParameter("@Oznaka", pOznaka));
            sqlUpit.Parameters.Add(new SqlParameter("@KratkiOpis", pKratkiOpis));
            sqlUpit.Parameters.Add(new SqlParameter("@DugiOpis", pDugiOpis));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Update(string tablica)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update " + tablica + " set Oznaka = @Oznaka, KratkiOpis = @KratkiOpis, DugiOpis = @DugiOpis Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@Oznaka", pOznaka));
            sqlUpit.Parameters.Add(new SqlParameter("@KratkiOpis", pKratkiOpis));
            sqlUpit.Parameters.Add(new SqlParameter("@DugiOpis", pDugiOpis));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string tablica)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete From " + tablica + " Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertNacinIsplateElement()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into JOPPDOznakaNacinaIsplateElement (JOPPDOznakaNacinaIsplateID, IDELEMENT) Values(@JOPPDOznakaNacinaIsplateID, @IDELEMENT)";

            sqlUpit.Parameters.Add(new SqlParameter("@JOPPDOznakaNacinaIsplateID", pJOPPDOznaka));
            sqlUpit.Parameters.Add(new SqlParameter("@IDELEMENT", pElement));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateNacinIsplateElement()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update JOPPDOznakaNacinaIsplateElement set JOPPDOznakaNacinaIsplateID = @JOPPDOznakaNacinaIsplateID, IDELEMENT = @IDELEMENT Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@JOPPDOznakaNacinaIsplateID", pJOPPDOznaka));
            sqlUpit.Parameters.Add(new SqlParameter("@IDELEMENT", pElement));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteNacinIsplateElement()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete From JOPPDOznakaNacinaIsplateElement Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertNeoporeziviPrimitakElement()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into JOPPDOznakaNeoporezivogPrimitkaElement (JOPPDOznakaNeoporezivogPrimitkaID, IDELEMENT) Values(@JOPPDOznakaNeoporezivogPrimitkaID, @IDELEMENT)";

            sqlUpit.Parameters.Add(new SqlParameter("@JOPPDOznakaNeoporezivogPrimitkaID", pJOPPDOznaka));
            sqlUpit.Parameters.Add(new SqlParameter("@IDELEMENT", pElement));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateNeoporeziviPrimitakElement()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update JOPPDOznakaNeoporezivogPrimitkaElement set JOPPDOznakaNeoporezivogPrimitkaID = @JOPPDOznakaNeoporezivogPrimitkaID, IDELEMENT = @IDELEMENT Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@JOPPDOznakaNeoporezivogPrimitkaID", pJOPPDOznaka));
            sqlUpit.Parameters.Add(new SqlParameter("@IDELEMENT", pElement));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteNeoporeziviPrimitakElement()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete From JOPPDOznakaNeoporezivogPrimitkaElement Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertOznakaPrimitkaElement()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into JOPPDOznakaPrimitkaElement (JOPPDOznakaPrimitkaID, IDELEMENT) Values(@JOPPDOznakaPrimitkaID, @IDELEMENT)";

            sqlUpit.Parameters.Add(new SqlParameter("@JOPPDOznakaPrimitkaID", pJOPPDOznaka));
            sqlUpit.Parameters.Add(new SqlParameter("@IDELEMENT", pElement));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateOznakaPrimitkaElement()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update JOPPDOznakaPrimitkaElement set JOPPDOznakaPrimitkaID = @JOPPDOznakaPrimitkaID, IDELEMENT = @IDELEMENT Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@JOPPDOznakaPrimitkaID", pJOPPDOznaka));
            sqlUpit.Parameters.Add(new SqlParameter("@IDELEMENT", pElement));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOznakaPrimitkaElement()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete From JOPPDOznakaPrimitkaElement Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertStjecateljPrimitkaElement()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into JOPPDOznakaStjecateljaPrimitkaElement (JOPPDOznakaStjecateljaPrimitkaID, IDELEMENT) Values(@JOPPDOznakaStjecateljaPrimitkaID, @IDELEMENT)";

            sqlUpit.Parameters.Add(new SqlParameter("@JOPPDOznakaStjecateljaPrimitkaID", pJOPPDOznaka));
            sqlUpit.Parameters.Add(new SqlParameter("@IDELEMENT", pElement));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateStjecateljPrimitkaElement()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update JOPPDOznakaStjecateljaPrimitkaElement set JOPPDOznakaStjecateljaPrimitkaID = @JOPPDOznakaStjecateljaPrimitkaID, IDELEMENT = @IDELEMENT Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@JOPPDOznakaStjecateljaPrimitkaID", pJOPPDOznaka));
            sqlUpit.Parameters.Add(new SqlParameter("@IDELEMENT", pElement));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteStjecateljPrimitkaElement()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete From JOPPDOznakaStjecateljaPrimitkaElement Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertPutniNalog()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into RegistarPutnihNaloga (ID_Radnik, DatumPutnogNaloga, ID_Likvidator, SifraPutnogNalog, TroskoviPutovanja, TroskoviVlastitogVozila, " +
                                  "OstaliTroskovi, Dnevnice, ID_NacinIsplate, TroskoviSmjestaja, IsTroskoviSmjestaja, IsDrugiTroskovi, DatumObracuna, Akontacija, IsTroskoviAutoputa, TS, VrstaDjelatnika) " + 
                                  "Values(@ID_Radnik, @DatumPutnogNaloga, @ID_Likvidator, @SifraPutnogNalog, @TroskoviPutovanja, @TroskoviVlastitogVozila, " +
                                  "@OstaliTroskovi, @Dnevnice, @ID_NacinIsplate, @TroskoviSmjestaja, @IsTroskoviSmjestaja, @IsDrugiTroskovi, @DatumObracuna, @Akontacija, @IsTroskoviAutoputa, @TS, @VrstaDjelatnika)";

            sqlUpit.Parameters.Add(new SqlParameter("@ID_Radnik", pID_Radnik));
            sqlUpit.Parameters.Add(new SqlParameter("@DatumPutnogNaloga", pDatumPutnogNaloga));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Likvidator", pID_Likvidator));
            sqlUpit.Parameters.Add(new SqlParameter("@SifraPutnogNalog", pSifraPutnogNaloga));
            sqlUpit.Parameters.Add(new SqlParameter("@TroskoviPutovanja", pTroskoviPutovanja));
            sqlUpit.Parameters.Add(new SqlParameter("@TroskoviVlastitogVozila", pTroskoviVlastitogVozila));
            sqlUpit.Parameters.Add(new SqlParameter("@OstaliTroskovi", pOstaliTroskovi));
            sqlUpit.Parameters.Add(new SqlParameter("@Dnevnice", pDnevnice));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_NacinIsplate", pID_NacinIsplate));
            sqlUpit.Parameters.Add(new SqlParameter("@TroskoviSmjestaja", pTroskoviSmjestaja));
            sqlUpit.Parameters.Add(new SqlParameter("@IsTroskoviSmjestaja", pIsTroskoviSmjestaja));
            sqlUpit.Parameters.Add(new SqlParameter("@IsDrugiTroskovi", pIsDrugiTroskovi));
            sqlUpit.Parameters.Add(new SqlParameter("@IsTroskoviAutoputa", pIsTroskoviAutoputa));
            if (pDatumObracuna == null)
                sqlUpit.Parameters.Add(new SqlParameter("@DatumObracuna", DBNull.Value));
            else
                sqlUpit.Parameters.Add(new SqlParameter("@DatumObracuna", pDatumObracuna));
            sqlUpit.Parameters.Add(new SqlParameter("@Akontacija", pAkontacija));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

            sqlUpit.Parameters.Add(new SqlParameter("@VrstaDjelatnika", pVrstaRadnika));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdatePutniNalog()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update RegistarPutnihNaloga set ID_Radnik = @ID_Radnik, DatumPutnogNaloga = @DatumPutnogNaloga, ID_Likvidator = @ID_Likvidator, " +
                                  "SifraPutnogNalog = @SifraPutnogNalog, TroskoviPutovanja = @TroskoviPutovanja, TroskoviVlastitogVozila = @TroskoviVlastitogVozila, " +
                                  "OstaliTroskovi = @OstaliTroskovi, Dnevnice = @Dnevnice, ID_NacinIsplate = @ID_NacinIsplate, TroskoviSmjestaja = @TroskoviSmjestaja, " +
                                  "IsTroskoviSmjestaja = @IsTroskoviSmjestaja, IsDrugiTroskovi = @IsDrugiTroskovi, " +
                                  "Akontacija = @Akontacija, DatumObracuna = @DatumObracuna, IsTroskoviAutoputa = @IsTroskoviAutoputa, TS = @TS, VrstaDjelatnika = @VrstaDjelatnika Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Radnik", pID_Radnik));
            sqlUpit.Parameters.Add(new SqlParameter("@DatumPutnogNaloga", pDatumPutnogNaloga));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Likvidator", pID_Likvidator));
            sqlUpit.Parameters.Add(new SqlParameter("@SifraPutnogNalog", pSifraPutnogNaloga));
            sqlUpit.Parameters.Add(new SqlParameter("@TroskoviPutovanja", pTroskoviPutovanja));
            sqlUpit.Parameters.Add(new SqlParameter("@TroskoviVlastitogVozila", pTroskoviVlastitogVozila));
            sqlUpit.Parameters.Add(new SqlParameter("@OstaliTroskovi", pOstaliTroskovi));
            sqlUpit.Parameters.Add(new SqlParameter("@Dnevnice", pDnevnice));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_NacinIsplate", pID_NacinIsplate));
            sqlUpit.Parameters.Add(new SqlParameter("@TroskoviSmjestaja", pTroskoviSmjestaja));
            sqlUpit.Parameters.Add(new SqlParameter("@IsTroskoviSmjestaja", pIsTroskoviSmjestaja));
            sqlUpit.Parameters.Add(new SqlParameter("@IsDrugiTroskovi", pIsDrugiTroskovi));
            sqlUpit.Parameters.Add(new SqlParameter("@IsTroskoviAutoputa", pIsTroskoviAutoputa));
            if (pDatumObracuna == null)
                sqlUpit.Parameters.Add(new SqlParameter("@DatumObracuna", DBNull.Value));
            else
                sqlUpit.Parameters.Add(new SqlParameter("@DatumObracuna", pDatumObracuna));
            sqlUpit.Parameters.Add(new SqlParameter("@Akontacija", pAkontacija));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

            sqlUpit.Parameters.Add(new SqlParameter("@VrstaDjelatnika", pVrstaRadnika));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePutniNalog()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete From RegistarPutnihNaloga Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int InsertJOPPDA(DateTime oznaka_izvjesca, int vrsta_izvjesca_id, int oznaka_podnositelja)
        {
            int id = 0;
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into JOPPDA (OznakaIzvjescaDatum, VrstaIzvjescaID, OznakaPodnositelja) Values(@OznakaIzvjescaDatum, @VrstaIzvjescaID, @OznakaPodnositelja) Select @@Identity";

            sqlUpit.Parameters.Add(new SqlParameter("@OznakaIzvjescaDatum", oznaka_izvjesca));
            sqlUpit.Parameters.Add(new SqlParameter("@VrstaIzvjescaID", vrsta_izvjesca_id));
            sqlUpit.Parameters.Add(new SqlParameter("@OznakaPodnositelja", oznaka_podnositelja));

            try
            {
                id = Convert.ToInt32(sqlUpit.ExecuteScalar());
            }
            catch
            {
            }
            return id;
        }

        public bool InsertJOPPDAObracun(int joppda_id, string obracun_id, int vrsta)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into JOPPDAObracun (JOPPDA_ID, Obracun_ID, Vrsta) Values(@JOPPDA_ID, @Obracun_ID, @Vrsta)";

            sqlUpit.Parameters.Add(new SqlParameter("@Obracun_ID", obracun_id));
            sqlUpit.Parameters.Add(new SqlParameter("@JOPPDA_ID", joppda_id));
            sqlUpit.Parameters.Add(new SqlParameter("@Vrsta", vrsta));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

        #region ObracuniRazno

        public class ObracunRazno
        {
            SqlClient client = null;
            public ObracunRazno()
                : base()
            {
                client = new SqlClient();
            }

            #region Properties
            public static int? pID_ObracunRazno
            {
                get;
                set;
            }
            public static int pSifra
            {
                get;
                set;
            }
            public static string pNaziv
            {
                get;
                set;
            }
            public static string pVrstaObracuna
            {
                get;
                set;
            }
            public static byte? pMjesec
            {
                get;
                set;
            }
            public static Int16? pGodina
            {
                get;
                set;
            }
            public static int? pID_OznakaNacinaIsplate
            {
                get;
                set;
            }
            public static int? pID_Veza
            {
                get;
                set;
            }
            public static int? pID_UF_Ucenik
            {
                get;
                set;
            }
            public static decimal? pIznos
            {
                get;
                set;
            }
            public static bool pUcenik { get; set; }
            public static bool pRoditelj { get; set; }
            public static bool pOstalo { get; set; }
            public static bool pUF { get; set; }
            public static bool pPraksa { get; set; }
            public static DataTable pOdabraneOsobe { get; set; }

            #endregion

            #region GetData

            public DataTable GetUceniciVeze()
            {
                DataTable dt = client.GetDataTable("Select ID, (Ime + ' ' + Prezime) As Naziv From UF_Ucenik Where ID_VrstaObiteljskeVeze = 1");
                return dt;
            }

            public DataTable GetOsobaVeza1(int id_ucenik)
            {
                DataTable dt = client.GetDataTable("Select ID, (Ime + ' ' + Prezime) As Naziv From UF_Ucenik Where ID <> '" + id_ucenik + "'");
                return dt;
            }

            public DataTable GetOsobaVeza2(int id_ucenik, int id_veza1)
            {
                DataTable dt = client.GetDataTable("Select ID, (Ime + ' ' + Prezime) As Naziv From UF_Ucenik Where ID NOT IN ('" + id_ucenik + "','" + id_veza1 + "')");
                return dt;
            }

            public DataTable GetOsobaVeza3(int id_ucenik, int id_veza1, int id_veza2)
            {
                DataTable dt = client.GetDataTable("Select ID, (Ime + ' ' + Prezime) As Naziv From UF_Ucenik Where ID NOT IN ('" + id_ucenik + "','" + id_veza1 + "', '" + id_veza2 + "')");
                return dt;
            }

            public DataTable GetOsobaVeza4(int id_ucenik, int id_veza1, int id_veza2, int id_veza3)
            {
                DataTable dt = client.GetDataTable("Select ID, (Ime + ' ' + Prezime) As Naziv From UF_Ucenik Where ID NOT IN ('" + id_ucenik + "','" + id_veza1 + "', '" + id_veza2 + "', '" + id_veza3 + "')");
                return dt;
            }

            public DataTable GetVrstaVeze1(int id_veze)
            {
                DataTable dt = new DataTable();
                if (id_veze == 1)
                {
                    dt = client.GetDataTable("Select ID, Naziv From UF_VrsteObiteljskihVeza Where ID NOT IN(1, 2, 3)");
                }
                else if (id_veze == 2)
                {
                    dt = client.GetDataTable("Select ID, Naziv From UF_VrsteObiteljskihVeza Where ID = 2");
                }
                else if (id_veze == 3)
                {
                    dt = client.GetDataTable("Select ID, Naziv From UF_VrsteObiteljskihVeza Where ID = 3");
                }
                else if (id_veze == 4)
                {
                    dt = client.GetDataTable("Select ID, Naziv From UF_VrsteObiteljskihVeza Where ID = 4");
                }
                else if (id_veze == 5)
                {
                    dt = client.GetDataTable("Select ID, Naziv From UF_VrsteObiteljskihVeza Where ID = 5");
                }
                return dt;
            }

            public DataRow GetIDVeze(int id_osobe)
            {
                DataRow dr = client.GetDataTable("Select ID_VrstaObiteljskeVeze From UF_Ucenik Where ID = '" + id_osobe + "'").Rows[0];
                return dr;
            }

            public string GetNazivOpcine(string id)
            {
                return client.ExecuteScalar("Select (IDOPCINE + ' | ' + NAZIVOPCINE) From OPCINA Where IDOPCINE = '" + id + "'") as string;
            }

            public DataTable GetNacinIsplate()
            {
                DataTable dt = client.GetDataTable("Select ID, KratkiOpis As Naziv From JOPPDOznakaNacinaIsplate");
                return dt;
            }

            public DataSet GetOsobeZaduzenje()
            {
                DataSet ds = new DataSet();

                DataTable dt1 = client.GetDataTable("Select ID, Naziv From UF_VrsteObiteljskihVeza Where ID In (1,2,4,8,9)");
                dt1.TableName = "VrsteOsoba";
                ds.Tables.Add(dt1);

                ds.Tables.Add(pOdabraneOsobe);

                DataRelation rel1 = new DataRelation(pOdabraneOsobe.TableName, dt1.Columns["ID"], pOdabraneOsobe.Columns["ID_VrstaVeze"]);
                ds.Relations.Add(rel1);

                return ds;
            }

            public DataSet GetStipendije()
            {
                DataSet ds = new DataSet();

                DataTable dtPrimary = client.GetDataTable("Select ID, Sifra, Naziv, Mjesec, Godina From JOPPDObracunRazno Where VrstaObracuna = '" + Enums.Vrstaobracuna.Stipendije + "'");

                DataTable dtRelated = client.GetDataTable("Select JOPPDObracunRaznoStavke.ID, ID_JOPPDObracunRazno, (JOPPDObracunRaznoStavke.Ime + ' '  + JOPPDObracunRaznoStavke.Prezime) As Osoba, " +
                                                          "JOPPDOznakaNacinaIsplate.KratkiOpis As Opis, Iznos From JOPPDObracunRaznoStavke " +
                                                           "Inner Join JOPPDOznakaNacinaIsplate On JOPPDObracunRaznoStavke.ID_JOPPDOznakaNacinaIsplate = JOPPDOznakaNacinaIsplate.ID " +
                                                           "Inner Join JOPPDObracunRazno On JOPPDObracunRaznoStavke.ID_JOPPDObracunRazno = JOPPDObracunRazno.ID " +
                                                           "Where JOPPDObracunRazno.VrstaObracuna = '" + Enums.Vrstaobracuna.Stipendije + "'");

                ds.Tables.Add(dtPrimary);
                ds.Tables.Add(dtRelated);

                DataRelation relation1 = new DataRelation("Stipendije", dtPrimary.Columns["ID"], dtRelated.Columns["ID_JOPPDObracunRazno"]);

                ds.Relations.Add(relation1);

                return ds;
            }

            public DataSet GetNagrade()
            {
                DataSet ds = new DataSet();

                DataTable dtPrimary = client.GetDataTable("Select ID, Sifra, Naziv, Mjesec, Godina From JOPPDObracunRazno Where VrstaObracuna = '" + Enums.Vrstaobracuna.NagradePraksa + "'");

                DataTable dtRelated = client.GetDataTable("Select JOPPDObracunRaznoStavke.ID, ID_JOPPDObracunRazno, (JOPPDObracunRaznoStavke.Ime + ' '  + JOPPDObracunRaznoStavke.Prezime) As Osoba, " +
                                                          "JOPPDOznakaNacinaIsplate.KratkiOpis As Opis, Iznos From JOPPDObracunRaznoStavke " +
                                                           "Inner Join JOPPDOznakaNacinaIsplate On JOPPDObracunRaznoStavke.ID_JOPPDOznakaNacinaIsplate = JOPPDOznakaNacinaIsplate.ID " +
                                                           "Inner Join JOPPDObracunRazno On JOPPDObracunRaznoStavke.ID_JOPPDObracunRazno = JOPPDObracunRazno.ID " +
                                                           "Where JOPPDObracunRazno.VrstaObracuna = '" + Enums.Vrstaobracuna.NagradePraksa + "'");

                ds.Tables.Add(dtPrimary);
                ds.Tables.Add(dtRelated);

                DataRelation relation1 = new DataRelation("Nagrade", dtPrimary.Columns["ID"], dtRelated.Columns["ID_JOPPDObracunRazno"]);

                ds.Relations.Add(relation1);

                return ds;
            }

            public DataSet GetNagradeNatjecanja()
            {
                DataSet ds = new DataSet();

                DataTable dtPrimary = client.GetDataTable("Select ID, Sifra, Naziv, Mjesec, Godina From JOPPDObracunRazno Where VrstaObracuna = '" + Enums.Vrstaobracuna.NagradeNatjecanja + "'");

                DataTable dtRelated = client.GetDataTable("Select JOPPDObracunRaznoStavke.ID, ID_JOPPDObracunRazno, (JOPPDObracunRaznoStavke.Ime + ' '  + JOPPDObracunRaznoStavke.Prezime) As Osoba, " +
                                                          "JOPPDOznakaNacinaIsplate.KratkiOpis As Opis, Iznos From JOPPDObracunRaznoStavke " +
                                                           "Inner Join JOPPDOznakaNacinaIsplate On JOPPDObracunRaznoStavke.ID_JOPPDOznakaNacinaIsplate = JOPPDOznakaNacinaIsplate.ID " +
                                                           "Inner Join JOPPDObracunRazno On JOPPDObracunRaznoStavke.ID_JOPPDObracunRazno = JOPPDObracunRazno.ID " +
                                                           "Where JOPPDObracunRazno.VrstaObracuna = '" + Enums.Vrstaobracuna.NagradeNatjecanja + "'");

                ds.Tables.Add(dtPrimary);
                ds.Tables.Add(dtRelated);

                DataRelation relation1 = new DataRelation("NagradeNatjecanja", dtPrimary.Columns["ID"], dtRelated.Columns["ID_JOPPDObracunRazno"]);

                ds.Relations.Add(relation1);

                return ds;
            }

            public DataSet GetStudentServisNeoporezivo()
            {
                DataSet ds = new DataSet();

                DataTable dtPrimary = client.GetDataTable("Select ID, Sifra, Naziv, Mjesec, Godina From JOPPDObracunRazno Where VrstaObracuna = '" + Enums.Vrstaobracuna.StudentServisNeoporezivo + "'");

                DataTable dtRelated = client.GetDataTable("Select JOPPDObracunRaznoStavke.ID, ID_JOPPDObracunRazno, (JOPPDObracunRaznoStavke.Ime + ' '  + JOPPDObracunRaznoStavke.Prezime) As Osoba, " +
                                                          "JOPPDOznakaNacinaIsplate.KratkiOpis As Opis, Iznos From JOPPDObracunRaznoStavke " +
                                                           "Inner Join JOPPDOznakaNacinaIsplate On JOPPDObracunRaznoStavke.ID_JOPPDOznakaNacinaIsplate = JOPPDOznakaNacinaIsplate.ID " +
                                                           "Inner Join JOPPDObracunRazno On JOPPDObracunRaznoStavke.ID_JOPPDObracunRazno = JOPPDObracunRazno.ID " +
                                                           "Where JOPPDObracunRazno.VrstaObracuna = '" + Enums.Vrstaobracuna.StudentServisNeoporezivo + "'");

                ds.Tables.Add(dtPrimary);
                ds.Tables.Add(dtRelated);

                DataRelation relation1 = new DataRelation("StudentServisNeoporezivo", dtPrimary.Columns["ID"], dtRelated.Columns["ID_JOPPDObracunRazno"]);

                ds.Relations.Add(relation1);

                return ds;
            }

            public DataSet GetStudentServisOporezivo()
            {
                DataSet ds = new DataSet();

                DataTable dtPrimary = client.GetDataTable("Select ID, Sifra, Naziv, Mjesec, Godina From JOPPDObracunRazno Where VrstaObracuna = '" + Enums.Vrstaobracuna.StudentServisOporezivo + "'");

                DataTable dtRelated = client.GetDataTable("Select JOPPDObracunRaznoStavke.ID, ID_JOPPDObracunRazno, (JOPPDObracunRaznoStavke.Ime + ' '  + JOPPDObracunRaznoStavke.Prezime) As Osoba, " +
                                                          "JOPPDOznakaNacinaIsplate.KratkiOpis As Opis, Iznos From JOPPDObracunRaznoStavke " +
                                                           "Inner Join JOPPDOznakaNacinaIsplate On JOPPDObracunRaznoStavke.ID_JOPPDOznakaNacinaIsplate = JOPPDOznakaNacinaIsplate.ID " +
                                                           "Inner Join JOPPDObracunRazno On JOPPDObracunRaznoStavke.ID_JOPPDObracunRazno = JOPPDObracunRazno.ID " +
                                                           "Where JOPPDObracunRazno.VrstaObracuna = '" + Enums.Vrstaobracuna.StudentServisOporezivo + "'");

                ds.Tables.Add(dtPrimary);
                ds.Tables.Add(dtRelated);

                DataRelation relation1 = new DataRelation("StudentServisOporezivo", dtPrimary.Columns["ID"], dtRelated.Columns["ID_JOPPDObracunRazno"]);

                ds.Relations.Add(relation1);

                return ds;
            }

            public DataSet GetSocijalnaPotpora()
            {
                DataSet ds = new DataSet();

                DataTable dtPrimary = client.GetDataTable("Select ID, Sifra, Naziv, Mjesec, Godina From JOPPDObracunRazno Where VrstaObracuna = '" + Enums.Vrstaobracuna.PrijevozNezaposleni + "'");

                DataTable dtRelated = client.GetDataTable("Select JOPPDObracunRaznoStavke.ID, ID_JOPPDObracunRazno, (JOPPDObracunRaznoStavke.Ime + ' '  + JOPPDObracunRaznoStavke.Prezime) As Osoba, " +
                                                          "JOPPDOznakaNacinaIsplate.KratkiOpis As Opis, Iznos From JOPPDObracunRaznoStavke " +
                                                           "Inner Join JOPPDOznakaNacinaIsplate On JOPPDObracunRaznoStavke.ID_JOPPDOznakaNacinaIsplate = JOPPDOznakaNacinaIsplate.ID " +
                                                           "Inner Join JOPPDObracunRazno On JOPPDObracunRaznoStavke.ID_JOPPDObracunRazno = JOPPDObracunRazno.ID " +
                                                           "Where JOPPDObracunRazno.VrstaObracuna = '" + Enums.Vrstaobracuna.PrijevozNezaposleni + "'");

                ds.Tables.Add(dtPrimary);
                ds.Tables.Add(dtRelated);

                DataRelation relation1 = new DataRelation("SocijalnaPotpora", dtPrimary.Columns["ID"], dtRelated.Columns["ID_JOPPDObracunRazno"]);

                ds.Relations.Add(relation1);

                return ds;
            }

            public DataSet GetSocijalnaNaknada()
            {
                DataSet ds = new DataSet();

                DataTable dtPrimary = client.GetDataTable("Select ID, Sifra, Naziv, Mjesec, Godina From JOPPDObracunRazno Where VrstaObracuna = '" + Enums.Vrstaobracuna.SocijalnaNaknada + "'");

                DataTable dtRelated = client.GetDataTable("Select JOPPDObracunRaznoStavke.ID, ID_JOPPDObracunRazno, (JOPPDObracunRaznoStavke.Ime + ' '  + JOPPDObracunRaznoStavke.Prezime) As Osoba, " +
                                                          "JOPPDOznakaNacinaIsplate.KratkiOpis As Opis, Iznos From JOPPDObracunRaznoStavke " +
                                                           "Inner Join JOPPDOznakaNacinaIsplate On JOPPDObracunRaznoStavke.ID_JOPPDOznakaNacinaIsplate = JOPPDOznakaNacinaIsplate.ID " +
                                                           "Inner Join JOPPDObracunRazno On JOPPDObracunRaznoStavke.ID_JOPPDObracunRazno = JOPPDObracunRazno.ID " +
                                                           "Where JOPPDObracunRazno.VrstaObracuna = '" + Enums.Vrstaobracuna.SocijalnaNaknada + "'");

                ds.Tables.Add(dtPrimary);
                ds.Tables.Add(dtRelated);

                DataRelation relation1 = new DataRelation("SocijalnaNaknada", dtPrimary.Columns["ID"], dtRelated.Columns["ID_JOPPDObracunRazno"]);

                ds.Relations.Add(relation1);

                return ds;
            }

            public int GetLastSifraObracuna()
            {
                try
                {
                    return (Convert.ToInt32(client.ExecuteScalar("Select Max(Sifra) From JOPPDObracunRazno")) + 1);
                }
                catch 
                {
                    return 1;
                }
            }

            public DataTable GetUceniciUF()
            {
                DataTable dt = client.GetDataTable("Select 'false' As Ozn, ID, ID_Opcina, Ime, Prezime, OIB, UlicaKucniBroj As Adresa, Naselje As Grad, 'UF' As Tip " + 
                                                   "From UF_Ucenik Where ID_VrstaObiteljskeVeze = '" + (int)Enums.VrsteOsoba.Ucenik + "'");
                return dt;
            }

            public DataTable GetUceniciPraksa()
            {
                DataTable dt = client.GetDataTable("Select 'false' As Ozn, IDUCENIK As ID, ID_Opcina, IMEUCENIK As Ime, PREZIMEUCENIK As Prezime, OIBUCENIK As OIB, " + 
                                                   "ULICAIBROJ As Adresa, NASELJE As Grad, 'PR' As Tip From UCENIK");
                return dt;
            }

            public DataTable GetUceniciAll()
            {
                DataTable dt = client.GetDataTable("Select 'false' As Ozn, ID, ID_Opcina, Ime, Prezime, OIB, UlicaKucniBroj As Adresa, Naselje As Grad, 'UF' As Tip " +
                                                   "From UF_Ucenik Where ID_VrstaObiteljskeVeze = '" + (int)Enums.VrsteOsoba.Ucenik + "' Union " + 
                                                   "Select 'false' As Ozn, IDUCENIK As ID, ID_Opcina, IMEUCENIK As Ime, PREZIMEUCENIK As Prezime, OIBUCENIK As OIB, " + 
                                                   "ULICAIBROJ As Adresa, NASELJE As Grad, 'PR' As Tip From UCENIK");
                return dt;
            }

            public DataTable GetRoditelji()
            {
                DataTable dt = client.GetDataTable("Select 'false' As Ozn, ID, ID_Opcina, Ime, Prezime, OIB, UlicaKucniBroj As Adresa, Naselje As Grad, 'UF' As Tip " +
                                      "From UF_Ucenik Where ID_VrstaObiteljskeVeze In (" + (int)Enums.VrsteOsoba.Roditelj + ") Union Select 'false' As Ozn, ID, " +
                                      "ID_Opcina, ImeRoditelj As Ime, PrezimeRoditelj As Prezime, OIBRoditelj As OIB, UlicaKucniBroj As Adresa, Naselje As Grad, 'UF' As Tip From UF_Ucenik " + 
                                      "Where ID_VrstaObiteljskeVeze = 1 And OIBRoditelj Not In (Select OIB From UF_Ucenik) Union " + 
                                      "Select 'false' As Ozn, IDUCENIK As ID, ID_Opcina, IMERODITELJA As Ime, PrezimeRoditelj As Prezime, OIBRoditelj As OIB, ULICAIBROJ As Adresa, NASELJE As Grad, 'PR' As Tip " + 
                                      "From UCENIK Where OIBRoditelj Not In (Select OIB From UF_Ucenik) And OIBRoditelj Not In (Select OIBRoditelj From UF_Ucenik)");
                return dt;
            }

            public DataTable GetOstalo()
            {
                DataTable dt = client.GetDataTable("Select 'false' As Ozn, ID, ID_Opcina, Ime, Prezime, OIB, UlicaKucniBroj As Adresa, Naselje As Grad From UF_Ucenik Where ID_VrstaObiteljskeVeze = '" + (int)Enums.VrsteOsoba.Ostalo + "'");
                return dt;
            }

            public bool ObracunByID()
            {
                DataTable dt1 = client.GetDataTable("Select Naziv, Mjesec, Godina From JOPPDObracunRazno Where ID = '" + pID_ObracunRazno + "'");

                DataRow red = dt1.Rows[0];

                try
                {
                    pNaziv = red["Naziv"].ToString();
                    pMjesec = Convert.ToByte(red["Mjesec"]);
                    pGodina = Convert.ToInt16(red["Godina"]);
                }
                catch
                {
                    return false;
                }

                DataTable dt2 = client.GetDataTable("Select ID_UF_Ucenik As ID_Osobe, ID_VrstaVeze, ID_Opcina, ID_JOPPDOznakaNacinaIsplate As ID_NacinIsplate, Ime, Prezime, OIB, Iznos " + 
                                                    "From JOPPDObracunRaznoStavke  Where ID_JOPPDObracunRazno = '" + pID_ObracunRazno + "'");

                dt2.TableName = "OdabraneOsobe";


                pOdabraneOsobe = dt2;

                pUcenik = false;
                pRoditelj = false;
                pOstalo = false;
                pUF = false;
                pPraksa = false;

                foreach (DataRow red2 in pOdabraneOsobe.Rows)
                {
                    if (red2["ID_VrstaVeze"].ToString() == "1" || red2["ID_VrstaVeze"].ToString() == "8")
                    {
                        pUcenik = true;
                    }
                    if (red2["ID_VrstaVeze"].ToString() == "2" || red2["ID_VrstaVeze"].ToString() == "9")
                    {
                        pRoditelj = true;
                    }
                    if (red2["ID_VrstaVeze"].ToString() == "4")
                    {
                        pOstalo = true;
                    }
                    if (red2["ID_VrstaVeze"].ToString() == "1")
                    {
                        pUF = true;
                    }
                    if (red2["ID_VrstaVeze"].ToString() == "8")
                    {
                        pPraksa = true;
                    }
                }

                return true;
            }

            #endregion

            #region WorkWithData

            public bool Insert(StringBuilder message)
            {
                SqlCommand sqlUpit = new SqlCommand();
                sqlUpit.Connection = client.sqlConnection;
                sqlUpit.CommandType = CommandType.Text;

                SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("ObracunRazno");
                sqlUpit.Transaction = transakcija;

                sqlUpit.CommandText = "Insert Into JOPPDObracunRazno (Sifra, Naziv, VrstaObracuna, Mjesec, Godina, TS) " +
                                      "Values (@Sifra, @Naziv, @VrstaObracuna, @Mjesec, @Godina, @TS) Select @@Identity";

                sqlUpit.Parameters.Add(new SqlParameter("@Sifra", pSifra));
                sqlUpit.Parameters.Add(new SqlParameter("@Naziv", pNaziv));
                sqlUpit.Parameters.Add(new SqlParameter("@VrstaObracuna", pVrstaObracuna));
                sqlUpit.Parameters.Add(new SqlParameter("@Mjesec", pMjesec));
                sqlUpit.Parameters.Add(new SqlParameter("@Godina", pGodina));
                sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

                try
                {
                    pID_ObracunRazno = Convert.ToInt32(sqlUpit.ExecuteScalar());
                }
                catch (Exception greska)
                {
                    message.Append(greska.Message);
                    transakcija.Rollback();
                    return false;
                }

                try
                {
                    foreach (DataRow red in pOdabraneOsobe.Rows)
                    {
                        pID_NacinIsplate = (int)red["ID_NacinIsplate"];
                        pID_UF_Ucenik = (int)red["ID_Osobe"];
                        pIznos = (decimal)red["Iznos"];
                        pID_Veza = (int)red["ID_VrstaVeze"];

                        sqlUpit.CommandText = "Insert Into JOPPDObracunRaznoStavke (ID_JOPPDObracunRazno, ID_JOPPDOznakaNacinaIsplate, ID_UF_Ucenik, Iznos, ID_VrstaVeze, Ime, Prezime, OIB, ID_Opcina) " +
                                              "Values ('" + pID_ObracunRazno + "', '" + pID_NacinIsplate + "', '" + pID_UF_Ucenik + "', '" + pIznos.ToString().Replace(',', '.') +
                                              "', " + pID_Veza + ", '" + red["Ime"].ToString() + "', '" + red["Prezime"].ToString() + "', '" + red["OIB"].ToString() + "', '" + red["ID_Opcina"].ToString() + "')";

                        sqlUpit.ExecuteNonQuery();
                    }
                }
                catch (Exception greska)
                {
                    message.Append(greska.Message);
                    transakcija.Rollback();
                    return false;
                }

                transakcija.Commit();
                return true;
            }

            public bool Update(StringBuilder message)
            {
                SqlCommand sqlUpit = new SqlCommand();
                sqlUpit.Connection = client.sqlConnection;
                sqlUpit.CommandType = CommandType.Text;

                SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("ObracunRazno");
                sqlUpit.Transaction = transakcija;

                sqlUpit.CommandText = "Update JOPPDObracunRazno Set Naziv = @Naziv, Mjesec = @Mjesec, Godina = @Godina, TS = @TS Where ID = @ID";

                sqlUpit.Parameters.Add(new SqlParameter("@Naziv", pNaziv));
                sqlUpit.Parameters.Add(new SqlParameter("@Mjesec", pMjesec));
                sqlUpit.Parameters.Add(new SqlParameter("@Godina", pGodina));
                sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));
                sqlUpit.Parameters.Add(new SqlParameter("@ID", pID_ObracunRazno));

                try
                {
                    sqlUpit.ExecuteNonQuery();
                }
                catch (Exception greska)
                {
                    message.Append(greska.Message);
                    transakcija.Rollback();
                    return false;
                }

                sqlUpit.CommandText = "Delete From JOPPDObracunRaznoStavke Where ID_JOPPDObracunRazno = @ID";

                try
                {
                    sqlUpit.ExecuteNonQuery();
                }
                catch (Exception greska)
                {
                    message.Append(greska.Message);
                    transakcija.Rollback();
                    return false;
                }

                try
                {
                    foreach (DataRow red in pOdabraneOsobe.Rows)
                    {
                        pID_NacinIsplate = (int)red["ID_NacinIsplate"];
                        pID_UF_Ucenik = (int)red["ID_Osobe"];
                        pIznos = (decimal)red["Iznos"];
                        pID_Veza = (int)red["ID_VrstaVeze"];

                        sqlUpit.CommandText = "Insert Into JOPPDObracunRaznoStavke (ID_JOPPDObracunRazno, ID_JOPPDOznakaNacinaIsplate, ID_UF_Ucenik, Iznos, ID_VrstaVeze, Ime, Prezime, OIB, ID_Opcina) " +
                                              "Values ('" + pID_ObracunRazno + "', '" + pID_NacinIsplate + "', '" + pID_UF_Ucenik + "', '" + pIznos.ToString().Replace(',', '.') +
                                              "', " + pID_Veza + ", '" + red["Ime"].ToString() + "', '" + red["Prezime"].ToString() + "', '" + red["OIB"].ToString() + "', '" + red["ID_Opcina"].ToString() + "')";

                        sqlUpit.ExecuteNonQuery();
                    }
                }
                catch (Exception greska)
                {
                    message.Append(greska.Message);
                    transakcija.Rollback();
                    return false;
                }

                transakcija.Commit();
                return true;
            }

            public bool Delete(StringBuilder message)
            {
                SqlCommand sqlUpit = new SqlCommand();
                sqlUpit.Connection = client.sqlConnection;
                sqlUpit.CommandType = CommandType.Text;

                SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("ObracunRazno");
                sqlUpit.Transaction = transakcija;

                sqlUpit.CommandText = "Delete From JOPPDObracunRaznoStavke Where ID_JOPPDObracunRazno = @ID_JOPPDObracunRazno";

                sqlUpit.Parameters.Add(new SqlParameter("@ID_JOPPDObracunRazno", pID_ObracunRazno));

                try
                {
                    sqlUpit.ExecuteNonQuery();
                }
                catch (Exception greska)
                {
                    message.Append(greska.Message);
                    transakcija.Rollback();
                    return false;
                }

                sqlUpit.CommandText = "Delete From JOPPDObracunRazno Where ID = @ID_JOPPDObracunRazno";

                try
                {
                    sqlUpit.ExecuteNonQuery();
                }
                catch (Exception greska)
                {
                    message.Append(greska.Message);
                    transakcija.Rollback();
                    return false;
                }

                transakcija.Commit();
                return true;
            }

            #endregion
        }

        #endregion

        #region Uvoz iz COPa

        public class COP : IDisposable
        {
            #region Constructor

            SqlClient client = null;
            public COP()
                : base()
            {
                client = new SqlClient();
            }

            public void Dispose()
            {
            }

            #endregion

            #region Properties

            public string pSifraObracuna { get; set; }
            public DateTime pDatumObracuna { get; set; }

            #endregion

            #region WorkWithData

            public void NapuniObracun(DataTable tblStranaA)
            {
                SqlCommand sqlUpit = new SqlCommand();
                sqlUpit.Connection = client.sqlConnection;
                sqlUpit.CommandType = CommandType.Text;

                string broj_obracuna = VratiSljedeciBrojObracuna(tblStranaA.Rows[0]["DatumIzvjesca"].ToString().Substring(0, 8));

                if (broj_obracuna.Length == 0)
                {
                    broj_obracuna = "001";
                }
                else if (broj_obracuna.Length == 1)
                {
                    broj_obracuna = "00" + broj_obracuna;
                }
                else if (broj_obracuna.Length == 2)
                {
                    broj_obracuna = "0" + broj_obracuna;
                }

                pSifraObracuna = tblStranaA.Rows[0]["DatumIzvjesca"].ToString().Substring(0, 8) + broj_obracuna;

                SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Obracun");
                sqlUpit.Transaction = transakcija;

                sqlUpit.CommandText = "Insert Into Obracun ([IDOBRACUN], [VRSTAOBRACUNA], [MJESECOBRACUNA], [GODINAOBRACUNA], [MJESECISPLATE], [GODINAISPLATE], [DATUMISPLATE], " +
                                      "[tjednifondsatiobracun], [MJESECNIFONDSATIOBRACUN], [OSNOVNIOO], [OBRACUNSKAOSNOVICA], [DATUMOBRACUNASTAZA], [OBRPOSTOTNIH], [OBRFIKSNIH], " +
                                      "[OBRKREDITNIH], [ZAKLJ], [SVRHAOBRACUNA], [IDENTIFIKATOROBRASCA]) " +
                                      "Values (@IDOBRACUN, @VRSTAOBRACUNA, @MJESECOBRACUNA, @GODINAOBRACUNA, @MJESECISPLATE, @GODINAISPLATE, @DATUMISPLATE, @tjednifondsatiobracun, " +
                                      "@MJESECNIFONDSATIOBRACUN, @OSNOVNIOO, @OBRACUNSKAOSNOVICA, @DATUMOBRACUNASTAZA, @OBRPOSTOTNIH, @OBRFIKSNIH, @OBRKREDITNIH, @ZAKLJ, @SVRHAOBRACUNA, @IDENTIFIKATOROBRASCA)";

                string mjesec_obracuna = (Convert.ToInt32(pSifraObracuna.Substring(5, 2)) - 1).ToString();
                if(mjesec_obracuna.Length == 1)
                {
                    //kod prvog mjeseca je vracao nula sto nije dobro
                    if (mjesec_obracuna == "0")
                    {
                        mjesec_obracuna = "01";
                    }
                    else
                    {
                        mjesec_obracuna = "0" + mjesec_obracuna;
                    }
                }

                pDatumObracuna = Convert.ToDateTime(tblStranaA.Rows[0]["DatumIzvjesca"].ToString());

                sqlUpit.Parameters.Add(new SqlParameter("@IDOBRACUN", pSifraObracuna));
                sqlUpit.Parameters.Add(new SqlParameter("@VRSTAOBRACUNA", "PL"));
                sqlUpit.Parameters.Add(new SqlParameter("@MJESECOBRACUNA", mjesec_obracuna));
                sqlUpit.Parameters.Add(new SqlParameter("@GODINAOBRACUNA", pSifraObracuna.Substring(0, 4)));
                sqlUpit.Parameters.Add(new SqlParameter("@MJESECISPLATE", pSifraObracuna.Substring(5, 2)));
                sqlUpit.Parameters.Add(new SqlParameter("@GODINAISPLATE", pSifraObracuna.Substring(0, 4)));
                sqlUpit.Parameters.Add(new SqlParameter("@DATUMISPLATE", Convert.ToDateTime(tblStranaA.Rows[0]["DatumIzvjesca"])));
                sqlUpit.Parameters.Add(new SqlParameter("@tjednifondsatiobracun", 99));
                sqlUpit.Parameters.Add(new SqlParameter("@MJESECNIFONDSATIOBRACUN", 99));
                sqlUpit.Parameters.Add(new SqlParameter("@OSNOVNIOO", 2200));
                sqlUpit.Parameters.Add(new SqlParameter("@OBRACUNSKAOSNOVICA", 5108.84M));
                //oduzimao se mjesec za jedan pa je javljalo error  kod prvog mjeseca, prepravljeno
                if (Convert.ToInt32(pSifraObracuna.Substring(5, 2)) - 1 == 0)
                {
                    sqlUpit.Parameters.Add(new SqlParameter("@DATUMOBRACUNASTAZA", new DateTime(Convert.ToInt32(pSifraObracuna.Substring(0, 4)), Convert.ToInt32(pSifraObracuna.Substring(5, 2)), 1)));
                }
                else
                {
                    sqlUpit.Parameters.Add(new SqlParameter("@DATUMOBRACUNASTAZA", new DateTime(Convert.ToInt32(pSifraObracuna.Substring(0, 4)), Convert.ToInt32(pSifraObracuna.Substring(5, 2)) - 1, 1)));
                }
                sqlUpit.Parameters.Add(new SqlParameter("@OBRPOSTOTNIH", false));
                sqlUpit.Parameters.Add(new SqlParameter("@OBRFIKSNIH", false));
                sqlUpit.Parameters.Add(new SqlParameter("@OBRKREDITNIH", false));
                sqlUpit.Parameters.Add(new SqlParameter("@ZAKLJ", true));
                sqlUpit.Parameters.Add(new SqlParameter("@SVRHAOBRACUNA", "Prijenos iz COP-a"));
                sqlUpit.Parameters.Add(new SqlParameter("@IDENTIFIKATOROBRASCA", "COP"));

                try
                {
                    sqlUpit.ExecuteNonQuery();
                }
                catch (Exception greska)
                {
                    MessageBox.Show(greska.Message);
                    transakcija.Rollback();
                    return;
                }
                transakcija.Commit();
            }

            public bool ProvjeraDaliPostojiObracunIzCOPa(DataTable tblStranaA)
            {
                DateTime date = Convert.ToDateTime(tblStranaA.Rows[0]["DatumIzvjesca"].ToString());

                int exist = Convert.ToInt32(client.ExecuteScalar("Select Count(IDOBRACUN) From Obracun Where DATUMISPLATE = '" + date.ToString("yyyy-MM-dd") + "' And IDENTIFIKATOROBRASCA = 'COP'"));

                if (exist > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            public bool NapuniObracunRadnici(DataTable tblRadnici)
            {
                SqlCommand sqlUpit = new SqlCommand();
                sqlUpit.Connection = client.sqlConnection;
                sqlUpit.CommandType = CommandType.Text;

                sqlUpit.CommandText = "Insert Into ObracunRadnici ([IDOBRACUN], [IDRADNIK], [SIFRAOPCINESTANOVANJA], [OBRACUNSKIKOEFICIJENT], [ISKORISTENOOO], [OBRACUNATIPRIREZ], " +
                                      "[faktoo], [KOEFICIJENT], [IDIPIDENT], [RADNIKOBRACUNOSNOVICA], [KOREKCIJAPRIREZA], [ODBITAKPRIJEKOREKCIJE], [OBRACUNAVAJOBUSTAVE]) " +
                                      "Values (@IDOBRACUN, @IDRADNIK, @SIFRAOPCINESTANOVANJA, @OBRACUNSKIKOEFICIJENT, @ISKORISTENOOO, @OBRACUNATIPRIREZ, @faktoo, " +
                                      "@KOEFICIJENT, @IDIPIDENT, @RADNIKOBRACUNOSNOVICA, @KOREKCIJAPRIREZA, @ODBITAKPRIJEKOREKCIJE, @OBRACUNAVAJOBUSTAVE)";

                sqlUpit.Parameters.Add(new SqlParameter("@IDOBRACUN", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@IDRADNIK", SqlDbType.Int));
                sqlUpit.Parameters.Add(new SqlParameter("@SIFRAOPCINESTANOVANJA", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@OBRACUNSKIKOEFICIJENT", SqlDbType.Decimal));
                sqlUpit.Parameters.Add(new SqlParameter("@ISKORISTENOOO", SqlDbType.Money));
                sqlUpit.Parameters.Add(new SqlParameter("@OBRACUNATIPRIREZ", SqlDbType.Money));
                sqlUpit.Parameters.Add(new SqlParameter("@faktoo", SqlDbType.SmallMoney));
                sqlUpit.Parameters.Add(new SqlParameter("@KOEFICIJENT", SqlDbType.Decimal));
                sqlUpit.Parameters.Add(new SqlParameter("@IDIPIDENT", SqlDbType.Int));
                sqlUpit.Parameters.Add(new SqlParameter("@RADNIKOBRACUNOSNOVICA", SqlDbType.Money));
                sqlUpit.Parameters.Add(new SqlParameter("@KOREKCIJAPRIREZA", SqlDbType.Money));
                sqlUpit.Parameters.Add(new SqlParameter("@ODBITAKPRIJEKOREKCIJE", SqlDbType.Money));
                sqlUpit.Parameters.Add(new SqlParameter("@OBRACUNAVAJOBUSTAVE", SqlDbType.Bit));

                int id_radnik = 0;

                foreach (DataRow red in tblRadnici.Rows)
                {
                    sqlUpit.CommandText = "Insert Into ObracunRadnici ([IDOBRACUN], [IDRADNIK], [SIFRAOPCINESTANOVANJA], [OBRACUNSKIKOEFICIJENT], [ISKORISTENOOO], [OBRACUNATIPRIREZ], " +
                                     "[faktoo], [KOEFICIJENT], [IDIPIDENT], [RADNIKOBRACUNOSNOVICA], [KOREKCIJAPRIREZA], [ODBITAKPRIJEKOREKCIJE], [OBRACUNAVAJOBUSTAVE]) " +
                                     "Values (@IDOBRACUN, @IDRADNIK, @SIFRAOPCINESTANOVANJA, @OBRACUNSKIKOEFICIJENT, @ISKORISTENOOO, @OBRACUNATIPRIREZ, @faktoo, " +
                                     "@KOEFICIJENT, @IDIPIDENT, @RADNIKOBRACUNOSNOVICA, @KOREKCIJAPRIREZA, @ODBITAKPRIJEKOREKCIJE, @OBRACUNAVAJOBUSTAVE)";



                    sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                    id_radnik = VratiIDRadnika(red["P4"].ToString());
                    if (id_radnik > 0)
                    {
                        sqlUpit.Parameters["@IDRADNIK"].Value = id_radnik;
                    }
                    else
                    {
                        MessageBox.Show("Ne postoji radnik sa OIB-om " + red["P4"].ToString() + " u MIPSEDU. Molimo unesite Radnika kako bi mogli prenjeti njegove podatke.");
                        return false;
                    }
                    sqlUpit.Parameters["@SIFRAOPCINESTANOVANJA"].Value = red["P2"].ToString().Substring(1,4);
                    sqlUpit.Parameters["@OBRACUNSKIKOEFICIJENT"].Value = 1;
                    sqlUpit.Parameters["@ISKORISTENOOO"].Value = Convert.ToDecimal(red["P134"].ToString().Replace('.',','));
                    sqlUpit.Parameters["@faktoo"].Value = 1;
                    sqlUpit.Parameters["@KOEFICIJENT"].Value = 1;
                    sqlUpit.Parameters["@IDIPIDENT"].Value = GetIDIpIdent(id_radnik);
                    sqlUpit.Parameters["@RADNIKOBRACUNOSNOVICA"].Value = Convert.ToDecimal(red["P12"].ToString().Replace('.', ','));
                    sqlUpit.Parameters["@KOREKCIJAPRIREZA"].Value = 0;
                    sqlUpit.Parameters["@ODBITAKPRIJEKOREKCIJE"].Value = 0;
                    sqlUpit.Parameters["@OBRACUNAVAJOBUSTAVE"].Value = 0;

                    if (red["P151"].ToString() == "19" && red["P61"].ToString() == "0000" && red["P62"].ToString() == "0000")
                    {
                        sqlUpit.Parameters["@OBRACUNATIPRIREZ"].Value = 0;                        
                    }
                    else if (red["P62"].ToString() != "0406")
                    {
                        sqlUpit.Parameters["@OBRACUNATIPRIREZ"].Value = Convert.ToDecimal(red["P142"].ToString().Replace('.', ','));
                    }

                    if (red["P62"].ToString() == "0406")
                    {
                        sqlUpit.Parameters["@KOREKCIJAPRIREZA"].Value = Convert.ToDecimal(red["P142"].ToString().Replace('.', ','));
                        sqlUpit.Parameters["@OBRACUNATIPRIREZ"].Value = 0;
                    }
                    else
                    {
                        sqlUpit.Parameters["@KOREKCIJAPRIREZA"].Value = 0;
                    }

                    try
                    {
                        sqlUpit.ExecuteNonQuery();
                    }
                    catch (Exception greska)
                    {
                        if (greska.Message.Contains("Violation of PRIMARY KEY"))
                        {
                            try
                            {
                                sqlUpit.CommandText = "Update ObracunRadnici Set ISKORISTENOOO = ISKORISTENOOO + @ISKORISTENOOO, OBRACUNATIPRIREZ = OBRACUNATIPRIREZ + @OBRACUNATIPRIREZ, " +
                                                      "RADNIKOBRACUNOSNOVICA = RADNIKOBRACUNOSNOVICA + @RADNIKOBRACUNOSNOVICA, KOREKCIJAPRIREZA = KOREKCIJAPRIREZA + @KOREKCIJAPRIREZA " +
                                                      "Where IDRADNIK = @IDRADNIK AND IDOBRACUN = @IDOBRACUN";

                                sqlUpit.ExecuteNonQuery();
                            }
                            catch
                            {
                                MessageBox.Show(greska.Message);
                                return false;
                            }
                        }
                        else
                        {

                            MessageBox.Show(greska.Message);
                            return false;
                        }
                    }
                }
                return true;
            }

            public void NapuniObracunDoprinosi(DataTable tblRadnici)
            {
                SqlCommand sqlUpit = new SqlCommand();
                sqlUpit.Connection = client.sqlConnection;
                sqlUpit.CommandType = CommandType.Text;

                sqlUpit.CommandText = "Insert Into ObracunDoprinosi ([IDOBRACUN], [IDRADNIK], [IDDOPRINOS], [OBRACUNATIDOPRINOS], [OSNOVICADOPRINOS], [VBDIDOPRINOS], [ZRNDOPRINOS], " + 
                                      "[NAZIVDOPRINOS], [IDVRSTADOPRINOS], [NAZIVVRSTADOPRINOS], [STOPA], [MODOPRINOS], [PODOPRINOS], [MZDOPRINOS], [PZDOPRINOS], [PRIMATELJDOPRINOS1], " + 
                                      "[PRIMATELJDOPRINOS2], [SIFRAOPISAPLACANJADOPRINOS], [OPISPLACANJADOPRINOS]) " +
                                      "Values (@IDOBRACUN, @IDRADNIK, @IDDOPRINOS, @OBRACUNATIDOPRINOS, @OSNOVICADOPRINOS, @VBDIDOPRINOS, @ZRNDOPRINOS, @NAZIVDOPRINOS, " +
                                      "@IDVRSTADOPRINOS, @NAZIVVRSTADOPRINOS, @STOPA, @MODOPRINOS, @PODOPRINOS, @MZDOPRINOS, @PZDOPRINOS, @PRIMATELJDOPRINOS1, " +
                                      "@PRIMATELJDOPRINOS2, @SIFRAOPISAPLACANJADOPRINOS, @OPISPLACANJADOPRINOS)";

                sqlUpit.Parameters.Add(new SqlParameter("@IDOBRACUN", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@IDRADNIK", SqlDbType.Int));
                sqlUpit.Parameters.Add(new SqlParameter("@IDDOPRINOS", SqlDbType.Int));
                sqlUpit.Parameters.Add(new SqlParameter("@OBRACUNATIDOPRINOS", SqlDbType.Money));
                sqlUpit.Parameters.Add(new SqlParameter("@OSNOVICADOPRINOS", SqlDbType.Money));
                sqlUpit.Parameters.Add(new SqlParameter("@VBDIDOPRINOS", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@ZRNDOPRINOS", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@NAZIVDOPRINOS", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@IDVRSTADOPRINOS", SqlDbType.Int));
                sqlUpit.Parameters.Add(new SqlParameter("@NAZIVVRSTADOPRINOS", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@STOPA", SqlDbType.SmallMoney));
                sqlUpit.Parameters.Add(new SqlParameter("@MODOPRINOS", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@PODOPRINOS", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@MZDOPRINOS", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@PZDOPRINOS", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@PRIMATELJDOPRINOS1", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@PRIMATELJDOPRINOS2", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@SIFRAOPISAPLACANJADOPRINOS", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@OPISPLACANJADOPRINOS", SqlDbType.NVarChar));

                int brojac = 6;
                int id_radnik = 0;

                foreach (DataRow red in tblRadnici.Rows)
                {
                    if (red["P61"].ToString() == "5201" || red["P61"].ToString() == "5203" || red["P61"].ToString() == "5204"
                        || red["P61"].ToString() == "5207" || red["P61"].ToString() == "5209" || red["P61"].ToString() == "5210"
                        || red["P61"].ToString() == "5211")
                    {
                        continue;
                    }
                    if (red["P151"].ToString() == "19" && red["P61"].ToString() == "0000" && red["P62"].ToString() == "0000")
                    {
                        continue;
                    }

                    for (int i = 0; i < brojac; i++)
                    {

                        sqlUpit.CommandText = "Insert Into ObracunDoprinosi ([IDOBRACUN], [IDRADNIK], [IDDOPRINOS], [OBRACUNATIDOPRINOS], [OSNOVICADOPRINOS], [VBDIDOPRINOS], [ZRNDOPRINOS], " +
                                      "[NAZIVDOPRINOS], [IDVRSTADOPRINOS], [NAZIVVRSTADOPRINOS], [STOPA], [MODOPRINOS], [PODOPRINOS], [MZDOPRINOS], [PZDOPRINOS], [PRIMATELJDOPRINOS1], " +
                                      "[PRIMATELJDOPRINOS2], [SIFRAOPISAPLACANJADOPRINOS], [OPISPLACANJADOPRINOS]) " +
                                      "Values (@IDOBRACUN, @IDRADNIK, @IDDOPRINOS, @OBRACUNATIDOPRINOS, @OSNOVICADOPRINOS, @VBDIDOPRINOS, @ZRNDOPRINOS, @NAZIVDOPRINOS, " +
                                      "@IDVRSTADOPRINOS, @NAZIVVRSTADOPRINOS, @STOPA, @MODOPRINOS, @PODOPRINOS, @MZDOPRINOS, @PZDOPRINOS, @PRIMATELJDOPRINOS1, " +
                                      "@PRIMATELJDOPRINOS2, @SIFRAOPISAPLACANJADOPRINOS, @OPISPLACANJADOPRINOS)";

                        sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                        id_radnik = VratiIDRadnika(red["P4"].ToString());

                        if (id_radnik > 0)
                        {
                            sqlUpit.Parameters["@IDRADNIK"].Value = id_radnik;
                        }
                        else
                        {
                            MessageBox.Show("Ne postoji radnik sa OIB-om " + red["P4"].ToString() + " u MIPSEDU. Molimo unesite Radnika da bi blilo moguće prenjeti njegove podatke.");
                            continue;
                        }

                        sqlUpit.Parameters["@IDDOPRINOS"].Value = VratiIDDoprinos(i);
                        sqlUpit.Parameters["@OBRACUNATIDOPRINOS"].Value = VratiObracunatiDoprinos(red, i);
                        sqlUpit.Parameters["@OSNOVICADOPRINOS"].Value = Convert.ToDecimal(red["P12"].ToString().Replace('.', ','));
                        sqlUpit.Parameters["@VBDIDOPRINOS"].Value = "1001005";
                        sqlUpit.Parameters["@ZRNDOPRINOS"].Value = VratiZrnDoprinos(i);
                        sqlUpit.Parameters["@NAZIVDOPRINOS"].Value = VratiNazivDoprinos(i);
                        if (VratiIDDoprinos(i) == 1 | VratiIDDoprinos(i) == 2)
                        {
                            sqlUpit.Parameters["@IDVRSTADOPRINOS"].Value = 2;
                        }
                        else
                        {
                            sqlUpit.Parameters["@IDVRSTADOPRINOS"].Value = 1;
                        }
                        sqlUpit.Parameters["@NAZIVVRSTADOPRINOS"].Value = "Doprinosi NA bruto";
                        sqlUpit.Parameters["@STOPA"].Value = VratiStopa(i);
                        sqlUpit.Parameters["@MODOPRINOS"].Value = VratiMODoprinos(i);
                        sqlUpit.Parameters["@PODOPRINOS"].Value = VratiPODoprinos(i);
                        sqlUpit.Parameters["@MZDOPRINOS"].Value = VratiMZDoprinos(i);
                        sqlUpit.Parameters["@PZDOPRINOS"].Value = VratiPZDoprinos(i);
                        sqlUpit.Parameters["@PRIMATELJDOPRINOS1"].Value = VratiPrimateljDoprinos1(i);
                        sqlUpit.Parameters["@PRIMATELJDOPRINOS2"].Value = VratiPrimateljDoprinos2(i);
                        sqlUpit.Parameters["@SIFRAOPISAPLACANJADOPRINOS"].Value = VratiSifraOpisaPlacanjaDoprinos(i);
                        sqlUpit.Parameters["@OPISPLACANJADOPRINOS"].Value = VratiOpisPlacanjaDoprinos(i);

                        try
                        {
                            sqlUpit.ExecuteNonQuery();
                        }
                        catch (Exception greska)
                        {
                            if (greska.Message.Contains("Violation of PRIMARY KEY"))
                            {
                                try
                                {
                                    sqlUpit.CommandText = "Update ObracunDoprinosi Set OBRACUNATIDOPRINOS = OBRACUNATIDOPRINOS + @OBRACUNATIDOPRINOS, OSNOVICADOPRINOS = OSNOVICADOPRINOS + @OSNOVICADOPRINOS " +
                                                          "Where IDRADNIK = @IDRADNIK And IDDOPRINOS = @IDDOPRINOS AND IDOBRACUN = @IDOBRACUN";

                                    sqlUpit.ExecuteNonQuery();
                                }
                                catch
                                {
                                    MessageBox.Show(greska.Message);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show(greska.Message);
                                return;
                            }
                        }
                    }
                }
            }

            public void NapuniObracunPorez(DataTable tblRadnici)
            {
                SqlCommand sqlUpit = new SqlCommand();
                sqlUpit.Connection = client.sqlConnection;
                sqlUpit.CommandType = CommandType.Text;

                sqlUpit.CommandText = "Insert Into ObracunPorezi ([IDOBRACUN], [IDRADNIK], [IDPOREZ], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], " + 
                                      "[MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ]) " +
                                      "Values (@IDOBRACUN, @IDRADNIK, @IDPOREZ, @OBRACUNATIPOREZ, @OSNOVICAPOREZ, @NAZIVPOREZ, @STOPAPOREZA, @POREZMJESECNO, " +
                                      "@MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ)";

                sqlUpit.Parameters.Add(new SqlParameter("@IDOBRACUN", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@IDRADNIK", SqlDbType.Int));
                sqlUpit.Parameters.Add(new SqlParameter("@IDPOREZ", SqlDbType.Int));
                sqlUpit.Parameters.Add(new SqlParameter("@OBRACUNATIPOREZ", SqlDbType.Money));
                sqlUpit.Parameters.Add(new SqlParameter("@OSNOVICAPOREZ", SqlDbType.Money));
                sqlUpit.Parameters.Add(new SqlParameter("@NAZIVPOREZ", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@STOPAPOREZA", SqlDbType.SmallMoney));
                sqlUpit.Parameters.Add(new SqlParameter("@POREZMJESECNO", SqlDbType.Money));
                sqlUpit.Parameters.Add(new SqlParameter("@MOPOREZ", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@POPOREZ", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@MZPOREZ", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@PZPOREZ", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@PRIMATELJPOREZ1", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@PRIMATELJPOREZ2", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@SIFRAOPISAPLACANJAPOREZ", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@OPISPLACANJAPOREZ", SqlDbType.NVarChar));

                int id_radnik = 0;

                foreach (DataRow red in tblRadnici.Rows)
                {
                    if (red["P61"].ToString() == "5201" || red["P61"].ToString() == "5203" || red["P61"].ToString() == "5204"
                        || red["P61"].ToString() == "5207" || red["P61"].ToString() == "5209" || red["P61"].ToString() == "5210"
                        || red["P61"].ToString() == "5211")
                    {
                        continue;
                    }
                    if (red["P151"].ToString() == "19" && red["P61"].ToString() == "0000" && red["P62"].ToString() == "0000")
                    {
                        continue;
                    }

                    sqlUpit.CommandText = "Insert Into ObracunPorezi ([IDOBRACUN], [IDRADNIK], [IDPOREZ], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], " +
                                     "[MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ]) " +
                                     "Values (@IDOBRACUN, @IDRADNIK, @IDPOREZ, @OBRACUNATIPOREZ, @OSNOVICAPOREZ, @NAZIVPOREZ, @STOPAPOREZA, @POREZMJESECNO, " +
                                     "@MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ)";

                    //insert reda za gop ukoliko postoji, ako ne radi po starom
                    if (red["P62"].ToString() == "0406")
                    {
                        sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                        id_radnik = VratiIDRadnika(red["P4"].ToString());
                        if (id_radnik > 0)
                        {
                            sqlUpit.Parameters["@IDRADNIK"].Value = id_radnik;
                        }
                        else
                        {
                            MessageBox.Show("Ne postoji radnik sa OIB-om " + red["P4"].ToString() + " u MIPSEDU. Molimo unesite Radnika da bi blilo moguće prenjeti njegove podatke.");
                            continue;
                        }

                        sqlUpit.Parameters["@IDPOREZ"].Value = 999;
                        sqlUpit.Parameters["@OSNOVICAPOREZ"].Value = 0;
                        sqlUpit.Parameters["@STOPAPOREZA"].Value =0;
                        sqlUpit.Parameters["@OBRACUNATIPOREZ"].Value = Convert.ToDecimal(red["P141"].ToString().Replace('.', ','));
                        sqlUpit.Parameters["@NAZIVPOREZ"].Value = VratiNazivPorez(999);
                        sqlUpit.Parameters["@POREZMJESECNO"].Value = VratiPorezMjesecno(999);
                        sqlUpit.Parameters["@MOPOREZ"].Value = VratiMOPorez(999);
                        sqlUpit.Parameters["@POPOREZ"].Value = VratiPOPorez(999);
                        sqlUpit.Parameters["@MZPOREZ"].Value = VratiMZPorez(999);
                        sqlUpit.Parameters["@PZPOREZ"].Value = VratiPZPorez(999);
                        sqlUpit.Parameters["@PRIMATELJPOREZ1"].Value = VratiPrimateljPorez1(999);
                        sqlUpit.Parameters["@PRIMATELJPOREZ2"].Value = VratiPrimateljPorez2(999);
                        sqlUpit.Parameters["@SIFRAOPISAPLACANJAPOREZ"].Value = VratiSifraOpisaPlacanjaPorez(999);
                        sqlUpit.Parameters["@OPISPLACANJAPOREZ"].Value = VratiOpisPlacanjaPorez(999);

                        try
                        {
                            sqlUpit.ExecuteNonQuery();
                        }
                        catch (Exception greska)
                        {
                            MessageBox.Show(greska.Message);
                            return;
                        }
                    }
                    else
                    {

                        #region prvi porezni rang od 0 - 2200  -  12%
                        if (Convert.ToDecimal(red["P135"].ToString().Replace('.', ',')) <= 2200)
                        {
                            sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                            id_radnik = VratiIDRadnika(red["P4"].ToString());
                            if (id_radnik > 0)
                            {
                                sqlUpit.Parameters["@IDRADNIK"].Value = id_radnik;
                            }
                            else
                            {
                                MessageBox.Show("Ne postoji radnik sa OIB-om " + red["P4"].ToString() + " u MIPSEDU. Molimo unesite Radnika da bi blilo moguće prenjeti njegove podatke.");
                                continue;
                            }
                            sqlUpit.Parameters["@IDPOREZ"].Value = 9;
                            sqlUpit.Parameters["@OSNOVICAPOREZ"].Value = Convert.ToDecimal(red["P135"].ToString().Replace('.', ','));
                            sqlUpit.Parameters["@STOPAPOREZA"].Value = VratiStopuPoreza(9);
                            sqlUpit.Parameters["@OBRACUNATIPOREZ"].Value = VratiObracunatiPorez(VratiStopuPoreza(9), Convert.ToDecimal(red["P135"].ToString().Replace('.', ',')));
                            sqlUpit.Parameters["@NAZIVPOREZ"].Value = VratiNazivPorez(9);
                            sqlUpit.Parameters["@POREZMJESECNO"].Value = VratiPorezMjesecno(9);
                            sqlUpit.Parameters["@MOPOREZ"].Value = VratiMOPorez(9);
                            sqlUpit.Parameters["@POPOREZ"].Value = VratiPOPorez(9);
                            sqlUpit.Parameters["@MZPOREZ"].Value = VratiMZPorez(9);
                            sqlUpit.Parameters["@PZPOREZ"].Value = VratiPZPorez(9);
                            sqlUpit.Parameters["@PRIMATELJPOREZ1"].Value = VratiPrimateljPorez1(9);
                            sqlUpit.Parameters["@PRIMATELJPOREZ2"].Value = VratiPrimateljPorez2(9);
                            sqlUpit.Parameters["@SIFRAOPISAPLACANJAPOREZ"].Value = VratiSifraOpisaPlacanjaPorez(9);
                            sqlUpit.Parameters["@OPISPLACANJAPOREZ"].Value = VratiOpisPlacanjaPorez(9);

                            try
                            {
                                sqlUpit.ExecuteNonQuery();
                            }
                            catch (Exception greska)
                            {
                                if (greska.Message.Contains("Violation of PRIMARY KEY"))
                                {
                                    try
                                    {
                                        #region korekcija kada su dva reda(prvi red je drugi porezni rang , drugi red je prvi porezni rang
                                        if (GetOsnovicaPorezPostojeci(pSifraObracuna, id_radnik, 9) == 2200)
                                        {
                                            sqlUpit.CommandText = "Insert Into ObracunPorezi ([IDOBRACUN], [IDRADNIK], [IDPOREZ], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], " +
                                                 "[MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ]) " +
                                                 "Values (@IDOBRACUN, @IDRADNIK, @IDPOREZ, @OBRACUNATIPOREZ, @OSNOVICAPOREZ, @NAZIVPOREZ, @STOPAPOREZA, @POREZMJESECNO, " +
                                                 "@MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ)";

                                            sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                                            sqlUpit.Parameters["@IDRADNIK"].Value = VratiIDRadnika(red["P4"].ToString());
                                            sqlUpit.Parameters["@IDPOREZ"].Value = 10;

                                            try
                                            {
                                                sqlUpit.ExecuteNonQuery();
                                            }
                                            catch (Exception error_drugi)
                                            {
                                                if (error_drugi.Message.Contains("Violation of PRIMARY KEY"))
                                                {
                                                    try
                                                    {
                                                        //ukoliko se desi da je drugi porezni rang pun ide u treci
                                                        if (GetOsnovicaPorezPostojeci(pSifraObracuna, id_radnik, 10) == 11000)
                                                        {
                                                            sqlUpit.CommandText = "Insert Into ObracunPorezi ([IDOBRACUN], [IDRADNIK], [IDPOREZ], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], " +
                                                                 "[MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ]) " +
                                                                 "Values (@IDOBRACUN, @IDRADNIK, @IDPOREZ, @OBRACUNATIPOREZ, @OSNOVICAPOREZ, @NAZIVPOREZ, @STOPAPOREZA, @POREZMJESECNO, " +
                                                                 "@MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ)";

                                                            sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                                                            sqlUpit.Parameters["@IDRADNIK"].Value = VratiIDRadnika(red["P4"].ToString());
                                                            sqlUpit.Parameters["@IDPOREZ"].Value = 11;

                                                            try
                                                            {
                                                                sqlUpit.ExecuteNonQuery();
                                                            }
                                                            catch (Exception greska_treci)
                                                            {
                                                                if (greska_treci.Message.Contains("Violation of PRIMARY KEY"))
                                                                {
                                                                    try
                                                                    {
                                                                        sqlUpit.CommandText = "Update ObracunPorezi Set OSNOVICAPOREZ = OSNOVICAPOREZ + @OSNOVICAPOREZ, OBRACUNATIPOREZ = OBRACUNATIPOREZ + @OBRACUNATIPOREZ " +
                                                                                              "Where IDRADNIK = @IDRADNIK And IDPOREZ = @IDPOREZ AND IDOBRACUN = @IDOBRACUN";

                                                                        sqlUpit.ExecuteNonQuery();
                                                                    }
                                                                    catch
                                                                    {
                                                                        MessageBox.Show(greska_treci.Message);
                                                                        return;
                                                                    }
                                                                }
                                                                else
                                                                {

                                                                    MessageBox.Show(greska_treci.Message);
                                                                    return;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            sqlUpit.CommandText = "Update ObracunPorezi Set OSNOVICAPOREZ = OSNOVICAPOREZ + @OSNOVICAPOREZ, OBRACUNATIPOREZ = OBRACUNATIPOREZ + @OBRACUNATIPOREZ " +
                                                                                  "Where IDRADNIK = @IDRADNIK And IDPOREZ = @IDPOREZ AND IDOBRACUN = @IDOBRACUN";

                                                            sqlUpit.ExecuteNonQuery();
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        MessageBox.Show(error_drugi.Message);
                                                        return;
                                                    }
                                                }
                                                else
                                                {

                                                    MessageBox.Show(error_drugi.Message);
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            sqlUpit.CommandText = "Update ObracunPorezi Set OSNOVICAPOREZ = OSNOVICAPOREZ + @OSNOVICAPOREZ, OBRACUNATIPOREZ = OBRACUNATIPOREZ + @OBRACUNATIPOREZ " +
                                                                  "Where IDRADNIK = @IDRADNIK And IDPOREZ = @IDPOREZ AND IDOBRACUN = @IDOBRACUN";
                                            sqlUpit.ExecuteNonQuery();
                                        }
                                        #endregion
                                    }
                                    catch
                                    {
                                        MessageBox.Show(greska.Message);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(greska.Message);
                                    return;
                                }
                            }
                        }
                        #endregion

                        #region drugi porezni rang od 2200 - 13200  -  25%
                        else if (Convert.ToDecimal(red["P135"].ToString().Replace('.', ',')) > 2200 & Convert.ToDecimal(red["P135"].ToString().Replace('.', ',')) <= 13200)
                        {
                            sqlUpit.CommandText = "Insert Into ObracunPorezi ([IDOBRACUN], [IDRADNIK], [IDPOREZ], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], " +
                                         "[MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ]) " +
                                         "Values (@IDOBRACUN, @IDRADNIK, @IDPOREZ, @OBRACUNATIPOREZ, @OSNOVICAPOREZ, @NAZIVPOREZ, @STOPAPOREZA, @POREZMJESECNO, " +
                                         "@MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ)";

                            sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                            sqlUpit.Parameters["@IDRADNIK"].Value = VratiIDRadnika(red["P4"].ToString());
                            sqlUpit.Parameters["@IDPOREZ"].Value = 9;
                            sqlUpit.Parameters["@OSNOVICAPOREZ"].Value = 2200;
                            sqlUpit.Parameters["@STOPAPOREZA"].Value = VratiStopuPoreza(9);
                            sqlUpit.Parameters["@OBRACUNATIPOREZ"].Value = VratiObracunatiPorez(VratiStopuPoreza(9), 2200);
                            sqlUpit.Parameters["@NAZIVPOREZ"].Value = VratiNazivPorez(9);
                            sqlUpit.Parameters["@POREZMJESECNO"].Value = VratiPorezMjesecno(9);
                            sqlUpit.Parameters["@MOPOREZ"].Value = VratiMOPorez(9);
                            sqlUpit.Parameters["@POPOREZ"].Value = VratiPOPorez(9);
                            sqlUpit.Parameters["@MZPOREZ"].Value = VratiMZPorez(9);
                            sqlUpit.Parameters["@PZPOREZ"].Value = VratiPZPorez(9);
                            sqlUpit.Parameters["@PRIMATELJPOREZ1"].Value = VratiPrimateljPorez1(9);
                            sqlUpit.Parameters["@PRIMATELJPOREZ2"].Value = VratiPrimateljPorez2(9);
                            sqlUpit.Parameters["@SIFRAOPISAPLACANJAPOREZ"].Value = VratiSifraOpisaPlacanjaPorez(9);
                            sqlUpit.Parameters["@OPISPLACANJAPOREZ"].Value = VratiOpisPlacanjaPorez(9);

                            try
                            {
                                sqlUpit.ExecuteNonQuery();
                            }
                            catch (Exception greska)
                            {
                                if (greska.Message.Contains("Violation of PRIMARY KEY"))
                                {
                                    try
                                    {
                                        #region korekcija kada su dva reda(prvi red je drugi porezni rang , drugi red je prvi porezni rang
                                        if (GetOsnovicaPorezPostojeci(pSifraObracuna, id_radnik, 9) == 2200)
                                        {
                                            sqlUpit.CommandText = "Insert Into ObracunPorezi ([IDOBRACUN], [IDRADNIK], [IDPOREZ], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], " +
                                                 "[MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ]) " +
                                                 "Values (@IDOBRACUN, @IDRADNIK, @IDPOREZ, @OBRACUNATIPOREZ, @OSNOVICAPOREZ, @NAZIVPOREZ, @STOPAPOREZA, @POREZMJESECNO, " +
                                                 "@MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ)";

                                            sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                                            sqlUpit.Parameters["@IDRADNIK"].Value = VratiIDRadnika(red["P4"].ToString());
                                            sqlUpit.Parameters["@IDPOREZ"].Value = 10;

                                            try
                                            {
                                                sqlUpit.ExecuteNonQuery();
                                            }
                                            catch (Exception error_drugi)
                                            {
                                                if (error_drugi.Message.Contains("Violation of PRIMARY KEY"))
                                                {
                                                    try
                                                    {
                                                        //ukoliko se desi da je drugi porezni rang pun ide u treci
                                                        if (GetOsnovicaPorezPostojeci(pSifraObracuna, id_radnik, 10) == 11000)
                                                        {
                                                            sqlUpit.CommandText = "Insert Into ObracunPorezi ([IDOBRACUN], [IDRADNIK], [IDPOREZ], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], " +
                                                                 "[MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ]) " +
                                                                 "Values (@IDOBRACUN, @IDRADNIK, @IDPOREZ, @OBRACUNATIPOREZ, @OSNOVICAPOREZ, @NAZIVPOREZ, @STOPAPOREZA, @POREZMJESECNO, " +
                                                                 "@MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ)";

                                                            sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                                                            sqlUpit.Parameters["@IDRADNIK"].Value = VratiIDRadnika(red["P4"].ToString());
                                                            sqlUpit.Parameters["@IDPOREZ"].Value = 11;

                                                            try
                                                            {
                                                                sqlUpit.ExecuteNonQuery();
                                                            }
                                                            catch (Exception greska_treci)
                                                            {
                                                                if (greska_treci.Message.Contains("Violation of PRIMARY KEY"))
                                                                {
                                                                    try
                                                                    {
                                                                        sqlUpit.CommandText = "Update ObracunPorezi Set OSNOVICAPOREZ = OSNOVICAPOREZ + @OSNOVICAPOREZ, OBRACUNATIPOREZ = OBRACUNATIPOREZ + @OBRACUNATIPOREZ " +
                                                                                              "Where IDRADNIK = @IDRADNIK And IDPOREZ = @IDPOREZ AND IDOBRACUN = @IDOBRACUN";

                                                                        sqlUpit.ExecuteNonQuery();
                                                                    }
                                                                    catch
                                                                    {
                                                                        MessageBox.Show(greska_treci.Message);
                                                                        return;
                                                                    }
                                                                }
                                                                else
                                                                {

                                                                    MessageBox.Show(greska_treci.Message);
                                                                    return;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            sqlUpit.CommandText = "Update ObracunPorezi Set OSNOVICAPOREZ = OSNOVICAPOREZ + @OSNOVICAPOREZ, OBRACUNATIPOREZ = OBRACUNATIPOREZ + @OBRACUNATIPOREZ " +
                                                                                  "Where IDRADNIK = @IDRADNIK And IDPOREZ = @IDPOREZ AND IDOBRACUN = @IDOBRACUN";

                                                            sqlUpit.ExecuteNonQuery();
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        MessageBox.Show(error_drugi.Message);
                                                        return;
                                                    }
                                                }
                                                else
                                                {

                                                    MessageBox.Show(error_drugi.Message);
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            sqlUpit.CommandText = "Update ObracunPorezi Set OSNOVICAPOREZ = OSNOVICAPOREZ + @OSNOVICAPOREZ, OBRACUNATIPOREZ = OBRACUNATIPOREZ + @OBRACUNATIPOREZ " +
                                                                  "Where IDRADNIK = @IDRADNIK And IDPOREZ = @IDPOREZ AND IDOBRACUN = @IDOBRACUN";
                                            sqlUpit.ExecuteNonQuery();
                                        }
                                        #endregion
                                    }
                                    catch
                                    {
                                        MessageBox.Show(greska.Message);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(greska.Message);
                                    return;
                                }
                            }

                            sqlUpit.CommandText = "Insert Into ObracunPorezi ([IDOBRACUN], [IDRADNIK], [IDPOREZ], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], " +
                                         "[MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ]) " +
                                         "Values (@IDOBRACUN, @IDRADNIK, @IDPOREZ, @OBRACUNATIPOREZ, @OSNOVICAPOREZ, @NAZIVPOREZ, @STOPAPOREZA, @POREZMJESECNO, " +
                                         "@MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ)";


                            sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                            sqlUpit.Parameters["@IDRADNIK"].Value = VratiIDRadnika(red["P4"].ToString());
                            sqlUpit.Parameters["@IDPOREZ"].Value = 10;
                            sqlUpit.Parameters["@OSNOVICAPOREZ"].Value = Convert.ToDecimal(red["P135"].ToString().Replace('.', ',')) - 2200;
                            sqlUpit.Parameters["@STOPAPOREZA"].Value = VratiStopuPoreza(10);
                            sqlUpit.Parameters["@OBRACUNATIPOREZ"].Value = VratiObracunatiPorez(VratiStopuPoreza(10), Convert.ToDecimal(red["P135"].ToString().Replace('.', ',')) - 2200);
                            sqlUpit.Parameters["@NAZIVPOREZ"].Value = VratiNazivPorez(10);
                            sqlUpit.Parameters["@POREZMJESECNO"].Value = VratiPorezMjesecno(10);
                            sqlUpit.Parameters["@MOPOREZ"].Value = VratiMOPorez(10);
                            sqlUpit.Parameters["@POPOREZ"].Value = VratiPOPorez(10);
                            sqlUpit.Parameters["@MZPOREZ"].Value = VratiMZPorez(10);
                            sqlUpit.Parameters["@PZPOREZ"].Value = VratiPZPorez(10);
                            sqlUpit.Parameters["@PRIMATELJPOREZ1"].Value = VratiPrimateljPorez1(10);
                            sqlUpit.Parameters["@PRIMATELJPOREZ2"].Value = VratiPrimateljPorez2(10);
                            sqlUpit.Parameters["@SIFRAOPISAPLACANJAPOREZ"].Value = VratiSifraOpisaPlacanjaPorez(10);
                            sqlUpit.Parameters["@OPISPLACANJAPOREZ"].Value = VratiOpisPlacanjaPorez(10);

                            try
                            {
                                sqlUpit.ExecuteNonQuery();
                            }
                            catch (Exception greska)
                            {
                                if (greska.Message.Contains("Violation of PRIMARY KEY"))
                                {
                                    try
                                    {
                                        #region korekcija kada postoji drugi porezni rang i kada je pun da stavlja u treci
                                        //ukoliko se desi da je drugi porezni rang pun ide u treci
                                        if (GetOsnovicaPorezPostojeci(pSifraObracuna, id_radnik, 10) == 11000)
                                        {
                                            sqlUpit.CommandText = "Insert Into ObracunPorezi ([IDOBRACUN], [IDRADNIK], [IDPOREZ], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], " +
                                                 "[MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ]) " +
                                                 "Values (@IDOBRACUN, @IDRADNIK, @IDPOREZ, @OBRACUNATIPOREZ, @OSNOVICAPOREZ, @NAZIVPOREZ, @STOPAPOREZA, @POREZMJESECNO, " +
                                                 "@MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ)";

                                            sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                                            sqlUpit.Parameters["@IDRADNIK"].Value = VratiIDRadnika(red["P4"].ToString());
                                            sqlUpit.Parameters["@IDPOREZ"].Value = 11;

                                            try
                                            {
                                                sqlUpit.ExecuteNonQuery();
                                            }
                                            catch (Exception greska_treci)
                                            {
                                                if (greska_treci.Message.Contains("Violation of PRIMARY KEY"))
                                                {
                                                    try
                                                    {
                                                        sqlUpit.CommandText = "Update ObracunPorezi Set OSNOVICAPOREZ = OSNOVICAPOREZ + @OSNOVICAPOREZ, OBRACUNATIPOREZ = OBRACUNATIPOREZ + @OBRACUNATIPOREZ " +
                                                                              "Where IDRADNIK = @IDRADNIK And IDPOREZ = @IDPOREZ AND IDOBRACUN = @IDOBRACUN";

                                                        sqlUpit.ExecuteNonQuery();
                                                    }
                                                    catch
                                                    {
                                                        MessageBox.Show(greska_treci.Message);
                                                        return;
                                                    }
                                                }
                                                else
                                                {

                                                    MessageBox.Show(greska_treci.Message);
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            sqlUpit.CommandText = "Update ObracunPorezi Set OSNOVICAPOREZ = OSNOVICAPOREZ + @OSNOVICAPOREZ, OBRACUNATIPOREZ = OBRACUNATIPOREZ + @OBRACUNATIPOREZ " +
                                                                  "Where IDRADNIK = @IDRADNIK And IDPOREZ = @IDPOREZ AND IDOBRACUN = @IDOBRACUN";

                                            sqlUpit.ExecuteNonQuery();
                                        }
                                        #endregion
                                    }
                                    catch
                                    {
                                        MessageBox.Show(greska.Message);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(greska.Message);
                                    return;
                                }
                            }
                        }
                        #endregion

                        #region treci porezni rang vise od 13200  -  40%
                        else if (Convert.ToDecimal(red["P135"].ToString().Replace('.', ',')) > 13200)
                        {
                            sqlUpit.CommandText = "Insert Into ObracunPorezi ([IDOBRACUN], [IDRADNIK], [IDPOREZ], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], " +
                                         "[MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ]) " +
                                         "Values (@IDOBRACUN, @IDRADNIK, @IDPOREZ, @OBRACUNATIPOREZ, @OSNOVICAPOREZ, @NAZIVPOREZ, @STOPAPOREZA, @POREZMJESECNO, " +
                                         "@MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ)";

                            sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                            sqlUpit.Parameters["@IDRADNIK"].Value = VratiIDRadnika(red["P4"].ToString());
                            sqlUpit.Parameters["@IDPOREZ"].Value = 9;
                            sqlUpit.Parameters["@OSNOVICAPOREZ"].Value = 2200;
                            sqlUpit.Parameters["@STOPAPOREZA"].Value = VratiStopuPoreza(9);
                            sqlUpit.Parameters["@OBRACUNATIPOREZ"].Value = VratiObracunatiPorez(VratiStopuPoreza(9), 2200);
                            sqlUpit.Parameters["@NAZIVPOREZ"].Value = VratiNazivPorez(9);
                            sqlUpit.Parameters["@POREZMJESECNO"].Value = VratiPorezMjesecno(9);
                            sqlUpit.Parameters["@MOPOREZ"].Value = VratiMOPorez(9);
                            sqlUpit.Parameters["@POPOREZ"].Value = VratiPOPorez(9);
                            sqlUpit.Parameters["@MZPOREZ"].Value = VratiMZPorez(9);
                            sqlUpit.Parameters["@PZPOREZ"].Value = VratiPZPorez(9);
                            sqlUpit.Parameters["@PRIMATELJPOREZ1"].Value = VratiPrimateljPorez1(9);
                            sqlUpit.Parameters["@PRIMATELJPOREZ2"].Value = VratiPrimateljPorez2(9);
                            sqlUpit.Parameters["@SIFRAOPISAPLACANJAPOREZ"].Value = VratiSifraOpisaPlacanjaPorez(9);
                            sqlUpit.Parameters["@OPISPLACANJAPOREZ"].Value = VratiOpisPlacanjaPorez(9);

                            try
                            {
                                sqlUpit.ExecuteNonQuery();
                            }
                            catch (Exception greska)
                            {
                                if (greska.Message.Contains("Violation of PRIMARY KEY"))
                                {
                                    try
                                    {
                                        #region korekcija kada su dva reda(prvi red je drugi porezni rang , drugi red je prvi porezni rang
                                        if (GetOsnovicaPorezPostojeci(pSifraObracuna, id_radnik, 9) == 2200)
                                        {
                                            sqlUpit.CommandText = "Insert Into ObracunPorezi ([IDOBRACUN], [IDRADNIK], [IDPOREZ], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], " +
                                                 "[MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ]) " +
                                                 "Values (@IDOBRACUN, @IDRADNIK, @IDPOREZ, @OBRACUNATIPOREZ, @OSNOVICAPOREZ, @NAZIVPOREZ, @STOPAPOREZA, @POREZMJESECNO, " +
                                                 "@MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ)";

                                            sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                                            sqlUpit.Parameters["@IDRADNIK"].Value = VratiIDRadnika(red["P4"].ToString());
                                            sqlUpit.Parameters["@IDPOREZ"].Value = 10;

                                            try
                                            {
                                                sqlUpit.ExecuteNonQuery();
                                            }
                                            catch (Exception error_drugi)
                                            {
                                                if (error_drugi.Message.Contains("Violation of PRIMARY KEY"))
                                                {
                                                    try
                                                    {
                                                        //ukoliko se desi da je drugi porezni rang pun ide u treci
                                                        if (GetOsnovicaPorezPostojeci(pSifraObracuna, id_radnik, 10) == 11000)
                                                        {
                                                            sqlUpit.CommandText = "Insert Into ObracunPorezi ([IDOBRACUN], [IDRADNIK], [IDPOREZ], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], " +
                                                                 "[MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ]) " +
                                                                 "Values (@IDOBRACUN, @IDRADNIK, @IDPOREZ, @OBRACUNATIPOREZ, @OSNOVICAPOREZ, @NAZIVPOREZ, @STOPAPOREZA, @POREZMJESECNO, " +
                                                                 "@MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ)";

                                                            sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                                                            sqlUpit.Parameters["@IDRADNIK"].Value = VratiIDRadnika(red["P4"].ToString());
                                                            sqlUpit.Parameters["@IDPOREZ"].Value = 11;

                                                            try
                                                            {
                                                                sqlUpit.ExecuteNonQuery();
                                                            }
                                                            catch (Exception greska_treci)
                                                            {
                                                                if (greska_treci.Message.Contains("Violation of PRIMARY KEY"))
                                                                {
                                                                    try
                                                                    {
                                                                        sqlUpit.CommandText = "Update ObracunPorezi Set OSNOVICAPOREZ = OSNOVICAPOREZ + @OSNOVICAPOREZ, OBRACUNATIPOREZ = OBRACUNATIPOREZ + @OBRACUNATIPOREZ " +
                                                                                              "Where IDRADNIK = @IDRADNIK And IDPOREZ = @IDPOREZ AND IDOBRACUN = @IDOBRACUN";

                                                                        sqlUpit.ExecuteNonQuery();
                                                                    }
                                                                    catch
                                                                    {
                                                                        MessageBox.Show(greska_treci.Message);
                                                                        return;
                                                                    }
                                                                }
                                                                else
                                                                {

                                                                    MessageBox.Show(greska_treci.Message);
                                                                    return;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            sqlUpit.CommandText = "Update ObracunPorezi Set OSNOVICAPOREZ = OSNOVICAPOREZ + @OSNOVICAPOREZ, OBRACUNATIPOREZ = OBRACUNATIPOREZ + @OBRACUNATIPOREZ " +
                                                                                  "Where IDRADNIK = @IDRADNIK And IDPOREZ = @IDPOREZ AND IDOBRACUN = @IDOBRACUN";

                                                            sqlUpit.ExecuteNonQuery();
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        MessageBox.Show(error_drugi.Message);
                                                        return;
                                                    }
                                                }
                                                else
                                                {

                                                    MessageBox.Show(error_drugi.Message);
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            sqlUpit.CommandText = "Update ObracunPorezi Set OSNOVICAPOREZ = OSNOVICAPOREZ + @OSNOVICAPOREZ, OBRACUNATIPOREZ = OBRACUNATIPOREZ + @OBRACUNATIPOREZ " +
                                                                  "Where IDRADNIK = @IDRADNIK And IDPOREZ = @IDPOREZ AND IDOBRACUN = @IDOBRACUN";
                                            sqlUpit.ExecuteNonQuery();
                                        }
                                        #endregion
                                    }
                                    catch
                                    {
                                        MessageBox.Show(greska.Message);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(greska.Message);
                                    return;
                                }
                            }

                            sqlUpit.CommandText = "Insert Into ObracunPorezi ([IDOBRACUN], [IDRADNIK], [IDPOREZ], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], " +
                                         "[MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ]) " +
                                         "Values (@IDOBRACUN, @IDRADNIK, @IDPOREZ, @OBRACUNATIPOREZ, @OSNOVICAPOREZ, @NAZIVPOREZ, @STOPAPOREZA, @POREZMJESECNO, " +
                                         "@MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ)";

                            sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                            sqlUpit.Parameters["@IDRADNIK"].Value = VratiIDRadnika(red["P4"].ToString());
                            sqlUpit.Parameters["@IDPOREZ"].Value = 10;
                            sqlUpit.Parameters["@OSNOVICAPOREZ"].Value = 11000;
                            sqlUpit.Parameters["@STOPAPOREZA"].Value = VratiStopuPoreza(10);
                            sqlUpit.Parameters["@OBRACUNATIPOREZ"].Value = VratiObracunatiPorez(VratiStopuPoreza(10), 11000);
                            sqlUpit.Parameters["@NAZIVPOREZ"].Value = VratiNazivPorez(10);
                            sqlUpit.Parameters["@POREZMJESECNO"].Value = VratiPorezMjesecno(10);
                            sqlUpit.Parameters["@MOPOREZ"].Value = VratiMOPorez(10);
                            sqlUpit.Parameters["@POPOREZ"].Value = VratiPOPorez(10);
                            sqlUpit.Parameters["@MZPOREZ"].Value = VratiMZPorez(10);
                            sqlUpit.Parameters["@PZPOREZ"].Value = VratiPZPorez(10);
                            sqlUpit.Parameters["@PRIMATELJPOREZ1"].Value = VratiPrimateljPorez1(10);
                            sqlUpit.Parameters["@PRIMATELJPOREZ2"].Value = VratiPrimateljPorez2(10);
                            sqlUpit.Parameters["@SIFRAOPISAPLACANJAPOREZ"].Value = VratiSifraOpisaPlacanjaPorez(10);
                            sqlUpit.Parameters["@OPISPLACANJAPOREZ"].Value = VratiOpisPlacanjaPorez(10);

                            try
                            {
                                sqlUpit.ExecuteNonQuery();
                            }
                            catch (Exception greska)
                            {
                                if (greska.Message.Contains("Violation of PRIMARY KEY"))
                                {
                                    try
                                    {
                                        #region korekcija kada postoji drugi porezni rang i kada je pun da stavlja u treci
                                        //ukoliko se desi da je drugi porezni rang pun ide u treci
                                        if (GetOsnovicaPorezPostojeci(pSifraObracuna, id_radnik, 10) == 11000)
                                        {
                                            sqlUpit.CommandText = "Insert Into ObracunPorezi ([IDOBRACUN], [IDRADNIK], [IDPOREZ], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], " +
                                                 "[MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ]) " +
                                                 "Values (@IDOBRACUN, @IDRADNIK, @IDPOREZ, @OBRACUNATIPOREZ, @OSNOVICAPOREZ, @NAZIVPOREZ, @STOPAPOREZA, @POREZMJESECNO, " +
                                                 "@MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ)";

                                            sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                                            sqlUpit.Parameters["@IDRADNIK"].Value = VratiIDRadnika(red["P4"].ToString());
                                            sqlUpit.Parameters["@IDPOREZ"].Value = 11;

                                            try
                                            {
                                                sqlUpit.ExecuteNonQuery();
                                            }
                                            catch (Exception greska_treci)
                                            {
                                                if (greska_treci.Message.Contains("Violation of PRIMARY KEY"))
                                                {
                                                    try
                                                    {
                                                        sqlUpit.CommandText = "Update ObracunPorezi Set OSNOVICAPOREZ = OSNOVICAPOREZ + @OSNOVICAPOREZ, OBRACUNATIPOREZ = OBRACUNATIPOREZ + @OBRACUNATIPOREZ " +
                                                                              "Where IDRADNIK = @IDRADNIK And IDPOREZ = @IDPOREZ AND IDOBRACUN = @IDOBRACUN";

                                                        sqlUpit.ExecuteNonQuery();
                                                    }
                                                    catch
                                                    {
                                                        MessageBox.Show(greska_treci.Message);
                                                        return;
                                                    }
                                                }
                                                else
                                                {

                                                    MessageBox.Show(greska_treci.Message);
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            sqlUpit.CommandText = "Update ObracunPorezi Set OSNOVICAPOREZ = OSNOVICAPOREZ + @OSNOVICAPOREZ, OBRACUNATIPOREZ = OBRACUNATIPOREZ + @OBRACUNATIPOREZ " +
                                                                  "Where IDRADNIK = @IDRADNIK And IDPOREZ = @IDPOREZ AND IDOBRACUN = @IDOBRACUN";

                                            sqlUpit.ExecuteNonQuery();
                                        }
                                        #endregion
                                    }
                                    catch
                                    {
                                        MessageBox.Show(greska.Message);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(greska.Message);
                                    return;
                                }
                            }

                            sqlUpit.CommandText = "Insert Into ObracunPorezi ([IDOBRACUN], [IDRADNIK], [IDPOREZ], [OBRACUNATIPOREZ], [OSNOVICAPOREZ], [NAZIVPOREZ], [STOPAPOREZA], [POREZMJESECNO], " +
                                         "[MOPOREZ], [POPOREZ], [MZPOREZ], [PZPOREZ], [PRIMATELJPOREZ1], [PRIMATELJPOREZ2], [SIFRAOPISAPLACANJAPOREZ], [OPISPLACANJAPOREZ]) " +
                                         "Values (@IDOBRACUN, @IDRADNIK, @IDPOREZ, @OBRACUNATIPOREZ, @OSNOVICAPOREZ, @NAZIVPOREZ, @STOPAPOREZA, @POREZMJESECNO, " +
                                         "@MOPOREZ, @POPOREZ, @MZPOREZ, @PZPOREZ, @PRIMATELJPOREZ1, @PRIMATELJPOREZ2, @SIFRAOPISAPLACANJAPOREZ, @OPISPLACANJAPOREZ)";


                            sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                            sqlUpit.Parameters["@IDRADNIK"].Value = VratiIDRadnika(red["P4"].ToString());
                            sqlUpit.Parameters["@IDPOREZ"].Value = 11;
                            sqlUpit.Parameters["@OSNOVICAPOREZ"].Value = Convert.ToDecimal(red["P135"].ToString().Replace('.', ',')) - 13200;
                            sqlUpit.Parameters["@STOPAPOREZA"].Value = VratiStopuPoreza(11);
                            sqlUpit.Parameters["@OBRACUNATIPOREZ"].Value = VratiObracunatiPorez(VratiStopuPoreza(10), Convert.ToDecimal(red["P135"].ToString().Replace('.', ',')) - 13200);
                            sqlUpit.Parameters["@NAZIVPOREZ"].Value = VratiNazivPorez(11);
                            sqlUpit.Parameters["@POREZMJESECNO"].Value = VratiPorezMjesecno(11);
                            sqlUpit.Parameters["@MOPOREZ"].Value = VratiMOPorez(11);
                            sqlUpit.Parameters["@POPOREZ"].Value = VratiPOPorez(11);
                            sqlUpit.Parameters["@MZPOREZ"].Value = VratiMZPorez(11);
                            sqlUpit.Parameters["@PZPOREZ"].Value = VratiPZPorez(11);
                            sqlUpit.Parameters["@PRIMATELJPOREZ1"].Value = VratiPrimateljPorez1(11);
                            sqlUpit.Parameters["@PRIMATELJPOREZ2"].Value = VratiPrimateljPorez2(11);
                            sqlUpit.Parameters["@SIFRAOPISAPLACANJAPOREZ"].Value = VratiSifraOpisaPlacanjaPorez(11);
                            sqlUpit.Parameters["@OPISPLACANJAPOREZ"].Value = VratiOpisPlacanjaPorez(11);

                            try
                            {
                                sqlUpit.ExecuteNonQuery();
                            }
                            catch (Exception greska)
                            {
                                if (greska.Message.Contains("Violation of PRIMARY KEY"))
                                {
                                    try
                                    {
                                        sqlUpit.CommandText = "Update ObracunPorezi Set OSNOVICAPOREZ = OSNOVICAPOREZ + @OSNOVICAPOREZ, OBRACUNATIPOREZ = OBRACUNATIPOREZ + @OBRACUNATIPOREZ " +
                                                              "Where IDRADNIK = @IDRADNIK And IDPOREZ = @IDPOREZ AND IDOBRACUN = @IDOBRACUN";

                                        sqlUpit.ExecuteNonQuery();
                                    }
                                    catch
                                    {
                                        MessageBox.Show(greska.Message);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(greska.Message);
                                    return;
                                }
                            }
                        }
                        #endregion
                    }
                }
            }

            public void NapuniObracunElementi(DataTable tblRadnici)
            {
                SqlCommand sqlUpit = new SqlCommand();
                sqlUpit.Connection = client.sqlConnection;
                sqlUpit.CommandType = CommandType.Text;

                sqlUpit.CommandText = "Insert Into ObracunElementi ([IDOBRACUN], [IDRADNIK], [IDELEMENT], [ELEMENTRAZDOBLJEOD], [ELEMENTRAZDOBLJEDO], [OBRSATI], [OBRSATNICA], " + 
                                      "[OBRPOSTOTAK], [NAZIVELEMENT], [IDVRSTAELEMENTA], [NAZIVVRSTAELEMENT], [OBRIZNOS], [OznakaMjeseca]) " +
                                      "Values (@IDOBRACUN, @IDRADNIK, @IDELEMENT, @ELEMENTRAZDOBLJEOD, @ELEMENTRAZDOBLJEDO, @OBRSATI, @OBRSATNICA, " +
                                      "@OBRPOSTOTAK, @NAZIVELEMENT, @IDVRSTAELEMENTA, @NAZIVVRSTAELEMENT, @OBRIZNOS, @OznakaMjeseca)";

                sqlUpit.Parameters.Add(new SqlParameter("@IDOBRACUN", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@IDRADNIK", SqlDbType.Int));
                sqlUpit.Parameters.Add(new SqlParameter("@IDELEMENT", SqlDbType.Int));
                sqlUpit.Parameters.Add(new SqlParameter("@ELEMENTRAZDOBLJEOD", SqlDbType.DateTime));
                sqlUpit.Parameters.Add(new SqlParameter("@ELEMENTRAZDOBLJEDO", SqlDbType.DateTime));
                sqlUpit.Parameters.Add(new SqlParameter("@OBRSATI", SqlDbType.SmallMoney));
                sqlUpit.Parameters.Add(new SqlParameter("@OBRSATNICA", SqlDbType.Decimal));
                sqlUpit.Parameters.Add(new SqlParameter("@OBRPOSTOTAK", SqlDbType.SmallMoney));
                sqlUpit.Parameters.Add(new SqlParameter("@NAZIVELEMENT", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@IDVRSTAELEMENTA", SqlDbType.SmallMoney));
                sqlUpit.Parameters.Add(new SqlParameter("@NAZIVVRSTAELEMENT", SqlDbType.NVarChar));
                sqlUpit.Parameters.Add(new SqlParameter("@OBRIZNOS", SqlDbType.Money));
                sqlUpit.Parameters.Add(new SqlParameter("@OznakaMjeseca", SqlDbType.Int));

                int id_radnik = 0;

                foreach (DataRow red in tblRadnici.Rows)
                {
                    //if (red["P151"].ToString() == "19")
                    //{
                    //    continue;
                    //}

                    sqlUpit.CommandText = "Insert Into ObracunElementi ([IDOBRACUN], [IDRADNIK], [IDELEMENT], [ELEMENTRAZDOBLJEOD], [ELEMENTRAZDOBLJEDO], [OBRSATI], [OBRSATNICA], " +
                                          "[OBRPOSTOTAK], [NAZIVELEMENT], [IDVRSTAELEMENTA], [NAZIVVRSTAELEMENT], [OBRIZNOS], [OznakaMjeseca]) " +
                                          "Values (@IDOBRACUN, @IDRADNIK, @IDELEMENT, @ELEMENTRAZDOBLJEOD, @ELEMENTRAZDOBLJEDO, @OBRSATI, @OBRSATNICA, " +
                                          "@OBRPOSTOTAK, @NAZIVELEMENT, @IDVRSTAELEMENTA, @NAZIVVRSTAELEMENT, @OBRIZNOS, @OznakaMjeseca)";

                    sqlUpit.Parameters["@IDOBRACUN"].Value = pSifraObracuna;
                    id_radnik = VratiIDRadnika(red["P4"].ToString());
                    if (id_radnik > 0)
                    {
                        sqlUpit.Parameters["@IDRADNIK"].Value = id_radnik;
                    }
                    else
                    {
                        MessageBox.Show("Ne postoji radnik sa OIB-om " + red["P4"].ToString() + " u MIPSEDU. Molimo unesite Radnika da bi blilo moguće prenjeti njegove podatke.");
                        continue;
                    }
                    sqlUpit.Parameters["@IDELEMENT"].Value = 9999;
                    sqlUpit.Parameters["@ELEMENTRAZDOBLJEOD"].Value = Convert.ToDateTime(red["P101"]);
                    sqlUpit.Parameters["@ELEMENTRAZDOBLJEDO"].Value = Convert.ToDateTime(red["P102"]);
                    sqlUpit.Parameters["@OBRSATI"].Value = Convert.ToDecimal(red["P10"].ToString().Replace('.', ','));
                    sqlUpit.Parameters["@OBRSATNICA"].Value = 1;
                    sqlUpit.Parameters["@OBRPOSTOTAK"].Value = 100;

                    switch (red["P61"].ToString())
                    {
                        case "5201":
                            sqlUpit.Parameters["@IDVRSTAELEMENTA"].Value = 1;
                            sqlUpit.Parameters["@NAZIVVRSTAELEMENT"].Value = "Neto";
                            sqlUpit.Parameters["@OBRIZNOS"].Value = Convert.ToDecimal(red["P152"].ToString().Replace('.', ','));
                            sqlUpit.Parameters["@NAZIVELEMENT"].Value = "BOLOVANJE";
                            sqlUpit.Parameters["@IDELEMENT"].Value = 50;
                            break;
                        case "5203":
                            sqlUpit.Parameters["@IDVRSTAELEMENTA"].Value = 1;
                            sqlUpit.Parameters["@NAZIVVRSTAELEMENT"].Value = "Neto";
                            sqlUpit.Parameters["@OBRIZNOS"].Value = Convert.ToDecimal(red["P152"].ToString().Replace('.', ','));
                            sqlUpit.Parameters["@NAZIVELEMENT"].Value = "Obvezni porodiljni dopust";
                            sqlUpit.Parameters["@IDELEMENT"].Value = 51;
                            break;
                        case "5204":
                            sqlUpit.Parameters["@IDVRSTAELEMENTA"].Value = 1;
                            sqlUpit.Parameters["@NAZIVVRSTAELEMENT"].Value = "Neto";
                            sqlUpit.Parameters["@OBRIZNOS"].Value = Convert.ToDecimal(red["P152"].ToString().Replace('.', ','));
                            sqlUpit.Parameters["@NAZIVELEMENT"].Value = "Roditeljski dopust";
                            sqlUpit.Parameters["@IDELEMENT"].Value = 1010;
                            break;
                        case "5207":
                            sqlUpit.Parameters["@IDVRSTAELEMENTA"].Value = 1;
                            sqlUpit.Parameters["@NAZIVVRSTAELEMENT"].Value = "Neto";
                            sqlUpit.Parameters["@OBRIZNOS"].Value = Convert.ToDecimal(red["P152"].ToString().Replace('.', ','));
                            sqlUpit.Parameters["@NAZIVELEMENT"].Value = "Komplikacije u trodnoći";
                            sqlUpit.Parameters["@IDELEMENT"].Value = 62;
                            break;
                        case "5209":
                            sqlUpit.Parameters["@IDVRSTAELEMENTA"].Value = 1;
                            sqlUpit.Parameters["@NAZIVVRSTAELEMENT"].Value = "Neto";
                            sqlUpit.Parameters["@OBRIZNOS"].Value = Convert.ToDecimal(red["P152"].ToString().Replace('.', ','));
                            sqlUpit.Parameters["@NAZIVELEMENT"].Value = "Povreda na radu";
                            sqlUpit.Parameters["@IDELEMENT"].Value = 63;
                            break;
                        case "5210":
                            sqlUpit.Parameters["@IDVRSTAELEMENTA"].Value = 1;
                            sqlUpit.Parameters["@NAZIVVRSTAELEMENT"].Value = "Neto";
                            sqlUpit.Parameters["@OBRIZNOS"].Value = Convert.ToDecimal(red["P152"].ToString().Replace('.', ','));
                            sqlUpit.Parameters["@NAZIVELEMENT"].Value = "Dopust za dijete sa poteškoćama u razvoju";
                            sqlUpit.Parameters["@IDELEMENT"].Value = 64;
                            break;
                        //NJEGA DJETETA NA POLA RADNOG VREMENA
                        case "2350":
                            sqlUpit.Parameters["@IDVRSTAELEMENTA"].Value = 1;
                            sqlUpit.Parameters["@NAZIVVRSTAELEMENT"].Value = "Neto";
                            sqlUpit.Parameters["@OBRIZNOS"].Value = Convert.ToDecimal(red["P152"].ToString().Replace('.', ','));
                            sqlUpit.Parameters["@NAZIVELEMENT"].Value = "Dopust za njegu djeteta - pola radnog vremena";
                            sqlUpit.Parameters["@IDELEMENT"].Value = 64;
                            break;
                        case "0000":
                            sqlUpit.Parameters["@IDVRSTAELEMENTA"].Value = 1;
                            sqlUpit.Parameters["@NAZIVVRSTAELEMENT"].Value = "Neto";
                            sqlUpit.Parameters["@OBRIZNOS"].Value = Convert.ToDecimal(red["P152"].ToString().Replace('.', ','));
                            sqlUpit.Parameters["@NAZIVELEMENT"].Value = "Neto COP";
                            sqlUpit.Parameters["@IDELEMENT"].Value = 9998;
                            break;
                        default:
                            sqlUpit.Parameters["@IDVRSTAELEMENTA"].Value = 2;
                            sqlUpit.Parameters["@NAZIVVRSTAELEMENT"].Value = "Bruto";
                            sqlUpit.Parameters["@OBRIZNOS"].Value = Convert.ToDecimal(red["P17"].ToString().Replace('.', ','));
                            sqlUpit.Parameters["@NAZIVELEMENT"].Value = "COP";
                            break;
                    }

                    if (red["P151"].ToString() == "19" && red["P61"].ToString() == "0000" && red["P62"].ToString() == "0000")
                    {
                        sqlUpit.Parameters["@IDVRSTAELEMENTA"].Value = 1;
                        sqlUpit.Parameters["@NAZIVVRSTAELEMENT"].Value = "Neto";
                        sqlUpit.Parameters["@OBRIZNOS"].Value = Convert.ToDecimal(red["P152"].ToString().Replace('.', ','));
                        sqlUpit.Parameters["@NAZIVELEMENT"].Value = "Naknada za prijevoz";
                        sqlUpit.Parameters["@IDELEMENT"].Value = 52;
                        sqlUpit.Parameters["@OBRSATI"].Value = 0;
                    }

                    if (red["P62"].ToString() == "0021" && (red["P61"].ToString() == "0001" || red["P61"].ToString() == "0026"))
                    {
                        sqlUpit.Parameters["@IDVRSTAELEMENTA"].Value = 2;
                        sqlUpit.Parameters["@NAZIVVRSTAELEMENT"].Value = "Bruto";
                        sqlUpit.Parameters["@OBRIZNOS"].Value = Convert.ToDecimal(red["P11"].ToString().Replace('.', ','));
                        sqlUpit.Parameters["@NAZIVELEMENT"].Value = "COP ostali primici";
                        sqlUpit.Parameters["@IDELEMENT"].Value = 18;
                        sqlUpit.Parameters["@OBRSATI"].Value = 0;
                    }

                    //kad je bruto i neto u jednom redu u datoteci
                    if (red["P151"].ToString() == "20" && red["P61"].ToString() == "0001" && red["P62"].ToString() == "0021")
                    {
                        sqlUpit.Parameters["@OBRIZNOS"].Value = Convert.ToDecimal(red["P11"].ToString().Replace('.', ','));
                    }

                    //Marko 22.09.2014. Otpremnina i neto na istom JOPPD obrazcu...
                    if (red["P151"].ToString() == "26" && red["P61"].ToString() == "0001" && red["P62"].ToString() == "0025")
                    {
                        sqlUpit.Parameters["@OBRIZNOS"].Value = Convert.ToDecimal(red["P11"].ToString().Replace('.', ','));
                    }
                    sqlUpit.Parameters["@OznakaMjeseca"].Value = Convert.ToInt32(red["P8"]);

                    //unos elelmenta za gop
                    if (red["P62"].ToString() == "0406")
                    {
                        sqlUpit.Parameters["@IDELEMENT"].Value = 9997;
                        sqlUpit.Parameters["@ELEMENTRAZDOBLJEOD"].Value = Convert.ToDateTime(red["P101"]);
                        sqlUpit.Parameters["@ELEMENTRAZDOBLJEDO"].Value = Convert.ToDateTime(red["P102"]);
                        sqlUpit.Parameters["@OBRSATI"].Value = 0;
                        sqlUpit.Parameters["@OBRSATNICA"].Value = 0;
                        sqlUpit.Parameters["@OBRPOSTOTAK"].Value = 0;
                        sqlUpit.Parameters["@OBRIZNOS"].Value = 0;
                        sqlUpit.Parameters["@IDVRSTAELEMENTA"].Value = 3;
                        sqlUpit.Parameters["@NAZIVVRSTAELEMENT"].Value = "Element GOP";
                        sqlUpit.Parameters["@NAZIVELEMENT"].Value = "Element GOP";
                    }

                    try
                    {
                        sqlUpit.ExecuteNonQuery();

                        #region unos drugog elementa ako je potrebno
                        if (red["P151"].ToString() == "19" && (red["P61"].ToString() == "0001" || red["P61"].ToString() == "0002" || red["P61"].ToString() == "0010") && red["P62"].ToString() == "0001")
                        {
                            sqlUpit.Parameters["@IDVRSTAELEMENTA"].Value = 1;
                            sqlUpit.Parameters["@NAZIVVRSTAELEMENT"].Value = "Neto";
                            sqlUpit.Parameters["@OBRIZNOS"].Value = Convert.ToDecimal(red["P152"].ToString().Replace('.', ','));
                            sqlUpit.Parameters["@NAZIVELEMENT"].Value = "Naknada za prijevoz";
                            sqlUpit.Parameters["@IDELEMENT"].Value = 52;
                            sqlUpit.Parameters["@OBRSATI"].Value = 0;

                            try
                            {

                                sqlUpit.ExecuteNonQuery();
                            }
                            catch (Exception greska)
                            {
                                if (greska.Message.Contains("Violation of PRIMARY KEY"))
                                {
                                    try
                                    {
                                        sqlUpit.CommandText = "Update ObracunElementi Set OBRSATI = OBRSATI + @OBRSATI, OBRIZNOS = OBRIZNOS + @OBRIZNOS " +
                                                              "Where IDRADNIK = @IDRADNIK And IDELEMENT = @IDELEMENT And ELEMENTRAZDOBLJEOD = @ELEMENTRAZDOBLJEOD And " + 
                                                              "ELEMENTRAZDOBLJEDO = @ELEMENTRAZDOBLJEDO AND IDOBRACUN = @IDOBRACUN";

                                        sqlUpit.ExecuteNonQuery();
                                    }
                                    catch
                                    {
                                        MessageBox.Show(greska.Message);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(greska.Message);
                                    return;
                                }
                            }
                        }
                        //dodano 04.03 provjeriti sa markom p62 dodano da gleda 0001
                        else if ((red["P151"].ToString() == "20" | red["P151"].ToString() == "26" | red["P151"].ToString() == "22") && 
                                  red["P61"].ToString() == "0001" && 
                                 (red["P62"].ToString() == "0021" | red["P62"].ToString() == "0025" | red["P62"].ToString() == "0001"))
                        {
                            sqlUpit.Parameters["@IDVRSTAELEMENTA"].Value = 1;
                            sqlUpit.Parameters["@NAZIVVRSTAELEMENT"].Value = "Neto";
                            sqlUpit.Parameters["@OBRIZNOS"].Value = Convert.ToDecimal(red["P152"].ToString().Replace('.', ','));
                            sqlUpit.Parameters["@NAZIVELEMENT"].Value = "COP Neto";
                            sqlUpit.Parameters["@IDELEMENT"].Value = 9998;
                            sqlUpit.Parameters["@OBRSATI"].Value = 0;

                            try
                            {

                                sqlUpit.ExecuteNonQuery();
                            }
                            catch (Exception greska)
                            {
                                if (greska.Message.Contains("Violation of PRIMARY KEY"))
                                {
                                    try
                                    {
                                        sqlUpit.CommandText = "Update ObracunElementi Set OBRSATI = OBRSATI + @OBRSATI, OBRIZNOS = OBRIZNOS + @OBRIZNOS " +
                                                              "Where IDRADNIK = @IDRADNIK And IDELEMENT = @IDELEMENT And ELEMENTRAZDOBLJEOD = @ELEMENTRAZDOBLJEOD And " +
                                                              "ELEMENTRAZDOBLJEDO = @ELEMENTRAZDOBLJEDO AND IDOBRACUN = @IDOBRACUN";

                                        sqlUpit.ExecuteNonQuery();
                                    }
                                    catch
                                    {
                                        MessageBox.Show(greska.Message);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(greska.Message);
                                    return;
                                }
                            }
                        }

                        #endregion
                    }
                    catch (Exception greska)
                    {
                        if (greska.Message.Contains("Violation of PRIMARY KEY"))
                        {
                            try
                            {
                                sqlUpit.CommandText = "Update ObracunElementi Set OBRSATI = OBRSATI + @OBRSATI, OBRIZNOS = OBRIZNOS + @OBRIZNOS " +
                                                      "Where IDRADNIK = @IDRADNIK And IDELEMENT = @IDELEMENT And ELEMENTRAZDOBLJEOD = @ELEMENTRAZDOBLJEOD And " + 
                                                      "ELEMENTRAZDOBLJEDO = @ELEMENTRAZDOBLJEDO AND IDOBRACUN = @IDOBRACUN";

                                sqlUpit.ExecuteNonQuery();
                            }
                            catch
                            {
                                MessageBox.Show(greska.Message);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(greska.Message);
                            return;
                        }
                    }
                }
            }

            public void ProvjeraIspravnostiPoreza(DataTable tblRadnici)
            {
                SqlCommand sqlUpit = new SqlCommand();
                sqlUpit.Connection = client.sqlConnection;
                sqlUpit.CommandType = CommandType.Text;

                sqlUpit.CommandText = "Select * From ObracunPorezi Where IDOBRACUN = '" + pSifraObracuna + "'";
                DataTable tblObracunPorezi = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlUpit);
                adapter.Fill(tblObracunPorezi);

                int id_radnika= 0;
                decimal porez_iz_tablice = 0;
                decimal razlika = 0;
                int brojac = 0;
                int id_porez = 0;
                decimal porez_iz_datoteke = 0;

                foreach (DataRow red1 in tblRadnici.Rows)
                {
                    brojac = 0;
                    id_radnika = VratiIDRadnika(red1["P4"].ToString());
                    porez_iz_tablice = 0;
                    razlika = 0;
                    porez_iz_datoteke = 0;

                    foreach (DataRow red_provjera in tblRadnici.Rows)
                    {
                        if (red1["P4"].ToString() == red_provjera["P4"].ToString())
                        {
                            brojac++;
                            porez_iz_datoteke += Convert.ToDecimal(red_provjera["P141"].ToString().Replace('.', ','));
                        }
                    }

                    if (id_radnika > 0)
                    {
                        id_porez = GetMaxIDPorez(id_radnika);

                        foreach (DataRow red in tblObracunPorezi.Rows)
                        {
                            if (id_radnika == Convert.ToInt32(red["IDRADNIK"]))
                            {
                                porez_iz_tablice += Convert.ToDecimal(red["OBRACUNATIPOREZ"]);
                            }
                        }

                        if (brojac > 1)
                        {
                            if (porez_iz_tablice != porez_iz_datoteke)
                            {
                                razlika = porez_iz_tablice - porez_iz_datoteke;

                                if (razlika < 0)//dodajemo vrijednost u tablicu na porez
                                {
                                    if (id_porez != 999)
                                    {

                                        sqlUpit.CommandText = "Update ObracunPorezi Set ObracunatiPorez = ObracunatiPorez + " + Math.Abs(razlika).ToString().Replace(',', '.') +
                                        ", OSNOVICAPOREZ = OSNOVICAPOREZ + 2200 Where IDOBRACUN = '" + pSifraObracuna + "' And IDRADNIK = '" + id_radnika + "' And IDPOREZ = '" + id_porez + "'";
                                        try
                                        {
                                            sqlUpit.ExecuteNonQuery();
                                            foreach (DataRow red in tblObracunPorezi.Rows)
                                            {
                                                if (id_radnika == Convert.ToInt32(red["IDRADNIK"]) && red["IDOBRACUN"].ToString() == pSifraObracuna && id_porez == Convert.ToInt32(red["IDPOREZ"]))
                                                {
                                                    red.BeginEdit();
                                                    red["OBRACUNATIPOREZ"] = Convert.ToDecimal(red["OBRACUNATIPOREZ"]) + Math.Abs(razlika);
                                                    red["OSNOVICAPOREZ"] = Convert.ToDecimal(red["OSNOVICAPOREZ"]) + 2200;
                                                    red.EndEdit();
                                                }
                                            }
                                            tblObracunPorezi.AcceptChanges();
                                        }
                                        catch (Exception greska)
                                        {
                                            MessageBox.Show(greska.Message);
                                            return;
                                        }
                                    }
                                }
                                else //oduzimamo vrijednost u tablicu porez
                                {
                                    if(id_porez != 999)
                                    {
                                        sqlUpit.CommandText = "Update ObracunPorezi Set ObracunatiPorez = ObracunatiPorez - " + Math.Abs(razlika).ToString().Replace(',', '.') +
                                        " Where IDOBRACUN = '" + pSifraObracuna + "' And IDRADNIK = '" + id_radnika + "' And IDPOREZ = '" + id_porez + "'";
                                        try
                                        {
                                            sqlUpit.ExecuteNonQuery();
                                        }
                                        catch (Exception greska)
                                        {
                                            MessageBox.Show(greska.Message);
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (porez_iz_tablice != Convert.ToDecimal(red1["P141"].ToString().Replace('.', ',')) && Convert.ToDecimal(red1["P141"]) > 0)
                            {
                                razlika = porez_iz_tablice - Convert.ToDecimal(red1["P141"].ToString().Replace('.', ','));

                                if (razlika < 0)//dodajemo vrijednost u tablicu na porez
                                {
                                    if (id_porez != 999)
                                    {
                                        sqlUpit.CommandText = "Update ObracunPorezi Set ObracunatiPorez = ObracunatiPorez + " + Math.Abs(razlika).ToString().Replace(',', '.') +
                                        " Where IDOBRACUN = '" + pSifraObracuna + "' And IDRADNIK = '" + id_radnika + "' And IDPOREZ = '" + id_porez + "'";
                                        try
                                        {
                                            sqlUpit.ExecuteNonQuery();
                                        }
                                        catch (Exception greska)
                                        {
                                            MessageBox.Show(greska.Message);
                                            return;
                                        }
                                    }
                                }
                                else //oduzimamo vrijednost u tablicu porez
                                {
                                    if (id_porez != 999)
                                    {
                                        sqlUpit.CommandText = "Update ObracunPorezi Set ObracunatiPorez = ObracunatiPorez - " + Math.Abs(razlika).ToString().Replace(',', '.') +
                                        " Where IDOBRACUN = '" + pSifraObracuna + "' And IDRADNIK = '" + id_radnika + "' And IDPOREZ = '" + id_porez + "'";
                                        try
                                        {
                                            sqlUpit.ExecuteNonQuery();
                                        }
                                        catch (Exception greska)
                                        {
                                            MessageBox.Show(greska.Message);
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private int GetMaxIDPorez(int id_radnika)
            {
                try
                {
                    return Convert.ToInt32(client.ExecuteScalar("Select MAX(IDPOREZ) From ObracunPorezi Where IDOBRACUN = '" + pSifraObracuna + "' And IDRADNIK = '" + id_radnika + "' And IDPOREZ < 900"));
                }
                catch
                {
                    return -1;
                }
            }

            private string VratiSljedeciBrojObracuna(string obracun)
            {
                return client.ExecuteScalar("Select MAX(SUBSTRING(IDOBRACUN, 9, 3)) + 1 From Obracun Where SUBSTRING(IDOBRACUN,0,9) = '" + obracun + "'").ToString();
            }

            private decimal GetOsnovicaPorezPostojeci(string obracun_id, int radnik_id, int porez_id)
            {
                try
                {
                    return Convert.ToDecimal(client.ExecuteScalar("Select OSNOVICAPOREZ From ObracunPorezi Where IDOBRACUN = '" + obracun_id + "' And IDRADNIK = '" + radnik_id + "' And IDPOREZ = " + porez_id));
                }
                catch
                {
                    return -1;
                }
            }

            private string VratiOpisPlacanjaPorez(int id)
            {
                return client.ExecuteScalar("Select OPISPLACANJAPOREZ From Porez Where IDPOREZ = '" + id + "'").ToString();
            }

            private string VratiSifraOpisaPlacanjaPorez(int id)
            {
                return client.ExecuteScalar("Select SIFRAOPISAPLACANJAPOREZ From Porez Where IDPOREZ = '" + id + "'").ToString();
            }

            private string VratiPrimateljPorez1(int id)
            {
                return client.ExecuteScalar("Select PRIMATELJPOREZ1 From Porez Where IDPOREZ = '" + id + "'").ToString();
            }

            private string VratiPrimateljPorez2(int id)
            {
                return client.ExecuteScalar("Select PRIMATELJPOREZ2 From Porez Where IDPOREZ = '" + id + "'").ToString();
            }

            private string VratiPZPorez(int id)
            {
                return client.ExecuteScalar("Select PZPOREZ From Porez Where IDPOREZ = '" + id + "'").ToString();
            }

            private string VratiMZPorez(int id)
            {
                return client.ExecuteScalar("Select MZPOREZ From Porez Where IDPOREZ = '" + id + "'").ToString();
            }

            private string VratiPOPorez(int id)
            {
                return client.ExecuteScalar("Select POPOREZ From Porez Where IDPOREZ = '" + id + "'").ToString();
            }

            private string VratiMOPorez(int id)
            {
                return client.ExecuteScalar("Select MOPOREZ From Porez Where IDPOREZ = '" + id + "'").ToString();
            }

            private decimal VratiPorezMjesecno(int id)
            {
                return Convert.ToDecimal(client.ExecuteScalar("Select POREZMJESECNO From Porez Where IDPOREZ = '" + id + "'").ToString().Replace('.', ','));
            }

            private string VratiNazivPorez(int id)
            {
                return client.ExecuteScalar("Select NAZIVPOREZ From Porez Where IDPOREZ = '" + id + "'").ToString();
            }

            private decimal VratiObracunatiPorez(decimal stopa, decimal osnovica)
            {
                return Math.Round((osnovica * stopa) / 100,2);
            }

            private decimal VratiStopuPoreza(int id)
            {
                return Convert.ToDecimal(client.ExecuteScalar("Select STOPAPOREZA From Porez Where IDPOREZ = '" + id + "'").ToString().Replace('.', ','));
            }

            private int VratiIDRadnika(string oib)
            {
                try
                {
                    return Convert.ToInt32(client.ExecuteScalar("Select IDRADNIK From Radnik Where OIB = '" + oib + "'"));
                }
                catch 
                {
                    return -1;
                }
            }

            private int VratiIDDoprinos(int brojac)
            {
                if (brojac == 0)
                {
                    return 1;
                }
                else if (brojac == 1)
                {
                    return 2;
                }
                else if (brojac == 2)
                {
                    return 4;
                }
                else if (brojac == 3)
                {
                    return 5;
                }
                else if (brojac == 4)
                {
                    return 6;
                }
                else
                {
                    return 7;
                }

            }

            private decimal VratiObracunatiDoprinos(DataRow red, int brojac)
            {
                if (brojac == 0)
                {
                    return Convert.ToDecimal(red["P121"].ToString().Replace('.', ','));
                }
                else if (brojac == 1)
                {
                    return Convert.ToDecimal(red["P122"].ToString().Replace('.', ','));
                }
                else if (brojac == 2)
                {
                    return Convert.ToDecimal(red["P124"].ToString().Replace('.', ','));
                }
                else if (brojac == 3)
                {
                    return Convert.ToDecimal(red["P125"].ToString().Replace('.', ','));
                }
                else if (brojac == 4)
                {
                    return Convert.ToDecimal(red["P129"].ToString().Replace('.', ','));
                }
                else
                {
                    return Convert.ToDecimal(red["P123"].ToString().Replace('.', ','));
                }
            }

            private string VratiZrnDoprinos(int brojac)
            {
                if (brojac == 0)
                {
                    return client.ExecuteScalar("Select ZRNDOPRINOS From Doprinos Where IDDOPRINOS = 1").ToString();
                }
                else if (brojac == 1)
                {
                    return client.ExecuteScalar("Select ZRNDOPRINOS From Doprinos Where IDDOPRINOS = 2").ToString();
                }
                else if (brojac == 2)
                {
                    return client.ExecuteScalar("Select ZRNDOPRINOS From Doprinos Where IDDOPRINOS = 4").ToString();
                }
                else if (brojac == 3)
                {
                    return client.ExecuteScalar("Select ZRNDOPRINOS From Doprinos Where IDDOPRINOS = 5").ToString();
                }
                else if (brojac == 4)
                {
                    return client.ExecuteScalar("Select ZRNDOPRINOS From Doprinos Where IDDOPRINOS = 6").ToString();
                }
                else
                {
                    return client.ExecuteScalar("Select ZRNDOPRINOS From Doprinos Where IDDOPRINOS = 7").ToString();
                }
            }

            private string VratiNazivDoprinos(int brojac)
            {
                if (brojac == 0)
                {
                    return client.ExecuteScalar("Select NAZIVDOPRINOS From Doprinos Where IDDOPRINOS = 1").ToString();
                }
                else if (brojac == 1)
                {
                    return client.ExecuteScalar("Select NAZIVDOPRINOS From Doprinos Where IDDOPRINOS = 2").ToString();
                }
                else if (brojac == 2)
                {
                    return client.ExecuteScalar("Select NAZIVDOPRINOS From Doprinos Where IDDOPRINOS = 4").ToString();
                }
                else if (brojac == 3)
                {
                    return client.ExecuteScalar("Select NAZIVDOPRINOS From Doprinos Where IDDOPRINOS = 5").ToString();
                }
                else if (brojac == 4)
                {
                    return client.ExecuteScalar("Select NAZIVDOPRINOS From Doprinos Where IDDOPRINOS = 6").ToString();
                }
                else
                {
                    return client.ExecuteScalar("Select NAZIVDOPRINOS From Doprinos Where IDDOPRINOS = 7").ToString();
                }
            }

            private decimal VratiStopa(int brojac)
            {
                if (brojac == 0)
                {
                    return Convert.ToDecimal(client.ExecuteScalar("Select STOPA From Doprinos Where IDDOPRINOS = 1").ToString().Replace('.', ','));
                }
                else if (brojac == 1)
                {
                    return Convert.ToDecimal(client.ExecuteScalar("Select STOPA From Doprinos Where IDDOPRINOS = 2").ToString().Replace('.', ','));
                }
                else if (brojac == 2)
                {
                    return Convert.ToDecimal(client.ExecuteScalar("Select STOPA From Doprinos Where IDDOPRINOS = 4").ToString().Replace('.', ','));
                }
                else if (brojac == 3)
                {
                    return Convert.ToDecimal(client.ExecuteScalar("Select STOPA From Doprinos Where IDDOPRINOS = 5").ToString().Replace('.', ','));
                }
                else if (brojac == 4)
                {
                    return Convert.ToDecimal(client.ExecuteScalar("Select STOPA From Doprinos Where IDDOPRINOS = 6").ToString().Replace('.', ','));
                }
                else
                {
                    return Convert.ToDecimal(client.ExecuteScalar("Select STOPA From Doprinos Where IDDOPRINOS = 7").ToString().Replace('.', ','));
                }
            }

            private string VratiPODoprinos(int brojac)
            {
                if (brojac == 0)
                {
                    return client.ExecuteScalar("Select PODOPRINOS From Doprinos Where IDDOPRINOS = 1").ToString();
                }
                else if (brojac == 1)
                {
                    return client.ExecuteScalar("Select PODOPRINOS From Doprinos Where IDDOPRINOS = 2").ToString();
                }
                else if (brojac == 2)
                {
                    return client.ExecuteScalar("Select PODOPRINOS From Doprinos Where IDDOPRINOS = 4").ToString();
                }
                else if (brojac == 3)
                {
                    return client.ExecuteScalar("Select PODOPRINOS From Doprinos Where IDDOPRINOS = 5").ToString();
                }
                else if (brojac == 4)
                {
                    return client.ExecuteScalar("Select PODOPRINOS From Doprinos Where IDDOPRINOS = 6").ToString();
                }
                else
                {
                    return client.ExecuteScalar("Select PODOPRINOS From Doprinos Where IDDOPRINOS = 7").ToString();
                }
            }

            private string VratiMODoprinos(int brojac)
            {
                if (brojac == 0)
                {
                    return client.ExecuteScalar("Select MODOPRINOS From Doprinos Where IDDOPRINOS = 1").ToString();
                }
                else if (brojac == 1)
                {
                    return client.ExecuteScalar("Select MODOPRINOS From Doprinos Where IDDOPRINOS = 2").ToString();
                }
                else if (brojac == 2)
                {
                    return client.ExecuteScalar("Select MODOPRINOS From Doprinos Where IDDOPRINOS = 4").ToString();
                }
                else if (brojac == 3)
                {
                    return client.ExecuteScalar("Select MODOPRINOS From Doprinos Where IDDOPRINOS = 5").ToString();
                }
                else if (brojac == 4)
                {
                    return client.ExecuteScalar("Select MODOPRINOS From Doprinos Where IDDOPRINOS = 6").ToString();
                }
                else
                {
                    return client.ExecuteScalar("Select MODOPRINOS From Doprinos Where IDDOPRINOS = 7").ToString();
                }
            }

            private string VratiMZDoprinos(int brojac)
            {
                if (brojac == 0)
                {
                    return client.ExecuteScalar("Select MZDOPRINOS From Doprinos Where IDDOPRINOS = 1").ToString();
                }
                else if (brojac == 1)
                {
                    return client.ExecuteScalar("Select MZDOPRINOS From Doprinos Where IDDOPRINOS = 2").ToString();
                }
                else if (brojac == 2)
                {
                    return client.ExecuteScalar("Select MZDOPRINOS From Doprinos Where IDDOPRINOS = 4").ToString();
                }
                else if (brojac == 3)
                {
                    return client.ExecuteScalar("Select MZDOPRINOS From Doprinos Where IDDOPRINOS = 5").ToString();
                }
                else if (brojac == 4)
                {
                    return client.ExecuteScalar("Select MZDOPRINOS From Doprinos Where IDDOPRINOS = 6").ToString();
                }
                else
                {
                    return client.ExecuteScalar("Select MZDOPRINOS From Doprinos Where IDDOPRINOS = 7").ToString();
                }
            }

            private string VratiPZDoprinos(int brojac)
            {
                if (brojac == 0)
                {
                    return client.ExecuteScalar("Select PZDOPRINOS From Doprinos Where IDDOPRINOS = 1").ToString();
                }
                else if (brojac == 1)
                {
                    return client.ExecuteScalar("Select PZDOPRINOS From Doprinos Where IDDOPRINOS = 2").ToString();
                }
                else if (brojac == 2)
                {
                    return client.ExecuteScalar("Select PZDOPRINOS From Doprinos Where IDDOPRINOS = 4").ToString();
                }
                else if (brojac == 3)
                {
                    return client.ExecuteScalar("Select PZDOPRINOS From Doprinos Where IDDOPRINOS = 5").ToString();
                }
                else if (brojac == 4)
                {
                    return client.ExecuteScalar("Select PZDOPRINOS From Doprinos Where IDDOPRINOS = 6").ToString();
                }
                else
                {
                    return client.ExecuteScalar("Select PZDOPRINOS From Doprinos Where IDDOPRINOS = 7").ToString();
                }
            }

            private string VratiPrimateljDoprinos1(int brojac)
            {
                if (brojac == 0)
                {
                    return client.ExecuteScalar("Select PRIMATELJDOPRINOS1 From Doprinos Where IDDOPRINOS = 1").ToString();
                }
                else if (brojac == 1)
                {
                    return client.ExecuteScalar("Select PRIMATELJDOPRINOS1 From Doprinos Where IDDOPRINOS = 2").ToString();
                }
                else if (brojac == 2)
                {
                    return client.ExecuteScalar("Select PRIMATELJDOPRINOS1 From Doprinos Where IDDOPRINOS = 4").ToString();
                }
                else if (brojac == 3)
                {
                    return client.ExecuteScalar("Select PRIMATELJDOPRINOS1 From Doprinos Where IDDOPRINOS = 5").ToString();
                }
                else if (brojac == 4)
                {
                    return client.ExecuteScalar("Select PRIMATELJDOPRINOS1 From Doprinos Where IDDOPRINOS = 6").ToString();
                }
                else
                {
                    return client.ExecuteScalar("Select PRIMATELJDOPRINOS1 From Doprinos Where IDDOPRINOS = 7").ToString();
                }
            }

            private string VratiPrimateljDoprinos2(int brojac)
            {
                if (brojac == 0)
                {
                    return client.ExecuteScalar("Select PRIMATELJDOPRINOS2 From Doprinos Where IDDOPRINOS = 1").ToString();
                }
                else if (brojac == 1)
                {
                    return client.ExecuteScalar("Select PRIMATELJDOPRINOS2 From Doprinos Where IDDOPRINOS = 2").ToString();
                }
                else if (brojac == 2)
                {
                    return client.ExecuteScalar("Select PRIMATELJDOPRINOS2 From Doprinos Where IDDOPRINOS = 4").ToString();
                }
                else if (brojac == 3)
                {
                    return client.ExecuteScalar("Select PRIMATELJDOPRINOS2 From Doprinos Where IDDOPRINOS = 5").ToString();
                }
                else if (brojac == 4)
                {
                    return client.ExecuteScalar("Select PRIMATELJDOPRINOS2 From Doprinos Where IDDOPRINOS = 6").ToString();
                }
                else
                {
                    return client.ExecuteScalar("Select PRIMATELJDOPRINOS2 From Doprinos Where IDDOPRINOS = 7").ToString();
                }
            }

            private string VratiSifraOpisaPlacanjaDoprinos(int brojac)
            {
                if (brojac == 0)
                {
                    return client.ExecuteScalar("Select SIFRAOPISAPLACANJADOPRINOS From Doprinos Where IDDOPRINOS = 1").ToString();
                }
                else if (brojac == 1)
                {
                    return client.ExecuteScalar("Select SIFRAOPISAPLACANJADOPRINOS From Doprinos Where IDDOPRINOS = 2").ToString();
                }
                else if (brojac == 2)
                {
                    return client.ExecuteScalar("Select SIFRAOPISAPLACANJADOPRINOS From Doprinos Where IDDOPRINOS = 4").ToString();
                }
                else if (brojac == 3)
                {
                    return client.ExecuteScalar("Select SIFRAOPISAPLACANJADOPRINOS From Doprinos Where IDDOPRINOS = 5").ToString();
                }
                else if (brojac == 4)
                {
                    return client.ExecuteScalar("Select SIFRAOPISAPLACANJADOPRINOS From Doprinos Where IDDOPRINOS = 6").ToString();
                }
                else
                {
                    return client.ExecuteScalar("Select SIFRAOPISAPLACANJADOPRINOS From Doprinos Where IDDOPRINOS = 7").ToString();
                }
            }

            private string VratiOpisPlacanjaDoprinos(int brojac)
            {
                if (brojac == 0)
                {
                    return client.ExecuteScalar("Select OPISPLACANJADOPRINOS From Doprinos Where IDDOPRINOS = 1").ToString();
                }
                else if (brojac == 1)
                {
                    return client.ExecuteScalar("Select OPISPLACANJADOPRINOS From Doprinos Where IDDOPRINOS = 2").ToString();
                }
                else if (brojac == 2)
                {
                    return client.ExecuteScalar("Select OPISPLACANJADOPRINOS From Doprinos Where IDDOPRINOS = 4").ToString();
                }
                else if (brojac == 3)
                {
                    return client.ExecuteScalar("Select OPISPLACANJADOPRINOS From Doprinos Where IDDOPRINOS = 5").ToString();
                }
                else if (brojac == 4)
                {
                    return client.ExecuteScalar("Select OPISPLACANJADOPRINOS From Doprinos Where IDDOPRINOS = 6").ToString();
                }
                else
                {
                    return client.ExecuteScalar("Select OPISPLACANJADOPRINOS From Doprinos Where IDDOPRINOS = 7").ToString();
                }
            }

            private string GetIDIpIdent(int id_radnik)
            {
                return client.ExecuteScalar("Select IDIPIDENT From Radnik Where IDRADNIK = " + id_radnik).ToString();
            }

            #endregion
        }

        #endregion


        internal bool ProvjeraJOPPD()
        {
            string has = "";
            try
            {
                has = client.ExecuteScalar("Select ID From JOPPDAObracun Where Vrsta = 2 And Obracun_ID = " + (int)pID).ToString();
            }
            catch { }

            if (has.Length > 0)
            { return false; }

            return true;
        }
    }
}
