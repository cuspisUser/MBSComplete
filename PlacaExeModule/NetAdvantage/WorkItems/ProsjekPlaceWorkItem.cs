namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using NetAdvantage.SmartParts;

    public class ProsjekPlaceWorkItem : MdiWorkItemBase
    {
        public ProsjekPlaceWorkItem() : base("ProsjekPlaceWorkItem", new ProsjekPlace())
        {
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}

