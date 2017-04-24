using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class PostanskiBrojevi : Base
    {
        public PostanskiBrojevi()
            : base()
        {
        }

        #region DohvatPodataka

        /// <summary>
        /// Dohvat postanskih brojeva po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public POSTANSKIBROJEVI GetPostanskiBroj(string id)
        {
            return base.Database.POSTANSKIBROJEVI.SingleOrDefault(p => p.POSTANSKIBROJ == id);
        }

        /// <summary>
        /// Dohvat svih postanskih brojeva
        /// </summary>
        /// <returns></returns>
        public IEnumerable<POSTANSKIBROJEVI> GetPostanskiBrojeviAll()
        {
            return base.Database.POSTANSKIBROJEVI.AsEnumerable();
        }

        /// <summary>
        /// Dohvat postanskih za combobox
        /// </summary>
        /// <returns></returns>
        public object GetPostanskiBrojeviComboBox()
        {
            return (from p in base.Database.POSTANSKIBROJEVI
                    orderby p.POSTANSKIBROJ
                    select new
                    {
                        ID = p.POSTANSKIBROJ,
                        PostanskiBroj = p.POSTANSKIBROJ + " - " + p.NAZIVPOSTE
                    }).AsEnumerable();
        }

        #endregion
    }
}
