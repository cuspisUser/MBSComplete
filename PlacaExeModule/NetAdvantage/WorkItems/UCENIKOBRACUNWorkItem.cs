namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class UCENIKOBRACUNWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new UCENIKOBRACUNDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("UCENIKOBRACUN", new FormDefinition(this, new UCENIKOBRACUNFormUserControl(), StringResources.UCENIKOBRACUNName, StringResources.UCENIKOBRACUNDescription, "NetAdvantage"));
            this.UCENIKOBRACUN.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.UCENIKOBRACUN.Site));
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.UCENIKOBRACUN;
            }
        }

        public FormDefinition UCENIKOBRACUN
        {
            get
            {
                return base.m_FormDefinitionDictionary["UCENIKOBRACUN"];
            }
        }
    }
}

