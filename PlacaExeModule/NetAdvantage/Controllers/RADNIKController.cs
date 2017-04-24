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

    public class RADNIKController : FormControllerBase
    {
        public DialogResult AddRADNIKBruto(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKBruto.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddRADNIKIzuzeceOdOvrhe(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKIzuzeceOdOvrhe.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddRADNIKKrediti(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKKrediti.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddRADNIKLevel7(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKLevel7.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddRADNIKNeto(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKNeto.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddRADNIKObustava(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKObustava.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddRADNIKOdbitak(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKOdbitak.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult AddRADNIKOlaksica(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKOlaksica.Show(DeklaritMode.Insert, currentRow, false);
        }

        public DialogResult DeleteRADNIKBruto(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKBruto.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteRADNIKIzuzeceOdOvrhe(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKIzuzeceOdOvrhe.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteRADNIKKrediti(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKKrediti.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteRADNIKLevel7(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKLevel7.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteRADNIKNeto(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKNeto.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteRADNIKObustava(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKObustava.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteRADNIKOdbitak(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKOdbitak.Show(DeklaritMode.Delete, currentRow, false);
        }

        public DialogResult DeleteRADNIKOlaksica(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKOlaksica.Show(DeklaritMode.Delete, currentRow, false);
        }

        public override void DoUpdate()
        {
            DataAdapterFactory.GetRADNIKDataAdapter().Update(this.DataSet);
        }

        public void NewGOOBRACUN(DataRow row)
        {
            GOOBRACUNWorkItem item = this.WorkItem.Items.AddNew<GOOBRACUNWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewOTISLI(DataRow row)
        {
            OTISLIWorkItem item = this.WorkItem.Items.AddNew<OTISLIWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void NewZAPOSLENI(DataRow row)
        {
            ZAPOSLENIWorkItem item = this.WorkItem.Items.AddNew<ZAPOSLENIWorkItem>();
            item.RootForm.Show(DeklaritMode.Insert, row, false);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public DataRow SelectBANKEBANKAZASTICENOIDBANKE(string fillMethod, DataRow fillByRow)
        {
            BANKESelectionListWorkItem item = this.WorkItem.Items.AddNew<BANKESelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectBANKEIDBANKE(string fillMethod, DataRow fillByRow)
        {
            BANKESelectionListWorkItem item = this.WorkItem.Items.AddNew<BANKESelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectKREDITORZADKREDITIIDKREDITOR(string fillMethod, DataRow fillByRow)
        {
            KREDITORSelectionListWorkItem item = this.WorkItem.Items.AddNew<KREDITORSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectOBUSTAVAZADOBUSTAVAIDOBUSTAVA(string fillMethod, DataRow fillByRow)
        {
            OBUSTAVASelectionListWorkItem item = this.WorkItem.Items.AddNew<OBUSTAVASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectOLAKSICEZADOLAKSICEIDOLAKSICE(string fillMethod, DataRow fillByRow)
        {
            OLAKSICESelectionListWorkItem item = this.WorkItem.Items.AddNew<OLAKSICESelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectOPCINAOPCINARADAIDOPCINE(string fillMethod, DataRow fillByRow)
        {
            OPCINASelectionListWorkItem item = this.WorkItem.Items.AddNew<OPCINASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectOPCINAOPCINASTANOVANJAIDOPCINE(string fillMethod, DataRow fillByRow)
        {
            OPCINASelectionListWorkItem item = this.WorkItem.Items.AddNew<OPCINASelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectOSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK(string fillMethod, DataRow fillByRow)
        {
            OSOBNIODBITAKSelectionListWorkItem item = this.WorkItem.Items.AddNew<OSOBNIODBITAKSelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow SelectRADNOVRIJEMEIDRADNOVRIJEME(string fillMethod, DataRow fillByRow)
        {
            RADNOVRIJEMESelectionListWorkItem item = this.WorkItem.Items.AddNew<RADNOVRIJEMESelectionListWorkItem>();
            DataRow row = item.ShowModal(true, fillMethod, fillByRow);
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowBANKEBANKAZASTICENOIDBANKE(DataRow fillByRow)
        {
            BANKEWorkItem item = this.WorkItem.Items.AddNew<BANKEWorkItem>();
            DataAdapterFactory.GetBANKEDataAdapter().Fill((BANKEDataSet) item.DataSet, Conversions.ToInteger(fillByRow["BANKAZASTICENOIDBANKE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowBANKEIDBANKE(DataRow fillByRow)
        {
            BANKEWorkItem item = this.WorkItem.Items.AddNew<BANKEWorkItem>();
            DataAdapterFactory.GetBANKEDataAdapter().Fill((BANKEDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDBANKE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowKREDITORZADKREDITIIDKREDITOR(DataRow fillByRow)
        {
            KREDITORWorkItem item = this.WorkItem.Items.AddNew<KREDITORWorkItem>();
            DataAdapterFactory.GetKREDITORDataAdapter().Fill((KREDITORDataSet) item.DataSet, Conversions.ToInteger(fillByRow["ZADKREDITIIDKREDITOR"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowOBUSTAVAZADOBUSTAVAIDOBUSTAVA(DataRow fillByRow)
        {
            OBUSTAVAWorkItem item = this.WorkItem.Items.AddNew<OBUSTAVAWorkItem>();
            DataAdapterFactory.GetOBUSTAVADataAdapter().Fill((OBUSTAVADataSet) item.DataSet, Conversions.ToInteger(fillByRow["ZADOBUSTAVAIDOBUSTAVA"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowOLAKSICEZADOLAKSICEIDOLAKSICE(DataRow fillByRow)
        {
            OLAKSICEWorkItem item = this.WorkItem.Items.AddNew<OLAKSICEWorkItem>();
            DataAdapterFactory.GetOLAKSICEDataAdapter().Fill((OLAKSICEDataSet) item.DataSet, Conversions.ToInteger(fillByRow["ZADOLAKSICEIDOLAKSICE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowOPCINAOPCINARADAIDOPCINE(DataRow fillByRow)
        {
            OPCINAWorkItem item = this.WorkItem.Items.AddNew<OPCINAWorkItem>();
            DataAdapterFactory.GetOPCINADataAdapter().Fill((OPCINADataSet) item.DataSet, Conversions.ToString(fillByRow["OPCINARADAIDOPCINE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowOPCINAOPCINASTANOVANJAIDOPCINE(DataRow fillByRow)
        {
            OPCINAWorkItem item = this.WorkItem.Items.AddNew<OPCINAWorkItem>();
            DataAdapterFactory.GetOPCINADataAdapter().Fill((OPCINADataSet) item.DataSet, Conversions.ToString(fillByRow["OPCINASTANOVANJAIDOPCINE"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowOSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK(DataRow fillByRow)
        {
            OSOBNIODBITAKWorkItem item = this.WorkItem.Items.AddNew<OSOBNIODBITAKWorkItem>();
            DataAdapterFactory.GetOSOBNIODBITAKDataAdapter().Fill((OSOBNIODBITAKDataSet) item.DataSet, Conversions.ToInteger(fillByRow["OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DataRow ShowRADNOVRIJEMEIDRADNOVRIJEME(DataRow fillByRow)
        {
            RADNOVRIJEMEWorkItem item = this.WorkItem.Items.AddNew<RADNOVRIJEMEWorkItem>();
            DataAdapterFactory.GetRADNOVRIJEMEDataAdapter().Fill((RADNOVRIJEMEDataSet) item.DataSet, Conversions.ToInteger(fillByRow["IDRADNOVRIJEME"]));
            DataRow row = null;
            if (item.RootForm.Show(DeklaritMode.Update, fillByRow, false) == DialogResult.OK)
            {
                row = DataSetUtil.GetRootTable(item.DataSet).Rows[0];
            }
            item.Terminate();
            this.WorkItem.Activate();
            return row;
        }

        public DialogResult UpdateRADNIKBruto(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKBruto.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateRADNIKIzuzeceOdOvrhe(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKIzuzeceOdOvrhe.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateRADNIKKrediti(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKKrediti.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateRADNIKLevel7(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKLevel7.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateRADNIKNeto(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKNeto.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateRADNIKObustava(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKObustava.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateRADNIKOdbitak(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKOdbitak.Show(DeklaritMode.Update, currentRow, false);
        }

        public DialogResult UpdateRADNIKOlaksica(DataRow currentRow)
        {
            return ((NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem).RADNIKOlaksica.Show(DeklaritMode.Update, currentRow, false);
        }

        public void ViewGOOBRACUN(DataRow row)
        {
            GOOBRACUNSelectionListWorkItem item = this.WorkItem.Items.AddNew<GOOBRACUNSelectionListWorkItem>();
            item.ShowModal(false, "FillByIDRADNIK", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewOTISLI(DataRow row)
        {
            OTISLISelectionListWorkItem item = this.WorkItem.Items.AddNew<OTISLISelectionListWorkItem>();
            item.ShowModal(false, "FillByIDRADNIK", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public void ViewZAPOSLENI(DataRow row)
        {
            ZAPOSLENISelectionListWorkItem item = this.WorkItem.Items.AddNew<ZAPOSLENISelectionListWorkItem>();
            item.ShowModal(false, "FillByIDRADNIK", row);
            item.Terminate();
            this.WorkItem.Activate();
        }

        public RADNIKDataSet DataSet
        {
            get
            {
                return (RADNIKDataSet) this.State["InstanceDataSet"];
            }
            set
            {
                this.State["InstanceDataSet"] = value;
            }
        }

        public FormDefinition RADNIKBrutoFormDefinition
        {
            get
            {
                return this.RADNIKWorkItem.RADNIKBruto;
            }
        }

        public FormDefinition RADNIKFormDefinition
        {
            get
            {
                return this.RADNIKWorkItem.RADNIK;
            }
        }

        public FormDefinition RADNIKIzuzeceOdOvrheFormDefinition
        {
            get
            {
                return this.RADNIKWorkItem.RADNIKIzuzeceOdOvrhe;
            }
        }

        public FormDefinition RADNIKKreditiFormDefinition
        {
            get
            {
                return this.RADNIKWorkItem.RADNIKKrediti;
            }
        }

        public FormDefinition RADNIKLevel7FormDefinition
        {
            get
            {
                return this.RADNIKWorkItem.RADNIKLevel7;
            }
        }

        public FormDefinition RADNIKNetoFormDefinition
        {
            get
            {
                return this.RADNIKWorkItem.RADNIKNeto;
            }
        }

        public FormDefinition RADNIKObustavaFormDefinition
        {
            get
            {
                return this.RADNIKWorkItem.RADNIKObustava;
            }
        }

        public FormDefinition RADNIKOdbitakFormDefinition
        {
            get
            {
                return this.RADNIKWorkItem.RADNIKOdbitak;
            }
        }

        public FormDefinition RADNIKOlaksicaFormDefinition
        {
            get
            {
                return this.RADNIKWorkItem.RADNIKOlaksica;
            }
        }

        public NetAdvantage.WorkItems.RADNIKWorkItem RADNIKWorkItem
        {
            get
            {
                return (NetAdvantage.WorkItems.RADNIKWorkItem) this.WorkItem;
            }
        }
    }
}

