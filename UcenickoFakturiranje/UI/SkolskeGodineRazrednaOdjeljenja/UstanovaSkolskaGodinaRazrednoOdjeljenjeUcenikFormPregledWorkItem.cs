using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.WorkItems;
using Deklarit.Resources;
using UcenickoFakturiranje.Enums;
using System.Web.UI;

namespace UcenickoFakturiranje.UI.SkolskeGodineRazrednaOdjeljenja
{
    public class UstanovaSkolskaGodinaRazrednoOdjeljenjeUcenikFormPregledWorkItem : SelectionListWorkItemBase
    {
        public List<int> UceniciSelected { get; set; }
        public int? RazrednoOdjeljenjeID { get; set; }

        public UstanovaSkolskaGodinaRazrednoOdjeljenjeUcenikFormPregledWorkItem() : base(new UstanovaSkolskaGodinaRazrednoOdjeljenjeUcenikFormPregled())
        {
            this.UICommandDefinitionContainer.Add(new UICommandDefinition[]{

                new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true),
                new UICommandDefinition("OznaciSve2", "Označi sve", this.Site + ".Tasks", Resources.ImageResourcesNew.page_copy, null, null),
                new UICommandDefinition("OdznaciSve2", "Odznači sve", this.Site + ".Tasks", Resources.ImageResourcesNew.page_copy, null, null),
                new UICommandDefinition("Refresh2", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", Resources.ImageResourcesNew.page_refresh, null, null), 
                //hrvoje 14.08.2013
                new UICommandDefinition("Dodaj", "Novi Učenik", this.Site + ".Tasks", Resources.ImageResourcesNew.page_add, null, null),
                new UICommandDefinition("Export", Deklarit.Resources.Resources.toolImportExport, this.Site, false, true, DeklaritMode.All), 
                new UICommandDefinition("ExportExcel2", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", Resources.ImageResourcesNew.export_excel, null, null), 

            });
        }
        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp(id);
        }
    }
}
