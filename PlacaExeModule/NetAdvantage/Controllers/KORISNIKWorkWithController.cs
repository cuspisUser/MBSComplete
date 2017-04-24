namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.WorkItems;

    public class KORISNIKWorkWithController : WorkWithControllerBase<KORISNIKWorkItem, KORISNIKDataSet>
    {
        public KORISNIKDataSet.KORISNIKRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetKORISNIKDataAdapter().Fill((KORISNIKDataSet) dataSet, Conversions.ToInteger(row["IDKORISNIK"]));
        }
    }
}

