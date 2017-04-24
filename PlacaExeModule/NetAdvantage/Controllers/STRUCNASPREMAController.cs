namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class STRUCNASPREMAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetSTRUCNASPREMADataAdapter().Update(this.DataSet);
        }

        public void NewRAD1SPREMEVEZA(DataRow row)
        {
            RAD1SPREMEVEZAWorkItem item = this.WorkItem.Items.AddNew<RAD1SPREMEVEZAWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewRADNIK(DataRow row)
        {
            RADNIKWorkItem item = this.WorkItem.Items.AddNew<RADNIKWorkItem>();
            if (row.Table.Columns.Contains("IDSTRUCNASPREMA"))
            {
                row.Table.Columns["IDSTRUCNASPREMA"].ExtendedProperties["AddColumnName"] = "TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA";
            }
            if (row.Table.Columns.Contains("NAZIVSTRUCNASPREMA"))
            {
                row.Table.Columns["NAZIVSTRUCNASPREMA"].ExtendedProperties["AddColumnName"] = "TRENUTNASTRUCNASPREMANAZIVSTRUCNASPREMA";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewRADNIK1(DataRow row)
        {
            RADNIKWorkItem item = this.WorkItem.Items.AddNew<RADNIKWorkItem>();
            if (row.Table.Columns.Contains("IDSTRUCNASPREMA"))
            {
                row.Table.Columns["IDSTRUCNASPREMA"].ExtendedProperties["AddColumnName"] = "POTREBNASTRUCNASPREMAIDSTRUCNASPREMA";
            }
            if (row.Table.Columns.Contains("NAZIVSTRUCNASPREMA"))
            {
                row.Table.Columns["NAZIVSTRUCNASPREMA"].ExtendedProperties["AddColumnName"] = "POTREBNASTRUCNASPREMANAZIVSTRUCNASPREMA";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRAD1SPREMEVEZA(DataRow row)
        {
            RAD1SPREMEVEZASelectionListWorkItem item = this.WorkItem.Items.AddNew<RAD1SPREMEVEZASelectionListWorkItem>();
            item.ShowModal(false, "FillByIDSTRUCNASPREMA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRADNIK(DataRow row)
        {
            RADNIKSelectionListWorkItem item = this.WorkItem.Items.AddNew<RADNIKSelectionListWorkItem>();
            item.ShowModal(false, "FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewRADNIK1(DataRow row)
        {
            RADNIKSelectionListWorkItem item = this.WorkItem.Items.AddNew<RADNIKSelectionListWorkItem>();
            item.ShowModal(false, "FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public STRUCNASPREMADataSet DataSet
        {
            get
            {
                return (STRUCNASPREMADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition STRUCNASPREMAFormDefinition
        {
            get
            {
                return this.STRUCNASPREMAWorkItem.STRUCNASPREMA;
            }
        }

        public NetAdvantage.WorkItems.STRUCNASPREMAWorkItem STRUCNASPREMAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.STRUCNASPREMAWorkItem) this.WorkItem;
            }
        }
    }
}

