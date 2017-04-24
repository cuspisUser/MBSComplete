namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class RADNOMJESTOWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new RADNOMJESTODataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("RADNOMJESTO", new FormDefinition(this, new RADNOMJESTOFormUserControl(), StringResources.RADNOMJESTOName, StringResources.RADNOMJESTODescription, "NetAdvantage"));
            this.RADNOMJESTO.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.RADNOMJESTO.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRADNIK", "Zaposlenici", this.RADNOMJESTO.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.RADNOMJESTO.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK", "Zaposlenici", this.RADNOMJESTO.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.RADNOMJESTO.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition RADNOMJESTO
        {
            get
            {
                return base.m_FormDefinitionDictionary["RADNOMJESTO"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.RADNOMJESTO;
            }
        }
    }
}

