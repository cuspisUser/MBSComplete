using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deklarit.Practices.CompositeUI.WorkItems;
using Deklarit.Practices.CompositeUI;
using Deklarit.Resources;

namespace JOPPD
{
    public class PutniNalogWorkItem : MdiWorkItemBase
    {
        public PutniNalogWorkItem()
            : base("PutniNalog", new uscPutniNalogPregled())
        {
            this.UICommandDefinitionContainer.Add(new UICommandDefinition[]{

                new UICommandDefinition("Tasks", Resources.Tasks, this.Site, true),
                new UICommandDefinition("Insert", Resources.toolInsert, this.Site + ".Tasks", ImageResourcesNew.insert_element, null, null),
                new UICommandDefinition("Update", Resources.toolUpdate, this.Site + ".Tasks", ImageResourcesNew.update, null, null),
                new UICommandDefinition("Delete", Resources.toolDelete, this.Site + ".Tasks", ImageResourcesNew.delete, null, null), 
                new UICommandDefinition("Refresh", Resources.toolRefresh, this.Site + ".Tasks", ImageResourcesNew.page_refresh, null, null), 
                new UICommandDefinition("Virmani", "Virmani", this.Site + ".Tasks", ImageResourcesNew.menu, null, null), 
                
                new UICommandDefinition("Relationships", Resources.toolRelations, this.Site, false, true, DeklaritMode.All)
            });
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp(id);
        }
    }
}
