namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class RAD1SPOLWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new RAD1SPOLDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("RAD1SPOL", new FormDefinition(this, new RAD1SPOLFormUserControl(), StringResources.RAD1SPOLName, StringResources.RAD1SPOLDescription, "NetAdvantage"));
            this.RAD1SPOL.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.RAD1SPOL.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRAD1VEZASPOL", "Veza RAD1 i spol", this.RAD1SPOL.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RAD1VEZASPOL.Insert"
            };
            this.RAD1SPOL.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRAD1VEZASPOL", "Veza RAD1 i spol", this.RAD1SPOL.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RAD1VEZASPOL.Select"
            };
            this.RAD1SPOL.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition RAD1SPOL
        {
            get
            {
                return base.m_FormDefinitionDictionary["RAD1SPOL"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.RAD1SPOL;
            }
        }
    }
}

