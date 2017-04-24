namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class MJESTOTROSKAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new MJESTOTROSKADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("MJESTOTROSKA", new FormDefinition(this, new MJESTOTROSKAFormUserControl(), StringResources.MJESTOTROSKAName, StringResources.MJESTOTROSKADescription, "NetAdvantage"));
            this.MJESTOTROSKA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.MJESTOTROSKA.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewGKSTAVKA", "GKSTAVKA", this.MJESTOTROSKA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "GKSTAVKA.Insert"
            };
            this.MJESTOTROSKA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewGKSTAVKA", "GKSTAVKA", this.MJESTOTROSKA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "GKSTAVKA.Select"
            };
            this.MJESTOTROSKA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition MJESTOTROSKA
        {
            get
            {
                return base.m_FormDefinitionDictionary["MJESTOTROSKA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.MJESTOTROSKA;
            }
        }
    }
}

