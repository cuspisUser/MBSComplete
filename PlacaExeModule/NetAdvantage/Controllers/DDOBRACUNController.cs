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

    public class DDOBRACUNController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetDDOBRACUNDataAdapter().Update(this.DataSet);
        }

        public DataRow SelectDDIZDATAKDDIDIZDATAK(string fillMethod, DataRow fillByRow)
        {
            DDIZDATAKSelectionListWorkItem item = this.WorkItem.Items.AddNew<DDIZDATAKSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectDDKATEGORIJAIDKATEGORIJA(string fillMethod, DataRow fillByRow)
        {
            DDKATEGORIJASelectionListWorkItem item = this.WorkItem.Items.AddNew<DDKATEGORIJASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectDDRADNIKDDIDRADNIK(string fillMethod, DataRow fillByRow)
        {
            DDRADNIKSelectionListWorkItem item = this.WorkItem.Items.AddNew<DDRADNIKSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectDDVRSTEPOSLADDIDVRSTAPOSLA(string fillMethod, DataRow fillByRow)
        {
            DDVRSTEPOSLASelectionListWorkItem item = this.WorkItem.Items.AddNew<DDVRSTEPOSLASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectDOPRINOSIDDOPRINOS(string fillMethod, DataRow fillByRow)
        {
            DOPRINOSSelectionListWorkItem item = this.WorkItem.Items.AddNew<DOPRINOSSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectKRIZNIPOREZIDKRIZNIPOREZ(string fillMethod, DataRow fillByRow)
        {
            KRIZNIPOREZSelectionListWorkItem item = this.WorkItem.Items.AddNew<KRIZNIPOREZSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectPOREZIDPOREZ(string fillMethod, DataRow fillByRow)
        {
            POREZSelectionListWorkItem item = this.WorkItem.Items.AddNew<POREZSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowDDIZDATAKDDIDIZDATAK(DataRow fillByRow)
        {
            DDIZDATAKWorkItem item = this.WorkItem.Items.AddNew<DDIZDATAKWorkItem>();
            DataAdapterFactory.GetDDIZDATAKDataAdapter().Fill((DDIZDATAKDataSet) item.DataSet, Conversions.ToInteger(fillByRow["DDIDIZDATAK"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowDDKATEGORIJAIDKATEGORIJA(DataRow fillByRow)
        {
            DDKATEGORIJAWorkItem item = this.WorkItem.Items.AddNew<DDKATEGORIJAWorkItem>();
            DataAdapterFactory.GetDDKATEGORIJADataAdapter().Fill((DDKATEGORIJADataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDKATEGORIJA"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowDDRADNIKDDIDRADNIK(DataRow fillByRow)
        {
            DDRADNIKWorkItem item = this.WorkItem.Items.AddNew<DDRADNIKWorkItem>();
            DataAdapterFactory.GetDDRADNIKDataAdapter().Fill((DDRADNIKDataSet) item.DataSet, Conversions.ToInteger(fillByRow["DDIDRADNIK"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowDDVRSTEPOSLADDIDVRSTAPOSLA(DataRow fillByRow)
        {
            DDVRSTEPOSLAWorkItem item = this.WorkItem.Items.AddNew<DDVRSTEPOSLAWorkItem>();
            DataAdapterFactory.GetDDVRSTEPOSLADataAdapter().Fill((DDVRSTEPOSLADataSet) item.DataSet, Conversions.ToInteger(fillByRow["DDIDVRSTAPOSLA"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowDOPRINOSIDDOPRINOS(DataRow fillByRow)
        {
            DOPRINOSWorkItem item = this.WorkItem.Items.AddNew<DOPRINOSWorkItem>();
            DataAdapterFactory.GetDOPRINOSDataAdapter().Fill((DOPRINOSDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDDOPRINOS"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowKRIZNIPOREZIDKRIZNIPOREZ(DataRow fillByRow)
        {
            KRIZNIPOREZWorkItem item = this.WorkItem.Items.AddNew<KRIZNIPOREZWorkItem>();
            DataAdapterFactory.GetKRIZNIPOREZDataAdapter().Fill((KRIZNIPOREZDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDKRIZNIPOREZ"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowPOREZIDPOREZ(DataRow fillByRow)
        {
            POREZWorkItem item = this.WorkItem.Items.AddNew<POREZWorkItem>();
            DataAdapterFactory.GetPOREZDataAdapter().Fill((POREZDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDPOREZ"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DDOBRACUNDataSet DataSet
        {
            get
            {
                return (DDOBRACUNDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition DDOBRACUNFormDefinition
        {
            get
            {
                return this.DDOBRACUNWorkItem.DDOBRACUN;
            }
        }

        public NetAdvantage.WorkItems.DDOBRACUNWorkItem DDOBRACUNWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.DDOBRACUNWorkItem) this.WorkItem;
            }
        }
    }
}

