namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class TIPIRAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetTIPIRADataAdapter().Update(this.DataSet);
        }

        public void NewIRA(DataRow row)
        {
            IraWorkItem item = this.WorkItem.Items.AddNew<IraWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewIRA(DataRow row)
        {
            IRASelectionListWorkItem item = this.WorkItem.Items.AddNew<IRASelectionListWorkItem>();
            item.ShowModal(false, "FillByIDTIPIRA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public TIPIRADataSet DataSet
        {
            get
            {
                return (TIPIRADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition TIPIRAFormDefinition
        {
            get
            {
                return this.TIPIRAWorkItem.TIPIRA;
            }
        }

        public NetAdvantage.WorkItems.TIPIRAWorkItem TIPIRAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.TIPIRAWorkItem) this.WorkItem;
            }
        }
    }
}

