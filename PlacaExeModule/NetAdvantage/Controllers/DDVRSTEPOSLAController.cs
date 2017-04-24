namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class DDVRSTEPOSLAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetDDVRSTEPOSLADataAdapter().Update(this.DataSet);
        }

        public DDVRSTEPOSLADataSet DataSet
        {
            get
            {
                return (DDVRSTEPOSLADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition DDVRSTEPOSLAFormDefinition
        {
            get
            {
                return this.DDVRSTEPOSLAWorkItem.DDVRSTEPOSLA;
            }
        }

        public NetAdvantage.WorkItems.DDVRSTEPOSLAWorkItem DDVRSTEPOSLAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.DDVRSTEPOSLAWorkItem) this.WorkItem;
            }
        }
    }
}

