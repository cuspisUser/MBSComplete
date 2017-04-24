namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class FINPOREZController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetFINPOREZDataAdapter().Update(this.DataSet);
        }

        public void NewPROIZVOD(DataRow row)
        {
            PROIZVODWorkItem item = this.WorkItem.Items.AddNew<PROIZVODWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewPROIZVOD(DataRow row)
        {
            PROIZVODSelectionListWorkItem item = this.WorkItem.Items.AddNew<PROIZVODSelectionListWorkItem>();
            item.ShowModal(false, "FillByFINPOREZIDPOREZ", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public FINPOREZDataSet DataSet
        {
            get
            {
                return (FINPOREZDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition FINPOREZFormDefinition
        {
            get
            {
                return this.FINPOREZWorkItem.FINPOREZ;
            }
        }

        public NetAdvantage.WorkItems.FINPOREZWorkItem FINPOREZWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.FINPOREZWorkItem) this.WorkItem;
            }
        }
    }
}

