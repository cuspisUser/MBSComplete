namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class VALUTEController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetVALUTEDataAdapter().Update(this.DataSet);
        }

        public VALUTEDataSet DataSet
        {
            get
            {
                return (VALUTEDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition VALUTEFormDefinition
        {
            get
            {
                return this.VALUTEWorkItem.VALUTE;
            }
        }

        public NetAdvantage.WorkItems.VALUTEWorkItem VALUTEWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.VALUTEWorkItem) this.WorkItem;
            }
        }
    }
}

