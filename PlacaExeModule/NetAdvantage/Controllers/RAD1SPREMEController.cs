namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class RAD1SPREMEController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetRAD1SPREMEDataAdapter().Update(this.DataSet);
        }

        public void NewRAD1SPREMEVEZA(DataRow row)
        {
            RAD1SPREMEVEZAWorkItem item = this.WorkItem.Items.AddNew<RAD1SPREMEVEZAWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRAD1SPREMEVEZA(DataRow row)
        {
            RAD1SPREMEVEZASelectionListWorkItem item = this.WorkItem.Items.AddNew<RAD1SPREMEVEZASelectionListWorkItem>();
            item.ShowModal(false, "FillByRAD1IDSPREME", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public RAD1SPREMEDataSet DataSet
        {
            get
            {
                return (RAD1SPREMEDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition RAD1SPREMEFormDefinition
        {
            get
            {
                return this.RAD1SPREMEWorkItem.RAD1SPREME;
            }
        }

        public NetAdvantage.WorkItems.RAD1SPREMEWorkItem RAD1SPREMEWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.RAD1SPREMEWorkItem) this.WorkItem;
            }
        }
    }
}

