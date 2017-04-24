namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class ZAPOSLENIController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetZAPOSLENIDataAdapter().Update(this.DataSet);
        }

        public ZAPOSLENIDataSet DataSet
        {
            get
            {
                return (ZAPOSLENIDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition ZAPOSLENIFormDefinition
        {
            get
            {
                return this.ZAPOSLENIWorkItem.ZAPOSLENI;
            }
        }

        public NetAdvantage.WorkItems.ZAPOSLENIWorkItem ZAPOSLENIWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.ZAPOSLENIWorkItem) this.WorkItem;
            }
        }
    }
}

