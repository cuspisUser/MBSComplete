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

    public class PARTNERWorkWithController : WorkWithControllerBase<PARTNERWorkItem, PARTNERDataSet>
    {
        public PARTNERDataSet.PARTNERRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetPARTNERDataAdapter().Fill((PARTNERDataSet) dataSet, Conversions.ToInteger(row["IDPARTNER"]));
        }

        [LocalCommandHandler("GKSTAVKA")]
        public void ShowGKSTAVKA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                GKSTAVKAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<GKSTAVKAWorkWithWorkItem>("Placa.GKSTAVKAFillByIDPARTNER");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<GKSTAVKAWorkWithWorkItem>("Placa.GKSTAVKAFillByIDPARTNER");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDPARTNER", this.CurrentRow);
            }
        }

        [LocalCommandHandler("IRA")]
        public void ShowIRA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                IRAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<IRAWorkWithWorkItem>("Placa.IRAFillByIRAPARTNERIDPARTNER");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<IRAWorkWithWorkItem>("Placa.IRAFillByIRAPARTNERIDPARTNER");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIRAPARTNERIDPARTNER", this.CurrentRow);
            }
        }

        [LocalCommandHandler("RACUN")]
        public void ShowRACUN(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RACUNWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RACUNWorkWithWorkItem>("Placa.RACUNFillByIDPARTNER");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RACUNWorkWithWorkItem>("Placa.RACUNFillByIDPARTNER");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDPARTNER", this.CurrentRow);
            }
        }

        [LocalCommandHandler("SHEMAURA")]
        public void ShowSHEMAURA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                SHEMAURAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<SHEMAURAWorkWithWorkItem>("Placa.SHEMAURAFillByPARTNERSHEMAURAIDPARTNER");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<SHEMAURAWorkWithWorkItem>("Placa.SHEMAURAFillByPARTNERSHEMAURAIDPARTNER");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByPARTNERSHEMAURAIDPARTNER", this.CurrentRow);
            }
        }

        [LocalCommandHandler("URA")]
        public void ShowURA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                URAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<URAWorkWithWorkItem>("Placa.URAFillByurapartnerIDPARTNER");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<URAWorkWithWorkItem>("Placa.URAFillByurapartnerIDPARTNER");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByurapartnerIDPARTNER", this.CurrentRow);
            }
        }
    }
}

