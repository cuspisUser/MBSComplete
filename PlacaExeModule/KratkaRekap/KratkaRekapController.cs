namespace KratkaRekapNamespace
{
    using Microsoft.Practices.CompositeUI;
    using System;
    using NetAdvantage.SmartParts;

    public class KratkaRekapController : Controller
    {
        private string m_izvjestaj;
        private string m_opisobracuna;

        public KratkaRekapNamespace.KratkaRekapWorkItem KratkaRekapWorkItem
        {
            get
            {
                return (KratkaRekapNamespace.KratkaRekapWorkItem)this.WorkItem;
            }
        }

        public string obracun
        {
            get
            {
                return ((KratkaRekapNamespace.KratkaRekapWorkItem)this.WorkItem).Obracun;
            }
            set
            {
                this.m_izvjestaj = value;
            }
        }

        public string opis
        {
            get
            {
                return ((KratkaRekapNamespace.KratkaRekapWorkItem)this.WorkItem).opisobracuna;
            }
            set
            {
                this.m_opisobracuna = value;
            }
        }

        public string opisobracuna
        {
            get
            {
                return ((KratkaRekapNamespace.KratkaRekapWorkItem)this.WorkItem).Obracun;
            }
            set
            {
                this.m_opisobracuna = value;
            }
        }
    }
}

