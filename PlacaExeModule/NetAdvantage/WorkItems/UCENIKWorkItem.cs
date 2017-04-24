namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class UCENIKWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new UCENIKDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("UCENIK", new FormDefinition(this, new UCENIKFormUserControl(), StringResources.UCENIKName, StringResources.UCENIKDescription, "NetAdvantage"));
            this.UCENIK.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.UCENIK.Site));
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.UCENIK;
            }
        }

        public FormDefinition UCENIK
        {
            get
            {
                return base.m_FormDefinitionDictionary["UCENIK"];
            }
        }
    }
}

