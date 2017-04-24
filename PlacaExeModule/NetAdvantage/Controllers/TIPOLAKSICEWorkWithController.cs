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

    public class TIPOLAKSICEWorkWithController : WorkWithControllerBase<TIPOLAKSICEWorkItem, TIPOLAKSICEDataSet>
    {
        public TIPOLAKSICEDataSet.TIPOLAKSICERow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetTIPOLAKSICEDataAdapter().Fill((TIPOLAKSICEDataSet) dataSet, Conversions.ToInteger(row["IDTIPOLAKSICE"]));
        }

        [LocalCommandHandler("OLAKSICE")]
        public void ShowOLAKSICE(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                OLAKSICEWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<OLAKSICEWorkWithWorkItem>("Placa.OLAKSICEFillByIDTIPOLAKSICE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<OLAKSICEWorkWithWorkItem>("Placa.OLAKSICEFillByIDTIPOLAKSICE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDTIPOLAKSICE", this.CurrentRow);
            }
        }
    }
}

