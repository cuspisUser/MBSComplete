namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;

    public class PripremaPlaceWorkItem : MdiWorkItemBase
    {
        public PripremaPlaceWorkItem() : base("PripremaPlaceCustom", new PripremaPlaceSmartPart())
        {
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}

