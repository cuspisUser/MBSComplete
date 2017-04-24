namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class PROIZVODWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new PROIZVODDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("PROIZVOD", new FormDefinition(this, new PROIZVODFormUserControl(), StringResources.PROIZVODName, StringResources.PROIZVODDescription, "NetAdvantage"));
            this.PROIZVOD.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.PROIZVOD.Site));
            base.OnInitialized();
        }

        public FormDefinition PROIZVOD
        {
            get
            {
                return base.m_FormDefinitionDictionary["PROIZVOD"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.PROIZVOD;
            }
        }
    }
}

