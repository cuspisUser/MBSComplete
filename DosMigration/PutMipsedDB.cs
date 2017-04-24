using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient; 
using System.Windows.Forms;
using System.Drawing;

namespace DosMigration
{
    class PutMipsedDB
    {
        enum Columns
        {
            IDRADNIK = 0,                   // int
            PREZIME = 1,                    // nvarchar&(50)
            IME = 2,                        // &nvarchar(50)
            IDSPOL = 3,                     // int(FK)
            KOEFICIJENT = 4,                // decimal(17,10)
            TJEDNIFONDSATI = 5,             // smallmoney 
            MBO = 6,                        // nvarchar(50)
            JMBG = 7,                       // nvarchar(13)
            DATUMRODJENJA = 8,              // datetime
            DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI = 9,  // datetime
            DATUMPRESTANKARADNOGODNOSA = 10,  // datetime
            GODINESTAZA = 11,               // smallint
            MJESECISTAZA = 12,              // smallint
            DANISTAZA = 13,                 // smallint
            AKTIVAN = 14,                   // bit
            MJESTO = 15,                    // nvarchar(50)
            ULICA = 16,                     // nvarchar(50)
            KUCNIBROJ = 17,                 // nvarchar(10)
            POSTOTAKOSLOBODJENJAODPOREZA = 18,  // smallmoney
            IDIPIDENT = 19,                 // int(FK)
            OIB = 20,                       // nvarchar(11)
            OPCINARADAIDOPCINE = 21,        // nvarchar(4)
            OPCINASTANOVANJAIDOPCINE = 22,  // nvarchar(4)
            RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = 23,  // int
            IDBANKE = 24,                   // int
            TEKUCI = 25,                    // nvarchar  
            ZBIRNINETO = 26,                // bit
            SIFRAOPISAPLACANJANETO = 27,    // nvarchar
            OPISPLACANJANETO = 28,          // nvarchar
            UZIMAUOBZIROSNOVICEDOPRINOSA = 29,  // bit
            TJEDNIFONDSATISTAZ = 30,        // smallmoney
            IDBENEFICIRANI = 31             // nvarchar
        }

        public void putDB(DataGridView dataGridView)
        {
            MessageBox.Show("Migracija podataka je pokrenuta. Molimo Vas na strpljenje dok se ista izvršava...", "Migracija podataka");

            using (SqlConnection connection = new SqlConnection(DosMigration.Properties.Settings.Default.MIPSED7ConnectionString))
            {
                connection.Open();

                int rowIndex = 0;
                int rowException = 0;
 
                foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
                {
                    String query = prepareQuery(dataGridViewRow);

                    try
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    catch /*(Exception ex)*/
                    {
                        //MessageBox.Show("Slijedeći unos nije bio uspješan:\n\n"+ query + "\n\n" + ex.ToString() + "\n\nNastavak importa...", "Greška pri migraciji podataka");
                        dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        rowException++;
                        //break;
                    }

                    rowIndex++;

                    if (rowIndex == dataGridView.RowCount  - 1)
                    {
                        if ((rowIndex + rowException) == dataGridView.RowCount  - 1)
                            MessageBox.Show("Migracija podataka je uspješno izvršena.", "Migracija podataka");
                        else
                            MessageBox.Show("Migracija je izvršena. Od ukupno " + (dataGridView.RowCount - 1).ToString() + " redaka " + (dataGridView.RowCount - 1 - rowException).ToString() + " su uspješno importirani, " + rowException.ToString() + " redaka nisu importirani u MIPSED 7 bazu podataka te su kao takvi žuto označeni.", "Migracija podataka");
                        break;
                    }
                }
            }
        }

        private String prepareQuery(DataGridViewRow dataGridViewRow)
        {
            String query = "INSERT INTO RADNIK(";

            foreach (String column in Enum.GetNames(typeof(Columns)))
            {
                query += column + ", ";
            }

            query = query.Remove(query.Count() - 2) + ") VALUES(";

            int i = 0;

            foreach (DataGridViewCell cell in dataGridViewRow.Cells)
            {
                switch (i)
                {
                    case 0:   // SIFRA -> IDRADNIK
                    case 4:   // KOEF -> KOEFICIJENT
                    case 5:   // FOND_SATI -> TJEDNIFONDSATI
                    case 11:  // GODINA_1 -> GODINESTAZA
                    case 12:  // MJESEC_1 -> MJESECISTAZA
                    case 13:  // DANI_1 -> DANISTAZA
                    case 18:  // HRVI_POST -> POSTOTAKOSLOBODJENJAODPOREZA
                        if (cell.Value.ToString() != "")
                        {
                            query += cell.Value.ToString();
                        }
                        else 
                        {
                            query += "0";
                        }
                        break;
                    
                    case 1:  // NAZIV -> PREZIME + IME
                        String[] naziv = cell.Value.ToString().Split(' ');
                        String ime = naziv[naziv.Count() - 1];
                        String prezime = "";
                        for (int j = 0; j < naziv.Count() - 1; j++)
                        {
                            prezime += naziv[j];
                        }
                        query += "'" + prezime + "', '" + ime + "'";
                        i++;
                        break;
                    
                    case 3:  // SPOL -> IDSPOL
                        if (cell.Value.ToString().ToUpper() == "M")
                        {
                            query += "1";
                        }
                        else if (cell.Value.ToString().ToUpper() == "Ž")
                        {
                            query += "2";
                        }
                        break;    
                    
                    case 6:   // MBO -> MBO
                    case 9:   // DAT_STAZ -> DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI
                    case 10:  // DAT_PREST -> DATUMPRESTANKARADNOGODNOSA
                    case 15:  // MJESTO_D -> MJESTO
                    case 16:  // ULICA1_D -> ULICA
                    case 17:  // KBR_D -> KUCNIBROJ
                    case 20:  // OIB -> OIB
                        query += "'" + cell.Value.ToString() + "'";
                        break;

                    case 7:   // JMBG -> JMBG + DATUMRODJENJA
                        String jmbg = cell.Value.ToString();
                        query += "'" + jmbg + "', '";
                        if (jmbg.Substring(4, 1) == "9")
                        {
                            query += "1" + jmbg.Substring(4, 3) + jmbg.Substring(2, 2) + jmbg.Substring(0, 2) + "'";
                        }
                        else
                        {
                            query += "2" + jmbg.Substring(4, 3) + jmbg.Substring(2, 2) + jmbg.Substring(0, 2) + "'";
                        }
                        i++;
                        break;

                    case 14:  // RAD_RADI -> AKTIVAN
                        if (cell.Value.ToString().Trim() == "")
                        {
                            query += "1";
                        }
                        else if (cell.Value.ToString().Trim().ToUpper() == "N")
                        {
                            query += "0";
                        }
                        break;

                    case 19:  // PK2 -> IDIPIDENT
                        if (cell.Value.ToString().Trim().ToUpper() == "D")
                        {
                            query += "2";
                        }
                        else
                        {
                            query += "1";
                        }
                        break;

                    //case 21:  // OPCINARADAIDOPCINE
                    //    query += "'0'";
                    //    break;

                }

                query += ", ";
                i++;
            }

            //case 21:  // OPCINARADAIDOPCINE
            query += "'0', ";

            //case 22:  // OPCINASTANOVANJAIDOPCINE
            query += "'0', ";

            //case 23:  // RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA
            query += "1, ";

            //case 24:  // IDBANKE
            query += "0, ";

            //case 25:  // TEKUCI
            query += "'', ";

            //case 26:  // ZBIRNINETO
            query += "0, ";

            //case 27:  // SIFRAOPISAPLACANJANETO
            query += "'', ";

            //case 28:  // OPISPLACANJANETO
            query += "'', ";

            //case 29:  // UZIMAUOBZIROSNOVICEDOPRINOSA
            query += "0, ";

            //case 30:  // TJEDNIFONDSATISTAZ
            query += "0, ";

            //case 31:  // IDBENEFICIRANI
            query += "'0'";

            //query = query.Remove(query.Count() - 2) + ")";
            query += ")";

            return query;
        }

    }
}
