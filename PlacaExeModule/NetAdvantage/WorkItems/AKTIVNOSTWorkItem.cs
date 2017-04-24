namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class AKTIVNOSTWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new AKTIVNOSTDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("AKTIVNOST", new FormDefinition(this, new AKTIVNOSTFormUserControl(), StringResources.AKTIVNOSTName, StringResources.AKTIVNOSTDescription, "NetAdvantage"));
            this.AKTIVNOST.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.AKTIVNOST.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewKONTO", "Kontni plan", this.AKTIVNOST.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "KONTO.Insert"
            };
            this.AKTIVNOST.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewKONTO", "Kontni plan", this.AKTIVNOST.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "KONTO.Select"
            };
            this.AKTIVNOST.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition AKTIVNOST
        {
            get
            {
                return base.m_FormDefinitionDictionary["AKTIVNOST"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.AKTIVNOST;
            }
        }
    }
}

