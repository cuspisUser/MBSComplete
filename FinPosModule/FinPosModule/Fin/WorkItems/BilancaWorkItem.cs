namespace FinPosModule.Fin.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;

    public class BilancaWorkItem : MdiWorkItemBase
    {
        public BilancaWorkItem() : base("BilancaWorkItem", new BilancaSmartPart())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Bilanca") {
                Text = "Bilanca",
                IsCategory = true,
                Site = "MainShellPanel"
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("Kreiraj") {
                Text = "Kreiraj izvještaj",
                Site = "MainShellPanel.Bilanca",
                Image = ImageResourcesNew.table
            };
            this.UICommandDefinitionContainer.Add(definition);
        }
    }
}

