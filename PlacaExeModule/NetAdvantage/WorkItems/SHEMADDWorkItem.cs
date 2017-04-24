namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class SHEMADDWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new SHEMADDDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("SHEMADD", new FormDefinition(this, new SHEMADDFormUserControl(), StringResources.SHEMADDName, StringResources.SHEMADDDescription, "NetAdvantage"));
            this.SHEMADD.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.SHEMADD.Site));
            base.m_FormDefinitionDictionary.Add("SHEMADDSHEMADDDOPRINOS", new FormDefinition(this, new SHEMADDFormSHEMADDSHEMADDDOPRINOSUserControl(), "SHEMADDSHEMADDDOPRINOS", "Doprinosi", "NetAdvantage"));
            this.SHEMADDSHEMADDDOPRINOS.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("SHEMADDSHEMADDDOPRINOSSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.SHEMADDSHEMADDDOPRINOS.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("SHEMADDSHEMADDDOPRINOSAddLine", this.ResourceManager.GetString("AddLine"), this.SHEMADDSHEMADDDOPRINOS.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("SHEMADDSHEMADDDOPRINOSAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.SHEMADDSHEMADDDOPRINOS.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("SHEMADDSHEMADDDOPRINOSDelete", this.ResourceManager.GetString("toolDelete"), this.SHEMADDSHEMADDDOPRINOS.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("SHEMADDSHEMADDSTANDARD", new FormDefinition(this, new SHEMADDFormSHEMADDSHEMADDSTANDARDUserControl(), "SHEMADDSHEMADDSTANDARD", "SHEMADDSTANDARD", "NetAdvantage"));
            this.SHEMADDSHEMADDSTANDARD.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("SHEMADDSHEMADDSTANDARDSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.SHEMADDSHEMADDSTANDARD.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("SHEMADDSHEMADDSTANDARDAddLine", this.ResourceManager.GetString("AddLine"), this.SHEMADDSHEMADDSTANDARD.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("SHEMADDSHEMADDSTANDARDAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.SHEMADDSHEMADDSTANDARD.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("SHEMADDSHEMADDSTANDARDDelete", this.ResourceManager.GetString("toolDelete"), this.SHEMADDSHEMADDSTANDARD.Site, 1, null, DeklaritMode.Delete) });
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.SHEMADD;
            }
        }

        public FormDefinition SHEMADD
        {
            get
            {
                return base.m_FormDefinitionDictionary["SHEMADD"];
            }
        }

        public FormDefinition SHEMADDSHEMADDDOPRINOS
        {
            get
            {
                return base.m_FormDefinitionDictionary["SHEMADDSHEMADDDOPRINOS"];
            }
        }

        public FormDefinition SHEMADDSHEMADDSTANDARD
        {
            get
            {
                return base.m_FormDefinitionDictionary["SHEMADDSHEMADDSTANDARD"];
            }
        }
    }
}

