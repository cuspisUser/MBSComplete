namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.WorkItems;

    public class URAVRSTAIZNOSAWorkWithController : WorkWithControllerBase<URAVRSTAIZNOSAWorkItem, URAVRSTAIZNOSADataSet>
    {
        public URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetURAVRSTAIZNOSADataAdapter().Fill((URAVRSTAIZNOSADataSet) dataSet, Conversions.ToInteger(row["IDURAVRSTAIZNOSA"]));
        }
    }
}

