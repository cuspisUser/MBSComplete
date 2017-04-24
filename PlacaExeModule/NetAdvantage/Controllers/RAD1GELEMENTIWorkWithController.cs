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

    public class RAD1GELEMENTIWorkWithController : WorkWithControllerBase<RAD1GELEMENTIWorkItem, RAD1GELEMENTIDataSet>
    {
        public RAD1GELEMENTIDataSet.RAD1GELEMENTIRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetRAD1GELEMENTIDataAdapter().Fill((RAD1GELEMENTIDataSet) dataSet, Conversions.ToInteger(row["RAD1GELEMENTIID"]));
        }

        [LocalCommandHandler("RAD1GELEMENTIVEZA")]
        public void ShowRAD1GELEMENTIVEZA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RAD1GELEMENTIVEZAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RAD1GELEMENTIVEZAWorkWithWorkItem>("Placa.RAD1GELEMENTIVEZAFillByRAD1GELEMENTIID");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RAD1GELEMENTIVEZAWorkWithWorkItem>("Placa.RAD1GELEMENTIVEZAFillByRAD1GELEMENTIID");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByRAD1GELEMENTIID", this.CurrentRow);
            }
        }
    }
}

