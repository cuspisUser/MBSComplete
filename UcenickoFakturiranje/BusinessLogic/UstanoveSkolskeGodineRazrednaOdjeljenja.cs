using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;
using System.Data.Objects;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class UstanoveSkolskeGodineRazrednaOdjeljenja : Base
    {
        public UstanoveSkolskeGodineRazrednaOdjeljenja()
            : base()
        {
        }

        #region Svojstva

        /// <summary>
        /// For catching ID
        /// </summary>
        public UF_UstanovaSkolskaGodinaRazredOdjeljenje RazrednoOdjeljenje { get; private set; }

        public static int pSelectedIndex
        {
            get;
            set;
        }

        #endregion

        #region ObjectValidation

        private bool ValidateDataInput(int? id, int? ustanovaSkolskaGodinaID, int? razredID, int? odjeljenjeID)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // USTANOVA - ŠKOLSKA GODINA - not null
            if (ustanovaSkolskaGodinaID == null)
            {
                this.ValidationMessages.Add(new DataValidationException("ComboBoxUstanovaSkolskaGodina", "- USTANOVA / ŠKOLSKA GODINA je obavezno polje"));
            }

            // RAZRED - not null
            if (razredID == null)
            {
                this.ValidationMessages.Add(new DataValidationException("ComboBoxRazred", "- RAZRED je obavezno polje"));
            }

            // ODJELJENJE - not null
            if (odjeljenjeID == null)
            {
                this.ValidationMessages.Add(new DataValidationException("ComboBoxOdjeljenje", "- ODJELJENJE je obavezno polje"));
            }

            // USTANOVA - ŠKOLSKA GODINA - RAZRED - ODJELJENJE
            if (ustanovaSkolskaGodinaID != null && razredID != null && odjeljenjeID != null)
            {
                // unique
                if (base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenje.Where(usgro => usgro.UstanovaSkolskaGodinaID == ustanovaSkolskaGodinaID && usgro.RazredID == razredID && 
                    usgro.OdjeljenjeID == odjeljenjeID && usgro.ID != (id ?? 0)).Count() > 0)
                {
                    this.ValidationMessages.Add(new DataValidationException("ComboBoxOdjeljenje", "- RAZREDNO ODJELJENJE za ovu odabranu ustanovu / školsku godinu već postoji"));
                }
            }

            return (this.ValidationMessages.Count == 0);
        }

        private bool ValidateConstraints(int id)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // USTANOVA - ŠKOLSKA GODINA - RAZREDNO ODJELJENJE with UČENIK
            if (base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik.Where(usgro => usgro.UstanovaSkolskaGodinaRazredOdjeljenjeID == id).Count() > 0)
            {
                this.ValidationMessages.Add(new DataValidationException(null, "Odbijeno brisanje razrednog odjeljenja, pošto se na njega već vežu učenici!"));
            }

            return (this.ValidationMessages.Count == 0);
        }

        #endregion

        #region ObjectPersistance

        public bool Add(int? ustanovaSkolskaGodinaID, int? razredID, int? odjeljenjeID, int? voditeljID)
        {
            if (!ValidateDataInput(null, ustanovaSkolskaGodinaID, razredID, odjeljenjeID))
                return false;

            UF_UstanovaSkolskaGodinaRazredOdjeljenje ustanovaSkolskaGodinaRazredOdjeljenje = new UF_UstanovaSkolskaGodinaRazredOdjeljenje();

            ustanovaSkolskaGodinaRazredOdjeljenje.UstanovaSkolskaGodinaID = ustanovaSkolskaGodinaID.Value;
            ustanovaSkolskaGodinaRazredOdjeljenje.RazredID = razredID.Value;
            ustanovaSkolskaGodinaRazredOdjeljenje.OdjeljenjeID = odjeljenjeID.Value;

            ustanovaSkolskaGodinaRazredOdjeljenje.VoditeljID = (voditeljID == 0 ? null : voditeljID);

            base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenje.AddObject(ustanovaSkolskaGodinaRazredOdjeljenje);

            this.RazrednoOdjeljenje = ustanovaSkolskaGodinaRazredOdjeljenje;

            return true;
        }

        public bool Update(int id, int? ustanovaSkolskaGodinaID, int? razredID, int? odjeljenjeID, int? voditeljID)
        {
            if (!ValidateDataInput(id, ustanovaSkolskaGodinaID, razredID, odjeljenjeID))
                return false;

            UF_UstanovaSkolskaGodinaRazredOdjeljenje ustanovaSkolskaGodinaRazredOdjeljenje = base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenje.SingleOrDefault(usgro => usgro.ID == id);

            ustanovaSkolskaGodinaRazredOdjeljenje.UstanovaSkolskaGodinaID = ustanovaSkolskaGodinaID.Value;
            ustanovaSkolskaGodinaRazredOdjeljenje.RazredID = razredID.Value;
            ustanovaSkolskaGodinaRazredOdjeljenje.OdjeljenjeID = odjeljenjeID.Value;

            ustanovaSkolskaGodinaRazredOdjeljenje.VoditeljID = (voditeljID == 0 ? null : voditeljID);

            return true;
        }

        public bool Delete(int id)
        {
            if (!ValidateConstraints(id))
                return false;

            UF_UstanovaSkolskaGodinaRazredOdjeljenje ustanovaSkolskaGodinaRazredOdjeljenje = base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenje.SingleOrDefault(usgro => usgro.ID == id);

            base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenje.DeleteObject(ustanovaSkolskaGodinaRazredOdjeljenje);

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

        #region GetObjectOrCollection

        public UF_UstanovaSkolskaGodinaRazredOdjeljenje GetUstanovaSkolskaGodinaRazredOdjeljenje(int id)
        {
            return base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenje.SingleOrDefault(ro => ro.ID == id);
        }

        public IEnumerable<UF_UstanovaSkolskaGodinaRazredOdjeljenje> GetUstanovaSkolskaGodinaRazredOdjeljenjeAll()
        {
            return base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenje.AsEnumerable();
        }

        public object GetUstanovaSkolskaGodinaRazredOdjeljenjeMainGrid()
        {
            return (from ro in base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenje
                    orderby ro.ID
                    select new 
                    {
                        ro.ID,
                        UstanovaSkolskaGodina = ro.UF_UstanovaSkolskaGodina.UF_Ustanova.Naziv + " / " + ro.UF_UstanovaSkolskaGodina.UF_SkolskaGodina.Naziv,
                        RazredOdjeljenje = ro.UF_Razred.Naziv + " " + ro.UF_Odjeljenje.Naziv,
                        Voditelj = ro.UF_Voditelj.Ime + " " + ro.UF_Voditelj.Prezime,
                        BrojUcenika = (ro.UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik.Count > 0 ? (int?)ro.UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik.Count : null)
                    }).AsEnumerable();
        }

        public object GetRazrednaOdjeljenjaByUstanova(int id_ustanova)
        {
            object vrati = null;
            //Novi nacin linq to entity (ima full support za sve moguce funkcionalnosti)
            vrati = Database.UF_UstanovaSkolskaGodinaRazredOdjeljenje.Include("UF_Razred").Include("UF_Odjeljenje")
                            .Where(odjeljenje => odjeljenje.UF_UstanovaSkolskaGodina.UstanovaID == id_ustanova)
                            .OrderBy(order => order.ID)
                            .Select(sel => new
                            {
                                ID = sel.ID,
                                Naziv = sel.UF_Razred.Naziv + "." + sel.UF_Odjeljenje.Naziv
                            });
            
            //stari nacin linq to query
            //vrati = (from razred_odjeljenje in Database.UF_UstanovaSkolskaGodinaRazredOdjeljenje
            //        join razred in Database.UF_Razred on razred_odjeljenje.RazredID equals razred.ID
            //        join odjeljenje in Database.UF_Odjeljenje on razred_odjeljenje.OdjeljenjeID equals odjeljenje.ID
            //        where razred_odjeljenje.UstanovaSkolskaGodinaID == id_ustanova
            //        orderby razred_odjeljenje.ID
            //        select new
            //        {
            //            ID = razred_odjeljenje.ID,
            //            Naziv = razred.Naziv + "." + odjeljenje.Naziv
            //        }).AsEnumerable();

            return vrati;
        }

        #endregion
    }
}
