namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class OSNOVAOSIGURANJAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new OSNOVAOSIGURANJADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("OSNOVAOSIGURANJA", new FormDefinition(this, new OSNOVAOSIGURANJAFormUserControl(), StringResources.OSNOVAOSIGURANJAName, StringResources.OSNOVAOSIGURANJADescription, "NetAdvantage"));
            this.OSNOVAOSIGURANJA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.OSNOVAOSIGURANJA.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewELEMENT", "Elementi", this.OSNOVAOSIGURANJA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "ELEMENT.Insert"
            };
            this.OSNOVAOSIGURANJA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewELEMENT", "Elementi", this.OSNOVAOSIGURANJA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "ELEMENT.Select"
            };
            this.OSNOVAOSIGURANJA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition OSNOVAOSIGURANJA
        {
            get
            {
                return base.m_FormDefinitionDictionary["OSNOVAOSIGURANJA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.OSNOVAOSIGURANJA;
            }
        }
    }
}

