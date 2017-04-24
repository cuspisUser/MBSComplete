namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class RAD1GELEMENTIVEZAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new RAD1GELEMENTIVEZADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("RAD1GELEMENTIVEZA", new FormDefinition(this, new RAD1GELEMENTIVEZAFormUserControl(), StringResources.RAD1GELEMENTIVEZAName, StringResources.RAD1GELEMENTIVEZADescription, "NetAdvantage"));
            this.RAD1GELEMENTIVEZA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.RAD1GELEMENTIVEZA.Site));
            base.OnInitialized();
        }

        public FormDefinition RAD1GELEMENTIVEZA
        {
            get
            {
                return base.m_FormDefinitionDictionary["RAD1GELEMENTIVEZA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.RAD1GELEMENTIVEZA;
            }
        }
    }
}

