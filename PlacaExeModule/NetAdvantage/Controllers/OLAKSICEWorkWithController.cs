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

    public class OLAKSICEWorkWithController : WorkWithControllerBase<OLAKSICEWorkItem, OLAKSICEDataSet>
    {
        public OLAKSICEDataSet.OLAKSICERow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetOLAKSICEDataAdapter().Fill((OLAKSICEDataSet) dataSet, Conversions.ToInteger(row["IDOLAKSICE"]));
        }
    }
}

