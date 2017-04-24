namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class PRPLACEWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new PRPLACEDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("PRPLACE", new FormDefinition(this, new PRPLACEFormUserControl(), StringResources.PRPLACEName, StringResources.PRPLACEDescription, "NetAdvantage"));
            this.PRPLACE.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.PRPLACE.Site));
            base.m_FormDefinitionDictionary.Add("PRPLACEPRPLACEELEMENTI", new FormDefinition(this, new PRPLACEFormPRPLACEPRPLACEELEMENTIUserControl(), "PRPLACEPRPLACEELEMENTI", "Elementi u pripremi", "NetAdvantage"));
            this.PRPLACEPRPLACEELEMENTI.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("PRPLACEPRPLACEELEMENTISaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.PRPLACEPRPLACEELEMENTI.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("PRPLACEPRPLACEELEMENTIAddLine", this.ResourceManager.GetString("AddLine"), this.PRPLACEPRPLACEELEMENTI.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("PRPLACEPRPLACEELEMENTIAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.PRPLACEPRPLACEELEMENTI.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("PRPLACEPRPLACEELEMENTIDelete", this.ResourceManager.GetString("toolDelete"), this.PRPLACEPRPLACEELEMENTI.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("PRPLACEPRPLACEELEMENTIRADNIK", new FormDefinition(this, new PRPLACEFormPRPLACEPRPLACEELEMENTIRADNIKUserControl(), "PRPLACEPRPLACEELEMENTIRADNIK", "Radnici u pripremi", "NetAdvantage"));
            this.PRPLACEPRPLACEELEMENTIRADNIK.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("PRPLACEPRPLACEELEMENTIRADNIKSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.PRPLACEPRPLACEELEMENTIRADNIK.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("PRPLACEPRPLACEELEMENTIRADNIKAddLine", this.ResourceManager.GetString("AddLine"), this.PRPLACEPRPLACEELEMENTIRADNIK.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("PRPLACEPRPLACEELEMENTIRADNIKAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.PRPLACEPRPLACEELEMENTIRADNIK.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("PRPLACEPRPLACEELEMENTIRADNIKDelete", this.ResourceManager.GetString("toolDelete"), this.PRPLACEPRPLACEELEMENTIRADNIK.Site, 1, null, DeklaritMode.Delete) });
            base.OnInitialized();
        }

        public FormDefinition PRPLACE
        {
            get
            {
                return base.m_FormDefinitionDictionary["PRPLACE"];
            }
        }

        public FormDefinition PRPLACEPRPLACEELEMENTI
        {
            get
            {
                return base.m_FormDefinitionDictionary["PRPLACEPRPLACEELEMENTI"];
            }
        }

        public FormDefinition PRPLACEPRPLACEELEMENTIRADNIK
        {
            get
            {
                return base.m_FormDefinitionDictionary["PRPLACEPRPLACEELEMENTIRADNIK"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.PRPLACE;
            }
        }
    }
}

