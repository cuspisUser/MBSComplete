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

    public class GKSTAVKAWorkWithController : WorkWithControllerBase<GKSTAVKAWorkItem, GKSTAVKADataSet>
    {
        public GKSTAVKADataSet.GKSTAVKARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetGKSTAVKADataAdapter().Fill((GKSTAVKADataSet) dataSet, Conversions.ToInteger(row["IDGKSTAVKA"]));
        }

        [LocalCommandHandler("ZATVARANJA")]
        public void ShowZATVARANJA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                ZATVARANJAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<ZATVARANJAWorkWithWorkItem>("Placa.ZATVARANJAFillByGK2IDGKSTAVKA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<ZATVARANJAWorkWithWorkItem>("Placa.ZATVARANJAFillByGK2IDGKSTAVKA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByGK2IDGKSTAVKA", this.CurrentRow);
            }
        }

        [LocalCommandHandler("ZATVARANJA1")]
        public void ShowZATVARANJA1(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                ZATVARANJAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<ZATVARANJAWorkWithWorkItem>("Placa.ZATVARANJAFillByGK1IDGKSTAVKA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<ZATVARANJAWorkWithWorkItem>("Placa.ZATVARANJAFillByGK1IDGKSTAVKA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByGK1IDGKSTAVKA", this.CurrentRow);
            }
        }
    }
}

