namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class RAD1VEZASPOLController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetRAD1VEZASPOLDataAdapter().Update(this.DataSet);
        }

        public RAD1VEZASPOLDataSet DataSet
        {
            get
            {
                return (RAD1VEZASPOLDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition RAD1VEZASPOLFormDefinition
        {
            get
            {
                return this.RAD1VEZASPOLWorkItem.RAD1VEZASPOL;
            }
        }

        public NetAdvantage.WorkItems.RAD1VEZASPOLWorkItem RAD1VEZASPOLWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.RAD1VEZASPOLWorkItem) this.WorkItem;
            }
        }
    }
}

