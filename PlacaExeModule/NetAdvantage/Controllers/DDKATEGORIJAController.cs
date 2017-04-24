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

    public class DDKATEGORIJAController : FormControllerBase
    {
        public DialogResult AddDDKATEGORIJAIzdaci(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.DDKATEGORIJAWorkItem) this.WorkItem).DDKATEGORIJAIzdaci.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddDDKATEGORIJALevel1(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.DDKATEGORIJAWorkItem) this.WorkItem).DDKATEGORIJALevel1.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddDDKATEGORIJALevel3(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.DDKATEGORIJAWorkItem) this.WorkItem).DDKATEGORIJALevel3.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult DeleteDDKATEGORIJAIzdaci(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.DDKATEGORIJAWorkItem) this.WorkItem).DDKATEGORIJAIzdaci.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteDDKATEGORIJALevel1(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.DDKATEGORIJAWorkItem) this.WorkItem).DDKATEGORIJALevel1.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteDDKATEGORIJALevel3(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.DDKATEGORIJAWorkItem) this.WorkItem).DDKATEGORIJALevel3.Show(DeklaritMode.Delete, currentRow, false);
        }

        public override void DoUpdate()
        {
            DataAdapterFactory.GetDDKATEGORIJADataAdapter().Update(this.DataSet);
        }

        public DataRow SelectDDIZDATAKDDIDIZDATAK(string fillMethod, DataRow fillByRow)
        {
            DDIZDATAKSelectionListWorkItem item = this.WorkItem.Items.AddNew<DDIZDATAKSelectionListWorkItem>();
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

        public DialogResult UpdateDDKATEGORIJAIzdaci(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.DDKATEGORIJAWorkItem) this.WorkItem).DDKATEGORIJAIzdaci.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateDDKATEGORIJALevel1(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.DDKATEGORIJAWorkItem) this.WorkItem).DDKATEGORIJALevel1.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateDDKATEGORIJALevel3(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.DDKATEGORIJAWorkItem) this.WorkItem).DDKATEGORIJALevel3.Show(DeklaritMode.Update, currentRow, false);
        }

        public DDKATEGORIJADataSet DataSet
        {
            get
            {
                return (DDKATEGORIJADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition DDKATEGORIJAFormDefinition
        {
            get
            {
                return this.DDKATEGORIJAWorkItem.DDKATEGORIJA;
            }
        }

        public FormDefinition DDKATEGORIJAIzdaciFormDefinition
        {
            get
            {
                return this.DDKATEGORIJAWorkItem.DDKATEGORIJAIzdaci;
            }
        }

        public FormDefinition DDKATEGORIJALevel1FormDefinition
        {
            get
            {
                return this.DDKATEGORIJAWorkItem.DDKATEGORIJALevel1;
            }
        }

        public FormDefinition DDKATEGORIJALevel3FormDefinition
        {
            get
            {
                return this.DDKATEGORIJAWorkItem.DDKATEGORIJALevel3;
            }
        }

        public NetAdvantage.WorkItems.DDKATEGORIJAWorkItem DDKATEGORIJAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.DDKATEGORIJAWorkItem) this.WorkItem;
            }
        }
    }
}

