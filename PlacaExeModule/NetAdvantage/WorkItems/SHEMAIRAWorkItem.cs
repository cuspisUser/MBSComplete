namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class SHEMAIRAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new SHEMAIRADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("SHEMAIRA", new FormDefinition(this, new SHEMAIRAFormUserControl(), StringResources.SHEMAIRAName, StringResources.SHEMAIRADescription, "NetAdvantage"));
            this.SHEMAIRA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.SHEMAIRA.Site));
            base.m_FormDefinitionDictionary.Add("SHEMAIRASHEMAIRAKONTIRANJE", new FormDefinition(this, new SHEMAIRAFormSHEMAIRASHEMAIRAKONTIRANJEUserControl(), "SHEMAIRASHEMAIRAKONTIRANJE", "SHEMAIRAKONTIRANJE", "NetAdvantage"));
            this.SHEMAIRASHEMAIRAKONTIRANJE.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("SHEMAIRASHEMAIRAKONTIRANJESaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.SHEMAIRASHEMAIRAKONTIRANJE.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("SHEMAIRASHEMAIRAKONTIRANJEAddLine", this.ResourceManager.GetString("AddLine"), this.SHEMAIRASHEMAIRAKONTIRANJE.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("SHEMAIRASHEMAIRAKONTIRANJEAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.SHEMAIRASHEMAIRAKONTIRANJE.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("SHEMAIRASHEMAIRAKONTIRANJEDelete", this.ResourceManager.GetString("toolDelete"), this.SHEMAIRASHEMAIRAKONTIRANJE.Site, 1, null, DeklaritMode.Delete) });
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.SHEMAIRA;
            }
        }

        public FormDefinition SHEMAIRA
        {
            get
            {
                return base.m_FormDefinitionDictionary["SHEMAIRA"];
            }
        }

        public FormDefinition SHEMAIRASHEMAIRAKONTIRANJE
        {
            get
            {
                return base.m_FormDefinitionDictionary["SHEMAIRASHEMAIRAKONTIRANJE"];
            }
        }
    }
}

