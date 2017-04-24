namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.WorkItems;

    public class ZAPOSLENIWorkWithController : WorkWithControllerBase<ZAPOSLENIWorkItem, ZAPOSLENIDataSet>
    {
        public ZAPOSLENIDataSet.ZAPOSLENIRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetZAPOSLENIDataAdapter().Fill((ZAPOSLENIDataSet) dataSet, Conversions.ToInteger(row["IDRADNIK"]), Conversions.ToDate(row["DATUMZAPOSLENJA"]));
        }
    }
}

