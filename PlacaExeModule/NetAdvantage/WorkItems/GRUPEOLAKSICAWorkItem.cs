namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class GRUPEOLAKSICAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new GRUPEOLAKSICADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("GRUPEOLAKSICA", new FormDefinition(this, new GRUPEOLAKSICAFormUserControl(), StringResources.GRUPEOLAKSICAName, StringResources.GRUPEOLAKSICADescription, "NetAdvantage"));
            this.GRUPEOLAKSICA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.GRUPEOLAKSICA.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewOLAKSICE", "Osiguranja-Olakšice", this.GRUPEOLAKSICA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "OLAKSICE.Insert"
            };
            this.GRUPEOLAKSICA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewOLAKSICE", "Osiguranja-Olakšice", this.GRUPEOLAKSICA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "OLAKSICE.Select"
            };
            this.GRUPEOLAKSICA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition GRUPEOLAKSICA
        {
            get
            {
                return base.m_FormDefinitionDictionary["GRUPEOLAKSICA"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.GRUPEOLAKSICA;
            }
        }
    }
}

