namespace Deklarit.Practices.CompositeUI.NetAdvantage.MenuEntryAdapters
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Services;
    using Microsoft.Practices.CompositeUI;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public class ToolStripVerticalToolbarAdapter : IUICommandDefinitionVerticalToolPanelAdapterService, IUICommandDefinitionAdapterService
    {
        public void AddElements(WorkItem workItem, IEnumerable<UICommandDefinition> menuEntryEnumerable, Control host)
        {
            NetAdvantageUIElementFactory.AddToolStripElements(workItem, menuEntryEnumerable, UICommandPlacement.VerticalToolPanel, host);
        }
    }
}

