using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class Odjeljenja : Base
    {
        public Odjeljenja()
            : base()
        {
        }

        #region ProvjeraIspravnostiUnosa

        /// <summary>
        /// Provjera ispravnosti unosa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="naziv"></param>
        /// <returns></returns>
        private bool ValidateDataInput(int? id, string naziv)
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
                if (base.Database.UF_Odjeljenje.Where(o => o.Naziv == naziv && o.ID != (id ?? 0)).Count() > 0)
                {
                    this.ValidationMessages.Add(new DataValidationException("TextBoxNaziv", "- NAZIV već postoji"));
                }
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

            // ODJELJENJE with USTANOVA - ŠKOLSKA GODINA - RAZREDNO ODJELJENJE
            if (base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenje.Where(ro => ro.OdjeljenjeID == id).Count() > 0)
            {
                this.ValidationMessages.Add(new DataValidationException(null, "Odbijeno brisanje odjeljenja jer se već koristi u razrednim odjeljenjima!"));
            }

            return (this.ValidationMessages.Count == 0);
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// Upis novog reda u bazu
        /// </summary>
        /// <param name="naziv"></param>
        /// <returns></returns>
        public bool Add(string naziv)
        {
            if (!ValidateDataInput(null, naziv))
                return false;

            UF_Odjeljenje odjeljenje = new UF_Odjeljenje();

            odjeljenje.Naziv = naziv;
            odjeljenje.TS = DateTime.Now;

            base.Database.UF_Odjeljenje.AddObject(odjeljenje);

            return true;
        }

        /// <summary>
        /// Editiranje postojeceg reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="naziv"></param>
        /// <returns></returns>
        public bool Update(int id, string naziv)
        {
            if (!ValidateDataInput(id, naziv))
                return false;

            UF_Odjeljenje odjeljenje = base.Database.UF_Odjeljenje.SingleOrDefault(o => o.ID == id);

            odjeljenje.Naziv = naziv;
            odjeljenje.TS = DateTime.Now;

            return true;
        }

        /// <summary>
        /// Brisanje reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            if(!ValidateConstraints(id))
                return false;

            UF_Odjeljenje odjeljenje = base.Database.UF_Odjeljenje.SingleOrDefault(o => o.ID == id);

            base.Database.UF_Odjeljenje.DeleteObject(odjeljenje);

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
        /// Dohvat odjeljenja po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UF_Odjeljenje GetOdjeljenje(int id)
        {
            return base.Database.UF_Odjeljenje.SingleOrDefault(o => o.ID == id);
        }

        /// <summary>
        /// DOhvat svih odjeljenja
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UF_Odjeljenje> GetOdjeljenjeAll()
        {
            return base.Database.UF_Odjeljenje.AsEnumerable();
        }

        /// <summary>
        /// Dohvat odjeljenja za glavni grid
        /// </summary>
        /// <returns></returns>
        public object GetOdjeljenjaMainGrid()
        {
            return (from o in base.Database.UF_Odjeljenje
                    orderby o.ID
                    select new
                    {
                        o.ID,
                        o.Naziv
                    }).AsEnumerable();
        }

        /// <summary>
        /// Dohvat odjeljenja za combobox
        /// </summary>
        /// <returns></returns>
        public object GetOdjeljenjaComboBox()
        {
            return (from o in base.Database.UF_Odjeljenje
                    orderby o.Naziv
                    select new
                    {
                        o.ID,
                        o.Naziv
                    }).AsEnumerable();
        }

        #endregion

        public static int pSelectedIndex
        {
            get;
            set;
        }
    }
}
