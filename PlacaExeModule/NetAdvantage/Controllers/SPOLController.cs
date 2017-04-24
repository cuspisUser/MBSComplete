namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class SPOLController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetSPOLDataAdapter().Update(this.DataSet);
        }

        public void NewRAD1VEZASPOL(DataRow row)
        {
            RAD1VEZASPOLWorkItem item = this.WorkItem.Items.AddNew<RAD1VEZASPOLWorkItem>();
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

        public void ViewRAD1VEZASPOL(DataRow row)
        {
            RAD1VEZASPOLSelectionListWorkItem item = this.WorkItem.Items.AddNew<RAD1VEZASPOLSelectionListWorkItem>();
            item.ShowModal(false, "FillByIDSPOL", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRADNIK(DataRow row)
        {
            RADNIKSelectionListWorkItem item = this.WorkItem.Items.AddNew<RADNIKSelectionListWorkItem>();
            item.ShowModal(false, "FillByIDSPOL", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public SPOLDataSet DataSet
        {
            get
            {
                return (SPOLDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition SPOLFormDefinition
        {
            get
            {
                return this.SPOLWorkItem.SPOL;
            }
        }

        public NetAdvantage.WorkItems.SPOLWorkItem SPOLWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.SPOLWorkItem) this.WorkItem;
            }
        }
    }
}

