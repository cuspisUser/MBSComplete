namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class TIPIRAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new TIPIRADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("TIPIRA", new FormDefinition(this, new TIPIRAFormUserControl(), StringResources.TIPIRAName, StringResources.TIPIRADescription, "NetAdvantage"));
            this.TIPIRA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.TIPIRA.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewIRA", "IRA", this.TIPIRA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "IRA.Insert"
            };
            this.TIPIRA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewIRA", "IRA", this.TIPIRA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "IRA.Select"
            };
            this.TIPIRA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.TIPIRA;
            }
        }

        public FormDefinition TIPIRA
        {
            get
            {
                return base.m_FormDefinitionDictionary["TIPIRA"];
            }
        }
    }
}

