namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;

    public class DOSIPZAGLAVLJEController : FormControllerBase
    {
        public override void DoUpdate()
        {
            DataAdapterFactory.GetDOSIPZAGLAVLJEDataAdapter().Update(this.DataSet);
        }

        public DOSIPZAGLAVLJEDataSet DataSet
        {
            get
            {
                return (DOSIPZAGLAVLJEDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition DOSIPZAGLAVLJEFormDefinition
        {
            get
            {
                return this.DOSIPZAGLAVLJEWorkItem.DOSIPZAGLAVLJE;
            }
        }

        public NetAdvantage.WorkItems.DOSIPZAGLAVLJEWorkItem DOSIPZAGLAVLJEWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.DOSIPZAGLAVLJEWorkItem) this.WorkItem;
            }
        }
    }
}

