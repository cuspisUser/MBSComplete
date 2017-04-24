namespace FinPosModule.ZatvaranjeBolnice
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using System.Windows.Forms;

    public class ZatvaranjeBolniceWorkItem : MdiWorkItemBase
    {
        public ZatvaranjeBolniceWorkItem() : base("ZatvaranjeBolniceWorkItem", new ZatvaranjeFormBolniceSmartPart())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Zatvaranje") {
                Text = "Otvorene stavke",
                IsCategory = true,
                Site = "MainShellPanel"
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("PoveziStavke") {
                Text = "Zatvori stavke",
                Site = "MainShellPanel.Zatvaranje",
                Image = ImageResourcesNew.table_relationship
            };
            this.UICommandDefinitionContainer.Add(definition);


            UICommandDefinition definition2 = new UICommandDefinition("UcitajDatoteku")
            {
                Text = "Učitaj datoteku",
                Site = "MainShellPanel.Zatvaranje",
                Image = ImageResourcesNew.tab_add
            };
            this.UICommandDefinitionContainer.Add(definition2);
        }

        protected ZatvaranjeBolniceWorkItem(string name, Control view) : base(name, view)
        {
        }
    }
}

