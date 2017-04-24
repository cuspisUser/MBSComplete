namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class DDKOLONAIDDController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetDDKOLONAIDDDataAdapter().Update(this.DataSet);
        }

        public void NewDDKATEGORIJA(DataRow row)
        {
            DDKATEGORIJAWorkItem item = this.WorkItem.Items.AddNew<DDKATEGORIJAWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewDDKATEGORIJA(DataRow row)
        {
            DDKATEGORIJASelectionListWorkItem item = this.WorkItem.Items.AddNew<DDKATEGORIJASelectionListWorkItem>();
            item.ShowModal(false, "FillByIDKOLONAIDD", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public DDKOLONAIDDDataSet DataSet
        {
            get
            {
                return (DDKOLONAIDDDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition DDKOLONAIDDFormDefinition
        {
            get
            {
                return this.DDKOLONAIDDWorkItem.DDKOLONAIDD;
            }
        }

        public NetAdvantage.WorkItems.DDKOLONAIDDWorkItem DDKOLONAIDDWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.DDKOLONAIDDWorkItem) this.WorkItem;
            }
        }
    }
}

