namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using My.Resources;
    using System;

    public class AmortizacijaWorkWith : MdiWorkItemBase
    {
        public AmortizacijaWorkWith() : base("AmortizacijaWorkWith", new Amortizacija())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Obracun") {
                Text = "Amortizacija",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("OtvoriPostojecu") {
                Text = "Otvori postojeću",
                Site = "MainShellPanel.Obracun",
                Image = My.Resources.ResourcesPlacaExe.note_new
            };
            this.UICommandDefinitionContainer.Add(definition);
            UICommandDefinition definition2 = new UICommandDefinition("KreirajNovu") {
                Text = "Kreiraj novu",
                Site = "MainShellPanel.Obracun",
                Image = My.Resources.ResourcesPlacaExe.note_edit
            };
            this.UICommandDefinitionContainer.Add(definition2);
            UICommandDefinition definition4 = new UICommandDefinition("Ispisi") {
                Text = "Ispiši amortizaciju",
                Site = "MainShellPanel.Obracun",
                Image = My.Resources.ResourcesPlacaExe.note_edit
            };
            this.UICommandDefinitionContainer.Add(definition4);
            UICommandDefinition definition6 = new UICommandDefinition("IspisiRekapitulaciju") {
                Text = "Ispiši rekapitulaciju",
                Site = "MainShellPanel.Obracun",
                Image = My.Resources.ResourcesPlacaExe.note_edit
            };
            this.UICommandDefinitionContainer.Add(definition6);
            UICommandDefinition definition3 = new UICommandDefinition("Zatvori") {
                Text = "Zatvori otvorenu",
                Site = "MainShellPanel.Obracun",
                Image = My.Resources.ResourcesPlacaExe.note_edit
            };
            this.UICommandDefinitionContainer.Add(definition3);
        }
    }
}

