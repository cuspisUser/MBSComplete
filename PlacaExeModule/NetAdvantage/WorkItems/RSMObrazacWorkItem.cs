namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using NetAdvantage.SmartParts;

    public class RSMObrazacWorkItem : MdiWorkItemBase
    {
        public RSMObrazacWorkItem() : base("RSMObrazac", new RSMObrazac())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Obracun") {
                Text = "Obračuni",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("Otvori") {
                Text = "Otvori obračun",
                Site = "MainShellPanel.Obracun",
                Image = ImageResourcesNew.layout
            };
            this.UICommandDefinitionContainer.Add(definition);
            UICommandDefinition definition2 = new UICommandDefinition("PonovnoStvori") {
                Text = "Ponovno stvori obrazac",
                Site = "MainShellPanel.Obracun",
                Image = ImageResourcesNew.script_add
            };
            this.UICommandDefinitionContainer.Add(definition2);
            /*UICommandDefinition definition8 = new UICommandDefinition("Ucenici") {
                Text = "Učenici/praksa",
                Site = "MainShellPanel.Obracun",
                Image = ImageResourcesNew.user_student
            };
            this.UICommandDefinitionContainer.Add(definition8);*/
            UICommandDefinition definition5 = new UICommandDefinition("RSM2010") {
                Text = "R-Sm-2010",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition5);
            UICommandDefinition definition3 = new UICommandDefinition("StranicaA2010") {
                Text = "R-Sm-2010-Stranica A",
                Site = "MainShellPanel.RSM2010",
                Image = ImageResourcesNew.script
            };
            this.UICommandDefinitionContainer.Add(definition3);
            UICommandDefinition definition4 = new UICommandDefinition("StranicaB2010") {
                Text = "R-Sm-2010-Stranica B",
                Site = "MainShellPanel.RSM2010",
                Image = ImageResourcesNew.script
            };
            this.UICommandDefinitionContainer.Add(definition4);
            UICommandDefinition definition6 = new UICommandDefinition("SnimiDatoteku2010") {
                Text = "R-Sm-2010 na disketu",
                Site = "MainShellPanel.RSM2010",
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

