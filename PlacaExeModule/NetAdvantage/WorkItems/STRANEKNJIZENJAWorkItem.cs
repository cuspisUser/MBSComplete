namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class STRANEKNJIZENJAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new STRANEKNJIZENJADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("STRANEKNJIZENJA", new FormDefinition(this, new STRANEKNJIZENJAFormUserControl(), StringResources.STRANEKNJIZENJAName, StringResources.STRANEKNJIZENJADescription, "NetAdvantage"));
            this.STRANEKNJIZENJA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.STRANEKNJIZENJA.Site));
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.STRANEKNJIZENJA;
            }
        }

        public FormDefinition STRANEKNJIZENJA
        {
            get
            {
                return base.m_FormDefinitionDictionary["STRANEKNJIZENJA"];
            }
        }
    }
}

