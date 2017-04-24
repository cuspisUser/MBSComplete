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

    public class OSNOVAOSIGURANJAWorkWithController : WorkWithControllerBase<OSNOVAOSIGURANJAWorkItem, OSNOVAOSIGURANJADataSet>
    {
        public OSNOVAOSIGURANJADataSet.OSNOVAOSIGURANJARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetOSNOVAOSIGURANJADataAdapter().Fill((OSNOVAOSIGURANJADataSet) dataSet, Conversions.ToString(row["IDOSNOVAOSIGURANJA"]));
        }

        [LocalCommandHandler("ELEMENT")]
        public void ShowELEMENT(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                ELEMENTWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<ELEMENTWorkWithWorkItem>("Placa.ELEMENTFillByIDOSNOVAOSIGURANJA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<ELEMENTWorkWithWorkItem>("Placa.ELEMENTFillByIDOSNOVAOSIGURANJA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDOSNOVAOSIGURANJA", this.CurrentRow);
            }
        }
    }
}

