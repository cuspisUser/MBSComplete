using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class UstanoveSkolskeGodine : Base
    {
        public UstanoveSkolskeGodine()
            : base()
        {
        }

        #region ProvjeraIspravnostiUnosa

        /// <summary>
        /// provjera ispravnosti unosa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ustanovaID"></param>
        /// <param name="skolskaGodinaID"></param>
        /// <returns></returns>
        private bool ValidateDateInput(int? id, int? ustanovaID, int? skolskaGodinaID)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // USTANOVA - not null
            if (ustanovaID == null)
            {
                this.ValidationMessages.Add(new DataValidationException("ComboBoxUstanova", "- USTANOVA je obavezno polje"));
            }

            // ŠKOLSKA GODINA - not null
            if (skolskaGodinaID == null)
            {
                this.ValidationMessages.Add(new DataValidationException("ComboBoxSkolskaGodina", "- ŠKOLSKA GODINA je obavezno polje"));
            }

            if (ustanovaID != null && skolskaGodinaID != null)
            {
                // USTANOVA - ŠKOLSKA GODINA - unique
                if (base.Database.UF_UstanovaSkolskaGodina.Where(usg => usg.UstanovaID == ustanovaID && usg.SkolskaGodinaID == skolskaGodinaID && usg.ID != (id ?? 0)).Count() > 0)
                {
                    this.ValidationMessages.Add(new DataValidationException("ComboBoxSkolskaGodina", "- ŠKOLSKA GODINA za odabranu USTANOVU je već otvorena"));
                }
            }

            return (this.ValidationMessages.Count == 0);
        }

        /// <summary>
        /// provjera podatak za brisanje
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ValidateConstraints(int id)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // USTANOVA - ŠKOLSKA GODINA with razredno odjeljenje
            if (base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenje.Where(usg => usg.UstanovaSkolskaGodinaID == id).Count() > 0)
            {
                this.ValidationMessages.Add(new DataValidationException(null, "Odbijeno brisanje školske godine i ustanove, pošto se na njih već vežu određena razredna odjeljenja!"));
            }

            return (this.ValidationMessages.Count == 0);
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// unos novog reda u bazu
        /// </summary>
        /// <param name="ustanovaID"></param>
        /// <param name="skolskaGodinaID"></param>
        /// <returns></returns>
        public bool Add(int? ustanovaID, int? skolskaGodinaID)
        {
            if (!ValidateDateInput(null, ustanovaID, skolskaGodinaID))
                return false;

            UF_UstanovaSkolskaGodina ustanovaSkolskaGodina = new UF_UstanovaSkolskaGodina();

            ustanovaSkolskaGodina.UstanovaID = ustanovaID.Value;
            ustanovaSkolskaGodina.SkolskaGodinaID = skolskaGodinaID.Value;

            base.Database.UF_UstanovaSkolskaGodina.AddObject(ustanovaSkolskaGodina);

            return true;
        }

        /// <summary>
        /// editiranje postojeceg reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ustanovaID"></param>
        /// <param name="skolskaGodinaID"></param>
        /// <returns></returns>
        public bool Update(int id, int? ustanovaID, int? skolskaGodinaID)
        {
            if (!ValidateDateInput(id, ustanovaID, skolskaGodinaID))
                return false;

            UF_UstanovaSkolskaGodina ustanovaSkolskaGodina = base.Database.UF_UstanovaSkolskaGodina.SingleOrDefault(usg => usg.ID == id);

            ustanovaSkolskaGodina.UstanovaID = ustanovaID.Value;
            ustanovaSkolskaGodina.SkolskaGodinaID = skolskaGodinaID.Value;

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

            UF_UstanovaSkolskaGodina ustanovaSkolskaGodina = base.Database.UF_UstanovaSkolskaGodina.SingleOrDefault(usg => usg.ID == id);

            base.Database.UF_UstanovaSkolskaGodina.DeleteObject(ustanovaSkolskaGodina);

            return true;
        }

        /// <summary>
        /// potvrda promjena u bazi
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
        /// dohvat ustanova skolskih godina po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UF_UstanovaSkolskaGodina GetUstanovaSkolskaGodina(int id)
        {
            return base.Database.UF_UstanovaSkolskaGodina.SingleOrDefault(u => u.ID == id);
        }

        /// <summary>
        /// dohvat svih ustanova skolskih godina
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UF_UstanovaSkolskaGodina> GetUstanoveSkolskeGodineAll()
        {
            return base.Database.UF_UstanovaSkolskaGodina.AsEnumerable();
        }

        /// <summary>
        /// dohvat ustanova skolskih godina za prikaz u gridu
        /// </summary>
        /// <returns></returns>
        public object GetUstanoveSkolskeGodineMainGrid()
        {
            return (from usk in base.Database.UF_UstanovaSkolskaGodina
                    orderby usk.ID
                    select new
                    {
                        usk.ID,
                        Ustanova = usk.UF_Ustanova.Naziv,
                        SkolskaGodina = usk.UF_SkolskaGodina.Naziv
                    });
        }

        /// <summary>
        /// dohvat ustanova skolskih godina za combobox
        /// </summary>
        /// <returns></returns>
        public object GetUstanoveSkolskeGodineComboBox()
        {
            return (from usk in base.Database.UF_UstanovaSkolskaGodina
                    orderby usk.UF_Ustanova.Naziv, usk.UF_SkolskaGodina.Naziv
                    select new
                    {
                        usk.ID,
                        UstanovaSkolskaGodina = usk.UF_Ustanova.Naziv + " / " + usk.UF_SkolskaGodina.Naziv
                    }).AsEnumerable();
        }

        #endregion

        public static int pSelectedIndex { get; set; }
    }
}
