namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class ORGJEDController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetORGJEDDataAdapter().Update(this.DataSet);
        }

        public void NewGKSTAVKA(DataRow row)
        {
            GKSTAVKAWorkItem item = this.WorkItem.Items.AddNew<GKSTAVKAWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewSHEMADD(DataRow row)
        {
            SHEMADDWorkItem item = this.WorkItem.Items.AddNew<SHEMADDWorkItem>();
            if (row.Table.Columns.Contains("IDORGJED"))
            {
                row.Table.Columns["IDORGJED"].ExtendedProperties["AddColumnName"] = "SHEMADDOJIDORGJED";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewSHEMAPLACA(DataRow row)
        {
            SHEMAPLACAWorkItem item = this.WorkItem.Items.AddNew<SHEMAPLACAWorkItem>();
            if (row.Table.Columns.Contains("IDORGJED"))
            {
                row.Table.Columns["IDORGJED"].ExtendedProperties["AddColumnName"] = "SHEMAPLOJIDORGJED";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewGKSTAVKA(DataRow row)
        {
            GKSTAVKASelectionListWorkItem item = this.WorkItem.Items.AddNew<GKSTAVKASelectionListWorkItem>();
            item.ShowModal(false, "FillByIDORGJED", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewSHEMADD(DataRow row)
        {
            SHEMADDSelectionListWorkItem item = this.WorkItem.Items.AddNew<SHEMADDSelectionListWorkItem>();
            item.ShowModal(false, "FillBySHEMADDOJIDORGJED", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewSHEMAPLACA(DataRow row)
        {
            SHEMAPLACASelectionListWorkItem item = this.WorkItem.Items.AddNew<SHEMAPLACASelectionListWorkItem>();
            item.ShowModal(false, "FillBySHEMAPLOJIDORGJED", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public ORGJEDDataSet DataSet
        {
            get
            {
                return (ORGJEDDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition ORGJEDFormDefinition
        {
            get
            {
                return this.ORGJEDWorkItem.ORGJED;
            }
        }

        public NetAdvantage.WorkItems.ORGJEDWorkItem ORGJEDWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.ORGJEDWorkItem) this.WorkItem;
            }
        }
    }
}

