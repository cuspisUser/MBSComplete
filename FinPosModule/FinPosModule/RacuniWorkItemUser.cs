namespace FinPosModule
{
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;

    public class RacuniWorkItemUser : MdiWorkItemBase
    {
        public RacuniWorkItemUser() : base("RacuniWorkItemUser", new RacuniSmartPartUser())
        {
        }
    }
}

