namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.WorkItems;

    public class OSDOKUMENTWorkWithController : WorkWithControllerBase<OSDOKUMENTWorkItem, OSDOKUMENTDataSet>
    {
        public OSDOKUMENTDataSet.OSDOKUMENTRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetOSDOKUMENTDataAdapter().Fill((OSDOKUMENTDataSet) dataSet, Conversions.ToInteger(row["IDOSDOKUMENT"]));
        }
    }
}

