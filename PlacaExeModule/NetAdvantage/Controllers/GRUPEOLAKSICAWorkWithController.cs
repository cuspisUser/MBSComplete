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

    public class GRUPEOLAKSICAWorkWithController : WorkWithControllerBase<GRUPEOLAKSICAWorkItem, GRUPEOLAKSICADataSet>
    {
        public GRUPEOLAKSICADataSet.GRUPEOLAKSICARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetGRUPEOLAKSICADataAdapter().Fill((GRUPEOLAKSICADataSet) dataSet, Conversions.ToInteger(row["IDGRUPEOLAKSICA"]));
        }

        [LocalCommandHandler("OLAKSICE")]
        public void ShowOLAKSICE(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                OLAKSICEWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<OLAKSICEWorkWithWorkItem>("Placa.OLAKSICEFillByIDGRUPEOLAKSICA");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<OLAKSICEWorkWithWorkItem>("Placa.OLAKSICEFillByIDGRUPEOLAKSICA");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDGRUPEOLAKSICA", this.CurrentRow);
            }
        }
    }
}

