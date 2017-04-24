namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class GODINEController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetGODINEDataAdapter().Update(this.DataSet);
        }

        public void NewEVIDENCIJA(DataRow row)
        {
            EVIDENCIJAWorkItem item = this.WorkItem.Items.AddNew<EVIDENCIJAWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewGKSTAVKA(DataRow row)
        {
            GKSTAVKAWorkItem item = this.WorkItem.Items.AddNew<GKSTAVKAWorkItem>();
            if (row.Table.Columns.Contains("IDGODINE"))
            {
                row.Table.Columns["IDGODINE"].ExtendedProperties["AddColumnName"] = "GKGODIDGODINE";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewIRA(DataRow row)
        {
            IraWorkItem item = this.WorkItem.Items.AddNew<IraWorkItem>();
            if (row.Table.Columns.Contains("IDGODINE"))
            {
                row.Table.Columns["IDGODINE"].ExtendedProperties["AddColumnName"] = "IRAGODIDGODINE";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewPLAN(DataRow row)
        {
            PLANWorkItem item = this.WorkItem.Items.AddNew<PLANWorkItem>();
            if (row.Table.Columns.Contains("IDGODINE"))
            {
                row.Table.Columns["IDGODINE"].ExtendedProperties["AddColumnName"] = "PLANGODINAIDGODINE";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewRACUN(DataRow row)
        {
            RACUNWorkItem item = this.WorkItem.Items.AddNew<RACUNWorkItem>();
            if (row.Table.Columns.Contains("IDGODINE"))
            {
                row.Table.Columns["IDGODINE"].ExtendedProperties["AddColumnName"] = "RACUNGODINAIDGODINE";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewURA(DataRow row)
        {
            URAWorkItem item = this.WorkItem.Items.AddNew<URAWorkItem>();
            if (row.Table.Columns.Contains("IDGODINE"))
            {
                row.Table.Columns["IDGODINE"].ExtendedProperties["AddColumnName"] = "URAGODIDGODINE";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewEVIDENCIJA(DataRow row)
        {
            EVIDENCIJASelectionListWorkItem item = this.WorkItem.Items.AddNew<EVIDENCIJASelectionListWorkItem>();
            item.ShowModal(false, "FillByIDGODINE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewGKSTAVKA(DataRow row)
        {
            GKSTAVKASelectionListWorkItem item = this.WorkItem.Items.AddNew<GKSTAVKASelectionListWorkItem>();
            item.ShowModal(false, "FillByGKGODIDGODINE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewIRA(DataRow row)
        {
            IRASelectionListWorkItem item = this.WorkItem.Items.AddNew<IRASelectionListWorkItem>();
            item.ShowModal(false, "FillByIRAGODIDGODINE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewPLAN(DataRow row)
        {
            PLANSelectionListWorkItem item = this.WorkItem.Items.AddNew<PLANSelectionListWorkItem>();
            item.ShowModal(false, "FillByPLANGODINAIDGODINE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRACUN(DataRow row)
        {
            RACUNSelectionListWorkItem item = this.WorkItem.Items.AddNew<RACUNSelectionListWorkItem>();
            item.ShowModal(false, "FillByRACUNGODINAIDGODINE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewURA(DataRow row)
        {
            URASelectionListWorkItem item = this.WorkItem.Items.AddNew<URASelectionListWorkItem>();
            item.ShowModal(false, "FillByURAGODIDGODINE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public GODINEDataSet DataSet
        {
            get
            {
                return (GODINEDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition GODINEFormDefinition
        {
            get
            {
                return this.GODINEWorkItem.GODINE;
            }
        }

        public NetAdvantage.WorkItems.GODINEWorkItem GODINEWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.GODINEWorkItem) this.WorkItem;
            }
        }
    }
}

