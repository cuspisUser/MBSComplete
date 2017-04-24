﻿namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class FINPOREZWorkWithController : WorkWithControllerBase<FINPOREZWorkItem, FINPOREZDataSet>
    {
        public FINPOREZDataSet.FINPOREZRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetFINPOREZDataAdapter().Fill((FINPOREZDataSet) dataSet, Conversions.ToInteger(row["FINPOREZIDPOREZ"]));
        }

        [LocalCommandHandler("PROIZVOD")]
        public void ShowPROIZVOD(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                PROIZVODWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<PROIZVODWorkWithWorkItem>("Placa.PROIZVODFillByFINPOREZIDPOREZ");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<PROIZVODWorkWithWorkItem>("Placa.PROIZVODFillByFINPOREZIDPOREZ");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByFINPOREZIDPOREZ", this.CurrentRow);
            }
        }
    }
}

