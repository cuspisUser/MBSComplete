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

    public class TIPIRAWorkWithController : WorkWithControllerBase<TIPIRAWorkItem, TIPIRADataSet>
    {
        public TIPIRADataSet.TIPIRARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetTIPIRADataAdapter().Fill((TIPIRADataSet) dataSet, Conversions.ToInteger(row["IDTIPIRA"]));
        }

        [LocalCommandHandler("IRA")]
        public void ShowIRA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                IRAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<IRAWorkWithWorkItem>("Placa.IRAFillByIDTIPIRA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<IRAWorkWithWorkItem>("Placa.IRAFillByIDTIPIRA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDTIPIRA", this.CurrentRow);
            }
        }
    }
}

