using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;


namespace UcenickoFakturiranje.BusinessLogic
{
    public class Voditelji : Base
    {
        public Voditelji() :
            base()
        {
        }

        #region ObjectValidation

        private bool ValidateDataInput(int? id, string ime, string prezime, string oib, bool aktivnost)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // IME - not null
            if (string.IsNullOrEmpty(ime))
            {
                this.ValidationMessages.Add(new DataValidationException("TextBoxIme", "- IME je obavezno polje"));
            }

            // PREZIME - not null
            if (string.IsNullOrEmpty(prezime))
            {
                this.ValidationMessages.Add(new DataValidationException("TextBoxPrezime", "- PREZIME je obavezno polje"));
            }

            if (!string.IsNullOrEmpty(oib))
            {
                // OIB - check length
                if (oib.Length != 11)
                {
                    this.ValidationMessages.Add(new DataValidationException("TextBoxOIB", "- OIB mora sadržavati 11 znakova"));
                }
                else
                {
                    if (base.Database.UF_Voditelj.Where(v => v.OIB == oib && v.ID != (id ?? 0)).Count() > 0)
                    {
                        this.ValidationMessages.Add(new DataValidationException("TextBoxOIB", "- OIB već postoji"));
                    }
                }
            }
            else
            {
                this.ValidationMessages.Add(new DataValidationException("TextBoxOIB", "- OIB je obavezno polje"));
            }

            return (this.ValidationMessages.Count == 0);
        }

        private bool ValidateConstraints(int id)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // VODITELJ with RAZREDNO ODJELJENJE
            if (base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenje.Where(v => v.VoditeljID == id).Count() > 0)
            {
                this.ValidationMessages.Add(new DataValidationException(null, "Odbijeno brisanje voditelja jer je vezan uz razredno odjeljenje!"));
            }

            return (this.ValidationMessages.Count == 0);
        }

        #endregion

        #region ObjectPersistance

        public bool Add(string ime, string prezime, string oib, int? radnoMjestoID, bool aktivnost)
        {
            if (!ValidateDataInput(null, ime, prezime, oib, aktivnost))
                return false;

            UF_Voditelj voditelj = new UF_Voditelj();

            voditelj.Ime = ime;
            voditelj.Prezime = prezime;
            voditelj.OIB = Utils.Tools.ReturnNULLIfEmpty(oib);
            voditelj.RadnoMjestoID = radnoMjestoID;
            voditelj.Aktivnost = aktivnost;
            voditelj.TS = DateTime.Now;

            base.Database.UF_Voditelj.AddObject(voditelj);

            return true;
        }

        public bool Update(int id, string ime, string prezime, string oib, int? radnoMjestoID, bool aktivnost)
        {
            if (!ValidateDataInput(id, ime, prezime, oib, aktivnost))
                return false;

            UF_Voditelj voditelj = base.Database.UF_Voditelj.SingleOrDefault(v => v.ID == id);

            voditelj.Ime = ime;
            voditelj.Prezime = prezime;
            voditelj.OIB = Utils.Tools.ReturnNULLIfEmpty(oib);
            voditelj.RadnoMjestoID = radnoMjestoID;
            voditelj.Aktivnost = aktivnost;

            return true;
        }

        public bool Delete(int id)
        {
            if (!ValidateConstraints(id))
                return false;

            UF_Voditelj voditelj = base.Database.UF_Voditelj.SingleOrDefault(v => v.ID == id);

            base.Database.UF_Voditelj.DeleteObject(voditelj);

            return true;
        }

        /// <summary>
        /// Save changes to entity
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

        #region GetOjectOrCollection

        public UF_Voditelj GetVoditelj(int id)
        {
            return base.Database.UF_Voditelj.SingleOrDefault(u => u.ID == id);
        }

        public IEnumerable<UF_Voditelj> GetVoditeljiAll()
        {
            return base.Database.UF_Voditelj.AsEnumerable();
        }

        public object GetVoditeljiMainGrid()
        {
            return (from v in base.Database.UF_Voditelj
                    orderby v.ID
                    select new
                    {
                        v.ID,
                        ImePrezime = v.Ime + " " + v.Prezime,
                        v.OIB,
                        RadnoMjesto = v.RADNOMJESTO.NAZIVRADNOMJESTO,
                        v.Aktivnost
                    }).AsEnumerable();
        }

        /// <summary>
        /// Metoda je proširena sa parametrom "ustanovaSkolskaGodinaRazredOdjeljenjeID".
        /// Ukoliko radimo editiranje entiteta u kojemu se upotrebljava voditelj, moramo voditi računa da se prikaže 
        /// i onaj voditelj koja nije aktivan.
        /// </summary>
        /// <param name="ustanovaSkolskaGodinaRazredOdjeljenjeID"></param>
        /// <returns></returns>
        public object GetVoditeljiComboBox(int? ustanovaSkolskaGodinaRazredOdjeljenjeID, bool insertDefaultValue)
        {
            int voditeljID = 0;

            if (ustanovaSkolskaGodinaRazredOdjeljenjeID != null)
            {
                UstanoveSkolskeGodineRazrednaOdjeljenja ustanoveSkolskeGodineRazrednaOdjeljenja = new UstanoveSkolskeGodineRazrednaOdjeljenja();
                UF_UstanovaSkolskaGodinaRazredOdjeljenje ustanovaSkolskaGodinaRazrednoOdjeljenje = ustanoveSkolskeGodineRazrednaOdjeljenja.GetUstanovaSkolskaGodinaRazredOdjeljenje(ustanovaSkolskaGodinaRazredOdjeljenjeID.GetValueOrDefault(0));

                if (ustanovaSkolskaGodinaRazrednoOdjeljenje != null)
                    voditeljID = ustanovaSkolskaGodinaRazrednoOdjeljenje.VoditeljID.GetValueOrDefault(0);
            }

            var voditelji = (from v in base.Database.UF_Voditelj
                             where v.Aktivnost || v.ID == voditeljID
                             orderby v.Ime + " " + v.Prezime
                             select new
                             {
                                 v.ID,
                                 Voditelj = v.Ime + " " + v.Prezime
                             }).ToList();

            if (insertDefaultValue)
                voditelji.Insert(0, new { ID = 0, Voditelj = "- nedefinirano" });

            return voditelji.AsEnumerable();
        }

        #endregion

        public static int pSelectedIndex
        {
            get;
            set;
        }
    }
}
