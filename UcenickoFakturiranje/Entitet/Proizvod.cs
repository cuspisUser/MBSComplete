using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UcenickoFakturiranje.Entitet
{
    public class Proizvod
    {
        public int? ID;
        public string Naziv;
        public int? JedinicaMjereID;
        public string JedinicaMjere;
        public int? TipKolicineID;
        public string TipKolicine;
        public bool IsGrupa;

        public Proizvod(int? ID, string Naziv, int? JedinicaMjereID, string JedinicaMjere, int? TipKolicineID, string TipKolicine, bool isGrupa) 
        {
            this.ID = ID;
            this.Naziv = Naziv;
            this.JedinicaMjereID = JedinicaMjereID;
            this.JedinicaMjere = JedinicaMjere;
            this.TipKolicineID = TipKolicineID;
            this.TipKolicine = TipKolicine;
            this.IsGrupa = isGrupa;
        }

    }
}
