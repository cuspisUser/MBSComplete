namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.WorkItems;

    public class GRUPEKOEFWorkWithController : WorkWithControllerBase<GRUPEKOEFWorkItem, GRUPEKOEFDataSet>
    {
        public GRUPEKOEFDataSet.GRUPEKOEFRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetGRUPEKOEFDataAdapter().Fill((GRUPEKOEFDataSet) dataSet, Conversions.ToInteger(row["IDGRUPEKOEF"]));
        }
    }
}

