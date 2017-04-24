namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class GKSTAVKAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new GKSTAVKADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("GKSTAVKA", new FormDefinition(this, new GKSTAVKAFormUserControl(), StringResources.GKSTAVKAName, StringResources.GKSTAVKADescription, "NetAdvantage"));
            this.GKSTAVKA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.GKSTAVKA.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewZATVARANJA1", "ZATVARANJA", this.GKSTAVKA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "ZATVARANJA.Insert"
            };
            this.GKSTAVKA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewZATVARANJA1", "ZATVARANJA", this.GKSTAVKA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "ZATVARANJA.Select"
            };
            this.GKSTAVKA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("NewZATVARANJA", "ZATVARANJA", this.GKSTAVKA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "ZATVARANJA.Insert"
            };
            this.GKSTAVKA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewZATVARANJA", "ZATVARANJA", this.GKSTAVKA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "ZATVARANJA.Select"
            };
            this.GKSTAVKA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition GKSTAVKA
        {
            get
            {
                return base.m_FormDefinitionDictionary["GKSTAVKA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.GKSTAVKA;
            }
        }
    }
}

