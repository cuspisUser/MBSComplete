namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class RACUNWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new RACUNDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("RACUN", new FormDefinition(this, new RACUNFormUserControl(), StringResources.RACUNName, StringResources.RACUNDescription, "NetAdvantage"));
            this.RACUN.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.RACUN.Site));

            this.RACUN.UICommandDefinitionContainer.Delete("SaveAndNew");

            base.m_FormDefinitionDictionary.Add("RACUNRacunStavke", new FormDefinition(this, new RACUNFormRACUNRacunStavkeUserControl(), "RACUNRacunStavke", "Stavke racuna", "NetAdvantage"));
            this.RACUNRacunStavke.UICommandDefinitionContainer.Add(new UICommandDefinition[] { 
                new UICommandDefinition("RACUNRacunStavkeSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.RACUNRacunStavke.Site, 6, null, DeklaritMode.Update), 
                new UICommandDefinition("RACUNRacunStavkeAddLine", this.ResourceManager.GetString("AddLine"), this.RACUNRacunStavke.Site, 6, null, DeklaritMode.Insert), 
                new UICommandDefinition("RACUNRacunStavkeAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.RACUNRacunStavke.Site, 5, null, DeklaritMode.Insert), 
                new UICommandDefinition("RACUNRacunStavkeDelete", this.ResourceManager.GetString("toolDelete"), this.RACUNRacunStavke.Site, 1, null, DeklaritMode.Delete) });
            base.OnInitialized();
        }

        public FormDefinition RACUN
        {
            get
            {
                return base.m_FormDefinitionDictionary["RACUN"];
            }
        }

        public FormDefinition RACUNRacunStavke
        {
            get
            {
                return base.m_FormDefinitionDictionary["RACUNRacunStavke"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.RACUN;
            }
        }
    }
}

