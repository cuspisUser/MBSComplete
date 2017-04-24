namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class ORGDIOController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetORGDIODataAdapter().Update(this.DataSet);
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
            item.ShowModal(false, "FillByIDORGDIO", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public ORGDIODataSet DataSet
        {
            get
            {
                return (ORGDIODataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition ORGDIOFormDefinition
        {
            get
            {
                return this.ORGDIOWorkItem.ORGDIO;
            }
        }

        public NetAdvantage.WorkItems.ORGDIOWorkItem ORGDIOWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.ORGDIOWorkItem) this.WorkItem;
            }
        }
    }
}

