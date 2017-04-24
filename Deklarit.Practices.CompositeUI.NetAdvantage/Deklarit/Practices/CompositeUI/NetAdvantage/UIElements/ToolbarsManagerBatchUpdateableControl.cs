namespace Deklarit.Practices.CompositeUI.NetAdvantage.UIElements
{
    using Deklarit.Practices.CompositeUI.Services;
    using Infragistics.Win.UltraWinToolbars;
    using System;

    public class ToolbarsManagerBatchUpdateableControl : IBatchUpdateableControl
    {
        private UltraToolbarsManager m_ToolBase;

        public ToolbarsManagerBatchUpdateableControl(UltraToolbarsManager control)
        {
            this.m_ToolBase = control;
        }

        public void BeginUpdate()
        {
            this.m_ToolBase.BeginUpdate();
        }

        public void EndUpdate()
        {
            this.m_ToolBase.EndUpdate();
        }
    }
}

