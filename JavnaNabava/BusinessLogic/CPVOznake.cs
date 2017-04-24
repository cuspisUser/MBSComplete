using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;

namespace JavnaNabava.BusinessLogic
{
    public class CPVOznake : Base
    {
        SqlClient client = null;
        public CPVOznake()
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

        #endregion

        #region DohvatPodataka

        /// <summary>
        /// Dohvat CPVOznaka za gglavni grid
        /// </summary>
        /// <returns></returns>
        public DataTable GetCPVOznakeMainGrid()
        {
            DataTable dtCPVOznake = client.GetDataTable("Select ID, Naziv From JN_CPV_Oznake");
            return dtCPVOznake;
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// Brisanje CPV oznake
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete From JN_CPV_Oznake Where ID = @ID";

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
        /// Novi red za CPV oznake
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into JN_CPV_Oznake (Naziv) Values (@Naziv)";

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
        /// Editiranje postojeceg reda za CPV oznake
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update JN_CPV_Oznake set Naziv = @Naziv Where ID = @ID";

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
