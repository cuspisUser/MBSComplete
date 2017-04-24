using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;
using System.Data;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class ProizvodiGrupeProizvodaStavke : Base
    {
        public ProizvodiGrupeProizvodaStavke()
            : base()
        {
        }

        #region ProvjeraIspravnostiUnosa

        /// <summary>
        /// provjera ispravnosti unosa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="proizvodID"></param>
        /// <param name="proizvodStavkaID"></param>
        /// <returns></returns>
        private bool ValidateDataInput(int? id, int proizvodID, int proizvodStavkaID)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // PROIZVOD & PROIZVOD STAVKA
            if (base.Database.UF_ProizvodStavka.Where(s => s.ProizvodID == proizvodID && s.ProizvodStavkaID == proizvodStavkaID && s.ID != (id ?? 0)).Count() > 0)
            {
                this.ValidationMessages.Add(new DataValidationException("UltraGridProizvodi", "- Odbarani POD-PROIZVOD je već dodjeljen navedenom proizvodu"));
            }

            return (this.ValidationMessages.Count == 0);
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// Unos novog reda u bazu
        /// </summary>
        /// <param name="proizvodID"></param>
        /// <param name="proizvodStavkaID"></param>
        /// <returns></returns>
        public bool Add(int proizvodID, int proizvodStavkaID)
        {
            if (!ValidateDataInput(null, proizvodID, proizvodStavkaID))
                return false;

            UF_ProizvodStavka proizvodStavka = new UF_ProizvodStavka();

            proizvodStavka.ProizvodID = proizvodID;
            proizvodStavka.ProizvodStavkaID = proizvodStavkaID;
            proizvodStavka.TS = DateTime.Now;

            base.Database.UF_ProizvodStavka.AddObject(proizvodStavka);

            return true;
        }

        /// <summary>
        /// Editiranje postojeceg reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="proizvodID"></param>
        /// <param name="proizvodStavkaID"></param>
        /// <returns></returns>
        public bool Update(int id, int proizvodID, int proizvodStavkaID)
        {
            if (!ValidateDataInput(id, proizvodID, proizvodStavkaID))
                return false;

            UF_ProizvodStavka proizvodStavka = base.Database.UF_ProizvodStavka.SingleOrDefault(s => s.ID == id);

            proizvodStavka.ProizvodID = proizvodID;
            proizvodStavka.ProizvodStavkaID = proizvodStavkaID;
            proizvodStavka.TS = DateTime.Now;

            return true;
        }

        /// <summary>
        /// brisanje reda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            UF_ProizvodStavka proizvodStavka = base.Database.UF_ProizvodStavka.SingleOrDefault(s => s.ID == id);

            base.Database.UF_ProizvodStavka.DeleteObject(proizvodStavka);

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
        /// dohvat porizvoda stavak po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UF_ProizvodStavka GetProizvodStavka(int id)
        {
            return base.Database.UF_ProizvodStavka.SingleOrDefault(s => s.ID == id);
        }

        /// <summary>
        /// dohvat svih porizvoda stavaka
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UF_ProizvodStavka> GetProizvodiStavkeAll()
        {
            return base.Database.UF_ProizvodStavka.AsEnumerable();
        }

        /// <summary>
        /// dohvat podataka za glavni grid
        /// </summary>
        /// <param name="proizvodID"></param>
        /// <returns></returns>
        public DataSet GetProizvodiStavkeMainGrid(int? proizvodID)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            string query = "SELECT 'True' as SEL, UF_Proizvod.ID, UF_Proizvod.Naziv, JEDINICAMJERE.NAZIVJEDINICAMJERE as JedinicaMjere " +
                           "FROM UF_Proizvod INNER JOIN UF_ProizvodStavka ON UF_Proizvod.ID = UF_ProizvodStavka.ProizvodStavkaID " +
                           "INNER JOIN JEDINICAMJERE ON UF_Proizvod.JedinicaMjereID = JEDINICAMJERE.IDJEDINICAMJERE " +
                           " WHERE (UF_ProizvodStavka.ProizvodID = " + proizvodID + ")";
            DataSet ds = client.GetDataSet(query);

            return ds;
        }

        #endregion

        public static int pSelectedIndex
        {
            get;
            set;
        }
    }
}
