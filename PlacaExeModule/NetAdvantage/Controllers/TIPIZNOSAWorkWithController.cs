namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.WorkItems;

    public class TIPIZNOSAWorkWithController : WorkWithControllerBase<TIPIZNOSAWorkItem, TIPIZNOSADataSet>
    {
        public TIPIZNOSADataSet.TIPIZNOSARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetTIPIZNOSADataAdapter().Fill((TIPIZNOSADataSet) dataSet, Conversions.ToInteger(row["IDTIPAIZNOSA"]));
        }
    }
}

