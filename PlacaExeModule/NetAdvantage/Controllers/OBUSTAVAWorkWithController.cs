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

    public class OBUSTAVAWorkWithController : WorkWithControllerBase<OBUSTAVAWorkItem, OBUSTAVADataSet>
    {
        public OBUSTAVADataSet.OBUSTAVARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetOBUSTAVADataAdapter().Fill((OBUSTAVADataSet) dataSet, Conversions.ToInteger(row["IDOBUSTAVA"]));
        }
    }
}

