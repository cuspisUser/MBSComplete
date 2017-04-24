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

    public class STRUCNASPREMAWorkWithController : WorkWithControllerBase<STRUCNASPREMAWorkItem, STRUCNASPREMADataSet>
    {
        public STRUCNASPREMADataSet.STRUCNASPREMARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetSTRUCNASPREMADataAdapter().Fill((STRUCNASPREMADataSet) dataSet, Conversions.ToInteger(row["IDSTRUCNASPREMA"]));
        }

        [LocalCommandHandler("RAD1SPREMEVEZA")]
        public void ShowRAD1SPREMEVEZA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RAD1SPREMEVEZAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RAD1SPREMEVEZAWorkWithWorkItem>("Placa.RAD1SPREMEVEZAFillByIDSTRUCNASPREMA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RAD1SPREMEVEZAWorkWithWorkItem>("Placa.RAD1SPREMEVEZAFillByIDSTRUCNASPREMA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDSTRUCNASPREMA", this.CurrentRow);
            }
        }

        [LocalCommandHandler("RADNIK")]
        public void ShowRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", this.CurrentRow);
            }
        }

        [LocalCommandHandler("RADNIK1")]
        public void ShowRADNIK1(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA", this.CurrentRow);
            }
        }
    }
}

