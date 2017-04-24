namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class UGOVORORADUController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetUGOVORORADUDataAdapter().Update(this.DataSet);
        }

        public void NewRADNIK(DataRow row)
        {
            RADNIKWorkItem item = this.WorkItem.Items.AddNew<RADNIKWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRADNIK(DataRow row)
        {
            RADNIKSelectionListWorkItem item = this.WorkItem.Items.AddNew<RADNIKSelectionListWorkItem>();
            item.ShowModal(false, "FillByIDUGOVORORADU", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public UGOVORORADUDataSet DataSet
        {
            get
            {
                return (UGOVORORADUDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition UGOVORORADUFormDefinition
        {
            get
            {
                return this.UGOVORORADUWorkItem.UGOVORORADU;
            }
        }

        public NetAdvantage.WorkItems.UGOVORORADUWorkItem UGOVORORADUWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.UGOVORORADUWorkItem) this.WorkItem;
            }
        }
    }
}

