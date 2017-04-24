namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class PARTNERWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new PARTNERDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("PARTNER", new FormDefinition(this, new PARTNERFormUserControl(), StringResources.PARTNERName, StringResources.PARTNERDescription, "NetAdvantage"));
            this.PARTNER.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.PARTNER.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewGKSTAVKA", "GKSTAVKA", this.PARTNER.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "GKSTAVKA.Insert"
            };
            this.PARTNER.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewGKSTAVKA", "GKSTAVKA", this.PARTNER.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "GKSTAVKA.Select"
            };
            this.PARTNER.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewIRA", "IRA", this.PARTNER.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "IRA.Insert"
            };
            this.PARTNER.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewIRA", "IRA", this.PARTNER.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "IRA.Select"
            };
            this.PARTNER.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewRACUN", "Izlazni računi", this.PARTNER.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RACUN.Insert"
            };
            this.PARTNER.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRACUN", "Izlazni računi", this.PARTNER.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RACUN.Select"
            };
            this.PARTNER.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewSHEMAURA", "Shema kontiranja URA", this.PARTNER.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "SHEMAURA.Insert"
            };
            this.PARTNER.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewSHEMAURA", "Shema kontiranja URA", this.PARTNER.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "SHEMAURA.Select"
            };
            this.PARTNER.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewURA", "URA", this.PARTNER.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "URA.Insert"
            };
            this.PARTNER.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewURA", "URA", this.PARTNER.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "URA.Select"
            };
            this.PARTNER.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.m_FormDefinitionDictionary.Add("PARTNERZADUZENJE", new FormDefinition(this, new PARTNERFormPARTNERZADUZENJEUserControl(), "PARTNERZADUZENJE", "Zaduzenja partnera", "NetAdvantage"));
            this.PARTNERZADUZENJE.UICommandDefinitionContainer.Add(new UICommandDefinition[] { new UICommandDefinition("PARTNERZADUZENJESaveAndClose", this.ResourceManager.GetString("captionSaveAndClose"), this.PARTNERZADUZENJE.Site, 6, null, DeklaritMode.Update), new UICommandDefinition("PARTNERZADUZENJEAddLine", this.ResourceManager.GetString("AddLine"), this.PARTNERZADUZENJE.Site, 6, null, DeklaritMode.Insert), new UICommandDefinition("PARTNERZADUZENJEAddLineAndNew", this.ResourceManager.GetString("captionAddLineAndNew"), this.PARTNERZADUZENJE.Site, 5, null, DeklaritMode.Insert), new UICommandDefinition("PARTNERZADUZENJEDelete", this.ResourceManager.GetString("toolDelete"), this.PARTNERZADUZENJE.Site, 1, null, DeklaritMode.Delete) });
            base.OnInitialized();
        }

        public FormDefinition PARTNER
        {
            get
            {
                return base.m_FormDefinitionDictionary["PARTNER"];
            }
        }

        public FormDefinition PARTNERZADUZENJE
        {
            get
            {
                return base.m_FormDefinitionDictionary["PARTNERZADUZENJE"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.PARTNER;
            }
        }
    }
}

