namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class VALUTEWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new VALUTEDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("VALUTE", new FormDefinition(this, new VALUTEFormUserControl(), StringResources.VALUTEName, StringResources.VALUTEDescription, "NetAdvantage"));
            this.VALUTE.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.VALUTE.Site));
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.VALUTE;
            }
        }

        public FormDefinition VALUTE
        {
            get
            {
                return base.m_FormDefinitionDictionary["VALUTE"];
            }
        }
    }
}

