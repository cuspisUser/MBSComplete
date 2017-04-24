using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.WorkItems;
using Deklarit.Resources;
using UcenickoFakturiranje.Enums;

namespace UcenickoFakturiranje.UI.SkolskeGodineRazrednaOdjeljenja
{
    public class UstanovaSkolskaGodinaRazrednoOdjeljenjeFormWorkItem : MdiWorkItemBase
    {
        public FormEditMode FormEditMode { get; set; }
        public int? RazrednoOdjeljenjeID { get; set; }
        public bool kontrola_za_editiranje { get; set; }

        public UstanovaSkolskaGodinaRazrednoOdjeljenjeFormWorkItem()
            : base("USTANOVASKOLSKAGODINARAZREDNOODJELJENJE", new UstanovaSkolskaGodinaRazrednoOdjeljenjeForm())
        {
            this.UICommandDefinitionContainer.Add(new UICommandDefinition[]{

                new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true),
                new UICommandDefinition("DodajUcenika", "Dodaj učenika", this.Site + ".Tasks", Resources.ImageResourcesNew.page_add, null, null),
                new UICommandDefinition("OznaciSve", "Označi sve", this.Site + ".Tasks", Resources.ImageResourcesNew.page_copy, null, null),
                new UICommandDefinition("OdznaciSve", "Odznači sve", this.Site + ".Tasks", Resources.ImageResourcesNew.page_copy, null, null),
                new UICommandDefinition("ObrisiOdabraneUcenike", "Obriši odabrane učenike", this.Site + ".Tasks", Resources.ImageResourcesNew.page_delete, null, null),
                new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", Resources.ImageResourcesNew.page_refresh, null, null), 

                new UICommandDefinition("Export", Deklarit.Resources.Resources.toolImportExport, this.Site, false, true, DeklaritMode.All), 
                new UICommandDefinition("ExportExcel", Deklarit.Resources.Resources.toolExportExcel, this.Site + ".Export", Resources.ImageResourcesNew.export_excel, null, null), 

                new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All)

            });
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp(id);
        }
    }
}
