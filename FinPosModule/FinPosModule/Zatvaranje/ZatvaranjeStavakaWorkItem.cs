namespace FinPosModule.Zatvaranje
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using System.Windows.Forms;

    public class ZatvaranjeStavakaWorkItem : MdiWorkItemBase
    {
        public ZatvaranjeStavakaWorkItem() : base("ZatvaranjeStavakaWorkItem", new ZatvaranjeSmartPart())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Zatvaranje") {
                Text = "Otvorene stavke",
                IsCategory = true,
                Site = "MainShellPanel"
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("PoveziStavke") {
                Text = "Poveži stavke",
                Site = "MainShellPanel.Zatvaranje",
                Image = ImageResourcesNew.table_relationship
            };
            this.UICommandDefinitionContainer.Add(definition);
        }

        protected ZatvaranjeStavakaWorkItem(string name, Control view) : base(name, view)
        {
        }
    }
}

