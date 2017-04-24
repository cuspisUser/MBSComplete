namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class BOLOVANJEFONDWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new BOLOVANJEFONDDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("BOLOVANJEFOND", new FormDefinition(this, new BOLOVANJEFONDFormUserControl(), StringResources.BOLOVANJEFONDName, StringResources.BOLOVANJEFONDDescription, "NetAdvantage"));
            this.BOLOVANJEFOND.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.BOLOVANJEFOND.Site));
            base.OnInitialized();
        }

        public FormDefinition BOLOVANJEFOND
        {
            get
            {
                return base.m_FormDefinitionDictionary["BOLOVANJEFOND"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.BOLOVANJEFOND;
            }
        }
    }
}

