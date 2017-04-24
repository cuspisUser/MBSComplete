namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class TIPIZNOSAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetTIPIZNOSADataAdapter().Update(this.DataSet);
        }

        public TIPIZNOSADataSet DataSet
        {
            get
            {
                return (TIPIZNOSADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition TIPIZNOSAFormDefinition
        {
            get
            {
                return this.TIPIZNOSAWorkItem.TIPIZNOSA;
            }
        }

        public NetAdvantage.WorkItems.TIPIZNOSAWorkItem TIPIZNOSAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.TIPIZNOSAWorkItem) this.WorkItem;
            }
        }
    }
}

