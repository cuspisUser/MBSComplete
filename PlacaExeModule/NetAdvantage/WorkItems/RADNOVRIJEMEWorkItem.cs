namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class RADNOVRIJEMEWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new RADNOVRIJEMEDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("RADNOVRIJEME", new FormDefinition(this, new RADNOVRIJEMEFormUserControl(), StringResources.RADNOVRIJEMEName, StringResources.RADNOVRIJEMEDescription, "NetAdvantage"));
            this.RADNOVRIJEME.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.RADNOVRIJEME.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRADNIK", "Zaposlenici", this.RADNOVRIJEME.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.RADNOVRIJEME.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK", "Zaposlenici", this.RADNOVRIJEME.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.RADNOVRIJEME.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition RADNOVRIJEME
        {
            get
            {
                return base.m_FormDefinitionDictionary["RADNOVRIJEME"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.RADNOVRIJEME;
            }
        }
    }
}

