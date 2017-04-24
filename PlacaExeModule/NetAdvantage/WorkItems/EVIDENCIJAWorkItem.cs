namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class EVIDENCIJAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new EVIDENCIJADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("EVIDENCIJA", new FormDefinition(this, new EVIDENCIJAFormUserControl(), StringResources.EVIDENCIJAName, StringResources.EVIDENCIJADescription, "NetAdvantage"));
            this.EVIDENCIJA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.EVIDENCIJA.Site));
            base.OnInitialized();
        }

        public FormDefinition EVIDENCIJA
        {
            get
            {
                return base.m_FormDefinitionDictionary["EVIDENCIJA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.EVIDENCIJA;
            }
        }
    }
}

