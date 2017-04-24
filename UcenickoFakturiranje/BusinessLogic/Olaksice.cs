using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;
using System.Data;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class Olaksice : Base
    {
        public Olaksice()
            : base()
        {
        }

        #region ProvjeraIspravnostiUnosa

        /// <summary>
        /// Provjera ispravnosit unosa
        /// </summary>
        /// <param name="naziv"></param>
        /// <param name="olaksicaPostotak"></param>
        /// <param name="olaksicaIznos"></param>
        /// <returns></returns>
        private bool ValidateDataInput(string naziv, decimal? olaksicaPostotak, decimal? olaksicaIznos)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // NAZIV - not null
            if (string.IsNullOrEmpty(naziv))
            {
                this.ValidationMessages.Add(new DataValidationException("TextBoxNaziv", "- NAZIV je obavezno polje"));
            }

            //IZNOS I POSTOTAK - not null
            if(!olaksicaIznos.HasValue && !olaksicaPostotak.HasValue)
            {
                this.ValidationMessages.Add(new DataValidationException("olaksica", "- morate unijeti ili postotak ili iznos olaksice"));
            }


            return (this.ValidationMessages.Count == 0);
        }

        /// <summary>
        /// Provjera podataka za brisanje
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ValidateConstaints(int id)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // CJENIK STAVKA
            if (base.Database.UF_CjenikStavka.Where(s => s.OlaksicaID == id).Count() > 0)
            {
                this.ValidationMessages.Add(new DataValidationException(null, "Odbijeno brisanje olakšice jer je vezana uz stavku cjenika!"));
            }

            return (this.ValidationMessages.Count == 0);
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// Upis novog reda u bazu
        /// </summary>
        /// <param name="naziv"></param>
        /// <param name="olaksicaPostotak"></param>
        /// <param name="olaksicaIznos"></param>
        /// <returns></returns>
        public bool Add(string naziv, decimal? olaksicaPostotak, decimal? olaksicaIznos)
        {
            if (!ValidateDataInput(naziv, olaksicaPostotak, olaksicaIznos))
                return false;

            UF_Olaksica olaksica = new UF_Olaksica();

            olaksica.Naziv = naziv;
            olaksica.OlaksicaPostotak = olaksicaPostotak;
            olaksica.OlaksicaIznos = olaksicaIznos;
            olaksica.TS = DateTime.Now;

            base.Database.UF_Olaksica.AddObject(olaksica);

            return true;
        }

        /// <summary>
        /// Editiranje postojeceg reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="naziv"></param>
        /// <param name="olaksicaPostotak"></param>
        /// <param name="olaksicaIznos"></param>
        /// <returns></returns>
        public bool Update(int id, string naziv, decimal? olaksicaPostotak, decimal? olaksicaIznos)
        {
            if (!ValidateDataInput(naziv, olaksicaPostotak, olaksicaIznos))
                return false;

            UF_Olaksica olaksica = base.Database.UF_Olaksica.SingleOrDefault(o => o.ID == id);

            olaksica.Naziv = naziv;
            olaksica.OlaksicaPostotak = olaksicaPostotak;
            olaksica.OlaksicaIznos = olaksicaIznos;
            olaksica.TS = DateTime.Now;

            return true;
        }

        /// <summary>
        /// Brisanje reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            if (!ValidateConstaints(id))
                return false;

            UF_Olaksica olaksica = base.Database.UF_Olaksica.SingleOrDefault(o => o.ID == id);

            base.Database.UF_Olaksica.DeleteObject(olaksica);

            return true;
        }

        /// <summary>
        /// Potvrda promjene u bazi
        /// </summary>
        public bool Persist()
        {
            try
            {
                base.Database.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        #endregion

        #region DohvatPodataka

        /// <summary>
        /// Dohvat olaksica po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UF_Olaksica GetOlaksica(int id)
        {
            return base.Database.UF_Olaksica.SingleOrDefault(o => o.ID == id);
        }

        /// <summary>
        /// Vraca maksimalni id olaksice
        /// </summary>
        /// <returns></returns>
        public int? GetMaxID()
        {
            try
            {
                return base.Database.UF_Olaksica.Max(o => o.ID);
            }
            catch 
            {
                return 1;
            }
        }

        /// <summary>
        /// dohvat svih olaksica
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UF_Olaksica> GetOlaksiceAll()
        {
            return base.Database.UF_Olaksica.AsEnumerable();
        }

        /// <summary>
        /// dohvat svih olaksica za glavni grid
        /// </summary>
        /// <returns></returns>
        public DataSet GetOlaksiceMainGrid()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            DataSet ds = new DataSet();

            DataTable dtOlaksice = client.GetDataTable("SELECT ID, Naziv, OlaksicaPostotak, OlaksicaIznos FROM UF_Olaksica Order by ID");

            DataTable dtDjeca = client.GetDataTable("SELECT OlaksicaID, ID, Ime, Prezime, OIB, RazrednoOdjeljenje from V_UF_UCENICI_OLAKSICE ORDER BY ID");

            DataTable dtProizvodi = client.GetDataTable("SELECT     OlaksicaID, ProizvodID, Naziv, JedinicaMjere, Grupa FROM  V_UF_PROIZVOD_OLAKSICE");

            ds.Tables.Add(dtOlaksice);
            ds.Tables.Add(dtDjeca);
            ds.Tables.Add(dtProizvodi);

            DataRelation relOlakDjeca = new DataRelation("Olaksice_Djeca", dtOlaksice.Columns["ID"], dtDjeca.Columns["OlaksicaID"]);
            ds.Relations.Add(relOlakDjeca);

            DataRelation relOlakProiz = new DataRelation("Olaksice_Proizvod", dtOlaksice.Columns["ID"], dtProizvodi.Columns["OlaksicaID"]);
            ds.Relations.Add(relOlakProiz);

            return ds;
        }

        /// <summary>
        /// Ubacivanje nulte olaksice ukoliko vec ne postoji
        /// </summary>
        public void InsertNultaOlaksica()
        {
            Mipsed7.DataAccessLayer.SqlClient sql_client = new Mipsed7.DataAccessLayer.SqlClient();

            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = sql_client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Select ID from UF_Olaksica Where OlaksicaPostotak is not null And OlaksicaIznos is not null";

            SqlDataReader sqlReader = sqlUpit.ExecuteReader();
            if (!sqlReader.HasRows)
            {
                sqlUpit.CommandText = "Insert Into UF_Olaksica Values (@TS, 'Bez popusta', 0, 0)";
                sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));
                try
                {
                    sqlReader.Close();
                    sqlUpit.ExecuteNonQuery();
                }
                catch { }
            }
            else
                sqlReader.Close();

        }

        /// <summary>
        /// Dohvat olaksica za combobox
        /// </summary>
        /// <returns></returns>
        public object GetOlaksicaComboBox() 
        {
            return (from j in base.Database.UF_Olaksica
                    orderby j.ID
                    select new { 
                        OlaksicaID = j.ID,
                        Olaksica = j.Naziv
                    }
                );
        }

        #endregion

        public static int pSelectedIndex
        {
            get;
            set;
        }
    }
}
