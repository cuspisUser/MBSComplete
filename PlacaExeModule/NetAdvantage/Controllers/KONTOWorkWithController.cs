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

    public class KONTOWorkWithController : WorkWithControllerBase<KONTOWorkItem, KONTODataSet>
    {
        public KONTODataSet.KONTORow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetKONTODataAdapter().Fill((KONTODataSet) dataSet, Conversions.ToString(row["IDKONTO"]));
        }

        [LocalCommandHandler("AMSKUPINE")]
        public void ShowAMSKUPINE(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                AMSKUPINEWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<AMSKUPINEWorkWithWorkItem>("Placa.AMSKUPINEFillByKTOIZVORAIDKONTO");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<AMSKUPINEWorkWithWorkItem>("Placa.AMSKUPINEFillByKTOIZVORAIDKONTO");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByKTOIZVORAIDKONTO", this.CurrentRow);
            }
        }

        [LocalCommandHandler("AMSKUPINE1")]
        public void ShowAMSKUPINE1(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                AMSKUPINEWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<AMSKUPINEWorkWithWorkItem>("Placa.AMSKUPINEFillByKTOISPRAVKAIDKONTO");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<AMSKUPINEWorkWithWorkItem>("Placa.AMSKUPINEFillByKTOISPRAVKAIDKONTO");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByKTOISPRAVKAIDKONTO", this.CurrentRow);
            }
        }

        [LocalCommandHandler("AMSKUPINE2")]
        public void ShowAMSKUPINE2(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                AMSKUPINEWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<AMSKUPINEWorkWithWorkItem>("Placa.AMSKUPINEFillByKTONABAVKEIDKONTO");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<AMSKUPINEWorkWithWorkItem>("Placa.AMSKUPINEFillByKTONABAVKEIDKONTO");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByKTONABAVKEIDKONTO", this.CurrentRow);
            }
        }

        [LocalCommandHandler("BLAGAJNA")]
        public void ShowBLAGAJNA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                BLAGAJNAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<BLAGAJNAWorkWithWorkItem>("Placa.BLAGAJNAFillByBLGKONTOIDKONTO");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<BLAGAJNAWorkWithWorkItem>("Placa.BLAGAJNAFillByBLGKONTOIDKONTO");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByBLGKONTOIDKONTO", this.CurrentRow);
            }
        }

        [LocalCommandHandler("GKSTAVKA")]
        public void ShowGKSTAVKA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                GKSTAVKAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<GKSTAVKAWorkWithWorkItem>("Placa.GKSTAVKAFillByIDKONTO");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<GKSTAVKAWorkWithWorkItem>("Placa.GKSTAVKAFillByIDKONTO");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDKONTO", this.CurrentRow);
            }
        }
    }
}

