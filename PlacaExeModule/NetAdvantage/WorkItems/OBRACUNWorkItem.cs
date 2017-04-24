namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class OBRACUNWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new OBRACUNDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("OBRACUN", new FormDefinition(this, new OBRACUNFormUserControl(), StringResources.OBRACUNName, StringResources.OBRACUNDescription, "NetAdvantage"));
            this.OBRACUN.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.OBRACUN.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRSMA", "RSMA", this.OBRACUN.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RSMA.Insert"
            };
            this.OBRACUN.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRSMA", "RSMA", this.OBRACUN.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RSMA.Select"
            };
            this.OBRACUN.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.m_FormDefinitionDictionary.Add("ObracunRadnici", new FormDefinition(this, new OBRACUNFormObracunRadniciUserControl(), "ObracunRadnici", "OBRACUNLevel1", "NetAdvantage"));
            this.ObracunRadnici.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("ObracunRadniciSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.ObracunRadnici.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("ObracunRadniciAddLine", this.ResourceManager.GetString("AddLine"), this.ObracunRadnici.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("ObracunRadniciAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.ObracunRadnici.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("ObracunRadniciDelete", this.ResourceManager.GetString("toolDelete"), this.ObracunRadnici.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("ObracunDoprinosi", new FormDefinition(this, new OBRACUNFormObracunDoprinosiUserControl(), "ObracunDoprinosi", "OBRACUNLevel3", "NetAdvantage"));
            this.ObracunDoprinosi.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("ObracunDoprinosiSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.ObracunDoprinosi.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("ObracunDoprinosiAddLine", this.ResourceManager.GetString("AddLine"), this.ObracunDoprinosi.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("ObracunDoprinosiAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.ObracunDoprinosi.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("ObracunDoprinosiDelete", this.ResourceManager.GetString("toolDelete"), this.ObracunDoprinosi.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("ObracunPorezi", new FormDefinition(this, new OBRACUNFormObracunPoreziUserControl(), "ObracunPorezi", "OBRACUNLevel4", "NetAdvantage"));
            this.ObracunPorezi.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("ObracunPoreziSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.ObracunPorezi.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("ObracunPoreziAddLine", this.ResourceManager.GetString("AddLine"), this.ObracunPorezi.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("ObracunPoreziAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.ObracunPorezi.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("ObracunPoreziDelete", this.ResourceManager.GetString("toolDelete"), this.ObracunPorezi.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("ObracunOlaksice", new FormDefinition(this, new OBRACUNFormObracunOlaksiceUserControl(), "ObracunOlaksice", "ObracunOlaksice", "NetAdvantage"));
            this.ObracunOlaksice.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("ObracunOlaksiceSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.ObracunOlaksice.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("ObracunOlaksiceAddLine", this.ResourceManager.GetString("AddLine"), this.ObracunOlaksice.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("ObracunOlaksiceAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.ObracunOlaksice.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("ObracunOlaksiceDelete", this.ResourceManager.GetString("toolDelete"), this.ObracunOlaksice.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("OBRACUNKrediti", new FormDefinition(this, new OBRACUNFormOBRACUNKreditiUserControl(), "OBRACUNKrediti", "ObracunKrediti", "NetAdvantage"));
            this.OBRACUNKrediti.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("OBRACUNKreditiSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.OBRACUNKrediti.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("OBRACUNKreditiAddLine", this.ResourceManager.GetString("AddLine"), this.OBRACUNKrediti.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("OBRACUNKreditiAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.OBRACUNKrediti.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("OBRACUNKreditiDelete", this.ResourceManager.GetString("toolDelete"), this.OBRACUNKrediti.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("OBRACUNObustave", new FormDefinition(this, new OBRACUNFormOBRACUNObustaveUserControl(), "OBRACUNObustave", "ObracunObustave", "NetAdvantage"));
            this.OBRACUNObustave.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("OBRACUNObustaveSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.OBRACUNObustave.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("OBRACUNObustaveAddLine", this.ResourceManager.GetString("AddLine"), this.OBRACUNObustave.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("OBRACUNObustaveAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.OBRACUNObustave.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("OBRACUNObustaveDelete", this.ResourceManager.GetString("toolDelete"), this.OBRACUNObustave.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("ObracunElementi", new FormDefinition(this, new OBRACUNFormObracunElementiUserControl(), "ObracunElementi", "ObracunElementi", "NetAdvantage"));
            this.ObracunElementi.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("ObracunElementiSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.ObracunElementi.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("ObracunElementiAddLine", this.ResourceManager.GetString("AddLine"), this.ObracunElementi.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("ObracunElementiAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.ObracunElementi.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("ObracunElementiDelete", this.ResourceManager.GetString("toolDelete"), this.ObracunElementi.Site, 1, null, DeklaritMode.Delete) });
            base.OnInitialized();
        }

        public FormDefinition OBRACUN
        {
            get
            {
                return base.m_FormDefinitionDictionary["OBRACUN"];
            }
        }

        public FormDefinition ObracunDoprinosi
        {
            get
            {
                return base.m_FormDefinitionDictionary["ObracunDoprinosi"];
            }
        }

        public FormDefinition ObracunElementi
        {
            get
            {
                return base.m_FormDefinitionDictionary["ObracunElementi"];
            }
        }

        public FormDefinition OBRACUNKrediti
        {
            get
            {
                return base.m_FormDefinitionDictionary["OBRACUNKrediti"];
            }
        }

        public FormDefinition OBRACUNObustave
        {
            get
            {
                return base.m_FormDefinitionDictionary["OBRACUNObustave"];
            }
        }

        public FormDefinition ObracunOlaksice
        {
            get
            {
                return base.m_FormDefinitionDictionary["ObracunOlaksice"];
            }
        }

        public FormDefinition ObracunPorezi
        {
            get
            {
                return base.m_FormDefinitionDictionary["ObracunPorezi"];
            }
        }

        public FormDefinition ObracunRadnici
        {
            get
            {
                return base.m_FormDefinitionDictionary["ObracunRadnici"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.OBRACUN;
            }
        }
    }
}

