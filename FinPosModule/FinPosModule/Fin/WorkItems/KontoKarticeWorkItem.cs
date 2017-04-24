namespace FinPosModule.Fin.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;

    public class KontoKarticeWorkItem : MdiWorkItemBase
    {
        public KontoKarticeWorkItem() : base("KontoKarticeWorkItem", new KontoKarticeSmartPart())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Kartice") {
                Text = "Konto kartice",
                IsCategory = true,
                Site = "MainShellPanel"
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("Kreiraj") {
                Text = "Kreiraj izvještaj",
                Site = "MainShellPanel.Kartice",
                Image = ImageResourcesNew.table
            };
            this.UICommandDefinitionContainer.Add(definition);
        }
    }
}

