namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class OSOBNIODBITAKController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetOSOBNIODBITAKDataAdapter().Update(this.DataSet);
        }

        public OSOBNIODBITAKDataSet DataSet
        {
            get
            {
                return (OSOBNIODBITAKDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition OSOBNIODBITAKFormDefinition
        {
            get
            {
                return this.OSOBNIODBITAKWorkItem.OSOBNIODBITAK;
            }
        }

        public NetAdvantage.WorkItems.OSOBNIODBITAKWorkItem OSOBNIODBITAKWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.OSOBNIODBITAKWorkItem) this.WorkItem;
            }
        }
    }
}

