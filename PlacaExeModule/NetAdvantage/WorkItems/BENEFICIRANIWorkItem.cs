namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class BENEFICIRANIWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new BENEFICIRANIDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("BENEFICIRANI", new FormDefinition(this, new BENEFICIRANIFormUserControl(), StringResources.BENEFICIRANIName, StringResources.BENEFICIRANIDescription, "NetAdvantage"));
            this.BENEFICIRANI.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.BENEFICIRANI.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRADNIK", "Zaposlenici", this.BENEFICIRANI.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.BENEFICIRANI.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK", "Zaposlenici", this.BENEFICIRANI.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.BENEFICIRANI.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition BENEFICIRANI
        {
            get
            {
                return base.m_FormDefinitionDictionary["BENEFICIRANI"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.BENEFICIRANI;
            }
        }
    }
}

