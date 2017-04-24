namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using NetAdvantage.SmartParts;

    public class Tablica011WorkItem : MdiWorkItemBase
    {
        public Tablica011WorkItem() : base("Tablica011WorkItem", new Tablica011())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Tablica011Command") {
                Text = "Mirovinsko Tablica 01/11",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("ZaGodinu") {
                Text = "Za godinu",
                Site = "MainShellPanel.Tablica011Command",
                Image = ImageResourcesNew.calendar_view_month
            };
            this.UICommandDefinitionContainer.Add(definition);
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}

