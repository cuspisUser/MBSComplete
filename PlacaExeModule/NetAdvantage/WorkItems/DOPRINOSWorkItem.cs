namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class DOPRINOSWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new DOPRINOSDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("DOPRINOS", new FormDefinition(this, new DOPRINOSFormUserControl(), StringResources.DOPRINOSName, StringResources.DOPRINOSDescription, "NetAdvantage"));
            this.DOPRINOS.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.DOPRINOS.Site));
            base.OnInitialized();
        }

        public FormDefinition DOPRINOS
        {
            get
            {
                return base.m_FormDefinitionDictionary["DOPRINOS"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.DOPRINOS;
            }
        }
    }
}

