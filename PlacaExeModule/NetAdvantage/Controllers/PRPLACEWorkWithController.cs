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

    public class PRPLACEWorkWithController : WorkWithControllerBase<PRPLACEWorkItem, PRPLACEDataSet>
    {
        public PRPLACEDataSet.PRPLACERow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetPRPLACEDataAdapter().Fill((PRPLACEDataSet) dataSet, Conversions.ToShort(row["PRPLACEZAMJESEC"]), Conversions.ToInteger(row["PRPLACEID"]), Conversions.ToShort(row["PRPLACEZAGODINU"]));
        }
    }
}

