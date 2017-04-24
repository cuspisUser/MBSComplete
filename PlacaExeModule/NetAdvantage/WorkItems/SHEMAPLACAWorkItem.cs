namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class SHEMAPLACAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new SHEMAPLACADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("SHEMAPLACA", new FormDefinition(this, new SHEMAPLACAFormUserControl(), StringResources.SHEMAPLACAName, StringResources.SHEMAPLACADescription, "NetAdvantage"));
            this.SHEMAPLACA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.SHEMAPLACA.Site));
            base.m_FormDefinitionDictionary.Add("SHEMAPLACASHEMAPLACADOP", new FormDefinition(this, new SHEMAPLACAFormSHEMAPLACASHEMAPLACADOPUserControl(), "SHEMAPLACASHEMAPLACADOP", "Doprinosi", "NetAdvantage"));
            this.SHEMAPLACASHEMAPLACADOP.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("SHEMAPLACASHEMAPLACADOPSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.SHEMAPLACASHEMAPLACADOP.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("SHEMAPLACASHEMAPLACADOPAddLine", this.ResourceManager.GetString("AddLine"), this.SHEMAPLACASHEMAPLACADOP.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("SHEMAPLACASHEMAPLACADOPAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.SHEMAPLACASHEMAPLACADOP.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("SHEMAPLACASHEMAPLACADOPDelete", this.ResourceManager.GetString("toolDelete"), this.SHEMAPLACASHEMAPLACADOP.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("SHEMAPLACASHEMAPLACAELEMENT", new FormDefinition(this, new SHEMAPLACAFormSHEMAPLACASHEMAPLACAELEMENTUserControl(), "SHEMAPLACASHEMAPLACAELEMENT", "SHEMAPLACAELEMENT", "NetAdvantage"));
            this.SHEMAPLACASHEMAPLACAELEMENT.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("SHEMAPLACASHEMAPLACAELEMENTSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.SHEMAPLACASHEMAPLACAELEMENT.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("SHEMAPLACASHEMAPLACAELEMENTAddLine", this.ResourceManager.GetString("AddLine"), this.SHEMAPLACASHEMAPLACAELEMENT.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("SHEMAPLACASHEMAPLACAELEMENTAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.SHEMAPLACASHEMAPLACAELEMENT.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("SHEMAPLACASHEMAPLACAELEMENTDelete", this.ResourceManager.GetString("toolDelete"), this.SHEMAPLACASHEMAPLACAELEMENT.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("SHEMAPLACASHEMAPLACASTANDARD", new FormDefinition(this, new SHEMAPLACAFormSHEMAPLACASHEMAPLACASTANDARDUserControl(), "SHEMAPLACASHEMAPLACASTANDARD", "SHEMAPLACASTANDARD", "NetAdvantage"));
            this.SHEMAPLACASHEMAPLACASTANDARD.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("SHEMAPLACASHEMAPLACASTANDARDSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.SHEMAPLACASHEMAPLACASTANDARD.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("SHEMAPLACASHEMAPLACASTANDARDAddLine", this.ResourceManager.GetString("AddLine"), this.SHEMAPLACASHEMAPLACASTANDARD.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("SHEMAPLACASHEMAPLACASTANDARDAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.SHEMAPLACASHEMAPLACASTANDARD.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("SHEMAPLACASHEMAPLACASTANDARDDelete", this.ResourceManager.GetString("toolDelete"), this.SHEMAPLACASHEMAPLACASTANDARD.Site, 1, null, DeklaritMode.Delete) });
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.SHEMAPLACA;
            }
        }

        public FormDefinition SHEMAPLACA
        {
            get
            {
                return base.m_FormDefinitionDictionary["SHEMAPLACA"];
            }
        }

        public FormDefinition SHEMAPLACASHEMAPLACADOP
        {
            get
            {
                return base.m_FormDefinitionDictionary["SHEMAPLACASHEMAPLACADOP"];
            }
        }

        public FormDefinition SHEMAPLACASHEMAPLACAELEMENT
        {
            get
            {
                return base.m_FormDefinitionDictionary["SHEMAPLACASHEMAPLACAELEMENT"];
            }
        }

        public FormDefinition SHEMAPLACASHEMAPLACASTANDARD
        {
            get
            {
                return base.m_FormDefinitionDictionary["SHEMAPLACASHEMAPLACASTANDARD"];
            }
        }
    }
}

