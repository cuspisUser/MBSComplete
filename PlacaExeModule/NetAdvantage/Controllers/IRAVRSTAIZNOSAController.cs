namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class IRAVRSTAIZNOSAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetIRAVRSTAIZNOSADataAdapter().Update(this.DataSet);
        }

        public IRAVRSTAIZNOSADataSet DataSet
        {
            get
            {
                return (IRAVRSTAIZNOSADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition IRAVRSTAIZNOSAFormDefinition
        {
            get
            {
                return this.IRAVRSTAIZNOSAWorkItem.IRAVRSTAIZNOSA;
            }
        }

        public NetAdvantage.WorkItems.IRAVRSTAIZNOSAWorkItem IRAVRSTAIZNOSAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.IRAVRSTAIZNOSAWorkItem) this.WorkItem;
            }
        }
    }
}

