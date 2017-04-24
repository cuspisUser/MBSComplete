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

    public class URAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetURADataAdapter().Update(this.DataSet);
        }

        public DataRow SelectGODINEURAGODIDGODINE(string fillMethod, DataRow fillByRow)
        {
            GODINESelectionListWorkItem item = this.WorkItem.Items.AddNew<GODINESelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectTIPURAIDTIPURA(string fillMethod, DataRow fillByRow)
        {
            TIPURASelectionListWorkItem item = this.WorkItem.Items.AddNew<TIPURASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowGODINEURAGODIDGODINE(DataRow fillByRow)
        {
            GODINEWorkItem item = this.WorkItem.Items.AddNew<GODINEWorkItem>();
            DataAdapterFactory.GetGODINEDataAdapter().Fill((GODINEDataSet) item.DataSet, Conversions.ToShort(fillByRow["URAGODIDGODINE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowTIPURAIDTIPURA(DataRow fillByRow)
        {
            TIPURAWorkItem item = this.WorkItem.Items.AddNew<TIPURAWorkItem>();
            DataAdapterFactory.GetTIPURADataAdapter().Fill((TIPURADataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDTIPURA"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public URADataSet DataSet
        {
            get
            {
                return (URADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition URAFormDefinition
        {
            get
            {
                return this.URAWorkItem.URA;
            }
        }

        public NetAdvantage.WorkItems.URAWorkItem URAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.URAWorkItem) this.WorkItem;
            }
        }
    }
}

