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
    public class Izdatnica : Base, IDisposable
    {
        SqlClient client = null;

        public Izdatnica()
            : base()
        {
            client = new SqlClient();
        }

        #region Properties

        public static Nullable<int> pID { get; set; }
        public string pSifra { get; set; }
        public DateTime pDatumNastajanja { get; set; }
        public int pID_Dokumenta { get; set; }
        public int pID_Skladista { get; set; }
        public string pNapomena { get; set; }
        public static int pSelectedIndex { get; set; }

        private static DataTable pizdatnicaStavke;
        public static DataTable pIzdatnicaStavke
        {
            get { return pizdatnicaStavke; }
            set { pizdatnicaStavke = value; }
        }
       
        public decimal pUkupanIznos { get; set; }
        private Nullable<DateTime> originalDate { get; set; }
        private Nullable<int> originalWarhouse { get; set; }
        public Nullable<int> mjestoTroska { get; set; }

        #endregion

        #region Work with data
        
        public DataSet GetMainGridData()
        {
            DataSet ds = new DataSet();

            string active_year = client.ExecuteScalar("Select IDGODINE From GODINE Where GODINEAKTIVNA = 1").ToString();

            //db - 28.01.2017 - dodan uvjet 'Where YEAR(DatumNastajanja) = " + active_year + " '
            //DataTable dt_primary = client.GetDataTable("Select 'false' As Ozn,  MT_Izdatnica.ID, MT_Izdatnica.Sifra, DOKUMENT.NAZIVDOKUMENT As Dokument, MT_Izdatnica.DatumNastajanja, MT_Skladista.Naziv As Skladiste, " + 
            //                                           "ROUND(MT_Izdatnica.UkupanIznos, 2) As UkupanIznos, MT_Izdatnica.Napomena, Zaduzen " +
            //                                           "From MT_Izdatnica Inner Join DOKUMENT On MT_Izdatnica.ID_Dokumenta = DOKUMENT.IDDOKUMENT " +
            //                                           "Inner Join MT_Skladista On MT_Izdatnica.ID_Skladista = MT_Skladista.ID Where YEAR(DatumNastajanja) = " + active_year + "");
            string storaa = "spDohvatiIzdatnice";
            SqlCommand comm = new SqlCommand(storaa);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@godina", active_year);
            comm.Connection = client.sqlConnection;

            DataTable dt_primary = client.GetDataTable(comm);

            //db - 28.01.2017 - dodan uvjet 'Where YEAR(DatumNastajanja) = " + active_year + " '
            //DataTable dt_related1 = client.GetDataTable("Select MT_IzdatnicaStavka.ID_Izdatnice, MT_IzdatnicaStavka.RedniBroj, PROIZVOD.IDPROIZVOD, PROIZVOD.NAZIVPROIZVOD AS Stavka, MT_IzdatnicaStavka.Kolicina, MT_IzdatnicaStavka.NabavnaCijena, " +
            //                                            "ROUND(MT_IzdatnicaStavka.UkupanIznos, 2) As Ukupno From MT_IzdatnicaStavka " +
            //                                            "Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD Where YEAR(DatumNastajanja) = " + active_year + " Order by MT_IzdatnicaStavka.RedniBroj, PROIZVOD.NAZIVPROIZVOD");
            string stora = "spDohvatiIzdatnicaStavke";
            SqlCommand com = new SqlCommand(stora);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@godina", active_year);
            com.Connection = client.sqlConnection;

            DataTable dt_related1 = client.GetDataTable(com);

            ds.Tables.Add(dt_primary);
            ds.Tables.Add(dt_related1);

            DataRelation relation1 = new DataRelation("Izdatnica", dt_primary.Columns["ID"], dt_related1.Columns["ID_Izdatnice"]);

            ds.Relations.Add(relation1);

            return ds;
        }

        public DataTable GetSkladiste()
        {
            return client.GetDataTable("Select ID, Naziv From MT_Skladista Order by Naziv");
        }

        internal object[] GetDokument1()
        {
            return client.ConvertDataTableToArrayList(client.GetDataTable("Select IDDOKUMENT As ID, (CAST(IDDOKUMENT As nvarchar) + ' | ' + NAZIVDOKUMENT) AS Naziv From DOKUMENT Order by NAZIVDOKUMENT")).ToArray();
        }

        internal object[] GetMjestoTroska()
        {
            return client.ConvertDataTableToArrayList(client.GetDataTable("Select IDMJESTOTROSKA As ID, (CAST(IDMJESTOTROSKA As nvarchar) + ' | ' + NAZIVMJESTOTROSKA) AS Naziv From MJESTOTROSKA Order by NAZIVMJESTOTROSKA")).ToArray();
        }

        public bool Delete(StringBuilder message)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;


            sqlUpit.CommandText = "Delete MT_SkladisteStavke From MT_SkladisteStavke Inner Join " +
                                  "MT_IzdatnicaStavka On MT_SkladisteStavke.ID_IzdatnicaStavke = MT_IzdatnicaStavka.ID Where MT_IzdatnicaStavka.ID_Izdatnice = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();

                sqlUpit.CommandText = "Delete from MT_IzdatnicaStavka Where ID_Izdatnice = @ID";

                sqlUpit.ExecuteNonQuery();

                sqlUpit.CommandText = "Delete from MT_Izdatnica Where ID = @ID";

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

        public bool Insert(StringBuilder message, Izdatnica objekt)
        {
            int id;
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Insert Into MT_Izdatnica ([Sifra], [DatumNastajanja], [ID_Dokumenta], [ID_Skladista], [Napomena], [TS], [UkupanIznos], [Zaduzen], MjestoTroska) Values " +
                                  "(@Sifra, @DatumNastajanja, @ID_Dokumenta, @ID_Skladista, @Napomena, @TS, @UkupanIznos, 1, @MjestoTroska) Select @@Identity";

            sqlUpit.Parameters.Add(new SqlParameter("@Sifra", objekt.pSifra));
            sqlUpit.Parameters.Add(new SqlParameter("@DatumNastajanja", objekt.pDatumNastajanja));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Dokumenta", objekt.pID_Dokumenta));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Skladista", objekt.pID_Skladista));
            
            if (pNapomena != null)
            {
                if (pNapomena.Length == 0)
                {
                    sqlUpit.Parameters.Add(new SqlParameter("@Napomena", DBNull.Value));
                }
                else
                {
                    sqlUpit.Parameters.Add(new SqlParameter("@Napomena", pNapomena));
                }
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Napomena", DBNull.Value));
            }
            
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));
            sqlUpit.Parameters.Add(new SqlParameter("@UkupanIznos", objekt.pUkupanIznos));
            
            if (mjestoTroska != null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@MjestoTroska", mjestoTroska));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@MjestoTroska", DBNull.Value));
            }

            try
            {
                id = Convert.ToInt32(sqlUpit.ExecuteScalar());

                if (InsertStavke(message, sqlUpit, id, objekt.pDatumNastajanja))
                {
                    return true;
                }
                else
                {
                    return false;
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

        private bool InsertStavke(StringBuilder message, SqlCommand sqlUpit, int id, DateTime datumNastajanja)
        {
            if (BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows.Count > 0)
            {
                sqlUpit.Parameters.Clear();

                sqlUpit.Parameters.Add(new SqlParameter("@ID_Izdatnice", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Proizvoda", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@Kolicina", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@NabavnaCijena", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Skladista", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@ID_IzdatnicaStavke", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@Stanje", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@TS", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@Saldo", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@UkupanIznosStavka", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@RedniBroj", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@ID", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@RedniBrojDan", ""));

                DataTable rowStanje;
                SqlDataAdapter adp;

                decimal stanje = 0;
                decimal saldo = 0;
                List<IzdatnicaStavke> razlika;
                IzdatnicaStavke stavka;

                foreach (DataRow red in BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows)
                {
                    stavka = new IzdatnicaStavke
                    {
                        idIzdatnica = id,
                        idProizvod = Convert.ToInt32(red["ID_Proizvoda"]),
                        kolicina = Convert.ToDecimal(red["Kolicina"]),
                        cijena = Convert.ToDecimal(red["NabavnaCijena"]),
                        redniBroj = RedniBrojSkladisteDan(datumNastajanja.ToString("yyyy-MM-dd"), pID_Skladista, Convert.ToInt32(red["ID_Proizvoda"]), sqlUpit),
                    };

                    sqlUpit.CommandText = "Insert Into MT_IzdatnicaStavka ([ID_Izdatnice], [ID_Proizvoda], [Kolicina], [NabavnaCijena], [UkupanIznos], [RedniBroj], RedniBrojDan) Values " +
                                          "(@ID_Izdatnice, @ID_Proizvoda, @Kolicina, @NabavnaCijena, @UkupanIznosStavka, @RedniBroj, @RedniBrojDan) Select @@Identity";

                    sqlUpit.Parameters["@ID_Izdatnice"].Value = id;
                    sqlUpit.Parameters["@ID_Proizvoda"].Value = stavka.idProizvod;
                    sqlUpit.Parameters["@Kolicina"].Value = stavka.kolicina;
                    sqlUpit.Parameters["@NabavnaCijena"].Value = stavka.cijena;;
                    sqlUpit.Parameters["@UkupanIznosStavka"].Value = stavka.cijena * stavka.kolicina;
                    sqlUpit.Parameters["@RedniBroj"].Value = Convert.ToInt32(red["RedniBroj"]);
                    sqlUpit.Parameters["@TS"].Value = datumNastajanja.ToString("yyyy-MM-dd");
                    sqlUpit.Parameters["@ID_Skladista"].Value = pID_Skladista;
                    sqlUpit.Parameters["@RedniBrojDan"].Value = stavka.redniBroj;

                    try
                    {
                        stavka.id = Convert.ToInt32(sqlUpit.ExecuteScalar());


                        sqlUpit.CommandText = "Select Stanje From MT_SklaDisteStavke Where ID_Skladista = @ID_Skladista And ID_Proizvod = @ID_Proizvoda And TS <= @TS Order by TS Desc, RedniBrojDan Desc";

                        stanje = Convert.ToDecimal(sqlUpit.ExecuteScalar());

                        try
                        {
                            sqlUpit.CommandText = "Select Top(1) ID_PrimkaStavke, ID_IzdatnicaStavke, ID_MeduskladisnicaStavke From MT_SkladisteStavke Where ID_Skladista = @ID_Skladista " +
                                                  "And ID_Proizvod = @ID_Proizvoda And TS <= @TS Order by TS Desc, RedniBrojDan Desc";

                            adp = new SqlDataAdapter(sqlUpit);
                            rowStanje = new DataTable();
                            adp.Fill(rowStanje);

                            //primka
                            if (rowStanje.Rows[0]["ID_PrimkaStavke"].ToString().Length > 0)
                            {
                                sqlUpit.CommandText = "Select Top(1) Saldo From MT_SkladisteStavke Inner Join MT_PrimkaStavke On MT_SkladisteStavke.ID_PrimkaStavke = MT_PrimkaStavke.ID " +
                                                      "Where ID_Skladista = @ID_Skladista And ID_Proizvoda = @ID_Proizvoda And TS <= @TS Order by MT_SkladisteStavke.TS Desc, MT_SkladisteStavke.RedniBrojDan Desc";
                            }//izdatnica
                            else if (rowStanje.Rows[0]["ID_IzdatnicaStavke"].ToString().Length > 0)
                            {
                                sqlUpit.CommandText = "Select Top(1) Saldo From MT_SkladisteStavke Inner Join MT_IzdatnicaStavka On MT_SkladisteStavke.ID_IzdatnicaStavke = MT_IzdatnicaStavka.ID " +
                                                      "Where ID_Skladista = @ID_Skladista And ID_Proizvoda = @ID_Proizvoda And TS <= @TS Order by MT_SkladisteStavke.TS Desc, MT_SkladisteStavke.RedniBrojDan Desc";
                            }//meduskladisnica
                            else
                            {
                                sqlUpit.CommandText = "Select Top(1) Saldo From MT_SkladisteStavke Inner Join MT_MeduskladisnicaStavka On MT_SkladisteStavke.ID_MeduskladisnicaStavke = MT_MeduskladisnicaStavka.ID " +
                                                      "Where ID_Skladista = @ID_Skladista And ID_Proizvoda = @ID_Proizvoda And TS <= @TS Order by MT_SkladisteStavke.TS Desc, MT_SkladisteStavke.RedniBrojDan Desc";
                            }

                            try
                            {
                                saldo = Convert.ToDecimal(sqlUpit.ExecuteScalar());
                            }
                            catch { saldo = 0; }
                        }
                        catch { saldo = 0; }

                        razlika = new List<IzdatnicaStavke>();
                        razlika.Add(stavka);

                        if (InsertSkladisteStavke(message, sqlUpit, stavka.id, stanje - stavka.kolicina, saldo - (stavka.kolicina * stavka.cijena)))
                        {
                            CalculateStock2(razlika, datumNastajanja, pID_Skladista, sqlUpit, false, (int)stavka.redniBroj);
                        }
                        else
                        {
                            return false;
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
                if (message.Length > 0)
                {
                    return false;
                }
            }
            return true;
        }

        class IzdatnicaStavke
        {
            public int id { get; set; }
            public int idIzdatnica { get; set; }
            public int idProizvod { get; set; }
            public decimal cijena { get; set; }
            public decimal kolicina { get; set; }
            public Nullable<int> redniBroj { get; set; }
        }

        public bool Update(StringBuilder message, Izdatnica objekt)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@Proizvod", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@NabavnaCijena", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Cijena", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Kolicina", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Saldo", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Stanje", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@RedniBrojDan", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Izdatnica", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@DatumNastajanja", objekt.pDatumNastajanja));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Dokumenta", objekt.pID_Dokumenta));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Skladista", objekt.pID_Skladista));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));
            sqlUpit.Parameters.Add(new SqlParameter("@Sifra", objekt.pSifra));

            sqlUpit.CommandText = "Update MT_Izdatnica Set Sifra = @Sifra, DatumNastajanja = @DatumNastajanja, ID_Dokumenta = @ID_Dokumenta, " +
                                  "ID_Skladista = @ID_Skladista, Napomena = @Napomena, TS = @TS, UkupanIznos=@UkupanIznos, MjestoTroska=@MjestoTroska Where ID = @ID";

            if (pNapomena != null)
            {
                if (pNapomena.Length == 0)
                {
                    sqlUpit.Parameters.Add(new SqlParameter("@Napomena", DBNull.Value));
                }
                else
                {
                    sqlUpit.Parameters.Add(new SqlParameter("@Napomena", pNapomena));
                }
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Napomena", DBNull.Value));
            }
            sqlUpit.Parameters.Add(new SqlParameter("@UkupanIznos", objekt.pUkupanIznos));

            if (mjestoTroska != null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@MjestoTroska", mjestoTroska));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@MjestoTroska", DBNull.Value));
            }

            try
            {
                CheckIsDateOrWarehouseModified();

                sqlUpit.ExecuteNonQuery();

                List<IzdatnicaStavke> razlika;

                if (originalDate != null || originalWarhouse != null)
                {
                    razlika = GetEmptyData(true);
                    //mjenjani datum i skladiste
                    if (originalWarhouse != null & originalDate != null)
                        SetToZeroAndRecalculate(razlika, originalDate.Value, originalWarhouse.Value, sqlUpit);
                    //mjenjano skladiste
                    else if (originalWarhouse != null & originalDate == null)
                        SetToZeroAndRecalculate(razlika, pDatumNastajanja, originalWarhouse.Value, sqlUpit);
                    //mjenjan datum
                    else if (originalWarhouse == null & originalDate != null)
                        SetToZeroAndRecalculate(razlika, originalDate.Value, (int)objekt.pID_Skladista, sqlUpit);


                    foreach (var item in GetEmptyData(false))
                    {
                        razlika = new List<IzdatnicaStavke>();
                        razlika.Add(item);
                        item.cijena = GetAverigePrice(pDatumNastajanja, item.idProizvod, sqlUpit, pID_Skladista, item.cijena);
                        InsertNewRows(item, sqlUpit);
                        CalculateStockAfterInsert(razlika, pDatumNastajanja, pID_Skladista, sqlUpit, false, Convert.ToInt32(sqlUpit.Parameters["@RedniBrojDan"].Value));
                        item.redniBroj = Convert.ToInt32(sqlUpit.Parameters["@RedniBrojDan"].Value);
                        UpdateRedniBroj(item, sqlUpit, pDatumNastajanja, (int)pID_Skladista);
                    }
                }


                razlika = GetDifferences();

                if (razlika.Count > 0)
                {
                    if (originalDate == null & originalWarhouse == null)
                    {
                        foreach (var item in razlika)
                        {
                            if (item.redniBroj != null)
                            {
                                CalculateStockUpdate(item, pDatumNastajanja, (int)pID_Skladista, sqlUpit);
                                //UpdateStavke(item, sqlUpit, pDatumNastajanja, (int)pID_Skladista, (int)item.redniBroj);
                            }
                            else
                            {
                                InsertNewRows(item, sqlUpit);
                                item.redniBroj = Convert.ToInt32(sqlUpit.Parameters["@RedniBrojDan"].Value);
                                CalculateStockAfterInsert(item, pDatumNastajanja, pID_Skladista, sqlUpit, false);
                            }
                        }
                    }
                    else
                    {
                        //kad su mjenjane stavke i mjenjan datum ili skladiste, update dokumenta
                        //foreach (var item in razlika)
                        //{
                        //    UpdateStavke(item, sqlUpit, pDatumNastajanja, (int)pID_Skladista, RedniBrojSkladisteDan(pDatumNastajanja.ToString("yyyy-MM-dd"), (int)pID_Skladista, item.idProizvod, sqlUpit));
                        //}
                    }
                }

                if (razlika.Count > 0 || originalDate != null || originalWarhouse != null)
                {
                    System.Windows.Forms.MessageBox.Show("Molimo provjerite sve izdatnice nastale nakon ove!");
                }
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

        private void UpdateStavke(IzdatnicaStavke razlika, SqlCommand sqlUpit, DateTime datumNastajanja, int skladiste, int redniBroj)
        {
            sqlUpit.Parameters["@ID"].Value = pID;
            sqlUpit.Parameters["@Proizvod"].Value = razlika.idProizvod;            
            sqlUpit.Parameters["@NabavnaCijena"].Value = Math.Abs(razlika.cijena);
            sqlUpit.Parameters["@Kolicina"].Value = razlika.kolicina;
            sqlUpit.Parameters["@RedniBrojDan"].Value = redniBroj;


            sqlUpit.CommandText = "Update MT_IzdatnicaStavka Set NabavnaCijena = @NabavnaCijena, UkupanIznos = Kolicina * @NabavnaCijena, Kolicina = @Kolicina, " +
                                    "RedniBrojDan = @RedniBrojdan Where ID_Izdatnice = @ID And ID_Proizvoda = @Proizvod";

            if (razlika.kolicina == 0)
            {
                sqlUpit.CommandText = "Delete From MT_IzdatnicaStavka Where ID_Izdatnice = @ID And ID_Proizvoda = @Proizvod";
            }

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch { }
        }

        private void CalculateStockUpdate(IzdatnicaStavke razlika, DateTime datumNastajanja, int skladiste, SqlCommand sqlUpit)
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

        private void DeleteFromStockRecalculateUpdate(IzdatnicaStavke item, DataTable dtRedovi, SqlCommand sqlUpit, int skladiste)
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
                    sqlUpit.Parameters["@Saldo"].Value = Convert.ToDecimal(row["Saldo"]) +(Convert.ToDecimal(row["Kolicina"]) * Convert.ToDecimal(row["Cijena"]));
                    sqlUpit.Parameters["@Stanje"].Value = Convert.ToDecimal(row["Stanje"]) + Convert.ToDecimal(row["Kolicina"]);
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

                    if (vrsta == "Izd")
                    {
                        sqlUpit.Parameters["@Saldo"].Value = Math.Round(Convert.ToDecimal(row["Saldo"]) + (kolicina * cijena) - (item.kolicina * item.cijena), 4);
                        sqlUpit.Parameters["@Stanje"].Value = Math.Round(Convert.ToDecimal(row["Stanje"]) + kolicina - item.kolicina, 4);
                    }
                    //else if (row["Vrsta"].ToString() == "Izd")
                    //{
                    //    sqlUpit.Parameters["@Saldo"].Value = Convert.ToDecimal(row["Saldo"]) - (item.kolicina * item.cijenaPDV);
                    //    sqlUpit.Parameters["@Stanje"].Value = Convert.ToDecimal(row["Stanje"]) - item.kolicina;
                    //}

                    try
                    {
                        sqlUpit.ExecuteNonQuery();
                    }
                    catch { }


                    //update prve stavke. kupi cijenu iz forme 
                    UpdateStavke(idStavka, item.cijena, item.kolicina, sqlUpit, item.idIzdatnica);

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
                        int id = 0;

                        try
                        {
                            sqlUpit.ExecuteNonQuery();

                            id = Convert.ToInt32(client.ExecuteScalar("Select ID_Izdatnice From MT_IzdatnicaStavka Where ID = " + idStavka)); 
                        }
                        catch { }
                        //update izdatnice 
                        UpdateStavke(idStavka, prosjecnaCijena, sqlUpit, id);
                    }
                }
            }
        }

        private void UpdateStavke(int idPrimkaStavak, decimal cijena, decimal kolicina, SqlCommand sqlUpit, int idIzdatnica)
        {
            sqlUpit.Parameters["@Izdatnica"].Value = idPrimkaStavak;
            sqlUpit.Parameters["@Cijena"].Value = Math.Abs(cijena);
            sqlUpit.Parameters["@Kolicina"].Value = kolicina;

            try
            {
                sqlUpit.CommandText = "Update MT_IzdatnicaStavka Set NabavnaCijena= @Cijena, UkupanIznos= @Cijena * @Kolicina, Kolicina = @Kolicina Where ID = @Izdatnica";

                sqlUpit.ExecuteNonQuery();
            }
            catch { }

            sqlUpit.Parameters["@Izdatnica"].Value = idIzdatnica;
            sqlUpit.CommandText = "Update MT_Izdatnica Set UkupanIznos = (Select Sum(UkupanIznos) From MT_IzdatnicaStavka Where ID_Izdatnice = @Izdatnica) Where ID = @Izdatnica";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch { }
        }

        private void UpdateStavke(int idPrimkaStavak, SqlCommand sqlUpit)
        {
            sqlUpit.Parameters["@Izdatnica"].Value = idPrimkaStavak;

            try
            {
                sqlUpit.CommandText = "Delete From MT_IzdatnicaStavka Where ID= @Izdatnica";

                sqlUpit.ExecuteNonQuery();
            }
            catch { }
        }

        private void UpdateRedniBroj(IzdatnicaStavke razlika, SqlCommand sqlUpit, DateTime datumNastajanja, int skladiste)
        {
            sqlUpit.Parameters["@ID"].Value = razlika.idIzdatnica;
            sqlUpit.Parameters["@Proizvod"].Value = razlika.idProizvod;
            sqlUpit.Parameters["@NabavnaCijena"].Value = Math.Abs(razlika.cijena);
            sqlUpit.Parameters["@Kolicina"].Value = razlika.kolicina;
            sqlUpit.Parameters["@RedniBrojDan"].Value = razlika.redniBroj;

            sqlUpit.CommandText = "Update MT_IzdatnicaStavka Set NabavnaCijena = @NabavnaCijena, UkupanIznos = Kolicina * @NabavnaCijena, Kolicina = @Kolicina, " +
                                    "RedniBrojDan = @RedniBrojdan Where ID_Izdatnice = @ID And ID_Proizvoda = @Proizvod";

            if (razlika.kolicina == 0)
            {
                sqlUpit.CommandText = "Delete From MT_IzdatnicaStavka Where ID_Izdatnice= @ID And ID_Proizvoda= @Proizvod";
            }

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch { }

            sqlUpit.CommandText = "Update MT_Izdatnica Set UkupanIznos = (Select Sum(UkupanIznos) From MT_IzdatnicaStavka Where ID_Izdatnice = @ID) Where ID = @ID";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch { }
        }

        private void CalculateStockAfterInsert(List<IzdatnicaStavke> razlika, DateTime datumNastajanja, int? skladiste, SqlCommand sqlUpit, bool vrsta, int redniBroj)
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

        private void CalculateStockAfterInsert(IzdatnicaStavke razlika, DateTime datumNastajanja, int? skladiste, SqlCommand sqlUpit, bool vrsta)
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

        private void SetToZeroAndRecalculate(List<IzdatnicaStavke> razlika, DateTime datumNastajanja, int skladiste, SqlCommand sqlUpit)
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

        private void DeleteFromStockRecalculate(IzdatnicaStavke item, DataTable dtRedovi, SqlCommand sqlUpit, int skladiste)
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

                        UpdateStavke(idStavka, prCijena, sqlUpit, item.idIzdatnica);
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

                        UpdateStavke(idStavka, prCijena, sqlUpit, item.idIzdatnica);
                    }

                    kolPrije = kolicina;
                    stPrije = Convert.ToDecimal(sqlUpit.Parameters["@Stanje"].Value);
                    salPrije = Convert.ToDecimal(sqlUpit.Parameters["@Saldo"].Value);
                    cijenaPrije = prCijena;
                }
            }
        }

        private void UpdateStavke(int idIzdatnica, decimal cijena, SqlCommand sqlUpit, int idIzdatnicaGlava)
        {
            sqlUpit.Parameters["@Izdatnica"].Value = idIzdatnica;
            sqlUpit.Parameters["@Cijena"].Value = Math.Abs(cijena);

            sqlUpit.CommandText = "Update MT_IzdatnicaStavka Set NabavnaCijena= @Cijena, UkupanIznos= @Cijena * Kolicina Where ID = @Izdatnica";
            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch { }

            sqlUpit.Parameters["@Izdatnica"].Value = idIzdatnicaGlava;
            sqlUpit.CommandText = "Update MT_Izdatnica Set UkupanIznos = (Select Sum(UkupanIznos) From MT_IzdatnicaStavka Where ID_Izdatnice = @Izdatnica) Where ID = @Izdatnica";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch { }
        }


        private void InsertNewRows(IzdatnicaStavke item, SqlCommand sqlUpit)
        {
            sqlUpit.Parameters["@Kolicina"].Value = item.kolicina;
            sqlUpit.Parameters["@TS"].Value = GetDatumNastajanja(item.idIzdatnica);
            sqlUpit.Parameters["@Stanje"].Value = Math.Round(Convert.ToDecimal(GetStanjeModified(item.idProizvod, pID_Skladista, pDatumNastajanja)) - item.kolicina, 4);
            sqlUpit.Parameters["@Saldo"].Value = Math.Round(Convert.ToDecimal(GetSaldoModified(item.idProizvod, pID_Skladista, pDatumNastajanja)) - (item.kolicina * item.cijena), 4);
            sqlUpit.Parameters["@RedniBrojDan"].Value = RedniBrojSkladisteDan(pDatumNastajanja.ToString("yyyy-MM-dd"), pID_Skladista, item.idProizvod, sqlUpit);

            sqlUpit.CommandText = "Insert Into MT_SkladisteStavke ([ID_Skladista],[ID_Proizvod],[ID_IzdatnicaStavke],[Kolicina],[Stanje],[Saldo],[TS], RedniBrojDan) Values " +
                                  "('" + (int)pID_Skladista + "', '" + item.idProizvod + "', '" + GetIdIzdatnicaStavke(item) + "', @Kolicina, @Stanje, @Saldo, @TS, @RedniBrojDan)";

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

        private object GetDatumNastajanja(int izdatnica)
        {
            return client.ExecuteScalar("Select DatumNastajanja From MT_Izdatnica Where ID = " + izdatnica);
        }

        private List<IzdatnicaStavke> GetEmptyData(bool stanje)
        {
            List<IzdatnicaStavke> temp;
            if (stanje)
            {
                temp = client.GetDataTable("Select * From MT_IzdatnicaStavka Where ID_Izdatnice = " + pID).AsEnumerable().Select(m => new IzdatnicaStavke()
                {
                    idIzdatnica = m.Field<int>("ID_Izdatnice"),
                    idProizvod = m.Field<int>("ID_Proizvoda"),
                    cijena = 0,
                    kolicina = 0,
                    redniBroj = m.Field<int>("RedniBrojDan"),
                }).ToList();
            }
            else
            {
                temp = BusinessLogic.Izdatnica.pIzdatnicaStavke.AsEnumerable().Select(m => new IzdatnicaStavke()
                {
                    idIzdatnica = m.Field<int>("ID_Izdatnice"),
                    idProizvod = m.Field<int>("ID_Proizvoda"),
                    cijena = m.Field<decimal>("NabavnaCijena"),
                    kolicina = m.Field<decimal>("Kolicina"),
                }).ToList();
            }

            return temp;
        }

        private void CheckIsDateOrWarehouseModified()
        {
            try
            {
                originalDate = Convert.ToDateTime(client.ExecuteScalar("Select DatumNastajanja From MT_Izdatnica Where ID = " + pID));
                if (originalDate.Value.ToString("yyyy-MM-dd") == pDatumNastajanja.ToString("yyyy-MM-dd"))
                {
                    originalDate = null;
                }
            }
            catch { originalDate = null; }

            try
            {
                originalWarhouse = Convert.ToInt32(client.ExecuteScalar("Select ID_Skladista From MT_Izdatnica Where ID = " + pID));
                if (originalWarhouse == pID_Skladista)
                {
                    originalWarhouse = null;
                }
            }
            catch { originalWarhouse = null; }
        }

        private bool UpdateStavke(StringBuilder message, SqlCommand sqlUpit)
        {
            //setiranje svih na nulu posto ih nesmijem micati jer su vec zaduzene, a kasnije samo mjenjam kolicinu i cijenu
            SetAllToZero(sqlUpit);
            int id = 0;

            if (BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows.Count > 0)
            {
                sqlUpit.Parameters.Clear();

                sqlUpit.Parameters.Add(new SqlParameter("@ID_Izdatnice", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Proizvoda", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@Kolicina", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@NabavnaCijena", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@UkupanIznos", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@RedniBroj", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@TS", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@Stanje", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@Saldo", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@ID", ""));

                foreach (DataRow red in BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows)
                {

                    sqlUpit.CommandText = "Update MT_IzdatnicaStavka Set NabavnaCijena=@NabavnaCijena, Kolicina=@Kolicina, UkupanIznos=@UkupanIznos " +
                                          "Where ID_Izdatnice=@ID_Izdatnice And ID_Proizvoda=@ID_Proizvoda Select @@ROWCOUNT";

                    sqlUpit.Parameters["@ID_Izdatnice"].Value = Convert.ToInt32(red["ID_Izdatnice"]);
                    sqlUpit.Parameters["@ID_Proizvoda"].Value = Convert.ToInt32(red["ID_Proizvoda"]);
                    sqlUpit.Parameters["@Kolicina"].Value = Convert.ToDecimal(red["Kolicina"]);
                    sqlUpit.Parameters["@NabavnaCijena"].Value = Convert.ToDecimal(red["NabavnaCijena"]);
                    sqlUpit.Parameters["@UkupanIznos"].Value = Convert.ToDecimal(red["NabavnaCijena"]) * Convert.ToDecimal(red["Kolicina"]);

                    try
                    {
                        id = Convert.ToInt32(sqlUpit.ExecuteScalar());

                        if (id == 0)
                        {
                            sqlUpit.CommandText = "Insert Into MT_IzdatnicaStavka ([ID_Izdatnice], [ID_Proizvoda], [Kolicina], [NabavnaCijena], [UkupanIznos], [RedniBroj]) Values " +
                                          "(@ID_Izdatnice, @ID_Proizvoda, @Kolicina, @NabavnaCijena, @UkupanIznos, @RedniBroj) Select @@Identity";

                            sqlUpit.Parameters["@ID_Izdatnice"].Value = Convert.ToInt32(red["ID_Izdatnice"]);
                            sqlUpit.Parameters["@ID_Proizvoda"].Value = Convert.ToInt32(red["ID_Proizvoda"]);
                            sqlUpit.Parameters["@Kolicina"].Value = Convert.ToDecimal(red["Kolicina"]);
                            sqlUpit.Parameters["@NabavnaCijena"].Value = Convert.ToDecimal(red["NabavnaCijena"]);
                            sqlUpit.Parameters["@UkupanIznos"].Value = Convert.ToDecimal(red["NabavnaCijena"]) * Convert.ToDecimal(red["Kolicina"]);
                            sqlUpit.Parameters["@RedniBroj"].Value = Convert.ToInt32(red["RedniBroj"]);

                            try
                            {
                                sqlUpit.ExecuteNonQuery();
                            }
                            catch (SqlException greska)
                            {
                                message.Append(greska.Message);
                                return false;
                            }
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
            }
            return true;
        }

        private void SetAllToZero(SqlCommand sqlUpit)
        {
            sqlUpit.Parameters.Clear();

            sqlUpit.CommandText = "Update MT_IzdatnicaStavka Set NabavnaCijena = 0, Kolicina = 0, UkupanIznos = 0 Where ID_Izdatnice = @ID";
            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch { }
        }

        private void CalculateStock(List<IzdatnicaStavke> razlika, DateTime datum, int skladiste, SqlCommand sqlUpit, bool vrsta)
        {
            DataTable dtRedovi = new DataTable("Redovi");
            SqlCommand sqlComm;
            SqlDataAdapter da = new SqlDataAdapter();
            sqlComm = new SqlCommand("spSkladisteRowsToUpdate", sqlUpit.Connection);

            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@Datum", datum);
            sqlComm.Parameters.AddWithValue("@Skladiste", skladiste);
            sqlComm.Parameters.Add(new SqlParameter("@Proizvod", SqlDbType.Int));

            foreach (var item in razlika)
            {
                dtRedovi.Clear();
                sqlComm.Parameters["@Proizvod"].Value = item.idProizvod;
                da.SelectCommand = sqlComm;
                da.Fill(dtRedovi);
                UpdateStock(item, dtRedovi, sqlUpit, vrsta, skladiste, item.idProizvod);
            }
        }

        private void CalculateStock2(List<IzdatnicaStavke> razlika, DateTime datum, int skladiste, SqlCommand sqlUpit, bool vrsta, int redniBroj)
        {
            DataTable dtRedovi = new DataTable("Redovi");
            SqlCommand sqlComm;
            SqlDataAdapter da = new SqlDataAdapter();
            sqlComm = new SqlCommand("spSkladisteRowsToUpdate2", sqlUpit.Connection);

            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@Datum", datum.ToString("yyyy-MM-dd"));
            sqlComm.Parameters.AddWithValue("@Skladiste", skladiste);
            sqlComm.Parameters.AddWithValue("@rednibroj", redniBroj);
            sqlComm.Parameters.Add(new SqlParameter("@Proizvod", SqlDbType.Int));

            foreach (var item in razlika)
            {
                dtRedovi.Clear();
                sqlComm.Parameters["@Proizvod"].Value = item.idProizvod;
                da.SelectCommand = sqlComm;
                da.Fill(dtRedovi);
                UpdateStock(item, dtRedovi, sqlUpit, vrsta, skladiste, item.idProizvod);
            }
        }

        private void UpdateStock(IzdatnicaStavke item, DataTable dtRedovi, SqlCommand sqlUpit, bool vrsta, int skladiste, int proizvod)
        {
            int id = 0;
            int brojac = 0;
            DateTime datum = new DateTime();

            //u slucaju kad se dodao novi artikl koji jos ne postoji u zalihama
            if (dtRedovi.Rows.Count == 0)
            {
                InsertStockIfNew(item, sqlUpit);
            }

            foreach (DataRow row in dtRedovi.Rows)
            {
                brojac++;
                sqlUpit.CommandText = "Update MT_SkladisteStavke Set Kolicina = @Kolicina, Saldo = @Saldo, Stanje = @Stanje Where ID = @ID";
                datum = Convert.ToDateTime(row["DatumDokumenta"]);

                sqlUpit.Parameters["@ID"].Value = row["ID"];
                if (row["Vrsta"].ToString() == "Izd" && brojac == 1 & vrsta)
                {
                    sqlUpit.Parameters["@Kolicina"].Value = item.kolicina;
                    sqlUpit.Parameters["@Saldo"].Value = Math.Round(GetSaldo(Convert.ToDecimal(row["Saldo"]), Convert.ToDecimal(row["Kolicina"]), Convert.ToDecimal(row["Cijena"]), item.kolicina, item.cijena), 4);
                    sqlUpit.Parameters["@Stanje"].Value = Convert.ToDecimal(row["Stanje"]) + Convert.ToDecimal(row["Kolicina"]) - item.kolicina;

                    try
                    {
                        sqlUpit.CommandText = "Update MT_SkladisteStavke Set Kolicina = @Kolicina, Saldo = @Saldo, Stanje = @Stanje Where ID = @ID";
                        sqlUpit.ExecuteNonQuery();
                    }
                    catch { }
                }
                else if (row["Vrsta"].ToString() == "Izd" & brojac == 1 & !vrsta)
                {
                    //UpdateIzdatnicaStavka(Convert.ToInt32(row["ID"]), Convert.ToInt32(row["idStavke"]));
                }
                else if (row["Vrsta"].ToString() == "Pri" )
                {
                    sqlUpit.Parameters["@Kolicina"].Value = Convert.ToDecimal(row["Kolicina"]);
                    sqlUpit.Parameters["@Stanje"].Value = Math.Round(GetStanje(id, Convert.ToDecimal(row["Kolicina"]), row["Vrsta"].ToString()), 4);
                    sqlUpit.Parameters["@Saldo"].Value = Math.Round(GetSaldoPrimka(id, Convert.ToDecimal(row["Kolicina"]), Convert.ToDecimal(row["Cijena"])), 4);

                    try
                    {
                        sqlUpit.CommandText = "Update MT_SkladisteStavke Set Kolicina = @Kolicina, Saldo = @Saldo, Stanje = @Stanje Where ID = @ID";
                        sqlUpit.ExecuteNonQuery();
                    }
                    catch { }
                }
                else if (row["Vrsta"].ToString() == "Izd" && brojac > 1)
                {
                    sqlUpit.Parameters["@Kolicina"].Value = Convert.ToDecimal(row["Kolicina"]);
                    sqlUpit.Parameters["@Stanje"].Value = Math.Round(GetStanje(id, Convert.ToDecimal(row["Kolicina"]), row["Vrsta"].ToString()), 4);
                    sqlUpit.Parameters["@Saldo"].Value = GetSaldoSetCijena(id, Convert.ToDecimal(row["idStavke"]), Convert.ToDecimal(row["Kolicina"]), 
                        item.idIzdatnica, datum, proizvod, sqlUpit, skladiste);

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
        }

        private void UpdateIzdatnicaStavka(int id, int idStavka)
        {
            decimal averagePrice = Math.Abs(Convert.ToDecimal(client.ExecuteScalar("Select COALESCE(Saldo / NULLIF(Stanje,0), 0) From MT_SkladisteStavke Where ID = " + id)));

            if (averagePrice == 0)
                return;

            client.ExecuteNonQuery("Update MT_IzdatnicaStavka Set NabavnaCijena = " + Math.Round(averagePrice, 4).ToString().Replace(',', '.') +
                ", UkupanIznos = Kolicina * " + Math.Round(averagePrice, 4).ToString().Replace(',', '.') + " Where ID = " + idStavka);

            int idIzdatnica = Convert.ToInt32(client.ExecuteScalar("Select ID_Izdatnice From MT_IzdatnicaStavka Where ID = " + idStavka));
            
            DataTable izdatncaStavke = client.GetDataTable("Select * From MT_IzdatnicaStavka Where ID_Izdatnice = " + idIzdatnica);
            decimal ukupno = 0;

            foreach (DataRow item in izdatncaStavke.Rows)
            {
                ukupno += Convert.ToDecimal(item["UkupanIznos"]);
            }

            client.ExecuteNonQuery("Update MT_Izdatnica Set UkupanIznos = " + ukupno.ToString().Replace(',', '.') + " Where ID = " + idIzdatnica);
        }

        private decimal GetSaldoPrimka(int id, decimal kolicina, decimal cijena)
        {

            return Math.Round(Convert.ToDecimal(client.ExecuteScalar("Select Saldo From MT_SkladisteStavke Where ID = " + id)) + (kolicina * cijena), 4);
        }

        private object GetSaldoSetCijena(int id, decimal idStavka, decimal kolicina, int idIzdatnica, DateTime datum, int proizvod, SqlCommand sqlupit, int skladiste)
        {
            decimal averagePrice = GetAverigePrice(datum, proizvod, sqlupit, skladiste, 0);

            if (averagePrice != 0)
            {
                client.ExecuteNonQuery("Update MT_IzdatnicaStavka Set NabavnaCijena = " + Math.Round(averagePrice, 4).ToString().Replace(',', '.') + " Where ID = " + idStavka);
                client.ExecuteNonQuery("Update MT_Izdatnica Set UkupanIznos = (Select Sum(UkupanIznos) From MT_IzdatnicaStavka Where ID_Izdatnice = " + idIzdatnica + ") Where ID = " + idIzdatnica);
            }            

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
            return saldoBaza + (kolicinaBaza * cijenaBaza) - (kolicina * cijena);
        }

        private void InsertStockIfNew(IzdatnicaStavke item, SqlCommand sqlUpit)
        {
            sqlUpit.Parameters["@Kolicina"].Value = item.kolicina;
            sqlUpit.Parameters["@Stanje"].Value = item.kolicina;
            sqlUpit.Parameters["@Saldo"].Value = item.kolicina * item.cijena;
            sqlUpit.Parameters["@TS"].Value = DateTime.Now;

            sqlUpit.CommandText = "Insert Into MT_SkladisteStavke ([ID_Skladista],[ID_Proizvod],[ID_IzdatnicaStavke],[Kolicina],[Stanje],[Saldo],[TS]) Values " +
                                  "('" + (int)pID_Skladista + "', '" + item.idProizvod + "', '" + GetIdIzdatnicaStavke(item) + "', @Kolicina, @Stanje, @Saldo, @TS)";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {

            }
        }

        private string GetIdIzdatnicaStavke(IzdatnicaStavke item)
        {
            string id = "";
            try
            {
                id = client.ExecuteScalar("Select ID From MT_IzdatnicaStavka Where ID_Izdatnice = '" + item.idIzdatnica + "' And ID_Proizvoda = '" + item.idProizvod + "'").ToString();
            }
            catch
            {
                id = client.ExecuteScalar("Insert Into MT_IzdatnicaStavka ([ID_Izdatnice],[ID_Proizvoda],[Kolicina],[NabavnaCijena],[UkupanIznos],[RedniBroj]) " +
                                          "Values (" + item.idIzdatnica + ", " + item.idProizvod + ", '" + item.kolicina.ToString().Replace(',', '.') + "', '" + item.cijena.ToString().Replace(',', '.') +
                                          "', '" + (item.cijena * item.kolicina).ToString().Replace(',', '.') + "', " + GetRedniBroj(item.idIzdatnica) + ") Select @@Identity").ToString();
            }

            return id;

        }

        private string GetRedniBroj(int primka)
        {
            string redniBroj = client.ExecuteScalar("Select Max(RedniBroj) + 1 From MT_IzdatnicaStavka Where ID_Izdatnice = " + primka).ToString();

            if (redniBroj.Length == 0)
            {
                return "1";
            }

            return redniBroj;
        }

        private List<IzdatnicaStavke> GetDifferences()
        {
            List<IzdatnicaStavke> izBaze = client.GetDataTable("Select * From MT_IzdatnicaStavka Where ID_Izdatnice = " + pID).AsEnumerable().Select(m => new IzdatnicaStavke()
            {
                idIzdatnica = m.Field<int>("ID_Izdatnice"),
                idProizvod = m.Field<int>("ID_Proizvoda"),
                cijena = m.Field<decimal>("NabavnaCijena"),
                kolicina = m.Field<decimal>("Kolicina"),
                redniBroj = m.Field<int>("RedniBrojDan"),
            }).ToList();

            List<IzdatnicaStavke> temp = BusinessLogic.Izdatnica.pIzdatnicaStavke.AsEnumerable().Select(m => new IzdatnicaStavke()
            {
                idIzdatnica = m.Field<int>("ID_Izdatnice"),
                idProizvod = m.Field<int>("ID_Proizvoda"),
                cijena = m.Field<decimal>("NabavnaCijena"),
                kolicina = m.Field<decimal>("Kolicina"),
            }).ToList();

            List<IzdatnicaStavke> razlike = new List<IzdatnicaStavke>();

            //ne postoji u tempu obrisan u aplikaciji
            var dontExistInBase = izBaze.Where(p => !temp.Any(p2 => p2.idProizvod == p.idProizvod));

            //ne postoji u bazi dodan novi item
            var dontExistInTemp = temp.Where(p => !izBaze.Any(p2 => p2.idProizvod == p.idProizvod));

            //razlike koje su nastle na artiklima koji su u bazi u u tempu, te vraca onaj koji je u tempu
            var result = temp.Where(p => !izBaze.Any(p2 => p2.idProizvod == p.idProizvod & p2.kolicina == p.kolicina & p.cijena == p2.cijena)
                & !dontExistInTemp.Any(p2 => p2.idProizvod == p.idProizvod));

            foreach (var item in dontExistInBase)
            {
                item.cijena = 0;
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

        private bool DeleteStavke(StringBuilder message, SqlCommand sqlUpit)
        {
            sqlUpit.Parameters.Clear();

            sqlUpit.CommandText = "Delete From MT_IzdatnicaStavka Where ID_Izdatnice = @ID";
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


        private bool DeleteStavkeSkladiste(StringBuilder message, SqlCommand sqlUpit)
        {
            sqlUpit.Parameters.Clear();

            sqlUpit.CommandText = "Delete MT_SkladisteStavke From MT_SkladisteStavke Inner Join " + 
                                  "MT_IzdatnicaStavka On MT_SkladisteStavke.ID_IzdatnicaStavke = MT_IzdatnicaStavka.ID Where MT_IzdatnicaStavka.ID_Izdatnice = @ID";
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

        public Nullable<T> IsDbNull<T>(object value) where T : struct
        {
            if (value != DBNull.Value && value != null)
            {
                // return (T)value; // CAST
                return (T)Convert.ChangeType(value, typeof(T)); // CONVERT
            }

            return null;
        }

        public DataRow GetSelected()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "SELECT [ID], [Sifra], [DatumNastajanja], [ID_Dokumenta], [ID_Skladista], [Napomena], MjestoTroska FROM MT_Izdatnica Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            return client.GetDataTable(sqlUpit).Rows[0];
        }

        internal object[] GetStavka(int skladiste)
        {
            return client.ConvertDataTableToArrayList(client.GetDataTable("Select Distinct PROIZVOD.IDPROIZVOD As ID, (CAST(PROIZVOD.IDPROIZVOD As nvarchar) + ' | ' + PROIZVOD.NAZIVPROIZVOD) As Naziv From MT_SkladisteStavke " +
            "Left Join MT_PrimkaStavke On MT_SkladisteStavke.ID_PrimkaStavke = MT_PrimkaStavke.ID " +
            "Left Join MT_MeduskladisnicaStavka On MT_SkladisteStavke.ID_MeduskladisnicaStavke = MT_MeduskladisnicaStavka.ID " +
            "Inner Join PROIZVOD On MT_PrimkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD Or MT_MeduskladisnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD " +
            "Where MT_SkladisteStavke.ID_Skladista = " + skladiste + " Order by NAZIV")).ToArray();
        }

        internal DataTable GetPostojeceStavke()
        {
            return client.GetDataTable("Select 'false' As SEL, MT_IzdatnicaStavka.ID_Izdatnice, MT_IzdatnicaStavka.ID_Proizvoda, PROIZVOD.NAZIVPROIZVOD As StavkaSkladista, " +
                                       "MT_IzdatnicaStavka.Kolicina, MT_IzdatnicaStavka.NabavnaCijena, MT_IzdatnicaStavka.RedniBroj From MT_IzdatnicaStavka " +
                                       "Inner Join PROIZVOD On MT_IzdatnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD Where MT_IzdatnicaStavka.ID_Izdatnice =" + pID + " Order by MT_IzdatnicaStavka.RedniBroj");
        }

        internal DataTable GetIzdatnicaIspis()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "SELECT [ID],[Sifra],[DatumNastajanja],[Skladiste],[IDPROIZVOD],[Proizvod],[JedinicaMjere],[Kolicina],[NabavnaCijena], Napomena, Dokument, NAZIVMJESTOTROSKA " +
                                  "FROM [v_Izdatnica] Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            return client.GetDataTable(sqlUpit);
        }

        //db - 10.11.2016
        internal DataTable GetIzdatnicaIspisOznaceni(Dictionary<int, int> oznaceni)
        {
            string where = string.Empty;
            int counter = 0;
            foreach (KeyValuePair<int, int> row in oznaceni)
            {
                counter++;

                if (counter < oznaceni.Count && oznaceni.Count > 1)
                {
                    where += "( ID = " + row.Key + " And Sifra = " + row.Value.ToString() + ") OR";
                }
                else
                {
                    where += "( ID = " + row.Key + " And Sifra = " + row.Value.ToString() + ") order by Sifra, Proizvod asc";
                }

            }

            DataTable racuni = client.GetDataTable("Select * From v_Izdatnica Where " + where);

            return racuni;
        }

        //db - 10.11.2016
        internal Dictionary<int, int> VratiOznaceneIzdatnicePoBroju(int year, int odRacuna, int doRacuna)
        {
            Dictionary<int, int> oznaceni = new Dictionary<int, int>();

            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "SELECT [ID],[Sifra],[DatumNastajanja],[Skladiste],[IDPROIZVOD],[Proizvod],[JedinicaMjere],[Kolicina],[NabavnaCijena], Napomena, Dokument, NAZIVMJESTOTROSKA " +
                                  "FROM [v_Izdatnica] Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            DataTable dt = client.GetDataTable(sqlUpit);

            foreach (DataRow row in dt.Rows)
            {
                oznaceni.Add(Convert.ToInt32(row["ID"]), Convert.ToInt32(row["Sifra"]));
            }

            return oznaceni;
        }

        private bool InsertSkladisteStavke(StringBuilder message, SqlCommand sqlUpit, int id, decimal stanje, decimal saldo)
        {
            sqlUpit.Parameters["@ID_IzdatnicaStavke"].Value = id;
            sqlUpit.Parameters["@Stanje"].Value = stanje;
            sqlUpit.Parameters["@Saldo"].Value = saldo;

            sqlUpit.CommandText = "Insert Into MT_SkladisteStavke ([ID_Skladista], [ID_IzdatnicaStavke], [Kolicina], [Stanje], [Saldo], [TS], [ID_Proizvod], RedniBrojDan) Values " +
                                        "(@ID_Skladista, @ID_IzdatnicaStavke, @Kolicina, @Stanje, @Saldo, @TS, @ID_Proizvoda, @RedniBrojDan)";

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

        internal DataRow GetStanjeSkladiste(int stavka, int skladiste, DateTime datum)
        {
            string datumDo = datum.ToString("yyyy-MM-dd");
            DataTable tbl = client.GetDataTable("Select Top 1 Stanje, CAST(0 AS Decimal(16, 4)) AS Cijena From MT_SkladisteStavke " +
                                                "Where TS <= '" + datumDo + "' And ID_Proizvod = " +  stavka + " And ID_Skladista = " + skladiste + " Order by TS desc, RedniBrojDan desc");


            tbl.Rows[0]["Cijena"] = CalculateAveragePrice(stavka, skladiste, datumDo);

            return tbl.Rows[0];
        }

        private object CalculateAveragePrice(int stavka, int skladiste, string datum)
        {
            return client.ExecuteScalar("Select Top 1 Abs(Round((MT_SkladisteStavke.Saldo / MT_SkladisteStavke.Stanje), 4)) From MT_SkladisteStavke " +
                   "Where MT_SkladisteStavke.ID_Skladista = " + skladiste + " And MT_SkladisteStavke.ID_Proizvod = " + stavka + " And MT_SkladisteStavke.TS <= '" + datum + 
                   "' And Stanje <> 0 Order by TS desc, RedniBrojDan desc");
        }

        public void Dispose()
        {
            client.CloseConnection();
        }

        #endregion

        internal object GetNextSifra()
        {
            //db - 28.1.2017
            string active_year = client.ExecuteScalar("Select IDGODINE From GODINE Where GODINEAKTIVNA = 1").ToString();

            try
            {
                var broj = client.ExecuteScalar("select top 1 (Sifra) + 1 from MT_Izdatnica where YEAR(Datumnastajanja) = '" + active_year + "' order by ID desc");
                if (broj == null)
                {
                    return 1;
                }
                else if (broj.ToString().Length > 0)
                {
                    return broj;
                }
                else
                {
                    return 1;
                }
            }
            catch { return ""; }
        }

        internal decimal CalculateUkupno()
        {
            decimal ukupno = 0;

            foreach (DataRow row in pIzdatnicaStavke.Rows)
            {
                ukupno += Convert.ToDecimal(row["NabavnaCijena"]) * Convert.ToDecimal(row["Kolicina"]);
            }

            return ukupno;
        }

        internal void IzdatnicaNaSkladiste(StringBuilder message, int id)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            StringBuilder negative = new StringBuilder();

            sqlUpit.Parameters.Add(new SqlParameter("@ID_Izdatnice", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Proizvoda", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Kolicina", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@NabavnaCijena", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Skladista", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_IzdatnicaStavke", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Stanje", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@Saldo", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@ID", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@RedniBroj", ""));
            sqlUpit.Parameters.Add(new SqlParameter("@RedniBrojDan", ""));

            sqlUpit.Parameters["@ID_Izdatnice"].Value = id;

            sqlUpit.CommandText = "Select * From MT_IzdatnicaStavka Where ID_Izdatnice = @ID_Izdatnice";
            DataTable tbl = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(sqlUpit);
            adp.Fill(tbl);

            sqlUpit.CommandText = "Select DatumNastajanja From MT_Izdatnica Where ID = @ID_Izdatnice";
            sqlUpit.Parameters["@TS"].Value = sqlUpit.ExecuteScalar();
            pDatumNastajanja = Convert.ToDateTime(sqlUpit.Parameters["@TS"].Value);

            decimal stanje = 0; decimal saldo = 0; DataTable rowStanje;
            sqlUpit.CommandText = "Select ID_Skladista From MT_Izdatnica Where ID = @ID_Izdatnice";
            pID_Skladista = Convert.ToInt32(sqlUpit.ExecuteScalar());
            IzdatnicaStavke stavka;
            List<IzdatnicaStavke> razlika;

            foreach (DataRow red in tbl.Rows)
            {
                sqlUpit.Parameters["@ID_Proizvoda"].Value = Convert.ToInt32(red["ID_Proizvoda"]);
                sqlUpit.Parameters["@ID_Skladista"].Value = pID_Skladista;
                sqlUpit.Parameters["@Kolicina"].Value = Convert.ToDecimal(red["Kolicina"]);
                sqlUpit.Parameters["@NabavnaCijena"].Value = Convert.ToDecimal(red["NabavnaCijena"]);
                sqlUpit.Parameters["@RedniBrojDan"].Value = RedniBrojSkladisteDan(Convert.ToDateTime(sqlUpit.Parameters["@TS"].Value).ToString("yyyy-MM-dd"), pID_Skladista, 
                                                                                    Convert.ToInt32(red["ID_Proizvoda"]), sqlUpit);

                try
                {
                    sqlUpit.CommandText = "Select Stanje From MT_SklaDisteStavke Where ID_Skladista = @ID_Skladista And ID_Proizvod = @ID_Proizvoda And TS <= @TS Order by TS Desc, RedniBrojDan Desc";

                    stanje = Convert.ToDecimal(sqlUpit.ExecuteScalar());

                    try
                    {
                        sqlUpit.CommandText = "Select Top(1) ID_PrimkaStavke, ID_IzdatnicaStavke, ID_MeduskladisnicaStavke From MT_SkladisteStavke Where ID_Skladista = @ID_Skladista " +
                                                  "And ID_Proizvod = @ID_Proizvoda And TS <= @TS Order by TS Desc, RedniBrojDan Desc";

                        adp = new SqlDataAdapter(sqlUpit);
                        rowStanje = new DataTable();
                        adp.Fill(rowStanje);

                        //primka
                        if (rowStanje.Rows[0]["ID_PrimkaStavke"].ToString().Length > 0)
                        {
                            sqlUpit.CommandText = "Select Top(1) Saldo From MT_SkladisteStavke Inner Join MT_PrimkaStavke On MT_SkladisteStavke.ID_PrimkaStavke = MT_PrimkaStavke.ID " +
                                                  "Where ID_Skladista = @ID_Skladista And ID_Proizvoda = @ID_Proizvoda And TS <= @TS Order by MT_SkladisteStavke.TS Desc, MT_SkladisteStavke.RedniBrojDan Desc";
                        }//izadatnica
                        else if (rowStanje.Rows[0]["ID_IzdatnicaStavke"].ToString().Length > 0)
                        {
                            sqlUpit.CommandText = "Select Top(1) Saldo From MT_SkladisteStavke Inner Join MT_IzdatnicaStavka On MT_SkladisteStavke.ID_IzdatnicaStavke = MT_IzdatnicaStavka.ID " +
                                                  "Where ID_Skladista = @ID_Skladista And ID_Proizvoda = @ID_Proizvoda And TS <= @TS Order by MT_SkladisteStavke.TS Desc, MT_SkladisteStavke.RedniBrojDan Desc";
                        }//meduskladisnica
                        else
                        {
                            sqlUpit.CommandText = "Select Top(1) Saldo From MT_SkladisteStavke Inner Join MT_MeduskladisnicaStavka On MT_SkladisteStavke.ID_MeduskladisnicaStavke = MT_MeduskladisnicaStavka.ID " +
                                                  "Where ID_Skladista = @ID_Skladista And ID_Proizvoda = @ID_Proizvoda And TS <= @TS Order by MT_SkladisteStavke.TS Desc, MT_SkladisteStavke.RedniBrojDan Desc";
                        }

                        try
                        {
                            saldo = Convert.ToDecimal(sqlUpit.ExecuteScalar());
                        }
                        catch { saldo = 0; }
                    }
                    catch { saldo = 0; }


                    stavka = new IzdatnicaStavke
                    {
                        id = Convert.ToInt32(red["ID"]),
                        idIzdatnica = id,
                        idProizvod = Convert.ToInt32(red["ID_Proizvoda"]),
                        kolicina = Convert.ToDecimal(red["Kolicina"]),
                        cijena = GetAverigePrice(pDatumNastajanja, Convert.ToInt32(red["ID_Proizvoda"]), sqlUpit, pID_Skladista, Math.Abs(Math.Round(Convert.ToDecimal(red["NabavnaCijena"]), 4))),
                    };

                    razlika = new List<IzdatnicaStavke>();
                    razlika.Add(stavka);

                    decimal newSaldo = Math.Round(saldo - (stavka.kolicina * stavka.cijena), 4);

                    if ((stanje - stavka.kolicina) < 0 | newSaldo < 0)
                    {
                        if ((stanje - stavka.kolicina) == 0)
                        {
                            newSaldo = 0;
                        }
                        else
                        {
                            negative.Append(string.Format(" - Artikl {0} je otišao sa saldom ili stanje u minus (saldo:{1}, stanje{2})\n", stavka.idProizvod, saldo - (stavka.kolicina * stavka.cijena), stanje - stavka.kolicina));
                        }
                    }

                    if (InsertSkladisteStavke(message, sqlUpit, stavka.id, stanje - stavka.kolicina, newSaldo))
                    {
                        CalculateStock2(razlika, Convert.ToDateTime(sqlUpit.Parameters["@TS"].Value), pID_Skladista, sqlUpit, false, Convert.ToInt32(sqlUpit.Parameters["@RedniBrojDan"].Value));

                        sqlUpit.Parameters["@NabavnaCijena"].Value = stavka.cijena;

                        SetCijenaIzdatnica(sqlUpit);
                    }

                }
                catch (SqlException greska)
                {
                    message.Append(greska.Message);
                }
            }

            sqlUpit.CommandText = "Update MT_Izdatnica Set Zaduzen = 1 Where ID = @ID_Izdatnice";
            sqlUpit.ExecuteNonQuery();

            if (negative.Length > 0)
            {
                System.Windows.Forms.MessageBox.Show(negative.ToString());
            }
        }

        private decimal GetAverigePrice(DateTime datum, int proizvod, SqlCommand sqlUpit, int skladiste, decimal cijenaDokument)
        {
            //sqlUpit.CommandText = "Select ISNULL(Sum(MT_PrimkaStavke.CijenaPDV * MT_PrimkaStavke.Kolicina) , 0) / SUM(MT_PrimkaStavke.Kolicina) From MT_SkladisteStavke " + 
            //    "Inner Join MT_PrimkaStavke On MT_SkladisteStavke.ID_PrimkaStavke = MT_PrimkaStavke.ID Where " +
            //    "MT_SkladisteStavke.TS <= '" + datum.ToString("yyyy-MM-dd") + "' And MT_SkladisteStavke.ID_Proizvod = " + proizvod + " And MT_SkladisteStavke.ID_Skladista = " + skladiste;

            sqlUpit.CommandText = "Select Top 1 Abs(Round((MT_SkladisteStavke.Saldo / MT_SkladisteStavke.Stanje), 4)) From MT_SkladisteStavke " +
                   "Where MT_SkladisteStavke.ID_Skladista = " + skladiste + " And MT_SkladisteStavke.ID_Proizvod = " + proizvod + " And MT_SkladisteStavke.TS <= '" + datum.ToString("yyyy-MM-dd") +
                   "' And Stanje <> 0 Order by TS desc, RedniBrojDan desc";


            try
            {
                decimal cijena = Convert.ToDecimal(sqlUpit.ExecuteScalar());
                return cijena;
            }
            catch { return cijenaDokument; }
        }


        private void SetCijenaIzdatnica(SqlCommand sqlUpit)
        {
            sqlUpit.CommandText = "Update MT_IzdatnicaStavka Set NabavnaCijena = @NabavnaCijena, UkupanIznos = Kolicina * @NabavnaCijena, RedniBrojDan = @RedniBrojDan Where ID = @ID_IzdatnicaStavke";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch { }

            sqlUpit.CommandText = "Update MT_Izdatnica Set UkupanIznos = (Select Sum(UkupanIznos) From MT_IzdatnicaStavka Where ID_Izdatnice = @ID_Izdatnice) Where ID = @ID_Izdatnice";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch { }
        }


        internal void ProvjeraDaliMozeNaSkladiste(int proizvod, decimal koicina, int skladiste, DateTime datum, string nazivProizvod, StringBuilder message)
        {
            decimal stanje;
            try
            {
                stanje = Convert.ToDecimal(client.ExecuteScalar("Select Top 1 Stanje From MT_SkladisteStavke Where ID_Proizvod = " + proizvod + " And ID_Skladista = " + skladiste +
                                                                " And TS <= '" + datum.ToString("yyyy-MM-dd") + "' Order by TS desc, RedniBrojDan desc"));
            }
            catch 
            {
                stanje = 0;
            }

            if (stanje < koicina)
            {
                message.Append(string.Format(" - Proizvod: {0} | {1} ima nedovoljno stanje na odabranom skladištu na odabrani datum!\n", proizvod, nazivProizvod));
            }
        }
    }
}
