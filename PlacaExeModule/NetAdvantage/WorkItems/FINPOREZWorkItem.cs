namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class FINPOREZWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new FINPOREZDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("FINPOREZ", new FormDefinition(this, new FINPOREZFormUserControl(), StringResources.FINPOREZName, StringResources.FINPOREZDescription, "NetAdvantage"));
            this.FINPOREZ.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.FINPOREZ.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewPROIZVOD", "PROIZVOD", this.FINPOREZ.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "PROIZVOD.Insert"
            };
            this.FINPOREZ.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewPROIZVOD", "PROIZVOD", this.FINPOREZ.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "PROIZVOD.Select"
            };
            this.FINPOREZ.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition FINPOREZ
        {
            get
            {
                return base.m_FormDefinitionDictionary["FINPOREZ"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.FINPOREZ;
            }
        }
    }
}

