namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class BANKEController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetBANKEDataAdapter().Update(this.DataSet);
        }

        public void NewDDRADNIK(DataRow row)
        {
            DDRADNIKWorkItem item = this.WorkItem.Items.AddNew<DDRADNIKWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewRADNIK(DataRow row)
        {
            RADNIKWorkItem item = this.WorkItem.Items.AddNew<RADNIKWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewDDRADNIK(DataRow row)
        {
            DDRADNIKSelectionListWorkItem item = this.WorkItem.Items.AddNew<DDRADNIKSelectionListWorkItem>();
            item.ShowModal(false, "FillByIDBANKE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRADNIK(DataRow row)
        {
            RADNIKSelectionListWorkItem item = this.WorkItem.Items.AddNew<RADNIKSelectionListWorkItem>();
            item.ShowModal(false, "FillByIDBANKE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public FormDefinition BANKEFormDefinition
        {
            get
            {
                return this.BANKEWorkItem.BANKE;
            }
        }

        public NetAdvantage.WorkItems.BANKEWorkItem BANKEWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.BANKEWorkItem) this.WorkItem;
            }
        }

        public BANKEDataSet DataSet
        {
            get
            {
                return (BANKEDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }
    }
}

