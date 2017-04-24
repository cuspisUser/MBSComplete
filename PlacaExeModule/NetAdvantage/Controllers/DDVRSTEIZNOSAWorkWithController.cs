namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.WorkItems;

    public class DDVRSTEIZNOSAWorkWithController : WorkWithControllerBase<DDVRSTEIZNOSAWorkItem, DDVRSTEIZNOSADataSet>
    {
        public DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetDDVRSTEIZNOSADataAdapter().Fill((DDVRSTEIZNOSADataSet) dataSet, Conversions.ToInteger(row["IDDDVRSTEIZNOSA"]));
        }
    }
}

