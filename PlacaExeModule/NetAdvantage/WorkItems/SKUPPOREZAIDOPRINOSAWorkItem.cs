namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class SKUPPOREZAIDOPRINOSAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new SKUPPOREZAIDOPRINOSADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("SKUPPOREZAIDOPRINOSA", new FormDefinition(this, new SKUPPOREZAIDOPRINOSAFormUserControl(), StringResources.SKUPPOREZAIDOPRINOSAName, StringResources.SKUPPOREZAIDOPRINOSADescription, "NetAdvantage"));
            this.SKUPPOREZAIDOPRINOSA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.SKUPPOREZAIDOPRINOSA.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRADNIK", "Zaposlenici", this.SKUPPOREZAIDOPRINOSA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.SKUPPOREZAIDOPRINOSA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK", "Zaposlenici", this.SKUPPOREZAIDOPRINOSA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.SKUPPOREZAIDOPRINOSA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.m_FormDefinitionDictionary.Add("SKUPPOREZAIDOPRINOSA1", new FormDefinition(this, new SKUPPOREZAIDOPRINOSAFormSKUPPOREZAIDOPRINOSA1UserControl(), "SKUPPOREZAIDOPRINOSA1", "Porezi", "NetAdvantage"));
            this.SKUPPOREZAIDOPRINOSA1.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("SKUPPOREZAIDOPRINOSA1SaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.SKUPPOREZAIDOPRINOSA1.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("SKUPPOREZAIDOPRINOSA1AddLine", this.ResourceManager.GetString("AddLine"), this.SKUPPOREZAIDOPRINOSA1.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("SKUPPOREZAIDOPRINOSA1AddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.SKUPPOREZAIDOPRINOSA1.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("SKUPPOREZAIDOPRINOSA1Delete", this.ResourceManager.GetString("toolDelete"), this.SKUPPOREZAIDOPRINOSA1.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("SKUPPOREZAIDOPRINOSA2", new FormDefinition(this, new SKUPPOREZAIDOPRINOSAFormSKUPPOREZAIDOPRINOSA2UserControl(), "SKUPPOREZAIDOPRINOSA2", "Doprinosi", "NetAdvantage"));
            this.SKUPPOREZAIDOPRINOSA2.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("SKUPPOREZAIDOPRINOSA2SaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.SKUPPOREZAIDOPRINOSA2.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("SKUPPOREZAIDOPRINOSA2AddLine", this.ResourceManager.GetString("AddLine"), this.SKUPPOREZAIDOPRINOSA2.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("SKUPPOREZAIDOPRINOSA2AddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.SKUPPOREZAIDOPRINOSA2.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("SKUPPOREZAIDOPRINOSA2Delete", this.ResourceManager.GetString("toolDelete"), this.SKUPPOREZAIDOPRINOSA2.Site, 1, null, DeklaritMode.Delete) });
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.SKUPPOREZAIDOPRINOSA;
            }
        }

        public FormDefinition SKUPPOREZAIDOPRINOSA
        {
            get
            {
                return base.m_FormDefinitionDictionary["SKUPPOREZAIDOPRINOSA"];
            }
        }

        public FormDefinition SKUPPOREZAIDOPRINOSA1
        {
            get
            {
                return base.m_FormDefinitionDictionary["SKUPPOREZAIDOPRINOSA1"];
            }
        }

        public FormDefinition SKUPPOREZAIDOPRINOSA2
        {
            get
            {
                return base.m_FormDefinitionDictionary["SKUPPOREZAIDOPRINOSA2"];
            }
        }
    }
}

