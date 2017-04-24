namespace FinPosModule.Fin.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;

    public class DnevnikKnjizenjaWorkItem : MdiWorkItemBase
    {
        public DnevnikKnjizenjaWorkItem() : base("DnevnikKnjizenjaWorkItem", new DnevnikKnjizenjaSmartpart())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Dnevnik") {
                Text = "Dnevnik",
                IsCategory = true,
                Site = "MainShellPanel"
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("Kreiraj") {
                Text = "Kreiraj izvještaj",
                Site = "MainShellPanel.Dnevnik",
                Image = ImageResourcesNew.table
            };
            this.UICommandDefinitionContainer.Add(definition);
        }
    }
}

