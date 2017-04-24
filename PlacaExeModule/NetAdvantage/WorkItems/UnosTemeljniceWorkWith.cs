namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using My.Resources;
    using System;

    public class UnosTemeljniceWorkWith : MdiWorkItemBase
    {
        public UnosTemeljniceWorkWith() : base("UnosTemeljniceWorkWith", new UnosTemeljnice())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Obracun") {
                Text = "Rad sa temeljnicama",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition9 = new UICommandDefinition("Kreiraj") {
                Text = "Kreiraj temeljnicu",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition9);
            UICommandDefinition definition = new UICommandDefinition("OtvoriPostojecu") {
                Text = "Otvori postojeću",
                Site = "MainShellPanel.Obracun",
                //Image = My.Resources.Resources.note_new
                Image = ImageResourcesNew.note
            };
            this.UICommandDefinitionContainer.Add(definition);
            UICommandDefinition definition2 = new UICommandDefinition("KreirajRashod") {
                Text = "Rashoda",
                Site = "MainShellPanel.Kreiraj",
                //Image = My.Resources.Resources.note_edit
                Image = ImageResourcesNew.note_edit
            };
            this.UICommandDefinitionContainer.Add(definition2);
            UICommandDefinition definition4 = new UICommandDefinition("KreirajPovecanje") {
                Text = "Povećanja vr.",
                Site = "MainShellPanel.Kreiraj",
                //Image = My.Resources.Resources.note_edit
                Image = ImageResourcesNew.note_edit
            };
            this.UICommandDefinitionContainer.Add(definition4);
            UICommandDefinition definition5 = new UICommandDefinition("KreirajSmanjenje") {
                Text = "Smanjenja vr.",
                Site = "MainShellPanel.Kreiraj",
                //Image = My.Resources.Resources.note_edit
                Image = ImageResourcesNew.note_edit
            };
            this.UICommandDefinitionContainer.Add(definition5);
            UICommandDefinition definition6 = new UICommandDefinition("IspisTemeljnice") {
                Text = "Ispis temeljnice",
                Site = "MainShellPanel.Obracun",
                //Image = My.Resources.Resources.note_edit
                Image = ImageResourcesNew.printer
            };
            this.UICommandDefinitionContainer.Add(definition6);
            //UICommandDefinition definition7 = new UICommandDefinition("IspisTemeljniceRekap") {
            //    Text = "Ispis rekapitulacije tem.",
            //    Site = "MainShellPanel.Obracun",
            //    //Image = My.Resources.Resources.note_edit
            //    Image = ImageResourcesNew.printer
            //};
            //this.UICommandDefinitionContainer.Add(definition7);
            UICommandDefinition definition3 = new UICommandDefinition("Zatvori") {
                Text = "Zatvori otvorenu",
                Site = "MainShellPanel.Obracun",
                //Image = My.Resources.Resources.note_edit
                Image = ImageResourcesNew.cancel
            };
            this.UICommandDefinitionContainer.Add(definition3);
        }
    }
}

