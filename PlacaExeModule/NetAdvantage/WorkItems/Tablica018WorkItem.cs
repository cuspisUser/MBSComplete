namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using NetAdvantage.SmartParts;

    public class Tablica018WorkItem : MdiWorkItemBase
    {
        public Tablica018WorkItem() : base("Tablica01WorkItem", new Tablica018())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Tablica01Command") {
                Text = "Mirovinsko Tablica 01/10",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("ZaGodinu") {
                Text = "Za godinu",
                Site = "MainShellPanel.Tablica01Command",
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

