using System;

using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;

namespace UcenickoFakturiranje
{
    public class DeklaritModuleInit : ModuleInit
    {
        private WorkItem m_WorkItem;

        [InjectionConstructor]
        public DeklaritModuleInit([ServiceDependency] WorkItem workItem)
        {
            this.m_WorkItem = workItem;
        }

        public override void Load()
        {
            this.m_WorkItem.WorkItems.AddNew<MainWorkItem>().Run();
        }
    }
}
