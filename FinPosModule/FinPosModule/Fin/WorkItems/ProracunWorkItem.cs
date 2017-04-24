
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using System;
using FinPosModule.Proracun;
    
    namespace FinPosModule.Fin.WorkItems
{public class ProracunWorkItem : MdiWorkItemBase
    {
        public ProracunWorkItem() : base("ProracunWorkItem", new ProracunSmartPart())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("Proracun") {
                Text = "Proračunski obrasci",
                IsCategory = true,
                Site = "MainShellPanel"
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("Kreiraj") {
                Text = "Kreiraj izvještaj",
                Site = "MainShellPanel.Proracun",
                Image = ImageResourcesNew.table
            };
            this.UICommandDefinitionContainer.Add(definition);
        }
    }
}

