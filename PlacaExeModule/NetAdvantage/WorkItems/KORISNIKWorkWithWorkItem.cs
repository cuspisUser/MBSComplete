namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Deklarit.Resources;
    using System;
    using NetAdvantage.SmartParts;

    public class KORISNIKWorkWithWorkItem : WorkWithWorkItemBase<KORISNIKWorkWith>
    {
        public KORISNIKWorkWithWorkItem() : base("KORISNIK")
        {

            this.UICommandDefinitionContainer.Add(new UICommandDefinition[] { 
                new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true), 
                new UICommandDefinition("View", Deklarit.Resources.Resources.toolDisplay, this.Site + ".Tasks", ImageResourcesNew.hand_property, null, "KORISNIK.Select;!KORISNIK.Update"), 
                new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", ImageResourcesNew.page_add, null, "KORISNIK.Insert"), 
                new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", ImageResourcesNew.page_edit, null, "KORISNIK.Update"), 
                new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", ImageResourcesNew.page_delete, null, "KORISNIK.Delete"), 
                new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", ImageResourcesNew.page_copy, null, "KORISNIK.Insert"), 
                new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", ImageResourcesNew.page_refresh, null, "KORISNIK.Select"), 
                new UICommandDefinition("FillAll", Deklarit.Resources.Resources.toolLoadAll, this.Site + ".Tasks", ImageResourcesNew.page_save, null, "KORISNIK.Select"), 
                new UICommandDefinition("Print", Deklarit.Resources.Resources.toolPrint, this.Site + ".Tasks", ImageResourcesNew.printer, null, "KORISNIK.Select"), 
                new UICommandDefinition("LogoPutanja", "Logo", this.Site + ".Tasks", ImageResourcesNew.locate, null, "KORISNIK.Select"), 
                new UICommandDefinition("Export", Deklarit.Resources.Resources.toolImportExport, this.Site, false, true, DeklaritMode.All), 
                new UICommandDefinition("ExportExcel", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", ImageResourcesNew.export_excel, null, "KORISNIK.Select"), 
                new UICommandDefinition("ExportXml", Deklarit.Resources.Resources.toolSaveXml, this.Site + ".Export", ImageResourcesNew.page_white_go, null, "KORISNIK.Select"), 
                new UICommandDefinition("ImportXml", Deklarit.Resources.Resources.toolLoadXml, this.Site + ".Export", ImageResourcesNew.page_white_get, null, "KORISNIK.Update"), 
                new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All) });
        }
    }
}

