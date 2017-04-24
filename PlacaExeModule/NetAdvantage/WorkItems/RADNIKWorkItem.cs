namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class RADNIKWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new RADNIKDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("RADNIK", new FormDefinition(this, new RADNIKFormUserControl(), StringResources.RADNIKName, StringResources.RADNIKDescription, "NetAdvantage"));
            this.RADNIK.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.RADNIK.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewGOOBRACUN", "Godišnji odbici i olakšice", this.RADNIK.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "GOOBRACUN.Insert"
            };
            this.RADNIK.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewGOOBRACUN", "Godišnji odbici i olakšice", this.RADNIK.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "GOOBRACUN.Select"
            };
            this.RADNIK.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewOTISLI", "OTISLI", this.RADNIK.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "OTISLI.Insert"
            };
            this.RADNIK.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewOTISLI", "OTISLI", this.RADNIK.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "OTISLI.Select"
            };
            this.RADNIK.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewZAPOSLENI", "ZAPOSLENI", this.RADNIK.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "ZAPOSLENI.Insert"
            };
            this.RADNIK.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewZAPOSLENI", "ZAPOSLENI", this.RADNIK.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "ZAPOSLENI.Select"
            };
            this.RADNIK.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.m_FormDefinitionDictionary.Add("RADNIKOdbitak", new FormDefinition(this, new RADNIKFormRADNIKOdbitakUserControl(), "RADNIKOdbitak", "Osobni odbici radnika", "NetAdvantage"));
            this.RADNIKOdbitak.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("RADNIKOdbitakSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.RADNIKOdbitak.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("RADNIKOdbitakAddLine", this.ResourceManager.GetString("AddLine"), this.RADNIKOdbitak.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("RADNIKOdbitakAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.RADNIKOdbitak.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("RADNIKOdbitakDelete", this.ResourceManager.GetString("toolDelete"), this.RADNIKOdbitak.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("RADNIKOlaksica", new FormDefinition(this, new RADNIKFormRADNIKOlaksicaUserControl(), "RADNIKOlaksica", "Olakšice", "NetAdvantage"));
            this.RADNIKOlaksica.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("RADNIKOlaksicaSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.RADNIKOlaksica.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("RADNIKOlaksicaAddLine", this.ResourceManager.GetString("AddLine"), this.RADNIKOlaksica.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("RADNIKOlaksicaAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.RADNIKOlaksica.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("RADNIKOlaksicaDelete", this.ResourceManager.GetString("toolDelete"), this.RADNIKOlaksica.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("RADNIKKrediti", new FormDefinition(this, new RADNIKFormRADNIKKreditiUserControl(), "RADNIKKrediti", "Krediti radnika", "NetAdvantage"));
            this.RADNIKKrediti.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("RADNIKKreditiSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.RADNIKKrediti.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("RADNIKKreditiAddLine", this.ResourceManager.GetString("AddLine"), this.RADNIKKrediti.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("RADNIKKreditiAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.RADNIKKrediti.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("RADNIKKreditiDelete", this.ResourceManager.GetString("toolDelete"), this.RADNIKKrediti.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("RADNIKBruto", new FormDefinition(this, new RADNIKFormRADNIKBrutoUserControl(), "RADNIKBruto", "Bruto elementi", "NetAdvantage"));
            this.RADNIKBruto.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("RADNIKBrutoSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.RADNIKBruto.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("RADNIKBrutoAddLine", this.ResourceManager.GetString("AddLine"), this.RADNIKBruto.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("RADNIKBrutoAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.RADNIKBruto.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("RADNIKBrutoDelete", this.ResourceManager.GetString("toolDelete"), this.RADNIKBruto.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("RADNIKNeto", new FormDefinition(this, new RADNIKFormRADNIKNetoUserControl(), "RADNIKNeto", "Neto elementi", "NetAdvantage"));
            this.RADNIKNeto.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("RADNIKNetoSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.RADNIKNeto.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("RADNIKNetoAddLine", this.ResourceManager.GetString("AddLine"), this.RADNIKNeto.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("RADNIKNetoAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.RADNIKNeto.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("RADNIKNetoDelete", this.ResourceManager.GetString("toolDelete"), this.RADNIKNeto.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("RADNIKObustava", new FormDefinition(this, new RADNIKFormRADNIKObustavaUserControl(), "RADNIKObustava", "Obustave", "NetAdvantage"));
            this.RADNIKObustava.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("RADNIKObustavaSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.RADNIKObustava.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("RADNIKObustavaAddLine", this.ResourceManager.GetString("AddLine"), this.RADNIKObustava.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("RADNIKObustavaAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.RADNIKObustava.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("RADNIKObustavaDelete", this.ResourceManager.GetString("toolDelete"), this.RADNIKObustava.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("RADNIKLevel7", new FormDefinition(this, new RADNIKFormRADNIKLevel7UserControl(), "RADNIKLevel7", "Koeficijenti", "NetAdvantage"));
            this.RADNIKLevel7.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("RADNIKLevel7SaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.RADNIKLevel7.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("RADNIKLevel7AddLine", this.ResourceManager.GetString("AddLine"), this.RADNIKLevel7.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("RADNIKLevel7AddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.RADNIKLevel7.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("RADNIKLevel7Delete", this.ResourceManager.GetString("toolDelete"), this.RADNIKLevel7.Site, 1, null, DeklaritMode.Delete) });
            base.m_FormDefinitionDictionary.Add("RADNIKIzuzeceOdOvrhe", new FormDefinition(this, new RADNIKFormRADNIKIzuzeceOdOvrheUserControl(), "RADNIKIzuzeceOdOvrhe", "IzuzeceOdOvrhe", "NetAdvantage"));
            this.RADNIKIzuzeceOdOvrhe.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("RADNIKIzuzeceOdOvrheSaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.RADNIKIzuzeceOdOvrhe.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("RADNIKIzuzeceOdOvrheAddLine", this.ResourceManager.GetString("AddLine"), this.RADNIKIzuzeceOdOvrhe.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("RADNIKIzuzeceOdOvrheAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.RADNIKIzuzeceOdOvrhe.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("RADNIKIzuzeceOdOvrheDelete", this.ResourceManager.GetString("toolDelete"), this.RADNIKIzuzeceOdOvrhe.Site, 1, null, DeklaritMode.Delete) });
            base.OnInitialized();
        }

        public FormDefinition RADNIK
        {
            get
            {
                return base.m_FormDefinitionDictionary["RADNIK"];
            }
        }

        public FormDefinition RADNIKBruto
        {
            get
            {
                return base.m_FormDefinitionDictionary["RADNIKBruto"];
            }
        }

        public FormDefinition RADNIKIzuzeceOdOvrhe
        {
            get
            {
                return base.m_FormDefinitionDictionary["RADNIKIzuzeceOdOvrhe"];
            }
        }

        public FormDefinition RADNIKKrediti
        {
            get
            {
                return base.m_FormDefinitionDictionary["RADNIKKrediti"];
            }
        }

        public FormDefinition RADNIKLevel7
        {
            get
            {
                return base.m_FormDefinitionDictionary["RADNIKLevel7"];
            }
        }

        public FormDefinition RADNIKNeto
        {
            get
            {
                return base.m_FormDefinitionDictionary["RADNIKNeto"];
            }
        }

        public FormDefinition RADNIKObustava
        {
            get
            {
                return base.m_FormDefinitionDictionary["RADNIKObustava"];
            }
        }

        public FormDefinition RADNIKOdbitak
        {
            get
            {
                return base.m_FormDefinitionDictionary["RADNIKOdbitak"];
            }
        }

        public FormDefinition RADNIKOlaksica
        {
            get
            {
                return base.m_FormDefinitionDictionary["RADNIKOlaksica"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.RADNIK;
            }
        }
    }
}

