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

    public class RACUNController : FormControllerBase
    {
        public DialogResult AddRACUNRacunStavke(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RACUNWorkItem) this.WorkItem).RACUNRacunStavke.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult DeleteRACUNRacunStavke(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RACUNWorkItem) this.WorkItem).RACUNRacunStavke.Show(DeklaritMode.Delete, currentRow, false);
        }

        public override void DoUpdate()
        {
            DataAdapterFactory.GetRACUNDataAdapter().Update(this.DataSet);
        }

        public DialogResult UpdateRACUNRacunStavke(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RACUNWorkItem) this.WorkItem).RACUNRacunStavke.Show(DeklaritMode.Update, currentRow, false);
        }

        public RACUNDataSet DataSet
        {
            get
            {
                return (RACUNDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition RACUNFormDefinition
        {
            get
            {
                return this.RACUNWorkItem.RACUN;
            }
        }

        public FormDefinition RACUNRacunStavkeFormDefinition
        {
            get
            {
                return this.RACUNWorkItem.RACUNRacunStavke;
            }
        }

        public NetAdvantage.WorkItems.RACUNWorkItem RACUNWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.RACUNWorkItem) this.WorkItem;
            }
        }
    }
}

