namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Deklarit.Resources;
    using System;
    using NetAdvantage.SmartParts;

    public class PRPLACEWorkWithWorkItem : WorkWithWorkItemBase<PRPLACEWorkWith>
    {
        public PRPLACEWorkWithWorkItem() : base("PRPLACE")
        {
            
            this.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true), new UICommandDefinition("View", Deklarit.Resources.Resources.toolDisplay, this.Site + ".Tasks", ImageResourcesNew.hand_property, null, "PRPLACE.Select;!PRPLACE.Update"), new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", ImageResourcesNew.page_add, null, "PRPLACE.Insert"), new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", ImageResourcesNew.page_edit, null, "PRPLACE.Update"), new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", ImageResourcesNew.page_delete, null, "PRPLACE.Delete"), new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", ImageResourcesNew.page_copy, null, "PRPLACE.Insert"), new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", ImageResourcesNew.page_refresh, null, "PRPLACE.Select"), new UICommandDefinition("FillAll", Deklarit.Resources.Resources.toolLoadAll, this.Site + ".Tasks", ImageResourcesNew.page_save, null, "PRPLACE.Select"), new UICommandDefinition("Print", Deklarit.Resources.Resources.toolPrint, this.Site + ".Tasks", ImageResourcesNew.printer, null, "PRPLACE.Select"), new UICommandDefinition("Export", Deklarit.Resources.Resources.toolExport, this.Site, false, true, DeklaritMode.All), new UICommandDefinition("ExportExcel", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", ImageResourcesNew.export_excel, null, "PRPLACE.Select"), new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All) });
        }

        protected override void OnInitialized()
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
        }
    }
}

