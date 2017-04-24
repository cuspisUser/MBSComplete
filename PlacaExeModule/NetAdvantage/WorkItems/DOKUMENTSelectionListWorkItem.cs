namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Deklarit.Resources;
    using System;
    using System.Windows.Forms;
    using NetAdvantage.SmartParts;

    public class DOKUMENTSelectionListWorkItem : SelectionListWorkItemBase
    {
        public DOKUMENTSelectionListWorkItem() : this(new DOKUMENTWorkWith(), true)
        {
        }

        public DOKUMENTSelectionListWorkItem(Control filteredView, bool addCRUDCommands) : this(filteredView, null, addCRUDCommands)
        {
        }

        public DOKUMENTSelectionListWorkItem(Control filteredView, Control unfilteredView, bool addCrudCommands) : base(filteredView, unfilteredView)
        {
            if (addCrudCommands)
            {
                
                this.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("View", Deklarit.Resources.Resources.toolDisplay, this.Site + ".Tasks", ImageResourcesNew.hand_property, null, "DOKUMENT.Select;!DOKUMENT.Update"), new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", ImageResourcesNew.page_add, null, "DOKUMENT.Insert"), new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", ImageResourcesNew.page_edit, null, "DOKUMENT.Update"), new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", ImageResourcesNew.page_delete, null, "DOKUMENT.Delete"), new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", ImageResourcesNew.page_copy, null, "DOKUMENT.Insert"), new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", ImageResourcesNew.page_refresh, null, "DOKUMENT.Select"), new UICommandDefinition("FillAll", Deklarit.Resources.Resources.toolLoadAll, this.Site + ".Tasks", ImageResourcesNew.page_save, null, "DOKUMENT.Select"), new UICommandDefinition("Print", Deklarit.Resources.Resources.toolPrint, this.Site + ".Tasks", ImageResourcesNew.printer, null, "DOKUMENT.Select"), new UICommandDefinition("Export", Deklarit.Resources.Resources.toolExport, this.Site, false, true, DeklaritMode.All), new UICommandDefinition("ExportExcel", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", ImageResourcesNew.export_excel, null, "DOKUMENT.Select"), new UICommandDefinition("BLAGAJNA", "BLAGAJNA", this.Site + ".Relationships", ImageResourcesNew.money, null, "BLAGAJNA.Select"), new UICommandDefinition("GKSTAVKA", "GKSTAVKA", this.Site + ".Relationships", ImageResourcesNew.book, null, "GKSTAVKA.Select"), new UICommandDefinition("IRA", "IRA", this.Site + ".Relationships", ImageResourcesNew.book, null, "IRA.Select"), new UICommandDefinition("SHEMAIRA", "Shema kontiranja IRA", this.Site + ".Relationships", ImageResourcesNew.book, null, "SHEMAIRA.Select"), new UICommandDefinition("URA", "URA", this.Site + ".Relationships", ImageResourcesNew.book, null, "URA.Select"), new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All) });
            }
        }
    }
}

