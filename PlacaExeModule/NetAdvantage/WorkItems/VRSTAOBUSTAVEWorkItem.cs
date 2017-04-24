namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class VRSTAOBUSTAVEWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new VRSTAOBUSTAVEDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("VRSTEOBUSTAVA", new FormDefinition(this, new VRSTAOBUSTAVEFormUserControl(), StringResources.VRSTAOBUSTAVEName, StringResources.VRSTAOBUSTAVEDescription, "NetAdvantage"));
            this.VRSTEOBUSTAVA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.VRSTEOBUSTAVA.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewOBUSTAVA", "Obustave", this.VRSTEOBUSTAVA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "OBUSTAVA.Insert"
            };
            this.VRSTEOBUSTAVA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewOBUSTAVA", "Obustave", this.VRSTEOBUSTAVA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "OBUSTAVA.Select"
            };
            this.VRSTEOBUSTAVA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.VRSTEOBUSTAVA;
            }
        }

        public FormDefinition VRSTEOBUSTAVA
        {
            get
            {
                return base.m_FormDefinitionDictionary["VRSTEOBUSTAVA"];
            }
        }
    }
}

