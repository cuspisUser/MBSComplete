namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class RAD1SPOLController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetRAD1SPOLDataAdapter().Update(this.DataSet);
        }

        public void NewRAD1VEZASPOL(DataRow row)
        {
            RAD1VEZASPOLWorkItem item = this.WorkItem.Items.AddNew<RAD1VEZASPOLWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRAD1VEZASPOL(DataRow row)
        {
            RAD1VEZASPOLSelectionListWorkItem item = this.WorkItem.Items.AddNew<RAD1VEZASPOLSelectionListWorkItem>();
            item.ShowModal(false, "FillByRAD1SPOLID", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public RAD1SPOLDataSet DataSet
        {
            get
            {
                return (RAD1SPOLDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition RAD1SPOLFormDefinition
        {
            get
            {
                return this.RAD1SPOLWorkItem.RAD1SPOL;
            }
        }

        public NetAdvantage.WorkItems.RAD1SPOLWorkItem RAD1SPOLWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.RAD1SPOLWorkItem) this.WorkItem;
            }
        }
    }
}

