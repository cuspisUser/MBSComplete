using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.WorkItems;
using Deklarit.Resources;

namespace Materijalno.UI.Dokumenti
{
    public class IzdatnicaWorkItem : MdiWorkItemBase
    {
        public IzdatnicaWorkItem()
            : base("IzdatnicaWorkItem", new IzdatnicaFormPregled())
        {
            this.UICommandDefinitionContainer.Add(new UICommandDefinition[]{

                new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true),
                new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", Resources.ImageResourcesNew.page_add, null, null),
                new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", Resources.ImageResourcesNew.page_edit, null, null),
                //new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", Resources.ImageResourcesNew.page_delete, null, null), 
                new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", Resources.ImageResourcesNew.page_copy, null,null), 
                new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", Resources.ImageResourcesNew.page_refresh, null, null), 
                new UICommandDefinition("Ispis", "Ispis", this.Site + ".Tasks", Resources.ImageResourcesNew.printer, null, null), 
                new UICommandDefinition("IspisOzn", "Ispis označenih", this.Site + ".Tasks", Resources.ImageResourcesNew.printer, null, null), 
                new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All)
            });
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp(id);
        }
    }
}