using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;

namespace JavnaNabava.BusinessLogic
{
    public class RegistarNabave : Base
    {
        SqlClient client = null;
        public RegistarNabave()
            : base()
        {
            client = new SqlClient();
        }

        #region Svojstva

        public static int? pID
        {
            get;
            set;
        }

        public static int? pID_VrstaNabave
        {
            get;
            set;
        }

        public static int? pID_CPV_Oznaka
        {
            get;
            set;
        }

        public static string pNaziv
        {
            get;
            set;
        }

        public static int? pID_Partner
        {
            get;
            set;
        }

        public static DateTime? pDatumPocetka
        {
            get;
            set;
        }

        public static int? pID_StopaPoreza
        {
            get;
            set;
        }

        public static decimal? pBezPDVa
        {
            get;
            set;
        }

        public static decimal? pSaPDVom
        {
            get;
            set;
        }

        public static DateTime? pDatumZavrsetka
        {
            get;
            set;
        }

        public static DateTime? pDatumIsporuke
        {
            get;
            set;
        }

        public static int? pID_RegistarNabave
        {
            get;
            set;
        }

        public static int? PID_OrganizacijskaJedinica
        {
            get;
            set;
        }

        public static int? pID_MjestoTroska
        {
            get;
            set;
        }

        public static string pEVR_Broj
        {
            get;
            set;
        }

        public static int? pID_EVR
        {
            get;
            set;
        }

        public static int pSelectedIndex
        {
            get;
            set;
        }

        #endregion

        #region DohvatPodataka

        /// <summary>
        /// Dohvat registra nabave za glavni grid
        /// </summary>
        /// <returns></returns>
        public DataTable GetRegistarNabaveMainGrid()
        {
            DataTable dtRegistarNabave = client.GetDataTable("Select JN_RegistarNabave.ID, JN_RegistarNabave.EVR_Broj As EVR, JN_VrstaNabave.Naziv As VrstaNabave, " +
                                         "JN_RegistarNabave.ID_CPV_Oznaka, '' As CPVOznaka, JN_RegistarNabave.Naziv, " +
                                         "PARTNER.NAZIVPARTNER As Partner, JN_RegistarNabave.DatumPocetka, JN_RegistarNabave.ID_StopaPoreza, '' As StopaPoreza, JN_RegistarNabave.BezPDVa, " + 
                                         "JN_RegistarNabave.SaPDVom, JN_RegistarNabave.DatumZavrsetka, JN_RegistarNabave.DatumIsporuke From JN_RegistarNabave " +
                                         "Inner Join JN_VrstaNabave on JN_RegistarNabave.ID_VrstaNabave = JN_VrstaNabave.ID " +
                                         "Inner Join PARTNER on JN_RegistarNabave.ID_Partner = PARTNER.IDPARTNER ");

            foreach (DataRow red in dtRegistarNabave.Rows)
            {
                if (red["ID_CPV_Oznaka"].ToString() != "")
                {
                    red["CPVOznaka"] = GetCPVOznakeByID(red["ID_CPV_Oznaka"].ToString());
                }
                if (red["ID_StopaPoreza"].ToString() != "")
                {
                    red["StopaPoreza"] = GetStopePorezaByID(red["ID_StopaPoreza"].ToString());
                }
            }

            return dtRegistarNabave;
        }

        /// <summary>
        /// Dohvat vrsta nabave za combobox
        /// </summary>
        /// <returns></returns>
        public DataTable GetVrsteNabave()
        {
            DataTable dtVrsteNabava = client.GetDataTable("Select ID, Naziv From JN_VrstaNabave");
            return dtVrsteNabava;
        }


        /// <summary>
        /// Dohvat CPV oznaka za combobox
        /// </summary>
        /// <returns></returns>
        public DataTable GetCPVOznake()
        {
            DataTable dtCPVOznake = client.GetDataTable("Select ID, Naziv From JN_CPV_Oznake");
            return dtCPVOznake;
        }

        public string GetCPVOznakeByID(string id)
        {
            DataTable dtCPVOznake = client.GetDataTable("Select Naziv From JN_CPV_Oznake Where ID = '" + id + "'");
            return dtCPVOznake.Rows[0]["Naziv"].ToString();
        }

        public string GetStopePorezaByID(string id)
        {
            DataTable dtStopePoreza = client.GetDataTable("Select FINPOREZNAZIVPOREZ As Naziv From FINPOREZ Where FINPOREZIDPOREZ = '" + id + "'");
            return dtStopePoreza.Rows[0]["Naziv"].ToString();
        }

        /// <summary>
        /// Dohvat partnera za combobox
        /// </summary>
        /// <returns></returns>
        public DataTable GetPartneri()
        {
            DataTable dtPartneri = client.GetDataTable("Select IDPARTNER As ID, NAZIVPARTNER As Naziv From PARTNER Where Ucenik = 0");
            return dtPartneri;
        }

        /// <summary>
        /// Dohvat stopa poreza za comobox
        /// </summary>
        /// <returns></returns>
        public DataTable GetStopePoreza()
        {
            DataTable dtStope = client.GetDataTable("Select FINPOREZIDPOREZ As ID, FINPOREZNAZIVPOREZ As Naziv, FINPOREZSTOPA As Stopa From FINPOREZ Order by FINPOREZSTOPA Desc");
            return dtStope;
        }

        /// <summary>
        /// Dohvat registra nabave po id-u
        /// </summary>
        /// <returns></returns>
        public bool RegistarNabaveByID()
        {
            DataTable dtRegistarNabave = client.GetDataTable("Select ID_VrstaNabave, ID_CPV_Oznaka, Naziv, ID_Partner, DatumPocetka, ID_StopaPoreza, BezPDVa, SaPDVom, " +
                                                             "DatumZavrsetka, DatumIsporuke, ID_EVR_Struktura, ID_OrganizacijskeJedinice, ID_MjestoTroska " + 
                                                             "From JN_RegistarNabave Where ID = '" + pID + "'");
            
            DataRow red = dtRegistarNabave.Rows[0];

            try
            {
                pID_VrstaNabave = (int)red["ID_VrstaNabave"];
                pNaziv = red["Naziv"].ToString();
                pID_Partner = (int)red["ID_Partner"];
                pDatumPocetka = (DateTime)red["DatumPocetka"];
                pBezPDVa = (decimal)red["BezPDVa"];
                pSaPDVom = (decimal)red["SaPDVom"];
                pID_EVR = (int)red["ID_EVR_Struktura"];
            }
            catch 
            {
                return false;
            }

            try
            {
                pDatumZavrsetka = (DateTime?)red["DatumZavrsetka"];
            }
            catch
            {
                pDatumZavrsetka = null;
            }
            try
            {
                pDatumIsporuke = (DateTime?)red["DatumIsporuke"];
            }
            catch
            {
                pDatumIsporuke = null;
            }
            try
            {
                pID_CPV_Oznaka = (int)red["ID_CPV_Oznaka"];
            }
            catch 
            {
                pID_CPV_Oznaka = null;
            }
            try
            {
                pID_StopaPoreza = (int)red["ID_StopaPoreza"];
            }
            catch
            {
                pID_StopaPoreza = null;
            }

            try
            {
                PID_OrganizacijskaJedinica = (int)red["ID_OrganizacijskeJedinice"];
            }
            catch
            {
                PID_OrganizacijskaJedinica = null;
            }

            try
            {
                pID_MjestoTroska = (int)red["ID_MjestoTroska"];
            }
            catch
            {
                pID_MjestoTroska = null;
            }

            return true;
        }

        public DataTable GetOrganizacijskaJedinica()
        {
            DataTable dtOrganizacijskaJedinica = client.GetDataTable("Select IDORGJED As ID, NAZIVORGJED As Naziv From ORGJED");
            return dtOrganizacijskaJedinica;
        }

        public DataTable GetMjestoTroska()
        {
            DataTable dtMjestoTroska = client.GetDataTable("Select IDMJESTOTROSKA As ID, NAZIVMJESTOTROSKA As Naziv From MJESTOTROSKA");
            return dtMjestoTroska;
        }

        public DataTable GetEVRStruktura()
        {
            DataTable dtEVRStruktura = client.GetDataTable("Select ID, Naziv From JN_EVR_Struktura");
            return dtEVRStruktura;
        }

        public DataRow GetEVRStrukturabyID(string id)
        {
            DataTable dtEVRStruktura = client.GetDataTable("Select OrganizacijskaJedinica, MjestoTroska From JN_EVR_Struktura Where ID = '" + id + "'");
            return dtEVRStruktura.Rows[0];
        }

        public int MaxIDRegistarNabave()
        {
            int broj = 0;
            DataTable dtEVRBroj = client.GetDataTable("Select Max(ID_RegistarNabave) As Broj From JN_RegistarNabave");

            if (dtEVRBroj.Rows.Count > 0)
            {
                if (dtEVRBroj.Rows[0]["Broj"] != DBNull.Value)
                {
                    broj = Convert.ToInt32(dtEVRBroj.Rows[0]["Broj"]);
                    return broj + 1;
                }
                else
                    return 1;
            }
            else
            {
                return 1;
            }
        }

        public DataRow EVRStrukturaByID()
        {
            DataTable dtEVRStruktura = client.GetDataTable("Select Pozicija_EVR, Separator_EVR, DuzinaBloka, OrganizacijskaJedinica, MjestoTroska, SeparatorBloka From " +
                                                           "JN_EVR_Struktura Where ID = '" + pID_EVR + "'");

            return dtEVRStruktura.Rows[0];
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// Brisanje RegistarNabave
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete From JN_RegistarNabave Where ID = @ID";

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

        /// <summary>
        /// Novi red za RegistarNabave
        /// </summary>
        /// <returns></returns>
        public bool Insert(StringBuilder message)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into JN_RegistarNabave (ID_VrstaNabave, ID_CPV_Oznaka, Naziv, ID_Partner, DatumPocetka, ID_StopaPoreza, BezPDVa, SaPDVom, DatumZavrsetka, " +
                                  "DatumIsporuke, TS, ID_EVR_Struktura, ID_RegistarNabave, ID_OrganizacijskeJedinice, ID_MjestoTroska, EVR_Broj) " +
                                  "Values (@ID_VrstaNabave, @ID_CPV_Oznaka, @Naziv, @ID_Partner, @DatumPocetka, @ID_StopaPoreza, @BezPDVa, @SaPDVom, @DatumZavrsetka, @DatumIsporuke, " +
                                  "@TS, @ID_EVR_Struktura, @ID_RegistarNabave, @ID_OrganizacijskeJedinice, @ID_MjestoTroska, @EVR_Broj)";

            sqlUpit.Parameters.Add(new SqlParameter("@ID_VrstaNabave", pID_VrstaNabave));
            if (pID_CPV_Oznaka != null)
                sqlUpit.Parameters.Add(new SqlParameter("@ID_CPV_Oznaka", pID_CPV_Oznaka));
            else
                sqlUpit.Parameters.Add(new SqlParameter("@ID_CPV_Oznaka", DBNull.Value));
            sqlUpit.Parameters.Add(new SqlParameter("@Naziv", pNaziv));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Partner", pID_Partner));
            sqlUpit.Parameters.Add(new SqlParameter("@DatumPocetka", pDatumPocetka));
            if (pID_StopaPoreza != null)
                sqlUpit.Parameters.Add(new SqlParameter("@ID_StopaPoreza", pID_StopaPoreza));
            else
                sqlUpit.Parameters.Add(new SqlParameter("@ID_StopaPoreza", DBNull.Value));
            sqlUpit.Parameters.Add(new SqlParameter("@BezPDVa", pBezPDVa));
            sqlUpit.Parameters.Add(new SqlParameter("@SaPDVom", pSaPDVom));
            if (pDatumZavrsetka != null)
                sqlUpit.Parameters.Add(new SqlParameter("@DatumZavrsetka", pDatumZavrsetka));
            else
                sqlUpit.Parameters.Add(new SqlParameter("@DatumZavrsetka", DBNull.Value));
            if (pDatumIsporuke != null)
                sqlUpit.Parameters.Add(new SqlParameter("@DatumIsporuke", pDatumIsporuke));
            else
                sqlUpit.Parameters.Add(new SqlParameter("@DatumIsporuke",DBNull.Value));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_EVR_Struktura", pID_EVR));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_RegistarNabave", pID_RegistarNabave));
            if (PID_OrganizacijskaJedinica != null)
                sqlUpit.Parameters.Add(new SqlParameter("@ID_OrganizacijskeJedinice", PID_OrganizacijskaJedinica));
            else
                sqlUpit.Parameters.Add(new SqlParameter("@ID_OrganizacijskeJedinice", DBNull.Value));
            if (pID_MjestoTroska != null)
                sqlUpit.Parameters.Add(new SqlParameter("@ID_MjestoTroska", pID_MjestoTroska));
            else
                sqlUpit.Parameters.Add(new SqlParameter("@ID_MjestoTroska", DBNull.Value));
            sqlUpit.Parameters.Add(new SqlParameter("@EVR_Broj", pEVR_Broj));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                return false;
            }
        }

        /// <summary>
        /// Editiranje postojeceg reda za RegistarNabave
        /// </summary>
        /// <returns></returns>
        public bool Update(StringBuilder message)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update JN_RegistarNabave Set ID_VrstaNabave = @ID_VrstaNabave, ID_CPV_Oznaka = @ID_CPV_Oznaka, Naziv = @Naziv, ID_Partner = @ID_Partner, " +
                                  "DatumPocetka = @DatumPocetka, ID_StopaPoreza = @ID_StopaPoreza, BezPDVa = @BezPDVa, SaPDVom = @SaPDVom, DatumZavrsetka = @DatumZavrsetka, " +
                                  "DatumIsporuke = @DatumIsporuke, TS = @TS Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_VrstaNabave", pID_VrstaNabave));
            if (pID_CPV_Oznaka != null)
                sqlUpit.Parameters.Add(new SqlParameter("@ID_CPV_Oznaka", pID_CPV_Oznaka));
            else
                sqlUpit.Parameters.Add(new SqlParameter("@ID_CPV_Oznaka", DBNull.Value));
            sqlUpit.Parameters.Add(new SqlParameter("@Naziv", pNaziv));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Partner", pID_Partner));
            sqlUpit.Parameters.Add(new SqlParameter("@DatumPocetka", pDatumPocetka));
            if (pID_StopaPoreza != null)
                sqlUpit.Parameters.Add(new SqlParameter("@ID_StopaPoreza", pID_StopaPoreza));
            else
                sqlUpit.Parameters.Add(new SqlParameter("@ID_StopaPoreza", DBNull.Value));
            sqlUpit.Parameters.Add(new SqlParameter("@BezPDVa", pBezPDVa));
            sqlUpit.Parameters.Add(new SqlParameter("@SaPDVom", pSaPDVom));
            if (pDatumZavrsetka != null)
                sqlUpit.Parameters.Add(new SqlParameter("@DatumZavrsetka", pDatumZavrsetka));
            else
                sqlUpit.Parameters.Add(new SqlParameter("@DatumZavrsetka", DBNull.Value));
            if (pDatumIsporuke != null)
                sqlUpit.Parameters.Add(new SqlParameter("@DatumIsporuke", pDatumIsporuke));
            else
                sqlUpit.Parameters.Add(new SqlParameter("@DatumIsporuke", DBNull.Value));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                return false;
            }
        }

        #endregion

    }
}
