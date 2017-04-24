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

    public class SHEMADDController : FormControllerBase
    {
        public DialogResult AddSHEMADDSHEMADDDOPRINOS(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMADDWorkItem) this.WorkItem).SHEMADDSHEMADDDOPRINOS.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddSHEMADDSHEMADDSTANDARD(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMADDWorkItem) this.WorkItem).SHEMADDSHEMADDSTANDARD.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult DeleteSHEMADDSHEMADDDOPRINOS(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMADDWorkItem) this.WorkItem).SHEMADDSHEMADDDOPRINOS.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteSHEMADDSHEMADDSTANDARD(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMADDWorkItem) this.WorkItem).SHEMADDSHEMADDSTANDARD.Show(DeklaritMode.Delete, currentRow, false);
        }

        public override void DoUpdate()
        {
            DataAdapterFactory.GetSHEMADDDataAdapter().Update(this.DataSet);
        }

        public DataRow SelectDDVRSTEIZNOSAIDDDVRSTEIZNOSA(string fillMethod, DataRow fillByRow)
        {
            DDVRSTEIZNOSASelectionListWorkItem item = this.WorkItem.Items.AddNew<DDVRSTEIZNOSASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectDOPRINOSSHEMADDDOPRINOSIDDOPRINOS(string fillMethod, DataRow fillByRow)
        {
            DOPRINOSSelectionListWorkItem item = this.WorkItem.Items.AddNew<DOPRINOSSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowDDVRSTEIZNOSAIDDDVRSTEIZNOSA(DataRow fillByRow)
        {
            DDVRSTEIZNOSAWorkItem item = this.WorkItem.Items.AddNew<DDVRSTEIZNOSAWorkItem>();
            DataAdapterFactory.GetDDVRSTEIZNOSADataAdapter().Fill((DDVRSTEIZNOSADataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDDDVRSTEIZNOSA"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowDOPRINOSSHEMADDDOPRINOSIDDOPRINOS(DataRow fillByRow)
        {
            DOPRINOSWorkItem item = this.WorkItem.Items.AddNew<DOPRINOSWorkItem>();
            DataAdapterFactory.GetDOPRINOSDataAdapter().Fill((DOPRINOSDataSet) item.DataSet, Conversions.ToInteger(fillByRow["SHEMADDDOPRINOSIDDOPRINOS"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DialogResult UpdateSHEMADDSHEMADDDOPRINOS(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMADDWorkItem) this.WorkItem).SHEMADDSHEMADDDOPRINOS.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateSHEMADDSHEMADDSTANDARD(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMADDWorkItem) this.WorkItem).SHEMADDSHEMADDSTANDARD.Show(DeklaritMode.Update, currentRow, false);
        }

        public SHEMADDDataSet DataSet
        {
            get
            {
                return (SHEMADDDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition SHEMADDFormDefinition
        {
            get
            {
                return this.SHEMADDWorkItem.SHEMADD;
            }
        }

        public FormDefinition SHEMADDSHEMADDDOPRINOSFormDefinition
        {
            get
            {
                return this.SHEMADDWorkItem.SHEMADDSHEMADDDOPRINOS;
            }
        }

        public FormDefinition SHEMADDSHEMADDSTANDARDFormDefinition
        {
            get
            {
                return this.SHEMADDWorkItem.SHEMADDSHEMADDSTANDARD;
            }
        }

        public NetAdvantage.WorkItems.SHEMADDWorkItem SHEMADDWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.SHEMADDWorkItem) this.WorkItem;
            }
        }
    }
}

