namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class UCENIKRSMIDENTController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetUCENIKRSMIDENTDataAdapter().Update(this.DataSet);
        }

        public UCENIKRSMIDENTDataSet DataSet
        {
            get
            {
                return (UCENIKRSMIDENTDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition UCENIKRSMIDENTFormDefinition
        {
            get
            {
                return this.UCENIKRSMIDENTWorkItem.UCENIKRSMIDENT;
            }
        }

        public NetAdvantage.WorkItems.UCENIKRSMIDENTWorkItem UCENIKRSMIDENTWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.UCENIKRSMIDENTWorkItem) this.WorkItem;
            }
        }
    }
}

