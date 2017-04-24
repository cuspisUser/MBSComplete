using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;
using System.Data;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class ProizvodiGrupeProizvoda : Base
    {
        public ProizvodiGrupeProizvoda()
            : base()
        {
        }

        #region ProvjeraIspravnostiUnosa

        /// <summary>
        /// Provjera ispravnosti unosa
        /// </summary>
        /// <param name="naziv"></param>
        /// <param name="tipKolicineID"></param>
        /// <param name="jedinicaMjereID"></param>
        /// <param name="stopa_poreza"></param>
        /// <param name="cijena"></param>
        /// <returns></returns>
        private bool ValidateDataInput(string naziv, string tipKolicineID, string jedinicaMjereID, string stopa_poreza, string cijena)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // NAZIV - not null
            if (string.IsNullOrEmpty(naziv))
            {
                this.ValidationMessages.Add(new DataValidationException("TextBoxNaziv", "- NAZIV je obavezno polje"));
            }

            // TIP KOLIČINE - not null
            if (tipKolicineID == null | tipKolicineID == string.Empty)
            {
                this.ValidationMessages.Add(new DataValidationException("ComboBoxTipObracunskeKolicine", "- TIP obračunske količine je obavezno polje"));
            }

            // TIP KOLIČINE - not null
            if (jedinicaMjereID == null | jedinicaMjereID == string.Empty)
            {
                this.ValidationMessages.Add(new DataValidationException("ComboBoxJedinicaMjere", "- Jedinica mjere je obavezno polje"));
            }

            // CIJENA - not null
            if (cijena == null | cijena == string.Empty)
            {
                this.ValidationMessages.Add(new DataValidationException("unmProizvodCijena", "- Cijena je obavezno polje"));
            }

            // STOPA POREZA - not null
            if (stopa_poreza == null | stopa_poreza == string.Empty)
            {
                this.ValidationMessages.Add(new DataValidationException("cmbProizvodPorez", "- Stopa poreza je obavezno polje"));
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

            // CJENIK STAVKA
            if (base.Database.UF_CjenikStavka.Where(s => s.ProizvodID == id).Count() > 0)
            {
                this.ValidationMessages.Add(new DataValidationException(null, "Odbijeno brisanje proizvoda jer je vezan uz stavku cjenika!"));
            }

            // PROIZVOD STAVKA
            if (base.Database.UF_ProizvodStavka.Where(s => s.ProizvodStavkaID == id).Count() > 0)
            {
                this.ValidationMessages.Add(new DataValidationException(null, "Odbijeno brisanje proizvoda jer je vezan uz grupu proizvoda!"));
            }

            return (this.ValidationMessages.Count == 0);
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// Unos novog reda u bazu
        /// </summary>
        /// <param name="naziv"></param>
        /// <param name="jedinicaMjereID"></param>
        /// <param name="tipKolicineID"></param>
        /// <param name="stopa_poreza"></param>
        /// <param name="cijena"></param>
        /// <param name="is_grupa"></param>
        /// <returns></returns>
        public bool Add(string naziv, string jedinicaMjereID, string tipKolicineID, string stopa_poreza, string cijena, bool is_grupa)
        {
            if (!ValidateDataInput(naziv, tipKolicineID, jedinicaMjereID, stopa_poreza, cijena))
                return false;

            UF_Proizvod proizvod = new UF_Proizvod();

            proizvod.Naziv = naziv;
            proizvod.JedinicaMjereID = Convert.ToInt32(jedinicaMjereID);
            proizvod.TipKolicineID = Convert.ToByte(tipKolicineID);
            proizvod.TS = DateTime.Now;
            proizvod.IsGrupa = is_grupa;
            proizvod.Cijena = Convert.ToDecimal(cijena);
            if (stopa_poreza != "")
                proizvod.PorezID = Convert.ToInt32(stopa_poreza);
            else
                proizvod.PorezID = null;

            base.Database.UF_Proizvod.AddObject(proizvod);

            return true;
        }

        /// <summary>
        /// Editiranje postojeceg reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="naziv"></param>
        /// <param name="jedinicaMjereID"></param>
        /// <param name="tipKolicineID"></param>
        /// <param name="stopa_poreza"></param>
        /// <param name="cijena"></param>
        /// <param name="is_grupa"></param>
        /// <returns></returns>
        public bool Update(int id, string naziv, string jedinicaMjereID, string tipKolicineID, string stopa_poreza, string cijena, bool is_grupa)
        {
            if (!ValidateDataInput(naziv, tipKolicineID, jedinicaMjereID, stopa_poreza, cijena))
                return false;

            UF_Proizvod proizvod = base.Database.UF_Proizvod.SingleOrDefault(p => p.ID == id);

            proizvod.Naziv = naziv;
            proizvod.JedinicaMjereID = Convert.ToInt32(jedinicaMjereID);
            proizvod.TipKolicineID = Convert.ToByte(tipKolicineID);
            proizvod.TS = DateTime.Now;
            proizvod.IsGrupa = is_grupa;
            proizvod.Cijena = Convert.ToDecimal(cijena);
            if (stopa_poreza != "")
                proizvod.PorezID = Convert.ToInt32(stopa_poreza);
            else
                proizvod.PorezID = null;

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

            UF_Proizvod proizvod = base.Database.UF_Proizvod.SingleOrDefault(p => p.ID == id);

            base.Database.UF_Proizvod.DeleteObject(proizvod);

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
        /// dohvat proizvoda po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UF_Proizvod GetProizvod(int id)
        {
            return base.Database.UF_Proizvod.SingleOrDefault(p => p.ID == id);
        }

        /// <summary>
        /// dohvat svih proizvoda
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UF_Proizvod> GetProizvodiAll()
        {
            return base.Database.UF_Proizvod.AsEnumerable();
        }

        /// <summary>
        /// Vraca maksimalni id
        /// </summary>
        /// <returns></returns>
        public int? GetMaxId() 
        {
            return base.Database.UF_Proizvod.Max(p => p.ID);
        }

        /// <summary>
        /// dohvat proizovda za prikaz u gridu
        /// </summary>
        /// <returns></returns>
        public object GetProizvodiMainGrid()
        {
            return (from p in base.Database.UF_Proizvod
                    orderby p.ID
                    select new
                    {
                        p.ID,
                        p.Naziv,
                        JedinicaMjere = p.JEDINICAMJERE.NAZIVJEDINICAMJERE,
                        TipObracunskeKolicine = p.UF_ProizvodTipKolicine.Naziv,
                        Grupa = p.IsGrupa
                    }).AsEnumerable();
        }

        /// <summary>
        /// dohvat proizvoda stavke
        /// </summary>
        /// <param name="proizvodID"></param>
        /// <returns></returns>
        public object GetProizvodiForAddingToGroupAsProizvodStavka(int? proizvodID)
        {
            Entities database = base.Database;

            return (from p in database.UF_Proizvod
                    where p.IsGrupa == false && !(from s in database.UF_ProizvodStavka
                                                             where s.ProizvodID == (proizvodID ?? 0)
                                                             select s.ProizvodStavkaID).Contains(p.ID)
                    orderby p.Naziv
                    select new
                    {
                        p.ID,
                        p.Naziv,
                        JedinicaMjere = p.JEDINICAMJERE.NAZIVJEDINICAMJERE
                    }).AsEnumerable();
        }

        public DataSet GetProizvodiOdaberList(int? proizvod)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
            string query = "SELECT 'False' as SEL, UF_Proizvod.ID, UF_Proizvod.Naziv, JEDINICAMJERE.NAZIVJEDINICAMJERE AS JedinicaMjere " +
                            " FROM		UF_Proizvod INNER JOIN " +
                            "                      JEDINICAMJERE ON UF_Proizvod.JedinicaMjereID = JEDINICAMJERE.IDJEDINICAMJERE " +
                            " WHERE     (UF_Proizvod.IsGrupa IS NULL OR UF_Proizvod.IsGrupa = 'False') " +
                            "		and UF_PROIZVOD.ID NOT IN (SELECT ProizvodStavkaID from UF_ProizvodStavka where ProizvodID = '" + proizvod + "') " +
                            "		and UF_PROIZVOD.ID <> '" + proizvod + "'";
            DataSet ds = new DataSet();
            DataTable dt = client.GetDataTable(query);
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>
        /// dohvat proizovoda za combobox
        /// </summary>
        /// <param name="proizvod_id"></param>
        /// <returns></returns>
        public object GetProizvodiComboBox(IList<int> proizvod_id)
        {
            return (from p in base.Database.UF_Proizvod
                        where !proizvod_id.Contains(p.ID)
                        orderby p.IsGrupa, p.Naziv
                        select new
                        {
                            ProizvodID = (p.ID),
                            Naziv = (p.IsGrupa ? "[GRUPA] " + p.Naziv : p.Naziv)
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
