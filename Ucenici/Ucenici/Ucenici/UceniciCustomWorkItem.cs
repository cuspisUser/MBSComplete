namespace Ucenici.Ucenici
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;

    public class UceniciCustomWorkItem : MdiWorkItemBase
    {
        public UceniciCustomWorkItem() : base("UceniciCustom", new UceniciCustom())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Tablice") {
                Text = "Ispisi",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);

            //UICommandDefinition definition = new UICommandDefinition("RSM") {
            //    Text = "Obrazac R-Sm",
            //    Site = "MainShellPanel.Tablice",
            //    Image = ImageResourcesNew.script
            //};
            //this.UICommandDefinitionContainer.Add(definition);

/*            UICommandDefinition definition2 = new UICommandDefinition("Rekapitulirano") {
                Text = "",
                Site = "MainShellPanel.Tablice"
            };
            this.UICommandDefinitionContainer.Add(definition2);
 */
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}

