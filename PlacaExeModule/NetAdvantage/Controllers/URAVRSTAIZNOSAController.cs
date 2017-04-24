namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class URAVRSTAIZNOSAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetURAVRSTAIZNOSADataAdapter().Update(this.DataSet);
        }

        public URAVRSTAIZNOSADataSet DataSet
        {
            get
            {
                return (URAVRSTAIZNOSADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition URAVRSTAIZNOSAFormDefinition
        {
            get
            {
                return this.URAVRSTAIZNOSAWorkItem.URAVRSTAIZNOSA;
            }
        }

        public NetAdvantage.WorkItems.URAVRSTAIZNOSAWorkItem URAVRSTAIZNOSAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.URAVRSTAIZNOSAWorkItem) this.WorkItem;
            }
        }
    }
}

