using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mipsed7.DataAccessLayer.EntityFramework;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace JavnaNabava.BusinessLogic
{
    public class Narudzbenica : Base
    {
        SqlClient client = null;
        public Narudzbenica()
            : base()
        {
            client = new SqlClient();
        }

        #region Svojstva

        public static int pSelectedIndex
        {
            get;
            set;
        }

        public static int? pID_Narudzbenica { get; set; }

        public static int? pID_Partner { get; set; }

        public static string pBrojNarudzbe { get; set; }

        public static string pNapomena { get; set; }

        public static DateTime? pDatumNarudzbe { get; set; }

        public static int? pNacinPlacanja { get; set; }

        public static int? pNacinIsporuke { get; set; }

        public static int? pID_Proizvod { get; set; }

        public static DataTable pNarudzbeProizvod { get; set; }

        public static List<string> pOdabraniProizvodi { get; set; }

        public static string pNazivProizvod { get; set; }

        public static decimal? pKolicinaProizvod { get; set; }

        public static int? pID_JedinicaMjere { get; set; }

        public static string  pJedinicaMjere { get; set; }

        #endregion

        #region DohvatPodataka

        public bool NarudzbenicaByID()
        {
            DataTable dt1 = client.GetDataTable("Select ID_Partner, BrojNarudzbe, Napomena, DatumNarudzbe From JN_Narudzbenica Where ID = '" + pID_Narudzbenica + "'");

            DataRow red = dt1.Rows[0];

            try
            {
                pID_Partner = (int)red["ID_Partner"];
                pBrojNarudzbe = red["BrojNarudzbe"].ToString();
                pNapomena = red["Napomena"].ToString();
                pDatumNarudzbe = Convert.ToDateTime(red["DatumNarudzbe"]);
            }
            catch
            {
                return false;
            }

            DataTable dt2 = client.GetDataTable("Select 'False' As 'SEL', ID_Proizvod As 'ID Proizvod', NAZIVPROIZVOD As 'Naziv proizvoda', NAZIVJEDINICAMJERE As 'Jedinica mjere', " + 
                                                "Kolicina As 'Količina', ID_JedinicaMjere From JN_NarudzbenicaProizvod " + 
                                                "Inner Join PROIZVOD On JN_NarudzbenicaProizvod.ID_Proizvod = PROIZVOD.IDPROIZVOD " + 
                                                "Inner Join JEDINICAMJERE On JN_NarudzbenicaProizvod.ID_JedinicaMjere = JEDINICAMJERE.IDJEDINICAMJERE " + 
                                                "Where ID_Narudzbenica =  '" + pID_Narudzbenica + "'");
            pNarudzbeProizvod = dt2;

            return true;
        }

        public DataSet GetDataMainGrid()
        {
            DataSet ds = new DataSet();

            DataTable dt_primary = client.GetDataTable("Select BrojNarudzbe As 'Broj narudžbe', Napomena, NAZIVPARTNER As 'Naziv partnera', PARTNERULICA As 'Partner adresa', " + 
                                    "PARTNERMJESTO As 'Partner mjesto', ID From JN_Narudzbenica Inner Join Partner On JN_Narudzbenica.ID_Partner = Partner.IDPARTNER");

            DataTable dt_related1 = client.GetDataTable("Select NAZIVPROIZVOD As 'Naziv proizvoda', Kolicina As 'Količina', FINPOREZNAZIVPOREZ As 'Porez proizvod', " + 
                                    "NAZIVJEDINICAMJERE As 'Mjerna jedinica', ID_Narudzbenica From JN_NarudzbenicaProizvod " +
                                    "Inner Join Proizvod On JN_NarudzbenicaProizvod.ID_Proizvod = Proizvod.IDPROIZVOD " +
                                    "Inner Join FINPOREZ On Proizvod.FINPOREZIDPOREZ = FINPOREZ.FINPOREZIDPOREZ " +
                                    "Inner JOin JEDINICAMJERE On Proizvod.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE");

            ds.Tables.Add(dt_primary);
            ds.Tables.Add(dt_related1);

            DataRelation relation1 = new DataRelation("Narudzbenica", dt_primary.Columns["ID"], dt_related1.Columns["ID_Narudzbenica"]);

            ds.Relations.Add(relation1);

            return ds;
        }

        public object GetProizvod()
        {
            DataTable tbl = new DataTable();

            SqlCommand command;
            if (pOdabraniProizvodi.Count > 0)
            {
                command = new SqlCommand("Select IDPROIZVOD As ID, NAZIVPROIZVOD As Naziv From PROIZVOD " +
                                     "Where IDPROIZVOD NOT IN (" + String.Join(",", pOdabraniProizvodi) + ")", client.sqlConnection);
            }
            else
            {
                command = new SqlCommand("Select IDPROIZVOD As ID, NAZIVPROIZVOD As Naziv From PROIZVOD", client.sqlConnection);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(tbl);

            return tbl;
        }

        public string GetJedinicaMjere()
        {
            string jedinica_mjere = string.Empty;

            SqlCommand command = new SqlCommand("Select IDJEDINICAMJERE From Proizvod Where IDPROIZVOD = @ID_Proizvod", client.sqlConnection);
            command.Parameters.Add(new SqlParameter("@ID_Proizvod", pID_Proizvod));

            pID_JedinicaMjere = (int)command.ExecuteScalar();

            command.CommandText = "Select NAZIVJEDINICAMJERE From JEDINICAMJERE Where IDJEDINICAMJERE = @ID_JedinicaMjere";
            command.Parameters.Add(new SqlParameter("@ID_JedinicaMjere", pID_JedinicaMjere));

            pJedinicaMjere =  command.ExecuteScalar().ToString();

            return pJedinicaMjere;
        }

        public object GetPartner()
        {
            //db - 03.02.2017 - sortirano po nazivu, ne ID-u
            return Database.PARTNER.OrderBy(order => order.NAZIVPARTNER)
                                   .Select(sel => new                                    { 
                                       ID = sel.IDPARTNER, 
                                       Naziv = sel.NAZIVPARTNER 
                                   });
        }

        public DataTable GetNacinPlacanja()
        {
            DataTable dt = client.GetDataTable("Select ID, Naziv From JN_NacinPlacanja");
            return dt;
        }

        public DataTable GetNacinIsporuke()
        {
            DataTable dt = client.GetDataTable("Select ID, Naziv From JN_NacinIsporuke");
            return dt;
        }

        public string GetBrojNarudzbe()
        {
            string broj_narudzbe = string.Empty;
            string fiskalna_godina = string.Empty;
            int broj = 0;

            SqlCommand command = new SqlCommand("SELECT MAX(SUBSTRING(BrojNarudzbe, CHARINDEX(BrojNarudzbe, '-'), LEN(BrojNarudzbe)-4)) " +
                "From JN_Narudzbenica Where RIGHT(BrojNarudzbe, 4) = YEAR(getdate()) ", client.sqlConnection);
            broj_narudzbe = command.ExecuteScalar().ToString();

            command.CommandText = "Select IDGODINE From GODINE Where GODINEAKTIVNA = 1";
            fiskalna_godina = command.ExecuteScalar().ToString();
            if (fiskalna_godina.Length < 4)
            {
                fiskalna_godina = DateTime.Now.Year.ToString();
            }

            if (broj_narudzbe.Length < 1)
            {
                broj_narudzbe = "0001-" + fiskalna_godina;
            }
            else
            {
                broj = Convert.ToInt32(broj_narudzbe) + 1;

                if (broj.ToString().Length == 1)
                {
                    broj_narudzbe = "000" + (broj).ToString() + "-" + fiskalna_godina;
                }
                else if (broj.ToString().Length == 2)
                {
                    broj_narudzbe = "00" + (broj).ToString() + "-" + fiskalna_godina;
                }
                else if (broj.ToString().Length == 3)
                {
                    broj_narudzbe = "0" + (broj).ToString() + "-" + fiskalna_godina;
                }
                else if (broj.ToString().Length == 4)
                {
                    broj_narudzbe = (broj).ToString() + "-" + fiskalna_godina;
                }
            }
            return broj_narudzbe;
        }

        public decimal? GetCijenaProizvod()
        {
            if(pID_Proizvod != null)
                return (decimal)client.ExecuteScalar("Select Cijena From Proizvod Where IDPROIZVOD = '" + pID_Proizvod + "'");
            
            return null;
        }
        
        #endregion

        #region RadSaPodacima

        public DataTable GetNarudzbenicaIspis(int? id)
        {
            DataTable dt = client.GetDataTable("Select * From v_JN_NarudzbeniceIspis Where ID = " + id + " Order by ProizvodSifra");
            return dt;
        }

        public bool Insert(StringBuilder message, UltraGrid ugdNarudzbeniceProizvod)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Narudzbenice");
            sqlUpit.Transaction = transakcija;

            sqlUpit.CommandText = "Insert Into JN_Narudzbenica (ID_Partner, BrojNarudzbe, Napomena, DatumNarudzbe, ID_NacinIsporuke, ID_NacinPlacanja, TS) " +
                                  "Values (@ID_Partner, @BrojNarudzbe, @Napomena, @DatumNarudzbe, @ID_NacinIsporuke, @ID_NacinPlacanja, @TS) Select @@Identity";

            if(pNapomena != null)
                sqlUpit.Parameters.Add(new SqlParameter("@Napomena", pNapomena));
            else
                sqlUpit.Parameters.Add(new SqlParameter("@Napomena", DBNull.Value));
            sqlUpit.Parameters.Add(new SqlParameter("@BrojNarudzbe", pBrojNarudzbe));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_Partner", pID_Partner));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));
            sqlUpit.Parameters.Add(new SqlParameter("@DatumNarudzbe", pDatumNarudzbe));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_NacinIsporuke", pNacinIsporuke));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_NacinPlacanja", pNacinPlacanja));

            try
            {
                pID_Narudzbenica = Convert.ToInt32(sqlUpit.ExecuteScalar());
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                transakcija.Rollback();
                return false;
            }

            try
            {
                foreach (UltraGridRow red in ugdNarudzbeniceProizvod.Rows)
                {
                    pID_Proizvod = (int)red.Cells["ID Proizvod"].Value;
                    pKolicinaProizvod = (decimal)red.Cells["Količina"].Value;
                    pID_JedinicaMjere = (int)red.Cells["ID_JedinicaMjere"].Value;

                    sqlUpit.CommandText = "Insert Into JN_NarudzbenicaProizvod (ID_Narudzbenica, ID_Proizvod, Kolicina, ID_JedinicaMjere) " +
                                          "Values ('" + pID_Narudzbenica + "', '" + pID_Proizvod + "', '" + pKolicinaProizvod.ToString().Replace(',', '.') + "', '" + pID_JedinicaMjere + "')";

                    sqlUpit.ExecuteNonQuery();
                }
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                transakcija.Rollback();
                return false;
            }

            transakcija.Commit();
            return true;
        }

        public bool Update(StringBuilder message, UltraGrid ugdNarudzbeniceProizvod)
        {
            string bez_poreza = string.Empty;
            string sa_porezom = string.Empty;
            string opis_stavka = string.Empty;
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Plan nabave");
            sqlUpit.Transaction = transakcija;

            sqlUpit.CommandText = "Update JN_Narudzbenica Set ID_Partner = @ID_Partner, Napomena = @Napomena, DatumNarudzbe = @DatumNarudzbe, " +
                                  "ID_NacinIsporuke = @ID_NacinIsporuke, ID_NacinPlacanja = @ID_NacinPlacanja, TS= @TS Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID_Partner", pID_Partner));
            sqlUpit.Parameters.Add(new SqlParameter("@Napomena", pNapomena));
            sqlUpit.Parameters.Add(new SqlParameter("@DatumNarudzbe", pDatumNarudzbe));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));
            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID_Narudzbenica));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_NacinIsporuke", pNacinIsporuke));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_NacinPlacanja", pNacinPlacanja));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                transakcija.Rollback();
                return false;
            }

            sqlUpit.CommandText = "Delete From JN_NarudzbenicaProizvod Where ID_Narudzbenica = @ID";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                transakcija.Rollback();
                return false;
            }

            try
            {
                foreach (UltraGridRow red in ugdNarudzbeniceProizvod.Rows)
                {
                    pID_Proizvod = (int)red.Cells["ID Proizvod"].Value;
                    pKolicinaProizvod = (decimal)red.Cells["Količina"].Value;
                    pID_JedinicaMjere = (int)red.Cells["ID_JedinicaMjere"].Value;

                    sqlUpit.CommandText = "Insert Into JN_NarudzbenicaProizvod (ID_Narudzbenica, ID_Proizvod, Kolicina, ID_JedinicaMjere) " +
                                          "Values ('" + pID_Narudzbenica + "', '" + pID_Proizvod + "', '" + pKolicinaProizvod.ToString().Replace(',','.') + "', '" + pID_JedinicaMjere + "')";

                    sqlUpit.ExecuteNonQuery();
                }

            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                transakcija.Rollback();
                return false;
            }

            transakcija.Commit();
            return true;
        }

        public bool Delete()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            bool kontrola = false;

            sqlUpit.CommandText = "Delete From JN_NarudzbenicaProizvod Where ID_Narudzbenica = @ID";
            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID_Narudzbenica));

            try
            {
                sqlUpit.ExecuteNonQuery();
                kontrola = true;
            }
            catch
            {
                kontrola = false;
            }

            sqlUpit.CommandText = "Delete From JN_Narudzbenica Where ID = @ID";

            try
            {
                sqlUpit.ExecuteNonQuery();
                kontrola = true;
            }
            catch
            {
                kontrola = false;
            }
            return kontrola;
        }

        /// <summary>
        /// If value is DBNull, then return "returnValue"
        /// </summary>
        /// <param name="value">Value to cast</param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public static T IsDbNull<T>(object value)
        {
            if (value != DBNull.Value && value != null)
            {
                // return (T)value; // CAST
                return (T)Convert.ChangeType(value, typeof(T)); // CONVERT
            }

            return default(T);
        }
        
        #endregion

    }
}
