namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class RAD1SPREMEVEZAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetRAD1SPREMEVEZADataAdapter().Update(this.DataSet);
        }

        public RAD1SPREMEVEZADataSet DataSet
        {
            get
            {
                return (RAD1SPREMEVEZADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition RAD1SPREMEVEZAFormDefinition
        {
            get
            {
                return this.RAD1SPREMEVEZAWorkItem.RAD1SPREMEVEZA;
            }
        }

        public NetAdvantage.WorkItems.RAD1SPREMEVEZAWorkItem RAD1SPREMEVEZAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.RAD1SPREMEVEZAWorkItem) this.WorkItem;
            }
        }
    }
}

