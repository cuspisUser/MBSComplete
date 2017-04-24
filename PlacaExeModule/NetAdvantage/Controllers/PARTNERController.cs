namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public class PARTNERController : FormControllerBase
    {
        public DialogResult AddPARTNERZADUZENJE(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.PARTNERWorkItem) this.WorkItem).PARTNERZADUZENJE.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult DeletePARTNERZADUZENJE(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.PARTNERWorkItem) this.WorkItem).PARTNERZADUZENJE.Show(DeklaritMode.Delete, currentRow, false);
        }

        public override void DoUpdate()
        {
            DataAdapterFactory.GetPARTNERDataAdapter().Update(this.DataSet);
        }

        public void NewGKSTAVKA(DataRow row)
        {
            GKSTAVKAWorkItem item = this.WorkItem.Items.AddNew<GKSTAVKAWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewIRA(DataRow row)
        {
            IraWorkItem item = this.WorkItem.Items.AddNew<IraWorkItem>();
            if (row.Table.Columns.Contains("IDPARTNER"))
            {
                row.Table.Columns["IDPARTNER"].ExtendedProperties["AddColumnName"] = "IRAPARTNERIDPARTNER";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewRACUN(DataRow row)
        {
            RACUNWorkItem item = this.WorkItem.Items.AddNew<RACUNWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewSHEMAURA(DataRow row)
        {
            SHEMAURAWorkItem item = this.WorkItem.Items.AddNew<SHEMAURAWorkItem>();
            if (row.Table.Columns.Contains("IDPARTNER"))
            {
                row.Table.Columns["IDPARTNER"].ExtendedProperties["AddColumnName"] = "PARTNERSHEMAURAIDPARTNER";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewURA(DataRow row)
        {
            URAWorkItem item = this.WorkItem.Items.AddNew<URAWorkItem>();
            if (row.Table.Columns.Contains("IDPARTNER"))
            {
                row.Table.Columns["IDPARTNER"].ExtendedProperties["AddColumnName"] = "urapartnerIDPARTNER";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public DialogResult UpdatePARTNERZADUZENJE(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.PARTNERWorkItem) this.WorkItem).PARTNERZADUZENJE.Show(DeklaritMode.Update, currentRow, false);
        }

        public void ViewGKSTAVKA(DataRow row)
        {
            GKSTAVKASelectionListWorkItem item = this.WorkItem.Items.AddNew<GKSTAVKASelectionListWorkItem>();
            item.ShowModal(false, "FillByIDPARTNER", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewIRA(DataRow row)
        {
            IRASelectionListWorkItem item = this.WorkItem.Items.AddNew<IRASelectionListWorkItem>();
            item.ShowModal(false, "FillByIRAPARTNERIDPARTNER", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRACUN(DataRow row)
        {
            RACUNSelectionListWorkItem item = this.WorkItem.Items.AddNew<RACUNSelectionListWorkItem>();
            item.ShowModal(false, "FillByIDPARTNER", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewSHEMAURA(DataRow row)
        {
            SHEMAURASelectionListWorkItem item = this.WorkItem.Items.AddNew<SHEMAURASelectionListWorkItem>();
            item.ShowModal(false, "FillByPARTNERSHEMAURAIDPARTNER", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewURA(DataRow row)
        {
            URASelectionListWorkItem item = this.WorkItem.Items.AddNew<URASelectionListWorkItem>();
            item.ShowModal(false, "FillByurapartnerIDPARTNER", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public PARTNERDataSet DataSet
        {
            get
            {
                return (PARTNERDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition PARTNERFormDefinition
        {
            get
            {
                return this.PARTNERWorkItem.PARTNER;
            }
        }

        public NetAdvantage.WorkItems.PARTNERWorkItem PARTNERWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.PARTNERWorkItem) this.WorkItem;
            }
        }

        public FormDefinition PARTNERZADUZENJEFormDefinition
        {
            get
            {
                return this.PARTNERWorkItem.PARTNERZADUZENJE;
            }
        }
    }
}

