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

    public class KORISNIKController : FormControllerBase
    {
        public DialogResult AddKORISNIKLevel1(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.KORISNIKWorkItem) this.WorkItem).KORISNIKLevel1.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult DeleteKORISNIKLevel1(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.KORISNIKWorkItem) this.WorkItem).KORISNIKLevel1.Show(DeklaritMode.Delete, currentRow, false);
        }

        public override void DoUpdate()
        {
            DataAdapterFactory.GetKORISNIKDataAdapter().Update(this.DataSet);
        }

        public DialogResult UpdateKORISNIKLevel1(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.KORISNIKWorkItem) this.WorkItem).KORISNIKLevel1.Show(DeklaritMode.Update, currentRow, false);
        }

        public KORISNIKDataSet DataSet
        {
            get
            {
                return (KORISNIKDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition KORISNIKFormDefinition
        {
            get
            {
                return this.KORISNIKWorkItem.KORISNIK;
            }
        }

        public FormDefinition KORISNIKLevel1FormDefinition
        {
            get
            {
                return this.KORISNIKWorkItem.KORISNIKLevel1;
            }
        }

        public NetAdvantage.WorkItems.KORISNIKWorkItem KORISNIKWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.KORISNIKWorkItem) this.WorkItem;
            }
        }
    }
}

