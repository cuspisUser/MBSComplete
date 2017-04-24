
using DDModule.DDModule;
using Microsoft.Practices.CompositeUI;
using System;

namespace DDModule.NetAdvantage.Controllers
{

    public class KratkaRekapController : Controller
    {
        private string m_izvjestaj;

        public KratkaRekapWorkItem KratkaRekapWorkItem
        {
            get
            {
                return (KratkaRekapWorkItem) this.WorkItem;
            }
        }

        public string obracun
        {
            get
            {
                return ((KratkaRekapWorkItem) this.WorkItem).Obracun;
            }
            set
            {
                this.m_izvjestaj = value;
            }
        }
    }
}

