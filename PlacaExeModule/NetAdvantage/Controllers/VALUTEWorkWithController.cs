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

    public class VALUTEWorkWithController : WorkWithControllerBase<VALUTEWorkItem, VALUTEDataSet>
    {
        public VALUTEDataSet.VALUTERow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetVALUTEDataAdapter().Fill((VALUTEDataSet) dataSet, Conversions.ToInteger(row["IDVALUTA"]));
        }
    }
}

