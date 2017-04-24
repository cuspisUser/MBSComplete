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

    public class DRZAVLJANSTVOWorkWithController : WorkWithControllerBase<DRZAVLJANSTVOWorkItem, DRZAVLJANSTVODataSet>
    {
        public DRZAVLJANSTVODataSet.DRZAVLJANSTVORow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetDRZAVLJANSTVODataAdapter().Fill((DRZAVLJANSTVODataSet) dataSet, Conversions.ToInteger(row["IDDRZAVLJANSTVO"]));
        }

        [LocalCommandHandler("RADNIK")]
        public void ShowRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDDRZAVLJANSTVO");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDDRZAVLJANSTVO");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDDRZAVLJANSTVO", this.CurrentRow);
            }
        }
    }
}

