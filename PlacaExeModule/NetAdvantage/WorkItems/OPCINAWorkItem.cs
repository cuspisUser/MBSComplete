namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class OPCINAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new OPCINADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("OPCINA", new FormDefinition(this, new OPCINAFormUserControl(), StringResources.OPCINAName, StringResources.OPCINADescription, "NetAdvantage"));
            this.OPCINA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.OPCINA.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewDDRADNIK1", "Primatelji DD", this.OPCINA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "DDRADNIK.Insert"
            };
            this.OPCINA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewDDRADNIK1", "Primatelji DD", this.OPCINA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "DDRADNIK.Select"
            };
            this.OPCINA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewDDRADNIK", "Primatelji DD", this.OPCINA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "DDRADNIK.Insert"
            };
            this.OPCINA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewDDRADNIK", "Primatelji DD", this.OPCINA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "DDRADNIK.Select"
            };
            this.OPCINA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewRADNIK1", "Zaposlenici", this.OPCINA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.OPCINA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK1", "Zaposlenici", this.OPCINA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.OPCINA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewRADNIK", "Zaposlenici", this.OPCINA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.OPCINA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK", "Zaposlenici", this.OPCINA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.OPCINA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition OPCINA
        {
            get
            {
                return base.m_FormDefinitionDictionary["OPCINA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.OPCINA;
            }
        }
    }
}

