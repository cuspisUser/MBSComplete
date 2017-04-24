namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class TIPDOKUMENTAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetTIPDOKUMENTADataAdapter().Update(this.DataSet);
        }

        public void NewDOKUMENT(DataRow row)
        {
            DOKUMENTWorkItem item = this.WorkItem.Items.AddNew<DOKUMENTWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewDOKUMENT(DataRow row)
        {
            DOKUMENTSelectionListWorkItem item = this.WorkItem.Items.AddNew<DOKUMENTSelectionListWorkItem>();
            item.ShowModal(false, "FillByIDTIPDOKUMENTA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public TIPDOKUMENTADataSet DataSet
        {
            get
            {
                return (TIPDOKUMENTADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition TIPDOKUMENTAFormDefinition
        {
            get
            {
                return this.TIPDOKUMENTAWorkItem.TIPDOKUMENTA;
            }
        }

        public NetAdvantage.WorkItems.TIPDOKUMENTAWorkItem TIPDOKUMENTAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.TIPDOKUMENTAWorkItem) this.WorkItem;
            }
        }
    }
}

