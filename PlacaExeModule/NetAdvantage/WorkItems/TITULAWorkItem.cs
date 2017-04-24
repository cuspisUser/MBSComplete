namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class TITULAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new TITULADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("TITULA", new FormDefinition(this, new TITULAFormUserControl(), StringResources.TITULAName, StringResources.TITULADescription, "NetAdvantage"));
            this.TITULA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.TITULA.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRADNIK", "Zaposlenici", this.TITULA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.TITULA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK", "Zaposlenici", this.TITULA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.TITULA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.TITULA;
            }
        }

        public FormDefinition TITULA
        {
            get
            {
                return base.m_FormDefinitionDictionary["TITULA"];
            }
        }
    }
}

