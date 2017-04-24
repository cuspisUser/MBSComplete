namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class DDKATEGORIJAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new DDKATEGORIJADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("DDKATEGORIJA", new FormDefinition(this, new DDKATEGORIJAFormUserControl(), StringResources.DDKATEGORIJAName, StringResources.DDKATEGORIJADescription, "NetAdvantage"));
            this.DDKATEGORIJA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.DDKATEGORIJA.Site));
            base.m_FormDefinitionDictionary.Add("DDKATEGORIJALevel1", new FormDefinition(this, new DDKATEGORIJAFormDDKATEGORIJALevel1UserControl(), "DDKATEGORIJALevel1", "Porezi", "NetAdvantage"));
            this.DDKATEGORIJALevel1.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("DDKATEGORIJALevel1SaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.DDKATEGORIJALevel1.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("DDKATEGORIJALevel1AddLine", this.ResourceManager.GetString("AddLine"), this.DDKATEGORIJALevel1.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("DDKATEGORIJALevel1AddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.DDKATEGORIJALevel1.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("DDKATEGORIJALevel1Delete", this.ResourceManager.GetString("toolDelete"), this.DDKATEGORIJALevel1.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("DDKATEGORIJALevel3", new FormDefinition(this, new DDKATEGORIJAFormDDKATEGORIJALevel3UserControl(), "DDKATEGORIJALevel3", "Doprinosi", "NetAdvantage"));
            this.DDKATEGORIJALevel3.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("DDKATEGORIJALevel3SaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.DDKATEGORIJALevel3.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("DDKATEGORIJALevel3AddLine", this.ResourceManager.GetString("AddLine"), this.DDKATEGORIJALevel3.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("DDKATEGORIJALevel3AddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.DDKATEGORIJALevel3.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("DDKATEGORIJALevel3Delete", this.ResourceManager.GetString("toolDelete"), this.DDKATEGORIJALevel3.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("DDKATEGORIJAIzdaci", new FormDefinition(this, new DDKATEGORIJAFormDDKATEGORIJAIzdaciUserControl(), "DDKATEGORIJAIzdaci", "Izdaci", "NetAdvantage"));
            this.DDKATEGORIJAIzdaci.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("DDKATEGORIJAIzdaciSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.DDKATEGORIJAIzdaci.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("DDKATEGORIJAIzdaciAddLine", this.ResourceManager.GetString("AddLine"), this.DDKATEGORIJAIzdaci.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("DDKATEGORIJAIzdaciAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.DDKATEGORIJAIzdaci.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("DDKATEGORIJAIzdaciDelete", this.ResourceManager.GetString("toolDelete"), this.DDKATEGORIJAIzdaci.Site, 1, null, DeklaritMode.Delete) });
            base.OnInitialized();
        }

        public FormDefinition DDKATEGORIJA
        {
            get
            {
                return base.m_FormDefinitionDictionary["DDKATEGORIJA"];
            }
        }

        public FormDefinition DDKATEGORIJAIzdaci
        {
            get
            {
                return base.m_FormDefinitionDictionary["DDKATEGORIJAIzdaci"];
            }
        }

        public FormDefinition DDKATEGORIJALevel1
        {
            get
            {
                return base.m_FormDefinitionDictionary["DDKATEGORIJALevel1"];
            }
        }

        public FormDefinition DDKATEGORIJALevel3
        {
            get
            {
                return base.m_FormDefinitionDictionary["DDKATEGORIJALevel3"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.DDKATEGORIJA;
            }
        }
    }
}

