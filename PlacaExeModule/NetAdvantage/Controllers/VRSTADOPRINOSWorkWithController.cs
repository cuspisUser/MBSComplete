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

    public class VRSTADOPRINOSWorkWithController : WorkWithControllerBase<VRSTADOPRINOSWorkItem, VRSTADOPRINOSDataSet>
    {
        public VRSTADOPRINOSDataSet.VRSTADOPRINOSRow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetVRSTADOPRINOSDataAdapter().Fill((VRSTADOPRINOSDataSet) dataSet, Conversions.ToInteger(row["IDVRSTADOPRINOS"]));
        }

        [LocalCommandHandler("DOPRINOS")]
        public void ShowDOPRINOS(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                DOPRINOSWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<DOPRINOSWorkWithWorkItem>("Placa.DOPRINOSFillByIDVRSTADOPRINOS");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<DOPRINOSWorkWithWorkItem>("Placa.DOPRINOSFillByIDVRSTADOPRINOS");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByIDVRSTADOPRINOS", this.CurrentRow);
            }
        }
    }
}

