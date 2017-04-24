namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class STRUCNASPREMAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new STRUCNASPREMADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("STRUCNASPREMA", new FormDefinition(this, new STRUCNASPREMAFormUserControl(), StringResources.STRUCNASPREMAName, StringResources.STRUCNASPREMADescription, "NetAdvantage"));
            this.STRUCNASPREMA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.STRUCNASPREMA.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRAD1SPREMEVEZA", "Veza RAD1 i strucne spreme", this.STRUCNASPREMA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RAD1SPREMEVEZA.Insert"
            };
            this.STRUCNASPREMA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRAD1SPREMEVEZA", "Veza RAD1 i strucne spreme", this.STRUCNASPREMA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RAD1SPREMEVEZA.Select"
            };
            this.STRUCNASPREMA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewRADNIK", "Zaposlenici", this.STRUCNASPREMA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.STRUCNASPREMA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK", "Zaposlenici", this.STRUCNASPREMA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.STRUCNASPREMA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewRADNIK1", "Zaposlenici", this.STRUCNASPREMA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.STRUCNASPREMA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK1", "Zaposlenici", this.STRUCNASPREMA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.STRUCNASPREMA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.STRUCNASPREMA;
            }
        }

        public FormDefinition STRUCNASPREMA
        {
            get
            {
                return base.m_FormDefinitionDictionary["STRUCNASPREMA"];
            }
        }
    }
}

