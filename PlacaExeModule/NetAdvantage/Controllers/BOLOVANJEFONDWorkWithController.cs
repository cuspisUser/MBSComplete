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

    public class BOLOVANJEFONDWorkWithController : WorkWithControllerBase<BOLOVANJEFONDWorkItem, BOLOVANJEFONDDataSet>
    {
        public BOLOVANJEFONDDataSet.BOLOVANJEFONDRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetBOLOVANJEFONDDataAdapter().Fill((BOLOVANJEFONDDataSet) dataSet, Conversions.ToInteger(row["ELEMENTBOLOVANJEIDELEMENT"]));
        }
    }
}

