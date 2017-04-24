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

    public class BLAGAJNAWorkWithController : WorkWithControllerBase<BLAGAJNAWorkItem, BLAGAJNADataSet>
    {
        public BLAGAJNADataSet.BLAGAJNARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetBLAGAJNADataAdapter().Fill((BLAGAJNADataSet) dataSet, Conversions.ToInteger(row["BLGDOKIDDOKUMENT"]));
        }
    }
}

