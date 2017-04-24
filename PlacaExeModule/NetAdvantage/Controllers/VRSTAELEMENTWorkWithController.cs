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

    public class VRSTAELEMENTWorkWithController : WorkWithControllerBase<VRSTAELEMENTWorkItem, VRSTAELEMENTDataSet>
    {
        public VRSTAELEMENTDataSet.VRSTAELEMENTRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetVRSTAELEMENTDataAdapter().Fill((VRSTAELEMENTDataSet) dataSet, Conversions.ToShort(row["IDVRSTAELEMENTA"]));
        }

        [LocalCommandHandler("ELEMENT")]
        public void ShowELEMENT(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                ELEMENTWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<ELEMENTWorkWithWorkItem>("Placa.ELEMENTFillByIDVRSTAELEMENTA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<ELEMENTWorkWithWorkItem>("Placa.ELEMENTFillByIDVRSTAELEMENTA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDVRSTAELEMENTA", this.CurrentRow);
            }
        }
    }
}

