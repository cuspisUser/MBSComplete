namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class GOOBRACUNWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new GOOBRACUNDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("GOOBRACUN", new FormDefinition(this, new GOOBRACUNFormUserControl(), StringResources.GOOBRACUNName, StringResources.GOOBRACUNDescription, "NetAdvantage"));
            this.GOOBRACUN.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.GOOBRACUN.Site));
            base.OnInitialized();
        }

        public FormDefinition GOOBRACUN
        {
            get
            {
                return base.m_FormDefinitionDictionary["GOOBRACUN"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.GOOBRACUN;
            }
        }
    }
}

