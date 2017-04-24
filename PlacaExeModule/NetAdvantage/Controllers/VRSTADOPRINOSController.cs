namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class VRSTADOPRINOSController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetVRSTADOPRINOSDataAdapter().Update(this.DataSet);
        }

        public void NewDOPRINOS(DataRow row)
        {
            DOPRINOSWorkItem item = this.WorkItem.Items.AddNew<DOPRINOSWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewDOPRINOS(DataRow row)
        {
            DOPRINOSSelectionListWorkItem item = this.WorkItem.Items.AddNew<DOPRINOSSelectionListWorkItem>();
            item.ShowModal(false, "FillByIDVRSTADOPRINOS", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public VRSTADOPRINOSDataSet DataSet
        {
            get
            {
                return (VRSTADOPRINOSDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition VRSTADOPRINOSFormDefinition
        {
            get
            {
                return this.VRSTADOPRINOSWorkItem.VRSTADOPRINOS;
            }
        }

        public NetAdvantage.WorkItems.VRSTADOPRINOSWorkItem VRSTADOPRINOSWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.VRSTADOPRINOSWorkItem) this.WorkItem;
            }
        }
    }
}

