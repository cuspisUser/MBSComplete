namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class IraWorkItem : FormWorkItemBase
    {
        public IraWorkItem()
        {
            base.Initialized += new EventHandler(this.IRAWorkItem_Initialized);
        }

        public override DataSet CreateDataSet()
        {
            return new IRADataSet();
        }

        private void IRAWorkItem_Initialized(object sender, EventArgs e)
        {
            this.IRA.UICommandDefinitionContainer.Delete("SaveAndNew");
            this.IRA.UICommandDefinitionContainer.Delete("Save");
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("IRA", new FormDefinition(this, new IRAFormUserControl(), StringResources.IRAName, StringResources.IRADescription, "NetAdvantage"));
            this.IRA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.IRA.Site));
            base.OnInitialized();
        }

        public FormDefinition IRA
        {
            get
            {
                return base.m_FormDefinitionDictionary["IRA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.IRA;
            }
        }
    }
}

