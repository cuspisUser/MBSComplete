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

    public class RSVRSTEOBRACUNAWorkWithController : WorkWithControllerBase<RSVRSTEOBRACUNAWorkItem, RSVRSTEOBRACUNADataSet>
    {
        public RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetRSVRSTEOBRACUNADataAdapter().Fill((RSVRSTEOBRACUNADataSet) dataSet, Conversions.ToString(row["IDRSVRSTEOBRACUNA"]));
        }

        [LocalCommandHandler("RSMA")]
        public void ShowRSMA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RSMAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RSMAWorkWithWorkItem>("Placa.RSMAFillByIDRSVRSTEOBRACUNA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RSMAWorkWithWorkItem>("Placa.RSMAFillByIDRSVRSTEOBRACUNA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDRSVRSTEOBRACUNA", this.CurrentRow);
            }
        }
    }
}

