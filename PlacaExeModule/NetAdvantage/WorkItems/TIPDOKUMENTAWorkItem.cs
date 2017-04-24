namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class TIPDOKUMENTAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new TIPDOKUMENTADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("TIPDOKUMENTA", new FormDefinition(this, new TIPDOKUMENTAFormUserControl(), StringResources.TIPDOKUMENTAName, StringResources.TIPDOKUMENTADescription, "NetAdvantage"));
            this.TIPDOKUMENTA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.TIPDOKUMENTA.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewDOKUMENT", "DOKUMENT", this.TIPDOKUMENTA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "DOKUMENT.Insert"
            };
            this.TIPDOKUMENTA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewDOKUMENT", "DOKUMENT", this.TIPDOKUMENTA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "DOKUMENT.Select"
            };
            this.TIPDOKUMENTA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.TIPDOKUMENTA;
            }
        }

        public FormDefinition TIPDOKUMENTA
        {
            get
            {
                return base.m_FormDefinitionDictionary["TIPDOKUMENTA"];
            }
        }
    }
}

