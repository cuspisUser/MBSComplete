namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using NetAdvantage.SmartParts;

    public class GodisnjiWorkItem : MdiWorkItemBase
    {
        public GodisnjiWorkItem() : base("Prosjekgodisnji", new Prosjekgodisnji())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Zadaci") {
                Text = "Zadaci",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition2 = new UICommandDefinition("Ucitaj") {
                Text = "Učitaj podatke",
                Site = "MainShellPanel.Zadaci",
                Image = ImageResourcesNew.page_white_get
            };
            this.UICommandDefinitionContainer.Add(definition2);
            UICommandDefinition definition = new UICommandDefinition("Snimi") {
                Text = "Snimi u Excel format",
                Site = "MainShellPanel.Zadaci",
                Image = ImageResourcesNew.page_excel
            };
            this.UICommandDefinitionContainer.Add(definition);
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}

