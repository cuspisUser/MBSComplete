namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Deklarit.Resources;
    using System;
    using System.Windows.Forms;
    using NetAdvantage.SmartParts;

    public class RADNIKSelectionListWorkItem : SelectionListWorkItemBase
    {
        public RADNIKSelectionListWorkItem() : this(new RADNIKWorkWith(), true)
        {
        }

        public RADNIKSelectionListWorkItem(Control filteredView, bool addCRUDCommands) : this(filteredView, null, addCRUDCommands)
        {
        }

        public RADNIKSelectionListWorkItem(Control filteredView, Control unfilteredView, bool addCrudCommands) : base(filteredView, unfilteredView)
        {
            if (addCrudCommands)
            {
                
                this.UICommandDefinitionContainer.Add(
                    new UICommandDefinition[] { new UICommandDefinition("View", Deklarit.Resources.Resources.toolDisplay, this.Site + ".Tasks", ImageResourcesNew.hand_property, null, "RADNIK.Select;!RADNIK.Update"), 
                    new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", ImageResourcesNew.page_add, null, "RADNIK.Insert"), 
                    new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", ImageResourcesNew.page_edit, null, "RADNIK.Update"), 
                    new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", ImageResourcesNew.page_delete, null, "RADNIK.Delete"), 
                    new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", ImageResourcesNew.page_copy, null, "RADNIK.Insert"), 
                    new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", ImageResourcesNew.page_refresh, null, "RADNIK.Select"), 
                    new UICommandDefinition("FillAll", Deklarit.Resources.Resources.toolLoadAll, this.Site + ".Tasks", ImageResourcesNew.page_save, null, "RADNIK.Select"), 
                    new UICommandDefinition("Print", Deklarit.Resources.Resources.toolPrint, this.Site + ".Tasks", ImageResourcesNew.printer, null, "RADNIK.Select"), 
                    new UICommandDefinition("Export", Deklarit.Resources.Resources.toolExport, this.Site, false, true, DeklaritMode.All), 
                    new UICommandDefinition("ExportExcel", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", ImageResourcesNew.export_excel, null, "RADNIK.Select"), 
                    new UICommandDefinition("GOOBRACUN", "Godišnji odbici i olakšice", this.Site + ".Relationships", ImageResourcesNew.calculator, null, "GOOBRACUN.Select"), 
                    new UICommandDefinition("OTISLI", "OTISLI", this.Site + ".Relationships", ImageResourcesNew.arrow_right, null, "OTISLI.Select"), 
                    new UICommandDefinition("ZAPOSLENI", "ZAPOSLENI", this.Site + ".Relationships", ImageResourcesNew.arrow_down, null, "ZAPOSLENI.Select"), 
                    new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All) });
            }
        }
    }
}

