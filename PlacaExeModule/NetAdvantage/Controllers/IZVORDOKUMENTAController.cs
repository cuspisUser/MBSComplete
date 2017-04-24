namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class IZVORDOKUMENTAController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetIZVORDOKUMENTADataAdapter().Update(this.DataSet);
        }

        public IZVORDOKUMENTADataSet DataSet
        {
            get
            {
                return (IZVORDOKUMENTADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition IZVORDOKUMENTAFormDefinition
        {
            get
            {
                return this.IZVORDOKUMENTAWorkItem.IZVORDOKUMENTA;
            }
        }

        public NetAdvantage.WorkItems.IZVORDOKUMENTAWorkItem IZVORDOKUMENTAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.IZVORDOKUMENTAWorkItem) this.WorkItem;
            }
        }
    }
}

