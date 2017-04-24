namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using NetAdvantage.SmartParts;

    public class JOPPDObrazacWorkItem : MdiWorkItemBase
    {
        public JOPPDObrazacWorkItem() : base("JOPPDObrazac", new JOPPDObrazac())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Obracun")
            {
                Text = "Obračuni",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition2 = new UICommandDefinition("PonovnoStvori")
            {
                Text = "Stvori novi obrazac",
                Site = "MainShellPanel.Obracun",
                Image = ImageResourcesNew.script_add
            };
            this.UICommandDefinitionContainer.Add(definition2);
            UICommandDefinition definition = new UICommandDefinition("Otvori")
            {
                Text = "Otvori postojeći obračun",
                Site = "MainShellPanel.Obracun",
                Image = ImageResourcesNew.layout
            };
            this.UICommandDefinitionContainer.Add(definition);
            UICommandDefinition definition5 = new UICommandDefinition("JOPPD")
            {
                Text = "JOPPD",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition5);
            UICommandDefinition definition7 = new UICommandDefinition("PotvrdiIzmjene")
            {
                Text = "Potvrdi podatke",
                Site = "MainShellPanel.JOPPD",
                Image = ImageResourcesNew.safe
            };
            this.UICommandDefinitionContainer.Add(definition7);
            UICommandDefinition definition3 = new UICommandDefinition("JOPPDStranicaA")
            {
                Text = "JOPPD - Stranica A",
                Site = "MainShellPanel.JOPPD",
                Image = ImageResourcesNew.script
            };
            this.UICommandDefinitionContainer.Add(definition3);
            UICommandDefinition definition4 = new UICommandDefinition("JOPPDStranicaB")
            {
                Text = "JOPPD - Stranica B",
                Site = "MainShellPanel.JOPPD",
                Image = ImageResourcesNew.script
            };
            this.UICommandDefinitionContainer.Add(definition4);
            UICommandDefinition definition6 = new UICommandDefinition("JOPPDDatoteka")
            {
                Text = "JOPPD datoteka",
                Site = "MainShellPanel.JOPPD",
                Image = ImageResourcesNew.script_save
            };
            this.UICommandDefinitionContainer.Add(definition6);
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}

