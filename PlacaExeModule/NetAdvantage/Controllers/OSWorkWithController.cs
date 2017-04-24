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

    public class OSWorkWithController : WorkWithControllerBase<OSWorkItem, OSDataSet>
    {
        public OSDataSet.OSRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetOSDataAdapter().Fill((OSDataSet) dataSet, Conversions.ToLong(row["INVBROJ"]));
        }

        [LocalCommandHandler("OSRAZMJESTAJ")]
        public void ShowOSRAZMJESTAJ(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                OSRAZMJESTAJWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<OSRAZMJESTAJWorkWithWorkItem>("Placa.OSRAZMJESTAJFillByINVBROJ");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<OSRAZMJESTAJWorkWithWorkItem>("Placa.OSRAZMJESTAJFillByINVBROJ");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByINVBROJ", this.CurrentRow);
            }
        }
    }
}

