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

    public class SHEMAURAController : FormControllerBase
    {
        public DialogResult AddSHEMAURASHEMAURAKONTIRANJE(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMAURAWorkItem) this.WorkItem).SHEMAURASHEMAURAKONTIRANJE.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult DeleteSHEMAURASHEMAURAKONTIRANJE(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMAURAWorkItem) this.WorkItem).SHEMAURASHEMAURAKONTIRANJE.Show(DeklaritMode.Delete, currentRow, false);
        }

        public override void DoUpdate()
        {
            DataAdapterFactory.GetSHEMAURADataAdapter().Update(this.DataSet);
        }

        public DialogResult UpdateSHEMAURASHEMAURAKONTIRANJE(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMAURAWorkItem) this.WorkItem).SHEMAURASHEMAURAKONTIRANJE.Show(DeklaritMode.Update, currentRow, false);
        }

        public SHEMAURADataSet DataSet
        {
            get
            {
                return (SHEMAURADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition SHEMAURAFormDefinition
        {
            get
            {
                return this.SHEMAURAWorkItem.SHEMAURA;
            }
        }

        public FormDefinition SHEMAURASHEMAURAKONTIRANJEFormDefinition
        {
            get
            {
                return this.SHEMAURAWorkItem.SHEMAURASHEMAURAKONTIRANJE;
            }
        }

        public NetAdvantage.WorkItems.SHEMAURAWorkItem SHEMAURAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.SHEMAURAWorkItem) this.WorkItem;
            }
        }
    }
}

