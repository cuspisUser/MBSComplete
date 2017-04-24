namespace EVModule.EvModule
{
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.Commands;
    using NetAdvantage.WorkItems;
    using System;

    public class MainController : Controller
    {
        [CommandHandler("Ev.EvidencijaUnosCommand")]
        public void ObracunCommand(object sender, EventArgs e)
        {
            EvidencijaCustomWorkItem item = this.WorkItem.Items.Get<EvidencijaCustomWorkItem>("Ev.EvidencijaUnos");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<EvidencijaCustomWorkItem>("Ev.EvidencijaUnos");
            }
            item.Show(item.Workspaces["main"]);
        }

        [CommandHandler("Ev.SmjeneCommand")]
        public void SmjeneCommand(object sender, EventArgs e)
        {
            SMJENEWorkWithWorkItem item = this.WorkItem.Items.Get<SMJENEWorkWithWorkItem>("Ev.Smjene");
            if (item == null)
            {
                item = this.WorkItem.Items.AddNew<SMJENEWorkWithWorkItem>("Ev.Smjene");
            }
            item.Show(item.Workspaces["main"]);
        }
    }
}

