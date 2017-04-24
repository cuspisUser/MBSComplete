namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.SmartParts;
    using NetAdvantage.WorkItems;

    public class OSRAZMJESTAJWorkWithController : WorkWithControllerBase<OSRAZMJESTAJWorkItem, OSRAZMJESTAJDataSet>
    {
        public OSRAZMJESTAJDataSet.OSRAZMJESTAJRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetOSRAZMJESTAJDataAdapter().Fill((OSRAZMJESTAJDataSet) dataSet, (Guid) row["IDOSRAZMJESTAJ"]);
        }
    }
}

