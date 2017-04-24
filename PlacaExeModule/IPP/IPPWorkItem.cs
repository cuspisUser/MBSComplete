namespace IPP
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;

    public class IPPWorkItem : MdiWorkItemBase
    {
        public IPPWorkItem() : base("IPPWorkItem", new IPPObrazac())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("IPPObrazacCommand") {
                Text = "IPP Obrazac",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("ZaMjesec") {
                Text = "Za mjesec i godinu",
                Site = "MainShellPanel.IPPObrazacCommand",
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

