using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;

namespace UcenickoFakturiranje.BusinessLogic
{
    class Porez : Base
    {
        public Porez() 
            : base()
        {
        }

        #region DohvatPodataka

        /// <summary>
        /// Dohvat poreza po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FINPOREZ GetPorez(int id)
        {
            FINPOREZ porez = base.Database.FINPOREZ.SingleOrDefault(j => j.FINPOREZIDPOREZ == id);
            return porez;
        }

        /// <summary>
        /// Dohvat svih poreza
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FINPOREZ> GetPorezAll()
        {
            return base.Database.FINPOREZ.AsEnumerable();
        }

        /// <summary>
        /// Dohvat poreza za combobox
        /// </summary>
        /// <returns></returns>
        public object GetPorezComboBox()
        {
            return (from j in base.Database.FINPOREZ
                    orderby j.FINPOREZIDPOREZ
                    select new
                    {
                        PorezID = j.FINPOREZIDPOREZ,
                        FINPOREZNAZIVPOREZ = j.FINPOREZNAZIVPOREZ
                       
                    }).AsEnumerable();
        }

        #endregion
    }
}
