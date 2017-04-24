namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class DDKOLONAIDDWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new DDKOLONAIDDDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("DDKOLONAIDD", new FormDefinition(this, new DDKOLONAIDDFormUserControl(), StringResources.DDKOLONAIDDName, StringResources.DDKOLONAIDDDescription, "NetAdvantage"));
            this.DDKOLONAIDD.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.DDKOLONAIDD.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewDDKATEGORIJA", "Kategorija drugog dohotka", this.DDKOLONAIDD.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "DDKATEGORIJA.Insert"
            };
            this.DDKOLONAIDD.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewDDKATEGORIJA", "Kategorija drugog dohotka", this.DDKOLONAIDD.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "DDKATEGORIJA.Select"
            };
            this.DDKOLONAIDD.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition DDKOLONAIDD
        {
            get
            {
                return base.m_FormDefinitionDictionary["DDKOLONAIDD"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.DDKOLONAIDD;
            }
        }
    }
}

