namespace NetAdvantage.Controllers
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Controllers;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public class PLANController : FormControllerBase
    {
        public DialogResult AddPLANORG(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.PLANWorkItem) this.WorkItem).PLANORG.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddPLANORGKON(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.PLANWorkItem) this.WorkItem).PLANORGKON.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult DeletePLANORG(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.PLANWorkItem) this.WorkItem).PLANORG.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeletePLANORGKON(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.PLANWorkItem) this.WorkItem).PLANORGKON.Show(DeklaritMode.Delete, currentRow, false);
        }

        public override void DoUpdate()
        {
            DataAdapterFactory.GetPLANDataAdapter().Update(this.DataSet);
        }

        public DataRow SelectGODINEPLANGODINAIDGODINE(string fillMethod, DataRow fillByRow)
        {
            GODINESelectionListWorkItem item = this.WorkItem.Items.AddNew<GODINESelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowGODINEPLANGODINAIDGODINE(DataRow fillByRow)
        {
            GODINEWorkItem item = this.WorkItem.Items.AddNew<GODINEWorkItem>();
            DataAdapterFactory.GetGODINEDataAdapter().Fill((GODINEDataSet) item.DataSet, Conversions.ToShort(fillByRow["PLANGODINAIDGODINE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DialogResult UpdatePLANORG(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.PLANWorkItem) this.WorkItem).PLANORG.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdatePLANORGKON(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.PLANWorkItem) this.WorkItem).PLANORGKON.Show(DeklaritMode.Update, currentRow, false);
        }

        public PLANDataSet DataSet
        {
            get
            {
                return (PLANDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition PLANFormDefinition
        {
            get
            {
                return this.PLANWorkItem.PLAN;
            }
        }

        public FormDefinition PLANORGFormDefinition
        {
            get
            {
                return this.PLANWorkItem.PLANORG;
            }
        }

        public FormDefinition PLANORGKONFormDefinition
        {
            get
            {
                return this.PLANWorkItem.PLANORGKON;
            }
        }

        public NetAdvantage.WorkItems.PLANWorkItem PLANWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.PLANWorkItem) this.WorkItem;
            }
        }
    }
}

