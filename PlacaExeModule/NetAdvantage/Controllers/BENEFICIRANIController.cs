namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class BENEFICIRANIController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetBENEFICIRANIDataAdapter().Update(this.DataSet);
        }

        public void NewRADNIK(DataRow row)
        {
            RADNIKWorkItem item = this.WorkItem.Items.AddNew<RADNIKWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRADNIK(DataRow row)
        {
            RADNIKSelectionListWorkItem item = this.WorkItem.Items.AddNew<RADNIKSelectionListWorkItem>();
            item.ShowModal(false, "FillByIDBENEFICIRANI", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public FormDefinition BENEFICIRANIFormDefinition
        {
            get
            {
                return this.BENEFICIRANIWorkItem.BENEFICIRANI;
            }
        }

        public NetAdvantage.WorkItems.BENEFICIRANIWorkItem BENEFICIRANIWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.BENEFICIRANIWorkItem) this.WorkItem;
            }
        }

        public BENEFICIRANIDataSet DataSet
        {
            get
            {
                return (BENEFICIRANIDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }
    }
}

