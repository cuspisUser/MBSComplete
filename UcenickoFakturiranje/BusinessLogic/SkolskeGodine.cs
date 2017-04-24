using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class SkolskeGodine : Base
    {
        public SkolskeGodine()
            : base()
        {
        }

        #region ProvjeraIspravnosiUnosa

        /// <summary>
        /// provjera ispravnosit unosa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="naziv"></param>
        /// <param name="datumPocetka"></param>
        /// <param name="datumZavrsetka"></param>
        /// <param name="aktivnost"></param>
        /// <returns></returns>
        private bool ValidateDataInput(int? id, string naziv, DateTime datumPocetka, DateTime datumZavrsetka, bool aktivnost)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // NAZIV - not null
            if (string.IsNullOrEmpty(naziv))
            {
                this.ValidationMessages.Add(new DataValidationException("TextBoxNaziv", "- NAZIV je obavezno polje"));
            }
            else
            {
                // NAZIV - unique
                if (base.Database.UF_SkolskaGodina.Where(s => s.Naziv == naziv && s.ID != (id ?? 0)).Count() > 0)
                {
                    this.ValidationMessages.Add(new DataValidationException("TextBoxNaziv", "- NAZIV već postoji"));
                }
            }

            // DATUMPOCETKA - not null
            if (datumPocetka == null)
            {
                this.ValidationMessages.Add(new DataValidationException("DateTimePickerDatumPocetka", "- DATUM POČETKA je obavezno polje"));
            }

            // DATUMZAVRSETKA - not null
            if (datumZavrsetka == null)
            {
                this.ValidationMessages.Add(new DataValidationException("DateTimePickerDatumZavrsetka", "- DATUM ZAVRŠETKA je obavezno polje"));
            }

            // DATUMZAVRSETKA > DATUMPOCETKA
            if (datumPocetka != null && datumZavrsetka != null)
            {
                if (datumZavrsetka <= datumPocetka)
                {
                    this.ValidationMessages.Add(new DataValidationException("DateTimePickerDatumZavrsetka", "- DATUM ZAVRŠETKA mora biti kasniji od DATUMA POČETKA"));
                }
            }

            return (this.ValidationMessages.Count == 0);
        }

        /// <summary>
        /// provjera podataka za brisanje
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ValidationConstraints(int id)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // ŠKOLSKA GODINA with USTANOVA
            if (base.Database.UF_UstanovaSkolskaGodina.Where(u => u.SkolskaGodinaID == id).Count() > 0)
            {
                this.ValidationMessages.Add(new DataValidationException(null, "Odbijeno brisanje školske godine jer uz sebe ima vezanu ustanovu!"));
            }

            return (this.ValidationMessages.Count == 0);
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// unos novoga reda u bazu
        /// </summary>
        /// <param name="naziv"></param>
        /// <param name="datumPocetka"></param>
        /// <param name="datumZavrsetka"></param>
        /// <param name="aktivnost"></param>
        /// <returns></returns>
        public bool Add(string naziv, DateTime datumPocetka, DateTime datumZavrsetka, bool aktivnost)
        {
            if (!ValidateDataInput(null, naziv, datumPocetka, datumZavrsetka, aktivnost))
                return false;

            UF_SkolskaGodina skolskaGodina = new UF_SkolskaGodina();

            skolskaGodina.Naziv = naziv;
            skolskaGodina.DatumPocetka = datumPocetka;
            skolskaGodina.DatumZavrsetka = datumZavrsetka;
            skolskaGodina.Aktivnost = aktivnost;
            skolskaGodina.TS = DateTime.Now;

            base.Database.UF_SkolskaGodina.AddObject(skolskaGodina);

            return true;
        }

        /// <summary>
        /// Editiranje postojeceg reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="naziv"></param>
        /// <param name="datumPocetka"></param>
        /// <param name="datumZavrsetka"></param>
        /// <param name="aktivnost"></param>
        /// <returns></returns>
        public bool Update(int id, string naziv, DateTime datumPocetka, DateTime datumZavrsetka, bool aktivnost)
        {
            if (!ValidateDataInput(id, naziv, datumPocetka, datumZavrsetka, aktivnost))
                return false;

            UF_SkolskaGodina skolskaGodina = base.Database.UF_SkolskaGodina.SingleOrDefault(s => s.ID == id);

            skolskaGodina.Naziv = naziv;
            skolskaGodina.DatumPocetka = datumPocetka;
            skolskaGodina.DatumZavrsetka = datumZavrsetka;
            skolskaGodina.Aktivnost = aktivnost;
            skolskaGodina.TS = DateTime.Now;

            return true;
        }

        /// <summary>
        /// brisanje reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            if (!ValidationConstraints(id))
                return false;

            UF_SkolskaGodina skolskaGodina = base.Database.UF_SkolskaGodina.SingleOrDefault(s => s.ID == id);

            base.Database.UF_SkolskaGodina.DeleteObject(skolskaGodina);

            return true;
        }

        /// <summary>
        /// potvrda promjene u bazi
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
        /// dohvat skoloskih godina po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UF_SkolskaGodina GetSkolskaGodina(int id)
        {
            return base.Database.UF_SkolskaGodina.SingleOrDefault(s => s.ID == id);
        }

        /// <summary>
        /// dohvat svih skoliskih godina
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UF_SkolskaGodina> GetSkolskeGodineAll()
        {
            return base.Database.UF_SkolskaGodina.AsEnumerable();
        }

        public object GetSkolskeGodineMainGrid()
        {
            return (from s in base.Database.UF_SkolskaGodina
                    orderby s.ID
                    select new
                    {
                        s.ID,
                        s.Naziv,
                        s.DatumPocetka,
                        s.DatumZavrsetka,
                        s.Aktivnost
                    }).AsEnumerable();
        }

        /// <summary>
        /// Metoda je proširena sa parametrom "ustanovaSkolskaGodinaID".
        /// Ukoliko radimo editiranje entiteta u kojemu se upotrebljava školska godina, moramo voditi računa da se prikaže 
        /// i ona školska godina koja nije aktivna.
        /// </summary>
        /// <param name="ustanovaSkolskaGodinaID"></param>
        /// <returns></returns>
        public object GetSkolskeGodineComboBox(int? ustanovaSkolskaGodinaID)
        {
            int skolskaGodinaID = 0;

            if (ustanovaSkolskaGodinaID != null)
            {
                UstanoveSkolskeGodine ustanoveSkolskeGodine = new UstanoveSkolskeGodine();
                UF_UstanovaSkolskaGodina ustanovaSkolskaGodina = ustanoveSkolskeGodine.GetUstanovaSkolskaGodina(ustanovaSkolskaGodinaID.GetValueOrDefault(0));

                if (ustanovaSkolskaGodina != null)
                    skolskaGodinaID = ustanovaSkolskaGodina.SkolskaGodinaID;
            }

            return (from s in base.Database.UF_SkolskaGodina
                    where s.Aktivnost || s.ID == skolskaGodinaID
                    orderby s.DatumPocetka
                    select new
                    {
                        s.ID,
                        s.Naziv
                    }).AsEnumerable();
        }

        #endregion
    }
}
