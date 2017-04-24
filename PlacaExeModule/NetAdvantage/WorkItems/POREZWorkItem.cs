namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class POREZWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new POREZDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("POREZ", new FormDefinition(this, new POREZFormUserControl(), StringResources.POREZName, StringResources.POREZDescription, "NetAdvantage"));
            this.POREZ.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.POREZ.Site));
            base.OnInitialized();
        }

        public FormDefinition POREZ
        {
            get
            {
                return base.m_FormDefinitionDictionary["POREZ"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.POREZ;
            }
        }
    }
}

