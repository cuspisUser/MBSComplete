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

    public class VRSTAOBUSTAVEWorkWithController : WorkWithControllerBase<VRSTAOBUSTAVEWorkItem, VRSTAOBUSTAVEDataSet>
    {
        public VRSTAOBUSTAVEDataSet.VRSTEOBUSTAVARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetVRSTAOBUSTAVEDataAdapter().Fill((VRSTAOBUSTAVEDataSet) dataSet, Conversions.ToShort(row["VRSTAOBUSTAVE"]));
        }

        [LocalCommandHandler("OBUSTAVA")]
        public void ShowOBUSTAVA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                OBUSTAVAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<OBUSTAVAWorkWithWorkItem>("Placa.OBUSTAVAFillByVRSTAOBUSTAVE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<OBUSTAVAWorkWithWorkItem>("Placa.OBUSTAVAFillByVRSTAOBUSTAVE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByVRSTAOBUSTAVE", this.CurrentRow);
            }
        }
    }
}

