namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class RAD1SPREMEWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new RAD1SPREMEDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("RAD1SPREME", new FormDefinition(this, new RAD1SPREMEFormUserControl(), StringResources.RAD1SPREMEName, StringResources.RAD1SPREMEDescription, "NetAdvantage"));
            this.RAD1SPREME.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.RAD1SPREME.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRAD1SPREMEVEZA", "Veza RAD1 i strucne spreme", this.RAD1SPREME.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RAD1SPREMEVEZA.Insert"
            };
            this.RAD1SPREME.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRAD1SPREMEVEZA", "Veza RAD1 i strucne spreme", this.RAD1SPREME.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RAD1SPREMEVEZA.Select"
            };
            this.RAD1SPREME.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition RAD1SPREME
        {
            get
            {
                return base.m_FormDefinitionDictionary["RAD1SPREME"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.RAD1SPREME;
            }
        }
    }
}

