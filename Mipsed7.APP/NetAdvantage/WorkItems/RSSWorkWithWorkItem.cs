using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.WorkItems;
using Deklarit.Resources;

using NetAdvantage.SmartParts;
using Mipsed7.APP.NetAdvantage.SmartParts;

namespace Mipsed7.APP.NetAdvantage.WorkItems
{
    public class RSSWorkWithWorkItem : WorkWithWorkItemBase<RSSWorkWith>
    {
        public RSSWorkWithWorkItem()
            : base("RSS.Vijesti")
        {

        }
    }
}
