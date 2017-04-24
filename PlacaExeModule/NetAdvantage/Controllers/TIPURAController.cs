namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class TIPURAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetTIPURADataAdapter().Update(this.DataSet);
        }

        public void NewURA(DataRow row)
        {
            URAWorkItem item = this.WorkItem.Items.AddNew<URAWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewURA(DataRow row)
        {
            URASelectionListWorkItem item = this.WorkItem.Items.AddNew<URASelectionListWorkItem>();
            item.ShowModal(false, "FillByIDTIPURA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public TIPURADataSet DataSet
        {
            get
            {
                return (TIPURADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition TIPURAFormDefinition
        {
            get
            {
                return this.TIPURAWorkItem.TIPURA;
            }
        }

        public NetAdvantage.WorkItems.TIPURAWorkItem TIPURAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.TIPURAWorkItem) this.WorkItem;
            }
        }
    }
}

