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

    public class RADNOVRIJEMEWorkWithController : WorkWithControllerBase<RADNOVRIJEMEWorkItem, RADNOVRIJEMEDataSet>
    {
        public RADNOVRIJEMEDataSet.RADNOVRIJEMERow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetRADNOVRIJEMEDataAdapter().Fill((RADNOVRIJEMEDataSet) dataSet, Conversions.ToInteger(row["IDRADNOVRIJEME"]));
        }

        [LocalCommandHandler("RADNIK")]
        public void ShowRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDRADNOVRIJEME");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByIDRADNOVRIJEME");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDRADNOVRIJEME", this.CurrentRow);
            }
        }
    }
}

