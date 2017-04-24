namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using NetAdvantage.SmartParts;

    public class FondBolovanjeWorkItem : MdiWorkItemBase
    {
        public FondBolovanjeWorkItem() : base("FondProsjekBolovanje", new FondProsjekBolovanje())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Zadaci") {
                Text = "Zadaci",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("Snimi") {
                Text = "Snimi obrazac",
                Site = "MainShellPanel.Zadaci",
                Image = ImageResourcesNew.page_copy
            };
            this.UICommandDefinitionContainer.Add(definition);
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}

