namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class GRUPEKOEFWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new GRUPEKOEFDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("GRUPEKOEF", new FormDefinition(this, new GRUPEKOEFFormUserControl(), StringResources.GRUPEKOEFName, StringResources.GRUPEKOEFDescription, "NetAdvantage"));
            this.GRUPEKOEF.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.GRUPEKOEF.Site));
            base.m_FormDefinitionDictionary.Add("GRUPEKOEFLevel1", new FormDefinition(this, new GRUPEKOEFFormGRUPEKOEFLevel1UserControl(), "GRUPEKOEFLevel1", "Elementi u grupi", "NetAdvantage"));
            this.GRUPEKOEFLevel1.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("GRUPEKOEFLevel1SaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.GRUPEKOEFLevel1.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("GRUPEKOEFLevel1AddLine", this.ResourceManager.GetString("AddLine"), this.GRUPEKOEFLevel1.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("GRUPEKOEFLevel1AddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.GRUPEKOEFLevel1.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("GRUPEKOEFLevel1Delete", this.ResourceManager.GetString("toolDelete"), this.GRUPEKOEFLevel1.Site, 1, null, DeklaritMode.Delete) });
            base.OnInitialized();
        }

        public FormDefinition GRUPEKOEF
        {
            get
            {
                return base.m_FormDefinitionDictionary["GRUPEKOEF"];
            }
        }

        public FormDefinition GRUPEKOEFLevel1
        {
            get
            {
                return base.m_FormDefinitionDictionary["GRUPEKOEFLevel1"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.GRUPEKOEF;
            }
        }
    }
}

