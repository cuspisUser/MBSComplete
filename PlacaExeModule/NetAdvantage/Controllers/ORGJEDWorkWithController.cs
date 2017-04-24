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

    public class ORGJEDWorkWithController : WorkWithControllerBase<ORGJEDWorkItem, ORGJEDDataSet>
    {
        public ORGJEDDataSet.ORGJEDRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetORGJEDDataAdapter().Fill((ORGJEDDataSet) dataSet, Conversions.ToInteger(row["IDORGJED"]));
        }

        [LocalCommandHandler("GKSTAVKA")]
        public void ShowGKSTAVKA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                GKSTAVKAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<GKSTAVKAWorkWithWorkItem>("Placa.GKSTAVKAFillByIDORGJED");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<GKSTAVKAWorkWithWorkItem>("Placa.GKSTAVKAFillByIDORGJED");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDORGJED", this.CurrentRow);
            }
        }

        [LocalCommandHandler("SHEMADD")]
        public void ShowSHEMADD(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                SHEMADDWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<SHEMADDWorkWithWorkItem>("Placa.SHEMADDFillBySHEMADDOJIDORGJED");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<SHEMADDWorkWithWorkItem>("Placa.SHEMADDFillBySHEMADDOJIDORGJED");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillBySHEMADDOJIDORGJED", this.CurrentRow);
            }
        }

        [LocalCommandHandler("SHEMAPLACA")]
        public void ShowSHEMAPLACA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                SHEMAPLACAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<SHEMAPLACAWorkWithWorkItem>("Placa.SHEMAPLACAFillBySHEMAPLOJIDORGJED");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<SHEMAPLACAWorkWithWorkItem>("Placa.SHEMAPLACAFillBySHEMAPLOJIDORGJED");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillBySHEMAPLOJIDORGJED", this.CurrentRow);
            }
        }
    }
}

