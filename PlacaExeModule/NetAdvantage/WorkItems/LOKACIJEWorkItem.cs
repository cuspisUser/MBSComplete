namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class LOKACIJEWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new LOKACIJEDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("LOKACIJE", new FormDefinition(this, new LOKACIJEFormUserControl(), StringResources.LOKACIJEName, StringResources.LOKACIJEDescription, "NetAdvantage"));
            this.LOKACIJE.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.LOKACIJE.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewOSRAZMJESTAJ", "OSRAZMJESTAJ", this.LOKACIJE.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "OSRAZMJESTAJ.Insert"
            };
            this.LOKACIJE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewOSRAZMJESTAJ", "OSRAZMJESTAJ", this.LOKACIJE.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "OSRAZMJESTAJ.Select"
            };
            this.LOKACIJE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public FormDefinition LOKACIJE
        {
            get
            {
                return base.m_FormDefinitionDictionary["LOKACIJE"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.LOKACIJE;
            }
        }
    }
}

