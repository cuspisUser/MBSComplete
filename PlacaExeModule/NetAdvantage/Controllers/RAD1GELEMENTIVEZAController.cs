namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class RAD1GELEMENTIVEZAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetRAD1GELEMENTIVEZADataAdapter().Update(this.DataSet);
        }

        public RAD1GELEMENTIVEZADataSet DataSet
        {
            get
            {
                return (RAD1GELEMENTIVEZADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition RAD1GELEMENTIVEZAFormDefinition
        {
            get
            {
                return this.RAD1GELEMENTIVEZAWorkItem.RAD1GELEMENTIVEZA;
            }
        }

        public NetAdvantage.WorkItems.RAD1GELEMENTIVEZAWorkItem RAD1GELEMENTIVEZAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.RAD1GELEMENTIVEZAWorkItem) this.WorkItem;
            }
        }
    }
}

