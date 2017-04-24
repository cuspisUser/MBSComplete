namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class URAVRSTAIZNOSAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new URAVRSTAIZNOSADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("URAVRSTAIZNOSA", new FormDefinition(this, new URAVRSTAIZNOSAFormUserControl(), StringResources.URAVRSTAIZNOSAName, StringResources.URAVRSTAIZNOSADescription, "NetAdvantage"));
            this.URAVRSTAIZNOSA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.URAVRSTAIZNOSA.Site));
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.URAVRSTAIZNOSA;
            }
        }

        public FormDefinition URAVRSTAIZNOSA
        {
            get
            {
                return base.m_FormDefinitionDictionary["URAVRSTAIZNOSA"];
            }
        }
    }
}

