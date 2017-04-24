using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;
using System.Data.Objects;
using System.Data.SqlClient;
using Mipsed7.DataAccessLayer;
using System.Data;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class UstanoveSkolskeGodineRazrednaOdjeljenjaUcenici : Base
    {
        SqlClient client = null;
        public UstanoveSkolskeGodineRazrednaOdjeljenjaUcenici()
            : base()
        {
            client = new SqlClient();
        }

        #region ObjectValidation

        private bool ValidateDataInput(int? id, int ustanovaSkolskaGodinaRezredOdjeljenjeID, int ucenikID)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // RAZREDNO ODJELJENJE - UČENIK - unique
            if (ustanovaSkolskaGodinaRezredOdjeljenjeID > -1 && ucenikID > -1)
            {
                // RAZREDNO ODJELJENJE
                if (base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik.Where(u => u.UstanovaSkolskaGodinaRazredOdjeljenjeID == ustanovaSkolskaGodinaRezredOdjeljenjeID &&
                    u.UcenikID == ucenikID && u.ID != (id ?? 0)).Count() > 0)
                {
                    this.ValidationMessages.Add(new DataValidationException(null, "- UČENIK je već dodjeljen odabranom razrednom odjeljenju"));
                }
            }

            return (this.ValidationMessages.Count == 0);
        }

        private bool ValidateConstraints(int id)
        {
            this.ValidationMessages = new List<DataValidationException>();

            // No validation rules for now...
            return (this.ValidationMessages.Count == 0);
        }

        #endregion

        #region ObjectPersistance

        public bool Add(int ustanovaSkolskaGodinaRazrednoOdjeljenjeID, int ucenikID)
        {
            if (!ValidateDataInput(null, ustanovaSkolskaGodinaRazrednoOdjeljenjeID, ucenikID))
                return false;

            UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik ustanovaSkolskaGodinaRazrednoOdjeljenjeUcenik = new UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik();

            ustanovaSkolskaGodinaRazrednoOdjeljenjeUcenik.UstanovaSkolskaGodinaRazredOdjeljenjeID = ustanovaSkolskaGodinaRazrednoOdjeljenjeID;
            ustanovaSkolskaGodinaRazrednoOdjeljenjeUcenik.UcenikID = ucenikID;

            base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik.AddObject(ustanovaSkolskaGodinaRazrednoOdjeljenjeUcenik);

            return true;
        }

        public bool Update(int? id, int ustanovaSkolskaGodinaRazrednoOdjeljenjeID, int ucenikID)
        {
            if (!ValidateDataInput(id, ustanovaSkolskaGodinaRazrednoOdjeljenjeID, ucenikID))
                return false;

            UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik ustanovaSkolskaGodinaRazrednoOdjeljenjeUcenik = base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik.SingleOrDefault(u => u.ID == ucenikID);

            ustanovaSkolskaGodinaRazrednoOdjeljenjeUcenik.UstanovaSkolskaGodinaRazredOdjeljenjeID = ustanovaSkolskaGodinaRazrednoOdjeljenjeID;
            ustanovaSkolskaGodinaRazrednoOdjeljenjeUcenik.UcenikID = ucenikID;

            return true;
        }

        public bool Delete(int id)
        {
            if (!ValidateConstraints(id))
                return false;

            //03.09.2015 Prilikom brisanja ucenika iz razreda prvo se taj ucenik mice iz svih predlozaaka
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.CommandText = "Delete From UF_PredlosciStavke Where IDUcenik = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", id));

            try
            {
                sqlUpit.ExecuteNonQuery();

                UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik ustanovaSkolskaGodinaRazredOdjeljenjeUcenik = base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik.SingleOrDefault(rou => rou.ID == id);
                base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik.DeleteObject(ustanovaSkolskaGodinaRazredOdjeljenjeUcenik);
            }
            catch
            {
                return false;
            }

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

        public UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik GetUstanovaSkolskaGodinaRazredOdjeljenjeUcenik(int id)
        {
            return base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik.SingleOrDefault(rou => rou.ID == id);
        }

        public IEnumerable<UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik> GetUstanovaSkolskaGodinaRazredOdjeljenjeUcenikAll()
        {
            return base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik.AsEnumerable();
        }

        public object GetUstanovaSkolskaGodinaRazredOdjeljenjeUcenikMainGrid(int ustanovaSkolskaGodinaRazrednoOdjeljenjeID)
        {
            return (from u in base.Database.UF_UstanovaSkolskaGodinaRazredOdjeljenjeUcenik
                    where u.UstanovaSkolskaGodinaRazredOdjeljenjeID == ustanovaSkolskaGodinaRazrednoOdjeljenjeID
                    orderby u.UF_Ucenik.Prezime + " " + u.UF_Ucenik.Ime, u.UF_Ucenik.OIB
                    select new 
                    {
                        u.ID,
                        Ucenik = u.UF_Ucenik.Prezime + " " + u.UF_Ucenik.Ime,
                        u.UF_Ucenik.OIB,
                        Spol = u.UF_Ucenik.SPOL.NAZIVSPOL
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
