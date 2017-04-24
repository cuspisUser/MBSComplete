namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class BOLOVANJEFONDController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetBOLOVANJEFONDDataAdapter().Update(this.DataSet);
        }

        public FormDefinition BOLOVANJEFONDFormDefinition
        {
            get
            {
                return this.BOLOVANJEFONDWorkItem.BOLOVANJEFOND;
            }
        }

        public NetAdvantage.WorkItems.BOLOVANJEFONDWorkItem BOLOVANJEFONDWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.BOLOVANJEFONDWorkItem) this.WorkItem;
            }
        }

        public BOLOVANJEFONDDataSet DataSet
        {
            get
            {
                return (BOLOVANJEFONDDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }
    }
}

