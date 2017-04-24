namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class KREDITORController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetKREDITORDataAdapter().Update(this.DataSet);
        }

        public KREDITORDataSet DataSet
        {
            get
            {
                return (KREDITORDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition KREDITORFormDefinition
        {
            get
            {
                return this.KREDITORWorkItem.KREDITOR;
            }
        }

        public NetAdvantage.WorkItems.KREDITORWorkItem KREDITORWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.KREDITORWorkItem) this.WorkItem;
            }
        }
    }
}

