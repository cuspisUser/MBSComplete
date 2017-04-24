namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class VRSTAELEMENTController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetVRSTAELEMENTDataAdapter().Update(this.DataSet);
        }

        public void NewELEMENT(DataRow row)
        {
            ELEMENTWorkItem item = this.WorkItem.Items.AddNew<ELEMENTWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewELEMENT(DataRow row)
        {
            ELEMENTSelectionListWorkItem item = this.WorkItem.Items.AddNew<ELEMENTSelectionListWorkItem>();
            item.ShowModal(false, "FillByIDVRSTAELEMENTA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public VRSTAELEMENTDataSet DataSet
        {
            get
            {
                return (VRSTAELEMENTDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition VRSTAELEMENTFormDefinition
        {
            get
            {
                return this.VRSTAELEMENTWorkItem.VRSTAELEMENT;
            }
        }

        public NetAdvantage.WorkItems.VRSTAELEMENTWorkItem VRSTAELEMENTWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.VRSTAELEMENTWorkItem) this.WorkItem;
            }
        }
    }
}

