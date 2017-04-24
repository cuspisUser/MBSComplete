namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Deklarit.Resources;
    using System;
    using System.Windows.Forms;
    using NetAdvantage.SmartParts;

    public class DDIZDATAKSelectionListWorkItem : SelectionListWorkItemBase
    {
        public DDIZDATAKSelectionListWorkItem() : this(new DDIZDATAKWorkWith(), true)
        {
        }

        public DDIZDATAKSelectionListWorkItem(Control filteredView, bool addCRUDCommands) : this(filteredView, null, addCRUDCommands)
        {
        }

        public DDIZDATAKSelectionListWorkItem(Control filteredView, Control unfilteredView, bool addCrudCommands) : base(filteredView, unfilteredView)
        {
            if (addCrudCommands)
            {
                
                this.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("View", Deklarit.Resources.Resources.toolDisplay, this.Site + ".Tasks", ImageResourcesNew.hand_property, null, "DDIZDATAK.Select;!DDIZDATAK.Update"), new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", ImageResourcesNew.page_add, null, "DDIZDATAK.Insert"), new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", ImageResourcesNew.page_edit, null, "DDIZDATAK.Update"), new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", ImageResourcesNew.page_delete, null, "DDIZDATAK.Delete"), new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", ImageResourcesNew.page_copy, null, "DDIZDATAK.Insert"), new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", ImageResourcesNew.page_refresh, null, "DDIZDATAK.Select"), new UICommandDefinition("FillAll", Deklarit.Resources.Resources.toolLoadAll, this.Site + ".Tasks", ImageResourcesNew.page_save, null, "DDIZDATAK.Select"), new UICommandDefinition("Print", Deklarit.Resources.Resources.toolPrint, this.Site + ".Tasks", ImageResourcesNew.printer, null, "DDIZDATAK.Select"), new UICommandDefinition("Export", Deklarit.Resources.Resources.toolExport, this.Site, false, true, DeklaritMode.All), new UICommandDefinition("ExportExcel", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", ImageResourcesNew.export_excel, null, "DDIZDATAK.Select"), new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All) });
            }
        }
    }
}

