namespace NetAdvantage.Controllers
{
    using CrystalDecisions.CrystalReports.Engine;
    using Microsoft.Practices.CompositeUI;
    using NetAdvantage.WorkItems;
    using System;

    public class PreviewReportControler : Controller
    {
        private ReportDocument m_izvjestaj;

        public ReportDocument Izvjestaj
        {
            get
            {
                return ((NetAdvantage.WorkItems.PreviewReportWorkItem) this.WorkItem).Izvjestaj;
            }
            set
            {
                this.m_izvjestaj = value;
            }
        }

        public NetAdvantage.WorkItems.PreviewReportWorkItem PreviewReportWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.PreviewReportWorkItem) this.WorkItem;
            }
        }
    }
}

