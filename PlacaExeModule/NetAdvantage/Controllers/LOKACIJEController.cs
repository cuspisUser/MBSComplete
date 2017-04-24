namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class LOKACIJEController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetLOKACIJEDataAdapter().Update(this.DataSet);
        }

        public void NewOSRAZMJESTAJ(DataRow row)
        {
            OSRAZMJESTAJWorkItem item = this.WorkItem.Items.AddNew<OSRAZMJESTAJWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewOSRAZMJESTAJ(DataRow row)
        {
            OSRAZMJESTAJSelectionListWorkItem item = this.WorkItem.Items.AddNew<OSRAZMJESTAJSelectionListWorkItem>();
            item.ShowModal(false, "FillByIDLOKACIJE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public LOKACIJEDataSet DataSet
        {
            get
            {
                return (LOKACIJEDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition LOKACIJEFormDefinition
        {
            get
            {
                return this.LOKACIJEWorkItem.LOKACIJE;
            }
        }

        public NetAdvantage.WorkItems.LOKACIJEWorkItem LOKACIJEWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.LOKACIJEWorkItem) this.WorkItem;
            }
        }
    }
}

