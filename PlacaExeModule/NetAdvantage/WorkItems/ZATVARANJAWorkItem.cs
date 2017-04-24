namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class ZATVARANJAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new ZATVARANJADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("ZATVARANJA", new FormDefinition(this, new ZATVARANJAFormUserControl(), StringResources.ZATVARANJAName, StringResources.ZATVARANJADescription, "NetAdvantage"));
            this.ZATVARANJA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.ZATVARANJA.Site));
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.ZATVARANJA;
            }
        }

        public FormDefinition ZATVARANJA
        {
            get
            {
                return base.m_FormDefinitionDictionary["ZATVARANJA"];
            }
        }
    }
}

