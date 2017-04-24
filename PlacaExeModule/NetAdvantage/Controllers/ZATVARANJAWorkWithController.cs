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

    public class ZATVARANJAWorkWithController : WorkWithControllerBase<ZATVARANJAWorkItem, ZATVARANJADataSet>
    {
        public ZATVARANJADataSet.ZATVARANJARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetZATVARANJADataAdapter().Fill((ZATVARANJADataSet) dataSet, Conversions.ToInteger(row["GK1IDGKSTAVKA"]), Conversions.ToInteger(row["GK2IDGKSTAVKA"]));
        }
    }
}

