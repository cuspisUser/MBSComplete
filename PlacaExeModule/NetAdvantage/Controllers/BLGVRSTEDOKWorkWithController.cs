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

    public class BLGVRSTEDOKWorkWithController : WorkWithControllerBase<BLGVRSTEDOKWorkItem, BLGVRSTEDOKDataSet>
    {
        public BLGVRSTEDOKDataSet.BLGVRSTEDOKRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetBLGVRSTEDOKDataAdapter().Fill((BLGVRSTEDOKDataSet) dataSet, Conversions.ToInteger(row["IDBLGVRSTEDOK"]));
        }
    }
}

