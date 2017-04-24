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

    public class MJESTOTROSKAWorkWithController : WorkWithControllerBase<MJESTOTROSKAWorkItem, MJESTOTROSKADataSet>
    {
        public MJESTOTROSKADataSet.MJESTOTROSKARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill((MJESTOTROSKADataSet) dataSet, Conversions.ToInteger(row["IDMJESTOTROSKA"]));
        }

        [LocalCommandHandler("GKSTAVKA")]
        public void ShowGKSTAVKA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                GKSTAVKAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<GKSTAVKAWorkWithWorkItem>("Placa.GKSTAVKAFillByIDMJESTOTROSKA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<GKSTAVKAWorkWithWorkItem>("Placa.GKSTAVKAFillByIDMJESTOTROSKA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDMJESTOTROSKA", this.CurrentRow);
            }
        }
    }
}

