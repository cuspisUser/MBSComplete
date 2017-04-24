using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Materijalno.BusinessLogic
{
    public class OtvaranjeSkladista : Base, IDisposable
    {
        SqlClient client = null;
        public OtvaranjeSkladista()
            : base()
        {
            client = new SqlClient();
        }

        public void Dispose()
        {
        }

        #region Properties

        public static int pID { get; set; }
        public string pSifra { get; set; }
        public string pNaziv { get; set; }
        public Nullable<int> pMjestoTroska { get; set; }
        public Nullable<int> pOrganizacijskaJedinica { get; set; }
        public Nullable<int> pTipSkladista { get; set; }
        public static int pSelectedIndex { get; set; }
        public bool pPorez { get; set; }

        #endregion

        #region Work with data

        public DataTable GetMainGridData()
        {
            return client.GetDataTable("Select ID, Sifra, Naziv, ID_MjestoTroska, ID_OrganizacijskaJedinica, ID_TipSkladista From MT_Skladista");
        }

        public DataRow GetSelectedRow()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Select ID, Sifra, Naziv, ID_MjestoTroska, ID_OrganizacijskaJedinica, ID_TipSkladista, Porez From MT_Skladista Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            return client.GetDataTable(sqlUpit).Rows[0];
        }

        public bool Delete(StringBuilder message)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete from MT_Skladista Where ID = @ID";

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

        public bool Insert(StringBuilder message, OtvaranjeSkladista objekt)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Insert Into MT_Skladista (Sifra, Naziv, ID_MjestoTroska, ID_OrganizacijskaJedinica, ID_TipSkladista, TS, Porez) " +
                                  "Values (@Sifra, @Naziv, @ID_MjestoTroska, @ID_OrganizacijskaJedinica, @ID_TipSkladista, @TS, @Porez)";

            if (objekt.pSifra == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Sifra", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Sifra", objekt.pSifra));
            }
            sqlUpit.Parameters.Add(new SqlParameter("@Naziv", objekt.pNaziv));
            if (objekt.pMjestoTroska == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_MjestoTroska", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_MjestoTroska", objekt.pMjestoTroska));
            }
            if (objekt.pOrganizacijskaJedinica == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_OrganizacijskaJedinica", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_OrganizacijskaJedinica", objekt.pOrganizacijskaJedinica));
            }
            if (objekt.pTipSkladista == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_TipSkladista", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_TipSkladista", objekt.pTipSkladista));
            }
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

            sqlUpit.Parameters.Add(new SqlParameter("@Porez", objekt.pPorez));

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

        public bool Update(StringBuilder message, OtvaranjeSkladista objekt)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Update MT_Skladista Set Sifra = @Sifra, Naziv = @Naziv, ID_MjestoTroska = @ID_MjestoTroska, ID_OrganizacijskaJedinica =@ID_OrganizacijskaJedinica, " +
                                  "ID_TipSkladista = @ID_TipSkladista, TS = @TS, Porez = @Porez Where ID = @ID";

            if (objekt.pSifra == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Sifra", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@Sifra", objekt.pSifra));
            }
            sqlUpit.Parameters.Add(new SqlParameter("@Naziv", objekt.pNaziv));
            if (objekt.pMjestoTroska == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_MjestoTroska", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_MjestoTroska", objekt.pMjestoTroska));
            }
            if (objekt.pOrganizacijskaJedinica == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_OrganizacijskaJedinica", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_OrganizacijskaJedinica", objekt.pOrganizacijskaJedinica));
            }
            if (objekt.pTipSkladista == null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_TipSkladista", DBNull.Value));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@ID_TipSkladista", objekt.pTipSkladista));
            }
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));
            sqlUpit.Parameters.Add(new SqlParameter("@Porez", objekt.pPorez));
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
                return (T)Convert.ChangeType(value, typeof(T));
            }

            return null;
        }

        public DataTable GetOrganizacijskaJedinica()
        {
            return client.GetDataTable("Select IDORGJED As ID, NAZIVORGJED As Naziv From ORGJED");
        }

        public DataTable GetMjestoTroska()
        {
            return client.GetDataTable("Select IDMJESTOTROSKA As ID, NAZIVMJESTOTROSKA As Naziv From MJESTOTROSKA");
        }

        public DataTable GetTipSkladista()
        {
            return client.GetDataTable("Select ID, Naziv From MT_TipSkladista");
        }

        internal DataTable GetSkladista()
        {
            return client.GetDataTable("Select Distinct ID_Skladista As ID, MT_Skladista.Naziv From MT_SkladisteStavke " +
                                       "Inner Join MT_Skladista On MT_SkladisteStavke.ID_Skladista = MT_Skladista.ID");
        }

        internal DataTable GetStanjeSkladistaIspis(int skladiste, int sort, DateTime datum)
        {
            string order = "";
            //if (sort == 0)
            //{
            //    order = " Order by Sifra";
            //}
            //else if (sort == 1)
            //{
            //    order = " Order by Proizvod";
            //}
            //else if (sort == 2)
            //{
            //    order = " Order by Kolicina";
            //}

            if (sort == 0)
            {
                order = "PROIZVOD.IDPROIZVOD";
            }
            else if (sort == 1)
            {
                order = "PROIZVOD.NAZIVPROIZVOD";
            }
            else if (sort == 2)
            {
                order = "KolicinaX asc";
            }

            //db - 16.1.2017
            //string dat = datum.ToString("yyyy-MM-dd");
            DataTable tbl = GetStanjeSkladista(skladiste, order, datum);


            foreach (DataRow red in tbl.Rows)
            {
                if (Convert.ToDecimal(red["KolicinaX"]) == 0)
                {
                    red["BasePrice"] = Math.Round(Convert.ToDecimal(red["Saldo"]), 4);
                }
                else
                {
                    red["BasePrice"] = Math.Abs(Math.Round(Convert.ToDecimal(red["Saldo"]) / Convert.ToDecimal(red["KolicinaX"]), 4));
                }
            }

            return tbl;
        }

        /// <summary>
        /// db - 16.1.7017 - Metoda je kreirana radi inventurne liste
        /// </summary>
        /// <param name="skladiste"></param>
        /// <param name="sort"></param>
        /// <param name="datum"></param>
        /// <param name="prikazatiKolicine"></param>
        /// <returns></returns>
        internal DataTable GetStanjeSkladistaZaInventurniList(int skladiste, int sort, DateTime datum, bool prikazatiKolicine)
        {
            string order = "";
           
            if (sort == 0)
            {
                order = "PROIZVOD.IDPROIZVOD";
            }
            else if (sort == 1)
            {
                order = "PROIZVOD.NAZIVPROIZVOD";
            }
            else if (sort == 2)
            {
                order = "KolicinaX asc";
            }

            //db - 16.1.2017
            //string dat = datum.ToString("yyyy-MM-dd");
            DataTable tbl = GetStanjeSkladistaInventurniListIspis(skladiste, order, datum, prikazatiKolicine);
            
            foreach (DataRow red in tbl.Rows)
            {
                if (red["KolicinaX"] != "")// //db - 16.1.2017
                {
                    if (Convert.ToDecimal(red["KolicinaX"]) == 0)
                    {
                        red["BasePrice"] = Math.Round(Convert.ToDecimal(red["Saldo"]), 4);
                    }
                    else
                    {
                        red["BasePrice"] = Math.Abs(Math.Round(Convert.ToDecimal(red["Saldo"]) / Convert.ToDecimal(red["KolicinaX"]), 4));
                    }
                }
                else
                {
                    red["BasePrice"] = Math.Round(Convert.ToDecimal(red["Saldo"]), 4);
                }
            }

            return tbl;
        }

        /// <summary>
        /// db - 16.1.7017 - Metoda je kreirana radi inventurne liste
        /// </summary>
        internal DataTable GetStanjeSkladistaInventurniListIspis(int skladiste, string sort, DateTime datum, bool prikazatiKolicine)
        {
            DataTable dt = new DataTable();
            SqlCommand sqlComm;

            //ukoliko je na formi odabrana Primka
            sqlComm = new SqlCommand("spInventurnaLista", client.sqlConnection);
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@idSkladista", skladiste);
            sqlComm.Parameters.AddWithValue("@datum", datum);
            //db - 11.01.2017
            if (sort == "")
            {
                sort = "PROIZVOD.NAZIVPROIZVOD";
            }
            sqlComm.Parameters.AddWithValue("@order", sort);
            sqlComm.Parameters.AddWithValue("@PrikazKolicina", prikazatiKolicine);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(dt);

            return dt;
        }


        //db - 26.10.2016
        internal DataTable GetStanjeSkladistaGrupe(int idSkladiste)
        {
            DataTable dt = new DataTable();
            SqlCommand sqlComm;

            //ukoliko je na formi odabrana Primka
            sqlComm = new SqlCommand("spStanjeSkladistaGrupe", client.sqlConnection);
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@idSkladista", idSkladiste);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(dt);

            return dt;
        }

        internal DataTable GetStanjeSkladista(int skladiste, string sort, DateTime datum)
        {
            DataTable dt = new DataTable();
            SqlCommand sqlComm;

            //ukoliko je na formi odabrana Primka
            sqlComm = new SqlCommand("spStanjeSkladista", client.sqlConnection);
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@idSkladista", skladiste);
            sqlComm.Parameters.AddWithValue("@datum", datum);
            //db - 11.01.2017
            if (sort == "")
            {
                sort = "PROIZVOD.NAZIVPROIZVOD";
            }
            sqlComm.Parameters.AddWithValue("@order", sort);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(dt);

            return dt;
        }


        internal DataTable GetPrimkeDobavljac(int dobavljac, string dateOD, string dateDo)
        {
            return client.GetDataTable("Select * From vPrimkaDobavljac Where Cast(Datum As date) Between '" + dateOD + "' And '" + dateDo +
                                       "' And ID_Partnera = " + dobavljac + " Order by Datum, Vrsta desc, Sifra");
        }


        #endregion

        internal object GetMainGridDataSkladista(int? id)
        {
            if (id != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                string datDO = DateTime.Now.ToString("yyyy-MM-dd");
                DataTable tbl = client.GetDataTable("Select Distinct main.ID_Skladista As ID_Skladiste, MT_Skladista.Naziv As Skladiste, PROIZVOD.IDPROIZVOD As Sifra, PROIZVOD.NAZIVPROIZVOD As Proizvod, " +
                "(Select Top 1 Stanje From MT_SkladisteStavke Where TS <= '" + datDO + "' And ID_Proizvod = main.ID_Proizvod And ID_Skladista = " + (int)id + " Order by TS desc, RedniBrojDan desc) As Kolicina, " +
                "JEDINICAMJERE.NAZIVJEDINICAMJERE, JEDINICAMJERE.IDJEDINICAMJERE, CAST(0 AS Decimal(18, 4)) AS BasePrice, " +
                "(Select Top 1 Saldo From MT_SkladisteStavke Where TS <= '" + datDO + "' And ID_Proizvod = main.ID_Proizvod And ID_Skladista = " + (int)id + " Order by TS desc, RedniBrojDan desc) As Saldo " +
                "From MT_SkladisteStavke As main Inner Join MT_Skladista On main.ID_Skladista = MT_Skladista.ID Inner Join PROIZVOD On main.ID_Proizvod = PROIZVOD.IDPROIZVOD " +
                "Inner join JEDINICAMJERE On PROIZVOD.IDJEDINICAMJERE = JEDINICAMJERE.IDJEDINICAMJERE Where main.TS <= '" + datDO + "' And main.ID_Skladista = " + (int)id + " Order by Proizvod, Sifra");

                foreach (DataRow red in tbl.Rows)
                {
                    if (Convert.ToDecimal(red["Kolicina"]) == 0)
                    {
                        red["BasePrice"] = Math.Round(Convert.ToDecimal(red["Saldo"]), 4);
                    }
                    else
                    {
                        red["BasePrice"] = Math.Abs(Math.Round(Convert.ToDecimal(red["Saldo"]) / Convert.ToDecimal(red["Kolicina"]), 4));
                    }
                }

                Cursor.Current = Cursors.Default;

                return tbl;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Dohvat iz View-a
        /// db - 17.10.2016 - dodani parametri id za skladište i mjesto troška plus dorada filtera koji se šalju u bazu
        /// </summary>
        /// <param name="datumOd"></param>
        /// <param name="datumDo"></param>
        /// <returns></returns>
        internal DataTable GetStanjeDokumenti(DateTime datumOd, DateTime datumDo, Nullable<int> idSkladista, int idMjestoTroska, string dokument)
        {
            string prviDio = "";
            string skladiste = "";
            string mjestoTroska = "";
            string zadnjiDio = "";

            prviDio = "Select * From vStanjeDokumenti v Where Cast(Datum As date) Between '" + datumOd.ToString("yyyy-MM-dd") + "' And '" + datumDo.ToString("yyyy-MM-dd") + "' ";

            if (idSkladista > 0)
            {
                skladiste = " And v.ID_Skladista = '" + idSkladista + "' ";
            }
            else
            {
                skladiste = "";
            }

            if (idMjestoTroska > 0)
            {
                mjestoTroska = " And v.ID_MjestoTroska = '" + idMjestoTroska + "' "; //db - 16.1.2017 korekcija iz v.IDMjestoTroska u v.ID_MjestoTroska
            }
            else
            {
                mjestoTroska = "";
            }

            string dokkumentt = "";
            if (dokument.Equals("Primka"))
            {
                dokkumentt = " and Vrsta = 'Primka' ";
            }
            else if (dokument.Equals("Izdatnica"))
            {
                dokkumentt = " and Vrsta = 'Izdatnica' ";
            }

            zadnjiDio = "Order by Datum, Vrsta desc, Sifra";



            DataTable dt = new DataTable();

            string cijeliSearch = prviDio + skladiste + mjestoTroska + dokkumentt + zadnjiDio;

            dt = client.GetDataTable(cijeliSearch);

            return dt;
        }

        /// <summary>
        /// Dohvat iz procedure
        /// db - 20.10.2016 - dodani parametri id za skladište i mjesto troška plus dorada filtera koji se šalju u bazu
        /// </summary>
        /// <param name="datumOd"></param>
        /// <param name="datumDo"></param>
        /// <returns></returns>
        internal DataTable GetSaldoKartice(DateTime datumOd, DateTime datumDo, Nullable<int> idSkladista, object proizvod)
        {
            DataTable dt = new DataTable();
            SqlCommand sqlComm;

            //ukoliko je na formi odabrana Primka
            sqlComm = new SqlCommand("spUlazIzlazSaldoKartica", client.sqlConnection);
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@DatumOd", datumOd);
            sqlComm.Parameters.AddWithValue("@DatumDo", datumDo);

            //skladište
            if (idSkladista > 0)
            {
                sqlComm.Parameters.AddWithValue("@Skladiste", idSkladista);
            }
            else
            {
                sqlComm.Parameters.AddWithValue("@Skladiste", DBNull.Value);
            }

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(dt);

            return dt;
        }

        /// <summary>
        /// Dohvat iz procedure
        /// db - 25.10.2016 - puni subreport crpSaldoGrupe.rpt (materijalno)
        /// </summary>
        /// <param name="datumOd"></param>
        /// <param name="datumDo"></param>
        /// <returns></returns>
        internal DataTable GetSaldoGrupe(DateTime datumOd, DateTime datumDo, Nullable<int> idSkladista)
        {
            DataTable dt = new DataTable();
            SqlCommand sqlComm;

            //ukoliko je na formi odabrana Primka
            sqlComm = new SqlCommand("spUlazIzlazSaldoGrupe", client.sqlConnection);
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@DatummOD1", datumOd);
            sqlComm.Parameters.AddWithValue("@DatummDO2", datumDo);

            //skladište
            if (idSkladista > 0)
            {
                sqlComm.Parameters.AddWithValue("@Skladistee3", idSkladista);
            }
            else
            {
                sqlComm.Parameters.AddWithValue("@Skladistee3", DBNull.Value);
            }

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(dt);

            return dt;
        }

        /// <summary>
        /// db - 21.10.2016
        /// Funkcija dohvaća proizvode koji su (bili) dostupni u odabranom skladištu u željenom periodu (ili na odr. datum)
        /// </summary>
        internal DataTable GetProizvodiSaldoKartice(DateTime datumOd, DateTime datumDo, int idSkladista)
        {
            DataTable dt = new DataTable();
            SqlCommand sqlComm;
            SqlClient sql = new SqlClient();

            //ukoliko je na formi odabrana Primka
            sqlComm = new SqlCommand("sp_DohvatiProizvodeZaSaldoKartice", sql.sqlConnection);
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@datumOd", datumOd);
            sqlComm.Parameters.AddWithValue("@datumDo", datumDo);
            sqlComm.Parameters.AddWithValue("@idSkladista", idSkladista);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(dt);

            return dt;
        }


        internal DataSet GetUlazIzlazGrupe(DateTime datumOd, DateTime datumDo, Nullable<int> skladiste, int vrsta)
        {
            DataSet ds = new DataSet("UlazIzlaz");
            SqlCommand sqlComm;
            if (vrsta == 1)
            {
                //ukoliko je na formi odabrana Primka
                sqlComm = new SqlCommand("spUlazIzlazGrupaPrimka", client.sqlConnection);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@datumOd", datumOd);
                sqlComm.Parameters.AddWithValue("@datumDo", datumDo);
            }
            else
            {
                //ukoliko je na formi odabrana Izdatnica
                sqlComm = new SqlCommand("spUlazIzlazGrupaIzdatnica", client.sqlConnection);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@datumOd", datumOd);
                sqlComm.Parameters.AddWithValue("@datumDo", datumDo);
            }

            if (skladiste != null)
            {
                sqlComm.Parameters.AddWithValue("@skladiste", skladiste);
            }
            else
            {
                sqlComm.Parameters.AddWithValue("@skladiste", DBNull.Value);
            }

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(ds);

            return ds;
        }

        internal DataTable GetMjestoTroska(DateTime datumOd, DateTime datumDo, Nullable<int> skladiste, int mjestoTroska)
        {
            DataTable tbl = new DataTable();
            SqlCommand sqlComm;

            sqlComm = new SqlCommand("spMjestoTroskaIspis", client.sqlConnection);
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@datumOd", datumOd.ToString("yyyy-MM-dd"));
            sqlComm.Parameters.AddWithValue("@dateumDo", datumDo.ToString("yyyy-MM-dd"));
            sqlComm.Parameters.AddWithValue("@mjestoTroska", mjestoTroska);

            if (skladiste != null)
            {
                sqlComm.Parameters.AddWithValue("@skladiste", skladiste);
            }
            else
            {
                sqlComm.Parameters.AddWithValue("@skladiste", DBNull.Value);
            }

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(tbl);

            return tbl;
        }

        internal string GetSkladisteNaziv(int? skladiste)
        {
            if (skladiste != null)
            {
                return client.ExecuteScalar("Select Naziv From MT_Skladista Where ID = " + (int)skladiste).ToString();
            }

            return "Sva skladišta";
        }

        internal object[] GetDobavljac()
        {
            return client.ConvertDataTableToArrayList(client.GetDataTable("Select IDPARTNER As ID, NAZIVPARTNER As Naziv From PARTNER")).ToArray();
        }
    }
}
