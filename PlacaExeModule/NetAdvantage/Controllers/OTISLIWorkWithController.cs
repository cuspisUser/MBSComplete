namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.SmartParts;
    using NetAdvantage.WorkItems;

    public class OTISLIWorkWithController : WorkWithControllerBase<OTISLIWorkItem, OTISLIDataSet>
    {
        public OTISLIDataSet.OTISLIRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetOTISLIDataAdapter().Fill((OTISLIDataSet) dataSet, Conversions.ToInteger(row["IDRADNIK"]), Conversions.ToDate(row["DATUMODLASKA"]));
        }
    }
}

