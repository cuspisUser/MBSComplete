namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public class DOKUMENTController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetDOKUMENTDataAdapter().Update(this.DataSet);
        }

        public void NewBLAGAJNA(DataRow row)
        {
            BLAGAJNAWorkItem item = this.WorkItem.Items.AddNew<BLAGAJNAWorkItem>();
            if (row.Table.Columns.Contains("IDDOKUMENT"))
            {
                row.Table.Columns["IDDOKUMENT"].ExtendedProperties["AddColumnName"] = "BLGDOKIDDOKUMENT";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
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
            if (row.Table.Columns.Contains("IDDOKUMENT"))
            {
                row.Table.Columns["IDDOKUMENT"].ExtendedProperties["AddColumnName"] = "IRADOKIDDOKUMENT";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewSHEMAIRA(DataRow row)
        {
            SHEMAIRAWorkItem item = this.WorkItem.Items.AddNew<SHEMAIRAWorkItem>();
            if (row.Table.Columns.Contains("IDDOKUMENT"))
            {
                row.Table.Columns["IDDOKUMENT"].ExtendedProperties["AddColumnName"] = "SHEMAIRADOKIDDOKUMENT";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewURA(DataRow row)
        {
            URAWorkItem item = this.WorkItem.Items.AddNew<URAWorkItem>();
            if (row.Table.Columns.Contains("IDDOKUMENT"))
            {
                row.Table.Columns["IDDOKUMENT"].ExtendedProperties["AddColumnName"] = "URADOKIDDOKUMENT";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public DataRow SelectTIPDOKUMENTAIDTIPDOKUMENTA(string fillMethod, DataRow fillByRow)
        {
            TIPDOKUMENTASelectionListWorkItem item = this.WorkItem.Items.AddNew<TIPDOKUMENTASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowTIPDOKUMENTAIDTIPDOKUMENTA(DataRow fillByRow)
        {
            TIPDOKUMENTAWorkItem item = this.WorkItem.Items.AddNew<TIPDOKUMENTAWorkItem>();
            DataAdapterFactory.GetTIPDOKUMENTADataAdapter().Fill((TIPDOKUMENTADataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDTIPDOKUMENTA"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public void ViewBLAGAJNA(DataRow row)
        {
            BLAGAJNASelectionListWorkItem item = this.WorkItem.Items.AddNew<BLAGAJNASelectionListWorkItem>();
            item.ShowModal(false, "FillByBLGDOKIDDOKUMENT", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewGKSTAVKA(DataRow row)
        {
            GKSTAVKASelectionListWorkItem item = this.WorkItem.Items.AddNew<GKSTAVKASelectionListWorkItem>();
            item.ShowModal(false, "FillByIDDOKUMENT", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewIRA(DataRow row)
        {
            IRASelectionListWorkItem item = this.WorkItem.Items.AddNew<IRASelectionListWorkItem>();
            item.ShowModal(false, "FillByIRADOKIDDOKUMENT", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewSHEMAIRA(DataRow row)
        {
            SHEMAIRASelectionListWorkItem item = this.WorkItem.Items.AddNew<SHEMAIRASelectionListWorkItem>();
            item.ShowModal(false, "FillBySHEMAIRADOKIDDOKUMENT", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewURA(DataRow row)
        {
            URASelectionListWorkItem item = this.WorkItem.Items.AddNew<URASelectionListWorkItem>();
            item.ShowModal(false, "FillByURADOKIDDOKUMENT", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public DOKUMENTDataSet DataSet
        {
            get
            {
                return (DOKUMENTDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition DOKUMENTFormDefinition
        {
            get
            {
                return this.DOKUMENTWorkItem.DOKUMENT;
            }
        }

        public NetAdvantage.WorkItems.DOKUMENTWorkItem DOKUMENTWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.DOKUMENTWorkItem) this.WorkItem;
            }
        }
    }
}

