namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class GRUPEOLAKSICAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetGRUPEOLAKSICADataAdapter().Update(this.DataSet);
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
            item.ShowModal(false, "FillByIDGRUPEOLAKSICA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public GRUPEOLAKSICADataSet DataSet
        {
            get
            {
                return (GRUPEOLAKSICADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition GRUPEOLAKSICAFormDefinition
        {
            get
            {
                return this.GRUPEOLAKSICAWorkItem.GRUPEOLAKSICA;
            }
        }

        public NetAdvantage.WorkItems.GRUPEOLAKSICAWorkItem GRUPEOLAKSICAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.GRUPEOLAKSICAWorkItem) this.WorkItem;
            }
        }
    }
}

