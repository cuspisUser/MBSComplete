namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class DDVRSTEIZNOSAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetDDVRSTEIZNOSADataAdapter().Update(this.DataSet);
        }

        public DDVRSTEIZNOSADataSet DataSet
        {
            get
            {
                return (DDVRSTEIZNOSADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition DDVRSTEIZNOSAFormDefinition
        {
            get
            {
                return this.DDVRSTEIZNOSAWorkItem.DDVRSTEIZNOSA;
            }
        }

        public NetAdvantage.WorkItems.DDVRSTEIZNOSAWorkItem DDVRSTEIZNOSAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.DDVRSTEIZNOSAWorkItem) this.WorkItem;
            }
        }
    }
}

