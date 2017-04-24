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

    public class ORGDIOWorkWithController : WorkWithControllerBase<ORGDIOWorkItem, ORGDIODataSet>
    {
        public ORGDIODataSet.ORGDIORow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetORGDIODataAdapter().Fill((ORGDIODataSet) dataSet, Conversions.ToInteger(row["IDORGDIO"]));
        }

        [LocalCommandHandler("RADNIK")]
        public void ShowRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDORGDIO");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDORGDIO");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDORGDIO", this.CurrentRow);
            }
        }
    }
}

