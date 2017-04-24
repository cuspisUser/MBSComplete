namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class KRIZNIPOREZWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new KRIZNIPOREZDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("KRIZNIPOREZ", new FormDefinition(this, new KRIZNIPOREZFormUserControl(), StringResources.KRIZNIPOREZName, StringResources.KRIZNIPOREZDescription, "NetAdvantage"));
            this.KRIZNIPOREZ.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.KRIZNIPOREZ.Site));
            base.OnInitialized();
        }

        public FormDefinition KRIZNIPOREZ
        {
            get
            {
                return base.m_FormDefinitionDictionary["KRIZNIPOREZ"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.KRIZNIPOREZ;
            }
        }
    }
}

