namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class TIPIZNOSAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new TIPIZNOSADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("TIPIZNOSA", new FormDefinition(this, new TIPIZNOSAFormUserControl(), StringResources.TIPIZNOSAName, StringResources.TIPIZNOSADescription, "NetAdvantage"));
            this.TIPIZNOSA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.TIPIZNOSA.Site));
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.TIPIZNOSA;
            }
        }

        public FormDefinition TIPIZNOSA
        {
            get
            {
                return base.m_FormDefinitionDictionary["TIPIZNOSA"];
            }
        }
    }
}

