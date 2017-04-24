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

    public class SPOLWorkWithController : WorkWithControllerBase<SPOLWorkItem, SPOLDataSet>
    {
        public SPOLDataSet.SPOLRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetSPOLDataAdapter().Fill((SPOLDataSet) dataSet, Conversions.ToInteger(row["IDSPOL"]));
        }

        [LocalCommandHandler("RAD1VEZASPOL")]
        public void ShowRAD1VEZASPOL(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RAD1VEZASPOLWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RAD1VEZASPOLWorkWithWorkItem>("Placa.RAD1VEZASPOLFillByIDSPOL");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RAD1VEZASPOLWorkWithWorkItem>("Placa.RAD1VEZASPOLFillByIDSPOL");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDSPOL", this.CurrentRow);
            }
        }

        [LocalCommandHandler("RADNIK")]
        public void ShowRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDSPOL");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDSPOL");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDSPOL", this.CurrentRow);
            }
        }
    }
}

