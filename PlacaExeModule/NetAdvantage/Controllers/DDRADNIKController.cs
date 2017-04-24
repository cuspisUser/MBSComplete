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

    public class DDRADNIKController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetDDRADNIKDataAdapter().Update(this.DataSet);
        }

        public DataRow SelectBANKEIDBANKE(string fillMethod, DataRow fillByRow)
        {
            BANKESelectionListWorkItem item = this.WorkItem.Items.AddNew<BANKESelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectOPCINAOPCINARADAIDOPCINE(string fillMethod, DataRow fillByRow)
        {
            OPCINASelectionListWorkItem item = this.WorkItem.Items.AddNew<OPCINASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectOPCINAOPCINASTANOVANJAIDOPCINE(string fillMethod, DataRow fillByRow)
        {
            OPCINASelectionListWorkItem item = this.WorkItem.Items.AddNew<OPCINASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowBANKEIDBANKE(DataRow fillByRow)
        {
            BANKEWorkItem item = this.WorkItem.Items.AddNew<BANKEWorkItem>();
            DataAdapterFactory.GetBANKEDataAdapter().Fill((BANKEDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDBANKE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowOPCINAOPCINARADAIDOPCINE(DataRow fillByRow)
        {
            OPCINAWorkItem item = this.WorkItem.Items.AddNew<OPCINAWorkItem>();
            DataAdapterFactory.GetOPCINADataAdapter().Fill((OPCINADataSet) item.DataSet, Conversions.ToString(fillByRow["OPCINARADAIDOPCINE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowOPCINAOPCINASTANOVANJAIDOPCINE(DataRow fillByRow)
        {
            OPCINAWorkItem item = this.WorkItem.Items.AddNew<OPCINAWorkItem>();
            DataAdapterFactory.GetOPCINADataAdapter().Fill((OPCINADataSet) item.DataSet, Conversions.ToString(fillByRow["OPCINASTANOVANJAIDOPCINE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DDRADNIKDataSet DataSet
        {
            get
            {
                return (DDRADNIKDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition DDRADNIKFormDefinition
        {
            get
            {
                return this.DDRADNIKWorkItem.DDRADNIK;
            }
        }

        public NetAdvantage.WorkItems.DDRADNIKWorkItem DDRADNIKWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.DDRADNIKWorkItem) this.WorkItem;
            }
        }
    }
}

