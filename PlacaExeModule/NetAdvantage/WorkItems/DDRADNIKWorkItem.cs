namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class DDRADNIKWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new DDRADNIKDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("DDRADNIK", new FormDefinition(this, new DDRADNIKFormUserControl(), StringResources.DDRADNIKName, StringResources.DDRADNIKDescription, "NetAdvantage"));
            this.DDRADNIK.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.DDRADNIK.Site));
            base.OnInitialized();
        }

        public FormDefinition DDRADNIK
        {
            get
            {
                return base.m_FormDefinitionDictionary["DDRADNIK"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.DDRADNIK;
            }
        }
    }
}

