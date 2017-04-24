using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;
using System.Data;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class Ucenici : Base
    {
        SqlClient client = null;
        public Ucenici()
            : base()
        {
            client = new SqlClient();
        }

        #region ProvjeraIspravnostiUnosa

        private bool ValidateDataInput(int? id, string ime, string prezime, string oib, string jmbg, int? id_vrsta_veze, string imeRoditelj, string prezimeRoditelj, string oibRoditelj, string IBANRoditelj)
        {
            this.ValidationMessages = new List<DataValidationException>();

            if (imeRoditelj.Length > 50)
            {
                this.ValidationMessages.Add(new DataValidationException("uteImeRoditelj", "- Ime roditelja je nesmije biti veće od 50"));
            }

            if (IBANRoditelj.Length > 30)
            {
                this.ValidationMessages.Add(new DataValidationException("uteIBANRoditelj", "- IBAN roditelja je nesmije biti veće od 30"));
            }

            if (prezimeRoditelj.Length > 50)
            {
                this.ValidationMessages.Add(new DataValidationException("utePrezimeRoditelj", "- Prezime roditelja je nesmije biti veće od 50"));
            }

            if (oibRoditelj.Length > 25)
            {
                this.ValidationMessages.Add(new DataValidationException("uteOIBRoditelj", "- OIB je predugačak"));
            }

            if (id_vrsta_veze == null)
            {
                this.ValidationMessages.Add(new DataValidationException("uceVrstaVeze", "- Vrsta veze je obavezno polje"));
            }
            // NAZIV - not null
            if (string.IsNullOrEmpty(ime))
            {
                this.ValidationMessages.Add(new DataValidationException("TextBoxIme", "- IME je obavezno polje"));
            }

            // PREZIME - not null
            if (string.IsNullOrEmpty(prezime))
            {
                this.ValidationMessages.Add(new DataValidationException("TextBoxPrezime", "- PREZIME je obavezno polje"));
            }

            // OIB - not null
            if (string.IsNullOrEmpty(oib))
            {
                this.ValidationMessages.Add(new DataValidationException("TextBoxOIB", "- OIB je obavezno polje"));
            }
            else
            {
                // OIB - check length
                if (oib.Length  > 25)
                {
                    this.ValidationMessages.Add(new DataValidationException("TextBoxOIB", "- OIB mora sadržavati manje od 25 znakova"));
                }
                else
                {
                    // OIB - unique
                    if (base.Database.UF_Ucenik.Where(v => v.OIB == oib && v.ID != (id ?? 0)).Count() > 0)
                    {
                        this.ValidationMessages.Add(new DataValidationException("TextBoxOIB", "- Upisani OIB već postoji"));
                    }
                }
            }

            // JMBG - not null
            if (!string.IsNullOrEmpty(jmbg))
            {
                // JMBG - check length
                if (jmbg.Length != 13)
                {
                    //maknuto zbog uvoza iz e matice
                    //this.ValidationMessages.Add(new DataValidationException("TextBoxJMBG", "- JMBG mora sadržavati 13 znakova"));
                }
                else
                {
                    // JMBG - unique
                    if (base.Database.UF_Ucenik.Where(v => v.JMBG == jmbg && v.ID != (id ?? 0)).Count() > 0)
                    {
                        this.ValidationMessages.Add(new DataValidationException("TextBoxJMBG", "- Upisani JMBG  već postoji"));
                    }
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

            // UČENICI WITH USTANOVA - ŠKOLSKA GODINA - RAZREDNO ODJELJENJE
            if (base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik.Where(u => u.UcenikID == id).Count() > 0)
            {
                this.ValidationMessages.Add(new DataValidationException(null, "Odbijeno brisanje učenika jer je vezan uz razredno odjeljenje!"));
            }

            // OBRAČUN STAVKE
            if (base.Database.UF_ObracunStavka.Where(s => s.UcenikID == id).Count() > 0)
            {
                this.ValidationMessages.Add(new DataValidationException(null, "Odbijeno brisanje učenika jer je vezan uz jedan od obračuna!"));
            }

            return (this.ValidationMessages.Count == 0);
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// unos novog reda u bazu
        /// </summary>
        /// <param name="ime"></param>
        /// <param name="prezime"></param>
        /// <param name="oib"></param>
        /// <param name="jmbg"></param>
        /// <param name="spolID"></param>
        /// <param name="ulicaKucniBroj"></param>
        /// <param name="naselje"></param>
        /// <param name="postanskiBrojID"></param>
        /// <param name="datumRodjenja"></param>
        /// <returns></returns>
        public bool Add(string ime, string prezime, string oib, string jmbg, int? spolID, string ulicaKucniBroj, string naselje, string postanskiBrojID, 
                        DateTime? datumRodjenja, string id_opcine, int? id_vrsta_veze, bool aktivan, string imeRoditelj, string prezimeRoditelj, string oibRoditelj, string IBANROditelj)
        {
            if (!ValidateDataInput(null, ime, prezime, oib, jmbg, id_vrsta_veze, imeRoditelj, prezimeRoditelj, oibRoditelj, IBANROditelj))
                return false;

            UF_Ucenik ucenik = new UF_Ucenik();

            ucenik.Ime = ime;
            ucenik.Prezime = prezime;
            ucenik.OIB = oib;
            ucenik.TS = DateTime.Now;
            ucenik.JMBG = Utils.Tools.ReturnNULLIfEmpty(jmbg);
            ucenik.SpolID = spolID;
            ucenik.UlicaKucniBroj = Utils.Tools.ReturnNULLIfEmpty(ulicaKucniBroj);
            ucenik.Naselje = naselje;
            ucenik.PostanskiBrojID = Utils.Tools.ReturnNULLIfEmpty(postanskiBrojID);
            ucenik.DatumRodjenja = datumRodjenja;
            ucenik.Preneseno = false;
            ucenik.ID_Opcina = Utils.Tools.ReturnNULLIfEmpty(id_opcine);
            ucenik.ID_VrstaObiteljskeVeze = (int)id_vrsta_veze;
            ucenik.Aktivan = aktivan;
            ucenik.ImeRoditelj = imeRoditelj;
            ucenik.PrezimeRoditelj = prezimeRoditelj;
            ucenik.OIBRoditelj = oibRoditelj;
            ucenik.IBANRoditelj = IBANROditelj;

            base.Database.UF_Ucenik.AddObject(ucenik);

            return true;
        }

        /// <summary>
        /// editiranje postojeceg reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ime"></param>
        /// <param name="prezime"></param>
        /// <param name="oib"></param>
        /// <param name="jmbg"></param>
        /// <param name="spolID"></param>
        /// <param name="ulicaKucniBroj"></param>
        /// <param name="naselje"></param>
        /// <param name="postanskiBrojID"></param>
        /// <param name="datumRodjenja"></param>
        /// <returns></returns>
        public bool Update(int id, string ime, string prezime, string oib, string jmbg, int? spolID, string ulicaKucniBroj, string naselje, string postanskiBrojID,
                            DateTime? datumRodjenja, string id_opcine, int? id_vrsta_veze, bool aktivan, string imeRoditelj, string prezimeRoditelj, string oibRoditelj, string IBANRoditelj)
        {
            if (!ValidateDataInput(id, ime, prezime, oib, jmbg, id_vrsta_veze, imeRoditelj, prezimeRoditelj, oibRoditelj, IBANRoditelj))
                return false;

            UF_Ucenik ucenik = base.Database.UF_Ucenik.SingleOrDefault(u => u.ID == id);

            ucenik.Ime = ime;
            ucenik.Prezime = prezime;
            ucenik.OIB = oib;
            ucenik.TS = DateTime.Now;
            ucenik.JMBG = Utils.Tools.ReturnNULLIfEmpty(jmbg);
            ucenik.SpolID = spolID;
            ucenik.UlicaKucniBroj = Utils.Tools.ReturnNULLIfEmpty(ulicaKucniBroj);
            ucenik.Naselje = naselje;
            ucenik.PostanskiBrojID = Utils.Tools.ReturnNULLIfEmpty(postanskiBrojID);
            ucenik.DatumRodjenja = datumRodjenja;
            ucenik.ID_Opcina = Utils.Tools.ReturnNULLIfEmpty(id_opcine);
            ucenik.ID_VrstaObiteljskeVeze = (int)id_vrsta_veze;
            ucenik.ImeRoditelj = imeRoditelj;
            ucenik.PrezimeRoditelj = prezimeRoditelj;
            ucenik.OIBRoditelj = oibRoditelj;
            ucenik.Aktivan = aktivan;
            ucenik.IBANRoditelj = IBANRoditelj;

            UpdateUceniciPartneri(oib, aktivan);

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

            UF_Ucenik ucenik = base.Database.UF_Ucenik.SingleOrDefault(u => u.ID == id);

            base.Database.UF_Ucenik.DeleteObject(ucenik);

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
            catch
            {
                return false;
            }
        }

        public void PrijenosUceniciPartneri(int id, string naziv, string mb, string mjesto, string ulica, string mail, string oib, string fax, string telefon, string ziro_1, string aktivan)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into Partner (IDPARTNER, NAZIVPARTNER, PARTNERMJESTO, PARTNERULICA, PARTNEROIB, PARTNERFAX, PARTNERTELEFON, PARTNERZIRO1, Ucenik, MB, PARTNEREMAIL, PARTNERZIRO2) " +
                                  "Values (@IDPARTNER, @NAZIVPARTNER, @PARTNERMJESTO, @PARTNERULICA, @PARTNEROIB, @PARTNERFAX, @PARTNERTELEFON, @PARTNERZIRO1, @Ucenik, @MB, @PARTNEREMAIL, @PARTNERZIRO2)";

            sqlUpit.Parameters.Add(new SqlParameter("@IDPARTNER", id));
            sqlUpit.Parameters.Add(new SqlParameter("@NAZIVPARTNER", naziv));
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNERMJESTO", mjesto));
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNERULICA", ulica));
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNEROIB", oib));
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNERFAX", fax));
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNERTELEFON", telefon));
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNERZIRO1", ziro_1));
            sqlUpit.Parameters.Add(new SqlParameter("@Ucenik", 1));
            sqlUpit.Parameters.Add(new SqlParameter("@MB", mb));
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNEREMAIL", mail));
            //Da ne sirimo tablicu sa dodatnom kolonom ovdje upisujem aktivnost ucenika jel oni ne koriste ziro racune 
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNERZIRO2", aktivan));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch (Exception greska)
            {
                MessageBox.Show("Dogodila se greška prilikom prijenosa učenika u partnere\n" + greska);
            }
        }

        public void UpdateUceniciPartneri(int id, string naziv, string mb, string mjesto, string ulica, string mail, string oib, string fax, string telefon, string ziro_1, string aktivan)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update Partner Set NAZIVPARTNER = @NAZIVPARTNER, PARTNERMJESTO = @PARTNERMJESTO, PARTNERULICA = @PARTNERULICA, PARTNERFAX = @PARTNERFAX, " +
                    "PARTNERTELEFON = @PARTNERTELEFON, PARTNERZIRO1 = @PARTNERZIRO1, MB = @MB, PARTNEREMAIL = @PARTNEREMAIL, PARTNERZIRO2 = @PARTNERZIRO2 Where PARTNEROIB = @PARTNEROIB";

            sqlUpit.Parameters.Add(new SqlParameter("@NAZIVPARTNER", naziv));
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNERMJESTO", mjesto));
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNERULICA", ulica));
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNEROIB", oib));
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNERFAX", fax));
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNERTELEFON", telefon));
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNERZIRO1", ziro_1));
            sqlUpit.Parameters.Add(new SqlParameter("@MB", mb));
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNEREMAIL", mail));
            //Da ne sirimo tablicu sa dodatnom kolonom ovdje upisujem aktivnost ucenika jel oni ne koriste ziro racune 
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNERZIRO2", aktivan));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch (Exception greska)
            {
                MessageBox.Show("Dogodila se greška prilikom prijenosa učenika u partnere\n" + greska);
            }
        }

        public void UpdateUceniciPartneri(string oib, bool aktivan)
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Update Partner Set PARTNERZIRO2 = @PARTNERZIRO2 Where PARTNEROIB = @PARTNEROIB";

            sqlUpit.Parameters.Add(new SqlParameter("@PARTNEROIB", oib));
            //Da ne sirimo tablicu sa dodatnom kolonom ovdje upisujem aktivnost ucenika jel oni ne koriste ziro racune 
            sqlUpit.Parameters.Add(new SqlParameter("@PARTNERZIRO2", aktivan.ToString()));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch { }
        }
        
        public void SetFlagPreneseniUcenik()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update UF_Ucenik Set Preneseno = @Preneseno";

            sqlUpit.Parameters.Add(new SqlParameter("@Preneseno", true));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch (Exception greska)
            {
                MessageBox.Show("Dogodila se greška prilikom prijenosa učenika u partnere\nSetiranje prenešenih partnera je neuspješno.\n" + greska);
            }
        }

        #endregion

        #region DohvatPodataka

        /// <summary>
        /// dohvat ucenika po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UF_Ucenik GetUcenik(int id)
        {
            return base.Database.UF_Ucenik.SingleOrDefault(u => u.ID == id);
        }

        /// <summary>
        /// dohvat svih ucenika
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UF_Ucenik> GetUceniciAll()
        {
            return base.Database.UF_Ucenik.AsEnumerable();
        }

        /// <summary>
        /// dohvat podatak za prikaz u gridu
        /// </summary>
        /// <returns></returns>
        public object GetUceniciMainGrid()
        {
            if (!UcenickoFakturiranje.UI.MaticniPodaci.UcenikFormPregled.vrsta_osobe)
            {
                return (from u in base.Database.UF_Ucenik
                        where u.ID_VrstaObiteljskeVeze == 1
                        orderby u.ID
                        select new
                        {
                            u.ID,
                            ImePrezime = u.Prezime + " " + u.Ime,
                            u.OIB,
                            u.JMBG,
                            Spol = u.SPOL.NAZIVSPOL,
                            u.UlicaKucniBroj,
                            u.Naselje,
                            PostanskiBroj = u.PostanskiBrojID + " - " + u.POSTANSKIBROJEVI.NAZIVPOSTE,
                            u.DatumRodjenja,
                            u.Preneseno,
                            u.Aktivan
                        }).AsEnumerable();
            }
            else
            {
                return (from u in base.Database.UF_Ucenik
                        where u.ID_VrstaObiteljskeVeze != 1
                        orderby u.ID
                        select new
                        {
                            u.ID,
                            ImePrezime = u.Prezime + " " + u.Ime,
                            u.OIB,
                            u.JMBG,
                            Spol = u.SPOL.NAZIVSPOL,
                            u.UlicaKucniBroj,
                            u.Naselje,
                            PostanskiBroj = u.PostanskiBrojID + " - " + u.POSTANSKIBROJEVI.NAZIVPOSTE,
                            u.DatumRodjenja,
                            u.Preneseno,
                            u.Aktivan
                        }).AsEnumerable();
            }
            
        }

        /// <summary>
        /// dohvat ucenika za razredno odjeljnje
        /// </summary>
        /// <param name="razrednoOdjeljenjeID"></param>
        /// <returns></returns>
        public object GetUceniciForAddingToRazrednoOdjeljenje(int? razrednoOdjeljenjeID)
        {
            Entities database = base.Database;

            return (from u in database.UF_Ucenik
                    where !(from ro in database.UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik
                            where ro.UstanovaSkolskaGodinaRazredOdjeljenjeID == (razrednoOdjeljenjeID ?? 0)
                            select ro.UcenikID).Contains(u.ID)
                    orderby u.Prezime + " " + u.Ime
                    select new
                    {
                        u.ID,
                        ImePrezime = u.Prezime + " " + u.Ime,
                        u.OIB,
                        Spol = u.SPOL.NAZIVSPOL,
                        u.DatumRodjenja,
                        u.Aktivan,
                        u.ID_VrstaObiteljskeVeze
                    }).Where(x => x.Aktivan == true && x.ID_VrstaObiteljskeVeze == 1).AsEnumerable();
        }

        /// <summary>
        /// dohvat maksimalnod id-a
        /// </summary>
        /// <returns></returns>
        public int GetMaxPartnerID()
        {
            int id = 0;

            DataTable dtMaxID = client.GetDataTable("SELECT MAX(IDPARTNER) From PARTNER");

            try
            {
                if (dtMaxID.Rows[0][0] != null)
                    id = Convert.ToInt32(dtMaxID.Rows[0][0]) + 1;
                else
                    id = 1;
            }
            catch 
            {
                id = 1;
            }

            return id;
        }


        public DataTable GetOpcine()
        {
            DataTable dt = client.GetDataTable("Select IDOPCINE AS ID, (IDOPCINE + ' | ' + NAZIVOPCINE) As Naziv From OPCINA");
            return dt;
        }

        public DataTable GetVrsteVeza(bool vrsta)
        {
            DataTable dt = new DataTable();

            if (vrsta)
            {
                dt = client.GetDataTable("Select ID, Naziv From UF_VrsteObiteljskihVeza Where ID IN (2,4)");
            }
            else
            {
                dt = client.GetDataTable("Select ID, Naziv From UF_VrsteObiteljskihVeza Where ID = 1");
            }
            return dt;
        }

        #endregion

        public static int pSelectedIndex
        {
            get;
            set;
        }

        internal bool NotExistPartner(string oib)
        {
            DataTable dt = client.GetDataTable("Select IDPARTNER From PARTNER Where PARTNEROIB = '" + oib + "'");

            if(dt.Rows.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
