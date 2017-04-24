namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class OSWorkItem : FormWorkItemBase
    {
        public OSWorkItem()
        {
            base.Initialized += new EventHandler(this.OSWorkItem_Initialized);
        }

        public override DataSet CreateDataSet()
        {
            return new OSDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("OS", new FormDefinition(this, new OSFormUserControl(), StringResources.OSName, StringResources.OSDescription, "NetAdvantage"));
            this.OS.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.OS.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewOSRAZMJESTAJ", "OSRAZMJESTAJ", this.OS.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "OSRAZMJESTAJ.Insert"
            };
            this.OS.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewOSRAZMJESTAJ", "OSRAZMJESTAJ", this.OS.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "OSRAZMJESTAJ.Select"
            };
            this.OS.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.m_FormDefinitionDictionary.Add("OSTEMELJNICA", new FormDefinition(this, new OSFormOSTEMELJNICAUserControl(), "OSTEMELJNICA", "TEMELJNICA", "NetAdvantage"));
            this.OSTEMELJNICA.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("OSTEMELJNICASaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.OSTEMELJNICA.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("OSTEMELJNICAAddLine", this.ResourceManager.GetString("AddLine"), this.OSTEMELJNICA.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("OSTEMELJNICAAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.OSTEMELJNICA.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("OSTEMELJNICADelete", this.ResourceManager.GetString("toolDelete"), this.OSTEMELJNICA.Site, 1, null, DeklaritMode.Delete) });
            base.OnInitialized();
        }

        private void OSWorkItem_Initialized(object sender, EventArgs e)
        {
            this.OS.UICommandDefinitionContainer.Delete("SaveAndNew");
            this.OS.UICommandDefinitionContainer.Delete("Save");
        }

        public FormDefinition OS
        {
            get
            {
                return base.m_FormDefinitionDictionary["OS"];
            }
        }

        public FormDefinition OSTEMELJNICA
        {
            get
            {
                return base.m_FormDefinitionDictionary["OSTEMELJNICA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.OS;
            }
        }
    }
}

