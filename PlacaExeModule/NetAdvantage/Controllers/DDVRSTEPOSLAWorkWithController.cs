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

    public class DDVRSTEPOSLAWorkWithController : WorkWithControllerBase<DDVRSTEPOSLAWorkItem, DDVRSTEPOSLADataSet>
    {
        public DDVRSTEPOSLADataSet.DDVRSTEPOSLARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetDDVRSTEPOSLADataAdapter().Fill((DDVRSTEPOSLADataSet) dataSet, Conversions.ToInteger(row["DDIDVRSTAPOSLA"]));
        }
    }
}

