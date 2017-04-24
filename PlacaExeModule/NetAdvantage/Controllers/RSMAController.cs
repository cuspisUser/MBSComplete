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

    public class RSMAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetRSMADataAdapter().Update(this.DataSet);
        }

        public DataRow SelectOBRACUNIDOBRACUN(string fillMethod, DataRow fillByRow)
        {
            OBRACUNSelectionListWorkItem item = this.WorkItem.Items.AddNew<OBRACUNSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectRSVRSTEOBRACUNAIDRSVRSTEOBRACUNA(string fillMethod, DataRow fillByRow)
        {
            RSVRSTEOBRACUNASelectionListWorkItem item = this.WorkItem.Items.AddNew<RSVRSTEOBRACUNASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectRSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKA(string fillMethod, DataRow fillByRow)
        {
            RSVRSTEOBVEZNIKASelectionListWorkItem item = this.WorkItem.Items.AddNew<RSVRSTEOBVEZNIKASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowOBRACUNIDOBRACUN(DataRow fillByRow)
        {
            OBRACUNWorkItem item = this.WorkItem.Items.AddNew<OBRACUNWorkItem>();
            DataAdapterFactory.GetOBRACUNDataAdapter().Fill((OBRACUNDataSet) item.DataSet, Conversions.ToString(fillByRow["IDOBRACUN"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowRSVRSTEOBRACUNAIDRSVRSTEOBRACUNA(DataRow fillByRow)
        {
            RSVRSTEOBRACUNAWorkItem item = this.WorkItem.Items.AddNew<RSVRSTEOBRACUNAWorkItem>();
            DataAdapterFactory.GetRSVRSTEOBRACUNADataAdapter().Fill((RSVRSTEOBRACUNADataSet) item.DataSet, Conversions.ToString(fillByRow["IDRSVRSTEOBRACUNA"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowRSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKA(DataRow fillByRow)
        {
            RSVRSTEOBVEZNIKAWorkItem item = this.WorkItem.Items.AddNew<RSVRSTEOBVEZNIKAWorkItem>();
            DataAdapterFactory.GetRSVRSTEOBVEZNIKADataAdapter().Fill((RSVRSTEOBVEZNIKADataSet) item.DataSet, Conversions.ToString(fillByRow["IDRSVRSTEOBVEZNIKA"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public RSMADataSet DataSet
        {
            get
            {
                return (RSMADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition RSMAFormDefinition
        {
            get
            {
                return this.RSMAWorkItem.RSMA;
            }
        }

        public NetAdvantage.WorkItems.RSMAWorkItem RSMAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.RSMAWorkItem) this.WorkItem;
            }
        }
    }
}

