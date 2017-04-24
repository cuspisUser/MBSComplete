namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class AMSKUPINEWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new AMSKUPINEDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("AMSKUPINE", new FormDefinition(this, new AMSKUPINEFormUserControl(), StringResources.AMSKUPINEName, StringResources.AMSKUPINEDescription, "NetAdvantage"));
            this.AMSKUPINE.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.AMSKUPINE.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewOS", "OS", this.AMSKUPINE.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "OS.Insert"
            };
            this.AMSKUPINE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewOS", "OS", this.AMSKUPINE.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "OS.Select"
            };
            this.AMSKUPINE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition AMSKUPINE
        {
            get
            {
                return base.m_FormDefinitionDictionary["AMSKUPINE"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.AMSKUPINE;
            }
        }
    }
}

