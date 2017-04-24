namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class STRUKAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetSTRUKADataAdapter().Update(this.DataSet);
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
            item.ShowModal(false, "FillByIDSTRUKA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public STRUKADataSet DataSet
        {
            get
            {
                return (STRUKADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition STRUKAFormDefinition
        {
            get
            {
                return this.STRUKAWorkItem.STRUKA;
            }
        }

        public NetAdvantage.WorkItems.STRUKAWorkItem STRUKAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.STRUKAWorkItem) this.WorkItem;
            }
        }
    }
}

