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

    public class UCENIKController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetUCENIKDataAdapter().Update(this.DataSet);
        }

        public DataRow SelectPOSTANSKIBROJEVIPOSTANSKIBROJ(string fillMethod, DataRow fillByRow)
        {
            POSTANSKIBROJEVISelectionListWorkItem item = this.WorkItem.Items.AddNew<POSTANSKIBROJEVISelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowPOSTANSKIBROJEVIPOSTANSKIBROJ(DataRow fillByRow)
        {
            POSTANSKIBROJEVIWorkItem item = this.WorkItem.Items.AddNew<POSTANSKIBROJEVIWorkItem>();
            DataAdapterFactory.GetPOSTANSKIBROJEVIDataAdapter().Fill((POSTANSKIBROJEVIDataSet) item.DataSet, Conversions.ToString(fillByRow["POSTANSKIBROJ"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public UCENIKDataSet DataSet
        {
            get
            {
                return (UCENIKDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition UCENIKFormDefinition
        {
            get
            {
                return this.UCENIKWorkItem.UCENIK;
            }
        }

        public NetAdvantage.WorkItems.UCENIKWorkItem UCENIKWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.UCENIKWorkItem) this.WorkItem;
            }
        }
    }
}

