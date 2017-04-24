namespace NetAdvantage.Controls
{
    using Deklarit;
    using Deklarit.Controls;
    using Deklarit.Resources;
    using Deklarit.WinHelper;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Reflection;

    public class RADNIKComboBox : DeklaritComboBox
    {
        private System.Data.DataSet m_DataSet = new RADNIKDataSet();
        protected int m_FillByIDBANKEIDBANKE;
        protected string m_FillByIDBENEFICIRANIIDBENEFICIRANI;
        protected int m_FillByIDBRACNOSTANJEIDBRACNOSTANJE;
        protected int m_FillByIDDRZAVLJANSTVOIDDRZAVLJANSTVO;
        protected int m_FillByIDIPIDENTIDIPIDENT;
        protected int m_FillByIDORGDIOIDORGDIO;
        protected int m_FillByIDRADNOMJESTOIDRADNOMJESTO;
        protected int m_FillByIDRADNOVRIJEMEIDRADNOVRIJEME;
        protected int m_FillByIDSPOLIDSPOL;
        protected int m_FillByIDSTRUKAIDSTRUKA;
        protected int m_FillByIDTITULAIDTITULA;
        protected int m_FillByIDUGOVORORADUIDUGOVORORADU;
        protected string m_FillByJMBGJMBG;
        protected string m_FillByOPCINARADAIDOPCINEOPCINARADAIDOPCINE;
        protected string m_FillByOPCINASTANOVANJAIDOPCINEOPCINASTANOVANJAIDOPCINE;
        protected int m_FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMAPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
        protected int m_FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
        protected int m_FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMATRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
        protected string m_FillMethod = "Fill";

        public RADNIKComboBox()
        {
            this.Text = "IDRADNIK";
            DataView defaultView = this.DataSet.Tables["RADNIK"].DefaultView;
            defaultView.Sort = "SPOJENOPREZIME";
            this.DisplayMember = "SPOJENOPREZIME";
            this.ValueMember = "IDRADNIK";
            this.DataSource = defaultView;
            DeklaritComboBox.myFillMethods = new TypeConverter.StandardValuesCollection(new string[] { 
                "Fill", "FillByIDRADNOMJESTO", "FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA", "FillByIDSTRUKA", "FillByIDBRACNOSTANJE", "FillByIDORGDIO", "FillByOPCINASTANOVANJAIDOPCINE", "FillByOPCINARADAIDOPCINE", "FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", "FillByJMBG", "FillByIDRADNOVRIJEME", "FillByIDDRZAVLJANSTVO", "FillByIDUGOVORORADU", "FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", "FillByIDIPIDENT", "FillByIDSPOL", 
                "FillByIDBANKE", "FillByIDBENEFICIRANI", "FillByIDTITULA"
             });
        }

        public void Fill()
        {
            if (this.m_DataSet != null)
            {
                try
                {
                    this.DataSource = null;
                    this.m_DataSet.Clear();
                    if (this.FillMethod == "Fill")
                    {
                        this.DataAdapter.Fill(this.m_DataSet);
                    }
                    else
                    {
                        MethodInfo method = this.DataAdapter.GetType().GetMethod(this.FillMethod);
                        this.InvokeFillByMethod(this.FillMethod, (IDataAdapter) this.DataAdapter, this.m_DataSet, method);
                    }
                    DataView defaultView = this.DataSet.Tables["RADNIK"].DefaultView;
                    defaultView.Sort = "SPOJENOPREZIME";
                    this.DisplayMember = "SPOJENOPREZIME";
                    this.DataSource = defaultView;
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                    
                }
            }
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            if (!this.DesignMode && this.FillAtStartup)
            {
                this.Fill();
                if (this.AddEmptyValue)
                {
                    DataView view = ComboHelper.GetComboValues(this.DataSet, "RADNIK", "IDRADNIK", "SPOJENOPREZIME", true, "<" + Deklarit.Resources.Resources.Empty + ">");
                    this.DataSource = null;
                    view.Sort = "Name";
                    this.DisplayMember = "Name";
                    this.ValueMember = "Id";
                    this.DataSource = view;
                }
            }
        }

        [Category("Deklarit"), Browsable(false)]
        public IRADNIKDataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.GetRADNIKDataAdapter();
                }
                return null;
            }
        }

        [Browsable(false), Category("Deklarit")]
        public System.Data.DataSet DataSet
        {
            get
            {
                return this.m_DataSet;
            }
        }

        [Category("Deklarit")]
        public virtual int FillByIDBANKEIDBANKE
        {
            get
            {
                return this.m_FillByIDBANKEIDBANKE;
            }
            set
            {
                this.m_FillByIDBANKEIDBANKE = value;
            }
        }

        [Category("Deklarit")]
        public virtual string FillByIDBENEFICIRANIIDBENEFICIRANI
        {
            get
            {
                return this.m_FillByIDBENEFICIRANIIDBENEFICIRANI;
            }
            set
            {
                this.m_FillByIDBENEFICIRANIIDBENEFICIRANI = value;
            }
        }

        [Category("Deklarit")]
        public virtual int FillByIDBRACNOSTANJEIDBRACNOSTANJE
        {
            get
            {
                return this.m_FillByIDBRACNOSTANJEIDBRACNOSTANJE;
            }
            set
            {
                this.m_FillByIDBRACNOSTANJEIDBRACNOSTANJE = value;
            }
        }

        [Category("Deklarit")]
        public virtual int FillByIDDRZAVLJANSTVOIDDRZAVLJANSTVO
        {
            get
            {
                return this.m_FillByIDDRZAVLJANSTVOIDDRZAVLJANSTVO;
            }
            set
            {
                this.m_FillByIDDRZAVLJANSTVOIDDRZAVLJANSTVO = value;
            }
        }

        [Category("Deklarit")]
        public virtual int FillByIDIPIDENTIDIPIDENT
        {
            get
            {
                return this.m_FillByIDIPIDENTIDIPIDENT;
            }
            set
            {
                this.m_FillByIDIPIDENTIDIPIDENT = value;
            }
        }

        [Category("Deklarit")]
        public virtual int FillByIDORGDIOIDORGDIO
        {
            get
            {
                return this.m_FillByIDORGDIOIDORGDIO;
            }
            set
            {
                this.m_FillByIDORGDIOIDORGDIO = value;
            }
        }

        [Category("Deklarit")]
        public virtual int FillByIDRADNOMJESTOIDRADNOMJESTO
        {
            get
            {
                return this.m_FillByIDRADNOMJESTOIDRADNOMJESTO;
            }
            set
            {
                this.m_FillByIDRADNOMJESTOIDRADNOMJESTO = value;
            }
        }

        [Category("Deklarit")]
        public virtual int FillByIDRADNOVRIJEMEIDRADNOVRIJEME
        {
            get
            {
                return this.m_FillByIDRADNOVRIJEMEIDRADNOVRIJEME;
            }
            set
            {
                this.m_FillByIDRADNOVRIJEMEIDRADNOVRIJEME = value;
            }
        }

        [Category("Deklarit")]
        public virtual int FillByIDSPOLIDSPOL
        {
            get
            {
                return this.m_FillByIDSPOLIDSPOL;
            }
            set
            {
                this.m_FillByIDSPOLIDSPOL = value;
            }
        }

        [Category("Deklarit")]
        public virtual int FillByIDSTRUKAIDSTRUKA
        {
            get
            {
                return this.m_FillByIDSTRUKAIDSTRUKA;
            }
            set
            {
                this.m_FillByIDSTRUKAIDSTRUKA = value;
            }
        }

        [Category("Deklarit")]
        public virtual int FillByIDTITULAIDTITULA
        {
            get
            {
                return this.m_FillByIDTITULAIDTITULA;
            }
            set
            {
                this.m_FillByIDTITULAIDTITULA = value;
            }
        }

        [Category("Deklarit")]
        public virtual int FillByIDUGOVORORADUIDUGOVORORADU
        {
            get
            {
                return this.m_FillByIDUGOVORORADUIDUGOVORORADU;
            }
            set
            {
                this.m_FillByIDUGOVORORADUIDUGOVORORADU = value;
            }
        }

        [Category("Deklarit")]
        public virtual string FillByJMBGJMBG
        {
            get
            {
                return this.m_FillByJMBGJMBG;
            }
            set
            {
                this.m_FillByJMBGJMBG = value;
            }
        }

        [Category("Deklarit")]
        public virtual string FillByOPCINARADAIDOPCINEOPCINARADAIDOPCINE
        {
            get
            {
                return this.m_FillByOPCINARADAIDOPCINEOPCINARADAIDOPCINE;
            }
            set
            {
                this.m_FillByOPCINARADAIDOPCINEOPCINARADAIDOPCINE = value;
            }
        }

        [Category("Deklarit")]
        public virtual string FillByOPCINASTANOVANJAIDOPCINEOPCINASTANOVANJAIDOPCINE
        {
            get
            {
                return this.m_FillByOPCINASTANOVANJAIDOPCINEOPCINASTANOVANJAIDOPCINE;
            }
            set
            {
                this.m_FillByOPCINASTANOVANJAIDOPCINEOPCINASTANOVANJAIDOPCINE = value;
            }
        }

        [Category("Deklarit")]
        public virtual int FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMAPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA
        {
            get
            {
                return this.m_FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMAPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
            }
            set
            {
                this.m_FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMAPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA = value;
            }
        }

        [Category("Deklarit")]
        public virtual int FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA
        {
            get
            {
                return this.m_FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
            }
            set
            {
                this.m_FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA = value;
            }
        }

        [Category("Deklarit")]
        public virtual int FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMATRENUTNASTRUCNASPREMAIDSTRUCNASPREMA
        {
            get
            {
                return this.m_FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMATRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
            }
            set
            {
                this.m_FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMATRENUTNASTRUCNASPREMAIDSTRUCNASPREMA = value;
            }
        }

        [DefaultValue("Fill"), TypeConverter(typeof(DeklaritComboBox.FillMethodsConverter)), Category("Deklarit")]
        public virtual string FillMethod
        {
            get
            {
                return this.m_FillMethod;
            }
            set
            {
                this.m_FillMethod = value;
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RADNIKComboBox
            // 
            this.Name = "RADNIKComboBox";
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

