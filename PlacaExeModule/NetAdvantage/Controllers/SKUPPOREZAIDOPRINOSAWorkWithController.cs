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

    public class SKUPPOREZAIDOPRINOSAWorkWithController : WorkWithControllerBase<SKUPPOREZAIDOPRINOSAWorkItem, SKUPPOREZAIDOPRINOSADataSet>
    {
        public SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetSKUPPOREZAIDOPRINOSADataAdapter().Fill((SKUPPOREZAIDOPRINOSADataSet) dataSet, Conversions.ToInteger(row["IDSKUPPOREZAIDOPRINOSA"]));
        }

        [LocalCommandHandler("RADNIK")]
        public void ShowRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", this.CurrentRow);
            }
        }
    }
}

