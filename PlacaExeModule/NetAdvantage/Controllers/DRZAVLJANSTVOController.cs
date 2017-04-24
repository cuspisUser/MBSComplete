namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class DRZAVLJANSTVOController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetDRZAVLJANSTVODataAdapter().Update(this.DataSet);
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
            item.ShowModal(false, "FillByIDDRZAVLJANSTVO", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public DRZAVLJANSTVODataSet DataSet
        {
            get
            {
                return (DRZAVLJANSTVODataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition DRZAVLJANSTVOFormDefinition
        {
            get
            {
                return this.DRZAVLJANSTVOWorkItem.DRZAVLJANSTVO;
            }
        }

        public NetAdvantage.WorkItems.DRZAVLJANSTVOWorkItem DRZAVLJANSTVOWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.DRZAVLJANSTVOWorkItem) this.WorkItem;
            }
        }
    }
}

