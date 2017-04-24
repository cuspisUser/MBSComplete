
using Deklarit.Practices.CompositeUI.WorkItems;
using System;
using FinPosModule.Ira;


namespace FinPosModule
{

    public class IraUserWorkItem : MdiWorkItemBase
    {
        public IraUserWorkItem()
            : base("Test", new IraSmartPart())
        {
        }
    }
}

