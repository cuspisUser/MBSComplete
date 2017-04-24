namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Deklarit.Resources;
    using System;
    using System.Windows.Forms;
    using NetAdvantage.SmartParts;

    public class MZOSTABLICESelectionListWorkItem : SelectionListWorkItemBase
    {
        public MZOSTABLICESelectionListWorkItem() : this(new MZOSTABLICEWorkWith(), true)
        {
        }

        public MZOSTABLICESelectionListWorkItem(Control filteredView, bool addCRUDCommands) : this(filteredView, null, addCRUDCommands)
        {
        }

        public MZOSTABLICESelectionListWorkItem(Control filteredView, Control unfilteredView, bool addCrudCommands) : base(filteredView, unfilteredView)
        {
            if (addCrudCommands)
            {
                
                this.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("View", Deklarit.Resources.Resources.toolDisplay, this.Site + ".Tasks", ImageResourcesNew.hand_property, null, "MZOSTABLICE.Select;!MZOSTABLICE.Update"), new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", ImageResourcesNew.page_add, null, "MZOSTABLICE.Insert"), new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", ImageResourcesNew.page_edit, null, "MZOSTABLICE.Update"), new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", ImageResourcesNew.page_delete, null, "MZOSTABLICE.Delete"), new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", ImageResourcesNew.page_copy, null, "MZOSTABLICE.Insert"), new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", ImageResourcesNew.page_refresh, null, "MZOSTABLICE.Select"), new UICommandDefinition("FillAll", Deklarit.Resources.Resources.toolLoadAll, this.Site + ".Tasks", ImageResourcesNew.page_save, null, "MZOSTABLICE.Select"), new UICommandDefinition("Print", Deklarit.Resources.Resources.toolPrint, this.Site + ".Tasks", ImageResourcesNew.printer, null, "MZOSTABLICE.Select"), new UICommandDefinition("Export", Deklarit.Resources.Resources.toolExport, this.Site, false, true, DeklaritMode.All), new UICommandDefinition("ExportExcel", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", ImageResourcesNew.export_excel, null, "MZOSTABLICE.Select"), new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All) });
            }
        }
    }
}

