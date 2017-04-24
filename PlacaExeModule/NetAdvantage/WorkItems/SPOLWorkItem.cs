namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class SPOLWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new SPOLDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("SPOL", new FormDefinition(this, new SPOLFormUserControl(), StringResources.SPOLName, StringResources.SPOLDescription, "NetAdvantage"));
            this.SPOL.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.SPOL.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRAD1VEZASPOL", "Veza RAD1 i spol", this.SPOL.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RAD1VEZASPOL.Insert"
            };
            this.SPOL.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRAD1VEZASPOL", "Veza RAD1 i spol", this.SPOL.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RAD1VEZASPOL.Select"
            };
            this.SPOL.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewRADNIK", "Zaposlenici", this.SPOL.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.SPOL.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK", "Zaposlenici", this.SPOL.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.SPOL.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.SPOL;
            }
        }

        public FormDefinition SPOL
        {
            get
            {
                return base.m_FormDefinitionDictionary["SPOL"];
            }
        }
    }
}

