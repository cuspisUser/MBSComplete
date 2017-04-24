namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class VRSTAOBUSTAVEController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetVRSTAOBUSTAVEDataAdapter().Update(this.DataSet);
        }

        public void NewOBUSTAVA(DataRow row)
        {
            OBUSTAVAWorkItem item = this.WorkItem.Items.AddNew<OBUSTAVAWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewOBUSTAVA(DataRow row)
        {
            OBUSTAVASelectionListWorkItem item = this.WorkItem.Items.AddNew<OBUSTAVASelectionListWorkItem>();
            item.ShowModal(false, "FillByVRSTAOBUSTAVE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public VRSTAOBUSTAVEDataSet DataSet
        {
            get
            {
                return (VRSTAOBUSTAVEDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public NetAdvantage.WorkItems.VRSTAOBUSTAVEWorkItem VRSTAOBUSTAVEWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.VRSTAOBUSTAVEWorkItem) this.WorkItem;
            }
        }

        public FormDefinition VRSTEOBUSTAVAFormDefinition
        {
            get
            {
                return this.VRSTAOBUSTAVEWorkItem.VRSTEOBUSTAVA;
            }
        }
    }
}

