namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class OSVRSTAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new OSVRSTADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("OSVRSTA", new FormDefinition(this, new OSVRSTAFormUserControl(), StringResources.OSVRSTAName, StringResources.OSVRSTADescription, "NetAdvantage"));
            this.OSVRSTA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.OSVRSTA.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewOS", "OS", this.OSVRSTA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "OS.Insert"
            };
            this.OSVRSTA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewOS", "OS", this.OSVRSTA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "OS.Select"
            };
            this.OSVRSTA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition OSVRSTA
        {
            get
            {
                return base.m_FormDefinitionDictionary["OSVRSTA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.OSVRSTA;
            }
        }
    }
}

