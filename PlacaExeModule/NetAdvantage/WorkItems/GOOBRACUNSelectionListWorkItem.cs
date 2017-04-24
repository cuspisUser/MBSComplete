namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Deklarit.Resources;
    using System;
    using System.Windows.Forms;
    using NetAdvantage.SmartParts;

    public class GOOBRACUNSelectionListWorkItem : SelectionListWorkItemBase
    {
        public GOOBRACUNSelectionListWorkItem() : this(new GOOBRACUNWorkWith(), true)
        {
        }

        public GOOBRACUNSelectionListWorkItem(Control filteredView, bool addCRUDCommands) : this(filteredView, null, addCRUDCommands)
        {
        }

        public GOOBRACUNSelectionListWorkItem(Control filteredView, Control unfilteredView, bool addCrudCommands) : base(filteredView, unfilteredView)
        {
            if (addCrudCommands)
            {
                
                this.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("View", Deklarit.Resources.Resources.toolDisplay, this.Site + ".Tasks", ImageResourcesNew.hand_property, null, "GOOBRACUN.Select;!GOOBRACUN.Update"), new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", ImageResourcesNew.page_add, null, "GOOBRACUN.Insert"), new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", ImageResourcesNew.page_edit, null, "GOOBRACUN.Update"), new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", ImageResourcesNew.page_delete, null, "GOOBRACUN.Delete"), new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", ImageResourcesNew.page_copy, null, "GOOBRACUN.Insert"), new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", ImageResourcesNew.page_refresh, null, "GOOBRACUN.Select"), new UICommandDefinition("FillAll", Deklarit.Resources.Resources.toolLoadAll, this.Site + ".Tasks", ImageResourcesNew.page_save, null, "GOOBRACUN.Select"), new UICommandDefinition("Print", Deklarit.Resources.Resources.toolPrint, this.Site + ".Tasks", ImageResourcesNew.printer, null, "GOOBRACUN.Select"), new UICommandDefinition("Export", Deklarit.Resources.Resources.toolExport, this.Site, false, true, DeklaritMode.All), new UICommandDefinition("ExportExcel", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", ImageResourcesNew.export_excel, null, "GOOBRACUN.Select"), new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All) });
            }
        }
    }
}

