namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class DDIZDATAKController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetDDIZDATAKDataAdapter().Update(this.DataSet);
        }

        public DDIZDATAKDataSet DataSet
        {
            get
            {
                return (DDIZDATAKDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition DDIZDATAKFormDefinition
        {
            get
            {
                return this.DDIZDATAKWorkItem.DDIZDATAK;
            }
        }

        public NetAdvantage.WorkItems.DDIZDATAKWorkItem DDIZDATAKWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.DDIZDATAKWorkItem) this.WorkItem;
            }
        }
    }
}

