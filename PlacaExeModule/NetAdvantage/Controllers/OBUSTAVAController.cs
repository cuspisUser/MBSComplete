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

    public class OBUSTAVAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetOBUSTAVADataAdapter().Update(this.DataSet);
        }

        public DataRow SelectVRSTAOBUSTAVEVRSTAOBUSTAVE(string fillMethod, DataRow fillByRow)
        {
            VRSTAOBUSTAVESelectionListWorkItem item = this.WorkItem.Items.AddNew<VRSTAOBUSTAVESelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowVRSTAOBUSTAVEVRSTAOBUSTAVE(DataRow fillByRow)
        {
            VRSTAOBUSTAVEWorkItem item = this.WorkItem.Items.AddNew<VRSTAOBUSTAVEWorkItem>();
            DataAdapterFactory.GetVRSTAOBUSTAVEDataAdapter().Fill((VRSTAOBUSTAVEDataSet) item.DataSet, Conversions.ToShort(fillByRow["VRSTAOBUSTAVE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public OBUSTAVADataSet DataSet
        {
            get
            {
                return (OBUSTAVADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition OBUSTAVAFormDefinition
        {
            get
            {
                return this.OBUSTAVAWorkItem.OBUSTAVA;
            }
        }

        public NetAdvantage.WorkItems.OBUSTAVAWorkItem OBUSTAVAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.OBUSTAVAWorkItem) this.WorkItem;
            }
        }
    }
}

