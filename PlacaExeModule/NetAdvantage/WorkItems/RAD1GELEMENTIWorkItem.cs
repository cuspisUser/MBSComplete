namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class RAD1GELEMENTIWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new RAD1GELEMENTIDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("RAD1GELEMENTI", new FormDefinition(this, new RAD1GELEMENTIFormUserControl(), StringResources.RAD1GELEMENTIName, StringResources.RAD1GELEMENTIDescription, "NetAdvantage"));
            this.RAD1GELEMENTI.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.RAD1GELEMENTI.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRAD1GELEMENTIVEZA", "Veza elementi RAD1G i elementi", this.RAD1GELEMENTI.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RAD1GELEMENTIVEZA.Insert"
            };
            this.RAD1GELEMENTI.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRAD1GELEMENTIVEZA", "Veza elementi RAD1G i elementi", this.RAD1GELEMENTI.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RAD1GELEMENTIVEZA.Select"
            };
            this.RAD1GELEMENTI.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition RAD1GELEMENTI
        {
            get
            {
                return base.m_FormDefinitionDictionary["RAD1GELEMENTI"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.RAD1GELEMENTI;
            }
        }
    }
}

