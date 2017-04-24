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

    public class PROIZVODWorkWithController : WorkWithControllerBase<PROIZVODWorkItem, PROIZVODDataSet>
    {
        public PROIZVODDataSet.PROIZVODRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetPROIZVODDataAdapter().Fill((PROIZVODDataSet) dataSet, Conversions.ToInteger(row["IDPROIZVOD"]));
        }
    }
}

