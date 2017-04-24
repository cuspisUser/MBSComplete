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

    public class GKSTAVKAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetGKSTAVKADataAdapter().Update(this.DataSet);
        }

        public void NewZATVARANJA(DataRow row)
        {
            ZATVARANJAWorkItem item = this.WorkItem.Items.AddNew<ZATVARANJAWorkItem>();
            if (row.Table.Columns.Contains("IDGKSTAVKA"))
            {
                row.Table.Columns["IDGKSTAVKA"].ExtendedProperties["AddColumnName"] = "GK2IDGKSTAVKA";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewZATVARANJA1(DataRow row)
        {
            ZATVARANJAWorkItem item = this.WorkItem.Items.AddNew<ZATVARANJAWorkItem>();
            if (row.Table.Columns.Contains("IDGKSTAVKA"))
            {
                row.Table.Columns["IDGKSTAVKA"].ExtendedProperties["AddColumnName"] = "GK1IDGKSTAVKA";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public DataRow SelectGODINEGKGODIDGODINE(string fillMethod, DataRow fillByRow)
        {
            GODINESelectionListWorkItem item = this.WorkItem.Items.AddNew<GODINESelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowGODINEGKGODIDGODINE(DataRow fillByRow)
        {
            GODINEWorkItem item = this.WorkItem.Items.AddNew<GODINEWorkItem>();
            DataAdapterFactory.GetGODINEDataAdapter().Fill((GODINEDataSet) item.DataSet, Conversions.ToShort(fillByRow["GKGODIDGODINE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public void ViewZATVARANJA(DataRow row)
        {
            ZATVARANJASelectionListWorkItem item = this.WorkItem.Items.AddNew<ZATVARANJASelectionListWorkItem>();
            item.ShowModal(false, "FillByGK2IDGKSTAVKA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewZATVARANJA1(DataRow row)
        {
            ZATVARANJASelectionListWorkItem item = this.WorkItem.Items.AddNew<ZATVARANJASelectionListWorkItem>();
            item.ShowModal(false, "FillByGK1IDGKSTAVKA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public GKSTAVKADataSet DataSet
        {
            get
            {
                return (GKSTAVKADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition GKSTAVKAFormDefinition
        {
            get
            {
                return this.GKSTAVKAWorkItem.GKSTAVKA;
            }
        }

        public NetAdvantage.WorkItems.GKSTAVKAWorkItem GKSTAVKAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.GKSTAVKAWorkItem) this.WorkItem;
            }
        }
    }
}

