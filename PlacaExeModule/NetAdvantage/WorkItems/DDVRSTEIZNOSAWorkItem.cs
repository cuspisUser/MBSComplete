namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class DDVRSTEIZNOSAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new DDVRSTEIZNOSADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("DDVRSTEIZNOSA", new FormDefinition(this, new DDVRSTEIZNOSAFormUserControl(), StringResources.DDVRSTEIZNOSAName, StringResources.DDVRSTEIZNOSADescription, "NetAdvantage"));
            this.DDVRSTEIZNOSA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.DDVRSTEIZNOSA.Site));
            base.OnInitialized();
        }

        public FormDefinition DDVRSTEIZNOSA
        {
            get
            {
                return base.m_FormDefinitionDictionary["DDVRSTEIZNOSA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.DDVRSTEIZNOSA;
            }
        }
    }
}

