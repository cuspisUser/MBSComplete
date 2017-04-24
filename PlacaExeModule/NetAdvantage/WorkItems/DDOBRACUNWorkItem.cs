namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class DDOBRACUNWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new DDOBRACUNDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("DDOBRACUN", new FormDefinition(this, new DDOBRACUNFormUserControl(), StringResources.DDOBRACUNName, StringResources.DDOBRACUNDescription, "NetAdvantage"));
            this.DDOBRACUN.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.DDOBRACUN.Site));
            base.OnInitialized();
        }

        public FormDefinition DDOBRACUN
        {
            get
            {
                return base.m_FormDefinitionDictionary["DDOBRACUN"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.DDOBRACUN;
            }
        }
    }
}

