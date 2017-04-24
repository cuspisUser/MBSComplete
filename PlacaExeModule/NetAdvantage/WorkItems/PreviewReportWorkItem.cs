namespace NetAdvantage.WorkItems
{
    using CrystalDecisions.CrystalReports.Engine;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using NetAdvantage.SmartParts;

    public class PreviewReportWorkItem : MdiWorkItemBase
    {
        private ReportDocument m_izvjestaj;

        public PreviewReportWorkItem() : base("PreviewReportWorkItem", new PreviewReport())
        {
        }

        public ReportDocument Izvjestaj
        {
            get
            {
                return this.m_izvjestaj;
            }
            set
            {
                this.m_izvjestaj = value;
            }
        }
    }
}

