namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.WorkItems;

    public class POREZWorkWithController : WorkWithControllerBase<POREZWorkItem, POREZDataSet>
    {
        public POREZDataSet.POREZRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetPOREZDataAdapter().Fill((POREZDataSet) dataSet, Conversions.ToInteger(row["IDPOREZ"]));
        }
    }
}

