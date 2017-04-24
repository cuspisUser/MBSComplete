namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class BRACNOSTANJEWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new BRACNOSTANJEDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("BRACNOSTANJE", new FormDefinition(this, new BRACNOSTANJEFormUserControl(), StringResources.BRACNOSTANJEName, StringResources.BRACNOSTANJEDescription, "NetAdvantage"));
            this.BRACNOSTANJE.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.BRACNOSTANJE.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRADNIK", "Zaposlenici", this.BRACNOSTANJE.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.BRACNOSTANJE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK", "Zaposlenici", this.BRACNOSTANJE.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.BRACNOSTANJE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition BRACNOSTANJE
        {
            get
            {
                return base.m_FormDefinitionDictionary["BRACNOSTANJE"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.BRACNOSTANJE;
            }
        }
    }
}

