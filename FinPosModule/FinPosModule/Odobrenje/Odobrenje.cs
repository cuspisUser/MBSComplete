using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.IO;
using Mipsed7.DataAccessLayer.EntityFramework;
using System.Data.SqlClient;

namespace FinPosModule
{
    public class Odobrenje : IDisposable
    {
        SqlClient client = null;
        public Odobrenje()
            : base()
        {
            client = new SqlClient();
        }

        public void Dispose()
        {

        }


        #region Properties
        
        public static int pSelectedIndex { get; set; }

        //odobrenje
        public static Nullable<int> pID { get; set; }
        public string pSifra { get; set; }
        public int pID_Odobrenje { get; set; }
        public int pID_Godina { get; set; }
        public int pID_Partner { get; set; }
        public DateTime pDatumIzdavanja { get; set; }
        public string pNapomena { get; set; }

        //OdobrenjeStavke
        public int pID_Proizvod { get; set; }
        public int pID_Porez { get; set; }
        public decimal pCijenaNeto { get; set; }
        public decimal pRabatStopa { get; set; }
        public decimal pKolicina { get; set; }
        public decimal pCijenaPDV { get; set; }

        public static DataTable pOdobrenjeStavke { get; set; }

        #endregion

        #region WorkWithData

        public DataSet GetMainGridData()
        {
            DataSet ds = new DataSet();

            DataTable dt_primary = client.GetDataTable("Select ID, Sifra, PARTNER.NAZIVPARTNER As Partner, DatumIzdavanja, Napomena From Odobrenje Inner Join PARTNER On Odobrenje.ID_Partner = PARTNER.IDPARTNER");

            DataTable dt_related1 = client.GetDataTable("Select ID_Odobrenje, PROIZVOD.NAZIVPROIZVOD As Proizvod, Kolicina, CijenaNeto As 'Cijena Neto', OdobrenjeStavke.CijenaPDV As 'Cijena PDV' " + 
                                                        "From OdobrenjeStavke Inner Join PROIZVOD On OdobrenjeStavke.ID_Proizvod = PROIZVOD.IDPROIZVOD");

            ds.Tables.Add(dt_primary);
            ds.Tables.Add(dt_related1);

            DataRelation relation1 = new DataRelation("Odobrenje", dt_primary.Columns["ID"], dt_related1.Columns["ID_Odobrenje"]);

            ds.Relations.Add(relation1);

            return ds;
        }

        public DataRow GetOdobrenje()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Select Sifra, ID_Godina, ID_Partner, DatumIzdavanja, Napomena From Odobrenje Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            return client.GetDataTable(sqlUpit).Rows[0];
        }

        internal object GetPartner()
        {
            return client.GetDataTable("Select IDPARTNER As ID, NAZIVPARTNER As Naziv From Partner");
        }

        internal object GetProizvod()
        {
            return client.GetDataTable("Select IDPROIZVOD As ID, NAZIVPROIZVOD AS Naziv From PROIZVOD");
        }

        internal object GetPorez()
        {
            return client.GetDataTable("Select FINPOREZIDPOREZ As ID, FINPOREZNAZIVPOREZ AS Naziv From FINPOREZ");
        }

        internal object GetGodina()
        {
            return client.GetDataTable("Select IDGODINE As ID, IDGODINE AS Naziv From GODINE Order by GODINEAKTIVNA Desc");
        }

        public bool Delete(StringBuilder message)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete from OdobrenjeStavke Where ID_Odobrenje = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();

                sqlUpit.CommandText = "Delete from Odobrenje Where ID = @ID";

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

        internal string GetNextID(int godina)
        {
            string broj_odobrenja = string.Empty;
            int broj = 0;

            SqlCommand command = new SqlCommand("Select Max(Sifra) From Odobrenje Where ID_Godina = " + godina, client.sqlConnection);
            broj_odobrenja = command.ExecuteScalar().ToString();

            if (broj_odobrenja.Length < 1)
            {
                broj_odobrenja = "0001";
            }
            else
            {
                broj = Convert.ToInt32(broj_odobrenja) + 1;

                if (broj.ToString().Length == 1)
                {
                    broj_odobrenja = "000" + (broj).ToString();
                }
                else if (broj.ToString().Length == 2)
                {
                    broj_odobrenja = "00" + (broj).ToString();
                }
                else if (broj.ToString().Length == 3)
                {
                    broj_odobrenja = "0" + (broj).ToString();
                }
                else if (broj.ToString().Length == 4)
                {
                    broj_odobrenja = (broj).ToString();
                }
            }
            return broj_odobrenja;
        }

        internal bool Insert(StringBuilder message, Odobrenje objekt)
        {
            int id;
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Odobrenje");

            sqlUpit.Transaction = transakcija;

            sqlUpit.CommandText = "Insert Into Odobrenje ([ID_Godina], [ID_Partner], [Sifra], [DatumIzdavanja], [Napomena], [TS]) Values " +
                                  "(@ID_Godina, @ID_Partner, @Sifra, @DatumIzdavanja, @Napomena, @TS) Select @@Identity";

            sqlUpit.Parameters.Add(new SqlParameter("@Sifra", objekt.pSifra));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Godina", objekt.pID_Godina));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Partner", objekt.pID_Partner));
            sqlUpit.Parameters.Add(new SqlParameter("@DatumIzdavanja", objekt.pDatumIzdavanja));
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
            if (Odobrenje.pOdobrenjeStavke.Rows.Count > 0)
            {
                sqlUpit.Parameters.Clear();

                sqlUpit.Parameters.Add(new SqlParameter("@ID_Odobrenje", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Proizvod", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Porez", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@CijenaNeto", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@RabatStopa", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@Kolicina", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@CijenaPDV", ""));

                foreach (DataRow red in Odobrenje.pOdobrenjeStavke.Rows)
                {

                    sqlUpit.CommandText = "Insert Into OdobrenjeStavke ([ID_Odobrenje], [ID_Proizvod], [ID_Porez], [CijenaNeto], [RabatStopa], [Kolicina], [CijenaPDV]) Values " +
                                          "(@ID_Odobrenje, @ID_Proizvod, @ID_Porez, @CijenaNeto, @RabatStopa, @Kolicina, @CijenaPDV)";


                    sqlUpit.Parameters["@ID_Odobrenje"].Value = id;
                    sqlUpit.Parameters["@ID_Proizvod"].Value = Convert.ToInt32(red["ID_Proizvod"]);
                    sqlUpit.Parameters["@ID_Porez"].Value = Convert.ToInt32(red["ID_Porez"]);
                    sqlUpit.Parameters["@CijenaNeto"].Value = Convert.ToDecimal(red["CijenaNeto"]);
                    sqlUpit.Parameters["@RabatStopa"].Value = Convert.ToDecimal(red["RabatStopa"]);
                    sqlUpit.Parameters["@Kolicina"].Value = Convert.ToDecimal(red["Kolicina"]);
                    sqlUpit.Parameters["@CijenaPDV"].Value = Convert.ToDecimal(red["CijenaPDV"]);

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
                if (message.Length > 0)
                {
                    return false;
                }
            }
            return true;
        }

        internal bool Update(StringBuilder message, Odobrenje objekt)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Odobrenje");

            sqlUpit.Transaction = transakcija;

            sqlUpit.CommandText = "Update Odobrenje Set ID_Godina = @ID_Godina, ID_Partner = @ID_Partner, Sifra = @Sifra, " +
                                  "DatumIzdavanja = @DatumIzdavanja, Napomena = @Napomena, TS = @TS Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@Sifra", objekt.pSifra));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Godina", objekt.pID_Godina));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Partner", objekt.pID_Partner));
            sqlUpit.Parameters.Add(new SqlParameter("@DatumIzdavanja", objekt.pDatumIzdavanja));
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
            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();

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

            sqlUpit.CommandText = "Delete From OdobrenjeStavke Where ID_Odobrenje = @ID";
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

        #endregion

        internal DataTable GetPostojeceStavke()
        {
            return client.GetDataTable("Select 'false' As SEL, ID_Odobrenje, ID_Proizvod, PROIZVOD.NAZIVPROIZVOD As Proizvod, ID_Porez, FINPOREZ.FINPOREZNAZIVPOREZ As Porez, " +
                                       "OdobrenjeStavke.CijenaNeto, OdobrenjeStavke.RabatStopa, OdobrenjeStavke.Kolicina, OdobrenjeStavke.CijenaPDV From OdobrenjeStavke " +
                                       "Inner Join PROIZVOD On OdobrenjeStavke.ID_Proizvod = PROIZVOD.IDPROIZVOD " +
                                       "Inner Join FINPOREZ On OdobrenjeStavke.ID_Porez = FINPOREZ.FINPOREZIDPOREZ " +
                                       "Where odobrenjeStavke.ID_Odobrenje =" + pID);
        }

        internal DataTable GetOdobrenjeIspis()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "SELECT * From v_Odobrenje Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            return client.GetDataTable(sqlUpit);
        }

        internal DataRow GetPorezCijena(int proizvod)
        {
            return client.GetDataTable("Select Proizvod.FINPOREZIDPOREZ As ID_PDV, Proizvod.Cijena, Proizvod.CijenaPDV From Proizvod " + 
                                       "Inner Join FINPOREZ on PROIZVOD.FINPOREZIDPOREZ = FINPOREZ.FINPOREZIDPOREZ Where PROIZVOD.IDPROIZVOD = " + proizvod).Rows[0];
        }

        internal decimal GetStopaPorez(int porez)
        {
            return Convert.ToDecimal(client.ExecuteScalar("Select FINPOREZSTOPA From FINPOREZ Where FINPOREZIDPOREZ = " + porez));
        }
    }
}
