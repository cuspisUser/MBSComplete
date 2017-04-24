namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class ZAPOSLENIWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new ZAPOSLENIDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("ZAPOSLENI", new FormDefinition(this, new ZAPOSLENIFormUserControl(), StringResources.ZAPOSLENIName, StringResources.ZAPOSLENIDescription, "NetAdvantage"));
            this.ZAPOSLENI.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.ZAPOSLENI.Site));
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.ZAPOSLENI;
            }
        }

        public FormDefinition ZAPOSLENI
        {
            get
            {
                return base.m_FormDefinitionDictionary["ZAPOSLENI"];
            }
        }
    }
}

