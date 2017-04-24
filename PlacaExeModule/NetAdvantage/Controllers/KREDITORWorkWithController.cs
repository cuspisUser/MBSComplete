namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.WorkItems;

    public class KREDITORWorkWithController : WorkWithControllerBase<KREDITORWorkItem, KREDITORDataSet>
    {
        public KREDITORDataSet.KREDITORRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetKREDITORDataAdapter().Fill((KREDITORDataSet) dataSet, Conversions.ToInteger(row["IDKREDITOR"]));
        }
    }
}

