namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class RAD1MELEMENTIVEZAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new RAD1MELEMENTIVEZADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("RAD1MELEMENTIVEZA", new FormDefinition(this, new RAD1MELEMENTIVEZAFormUserControl(), StringResources.RAD1MELEMENTIVEZAName, StringResources.RAD1MELEMENTIVEZADescription, "NetAdvantage"));
            this.RAD1MELEMENTIVEZA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.RAD1MELEMENTIVEZA.Site));
            base.OnInitialized();
        }

        public FormDefinition RAD1MELEMENTIVEZA
        {
            get
            {
                return base.m_FormDefinitionDictionary["RAD1MELEMENTIVEZA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.RAD1MELEMENTIVEZA;
            }
        }
    }
}

