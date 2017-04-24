namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class PROIZVODController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetPROIZVODDataAdapter().Update(this.DataSet);
        }

        public PROIZVODDataSet DataSet
        {
            get
            {
                return (PROIZVODDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition PROIZVODFormDefinition
        {
            get
            {
                return this.PROIZVODWorkItem.PROIZVOD;
            }
        }

        public NetAdvantage.WorkItems.PROIZVODWorkItem PROIZVODWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.PROIZVODWorkItem) this.WorkItem;
            }
        }
    }
}

