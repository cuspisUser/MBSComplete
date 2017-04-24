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

    public class UCENIKRSMIDENTWorkWithController : WorkWithControllerBase<UCENIKRSMIDENTWorkItem, UCENIKRSMIDENTDataSet>
    {
        public UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetUCENIKRSMIDENTDataAdapter().Fill((UCENIKRSMIDENTDataSet) dataSet, Conversions.ToString(row["UCENIKRSMIDENT"]));
        }
    }
}

