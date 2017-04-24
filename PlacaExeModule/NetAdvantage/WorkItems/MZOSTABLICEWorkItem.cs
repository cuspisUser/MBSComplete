namespace NetAdvantage.WorkItems
{
    using Deklarit.Practices.CompositeUI.Constants;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.SmartParts;
    using Placa;
    using System;
    using System.Data;

    public class MZOSTABLICEWorkItem : FormWorkItemBase
    {
        public override DataSet CreateDataSet()
        {
            return new MZOSTABLICEDataSet();
        }

        protected override void OnInitialized()
        {
            base.m_FormDefinitionDictionary.Add("MZOSTABLICE", new FormDefinition(this, new MZOSTABLICEFormUserControl(), StringResources.MZOSTABLICEName, StringResources.MZOSTABLICEDescription, "NetAdvantage"));
            this.MZOSTABLICE.UICommandDefinitionContainer.Add(StandardCommandDefinitions.GetFormCommands(this.MZOSTABLICE.Site));
            base.OnInitialized();
        }

        public FormDefinition MZOSTABLICE
        {
            get
            {
                return base.m_FormDefinitionDictionary["MZOSTABLICE"];
            }
        }

        public override FormDefinition RootForm
        {
            get
            {
                return this.MZOSTABLICE;
            }
        }
    }
}

