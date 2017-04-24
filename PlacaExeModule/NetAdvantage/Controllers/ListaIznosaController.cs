namespace NetAdvantage.Controllers
{
    using Microsoft.Practices.CompositeUI;
    using System;

    public class ListaIznosaController : Controller
    {
        public string obracun;

        public string kojiobracun
        {
            get
            {
                return this.obracun;
            }
            set
            {
                this.obracun = value;
            }
        }
    }
}

