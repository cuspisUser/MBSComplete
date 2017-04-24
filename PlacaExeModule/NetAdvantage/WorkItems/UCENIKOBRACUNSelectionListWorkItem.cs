namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Deklarit.Resources;
    using System;
    using NetAdvantage.SmartParts;
    using System.Windows.Forms;

    public class UCENIKOBRACUNSelectionListWorkItem : SelectionListWorkItemBase
    {
        public UCENIKOBRACUNSelectionListWorkItem() : this(new UCENIKOBRACUNWorkWith(), true)
        {
        }

        public UCENIKOBRACUNSelectionListWorkItem(Control filteredView, bool addCRUDCommands) : this(filteredView, null, addCRUDCommands)
        {
        }

        public UCENIKOBRACUNSelectionListWorkItem(Control filteredView, Control unfilteredView, bool addCrudCommands) : base(filteredView, unfilteredView)
        {
            if (addCrudCommands)
            {

                this.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("View", Deklarit.Resources.Resources.toolDisplay, this.Site + ".Tasks", ImageResourcesNew.hand_property, null, "UCENIKOBRACUN.Select;!UCENIKOBRACUN.Update"), new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", ImageResourcesNew.page_add, null, "UCENIKOBRACUN.Insert"), new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", ImageResourcesNew.page_edit, null, "UCENIKOBRACUN.Update"), new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", ImageResourcesNew.page_delete, null, "UCENIKOBRACUN.Delete"), new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", ImageResourcesNew.page_copy, null, "UCENIKOBRACUN.Insert"), new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", ImageResourcesNew.page_refresh, null, "UCENIKOBRACUN.Select"), new UICommandDefinition("FillAll", Deklarit.Resources.Resources.toolLoadAll, this.Site + ".Tasks", ImageResourcesNew.page_save, null, "UCENIKOBRACUN.Select"), new UICommandDefinition("Print", Deklarit.Resources.Resources.toolPrint, this.Site + ".Tasks", ImageResourcesNew.printer, null, "UCENIKOBRACUN.Select"), new UICommandDefinition("Export", Deklarit.Resources.Resources.toolImportExport, this.Site, false, true, DeklaritMode.All), new UICommandDefinition("ExportExcel", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", ImageResourcesNew.export_excel, null, "UCENIKOBRACUN.Select"), new UICommandDefinition("ExportXml", Deklarit.Resources.Resources.toolSaveXml, this.Site + ".Export", ImageResourcesNew.page_white_go, null, "UCENIKOBRACUN.Select"), new UICommandDefinition("ImportXml", Deklarit.Resources.Resources.toolLoadXml, this.Site + ".Export", ImageResourcesNew.page_white_get, null, "UCENIKOBRACUN.Update"), new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All) });
            }
        }
    }
}

