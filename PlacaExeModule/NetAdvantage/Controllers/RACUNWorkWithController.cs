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

    public class RACUNWorkWithController : WorkWithControllerBase<RACUNWorkItem, RACUNDataSet>
    {
        public RACUNDataSet.RACUNRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetRACUNDataAdapter().Fill((RACUNDataSet) dataSet, Conversions.ToInteger(row["IDRACUN"]), Conversions.ToShort(row["RACUNGODINAIDGODINE"]));
        }
    }
}

