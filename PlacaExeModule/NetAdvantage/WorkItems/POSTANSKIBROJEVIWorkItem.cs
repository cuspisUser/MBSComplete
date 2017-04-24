namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class POSTANSKIBROJEVIWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new POSTANSKIBROJEVIDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("POSTANSKIBROJEVI", new FormDefinition(this, new POSTANSKIBROJEVIFormUserControl(), StringResources.POSTANSKIBROJEVIName, StringResources.POSTANSKIBROJEVIDescription, "NetAdvantage"));
            this.POSTANSKIBROJEVI.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.POSTANSKIBROJEVI.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewUCENIK", "UCENIK", this.POSTANSKIBROJEVI.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "UCENIK.Insert"
            };
            this.POSTANSKIBROJEVI.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewUCENIK", "UCENIK", this.POSTANSKIBROJEVI.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "UCENIK.Select"
            };
            this.POSTANSKIBROJEVI.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition POSTANSKIBROJEVI
        {
            get
            {
                return base.m_FormDefinitionDictionary["POSTANSKIBROJEVI"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.POSTANSKIBROJEVI;
            }
        }
    }
}

