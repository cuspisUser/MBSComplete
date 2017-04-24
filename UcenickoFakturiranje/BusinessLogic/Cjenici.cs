using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;
using System.Data;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class Cjenici : Base
    {
        public Cjenici()
            : base()
        {
        }

        #region ProvjeraIspravnostiUnosa
        
        /// <summary>
        /// Provjera ispravnosti unosa
        /// </summary>
        /// <param name="naziv"></param>
        /// <param name="vrijediOd"></param>
        /// <param name="vrijediDo"></param>
        /// <param name="stavke"></param>
        /// <returns></returns>
        private bool ValidateDataInput(string naziv, DateTime vrijediOd, DateTime? vrijediDo, bool stavke)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // NAZIV - not null
            if (string.IsNullOrEmpty(naziv))
            {
                this.ValidationMessages.Add(new DataValidationException("TextBoxNaziv", "- NAZIV je obavezno polje"));
            }

            // VRIJEDO OD - not null
            if (vrijediOd == null)
            {
                this.ValidationMessages.Add(new DataValidationException("DateTimePickerDatumOd", "- DATUM OD je obavezno polje"));
            }

            // DATUM DO => DATUM OD
            if (vrijediOd != null && vrijediDo != null)
            {
                if (vrijediDo < vrijediOd)
                {
                    this.ValidationMessages.Add(new DataValidationException("DateTimePickerDatumOd", "- DATUM DO mora biti kasniji ili jednak DATUMU OD"));
                }
            }
            //kontrola za obavezan unos stavaka
            if (!stavke)
            {
                this.ValidationMessages.Add(new DataValidationException("UltraGridStavke", "- Potrebno je pridružiti stavke cjeniku"));
            }

            return (this.ValidationMessages.Count == 0);
        }

        /// <summary>
        /// Provjera podataka za brisanje
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ValidateConstraints(int id)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // CJENCI STAVKE
            if (base.Database.UF_CjenikStavka.Where(s => s.CjenikID == id).Count() > 0)
            {
                this.ValidationMessages.Add(new DataValidationException(null, "Odbijeno brisanje cjenika jer uz sebe ima vezane stavke cjenika!"));
            }

            return (this.ValidationMessages.Count == 0);
        }

        #endregion

        #region RadSaPodacima
        /// <summary>
        /// Upis novog reda u bazu
        /// </summary>
        /// <param name="naziv"></param>
        /// <param name="vrijediOd"></param>
        /// <param name="vrijediDo"></param>
        /// <param name="stavke"></param>
        /// <returns></returns>
        public bool Add(string naziv, DateTime vrijediOd, DateTime? vrijediDo, bool stavke)
        {
            if (!ValidateDataInput(naziv, vrijediOd, vrijediDo, stavke))
                return false;

            UF_Cjenik cjenik = new UF_Cjenik();

            cjenik.Naziv = naziv;
            cjenik.VrijediOd = vrijediOd;
            cjenik.VrijediDo = vrijediDo;
            cjenik.TS = DateTime.Now;

            base.Database.UF_Cjenik.AddObject(cjenik);

            return true;
        }

        /// <summary>
        /// Editiranje postojeceg reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="naziv"></param>
        /// <param name="vrijediOd"></param>
        /// <param name="vrijediDo"></param>
        /// <param name="stavke"></param>
        /// <returns></returns>
        public bool Update(int id, string naziv, DateTime vrijediOd, DateTime? vrijediDo, bool stavke)
        {
            if (!ValidateDataInput(naziv, vrijediOd, vrijediDo, stavke))
                return false;

            UF_Cjenik cjenik = base.Database.UF_Cjenik.SingleOrDefault(c => c.ID == id);

            cjenik.Naziv = naziv;
            cjenik.VrijediOd = vrijediOd;
            cjenik.VrijediDo = vrijediDo;
            cjenik.TS = DateTime.Now;

            return true;
        }

        /// <summary>
        /// Brisanje reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            if (!ValidateConstraints(id))
                return false;

            UF_Cjenik cjenik = base.Database.UF_Cjenik.SingleOrDefault(c => c.ID == id);

            base.Database.UF_Cjenik.DeleteObject(cjenik);

            return true;
        }

        /// <summary>
        /// Potvrda promjena u bazi
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
        /// dohvat podataka po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UF_Cjenik GetCjenik(int id)
        {
            return base.Database.UF_Cjenik.SingleOrDefault(c => c.ID == id);
        }

        /// <summary>
        /// dohvat svih podataka
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UF_Cjenik> GetCjeniciAll()
        {
            return base.Database.UF_Cjenik.AsEnumerable();
        }

        /// <summary>
        /// dohvat maksimalnog id-a
        /// </summary>
        /// <returns></returns>
        public int? GetMaxId()
        {
            return base.Database.UF_Cjenik.Max(p => p.ID);
        }

        /// <summary>
        /// Dohvat podataka za prikaz u gridu
        /// </summary>
        /// <returns></returns>
        public DataSet GetCjeniciMainGrid()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            DataSet ds = new DataSet();

            DataTable dtCjenici = client.GetDataTable("SELECT [ID],[Naziv],[VrijediOd],[VrijediDo] FROM [UF_Cjenik] order by ID");

            DataTable dtProizvod = client.GetDataTable("SELECT CjenikID, ProizvodID, Naziv, JedinicaMjere, Grupa from V_UF_PROIZVOD_CJENIK ORDER BY CjenikID");

            ds.Tables.Add(dtCjenici);
            ds.Tables.Add(dtProizvod);

            DataRelation relCjeniciProizvod = new DataRelation("CJENICI_PROIZVODI", dtCjenici.Columns["ID"], dtProizvod.Columns["CjenikID"]);

            ds.Relations.Add(relCjeniciProizvod);
            return ds;
        }
        #endregion

        public static int pSelectedIndex
        {
            get;
            set;
        }
    }
}
