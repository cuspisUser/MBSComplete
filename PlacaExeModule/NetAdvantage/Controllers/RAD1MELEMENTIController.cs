namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class RAD1MELEMENTIController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetRAD1MELEMENTIDataAdapter().Update(this.DataSet);
        }

        public void NewRAD1MELEMENTIVEZA(DataRow row)
        {
            RAD1MELEMENTIVEZAWorkItem item = this.WorkItem.Items.AddNew<RAD1MELEMENTIVEZAWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRAD1MELEMENTIVEZA(DataRow row)
        {
            RAD1MELEMENTIVEZASelectionListWorkItem item = this.WorkItem.Items.AddNew<RAD1MELEMENTIVEZASelectionListWorkItem>();
            item.ShowModal(false, "FillByRAD1ELEMENTIID", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public RAD1MELEMENTIDataSet DataSet
        {
            get
            {
                return (RAD1MELEMENTIDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition RAD1MELEMENTIFormDefinition
        {
            get
            {
                return this.RAD1MELEMENTIWorkItem.RAD1MELEMENTI;
            }
        }

        public NetAdvantage.WorkItems.RAD1MELEMENTIWorkItem RAD1MELEMENTIWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.RAD1MELEMENTIWorkItem) this.WorkItem;
            }
        }
    }
}

