namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class SMJENEWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new SMJENEDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("SMJENE", new FormDefinition(this, new SMJENEFormUserControl(), StringResources.SMJENEName, StringResources.SMJENEDescription, "NetAdvantage"));
            this.SMJENE.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.SMJENE.Site));
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.SMJENE;
            }
        }

        public FormDefinition SMJENE
        {
            get
            {
                return base.m_FormDefinitionDictionary["SMJENE"];
            }
        }
    }
}

