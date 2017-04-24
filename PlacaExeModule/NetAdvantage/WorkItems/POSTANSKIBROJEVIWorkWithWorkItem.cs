namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Deklarit.Resources;
    using System;
    using NetAdvantage.SmartParts;

    public class POSTANSKIBROJEVIWorkWithWorkItem : WorkWithWorkItemBase<POSTANSKIBROJEVIWorkWith>
    {
        public POSTANSKIBROJEVIWorkWithWorkItem() : base("POSTANSKIBROJEVI")
        {

            this.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true), new UICommandDefinition("View", Deklarit.Resources.Resources.toolDisplay, this.Site + ".Tasks", ImageResourcesNew.hand_property, null, "POSTANSKIBROJEVI.Select;!POSTANSKIBROJEVI.Update"), new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", ImageResourcesNew.page_add, null, "POSTANSKIBROJEVI.Insert"), new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", ImageResourcesNew.page_edit, null, "POSTANSKIBROJEVI.Update"), new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", ImageResourcesNew.page_delete, null, "POSTANSKIBROJEVI.Delete"), new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", ImageResourcesNew.page_copy, null, "POSTANSKIBROJEVI.Insert"), new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", ImageResourcesNew.page_refresh, null, "POSTANSKIBROJEVI.Select"), new UICommandDefinition("FillAll", Deklarit.Resources.Resources.toolLoadAll, this.Site + ".Tasks", ImageResourcesNew.page_save, null, "POSTANSKIBROJEVI.Select"), new UICommandDefinition("Print", Deklarit.Resources.Resources.toolPrint, this.Site + ".Tasks", ImageResourcesNew.printer, null, "POSTANSKIBROJEVI.Select"), new UICommandDefinition("Export", Deklarit.Resources.Resources.toolImportExport, this.Site, false, true, DeklaritMode.All), new UICommandDefinition("ExportExcel", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", ImageResourcesNew.export_excel, null, "POSTANSKIBROJEVI.Select"), new UICommandDefinition("ExportXml", Deklarit.Resources.Resources.toolSaveXml, this.Site + ".Export", ImageResourcesNew.page_white_go, null, "POSTANSKIBROJEVI.Select"), new UICommandDefinition("ImportXml", Deklarit.Resources.Resources.toolLoadXml, this.Site + ".Export", ImageResourcesNew.page_white_get, null, "POSTANSKIBROJEVI.Update"), new UICommandDefinition("UCENIK", "UCENIK", this.Site + ".Relationships", ImageResourcesNew.user_student, null, "UCENIK.Select"), new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All) });
        }
    }
}

