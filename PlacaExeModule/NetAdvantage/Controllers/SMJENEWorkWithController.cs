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

    public class SMJENEWorkWithController : WorkWithControllerBase<SMJENEWorkItem, SMJENEDataSet>
    {
        public SMJENEDataSet.SMJENERow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetSMJENEDataAdapter().Fill((SMJENEDataSet) dataSet, Conversions.ToInteger(row["IDSMJENE"]));
        }
    }
}

