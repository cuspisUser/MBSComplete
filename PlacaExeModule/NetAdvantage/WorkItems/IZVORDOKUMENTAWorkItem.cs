namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class IZVORDOKUMENTAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new IZVORDOKUMENTADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("IZVORDOKUMENTA", new FormDefinition(this, new IZVORDOKUMENTAFormUserControl(), StringResources.IZVORDOKUMENTAName, StringResources.IZVORDOKUMENTADescription, "NetAdvantage"));
            this.IZVORDOKUMENTA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.IZVORDOKUMENTA.Site));
            base.OnInitialized();
        }

        public FormDefinition IZVORDOKUMENTA
        {
            get
            {
                return base.m_FormDefinitionDictionary["IZVORDOKUMENTA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.IZVORDOKUMENTA;
            }
        }
    }
}

