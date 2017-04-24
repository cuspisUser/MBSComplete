namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class SMJENEController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetSMJENEDataAdapter().Update(this.DataSet);
        }

        public SMJENEDataSet DataSet
        {
            get
            {
                return (SMJENEDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition SMJENEFormDefinition
        {
            get
            {
                return this.SMJENEWorkItem.SMJENE;
            }
        }

        public NetAdvantage.WorkItems.SMJENEWorkItem SMJENEWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.SMJENEWorkItem) this.WorkItem;
            }
        }
    }
}

