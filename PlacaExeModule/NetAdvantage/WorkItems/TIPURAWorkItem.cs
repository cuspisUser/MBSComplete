namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class TIPURAWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new TIPURADataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("TIPURA", new FormDefinition(this, new TIPURAFormUserControl(), StringResources.TIPURAName, StringResources.TIPURADescription, "NetAdvantage"));
            this.TIPURA.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.TIPURA.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewURA", "URA", this.TIPURA.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "URA.Insert"
            };
            this.TIPURA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewURA", "URA", this.TIPURA.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "URA.Select"
            };
            this.TIPURA.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.TIPURA;
            }
        }

        public FormDefinition TIPURA
        {
            get
            {
                return base.m_FormDefinitionDictionary["TIPURA"];
            }
        }
    }
}

