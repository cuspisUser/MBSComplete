using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace DosMigration
{
    class PutMipsedDB
    {
        enum Columns
        {
            IDRADNIK = 0,                                   // int
            TEKUCI = 1,                                     // nvarchar(10)
            IDBANKE = 2,                                    // int
            PREZIME = 3,                                    // nvarchar&(50)
            IME = 4,                                        // &nvarchar(50)
            IDSPOL = 5,                                     // int(FK)
            OPCINASTANOVANJAIDOPCINE = 6,                  // nvarchar(4)
            KOEFICIJENT = 7,                                // decimal(17,10)
            TJEDNIFONDSATI = 8,                             // smallmoney
            TJEDNIFONDSATISTAZ = 9,                         // smallmoney
            MBO = 10,                                        // nvarchar(50)
            JMBG = 11,                                       // nvarchar(13)
            DATUMRODJENJA = 12,                              // datetime
            DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI = 13,   // datetime
            DATUMPRESTANKARADNOGODNOSA = 14,                // datetime
            GODINESTAZA = 15,                               // smallint
            MJESECISTAZA = 16,                              // smallint
            DANISTAZA = 17,                                 // smallint
            AKTIVAN = 18,                                   // bit
            MJESTO = 19,                                    // nvarchar(50)
            ULICA = 20,                                     // nvarchar(50)
            KUCNIBROJ = 21,                                 // nvarchar(10)
            POSTOTAKOSLOBODJENJAODPOREZA = 22,              // smallmoney
            IDIPIDENT = 23,                                 // int(FK)
            OIB = 24,                                       // nvarchar(11)
            OPCINARADAIDOPCINE = 25,                        // nvarchar(4)
            RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = 26,// int
            ZBIRNINETO = 27,                                // bit
            SIFRAOPISAPLACANJANETO = 28,                    // nvarchar
            OPISPLACANJANETO = 29,                          // nvarchar
            UZIMAUOBZIROSNOVICEDOPRINOSA = 30,              // bit
            IDBENEFICIRANI = 31                             // nvarchar
        }

        private Boolean executeQuery(String query)
        {
            using (SqlConnection connection = new SqlConnection(DosMigration.Properties.Settings.Default.MIPSED7ConnectionString))
            {
                Boolean execution = true;

                connection.Open();

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
                    execution = false;
                }
                finally
                {
                    connection.Close();
                }

                return execution;
            }
        }

        public void putDB(DataGridView dataGridView1, DataGridView dataGridView2, DataGridView dataGridView3, DataGridView dataGridView5, ToolStripComboBox toolStripComboBox, bool imeRadnika)
        {
            MessageBox.Show("Molimo Vas za strpljenje dok se migracija podataka izvršava...", "Migracija podataka");

            //using (SqlConnection connection = new SqlConnection(DosMigration.Properties.Settings.Default.MIPSED7ConnectionString))
            //{
            //connection.Open();

            int rowIndex = 0;
            int rowException = 0;

            setYellow(dataGridView2);

            foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
            {
                String[] queries = { "", "" };
                queries = prepareQuery(dataGridViewRow, dataGridView2, dataGridView3, dataGridView5, toolStripComboBox, imeRadnika);
                String query = queries[0];

                //try
                // {
                //     using (SqlCommand command = new SqlCommand(query, connection))
                //     {
                //         command.ExecuteNonQuery();
                //     }

                //     dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                // }
                // catch /*(Exception ex)*/
                // {
                //     //MessageBox.Show("Slijedeći unos nije bio uspješan:\n\n"+ query + "\n\n" + ex.ToString() + "\n\nNastavak importa...", "Greška pri migraciji podataka");
                //     dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                //     rowException++;
                //     //break;
                // }

                if (!executeQuery(query))
                {
                    dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    rowException++;
                }
                else
                {
                    dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                }

                rowIndex++;

                if (rowIndex == dataGridView1.RowCount - 1)
                {
                    if ((rowIndex + rowException) == dataGridView1.RowCount - 1)
                        MessageBox.Show("Migracija podataka je uspješno izvršena.", "Migracija podataka");
                    else
                        MessageBox.Show("Migracija je izvršena. Od ukupno " + (dataGridView1.RowCount - 1).ToString() + " redaka " + (dataGridView1.RowCount - 1 - rowException).ToString() + " su uspješno importirani, " + rowException.ToString() + " redaka nisu importirani u MIPSED 7 bazu podataka te su kao takvi žuto označeni.", "Migracija podataka");
                    break;
                }

                if (queries[1] != "")
                {
                    executeQuery(queries[1]);
                }
            }
            //}
        }

        private String getBanka(String nazivBanke, DataGridView dataGridView3)
        {
            String sifraBanke = "0";

            //String[] banks = { 
            //                   "ZAGREBAČKA", "ZAGREBACKA", "ZABA", // ZAGREBAČKA BANKA
            //                   "PRIVREDNA", "PBZ",  // PRIVREDNA BANKA
            //                   "RAIFFEISEN", "RBA", // RAIFFEISEN BANK
            //                   "ERSTE",  // ERSTE S. BANK
            //                   "HPB", "POŠTA", "POSTA",  // HPB d.d.
            //                   "SPLITSKA",  // SPLITSKA BANKA
            //                   "OTP",  // OTP BANKA d.d.
            //                   "MEĐIMUR", "MEDIMUR", "MEDJIMUR",  // MEĐIMURSKA BANKA
            //                   "SONIC",  // BANKA SONIC
            //                   "KVARNER",  // KVARNER BANKA
            //                   "KOVANICA",  // BANKA KOVANICA
            //                   "DALM" , "BSD",  // BANKA SPLITSKO-DALMATINSKA
            //                   "CENTAR",  // CENTAR BANKA
            //                   "PARTNER",  // PARTNER BANKA
            //                   "CREDO",  // CREDO BANKA
            //                   "CROATIA",  // CROATIA BANKA
            //                   "POŽEŠKA", "POZESKA",  // POŽEŠKA BANKA
            //                   "PRIMORSKA",  // PRIMORSKA BANKA
            //                   "GOSPODAR",  // GOSPODARSKO KREDITNA
            //                   "SAMOBOR",  // SAMOBORSKA BANKA
            //                   "IMEX",  // IMEX BANKA
            //                   "SLATIN",  // SLATINSKA BANKA
            //                   "ISTAR", "ISTRA",  // ISTARSKA KREDITNA
            //                   "SLAVON",  // SLAVONSKA BANKA
            //                   "JADRAN",  // JADRANSKA BANKA
            //                   "ŠTED" , "STED",  // ŠTEDBANKA
            //                   "VABA", "VARAŽDIN", "VARAZDIN",  // VABA BANKA VARAŽDIN
            //                   "KARLOV",  // KARLOVAČKA BANKA
            //                   "KREDIT",  // KREDITNA BANKA ZAGREB
            //                   "NOVA",  // NOVA BANKA
            //                   "BROD",  // BANKA BROD
            //                   "HYPO", "HAAB"  // HYPO ALPE ADRIA
            //                 };

            Dictionary<String, int> bank = new Dictionary<string, int>();
            bank.Add("ZAGREBAČKA", 1);
            bank.Add("ZAGREBACKA", 1);
            bank.Add("ZABA", 1);                // ZAGREBAČKA BANKA
            bank.Add("PRIVREDNA", 2);
            bank.Add("PBZ", 2);                 // PRIVREDNA BANKA
            bank.Add("RAIFFEISEN", 3);
            bank.Add("RBA", 3);                 // RAIFFEISEN BANK
            bank.Add("ERSTE", 4);
            bank.Add("ESB", 4);                 // ERSTE S. BANK
            bank.Add("HPB", 5);
            bank.Add("POŠTA", 5);
            bank.Add("POSTA", 5);              // HPB d.d.
            bank.Add("SPLITSKA", 6);
            bank.Add("SOCIÉTÉ", 6);
            bank.Add("SOCIETE", 6);
            bank.Add("SG", 6);                  // SPLITSKA BANKA
            bank.Add("OTP", 7);                 // OTP BANKA d.d.
            bank.Add("MEĐIMUR", 8);
            bank.Add("MEDIMUR", 8);
            bank.Add("MEDJIMUR", 8);
            bank.Add("MB", 8);                  // MEĐIMURSKA BANKA
            bank.Add("SONIC", 9);               // BANKA SONIC
            bank.Add("KVARNER", 10);           // KVARNER BANKA
            bank.Add("KOVANICA", 11);          // BANKA KOVANICA
            bank.Add("DALM", 12);
            bank.Add("BSD", 12);                // BANKA SPLITSKO-
            bank.Add("CENTAR", 13);             // CENTAR BANKA
            bank.Add("PARTNER", 14);
            bank.Add("PABA", 14);               // PARTNER BANKA
            bank.Add("PODRAV", 15);
            bank.Add("POBA", 15);               // PODRAVSKA BANKA
            bank.Add("CREDO", 16);              // CREDO BANKA
            bank.Add("CROATIA", 17);            // CROATIA BANKA
            bank.Add("POŽEŠKA", 18);
            bank.Add("POZESKA", 18);            // POŽEŠKA BANKA
            bank.Add("PRIMORSKA", 19);          // PRIMORSKA BANKA
            bank.Add("GOSPODAR", 20);           // GOSPODARSKO KREDITNA
            bank.Add("SAMOBOR", 21);
            bank.Add("SABA", 22);
            bank.Add("SABANK", 23);             // SAMOBORSKA BANKA
            bank.Add("IMEX", 24);               // IMEX BANKA
            bank.Add("SLATIN", 25);             // SLATINSKA BANKA
            bank.Add("ISTAR", 26);
            bank.Add("ISTRA", 26);
            bank.Add("UMAG", 26);               // ISTARSKA KREDITNA
            bank.Add("SLAVON", 27);             // SLAVONSKA BANKA
            bank.Add("JADRAN", 28);             // JADRANSKA BANKA
            bank.Add("ŠTED", 29);
            bank.Add("STED", 29);               // ŠTEDBANKA
            bank.Add("VABA", 30);
            bank.Add("VARAŽDIN", 30);
            bank.Add("VARAZDIN", 30);           // VABA BANKA VARAŽDIN
            bank.Add("KARLOV", 31);
            bank.Add("KABA", 31);               // KARLOVAČKA BANKA
            bank.Add("KREDIT", 32);
            bank.Add("KBZ", 32);                // KREDITNA BANKA ZAGREB
            bank.Add("NAVA", 33);               // NAVA BANKA
            bank.Add("BROD", 34);               // BANKA BROD
            bank.Add("HYPO", 35);
            bank.Add("HAAB", 35);               // HYPO ALPE ADRIA
            bank.Add("POPULARE", 36);
            bank.Add("BPC", 36);                // BANCO POPULARE CROATIA
            bank.Add("BKS", 37);                // BKS BANK
            bank.Add("PRIMOR", 38);             // PRIMORSKA BANKA
            bank.Add("TESLA", 39);              // TESLA ŠTEDNA BANKA
            bank.Add("VENETO", 40);             // VENETO BANKA
            bank.Add("VOLKS", 41);              // VOLKSBANK

            Boolean foundBank = false;

            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                //for (int j = 0; j < bank.Count(); j++)
                foreach (KeyValuePair<String, int> pair1 in bank)
                {
                    foreach (KeyValuePair<String, int> pair2 in bank)
                    {
                        if ((nazivBanke.ToUpper().Contains(pair1.Key)) &&
                            (dataGridView3[1, i].Value.ToString().ToUpper().Contains(pair2.Key)) &&
                            (pair1.Value == pair2.Value))
                        {
                            sifraBanke = dataGridView3[0, i].Value.ToString();
                            foundBank = true;
                            break;
                        }
                    }

                    if (foundBank)
                    {
                        break;
                    }
                }

                if (foundBank)
                {
                    break;
                }
            }

            return sifraBanke;
        }

        private String[] getTekuciBanka(String sifra, DataGridView dataGridView2, DataGridView dataGridView3)
        {
            string[] tekuciBanka = { "", "", "" };
            String tekuci = "";
            String banka = "0";

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                if (dataGridView2[0, i].Value.ToString() == sifra)
                {
                    if (dataGridView2[5, i].Value.ToString().Count() > 10)
                    {
                        tekuci = dataGridView2[5, i].Value.ToString().Remove(10);
                    }
                    else
                    {
                        tekuci = dataGridView2[5, i].Value.ToString();
                    }

                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.White;

                    banka = getBanka(dataGridView2[3, i].Value.ToString(), dataGridView3);

                    if ((tekuci != "\0") && (tekuci.Substring(0, 2) == "35"))
                    {
                        //executeQuery("INSERT INTO RadnikIzuzeceOdOvrhe(IDRADNIK, BANKAZASTICENOIDBANKE, ZADSIFRAOPISAPLACANJAIZUZECE, ZADOPISPLACANJAIZUZECE, ZADTEKUCIIZUZECE, ZADMOIZUZECE, ZADIZNOSIZUZECA) VALUES(" + sifra + ", " + banka + ", '','', " + tekuci + ", '', 0.00)");
                        tekuciBanka[2] = "INSERT INTO RadnikIzuzeceOdOvrhe(IDRADNIK, BANKAZASTICENOIDBANKE, ZADSIFRAOPISAPLACANJAIZUZECE, ZADOPISPLACANJAIZUZECE, ZADTEKUCIIZUZECE, ZADMOIZUZECE, ZADIZNOSIZUZECA) VALUES(" + sifra + ", " + banka + ", '','', " + tekuci + ", '', 0.00)";
                    }
                    else
                    {
                        tekuciBanka[0] = tekuci;
                        tekuciBanka[1] = banka;
                    }
                }
            }

            //tekuciBanka[0] = tekuci;
            //tekuciBanka[1] = banka;
            //tekuciBanka[2] = query2;

            return tekuciBanka;
        }

        private void setYellow(DataGridView dataGridView2)
        {
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
            }
        }

        private String[] prepareQuery(DataGridViewRow dataGridViewRow, DataGridView dataGridView2, DataGridView dataGridView3, DataGridView dataGridView5, ToolStripComboBox toolStripComboBox, bool imeRadnika)
        {
            String[] queries = { "", "" };
            String query = "INSERT INTO RADNIK(";
            String query2 = "";

            String sifra = "";

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
                    case 0:   // (SIFRA -> IDRADNIK) + (POZ_BRO_O -> TEKUCI)
                        String[] tekuciBanka = getTekuciBanka(cell.Value.ToString(), dataGridView2, dataGridView3);
                        sifra = cell.Value.ToString();
                        query += cell.Value.ToString() + ", '" + tekuciBanka[0] + "'," + tekuciBanka[1];
                        query2 = tekuciBanka[2];
                        i++;
                        i++;
                        break;

                    case 7:   // KOEF -> KOEFICIJENT
                    case 15:  // GODINA_1 -> GODINESTAZA
                    case 16:  // MJESEC_1 -> MJESECISTAZA
                    case 17:  // DANI_1 -> DANISTAZA
                    case 22:  // HRVI_POST -> POSTOTAKOSLOBODJENJAODPOREZA
                        if (cell.Value.ToString() != "")
                        {
                            query += cell.Value.ToString();
                        }
                        else
                        {
                            query += "0";
                        }
                        break;

                    case 3:  // NAZIV -> PREZIME + IME
                        String[] naziv = cell.Value.ToString().Split(' ');
                        String ime = "";
                        String prezime = "";

                        if (imeRadnika)
                        {
                            ime = naziv[naziv.Count() - 1];

                            for (int j = 0; j < naziv.Count() - 1; j++)
                            {
                                prezime += naziv[j];
                            }
                            query += "'" + prezime + "', '" + ime + "'";
                            i++;
                        }
                        else
                        {
                            ime = naziv[0];

                            for (int j = 1; j < naziv.Count(); j++)
                            {
                                prezime += naziv[j];
                            }
                            query += "'" + prezime + "', '" + ime + "'";
                            i++;
                        }
                        break;

                    case 5:  // SPOL -> IDSPOL
                        if (cell.Value.ToString().ToUpper() == "M")
                        {
                            query += "1";
                        }
                        else if (cell.Value.ToString().ToUpper() == "Ž")
                        {
                            query += "2";
                        }
                        break;


                    case 6:  // OPCINA_1 -> OPCINASTANOVANJAIDOPCINE
                        if (cell.Value.ToString() != "")
                        {
                            String opcina = getOpcina(cell.Value.ToString(), dataGridView5);
                            if (opcina != "")
                            {
                                query += "'" + getOpcina(cell.Value.ToString(), dataGridView5) + "'";
                            }
                            else
                            {
                                query += "'0'";
                            }
                        }
                        else
                        {
                            query += "'0'";
                        }
                        break;

                    case 8:  // FOND_SATI -> TJEDNIFONDSATI = TJEDNIFONDSATISTAZ
                        if (cell.Value.ToString() != "")
                        {
                            query += cell.Value.ToString() + ", " + cell.Value.ToString();
                        }
                        else
                        {
                            query += "0" + ", " + "0";
                        }
                        i++;
                        break;

                    case 10:   // MBO -> MBO
                    case 13:  // DAT_STAZ -> DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI
                    case 19:  // MJESTO_D -> MJESTO
                    case 20:  // ULICA1_D -> ULICA
                    case 21:  // KBR_D -> KUCNIBROJ
                    case 24:  // OIB -> OIB
                        query += "'" + cell.Value.ToString() + "'";
                        break;

                    case 14:  // DAT_PREST -> DATUMPRESTANKARADNOGODNOSA
                        if (cell.Value.ToString() != "")
                        {
                            query += "'" + cell.Value.ToString() + "'";
                        }
                        else
                        {
                            query += "null";
                        }
                        break;

                    case 11:   // JMBG -> JMBG + DATUMRODJENJA
                        String jmbg = cell.Value.ToString();
                        query += "'" + jmbg + "', ";
                        Match match = Regex.Match(jmbg, @"([0-9]){13}$", RegexOptions.IgnoreCase);
                        if ((jmbg.Count() == 13) && (match.Success))
                        {
                            if (jmbg.Substring(4, 1) == "9")
                            {
                                query += "'" + "1" + jmbg.Substring(4, 3) + jmbg.Substring(2, 2) + jmbg.Substring(0, 2) + "'";
                            }
                            else
                            {
                                query += "'" + "2" + jmbg.Substring(4, 3) + jmbg.Substring(2, 2) + jmbg.Substring(0, 2) + "'";
                            }
                        }
                        i++;
                        break;

                    case 18:  // RAD_RADI -> AKTIVAN
                        if (cell.Value.ToString().Trim() == "")
                        {
                            query += "1";
                        }
                        // ne prebaciti radnike koje više nisu aktivni (MANTIS #37)
                        //else if (cell.Value.ToString().Trim().ToUpper() == "N")
                        //{
                        //    query += "0";
                        //}
                        break;

                    case 23:  // PK2 -> IDIPIDENT
                        if (cell.Value.ToString().Trim().ToUpper() == "D")
                        {
                            query += "2";
                        }
                        else
                        {
                            query += "1";
                        }
                        break;

                }

                query += ", ";
                i++;
            }

            //case 25:  // OPCINARADAIDOPCINE
            if (toolStripComboBox.Text != "")
            {
                query += "'" + toolStripComboBox.Text.Substring(0, 4) + "', ";
            }
            else
            {
                query += "'0', ";
            }

            //case 25:  // OPCINASTANOVANJAIDOPCINE  -> new case 6
            //query += "'0', ";

            //case 26:  // RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA
            query += "1, ";

            //case 25:  // IDBANKE
            //query += "0, ";

            //case 26:  // TEKUCI
            //query += "'', ";

            //case 27:  // ZBIRNINETO
            query += "1, ";

            //case 28:  // SIFRAOPISAPLACANJANETO
            query += "'16', ";

            //case 29:  // OPISPLACANJANETO
            query += "'Sredstva za isplatu plaće', ";

            //case 30:  // UZIMAUOBZIROSNOVICEDOPRINOSA
            query += "0, ";

            //case 31:  // IDBENEFICIRANI
            query += "'0'";

            //query = query.Remove(query.Count() - 2) + ")";
            query += ")";

            queries[0] = query;
            queries[1] = query2;

            //if (sifra == "137")
            //{

            //}

            return queries;
        }

        private String getOpcina(String opcinaDOS, DataGridView dataGridView5)
        {
            String opcinaMIPSED = "";

            for (int i = 0; i < dataGridView5.Rows.Count - 1; i++)
            {
                if (dataGridView5[0, i].Value.ToString() == opcinaDOS)
                {
                    opcinaMIPSED = dataGridView5[1, i].Value.ToString();
                    break;
                }
            }

            return opcinaMIPSED;
        }
    }
}
