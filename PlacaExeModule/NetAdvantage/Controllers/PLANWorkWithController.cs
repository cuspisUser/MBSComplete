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

    public class PLANWorkWithController : WorkWithControllerBase<PLANWorkItem, PLANDataSet>
    {
        public PLANDataSet.PLANRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetPLANDataAdapter().Fill((PLANDataSet) dataSet, Conversions.ToInteger(row["IDPLAN"]), Conversions.ToShort(row["PLANGODINAIDGODINE"]));
        }
    }
}

