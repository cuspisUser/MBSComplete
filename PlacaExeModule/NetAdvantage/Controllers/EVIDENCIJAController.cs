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

    public class EVIDENCIJAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetEVIDENCIJADataAdapter().Update(this.DataSet);
        }

        public DataRow SelectGODINEIDGODINE(string fillMethod, DataRow fillByRow)
        {
            GODINESelectionListWorkItem item = this.WorkItem.Items.AddNew<GODINESelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectSMJENEDRUGASMJENAIDSMJENE(string fillMethod, DataRow fillByRow)
        {
            SMJENESelectionListWorkItem item = this.WorkItem.Items.AddNew<SMJENESelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectSMJENEPRVASMJENAIDSMJENE(string fillMethod, DataRow fillByRow)
        {
            SMJENESelectionListWorkItem item = this.WorkItem.Items.AddNew<SMJENESelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowGODINEIDGODINE(DataRow fillByRow)
        {
            GODINEWorkItem item = this.WorkItem.Items.AddNew<GODINEWorkItem>();
            DataAdapterFactory.GetGODINEDataAdapter().Fill((GODINEDataSet) item.DataSet, Conversions.ToShort(fillByRow["IDGODINE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowSMJENEDRUGASMJENAIDSMJENE(DataRow fillByRow)
        {
            SMJENEWorkItem item = this.WorkItem.Items.AddNew<SMJENEWorkItem>();
            DataAdapterFactory.GetSMJENEDataAdapter().Fill((SMJENEDataSet) item.DataSet, Conversions.ToInteger(fillByRow["DRUGASMJENAIDSMJENE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowSMJENEPRVASMJENAIDSMJENE(DataRow fillByRow)
        {
            SMJENEWorkItem item = this.WorkItem.Items.AddNew<SMJENEWorkItem>();
            DataAdapterFactory.GetSMJENEDataAdapter().Fill((SMJENEDataSet) item.DataSet, Conversions.ToInteger(fillByRow["PRVASMJENAIDSMJENE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public EVIDENCIJADataSet DataSet
        {
            get
            {
                return (EVIDENCIJADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition EVIDENCIJAFormDefinition
        {
            get
            {
                return this.EVIDENCIJAWorkItem.EVIDENCIJA;
            }
        }

        public NetAdvantage.WorkItems.EVIDENCIJAWorkItem EVIDENCIJAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.EVIDENCIJAWorkItem) this.WorkItem;
            }
        }
    }
}

