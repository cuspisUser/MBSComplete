namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class URAWorkItem : FormWorkItemBase
    {
        public URAWorkItem()
        {
            base.Initialized += new EventHandler(this.URAWorkItem_Initialized);
        }

        public override DataSet CreateDataSet()
        {
            return new URADataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("URA", new FormDefinition(this, new URAFormUserControl(), StringResources.URAName, StringResources.URADescription, "NetAdvantage"));
            this.URA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.URA.Site));
            base.OnInitialized();
        }

        private void URAWorkItem_Initialized(object sender, EventArgs e)
        {
            this.URA.UICommandDefinitionContainer.Delete("SaveAndNew");
            this.URA.UICommandDefinitionContainer.Delete("Save");
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.URA;
            }
        }

        public FormDefinition URA
        {
            get
            {
                return base.m_FormDefinitionDictionary["URA"];
            }
        }
    }
}

