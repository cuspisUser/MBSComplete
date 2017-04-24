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

    public class SHEMAPLACAController : FormControllerBase
    {
        public DialogResult AddSHEMAPLACASHEMAPLACADOP(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMAPLACAWorkItem) this.WorkItem).SHEMAPLACASHEMAPLACADOP.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddSHEMAPLACASHEMAPLACAELEMENT(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMAPLACAWorkItem) this.WorkItem).SHEMAPLACASHEMAPLACAELEMENT.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddSHEMAPLACASHEMAPLACASTANDARD(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMAPLACAWorkItem) this.WorkItem).SHEMAPLACASHEMAPLACASTANDARD.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult DeleteSHEMAPLACASHEMAPLACADOP(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMAPLACAWorkItem) this.WorkItem).SHEMAPLACASHEMAPLACADOP.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteSHEMAPLACASHEMAPLACAELEMENT(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMAPLACAWorkItem) this.WorkItem).SHEMAPLACASHEMAPLACAELEMENT.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteSHEMAPLACASHEMAPLACASTANDARD(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMAPLACAWorkItem) this.WorkItem).SHEMAPLACASHEMAPLACASTANDARD.Show(DeklaritMode.Delete, currentRow, false);
        }

        public override void DoUpdate()
        {
            DataAdapterFactory.GetSHEMAPLACADataAdapter().Update(this.DataSet);
        }

        public DataRow SelectDOPRINOSSHEMAPLDOPIDDOPRINOS(string fillMethod, DataRow fillByRow)
        {
            DOPRINOSSelectionListWorkItem item = this.WorkItem.Items.AddNew<DOPRINOSSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowDOPRINOSSHEMAPLDOPIDDOPRINOS(DataRow fillByRow)
        {
            DOPRINOSWorkItem item = this.WorkItem.Items.AddNew<DOPRINOSWorkItem>();
            DataAdapterFactory.GetDOPRINOSDataAdapter().Fill((DOPRINOSDataSet) item.DataSet, Conversions.ToInteger(fillByRow["SHEMAPLDOPIDDOPRINOS"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DialogResult UpdateSHEMAPLACASHEMAPLACADOP(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMAPLACAWorkItem) this.WorkItem).SHEMAPLACASHEMAPLACADOP.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateSHEMAPLACASHEMAPLACAELEMENT(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMAPLACAWorkItem) this.WorkItem).SHEMAPLACASHEMAPLACAELEMENT.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateSHEMAPLACASHEMAPLACASTANDARD(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.SHEMAPLACAWorkItem) this.WorkItem).SHEMAPLACASHEMAPLACASTANDARD.Show(DeklaritMode.Update, currentRow, false);
        }

        public SHEMAPLACADataSet DataSet
        {
            get
            {
                return (SHEMAPLACADataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition SHEMAPLACAFormDefinition
        {
            get
            {
                return this.SHEMAPLACAWorkItem.SHEMAPLACA;
            }
        }

        public FormDefinition SHEMAPLACASHEMAPLACADOPFormDefinition
        {
            get
            {
                return this.SHEMAPLACAWorkItem.SHEMAPLACASHEMAPLACADOP;
            }
        }

        public FormDefinition SHEMAPLACASHEMAPLACAELEMENTFormDefinition
        {
            get
            {
                return this.SHEMAPLACAWorkItem.SHEMAPLACASHEMAPLACAELEMENT;
            }
        }

        public FormDefinition SHEMAPLACASHEMAPLACASTANDARDFormDefinition
        {
            get
            {
                return this.SHEMAPLACAWorkItem.SHEMAPLACASHEMAPLACASTANDARD;
            }
        }

        public NetAdvantage.WorkItems.SHEMAPLACAWorkItem SHEMAPLACAWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.SHEMAPLACAWorkItem) this.WorkItem;
            }
        }
    }
}

