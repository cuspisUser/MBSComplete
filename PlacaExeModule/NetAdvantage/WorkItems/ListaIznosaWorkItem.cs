namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using NetAdvantage.SmartParts;
    using NetAdvantage.WorkItems;

    public class ListaIznosaWorkItem : MdiWorkItemBase
    {
        public ListaIznosaWorkItem()
            : base("Lista", new ListaIznosaRadnika.ListaIznosa(null))
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Obracun")
            {
                Text = "Obračun",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("ZaObracun")
            {
                Text = "Za obračun",
                Site = "MainShellPanel.Obracun",
                Image = ImageResourcesNew.layout
            };
            this.UICommandDefinitionContainer.Add(definition);
            UICommandDefinition definition2 = new UICommandDefinition("Ispis")
            {
                IsCategory = true,
                Text = "Ispis",
                Site = "MainShellPanel"
            };
            this.UICommandDefinitionContainer.Add(definition2);
            UICommandDefinition definition3 = new UICommandDefinition("IspisiListu")
            {
                Text = "Ispiši listu",
                Site = "MainShellPanel.Ispis",
                Image = ImageResourcesNew.printer
            };
            this.UICommandDefinitionContainer.Add(definition3);
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}

