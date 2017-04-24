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

    public class OSRAZMJESTAJController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetOSRAZMJESTAJDataAdapter().Update(this.DataSet);
        }

        public DataRow SelectOSINVBROJ(string fillMethod, DataRow fillByRow)
        {
            OSSelectionListWorkItem item = this.WorkItem.Items.AddNew<OSSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowOSINVBROJ(DataRow fillByRow)
        {
            OSWorkItem item = this.WorkItem.Items.AddNew<OSWorkItem>();
            DataAdapterFactory.GetOSDataAdapter().Fill((OSDataSet) item.DataSet, Conversions.ToLong(fillByRow["INVBROJ"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public OSRAZMJESTAJDataSet DataSet
        {
            get
            {
                return (OSRAZMJESTAJDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition OSRAZMJESTAJFormDefinition
        {
            get
            {
                return this.OSRAZMJESTAJWorkItem.OSRAZMJESTAJ;
            }
        }

        public NetAdvantage.WorkItems.OSRAZMJESTAJWorkItem OSRAZMJESTAJWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.OSRAZMJESTAJWorkItem) this.WorkItem;
            }
        }
    }
}

