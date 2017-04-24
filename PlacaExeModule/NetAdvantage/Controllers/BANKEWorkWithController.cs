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

    public class BANKEWorkWithController : WorkWithControllerBase<BANKEWorkItem, BANKEDataSet>
    {
        public BANKEDataSet.BANKERow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetBANKEDataAdapter().Fill((BANKEDataSet) dataSet, Conversions.ToInteger(row["IDBANKE"]));
        }

        [LocalCommandHandler("DDRADNIK")]
        public void ShowDDRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                DDRADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<DDRADNIKWorkWithWorkItem>("Placa.DDRADNIKFillByIDBANKE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<DDRADNIKWorkWithWorkItem>("Placa.DDRADNIKFillByIDBANKE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDBANKE", this.CurrentRow);
            }
        }

        [LocalCommandHandler("RADNIK")]
        public void ShowRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDBANKE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDBANKE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDBANKE", this.CurrentRow);
            }
        }
    }
}

