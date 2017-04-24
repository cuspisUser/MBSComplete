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

    public class ZATVARANJAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetZATVARANJADataAdapter().Update(this.DataSet);
        }

        public DataRow SelectGKSTAVKAGK1IDGKSTAVKA(string fillMethod, DataRow fillByRow)
        {
            GKSTAVKASelectionListWorkItem item = this.WorkItem.Items.AddNew<GKSTAVKASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectGKSTAVKAGK2IDGKSTAVKA(string fillMethod, DataRow fillByRow)
        {
            GKSTAVKASelectionListWorkItem item = this.WorkItem.Items.AddNew<GKSTAVKASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowGKSTAVKAGK1IDGKSTAVKA(DataRow fillByRow)
        {
            GKSTAVKAWorkItem item = this.WorkItem.Items.AddNew<GKSTAVKAWorkItem>();
            DataAdapterFactory.GetGKSTAVKADataAdapter().Fill((GKSTAVKADataSet) item.DataSet, Conversions.ToInteger(fillByRow["GK1IDGKSTAVKA"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowGKSTAVKAGK2IDGKSTAVKA(DataRow fillByRow)
        {
            GKSTAVKAWorkItem item = this.WorkItem.Items.AddNew<GKSTAVKAWorkItem>();
            DataAdapterFactory.GetGKSTAVKADataAdapter().Fill((GKSTAVKADataSet) item.DataSet, Conversions.ToInteger(fillByRow["GK2IDGKSTAVKA"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public ZATVARANJADataSet DataSet
        {
            get
            {
                return (ZATVARANJADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition ZATVARANJAFormDefinition
        {
            get
            {
                return this.ZATVARANJAWorkItem.ZATVARANJA;
            }
        }

        public NetAdvantage.WorkItems.ZATVARANJAWorkItem ZATVARANJAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.ZATVARANJAWorkItem) this.WorkItem;
            }
        }
    }
}

