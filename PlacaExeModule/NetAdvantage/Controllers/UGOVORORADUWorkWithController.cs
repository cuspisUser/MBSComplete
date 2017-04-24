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

    public class UGOVORORADUWorkWithController : WorkWithControllerBase<UGOVORORADUWorkItem, UGOVORORADUDataSet>
    {
        public UGOVORORADUDataSet.UGOVORORADURow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetUGOVORORADUDataAdapter().Fill((UGOVORORADUDataSet) dataSet, Conversions.ToInteger(row["IDUGOVORORADU"]));
        }

        [LocalCommandHandler("RADNIK")]
        public void ShowRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDUGOVORORADU");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDUGOVORORADU");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDUGOVORORADU", this.CurrentRow);
            }
        }
    }
}

