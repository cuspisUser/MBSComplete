namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class BANKEWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new BANKEDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("BANKE", new FormDefinition(this, new BANKEFormUserControl(), StringResources.BANKEName, StringResources.BANKEDescription, "NetAdvantage"));
            this.BANKE.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.BANKE.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewDDRADNIK", "Primatelji DD", this.BANKE.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "DDRADNIK.Insert"
            };
            this.BANKE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewDDRADNIK", "Primatelji DD", this.BANKE.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "DDRADNIK.Select"
            };
            this.BANKE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewRADNIK", "Zaposlenici", this.BANKE.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.BANKE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK", "Zaposlenici", this.BANKE.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.BANKE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition BANKE
        {
            get
            {
                return base.m_FormDefinitionDictionary["BANKE"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.BANKE;
            }
        }
    }
}

