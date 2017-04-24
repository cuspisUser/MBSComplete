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

    public class TIPURAWorkWithController : WorkWithControllerBase<TIPURAWorkItem, TIPURADataSet>
    {
        public TIPURADataSet.TIPURARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetTIPURADataAdapter().Fill((TIPURADataSet) dataSet, Conversions.ToInteger(row["IDTIPURA"]));
        }

        [LocalCommandHandler("URA")]
        public void ShowURA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                URAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<URAWorkWithWorkItem>("Placa.URAFillByIDTIPURA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<URAWorkWithWorkItem>("Placa.URAFillByIDTIPURA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDTIPURA", this.CurrentRow);
            }
        }
    }
}

