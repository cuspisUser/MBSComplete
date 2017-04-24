using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Mipsed7.DataAccessLayer
{
    /// <summary>
    /// Matija Božičević - 09.08.2012.
    /// 
    /// Ova klasa se koristi za dohvat podataka iz baze.
    /// </summary>
    public class SqlClient
    {
        public readonly SqlConnection sqlConnection = new SqlConnection(string.Format(
            "Data Source={0};Initial Catalog={1};User ID={2};Password={3};Pooling=false;",
            Mipsed7.Core.ApplicationDatabaseInformation.ServerName,
            Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName,
            Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName,
            Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword));

        public SqlClient()
        {
            try
            {
                if (sqlConnection.State != System.Data.ConnectionState.Open)
                    sqlConnection.Open();
            }
            catch (SqlException e) { }
            catch (Exception ex) { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">Ukoliko želimo pristupiti nekoj drugoj bazi, koristi se ovaj konstruktor</param>
        public SqlClient(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);

            try
            {
                if (sqlConnection.State != System.Data.ConnectionState.Open)
                    sqlConnection.Open();
            }
            catch (SqlException e) { }
            catch (Exception ex) { }
        }

        /// <summary>
        /// Insert, Update, Delete and returns the number of rows affected
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>The number of rows affected</returns>
        public int ExecuteNonQuery(string sql)
        {
            int x = 0;
            try
            {
                SqlCommand comm = new SqlCommand(sql, sqlConnection);
                x = comm.ExecuteNonQuery();
            }
            catch (SqlException e) { }
            catch (Exception ex) { }

            return x;
        }

        /// <summary>
        /// Executes the query, and returns the first column of the first row in the 
        /// result set returned by the query. Additional columns or rows are ignored.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>The first column of the first row in the result set, or a null reference</returns>
        public object ExecuteScalar(string sql)
        {
            return new SqlCommand(sql, sqlConnection).ExecuteScalar();
        }

        public DataSet GetDataSet(string sql)
        {
            DataSet dataSet = new DataSet();

            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
            }
            catch (SqlException e) { }
            catch (Exception ex) { }

            return dataSet;
        }

        public DataSet GetDataSet(SqlCommand sqlCommand)
        {
            DataSet dataSet = new DataSet();

            sqlCommand.Connection = this.sqlConnection;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }

        public DataTable GetDataTable(string sql)
        {
            DataTable dataTable = new DataTable();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable GetDataTable(SqlCommand sqlCommand)
        {
            DataTable dataTable = new DataTable();

            sqlCommand.Connection = this.sqlConnection;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }

        public void CloseConnection()
        {
            if (this.sqlConnection.State != ConnectionState.Closed)
                this.sqlConnection.Close();

        }

        /// <summary>
        /// metoda za punjenje kombo boxa isključivo sa kolonama ID i Naziv
        /// </summary>
        /// <param name="dtTable"></param>
        /// <returns></returns>
        public List<FillCombo> ConvertDataTableToArrayList(DataTable dtTable)
        {
            List<FillCombo> izBaze = dtTable.AsEnumerable().Select(m => new FillCombo()
            {
                ID = m.Field<int>("ID"),
                Naziv = m.Field<string>("Naziv")
            }).ToList();
            return izBaze;
        }

        public class FillCombo
        {
            public int ID { get; set; }
            public string Naziv { get; set; }
        }

    }
}
