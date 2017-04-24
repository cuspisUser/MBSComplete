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

    public class TIPDOKUMENTAWorkWithController : WorkWithControllerBase<TIPDOKUMENTAWorkItem, TIPDOKUMENTADataSet>
    {
        public TIPDOKUMENTADataSet.TIPDOKUMENTARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetTIPDOKUMENTADataAdapter().Fill((TIPDOKUMENTADataSet) dataSet, Conversions.ToInteger(row["IDTIPDOKUMENTA"]));
        }

        [LocalCommandHandler("DOKUMENT")]
        public void ShowDOKUMENT(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                DOKUMENTWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<DOKUMENTWorkWithWorkItem>("Placa.DOKUMENTFillByIDTIPDOKUMENTA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<DOKUMENTWorkWithWorkItem>("Placa.DOKUMENTFillByIDTIPDOKUMENTA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDTIPDOKUMENTA", this.CurrentRow);
            }
        }
    }
}

