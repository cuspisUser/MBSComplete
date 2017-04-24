namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class RSVRSTEOBRACUNAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetRSVRSTEOBRACUNADataAdapter().Update(this.DataSet);
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
            item.ShowModal(false, "FillByIDRSVRSTEOBRACUNA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public RSVRSTEOBRACUNADataSet DataSet
        {
            get
            {
                return (RSVRSTEOBRACUNADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition RSVRSTEOBRACUNAFormDefinition
        {
            get
            {
                return this.RSVRSTEOBRACUNAWorkItem.RSVRSTEOBRACUNA;
            }
        }

        public NetAdvantage.WorkItems.RSVRSTEOBRACUNAWorkItem RSVRSTEOBRACUNAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.RSVRSTEOBRACUNAWorkItem) this.WorkItem;
            }
        }
    }
}

