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

    public class DOKUMENTWorkWithController : WorkWithControllerBase<DOKUMENTWorkItem, DOKUMENTDataSet>
    {
        public DOKUMENTDataSet.DOKUMENTRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetDOKUMENTDataAdapter().Fill((DOKUMENTDataSet) dataSet, Conversions.ToInteger(row["IDDOKUMENT"]));
        }

        [LocalCommandHandler("BLAGAJNA")]
        public void ShowBLAGAJNA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                BLAGAJNAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<BLAGAJNAWorkWithWorkItem>("Placa.BLAGAJNAFillByBLGDOKIDDOKUMENT");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<BLAGAJNAWorkWithWorkItem>("Placa.BLAGAJNAFillByBLGDOKIDDOKUMENT");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByBLGDOKIDDOKUMENT", this.CurrentRow);
            }
        }

        [LocalCommandHandler("GKSTAVKA")]
        public void ShowGKSTAVKA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                GKSTAVKAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<GKSTAVKAWorkWithWorkItem>("Placa.GKSTAVKAFillByIDDOKUMENT");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<GKSTAVKAWorkWithWorkItem>("Placa.GKSTAVKAFillByIDDOKUMENT");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDDOKUMENT", this.CurrentRow);
            }
        }

        [LocalCommandHandler("IRA")]
        public void ShowIRA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                IRAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<IRAWorkWithWorkItem>("Placa.IRAFillByIRADOKIDDOKUMENT");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<IRAWorkWithWorkItem>("Placa.IRAFillByIRADOKIDDOKUMENT");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIRADOKIDDOKUMENT", this.CurrentRow);
            }
        }

        [LocalCommandHandler("SHEMAIRA")]
        public void ShowSHEMAIRA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                SHEMAIRAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<SHEMAIRAWorkWithWorkItem>("Placa.SHEMAIRAFillBySHEMAIRADOKIDDOKUMENT");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<SHEMAIRAWorkWithWorkItem>("Placa.SHEMAIRAFillBySHEMAIRADOKIDDOKUMENT");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillBySHEMAIRADOKIDDOKUMENT", this.CurrentRow);
            }
        }

        [LocalCommandHandler("URA")]
        public void ShowURA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                URAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<URAWorkWithWorkItem>("Placa.URAFillByURADOKIDDOKUMENT");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<URAWorkWithWorkItem>("Placa.URAFillByURADOKIDDOKUMENT");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByURADOKIDDOKUMENT", this.CurrentRow);
            }
        }
    }
}

