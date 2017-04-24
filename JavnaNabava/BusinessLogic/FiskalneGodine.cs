using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;

namespace JavnaNabava.BusinessLogic
{
    public class FiskalneGodine : Base
    {
        SqlClient client = null;
        public FiskalneGodine()
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

        public static bool pAktivna
        {
            get;
            set;
        }

        #endregion

        #region DohvatPodataka

        /// <summary>
        /// Dohvat fiskalnih godina za glavni grid
        /// </summary>
        /// <returns></returns>
        public DataTable GetFiskalneGodineMainGrid()
        {
            DataTable dtVrsteNabave = client.GetDataTable("Select IDGODINE, GODINEAKTIVNA From GODINE");
            return dtVrsteNabave;
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// Brisanje fiskalnih godina
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete From GODINE Where IDGODINE = @IDGODINE";

            sqlUpit.Parameters.Add(new SqlParameter("@IDGODINE", pID));

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
        /// Novi red za fiskalne godine
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into GODINE (IDGODINE, GODINEAKTIVNA) Values (@IDGODINE, @GODINEAKTIVNA)";

            sqlUpit.Parameters.Add(new SqlParameter("@IDGODINE", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@GODINEAKTIVNA", pAktivna));

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
        /// Editiranje postojeceg reda za fiskalne godine
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update GODINE set GODINEAKTIVNA = @GODINEAKTIVNA Where IDGODINE = @IDGODINE";

            sqlUpit.Parameters.Add(new SqlParameter("@IDGODINE", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@GODINEAKTIVNA", pAktivna));

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
        /// Setiranje aktivnih fiskalnih godina na false prilikom  otvaranja nove fiskalne skolske godine
        /// </summary>
        public bool AktivnaSkolskaGodina()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update GODINE set GODINEAKTIVNA = 0";

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

        #endregion

    }
}
