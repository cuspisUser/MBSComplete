namespace FinPosModule
{
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;

    public class UraUserWorkItem : MdiWorkItemBase
    {
        public UraUserWorkItem() : base("UraUserWorkItem", new UraSmartPart())
        {
        }
    }
}

