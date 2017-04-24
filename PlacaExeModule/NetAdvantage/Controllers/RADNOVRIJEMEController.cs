namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class RADNOVRIJEMEController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetRADNOVRIJEMEDataAdapter().Update(this.DataSet);
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
            item.ShowModal(false, "FillByIDRADNOVRIJEME", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public RADNOVRIJEMEDataSet DataSet
        {
            get
            {
                return (RADNOVRIJEMEDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition RADNOVRIJEMEFormDefinition
        {
            get
            {
                return this.RADNOVRIJEMEWorkItem.RADNOVRIJEME;
            }
        }

        public NetAdvantage.WorkItems.RADNOVRIJEMEWorkItem RADNOVRIJEMEWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.RADNOVRIJEMEWorkItem) this.WorkItem;
            }
        }
    }
}

