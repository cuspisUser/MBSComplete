using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materijalno
{
    public class InventuraStavke
    {
        private int _iDStavke;       
        private int _iDInventure;        
        private int _iDProizvod;        
        private decimal _kolicinaZaliha;        
        private decimal _stvarnaKolicina;        

        public int IDStavke
        {
            get { return _iDStavke; }
            set { _iDStavke = value; }
        }        
        public int IDInventure
        {
            get { return _iDInventure; }
            set { _iDInventure = value; }
        }
        public int IDProizvod
        {
            get { return _iDProizvod; }
            set { _iDProizvod = value; }
        }
        public decimal KolicinaZaliha
        {
            get { return _kolicinaZaliha; }
            set { _kolicinaZaliha = value; }
        }
        public decimal StvarnaKolicina
        {
            get { return _stvarnaKolicina; }
            set { _stvarnaKolicina = value; }
        }


    }
}
