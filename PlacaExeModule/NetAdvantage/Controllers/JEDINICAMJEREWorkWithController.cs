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

    public class JEDINICAMJEREWorkWithController : WorkWithControllerBase<JEDINICAMJEREWorkItem, JEDINICAMJEREDataSet>
    {
        public JEDINICAMJEREDataSet.JEDINICAMJERERow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetJEDINICAMJEREDataAdapter().Fill((JEDINICAMJEREDataSet) dataSet, Conversions.ToInteger(row["IDJEDINICAMJERE"]));
        }

        [LocalCommandHandler("PROIZVOD")]
        public void ShowPROIZVOD(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                PROIZVODWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<PROIZVODWorkWithWorkItem>("Placa.PROIZVODFillByIDJEDINICAMJERE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<PROIZVODWorkWithWorkItem>("Placa.PROIZVODFillByIDJEDINICAMJERE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDJEDINICAMJERE", this.CurrentRow);
            }
        }
    }
}

