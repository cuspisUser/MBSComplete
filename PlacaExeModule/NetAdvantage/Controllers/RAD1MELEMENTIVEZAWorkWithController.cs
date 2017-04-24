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

    public class RAD1MELEMENTIVEZAWorkWithController : WorkWithControllerBase<RAD1MELEMENTIVEZAWorkItem, RAD1MELEMENTIVEZADataSet>
    {
        public RAD1MELEMENTIVEZADataSet.RAD1MELEMENTIVEZARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetRAD1MELEMENTIVEZADataAdapter().Fill((RAD1MELEMENTIVEZADataSet) dataSet, Conversions.ToInteger(row["RAD1ELEMENTIID"]), Conversions.ToInteger(row["IDELEMENT"]));
        }
    }
}

