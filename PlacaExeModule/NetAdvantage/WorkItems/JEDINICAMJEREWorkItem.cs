namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class JEDINICAMJEREWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new JEDINICAMJEREDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("JEDINICAMJERE", new FormDefinition(this, new JEDINICAMJEREFormUserControl(), StringResources.JEDINICAMJEREName, StringResources.JEDINICAMJEREDescription, "NetAdvantage"));
            this.JEDINICAMJERE.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.JEDINICAMJERE.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewPROIZVOD", "PROIZVOD", this.JEDINICAMJERE.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "PROIZVOD.Insert"
            };
            this.JEDINICAMJERE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewPROIZVOD", "PROIZVOD", this.JEDINICAMJERE.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "PROIZVOD.Select"
            };
            this.JEDINICAMJERE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition JEDINICAMJERE
        {
            get
            {
                return base.m_FormDefinitionDictionary["JEDINICAMJERE"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.JEDINICAMJERE;
            }
        }
    }
}

