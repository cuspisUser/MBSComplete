using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;

namespace JavnaNabava.BusinessLogic
{
    public class EVRStruktura : Base
    {
        SqlClient client = null;
        public EVRStruktura()
            : base()
        {
            client = new SqlClient();
        }

        #region Svojstva

        public static int pSelectedIndex
        {
            get;
            set;
        }

        public static int pID
        {
            get;
            set;
        }

        public static string pNaziv
        {
            get;
            set;
        }

        public static string pPozicija_EVR
        {
            get;
            set;
        }

        public static string pSeparator_EVR
        {
            get;
            set;
        }

        public static int? pDuzinaBloka
        {
            get;
            set;
        }

        public static bool pOrganizacijskaJedinica
        {
            get;
            set;
        }

        public static bool pMjestoTroska
        {
            get;
            set;
        }

        public static string pSeparatorBloka
        {
            get;
            set;
        }

        #endregion

        #region DohvatPodataka

        /// <summary>
        /// Dohvat EVRStruktura za glavni grid
        /// </summary>
        /// <returns></returns>
        public DataTable GetEVRStrukturaMainGrid()
        {
            DataTable dtEVRStruktura = client.GetDataTable("Select ID, Naziv From JN_EVR_Struktura");
            return dtEVRStruktura;
        }

        public bool EVRStrukturaByID()
        {
            DataTable dtEVRStruktura = client.GetDataTable("Select Naziv, Pozicija_EVR, Separator_EVR, DuzinaBloka, OrganizacijskaJedinica, MjestoTroska, SeparatorBloka From " +
                                                           "JN_EVR_Struktura Where ID = '" + pID + "'");

            DataRow red = dtEVRStruktura.Rows[0];

            try
            {
                pNaziv = red["Naziv"].ToString();
                pPozicija_EVR = red["Pozicija_EVR"].ToString();
                pSeparator_EVR = red["Separator_EVR"].ToString();
                pDuzinaBloka = Convert.ToInt32(red["DuzinaBloka"]);
                pOrganizacijskaJedinica = Convert.ToBoolean(red["OrganizacijskaJedinica"]);
                pMjestoTroska = Convert.ToBoolean(red["MjestoTroska"]);
                pSeparatorBloka = red["SeparatorBloka"].ToString();
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// Brisanje EVRStruktura
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete From JN_EVR_Struktura Where ID = @ID";

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
        /// Novi red za EVRStruktura
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Insert(StringBuilder message)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into JN_EVR_Struktura (Naziv, Pozicija_EVR, Separator_EVR, DuzinaBloka, OrganizacijskaJedinica, MjestoTroska, SeparatorBloka, TS) " +
                                  "Values (@Naziv, @Pozicija_EVR, @Separator_EVR, @DuzinaBloka, @OrganizacijskaJedinica, @MjestoTroska, @SeparatorBloka, @TS)";

            sqlUpit.Parameters.Add(new SqlParameter("@Naziv", pNaziv));
            sqlUpit.Parameters.Add(new SqlParameter("@Pozicija_EVR", pPozicija_EVR));
            sqlUpit.Parameters.Add(new SqlParameter("@Separator_EVR", pSeparator_EVR));
            sqlUpit.Parameters.Add(new SqlParameter("@DuzinaBloka", pDuzinaBloka));
            sqlUpit.Parameters.Add(new SqlParameter("@OrganizacijskaJedinica", pOrganizacijskaJedinica));
            sqlUpit.Parameters.Add(new SqlParameter("@MjestoTroska", pMjestoTroska));
            sqlUpit.Parameters.Add(new SqlParameter("@SeparatorBloka", pSeparatorBloka));
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

        /// <summary>
        /// Editiranje postojeceg reda za EVRStruktura
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Update(StringBuilder message)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update JN_EVR_Struktura Set Naziv = @Naziv, Pozicija_EVR = @Pozicija_EVR, Separator_EVR = @Separator_EVR, DuzinaBloka = @DuzinaBloka, " +
                                  "OrganizacijskaJedinica = @OrganizacijskaJedinica, MjestoTroska = @MjestoTroska, SeparatorBloka = @SeparatorBloka, TS = @TS Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@Naziv", pNaziv));
            sqlUpit.Parameters.Add(new SqlParameter("@Pozicija_EVR", pPozicija_EVR));
            sqlUpit.Parameters.Add(new SqlParameter("@Separator_EVR", pSeparator_EVR));
            sqlUpit.Parameters.Add(new SqlParameter("@DuzinaBloka", pDuzinaBloka));
            sqlUpit.Parameters.Add(new SqlParameter("@OrganizacijskaJedinica", pOrganizacijskaJedinica));
            sqlUpit.Parameters.Add(new SqlParameter("@MjestoTroska", pMjestoTroska));
            sqlUpit.Parameters.Add(new SqlParameter("@SeparatorBloka", pSeparatorBloka));
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
