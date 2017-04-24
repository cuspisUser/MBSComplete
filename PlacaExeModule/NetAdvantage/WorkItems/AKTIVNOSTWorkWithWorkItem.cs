﻿namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Deklarit.Resources;
    using System;
    using NetAdvantage.SmartParts;

    public class AKTIVNOSTWorkWithWorkItem : WorkWithWorkItemBase<AKTIVNOSTWorkWith>
    {
        public AKTIVNOSTWorkWithWorkItem() : base("AKTIVNOST")
        {
            this.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true), 
                new UICommandDefinition("View", Deklarit.Resources.Resources.toolDisplay, this.Site + ".Tasks", ImageResourcesNew.hand_property, null, "AKTIVNOST.Select;!AKTIVNOST.Update"), 
                new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", ImageResourcesNew.page_add, null, "AKTIVNOST.Insert"), 
                new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", ImageResourcesNew.page_edit, null, "AKTIVNOST.Update"), 
                new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", ImageResourcesNew.page_delete, null, "AKTIVNOST.Delete"), 
                new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", ImageResourcesNew.page_copy, null, "AKTIVNOST.Insert"), 
                new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", ImageResourcesNew.page_refresh, null, "AKTIVNOST.Select"), 
                new UICommandDefinition("FillAll", Deklarit.Resources.Resources.toolLoadAll, this.Site + ".Tasks", ImageResourcesNew.page_save, null, "AKTIVNOST.Select"), 
                new UICommandDefinition("Print", Deklarit.Resources.Resources.toolPrint, this.Site + ".Tasks", ImageResourcesNew.printer, null, "AKTIVNOST.Select"), 
                new UICommandDefinition("Export", Deklarit.Resources.Resources.toolExport, this.Site, false, true, DeklaritMode.All), 
                new UICommandDefinition("ExportExcel", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", ImageResourcesNew.export_excel, null, "AKTIVNOST.Select"), 
                new UICommandDefinition("KONTO", "Kontni plan", this.Site + ".Relationships", ImageResourcesNew.page, null, "KONTO.Select"), 
                new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All) });
        }
    }
}

