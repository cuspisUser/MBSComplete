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

    public class SHEMAURAWorkWithController : WorkWithControllerBase<SHEMAURAWorkItem, SHEMAURADataSet>
    {
        public SHEMAURADataSet.SHEMAURARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetSHEMAURADataAdapter().Fill((SHEMAURADataSet) dataSet, Conversions.ToInteger(row["IDSHEMAURA"]));
        }
    }
}

