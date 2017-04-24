namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class RAD1GELEMENTIController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetRAD1GELEMENTIDataAdapter().Update(this.DataSet);
        }

        public void NewRAD1GELEMENTIVEZA(DataRow row)
        {
            RAD1GELEMENTIVEZAWorkItem item = this.WorkItem.Items.AddNew<RAD1GELEMENTIVEZAWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRAD1GELEMENTIVEZA(DataRow row)
        {
            RAD1GELEMENTIVEZASelectionListWorkItem item = this.WorkItem.Items.AddNew<RAD1GELEMENTIVEZASelectionListWorkItem>();
            item.ShowModal(false, "FillByRAD1GELEMENTIID", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public RAD1GELEMENTIDataSet DataSet
        {
            get
            {
                return (RAD1GELEMENTIDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition RAD1GELEMENTIFormDefinition
        {
            get
            {
                return this.RAD1GELEMENTIWorkItem.RAD1GELEMENTI;
            }
        }

        public NetAdvantage.WorkItems.RAD1GELEMENTIWorkItem RAD1GELEMENTIWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.RAD1GELEMENTIWorkItem) this.WorkItem;
            }
        }
    }
}

