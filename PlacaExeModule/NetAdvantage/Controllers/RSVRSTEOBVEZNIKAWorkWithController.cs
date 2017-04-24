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

    public class RSVRSTEOBVEZNIKAWorkWithController : WorkWithControllerBase<RSVRSTEOBVEZNIKAWorkItem, RSVRSTEOBVEZNIKADataSet>
    {
        public RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetRSVRSTEOBVEZNIKADataAdapter().Fill((RSVRSTEOBVEZNIKADataSet) dataSet, Conversions.ToString(row["IDRSVRSTEOBVEZNIKA"]));
        }

        [LocalCommandHandler("RSMA")]
        public void ShowRSMA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RSMAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RSMAWorkWithWorkItem>("Placa.RSMAFillByIDRSVRSTEOBVEZNIKA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RSMAWorkWithWorkItem>("Placa.RSMAFillByIDRSVRSTEOBVEZNIKA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDRSVRSTEOBVEZNIKA", this.CurrentRow);
            }
        }
    }
}

