namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class DDIZDATAKWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new DDIZDATAKDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("DDIZDATAK", new FormDefinition(this, new DDIZDATAKFormUserControl(), StringResources.DDIZDATAKName, StringResources.DDIZDATAKDescription, "NetAdvantage"));
            this.DDIZDATAK.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.DDIZDATAK.Site));
            base.OnInitialized();
        }

        public FormDefinition DDIZDATAK
        {
            get
            {
                return base.m_FormDefinitionDictionary["DDIZDATAK"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.DDIZDATAK;
            }
        }
    }
}

