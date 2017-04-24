namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.WorkItems;

    public class DDIZDATAKWorkWithController : WorkWithControllerBase<DDIZDATAKWorkItem, DDIZDATAKDataSet>
    {
        public DDIZDATAKDataSet.DDIZDATAKRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetDDIZDATAKDataAdapter().Fill((DDIZDATAKDataSet) dataSet, Conversions.ToInteger(row["DDIDIZDATAK"]));
        }
    }
}

