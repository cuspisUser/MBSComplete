using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;

namespace JavnaNabava.BusinessLogic
{
    public class VrsteNabave : Base
    {
        SqlClient client = null;
        public VrsteNabave()
            : base()
        {
            client = new SqlClient();
        }

        #region Svojstva

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

        public static int pSelectedIndex
        {
            get;
            set;
        }

        #endregion

        #region DohvatPodataka

        /// <summary>
        /// Dohvat VrsteNabave za glavni grid
        /// </summary>
        /// <returns></returns>
        public DataTable GetVrsteNabaveMainGrid()
        {
            DataTable dtVrsteNabave = client.GetDataTable("Select ID, Naziv From JN_VrstaNabave");
            return dtVrsteNabave;
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// Brisanje VrsteNabave
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete From JN_VrstaNabave Where ID = @ID";

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
        /// Novi red za VrsteNabave
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into JN_VrstaNabave (Naziv) Values (@Naziv)";

            sqlUpit.Parameters.Add(new SqlParameter("@Naziv", pNaziv));

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
        /// Editiranje postojeceg reda za VrsteNabave
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update JN_VrstaNabave set Naziv = @Naziv Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@Naziv", pNaziv));

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
