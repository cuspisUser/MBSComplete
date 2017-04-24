namespace NetAdvantage
{
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.ObjectBuilder;
    using Placa;
    using System;
    using System.Resources;

    public class DeklaritModuleInit : ModuleInit
    {
        private WorkItem m_WorkItem;

        [InjectionConstructor]
        public DeklaritModuleInit([ServiceDependency] WorkItem workItem)
        {
            this.m_WorkItem = workItem;
        }

        public override void AddServices()
        {
            base.AddServices();
            this.m_WorkItem.Services.Add(typeof(ResourceManager), ImageResources.ResourceManager);
        }

        public override void Load()
        {
            DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
            this.m_WorkItem.WorkItems.AddNew<MainWorkItem>().Run();
        }
    }
}

