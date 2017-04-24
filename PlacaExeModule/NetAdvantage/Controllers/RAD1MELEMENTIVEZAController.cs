namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class RAD1MELEMENTIVEZAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetRAD1MELEMENTIVEZADataAdapter().Update(this.DataSet);
        }

        public RAD1MELEMENTIVEZADataSet DataSet
        {
            get
            {
                return (RAD1MELEMENTIVEZADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition RAD1MELEMENTIVEZAFormDefinition
        {
            get
            {
                return this.RAD1MELEMENTIVEZAWorkItem.RAD1MELEMENTIVEZA;
            }
        }

        public NetAdvantage.WorkItems.RAD1MELEMENTIVEZAWorkItem RAD1MELEMENTIVEZAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.RAD1MELEMENTIVEZAWorkItem) this.WorkItem;
            }
        }
    }
}

