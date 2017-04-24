namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class BLGVRSTEDOKController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetBLGVRSTEDOKDataAdapter().Update(this.DataSet);
        }

        public FormDefinition BLGVRSTEDOKFormDefinition
        {
            get
            {
                return this.BLGVRSTEDOKWorkItem.BLGVRSTEDOK;
            }
        }

        public NetAdvantage.WorkItems.BLGVRSTEDOKWorkItem BLGVRSTEDOKWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.BLGVRSTEDOKWorkItem) this.WorkItem;
            }
        }

        public BLGVRSTEDOKDataSet DataSet
        {
            get
            {
                return (BLGVRSTEDOKDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }
    }
}

