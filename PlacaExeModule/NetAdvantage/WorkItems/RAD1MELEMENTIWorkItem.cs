namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class RAD1MELEMENTIWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new RAD1MELEMENTIDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("RAD1MELEMENTI", new FormDefinition(this, new RAD1MELEMENTIFormUserControl(), StringResources.RAD1MELEMENTIName, StringResources.RAD1MELEMENTIDescription, "NetAdvantage"));
            this.RAD1MELEMENTI.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.RAD1MELEMENTI.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRAD1MELEMENTIVEZA", "Veza RAD1M elementi i elementi", this.RAD1MELEMENTI.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RAD1MELEMENTIVEZA.Insert"
            };
            this.RAD1MELEMENTI.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRAD1MELEMENTIVEZA", "Veza RAD1M elementi i elementi", this.RAD1MELEMENTI.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RAD1MELEMENTIVEZA.Select"
            };
            this.RAD1MELEMENTI.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition RAD1MELEMENTI
        {
            get
            {
                return base.m_FormDefinitionDictionary["RAD1MELEMENTI"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.RAD1MELEMENTI;
            }
        }
    }
}

