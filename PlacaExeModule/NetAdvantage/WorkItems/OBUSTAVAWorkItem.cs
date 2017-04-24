namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class OBUSTAVAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new OBUSTAVADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("OBUSTAVA", new FormDefinition(this, new OBUSTAVAFormUserControl(), StringResources.OBUSTAVAName, StringResources.OBUSTAVADescription, "NetAdvantage"));
            this.OBUSTAVA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.OBUSTAVA.Site));
            base.OnInitialized();
        }

        public FormDefinition OBUSTAVA
        {
            get
            {
                return base.m_FormDefinitionDictionary["OBUSTAVA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.OBUSTAVA;
            }
        }
    }
}

