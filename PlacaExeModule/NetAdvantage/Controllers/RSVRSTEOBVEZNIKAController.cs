namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class RSVRSTEOBVEZNIKAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetRSVRSTEOBVEZNIKADataAdapter().Update(this.DataSet);
        }

        public void NewRSMA(DataRow row)
        {
            RSMAWorkItem item = this.WorkItem.Items.AddNew<RSMAWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRSMA(DataRow row)
        {
            RSMASelectionListWorkItem item = this.WorkItem.Items.AddNew<RSMASelectionListWorkItem>();
            item.ShowModal(false, "FillByIDRSVRSTEOBVEZNIKA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public RSVRSTEOBVEZNIKADataSet DataSet
        {
            get
            {
                return (RSVRSTEOBVEZNIKADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition RSVRSTEOBVEZNIKAFormDefinition
        {
            get
            {
                return this.RSVRSTEOBVEZNIKAWorkItem.RSVRSTEOBVEZNIKA;
            }
        }

        public NetAdvantage.WorkItems.RSVRSTEOBVEZNIKAWorkItem RSVRSTEOBVEZNIKAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.RSVRSTEOBVEZNIKAWorkItem) this.WorkItem;
            }
        }
    }
}

