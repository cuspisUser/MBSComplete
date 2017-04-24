namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Deklarit.Resources;
    using System;
    using NetAdvantage.SmartParts;

    public class JEDINICAMJEREWorkWithWorkItem : WorkWithWorkItemBase<JEDINICAMJEREWorkWith>
    {
        public JEDINICAMJEREWorkWithWorkItem() : base("JEDINICAMJERE")
        {

            this.UICommandDefinitionContainer.Add(new UICommandDefinition[] 
            { 
                new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true),
                new UICommandDefinition("View", Deklarit.Resources.Resources.toolDisplay, this.Site + ".Tasks", ImageResourcesNew.hand_property, null, "JEDINICAMJERE.Select;!JEDINICAMJERE.Update"), 
                new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", ImageResourcesNew.page_add, null, "JEDINICAMJERE.Insert"), 
                new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", ImageResourcesNew.page_edit, null, "JEDINICAMJERE.Update"), 
                new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", ImageResourcesNew.page_delete, null, "JEDINICAMJERE.Delete"),
                new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", ImageResourcesNew.page_copy, null, "JEDINICAMJERE.Insert"), 
                new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", ImageResourcesNew.page_refresh, null, "JEDINICAMJERE.Select"),
                new UICommandDefinition("FillAll", Deklarit.Resources.Resources.toolLoadAll, this.Site + ".Tasks", ImageResourcesNew.page_save, null, "JEDINICAMJERE.Select"), 
                new UICommandDefinition("Print", Deklarit.Resources.Resources.toolPrint, this.Site + ".Tasks", ImageResourcesNew.printer, null, "JEDINICAMJERE.Select"), 
                new UICommandDefinition("Export", Deklarit.Resources.Resources.toolExport, this.Site, false, true, DeklaritMode.All),
                new UICommandDefinition("ExportExcel", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", ImageResourcesNew.export_excel, null, "JEDINICAMJERE.Select")
                //new UICommandDefinition("PROIZVOD", "PROIZVOD", this.Site + ".Relationships", ImageResourcesNew.factory, null, "PROIZVOD.Select"), 
                //new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All) 
            });
        }
    }
}

