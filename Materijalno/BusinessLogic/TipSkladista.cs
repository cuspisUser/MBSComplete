using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;

namespace Materijalno.BusinessLogic
{
    public class TipSkladista : Base, IDisposable
    {
        SqlClient client = null;
        public TipSkladista()
            : base()
        {
            client = new SqlClient();
        }

        public void Dispose()
        {
        }

        #region Properties

        public static int pID { get; set; }
        public string pNaziv { get; set; }
        public static int pSelectedIndex { get; set; }

        #endregion

        #region Work with data

        public DataTable GetMainGridData()
        {
            return client.GetDataTable("Select ID, Naziv From MT_TipSkladista");
        }

        public DataRow GetSelectedRow()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Select ID, Naziv From MT_TipSkladista Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            return client.GetDataTable(sqlUpit).Rows[0];
        }

        public bool Delete(StringBuilder message)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete from MT_TipSkladista Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch (SqlException greska)
            {
                message.Append(greska.Message);
                return false;
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                return false;
            }
        }

        public bool Insert(StringBuilder message, TipSkladista objekt)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Insert Into MT_TipSkladista (Naziv, TS) Values (@Naziv, @TS)";

            sqlUpit.Parameters.Add(new SqlParameter("@Naziv", objekt.pNaziv));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch (SqlException greska)
            {
                message.Append(greska.Message);
                return false;
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                return false;
            }
        }

        public bool Update(StringBuilder message, TipSkladista objekt)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Update MT_TipSkladista Set Naziv = @Naziv, TS = @TS Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@Naziv", objekt.pNaziv));
            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

            try
            {
                sqlUpit.ExecuteNonQuery();
                return true;
            }
            catch (SqlException greska)
            {
                message.Append(greska.Message);
                return false;
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                return false;
            }
        }

        public Nullable<T> IsDbNull<T>(object value) where T : struct
        {
            if (value != DBNull.Value && value != null)
            {
                // return (T)value; // CAST
                return (T)Convert.ChangeType(value, typeof(T)); // CONVERT
            }

            return null;
        }

        #endregion
    }
}
