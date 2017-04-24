namespace FinPosModule
{
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;

    public class GKWorkItem : MdiWorkItemBase
    {
        public GKWorkItem() : base("GKWorkItem", new GKSmartPart())
        {
        }
    }
}

