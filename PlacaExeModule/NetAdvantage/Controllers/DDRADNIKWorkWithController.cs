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

    public class DDRADNIKWorkWithController : WorkWithControllerBase<DDRADNIKWorkItem, DDRADNIKDataSet>
    {
        public DDRADNIKDataSet.DDRADNIKRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetDDRADNIKDataAdapter().Fill((DDRADNIKDataSet) dataSet, Conversions.ToInteger(row["DDIDRADNIK"]));
        }
    }
}

