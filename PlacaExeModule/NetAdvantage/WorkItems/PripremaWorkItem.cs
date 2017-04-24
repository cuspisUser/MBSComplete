namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using My.Resources;
    using System;
    using NetAdvantage.SmartParts;
    using System.Windows.Media.Imaging;

    public class PripremaWorkItem : MdiWorkItemBase
    {
        public PripremaWorkItem() : base("PripremaworkItem", new ObracunSmartPart())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Obracun")
            {
                Text = "Obračun",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition2 = new UICommandDefinition("ZapocniNovi") {
                Text = "Započni novi",
                Site = "MainShellPanel.Obracun",
                //Image = My.Resources.Resources .note_new
                Image = ImageResourcesNew.page_white
            };
            this.UICommandDefinitionContainer.Add(definition2);
            UICommandDefinition definition3 = new UICommandDefinition("OtvoriPostojeci") {
                Text = "Otvori postojeći",
                Site = "MainShellPanel.Obracun",
                //Image = My.Resources.Resources.note_edit
                Image = ImageResourcesNew.page
            };
            this.UICommandDefinitionContainer.Add(definition3);
            UICommandDefinition definition16 = new UICommandDefinition("DodajRadnike") {
                Text = "Dodaj radnike u obračun",
                Site = "MainShellPanel.Obracun",
                //Image = My.Resources.Resources.user_add
                Image = ImageResourcesNew.user_go
            };
            this.UICommandDefinitionContainer.Add(definition16);
            UICommandDefinition definition19 = new UICommandDefinition("ObrisiRadnike") {
                Text = "Obriši radnike iz obračuna",
                Site = "MainShellPanel.Obracun",
                //Image = My.Resources.Resources.user_delete
                Image = ImageResourcesNew.user_delete
            };
            this.UICommandDefinitionContainer.Add(definition19);
            UICommandDefinition definition23 = new UICommandDefinition("DovuciIzPripreme") {
                Text = "Unos elemenata iz pripreme",
                Site = "MainShellPanel.Obracun",
                //Image = My.Resources.Resources.tables_add
                Image = ImageResourcesNew.table_export
            };
            this.UICommandDefinitionContainer.Add(definition23);
            UICommandDefinition definition8 = new UICommandDefinition("DovuciIzGO") {
                Text = "Import tablice GO",
                Site = "MainShellPanel.Obracun",
                //Image = My.Resources.Resources.tables_add
                Image = ImageResourcesNew.table_import
            };
            this.UICommandDefinitionContainer.Add(definition8);

            // Funkcionalnost "Neto u bruto" deaktivirana
            /*
            UICommandDefinition definition20 = new UICommandDefinition("NetoUBruto") {
                Text = "Neto u bruto",
                Site = "MainShellPanel.Obracun",
                //Image = My.Resources.Resources.replace2
                Image = ImageResourcesNew.table_refresh
            };
            this.UICommandDefinitionContainer.Add(definition20);
            */
            
            UICommandDefinition definition21 = new UICommandDefinition("PrebaciElemente") {
                Text = "Neto ele. iz zaduženja",
                Site = "MainShellPanel.Obracun",
                //Image = My.Resources.Resources.replace2
                Image = ImageResourcesNew.table_refresh
            };
            this.UICommandDefinitionContainer.Add(definition21);
            UICommandDefinition definition22 = new UICommandDefinition("Izlaz") {
                Text = "Izlaz iz obračuna",
                Site = "MainShellPanel.Obracun",
                Image = ImageResourcesNew.cancel

            };
            this.UICommandDefinitionContainer.Add(definition22);
            UICommandDefinition definition = new UICommandDefinition("Rekapitulacije") {
                Text = "Rekapitulacije",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition);
            UICommandDefinition definition15 = new UICommandDefinition("Rekapitulacija") {
                Text = "Rekapitulacija",
                Site = "MainShellPanel.Rekapitulacije",
                Image = ImageResourcesNew.table_sum
            };
            this.UICommandDefinitionContainer.Add(definition15);
            UICommandDefinition definition14 = new UICommandDefinition("Bruto") {
                Text = "Bruto primanja",
                Site = "MainShellPanel.Rekapitulacije",
                Image = ImageResourcesNew.calculator_add
            };
            this.UICommandDefinitionContainer.Add(definition14);
            UICommandDefinition definition24 = new UICommandDefinition("Neto") {
                Text = "Neto primanje",
                Site = "MainShellPanel.Rekapitulacije",
                Image = ImageResourcesNew.calculator_delete
            };
            this.UICommandDefinitionContainer.Add(definition24);
            UICommandDefinition definition26 = new UICommandDefinition("Porez") {
                Text = "Porezi",
                Site = "MainShellPanel.Rekapitulacije",
                Image = ImageResourcesNew.entity
            };
            this.UICommandDefinitionContainer.Add(definition26);
            UICommandDefinition definition27 = new UICommandDefinition("Doprinos") {
                Text = "Doprinosi",
                Site = "MainShellPanel.Rekapitulacije",
                Image = ImageResourcesNew.group
            };
            this.UICommandDefinitionContainer.Add(definition27);
            UICommandDefinition definition28 = new UICommandDefinition("Olaksica") {
                Text = "Olakšice",
                Site = "MainShellPanel.Rekapitulacije",
                Image = ImageResourcesNew.group_add
            };
            this.UICommandDefinitionContainer.Add(definition28);
            UICommandDefinition definition29 = new UICommandDefinition("Kredit") {
                Text = "Krediti",
                Site = "MainShellPanel.Rekapitulacije",
                Image = ImageResourcesNew.credit
            };
            this.UICommandDefinitionContainer.Add(definition29);
            UICommandDefinition definition30 = new UICommandDefinition("Fiksna") {
                Text = "Fiksne obustave",
                Site = "MainShellPanel.Rekapitulacije",
                Image = ImageResourcesNew.group_error
            };
            this.UICommandDefinitionContainer.Add(definition30);
            UICommandDefinition definition32 = new UICommandDefinition("Postotna") {
                Text = "Postotne obustave",
                Site = "MainShellPanel.Rekapitulacije",
                Image = ImageResourcesNew.group_delete
            };
            this.UICommandDefinitionContainer.Add(definition32);
            UICommandDefinition definition6 = new UICommandDefinition("Ispisi") {
                Text = "Ispisi",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition6);
            UICommandDefinition definition9 = new UICommandDefinition("IspisiPlatneCommand") {
                Text = "Platne/šifra/označeni",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.page_red
            };
            //this.UICommandDefinitionContainer.Add(definition9);
            UICommandDefinition definition10 = new UICommandDefinition("IspisiPlatneAbecedaCommnd") {
                Text = "Platne/svi/abeceda",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.page_white_c
            };
            //this.UICommandDefinitionContainer.Add(definition10);
            UICommandDefinition definition5 = new UICommandDefinition("IspisiPlatnePojedinacnoCommand") {
                Text = "Platna/odabrani",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.page_green
            };
            //db - 03.02.2017
            //UICommandDefinition definition99 = new UICommandDefinition("PlatnaInstituti")
            //{
            //    Text = "Platne liste instituti",
            //    Site = "MainShellPanel.Ispisi",
            //    Image = ImageResourcesNew.page_red
            //};
            //this.UICommandDefinitionContainer.Add(definition99);
            //this.UICommandDefinitionContainer.Add(definition5);
            
            UICommandDefinition definition40 = new UICommandDefinition("PlatnaDoprinosNA")
            {
                Text = "Platna lista",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.script
            };
            this.UICommandDefinitionContainer.Add(definition40);

            UICommandDefinition definition4 = new UICommandDefinition("IspisiPotpisnuListuCommand") {
                Text = "Potpisna lista",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.page_edit
            };
            this.UICommandDefinitionContainer.Add(definition4);
            UICommandDefinition definition11 = new UICommandDefinition("ListaIznosaCommand") {
                Text = "Lista iznosa",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.page_white_h
            };
            this.UICommandDefinitionContainer.Add(definition11);

            UICommandDefinition definition101 = new UICommandDefinition("IspisiPlatneNP1Command")
            {
                Text = "NP 1",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.page_white_code
            };
            this.UICommandDefinitionContainer.Add(definition101);

            UICommandDefinition definition12 = new UICommandDefinition("VirmaniCommand") {
                Text = "Virmani",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.cheque
            };
            this.UICommandDefinitionContainer.Add(definition12);

            UICommandDefinition definition13 = new UICommandDefinition("RSMCommand") {
                Text = "R-Sm Obrazac",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.script
            };

          
            
            UICommandDefinition definition33 = new UICommandDefinition("GO") {
                Text = "Godišnji obračun",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition33);
            //hrvoje 
            //UICommandDefinition definition25 = new UICommandDefinition("GOOdbici") {
            //    Text = "Godišnji odbici",
            //    Site = "MainShellPanel.GO",
            //    Image = ImageResourcesNew.document_empty
            //};
            //this.UICommandDefinitionContainer.Add(definition25);
            //
            //UICommandDefinition definition18 = new UICommandDefinition("ObrasciPorezna")
            //{
            //    Text = "Zahtjev MFIN-PU",
            //    Site = "MainShellPanel.GO",
            //    Image = ImageResourcesNew.document_empty
            //};
            //this.UICommandDefinitionContainer.Add(definition18);
            //hrvoje
            UICommandDefinition definition7 = new UICommandDefinition("Konacni") {
                Text = "Godišnji obračun poreza",
                Site = "MainShellPanel.GO",
                Image = ImageResourcesNew.document_empty
            };
            this.UICommandDefinitionContainer.Add(definition7);
            UICommandDefinition definition17 = new UICommandDefinition("RekapKonacniPorezRadniciOpcine") {
                Text = "Rekapitulacija korekcija por.",
                Site = "MainShellPanel.GO",
                Image = ImageResourcesNew.document_empty
            };
            this.UICommandDefinitionContainer.Add(definition17);
            UICommandDefinition definition20 = new UICommandDefinition("BrisanjeStavkeObracun")
            {
                Text = "Obriši stavke za konačni obračun.",
                Site = "MainShellPanel.GO",
                Image = ImageResourcesNew.delete
            };
            this.UICommandDefinitionContainer.Add(definition20);

            UICommandDefinition definition100 = new UICommandDefinition("IspisiPlatneNoveCommand")
            {
                Text = "Platne svi od 01.07.2015",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.page_white_code
            };
            //this.UICommandDefinitionContainer.Add(definition100);

           

        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
    }
}

