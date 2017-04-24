using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;

namespace JavnaNabava.BusinessLogic
{
    public class NacinIsporuke : Base
    {
        SqlClient client = null;
        public NacinIsporuke()
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
        /// Dohvat NacinIsporuke za glavni grid
        /// </summary>
        /// <returns></returns>
        public DataTable GetNacinIsporukeMainGrid()
        {
            DataTable dt = client.GetDataTable("Select ID, Naziv From JN_NacinIsporuke");
            return dt;
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// Brisanje NacinIsporuke
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete From JN_NacinIsporuke Where ID = @ID";

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
        /// Novi red za NacinIsporuke
        /// </summary>
        /// <returns></returns>
        public bool Insert(StringBuilder message)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("NacinIsporuke");
            sqlUpit.Transaction = transakcija;

            sqlUpit.CommandText = "Insert Into JN_NacinIsporuke (Naziv, TS) Values (@Naziv, @TS)";

            sqlUpit.Parameters.Add(new SqlParameter("@Naziv", pNaziv));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

            try
            {
                sqlUpit.ExecuteNonQuery();
                transakcija.Commit();
                return true;
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                transakcija.Rollback();
                return false;
            }
        }

        /// <summary>
        /// Editiranje postojeceg reda za NacinIsporuke
        /// </summary>
        /// <returns></returns>
        public bool Update(StringBuilder message)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Plan nabave");
            sqlUpit.Transaction = transakcija;

            sqlUpit.CommandText = "Update JN_NacinIsporuke set Naziv = @Naziv, TS =@TS Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@Naziv", pNaziv));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

            try
            {
                sqlUpit.ExecuteNonQuery();
                transakcija.Commit();
                return true;
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                transakcija.Rollback();
                return false;
            }
        }

        /// <summary>
        /// If value is DBNull, then return "returnValue"
        /// </summary>
        /// <param name="value">Value to cast</param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public static T IsDbNull<T>(object value)
        {
            if (value != DBNull.Value && value != null)
            {
                // return (T)value; // CAST
                return (T)Convert.ChangeType(value, typeof(T)); // CONVERT
            }

            return default(T);
        }

        #endregion

    }
}
