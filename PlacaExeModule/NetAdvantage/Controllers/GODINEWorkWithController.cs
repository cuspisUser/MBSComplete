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

    public class GODINEWorkWithController : WorkWithControllerBase<GODINEWorkItem, GODINEDataSet>
    {
        public GODINEDataSet.GODINERow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetGODINEDataAdapter().Fill((GODINEDataSet) dataSet, Conversions.ToShort(row["IDGODINE"]));
        }

        [LocalCommandHandler("EVIDENCIJA")]
        public void ShowEVIDENCIJA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                EVIDENCIJAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<EVIDENCIJAWorkWithWorkItem>("Placa.EVIDENCIJAFillByIDGODINE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<EVIDENCIJAWorkWithWorkItem>("Placa.EVIDENCIJAFillByIDGODINE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDGODINE", this.CurrentRow);
            }
        }

        [LocalCommandHandler("GKSTAVKA")]
        public void ShowGKSTAVKA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                GKSTAVKAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<GKSTAVKAWorkWithWorkItem>("Placa.GKSTAVKAFillByGKGODIDGODINE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<GKSTAVKAWorkWithWorkItem>("Placa.GKSTAVKAFillByGKGODIDGODINE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByGKGODIDGODINE", this.CurrentRow);
            }
        }

        [LocalCommandHandler("IRA")]
        public void ShowIRA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                IRAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<IRAWorkWithWorkItem>("Placa.IRAFillByIRAGODIDGODINE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<IRAWorkWithWorkItem>("Placa.IRAFillByIRAGODIDGODINE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIRAGODIDGODINE", this.CurrentRow);
            }
        }

        [LocalCommandHandler("PLAN")]
        public void ShowPLAN(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                PLANWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<PLANWorkWithWorkItem>("Placa.PLANFillByPLANGODINAIDGODINE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<PLANWorkWithWorkItem>("Placa.PLANFillByPLANGODINAIDGODINE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByPLANGODINAIDGODINE", this.CurrentRow);
            }
        }

        [LocalCommandHandler("RACUN")]
        public void ShowRACUN(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RACUNWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RACUNWorkWithWorkItem>("Placa.RACUNFillByRACUNGODINAIDGODINE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RACUNWorkWithWorkItem>("Placa.RACUNFillByRACUNGODINAIDGODINE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByRACUNGODINAIDGODINE", this.CurrentRow);
            }
        }

        [LocalCommandHandler("URA")]
        public void ShowURA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                URAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<URAWorkWithWorkItem>("Placa.URAFillByURAGODIDGODINE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<URAWorkWithWorkItem>("Placa.URAFillByURAGODIDGODINE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByURAGODIDGODINE", this.CurrentRow);
            }
        }
    }
}

