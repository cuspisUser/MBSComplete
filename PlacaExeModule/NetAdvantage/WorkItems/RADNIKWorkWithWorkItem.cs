namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Deklarit.Resources;
    using System;
    using NetAdvantage.SmartParts;

    public class RADNIKWorkWithWorkItem : WorkWithWorkItemBase<RADNIKWorkWith>
    {
        public RADNIKWorkWithWorkItem() : base("RADNIK")
        {
            
            this.UICommandDefinitionContainer.Add(new UICommandDefinition[] { 
                new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true), 
                new UICommandDefinition("View", Deklarit.Resources.Resources.toolDisplay, this.Site + ".Tasks", ImageResourcesNew.hand_property, null, "RADNIK.Select;!RADNIK.Update"), 
                new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", ImageResourcesNew.page_add, null, "RADNIK.Insert"), 
                new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", ImageResourcesNew.page_edit, null, "RADNIK.Update"), 
                new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", ImageResourcesNew.page_delete, null, "RADNIK.Delete"), 
                new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", ImageResourcesNew.page_copy, null, "RADNIK.Insert"), 
                new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", ImageResourcesNew.page_refresh, null, "RADNIK.Select"),
                new UICommandDefinition("FillAll", Deklarit.Resources.Resources.toolLoadAll, this.Site + ".Tasks", ImageResourcesNew.page_save, null, "RADNIK.Select"), 
                new UICommandDefinition("Print", Deklarit.Resources.Resources.toolPrint, this.Site + ".Tasks", ImageResourcesNew.printer, null, "RADNIK.Select"), 
                new UICommandDefinition("Export", Deklarit.Resources.Resources.toolExport, this.Site, false, true, DeklaritMode.All), 
                new UICommandDefinition("ExportExcel", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", ImageResourcesNew.export_excel, null, "RADNIK.Select"), 
                new UICommandDefinition("GOOBRACUN", "Godišnji odbici i olakšice", this.Site + ".Relationships", ImageResourcesNew.calculator_delete, null, "GOOBRACUN.Select"), 
                new UICommandDefinition("OTISLI", "Otišli", this.Site + ".Relationships", ImageResourcesNew.arrow_right, null, "OTISLI.Select"), 
                new UICommandDefinition("ZAPOSLENI", "Zaposleni", this.Site + ".Relationships", ImageResourcesNew.arrow_down, null, "ZAPOSLENI.Select"), 
                new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All) });
        }

        protected override void OnInitialized()
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Ispisi") {
                Text = "Ispiši",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("IspisEvidencijeORadnicima") {
                Text = "Evidencija o radnicima",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.participation_rate
            };
            this.UICommandDefinitionContainer.Add(definition);
            UICommandDefinition definition2 = new UICommandDefinition("PopisRadnika") {
                Text = "Popis zaposlenika",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.group
            };
            this.UICommandDefinitionContainer.Add(definition2);
            UICommandDefinition definition3 = new UICommandDefinition("cmdIspisiKredite") {
                Text = "Zaduženi krediti",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.credit
            };
            this.UICommandDefinitionContainer.Add(definition3);
            UICommandDefinition definition6 = new UICommandDefinition("cmdIspisiObustave") {
                Text = "Zadužene obustave",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.group_error
            };
            this.UICommandDefinitionContainer.Add(definition6);
            UICommandDefinition definition4 = new UICommandDefinition("cmdIspisiKreditePojedinacno") {
                Text = "Krediti po zaposleniku",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.credit
            };
            this.UICommandDefinitionContainer.Add(definition4);
            UICommandDefinition definition5 = new UICommandDefinition("cmdIspisiObustavePojedinacno") {
                Text = "Obustave po zaposleniku",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.group_error
            };
            this.UICommandDefinitionContainer.Add(definition5);
            UICommandDefinition definition12 = new UICommandDefinition("cmdIspisPlatnih") {
                Text = "Platne liste / razdoblje",
                Site = "MainShellPanel.Ispisi",
                Image = ImageResourcesNew.page_white_stack
            };
            this.UICommandDefinitionContainer.Add(definition12);
            UICommandDefinition definition11 = new UICommandDefinition("Obrade") {
                Text = "Obrade",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition11);

            // Funkcionalnost "Neto u bruto" deaktivirana
            /*
            UICommandDefinition definition9 = new UICommandDefinition("NetoUBruto") {
                Text = "Neto u bruto",
                Site = "MainShellPanel.Obrade",
                Image = ImageResourcesNew.calculator_add
            };
            this.UICommandDefinitionContainer.Add(definition9);
            */

            UICommandDefinition definition7 = new UICommandDefinition("cmdImportOIB") {
                Text = "Import OIB",
                Site = "MainShellPanel.Obrade",
                Image = ImageResourcesNew.document_import
            };
            this.UICommandDefinitionContainer.Add(definition7);
            UICommandDefinition definition8 = new UICommandDefinition("cmdImportPrintListe") {
                Text = "Import print liste",
                Site = "MainShellPanel.Obrade",
                Image = ImageResourcesNew.document_import
            };
            this.UICommandDefinitionContainer.Add(definition8);
        }
    }
}

