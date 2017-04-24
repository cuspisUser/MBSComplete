namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class VERZIJAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetVERZIJADataAdapter().Update(this.DataSet);
        }

        public VERZIJADataSet DataSet
        {
            get
            {
                return (VERZIJADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition VERZIJAFormDefinition
        {
            get
            {
                return this.VERZIJAWorkItem.VERZIJA;
            }
        }

        public NetAdvantage.WorkItems.VERZIJAWorkItem VERZIJAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.VERZIJAWorkItem) this.WorkItem;
            }
        }
    }
}

