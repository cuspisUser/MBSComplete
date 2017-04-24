namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class PLVRSTEIZNOSAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetPLVRSTEIZNOSADataAdapter().Update(this.DataSet);
        }

        public PLVRSTEIZNOSADataSet DataSet
        {
            get
            {
                return (PLVRSTEIZNOSADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition PLVRSTEIZNOSAFormDefinition
        {
            get
            {
                return this.PLVRSTEIZNOSAWorkItem.PLVRSTEIZNOSA;
            }
        }

        public NetAdvantage.WorkItems.PLVRSTEIZNOSAWorkItem PLVRSTEIZNOSAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.PLVRSTEIZNOSAWorkItem) this.WorkItem;
            }
        }
    }
}

