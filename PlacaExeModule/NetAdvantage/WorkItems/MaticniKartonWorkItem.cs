namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;

    public class MaticniKartonWorkItem : MdiWorkItemBase
    {
        public MaticniKartonWorkItem() : base("MaticniKarton", new MaticniKarton.MaticniKarton())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Zadaci") {
                Text = "Matični karton",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition2 = new UICommandDefinition("OtvoriGodinu") {
                Text = "Otvori godinu",
                Site = "MainShellPanel.Zadaci",
                Image = ImageResourcesNew.calendar_view_month
            };
            this.UICommandDefinitionContainer.Add(definition2);
            UICommandDefinition definition = new UICommandDefinition("Ispisi") {
                Text = "Ispiši",
                Site = "MainShellPanel.Zadaci",
                Image = ImageResourcesNew.printer
            };
            this.UICommandDefinitionContainer.Add(definition);
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}

