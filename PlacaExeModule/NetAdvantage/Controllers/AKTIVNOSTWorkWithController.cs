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

    public class AKTIVNOSTWorkWithController : WorkWithControllerBase<AKTIVNOSTWorkItem, AKTIVNOSTDataSet>
    {
        public AKTIVNOSTDataSet.AKTIVNOSTRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetAKTIVNOSTDataAdapter().Fill((AKTIVNOSTDataSet) dataSet, Conversions.ToInteger(row["IDAKTIVNOST"]));
        }

        [LocalCommandHandler("KONTO")]
        public void ShowKONTO(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                KONTOWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<KONTOWorkWithWorkItem>("Placa.KONTOFillByIDAKTIVNOST");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<KONTOWorkWithWorkItem>("Placa.KONTOFillByIDAKTIVNOST");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDAKTIVNOST", this.CurrentRow);
            }
        }
    }
}

