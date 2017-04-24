namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.WorkItems;

    public class SHEMAIRAWorkWithController : WorkWithControllerBase<SHEMAIRAWorkItem, SHEMAIRADataSet>
    {
        public SHEMAIRADataSet.SHEMAIRARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetSHEMAIRADataAdapter().Fill((SHEMAIRADataSet) dataSet, Conversions.ToInteger(row["IDSHEMAIRA"]));
        }
    }
}

