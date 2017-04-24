namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class BLAGAJNAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new BLAGAJNADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("BLAGAJNA", new FormDefinition(this, new BLAGAJNAFormUserControl(), StringResources.BLAGAJNAName, StringResources.BLAGAJNADescription, "NetAdvantage"));
            this.BLAGAJNA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.BLAGAJNA.Site));
            base.m_FormDefinitionDictionary.Add("BLAGAJNAStavkeBlagajne", new FormDefinition(this, new BLAGAJNAFormBLAGAJNAStavkeBlagajneUserControl(), "BLAGAJNAStavkeBlagajne", "StavkeBlagajne", "NetAdvantage"));
            this.BLAGAJNAStavkeBlagajne.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("BLAGAJNAStavkeBlagajneSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.BLAGAJNAStavkeBlagajne.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("BLAGAJNAStavkeBlagajneAddLine", this.ResourceManager.GetString("AddLine"), this.BLAGAJNAStavkeBlagajne.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("BLAGAJNAStavkeBlagajneAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.BLAGAJNAStavkeBlagajne.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("BLAGAJNAStavkeBlagajneDelete", this.ResourceManager.GetString("toolDelete"), this.BLAGAJNAStavkeBlagajne.Site, 1, null, DeklaritMode.Delete) });
            base.OnInitialized();
        }

        public FormDefinition BLAGAJNA
        {
            get
            {
                return base.m_FormDefinitionDictionary["BLAGAJNA"];
            }
        }

        public FormDefinition BLAGAJNAStavkeBlagajne
        {
            get
            {
                return base.m_FormDefinitionDictionary["BLAGAJNAStavkeBlagajne"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.BLAGAJNA;
            }
        }
    }
}

