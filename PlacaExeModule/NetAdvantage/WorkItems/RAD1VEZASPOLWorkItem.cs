namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class RAD1VEZASPOLWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new RAD1VEZASPOLDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("RAD1VEZASPOL", new FormDefinition(this, new RAD1VEZASPOLFormUserControl(), StringResources.RAD1VEZASPOLName, StringResources.RAD1VEZASPOLDescription, "NetAdvantage"));
            this.RAD1VEZASPOL.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.RAD1VEZASPOL.Site));
            base.OnInitialized();
        }

        public FormDefinition RAD1VEZASPOL
        {
            get
            {
                return base.m_FormDefinitionDictionary["RAD1VEZASPOL"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.RAD1VEZASPOL;
            }
        }
    }
}

