namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class OLAKSICEWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new OLAKSICEDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("OLAKSICE", new FormDefinition(this, new OLAKSICEFormUserControl(), StringResources.OLAKSICEName, StringResources.OLAKSICEDescription, "NetAdvantage"));
            this.OLAKSICE.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.OLAKSICE.Site));
            base.OnInitialized();
        }

        public FormDefinition OLAKSICE
        {
            get
            {
                return base.m_FormDefinitionDictionary["OLAKSICE"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.OLAKSICE;
            }
        }
    }
}

