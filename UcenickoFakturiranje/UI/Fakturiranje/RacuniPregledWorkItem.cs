using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deklarit.Practices.CompositeUI.WorkItems;
using Deklarit.Practices.CompositeUI;
using Deklarit.Resources;

namespace UcenickoFakturiranje.UI.Fakturiranje
{
    public class RacuniPregledWorkItem : MdiWorkItemBase
    {
        public RacuniPregledWorkItem()
            : base("RacuniPregled", new uscRacuniPregled())
        {
            this.UICommandDefinitionContainer.Add(new UICommandDefinition[]{

                new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true),
                new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", Resources.ImageResourcesNew.page_edit, null, null),
                new UICommandDefinition("Storno", "Storno označenih", this.Site + ".Tasks", Resources.ImageResourcesNew.newsvine, null, null), 
                new UICommandDefinition("PrijenosGKOznaceni", "Prijenos u GK označenih", this.Site + ".Tasks", Resources.ImageResourcesNew.money_in_envelope, null, null), 
                new UICommandDefinition("PrijenosGKPoBroju", "Prijenos u GK po broju", this.Site + ".Tasks", Resources.ImageResourcesNew.money_in_envelope, null, null), 
                new UICommandDefinition("IspisOzn", "Ispis označenih", this.Site + ".Tasks", Resources.ImageResourcesNew.printer, null, null), 
                new UICommandDefinition("IspisPoBroju", "Ispis po broju", this.Site + ".Tasks", Resources.ImageResourcesNew.printer, null, null), 
                new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", Resources.ImageResourcesNew.page_refresh, null, null),

                new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All)

            });
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp(id);
        }
    }
    
}
