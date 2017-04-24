namespace NetAdvantage.Controllers
{
    using Microsoft.Practices.CompositeUI;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class s_od_rekap_doprinosController : Controller
    {
        public s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow KeysRow;

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

