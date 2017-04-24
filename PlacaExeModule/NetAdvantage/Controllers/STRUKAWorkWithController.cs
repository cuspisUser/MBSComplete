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

    public class STRUKAWorkWithController : WorkWithControllerBase<STRUKAWorkItem, STRUKADataSet>
    {
        public STRUKADataSet.STRUKARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetSTRUKADataAdapter().Fill((STRUKADataSet) dataSet, Conversions.ToInteger(row["IDSTRUKA"]));
        }

        [LocalCommandHandler("RADNIK")]
        public void ShowRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDSTRUKA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDSTRUKA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDSTRUKA", this.CurrentRow);
            }
        }
    }
}

