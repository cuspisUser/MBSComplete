namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Deklarit.Resources;
    using System;
    using NetAdvantage.SmartParts;
    using System.Collections.Generic;

    public class OSWorkWithWorkItem : WorkWithWorkItemBase<OSWorkWith>
    {
        public OSWorkWithWorkItem() : base("OS")
        {
            
            this.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true), new UICommandDefinition("View", Deklarit.Resources.Resources.toolDisplay, this.Site + ".Tasks", ImageResourcesNew.hand_property, null, "OS.Select;!OS.Update"), new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", ImageResourcesNew.page_add, null, "OS.Insert"), new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", ImageResourcesNew.page_edit, null, "OS.Update"), new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", ImageResourcesNew.page_delete, null, "OS.Delete"), new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", ImageResourcesNew.page_copy, null, "OS.Insert"), new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", ImageResourcesNew.page_refresh, null, "OS.Select"), new UICommandDefinition("FillAll", Deklarit.Resources.Resources.toolLoadAll, this.Site + ".Tasks", ImageResourcesNew.page_save, null, "OS.Select"), new UICommandDefinition("Print", Deklarit.Resources.Resources.toolPrint, this.Site + ".Tasks", ImageResourcesNew.printer, null, "OS.Select"), new UICommandDefinition("Export", Deklarit.Resources.Resources.toolExport, this.Site, false, true, DeklaritMode.All), new UICommandDefinition("ExportExcel", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", ImageResourcesNew.export_excel, null, "OS.Select"), new UICommandDefinition("OSRAZMJESTAJ", "OSRAZMJESTAJ", this.Site + ".Relationships", ImageResourcesNew.monitor_go, null, "OSRAZMJESTAJ.Select"), new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All) });
        }

        protected override void OnInitialized()
        {
            IEnumerator<UICommandDefinition> enumerator = this.UICommandDefinitionContainer.GetEnumerator();
            while (enumerator.MoveNext())
            {
                UICommandDefinition current = enumerator.Current;
                if (current.Name.ToString() == "ExportExcel")
                {
                    this.UICommandDefinitionContainer.Delete("ExportExcel");
                }
                if ((current.Parent != null) && (current.Parent.Name.ToString() == "Relationships"))
                {
                    this.UICommandDefinitionContainer.Delete(current.Name);
                }
            }
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Filtriranje") {
                Text = "Filteri",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition7 = new UICommandDefinition("FilterOS") {
                Text = "Prikaži samo OS",
                Site = "MainShellPanel.Filtriranje",
                Image = ImageResourcesNew.monitor
            };
            this.UICommandDefinitionContainer.Add(definition7);
            UICommandDefinition definition8 = new UICommandDefinition("FilterSI") {
                Text = "Prikaži samo SI",
                Site = "MainShellPanel.Filtriranje",
                Image = ImageResourcesNew.pencil
            };
            this.UICommandDefinitionContainer.Add(definition8);
            UICommandDefinition definition9 = new UICommandDefinition("FilterNista") {
                Text = "Prikaži sve",
                Site = "MainShellPanel.Filtriranje",
                Image = ImageResourcesNew.house_two
            };
            this.UICommandDefinitionContainer.Add(definition9);
            UICommandDefinition definition5 = new UICommandDefinition("Dodatno") {
                Text = "Dodatno",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition5);
            UICommandDefinition definition3 = new UICommandDefinition("IspisNaljepnicaMale") {
                Text = "Zebra-male nalj.",
                Site = "MainShellPanel.Dodatno",
                Image = ImageResourcesNew.barcode
            };
            this.UICommandDefinitionContainer.Add(definition3);
            UICommandDefinition definition4 = new UICommandDefinition("IspisNaljepnicaMalePoNosiocu") {
                Text = "Po nositelju ispis nalj.",
                Site = "MainShellPanel.Dodatno",
                Image = ImageResourcesNew.vcard
            };
            this.UICommandDefinitionContainer.Add(definition4);
            UICommandDefinition definition = new UICommandDefinition("DosImport") {
                Text = "OS/SI iz DOS programa",
                Site = "MainShellPanel.Dodatno",
                Image = ImageResourcesNew.application_osx_terminal
            };
            this.UICommandDefinitionContainer.Add(definition);
            UICommandDefinition definition10 = new UICommandDefinition("Izvjestaji") {
                Text = "Izvještaji",
                Site = "MainShellPanel",
                IsCategory = true
            };
            this.UICommandDefinitionContainer.Add(definition10);
            UICommandDefinition definition2 = new UICommandDefinition("BilancaOS") {
                Text = "Stanje OS/SI",
                Site = "MainShellPanel.Izvjestaji",
                Image = ImageResourcesNew.table
            };
            this.UICommandDefinitionContainer.Add(definition2);
            UICommandDefinition definition11 = new UICommandDefinition("KarticaOS") {
                Text = "Kartica OS/SI",
                Site = "MainShellPanel.Izvjestaji",
                Image = ImageResourcesNew.table
            };
            this.UICommandDefinitionContainer.Add(definition11);
        }
    }
}

