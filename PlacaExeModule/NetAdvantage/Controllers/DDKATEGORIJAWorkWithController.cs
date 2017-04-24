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

    public class DDKATEGORIJAWorkWithController : WorkWithControllerBase<DDKATEGORIJAWorkItem, DDKATEGORIJADataSet>
    {
        public DDKATEGORIJADataSet.DDKATEGORIJARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetDDKATEGORIJADataAdapter().Fill((DDKATEGORIJADataSet) dataSet, Conversions.ToInteger(row["IDKATEGORIJA"]));
        }
    }
}

