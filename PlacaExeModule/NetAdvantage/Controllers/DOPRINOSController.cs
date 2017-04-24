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

    public class DOPRINOSController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetDOPRINOSDataAdapter().Update(this.DataSet);
        }

        public DataRow SelectVRSTADOPRINOSIDVRSTADOPRINOS(string fillMethod, DataRow fillByRow)
        {
            VRSTADOPRINOSSelectionListWorkItem item = this.WorkItem.Items.AddNew<VRSTADOPRINOSSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowVRSTADOPRINOSIDVRSTADOPRINOS(DataRow fillByRow)
        {
            VRSTADOPRINOSWorkItem item = this.WorkItem.Items.AddNew<VRSTADOPRINOSWorkItem>();
            DataAdapterFactory.GetVRSTADOPRINOSDataAdapter().Fill((VRSTADOPRINOSDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDVRSTADOPRINOS"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DOPRINOSDataSet DataSet
        {
            get
            {
                return (DOPRINOSDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition DOPRINOSFormDefinition
        {
            get
            {
                return this.DOPRINOSWorkItem.DOPRINOS;
            }
        }

        public NetAdvantage.WorkItems.DOPRINOSWorkItem DOPRINOSWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.DOPRINOSWorkItem) this.WorkItem;
            }
        }
    }
}

