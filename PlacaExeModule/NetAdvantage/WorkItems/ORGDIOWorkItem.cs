namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class ORGDIOWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new ORGDIODataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("ORGDIO", new FormDefinition(this, new ORGDIOFormUserControl(), StringResources.ORGDIOName, StringResources.ORGDIODescription, "NetAdvantage"));
            this.ORGDIO.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.ORGDIO.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRADNIK", "Zaposlenici", this.ORGDIO.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.ORGDIO.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK", "Zaposlenici", this.ORGDIO.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.ORGDIO.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition ORGDIO
        {
            get
            {
                return base.m_FormDefinitionDictionary["ORGDIO"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.ORGDIO;
            }
        }
    }
}

