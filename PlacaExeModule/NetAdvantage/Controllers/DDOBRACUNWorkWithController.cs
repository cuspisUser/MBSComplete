namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.WorkItems;

    public class DDOBRACUNWorkWithController : WorkWithControllerBase<DDOBRACUNWorkItem, DDOBRACUNDataSet>
    {
        public DDOBRACUNDataSet.DDOBRACUNRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetDDOBRACUNDataAdapter().Fill((DDOBRACUNDataSet) dataSet, Conversions.ToString(row["DDOBRACUNIDOBRACUN"]));
        }
    }
}

