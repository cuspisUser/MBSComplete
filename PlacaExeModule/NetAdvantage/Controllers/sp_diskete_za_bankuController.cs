namespace NetAdvantage.Controllers
{
    using Microsoft.Practices.CompositeUI;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class sp_diskete_za_bankuController : Controller
    {
        public sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow KeysRow;

        public DataRow SelectOBRACUNidobracun(string fillMethod, DataRow fillByRow)
        {
            OBRACUNSelectionListWorkItem item = this.WorkItem.Items.AddNew<OBRACUNSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }
    }
}

