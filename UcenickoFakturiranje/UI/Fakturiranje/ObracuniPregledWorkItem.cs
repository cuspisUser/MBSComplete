using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deklarit.Practices.CompositeUI.WorkItems;
using Deklarit.Practices.CompositeUI;
using Deklarit.Resources;

namespace UcenickoFakturiranje.UI.Fakturiranje
{
    public class ObracuniPregledWorkItem : MdiWorkItemBase
    {
        public ObracuniPregledWorkItem() : base("OBRACUNIPREGLED", new uscObracuniPregled())
        {
            this.UICommandDefinitionContainer.Add(new UICommandDefinition[]{

                new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true),
                new UICommandDefinition("Insert", "Kreiraj obračun", this.Site + ".Tasks", Resources.ImageResourcesNew.page_add, null, null),
                new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", Resources.ImageResourcesNew.page_edit, null, null),
                new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", Resources.ImageResourcesNew.page_delete, null, null), 
                new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", Resources.ImageResourcesNew.page_refresh, null, null), 
                
                new UICommandDefinition("Zavrsi", "Završi obračun", this.Site, false, true, DeklaritMode.All), 
                //new UICommandDefinition("Zakljucaj", "Zaključaj/Otključaj obračun", this.Site + ".Zavrsi", Resources.ImageResourcesNew.lock_add, null, null), 
                //new UICommandDefinition("Zaduzi", "Financijski zaduži", this.Site + ".Zavrsi", Resources.ImageResourcesNew.money_in_envelope, null, null), 
                //new UICommandDefinition("Virmani", "Virmani", this.Site + ".Zavrsi", Resources.ImageResourcesNew.menu, null, null), 
                //new UICommandDefinition("VirmaniPojedinacno", "Virmani za odabrane", this.Site + ".Zavrsi", Resources.ImageResourcesNew.menu, null, null), 
                //new UICommandDefinition("RacuniPojedinacno", "Računi za odabrane", this.Site + ".Zavrsi", Resources.ImageResourcesNew.menu, null, null), 
                new UICommandDefinition("Racuni", "Računi", this.Site + ".Zavrsi", Resources.ImageResourcesNew.menu, null, null), 

                new UICommandDefinition("Ispis", "Ispis", this.Site, false, true, DeklaritMode.All), 
                new UICommandDefinition("Rekapitulacija", "Rekapitulacija", this.Site + ".Ispis", Resources.ImageResourcesNew.printer, null, null),
                new UICommandDefinition("RekapitulacijaRazrednoOdjeljenje", "Rkp. po razrednom odjeljenju", this.Site + ".Ispis", Resources.ImageResourcesNew.printer, null, null),

                new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All)

            });
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp(id);
        }
    }
    
}
