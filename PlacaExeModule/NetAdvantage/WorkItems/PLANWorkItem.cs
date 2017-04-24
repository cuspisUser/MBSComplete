namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class PLANWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new PLANDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("PLAN", new FormDefinition(this, new PLANFormUserControl(), StringResources.PLANName, StringResources.PLANDescription, "NetAdvantage"));
            this.PLAN.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.PLAN.Site));
            base.m_FormDefinitionDictionary.Add("PLANORG", new FormDefinition(this, new PLANFormPLANORGUserControl(), "PLANORG", "ORG", "NetAdvantage"));
            this.PLANORG.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("PLANORGSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.PLANORG.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("PLANORGAddLine", this.ResourceManager.GetString("AddLine"), this.PLANORG.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("PLANORGAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.PLANORG.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("PLANORGDelete", this.ResourceManager.GetString("toolDelete"), this.PLANORG.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("PLANORGKON", new FormDefinition(this, new PLANFormPLANORGKONUserControl(), "PLANORGKON", "KON", "NetAdvantage"));
            this.PLANORGKON.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("PLANORGKONSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.PLANORGKON.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("PLANORGKONAddLine", this.ResourceManager.GetString("AddLine"), this.PLANORGKON.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("PLANORGKONAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.PLANORGKON.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("PLANORGKONDelete", this.ResourceManager.GetString("toolDelete"), this.PLANORGKON.Site, 1, null, DeklaritMode.Delete) });
            base.OnInitialized();
        }

        public FormDefinition PLAN
        {
            get
            {
                return base.m_FormDefinitionDictionary["PLAN"];
            }
        }

        public FormDefinition PLANORG
        {
            get
            {
                return base.m_FormDefinitionDictionary["PLANORG"];
            }
        }

        public FormDefinition PLANORGKON
        {
            get
            {
                return base.m_FormDefinitionDictionary["PLANORGKON"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.PLAN;
            }
        }
    }
}

