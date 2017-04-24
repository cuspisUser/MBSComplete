namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using NetAdvantage.WorkItems;

    public class MZOSTABLICEWorkWithController : WorkWithControllerBase<MZOSTABLICEWorkItem, MZOSTABLICEDataSet>
    {
        public MZOSTABLICEDataSet.MZOSTABLICERow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetMZOSTABLICEDataAdapter().Fill((MZOSTABLICEDataSet) dataSet, Conversions.ToInteger(row["IDMZOSTABLICE"]));
        }
    }
}

