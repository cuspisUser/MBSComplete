namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class PLVRSTEIZNOSAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new PLVRSTEIZNOSADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("PLVRSTEIZNOSA", new FormDefinition(this, new PLVRSTEIZNOSAFormUserControl(), StringResources.PLVRSTEIZNOSAName, StringResources.PLVRSTEIZNOSADescription, "NetAdvantage"));
            this.PLVRSTEIZNOSA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.PLVRSTEIZNOSA.Site));
            base.OnInitialized();
        }

        public FormDefinition PLVRSTEIZNOSA
        {
            get
            {
                return base.m_FormDefinitionDictionary["PLVRSTEIZNOSA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.PLVRSTEIZNOSA;
            }
        }
    }
}

