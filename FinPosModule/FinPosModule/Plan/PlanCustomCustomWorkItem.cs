namespace FinPosModule.Plan
{
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;

    public class PlanCustomCustomWorkItem : MdiWorkItemBase
    {
        public PlanCustomCustomWorkItem() : base("PlanCustom", new PlanCustom())
        {
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}

