namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class OTISLIWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new OTISLIDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("OTISLI", new FormDefinition(this, new OTISLIFormUserControl(), StringResources.OTISLIName, StringResources.OTISLIDescription, "NetAdvantage"));
            this.OTISLI.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.OTISLI.Site));
            base.OnInitialized();
        }

        public FormDefinition OTISLI
        {
            get
            {
                return base.m_FormDefinitionDictionary["OTISLI"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.OTISLI;
            }
        }
    }
}

