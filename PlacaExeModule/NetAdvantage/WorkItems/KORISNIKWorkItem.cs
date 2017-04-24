namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class KORISNIKWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new KORISNIKDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("KORISNIK", new FormDefinition(this, new KORISNIKFormUserControl(), StringResources.KORISNIKName, StringResources.KORISNIKDescription, "NetAdvantage"));
            this.KORISNIK.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.KORISNIK.Site));
            base.m_FormDefinitionDictionary.Add("KORISNIKLevel1", new FormDefinition(this, new KORISNIKFormKORISNIKLevel1UserControl(), "KORISNIKLevel1", "Podaci o isplatnim Žrn-ima korisnika", "NetAdvantage"));
            this.KORISNIKLevel1.UICommandDefinitionContainer.Add(new UICommandDefinition[] { 
                new UICommandDefinition("KORISNIKLevel1SaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.KORISNIKLevel1.Site, 6, null, DeklaritMode.Update), 
                new UICommandDefinition("KORISNIKLevel1AddLine", this.ResourceManager.GetString("AddLine"), this.KORISNIKLevel1.Site, 6, null, DeklaritMode.Insert), 
                new UICommandDefinition("KORISNIKLevel1AddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.KORISNIKLevel1.Site, 5, null, DeklaritMode.Insert), 
                new UICommandDefinition("KORISNIKLevel1Delete", this.ResourceManager.GetString("toolDelete"), this.KORISNIKLevel1.Site, 1, null, DeklaritMode.Delete)
            });
            base.OnInitialized();
        }

        public FormDefinition KORISNIK
        {
            get
            {
                return base.m_FormDefinitionDictionary["KORISNIK"];
            }
        }

        public FormDefinition KORISNIKLevel1
        {
            get
            {
                return base.m_FormDefinitionDictionary["KORISNIKLevel1"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.KORISNIK;
            }
        }
    }
}

