namespace EVModule.EvModule
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;

    public class EvidencijaCustomWorkItem : MdiWorkItemBase
    {
        public EvidencijaCustomWorkItem() : base("EvidencijaCustom", new EvidencijaCustom())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Tablice") {
                Text = "Ispisi",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("Smjenski") {
                Text = "Ispis evidencije",
                Site = "MainShellPanel.Tablice",
                Image = ImageResourcesNew.session_idle_time
            };
            this.UICommandDefinitionContainer.Add(definition);
            UICommandDefinition definition2 = new UICommandDefinition("Rekapitulirano") {
                Text = "Ispis rekapitulacije",
                Site = "MainShellPanel.Tablice",
                Image = ImageResourcesNew.table_sum
            };
            this.UICommandDefinitionContainer.Add(definition2);
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}

