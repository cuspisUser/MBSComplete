namespace FinPosModule.NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;

    public class BlagajnaWorkItemUser : MdiWorkItemBase
    {
        public BlagajnaWorkItemUser() : base("BlagajnaSmartpart", new BlagajnaSmartPart())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Blagajna") {
                Text = "Blagajna",
                IsCategory = true,
                Site = "MainShellPanel"
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("OtvoriPostojecu") {
                Text = "Otvori postojeću blagajnu",
                Site = "MainShellPanel.Blagajna",
                Image = ImageResourcesNew.total_plan_cost
            };
            this.UICommandDefinitionContainer.Add(definition);
        }
    }
}

