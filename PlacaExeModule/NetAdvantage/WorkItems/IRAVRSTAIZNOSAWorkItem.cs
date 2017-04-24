namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class IRAVRSTAIZNOSAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new IRAVRSTAIZNOSADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("IRAVRSTAIZNOSA", new FormDefinition(this, new IRAVRSTAIZNOSAFormUserControl(), StringResources.IRAVRSTAIZNOSAName, StringResources.IRAVRSTAIZNOSADescription, "NetAdvantage"));
            this.IRAVRSTAIZNOSA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.IRAVRSTAIZNOSA.Site));
            base.OnInitialized();
        }

        public FormDefinition IRAVRSTAIZNOSA
        {
            get
            {
                return base.m_FormDefinitionDictionary["IRAVRSTAIZNOSA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.IRAVRSTAIZNOSA;
            }
        }
    }
}

