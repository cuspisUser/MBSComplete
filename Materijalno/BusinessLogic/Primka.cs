using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;
using System.Collections;

namespace Materijalno.BusinessLogic
{
    public class Primka : Base, IDisposable
    {
        SqlClient client = null;

        //zbog brisanja stavaka kod update-a
        public static bool kontrola_stavke = false;

        public Primka()
            : base()
        {
            client = new SqlClient();
        }

        #region Properties

        public static Nullable<int> pID { get; set; }
        public string pBrojPrimke { get; set; }
        public DateTime pDatumNastajanja { get; set; }
        public int pDobavljac { get; set; }
        public Nullable<int> pVrstaDokumenta { get; set; }
        public Nullable<DateTime> pDatumDokumentaDobavljaca { get; set; }
        public Nullable<int> pSkaldiste { get; set; }
        public Nullable<int> pNarudzbenica { get; set; }
        public Nullable<decimal> pNeto { get; set; }
        public Nullable<decimal> pPDV { get; set; }
        public Nullable<decimal> pBruto { get; set; }
        public Nullable<decimal> pZavrsniTransport { get; set; }
        public Nullable<decimal> pZavrsniCarina { get; set; }
        public Nullable<decimal> pZavrsniOstalo { get; set; }
        public static int pSelectedIndex { get; set; }
        public static DataTable pPrimkaStavke { get; set; }
        public static string pBrojUlaznogDokumenta { get; set; }
        public string pOpis { get; set; }
        private Nullable<DateTime> originalDate { get; set; }
        private Nullable<int> originalWarhouse { get; set; }

        #endregion

        #region Work with data

        public DataSet GetMainGridData()
        {
            DataSet ds = new DataSet();

            //dohvat aktivne godine
            string active_year = client.ExecuteScalar("Select IDGODINE From GODINE Where GODINEAKTIVNA = 1").ToString();

            //db - 28.1.2017
            //DataTable dt_primary = client.GetDataTable("Select CONVERT(bit, 0) AS Ozn, MT_Primka.ID, (SifraPrimke + '       ' +  MT_Primka.Opis) As Opis, DatumNastajanja, PARTNER.NAZIVPARTNER, BrojUlaznogDokumenta, MT_Skladista.Naziv As Skladiste, NetoPrimke, " +
            //                       "BrutoPrimke, PDVPrimke, Preneseno, ID_Skladista From MT_Primka Inner Join PARTNER On MT_Primka.ID_Partnera = PARTNER.IDPARTNER " + 
            //                       "Inner Join MT_Skladista On MT_Primka.ID_Skladista = MT_Skladista.ID Where YEAR(DatumNastajanja) = " + active_year + " Order by MT_Primka.ID, SifraPrimke");

            int brojStavki = 0;
            string dohvat = "Select count(ID) from MT_PrimkaStavke where ID_Primke = '" + pBrojPrimke + "' ";
            SqlCommand sqlDohvat = new SqlCommand(dohvat);
            sqlDohvat.Connection = client.sqlConnection;
            brojStavki = Convert.ToInt32(sqlDohvat.ExecuteScalar());



            string storaa = "spDohvatiPrimke";
            SqlCommand comm = new SqlCommand(storaa);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@godina", active_year);
            comm.Connection = client.sqlConnection;

            DataTable dt_primary = client.GetDataTable(comm);


            //db - 28.1.2017 - dodano  (MT_PrimkaStavke.CijenaPDV - MT_PrimkaStavke.Cijena) as PDV  && FINPOREZ.FINPOREZSTOPA as StopaPDV
            //DataTable dt_related1 = client.GetDataTable("Select MT_PrimkaStavke.RedniBroj, PROIZVOD.NAZIVPROIZVOD, JEDINICAMJERE.NAZIVJEDINICAMJERE, Kolicina, MT_PrimkaStavke.Cijena As Neto, MT_PrimkaStavke.CIjenaPDV As Bruto, (MT_PrimkaStavke.CijenaPDV - MT_PrimkaStavke.Cijena) as PDV," +
            //                        "Round((Kolicina *  MT_PrimkaStavke.Cijena), 2) As [Uk.Neto], Round((Kolicina *  MT_PrimkaStavke.CIjenaPDV), 2) As [Uk.Bruto], " +
            //                        "FINPOREZ.FINPOREZSTOPA as StopaPDV, , ID_Primke From MT_PrimkaStavke Inner Join PROIZVOD on MT_PrimkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD " + 
            //                        "Inner Join JEDINICAMJERE on MT_PrimkaStavke.ID_JedinicaMjere = JEDINICAMJERE.IDJEDINICAMJERE " +
            //                        "inner join FINPOREZ on MT_PrimkaStavke.ID_Porez = FINPOREZ.FINPOREZIDPOREZ " +
            //                        "Inner Join MT_Primka On MT_PrimkaStavke.ID_Primke = MT_Primka.ID Where YEAR(MT_Primka.DatumNastajanja) = " + active_year + " Order by NAZIVPROIZVOD");
            string stora = "spDohvatiPrimkaStavke";
            SqlCommand com = new SqlCommand(stora);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@godina", active_year);
            com.Connection = client.sqlConnection;

            DataTable dt_related1 = client.GetDataTable(com);

            ds.Tables.Add(dt_primary);
            ds.Tables.Add(dt_related1);

            DataRelation relation1 = new DataRelation("Primka", dt_primary.Columns["ID"], dt_related1.Columns["ID_Primke"]);

            ds.Relations.Add(relation1);

            return ds;
        }

        public DataRow GetPrimka()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "SELECT [ID],[SifraPrimke],[DatumNastajanja],[ID_Partnera],[ID_Dokumenta],[DatumDokumentaDobavljaca],[ID_Skladista],[ID_Narudzbenice], " +
                                  "[NetoPrimke],[PDVPrimke],[BrutoPrimke],[ZavisniTransport],[ZavisniCarina],[ZavisniOstalo],[TS], BrojUlaznogDokumenta, Opis FROM [dbo].[MT_Primka] Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            return client.GetDataTable(sqlUpit).Rows[0];
        }

        public DataTable GetPrimkaIspis()
        {
            DataTable tbl = new DataTable();
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Select [ID],[SifraPrimke],[DatumNastajanja],[IDPARTNER],[NAZIVPARTNER],[PARTNERMJESTO],[PARTNEROIB],[PARTNERULICA],[ID_Dokumenta]," +
                        "[ID_Narudzbenice],[Dokument],[BrojNarudzbe],[IDPROIZVOD],[Cijena],[Kolicina],[NAZIVPROIZVOD],[NAZIVJEDINICAMJERE], Skladiste, CijenaPDV, DatumDokumentaDobavljaca, " +
                        "BrojUlaznogDokumenta, VrstaUlaznogDokumenta, Opis From v_Primka Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            tbl = client.GetDataTable(sqlUpit);

            foreach (DataRow red in tbl.Rows)
            {
                if (red["ID_Dokumenta"].ToString() != "")
                {
                    red["Dokument"] = GetDokumentIspis(red["ID_Dokumenta"].ToString());
                }
                if (red["ID_Narudzbenice"].ToString() != "")
                {
                    red["BrojNarudzbe"] = GetNarudzbenicaIspis(red["ID_Narudzbenice"].ToString());
                }
            }

            return tbl;
        }

        // db - 26.10.2016 metoda dohvaća data source za subreport
        //db - 10.01.2017 - vise ne dohvaca preko procedure, nego preko view-a
        public DataTable GetPrimkaGrupe(int idPrimke)
        {
            DataTable dt = new DataTable();
            SqlClient sql = new SqlClient();
            SqlCommand sqlComm = new SqlCommand("select * from v_Primka where ID = '" + idPrimke + "' ");

            ////ukoliko je na formi odabrana Primka
            //sqlComm = new SqlCommand("spGrupaPrimka", sql.sqlConnection);
            //sqlComm.CommandType = CommandType.StoredProcedure;
            //sqlComm.Parameters.AddWithValue("@idPrimke", idPrimke);

            try
            {
                dt = sql.GetDataTable(sqlComm);
            }
            catch (SqlException ex) { }
            catch (Exception ex) { }


            return dt;
        }

        private string GetNarudzbenicaIspis(string p)
        {
            DataTable tbl = client.GetDataTable("Select BrojNarudzbe From JN_Narudzbenica Where ID = '" + p + "'");
            return tbl.Rows[0]["BrojNarudzbe"].ToString();
        }

        private string GetDokumentIspis(string p)
        {
            DataTable tbl = client.GetDataTable("Select NAZIVDOKUMENT From DOKUMENT Where IDDOKUMENT = '" + p + "'");
            return tbl.Rows[0]["NAZIVDOKUMENT"].ToString();
        }

        public DataTable GetSkladiste()
        {
            return client.GetDataTable("Select ID, Naziv From MT_Skladista Order by Naziv");
        }

        public object[] GetPartner()
        {
            return client.ConvertDataTableToArrayList(client.GetDataTable("Select IDPARTNER As ID, (CAST(IDPARTNER AS nvarchar) + ' | ' + NAZIVPARTNER) As Naziv From Partner Order by NAZIVPARTNER")).ToArray();
        }
        public DataTable GetPartner1()
        {
            return client.GetDataTable("Select IDPARTNER As ID, NAZIVPARTNER As Naziv From Partner Order by NAZIVPARTNER");
        }
        public DataTable GetNarudzbenica()
        {
            return client.GetDataTable("Select ID, BrojNarudzbe As Naziv From JN_Narudzbenica Order by BrojNarudzbe");
        }

        public DataTable GetDokument()
        {
            return client.GetDataTable("Select IDDOKUMENT As ID, NAZIVDOKUMENT AS Naziv From DOKUMENT Order by NAZIVDOKUMENT");
        }

        internal object[] GetProizvod()
        {
            return client.ConvertDataTableToArrayList(client.GetDataTable("Select IDPROIZVOD As ID, (CAST(IDPROIZVOD AS nvarchar) + ' | ' + NAZIVPROIZVOD) AS Naziv From PROIZVOD Order by NAZIV")).ToArray();
        }

        internal DataRow GetMjeraPDV(int proizvod)
        {
            return client.GetDataTable("Select Proizvod.FINPOREZIDPOREZ As ID_PDV, Proizvod.IDJEDINICAMJERE As ID_JedinicaMjere, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, " +
                                       "FINPOREZ.FINPOREZNAZIVPOREZ As PDV, Proizvod.Cijena, Proizvod.CijenaPDV From Proizvod Inner Join FINPOREZ on PROIZVOD.FINPOREZIDPOREZ = FINPOREZ.FINPOREZIDPOREZ " +
                                       "Inner Join JEDINICAMJERE on PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE Where PROIZVOD.IDPROIZVOD = " + proizvod).Rows[0];
        }

        internal object GetMjeranaJedinica()
        {
            return client.GetDataTable("Select IDJEDINICAMJERE As ID, NAZIVJEDINICAMJERE As Naziv From JEDINICAMJERE");
        }

        internal object GetBrojDokumenta()
        {
            //db - 30.1.2017 - ovo ne valja jer kad se napravi invrentura i unese u skladište, Sifra krece opet od 1, tako da MAX(Sifra) nije dobro rješenje
            string text = "select top 1 (SifraPrimke) + 1 from MT_Primka order by ID desc";
            SqlCommand com = new SqlCommand(text);
            com.CommandType = CommandType.Text;
            com.Connection = client.sqlConnection;

            DataTable dt = new DataTable();
            dt = client.GetDataTable(com);

            string brojPrimke = "";
            if (dt.Rows.Count > 0)
            {
                try
                {
                    brojPrimke = dt.Rows[0][0].ToString();
                }
                catch { }
            }
            else
            {
                brojPrimke = "1";
            }

            return brojPrimke;
        }

        public DataRow GetFullPartnerByID(int partner)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Select NAZIVPARTNER As Naziv, PARTNERULICA As Adresa, PARTNERMJESTO As Grad, PARTNEROIB As OIB From PARTNER Where IDPARTNER = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", partner));

            return client.GetDataTable(sqlUpit).Rows[0];
        }

        public string GetFullSkladisteByID(int? skaldiste)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Select Naziv From MT_Skladista Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", skaldiste));

            return client.GetDataTable(sqlUpit).Rows[0]["Naziv"].ToString();
        }

        public string GetFullVrstaDokumenta(int? vrsta_dokumenta)
        {
            if (vrsta_dokumenta != null)
            {
                SqlCommand sqlUpit = new SqlCommand();
                sqlUpit.Connection = client.sqlConnection;
                sqlUpit.CommandType = CommandType.Text;

                sqlUpit.CommandText = "Select NAZIVDOKUMENT As Naziv From DOKUMENT Where IDDOKUMENT = @ID";

                sqlUpit.Parameters.Add(new SqlParameter("@ID", vrsta_dokumenta));

                return client.GetDataTable(sqlUpit).Rows[0]["Naziv"].ToString();
            }
            else { return null; }
        }

        public DataTable GetPrimkaStavke()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            sqlUpit.CommandText = "Select 'false' As SEL, ID_Primke, ID_Proizvoda, PROIZVOD.NAZIVPROIZVOD As Proizvod, ID_JedinicaMjere, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, MT_PrimkaStavke.Cijena, ID_Porez, " +
            "FINPOREZ.FINPOREZNAZIVPOREZ As Porez, Kolicina, MT_PrimkaStavke.CijenaPDV, 0 As BrojUlaznogDokumenta, (Kolicina * MT_PrimkaStavke.Cijena + (Kolicina * MT_PrimkaStavke.Cijena * (FINPOREZ.FINPOREZSTOPA/100)))As UkupnaNabavnaCijena, " +
            "MT_PrimkaStavke.RedniBroj From MT_PrimkaStavke Inner Join PROIZVOD on MT_PrimkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD " +
            "Inner Join JEDINICAMJERE on MT_PrimkaStavke.ID_JedinicaMjere = JEDINICAMJERE.IDJEDINICAMJERE " +
            "Inner Join FINPOREZ on MT_PrimkaStavke.ID_Porez = FINPOREZ.FINPOREZIDPOREZ Where ID_Primke = @ID Order by PROIZVOD.NAZIVPROIZVOD";

            return client.GetDataTable(sqlUpit);
        }

        public bool Delete(StringBuilder message)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete from MT_PrimkaStavke Where ID_Primke = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();

                sqlUpit.CommandText = "Delete from MT_Primka Where ID = @ID";

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

        public bool Insert(StringBuilder message, Primka objekt)
        {
            int id;
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Primka");

            sqlUpit.Transaction = transakcija;

            sqlUpit.CommandText = "Insert Into MT_Primka ([SifraPrimke],[DatumNastajanja],[ID_Partnera],[ID_Dokumenta],[DatumDokumentaDobavljaca],[ID_Skladista] " +
                                  ",[ID_Narudzbenice],[NetoPrimke],[PDVPrimke],[BrutoPrimke],[ZavisniTransport],[ZavisniCarina],[ZavisniOstalo],[TS],[BrojUlaznogDokumenta], [Preneseno], Opis) Values " +
                                  "(@SifraPrimke, @DatumNastajanja, @ID_Partner, @ID_Dokumenta, @DatumDobavljaca, @ID_Skladista, @ID_Narudzbenica, @Neto, " +
                                  "@PDV, @Bruto, @Transport, @Carina, @Ostalo, @TS, @BrojUlaznogDokumenta, @Preneseno, @Opis) Select @@Identity";

            sqlUpit.Parameters.Add(new SqlParameter("@SifraPrimke", objekt.pBrojPrimke));
            sqlUpit.Parameters.Add(new SqlParameter("@DatumNastajanja", objekt.pDatumNastajanja));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Partner", objekt.pDobavljac));
            if (objekt.pVrstaDokumenta == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Dokumenta", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Dokumenta", objekt.pVrstaDokumenta));
            }

            if (objekt.pSkaldiste == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Skladista", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Skladista", objekt.pSkaldiste));
            }

            if (objekt.pDatumDokumentaDobavljaca == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@DatumDobavljaca", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@DatumDobavljaca", objekt.pDatumDokumentaDobavljaca));
            }
            if (objekt.pNarudzbenica == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Narudzbenica", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Narudzbenica", objekt.pNarudzbenica));
            }
            if (objekt.pNeto == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Neto", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Neto", objekt.pNeto));
            }
            if (objekt.pPDV == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@PDV", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@PDV", objekt.pPDV));
            }
            if (objekt.pBruto == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Bruto", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Bruto", objekt.pBruto));
            }
            if (objekt.pZavrsniTransport == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Transport", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Transport", objekt.pZavrsniTransport));
            }
            if (objekt.pZavrsniCarina == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Carina", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Carina", objekt.pZavrsniCarina));
            }
            if (objekt.pZavrsniOstalo == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Ostalo", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Ostalo", objekt.pZavrsniOstalo));
            }
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

            if (pBrojUlaznogDokumenta != null)
            {
                if (pBrojUlaznogDokumenta.Length == 0)
                {
                    sqlUpit.Parameters.Add(new SqlParameter("@BrojUlaznogDokumenta", DBNull.Value));
                }
                else
                {
                    sqlUpit.Parameters.Add(new SqlParameter("@BrojUlaznogDokumenta", pBrojUlaznogDokumenta));
                }
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@BrojUlaznogDokumenta", DBNull.Value));
            }

            if (objekt.pOpis == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Opis", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Opis", objekt.pOpis));
            }

            sqlUpit.Parameters.Add(new SqlParameter("@Preneseno", false));

            try
            {
                id = Convert.ToInt32(sqlUpit.ExecuteScalar());

                if (InsertStavke(message, sqlUpit, id, objekt))
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

        private bool InsertStavke(StringBuilder message, SqlCommand sqlUpit, int id, Primka objekt)
        {
            if (BusinessLogic.Primka.pPrimkaStavke.Rows.Count > 0)
            {
                sqlUpit.Parameters.Clear();

                sqlUpit.Parameters.Add(new SqlParameter("@Primka", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@Proizvod", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@JedinicaMjere", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@Cijena", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@Porez", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@Kolicina", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@CijenaPDV", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@RedniBroj", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@RedniBrojDan", ""));

                foreach (DataRow red in BusinessLogic.Primka.pPrimkaStavke.Rows)
                {
                    sqlUpit.Parameters["@Primka"].Value = id;
                    sqlUpit.Parameters["@Proizvod"].Value = Convert.ToInt32(red["ID_Proizvoda"]);
                    sqlUpit.Parameters["@JedinicaMjere"].Value = Convert.ToInt32(red["ID_JedinicaMjere"]);
                    sqlUpit.Parameters["@Cijena"].Value = Convert.ToDecimal(red["Cijena"]);
                    sqlUpit.Parameters["@Porez"].Value = Convert.ToInt32(red["ID_Porez"]);
                    sqlUpit.Parameters["@Kolicina"].Value = Convert.ToDecimal(red["Kolicina"]);
                    sqlUpit.Parameters["@CijenaPDV"].Value = Convert.ToDecimal(red["CijenaPDV"]);
                    sqlUpit.Parameters["@RedniBroj"].Value = Convert.ToInt32(red["RedniBroj"]);
                    sqlUpit.Parameters["@RedniBrojDan"].Value = RedniBrojSkladisteDan(objekt.pDatumNastajanja.ToString("yyyy-MM-dd"), (int)objekt.pSkaldiste,
                                                                                      Convert.ToInt32(red["ID_JedinicaMjere"]), sqlUpit);

                    sqlUpit.CommandText = "Insert Into MT_PrimkaStavke ([ID_Primke], [ID_Proizvoda], [ID_JedinicaMjere], [Cijena], [ID_Porez], [Kolicina], [CijenaPDV], [RedniBroj], RedniBrojDan) " +
                                          "Values (@Primka, @Proizvod, @JedinicaMjere, @Cijena, @Porez, @Kolicina, @CijenaPDV, @RedniBroj, @RedniBrojDan)";

                    try
                    {
                        sqlUpit.ExecuteNonQuery();
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
            }
            return true;
        }

        public bool Update(StringBuilder message, Primka objekt, bool preneseno)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            List<PrimkaStavke> razlika;

            sqlUpit.CommandText = "Update MT_Primka Set SifraPrimke = @SifraPrimke, DatumNastajanja = @DatumNastajanja, ID_Partnera = @ID_Partner, ID_Dokumenta = @ID_Dokumenta, " +
                                  "DatumDokumentaDobavljaca = @DatumDobavljaca, ID_Skladista = @ID_Skladista, ID_Narudzbenice = @ID_Narudzbenica, NetoPrimke = @Neto, " +
                                  "PDVPrimke = @PDV, BrutoPrimke = @Bruto, ZavisniTransport = @Transport, ZavisniCarina = @Carina, ZavisniOstalo = @Ostalo, TS = @TS, " +
                                  "BrojUlaznogDokumenta = @BrojUlaznogDokumenta, Preneseno = @Preneseno, Opis = @Opis Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@Kolicina", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Saldo", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Stanje", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@RedniBrojDan", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Primka", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Proizvod", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Cijena", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Porez", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@CijenaPDV", ""));

            sqlUpit.Parameters.Add(new SqlParameter("@SifraPrimke", objekt.pBrojPrimke));
            sqlUpit.Parameters.Add(new SqlParameter("@DatumNastajanja", objekt.pDatumNastajanja));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Partner", objekt.pDobavljac));


            if (objekt.pVrstaDokumenta == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Dokumenta", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Dokumenta", objekt.pVrstaDokumenta));
            }

            if (objekt.pSkaldiste == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Skladista", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Skladista", objekt.pSkaldiste));
            }

            if (objekt.pDatumDokumentaDobavljaca == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@DatumDobavljaca", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@DatumDobavljaca", objekt.pDatumDokumentaDobavljaca));
            }
            if (objekt.pNarudzbenica == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Narudzbenica", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Narudzbenica", objekt.pNarudzbenica));
            }
            if (objekt.pNeto == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Neto", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Neto", objekt.pNeto));
            }
            if (objekt.pPDV == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@PDV", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@PDV", objekt.pPDV));
            }
            if (objekt.pBruto == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Bruto", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Bruto", objekt.pBruto));
            }
            if (objekt.pZavrsniTransport == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Transport", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Transport", objekt.pZavrsniTransport));
            }
            if (objekt.pZavrsniCarina == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Carina", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Carina", objekt.pZavrsniCarina));
            }
            if (objekt.pZavrsniOstalo == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Ostalo", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Ostalo", objekt.pZavrsniOstalo));
            }
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));
            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            if (pBrojUlaznogDokumenta != null)
            {
                if (pBrojUlaznogDokumenta.Length == 0)
                {
                    sqlUpit.Parameters.Add(new SqlParameter("@BrojUlaznogDokumenta", DBNull.Value));
                }
                else
                {
                    sqlUpit.Parameters.Add(new SqlParameter("@BrojUlaznogDokumenta", pBrojUlaznogDokumenta));
                }
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@BrojUlaznogDokumenta", DBNull.Value));
            }

            if (objekt.pOpis == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Opis", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Opis", objekt.pOpis));
            }

            if (preneseno)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Preneseno", false));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Preneseno", true));
            }

            try
            {
                CheckIsDateOrWarehouseModified();

                sqlUpit.ExecuteNonQuery();

                //dok jos nije zaduzeno
                if (preneseno && kontrola_stavke)
                {
                    kontrola_stavke = false;

                    if (DeleteStavke(message, sqlUpit))
                    {
                        if (InsertStavke(message, sqlUpit, (int)pID, objekt))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if ((!preneseno && kontrola_stavke) | ((!preneseno) & (originalDate != null || originalWarhouse != null)))
                {
                    if (originalDate != null || originalWarhouse != null)
                    {
                        //1. broisanje reda 2. rekalkulacija
                        razlika = GetEmptyData(true);
                        //mjenjani datum i skladiste
                        if (originalWarhouse != null & originalDate != null)
                            SetToZeroAndRecalculate(razlika, originalDate.Value, originalWarhouse.Value, sqlUpit);
                        //mjenjano skladiste
                        else if (originalWarhouse != null & originalDate == null)
                            SetToZeroAndRecalculate(razlika, pDatumNastajanja, originalWarhouse.Value, sqlUpit);
                        //mjenjan datum
                        else if (originalWarhouse == null & originalDate != null)
                            SetToZeroAndRecalculate(razlika, originalDate.Value, (int)pSkaldiste, sqlUpit);

                        foreach (var item in GetEmptyData(false))
                        {
                            razlika = new List<PrimkaStavke>();
                            razlika.Add(item);
                            InsertNewRows(item, sqlUpit);
                            CalculateStockAfterInsert(razlika, pDatumNastajanja, pSkaldiste, sqlUpit, false, Convert.ToInt32(sqlUpit.Parameters["@RedniBrojDan"].Value));
                            item.redniBroj = Convert.ToInt32(sqlUpit.Parameters["@RedniBrojDan"].Value);
                            UpdateRedniBroj(item, sqlUpit, pDatumNastajanja, (int)pSkaldiste);
                        }
                    }

                    //razlika od onoga u bazi
                    razlika = GetDifferences();

                    if (razlika.Count > 0)
                    {
                        if (originalDate == null & originalWarhouse == null)
                        {
                            foreach (var item in razlika)
                            {
                                if (item.redniBroj != null)
                                {
                                    CalculateStockUpdate(item, pDatumNastajanja, (int)pSkaldiste, sqlUpit);
                                    //UpdateStavke(item, sqlUpit, pDatumNastajanja, (int)pSkaldiste, (int)item.redniBroj);
                                }
                                else
                                {
                                    //kad se doda nova stavka u primku
                                    InsertNewRows(item, sqlUpit);
                                    item.redniBroj = Convert.ToInt32(sqlUpit.Parameters["@RedniBrojDan"].Value);
                                    CalculateStockAfterInsert(item, pDatumNastajanja, pSkaldiste, sqlUpit, false);
                                }
                            }
                        }
                        else
                        {
                            ////kad su mjenjane stavke i mjenjan datum ili skladiste, update dokumenta
                            //foreach (var item in razlika)
                            //{
                            //    UpdateStavke(item, sqlUpit, pDatumNastajanja, (int)pSkaldiste, RedniBrojSkladisteDan(pDatumNastajanja.ToString("yyyy-MM-dd"), (int)pSkaldiste, item.idProizvod, sqlUpit));
                            //}
                        }
                    }
                    return true;
                }
                else
                {
                    return true;
                }
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

        private void InsertNewRows(PrimkaStavke item, SqlCommand sqlUpit)
        {
            sqlUpit.Parameters["@Kolicina"].Value = item.kolicina;

            sqlUpit.Parameters["@TS"].Value = GetDatumNastajanja(item.idPrimka);
            sqlUpit.Parameters["@Stanje"].Value = Math.Round(Convert.ToDecimal(GetStanjeModified(item.idProizvod, pSkaldiste, pDatumNastajanja)) + item.kolicina, 4);
            sqlUpit.Parameters["@Saldo"].Value = Math.Round(Convert.ToDecimal(GetSaldoModified(item.idProizvod, pSkaldiste, pDatumNastajanja)) + (item.kolicina * item.cijenaPDV), 4);
            sqlUpit.Parameters["@RedniBrojDan"].Value = RedniBrojSkladisteDan(Convert.ToDateTime(sqlUpit.Parameters["@TS"].Value).ToString("yyyy-MM-dd"),
                                                                                Convert.ToInt32(sqlUpit.Parameters["@ID_Skladista"].Value), item.idProizvod, sqlUpit);


            sqlUpit.CommandText = "Insert Into MT_SkladisteStavke ([ID_Skladista],[ID_Proizvod],[ID_PrimkaStavke],[Kolicina],[Stanje],[Saldo],[TS], RedniBrojDan) Values " +
                                  "('" + (int)pSkaldiste + "', '" + item.idProizvod + "', '" + GetIdPrimkaStavke(item) + "', @Kolicina, @Stanje, @Saldo, @TS, @RedniBrojDan)";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            { }
        }

        private List<PrimkaStavke> GetEmptyData(bool stanje)
        {
            List<PrimkaStavke> temp;
            if (stanje)
            {
                temp = client.GetDataTable("Select * From MT_PrimkaStavke Where ID_Primke = " + pID).AsEnumerable().Select(m => new PrimkaStavke()
                {
                    idPrimka = m.Field<int>("ID_Primke"),
                    idProizvod = m.Field<int>("ID_Proizvoda"),
                    idJedinicaMjere = m.Field<int>("ID_JedinicaMjere"),
                    cijena = 0,
                    idPorez = m.Field<int>("ID_Porez"),
                    kolicina = 0,
                    cijenaPDV = 0,
                    redniBroj = m.Field<int>("RedniBrojDan"),
                }).ToList();
            }
            else
            {
                temp = BusinessLogic.Primka.pPrimkaStavke.AsEnumerable().Select(m => new PrimkaStavke()
                {
                    idPrimka = m.Field<int>("ID_Primke"),
                    idProizvod = m.Field<int>("ID_Proizvoda"),
                    idJedinicaMjere = m.Field<int>("ID_JedinicaMjere"),
                    cijena = m.Field<decimal>("cijena"),
                    idPorez = m.Field<int>("ID_Porez"),
                    kolicina = m.Field<decimal>("Kolicina"),
                    cijenaPDV = m.Field<decimal>("CijenaPDV"),
                }).ToList();
            }

            return temp;
        }

        private void CheckIsDateOrWarehouseModified()
        {
            try
            {
                originalDate = Convert.ToDateTime(client.ExecuteScalar("Select DatumNastajanja From MT_Primka Where ID = " + pID));
                if (originalDate.Value.ToString("yyyy-MM-dd") == pDatumNastajanja.ToString("yyyy-MM-dd"))
                {
                    originalDate = null;
                }
            }
            catch { originalDate = null; }

            try
            {
                originalWarhouse = Convert.ToInt32(client.ExecuteScalar("Select ID_Skladista From MT_Primka Where ID = " + pID));
                if (originalWarhouse == pSkaldiste)
                {
                    originalWarhouse = null;
                }
            }
            catch { originalWarhouse = null; }
        }

        private void SetToZeroAndRecalculate(List<PrimkaStavke> razlika, DateTime datumNastajanja, int skladiste, SqlCommand sqlUpit)
        {
            DataTable dtRedovi = new DataTable("Redovi");
            SqlCommand sqlComm;
            SqlDataAdapter da = new SqlDataAdapter();
            sqlComm = new SqlCommand("spSkladisteDeleteAndRecalculate", client.sqlConnection);

            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@Datum", datumNastajanja.ToString("yyyy-MM-dd"));
            sqlComm.Parameters.AddWithValue("@Skladiste", skladiste);
            sqlComm.Parameters.Add(new SqlParameter("@Proizvod", SqlDbType.Int));
            sqlComm.Parameters.Add(new SqlParameter("@rednibroj", SqlDbType.Int));

            foreach (var item in razlika)
            {
                dtRedovi.Clear();
                sqlComm.Parameters["@Proizvod"].Value = item.idProizvod;
                sqlComm.Parameters["@rednibroj"].Value = item.redniBroj;
                da.SelectCommand = sqlComm;
                da.Fill(dtRedovi);
                DeleteFromStockRecalculate(item, dtRedovi, sqlUpit, (int)skladiste);
            }
        }

        private void CalculateStockUpdate(PrimkaStavke razlika, DateTime datumNastajanja, int skladiste, SqlCommand sqlUpit)
        {
            DataTable dtRedovi = new DataTable("Redovi");
            SqlCommand sqlComm;
            SqlDataAdapter da = new SqlDataAdapter();
            sqlComm = new SqlCommand("spSkladisteDeleteAndRecalculate", client.sqlConnection);

            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@Datum", datumNastajanja.ToString("yyyy-MM-dd"));
            sqlComm.Parameters.AddWithValue("@Skladiste", skladiste);

            sqlComm.Parameters.AddWithValue("@Proizvod", razlika.idProizvod);
            sqlComm.Parameters.AddWithValue("@rednibroj", razlika.redniBroj);

            da.SelectCommand = sqlComm;
            da.Fill(dtRedovi);
            DeleteFromStockRecalculateUpdate(razlika, dtRedovi, sqlUpit, (int)skladiste);
        }

        private void CalculateStockAfterInsert(List<PrimkaStavke> razlika, DateTime datumNastajanja, int? skladiste, SqlCommand sqlUpit, bool vrsta, int redniBroj)
        {
            DataTable dtRedovi = new DataTable("Redovi");
            SqlCommand sqlComm;
            SqlDataAdapter da = new SqlDataAdapter();
            sqlComm = new SqlCommand("spSkladisteRowsToUpdate2", client.sqlConnection);

            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@Datum", datumNastajanja.ToString("yyyy-MM-dd"));
            sqlComm.Parameters.AddWithValue("@Skladiste", skladiste);
            sqlComm.Parameters.Add(new SqlParameter("@Proizvod", SqlDbType.Int));
            sqlComm.Parameters.AddWithValue("@rednibroj", redniBroj);


            foreach (var item in razlika)
            {
                dtRedovi.Clear();
                sqlComm.Parameters["@Proizvod"].Value = item.idProizvod;
                da.SelectCommand = sqlComm;
                da.Fill(dtRedovi);
                UpdateStock(item, dtRedovi, sqlUpit, vrsta, (int)skladiste, item.idProizvod);
            }
        }


        private void CalculateStockAfterInsert(PrimkaStavke razlika, DateTime datumNastajanja, int? skladiste, SqlCommand sqlUpit, bool vrsta)
        {
            DataTable dtRedovi = new DataTable("Redovi");
            SqlCommand sqlComm;
            SqlDataAdapter da = new SqlDataAdapter();
            sqlComm = new SqlCommand("spSkladisteRowsToUpdate2", client.sqlConnection);

            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@Datum", datumNastajanja.ToString("yyyy-MM-dd"));
            sqlComm.Parameters.AddWithValue("@Skladiste", skladiste);
            sqlComm.Parameters.Add(new SqlParameter("@Proizvod", SqlDbType.Int));
            sqlComm.Parameters.AddWithValue("@rednibroj", razlika.redniBroj);

            sqlComm.Parameters["@Proizvod"].Value = razlika.idProizvod;
            da.SelectCommand = sqlComm;
            da.Fill(dtRedovi);
            UpdateStock(razlika, dtRedovi, sqlUpit, vrsta, (int)skladiste, razlika.idProizvod);
        }


        private void CalculateStock(List<PrimkaStavke> razlika, DateTime datumNastajanja, int? skladiste, SqlCommand sqlUpit, bool vrsta)
        {
            DataTable dtRedovi = new DataTable("Redovi");
            SqlCommand sqlComm;
            SqlDataAdapter da = new SqlDataAdapter();
            sqlComm = new SqlCommand("spSkladisteRowsToUpdate", client.sqlConnection);

            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@Datum", datumNastajanja);
            sqlComm.Parameters.AddWithValue("@Skladiste", skladiste);
            sqlComm.Parameters.Add(new SqlParameter("@Proizvod", SqlDbType.Int));


            foreach (var item in razlika)
            {
                dtRedovi.Clear();
                sqlComm.Parameters["@Proizvod"].Value = item.idProizvod;
                da.SelectCommand = sqlComm;
                da.Fill(dtRedovi);
                UpdateStock(item, dtRedovi, sqlUpit, vrsta, (int)skladiste, item.idProizvod);
            }
        }

        private void CalculateStock2(List<PrimkaStavke> razlika, DateTime datumNastajanja, int? skladiste, SqlCommand sqlUpit, bool vrsta, int redniBroj)
        {
            DataTable dtRedovi = new DataTable("Redovi");
            SqlCommand sqlComm;
            SqlDataAdapter da = new SqlDataAdapter();
            sqlComm = new SqlCommand("spSkladisteRowsToUpdate2", client.sqlConnection);

            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@Datum", datumNastajanja.ToString("yyyy-MM-dd"));
            sqlComm.Parameters.AddWithValue("@Skladiste", skladiste);
            sqlComm.Parameters.Add(new SqlParameter("@Proizvod", SqlDbType.Int));

            foreach (var item in razlika)
            {
                dtRedovi.Clear();
                sqlComm.Parameters["@Proizvod"].Value = item.idProizvod;
                sqlComm.Parameters.AddWithValue("@rednibroj", redniBroj);
                da.SelectCommand = sqlComm;
                da.Fill(dtRedovi);
                UpdateStock(item, dtRedovi, sqlUpit, vrsta, (int)skladiste, item.idProizvod);
            }
        }

        private void UpdateStock(PrimkaStavke item, DataTable dtRedovi, SqlCommand sqlUpit, bool vrsta, int skladiste, int proizvod)
        {
            int id = 0;
            int brojac = 0;
            string changedDocuments = "";
            DateTime datum = new DateTime();

            //u slucaju kad se dodao novi artikl koji jos ne postoji u zalihama
            if (dtRedovi.Rows.Count == 0)
            {
                InsertStockIfNew(item, sqlUpit, skladiste);
            }

            foreach (DataRow row in dtRedovi.Rows)
            {
                brojac++;

                sqlUpit.Parameters["@ID"].Value = row["ID"];
                datum = Convert.ToDateTime(row["DatumDokumenta"]);

                if (row["Vrsta"].ToString() == "Pri" && brojac == 1 & vrsta)
                {
                    sqlUpit.Parameters["@Kolicina"].Value = item.kolicina;
                    sqlUpit.Parameters["@Saldo"].Value = Math.Round(GetSaldo(Convert.ToDecimal(row["Saldo"]), Convert.ToDecimal(row["Kolicina"]), Convert.ToDecimal(row["Cijena"]), item.kolicina, item.cijenaPDV), 4);
                    sqlUpit.Parameters["@Stanje"].Value = Math.Round(Convert.ToDecimal(row["Stanje"]) - Convert.ToDecimal(row["Kolicina"]) + item.kolicina, 4);
                    try
                    {
                        sqlUpit.CommandText = "Update MT_SkladisteStavke Set Kolicina = @Kolicina, Saldo = @Saldo, Stanje = @Stanje Where ID = @ID";
                        sqlUpit.ExecuteNonQuery();
                    }
                    catch { }

                    //update prve stavke

                }
                else if (row["Vrsta"].ToString() == "Pri" && brojac > 1)
                {
                    sqlUpit.Parameters["@Kolicina"].Value = Convert.ToDecimal(row["Kolicina"]);
                    sqlUpit.Parameters["@Stanje"].Value = Math.Round(GetStanje(id, Convert.ToDecimal(row["Kolicina"]), row["Vrsta"].ToString()), 4);
                    sqlUpit.Parameters["@Saldo"].Value = GetSaldoPrimka(id, Convert.ToDecimal(row["Kolicina"]), Convert.ToDecimal(row["Cijena"]));

                    try
                    {
                        sqlUpit.CommandText = "Update MT_SkladisteStavke Set Kolicina = @Kolicina, Saldo = @Saldo, Stanje = @Stanje Where ID = @ID";
                        sqlUpit.ExecuteNonQuery();
                    }
                    catch { }

                    ////update primka
                    //UpdateStavke(idStavka
                }
                else if (row["Vrsta"].ToString() == "Izd")
                {
                    sqlUpit.Parameters["@Kolicina"].Value = Convert.ToDecimal(row["Kolicina"]);
                    sqlUpit.Parameters["@Stanje"].Value = Math.Round(GetStanje(id, Convert.ToDecimal(row["Kolicina"]), row["Vrsta"].ToString()), 4);
                    sqlUpit.Parameters["@Saldo"].Value = GetSaldoSetCijena(id, Convert.ToDecimal(row["idStavke"]), Convert.ToDecimal(row["Kolicina"]),
                        datum, proizvod, sqlUpit, skladiste);

                    if (changedDocuments.Length == 0)
                    {
                        changedDocuments = row["Izdatnica"].ToString();
                    }
                    else
                    {
                        changedDocuments += ", " + row["Izdatnica"].ToString();
                    }

                    try
                    {
                        sqlUpit.CommandText = "Update MT_SkladisteStavke Set Kolicina = @Kolicina, Saldo = @Saldo, Stanje = @Stanje Where ID = @ID";
                        sqlUpit.ExecuteNonQuery();
                    }
                    catch { }
                }

                brojac++;
                id = Convert.ToInt32(row["ID"]);
            }

            if (changedDocuments.Length > 0)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Za proizvod {0} promjenjene su izdatnice: {1}. Provjerite cijene!!!", GetPrizvodText(item.idProizvod), changedDocuments));
            }
        }

        private void DeleteFromStockRecalculateUpdate(PrimkaStavke item, DataTable dtRedovi, SqlCommand sqlUpit, int skladiste)
        {
            int brojac = 0;

            decimal kolicina = 0; decimal cijena = 0; string vrsta = ""; Nullable<decimal> stopa = 0; int idStavka = 0; DateTime datumDokumenta = new DateTime(); int redniBroj = 0;
            decimal prosjecnaCijena = 0;

            foreach (DataRow row in dtRedovi.Rows)
            {
                brojac++;
                sqlUpit.Parameters["@ID"].Value = row["ID"];
                vrsta = row["Vrsta"].ToString();
                //kolicina na stavci
                kolicina = Convert.ToDecimal(row["Kolicina"]);
                cijena = Convert.ToDecimal(row["Cijena"]);
                if (row["Stopa"].ToString().Length > 0)
                {
                    stopa = Convert.ToDecimal(row["Stopa"]);
                }
                else { stopa = null; }
                idStavka = Convert.ToInt32(row["idStavke"]);
                datumDokumenta = Convert.ToDateTime(row["DatumDokumenta"]);
                redniBroj = Convert.ToInt32(row["RedniBrojDan"]);

                if (brojac == 1 && item.kolicina == 0)
                {
                    sqlUpit.Parameters["@Saldo"].Value = 0;
                    sqlUpit.Parameters["@Stanje"].Value = 0;
                    sqlUpit.Parameters["@Kolicina"].Value = 0;
                    sqlUpit.CommandText = "Delete From MT_SkladisteStavke Where ID = @ID";

                    try
                    {
                        sqlUpit.ExecuteNonQuery();
                    }
                    catch { }

                    //brisanje iz dokumenta
                    UpdateStavke(idStavka, sqlUpit);
                }
                else if (brojac == 1 && item.kolicina != 0)
                {
                    sqlUpit.CommandText = "Update MT_SkladisteStavke Set Kolicina = @Kolicina, Saldo = @Saldo, Stanje = @Stanje Where ID = @ID";
                    sqlUpit.Parameters["@Kolicina"].Value = item.kolicina;

                    if (vrsta == "Pri")
                    {
                        sqlUpit.Parameters["@Saldo"].Value = Math.Round(Convert.ToDecimal(row["Saldo"]) - (kolicina * cijena) + (item.kolicina * item.cijenaPDV), 4);
                        sqlUpit.Parameters["@Stanje"].Value = Math.Round(Convert.ToDecimal(row["Stanje"]) - kolicina + item.kolicina, 4);
                    }

                    try
                    {
                        sqlUpit.ExecuteNonQuery();
                    }
                    catch { }

                    //update prve stavke. kupi cijenu iz forme 
                    UpdateStavke(idStavka, item.cijenaPDV, item.cijena, sqlUpit);
                }

                if (brojac > 1)
                {
                    sqlUpit.Parameters["@Kolicina"].Value = Convert.ToDecimal(row["Kolicina"]);

                    if (vrsta == "Pri")
                    {
                        sqlUpit.CommandText = "Update MT_SkladisteStavke Set Saldo = @Saldo, Stanje = @Stanje Where ID = @ID";
                        sqlUpit.Parameters["@Saldo"].Value = Math.Round(Convert.ToDecimal(sqlUpit.Parameters["@Saldo"].Value) + (kolicina * cijena), 4);
                        sqlUpit.Parameters["@Stanje"].Value = Math.Round(Convert.ToDecimal(sqlUpit.Parameters["@Stanje"].Value) + kolicina, 4);

                        try
                        {
                            sqlUpit.ExecuteNonQuery();
                        }
                        catch { }
                        //update primke
                        //UpdateStavke(idStavka,  Convert.ToDecimal(sqlUpit.Parameters["@Saldo"].Value), Convert.ToDecimal(sqlUpit.Parameters["@Stanje"].Value), (int)stopa, sqlUpit);
                    }
                    else if (vrsta == "Izd")
                    {
                        try
                        {
                            prosjecnaCijena = GetAverigePrice(datumDokumenta, item.idProizvod, sqlUpit, skladiste, 0);
                        }
                        catch { }

                        sqlUpit.CommandText = "Update MT_SkladisteStavke Set Saldo = @Saldo, Stanje = @Stanje Where ID = @ID";
                        sqlUpit.Parameters["@Saldo"].Value = Math.Round(Convert.ToDecimal(sqlUpit.Parameters["@Saldo"].Value) - (kolicina * prosjecnaCijena), 4);
                        sqlUpit.Parameters["@Stanje"].Value = Math.Round(Convert.ToDecimal(sqlUpit.Parameters["@Stanje"].Value) - kolicina, 4);

                        try
                        {
                            sqlUpit.ExecuteNonQuery();
                        }
                        catch { }
                        //update izdatnice 
                        UpdateStavke(idStavka, prosjecnaCijena, sqlUpit);
                    }
                }
            }
        }

        private void DeleteFromStockRecalculate(PrimkaStavke item, DataTable dtRedovi, SqlCommand sqlUpit, int skladiste)
        {
            int brojac = 0;

            decimal kolicina = 0; decimal cijenaPrije = 0; string vrsta = "";
            decimal kolPrije = 0; decimal stPrije = 0; decimal salPrije = 0;
            decimal prCijena = 0; int redniBroj = 0; DateTime datumDokumenta = new DateTime(); int idStavka = 0;

            foreach (DataRow row in dtRedovi.Rows)
            {
                brojac++;
                sqlUpit.Parameters["@ID"].Value = row["ID"];
                sqlUpit.Parameters["@Saldo"].Value = 0;
                sqlUpit.Parameters["@Stanje"].Value = 0;
                sqlUpit.Parameters["@Kolicina"].Value = 0;
                vrsta = row["Vrsta"].ToString();
                kolicina = Convert.ToDecimal(row["Kolicina"]);
                redniBroj = Convert.ToInt32(row["RedniBrojdan"]);
                datumDokumenta = Convert.ToDateTime(row["DatumDokumenta"]);
                idStavka = Convert.ToInt32(row["idStavke"]);

                if (brojac == 1)
                {
                    sqlUpit.CommandText = "Delete From MT_SkladisteStavke Where ID = @ID";
                    try
                    {
                        sqlUpit.ExecuteNonQuery();

                        kolPrije = kolicina;
                        stPrije = Convert.ToDecimal(row["Stanje"]);
                        salPrije = Convert.ToDecimal(row["Saldo"]);
                        cijenaPrije = Convert.ToDecimal(row["Cijena"]);
                    }
                    catch { }
                }

                if (brojac == 2)
                {
                    sqlUpit.Parameters["@Kolicina"].Value = Convert.ToDecimal(row["Kolicina"]);

                    if (vrsta == "Pri")
                    {
                        sqlUpit.CommandText = "Update MT_SkladisteStavke Set Kolicina = @Kolicina, Saldo = @Saldo, Stanje = @Stanje Where ID = @ID";
                        sqlUpit.Parameters["@Saldo"].Value = Math.Round((salPrije + (kolPrije * cijenaPrije)) + (kolicina * Convert.ToDecimal(row["Cijena"])), 4);
                        sqlUpit.Parameters["@Stanje"].Value = (stPrije + kolPrije) + kolicina;

                        try
                        {
                            sqlUpit.ExecuteNonQuery();
                        }
                        catch { }
                    }
                    else if (vrsta == "Izd")
                    {
                        prCijena = GetAverigePrice(datumDokumenta, item.idProizvod, sqlUpit, skladiste, 0);

                        sqlUpit.CommandText = "Update MT_SkladisteStavke Set Kolicina = @Kolicina, Saldo = @Saldo, Stanje = @Stanje Where ID = @ID";
                        sqlUpit.Parameters["@Saldo"].Value = Math.Round((salPrije + (kolPrije * cijenaPrije)) - (kolicina * prCijena), 4);
                        sqlUpit.Parameters["@Stanje"].Value = (stPrije + kolPrije) - kolicina;

                        try
                        {
                            sqlUpit.ExecuteNonQuery();
                        }
                        catch { }

                        UpdateStavke(idStavka, prCijena, sqlUpit);
                    }

                    kolPrije = kolicina;
                    stPrije = Convert.ToDecimal(sqlUpit.Parameters["@Stanje"].Value);
                    salPrije = Convert.ToDecimal(sqlUpit.Parameters["@Saldo"].Value);
                    cijenaPrije = prCijena;
                }

                if (brojac > 2)
                {
                    sqlUpit.Parameters["@Kolicina"].Value = Convert.ToDecimal(row["Kolicina"]);

                    if (vrsta == "Pri")
                    {
                        sqlUpit.CommandText = "Update MT_SkladisteStavke Set Kolicina = @Kolicina, Saldo = @Saldo, Stanje = @Stanje Where ID = @ID";
                        sqlUpit.Parameters["@Saldo"].Value = Math.Round(salPrije + (kolicina * Convert.ToDecimal(row["Cijena"])), 4);
                        sqlUpit.Parameters["@Stanje"].Value = stPrije + kolicina;

                        try
                        {
                            sqlUpit.ExecuteNonQuery();
                        }
                        catch { }
                    }
                    else if (vrsta == "Izd")
                    {
                        prCijena = GetAverigePrice(datumDokumenta, item.idProizvod, sqlUpit, skladiste, 0);

                        sqlUpit.CommandText = "Update MT_SkladisteStavke Set Kolicina = @Kolicina, Saldo = @Saldo, Stanje = @Stanje Where ID = @ID";
                        sqlUpit.Parameters["@Saldo"].Value = Math.Round(salPrije - (kolicina * prCijena), 4);
                        sqlUpit.Parameters["@Stanje"].Value = stPrije - kolicina;

                        try
                        {
                            sqlUpit.ExecuteNonQuery();
                        }
                        catch { }

                        UpdateStavke(idStavka, prCijena, sqlUpit);
                    }

                    kolPrije = kolicina;
                    stPrije = Convert.ToDecimal(sqlUpit.Parameters["@Stanje"].Value);
                    salPrije = Convert.ToDecimal(sqlUpit.Parameters["@Saldo"].Value);
                    cijenaPrije = prCijena;
                }
            }
        }


        private string GetPrizvodText(int proizvod)
        {
            return client.ExecuteScalar("Select NAZIVPROIZVOD From PROIZVOD Where IDPROIZVOD = " + proizvod).ToString();
        }

        private void InsertStockIfNew(PrimkaStavke item, SqlCommand sqlUpit, int skladiste)
        {
            sqlUpit.Parameters["@Kolicina"].Value = item.kolicina;
            sqlUpit.Parameters["@Stanje"].Value = item.kolicina;
            sqlUpit.Parameters["@Saldo"].Value = item.kolicina * item.cijenaPDV;
            sqlUpit.Parameters["@TS"].Value = GetDatumNastajanja(item.idPrimka);

            sqlUpit.CommandText = "Insert Into MT_SkladisteStavke ([ID_Skladista],[ID_Proizvod],[ID_PrimkaStavke],[Kolicina],[Stanje],[Saldo],[TS]) Values " +
                                  "('" + skladiste + "', '" + item.idProizvod + "', '" + GetIdPrimkaStavke(item) + "', @Kolicina, @Stanje, @Saldo, @TS)";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {

            }
        }

        private object GetSaldoModified(int proizvod, int? pSkaldiste, DateTime pDatumNastajanja)
        {
            return client.ExecuteScalar("Select Top 1 MT_SkladisteStavke.Saldo From MT_SkladisteStavke Where MT_SkladisteStavke.TS <= '" + pDatumNastajanja.ToString("yyyy-MM-dd") +
                                        "' And Kolicina > 0 And MT_SkladisteStavke.ID_Skladista = " + pSkaldiste + " And MT_SkladisteStavke.ID_Proizvod = " + proizvod + " Order by TS desc, RedniBrojDan desc");
        }

        private object GetStanjeModified(int proizvod, int? pSkaldiste, DateTime pDatumNastajanja)
        {
            return client.ExecuteScalar("Select Top 1 MT_SkladisteStavke.Stanje From MT_SkladisteStavke Where MT_SkladisteStavke.TS <= '" + pDatumNastajanja.ToString("yyyy-MM-dd") +
                                        "' And Kolicina > 0 And MT_SkladisteStavke.ID_Skladista = " + pSkaldiste + " And MT_SkladisteStavke.ID_Proizvod = " + proizvod + " Order by TS desc, RedniBrojDan desc");
        }

        private object GetDatumNastajanja(int primka)
        {
            return client.ExecuteScalar("Select DatumNastajanja From MT_Primka Where ID = " + primka);
        }

        private string GetIdPrimkaStavke(PrimkaStavke item)
        {
            string id = "";
            try
            {
                id = client.ExecuteScalar("Select ID From MT_PrimkaStavke Where ID_Primke = '" + item.idPrimka + "' And ID_Proizvoda = '" + item.idProizvod + "'").ToString();
            }
            catch
            {
                id = client.ExecuteScalar("Insert Into MT_PrimkaStavke ([ID_Primke], [ID_Proizvoda], [ID_JedinicaMjere], [Cijena], [ID_Porez], [Kolicina], [CijenaPDV], [RedniBroj]) " +
                                          "Values (" + item.idPrimka + ", " + item.idProizvod + ", " + item.idJedinicaMjere + ", '" + item.cijena.ToString().Replace(',', '.') +
                                          "', " + item.idPorez + ", '" + item.kolicina.ToString().Replace(',', '.') + "', '" + item.cijenaPDV.ToString().Replace(',', '.') + "', " +
                                          GetRedniBroj(item.idPrimka) + ") Select @@Identity").ToString();
            }

            return id;
        }

        private string GetRedniBroj(int primka)
        {
            string redniBroj = client.ExecuteScalar("Select Max(RedniBroj) + 1 From MT_PrimkaStavke Where ID_Primke = " + primka).ToString();

            if (redniBroj.Length == 0)
            {
                return "1";
            }

            return redniBroj;
        }

        private object GetSaldoPrimka(int id, decimal kolicina, decimal cijena)
        {
            return Math.Round(Convert.ToDecimal(client.ExecuteScalar("Select Saldo From MT_SkladisteStavke Where ID = " + id)) + (kolicina * cijena), 4);
        }

        private object GetSaldoSetCijena(int id, decimal idStavka, decimal kolicina, DateTime datum, int proizvod, SqlCommand sqlUpit, int skladiste)
        {
            decimal averagePrice = GetAverigePrice(datum, proizvod, sqlUpit, skladiste, 0);

            if (averagePrice == 0)
            {
                averagePrice = Math.Round(Convert.ToDecimal(client.ExecuteScalar("Select UkupanIznos fROM MT_IzdatnicaStavka Where ID = " + idStavka)), 4);
            }

            //update izdatnice i stavke koja se dira
            decimal ukupno = Convert.ToDecimal(client.ExecuteScalar("Select UkupanIznos From MT_IzdatnicaStavka Where ID = " + idStavka));
            client.ExecuteNonQuery("Update MT_IzdatnicaStavka Set NabavnaCijena = " + Math.Round(averagePrice, 4).ToString().Replace(',', '.') + ", UkupanIznos = Kolicina * " +
                                     Math.Round(averagePrice, 4).ToString().Replace(',', '.') + " Where ID = " + idStavka);
            //novi ukupan iznos
            decimal newUkupno = Convert.ToDecimal(client.ExecuteScalar("Select UkupanIznos From MT_IzdatnicaStavka Where ID = " + idStavka));

            int idIzdatnica = Convert.ToInt32(client.ExecuteScalar("Select ID_Izdatnice From MT_IzdatnicaStavka Where ID = " + idStavka));
            client.ExecuteNonQuery("Update MT_Izdatnica Set UkupanIznos = UkupanIznos - " + Math.Round(ukupno, 4).ToString().Replace(',', '.') + " + " +
                                    Math.Round(newUkupno, 4).ToString().Replace(',', '.') + "  Where ID = " + idIzdatnica);

            return Math.Round(Convert.ToDecimal(client.ExecuteScalar("Select Saldo From MT_SkladisteStavke Where ID = " + id)) - (averagePrice * kolicina), 4);

        }

        private decimal GetStanje(int id, decimal kolicina, string vrsta)
        {
            if (vrsta == "Pri")
            {
                return Convert.ToDecimal(client.ExecuteScalar("Select Stanje From MT_SkladisteStavke Where ID = " + id)) + kolicina;
            }
            else if (vrsta == "Izd")
            {
                return Convert.ToDecimal(client.ExecuteScalar("Select Stanje From MT_SkladisteStavke Where ID = " + id)) - kolicina;
            }
            else
            {
                return Convert.ToDecimal(client.ExecuteScalar("Select Stanje From MT_SkladisteStavke Where ID = " + id)) - kolicina;
            }
        }

        private decimal GetSaldo(decimal saldoBaza, decimal kolicinaBaza, decimal cijenaBaza, decimal kolicina, decimal cijena)
        {
            return saldoBaza - (kolicinaBaza * cijenaBaza) + (kolicina * cijena);
        }

        private List<PrimkaStavke> GetDifferences()
        {
            List<PrimkaStavke> izBaze = client.GetDataTable("Select * From MT_PrimkaStavke Where ID_Primke = " + pID).AsEnumerable().Select(m => new PrimkaStavke()
            {
                idPrimka = m.Field<int>("ID_Primke"),
                idProizvod = m.Field<int>("ID_Proizvoda"),
                idJedinicaMjere = m.Field<int>("ID_JedinicaMjere"),
                cijena = m.Field<decimal>("cijena"),
                idPorez = m.Field<int>("ID_Porez"),
                kolicina = m.Field<decimal>("Kolicina"),
                cijenaPDV = m.Field<decimal>("CijenaPDV"),
                redniBroj = m.Field<int>("RedniBrojDan"),
            }).ToList();


            List<PrimkaStavke> temp = BusinessLogic.Primka.pPrimkaStavke.AsEnumerable().Select(m => new PrimkaStavke()
            {
                idPrimka = m.Field<int>("ID_Primke"),
                idProizvod = m.Field<int>("ID_Proizvoda"),
                idJedinicaMjere = m.Field<int>("ID_JedinicaMjere"),
                cijena = m.Field<decimal>("cijena"),
                idPorez = m.Field<int>("ID_Porez"),
                kolicina = m.Field<decimal>("Kolicina"),
                cijenaPDV = m.Field<decimal>("CijenaPDV"),
                redniBroj = null,
            }).ToList();

            List<PrimkaStavke> razlike = new List<PrimkaStavke>();

            //ne postoji u tempu obrisan u aplikaciji
            var dontExistInBase = izBaze.Where(p => !temp.Any(p2 => p2.idProizvod == p.idProizvod));

            //ne postoji u bazi dodan novi item
            var dontExistInTemp = temp.Where(p => !izBaze.Any(p2 => p2.idProizvod == p.idProizvod));

            //razlike koje su nastle na artiklima koji su u bazi i u tempu, te vraca onaj koji je u tempu
            var result = temp.Where(p => !izBaze.Any(p2 => p2.idProizvod == p.idProizvod & p2.kolicina == p.kolicina & p.cijena == p2.cijena)
                & !dontExistInTemp.Any(p2 => p2.idProizvod == p.idProizvod));

            foreach (var item in dontExistInBase)
            {
                item.cijena = 0;
                item.cijenaPDV = 0;
                item.kolicina = 0;
                razlike.Add(item);
            }
            foreach (var item in dontExistInTemp)
            {
                razlike.Add(item);
            }
            foreach (var item in result)
            {
                item.redniBroj = izBaze.Where(x => x.idProizvod == item.idProizvod).ToList()[0].redniBroj;
                razlike.Add(item);
            }

            return razlike;
        }

        /// <summary>
        /// update prve stavke
        /// </summary>
        /// <param name="idPrimkaStavak"></param>
        /// <param name="cijena"></param>
        /// <param name="stopa"></param>
        /// <param name="sqlUpit"></param>
        private void UpdateStavke(int idPrimkaStavak, decimal cijena, decimal neto, SqlCommand sqlUpit)
        {
            sqlUpit.Parameters["@Primka"].Value = idPrimkaStavak;
            sqlUpit.Parameters["@Cijena"].Value = cijena;
            sqlUpit.Parameters["@Porez"].Value = neto;

            try
            {
                sqlUpit.CommandText = "Update MT_PrimkaStavke Set Cijena= @Porez, CijenaPDV= @Cijena, Kolicina = @Kolicina Where ID = @Primka";

                sqlUpit.ExecuteNonQuery();
            }
            catch { }
        }

        /// <summary>
        /// Brisanje stavke ukoliko je nula
        /// </summary>
        /// <param name="idPrimkaStavak"></param>
        /// <param name="sqlUpit"></param>
        private void UpdateStavke(int idPrimkaStavak, SqlCommand sqlUpit)
        {
            sqlUpit.Parameters["@Primka"].Value = idPrimkaStavak;

            try
            {
                sqlUpit.CommandText = "Delete From MT_PrimkaStavke Where ID= @Primka";

                sqlUpit.ExecuteNonQuery();
            }
            catch { }
        }

        /// <summary>
        /// update stavke izdatnica  koja nije prva
        /// </summary>
        /// <param name="idIzdatnica"></param>
        /// <param name="saldo"></param>
        /// <param name="stanje"></param>
        /// <param name="sqlUpit"></param>

        private void UpdateStavke(int idIzdatnica, decimal cijena, SqlCommand sqlUpit)
        {
            sqlUpit.Parameters["@Primka"].Value = idIzdatnica;
            sqlUpit.Parameters["@Cijena"].Value = Math.Abs(cijena);

            sqlUpit.CommandText = "Update MT_IzdatnicaStavka Set NabavnaCijena= @Cijena, UkupanIznos= @Cijena * Kolicina Where ID = @Primka";
            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch { }

            sqlUpit.CommandText = "Select Distinct ID_Izdatnice From MT_IzdatnicaStavka Where ID = @Primka";

            int id = 0;
            try
            {
                id = Convert.ToInt32(sqlUpit.ExecuteNonQuery());
            }
            catch { }

            sqlUpit.Parameters["@Primka"].Value = id;
            sqlUpit.CommandText = "Update MT_Izdatnica Set UkupanIznos = (Select Sum(UkupanIznos) From MT_IzdatnicaStavka Where ID_Izdatnice = @Primka) Where ID = @Primka";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch { }
        }

        /// <summary>
        /// update stavke primka koja nije prva
        /// </summary>
        /// <param name="idPrimakStavka"></param>
        /// <param name="saldo"></param>
        /// <param name="stanje"></param>
        /// <param name="stopa"></param>
        /// <param name="sqlUpit"></param>
        private void UpdateStavke(int idPrimakStavka, decimal saldo, decimal stanje, int stopa, SqlCommand sqlUpit)
        {
            sqlUpit.Parameters["@Primka"].Value = idPrimakStavka;
            sqlUpit.Parameters["@Cijena"].Value = Math.Round(saldo / stanje, 4);
            sqlUpit.Parameters["@Porez"].Value = Convert.ToDecimal(sqlUpit.Parameters["@Cijena"].Value) / (1 + (stopa / 100));

            sqlUpit.CommandText = "Update MT_PrimkaStavke Set Cijena= @Porez, CijenaPDV= @Cijena Where ID = @Primka";
            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch { }
        }


        private void UpdateRedniBroj(PrimkaStavke razlika, SqlCommand sqlUpit, DateTime datumNastajanja, int skladiste)
        {
            sqlUpit.Parameters["@Primka"].Value = razlika.idPrimka;
            sqlUpit.Parameters["@Proizvod"].Value = razlika.idProizvod;
            sqlUpit.Parameters["@Cijena"].Value = razlika.cijena;
            sqlUpit.Parameters["@Porez"].Value = razlika.idPorez;
            sqlUpit.Parameters["@Kolicina"].Value = razlika.kolicina;
            sqlUpit.Parameters["@CijenaPDV"].Value = razlika.cijenaPDV;
            sqlUpit.Parameters["@RedniBrojDan"].Value = razlika.redniBroj;

            sqlUpit.CommandText = "Update MT_PrimkaStavke Set Cijena= @Cijena, ID_Porez= @Porez, Kolicina= @Kolicina, CijenaPDV= @CijenaPDV, RedniBrojDan = @RedniBrojDan " +
                                          "Where ID_Primke= @Primka And ID_Proizvoda= @Proizvod";

            if (razlika.kolicina == 0)
            {
                sqlUpit.CommandText = "Delete From MT_PrimkaStavke Where ID_Primke= @Primka And ID_Proizvoda= @Proizvod";
            }

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch { }
        }

        private void SetAllToZero(SqlCommand sqlUpit)
        {
            sqlUpit.Parameters.Clear();

            sqlUpit.CommandText = "Update MT_PrimkaStavke Set Cijena = 0, Kolicina = 0, CijenaPDV = 0 Where ID_Primke = @ID";
            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch { }
        }

        private bool DeleteStavke(StringBuilder message, SqlCommand sqlUpit)
        {
            sqlUpit.Parameters.Clear();

            sqlUpit.CommandText = "Delete From MT_PrimkaStavke Where ID_Primke = @ID";
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

        internal void SetPreneseno(Dictionary<int, int> primke, StringBuilder message)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.Parameters.Add(new SqlParameter("@ID", ""));

            foreach (KeyValuePair<int, int> primka in primke)
            {
                sqlUpit.CommandText = "Update MT_Primka Set Preneseno = 1 Where ID = @ID";

                sqlUpit.Parameters["@ID"].Value = primka.Key;

                try
                {
                    sqlUpit.ExecuteNonQuery();
                }
                catch (Exception greska) { message.Append(greska.Message); }
            }
        }

        internal bool IsPreneseno()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.Parameters.Add(new SqlParameter("@ID", ""));

            sqlUpit.CommandText = "Select Preneseno From MT_Primka Where ID = @ID";
            sqlUpit.Parameters["@ID"].Value = pID;
            try
            {
                return Convert.ToBoolean(sqlUpit.ExecuteScalar());
            }
            catch { return false; }
        }

        internal bool InsertStavkeSkladiste(Dictionary<int, int> primka, StringBuilder message)
        {
            string primke = string.Empty;

            foreach (KeyValuePair<int, int> item in primka)
            {
                if (primke.Length > 0)
                {
                    primke += "," + item.Key.ToString();
                }
                else
                {
                    primke = item.Key.ToString();
                }
            }

            DataTable dtPrimka = client.GetDataTable("Select MT_Primka.ID As IDPrimka, MT_PrimkaStavke.ID AS ID_PrimkaStavke, Kolicina, MT_Primka.ID_Skladista, MT_PrimkaStavke.ID_Proizvoda, MT_PrimkaStavke.CijenaPDV As Cijena, MT_Primka.DatumNastajanja, MT_PrimkaStavke.ID_Porez, MT_PrimkaStavke.ID_JedinicaMjere, MT_PrimkaStavke.Cijena As Neto From MT_Primka " +
                           "Inner Join MT_PrimkaStavke on MT_Primka.ID = MT_PrimkaStavke.ID_Primke Where MT_Primka.ID In (" + primke + ") And Preneseno = 0");

            //db - 27.1.2017 - dohvat zadnjeg unesenog datuma nastajanja prije odabrane primke
            //DataTable dtPrethodniZapis = client.GetDataTable("select top 1 DatumNastajanja from MT_Primka where ID < '" + primke + "'  order by DatumNastajanja desc");


            //db - 03.02.2017 - provjera da li za ovu primku postoji zapis stavaka u MT_SkladisteStavke po godini datuma kad je ova primka kreirana. ukoliko ne, znaci da je 
            //riječ o POČETNOM stanju
            DateTime datumNastajanjaPrimke = DateTime.MinValue;
            if (dtPrimka.Rows.Count > 0)
            {
                try
                {
                    datumNastajanjaPrimke = Convert.ToDateTime(dtPrimka.Rows[0]["DatumNastajanja"]);
                }
                catch { }
            }

            //db - 03.02.2017 - Broj prethodno zapisanih stavaka u MT_SkladisteStavke po godini datuma nastajanja Primke koja se prenosi
            int brojPrethodnih = Convert.ToInt32(client.GetDataTable("select count(ID_PrimkaStavke) from MT_SkladisteStavke inner join MT_PrimkaStavke on MT_PrimkaStavke.ID = MT_SkladisteStavke.ID_PrimkaStavke	inner join MT_Primka on MT_PrimkaStavke.ID_Primke = MT_Primka.ID where MT_SkladisteStavke.ID_Skladista = '" + Convert.ToInt32(dtPrimka.Rows[0]["ID_Skladista"]) + "' and YEAR(MT_SkladisteStavke.TS) = YEAR('" + datumNastajanjaPrimke.ToString("yyyy-MM-dd") + "') ").Rows[0][0]);

            bool pocetniUnos;
            
            if (brojPrethodnih > 0)
            {
                pocetniUnos = false;
            }
            else
            {
                pocetniUnos = true;
            }


            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            DataTable rowStanje = new DataTable();
            SqlDataAdapter adp;

            sqlUpit.Parameters.Add(new SqlParameter("@ID_Skladiste", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_PrimkaStavke", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Kolicina", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Stanje", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Saldo", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Proizvod", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@ID", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@RedniBroj", ""));

            decimal stanje = 0;
            decimal saldo = 0;
            List<PrimkaStavke> razlika;
            PrimkaStavke stavka;

            //ovaj dio se PRESKAČE ukoliko se unosi npr. inventura PO PRVI PUT u mt_primkastavke
            if (pocetniUnos == false)
            {
                foreach (DataRow row in dtPrimka.Rows)
                {
                    sqlUpit.Parameters["@TS"].Value = Convert.ToDateTime(row["DatumNastajanja"]).ToString("yyyy-MM-dd");
                    sqlUpit.Parameters["@ID_Skladiste"].Value = row["ID_Skladista"];
                    sqlUpit.Parameters["@ID_Proizvod"].Value = row["ID_Proizvoda"];

                    sqlUpit.CommandText = "Select Stanje From MT_SklaDisteStavke Where ID_Skladista = @ID_Skladiste And ID_Proizvod = @ID_Proizvod And TS <= @TS Order by TS Desc, RedniBrojDan Desc";

                    stanje = Convert.ToDecimal(sqlUpit.ExecuteScalar());

                    try
                    {
                        sqlUpit.CommandText = "Select Top(1) ID_PrimkaStavke, ID_IzdatnicaStavke, ID_MeduskladisnicaStavke From MT_SkladisteStavke Where ID_Skladista = @ID_Skladiste " +
                                                      "And ID_Proizvod = @ID_Proizvod And TS <= @TS Order by TS Desc, RedniBrojDan Desc";
                        adp = new SqlDataAdapter(sqlUpit);
                        adp.Fill(rowStanje);

                        //primka
                        if (rowStanje.Rows[0]["ID_PrimkaStavke"].ToString().Length > 0)
                        {
                            sqlUpit.CommandText = "Select Top(1) Saldo From MT_SkladisteStavke Inner Join MT_PrimkaStavke On MT_SkladisteStavke.ID_PrimkaStavke = MT_PrimkaStavke.ID " +
                                                  "Where ID_Skladista = @ID_Skladiste And ID_Proizvoda = @ID_Proizvod And TS <= @TS Order by MT_SkladisteStavke.TS Desc, MT_SkladisteStavke.RedniBrojDan Desc";
                        }//izadatnica
                        else if (rowStanje.Rows[0]["ID_IzdatnicaStavke"].ToString().Length > 0)
                        {
                            sqlUpit.CommandText = "Select Top(1) Saldo From MT_SkladisteStavke Inner Join MT_IzdatnicaStavka On MT_SkladisteStavke.ID_IzdatnicaStavke = MT_IzdatnicaStavka.ID " +
                                                  "Where ID_Skladista = @ID_Skladiste And ID_Proizvoda = @ID_Proizvod And TS <= @TS Order by MT_SkladisteStavke.TS Desc, MT_SkladisteStavke.RedniBrojDan Desc";
                        }//meduskladisnica
                        else
                        {
                            sqlUpit.CommandText = "Select Top(1) Saldo From MT_SkladisteStavke Inner Join MT_MeduskladisnicaStavka On MT_SkladisteStavke.ID_MeduskladisnicaStavke = MT_MeduskladisnicaStavka.ID " +
                                                  "Where ID_Skladista = @ID_Skladiste And ID_Proizvoda = @ID_Proizvod And TS <= @TS Order by MT_SkladisteStavke.TS Desc, MT_SkladisteStavke.RedniBrojDan Desc";
                        }

                        try
                        {
                            saldo = Convert.ToDecimal(sqlUpit.ExecuteScalar());
                        }
                        catch { saldo = 0; }
                    }
                    catch { saldo = 0; }

                    sqlUpit.Parameters["@ID_PrimkaStavke"].Value = row["ID_PrimkaStavke"];
                    sqlUpit.Parameters["@Kolicina"].Value = row["Kolicina"].ToString().Replace(",", ".");
                    sqlUpit.Parameters["@Stanje"].Value = stanje + Convert.ToDecimal(row["Kolicina"].ToString());
                    sqlUpit.Parameters["@Saldo"].Value = saldo + (Convert.ToDecimal(row["Kolicina"].ToString()) * Convert.ToDecimal(row["Cijena"].ToString()));
                    sqlUpit.Parameters["@RedniBroj"].Value = RedniBrojSkladisteDan(Convert.ToDateTime(sqlUpit.Parameters["@TS"].Value).ToString("yyyy-MM-dd"),
                                                                                    Convert.ToInt32(sqlUpit.Parameters["@ID_Skladiste"].Value), Convert.ToInt32(sqlUpit.Parameters["@ID_Proizvod"].Value), sqlUpit);

                    sqlUpit.CommandText = "Insert Into MT_SkladisteStavke (ID_Skladista, ID_PrimkaStavke, Kolicina, Stanje, Saldo, TS, ID_Proizvod, RedniBrojDan) " +
                                          "Values (@ID_Skladiste, @ID_PrimkaStavke, @Kolicina, @Stanje, @Saldo, @TS, @ID_Proizvod, @RedniBroj)";

                    stavka = new PrimkaStavke
                    {
                        idPrimka = Convert.ToInt32(row["IDPrimka"]),
                        idProizvod = Convert.ToInt32(row["ID_Proizvoda"]),
                        idPorez = Convert.ToInt32(row["ID_Porez"]),
                        idJedinicaMjere = Convert.ToInt32(row["ID_JedinicaMjere"]),
                        kolicina = Convert.ToDecimal(row["Kolicina"]),
                        cijena = Convert.ToDecimal(row["Neto"]),
                        cijenaPDV = Convert.ToDecimal(row["Cijena"])
                    };
                    razlika = new List<PrimkaStavke>();
                    razlika.Add(stavka);

                    try
                    {
                        sqlUpit.ExecuteNonQuery();

                        //update rednog broja stavke u danu nakon stavljanja na skladiste
                        sqlUpit.CommandText = "Update MT_PrimkaStavke Set RedniBrojDan = @RedniBroj Where ID = @ID_PrimkaStavke";

                        sqlUpit.ExecuteNonQuery();
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

                    CalculateStock2(razlika, Convert.ToDateTime(row["DatumNastajanja"]), Convert.ToInt32(row["ID_Skladista"]), sqlUpit, false, Convert.ToInt32(sqlUpit.Parameters["@RedniBroj"].Value));
                }
            }
            else//db - 27.1.2017 - logika ukoliko je prvi unos u godini, dohvat sveg iz primkastavke i prijenos u skladistestavke
            {
                DataTable dtPrimkaStavkePocetakGodine = client.GetDataTable("select * from mt_primkastavke where id_primke = '" + primke + "' ");

                string sqll = "Insert Into MT_SkladisteStavke (ID_Skladista, ID_PrimkaStavke, Kolicina, Stanje, Saldo, TS, ID_Proizvod, RedniBrojDan) " +
                                          "Values (@ID_Skladista, @ID_PrimkaStavke, @Kolicina, @Stanje, @Saldo, @TS, @ID_Proizvod, @RedniBrojDan)";

                foreach (DataRow row in dtPrimka.Rows)
                {
                    SqlCommand sqlUpitno = new SqlCommand(sqll);
                    sqlUpitno.Connection = client.sqlConnection;
                    sqlUpitno.CommandType = CommandType.Text;

                    DateTime dat = Convert.ToDateTime(row["DatumNastajanja"]);
                    string datum = dat.ToString("yyyy-MM-dd");

                    int id_skladiste = Convert.ToInt32(row["ID_Skladista"]);
                    int id_proizvod = Convert.ToInt32(row["ID_Proizvoda"]);

                    sqlUpitno.Parameters.AddWithValue("@ID_Skladista", id_skladiste);
                    sqlUpitno.Parameters.AddWithValue("@ID_PrimkaStavke", Convert.ToInt32(row["ID_PrimkaStavke"]));
                    sqlUpitno.Parameters.AddWithValue("@ID_Proizvod", id_proizvod);
                    sqlUpitno.Parameters.AddWithValue("@Kolicina", row["Kolicina"].ToString().Replace(",", "."));
                    sqlUpitno.Parameters.AddWithValue("@Stanje", Convert.ToDecimal(row["Kolicina"].ToString()));
                    sqlUpitno.Parameters.AddWithValue("@Saldo", (Convert.ToDecimal(row["Kolicina"].ToString()) * Convert.ToDecimal(row["Cijena"].ToString())));

                    sqlUpitno.Parameters.AddWithValue("@RedniBrojDan", RedniBrojSkladisteDan(datum, id_skladiste, id_proizvod));

                    sqlUpitno.Parameters.AddWithValue("@TS", Convert.ToDateTime(row["DatumNastajanja"]).ToString("yyyy-MM-dd"));

                    try
                    {
                        sqlUpitno.ExecuteNonQuery();
                    }
                    catch (SqlException ex) { }
                    catch (Exception ex) { }
                }
            }

            return true;
        }


        private decimal GetAverigePrice(DateTime datum, int proizvod, SqlCommand sqlUpit, int skladiste, decimal cijenaDokument)
        {
            //sqlUpit.CommandText = "Select ISNULL(Sum(MT_PrimkaStavke.CijenaPDV * MT_PrimkaStavke.Kolicina) , 0) / SUM(MT_PrimkaStavke.Kolicina) From MT_SkladisteStavke " +
            //    "Inner Join MT_PrimkaStavke On MT_SkladisteStavke.ID_PrimkaStavke = MT_PrimkaStavke.ID Where " +
            //    "MT_SkladisteStavke.TS <= '" + datum.ToString("yyyy-MM-dd") + "' And MT_SkladisteStavke.ID_Proizvod = " + proizvod + " And MT_SkladisteStavke.ID_Skladista = " + skladiste;

            sqlUpit.CommandText = "Select Top 1 Abs(Round((MT_SkladisteStavke.Saldo / MT_SkladisteStavke.Stanje), 4)) From MT_SkladisteStavke " +
                   "Where MT_SkladisteStavke.ID_Skladista = " + skladiste + " And MT_SkladisteStavke.ID_Proizvod = " + proizvod + " And MT_SkladisteStavke.TS <= '" + datum +
                   "' And Stanje <> 0 Order by TS desc, RedniBrojDan desc";

            try
            {
                decimal cijena = Convert.ToDecimal(sqlUpit.ExecuteScalar());
                return cijena;
            }
            catch { return cijenaDokument; }
        }


        private int RedniBrojSkladisteDan(string dateTime, int skladiste, int proizvod, SqlCommand sqlUpit)
        {
            int redniBroj = 1;

            try
            {
                sqlUpit.CommandText = "Select Max(RedniBrojDan) From MT_SkladisteStavke Where MT_SkladisteStavke.ID_Skladista = " + skladiste +
                                            " And TS = '" + dateTime + "' and ID_Proizvod = " + proizvod;

                redniBroj = Convert.ToInt32(sqlUpit.ExecuteScalar()) + 1;
            }
            catch { redniBroj = 1; }

            return redniBroj;
        }

        /// <summary>
        /// //db - 27.1.2017 ista metoda kao i gore, ali bez sqlcommand-a
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="skladiste"></param>
        /// <param name="proizvod"></param>
        /// <returns></returns>
        private int RedniBrojSkladisteDan(string dateTime, int skladiste, int proizvod)
        {
            int redniBroj = 1;
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            try
            {
                sqlUpit.CommandText = "Select Max(RedniBrojDan) From MT_SkladisteStavke Where MT_SkladisteStavke.ID_Skladista = " + skladiste +
                                            " And TS = '" + dateTime + "' and ID_Proizvod = " + proizvod;

                redniBroj = Convert.ToInt32(sqlUpit.ExecuteScalar()) + 1;
            }
            catch { redniBroj = 1; }

            return redniBroj;
        }

        internal DataTable GetStavkeFromNarudzbenica(int narudzbenica)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Select 'false' As SEL, NULL AS ID_Primke, JN_NarudzbenicaProizvod.ID_Proizvod As ID_Proizvoda, PROIZVOD.NAZIVPROIZVOD AS Proizvod, " +
            "JN_NarudzbenicaProizvod.ID_JedinicaMjere, JEDINICAMJERE.NAZIVJEDINICAMJERE As JedinicaMjere, PROIZVOD.CIJENA As Cijena, PROIZVOD.FINPOREZIDPOREZ As ID_Porez, " +
            "FINPOREZ.FINPOREZNAZIVPOREZ As Porez, JN_NarudzbenicaProizvod.Kolicina, PROIZVOD.CijenaPDV, 0 As BrojUlaznogDokumenta From JN_NarudzbenicaProizvod Inner Join PROIZVOD On JN_NarudzbenicaProizvod.ID_Proizvod = PROIZVOD.IDPROIZVOD " +
            "Inner Join JEDINICAMJERE On JN_NarudzbenicaProizvod.ID_JedinicaMjere = JEDINICAMJERE.IDJEDINICAMJERE Inner Join FINPOREZ On Proizvod.FINPOREZIDPOREZ = FINPOREZ.FINPOREZIDPOREZ " +
            "Where JN_NarudzbenicaProizvod.ID_Narudzbenica = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", narudzbenica));

            return client.GetDataTable(sqlUpit);
        }

        internal decimal GetStopaPDV(int stopa)
        {
            return Convert.ToDecimal(client.ExecuteScalar("Select FINPOREZSTOPA/100 From FINPOREZ Where FINPOREZIDPOREZ = " + stopa));
        }

        internal object GetPorez()
        {
            DataTable dt = client.GetDataTable("Select FINPOREZIDPOREZ As ID, FINPOREZNAZIVPOREZ As Naziv From FINPOREZ Order by FinPorezStopa");
            return dt;
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

        public void Dispose()
        {
            client.CloseConnection();
        }

        #endregion

        internal bool ProvjeraPostoji(int proizvod, int? mjernaProizvodAmbalaza, int mjernaProizvod)
        {
            DataTable tbl = client.GetDataTable("Select ID_JedinicaMjere From MT_PrimkaStavke Where ID_Proizvoda = " + proizvod);

            if (mjernaProizvodAmbalaza != null)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    if (row["ID_JedinicaMjere"].ToString() != mjernaProizvodAmbalaza.ToString())
                    {
                        return true;
                    }
                }
            }
            else
            {
                foreach (DataRow row in tbl.Rows)
                {
                    if (row["ID_JedinicaMjere"].ToString() != mjernaProizvod.ToString())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        internal object UkupnaCijena(object ukupnoPrije, object porez, object proizvod)
        {
            decimal stopa;
            decimal ukupno;
            try
            {
                ukupno = Convert.ToDecimal(ukupnoPrije);
                stopa = Convert.ToDecimal(client.ExecuteScalar("Select FINPOREZ.FINPOREZSTOPA From FINPOREZ Where FINPOREZ.FINPOREZIDPOREZ = " + porez));
            }
            catch { stopa = 0; ukupno = 0; }

            return ukupno + (ukupno * (stopa / 100));
        }

        class PrimkaStavke
        {
            public int idPrimka { get; set; }
            public int idProizvod { get; set; }
            public int idJedinicaMjere { get; set; }
            public decimal cijena { get; set; }
            public int idPorez { get; set; }
            public decimal kolicina { get; set; }
            public decimal cijenaPDV { get; set; }
            public Nullable<int> redniBroj { get; set; }
        }
    }
}
