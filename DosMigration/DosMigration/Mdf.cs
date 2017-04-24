using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace DosMigration
{
    class Mdf
    {
        public Boolean getDataGrid(DataGridView dataGridView, String table)
        {
            Boolean succeed = false;
            String query = "SELECT * FROM " + table;

            using (SqlConnection connection = new SqlConnection(DosMigration.Properties.Settings.Default.MIPSED7ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataSet dataSet = new DataSet();


                connection.Open();

                try
                {
                    dataAdapter.Fill(dataSet, "table");
                }
                catch /*(Exception ex)*/
                {
                    //MessageBox.Show("Slijedeći unos nije bio uspješan:\n\n"+ query + "\n\n" + ex.ToString() + "\n\nNastavak importa...", "Greška pri migraciji podataka");
                    succeed = false;
                }
                finally
                {
                    connection.Close();
                    dataGridView.DataSource = dataSet;
                    dataGridView.DataMember = "table";
                }

                return succeed;
            }
        }
    }
}
