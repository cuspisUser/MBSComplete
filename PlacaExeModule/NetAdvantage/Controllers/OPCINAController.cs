namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class OPCINAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetOPCINADataAdapter().Update(this.DataSet);
        }

        public void NewDDRADNIK(DataRow row)
        {
            DDRADNIKWorkItem item = this.WorkItem.Items.AddNew<DDRADNIKWorkItem>();
            if (row.Table.Columns.Contains("IDOPCINE"))
            {
                row.Table.Columns["IDOPCINE"].ExtendedProperties["AddColumnName"] = "OPCINASTANOVANJAIDOPCINE";
            }
            if (row.Table.Columns.Contains("NAZIVOPCINE"))
            {
                row.Table.Columns["NAZIVOPCINE"].ExtendedProperties["AddColumnName"] = "OPCINASTANOVANJANAZIVOPCINE";
            }
            if (row.Table.Columns.Contains("PRIREZ"))
            {
                row.Table.Columns["PRIREZ"].ExtendedProperties["AddColumnName"] = "OPCINASTANOVANJAPRIREZ";
            }
            if (row.Table.Columns.Contains("VBDIOPCINA"))
            {
                row.Table.Columns["VBDIOPCINA"].ExtendedProperties["AddColumnName"] = "OPCINASTANOVANJAVBDIOPCINA";
            }
            if (row.Table.Columns.Contains("ZRNOPCINA"))
            {
                row.Table.Columns["ZRNOPCINA"].ExtendedProperties["AddColumnName"] = "OPCINASTANOVANJAZRNOPCINA";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewDDRADNIK1(DataRow row)
        {
            DDRADNIKWorkItem item = this.WorkItem.Items.AddNew<DDRADNIKWorkItem>();
            if (row.Table.Columns.Contains("IDOPCINE"))
            {
                row.Table.Columns["IDOPCINE"].ExtendedProperties["AddColumnName"] = "OPCINARADAIDOPCINE";
            }
            if (row.Table.Columns.Contains("NAZIVOPCINE"))
            {
                row.Table.Columns["NAZIVOPCINE"].ExtendedProperties["AddColumnName"] = "OPCINARADANAZIVOPCINE";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewRADNIK(DataRow row)
        {
            RADNIKWorkItem item = this.WorkItem.Items.AddNew<RADNIKWorkItem>();
            if (row.Table.Columns.Contains("IDOPCINE"))
            {
                row.Table.Columns["IDOPCINE"].ExtendedProperties["AddColumnName"] = "OPCINASTANOVANJAIDOPCINE";
            }
            if (row.Table.Columns.Contains("NAZIVOPCINE"))
            {
                row.Table.Columns["NAZIVOPCINE"].ExtendedProperties["AddColumnName"] = "OPCINASTANOVANJANAZIVOPCINE";
            }
            if (row.Table.Columns.Contains("PRIREZ"))
            {
                row.Table.Columns["PRIREZ"].ExtendedProperties["AddColumnName"] = "OPCINASTANOVANJAPRIREZ";
            }
            if (row.Table.Columns.Contains("VBDIOPCINA"))
            {
                row.Table.Columns["VBDIOPCINA"].ExtendedProperties["AddColumnName"] = "OPCINASTANOVANJAVBDIOPCINA";
            }
            if (row.Table.Columns.Contains("ZRNOPCINA"))
            {
                row.Table.Columns["ZRNOPCINA"].ExtendedProperties["AddColumnName"] = "OPCINASTANOVANJAZRNOPCINA";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewRADNIK1(DataRow row)
        {
            RADNIKWorkItem item = this.WorkItem.Items.AddNew<RADNIKWorkItem>();
            if (row.Table.Columns.Contains("IDOPCINE"))
            {
                row.Table.Columns["IDOPCINE"].ExtendedProperties["AddColumnName"] = "OPCINARADAIDOPCINE";
            }
            if (row.Table.Columns.Contains("NAZIVOPCINE"))
            {
                row.Table.Columns["NAZIVOPCINE"].ExtendedProperties["AddColumnName"] = "OPCINARADANAZIVOPCINE";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewDDRADNIK(DataRow row)
        {
            DDRADNIKSelectionListWorkItem item = this.WorkItem.Items.AddNew<DDRADNIKSelectionListWorkItem>();
            item.ShowModal(false, "FillByOPCINASTANOVANJAIDOPCINE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewDDRADNIK1(DataRow row)
        {
            DDRADNIKSelectionListWorkItem item = this.WorkItem.Items.AddNew<DDRADNIKSelectionListWorkItem>();
            item.ShowModal(false, "FillByOPCINARADAIDOPCINE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRADNIK(DataRow row)
        {
            RADNIKSelectionListWorkItem item = this.WorkItem.Items.AddNew<RADNIKSelectionListWorkItem>();
            item.ShowModal(false, "FillByOPCINASTANOVANJAIDOPCINE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRADNIK1(DataRow row)
        {
            RADNIKSelectionListWorkItem item = this.WorkItem.Items.AddNew<RADNIKSelectionListWorkItem>();
            item.ShowModal(false, "FillByOPCINARADAIDOPCINE", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public OPCINADataSet DataSet
        {
            get
            {
                return (OPCINADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition OPCINAFormDefinition
        {
            get
            {
                return this.OPCINAWorkItem.OPCINA;
            }
        }

        public NetAdvantage.WorkItems.OPCINAWorkItem OPCINAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.OPCINAWorkItem) this.WorkItem;
            }
        }
    }
}

