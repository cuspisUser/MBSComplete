namespace NetAdvantage.Controllers
{
    using Microsoft.Practices.CompositeUI;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class S_OS_STANJE_LOKACIJAController : Controller
    {
        public S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow KeysRow;

        public DataRow SelectOSinvbroj(string fillMethod, DataRow fillByRow)
        {
            OSSelectionListWorkItem item = this.WorkItem.Items.AddNew<OSSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }
    }
}

