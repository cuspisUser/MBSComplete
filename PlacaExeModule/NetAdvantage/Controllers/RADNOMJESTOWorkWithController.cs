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

    public class RADNOMJESTOWorkWithController : WorkWithControllerBase<RADNOMJESTOWorkItem, RADNOMJESTODataSet>
    {
        public RADNOMJESTODataSet.RADNOMJESTORow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetRADNOMJESTODataAdapter().Fill((RADNOMJESTODataSet) dataSet, Conversions.ToInteger(row["IDRADNOMJESTO"]));
        }

        [LocalCommandHandler("RADNIK")]
        public void ShowRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDRADNOMJESTO");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDRADNOMJESTO");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDRADNOMJESTO", this.CurrentRow);
            }
        }
    }
}

