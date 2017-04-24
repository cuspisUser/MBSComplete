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

    public class UCENIKOBRACUNController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetUCENIKOBRACUNDataAdapter().Update(this.DataSet);
        }

        public DataRow SelectUCENIKIDUCENIK(string fillMethod, DataRow fillByRow)
        {
            UCENIKSelectionListWorkItem item = this.WorkItem.Items.AddNew<UCENIKSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowUCENIKIDUCENIK(DataRow fillByRow)
        {
            UCENIKWorkItem item = this.WorkItem.Items.AddNew<UCENIKWorkItem>();
            DataAdapterFactory.GetUCENIKDataAdapter().Fill((UCENIKDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDUCENIK"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public UCENIKOBRACUNDataSet DataSet
        {
            get
            {
                return (UCENIKOBRACUNDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition UCENIKOBRACUNFormDefinition
        {
            get
            {
                return this.UCENIKOBRACUNWorkItem.UCENIKOBRACUN;
            }
        }

        public NetAdvantage.WorkItems.UCENIKOBRACUNWorkItem UCENIKOBRACUNWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.UCENIKOBRACUNWorkItem) this.WorkItem;
            }
        }
    }
}

