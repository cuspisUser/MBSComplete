namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class JEDINICAMJEREController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetJEDINICAMJEREDataAdapter().Update(this.DataSet);
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
            item.ShowModal(false, "FillByIDJEDINICAMJERE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public JEDINICAMJEREDataSet DataSet
        {
            get
            {
                return (JEDINICAMJEREDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition JEDINICAMJEREFormDefinition
        {
            get
            {
                return this.JEDINICAMJEREWorkItem.JEDINICAMJERE;
            }
        }

        public NetAdvantage.WorkItems.JEDINICAMJEREWorkItem JEDINICAMJEREWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.JEDINICAMJEREWorkItem) this.WorkItem;
            }
        }
    }
}

