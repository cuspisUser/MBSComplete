namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class POREZController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetPOREZDataAdapter().Update(this.DataSet);
        }

        public POREZDataSet DataSet
        {
            get
            {
                return (POREZDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition POREZFormDefinition
        {
            get
            {
                return this.POREZWorkItem.POREZ;
            }
        }

        public NetAdvantage.WorkItems.POREZWorkItem POREZWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.POREZWorkItem) this.WorkItem;
            }
        }
    }
}

