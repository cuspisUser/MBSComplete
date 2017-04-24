using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;

namespace Materijalno.BusinessLogic
{
    public class Proizvod : Base, IDisposable
    {
        SqlClient client = null;
        public Proizvod()
            : base()
        {
            client = new SqlClient();
        }

        public void Dispose()
        {

        }

        #region Properties

        public int pSifra { get; set; }
        public string pNaziv { get; set; }
        public double pCijena { get; set; }
        public int pJedinicaMjere { get; set; }
        public int pPorez { get; set; }
        public double pCijenaPDV { get; set; }
        public Nullable<int> grupaProizvod { get; set; }

        #endregion

        #region Work with data

        public bool Insert(StringBuilder message, Proizvod objekt)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Insert Into PROIZVOD (IDPROIZVOD, NAZIVPROIZVOD, FINPOREZIDPOREZ, CIJENA, IDJEDINICAMJERE, CIjenaPDV, idGrupa) " +
                                  "Values (@IDPROIZVOD, @NAZIVPROIZVOD, @FINPOREZIDPOREZ, @CIJENA, @IDJEDINICAMJERE, @CijenaPDV, @idGrupa)";

            sqlUpit.Parameters.Add(new SqlParameter("@IDPROIZVOD", objekt.pSifra));
            sqlUpit.Parameters.Add(new SqlParameter("@NAZIVPROIZVOD", objekt.pNaziv));
            sqlUpit.Parameters.Add(new SqlParameter("@FINPOREZIDPOREZ", objekt.pPorez));
            sqlUpit.Parameters.Add(new SqlParameter("@CIJENA", objekt.pCijena));
            sqlUpit.Parameters.Add(new SqlParameter("@IDJEDINICAMJERE", objekt.pJedinicaMjere));
            sqlUpit.Parameters.Add(new SqlParameter("@CijenaPDV", objekt.pCijenaPDV));
            if (objekt.grupaProizvod != null)
            {
                sqlUpit.Parameters.Add(new SqlParameter("@idGrupa", objekt.grupaProizvod));
            }
            else
            {
                sqlUpit.Parameters.Add(new SqlParameter("@idGrupa", DBNull.Value));
            }

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

        internal bool ProvjeraSifre(int sifra)
        {
            DataTable tbl = client.GetDataTable("Select IDPROIZVOD From PROIZVOD Where IDPROIZVOD = " + sifra);

            if (tbl.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal object GetJedinicaMjere()
        {
            DataTable dt = client.GetDataTable("Select IDJEDINICAMJERE As ID, NAZIVJEDINICAMJERE As Naziv From JEDINICAMJERE");
            return dt;
        }

        internal object GetPorez()
        {
            DataTable dt = client.GetDataTable("Select FINPOREZIDPOREZ As ID, FINPOREZNAZIVPOREZ As Naziv From FINPOREZ");
            return dt;
        }

        internal object GetGrupa()
        {
            DataTable dt = client.GetDataTable("Select ID, Naziv From MT_GrupeProizvoda");
            return dt;
        }

        internal object GetSifraPorez()
        {
            return client.ExecuteScalar("Select Max(IDPROIZVOD + 1) From PROIZVOD").ToString();
        }

        internal double GetStopaPorez(int porez)
        {
            return Convert.ToDouble(client.ExecuteScalar("Select FINPOREZSTOPA From FINPOREZ Where FINPOREZIDPOREZ = " + porez));
        }

        internal object[] GetProizvod1()
        {
            return client.ConvertDataTableToArrayList(client.GetDataTable("Select IDPROIZVOD As ID, (CAST(IDPROIZVOD AS nvarchar) + ' | '  + NAZIVPROIZVOD) As Naziv From PROIZVOD")).ToArray();
        }

        internal DataSet GetKarticeArtiklaIspis(int proizvod, Nullable<int> skladiste, string datumOd, string datumDo)
        {
            DataSet ds = new DataSet("KarticeArtikala");
            SqlCommand sqlComm = new SqlCommand("sp_KarticeReprodukcijskogMaterijala", client.sqlConnection);
            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.Parameters.AddWithValue("@ID", proizvod);
            sqlComm.Parameters.AddWithValue("@Skladiste", skladiste);
            sqlComm.Parameters.AddWithValue("@DatumOd", datumOd);
            sqlComm.Parameters.AddWithValue("@DatumDo", datumDo);
            sqlComm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlComm;
            da.Fill(ds);

            return ds;
        }

        internal DataTable GetSkladiste()
        {
            DataTable dt = client.GetDataTable("Select ID, NAZIV From MT_Skladista");
            return dt;
        }

        #endregion

        internal bool ObveznikPDV()
        {
            try
            {
                if (Convert.ToBoolean(client.ExecuteScalar("Select OBVEZNIKPDVA From Korisnik")))
                {
                    return true;
                }
            }
            catch { return false; }

            return false;
        }

        internal double PredPorez()
        {
            try
            {
                return Convert.ToDouble(client.ExecuteScalar("Select PredPorez From Korisnik"));
            }
            catch { return 0; }
        }

        internal DataTable GetMjestoTroska()
        {
            DataTable dt = client.GetDataTable("Select IDMJESTOTROSKA As ID, NAZIVMJESTOTROSKA As NAZIV From MJESTOTROSKA");
            return dt;
        }

        internal bool SkladistePorez()
        {
            try
            {
                if (Convert.ToBoolean(client.ExecuteScalar("Select Porez From MT_Skladista Where ID = " + "")))
                {
                    return true;
                }
            }
            catch { return false; }

            return false;
        }
    }
}
