namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class KONTOController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetKONTODataAdapter().Update(this.DataSet);
        }

        public void NewAMSKUPINE(DataRow row)
        {
            AMSKUPINEWorkItem item = this.WorkItem.Items.AddNew<AMSKUPINEWorkItem>();
            if (row.Table.Columns.Contains("IDKONTO"))
            {
                row.Table.Columns["IDKONTO"].ExtendedProperties["AddColumnName"] = "KTOIZVORAIDKONTO";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewAMSKUPINE1(DataRow row)
        {
            AMSKUPINEWorkItem item = this.WorkItem.Items.AddNew<AMSKUPINEWorkItem>();
            if (row.Table.Columns.Contains("IDKONTO"))
            {
                row.Table.Columns["IDKONTO"].ExtendedProperties["AddColumnName"] = "KTOISPRAVKAIDKONTO";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewAMSKUPINE2(DataRow row)
        {
            AMSKUPINEWorkItem item = this.WorkItem.Items.AddNew<AMSKUPINEWorkItem>();
            if (row.Table.Columns.Contains("IDKONTO"))
            {
                row.Table.Columns["IDKONTO"].ExtendedProperties["AddColumnName"] = "KTONABAVKEIDKONTO";
            }
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewBLAGAJNA(DataRow row)
        {
            BLAGAJNAWorkItem item = this.WorkItem.Items.AddNew<BLAGAJNAWorkItem>();
            if (row.Table.Columns.Contains("IDKONTO"))
            {
                row.Table.Columns["IDKONTO"].ExtendedProperties["AddColumnName"] = "BLGKONTOIDKONTO";
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

        public void ViewAMSKUPINE(DataRow row)
        {
            AMSKUPINESelectionListWorkItem item = this.WorkItem.Items.AddNew<AMSKUPINESelectionListWorkItem>();
            item.ShowModal(false, "FillByKTOIZVORAIDKONTO", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewAMSKUPINE1(DataRow row)
        {
            AMSKUPINESelectionListWorkItem item = this.WorkItem.Items.AddNew<AMSKUPINESelectionListWorkItem>();
            item.ShowModal(false, "FillByKTOISPRAVKAIDKONTO", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewAMSKUPINE2(DataRow row)
        {
            AMSKUPINESelectionListWorkItem item = this.WorkItem.Items.AddNew<AMSKUPINESelectionListWorkItem>();
            item.ShowModal(false, "FillByKTONABAVKEIDKONTO", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewBLAGAJNA(DataRow row)
        {
            BLAGAJNASelectionListWorkItem item = this.WorkItem.Items.AddNew<BLAGAJNASelectionListWorkItem>();
            item.ShowModal(false, "FillByBLGKONTOIDKONTO", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewGKSTAVKA(DataRow row)
        {
            GKSTAVKASelectionListWorkItem item = this.WorkItem.Items.AddNew<GKSTAVKASelectionListWorkItem>();
            item.ShowModal(false, "FillByIDKONTO", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public KONTODataSet DataSet
        {
            get
            {
                return (KONTODataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition KONTOFormDefinition
        {
            get
            {
                return this.KONTOWorkItem.KONTO;
            }
        }

        public NetAdvantage.WorkItems.KONTOWorkItem KONTOWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.KONTOWorkItem) this.WorkItem;
            }
        }
    }
}

