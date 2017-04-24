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

    public class OSOBNIODBITAKWorkWithController : WorkWithControllerBase<OSOBNIODBITAKWorkItem, OSOBNIODBITAKDataSet>
    {
        public OSOBNIODBITAKDataSet.OSOBNIODBITAKRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetOSOBNIODBITAKDataAdapter().Fill((OSOBNIODBITAKDataSet) dataSet, Conversions.ToInteger(row["IDOSOBNIODBITAK"]));
        }
    }
}

