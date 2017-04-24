using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;

namespace JavnaNabava.BusinessLogic
{
    public class NacinPlacanja : Base
    {
        SqlClient client = null;
        public NacinPlacanja()
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
        /// Dohvat NacinPlacanja za glavni grid
        /// </summary>
        /// <returns></returns>
        public DataTable GetNacinPlacanjaMainGrid()
        {
            DataTable dt = client.GetDataTable("Select ID, Naziv From JN_NacinPlacanja");
            return dt;
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// Brisanje NacinPlacanja
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete From JN_NacinPlacanja Where ID = @ID";

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
        /// Novi red za NacinPlacanja
        /// </summary>
        /// <returns></returns>
        public bool Insert(StringBuilder message)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("NacinPlacanja");
            sqlUpit.Transaction = transakcija;

            sqlUpit.CommandText = "Insert Into JN_NacinPlacanja (Naziv, TS) Values (@Naziv, @TS)";

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
        /// Editiranje postojeceg reda za NacinPlacanja
        /// </summary>
        /// <returns></returns>
        public bool Update(StringBuilder message)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Plan nabave");
            sqlUpit.Transaction = transakcija;

            sqlUpit.CommandText = "Update JN_NacinPlacanja set Naziv = @Naziv, TS = @TS Where ID = @ID";

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
