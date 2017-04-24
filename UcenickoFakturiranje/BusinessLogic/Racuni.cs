using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;
using Spire.Barcode;
using System.Drawing;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class Racuni : Base, IDisposable
    {
        SqlClient client = null;
        public Racuni()
            : base()
        {
            client = new SqlClient();
        }

        public void Dispose()
        {

        }

        #region Properties

        public static int pIDRacun { get; set; }
        public  int pIDPartner { get; set; }
        public static short pIDGodina { get; set; }
        public DateTime pDatum { get; set; }
        public DateTime pValuta { get; set; }
        public string pModel { get; set; }
        public string pPoziv { get; set; }
        public string pNapomena { get; set; }
        public decimal pUkupanIznos { get; set; }
        public static int pSelectedIndex { get; set; }
        public Dictionary<int, int> pOdabraniRacuni { get; set; }
        public static DataTable pRacuniStavke { get; set; }

        public int pCounter {get; set;}

        #endregion

        #region WorkWithData

        internal object GetGridData()
        {
            DataSet ds = new DataSet();

            DataTable dtMain = client.GetDataTable("Select Distinct 'false' As Ozn, IDRACUN, RACUNGODINAIDGODINE, Partner.NAZIVPARTNER, " + 
                    "DATUM, NAPOMENA, UkupanIznos, VezaRacunID, Vrsta, Zaduzen, VezaObracun From RACUN " + 
                    "Inner Join Partner On Racun.IDPARTNER = PARTNER.IDPARTNER Inner Join UF_ObracunStavka On RACUN.VezaObracun = UF_ObracunStavka.ObracunID " + 
                    "Where Vrsta In ('SU','UF') Order by RACUNGODINAIDGODINE Desc, IDRACUN Desc");

            DataTable dtRelation = client.GetDataTable("Select '' As None, RACUNRacunStavke.IDRACUN, RACUNRacunStavke.RACUNGODINAIDGODINE, BROJSTAVKE, NAZIVPROIZVODRACUN, CIJENARACUN, RABAT, FINPOREZSTOPARACUN, CijenaPDV, KOLICINA " +
                                   "From RACUNRacunStavke Inner Join Racun On RACUNRacunStavke.IDRACUN = RACUN.IDRACUN And RACUNRacunStavke.RACUNGODINAIDGODINE = RACUN.RACUNGODINAIDGODINE  Where Vrsta In ('SU','UF')");

            ds.Tables.Add(dtMain);
            ds.Tables.Add(dtRelation);


            DataRelation relation = new DataRelation("Racuni", new DataColumn[] { dtMain.Columns["IDRACUN"], dtMain.Columns["RACUNGODINAIDGODINE"] },
                                                               new DataColumn[] { dtRelation.Columns["IDRACUN"], dtRelation.Columns["RACUNGODINAIDGODINE"] });

            ds.Relations.Add(relation);
            return ds;
        }

        public DataTable GetPartner()
        {
            return client.GetDataTable("Select IDPARTNER As ID, NAZIVPARTNER As Naziv From PARTNER Where Ucenik = 1");
        }

        public DataTable GetProizvod()
        {
            return client.GetDataTable("Select ID, Naziv From UF_Proizvod");
        }

        public bool Update(StringBuilder message, Racuni objekt)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Racuni");

            sqlUpit.Transaction = transakcija;

            sqlUpit.CommandText = "Update RACUN Set IDPARTNER = @IDPARTNER, DATUM = @DATUM, VALUTA = @VALUTA, " +
                                  "MODEL = @MODEL, POZIV = @POZIV, NAPOMENA = @NAPOMENA, UkupanIznos = @UkupanIznos Where IDRACUN = @IDRACUN And RACUNGODINAIDGODINE = @RACUNGODINAIDGODINE";

            sqlUpit.Parameters.Add(new SqlParameter("@IDRACUN", pIDRacun));
            sqlUpit.Parameters.Add(new SqlParameter("@RACUNGODINAIDGODINE", pIDGodina));
            sqlUpit.Parameters.Add(new SqlParameter("@IDPARTNER", objekt.pIDPartner));
            sqlUpit.Parameters.Add(new SqlParameter("@DATUM", objekt.pDatum));
            sqlUpit.Parameters.Add(new SqlParameter("@VALUTA", objekt.pValuta));
            sqlUpit.Parameters.Add(new SqlParameter("@MODEL", objekt.pModel));
            sqlUpit.Parameters.Add(new SqlParameter("@POZIV", objekt.pPoziv));
            if (objekt.pNapomena == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@NAPOMENA", DBNull.Value));
            }
            else if (objekt.pNapomena.Length == 0)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@NAPOMENA", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@NAPOMENA", objekt.pNapomena));
            }
            
            sqlUpit.Parameters.Add(new SqlParameter("@UkupanIznos", objekt.pUkupanIznos));

            try
            {
                sqlUpit.ExecuteNonQuery();

                if (DeleteStavke(message, sqlUpit))
                {
                    if (InsertStavke(message, sqlUpit))
                    {
                        transakcija.Commit();
                        return true;
                    }
                    else
                    {
                        transakcija.Rollback();
                        return false;
                    }
                }
                else
                {
                    transakcija.Rollback();
                    return false;
                }

            }
            catch (SqlException greska)
            {
                message.Append(greska.Message);
                transakcija.Rollback();
                return false;
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                transakcija.Rollback();
                return false;
            }
        }

        private bool DeleteStavke(StringBuilder message, SqlCommand sqlUpit)
        {
            sqlUpit.Parameters.Clear();

            sqlUpit.CommandText = "Delete From RACUNRacunStavke Where IDRACUN = @IDRACUN And RACUNGODINAIDGODINE = @RACUNGODINAIDGODINE";
            sqlUpit.Parameters.Add(new SqlParameter("@IDRACUN", pIDRacun));
            sqlUpit.Parameters.Add(new SqlParameter("@RACUNGODINAIDGODINE", pIDGodina));

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

        private bool InsertStavke(StringBuilder message, SqlCommand sqlUpit)
        {
            if (BusinessLogic.Racuni.pRacuniStavke.Rows.Count > 0)
            {
                int brojStavke = 1;

                sqlUpit.Parameters.Clear();

                sqlUpit.Parameters.Add(new SqlParameter("@BrojStavke", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IDPROIZVOD", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@NAZIVPROIZVODRACUN", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@CIJENARACUN", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@RABAT", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@KOLICINA", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@FINPOREZSTOPARACUN", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@CijenaPDV", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IDRACUN", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@RACUNGODINAIDGODINE", ""));

                foreach (DataRow red in BusinessLogic.Racuni.pRacuniStavke.Rows)
                {
                    sqlUpit.CommandText = "Insert Into RACUNRacunStavke ([IDRACUN], [RACUNGODINAIDGODINE], [BROJSTAVKE], [IDPROIZVOD], [NAZIVPROIZVODRACUN], [CIJENARACUN], [RABAT], [KOLICINA], [FINPOREZSTOPARACUN], [CijenaPDV]) " +
                                          "Values (@IDRACUN, @RACUNGODINAIDGODINE, @BrojStavke, @IDPROIZVOD, @NAZIVPROIZVODRACUN, @CIJENARACUN, @RABAT, @KOLICINA, @FINPOREZSTOPARACUN, @CijenaPDV)";

                    sqlUpit.Parameters["@BrojStavke"].Value = brojStavke;
                    sqlUpit.Parameters["@IDPROIZVOD"].Value = Convert.ToInt32(red["IDPROIZVOD"]);
                    sqlUpit.Parameters["@NAZIVPROIZVODRACUN"].Value = red["NAZIVPROIZVODRACUN"].ToString();
                    sqlUpit.Parameters["@CIJENARACUN"].Value = Convert.ToDecimal(red["CIJENARACUN"]);
                    sqlUpit.Parameters["@RABAT"].Value = Convert.ToDecimal(red["RABAT"]);
                    sqlUpit.Parameters["@KOLICINA"].Value = Convert.ToDecimal(red["KOLICINA"]);
                    sqlUpit.Parameters["@FINPOREZSTOPARACUN"].Value = Convert.ToDecimal(red["FINPOREZSTOPARACUN"]);
                    sqlUpit.Parameters["@CijenaPDV"].Value = Convert.ToDecimal(red["CijenaPDV"]);
                    sqlUpit.Parameters["@IDRACUN"].Value =pIDRacun;
                    sqlUpit.Parameters["@RACUNGODINAIDGODINE"].Value = pIDGodina;

                    try
                    {
                        sqlUpit.ExecuteNonQuery();
                        brojStavke++;
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
                if (message.Length > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public DataRow GetSelected()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "SELECT [IDPARTNER], [DATUM], [VALUTA], [MODEL], [POZIV], [NAPOMENA], [UkupanIznos] FROM RACUN " + 
                                  "Where IDRACUN = @IDRACUN ANd RACUNGODINAIDGODINE = @RACUNGODINAIDGODINE";

            sqlUpit.Parameters.Add(new SqlParameter("@IDRACUN", pIDRacun));
            sqlUpit.Parameters.Add(new SqlParameter("@RACUNGODINAIDGODINE", pIDGodina));

            return client.GetDataTable(sqlUpit).Rows[0];
        }

        #endregion

        internal DataTable GetPostojeceStavke()
        {
            return client.GetDataTable("Select 'false' As SEL, BROJSTAVKE, IDPROIZVOD, NAZIVPROIZVODRACUN, CIJENARACUN, RABAT, KOLICINA, FINPOREZSTOPARACUN, CijenaPDV " +
                                       "From RACUNRacunStavke Where IDRACUN = '" + pIDRacun + "' And RACUNGODINAIDGODINE = '" + pIDGodina + "' Order by BROJSTAVKE");
        }

        internal object GetCijena(int proizvod)
        {
            return Convert.ToDecimal(client.ExecuteScalar("Select Cijena From UF_Proizvod Where ID = " + proizvod).ToString());
        }

        internal bool Storno()
        {
            DataTable stavkeRacun = client.GetDataTable("Select * From RACUNRacunStavke Where IDRACUN = '" + pIDRacun + "' And RACUNGODINAIDGODINE = '" + pIDGodina + "'");
            DataRow racun = client.GetDataTable("Select * From RACUN Where IDRACUN = '" + pIDRacun + "' And RACUNGODINAIDGODINE = '" + pIDGodina + "'").Rows[0];

            int activeYear = Convert.ToInt32(client.ExecuteScalar("Select IDGODINE From GODINE Where GODINEAKTIVNA = 1"));
            int brojRacuna = GetNextID(activeYear);
            decimal ukupanIznos = Convert.ToDecimal(racun["UkupanIznos"]) * -1;
            decimal kolicina;

            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Storno");

            sqlUpit.Transaction = transakcija;

            sqlUpit.CommandText = "Insert Into RACUN ([IDRACUN],[RACUNGODINAIDGODINE],[IDPARTNER],[DATUM],[VALUTA],[MODEL],[POZIV],[NAPOMENA],[ZAPREDUJAM],[Vrsta],[UkupanIznos],[VezaObracun],[VezaRacunID],[VezaRacunGodina], [Ustanova], [Zaduzen]) " +
                                  "Values (@IDRACUN, @RACUNGODINAIDGODINE, @IDPARTNER, @DATUM, @VALUTA, @MODEL, @POZIV, @NAPOMENA, @ZAPREDUJAM, @Vrsta, @UkupanIznos, @VezaObracun, @VezaRacunID, @VezaRacunGodina, @Ustanova, @Zaduzen)";

            sqlUpit.Parameters.Add(new SqlParameter("@IDRACUN", brojRacuna));
            sqlUpit.Parameters.Add(new SqlParameter("@RACUNGODINAIDGODINE", activeYear));
            sqlUpit.Parameters.Add(new SqlParameter("@IDPARTNER", racun["IDPARTNER"]));
            sqlUpit.Parameters.Add(new SqlParameter("@DATUM", DateTime.Now.Date));
            sqlUpit.Parameters.Add(new SqlParameter("@VALUTA", racun["Valuta"]));
            sqlUpit.Parameters.Add(new SqlParameter("@MODEL", racun["MODEL"]));
            sqlUpit.Parameters.Add(new SqlParameter("@POZIV", racun["POZIV"]));
            sqlUpit.Parameters.Add(new SqlParameter("@NAPOMENA", string.Format("Storno računa: {0}-{1}", racun["IDRACUN"].ToString(), racun["RACUNGODINAIDGODINE"].ToString())));
            sqlUpit.Parameters.Add(new SqlParameter("@UkupanIznos", ukupanIznos));
            sqlUpit.Parameters.Add(new SqlParameter("@ZAPREDUJAM", false));
            sqlUpit.Parameters.Add(new SqlParameter("@Vrsta", "SU"));
            sqlUpit.Parameters.Add(new SqlParameter("@VezaObracun", racun["VezaObracun"]));
            sqlUpit.Parameters.Add(new SqlParameter("@VezaRacunID", racun["IDRACUN"]));
            sqlUpit.Parameters.Add(new SqlParameter("@VezaRacunGodina", racun["RACUNGODINAIDGODINE"]));
            sqlUpit.Parameters.Add(new SqlParameter("@ustanova", racun["Ustanova"]));
            sqlUpit.Parameters.Add(new SqlParameter("@Zaduzen", false));

            try
            {
                sqlUpit.ExecuteNonQuery();

                sqlUpit.Parameters.Add(new SqlParameter("@BROJSTAVKE", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IDPROIZVOD", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@NAZIVPROIZVODRACUN", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@CIJENARACUN", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@RABAT", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@KOLICINA", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@FINPOREZSTOPARACUN", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@CijenaPDV", ""));

                foreach (DataRow row in stavkeRacun.Rows)
                {
                    sqlUpit.CommandText = "Insert Into RACUNRacunStavke ([IDRACUN],[RACUNGODINAIDGODINE],[BROJSTAVKE],[IDPROIZVOD],[NAZIVPROIZVODRACUN],[CIJENARACUN],[RABAT],[KOLICINA],[FINPOREZSTOPARACUN],[CijenaPDV]) Values " +
                                          "(@IDRACUN, @RACUNGODINAIDGODINE, @BROJSTAVKE, @IDPROIZVOD, @NAZIVPROIZVODRACUN, @CIJENARACUN, @RABAT, @KOLICINA, @FINPOREZSTOPARACUN, @CijenaPDV)";


                    kolicina = Convert.ToDecimal(row["KOLICINA"]) * -1;

                    sqlUpit.Parameters["@BROJSTAVKE"].Value = row["BROJSTAVKE"].ToString();
                    sqlUpit.Parameters["@IDPROIZVOD"].Value = row["IDPROIZVOD"];
                    sqlUpit.Parameters["@NAZIVPROIZVODRACUN"].Value = row["NAZIVPROIZVODRACUN"];
                    sqlUpit.Parameters["@CIJENARACUN"].Value = row["CIJENARACUN"];
                    sqlUpit.Parameters["@RABAT"].Value = row["RABAT"];
                    sqlUpit.Parameters["@KOLICINA"].Value = kolicina;
                    sqlUpit.Parameters["@FINPOREZSTOPARACUN"].Value = row["FINPOREZSTOPARACUN"];
                    sqlUpit.Parameters["@CijenaPDV"].Value = row["CijenaPDV"];

                    sqlUpit.ExecuteNonQuery();
                }

                sqlUpit.CommandText = "Update RACUN Set VezaRacunID = @VezaRacunID, VezaRacunGodina = @VezaRacunGodina Where IDRACUN = @IDRACUN And RACUNGODINAIDGODINE = @RACUNGODINAIDGODINE";

                sqlUpit.Parameters["@VezaRacunID"].Value = brojRacuna;
                sqlUpit.Parameters["@VezaRacunGodina"].Value = activeYear;
                sqlUpit.Parameters["@IDRACUN"].Value = racun["IDRACUN"];
                sqlUpit.Parameters["@RACUNGODINAIDGODINE"].Value = racun["RACUNGODINAIDGODINE"];

                sqlUpit.ExecuteNonQuery();

                transakcija.Commit();

                return true;
            }
            catch
            {
                transakcija.Rollback();
                return false;
            }

        }

        private int GetNextID(int year)
        {
            int parser;
            string number = client.ExecuteScalar("Select Max(IDRACUN) From Racun Where RACUNGODINAIDGODINE = " + year).ToString();

            if (Int32.TryParse(number, out parser))
            {
                return Convert.ToInt32(number) + 1;
            }
            else
            {
                return 1;
            }
        }

        internal DataTable GetDataRacuni(Dictionary<int, int> oznaceni)
        {
            string where = string.Empty;
            int counter = 0;
            foreach (KeyValuePair<int, int> row in oznaceni)
            {
                counter++;

                if (counter < oznaceni.Count && oznaceni.Count > 1)
                {
                    where += "(IDRACUN = " + row.Key + " And RACUNGODINAIDGODINE = " + row.Value.ToString() + ") OR";
                }
                else
                {
                    where += "(IDRACUN = " + row.Key + " And RACUNGODINAIDGODINE = " + row.Value.ToString() + ") ";
                }

            }

            DataTable racuni = client.GetDataTable("Select * From vRacunUF Where " + where);

            IBAN iban = new IBAN();

            string ibanPlatitelja = string.Empty;

            foreach (DataRow row in racuni.Rows)
            {

                row["ustanoaIBAN"] = iban.GenerirajIBANIzBrojaRacuna(row["ustanovaBrojBanke"].ToString() + "-" + row["ustanovaBrojRacuna"].ToString(), false, true);

                row["Razred"] = GetUcenikRazred(row["ObracunStavkaID"].ToString());

                row["barcode"] = Get2DBarcode(row);
            }


            return racuni;
        }

        private object Get2DBarcode(DataRow row)
        {
            string data = ParseData(string.Format("HRVHUB30\nHRK\n{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\nHR{8}\n{9}\nOTHR\n{10}\n",
                            GetCijenaBarcode(row["UkupanIznos"]), row["RoditeljIme"].ToString() + " " + row["RoditeljPrezime"].ToString(), row["adresa"], row["grad"],
                            row["ustanovaNaziv"], row["ustanovaAdresa"], row["ustanovaPosta"].ToString() + " " + row["ustanovaGrad"].ToString(), row["ustanoaIBAN"].ToString().Replace(" ", string.Empty),
                            row["ustanovaModel"], row["ustanovaPozivNaBroj"], row["nazivObracuna"]));

            IBarcodeSettings settings = new BarcodeSettings();

            settings.Data = data;
            settings.Data2D = data;
            settings.Type = BarCodeType.Pdf417;
            settings.Pdf417DataMode = Pdf417DataMode.Byte;
            settings.ShowText = false;
            settings.ShowTextOnBottom = false;
            settings.ShowTopText = false;
            settings.Pdf417Truncated = false;
            settings.Unit = GraphicsUnit.Millimeter;
            settings.Pdf417ECL = Pdf417ECL.Level4;
            settings.ColumnCount = 9;
            settings.XYRatio = 2.2F;
            settings.X = 0.5F;
            settings.Y = 1.0F;

            BarCodeGenerator gen = new BarCodeGenerator(settings);

            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(gen.GenerateImage(), typeof(byte[]));
        }

        private string ParseData(string text)
        {
            string parsedText = text.Replace('Č', 'C').Replace('č', 'c').Replace('Ć', 'C').Replace('ć', 'c').Replace('Š', 'S').Replace('š', 's')
                                    .Replace('Ž', 'Z').Replace('ž', 'z').Replace('đ', 'd').Replace('Đ', 'D');

            return parsedText;
        }

        private string GetCijenaBarcode(object price)
        {
            decimal cijena = Math.Round(Convert.ToDecimal(price), 2) * 100;

            int lenght = ((int)cijena).ToString().Length;

            int empty = 15 - lenght;

            string cijenaFinal = string.Empty;

            for (int i = 0; i < empty; i++)
            {
                cijenaFinal +=  "0";
            }

            cijenaFinal += ((int)cijena).ToString();
            
            return cijenaFinal;
        }

        private object GetUcenikRazred(string obracunStavkaID)
        {
            return client.ExecuteScalar("Select UF_Razred.Naziv + '.' + UF_Odjeljenje.Naziv From UF_ObracunStavka " + 
                   "Inner Join UF_UstanovaSkolskaGodinaRazredOdjeljenje On UF_ObracunStavka.RazrednoOdjeljenjeID = UF_UstanovaSkolskaGodinaRazredOdjeljenje.ID " + 
                   "Inner Join UF_Razred On UF_UstanovaSkolskaGodinaRazredOdjeljenje.RazredID = UF_Razred.ID " + 
                   "Inner Join UF_Odjeljenje On UF_UstanovaSkolskaGodinaRazredOdjeljenje.OdjeljenjeID = UF_Odjeljenje.ID Where UF_ObracunStavka.ID = '" + obracunStavkaID + "'");
        }


        internal DataTable GetOznaceniRacuni(Dictionary<int, int> oznaceni)
        {
            string where = string.Empty;
            int counter = 0;
            foreach (KeyValuePair<int, int> row in oznaceni)
            {
                counter++;

                if (counter < oznaceni.Count && oznaceni.Count > 1)
                {
                    where += "(IDRACUN = " + row.Key + " And RACUNGODINAIDGODINE = " + row.Value.ToString() + ") OR";
                }
                else
                {
                    where += "(IDRACUN = " + row.Key + " And RACUNGODINAIDGODINE = " + row.Value.ToString() + ") ";
                }

            }

            DataTable racuni = client.GetDataTable("Select IDRACUN, RACUNGODINAIDGODINE, RACUN.IDPARTNER, PARTNER.PARTNEROIB, UKUPANIZNOS, RACUN.DATUM, RACUN.VALUTA, UF_Obracun.Naziv, RACUN.Vrsta, RACUN.VezaRacunID, RACUN.VezaRacunGodina From RACUN " +
                               "Inner Join PARTNER On RACUN.IDPARTNER = PARTNER.IDPARTNER Inner Join UF_Obracun On RACUN.VezaObracun = UF_Obracun.ID " + 
                               "Where (Zaduzen is NULL or Zaduzen <> 'True') And Vrsta In ('UF','SU') " + 
                               "And (" + where + ")");

            return racuni;
        }


        internal object LoadGodina()
        {
            return client.GetDataTable("Select IDGODINE AS ID, IDGODINE As Naziv From GODINE Order by GODINEAKTIVNA desc");
        }

        internal Dictionary<int, int> VratiOznaceneRacunePoBroju(int year, int odRacuna, int doRacuna)
        {
            Dictionary<int, int> oznaceni = new Dictionary<int, int>();

            DataTable dt = client.GetDataTable("Select IDRACUN, RACUNGODINAIDGODINE From RACUN Where RACUNGODINAIDGODINE = '" + year + 
                                               "' And IDRACUN Between '" + odRacuna + "' And '" + doRacuna + "' And Vrsta In('UF','SU') Order by IDRACUN");

            foreach (DataRow row in dt.Rows)
            {
                 oznaceni.Add(Convert.ToInt32(row["IDRACUN"]), Convert.ToInt32(row["RACUNGODINAIDGODINE"]));
            }

            return oznaceni;
        }

        internal bool IsStorniran()
        {
            DataRow racun = client.GetDataTable("Select * From RACUN Where IDRACUN = '" + pIDRacun + "' And RACUNGODINAIDGODINE = '" + pIDGodina + "'").Rows[0];

            if (racun["VezaRacunID"].ToString().Length > 0)
            {
                return false;
            }

            return true;
        }

        public int GetIDShemaOdabir()
        {
            using (UcenickoFakturiranje.UI.Fakturiranje.OdabirSheme objekt = new UI.Fakturiranje.OdabirSheme())
            {
                if (objekt.ShowDialogForm("Odabir sheme") == System.Windows.Forms.DialogResult.OK)
                {
                    return objekt.id_sheme;
                }
                else
                {
                    return 0;
                }
            }
        }

        public DataTable GetShemaKontiranjeByID(int id)
        {
            DataTable dtShemaKontiranja = client.GetDataTable("SELECT dbo.KONTO.IDKONTO AS ID_KONTO, dbo.STRANEKNJIZENJA.IDSTRANEKNJIZENJA AS ID_STRANE_KNJIZENJA, " +
                                          "dbo.IRAVRSTAIZNOSA.IDIRAVRSTAIZNOSA AS ID_IRA_VRSTA_IZNOSA, dbo.MJESTOTROSKA.IDMJESTOTROSKA AS ID_MJESTO_TROSKA, " +
                                          "dbo.ORGJED.IDORGJED AS ID_ORG_JED, (RTRIM(dbo.Konto.IDKONTO) + ' | ' + dbo.Konto.NAZIVKONTO) AS Konto, " +
                                          "dbo.STRANEKNJIZENJA.NAZIVSTRANEKNJIZENJA AS StranaKnjizenja, dbo.IRAVRSTAIZNOSA.IRAVRSTAIZNOSANAZIV AS VrstaIznosa, " +
                                          "(dbo.MJESTOTROSKA.NAZIVMJESTOTROSKA + ' | ' + Convert(nvarchar, dbo.MJESTOTROSKA.IDMJESTOTROSKA)) AS SifraMT, " +
                                          "(dbo.ORGJED.NAZIVORGJED + ' | ' + Convert(nvarchar, dbo.ORGJED.IDORGJED)) AS SifraOJ " +
                                          "FROM dbo.UF_ShemaKontiranje INNER JOIN dbo.STRANEKNJIZENJA ON dbo.UF_ShemaKontiranje.ID_STRANE_KNJIZENJA = dbo.STRANEKNJIZENJA.IDSTRANEKNJIZENJA " +
                                          "INNER JOIN dbo.IRAVRSTAIZNOSA ON dbo.UF_ShemaKontiranje.ID_IRA_VRSTA_IZNOSA = dbo.IRAVRSTAIZNOSA.IDIRAVRSTAIZNOSA INNER JOIN " +
                                          "dbo.ORGJED ON dbo.UF_ShemaKontiranje.ID_ORG_JED = dbo.ORGJED.IDORGJED INNER JOIN " +
                                          "dbo.MJESTOTROSKA ON dbo.UF_ShemaKontiranje.ID_MJESTO_TROSKA = dbo.MJESTOTROSKA.IDMJESTOTROSKA INNER JOIN " +
                                          "dbo.KONTO ON dbo.UF_ShemaKontiranje.ID_KONTO = dbo.KONTO.IDKONTO WHERE (dbo.UF_ShemaKontiranje.ID_SHEMA = '" + id + "')");
            return dtShemaKontiranja;
        }

        private int GetAktivnaGodina()
        {
            int aktivna_godina = 0;

            DataTable dtgodina = client.GetDataTable("Select IDGODINE From Godine Where GODINEAKTIVNA = 1");

            if (dtgodina.Rows.Count > 0)
            {
                aktivna_godina = Convert.ToInt32(dtgodina.Rows[0]["IDGODINE"]);
                return aktivna_godina;
            }
            else
            {
                return DateTime.Now.Year;
            }
        }

        internal bool SetZatvaranja()
        {
            DataTable dtStornoRacuni = GetStornoRacuni(pOdabraniRacuni);

            DataTable dtGKstavke;

            foreach (DataRow row in dtStornoRacuni.Rows)
            {
                dtGKstavke = GetGKStavka(row["IDRACUN"], row["RACUNGODINAIDGODINE"], row["VezaRacunID"], row["VezaRacunGodina"]);

                foreach (DataRow gk in dtGKstavke.Rows)
                {
                    InsertZatvaranje(gk["GKSTAVKA1"], gk["GKSTAVKA2"], row["Iznos"]);
                }
            }

            return true;
        }

        private void InsertZatvaranje(object gkStavka1, object gkStavka2, object iznos)
        {
            client.ExecuteNonQuery("Insert Into ZATVARANJA (GK1IDGKSTAVKA, GK2IDGKSTAVKA, ZATVARANJAIZNOS) Values ('" + gkStavka1 + "', '" + gkStavka2 + "', '" + iznos.ToString().Replace(',','.') + "')");
        }

        private DataTable GetGKStavka(object idStorno, object godinaStorno, object idOriginal, object godinaOriginal)
        {
            return client.GetDataTable("Select Distinct (Select IDGKSTAVKA From GKSTAVKA Where BrojDokumenta = '" + idStorno + "' And GKGODIDGODINE = '" + godinaStorno +
                                       "' And IDDOKUMENT = 997 And BrojStavke = p.BROJSTAVKE) As GKSTAVKA1, (Select IDGKSTAVKA From GKSTAVKA Where BrojDokumenta = '" + idOriginal +
                                       "' And GKGODIDGODINE = '" + godinaOriginal + "' And IDDOKUMENT = 997 And BrojStavke = p.BROJSTAVKE) As GKSTAVKA2 " +
                                       "From GKSTAVKA As P Where BrojDokumenta = '" + idStorno + "' And GKGODIDGODINE = '" + godinaStorno + "' And IDDOKUMENT = 997 And IDKONTO Like '1%'");
        }

        private DataTable GetStornoRacuni(Dictionary<int, int> pOdabraniRacuni)
        {
            string where = string.Empty;
            int counter = 0;
            foreach (KeyValuePair<int, int> row in pOdabraniRacuni)
            {
                counter++;

                if (counter < pOdabraniRacuni.Count && pOdabraniRacuni.Count > 1)
                {
                    where += "(IDRACUN = " + row.Key + " And RACUNGODINAIDGODINE = " + row.Value.ToString() + " And Vrsta In ('SU')) OR";
                }
                else
                {
                    where += "(IDRACUN = " + row.Key + " And RACUNGODINAIDGODINE = " + row.Value.ToString() + " And Vrsta In ('SU')) ";
                }

            }

            DataTable racuni = client.GetDataTable("Select IDRACUN, RACUNGODINAIDGODINE, VezaRacunID, VezaRacunGodina, Abs(UkupanIznos) As Iznos " + 
                                                   "From RACUN Where Zaduzen = 'True' And " + where);

            return racuni;
        }

        public bool InsertGlavnaKnjiga(ref int idShema)
        {
            idShema = GetIDShemaOdabir();
            DataTable dtShemaUF = GetShemaKontiranjeByID(idShema);

            DataTable dtRacuni = GetOznaceniRacuni(pOdabraniRacuni);

            int brojStavke = 0;
            int idDokument = 997;
            int idMjestoTroska;
            int idOrgJedinice;
            string idKonto;
            string duguje;
            string potrazuje;
            string zatvoreno;
            int activeYear = GetAktivnaGodina();
            int status;

            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.Parameters.Add(new SqlParameter("@DatumPrijave", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@ValutaPlacanja", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@BrojDokumenta", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@OPIS", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@GODINA", ""));

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Upis u glavnu knjigu");
            pCounter = 0;

            sqlUpit.Transaction = transakcija;

            try
            {
                foreach (DataRow row in dtRacuni.Rows)
                {
                    status = 1;

                    sqlUpit.Parameters["@DatumPrijave"].Value = row["DATUM"];
                    sqlUpit.Parameters["@ValutaPlacanja"].Value = row["VALUTA"];
                    sqlUpit.Parameters["@BrojDokumenta"].Value = row["IDRACUN"];
                    sqlUpit.Parameters["@OPIS"].Value = row["Naziv"];
                    sqlUpit.Parameters["@GODINA"].Value = row["RACUNGODINAIDGODINE"];

                    if (row["Vrsta"].ToString() == "SU")
                    {
                        status = 1;
                        sqlUpit.CommandText = "Update GKSTAVKA Set statusgk = 1 Where BROJDOKUMENTA = '" + row["VezaRacunID"] + "' And GKGODIDGODINE = '" + row["VezaRacunGodina"] + "' And IDDOKUMENT = 997";
                        sqlUpit.ExecuteNonQuery();
                    }

                    foreach (DataRow shema_kontiranja in dtShemaUF.Rows)
                    {
                        brojStavke++;
                        idMjestoTroska = (int)shema_kontiranja["ID_MJESTO_TROSKA"];
                        idOrgJedinice = (int)shema_kontiranja["ID_ORG_JED"];
                        idKonto = shema_kontiranja["ID_KONTO"].ToString().Trim();

                        if (Convert.ToInt32(shema_kontiranja["ID_STRANE_KNJIZENJA"]) == 1)
                        {
                            duguje = Convert.ToDecimal(row["UKUPANIZNOS"]).ToString().Replace(',', '.');
                            potrazuje = "0";

                            sqlUpit.CommandText = "Insert Into GKSTAVKA (DATUMDOKUMENTA, BROJDOKUMENTA, BROJSTAVKE, IDDOKUMENT, IDMJESTOTROSKA, IDORGJED, IDKONTO, OPIS, duguje, POTRAZUJE, " +
                            "DATUMPRIJAVE, IDPARTNER, ZATVORENIIZNOS, statusgk, ORIGINALNIDOKUMENT, GKGODIDGODINE, GKDATUMVALUTE) Values " +
                            "(@DatumPrijave, @BrojDokumenta, " + brojStavke + ", " + idDokument + ", " + idMjestoTroska + ", " + idOrgJedinice + ", '" + idKonto + "', @OPIS, '" + 
                            duguje + "', '" + potrazuje + "', @DatumPrijave, " + (int)row["IDPARTNER"] + ", '0', '" + status + "', 'Učeničko fakturiranje', @GODINA, @ValutaPlacanja)";
                        }
                        else
                        {
                            potrazuje = Convert.ToDecimal(row["UKUPANIZNOS"]).ToString().Replace(',', '.');
                            zatvoreno = Math.Abs(Convert.ToDecimal(row["UKUPANIZNOS"])).ToString().Replace(',', '.');
                            duguje = "0";

                            sqlUpit.CommandText = "Insert Into GKSTAVKA (DATUMDOKUMENTA, BROJDOKUMENTA, BROJSTAVKE, IDDOKUMENT, IDMJESTOTROSKA, IDORGJED, IDKONTO, OPIS, duguje, POTRAZUJE, " +
                            "DATUMPRIJAVE, IDPARTNER, ZATVORENIIZNOS, statusgk, ORIGINALNIDOKUMENT, GKGODIDGODINE, GKDATUMVALUTE) Values " +
                            "(@DatumPrijave, @BrojDokumenta, " + brojStavke + ", " + idDokument + ", " + idMjestoTroska + ", " + idOrgJedinice + ", '" + idKonto + "', " +
                            "@OPIS, '" + duguje + "', '" + potrazuje + "', @DatumPrijave, " + (int)row["IDPARTNER"] + ", '" + zatvoreno + "', '" + status + "', " +
                            "'Učeničko fakturiranje', @GODINA, @ValutaPlacanja)";
                        }

                        sqlUpit.ExecuteNonQuery();

                    }
                    pCounter++;
                    brojStavke = 0;
                }

                transakcija.Commit();

            }
            catch
            {
                pCounter = 0;
                transakcija.Rollback();
                return false;
            }
            return true;
        }

        public int GetIDShema()
        {
            int broj_dokumenta = 0;

            DataTable dtbroj = client.GetDataTable("Select Max(ID) As Broj From UF_Shema");

            if (dtbroj.Rows.Count > 0 && dtbroj.Rows[0]["Broj"].ToString() != "")
            {
                broj_dokumenta = Convert.ToInt32(dtbroj.Rows[0]["Broj"]);
                return broj_dokumenta;
            }
            else
            {
                return 0;
            }
        }

        internal void SetPreneseniObracuni()
        {
            string where = string.Empty;
            int counter = 0;
            foreach (KeyValuePair<int, int> row in pOdabraniRacuni)
            {
                counter++;

                if (counter < pOdabraniRacuni.Count && pOdabraniRacuni.Count > 1)
                {
                    where += "(IDRACUN = " + row.Key + " And RACUNGODINAIDGODINE = " + row.Value.ToString() + ") OR";
                }
                else
                {
                    where += "(IDRACUN = " + row.Key + " And RACUNGODINAIDGODINE = " + row.Value.ToString() + ") ";
                }

            }
            client.ExecuteNonQuery("Update RACUN Set Zaduzen = 1 Where " + where);
        }

        internal bool InsertIRA()
        {
            DataTable dtRacuni = GetRacuni();
            DataTable dtRacuniStavke = GetRacuniStavke();
            DataRow[] stavke;

            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Upis u IRA");
            sqlUpit.Transaction = transakcija;

            try
            {

                decimal osn05 = 0;
                decimal osn10 = 0;
                decimal osn22 = 0;
                decimal osn23 = 0;
                decimal osn25 = 0;
                decimal nula = 0;
                decimal pdv05 = 0;
                decimal pdv10 = 0;
                decimal pdv22 = 0;
                decimal pdv23 = 0;
                decimal pdv25 = 0;

                sqlUpit.Parameters.Add(new SqlParameter("@IRAGODINA", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IRABROJ", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IRAPARTNER", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IRADATUM", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IRAVALUTA", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IRAUKUPNO", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@NULA", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@OSN10", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@OSN22", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@OSN25", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@OSN23", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@OSN05", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@PDV10", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@PDV22", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@PDV25", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@PDV23", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@PDV05", ""));

                pCounter = 0;

                foreach (DataRow row in dtRacuni.Rows)
                {
                    stavke = dtRacuniStavke.Select("IDRACUN= '" + row["IDRACUN"].ToString() + "' And RACUNGODINAIDGODINE = '" + row["RACUNGODINAIDGODINE"].ToString() + "'");

                    foreach (DataRow stav in stavke)
                    {
                        if (Convert.ToDecimal(stav["FINPOREZSTOPARACUN"]) == 0)
                        {
                            nula += Convert.ToDecimal(stav["CijenaStavka"]);
                        }
                        else if (Convert.ToDecimal(stav["FINPOREZSTOPARACUN"].ToString()) == 5)
                        {
                            osn05 += Convert.ToDecimal(stav["CijenaStavka"]);
                            pdv05 += Convert.ToDecimal(stav["CijenaStavka"]) * Convert.ToDecimal(stav["FINPOREZSTOPARACUN"]) / 100;
                        }
                        else if (Convert.ToDecimal(stav["FINPOREZSTOPARACUN"].ToString()) == 10)
                        {
                            osn10 += Convert.ToDecimal(stav["CijenaStavka"]);
                            pdv10 += Convert.ToDecimal(stav["CijenaStavka"]) * Convert.ToDecimal(stav["FINPOREZSTOPARACUN"]) / 100;
                        }
                        else if (Convert.ToDecimal(stav["FINPOREZSTOPARACUN"].ToString()) == 22)
                        {
                            osn22 += Convert.ToDecimal(stav["CijenaStavka"]);
                            pdv22 += Convert.ToDecimal(stav["CijenaStavka"]) * Convert.ToDecimal(stav["FINPOREZSTOPARACUN"]) / 100;
                        }
                        else if (Convert.ToDecimal(stav["FINPOREZSTOPARACUN"].ToString()) == 23)
                        {
                            osn23 += Convert.ToDecimal(stav["CijenaStavka"]);
                            pdv23 += Convert.ToDecimal(stav["CijenaStavka"]) * Convert.ToDecimal(stav["FINPOREZSTOPARACUN"]) / 100;
                        }
                        else if (Convert.ToDecimal(stav["FINPOREZSTOPARACUN"].ToString()) == 25)
                        {
                            osn25 += Convert.ToDecimal(stav["CijenaStavka"]);
                            pdv25 += Convert.ToDecimal(stav["CijenaStavka"]) * Convert.ToDecimal(stav["FINPOREZSTOPARACUN"]) / 100;
                        }
                    }

                    sqlUpit.Parameters["@IRAGODINA"].Value = row["RACUNGODINAIDGODINE"];
                    sqlUpit.Parameters["@IRABROJ"].Value = row["IDRACUN"];
                    sqlUpit.Parameters["@IRAPARTNER"].Value = row["IDPARTNER"];
                    sqlUpit.Parameters["@IRADATUM"].Value = row["DATUM"];
                    sqlUpit.Parameters["@IRAVALUTA"].Value = row["VALUTA"];
                    sqlUpit.Parameters["@IRAUKUPNO"].Value = row["UkupanIznos"];
                    sqlUpit.Parameters["@NULA"].Value = nula;
                    sqlUpit.Parameters["@OSN10"].Value = osn10;
                    sqlUpit.Parameters["@OSN22"].Value = osn22;
                    sqlUpit.Parameters["@OSN25"].Value = osn25;
                    sqlUpit.Parameters["@OSN23"].Value = osn23;
                    sqlUpit.Parameters["@OSN05"].Value = osn05;
                    sqlUpit.Parameters["@PDV10"].Value = pdv10;
                    sqlUpit.Parameters["@PDV22"].Value = pdv22;
                    sqlUpit.Parameters["@PDV25"].Value = pdv25;
                    sqlUpit.Parameters["@PDV23"].Value = pdv23;
                    sqlUpit.Parameters["@PDV05"].Value = pdv05;

                    sqlUpit.CommandText = "Insert Into IRA ([IRAGODIDGODINE],[IRADOKIDDOKUMENT],[IRABROJ],[IRAPARTNERIDPARTNER],[IDTIPIRA],[IRADATUM],[IRAVALUTA],[IRANAPOMENA],[IRAUKUPNO] " +
                                          ",[NEPODLEZE],[IZVOZ],[MEDJTRANS],[TUZEMSTVO],[NULA],[OSTALO],[OSN10],[OSN22],[OSN23],[OSN25],[PDV10],[PDV22],[PDV23],[PDV25],[OSN05],[PDV05],[NEPODLEZE_USLUGA]) " +
                                          "Values (@IRAGODINA, 997, @IRABROJ, @IRAPARTNER, 1, @IRADATUM, @IRAVALUTA, 'Prijenos iz UF-a', @IRAUKUPNO, 0, 0, 0, @NULA, 0, 0, " +
                                          "@OSN10, @OSN22, @OSN23, @OSN25, @PDV10, @PDV22, @PDV23, @PDV25, @OSN05, @PDV05, 0)";

                    sqlUpit.ExecuteNonQuery();

                    nula = 0;
                    osn05 = 0;
                    osn10 = 0;
                    osn22 = 0;
                    osn23 = 0;
                    osn25 = 0;
                    pdv05 = 0;
                    pdv10 = 0;
                    pdv22 = 0;
                    pdv23 = 0;
                    pdv25 = 0;

                    pCounter++;
                }

                transakcija.Commit();
            }
            catch 
            {
                pCounter = 0;
                transakcija.Rollback();
                return false;
            }
            
            return true;
        }

        private DataTable GetRacuni()
        {
            string where = string.Empty;
            int counter = 0;

            foreach (KeyValuePair<int, int> row in pOdabraniRacuni)
            {
                counter++;

                if (counter < pOdabraniRacuni.Count && pOdabraniRacuni.Count > 1)
                {
                    where += "(IDRACUN = " + row.Key + " And RACUNGODINAIDGODINE = " + row.Value.ToString() + ") OR";
                }
                else
                {
                    where += "(IDRACUN = " + row.Key + " And RACUNGODINAIDGODINE = " + row.Value.ToString() + ") ";
                }

            }

            DataTable racuni = client.GetDataTable("Select RACUN.IDRACUN, RACUN.RACUNGODINAIDGODINE, RACUN.IDPARTNER, RACUN.DATUM, RACUN.VALUTA, RACUN.UkupanIznos " + 
                               "From RACUN Where (Zaduzen is NULL or Zaduzen <> 'True') And (" + where + ")");

            return racuni;
        }

        private DataTable GetRacuniStavke()
        {
            string where = string.Empty;
            int counter = 0;

            foreach (KeyValuePair<int, int> row in pOdabraniRacuni)
            {
                counter++;

                if (counter < pOdabraniRacuni.Count && pOdabraniRacuni.Count > 1)
                {
                    where += "(RACUN.IDRACUN = " + row.Key + " And RACUN.RACUNGODINAIDGODINE = " + row.Value.ToString() + ") OR";
                }
                else
                {
                    where += "(RACUN.IDRACUN = " + row.Key + " And RACUN.RACUNGODINAIDGODINE = " + row.Value.ToString() + ") ";
                }

            }

            DataTable racuni = client.GetDataTable("Select RACUN.IDRACUN, RACUN.RACUNGODINAIDGODINE, ((CIJENARACUN * KOLICINA) - (CIJENARACUN * KOLICINA * RABAT /100)) As CijenaStavka, " +
                                                   "FINPOREZSTOPARACUN From RACUNRacunStavke Inner Join UF_Proizvod On RACUNRacunStavke.IDPROIZVOD = UF_Proizvod.ID " +
                                                   "Inner Join Racun On RACUNRacunStavke.IDRACUN = RACUN.IDRACUN And RACUNRacunStavke.RACUNGODINAIDGODINE = RACUN.RACUNGODINAIDGODINE " +
                                                   "Where (Zaduzen is NULL or Zaduzen <> 'True') And (" + where + ")");

            return racuni;
        }
    }
}