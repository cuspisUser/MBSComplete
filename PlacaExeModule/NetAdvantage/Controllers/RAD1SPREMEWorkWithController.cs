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

    public class RAD1SPREMEWorkWithController : WorkWithControllerBase<RAD1SPREMEWorkItem, RAD1SPREMEDataSet>
    {
        public RAD1SPREMEDataSet.RAD1SPREMERow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetRAD1SPREMEDataAdapter().Fill((RAD1SPREMEDataSet) dataSet, Conversions.ToInteger(row["RAD1IDSPREME"]));
        }

        [LocalCommandHandler("RAD1SPREMEVEZA")]
        public void ShowRAD1SPREMEVEZA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RAD1SPREMEVEZAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RAD1SPREMEVEZAWorkWithWorkItem>("Placa.RAD1SPREMEVEZAFillByRAD1IDSPREME");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RAD1SPREMEVEZAWorkWithWorkItem>("Placa.RAD1SPREMEVEZAFillByRAD1IDSPREME");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByRAD1IDSPREME", this.CurrentRow);
            }
        }
    }
}

