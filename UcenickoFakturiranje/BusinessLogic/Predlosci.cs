using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class Predlosci : Base
    {
        public Predlosci()
            : base()
        {
        }

        #region Svojstva

        public static int pSelectedIndex
        {
            get;
            set;
        }

        public static int pId_predlozak
        {
            get;
            set;
        }
        public static string pNaziv
        {
            get;
            set;
        }
        public static int? pId_ustanova_skolska_godina
        {
            get;
            set;
        }
        public static bool pAktivan
        {
            get;
            set;
        }

        public static int? pIDRazrednoOdjeljenje
        { 
            get; 
            set; 
        }

        public static int? pIDUcenik
        {
            get;
            set;
        }

        public static int? pIDCjenik
        {
            get;
            set;
        }

        #endregion

        #region DohvatPodataka

        /// <summary>
        /// dohvat svih predlozaka
        /// </summary>
        /// <returns></returns>
        public DataSet GetPredlosci()
        {
            SqlClient client = new SqlClient();
            DataSet ds = new DataSet();

            DataTable dtPredlosci = client.GetDataTable("SELECT * FROM v_UF_Predlosci");
            ds.Tables.Add(dtPredlosci);

            return ds;
        }

        /// <summary>
        /// dohvat ustanova i skolskih godina
        /// </summary>
        /// <returns></returns>
        public DataTable GetUstanoveSkolskeGodine()
        {
            SqlClient client = new SqlClient();

            DataTable dtUstanove = client.GetDataTable("SELECT DISTINCT UF_UstanovaSkolskaGodina.ID, UF_Ustanova.Naziv + ' - ' + UF_SkolskaGodina.Naziv AS SkolskaGodina FROM UF_SkolskaGodina " + 
                                   "INNER JOIN UF_UstanovaSkolskaGodina ON UF_SkolskaGodina.ID = UF_UstanovaSkolskaGodina.SkolskaGodinaID " + 
                                   "INNER JOIN UF_Ustanova ON UF_UstanovaSkolskaGodina.UstanovaID = UF_Ustanova.ID");
            return dtUstanove;
        }

        /// <summary>
        /// dohvat razreda i odjeljenja
        /// </summary>
        /// <returns></returns>
        public DataTable GetRazrediOdjeljenja(int id_skolska_godina)
        {
            SqlClient client = new SqlClient();

            DataTable dtRazredi = client.GetDataTable("SELECT DISTINCT UF_Razred.Naziv + UF_Odjeljenje.Naziv AS Razred, UF_UstanovaSkolskaGodinaRazredOdjeljenje.ID " +
                                  "FROM UF_UstanovaSkolskaGodinaRazredOdjeljenje INNER JOIN UF_Razred ON UF_UstanovaSkolskaGodinaRazredOdjeljenje.RazredID = UF_Razred.ID " + 
                                  "INNER JOIN UF_Odjeljenje ON UF_UstanovaSkolskaGodinaRazredOdjeljenje.OdjeljenjeID = UF_Odjeljenje.ID " + 
                                  "WHERE UF_UstanovaSkolskaGodinaRazredOdjeljenje.UstanovaSkolskaGodinaID = " + id_skolska_godina + " ORDER BY Razred");
            return dtRazredi;
        }

        /// <summary>
        /// dohvat ucenika za razredno odjeljenje
        /// </summary>
        /// <returns></returns>
        public DataTable GetuceniciOdjeljenje(int id_razredno_odjeljenje)
        {
            SqlClient client = new SqlClient();

            DataTable dtOdjeljenja = client.GetDataTable("SELECT 'false' as SEL, UF_Ucenik.ID, UF_Ucenik.Ime, UF_Ucenik.Prezime FROM UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik " + 
                                  "INNER JOIN UF_Ucenik ON UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik.UcenikID = UF_Ucenik.ID " +
                                  "WHERE UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik.UstanovaSkolskaGodinaRazredOdjeljenjeID = " + id_razredno_odjeljenje + " And UF_Ucenik.Aktivan = 1 Order By UF_Ucenik.Ime");
            return dtOdjeljenja;
        }

        /// <summary>
        /// dohvat cjenika
        /// </summary>
        /// <returns></returns>
        public DataTable GetCjenik()
        {
            SqlClient client = new SqlClient();

            DataTable dtCjenik = client.GetDataTable("SELECT UF_Cjenik.Naziv, UF_Cjenik.ID FROM UF_Cjenik ORDER BY Naziv");
            return dtCjenik;
        }

        /// <summary>
        /// dohvat stavke cjenika
        /// </summary>
        /// <returns></returns>
        public DataTable GetCjenikStavke(int id_cjenik)
        {
            SqlClient client = new SqlClient();

            DataTable dtCjenikStavke = client.GetDataTable("SELECT ID, Proizvod, JM, [Porezna stopa], [Jed. Cijena], Olakšica, Postotak, [Novčani iznos olakšice], [Cijena u cjeniku] " +
                                       "FROM V_UF_CJENIK_STAVKE_Predlozak WHERE CjenikID = " + id_cjenik);

            return dtCjenikStavke;
        }

        /// <summary>
        /// Dohvat predlozaka
        /// </summary>
        /// <param name="id_predloska"></param>
        /// <returns></returns>
        public DataRow DohvatPredloska(int id_predloska)
        {
            SqlClient client = new SqlClient();

            DataTable dtCjenik = client.GetDataTable("SELECT Naziv, IDUstanovaSkolskaGodina, IDRazrednoOdjeljenje FROM UF_Predlosci Where IDPredloska = " + id_predloska);
            return dtCjenik.Rows[0];
        }

        /// <summary>
        /// Dohvat stavaka za predloske
        /// </summary>
        /// <param name="id_predloska"></param>
        /// <returns></returns>
        public DataTable DohvatPredloskaStavke(int id_predloska)
        {
            SqlClient client = new SqlClient();

            DataTable dtCjenik = client.GetDataTable("SELECT dbo.UF_Predlosci.IDRazrednoOdjeljenje, dbo.UF_PredlosciStavke.IDUcenik, dbo.UF_PredlosciStavke.IDCjenik FROM " +
                                 "dbo.UF_PredlosciStavke INNER JOIN dbo.UF_Predlosci ON dbo.UF_PredlosciStavke.IDPredloska = dbo.UF_Predlosci.IDPredloska " +
                                 "WHERE (dbo.UF_PredlosciStavke.IDPredloska = '" + id_predloska + "')");
            return dtCjenik;
        }

        /// <summary>
        /// Dohvat podataka za cjenik stavke po uceniku
        /// </summary>
        /// <param name="id_ucenika"></param>
        /// <returns></returns>
        public DataSet NapuniStavkeCjenikZaUcenika(int id_ucenika)
        {
            SqlClient sql = new SqlClient();
            DataSet ds = new DataSet();

            DataTable UF_Cjenik = sql.GetDataTable("Select Distinct UF_PredlosciStavke.IDCjenik, UF_Cjenik.Naziv From UF_PredlosciStavke INNER JOIN " +
                                                   "UF_Cjenik on UF_PredlosciStavke.IDCjenik = UF_Cjenik.ID  Where IDUcenik = '" + id_ucenika + "'");

            UF_Cjenik.TableName = "Cjenik";

            DataTable UF_Stavka = sql.GetDataTable("SELECT Distinct ID, CjenikID, Proizvod, JM, [Porezna stopa], [Jed. Cijena], Olakšica, Postotak, [Novčani iznos olakšice] " +
                                  "[Cijena u cjeniku] From V_UF_CJENIK_STAVKE_Predlozak INNER JOIN UF_PredlosciStavke on V_UF_CJENIK_STAVKE_Predlozak.CjenikID = UF_PredlosciStavke.IDCjenik " +
                                  "Where UF_PredlosciStavke.IDUcenik = '" + id_ucenika + "'");

            UF_Stavka.TableName = "Stavke";

            ds.Tables.Add(UF_Cjenik);
            ds.Tables.Add(UF_Stavka);

            DataRelation rel1 = new DataRelation("Cjenik_stavka", UF_Cjenik.Columns["IDCjenik"], UF_Stavka.Columns["CjenikID"]);

            ds.Relations.Add(rel1);

            return ds;
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// Upis novog reda predloska u bazu
        /// </summary>
        /// <returns></returns>
        public bool InsertPredlosci()
        {
            SqlClient client = new SqlClient();
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into UF_Predlosci ([Naziv], [IDUstanovaSkolskaGodina], [IDRazrednoOdjeljenje], [Aktivan],[TS]) Values(@Naziv, @IDUstanovaSkolskaGodina, @IDRazrednoOdjeljenje, @Aktivan, @TS) " +
                                  "Select @@Identity";

            sqlUpit.Parameters.Add(new SqlParameter("@Naziv", pNaziv));
            sqlUpit.Parameters.Add(new SqlParameter("@IDUstanovaSkolskaGodina", pId_ustanova_skolska_godina));
            sqlUpit.Parameters.Add(new SqlParameter("@IDRazrednoOdjeljenje", pIDRazrednoOdjeljenje));
            sqlUpit.Parameters.Add(new SqlParameter("@Aktivan", pAktivan));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

            try
            {
                pId_predlozak = Convert.ToInt32(sqlUpit.ExecuteScalar());
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Upis novog reda predloska stavke u bazu
        /// </summary>
        /// <returns></returns>
        public bool InsertPredlosciStavke()
        {
            SqlClient client = new SqlClient();
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into UF_PredlosciStavke ([IDPredloska], [IDUcenik], [IDCjenik], [TS]) " +
                                  "Values(@IDPredloska, @IDUcenik, @IDCjenik, @TS)";

            sqlUpit.Parameters.Add(new SqlParameter("@IDPredloska", pId_predlozak));
            sqlUpit.Parameters.Add(new SqlParameter("@IDUcenik", pIDUcenik));
            sqlUpit.Parameters.Add(new SqlParameter("@IDCjenik", pIDCjenik));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

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

        /// <summary>
        /// Editiranje postojeceg reda predloska
        /// </summary>
        /// <returns></returns>
        public bool UpdatePredlosci()
        {
            SqlClient client = new SqlClient();
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update UF_Predlosci Set Naziv = @Naziv, IDUstanovaSkolskaGodina = @IDUstanovaSkolskaGodina, IDRazrednoOdjeljenje = @IDRazrednoOdjeljenje, Aktivan = @Aktivan, TS = @TS Where IDPredloska = @IDPredloska";

            sqlUpit.Parameters.Add(new SqlParameter("@Naziv", pNaziv));
            sqlUpit.Parameters.Add(new SqlParameter("@IDUstanovaSkolskaGodina", pId_ustanova_skolska_godina));
            sqlUpit.Parameters.Add(new SqlParameter("@IDRazrednoOdjeljenje", pIDRazrednoOdjeljenje));
            sqlUpit.Parameters.Add(new SqlParameter("@Aktivan", pAktivan));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));
            sqlUpit.Parameters.Add(new SqlParameter("@IDPredloska", pId_predlozak));

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

        /// <summary>
        /// brisanje reda predloska stavke
        /// </summary>
        /// <returns></returns>
        public bool DeletePredlosciStavke()
        {
            SqlClient client = new SqlClient();
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Delete from UF_PredlosciStavke Where IDPredloska = @IDPredloska";

            sqlUpit.Parameters.Add(new SqlParameter("@IDPredloska", pId_predlozak));

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

        /// <summary>
        /// brisanje reda predloska
        /// </summary>
        /// <returns></returns>
        public bool DeletePredlosci()
        {
            DeletePredlosciStavke();
            SqlClient client = new SqlClient();
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Delete from UF_Predlosci Where IDPredloska = @IDPredloska";

            sqlUpit.Parameters.Add(new SqlParameter("@IDPredloska", pId_predlozak));

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

        /// <summary>
        /// Editiranje statusa aktivnosti predloska
        /// </summary>
        /// <param name="id_predloska"></param>
        /// <param name="aktivan"></param>
        /// <returns></returns>
        public bool UpdatePredlosciAktivnost(int id_predloska, bool aktivan)
        {
            SqlClient client = new SqlClient();
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update UF_Predlosci Set Aktivan = @Aktivan, TS = @TS Where IDPredloska = @IDPredloska";

            sqlUpit.Parameters.Add(new SqlParameter("@Aktivan", aktivan));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));
            sqlUpit.Parameters.Add(new SqlParameter("@IDPredloska", id_predloska));

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

        #region ProvjeraIspravnostiUnosa

        /// <summary>
        /// Provjera ispravnosti unosa
        /// </summary>
        /// <returns></returns>
        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();
            
            // naziv - not null
            if (string.IsNullOrEmpty(pNaziv))
            {
                message.Append(" - Naziv predloška je obavezno polje");
            }
            // ustanova - not null
            if (pId_ustanova_skolska_godina == null)
            {
                message.Append(" - Ustanova školska godina je obavezno polje");
            }
            // odjeljenje - not null
            if (pIDRazrednoOdjeljenje == null)
            {
                message.Append(" - Razredno odjeljenje je obavezno polje");
            }
            // cjenik - not null
            if (pIDCjenik == null)
            {
                message.Append(" - Cjenik je obavezno polje");
            }
            return message;
        }

        #endregion

    }
}
