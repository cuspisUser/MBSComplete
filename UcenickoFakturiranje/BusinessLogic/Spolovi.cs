using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class Spolovi : Base
    {
        public Spolovi()
            : base()
        {
        }

        #region DohvatPodataka

        /// <summary>
        /// dohvat spola po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SPOL GetSpol(int id)
        {
            return base.Database.SPOL.SingleOrDefault(s => s.IDSPOL == id);
        }

        /// <summary>
        /// dohvat svih spolova
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SPOL> GetSpoloviAll()
        {
            return base.Database.SPOL.AsEnumerable();
        }

        /// <summary>
        /// dohvat spolova za prikaz u gridu
        /// </summary>
        /// <returns></returns>
        public object GetSpoloviComboBox()
        {
            return (from s in base.Database.SPOL
                    orderby s.IDSPOL
                    select new
                    {
                        ID = s.IDSPOL,
                        Spol = s.NAZIVSPOL
                    }).AsEnumerable();
        }

        #endregion
    }
}
