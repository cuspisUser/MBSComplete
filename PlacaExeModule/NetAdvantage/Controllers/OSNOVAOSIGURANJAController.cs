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

    public class OSNOVAOSIGURANJAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetOSNOVAOSIGURANJADataAdapter().Update(this.DataSet);
        }

        public void NewELEMENT(DataRow row)
        {
            ELEMENTWorkItem item = this.WorkItem.Items.AddNew<ELEMENTWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public DataRow SelectOSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJA(string fillMethod, DataRow fillByRow)
        {
            OSNOVAOSIGURANJASelectionListWorkItem item = this.WorkItem.Items.AddNew<OSNOVAOSIGURANJASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowOSNOVAOSIGURANJAZAMOOIDOSNOVAOSIGURANJA(DataRow fillByRow)
        {
            NetAdvantage.WorkItems.OSNOVAOSIGURANJAWorkItem item = this.WorkItem.Items.AddNew<NetAdvantage.WorkItems.OSNOVAOSIGURANJAWorkItem>();
            DataAdapterFactory.GetOSNOVAOSIGURANJADataAdapter().Fill((OSNOVAOSIGURANJADataSet) item.DataSet, Conversions.ToString(fillByRow["ZAMOOIDOSNOVAOSIGURANJA"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public void ViewELEMENT(DataRow row)
        {
            ELEMENTSelectionListWorkItem item = this.WorkItem.Items.AddNew<ELEMENTSelectionListWorkItem>();
            item.ShowModal(false, "FillByIDOSNOVAOSIGURANJA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public OSNOVAOSIGURANJADataSet DataSet
        {
            get
            {
                return (OSNOVAOSIGURANJADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition OSNOVAOSIGURANJAFormDefinition
        {
            get
            {
                return this.OSNOVAOSIGURANJAWorkItem.OSNOVAOSIGURANJA;
            }
        }

        public NetAdvantage.WorkItems.OSNOVAOSIGURANJAWorkItem OSNOVAOSIGURANJAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.OSNOVAOSIGURANJAWorkItem) this.WorkItem;
            }
        }
    }
}

