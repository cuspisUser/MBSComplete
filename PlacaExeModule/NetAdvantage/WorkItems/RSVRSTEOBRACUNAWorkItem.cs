namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class RSVRSTEOBRACUNAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new RSVRSTEOBRACUNADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("RSVRSTEOBRACUNA", new FormDefinition(this, new RSVRSTEOBRACUNAFormUserControl(), StringResources.RSVRSTEOBRACUNAName, StringResources.RSVRSTEOBRACUNADescription, "NetAdvantage"));
            this.RSVRSTEOBRACUNA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.RSVRSTEOBRACUNA.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRSMA", "RSMA", this.RSVRSTEOBRACUNA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RSMA.Insert"
            };
            this.RSVRSTEOBRACUNA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRSMA", "RSMA", this.RSVRSTEOBRACUNA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RSMA.Select"
            };
            this.RSVRSTEOBRACUNA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.RSVRSTEOBRACUNA;
            }
        }

        public FormDefinition RSVRSTEOBRACUNA
        {
            get
            {
                return base.m_FormDefinitionDictionary["RSVRSTEOBRACUNA"];
            }
        }
    }
}

