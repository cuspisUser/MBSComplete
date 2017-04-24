using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class ProizvodiGrupeProizvodaTipKolicine : Base
    {
        public ProizvodiGrupeProizvodaTipKolicine()
            : base()
        {
        }

        #region DohvatPodataka

        /// <summary>
        /// dohvat podataka po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UF_ProizvodTipKolicine GetTipKolicine(int id)
        {
            return base.Database.UF_ProizvodTipKolicine.SingleOrDefault(t => t.ID == id);
        }

        /// <summary>
        /// dohvat svih tipova kolicina
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UF_ProizvodTipKolicine> GetTipoviKolicineAll()
        {
            return base.Database.UF_ProizvodTipKolicine.AsEnumerable();
        }

        /// <summary>
        /// dohvat tipova kolicina za combobox
        /// </summary>
        /// <returns></returns>
        public object GetTipoviKolicineComboBox()
        {
            return (from t in base.Database.UF_ProizvodTipKolicine
                    orderby t.ID
                    select new
                    {
                        t.ID,
                        t.Naziv
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
