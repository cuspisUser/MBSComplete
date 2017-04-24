namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class BLGVRSTEDOKWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new BLGVRSTEDOKDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("BLGVRSTEDOK", new FormDefinition(this, new BLGVRSTEDOKFormUserControl(), StringResources.BLGVRSTEDOKName, StringResources.BLGVRSTEDOKDescription, "NetAdvantage"));
            this.BLGVRSTEDOK.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.BLGVRSTEDOK.Site));
            base.OnInitialized();
        }

        public FormDefinition BLGVRSTEDOK
        {
            get
            {
                return base.m_FormDefinitionDictionary["BLGVRSTEDOK"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.BLGVRSTEDOK;
            }
        }
    }
}

