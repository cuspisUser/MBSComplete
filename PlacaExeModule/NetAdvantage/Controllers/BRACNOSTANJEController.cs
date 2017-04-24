namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class BRACNOSTANJEController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetBRACNOSTANJEDataAdapter().Update(this.DataSet);
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
            item.ShowModal(false, "FillByIDBRACNOSTANJE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public FormDefinition BRACNOSTANJEFormDefinition
        {
            get
            {
                return this.BRACNOSTANJEWorkItem.BRACNOSTANJE;
            }
        }

        public NetAdvantage.WorkItems.BRACNOSTANJEWorkItem BRACNOSTANJEWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.BRACNOSTANJEWorkItem) this.WorkItem;
            }
        }

        public BRACNOSTANJEDataSet DataSet
        {
            get
            {
                return (BRACNOSTANJEDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }
    }
}

