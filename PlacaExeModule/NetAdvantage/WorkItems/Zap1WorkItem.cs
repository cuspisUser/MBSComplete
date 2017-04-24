namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using NetAdvantage.SmartParts;

    public class Zap1WorkItem : MdiWorkItemBase
    {
        public Zap1WorkItem() : base("Zap1", new Zap1())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Izvjestaji") {
                Text = "ZAP1 Obrazac",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("ZaObracun") {
                Text = "Za obračun",
                Site = "MainShellPanel.Izvjestaji",
                Image = ImageResourcesNew.layout
            };
            this.UICommandDefinitionContainer.Add(definition);
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}

