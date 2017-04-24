namespace NetAdvantage.Controllers
{
    using Microsoft.Practices.CompositeUI;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class S_OD_STANJE_OBUSTAVAController : Controller
    {
        public S_OD_STANJE_OBUSTAVADataSet.S_OD_STANJE_OBUSTAVARow KeysRow;

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

