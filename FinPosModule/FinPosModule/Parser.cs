using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Windows.Forms;

namespace FinPosModule
{
    class Parser
    {
        private string txtFilePath;
        private List<Slog905Holder> listSlog905 = new List<Slog905Holder>();

        public Parser(String filePath)
        {
            this.txtFilePath = filePath;
            readtTxtFile(filePath);
            WriteInDataBase();
        }

        private void readtTxtFile(string filePath)
        {
            StreamReader objReader = new StreamReader(filePath, Encoding.GetEncoding(1250));
            string line = "";
            while (line != null)
            {
                line = objReader.ReadLine();
                odaberiSlog(line);
            }
            objReader.Close();

        }

        private void odaberiSlog(string line)
        {
            if (line != null)
            {
                int lineLenght = line.Length;
                string slog = line.Substring(lineLenght - 3, 3);
                switch (slog)
                {
                    case "900": //parserSloga900(line);
                        break;
                    case "903": //parserSloga903(line);
                        break;
                    case "905": parserSloga905(line);
                        break;
                    case "907":// parserSloga907(line);
                        break;
                    case "909": //parserSloga909(line);
                        break;
                    case "999": //parserSloga909(line);
                        break;
                    default:
                        break;
                }
            }

        }

        private void parserSloga900(string line)
        {
        }

        private void parserSloga903(string line)
        {
        }

        private void parserSloga905(string line)
        {
            string iznos = "";
            Slog905Holder slog905 = new Slog905Holder();

            slog905.predznak = line.Substring(0, 2);

            slog905.racunPrimateljaPlatitelja = line.Substring(2, 34);
            slog905.nazivPrimateljaPlatitelja = line.Substring(36, 70);
            slog905.adresaPrimateljaPlatitelja = line.Substring(106, 35);
            slog905.sjedistePrimateljaPlatitelja = line.Substring(141, 35);
            slog905.datumValute = line.Substring(176, 8);
            slog905.datumIzvrsenja = line.Substring(184, 8);

            iznos = line.Substring(227, 15).Insert(13, ",");
            if (slog905.predznak == "10")
            {
                slog905.iznos = "-" + iznos;
            }
            else
            {
                slog905.iznos = iznos;
            }
            slog905.pozivNaBrojPlatitelja = line.Substring(242, 26);
            slog905.pozivNaBrojPrimatelja = line.Substring(268, 26);
            slog905.sifraNamjene = line.Substring(294, 4);
            slog905.opisPlacanja = line.Substring(298, 140);

            listSlog905.Add(slog905);
        }

        private void parserSloga907(string line)
        {
        }

        private void parserSloga909(string line)
        {
        }

        private void parserSloga999(string line)
        {
        }

        private void WriteInDataBase()
        {
            //Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            //decimal iznos = 0;
            //string query = string.Empty;
            //string datum = DateTime.Now.ToString("yyyy-MM-dd");
            //int brojDokumenta = Convert.ToInt32(client.ExecuteScalar("Select Max(BROJDOKUMENTA + 1) From GKSTAVKA Where IDDOKUMENT = 4").ToString());
            //string datumPrijave = listSlog905[0].datumIzvrsenja.Substring(0, 4) + "-" + listSlog905[0].datumIzvrsenja.Substring(4, 2) + "-" + listSlog905[0].datumIzvrsenja.Substring(6, 2);
            //int godina = Convert.ToInt32(client.ExecuteScalar("Select IDGODINE From GODINE Where GODINEAKTIVNA = 1").ToString());

            //foreach (Slog905Holder slog905 in listSlog905)
            //{
            //    iznos += Convert.ToDecimal(slog905.iznos);
            //}

            //if (iznos > 0)
            //{
            //    query = "Insert Into GKSTAVKA ([DATUMDOKUMENTA],[BROJDOKUMENTA],[BROJSTAVKE],[IDDOKUMENT],[IDMJESTOTROSKA],[IDORGJED],[IDKONTO],[duguje]" +
            //            ",[DATUMPRIJAVE],[ZATVORENIIZNOS],[statusgk],[GKGODIDGODINE]) VALUES " +
            //            "('" + datum + "', " + brojDokumenta + ", 1, 4, 3, 3, '111213', " + iznos.ToString().Replace(',', '.') + ", '" + datumPrijave + "', 0, " + 
            //            "0, " + godina + ")";
            //}
            //else
            //{
            //    query = "Insert Into GKSTAVKA ([DATUMDOKUMENTA],[BROJDOKUMENTA],[BROJSTAVKE],[IDDOKUMENT],[IDMJESTOTROSKA],[IDORGJED],[IDKONTO],[duguje]" +
            //            ",[DATUMPRIJAVE],[ZATVORENIIZNOS],[statusgk],[GKGODIDGODINE]) VALUES " +
            //            "('" + datum + "', " + brojDokumenta + 1 + ", 1, 4, 3, 3, '111213', " + Math.Abs(iznos).ToString().Replace(',', '.') + ", '" + datumPrijave + "', 0, " +
            //            "0, " + godina + ")";
            //}

            //client.ExecuteNonQuery(query);

            MessageBox.Show("Automatski izvodi su u izradi!");
        }
    }

    class Slog905Holder
    {

        public string racunPrimateljaPlatitelja;
        public string nazivPrimateljaPlatitelja;
        public string adresaPrimateljaPlatitelja;
        public string sjedistePrimateljaPlatitelja;
        public string datumValute;
        public string datumIzvrsenja;
        public string iznos;
        public string pozivNaBrojPlatitelja;
        public string pozivNaBrojPrimatelja;
        public string sifraNamjene;
        public string opisPlacanja;
        public string predznak;
    }
}
