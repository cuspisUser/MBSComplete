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

    public class LOKACIJEWorkWithController : WorkWithControllerBase<LOKACIJEWorkItem, LOKACIJEDataSet>
    {
        public LOKACIJEDataSet.LOKACIJERow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetLOKACIJEDataAdapter().Fill((LOKACIJEDataSet) dataSet, Conversions.ToInteger(row["IDLOKACIJE"]));
        }

        [LocalCommandHandler("OSRAZMJESTAJ")]
        public void ShowOSRAZMJESTAJ(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                OSRAZMJESTAJWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<OSRAZMJESTAJWorkWithWorkItem>("Placa.OSRAZMJESTAJFillByIDLOKACIJE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<OSRAZMJESTAJWorkWithWorkItem>("Placa.OSRAZMJESTAJFillByIDLOKACIJE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDLOKACIJE", this.CurrentRow);
            }
        }
    }
}

