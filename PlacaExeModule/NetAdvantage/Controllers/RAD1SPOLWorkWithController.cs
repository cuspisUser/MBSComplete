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

    public class RAD1SPOLWorkWithController : WorkWithControllerBase<RAD1SPOLWorkItem, RAD1SPOLDataSet>
    {
        public RAD1SPOLDataSet.RAD1SPOLRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetRAD1SPOLDataAdapter().Fill((RAD1SPOLDataSet) dataSet, Conversions.ToInteger(row["RAD1SPOLID"]));
        }

        [LocalCommandHandler("RAD1VEZASPOL")]
        public void ShowRAD1VEZASPOL(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RAD1VEZASPOLWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RAD1VEZASPOLWorkWithWorkItem>("Placa.RAD1VEZASPOLFillByRAD1SPOLID");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RAD1VEZASPOLWorkWithWorkItem>("Placa.RAD1VEZASPOLFillByRAD1SPOLID");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByRAD1SPOLID", this.CurrentRow);
            }
        }
    }
}

