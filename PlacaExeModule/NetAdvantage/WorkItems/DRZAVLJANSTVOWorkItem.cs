namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class DRZAVLJANSTVOWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new DRZAVLJANSTVODataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("DRZAVLJANSTVO", new FormDefinition(this, new DRZAVLJANSTVOFormUserControl(), StringResources.DRZAVLJANSTVOName, StringResources.DRZAVLJANSTVODescription, "NetAdvantage"));
            this.DRZAVLJANSTVO.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.DRZAVLJANSTVO.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewRADNIK", "Zaposlenici", this.DRZAVLJANSTVO.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Insert"
            };
            this.DRZAVLJANSTVO.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewRADNIK", "Zaposlenici", this.DRZAVLJANSTVO.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "RADNIK.Select"
            };
            this.DRZAVLJANSTVO.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition DRZAVLJANSTVO
        {
            get
            {
                return base.m_FormDefinitionDictionary["DRZAVLJANSTVO"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.DRZAVLJANSTVO;
            }
        }
    }
}

