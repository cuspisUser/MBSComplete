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

    public class TITULAWorkWithController : WorkWithControllerBase<TITULAWorkItem, TITULADataSet>
    {
        public TITULADataSet.TITULARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetTITULADataAdapter().Fill((TITULADataSet) dataSet, Conversions.ToInteger(row["IDTITULA"]));
        }

        [LocalCommandHandler("RADNIK")]
        public void ShowRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDTITULA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDTITULA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDTITULA", this.CurrentRow);
            }
        }
    }
}

