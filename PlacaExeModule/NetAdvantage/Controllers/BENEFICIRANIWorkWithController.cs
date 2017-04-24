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

    public class BENEFICIRANIWorkWithController : WorkWithControllerBase<BENEFICIRANIWorkItem, BENEFICIRANIDataSet>
    {
        public BENEFICIRANIDataSet.BENEFICIRANIRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetBENEFICIRANIDataAdapter().Fill((BENEFICIRANIDataSet) dataSet, Conversions.ToString(row["IDBENEFICIRANI"]));
        }

        [LocalCommandHandler("RADNIK")]
        public void ShowRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDBENEFICIRANI");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDBENEFICIRANI");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDBENEFICIRANI", this.CurrentRow);
            }
        }
    }
}

