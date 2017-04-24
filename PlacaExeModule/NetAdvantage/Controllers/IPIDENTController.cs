namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class IPIDENTController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetIPIDENTDataAdapter().Update(this.DataSet);
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
            item.ShowModal(false, "FillByIDIPIDENT", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public IPIDENTDataSet DataSet
        {
            get
            {
                return (IPIDENTDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition IPIDENTFormDefinition
        {
            get
            {
                return this.IPIDENTWorkItem.IPIDENT;
            }
        }

        public NetAdvantage.WorkItems.IPIDENTWorkItem IPIDENTWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.IPIDENTWorkItem) this.WorkItem;
            }
        }
    }
}

