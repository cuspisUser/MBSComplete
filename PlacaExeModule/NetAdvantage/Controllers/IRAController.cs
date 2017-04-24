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

    public class IRAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetIRADataAdapter().Update(this.DataSet);
        }

        public DataRow SelectGODINEIRAGODIDGODINE(string fillMethod, DataRow fillByRow)
        {
            GODINESelectionListWorkItem item = this.WorkItem.Items.AddNew<GODINESelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectTIPIRAIDTIPIRA(string fillMethod, DataRow fillByRow)
        {
            TIPIRASelectionListWorkItem item = this.WorkItem.Items.AddNew<TIPIRASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowGODINEIRAGODIDGODINE(DataRow fillByRow)
        {
            GODINEWorkItem item = this.WorkItem.Items.AddNew<GODINEWorkItem>();
            DataAdapterFactory.GetGODINEDataAdapter().Fill((GODINEDataSet) item.DataSet, Conversions.ToShort(fillByRow["IRAGODIDGODINE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowTIPIRAIDTIPIRA(DataRow fillByRow)
        {
            TIPIRAWorkItem item = this.WorkItem.Items.AddNew<TIPIRAWorkItem>();
            DataAdapterFactory.GetTIPIRADataAdapter().Fill((TIPIRADataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDTIPIRA"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public IRADataSet DataSet
        {
            get
            {
                return (IRADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition IRAFormDefinition
        {
            get
            {
                return this.IRAWorkItem.IRA;
            }
        }

        public IraWorkItem IRAWorkItem
        {
            get
            {
                return (IraWorkItem) this.WorkItem;
            }
        }
    }
}

