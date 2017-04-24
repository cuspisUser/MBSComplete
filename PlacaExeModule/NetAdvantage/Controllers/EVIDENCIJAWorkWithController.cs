namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.WorkItems;

    public class EVIDENCIJAWorkWithController : WorkWithControllerBase<EVIDENCIJAWorkItem, EVIDENCIJADataSet>
    {
        public EVIDENCIJADataSet.EVIDENCIJARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetEVIDENCIJADataAdapter().Fill((EVIDENCIJADataSet) dataSet, Conversions.ToInteger(row["MJESEC"]), Conversions.ToShort(row["IDGODINE"]), Conversions.ToInteger(row["BROJEVIDENCIJE"]));
        }
    }
}

