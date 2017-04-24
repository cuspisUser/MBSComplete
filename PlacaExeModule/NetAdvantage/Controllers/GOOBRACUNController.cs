namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class GOOBRACUNController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetGOOBRACUNDataAdapter().Update(this.DataSet);
        }

        public GOOBRACUNDataSet DataSet
        {
            get
            {
                return (GOOBRACUNDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition GOOBRACUNFormDefinition
        {
            get
            {
                return this.GOOBRACUNWorkItem.GOOBRACUN;
            }
        }

        public NetAdvantage.WorkItems.GOOBRACUNWorkItem GOOBRACUNWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.GOOBRACUNWorkItem) this.WorkItem;
            }
        }
    }
}

