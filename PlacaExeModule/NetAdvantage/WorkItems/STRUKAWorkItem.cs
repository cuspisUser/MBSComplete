namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class STRUKAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new STRUKADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("STRUKA", new FormDefinition(this, new STRUKAFormUserControl(), StringResources.STRUKAName, StringResources.STRUKADescription, "NetAdvantage"));
            this.STRUKA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.STRUKA.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRADNIK", "Zaposlenici", this.STRUKA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.STRUKA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK", "Zaposlenici", this.STRUKA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.STRUKA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.STRUKA;
            }
        }

        public FormDefinition STRUKA
        {
            get
            {
                return base.m_FormDefinitionDictionary["STRUKA"];
            }
        }
    }
}

