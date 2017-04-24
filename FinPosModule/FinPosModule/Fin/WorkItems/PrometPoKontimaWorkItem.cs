namespace FinPosModule.Fin.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;

    public class PrometPoKontimaWorkItem : MdiWorkItemBase
    {
        public PrometPoKontimaWorkItem() : base("PrometPoKontimaWorkItem", new PrometPoKontimaSmartPart())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Promet") {
                Text = "Promet po kontima",
                IsCategory = true,
                Site = "MainShellPanel"
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("Kreiraj") {
                Text = "Kreiraj izvještaj",
                Site = "MainShellPanel.Promet",
                Image = ImageResourcesNew.table
            };
            this.UICommandDefinitionContainer.Add(definition);
        }
    }
}

