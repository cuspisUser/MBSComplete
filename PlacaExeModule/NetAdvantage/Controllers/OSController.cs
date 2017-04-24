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

    public class OSController : FormControllerBase
    {
        public DialogResult AddOSTEMELJNICA(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OSWorkItem) this.WorkItem).OSTEMELJNICA.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult DeleteOSTEMELJNICA(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OSWorkItem) this.WorkItem).OSTEMELJNICA.Show(DeklaritMode.Delete, currentRow, false);
        }

        public override void DoUpdate()
        {
            DataAdapterFactory.GetOSDataAdapter().Update(this.DataSet);
        }

        public void NewOSRAZMJESTAJ(DataRow row)
        {
            OSRAZMJESTAJWorkItem item = this.WorkItem.Items.AddNew<OSRAZMJESTAJWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public DialogResult UpdateOSTEMELJNICA(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OSWorkItem) this.WorkItem).OSTEMELJNICA.Show(DeklaritMode.Update, currentRow, false);
        }

        public void ViewOSRAZMJESTAJ(DataRow row)
        {
            OSRAZMJESTAJSelectionListWorkItem item = this.WorkItem.Items.AddNew<OSRAZMJESTAJSelectionListWorkItem>();
            item.ShowModal(false, "FillByINVBROJ", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public OSDataSet DataSet
        {
            get
            {
                return (OSDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition OSFormDefinition
        {
            get
            {
                return this.OSWorkItem.OS;
            }
        }

        public FormDefinition OSTEMELJNICAFormDefinition
        {
            get
            {
                return this.OSWorkItem.OSTEMELJNICA;
            }
        }

        public NetAdvantage.WorkItems.OSWorkItem OSWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.OSWorkItem) this.WorkItem;
            }
        }
    }
}

