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

    public class OSVRSTAWorkWithController : WorkWithControllerBase<OSVRSTAWorkItem, OSVRSTADataSet>
    {
        public OSVRSTADataSet.OSVRSTARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetOSVRSTADataAdapter().Fill((OSVRSTADataSet) dataSet, Conversions.ToInteger(row["IDOSVRSTA"]));
        }

        [LocalCommandHandler("OS")]
        public void ShowOS(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                OSWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<OSWorkWithWorkItem>("Placa.OSFillByIDOSVRSTA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<OSWorkWithWorkItem>("Placa.OSFillByIDOSVRSTA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDOSVRSTA", this.CurrentRow);
            }
        }
    }
}

