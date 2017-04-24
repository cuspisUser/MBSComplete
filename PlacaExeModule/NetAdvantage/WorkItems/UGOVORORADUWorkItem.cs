namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class UGOVORORADUWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new UGOVORORADUDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("UGOVORORADU", new FormDefinition(this, new UGOVORORADUFormUserControl(), StringResources.UGOVORORADUName, StringResources.UGOVORORADUDescription, "NetAdvantage"));
            this.UGOVORORADU.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.UGOVORORADU.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRADNIK", "Zaposlenici", this.UGOVORORADU.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.UGOVORORADU.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK", "Zaposlenici", this.UGOVORORADU.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.UGOVORORADU.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.UGOVORORADU;
            }
        }

        public FormDefinition UGOVORORADU
        {
            get
            {
                return base.m_FormDefinitionDictionary["UGOVORORADU"];
            }
        }
    }
}

