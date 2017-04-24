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

    public class SKUPPOREZAIDOPRINOSAController : FormControllerBase
    {
        public DialogResult AddSKUPPOREZAIDOPRINOSA1(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SKUPPOREZAIDOPRINOSAWorkItem) this.WorkItem).SKUPPOREZAIDOPRINOSA1.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddSKUPPOREZAIDOPRINOSA2(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SKUPPOREZAIDOPRINOSAWorkItem) this.WorkItem).SKUPPOREZAIDOPRINOSA2.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult DeleteSKUPPOREZAIDOPRINOSA1(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SKUPPOREZAIDOPRINOSAWorkItem) this.WorkItem).SKUPPOREZAIDOPRINOSA1.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteSKUPPOREZAIDOPRINOSA2(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SKUPPOREZAIDOPRINOSAWorkItem) this.WorkItem).SKUPPOREZAIDOPRINOSA2.Show(DeklaritMode.Delete, currentRow, false);
        }

        public override void DoUpdate()
        {
            DataAdapterFactory.GetSKUPPOREZAIDOPRINOSADataAdapter().Update(this.DataSet);
        }

        public void NewRADNIK(DataRow row)
        {
            RADNIKWorkItem item = this.WorkItem.Items.AddNew<RADNIKWorkItem>();
            if (row.Table.Columns.Contains("IDSKUPPOREZAIDOPRINOSA"))
            {
                row.Table.Columns["IDSKUPPOREZAIDOPRINOSA"].ExtendedProperties["AddColumnName"] = "RADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA";
            }
            if (row.Table.Columns.Contains("NAZIVSKUPPOREZAIDOPRINOSA"))
            {
                row.Table.Columns["NAZIVSKUPPOREZAIDOPRINOSA"].ExtendedProperties["AddColumnName"] = "RADNIKPOREZIDOPRINOSNAZIVSKUPPOREZAIDOPRINOSA";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public DataRow SelectDOPRINOSIDDOPRINOS(string fillMethod, DataRow fillByRow)
        {
            DOPRINOSSelectionListWorkItem item = this.WorkItem.Items.AddNew<DOPRINOSSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectPOREZIDPOREZ(string fillMethod, DataRow fillByRow)
        {
            POREZSelectionListWorkItem item = this.WorkItem.Items.AddNew<POREZSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowDOPRINOSIDDOPRINOS(DataRow fillByRow)
        {
            DOPRINOSWorkItem item = this.WorkItem.Items.AddNew<DOPRINOSWorkItem>();
            DataAdapterFactory.GetDOPRINOSDataAdapter().Fill((DOPRINOSDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDDOPRINOS"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowPOREZIDPOREZ(DataRow fillByRow)
        {
            POREZWorkItem item = this.WorkItem.Items.AddNew<POREZWorkItem>();
            DataAdapterFactory.GetPOREZDataAdapter().Fill((POREZDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDPOREZ"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DialogResult UpdateSKUPPOREZAIDOPRINOSA1(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SKUPPOREZAIDOPRINOSAWorkItem) this.WorkItem).SKUPPOREZAIDOPRINOSA1.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateSKUPPOREZAIDOPRINOSA2(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SKUPPOREZAIDOPRINOSAWorkItem) this.WorkItem).SKUPPOREZAIDOPRINOSA2.Show(DeklaritMode.Update, currentRow, false);
        }

        public void ViewRADNIK(DataRow row)
        {
            RADNIKSelectionListWorkItem item = this.WorkItem.Items.AddNew<RADNIKSelectionListWorkItem>();
            item.ShowModal(false, "FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public SKUPPOREZAIDOPRINOSADataSet DataSet
        {
            get
            {
                return (SKUPPOREZAIDOPRINOSADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition SKUPPOREZAIDOPRINOSA1FormDefinition
        {
            get
            {
                return this.SKUPPOREZAIDOPRINOSAWorkItem.SKUPPOREZAIDOPRINOSA1;
            }
        }

        public FormDefinition SKUPPOREZAIDOPRINOSA2FormDefinition
        {
            get
            {
                return this.SKUPPOREZAIDOPRINOSAWorkItem.SKUPPOREZAIDOPRINOSA2;
            }
        }

        public FormDefinition SKUPPOREZAIDOPRINOSAFormDefinition
        {
            get
            {
                return this.SKUPPOREZAIDOPRINOSAWorkItem.SKUPPOREZAIDOPRINOSA;
            }
        }

        public NetAdvantage.WorkItems.SKUPPOREZAIDOPRINOSAWorkItem SKUPPOREZAIDOPRINOSAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.SKUPPOREZAIDOPRINOSAWorkItem) this.WorkItem;
            }
        }
    }
}

