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

    public class RAD1MELEMENTIWorkWithController : WorkWithControllerBase<RAD1MELEMENTIWorkItem, RAD1MELEMENTIDataSet>
    {
        public RAD1MELEMENTIDataSet.RAD1MELEMENTIRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetRAD1MELEMENTIDataAdapter().Fill((RAD1MELEMENTIDataSet) dataSet, Conversions.ToInteger(row["RAD1ELEMENTIID"]));
        }

        [LocalCommandHandler("RAD1MELEMENTIVEZA")]
        public void ShowRAD1MELEMENTIVEZA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RAD1MELEMENTIVEZAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RAD1MELEMENTIVEZAWorkWithWorkItem>("Placa.RAD1MELEMENTIVEZAFillByRAD1ELEMENTIID");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RAD1MELEMENTIVEZAWorkWithWorkItem>("Placa.RAD1MELEMENTIVEZAFillByRAD1ELEMENTIID");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByRAD1ELEMENTIID", this.CurrentRow);
            }
        }
    }
}

