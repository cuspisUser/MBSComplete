namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
    using NetAdvantage.SmartParts;

    public class PripremaPlaceCustomWorkItem : MdiWorkItemBase
    {
        public PripremaPlaceCustomWorkItem() : base("PripremaPlaceCustom", new PripremaPlaceCustom())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Tablice") {
                Text = "MZOŠ Tablice-OŠ",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("Smjenski") {
                Text = "Smjenski rad",
                Site = "MainShellPanel.Tablice",
                Image = ImageResourcesNew.note_go
            };
            this.UICommandDefinitionContainer.Add(definition);
            UICommandDefinition definition2 = new UICommandDefinition("Posebni") {
                Text = "Posebni uvjeti",
                Site = "MainShellPanel.Tablice",
                Image = ImageResourcesNew.star
            };
            this.UICommandDefinitionContainer.Add(definition2);
            UICommandDefinition definition3 = new UICommandDefinition("Uvecanje") {
                Text = "Uvećanje",
                Site = "MainShellPanel.Tablice",
                Image = ImageResourcesNew.coins_add
            };
            this.UICommandDefinitionContainer.Add(definition3);
            UICommandDefinition definition4 = new UICommandDefinition("PreracunajSatnice") {
                Text = "Preračunaj satnice",
                Site = "MainShellPanel.Tablice",
                Image = ImageResourcesNew.time
            };
            this.UICommandDefinitionContainer.Add(definition4);
            UICommandDefinition definition5 = new UICommandDefinition("IspisRekapitulacijeCommand") {
                Text = "Rekapitulacija",
                Site = "MainShellPanel.Tablice",
                Image = ImageResourcesNew.document_prepare
            };
            this.UICommandDefinitionContainer.Add(definition5);
            UICommandDefinition definition8 = new UICommandDefinition("TabliceSS") {
                Text = "MZOŠ Tablice-SŠ",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition8);
            UICommandDefinition definition7 = new UICommandDefinition("PosebniSS") {
                Text = "Posebni uvjeti-SŠ",
                Site = "MainShellPanel.TabliceSS",
                Image = ImageResourcesNew.star
            };
            this.UICommandDefinitionContainer.Add(definition7);
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}

