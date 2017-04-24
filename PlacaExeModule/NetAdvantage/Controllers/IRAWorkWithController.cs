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

    public class IRAWorkWithController : WorkWithControllerBase<IraWorkItem, IRADataSet>
    {
        public IRADataSet.IRARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetIRADataAdapter().Fill((IRADataSet) dataSet, Conversions.ToShort(row["IRAGODIDGODINE"]), Conversions.ToInteger(row["IRADOKIDDOKUMENT"]), Conversions.ToInteger(row["IRABROJ"]));
        }
    }
}

