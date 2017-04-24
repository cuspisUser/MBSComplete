using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;

namespace Materijalno.BusinessLogic
{
    public class Meduskladisnica : Base, IDisposable
    {
        SqlClient client = null;
        public Meduskladisnica()
            : base()
        {
            client = new SqlClient();
        }

        #region Properties

        public static int pID { get; set; }
        public int pSifra { get; set; }
        public int pIzlaznoSkladiste { get; set; }
        public int pUlaznoSkladiste { get; set; }
        public DateTime pDatum { get; set; }
        public static DataTable pMeduskladisnicaStavke { get; set; }

        #endregion

        #region Work with data

        public DataSet GetMainGridData()
        {
            DataSet ds = new DataSet();

            string active_year = client.ExecuteScalar("Select IDGODINE From GODINE Where GODINEAKTIVNA = 1").ToString();

            DataTable dt_primary = client.GetDataTable("Select ID, Sifra, Datum, " +
                                   "(Select Naziv From MT_Skladista Where MT_Skladista.ID = MT_Meduskladisnica.ID_IzlaznoSkladiste) As IzlaznoSkladiste, " + 
                                   "(Select Naziv From MT_Skladista Where MT_Skladista.ID = MT_Meduskladisnica.ID_UlaznoSkladiste) As UlaznoSkladiste " + 
                                   "From MT_Meduskladisnica Where YEAR(Datum) =" + active_year);

            DataTable dt_related1 = client.GetDataTable("Select ID_Meduskladisnice, PROIZVOD.IDPROIZVOD, PROIZVOD.NAZIVPROIZVOD AS Proizvod, MT_MeduskladisnicaStavka.Kolicina From " + 
                                    "MT_MeduskladisnicaStavka Inner Join PROIZVOD On MT_MeduskladisnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD  " + 
                                    "Inner Join MT_Meduskladisnica On MT_MeduskladisnicaStavka.ID_Meduskladisnice = MT_Meduskladisnica.ID " +
                                    "Where YEAR(MT_Meduskladisnica.Datum) = " + active_year + " Order by PROIZVOD.NAZIVPROIZVOD");

            ds.Tables.Add(dt_primary);
            ds.Tables.Add(dt_related1);

            DataRelation relation1 = new DataRelation("Meduskladisnica", dt_primary.Columns["ID"], dt_related1.Columns["ID_Meduskladisnice"]);

            ds.Relations.Add(relation1);

            return ds;
        }

        public bool Delete(StringBuilder message)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;


            sqlUpit.CommandText = "Delete MT_SkladisteStavke From MT_SkladisteStavke Inner Join " +
                                  "MT_MeduskladisnicaStavka On MT_SkladisteStavke.ID_MeduskladisnicaStavke = MT_MeduskladisnicaStavka.ID Where MT_MeduskladisnicaStavka.ID_Meduskladisnice = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();

                sqlUpit.CommandText = "Delete from MT_MeduskladisnicaStavka Where ID_Meduskladisnice = @ID";

                sqlUpit.ExecuteNonQuery();

                sqlUpit.CommandText = "Delete from MT_Meduskladisnica Where ID = @ID";

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

        public bool Insert(StringBuilder message, Meduskladisnica objekt)
        {
            int id;
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Meduskladisnica");

            sqlUpit.Transaction = transakcija;

            sqlUpit.CommandText = "Insert Into MT_Meduskladisnica ([ID_IzlaznoSkladiste], [ID_UlaznoSkladiste], [Sifra], [Datum], [TS]) Values " +
                                  "(@ID_IzlaznoSkladiste, @ID_UlaznoSkladiste, @Sifra, @Datum, @TS) Select @@Identity";

            sqlUpit.Parameters.Add(new SqlParameter("@ID_IzlaznoSkladiste", objekt.pIzlaznoSkladiste));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_UlaznoSkladiste", objekt.pUlaznoSkladiste));
            sqlUpit.Parameters.Add(new SqlParameter("@Sifra", objekt.pSifra));
            sqlUpit.Parameters.Add(new SqlParameter("@Datum", objekt.pDatum));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

            try
            {
                id = Convert.ToInt32(sqlUpit.ExecuteScalar());

                if (InsertStavke(message, sqlUpit, id))
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

        private bool InsertStavke(StringBuilder message, SqlCommand sqlUpit, int id)
        {
            if (BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Rows.Count > 0)
            {
                int id_stavka;

                sqlUpit.Parameters.Clear();

                sqlUpit.Parameters.Add(new SqlParameter("@ID_Meduskladisnice", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Proizvoda", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@IzlaznaCijena", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@UlaznaCijena", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@Kolicina", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Skladista", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@ID_MeduskladisnicaStavke", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@Stanje", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@Saldo", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@TS", ""));

                foreach (DataRow red in BusinessLogic.Meduskladisnica.pMeduskladisnicaStavke.Rows)
                {

                    sqlUpit.CommandText = "Insert Into MT_MeduskladisnicaStavka ([ID_Meduskladisnice], [ID_Proizvoda], [Kolicina], [IzlaznaCijena], [UlaznaCijena]) " +
                                          "Values (@ID_Meduskladisnice, @ID_Proizvoda, @Kolicina, @IzlaznaCijena, @UlaznaCijena) Select @@Identity";

                    sqlUpit.Parameters["@ID_Meduskladisnice"].Value = id;
                    sqlUpit.Parameters["@ID_Proizvoda"].Value = Convert.ToInt32(red["ID_Proizvoda"]);
                    sqlUpit.Parameters["@IzlaznaCijena"].Value = Convert.ToDecimal(red["IzlaznaCijena"]);
                    sqlUpit.Parameters["@UlaznaCijena"].Value = Convert.ToDecimal(red["UlaznaCijena"]);
                    sqlUpit.Parameters["@Kolicina"].Value = Convert.ToDecimal(red["Kolicina"]);

                    try
                    {
                        id_stavka = Convert.ToInt32(sqlUpit.ExecuteScalar());

                        InsertSkladisteStavke(message, sqlUpit, id_stavka, Convert.ToInt32(red["ID_Proizvoda"]), Convert.ToDecimal(red["Kolicina"]), Convert.ToDecimal(red["UlaznaCijena"]), Convert.ToDecimal(red["IzlaznaCijena"]));
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

        private void InsertSkladisteStavke(StringBuilder message, SqlCommand sqlUpit, int id_stavka, int proizvod, decimal kolicina, decimal ulazna_cijena, decimal izlazna_cijena)
        {
            decimal stanje = 0;
            decimal saldo_ulaz = 0;
            decimal saldo_izlaz = 0;
            DataTable rowStanje = new DataTable();
            SqlDataAdapter adp;

            sqlUpit.CommandText = "Select (ISNULL(SUM(MT_SkladisteStavke.Kolicina), 0) - (Select ISNULL(SUM(MT_SkladisteStavke.Kolicina), 0) From MT_SkladisteStavke " +
            "Inner Join MT_IzdatnicaStavka On MT_SkladisteStavke.ID_IzdatnicaStavke = MT_IzdatnicaStavka.ID Where MT_SkladisteStavke.ID_Skladista = '" + pUlaznoSkladiste + "' And " +
            "MT_IzdatnicaStavka.ID_Proizvoda = '" + proizvod + "')) As Kolicina From MT_SkladisteStavke Left Join MT_PrimkaStavke On MT_SkladisteStavke.ID_PrimkaStavke = MT_PrimkaStavke.ID " +
            "Left Join MT_MeduskladisnicaStavka On MT_SkladisteStavke.ID_MeduskladisnicaStavke = MT_MeduskladisnicaStavka.ID Where MT_SkladisteStavke.ID_Skladista = '" + pUlaznoSkladiste + "' " +
            "And (MT_PrimkaStavke.ID_Proizvoda = '" + proizvod + "' OR MT_MeduskladisnicaStavka.ID_Proizvoda = '" + proizvod + "')";

            stanje = Convert.ToDecimal(sqlUpit.ExecuteScalar());
            //saldo izlaz
            try
            {
                sqlUpit.CommandText = "Select Top(1) ID_PrimkaStavke, ID_IzdatnicaStavke, ID_MeduskladisnicaStavke From MT_SkladisteStavke Where ID_Skladista = " + pIzlaznoSkladiste  + " And ID_Proizvod = '" + proizvod + "' Order by TS Desc";
                adp = new SqlDataAdapter(sqlUpit);
                adp.Fill(rowStanje);

                //primka
                if (rowStanje.Rows[0]["ID_PrimkaStavke"].ToString().Length > 0)
                {
                    sqlUpit.CommandText = "Select Top(1) Saldo From MT_SkladisteStavke Inner Join MT_PrimkaStavke On MT_SkladisteStavke.ID_PrimkaStavke = MT_PrimkaStavke.ID " +
                                          "Where ID_Skladista = '" + pIzlaznoSkladiste + "' And ID_Proizvoda = '" + proizvod + "' Order by TS Desc";
                }//izadatnica
                else if (rowStanje.Rows[0]["ID_IzdatnicaStavke"].ToString().Length > 0)
                {
                    sqlUpit.CommandText = "Select Top(1) Saldo From MT_SkladisteStavke Inner Join MT_IzdatnicaStavka On MT_SkladisteStavke.ID_IzdatnicaStavke = MT_IzdatnicaStavka.ID " +
                                          "Where ID_Skladista = '" + pIzlaznoSkladiste + "' And ID_Proizvoda = '" + proizvod + "' Order by TS Desc";
                }//meduskladisnica
                else
                {
                    sqlUpit.CommandText = "Select Top(1) Saldo From MT_SkladisteStavke Inner Join MT_MeduskladisnicaStavka On MT_SkladisteStavke.ID_MeduskladisnicaStavke = MT_MeduskladisnicaStavka.ID " +
                                          "Where ID_Skladista = '" + pIzlaznoSkladiste + "' And ID_Proizvoda = '" + proizvod + "' Order by TS Desc";
                }

                try
                {
                    saldo_izlaz = Convert.ToDecimal(sqlUpit.ExecuteScalar());
                }
                catch { saldo_izlaz = 0; }
            }
            catch { saldo_izlaz = 0; }

            //saldo ulaz
            try
            {
                sqlUpit.CommandText = "Select Top(1) ID_PrimkaStavke, ID_IzdatnicaStavke, ID_MeduskladisnicaStavke From MT_SkladisteStavke Where ID_Skladista = " + pUlaznoSkladiste + " And ID_Proizvod = '" + proizvod + "' Order by TS Desc";
                adp = new SqlDataAdapter(sqlUpit);
                adp.Fill(rowStanje);

                //primka
                if (rowStanje.Rows[0]["ID_PrimkaStavke"].ToString().Length > 0)
                {
                    sqlUpit.CommandText = "Select Top(1) Saldo From MT_SkladisteStavke Inner Join MT_PrimkaStavke On MT_SkladisteStavke.ID_PrimkaStavke = MT_PrimkaStavke.ID " +
                                          "Where ID_Skladista = '" + pUlaznoSkladiste + "' And ID_Proizvoda = '" + proizvod + "' Order by TS Desc";
                }//izadatnica
                else if (rowStanje.Rows[0]["ID_IzdatnicaStavke"].ToString().Length > 0)
                {
                    sqlUpit.CommandText = "Select Top(1) Saldo From MT_SkladisteStavke Inner Join MT_IzdatnicaStavka On MT_SkladisteStavke.ID_IzdatnicaStavke = MT_IzdatnicaStavka.ID " +
                                          "Where ID_Skladista = '" + pUlaznoSkladiste + "' And ID_Proizvoda = '" + proizvod + "' Order by TS Desc";
                }//meduskladisnica
                else
                {
                    sqlUpit.CommandText = "Select Top(1) Saldo From MT_SkladisteStavke Inner Join MT_MeduskladisnicaStavka On MT_SkladisteStavke.ID_MeduskladisnicaStavke = MT_MeduskladisnicaStavka.ID " +
                                          "Where ID_Skladista = '" + pUlaznoSkladiste + "' And ID_Proizvoda = '" + proizvod + "' Order by TS Desc";
                }

                try
                {
                    saldo_ulaz = Convert.ToDecimal(sqlUpit.ExecuteScalar());
                }
                catch { saldo_ulaz = 0; }
            }
            catch { saldo_ulaz = 0; }
            
            sqlUpit.CommandText = "Insert Into MT_SkladisteStavke ([ID_Skladista], [ID_MeduskladisnicaStavke], [Kolicina], [Stanje], [Saldo], [TS], [ID_Proizvod]) Values " +
                                        "(@ID_Skladista, @ID_MeduskladisnicaStavke, @Kolicina, @Stanje, @Saldo, @TS, @ID_Proizvoda)";

            sqlUpit.Parameters["@ID_Skladista"].Value = pUlaznoSkladiste;
            sqlUpit.Parameters["@ID_MeduskladisnicaStavke"].Value = id_stavka;
            sqlUpit.Parameters["@TS"].Value = DateTime.Now;
            sqlUpit.Parameters["@Stanje"].Value = stanje + kolicina;
            sqlUpit.Parameters["@Saldo"].Value = saldo_ulaz + (kolicina * ulazna_cijena);

            try
            {
                sqlUpit.ExecuteNonQuery();

                sqlUpit.CommandText = "Select (ISNULL(SUM(MT_SkladisteStavke.Kolicina), 0) - (Select ISNULL(SUM(MT_SkladisteStavke.Kolicina), 0) From MT_SkladisteStavke " +
                "Inner Join MT_IzdatnicaStavka On MT_SkladisteStavke.ID_IzdatnicaStavke = MT_IzdatnicaStavka.ID Where MT_SkladisteStavke.ID_Skladista = '" + pIzlaznoSkladiste + "' And " +
                "MT_IzdatnicaStavka.ID_Proizvoda = '" + proizvod + "')) As Kolicina From MT_SkladisteStavke Left Join MT_PrimkaStavke On MT_SkladisteStavke.ID_PrimkaStavke = MT_PrimkaStavke.ID " +
                "Left Join MT_MeduskladisnicaStavka On MT_SkladisteStavke.ID_MeduskladisnicaStavke = MT_MeduskladisnicaStavka.ID Where MT_SkladisteStavke.ID_Skladista = '" + pIzlaznoSkladiste + "' " +
                "And (MT_PrimkaStavke.ID_Proizvoda = '" + proizvod + "' OR MT_MeduskladisnicaStavka.ID_Proizvoda = '" + proizvod + "')";

                stanje = Convert.ToDecimal(sqlUpit.ExecuteScalar());

                sqlUpit.CommandText = "Insert Into MT_SkladisteStavke ([ID_Skladista], [ID_MeduskladisnicaStavke], [Kolicina], [Stanje], [Saldo], [TS], [ID_Proizvod]) Values " +
                                        "(@ID_Skladista, @ID_MeduskladisnicaStavke, @Kolicina, @Stanje, @Saldo, @TS, @ID_Proizvoda)";

                sqlUpit.Parameters["@Kolicina"].Value = Convert.ToDecimal(sqlUpit.Parameters["@Kolicina"].Value) * - 1;
                sqlUpit.Parameters["@ID_Skladista"].Value = pIzlaznoSkladiste;
                sqlUpit.Parameters["@Stanje"].Value = stanje - kolicina;
                sqlUpit.Parameters["@Saldo"].Value = saldo_izlaz - (kolicina * izlazna_cijena);

                sqlUpit.ExecuteNonQuery();
            }
            catch (SqlException greska)
            {
                message.Append(greska.Message);
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
            }
        }

        public bool Update(StringBuilder message, Meduskladisnica objekt)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Meduskladisnica");

            sqlUpit.Transaction = transakcija;

            sqlUpit.CommandText = "Update MT_Meduskladisnica Set ID_IzlaznoSkladiste = @ID_IzlaznoSkladiste, ID_UlaznoSkladiste = @ID_UlaznoSkladiste, Sifra = @Sifra, " +
                                  "Datum = @Datum, TS = @TS Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID_IzlaznoSkladiste", objekt.pIzlaznoSkladiste));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_UlaznoSkladiste", objekt.pUlaznoSkladiste));
            sqlUpit.Parameters.Add(new SqlParameter("@Sifra", objekt.pSifra));
            sqlUpit.Parameters.Add(new SqlParameter("@Datum", objekt.pDatum));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));
            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();

                if (DeleteStavkeSkladiste(message, sqlUpit))
                {

                    if (DeleteStavke(message, sqlUpit))
                    {
                        if (InsertStavke(message, sqlUpit, (int)pID))
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

            sqlUpit.CommandText = "Delete From MT_MeduskladisnicaStavka Where ID_Meduskladisnice = @ID";
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
                                  "MT_MeduskladisnicaStavka On MT_SkladisteStavke.ID_MeduskladisnicaStavke = MT_MeduskladisnicaStavka.ID Where MT_MeduskladisnicaStavka.ID_Meduskladisnice = @ID";
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

        internal object GetBrojDokumenta()
        {
            string broj = client.GetDataTable("Select Max(Sifra + 1) from MT_Meduskladisnica").Rows[0][0].ToString();

            if (broj == "")
            {
                return 1;
            }
            else
            {
                return broj;
            }
        }

        internal object GetSkladiste()
        {
            return client.GetDataTable("Select ID, Naziv From MT_Skladista");
        }

        public DataRow GetRow()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "SELECT [ID],[ID_IzlaznoSkladiste],[ID_UlaznoSkladiste],[Sifra],[Datum],[TS] FROM [MT_Meduskladisnica] Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            return client.GetDataTable(sqlUpit).Rows[0];
        }

        internal DataTable GetProizvodiZaSkladiste(int skladiste)
        {
            return client.GetDataTable("Select Distinct PROIZVOD.IDPROIZVOD AS ID, PROIZVOD.NAZIVPROIZVOD As Naziv From MT_SkladisteStavke " + 
                                       "Left Join MT_PrimkaStavke On MT_SkladisteStavke.ID_PrimkaStavke = MT_PrimkaStavke.ID " +
                                       "Left Join MT_MeduskladisnicaStavka On MT_SkladisteStavke.ID_MeduskladisnicaStavke = MT_MeduskladisnicaStavka.ID " +
                                       "Inner Join PROIZVOD On MT_PrimkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD Or MT_MeduskladisnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD " +
                                       "Where MT_SkladisteStavke.ID_Skladista = " + skladiste + " And MT_SkladisteStavke.Kolicina > 0 Order by PROIZVOD.NAZIVPROIZVOD");
        }

        internal DataRow GetStanjeSkladiste(int proizvod, int skladiste)
        {
            DataTable tbl = client.GetDataTable("Select * from v_StanjeSkladista Where ID_Skladiste = " + skladiste + " And Sifra = " + proizvod);

            foreach (DataRow red in tbl.Rows)
            {
                red["Kolicina"] = GetKolicina(red["Sifra"].ToString(), skladiste);

                red["Saldo"] = GetPrice(red["Sifra"].ToString(), skladiste);

                red["BasePrice"] = Math.Round(Convert.ToDecimal(red["Saldo"]) / Convert.ToDecimal(red["Kolicina"]), 2);
            }

            return tbl.Rows[0];
        }

        private object GetPrice(string proizvod, int skladiste)
        {
            DataTable tbl = client.GetDataTable("Select Top 1 Saldo From MT_SkladisteStavke Left Join MT_PrimkaStavke On MT_SkladisteStavke.ID_PrimkaStavke = MT_PrimkaStavke.ID " +
                            "Left Join MT_MeduskladisnicaStavka On MT_SkladisteStavke.ID_MeduskladisnicaStavke = MT_MeduskladisnicaStavka.ID " +
                            "Left Join MT_IzdatnicaStavka On MT_SkladisteStavke.ID_IzdatnicaStavke = MT_IzdatnicaStavka.ID " +
                            "Where MT_SkladisteStavke.ID_Skladista = " + skladiste + " And (MT_PrimkaStavke.ID_Proizvoda = " + proizvod + " OR MT_MeduskladisnicaStavka.ID_Proizvoda = " + proizvod +
                            " OR MT_IzdatnicaStavka.ID_Proizvoda = " + proizvod + ") Order by TS desc");

            return tbl.Rows[0]["Saldo"];
        }

        public object GetKolicina(string proizvod, int skladiste)
        {
            DataTable tbl = client.GetDataTable("Select (ISNULL(SUM(MT_SkladisteStavke.Kolicina), 0) - (Select ISNULL(SUM(MT_SkladisteStavke.Kolicina), 0) " +
                            "From MT_SkladisteStavke Inner Join MT_IzdatnicaStavka On MT_SkladisteStavke.ID_IzdatnicaStavke = MT_IzdatnicaStavka.ID " +
                            "Where MT_SkladisteStavke.ID_Skladista = " + skladiste + " And MT_IzdatnicaStavka.ID_Proizvoda = " + proizvod + ")) As Kolicina From MT_SkladisteStavke  " +
                            "Left Join MT_PrimkaStavke On MT_SkladisteStavke.ID_PrimkaStavke = MT_PrimkaStavke.ID " +
                            "Left Join MT_MeduskladisnicaStavka oN MT_SkladisteStavke.ID_MeduskladisnicaStavke = MT_MeduskladisnicaStavka.ID " +
                            "Where MT_SkladisteStavke.ID_Skladista = " + skladiste + " And (MT_PrimkaStavke.ID_Proizvoda = " + proizvod +
                            " OR MT_MeduskladisnicaStavka.ID_Proizvoda = " + proizvod + ")");
            return tbl.Rows[0]["Kolicina"];
        }

        internal DataTable GetPostojeceStavke()
        {
            return client.GetDataTable("Select 'false' As SEL, MT_MeduskladisnicaStavka.ID_Meduskladisnice As ID_Meduskladisnica, MT_MeduskladisnicaStavka.ID_Proizvoda, " +
            "PROIZVOD.NAZIVPROIZVOD As Proizvod, MT_MeduskladisnicaStavka.IzlaznaCijena, MT_MeduskladisnicaStavka.UlaznaCijena, MT_MeduskladisnicaStavka.Kolicina From MT_MeduskladisnicaStavka " +
            "Inner Join PROIZVOD On MT_MeduskladisnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD Where MT_MeduskladisnicaStavka.ID_Meduskladisnice =" + pID);
        }


        internal DataTable GetMeduskladisnicaIspis()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Select Sifra, Datum, IzlaznoSkladiste, UlaznoSkladiste, IDPROIZVOD, Proizvod, Kolicina, JedinicaMjere, IzlaznaCijena, UlaznaCijena From v_Meduskladisnica Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            return client.GetDataTable(sqlUpit);
        }

        #endregion

        public void Dispose()
        {
        }

        public static int pSelectedIndex { get; set; }
    }
}
