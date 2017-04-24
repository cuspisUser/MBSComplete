namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Deklarit.Resources;
    using NetAdvantage.SmartParts;
    using System;

    public class KONTOWorkWithWorkItem : WorkWithWorkItemBase<KONTOWorkWith>
    {
        public KONTOWorkWithWorkItem() : base("KONTO")
        {
            
            this.UICommandDefinitionContainer.Add(new UICommandDefinition[] { 
                new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true), 
                new UICommandDefinition("View", Deklarit.Resources.Resources.toolDisplay, this.Site + ".Tasks", ImageResourcesNew.hand_property, null, "KONTO.Select;!KONTO.Update"), 
                new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", ImageResourcesNew.page_add, null, "KONTO.Insert"), 
                new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", ImageResourcesNew.page_edit, null, "KONTO.Update"), 
                new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", ImageResourcesNew.page_delete, null, "KONTO.Delete"), 
                new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", ImageResourcesNew.page_copy, null, "KONTO.Insert"), 
                new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", ImageResourcesNew.page_refresh, null, "KONTO.Select"), 
                new UICommandDefinition("FillAll", Deklarit.Resources.Resources.toolLoadAll, this.Site + ".Tasks", ImageResourcesNew.page_save, null, "KONTO.Select"), 
                new UICommandDefinition("Print", Deklarit.Resources.Resources.toolPrint, this.Site + ".Tasks", ImageResourcesNew.printer, null, "KONTO.Select"), 
                new UICommandDefinition("Export", Deklarit.Resources.Resources.toolExport, this.Site, false, true, DeklaritMode.All), 
                new UICommandDefinition("ExportExcel", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", ImageResourcesNew.export_excel, null, "KONTO.Select"), 
                new UICommandDefinition("AMSKUPINE", "AM skupine nabavne vrijednosti", this.Site + ".Relationships", ImageResourcesNew.computer, null, "AMSKUPINE.Select"), 
                new UICommandDefinition("AMSKUPINE", "AM skupine ispravka vrijednosti", this.Site + ".Relationships", ImageResourcesNew.computer, null, "AMSKUPINE.Select"), 
                new UICommandDefinition("AMSKUPINE", "AM skupine izvora vlasništva", this.Site + ".Relationships", ImageResourcesNew.computer, null, "AMSKUPINE.Select"), 
                new UICommandDefinition("BLAGAJNA", "BLAGAJNA", this.Site + ".Relationships", ImageResourcesNew.money, null, "BLAGAJNA.Select"), 
                new UICommandDefinition("GKSTAVKA", "GKSTAVKA", this.Site + ".Relationships", ImageResourcesNew.book, null, "GKSTAVKA.Select"), 
                new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All)
             });
        }

        protected override void OnInitialized()

        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Dodatno") {
                Text = "Dodatno",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition2 = new UICommandDefinition("Pretrazi") {
                Text = "Pretraživanje",
                Site = "MainShellPanel.Dodatno",
                Image = ImageResourcesNew.find
            };
            this.UICommandDefinitionContainer.Add(definition2);
            UICommandDefinition definition = new UICommandDefinition("Ponisti") {
                Text = "Poništi filter",
                Site = "MainShellPanel.Dodatno",
                Image = ImageResourcesNew.filter_delete
            };
            this.UICommandDefinitionContainer.Add(definition);
        }
    }
}

