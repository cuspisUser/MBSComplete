namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class KRIZNIPOREZController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetKRIZNIPOREZDataAdapter().Update(this.DataSet);
        }

        public KRIZNIPOREZDataSet DataSet
        {
            get
            {
                return (KRIZNIPOREZDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition KRIZNIPOREZFormDefinition
        {
            get
            {
                return this.KRIZNIPOREZWorkItem.KRIZNIPOREZ;
            }
        }

        public NetAdvantage.WorkItems.KRIZNIPOREZWorkItem KRIZNIPOREZWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.KRIZNIPOREZWorkItem) this.WorkItem;
            }
        }
    }
}

