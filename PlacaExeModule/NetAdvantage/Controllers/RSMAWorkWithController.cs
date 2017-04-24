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

    public class RSMAWorkWithController : WorkWithControllerBase<RSMAWorkItem, RSMADataSet>
    {
        public RSMADataSet.RSMARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetRSMADataAdapter().Fill((RSMADataSet) dataSet, Conversions.ToString(row["IDENTIFIKATOROBRASCA"]));
        }
    }
}

