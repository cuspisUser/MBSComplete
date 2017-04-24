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

    public class OBRACUNController : FormControllerBase
    {
        public DialogResult AddObracunDoprinosi(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).ObracunDoprinosi.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddObracunElementi(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).ObracunElementi.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddOBRACUNKrediti(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).OBRACUNKrediti.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddOBRACUNObustave(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).OBRACUNObustave.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddObracunOlaksice(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).ObracunOlaksice.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddObracunPorezi(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).ObracunPorezi.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddObracunRadnici(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).ObracunRadnici.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult DeleteObracunDoprinosi(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).ObracunDoprinosi.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteObracunElementi(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).ObracunElementi.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteOBRACUNKrediti(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).OBRACUNKrediti.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteOBRACUNObustave(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).OBRACUNObustave.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteObracunOlaksice(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).ObracunOlaksice.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteObracunPorezi(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).ObracunPorezi.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteObracunRadnici(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).ObracunRadnici.Show(DeklaritMode.Delete, currentRow, false);
        }

        public override void DoUpdate()
        {
            DataAdapterFactory.GetOBRACUNDataAdapter().Update(this.DataSet);
        }

        public void NewRSMA(DataRow row)
        {
            RSMAWorkItem item = this.WorkItem.Items.AddNew<RSMAWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public DataRow SelectDOPRINOSIDDOPRINOS(string fillMethod, DataRow fillByRow)
        {
            DOPRINOSSelectionListWorkItem item = this.WorkItem.Items.AddNew<DOPRINOSSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectKREDITORIDKREDITOR(string fillMethod, DataRow fillByRow)
        {
            KREDITORSelectionListWorkItem item = this.WorkItem.Items.AddNew<KREDITORSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectKRIZNIPOREZIDKRIZNIPOREZ(string fillMethod, DataRow fillByRow)
        {
            KRIZNIPOREZSelectionListWorkItem item = this.WorkItem.Items.AddNew<KRIZNIPOREZSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectOBUSTAVAIDOBUSTAVA(string fillMethod, DataRow fillByRow)
        {
            OBUSTAVASelectionListWorkItem item = this.WorkItem.Items.AddNew<OBUSTAVASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectOLAKSICEIDOLAKSICE(string fillMethod, DataRow fillByRow)
        {
            OLAKSICESelectionListWorkItem item = this.WorkItem.Items.AddNew<OLAKSICESelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectPOREZIDPOREZ(string fillMethod, DataRow fillByRow)
        {
            POREZSelectionListWorkItem item = this.WorkItem.Items.AddNew<POREZSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowDOPRINOSIDDOPRINOS(DataRow fillByRow)
        {
            DOPRINOSWorkItem item = this.WorkItem.Items.AddNew<DOPRINOSWorkItem>();
            DataAdapterFactory.GetDOPRINOSDataAdapter().Fill((DOPRINOSDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDDOPRINOS"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowKREDITORIDKREDITOR(DataRow fillByRow)
        {
            KREDITORWorkItem item = this.WorkItem.Items.AddNew<KREDITORWorkItem>();
            DataAdapterFactory.GetKREDITORDataAdapter().Fill((KREDITORDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDKREDITOR"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowKRIZNIPOREZIDKRIZNIPOREZ(DataRow fillByRow)
        {
            KRIZNIPOREZWorkItem item = this.WorkItem.Items.AddNew<KRIZNIPOREZWorkItem>();
            DataAdapterFactory.GetKRIZNIPOREZDataAdapter().Fill((KRIZNIPOREZDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDKRIZNIPOREZ"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowOBUSTAVAIDOBUSTAVA(DataRow fillByRow)
        {
            OBUSTAVAWorkItem item = this.WorkItem.Items.AddNew<OBUSTAVAWorkItem>();
            DataAdapterFactory.GetOBUSTAVADataAdapter().Fill((OBUSTAVADataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDOBUSTAVA"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowOLAKSICEIDOLAKSICE(DataRow fillByRow)
        {
            OLAKSICEWorkItem item = this.WorkItem.Items.AddNew<OLAKSICEWorkItem>();
            DataAdapterFactory.GetOLAKSICEDataAdapter().Fill((OLAKSICEDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDOLAKSICE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowPOREZIDPOREZ(DataRow fillByRow)
        {
            POREZWorkItem item = this.WorkItem.Items.AddNew<POREZWorkItem>();
            DataAdapterFactory.GetPOREZDataAdapter().Fill((POREZDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDPOREZ"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DialogResult UpdateObracunDoprinosi(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).ObracunDoprinosi.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateObracunElementi(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).ObracunElementi.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateOBRACUNKrediti(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).OBRACUNKrediti.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateOBRACUNObustave(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).OBRACUNObustave.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateObracunOlaksice(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).ObracunOlaksice.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateObracunPorezi(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).ObracunPorezi.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateObracunRadnici(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem).ObracunRadnici.Show(DeklaritMode.Update, currentRow, false);
        }

        public void ViewRSMA(DataRow row)
        {
            RSMASelectionListWorkItem item = this.WorkItem.Items.AddNew<RSMASelectionListWorkItem>();
            item.ShowModal(false, "FillByIDOBRACUN", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public OBRACUNDataSet DataSet
        {
            get
            {
                return (OBRACUNDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition ObracunDoprinosiFormDefinition
        {
            get
            {
                return this.OBRACUNWorkItem.ObracunDoprinosi;
            }
        }

        public FormDefinition ObracunElementiFormDefinition
        {
            get
            {
                return this.OBRACUNWorkItem.ObracunElementi;
            }
        }

        public FormDefinition OBRACUNFormDefinition
        {
            get
            {
                return this.OBRACUNWorkItem.OBRACUN;
            }
        }

        public FormDefinition OBRACUNKreditiFormDefinition
        {
            get
            {
                return this.OBRACUNWorkItem.OBRACUNKrediti;
            }
        }

        public FormDefinition OBRACUNObustaveFormDefinition
        {
            get
            {
                return this.OBRACUNWorkItem.OBRACUNObustave;
            }
        }

        public FormDefinition ObracunOlaksiceFormDefinition
        {
            get
            {
                return this.OBRACUNWorkItem.ObracunOlaksice;
            }
        }

        public FormDefinition ObracunPoreziFormDefinition
        {
            get
            {
                return this.OBRACUNWorkItem.ObracunPorezi;
            }
        }

        public FormDefinition ObracunRadniciFormDefinition
        {
            get
            {
                return this.OBRACUNWorkItem.ObracunRadnici;
            }
        }

        public NetAdvantage.WorkItems.OBRACUNWorkItem OBRACUNWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.OBRACUNWorkItem) this.WorkItem;
            }
        }
    }
}

