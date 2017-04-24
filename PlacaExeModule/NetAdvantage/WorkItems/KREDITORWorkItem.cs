namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class KREDITORWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new KREDITORDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("KREDITOR", new FormDefinition(this, new KREDITORFormUserControl(), StringResources.KREDITORName, StringResources.KREDITORDescription, "NetAdvantage"));
            this.KREDITOR.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.KREDITOR.Site));
            base.OnInitialized();
        }

        public FormDefinition KREDITOR
        {
            get
            {
                return base.m_FormDefinitionDictionary["KREDITOR"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.KREDITOR;
            }
        }
    }
}

