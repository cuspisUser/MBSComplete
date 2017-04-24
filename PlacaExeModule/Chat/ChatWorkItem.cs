using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deklarit.Practices.CompositeUI.WorkItems;
using Deklarit.Practices.CompositeUI;
using Deklarit.Resources;

namespace Chat
{
    public class ChatWorkItem : MdiWorkItemBase
    {
        public ChatWorkItem()
            : base("Chat", new uscChat())
        {
            this.UICommandDefinitionContainer.Add(new UICommandDefinition[]{

                new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true),
                new UICommandDefinition("Registracija", "Registracija", this.Site + ".Tasks", ImageResourcesNew.user_add, null, null),
                
                new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All)
            });
        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp(id);
        }
    }
}
