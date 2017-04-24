namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class OSRAZMJESTAJWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new OSRAZMJESTAJDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("OSRAZMJESTAJ", new FormDefinition(this, new OSRAZMJESTAJFormUserControl(), StringResources.OSRAZMJESTAJName, StringResources.OSRAZMJESTAJDescription, "NetAdvantage"));
            this.OSRAZMJESTAJ.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.OSRAZMJESTAJ.Site));
            base.OnInitialized();
        }

        public FormDefinition OSRAZMJESTAJ
        {
            get
            {
                return base.m_FormDefinitionDictionary["OSRAZMJESTAJ"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.OSRAZMJESTAJ;
            }
        }
    }
}

