namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class VIRMANIWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new VIRMANIDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("VIRMANI", new FormDefinition(this, new VIRMANIFormUserControl(), StringResources.VIRMANIName, StringResources.VIRMANIDescription, "NetAdvantage"));
            this.VIRMANI.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.VIRMANI.Site));
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.VIRMANI;
            }
        }

        public FormDefinition VIRMANI
        {
            get
            {
                return base.m_FormDefinitionDictionary["VIRMANI"];
            }
        }
    }
}

