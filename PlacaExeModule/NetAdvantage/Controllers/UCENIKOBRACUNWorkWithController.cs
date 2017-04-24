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

    public class UCENIKOBRACUNWorkWithController : WorkWithControllerBase<UCENIKOBRACUNWorkItem, UCENIKOBRACUNDataSet>
    {
        public UCENIKOBRACUNDataSet.UCENIKOBRACUNRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetUCENIKOBRACUNDataAdapter().Fill((UCENIKOBRACUNDataSet) dataSet, Conversions.ToInteger(row["UCOBRMJESEC"]), Conversions.ToInteger(row["UCOBRGODINA"]));
        }
    }
}

