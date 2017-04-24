namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class OTISLIController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetOTISLIDataAdapter().Update(this.DataSet);
        }

        public OTISLIDataSet DataSet
        {
            get
            {
                return (OTISLIDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition OTISLIFormDefinition
        {
            get
            {
                return this.OTISLIWorkItem.OTISLI;
            }
        }

        public NetAdvantage.WorkItems.OTISLIWorkItem OTISLIWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.OTISLIWorkItem) this.WorkItem;
            }
        }
    }
}

