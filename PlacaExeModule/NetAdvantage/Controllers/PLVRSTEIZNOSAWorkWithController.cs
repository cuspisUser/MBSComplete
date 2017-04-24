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

    public class PLVRSTEIZNOSAWorkWithController : WorkWithControllerBase<PLVRSTEIZNOSAWorkItem, PLVRSTEIZNOSADataSet>
    {
        public PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetPLVRSTEIZNOSADataAdapter().Fill((PLVRSTEIZNOSADataSet) dataSet, Conversions.ToInteger(row["IDPLVRSTEIZNOSA"]));
        }
    }
}

