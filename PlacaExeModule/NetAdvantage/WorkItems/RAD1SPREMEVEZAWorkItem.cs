namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class RAD1SPREMEVEZAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new RAD1SPREMEVEZADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("RAD1SPREMEVEZA", new FormDefinition(this, new RAD1SPREMEVEZAFormUserControl(), StringResources.RAD1SPREMEVEZAName, StringResources.RAD1SPREMEVEZADescription, "NetAdvantage"));
            this.RAD1SPREMEVEZA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.RAD1SPREMEVEZA.Site));
            base.OnInitialized();
        }

        public FormDefinition RAD1SPREMEVEZA
        {
            get
            {
                return base.m_FormDefinitionDictionary["RAD1SPREMEVEZA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.RAD1SPREMEVEZA;
            }
        }
    }
}

