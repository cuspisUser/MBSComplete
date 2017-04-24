using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class RadnaMjesta : Base
    {
        public RadnaMjesta()
            : base()
        {
        }

        #region DohvatPodataka

        /// <summary>
        /// dohvat radnih mjesta po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RADNOMJESTO GetRadnoMjesto(int id)
        {
            return base.Database.RADNOMJESTO.SingleOrDefault(r => r.IDRADNOMJESTO == id);
        }

        /// <summary>
        /// dohvat svih radnih mjesta
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RADNOMJESTO> GetRadnaMjestaAll()
        {
            return base.Database.RADNOMJESTO.AsEnumerable();
        }

        /// <summary>
        /// dohvat radnih mjesta za comobox
        /// </summary>
        /// <returns></returns>
        public object GetRadnaMjestaComboBox()
        {
            return (from r in base.Database.RADNOMJESTO
                    orderby r.NAZIVRADNOMJESTO
                    select new
                    {
                        ID = r.IDRADNOMJESTO,
                        RadnoMjesto = r.NAZIVRADNOMJESTO
                    }).AsEnumerable();
        }

        #endregion
    }
}
