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

    public class RADNIKWorkWithController : WorkWithControllerBase<RADNIKWorkItem, RADNIKDataSet>
    {
        public RADNIKDataSet.RADNIKRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetRADNIKDataAdapter().Fill((RADNIKDataSet) dataSet, Conversions.ToInteger(row["IDRADNIK"]));
        }

        [LocalCommandHandler("GOOBRACUN")]
        public void ShowGOOBRACUN(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                GOOBRACUNWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<GOOBRACUNWorkWithWorkItem>("Placa.GOOBRACUNFillByIDRADNIK");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<GOOBRACUNWorkWithWorkItem>("Placa.GOOBRACUNFillByIDRADNIK");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDRADNIK", this.CurrentRow);
            }
        }

        [LocalCommandHandler("OTISLI")]
        public void ShowOTISLI(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                OTISLIWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<OTISLIWorkWithWorkItem>("Placa.OTISLIFillByIDRADNIK");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<OTISLIWorkWithWorkItem>("Placa.OTISLIFillByIDRADNIK");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDRADNIK", this.CurrentRow);
            }
        }

        [LocalCommandHandler("ZAPOSLENI")]
        public void ShowZAPOSLENI(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                ZAPOSLENIWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<ZAPOSLENIWorkWithWorkItem>("Placa.ZAPOSLENIFillByIDRADNIK");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<ZAPOSLENIWorkWithWorkItem>("Placa.ZAPOSLENIFillByIDRADNIK");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDRADNIK", this.CurrentRow);
            }
        }
    }
}

