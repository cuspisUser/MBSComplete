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

    public class ELEMENTWorkWithController : WorkWithControllerBase<ELEMENTWorkItem, ELEMENTDataSet>
    {
        public ELEMENTDataSet.ELEMENTRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetELEMENTDataAdapter().Fill((ELEMENTDataSet) dataSet, Conversions.ToInteger(row["IDELEMENT"]));
        }

        [LocalCommandHandler("BOLOVANJEFOND")]
        public void ShowBOLOVANJEFOND(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                BOLOVANJEFONDWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<BOLOVANJEFONDWorkWithWorkItem>("Placa.BOLOVANJEFONDFillByELEMENTBOLOVANJEIDELEMENT");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<BOLOVANJEFONDWorkWithWorkItem>("Placa.BOLOVANJEFONDFillByELEMENTBOLOVANJEIDELEMENT");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByELEMENTBOLOVANJEIDELEMENT", this.CurrentRow);
            }
        }

        [LocalCommandHandler("RAD1GELEMENTIVEZA")]
        public void ShowRAD1GELEMENTIVEZA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RAD1GELEMENTIVEZAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RAD1GELEMENTIVEZAWorkWithWorkItem>("Placa.RAD1GELEMENTIVEZAFillByIDELEMENT");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RAD1GELEMENTIVEZAWorkWithWorkItem>("Placa.RAD1GELEMENTIVEZAFillByIDELEMENT");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDELEMENT", this.CurrentRow);
            }
        }

        [LocalCommandHandler("RAD1MELEMENTIVEZA")]
        public void ShowRAD1MELEMENTIVEZA(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RAD1MELEMENTIVEZAWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RAD1MELEMENTIVEZAWorkWithWorkItem>("Placa.RAD1MELEMENTIVEZAFillByIDELEMENT");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RAD1MELEMENTIVEZAWorkWithWorkItem>("Placa.RAD1MELEMENTIVEZAFillByIDELEMENT");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDELEMENT", this.CurrentRow);
            }
        }
    }
}

