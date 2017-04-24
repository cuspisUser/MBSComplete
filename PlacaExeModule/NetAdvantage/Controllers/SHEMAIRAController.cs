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

    public class SHEMAIRAController : FormControllerBase
    {
        public DialogResult AddSHEMAIRASHEMAIRAKONTIRANJE(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMAIRAWorkItem) this.WorkItem).SHEMAIRASHEMAIRAKONTIRANJE.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult DeleteSHEMAIRASHEMAIRAKONTIRANJE(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMAIRAWorkItem) this.WorkItem).SHEMAIRASHEMAIRAKONTIRANJE.Show(DeklaritMode.Delete, currentRow, false);
        }

        public override void DoUpdate()
        {
            DataAdapterFactory.GetSHEMAIRADataAdapter().Update(this.DataSet);
        }

        public DialogResult UpdateSHEMAIRASHEMAIRAKONTIRANJE(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMAIRAWorkItem) this.WorkItem).SHEMAIRASHEMAIRAKONTIRANJE.Show(DeklaritMode.Update, currentRow, false);
        }

        public SHEMAIRADataSet DataSet
        {
            get
            {
                return (SHEMAIRADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition SHEMAIRAFormDefinition
        {
            get
            {
                return this.SHEMAIRAWorkItem.SHEMAIRA;
            }
        }

        public FormDefinition SHEMAIRASHEMAIRAKONTIRANJEFormDefinition
        {
            get
            {
                return this.SHEMAIRAWorkItem.SHEMAIRASHEMAIRAKONTIRANJE;
            }
        }

        public NetAdvantage.WorkItems.SHEMAIRAWorkItem SHEMAIRAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.SHEMAIRAWorkItem) this.WorkItem;
            }
        }
    }
}

