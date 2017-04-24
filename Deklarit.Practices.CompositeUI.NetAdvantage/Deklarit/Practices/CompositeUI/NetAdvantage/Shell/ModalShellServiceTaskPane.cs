namespace Deklarit.Practices.CompositeUI.NetAdvantage.Shell
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Services;
    using Microsoft.Practices.CompositeUI;
    using System;

    public class ModalShellServiceTaskPane : IModalViewService
    {
        public IModalForm GetModalFormView(WorkItem workItem)
        {
            return workItem.Items.AddNew<InstanceModalForm>();
        }

        public IModalForm GetWorkWithModalView(WorkItem workItem)
        {
            WorkWithModalForm item = new WorkWithModalForm(workItem, true);
            workItem.Items.Add(item);
            return item;
        }
    }
}

