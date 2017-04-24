namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class MJESTOTROSKAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetMJESTOTROSKADataAdapter().Update(this.DataSet);
        }

        public void NewGKSTAVKA(DataRow row)
        {
            GKSTAVKAWorkItem item = this.WorkItem.Items.AddNew<GKSTAVKAWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewGKSTAVKA(DataRow row)
        {
            GKSTAVKASelectionListWorkItem item = this.WorkItem.Items.AddNew<GKSTAVKASelectionListWorkItem>();
            item.ShowModal(false, "FillByIDMJESTOTROSKA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public MJESTOTROSKADataSet DataSet
        {
            get
            {
                return (MJESTOTROSKADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition MJESTOTROSKAFormDefinition
        {
            get
            {
                return this.MJESTOTROSKAWorkItem.MJESTOTROSKA;
            }
        }

        public NetAdvantage.WorkItems.MJESTOTROSKAWorkItem MJESTOTROSKAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.MJESTOTROSKAWorkItem) this.WorkItem;
            }
        }
    }
}

