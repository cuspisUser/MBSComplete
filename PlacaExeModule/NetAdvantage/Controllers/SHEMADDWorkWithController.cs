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

    public class SHEMADDWorkWithController : WorkWithControllerBase<SHEMADDWorkItem, SHEMADDDataSet>
    {
        public SHEMADDDataSet.SHEMADDRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetSHEMADDDataAdapter().Fill((SHEMADDDataSet) dataSet, Conversions.ToInteger(row["IDSHEMADD"]));
        }
    }
}

