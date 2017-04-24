namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class RSVRSTEOBVEZNIKAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new RSVRSTEOBVEZNIKADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("RSVRSTEOBVEZNIKA", new FormDefinition(this, new RSVRSTEOBVEZNIKAFormUserControl(), StringResources.RSVRSTEOBVEZNIKAName, StringResources.RSVRSTEOBVEZNIKADescription, "NetAdvantage"));
            this.RSVRSTEOBVEZNIKA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.RSVRSTEOBVEZNIKA.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRSMA", "RSMA", this.RSVRSTEOBVEZNIKA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RSMA.Insert"
            };
            this.RSVRSTEOBVEZNIKA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRSMA", "RSMA", this.RSVRSTEOBVEZNIKA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RSMA.Select"
            };
            this.RSVRSTEOBVEZNIKA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.RSVRSTEOBVEZNIKA;
            }
        }

        public FormDefinition RSVRSTEOBVEZNIKA
        {
            get
            {
                return base.m_FormDefinitionDictionary["RSVRSTEOBVEZNIKA"];
            }
        }
    }
}

