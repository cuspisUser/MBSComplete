using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;
using Infragistics.Win.UltraWinEditors;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class CjeniciStavke : Base
    {
        public CjeniciStavke()
            : base()
        {
        }

        #region ProvjeraIspravnostiUnosa
        
        /// <summary>
        /// Provjera ispravnosti unosa
        /// </summary>
        /// <param name="cjenikID"></param>
        /// <param name="proizvodID"></param>
        /// <param name="olaksica"></param>
        /// <returns></returns>
        public bool ValidateDataInput(int? cjenikID, UltraComboEditor proizvodID, UltraComboEditor olaksica)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // CJENIKID - not null
            if (cjenikID == null)
            {
                this.ValidationMessages.Add(new DataValidationException(null, "- CJENIK je obavezno polje"));
            }

            // PROIZVODID - not null
            if (proizvodID.Value == null)
            {
                this.ValidationMessages.Add(new DataValidationException("ComboBoxProizvod", "- PROIZVOD je obavezno polje"));
            }

            // OLAKSICA - not null
            if (olaksica.Value == null)
            {
                this.ValidationMessages.Add(new DataValidationException("ComboBoxOlaksica", "- OLAKŠICA je obavezno polje"));
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

            return (this.ValidationMessages.Count == 0);
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// Upis novog reda u bazu
        /// </summary>
        /// <param name="cjenikID"></param>
        /// <param name="proizvodID"></param>
        /// <param name="porezID"></param>
        /// <param name="cijena"></param>
        /// <param name="olaksicaID"></param>
        /// <param name="olaksicaPostotak"></param>
        /// <param name="olaksicaIznos"></param>
        /// <returns></returns>
        public bool Add(int cjenikID, int proizvodID, int? porezID, decimal cijena, int? olaksicaID, decimal? olaksicaPostotak, decimal? olaksicaIznos)
        {
            UF_CjenikStavka cjenikStavka = new UF_CjenikStavka();

            cjenikStavka.CjenikID = cjenikID;
            cjenikStavka.ProizvodID = proizvodID;
            cjenikStavka.TS = DateTime.Now;
            cjenikStavka.OlaksicaID = olaksicaID;
            cjenikStavka.OlaksicaPostotak = (olaksicaID != null ? olaksicaPostotak : null);
            cjenikStavka.OlaksicaIznos = (olaksicaID != null ? olaksicaIznos : null);

            base.Database.UF_CjenikStavka.AddObject(cjenikStavka);

            return true;
        }

        /// <summary>
        /// Editiranje postojeceg reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cjenikID"></param>
        /// <param name="proizvodID"></param>
        /// <param name="porezID"></param>
        /// <param name="cijena"></param>
        /// <param name="olaksicaID"></param>
        /// <param name="olaksicaPostotak"></param>
        /// <param name="olaksicaIznos"></param>
        /// <returns></returns>
        public bool Update(int id, int cjenikID, int proizvodID, int? porezID, decimal cijena, int? olaksicaID, decimal? olaksicaPostotak, decimal? olaksicaIznos)
        {
            UF_CjenikStavka cjenikStavka = base.Database.UF_CjenikStavka.SingleOrDefault(s => s.ID == id);

            cjenikStavka.CjenikID = cjenikID;
            cjenikStavka.ProizvodID = proizvodID;
            cjenikStavka.TS = DateTime.Now;
            cjenikStavka.OlaksicaID = olaksicaID;
            cjenikStavka.OlaksicaPostotak = (olaksicaID != null ? olaksicaPostotak : null);
            cjenikStavka.OlaksicaIznos = (olaksicaID != null ? olaksicaIznos : null);

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

            UF_CjenikStavka cjenikStavka = base.Database.UF_CjenikStavka.SingleOrDefault(s => s.ID == id);

            base.Database.UF_CjenikStavka.DeleteObject(cjenikStavka);

            return true;
        }

        /// <summary>
        /// Potvrda promjena u bazi
        /// </summary>
        /// <returns></returns>
        public bool Perist()
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
        public V_UF_CJENIK_STAVKE GetCjenikStavka(int id)
        {
            return base.Database.V_UF_CJENIK_STAVKE.SingleOrDefault(p => p.ID == id);
        }

        /// <summary>
        /// dohvat svih podataka
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UF_CjenikStavka> GetCjeniciStavkeAll()
        {
            return base.Database.UF_CjenikStavka.AsEnumerable();
        }

        /// <summary>
        /// Dohvat podataka za prikaz u gridu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object GetCjeniciStavkeMainGrid(int id)
        {
            return (from c in base.Database.V_UF_CJENIK_STAVKE
                    orderby c.ID
                    where c.CjenikID == id
                    select new
                    {
                        ID = c.ID,
                        ProizvodID = c.ProizvodID,
                        Naziv = c.Naziv,
                        Cijena = c.Proizvod_cjena,
                        Olaksica = c.Olaksica,
                        OlaksicaPostotak = c.OlaksicaPostotak,
                        OlaksicaIznos = c.OlaksicaIznos,
                    }).AsEnumerable();
        }

        /// <summary>
        /// dohvat maksimalnog id-a
        /// </summary>
        /// <returns></returns>
        public int? GetMaxId()
        {
            try
            {
                return base.Database.UF_CjenikStavka.Max(p => p.ID);
            }
            catch 
            {
                return 1;
            }
        }
        #endregion

        public static int pSelectedIndex
        {
            get;
            set;
        }
    }
}
