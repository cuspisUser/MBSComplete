namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class OSOBNIODBITAKWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new OSOBNIODBITAKDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("OSOBNIODBITAK", new FormDefinition(this, new OSOBNIODBITAKFormUserControl(), StringResources.OSOBNIODBITAKName, StringResources.OSOBNIODBITAKDescription, "NetAdvantage"));
            this.OSOBNIODBITAK.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.OSOBNIODBITAK.Site));
            base.OnInitialized();
        }

        public FormDefinition OSOBNIODBITAK
        {
            get
            {
                return base.m_FormDefinitionDictionary["OSOBNIODBITAK"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.OSOBNIODBITAK;
            }
        }
    }
}

