using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;

namespace Materijalno.BusinessLogic
{
    public class Inventura : Base, IDisposable
    {
        SqlClient client = null;
        InventuraStavke stavke;

        public Inventura()
            : base()
        {
            client = new SqlClient();
            stavke = new InventuraStavke();
        }

        public void Dispose()
        {
            client.CloseConnection();
        }

        #region Props
        public static Nullable<int> pID { get; set; }
        public static Nullable<int> pIDStavke { get; set; }
        public static DateTime datumInventure { get; set; }
        public int idSkladiste { get; set; }
        public Int16 idGodina { get; set; }

        private static DataTable pinventuraStavke;
        public static DataTable pInventuraStavke
        {
            get { return Inventura.pinventuraStavke; }
            set { Inventura.pinventuraStavke = value; }
        }
      
        public static int pSelectedIndex { get; set; }

        #endregion

        #region Work with data

        public DataSet GetMainGridData()
        {
            DataSet ds = new DataSet();

            //MT_Inventura --> Band[0] --> dohvat SVIH
            DataTable dt_primary = client.GetDataTable("SELECT inv.ID, inv.DatumInventure,sklad.ID as IDSkladista, sklad.Naziv as Skladiste, inv.IDGodina, inv.TS FROM MT_Inventura inv left join MT_Skladista sklad on sklad.ID = inv.IDSKladiste");

            //MT_InventuraStavka --> Band[1]  --> dohvat SVIH
            DataTable dt_related1 = new DataTable();
            SqlCommand sqlComm;
       
            sqlComm = new SqlCommand("spInventuraDohvatStavki", client.sqlConnection);
            sqlComm.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(dt_related1);   

            ds.Tables.Add(dt_primary);
            ds.Tables.Add(dt_related1);

            DataRelation relation1 = new DataRelation("Inventuraaa", dt_primary.Columns["ID"], dt_related1.Columns["ID_Inventura"]);

            ds.Relations.Add(relation1);

            return ds;
        }

        public DataSet GetMainGridData2()
        {
            DataSet ds = new DataSet();

            //MT_Inventura --> Band[0]
            DataTable dt_primary = client.GetDataTable("SELECT inv.ID, inv.DatumInventure, sklad.Naziv as Skladiste, inv.IDGodina, inv.TS FROM MT_Inventura inv left join MT_Skladista sklad on sklad.ID = inv.IDSKladiste");

            //MT_InventuraStavka --> Band[1]
            DataTable dt_related1 = client.GetDataTable("SELECT ID, ID_Inventura, ID_Proizvod, pro.NAZIVPROIZVOD, jed.NAZIVJEDINICAMJERE, KolicinaZaliha, StvarnaKolicina FROM MT_InventuraStavka stav " +
            "left join PROIZVOD pro on pro.IDPROIZVOD = stav.ID_Proizvod " +
            "left join JEDINICAMJERE jed on pro.IDJEDINICAMJERE = jed.IDJEDINICAMJERE " +
            "where stav.ID_Inventura = '" + UI.Dokumenti.InventuraFormPregled._idInv + "' "+
            "order by pro.NAZIVPROIZVOD");

            ds.Tables.Add(dt_primary);
            ds.Tables.Add(dt_related1);

            DataRelation relation1 = new DataRelation("Inventuraaa", dt_primary.Columns["ID"], dt_related1.Columns["ID_Inventura"]);

            ds.Relations.Add(relation1);

            return ds;
        }

        public bool Delete(StringBuilder message)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.CommandText = "Delete from MT_InventuraStavka Where ID_Inventura = @ID";

                sqlUpit.ExecuteNonQuery();

                sqlUpit.CommandText = "Delete from MT_Inventura Where ID = @ID";

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

        public bool Insert(StringBuilder message, Inventura obj)
        {
            bool x = false;

            SqlConnection conn = new SqlConnection();
            conn = client.sqlConnection;

            if (client.sqlConnection.State == ConnectionState.Closed) conn.Open();
           
            try
            {
                //dohvat iz StanjaSkladišta!
                SqlCommand com = new SqlCommand("spStanjeSkladista", conn);
                com.Parameters.AddWithValue("@idSkladista", obj.idSkladiste);
                com.Parameters.AddWithValue("@datum", Inventura.datumInventure);
                com.Parameters.AddWithValue("@order", "PROIZVOD.NAZIVPROIZVOD");

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(com);
                com.CommandType = CommandType.StoredProcedure;
                da.Fill(dt); //ova tablica se puni u MT_InventuraStavke
                if(dt.Rows.Count == 0) 
                {
                    MessageBox.Show("Odabrana inventura ne sadrži nikakve proizvode.");
                    return false;
                }


                //prvo upis inventure u bazu
                SqlCommand comm = new SqlCommand();
                comm.Connection = client.sqlConnection;
                comm.CommandText = "Insert into MT_Inventura (DatumInventure, IDSKladiste, IDGodina, TS) values (@DatumInventure, @IDSKladiste, @IDGodina, @TS) Select @@Identity";
                comm.Parameters.AddWithValue("@DatumInventure", Inventura.datumInventure);
                comm.Parameters.AddWithValue("@IDSkladiste", obj.idSkladiste);
                comm.Parameters.AddWithValue("@IDGodina", obj.idGodina);
                comm.Parameters.AddWithValue("@TS", DateTime.Now);

                int idInventura = 0;
                try
                {
                    idInventura = Convert.ToInt32(comm.ExecuteScalar());

                    x = true;
                }
                catch { }


                //onda i upis stavki
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int idSkladiste = Convert.ToInt32(dt.Rows[i]["ID_Skladiste"]);
                    int idProizvod = Convert.ToInt32(dt.Rows[i]["IDProizvod"]);
                    decimal stanje = Convert.ToDecimal(dt.Rows[i]["Stanje"]);

                    decimal cijena = 0;
                    if (dt.Rows[i]["CijenaPDV"].ToString().Equals(""))
                    {
                        cijena = 0;
                    }
                    else
                    {
                        cijena = Convert.ToDecimal(dt.Rows[i]["CijenaPDV"]);
                        cijena = Math.Round(cijena, 2);
                    }

     
                    SqlCommand commm = new SqlCommand();
                    commm.Connection = client.sqlConnection;
                    commm.CommandText = ("INSERT INTO MT_InventuraStavka ([ID_Inventura],[ID_Proizvod],[CijenaPDV],[KolicinaZaliha],[StvarnaKolicina]) VALUES (@idInventura, @idProizvod, @Cijena, @stanje, @nula) ");
                    commm.Parameters.AddWithValue("@idInventura", idInventura);
                    commm.Parameters.AddWithValue("@idProizvod", idProizvod);
                    commm.Parameters.AddWithValue("@Cijena", cijena == 0? DBNull.Value:(object)cijena);
                    commm.Parameters.AddWithValue("@stanje", stanje);
                    commm.Parameters.AddWithValue("@nula", DBNull.Value);
                   
                    commm.ExecuteNonQuery();
                }
            }
            catch
            {
                conn.Close();
            }

            return x;
        }

        private bool InsertStavke(StringBuilder message, SqlCommand sqlUpit, int id, DateTime datumNastajanja)
        {
            bool xyz = false;
            if (BusinessLogic.Inventura.pInventuraStavke.Rows.Count > 0)
            {
                sqlUpit.Parameters.Clear();

                sqlUpit.Parameters.Add(new SqlParameter("@ID_Inventura", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@ID_Proizvod", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@KolicinaZaliha", ""));
                sqlUpit.Parameters.Add(new SqlParameter("@StvarnaKolicina", ""));

                InventuraStavke stavka;

                foreach (DataRow dr in BusinessLogic.Inventura.pInventuraStavke.Rows)
                {
                    stavka = new InventuraStavke
                    {
                        IDInventure = id,
                        IDProizvod = Convert.ToInt32(dr["ID_Proizvod"]),
                        KolicinaZaliha = Convert.ToDecimal(dr["KolicinaZaliha"]),
                        StvarnaKolicina = Convert.ToDecimal(dr["StvarnaKolicina"])
                    };


                    //int id;
                    //SqlCommand sqlUpit = new SqlCommand();
                    //sqlUpit.Connection = client.sqlConnection;
                    //sqlUpit.CommandType = CommandType.Text;

                    sqlUpit.CommandText = "INSERT INTO MT_InventuraStavka (ID_Inventura, ID_Proizvod, KolicinaZaliha, StvarnaKolicina) VALUES (@ID_Inventura, @ID_Proizvod, @KolicinaZaliha,  @StvarnaKolicina) Select @@Identity";


                    sqlUpit.Parameters["@ID_Inventura"].Value = id;
                    sqlUpit.Parameters["@ID_Proizvod"].Value = stavka.IDProizvod;
                    sqlUpit.Parameters["@KolicinaZaliha"].Value = stavka.KolicinaZaliha;
                    sqlUpit.Parameters["@StvarnaKolicina"].Value = stavka.StvarnaKolicina;

                    try
                    {
                        sqlUpit.ExecuteNonQuery();
                        xyz = true;
                    }
                    catch (SqlException greska)
                    {
                        message.Append(greska.Message);
                        return xyz;
                    }
                    catch (Exception greska)
                    {
                        message.Append(greska.Message);
                        return xyz;
                    }
                }
            }

            return xyz;
        }

        /// <summary>
        /// Update inventure
        /// </summary>
        /// <param name="message"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(StringBuilder message, Inventura obj)
        {
            bool xyz = false;

            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@DatumInventure", Inventura.datumInventure));
            sqlUpit.Parameters.Add(new SqlParameter("@IDGodina", obj.idGodina));
            sqlUpit.Parameters.Add(new SqlParameter("@IDSKladiste", obj.idSkladiste));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

            sqlUpit.CommandText = "UPDATE [dbo].[MT_Inventura] SET DatumInventure = @DatumInventure,IDSKladiste = @IDSKladiste,IDGodina = @IDGodina,TS = @TS WHERE ID = @ID";

            try
            {
                sqlUpit.ExecuteNonQuery();
                xyz = true;
            }
            catch (SqlException greska)
            {
                message.Append(greska.Message);
                return xyz;
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                return xyz;
            }

            return xyz;
        }

        /// <summary>
        /// Update stavki
        /// </summary>
        /// <param name="stav"></param>
        /// <param name="sqlUpit"></param>
        /// <param name="datumNastajanja"></param>
        public void UpdateStavke(int idInventure, DataTable stavkeZaSpremiti)
        {
            SqlConnection conn = new SqlConnection();
            conn = client.sqlConnection;

            ////prvo obrisati sve stavke za tu inventuru             
            SqlCommand com = new SqlCommand();
            com.Connection = conn;
            com.CommandType = CommandType.Text;

            com.CommandText = ("Delete from MT_InventuraStavka where ID_Inventura = '" + idInventure + "'");

            if (client.sqlConnection.State == ConnectionState.Closed) conn.Open();

            try
            {
                com.ExecuteNonQuery();
            }
            catch (SqlException greska)
            {
            }
            catch (Exception greska)
            {
            }
           
            var stanje = (Object)null;
            //onda i upis stavki
            for (int i = 0; i < stavkeZaSpremiti.Rows.Count; i++)
            {             
                int idProizvod = Convert.ToInt32(stavkeZaSpremiti.Rows[i]["IDProizvod"]);
                decimal kolicinaZaliha = Convert.ToDecimal(stavkeZaSpremiti.Rows[i]["KolicinaZaliha"]);
                
                if (stavkeZaSpremiti.Rows[i]["StvarnaKolicina"] != DBNull.Value)
                {
                    stanje = Convert.ToDecimal(stavkeZaSpremiti.Rows[i]["StvarnaKolicina"]);
                }
                else
                {
                    stanje = (object)DBNull.Value;
                }                            

                SqlCommand commm = new SqlCommand();
                commm.Connection = client.sqlConnection;
                commm.CommandText = ("INSERT INTO MT_InventuraStavka ([ID_Inventura],[ID_Proizvod],[KolicinaZaliha],[StvarnaKolicina]) VALUES (@idInventura, @idProizvod, @stanje, @stvarno) ");
                commm.Parameters.AddWithValue("@idInventura", idInventure);
                commm.Parameters.AddWithValue("@idProizvod", idProizvod);
                commm.Parameters.AddWithValue("@stanje", kolicinaZaliha);
                commm.Parameters.AddWithValue("@stvarno", stanje);
              
                commm.ExecuteNonQuery();
            }
        }
       

        #endregion

        internal DataTable DohvatiInventuruManjak(int idInventure, DateTime datum)
        {               
            SqlConnection conn = new SqlConnection();
            conn = client.sqlConnection;
                                 
            SqlCommand com = new SqlCommand("spInventuraManjak");
            com.Connection = conn;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@IdInventure", idInventure);
            com.Parameters.AddWithValue("@datum", datum);   
       
             DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(com);

            if (client.sqlConnection.State == ConnectionState.Closed) conn.Open();

            try
            {
                da.Fill(dt);
            }
            catch (SqlException greska)
            {
            }
            catch (Exception greska)
            {
            }
           
            return dt;
        }

        internal DataTable DohvatiInventuruVishak(int idInventure, DateTime datum)
        {
            SqlConnection conn = new SqlConnection();
            conn = client.sqlConnection;
      
            SqlCommand com = new SqlCommand("spInventuraVishak");
            com.Connection = conn;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@IdInventure", idInventure);
            com.Parameters.AddWithValue("@datum", datum);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(com);

            if (client.sqlConnection.State == ConnectionState.Closed) conn.Open();

            try
            {
                da.Fill(dt);
            }
            catch (SqlException greska)
            {
            }
            catch (Exception greska)
            {
            }

            return dt;
        }

        internal object[] GetStavka(int skladiste)
        {
            return client.ConvertDataTableToArrayList(client.GetDataTable("Select Distinct PROIZVOD.IDPROIZVOD As ID, PROIZVOD.NAZIVPROIZVOD, (CAST(PROIZVOD.IDPROIZVOD As nvarchar) + ' | ' + PROIZVOD.NAZIVPROIZVOD) As Naziv From MT_SkladisteStavke " +
            "Left Join MT_PrimkaStavke On MT_SkladisteStavke.ID_PrimkaStavke = MT_PrimkaStavke.ID " +
            "Left Join MT_MeduskladisnicaStavka On MT_SkladisteStavke.ID_MeduskladisnicaStavke = MT_MeduskladisnicaStavka.ID " +
            "Inner Join PROIZVOD On MT_PrimkaStavke.ID_Proizvoda = PROIZVOD.IDPROIZVOD Or MT_MeduskladisnicaStavka.ID_Proizvoda = PROIZVOD.IDPROIZVOD " +
            "Where MT_SkladisteStavke.ID_Skladista = " + skladiste + " Order by PROIZVOD.NAZIVPROIZVOD asc")).ToArray();
        }

        internal DataRow GetStanjeSkladiste(int stavka, int skladiste, DateTime datum)
        {
            string datumDo = datum.ToString("yyyy-MM-dd");
            DataTable tbl = client.GetDataTable("Select Top 1 Stanje, CAST(0 AS Decimal(16, 4)) AS Cijena From MT_SkladisteStavke " +
                                                "Where TS <= '" + datumDo + "' And ID_Proizvod = " + stavka + " And ID_Skladista = " + skladiste + " Order by TS desc, RedniBrojDan desc");

            //db - 02.02.2017
            //tbl.Rows[0]["Cijena"] = CalculateAveragePrice(stavka, skladiste, datumDo);

            return tbl.Rows[0];
        }

        private object CalculateAveragePrice(int stavka, int skladiste, string datum)
        {
            return client.ExecuteScalar("Select Top 1 Abs(Round((MT_SkladisteStavke.Saldo / MT_SkladisteStavke.Stanje), 4)) From MT_SkladisteStavke " +
                   "Where MT_SkladisteStavke.ID_Skladista = " + skladiste + " And MT_SkladisteStavke.ID_Proizvod = " + stavka + " And MT_SkladisteStavke.TS <= '" + datum +
                   "' And Stanje <> 0 Order by TS desc, RedniBrojDan desc");
        }

        /// <summary>
        /// Dohvaća inventuru
        /// </summary>
        /// <returns></returns>
        public DataRow GetSelectedInventura()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            sqlUpit.CommandText = "select inv.ID, inv.DatumInventure, sklad.Naziv, inv.IDSKladiste, inv.IDGodina " +
                                  "from MT_Inventura inv left join MT_Skladista sklad on sklad.ID = inv.IDSkladiste " +
                                  "where inv.ID = @ID";          

            return client.GetDataTable(sqlUpit).Rows[0];
        }

        /// <summary>
        /// Dohvaća stavke po ID-u inventure
        /// </summary>
        /// <returns></returns>
        public DataTable GetPostojeceStavke()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            sqlUpit.CommandText = "select 'false' as SEL, stav.ID_Inventura, stav.ID_Proizvod,	pro.NAZIVPROIZVOD As StavkaSkladista, stav.KolicinaZaliha, stav.StvarnaKolicina " +
                                       "from MT_InventuraStavka stav inner join PROIZVOD pro on pro.IDPROIZVOD = stav.ID_Proizvod " +
                                       "where stav.ID_Inventura = @ID " +
                                       "order by pro.NAZIVPROIZVOD asc"; //db - 03.02.2017 sortiranje po NAZIVU asc

            return client.GetDataTable(sqlUpit);
        }

        /// <summary>
        /// Dohvaća pojedinu stavku
        /// </summary>
        /// <returns></returns>
        internal DataRow GetPostojecuStavku()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pIDStavke));

            sqlUpit.CommandText = "select 'false' as SEL, stav.ID_Inventura, stav.ID_Proizvod,	pro.NAZIVPROIZVOD As StavkaSkladista, stav.KolicinaZaliha, stav.StvarnaKolicina" +
                                       "from MT_InventuraStavka stav inner join PROIZVOD pro on pro.IDPROIZVOD = stav.ID_Proizvod" +
                                       "where stav.ID = @ID" +
                                       "order by stav.ID";

            return client.GetDataTable(sqlUpit).Rows[0];
        }

        public DataTable GetSkladiste()
        {
            return client.GetDataTable("Select ID, Naziv From MT_Skladista Order by Naziv");
        }

        internal object[] GetMjestoTroska()
        {
            return client.ConvertDataTableToArrayList(client.GetDataTable("Select IDMJESTOTROSKA As ID, (CAST(IDMJESTOTROSKA As nvarchar) + ' | ' + NAZIVMJESTOTROSKA) AS Naziv From MJESTOTROSKA Order by NAZIVMJESTOTROSKA")).ToArray();
        }

        internal object[] GetDokument1()
        {
            return client.ConvertDataTableToArrayList(client.GetDataTable("Select IDDOKUMENT As ID, (CAST(IDDOKUMENT As nvarchar) + ' | ' + NAZIVDOKUMENT) AS Naziv From DOKUMENT Order by NAZIVDOKUMENT")).ToArray();
        }

        internal object GetNextSifra()
        {
            try
            {
                var broj = client.ExecuteScalar("Select Max(Cast(Sifra As int)) + 1 From MT_Inventura");
                if (broj.ToString().Length > 0)
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

        internal DataTable GetInventuraIspis()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "SELECT [DatumInventure],[Naziv],[NAZIVPROIZVOD],[KolicinaZaliha],[StvarnaKolicina] FROM [v_Izdatnica] Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            return client.GetDataTable(sqlUpit);
        }

        //db - 10.11.2016
        internal DataTable GetInventuraIspisOznaceni(Dictionary<int, int> oznaceni)
        {
            string where = string.Empty;
            int counter = 0;
            foreach (KeyValuePair<int, int> row in oznaceni)
            {
                counter++;

                if (counter < oznaceni.Count && oznaceni.Count > 1)
                {
                    where += "(ID = " + row.Key + " And Sifra = " + row.Value.ToString() + ") OR";
                }
                else
                {
                    where += "(ID = " + row.Key + " And Sifra = " + row.Value.ToString() + ") ";
                }

            }

            DataTable racuni = client.GetDataTable("Select * From v_Inventura Where " + where);

            return racuni;
        }
        
    }



}