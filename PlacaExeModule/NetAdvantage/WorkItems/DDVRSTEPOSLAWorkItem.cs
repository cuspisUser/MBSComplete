namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class DDVRSTEPOSLAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new DDVRSTEPOSLADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("DDVRSTEPOSLA", new FormDefinition(this, new DDVRSTEPOSLAFormUserControl(), StringResources.DDVRSTEPOSLAName, StringResources.DDVRSTEPOSLADescription, "NetAdvantage"));
            this.DDVRSTEPOSLA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.DDVRSTEPOSLA.Site));
            base.OnInitialized();
        }

        public FormDefinition DDVRSTEPOSLA
        {
            get
            {
                return base.m_FormDefinitionDictionary["DDVRSTEPOSLA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.DDVRSTEPOSLA;
            }
        }
    }
}

