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

    public class IZVORDOKUMENTAWorkWithController : WorkWithControllerBase<IZVORDOKUMENTAWorkItem, IZVORDOKUMENTADataSet>
    {
        public IZVORDOKUMENTADataSet.IZVORDOKUMENTARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetIZVORDOKUMENTADataAdapter().Fill((IZVORDOKUMENTADataSet) dataSet, Conversions.ToString(row["SIFRAIZVORA"]));
        }
    }
}

