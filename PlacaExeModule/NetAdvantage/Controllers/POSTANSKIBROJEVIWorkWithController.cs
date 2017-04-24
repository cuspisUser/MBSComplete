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

    public class POSTANSKIBROJEVIWorkWithController : WorkWithControllerBase<POSTANSKIBROJEVIWorkItem, POSTANSKIBROJEVIDataSet>
    {
        public POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetPOSTANSKIBROJEVIDataAdapter().Fill((POSTANSKIBROJEVIDataSet) dataSet, Conversions.ToString(row["POSTANSKIBROJ"]));
        }

        [LocalCommandHandler("UCENIK")]
        public void ShowUCENIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                UCENIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<UCENIKWorkWithWorkItem>("Placa.UCENIKFillByPOSTANSKIBROJ");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<UCENIKWorkWithWorkItem>("Placa.UCENIKFillByPOSTANSKIBROJ");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByPOSTANSKIBROJ", this.CurrentRow);
            }
        }
    }
}

