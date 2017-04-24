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

    public class RAD1SPREMEVEZAWorkWithController : WorkWithControllerBase<RAD1SPREMEVEZAWorkItem, RAD1SPREMEVEZADataSet>
    {
        public RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetRAD1SPREMEVEZADataAdapter().Fill((RAD1SPREMEVEZADataSet) dataSet, Conversions.ToInteger(row["RAD1IDSPREME"]), Conversions.ToInteger(row["IDSTRUCNASPREMA"]));
        }
    }
}

