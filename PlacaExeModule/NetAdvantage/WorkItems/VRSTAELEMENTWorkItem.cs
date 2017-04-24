namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class VRSTAELEMENTWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new VRSTAELEMENTDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("VRSTAELEMENT", new FormDefinition(this, new VRSTAELEMENTFormUserControl(), StringResources.VRSTAELEMENTName, StringResources.VRSTAELEMENTDescription, "NetAdvantage"));
            this.VRSTAELEMENT.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.VRSTAELEMENT.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewELEMENT", "Elementi", this.VRSTAELEMENT.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "ELEMENT.Insert"
            };
            this.VRSTAELEMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewELEMENT", "Elementi", this.VRSTAELEMENT.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "ELEMENT.Select"
            };
            this.VRSTAELEMENT.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.VRSTAELEMENT;
            }
        }

        public FormDefinition VRSTAELEMENT
        {
            get
            {
                return base.m_FormDefinitionDictionary["VRSTAELEMENT"];
            }
        }
    }
}

