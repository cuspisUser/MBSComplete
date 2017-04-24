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

    public class RAD1VEZASPOLWorkWithController : WorkWithControllerBase<RAD1VEZASPOLWorkItem, RAD1VEZASPOLDataSet>
    {
        public RAD1VEZASPOLDataSet.RAD1VEZASPOLRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetRAD1VEZASPOLDataAdapter().Fill((RAD1VEZASPOLDataSet) dataSet, Conversions.ToInteger(row["RAD1SPOLID"]), Conversions.ToInteger(row["IDSPOL"]));
        }
    }
}

