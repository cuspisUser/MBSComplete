namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class AMSKUPINEController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetAMSKUPINEDataAdapter().Update(this.DataSet);
        }

        public void NewOS(DataRow row)
        {
            OSWorkItem item = this.WorkItem.Items.AddNew<OSWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewOS(DataRow row)
        {
            OSSelectionListWorkItem item = this.WorkItem.Items.AddNew<OSSelectionListWorkItem>();
            item.ShowModal(false, "FillByIDAMSKUPINE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public FormDefinition AMSKUPINEFormDefinition
        {
            get
            {
                return this.AMSKUPINEWorkItem.AMSKUPINE;
            }
        }

        public NetAdvantage.WorkItems.AMSKUPINEWorkItem AMSKUPINEWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.AMSKUPINEWorkItem) this.WorkItem;
            }
        }

        public AMSKUPINEDataSet DataSet
        {
            get
            {
                return (AMSKUPINEDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }
    }
}

