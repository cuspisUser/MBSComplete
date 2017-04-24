namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class UCENIKRSMIDENTWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new UCENIKRSMIDENTDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("UCENIKRSMIDENT", new FormDefinition(this, new UCENIKRSMIDENTFormUserControl(), StringResources.UCENIKRSMIDENTName, StringResources.UCENIKRSMIDENTDescription, "NetAdvantage"));
            this.UCENIKRSMIDENT.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.UCENIKRSMIDENT.Site));
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.UCENIKRSMIDENT;
            }
        }

        public FormDefinition UCENIKRSMIDENT
        {
            get
            {
                return base.m_FormDefinitionDictionary["UCENIKRSMIDENT"];
            }
        }
    }
}

