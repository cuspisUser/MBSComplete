namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class MZOSTABLICEController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetMZOSTABLICEDataAdapter().Update(this.DataSet);
        }

        public MZOSTABLICEDataSet DataSet
        {
            get
            {
                return (MZOSTABLICEDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition MZOSTABLICEFormDefinition
        {
            get
            {
                return this.MZOSTABLICEWorkItem.MZOSTABLICE;
            }
        }

        public NetAdvantage.WorkItems.MZOSTABLICEWorkItem MZOSTABLICEWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.MZOSTABLICEWorkItem) this.WorkItem;
            }
        }
    }
}

