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

    public class RAD1GELEMENTIVEZAWorkWithController : WorkWithControllerBase<RAD1GELEMENTIVEZAWorkItem, RAD1GELEMENTIVEZADataSet>
    {
        public RAD1GELEMENTIVEZADataSet.RAD1GELEMENTIVEZARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetRAD1GELEMENTIVEZADataAdapter().Fill((RAD1GELEMENTIVEZADataSet) dataSet, Conversions.ToInteger(row["RAD1GELEMENTIID"]), Conversions.ToInteger(row["IDELEMENT"]));
        }
    }
}

