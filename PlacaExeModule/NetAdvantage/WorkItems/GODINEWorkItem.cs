namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class GODINEWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new GODINEDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("GODINE", new FormDefinition(this, new GODINEFormUserControl(), StringResources.GODINEName, StringResources.GODINEDescription, "NetAdvantage"));
            this.GODINE.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.GODINE.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewEVIDENCIJA", "EVIDENCIJA", this.GODINE.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "EVIDENCIJA.Insert"
            };
            this.GODINE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewEVIDENCIJA", "EVIDENCIJA", this.GODINE.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "EVIDENCIJA.Select"
            };
            this.GODINE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewGKSTAVKA", "GKSTAVKA", this.GODINE.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "GKSTAVKA.Insert"
            };
            this.GODINE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewGKSTAVKA", "GKSTAVKA", this.GODINE.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "GKSTAVKA.Select"
            };
            this.GODINE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewIRA", "IRA", this.GODINE.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "IRA.Insert"
            };
            this.GODINE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewIRA", "IRA", this.GODINE.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "IRA.Select"
            };
            this.GODINE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewRACUN", "Izlazni računi", this.GODINE.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RACUN.Insert"
            };
            this.GODINE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRACUN", "Izlazni računi", this.GODINE.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RACUN.Select"
            };
            this.GODINE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewPLAN", "PLAN", this.GODINE.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "PLAN.Insert"
            };
            this.GODINE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewPLAN", "PLAN", this.GODINE.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "PLAN.Select"
            };
            this.GODINE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewURA", "URA", this.GODINE.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "URA.Insert"
            };
            this.GODINE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewURA", "URA", this.GODINE.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "URA.Select"
            };
            this.GODINE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition GODINE
        {
            get
            {
                return base.m_FormDefinitionDictionary["GODINE"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.GODINE;
            }
        }
    }
}

