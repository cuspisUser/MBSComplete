namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class SHEMAURAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new SHEMAURADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("SHEMAURA", new FormDefinition(this, new SHEMAURAFormUserControl(), StringResources.SHEMAURAName, StringResources.SHEMAURADescription, "NetAdvantage"));
            this.SHEMAURA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.SHEMAURA.Site));
            base.m_FormDefinitionDictionary.Add("SHEMAURASHEMAURAKONTIRANJE", new FormDefinition(this, new SHEMAURAFormSHEMAURASHEMAURAKONTIRANJEUserControl(), "SHEMAURASHEMAURAKONTIRANJE", "SHEMAURAKONTIRANJE", "NetAdvantage"));
            this.SHEMAURASHEMAURAKONTIRANJE.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("SHEMAURASHEMAURAKONTIRANJESaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.SHEMAURASHEMAURAKONTIRANJE.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("SHEMAURASHEMAURAKONTIRANJEAddLine", this.ResourceManager.GetString("AddLine"), this.SHEMAURASHEMAURAKONTIRANJE.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("SHEMAURASHEMAURAKONTIRANJEAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.SHEMAURASHEMAURAKONTIRANJE.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("SHEMAURASHEMAURAKONTIRANJEDelete", this.ResourceManager.GetString("toolDelete"), this.SHEMAURASHEMAURAKONTIRANJE.Site, 1, null, DeklaritMode.Delete) });
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.SHEMAURA;
            }
        }

        public FormDefinition SHEMAURA
        {
            get
            {
                return base.m_FormDefinitionDictionary["SHEMAURA"];
            }
        }

        public FormDefinition SHEMAURASHEMAURAKONTIRANJE
        {
            get
            {
                return base.m_FormDefinitionDictionary["SHEMAURASHEMAURAKONTIRANJE"];
            }
        }
    }
}

