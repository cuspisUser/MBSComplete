using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.WorkItems;
using Deklarit.Resources;

namespace Materijalno.UI.Dokumenti
{
    class InventuraWorkItem : MdiWorkItemBase
    {
        public InventuraWorkItem() : base("InventuraWorkItem", new InventuraFormPregled())
        {
            this.UICommandDefinitionContainer.Add(new UICommandDefinition[]{

                new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true),                
                new UICommandDefinition("Insert", Deklarit.Resources.Resources.toolInsert, this.Site + ".Tasks", Resources.ImageResourcesNew.page_add, null, null),
                //Update SAMO ako Inventura nije unešena kao početno stanje!!
                new UICommandDefinition("Update", Deklarit.Resources.Resources.toolUpdate, this.Site + ".Tasks", Resources.ImageResourcesNew.page_edit, null, null),
                
                //db - 31.01.2017
                //new UICommandDefinition("", "", this.Site + ".Tasks", "", null, null), 
                //new UICommandDefinition("Lock", "Zaključaj", this.Site + ".Tasks", Resources.ImageResourcesNew.key_1_, null, null), 

                //Delete će se koristiti SAMO za potrebe testiranja!!                
                //db 30.01.2017 - brisanje inventura zasad onemogućeno dok se ne dogovori drukčija logika.
                //new UICommandDefinition("Delete", Deklarit.Resources.Resources.toolDelete, this.Site + ".Tasks", Resources.ImageResourcesNew.page_delete, null, null), 

                //new UICommandDefinition("Copy", Deklarit.Resources.Resources.toolCopy, this.Site + ".Tasks", Resources.ImageResourcesNew.page_copy, null,null), 
                //new UICommandDefinition("Refresh", Deklarit.Resources.Resources.toolRefresh, this.Site + ".Tasks", Resources.ImageResourcesNew.page_refresh, null, null), 
                new UICommandDefinition("IspisManjak", "Ispis temeljnice manjka", this.Site + ".Tasks", Resources.ImageResourcesNew.printer, null, null), 
                new UICommandDefinition("IspisVishak", "Ispis temeljnice višak", this.Site + ".Tasks", Resources.ImageResourcesNew.printer, null, null), 
                //new UICommandDefinition("IspisOzn", "Ispis označenih", this.Site + ".Tasks", Resources.ImageResourcesNew.printer, null, null), 
                //new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All)
            });
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp(id);
        }
    }
}
