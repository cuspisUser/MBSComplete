using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Mipsed7.DataAccessLayer;
using UcenickoFakturiranje.Utils.Exceptions;
using System.IO;
using Mipsed7.DataAccessLayer.EntityFramework;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class Ustanove : Base
    {
        public Ustanove()
            : base()
        {
        }

        #region ProvjeraIspravnostiUnosa

        /// <summary>
        /// provjera ispravnosti unosa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="naziv"></param>
        /// <param name="skraceniNaziv"></param>
        /// <param name="oib"></param>
        /// <param name="logotip"></param>
        /// <param name="id_korisnik"></param>
        /// <param name="sifra_ustanove"></param>
        /// <param name="postanski_broj"></param>
        /// <returns></returns>
        private bool ValidateDataInput(int? id, string naziv, string skraceniNaziv, string oib, string logotip, int? id_korisnik, string sifra_ustanove, string postanski_broj, string model, string poziv_na_broj_01, string model3, string poziv_na_broj_03)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // NAZIV - not null
            if (string.IsNullOrEmpty(naziv))
            {
                this.ValidationMessages.Add(new DataValidationException("TextBoxNaziv", "- NAZIV je obavezno polje"));
            }

            // SKRAĆENI NAZIV - not null
            if (string.IsNullOrEmpty(skraceniNaziv))
            {
                this.ValidationMessages.Add(new DataValidationException("TextBoxSkraceniNaziv", "- SKRAĆENI NAZIV je obavezno polje"));
            }

            // Korisnik id - not null
            if (id_korisnik == null)
            {
                this.ValidationMessages.Add(new DataValidationException("ucbUstanoveKorisnik", "- Korisnik je obavezno polje"));
            }

            // Korisnik id - not null
            if (sifra_ustanove == "")
            {
                this.ValidationMessages.Add(new DataValidationException("uteUstanoveSifraUstanove", "- Sifra ustanove je obavezno polje"));
            }
            else if (sifra_ustanove.Length > 2)
            {
                this.ValidationMessages.Add(new DataValidationException("uteUstanoveSifraUstanove", "- Sifra ustanove može sadržavati maksimalno 2 znaka"));
            }

            // OIB - not null
            if (string.IsNullOrEmpty(oib))
            {
                this.ValidationMessages.Add(new DataValidationException("TextBoxOIB", "- OIB je obavezno polje"));
            }
            else
            {
                if (oib.Length != 11)
                {
                    this.ValidationMessages.Add(new DataValidationException("TextBoxOIB", "- OIB mora sadržavati 11 znakova"));
                }
            }

            if (!string.IsNullOrEmpty(logotip))
            {
                if (!logotip.ToLower().EndsWith(".jpg") &&
                    !logotip.ToLower().EndsWith(".gif"))
                {
                    this.ValidationMessages.Add(new DataValidationException("TextBoxLogotip", "- Za logotip su dozvoljene samo datoteke sa esktenzijom .JPG i .GIF"));
                }
            }

            if (postanski_broj == null)
            {
                this.ValidationMessages.Add(new DataValidationException("ComboBoxPostanskiBroj", "- Poštanski broj je obavezno polje"));
            }

            if (model.Length > 0)
            {
                //model
                try
                {
                    Convert.ToInt32(model);
                    if (model.Length != 2)
                    {
                        this.ValidationMessages.Add(new DataValidationException("txtModel", "- Model može sadržavati samo dvoznamenkasti broj"));
                    }
                }
                catch
                {
                    this.ValidationMessages.Add(new DataValidationException("txtModel", "- Model može sadržavati samo dvoznamenkasti broj"));
                }

                //poziv na broj 01
                try
                {
                    Convert.ToDecimal(poziv_na_broj_01);
                    if (poziv_na_broj_01.Length > 4 | poziv_na_broj_01.Length == 0)
                    {
                        this.ValidationMessages.Add(new DataValidationException("txtPozivNaBroj01", "- Prva skupina je obavezna i ne smije sadržavati više od 4 brojeva"));
                    }
                }
                catch
                {
                    this.ValidationMessages.Add(new DataValidationException("txtPozivNaBroj01", "- Prva skupina je obavezna i ne smije sadržavati više od 4 brojeva"));
                }
            }

            if (model3.Length > 0)
            {
                //model
                try
                {
                    Convert.ToInt32(model3);
                    if (model3.Length != 2)
                    {
                        this.ValidationMessages.Add(new DataValidationException("txtModel", "- Model može sadržavati samo dvoznamenkasti broj"));
                    }
                }
                catch
                {
                    this.ValidationMessages.Add(new DataValidationException("txtModel", "- Model može sadržavati samo dvoznamenkasti broj"));
                }

                //poziv na broj 01
                try
                {
                    Convert.ToDecimal(poziv_na_broj_03);
                    if (poziv_na_broj_03.Length > 4 | poziv_na_broj_03.Length == 0)
                    {
                        this.ValidationMessages.Add(new DataValidationException("txtPozivNaBroj01", "- Prva skupina je obavezna i ne smije sadržavati više od 4 brojeva"));
                    }
                }
                catch
                {
                    this.ValidationMessages.Add(new DataValidationException("txtPozivNaBroj01", "- Prva skupina je obavezna i ne smije sadržavati više od 4 brojeva"));
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

            // USTANOVA with ŠKOLSKA GODINA
            if (base.Database.UF_UstanovaSkolskaGodina.Where(u => u.UstanovaID == id).Count() > 0)
            {
                this.ValidationMessages.Add(new DataValidationException(null, "Odbijeno brisanje ustanove jer uz sebe ima vezanu školsku godinu!"));
            }

            return (this.ValidationMessages.Count == 0);
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// unos novog reda u bazu
        /// </summary>
        /// <param name="naziv"></param>
        /// <param name="skraceniNaziv"></param>
        /// <param name="oib"></param>
        /// <param name="ulicaKucniBroj"></param>
        /// <param name="postanskiBrojID"></param>
        /// <param name="kontaktPodaci"></param>
        /// <param name="logotip"></param>
        /// <param name="maticnapodrucna"></param>
        /// <param name="id_korisnik"></param>
        /// <param name="sifra_ustanove"></param>
        /// <returns></returns>
        public bool Add(string naziv, string skraceniNaziv, string oib, string ulicaKucniBroj, string postanskiBrojID, string kontaktPodaci, string logotip, bool maticnapodrucna, 
                        int? id_korisnik, string sifra_ustanove, string model, string poziv_na_broj_01, string model2, byte broj, string model3, string poziv_na_broj_03, bool PDVNapomena, bool OtvoreneStavke)
        {
            if (!ValidateDataInput(null, naziv, skraceniNaziv, oib, logotip, id_korisnik, sifra_ustanove, postanskiBrojID, model, poziv_na_broj_01, model3, poziv_na_broj_03))
                return false;

            UF_Ustanova ustanova = new UF_Ustanova();

            ustanova.Naziv = naziv;
            ustanova.SkraceniNaziv = skraceniNaziv;
            ustanova.KorisnikID = (int)id_korisnik;
            ustanova.OIB = oib;
            ustanova.SifraUstanove = sifra_ustanove;
            ustanova.TS = DateTime.Now;
            ustanova.Maticna = maticnapodrucna;
            ustanova.UlicaKucniBroj = Utils.Tools.ReturnNULLIfEmpty(ulicaKucniBroj);
            ustanova.PostanskiBrojID = Utils.Tools.ReturnNULLIfEmpty(postanskiBrojID);
            ustanova.KontaktPodaci = Utils.Tools.ReturnNULLIfEmpty(kontaktPodaci);
            ustanova.Model = Utils.Tools.ReturnNULLIfEmpty(model);
            ustanova.PozivNaBroj01 = Utils.Tools.ReturnNULLIfEmpty(poziv_na_broj_01);
            ustanova.Broj = broj;
            ustanova.ModelOdobrenja2 = Utils.Tools.ReturnNULLIfEmpty(model2);
            ustanova.PozivNaBrojOdobrenja = poziv_na_broj_03;
            ustanova.ModelOdobrenja = model3;
            ustanova.PDVNapomena = PDVNapomena;
            ustanova.OtvoreneStavke = OtvoreneStavke;

            if (!string.IsNullOrEmpty(logotip))
                ustanova.Logo = File.ReadAllBytes(logotip);

            base.Database.UF_Ustanova.AddObject(ustanova);

            return true;
        }

        /// <summary>
        /// editiranje postojeceg reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="naziv"></param>
        /// <param name="skraceniNaziv"></param>
        /// <param name="oib"></param>
        /// <param name="ulicaKucniBroj"></param>
        /// <param name="postanskiBrojID"></param>
        /// <param name="kontaktPodaci"></param>
        /// <param name="logotip"></param>
        /// <param name="maticnapodrucna"></param>
        /// <param name="id_korisnik"></param>
        /// <param name="sifra_ustanove"></param>
        /// <returns></returns>
        public bool Update(int id, string naziv, string skraceniNaziv, string oib, string ulicaKucniBroj, string postanskiBrojID, string kontaktPodaci, string logotip, bool maticnapodrucna, 
                           int? id_korisnik, string sifra_ustanove, string model, string poziv_na_broj_01, string model2, byte broj, string model3, string poziv_na_broj_03, bool PDVNapomena, bool OtvoreneStavke)
        {
            if (!ValidateDataInput(id, naziv, skraceniNaziv, oib, logotip, id_korisnik, sifra_ustanove, postanskiBrojID, model, poziv_na_broj_01, model3, poziv_na_broj_03))
                return false;

            UF_Ustanova ustanova = base.Database.UF_Ustanova.SingleOrDefault(u => u.ID == id);

            ustanova.Naziv = naziv;
            ustanova.SkraceniNaziv = skraceniNaziv;
            ustanova.KorisnikID = (int)id_korisnik;
            ustanova.OIB = oib;
            ustanova.SifraUstanove = sifra_ustanove;
            ustanova.TS = DateTime.Now;
            ustanova.Maticna = maticnapodrucna;
            ustanova.UlicaKucniBroj = Utils.Tools.ReturnNULLIfEmpty(ulicaKucniBroj);
            ustanova.PostanskiBrojID = Utils.Tools.ReturnNULLIfEmpty(postanskiBrojID);
            ustanova.KontaktPodaci = Utils.Tools.ReturnNULLIfEmpty(kontaktPodaci);
            ustanova.Model = Utils.Tools.ReturnNULLIfEmpty(model);
            ustanova.PozivNaBroj01 = Utils.Tools.ReturnNULLIfEmpty(poziv_na_broj_01);
            ustanova.Broj = broj;
            ustanova.ModelOdobrenja2 = Utils.Tools.ReturnNULLIfEmpty(model2);
            ustanova.PozivNaBrojOdobrenja = poziv_na_broj_03;
            ustanova.ModelOdobrenja = model3;
            ustanova.PDVNapomena = PDVNapomena;
            ustanova.OtvoreneStavke = OtvoreneStavke;

            if (!string.IsNullOrEmpty(logotip))
                ustanova.Logo = File.ReadAllBytes(logotip);

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

            UF_Ustanova ustanova = base.Database.UF_Ustanova.SingleOrDefault(u => u.ID == id);

            base.Database.UF_Ustanova.DeleteObject(ustanova);

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
        /// dohvat ustanova po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UF_Ustanova GetUstanova(int id)
        {
            return base.Database.UF_Ustanova.SingleOrDefault(u => u.ID == id);
        }

        /// <summary>
        /// dohvat korisnika za comobobox
        /// </summary>
        /// <returns></returns>
        public DataTable GetKorisnici()
        {
            SqlClient client = new SqlClient();

            DataTable dtKorisnik = client.GetDataTable("SELECT IDZIRO, NAZIVZIRO From KORISNIKLevel1");
            return dtKorisnik;
        }

        ///// <summary>
        ///// dohvat svih ustanova
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable<UF_Ustanova> GetUstanoveAll()
        //{
        //    return base.Database.UF_Ustanova.AsEnumerable();

        //}

        /// <summary>
        /// dohvat ustanova za prikaz u gridu
        /// </summary>
        /// <returns></returns>
        public object GetUstanoveMainGrid()
        {
            return (from u in base.Database.UF_Ustanova
                    orderby u.ID
                    select new
                    {
                        u.ID,
                        u.Naziv,
                        u.SkraceniNaziv,
                        u.OIB,
                        u.SifraUstanove,
                        u.UlicaKucniBroj,
                        PostanskiBroj = u.PostanskiBrojID + " - " + u.POSTANSKIBROJEVI.NAZIVPOSTE,
                        u.KontaktPodaci
                    }).AsEnumerable();
        }

        /// <summary>
        /// dohvat ustanova za comobobox
        /// </summary>
        /// <returns></returns>
        public object GetUstanoveComboBox()
        {
            return (from u in base.Database.UF_Ustanova
                    orderby u.Naziv
                    select new
                    {
                        u.ID,
                        u.Naziv
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
