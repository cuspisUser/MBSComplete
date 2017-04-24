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

    public class IPIDENTWorkWithController : WorkWithControllerBase<IPIDENTWorkItem, IPIDENTDataSet>
    {
        public IPIDENTDataSet.IPIDENTRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetIPIDENTDataAdapter().Fill((IPIDENTDataSet) dataSet, Conversions.ToInteger(row["IDIPIDENT"]));
        }

        [LocalCommandHandler("RADNIK")]
        public void ShowRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDIPIDENT");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDIPIDENT");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDIPIDENT", this.CurrentRow);
            }
        }
    }
}

