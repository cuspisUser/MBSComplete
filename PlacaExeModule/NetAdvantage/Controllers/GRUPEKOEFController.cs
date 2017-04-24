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

    public class GRUPEKOEFController : FormControllerBase
    {
        public DialogResult AddGRUPEKOEFLevel1(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.GRUPEKOEFWorkItem) this.WorkItem).GRUPEKOEFLevel1.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult DeleteGRUPEKOEFLevel1(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.GRUPEKOEFWorkItem) this.WorkItem).GRUPEKOEFLevel1.Show(DeklaritMode.Delete, currentRow, false);
        }

        public override void DoUpdate()
        {
            DataAdapterFactory.GetGRUPEKOEFDataAdapter().Update(this.DataSet);
        }

        public DataRow SelectMZOSTABLICEIDMZOSTABLICE(string fillMethod, DataRow fillByRow)
        {
            MZOSTABLICESelectionListWorkItem item = this.WorkItem.Items.AddNew<MZOSTABLICESelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowMZOSTABLICEIDMZOSTABLICE(DataRow fillByRow)
        {
            MZOSTABLICEWorkItem item = this.WorkItem.Items.AddNew<MZOSTABLICEWorkItem>();
            DataAdapterFactory.GetMZOSTABLICEDataAdapter().Fill((MZOSTABLICEDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDMZOSTABLICE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DialogResult UpdateGRUPEKOEFLevel1(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.GRUPEKOEFWorkItem) this.WorkItem).GRUPEKOEFLevel1.Show(DeklaritMode.Update, currentRow, false);
        }

        public GRUPEKOEFDataSet DataSet
        {
            get
            {
                return (GRUPEKOEFDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition GRUPEKOEFFormDefinition
        {
            get
            {
                return this.GRUPEKOEFWorkItem.GRUPEKOEF;
            }
        }

        public FormDefinition GRUPEKOEFLevel1FormDefinition
        {
            get
            {
                return this.GRUPEKOEFWorkItem.GRUPEKOEFLevel1;
            }
        }

        public NetAdvantage.WorkItems.GRUPEKOEFWorkItem GRUPEKOEFWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.GRUPEKOEFWorkItem) this.WorkItem;
            }
        }
    }
}

