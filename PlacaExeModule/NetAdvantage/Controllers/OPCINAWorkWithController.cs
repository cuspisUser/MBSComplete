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

    public class OPCINAWorkWithController : WorkWithControllerBase<OPCINAWorkItem, OPCINADataSet>
    {
        public OPCINADataSet.OPCINARow KeysRow;

        public override void Fill(DataSet dataSet, IDictionary<string, object> row)
        {
            DataAdapterFactory.GetOPCINADataAdapter().Fill((OPCINADataSet) dataSet, Conversions.ToString(row["IDOPCINE"]));
        }

        [LocalCommandHandler("DDRADNIK")]
        public void ShowDDRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                DDRADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<DDRADNIKWorkWithWorkItem>("Placa.DDRADNIKFillByOPCINASTANOVANJAIDOPCINE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<DDRADNIKWorkWithWorkItem>("Placa.DDRADNIKFillByOPCINASTANOVANJAIDOPCINE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByOPCINASTANOVANJAIDOPCINE", this.CurrentRow);
            }
        }

        [LocalCommandHandler("DDRADNIK1")]
        public void ShowDDRADNIK1(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                DDRADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<DDRADNIKWorkWithWorkItem>("Placa.DDRADNIKFillByOPCINARADAIDOPCINE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<DDRADNIKWorkWithWorkItem>("Placa.DDRADNIKFillByOPCINARADAIDOPCINE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByOPCINARADAIDOPCINE", this.CurrentRow);
            }
        }

        [LocalCommandHandler("RADNIK")]
        public void ShowRADNIK(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByOPCINASTANOVANJAIDOPCINE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByOPCINASTANOVANJAIDOPCINE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByOPCINASTANOVANJAIDOPCINE", this.CurrentRow);
            }
        }

        [LocalCommandHandler("RADNIK1")]
        public void ShowRADNIK1(object sender, EventArgs e)
        {
            if (this.CurrentRow != null)
            {
                RADNIKWorkWithWorkItem item = this.WorkItem.Parent.Items.Get<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByOPCINARADAIDOPCINE");
                if (item == null)
                {
                    item = this.WorkItem.Parent.Items.AddNew<RADNIKWorkWithWorkItem>("Placa.RADNIKFillByOPCINARADAIDOPCINE");
                }
                item.Show(this.WorkItem.Workspaces["main"], "FillByOPCINARADAIDOPCINE", this.CurrentRow);
            }
        }
    }
}

