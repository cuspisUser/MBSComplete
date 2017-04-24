using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.WorkItems;
using NetAdvantage.SmartParts;

namespace PlacaModule.PlacaModule
{
    public class RasporedWorkWithWorkItem : WorkWithWorkItemBase<RasporedWorkWith>
    {
        public RasporedWorkWithWorkItem()
            : base("Raspored sati")
        {

        }
    }
}
