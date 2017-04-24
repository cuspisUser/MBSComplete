namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class TIPOLAKSICEWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new TIPOLAKSICEDataSet();
        }

        protected override void OnInitialized()
        {
            
            base.m_FormDefinitionDictionary.Add("TIPOLAKSICE", new FormDefinition(this, new TIPOLAKSICEFormUserControl(), StringResources.TIPOLAKSICEName, StringResources.TIPOLAKSICEDescription, "NetAdvantage"));
            this.TIPOLAKSICE.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.TIPOLAKSICE.Site));
            UICommandDefinition uiCommandDefinition = null;
            uiCommandDefinition = new UICommandDefinition("NewOLAKSICE", "Osiguranja-Olakšice", this.TIPOLAKSICE.Site + ".New", 3, null, DeklaritMode.Update) {
                PermissionName = "OLAKSICE.Insert"
            };
            this.TIPOLAKSICE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            uiCommandDefinition = new UICommandDefinition("ViewOLAKSICE", "Osiguranja-Olakšice", this.TIPOLAKSICE.Site + ".View", 3, null, DeklaritMode.Update) {
                PermissionName = "OLAKSICE.Select"
            };
            this.TIPOLAKSICE.UICommandDefinitionContainer.Add(uiCommandDefinition);
            base.OnInitialized();
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.TIPOLAKSICE;
            }
        }

        public FormDefinition TIPOLAKSICE
        {
            get
            {
                return base.m_FormDefinitionDictionary["TIPOLAKSICE"];
            }
        }
    }
}

