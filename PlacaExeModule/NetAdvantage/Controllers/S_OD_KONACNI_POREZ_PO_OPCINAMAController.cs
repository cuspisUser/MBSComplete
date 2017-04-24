﻿namespace NetAdvantage.Controllers
{
    using Microsoft.Practices.CompositeUI;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;

    public class S_OD_KONACNI_POREZ_PO_OPCINAMAController : Controller
    {
        public S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow KeysRow;

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

