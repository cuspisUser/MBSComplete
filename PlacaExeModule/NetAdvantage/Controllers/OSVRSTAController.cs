namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class OSVRSTAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetOSVRSTADataAdapter().Update(this.DataSet);
        }

        public void NewOS(DataRow row)
        {
            OSWorkItem item = this.WorkItem.Items.AddNew<OSWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewOS(DataRow row)
        {
            OSSelectionListWorkItem item = this.WorkItem.Items.AddNew<OSSelectionListWorkItem>();
            item.ShowModal(false, "FillByIDOSVRSTA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public OSVRSTADataSet DataSet
        {
            get
            {
                return (OSVRSTADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition OSVRSTAFormDefinition
        {
            get
            {
                return this.OSVRSTAWorkItem.OSVRSTA;
            }
        }

        public NetAdvantage.WorkItems.OSVRSTAWorkItem OSVRSTAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.OSVRSTAWorkItem) this.WorkItem;
            }
        }
    }
}

