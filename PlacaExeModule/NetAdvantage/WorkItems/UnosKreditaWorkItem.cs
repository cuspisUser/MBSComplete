namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using NetAdvantage.SmartParts;

    public class UnosKreditaWorkItem : MdiWorkItemBase
    {
        public UnosKreditaWorkItem() : base("UnosKreditaSmartPart", new UnosKreditaSmartPart())
        {
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}

