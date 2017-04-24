namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class VRSTADOPRINOSWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new VRSTADOPRINOSDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("VRSTADOPRINOS", new FormDefinition(this, new VRSTADOPRINOSFormUserControl(), StringResources.VRSTADOPRINOSName, StringResources.VRSTADOPRINOSDescription, "NetAdvantage"));
            this.VRSTADOPRINOS.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.VRSTADOPRINOS.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewDOPRINOS", "Doprinosi", this.VRSTADOPRINOS.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "DOPRINOS.Insert"
            };
            this.VRSTADOPRINOS.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewDOPRINOS", "Doprinosi", this.VRSTADOPRINOS.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "DOPRINOS.Select"
            };
            this.VRSTADOPRINOS.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.VRSTADOPRINOS;
            }
        }

        public FormDefinition VRSTADOPRINOS
        {
            get
            {
                return base.m_FormDefinitionDictionary["VRSTADOPRINOS"];
            }
        }
    }
}

