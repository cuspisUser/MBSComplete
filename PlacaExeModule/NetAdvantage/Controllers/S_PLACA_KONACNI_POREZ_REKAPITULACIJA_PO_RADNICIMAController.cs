namespace NetAdvantage.Controllers
{
    using Microsoft.Practices.CompositeUI;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMAController : Controller
    {
        public S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMADataSet.S_PLACA_KONACNI_POREZ_REKAPITULACIJA_PO_RADNICIMARow KeysRow;

        public DataRow SelectOBRACUNIDOBRACUN(string fillMethod, DataRow fillByRow)
        {
            OBRACUNSelectionListWorkItem item = this.WorkItem.Items.AddNew<OBRACUNSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }
    }
}

