using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class Razredi : Base
    {
        public Razredi()
            : base()
        {
        }

        #region ProvjeraIspravnostiUnosa

        /// <summary>
        /// provjera ispravnosti unosa
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
                if (base.Database.UF_Razred.Where(r => r.Naziv == naziv && r.ID != (id ?? 0)).Count() > 0)
                {
                    this.ValidationMessages.Add(new DataValidationException("TextBoxNaziv", "- NAZIV već postoji"));
                }
            }

            return (this.ValidationMessages.Count == 0);
        }

        /// <summary>
        /// provjera podataka za brisanje
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ValidateConstraints(int id)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // RAZRED with USTANOVA - ŠKOLSKA GODINA - RAZREDNO ODJELJENJE
            if (base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenje.Where(ro => ro.RazredID == id).Count() > 0)
            {
                this.ValidationMessages.Add(new DataValidationException(null, "Odbijeno brisanje razreda jer se već koristi u razrednim odjeljenima!"));
            }

            return (this.ValidationMessages.Count == 0);
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// unos novog reda u bazu
        /// </summary>
        /// <param name="naziv"></param>
        /// <returns></returns>
        public bool Add(string naziv)
        {
            if (!ValidateDataInput(null, naziv))
                return false;

            UF_Razred razred = new UF_Razred();

            razred.Naziv = naziv;
            razred.TS = DateTime.Now;

            base.Database.UF_Razred.AddObject(razred);

            return true;
        }

        /// <summary>
        /// editiranje postojeceg reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="naziv"></param>
        /// <returns></returns>
        public bool Update(int id, string naziv)
        {
            if (!ValidateDataInput(id, naziv))
                return false;

            UF_Razred razred = base.Database.UF_Razred.SingleOrDefault(r => r.ID == id);

            razred.Naziv = naziv;
            razred.TS = DateTime.Now;

            return true;
        }

        /// <summary>
        /// brisanje reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            if (!ValidateConstraints(id))
                return false;

            UF_Razred razred = base.Database.UF_Razred.SingleOrDefault(r => r.ID == id);

            base.Database.UF_Razred.DeleteObject(razred);

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
        /// dohvat razreda po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UF_Razred GetRazred(int id)
        {
            return base.Database.UF_Razred.SingleOrDefault(r => r.ID == id);
        }

        /// <summary>
        /// dohvat svih razreda
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UF_Razred> GetRazrediAll()
        {
            return base.Database.UF_Razred.AsEnumerable();
        }

        /// <summary>
        /// dohvat razreda za prikaz u gridu
        /// </summary>
        /// <returns></returns>
        public object GetRazrediMainGrid()
        {
            return (from r in base.Database.UF_Razred
                    orderby r.ID
                    select new
                    {
                        r.ID,
                        r.Naziv,
                    }).AsEnumerable();
        }

        /// <summary>
        /// dohvat razreda za combobox
        /// </summary>
        /// <returns></returns>
        public object GetRazrediComboBox()
        {
            return (from r in base.Database.UF_Razred
                    orderby r.Naziv
                    select new
                    {
                        r.ID,
                        r.Naziv,
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
