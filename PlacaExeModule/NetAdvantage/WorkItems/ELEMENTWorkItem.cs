namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class ELEMENTWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new ELEMENTDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("ELEMENT", new FormDefinition(this, new ELEMENTFormUserControl(), StringResources.ELEMENTName, StringResources.ELEMENTDescription, "NetAdvantage"));
            this.ELEMENT.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.ELEMENT.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewBOLOVANJEFOND", "BOLOVANJEFOND", this.ELEMENT.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "BOLOVANJEFOND.Insert"
            };
            this.ELEMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewBOLOVANJEFOND", "BOLOVANJEFOND", this.ELEMENT.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "BOLOVANJEFOND.Select"
            };
            this.ELEMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewRAD1GELEMENTIVEZA", "Veza elementi RAD1G i elementi", this.ELEMENT.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RAD1GELEMENTIVEZA.Insert"
            };
            this.ELEMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRAD1GELEMENTIVEZA", "Veza elementi RAD1G i elementi", this.ELEMENT.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RAD1GELEMENTIVEZA.Select"
            };
            this.ELEMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewRAD1MELEMENTIVEZA", "Veza RAD1M elementi i elementi", this.ELEMENT.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RAD1MELEMENTIVEZA.Insert"
            };
            this.ELEMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRAD1MELEMENTIVEZA", "Veza RAD1M elementi i elementi", this.ELEMENT.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RAD1MELEMENTIVEZA.Select"
            };
            this.ELEMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition ELEMENT
        {
            get
            {
                return base.m_FormDefinitionDictionary["ELEMENT"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.ELEMENT;
            }
        }
    }
}

