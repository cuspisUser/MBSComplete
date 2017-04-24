using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class JedinicaMjere : Base
    {
        public JedinicaMjere() 
            : base()
        {
        }

        #region DohvatPodataka

        /// <summary>
        /// dohvat podataka po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JEDINICAMJERE GetJedinicaMjere(int id)
        {
            return base.Database.JEDINICAMJERE.SingleOrDefault(j => j.IDJEDINICAMJERE == id);
        }

        /// <summary>
        /// dohvat svih podataka
        /// </summary>
        /// <returns></returns>
        public IEnumerable<JEDINICAMJERE> GetJediniceMjereAll()
        {
            return base.Database.JEDINICAMJERE.AsEnumerable();
        }

        /// <summary>
        /// Punjenje comboboxa jedinica mjere
        /// </summary>
        /// <returns></returns>
        public object GetJediniceMjereComboBox()
        {
            return (from j in base.Database.JEDINICAMJERE
                    orderby j.IDJEDINICAMJERE
                    select new
                    {
                       ID = j.IDJEDINICAMJERE,
                       Naziv = j.NAZIVJEDINICAMJERE
                       
                    }).AsEnumerable();
        }

        #endregion
    }
}
