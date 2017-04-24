namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class VIRMANIController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetVIRMANIDataAdapter().Update(this.DataSet);
        }

        public VIRMANIDataSet DataSet
        {
            get
            {
                return (VIRMANIDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition VIRMANIFormDefinition
        {
            get
            {
                return this.VIRMANIWorkItem.VIRMANI;
            }
        }

        public NetAdvantage.WorkItems.VIRMANIWorkItem VIRMANIWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.VIRMANIWorkItem) this.WorkItem;
            }
        }
    }
}

