namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public class OLAKSICEController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetOLAKSICEDataAdapter().Update(this.DataSet);
        }

        public DataRow SelectGRUPEOLAKSICAIDGRUPEOLAKSICA(string fillMethod, DataRow fillByRow)
        {
            GRUPEOLAKSICASelectionListWorkItem item = this.WorkItem.Items.AddNew<GRUPEOLAKSICASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowGRUPEOLAKSICAIDGRUPEOLAKSICA(DataRow fillByRow)
        {
            GRUPEOLAKSICAWorkItem item = this.WorkItem.Items.AddNew<GRUPEOLAKSICAWorkItem>();
            DataAdapterFactory.GetGRUPEOLAKSICADataAdapter().Fill((GRUPEOLAKSICADataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDGRUPEOLAKSICA"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public OLAKSICEDataSet DataSet
        {
            get
            {
                return (OLAKSICEDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition OLAKSICEFormDefinition
        {
            get
            {
                return this.OLAKSICEWorkItem.OLAKSICE;
            }
        }

        public NetAdvantage.WorkItems.OLAKSICEWorkItem OLAKSICEWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.OLAKSICEWorkItem) this.WorkItem;
            }
        }
    }
}

