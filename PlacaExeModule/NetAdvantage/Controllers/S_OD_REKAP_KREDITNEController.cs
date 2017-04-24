namespace NetAdvantage.Controllers
{
    using Microsoft.Practices.CompositeUI;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class S_OD_REKAP_KREDITNEController : Controller
    {
        public S_OD_REKAP_KREDITNEDataSet.S_OD_REKAP_KREDITNERow KeysRow;

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

