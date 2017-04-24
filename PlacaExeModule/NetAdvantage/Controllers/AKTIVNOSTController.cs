namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class AKTIVNOSTController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetAKTIVNOSTDataAdapter().Update(this.DataSet);
        }

        public void NewKONTO(DataRow row)
        {
            KONTOWorkItem item = this.WorkItem.Items.AddNew<KONTOWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewKONTO(DataRow row)
        {
            KONTOSelectionListWorkItem item = this.WorkItem.Items.AddNew<KONTOSelectionListWorkItem>();
            item.ShowModal(false, "FillByIDAKTIVNOST", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public FormDefinition AKTIVNOSTFormDefinition
        {
            get
            {
                return this.AKTIVNOSTWorkItem.AKTIVNOST;
            }
        }

        public NetAdvantage.WorkItems.AKTIVNOSTWorkItem AKTIVNOSTWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.AKTIVNOSTWorkItem) this.WorkItem;
            }
        }

        public AKTIVNOSTDataSet DataSet
        {
            get
            {
                return (AKTIVNOSTDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }
    }
}

