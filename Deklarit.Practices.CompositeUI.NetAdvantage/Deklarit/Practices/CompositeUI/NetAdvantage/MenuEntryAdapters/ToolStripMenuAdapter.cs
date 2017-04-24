namespace Deklarit.Practices.CompositeUI.NetAdvantage.MenuEntryAdapters
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Services;
    using Microsoft.Practices.CompositeUI;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public class ToolStripMenuAdapter : IUICommandDefinitionMenuAdapterService, IUICommandDefinitionAdapterService
    {
        public void AddElements(WorkItem workItem, IEnumerable<UICommandDefinition> menuEntryEnumerable, Control host)
        {
            NetAdvantageUIElementFactory.AddToolStripElements(workItem, menuEntryEnumerable, UICommandPlacement.Menu, host);
        }
    }
}

