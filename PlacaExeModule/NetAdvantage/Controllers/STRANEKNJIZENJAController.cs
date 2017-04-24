namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class STRANEKNJIZENJAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Update(this.DataSet);
        }

        public STRANEKNJIZENJADataSet DataSet
        {
            get
            {
                return (STRANEKNJIZENJADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition STRANEKNJIZENJAFormDefinition
        {
            get
            {
                return this.STRANEKNJIZENJAWorkItem.STRANEKNJIZENJA;
            }
        }

        public NetAdvantage.WorkItems.STRANEKNJIZENJAWorkItem STRANEKNJIZENJAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.STRANEKNJIZENJAWorkItem) this.WorkItem;
            }
        }
    }
}

