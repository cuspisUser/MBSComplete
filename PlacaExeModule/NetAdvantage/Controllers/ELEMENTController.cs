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

    public class ELEMENTController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetELEMENTDataAdapter().Update(this.DataSet);
        }

        public void NewBOLOVANJEFOND(DataRow row)
        {
            BOLOVANJEFONDWorkItem item = this.WorkItem.Items.AddNew<BOLOVANJEFONDWorkItem>();
            if (row.Table.Columns.Contains("IDELEMENT"))
            {
                row.Table.Columns["IDELEMENT"].ExtendedProperties["AddColumnName"] = "ELEMENTBOLOVANJEIDELEMENT";
            }
            if (row.Table.Columns.Contains("NAZIVELEMENT"))
            {
                row.Table.Columns["NAZIVELEMENT"].ExtendedProperties["AddColumnName"] = "ELEMENTBOLOVANJENAZIVELEMENT";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewRAD1GELEMENTIVEZA(DataRow row)
        {
            RAD1GELEMENTIVEZAWorkItem item = this.WorkItem.Items.AddNew<RAD1GELEMENTIVEZAWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewRAD1MELEMENTIVEZA(DataRow row)
        {
            RAD1MELEMENTIVEZAWorkItem item = this.WorkItem.Items.AddNew<RAD1MELEMENTIVEZAWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public DataRow SelectOSNOVAOSIGURANJAIDOSNOVAOSIGURANJA(string fillMethod, DataRow fillByRow)
        {
            OSNOVAOSIGURANJASelectionListWorkItem item = this.WorkItem.Items.AddNew<OSNOVAOSIGURANJASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectVRSTAELEMENTIDVRSTAELEMENTA(string fillMethod, DataRow fillByRow)
        {
            VRSTAELEMENTSelectionListWorkItem item = this.WorkItem.Items.AddNew<VRSTAELEMENTSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowOSNOVAOSIGURANJAIDOSNOVAOSIGURANJA(DataRow fillByRow)
        {
            OSNOVAOSIGURANJAWorkItem item = this.WorkItem.Items.AddNew<OSNOVAOSIGURANJAWorkItem>();
            DataAdapterFactory.GetOSNOVAOSIGURANJADataAdapter().Fill((OSNOVAOSIGURANJADataSet) item.DataSet, Conversions.ToString(fillByRow["IDOSNOVAOSIGURANJA"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowVRSTAELEMENTIDVRSTAELEMENTA(DataRow fillByRow)
        {
            VRSTAELEMENTWorkItem item = this.WorkItem.Items.AddNew<VRSTAELEMENTWorkItem>();
            DataAdapterFactory.GetVRSTAELEMENTDataAdapter().Fill((VRSTAELEMENTDataSet) item.DataSet, Conversions.ToShort(fillByRow["IDVRSTAELEMENTA"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public void ViewBOLOVANJEFOND(DataRow row)
        {
            BOLOVANJEFONDSelectionListWorkItem item = this.WorkItem.Items.AddNew<BOLOVANJEFONDSelectionListWorkItem>();
            item.ShowModal(false, "FillByELEMENTBOLOVANJEIDELEMENT", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRAD1GELEMENTIVEZA(DataRow row)
        {
            RAD1GELEMENTIVEZASelectionListWorkItem item = this.WorkItem.Items.AddNew<RAD1GELEMENTIVEZASelectionListWorkItem>();
            item.ShowModal(false, "FillByIDELEMENT", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRAD1MELEMENTIVEZA(DataRow row)
        {
            RAD1MELEMENTIVEZASelectionListWorkItem item = this.WorkItem.Items.AddNew<RAD1MELEMENTIVEZASelectionListWorkItem>();
            item.ShowModal(false, "FillByIDELEMENT", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public ELEMENTDataSet DataSet
        {
            get
            {
                return (ELEMENTDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition ELEMENTFormDefinition
        {
            get
            {
                return this.ELEMENTWorkItem.ELEMENT;
            }
        }

        public NetAdvantage.WorkItems.ELEMENTWorkItem ELEMENTWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.ELEMENTWorkItem) this.WorkItem;
            }
        }
    }
}

