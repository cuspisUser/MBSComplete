﻿namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.SmartParts;
    using NetAdvantage.WorkItems;

    public class DOPRINOSWorkWithController : WorkWithControllerBase<DOPRINOSWorkItem, DOPRINOSDataSet>
    {
        public DOPRINOSDataSet.DOPRINOSRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetDOPRINOSDataAdapter().Fill((DOPRINOSDataSet) dataSet, Conversions.ToInteger(row["IDDOPRINOS"]));
        }
    }
}

