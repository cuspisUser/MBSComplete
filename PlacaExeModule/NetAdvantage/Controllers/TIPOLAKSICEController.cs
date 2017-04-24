namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class TIPOLAKSICEController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetTIPOLAKSICEDataAdapter().Update(this.DataSet);
        }

        public void NewOLAKSICE(DataRow row)
        {
            OLAKSICEWorkItem item = this.WorkItem.Items.AddNew<OLAKSICEWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewOLAKSICE(DataRow row)
        {
            OLAKSICESelectionListWorkItem item = this.WorkItem.Items.AddNew<OLAKSICESelectionListWorkItem>();
            item.ShowModal(false, "FillByIDTIPOLAKSICE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public TIPOLAKSICEDataSet DataSet
        {
            get
            {
                return (TIPOLAKSICEDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition TIPOLAKSICEFormDefinition
        {
            get
            {
                return this.TIPOLAKSICEWorkItem.TIPOLAKSICE;
            }
        }

        public NetAdvantage.WorkItems.TIPOLAKSICEWorkItem TIPOLAKSICEWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.TIPOLAKSICEWorkItem) this.WorkItem;
            }
        }
    }
}

