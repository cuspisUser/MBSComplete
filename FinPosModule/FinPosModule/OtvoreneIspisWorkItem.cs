
using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.WorkItems;
using System;
using FinPosModule.OtvoreneIspis;


namespace FinPosModule
{

    public class OtvoreneIspisWorkItem : MdiWorkItemBase
    {
        public OtvoreneIspisWorkItem() : base("OtvoreneIspisWorkItem", new OtvoreneIspisSmartPart())
        {
            //UICommandDefinition uiCommandDefinition = new UICommandDefinition("Otvorene") {
            //    Text = "Otvorene stavke",
            //    IsCategory = true,
            //    Site = "MainShellPanel"
            //};
            //this.UICommandDefinitionContainer.Add(uiCommandDefinition);
            //UICommandDefinition definition = new UICommandDefinition("Kreiraj") {
            //    Text = "Otvorene stavke dospjele",
            //    Site = "MainShellPanel.Otvorene",
            //    Image = ImageResourcesNew.table
            //};
            //this.UICommandDefinitionContainer.Add(definition);

            //UICommandDefinition definition2 = new UICommandDefinition("KreirajSve")
            //{
            //    Text = "Otvorene stavke sve",
            //    Site = "MainShellPanel.OtvoreneSve",
            //    Image = ImageResourcesNew.table
            //};
            //this.UICommandDefinitionContainer.Add(definition2);

            this.UICommandDefinitionContainer.Add(new UICommandDefinition[]{

                new UICommandDefinition("Tasks", Deklarit.Resources.Resources.Tasks, this.Site, true),
                new UICommandDefinition("Kreiraj", "Otvorene stavke dospjele", this.Site + ".Tasks", Resources.ImageResourcesNew.printer_empty, null, null),
                new UICommandDefinition("KreirajSve", "Otvorene stavke sve", this.Site + ".Tasks", Resources.ImageResourcesNew.processor, null, null),
                new UICommandDefinition("Relationships", Deklarit.Resources.Resources.toolRelations, this.Site, false, true, DeklaritMode.All)

            });

        }
    }
}

