namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class OBRACUNWorkWithController : WorkWithControllerBase<OBRACUNWorkItem, OBRACUNDataSet>
    {
        public OBRACUNDataSet.OBRACUNRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetOBRACUNDataAdapter().Fill((OBRACUNDataSet) dataSet, Conversions.ToString(row["IDOBRACUN"]));
        }

        [LocalCommandHandler("RSMA")]
        public void ShowRSMA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RSMAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RSMAWorkWithWorkItem>("Placa.RSMAFillByIDOBRACUN");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RSMAWorkWithWorkItem>("Placa.RSMAFillByIDOBRACUN");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDOBRACUN", this.CurrentRow);
            }
        }
    }
}

