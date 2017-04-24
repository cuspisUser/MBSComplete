namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class POSTANSKIBROJEVIController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetPOSTANSKIBROJEVIDataAdapter().Update(this.DataSet);
        }

        public void NewUCENIK(DataRow row)
        {
            UCENIKWorkItem item = this.WorkItem.Items.AddNew<UCENIKWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewUCENIK(DataRow row)
        {
            UCENIKSelectionListWorkItem item = this.WorkItem.Items.AddNew<UCENIKSelectionListWorkItem>();
            item.ShowModal(false, "FillByPOSTANSKIBROJ", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public POSTANSKIBROJEVIDataSet DataSet
        {
            get
            {
                return (POSTANSKIBROJEVIDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition POSTANSKIBROJEVIFormDefinition
        {
            get
            {
                return this.POSTANSKIBROJEVIWorkItem.POSTANSKIBROJEVI;
            }
        }

        public NetAdvantage.WorkItems.POSTANSKIBROJEVIWorkItem POSTANSKIBROJEVIWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.POSTANSKIBROJEVIWorkItem) this.WorkItem;
            }
        }
    }
}

