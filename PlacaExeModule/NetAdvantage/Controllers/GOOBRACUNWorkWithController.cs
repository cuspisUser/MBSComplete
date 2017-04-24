namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.WorkItems;

    public class GOOBRACUNWorkWithController : WorkWithControllerBase<GOOBRACUNWorkItem, GOOBRACUNDataSet>
    {
        public GOOBRACUNDataSet.GOOBRACUNRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetGOOBRACUNDataAdapter().Fill((GOOBRACUNDataSet) dataSet, Conversions.ToInteger(row["IDGOOBRACUN"]));
        }
    }
}

