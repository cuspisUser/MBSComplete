namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class ORGJEDWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new ORGJEDDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("ORGJED", new FormDefinition(this, new ORGJEDFormUserControl(), StringResources.ORGJEDName, StringResources.ORGJEDDescription, "NetAdvantage"));
            this.ORGJED.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.ORGJED.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewGKSTAVKA", "GKSTAVKA", this.ORGJED.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "GKSTAVKA.Insert"
            };
            this.ORGJED.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewGKSTAVKA", "GKSTAVKA", this.ORGJED.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "GKSTAVKA.Select"
            };
            this.ORGJED.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewSHEMADD", "Shema drugi dohodak", this.ORGJED.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "SHEMADD.Insert"
            };
            this.ORGJED.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewSHEMADD", "Shema drugi dohodak", this.ORGJED.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "SHEMADD.Select"
            };
            this.ORGJED.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewSHEMAPLACA", "Shema place", this.ORGJED.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "SHEMAPLACA.Insert"
            };
            this.ORGJED.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewSHEMAPLACA", "Shema place", this.ORGJED.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "SHEMAPLACA.Select"
            };
            this.ORGJED.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition ORGJED
        {
            get
            {
                return base.m_FormDefinitionDictionary["ORGJED"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.ORGJED;
            }
        }
    }
}

