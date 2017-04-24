namespace NetAdvantage.WorkItems
{
    using CrystalDecisions.CrystalReports.Engine;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using NetAdvantage.SmartParts;
    using CrystalDecisions.Windows.Forms;

    public class PreviewReportWorkItem2 : MdiWorkItemBase
    {
        private CrystalReportViewer m_izvjestaj;

        public PreviewReportWorkItem2() : base("PreviewReportWorkItem2", new PreviewReport())
        {
        }

        public CrystalReportViewer Izvjestaj
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

