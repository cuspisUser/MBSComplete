namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class OSDOKUMENTController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetOSDOKUMENTDataAdapter().Update(this.DataSet);
        }

        public OSDOKUMENTDataSet DataSet
        {
            get
            {
                return (OSDOKUMENTDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition OSDOKUMENTFormDefinition
        {
            get
            {
                return this.OSDOKUMENTWorkItem.OSDOKUMENT;
            }
        }

        public NetAdvantage.WorkItems.OSDOKUMENTWorkItem OSDOKUMENTWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.OSDOKUMENTWorkItem) this.WorkItem;
            }
        }
    }
}

