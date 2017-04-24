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

    public class BRACNOSTANJEWorkWithController : WorkWithControllerBase<BRACNOSTANJEWorkItem, BRACNOSTANJEDataSet>
    {
        public BRACNOSTANJEDataSet.BRACNOSTANJERow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetBRACNOSTANJEDataAdapter().Fill((BRACNOSTANJEDataSet) dataSet, Conversions.ToInteger(row["IDBRACNOSTANJE"]));
        }

        [LocalCommandHandler("RADNIK")]
        public void ShowRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDBRACNOSTANJE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDBRACNOSTANJE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDBRACNOSTANJE", this.CurrentRow);
            }
        }
    }
}

