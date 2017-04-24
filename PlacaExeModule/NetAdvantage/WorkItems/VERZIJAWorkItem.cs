namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class VERZIJAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new VERZIJADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("VERZIJA", new FormDefinition(this, new VERZIJAFormUserControl(), StringResources.VERZIJAName, StringResources.VERZIJADescription, "NetAdvantage"));
            this.VERZIJA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.VERZIJA.Site));
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.VERZIJA;
            }
        }

        public FormDefinition VERZIJA
        {
            get
            {
                return base.m_FormDefinitionDictionary["VERZIJA"];
            }
        }
    }
}

