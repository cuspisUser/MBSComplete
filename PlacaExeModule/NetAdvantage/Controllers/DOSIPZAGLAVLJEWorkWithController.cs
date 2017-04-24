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

    public class DOSIPZAGLAVLJEWorkWithController : WorkWithControllerBase<DOSIPZAGLAVLJEWorkItem, DOSIPZAGLAVLJEDataSet>
    {
        public DOSIPZAGLAVLJEDataSet.DOSIPZAGLAVLJERow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetDOSIPZAGLAVLJEDataAdapter().Fill((DOSIPZAGLAVLJEDataSet) dataSet, Conversions.ToString(row["DOSIPIDENT"]), Conversions.ToString(row["DOSJMBG"]));
        }
    }
}

