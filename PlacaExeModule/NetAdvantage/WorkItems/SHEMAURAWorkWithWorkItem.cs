﻿namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Deklarit.Resources;
    using System;
    using NetAdvantage.SmartParts;

    public class SHEMAURAWorkWithWorkItem : WorkWithWorkItemBase<SHEMAURAWorkWith>
    {
        public SHEMAURAWorkWithWorkItem() : base("SHEMAURA")
        {            
            this.UICommandDefinitionContainer.Add(new UICommandDefinition[] { 
                new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true), 
                new UICommandDefinition("View", Deklarit.Resources.Resources.toolDisplay, this.Site + ".Tasks", ImageResourcesNew.hand_property, null, "SHEMAURA.Select;!SHEMAURA.Update"), 
                new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", ImageResourcesNew.page_add, null, "SHEMAURA.Insert"), 
                new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", ImageResourcesNew.page_edit, null, "SHEMAURA.Update"), 
                new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", ImageResourcesNew.page_delete, null, "SHEMAURA.Delete"), 
                new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", ImageResourcesNew.page_copy, null, "SHEMAURA.Insert"), 
                new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", ImageResourcesNew.page_refresh, null, "SHEMAURA.Select"), 
                new UICommandDefinition("FillAll", Deklarit.Resources.Resources.toolLoadAll, this.Site + ".Tasks", ImageResourcesNew.page_save, null, "SHEMAURA.Select"), 
                new UICommandDefinition("Print", Deklarit.Resources.Resources.toolPrint, this.Site + ".Tasks", ImageResourcesNew.printer, null, "SHEMAURA.Select"), 
                new UICommandDefinition("Export", Deklarit.Resources.Resources.toolExport, this.Site, false, true, DeklaritMode.All), 
                new UICommandDefinition("ExportExcel", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", ImageResourcesNew.export_excel, null, "SHEMAURA.Select"), 
                new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All) });
        }
    }
}

