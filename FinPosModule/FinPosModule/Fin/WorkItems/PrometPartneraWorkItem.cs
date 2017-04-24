namespace FinPosModule.Fin.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;

    public class PrometPartneraWorkItem : MdiWorkItemBase
    {
        public PrometPartneraWorkItem() : base("PrometPartneraWorkItem", new PrometPartneraSmartPart())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("PrometPartnera") {
                Text = "Promet po partnerima",
                IsCategory = true,
                Site = "MainShellPanel"
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("Kreiraj") {
                Text = "Kreiraj izvještaj",
                Site = "MainShellPanel.PrometPartnera",
                Image = ImageResourcesNew.table
            };
            this.UICommandDefinitionContainer.Add(definition);
        }
    }
}

