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

    public class DDKOLONAIDDWorkWithController : WorkWithControllerBase<DDKOLONAIDDWorkItem, DDKOLONAIDDDataSet>
    {
        public DDKOLONAIDDDataSet.DDKOLONAIDDRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetDDKOLONAIDDDataAdapter().Fill((DDKOLONAIDDDataSet) dataSet, Conversions.ToInteger(row["IDKOLONAIDD"]));
        }

        [LocalCommandHandler("DDKATEGORIJA")]
        public void ShowDDKATEGORIJA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                DDKATEGORIJAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<DDKATEGORIJAWorkWithWorkItem>("Placa.DDKATEGORIJAFillByIDKOLONAIDD");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<DDKATEGORIJAWorkWithWorkItem>("Placa.DDKATEGORIJAFillByIDKOLONAIDD");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDKOLONAIDD", this.CurrentRow);
            }
        }
    }
}

