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

    public class AMSKUPINEWorkWithController : WorkWithControllerBase<AMSKUPINEWorkItem, AMSKUPINEDataSet>
    {
        public AMSKUPINEDataSet.AMSKUPINERow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetAMSKUPINEDataAdapter().Fill((AMSKUPINEDataSet) dataSet, Conversions.ToInteger(row["IDAMSKUPINE"]));
        }

        [LocalCommandHandler("OS")]
        public void ShowOS(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                OSWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<OSWorkWithWorkItem>("Placa.OSFillByIDAMSKUPINE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<OSWorkWithWorkItem>("Placa.OSFillByIDAMSKUPINE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDAMSKUPINE", this.CurrentRow);
            }
        }
    }
}

