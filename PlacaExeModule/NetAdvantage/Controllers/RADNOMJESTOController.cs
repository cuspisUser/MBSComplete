namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class RADNOMJESTOController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetRADNOMJESTODataAdapter().Update(this.DataSet);
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
            item.ShowModal(false, "FillByIDRADNOMJESTO", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public RADNOMJESTODataSet DataSet
        {
            get
            {
                return (RADNOMJESTODataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition RADNOMJESTOFormDefinition
        {
            get
            {
                return this.RADNOMJESTOWorkItem.RADNOMJESTO;
            }
        }

        public NetAdvantage.WorkItems.RADNOMJESTOWorkItem RADNOMJESTOWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.RADNOMJESTOWorkItem) this.WorkItem;
            }
        }
    }
}

