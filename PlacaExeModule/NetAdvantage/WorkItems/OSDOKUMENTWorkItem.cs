namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class OSDOKUMENTWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new OSDOKUMENTDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("OSDOKUMENT", new FormDefinition(this, new OSDOKUMENTFormUserControl(), StringResources.OSDOKUMENTName, StringResources.OSDOKUMENTDescription, "NetAdvantage"));
            this.OSDOKUMENT.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.OSDOKUMENT.Site));
            base.OnInitialized();
        }

        public FormDefinition OSDOKUMENT
        {
            get
            {
                return base.m_FormDefinitionDictionary["OSDOKUMENT"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.OSDOKUMENT;
            }
        }
    }
}

