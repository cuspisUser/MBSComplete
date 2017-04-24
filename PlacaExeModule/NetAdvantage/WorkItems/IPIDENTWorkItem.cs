namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class IPIDENTWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new IPIDENTDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("IPIDENT", new FormDefinition(this, new IPIDENTFormUserControl(), StringResources.IPIDENTName, StringResources.IPIDENTDescription, "NetAdvantage"));
            this.IPIDENT.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.IPIDENT.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRADNIK", "Zaposlenici", this.IPIDENT.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.IPIDENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK", "Zaposlenici", this.IPIDENT.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.IPIDENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition IPIDENT
        {
            get
            {
                return base.m_FormDefinitionDictionary["IPIDENT"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.IPIDENT;
            }
        }
    }
}

