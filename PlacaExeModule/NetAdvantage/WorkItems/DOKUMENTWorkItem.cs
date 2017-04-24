namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class DOKUMENTWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new DOKUMENTDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("DOKUMENT", new FormDefinition(this, new DOKUMENTFormUserControl(), StringResources.DOKUMENTName, StringResources.DOKUMENTDescription, "NetAdvantage"));
            this.DOKUMENT.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.DOKUMENT.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewBLAGAJNA", "BLAGAJNA", this.DOKUMENT.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "BLAGAJNA.Insert"
            };
            this.DOKUMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewBLAGAJNA", "BLAGAJNA", this.DOKUMENT.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "BLAGAJNA.Select"
            };
            this.DOKUMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewGKSTAVKA", "GKSTAVKA", this.DOKUMENT.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "GKSTAVKA.Insert"
            };
            this.DOKUMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewGKSTAVKA", "GKSTAVKA", this.DOKUMENT.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "GKSTAVKA.Select"
            };
            this.DOKUMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewIRA", "IRA", this.DOKUMENT.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "IRA.Insert"
            };
            this.DOKUMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewIRA", "IRA", this.DOKUMENT.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "IRA.Select"
            };
            this.DOKUMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewSHEMAIRA", "Shema kontiranja IRA", this.DOKUMENT.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "SHEMAIRA.Insert"
            };
            this.DOKUMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewSHEMAIRA", "Shema kontiranja IRA", this.DOKUMENT.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "SHEMAIRA.Select"
            };
            this.DOKUMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewURA", "URA", this.DOKUMENT.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "URA.Insert"
            };
            this.DOKUMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewURA", "URA", this.DOKUMENT.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "URA.Select"
            };
            this.DOKUMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition DOKUMENT
        {
            get
            {
                return base.m_FormDefinitionDictionary["DOKUMENT"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.DOKUMENT;
            }
        }
    }
}

