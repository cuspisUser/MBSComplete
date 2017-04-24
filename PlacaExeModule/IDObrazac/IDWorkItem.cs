namespace IDObrazacNamespace
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using NetAdvantage.SmartParts;
    using NetAdvantage.WorkItems;

    public class IDWorkItem : MdiWorkItemBase
    {
        public IDWorkItem() : base("IDObrazac", new IDObrazacNamespace.IDObrazac())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("IDObrazacCommand") {
                Text = "ID Obrazac",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("ZaObracun") {
                Text = "Za obračun",
                Site = "MainShellPanel.IDObrazacCommand",
                Image = ImageResourcesNew.layout
            };
            this.UICommandDefinitionContainer.Add(definition);
            UICommandDefinition definition2 = new UICommandDefinition("ZaMjesec") {
                Text = "Za mjesec i godinu",
                Site = "MainShellPanel.IDObrazacCommand",
                Image = ImageResourcesNew.calendar_view_month
            };
            this.UICommandDefinitionContainer.Add(definition2);
            UICommandDefinition definition3 = new UICommandDefinition("Ispis") {
                Text = "Ispis obrasca prije 1.1.2011.",
                Site = "MainShellPanel.IDObrazacCommand",
                Image = ImageResourcesNew.script
            };
            this.UICommandDefinitionContainer.Add(definition3);
            UICommandDefinition definition4 = new UICommandDefinition("Ispis2011") {
                Text = "Ispis obrasca nakon 1.1.2011.",
                Site = "MainShellPanel.IDObrazacCommand",
                Image = ImageResourcesNew.script_go
            };
            this.UICommandDefinitionContainer.Add(definition4);
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}

