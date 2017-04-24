
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.WorkItems;
using System;
using FinPosModule.KarticePartneraUvjeti;

namespace FinPosModule
{

    public class KarticePartneraWorkItem : MdiWorkItemBase
    {
        public KarticePartneraWorkItem() : base("KarticePartneraWorkItem", new KarticePartneraSmartPart())
        {
            UICommandDefinition uiCommandDefinition = new UICommandDefinition("KarticePartnera") {
                Text = "Kartice partnera",
                IsCategory = true,
                Site = "MainShellPanel"
            };
            this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            UICommandDefinition definition = new UICommandDefinition("Kreiraj") {
                Text = "Kreiraj izvještaj/Portrait",
                Site = "MainShellPanel.KarticePartnera",
                Image = ImageResourcesNew.table
            };
            this.UICommandDefinitionContainer.Add(definition);

            UICommandDefinition definition2 = new UICommandDefinition("KreirajLand")
            {
                Text = "Kreiraj izvještaj/LandScape",
                Site = "MainShellPanel.KarticePartnera",
                Image = ImageResourcesNew.table
            };
            this.UICommandDefinitionContainer.Add(definition2);
        }
    }
}

