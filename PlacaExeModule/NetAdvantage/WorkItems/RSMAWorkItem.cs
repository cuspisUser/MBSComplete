namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class RSMAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new RSMADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("RSMA", new FormDefinition(this, new RSMAFormUserControl(), StringResources.RSMAName, StringResources.RSMADescription, "NetAdvantage"));
            this.RSMA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.RSMA.Site));
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.RSMA;
            }
        }

        public FormDefinition RSMA
        {
            get
            {
                return base.m_FormDefinitionDictionary["RSMA"];
            }
        }
    }
}

