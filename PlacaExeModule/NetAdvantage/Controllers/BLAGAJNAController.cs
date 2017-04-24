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

    public class BLAGAJNAController : FormControllerBase
    {
        public DialogResult AddBLAGAJNAStavkeBlagajne(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.BLAGAJNAWorkItem) this.WorkItem).BLAGAJNAStavkeBlagajne.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult DeleteBLAGAJNAStavkeBlagajne(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.BLAGAJNAWorkItem) this.WorkItem).BLAGAJNAStavkeBlagajne.Show(DeklaritMode.Delete, currentRow, false);
        }

        public override void DoUpdate()
        {
            DataAdapterFactory.GetBLAGAJNADataAdapter().Update(this.DataSet);
        }

        public DataRow SelectBLGVRSTEDOKIDBLGVRSTEDOK(string fillMethod, DataRow fillByRow)
        {
            BLGVRSTEDOKSelectionListWorkItem item = this.WorkItem.Items.AddNew<BLGVRSTEDOKSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectGODINEblggodineIDGODINE(string fillMethod, DataRow fillByRow)
        {
            GODINESelectionListWorkItem item = this.WorkItem.Items.AddNew<GODINESelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowBLGVRSTEDOKIDBLGVRSTEDOK(DataRow fillByRow)
        {
            BLGVRSTEDOKWorkItem item = this.WorkItem.Items.AddNew<BLGVRSTEDOKWorkItem>();
            DataAdapterFactory.GetBLGVRSTEDOKDataAdapter().Fill((BLGVRSTEDOKDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDBLGVRSTEDOK"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowGODINEblggodineIDGODINE(DataRow fillByRow)
        {
            GODINEWorkItem item = this.WorkItem.Items.AddNew<GODINEWorkItem>();
            DataAdapterFactory.GetGODINEDataAdapter().Fill((GODINEDataSet) item.DataSet, Conversions.ToShort(fillByRow["blggodineIDGODINE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DialogResult UpdateBLAGAJNAStavkeBlagajne(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.BLAGAJNAWorkItem) this.WorkItem).BLAGAJNAStavkeBlagajne.Show(DeklaritMode.Update, currentRow, false);
        }

        public FormDefinition BLAGAJNAFormDefinition
        {
            get
            {
                return this.BLAGAJNAWorkItem.BLAGAJNA;
            }
        }

        public FormDefinition BLAGAJNAStavkeBlagajneFormDefinition
        {
            get
            {
                return this.BLAGAJNAWorkItem.BLAGAJNAStavkeBlagajne;
            }
        }

        public NetAdvantage.WorkItems.BLAGAJNAWorkItem BLAGAJNAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.BLAGAJNAWorkItem) this.WorkItem;
            }
        }

        public BLAGAJNADataSet DataSet
        {
            get
            {
                return (BLAGAJNADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }
    }
}

