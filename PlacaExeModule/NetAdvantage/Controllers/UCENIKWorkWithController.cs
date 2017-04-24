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

    public class UCENIKWorkWithController : WorkWithControllerBase<UCENIKWorkItem, UCENIKDataSet>
    {
        public UCENIKDataSet.UCENIKRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetUCENIKDataAdapter().Fill((UCENIKDataSet) dataSet, Conversions.ToInteger(row["IDUCENIK"]));
        }
    }
}

