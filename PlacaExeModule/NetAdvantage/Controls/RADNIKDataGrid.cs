namespace NetAdvantage.Controls
{
    using Deklarit;
    using Deklarit.Controls;
    using Deklarit.Resources;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Globalization;
    using System.Reflection;
    using System.Security.Principal;
    using System.Threading;
    using System.Windows.Forms;

    public class RADNIKDataGrid : DeklaritDataGrid
    {
        private int currentRow;
        private RADNIKDataSet dsRADNIKDataSet1 = new RADNIKDataSet();
        private System.Data.DataView dv1;
        private int m_FillByIDBANKEIDBANKE;
        private string m_FillByIDBENEFICIRANIIDBENEFICIRANI;
        private int m_FillByIDBRACNOSTANJEIDBRACNOSTANJE;
        private int m_FillByIDDRZAVLJANSTVOIDDRZAVLJANSTVO;
        private int m_FillByIDIPIDENTIDIPIDENT;
        private int m_FillByIDORGDIOIDORGDIO;
        private int m_FillByIDRADNOMJESTOIDRADNOMJESTO;
        private int m_FillByIDRADNOVRIJEMEIDRADNOVRIJEME;
        private int m_FillByIDSPOLIDSPOL;
        private int m_FillByIDSTRUKAIDSTRUKA;
        private int m_FillByIDTITULAIDTITULA;
        private int m_FillByIDUGOVORORADUIDUGOVORORADU;
        private string m_FillByJMBGJMBG;
        private string m_FillByOPCINARADAIDOPCINEOPCINARADAIDOPCINE;
        private string m_FillByOPCINASTANOVANJAIDOPCINEOPCINASTANOVANJAIDOPCINE;
        private bool m_FillByPage = false;
        private int m_FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMAPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA;
        private int m_FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSARADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA;
        private int m_FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMATRENUTNASTRUCNASPREMAIDSTRUCNASPREMA;
        private string m_FillMethod = "Fill";
        private bool m_GridLoading;
        private int m_PageSize = 60;
        private int m_StartRow;
        private int startRowThread;
        private const int WM_SETREDRAW = 11;

        public RADNIKDataGrid()
        {
            this.BindDataGrid();
            DeklaritDataGrid.myFillMethods = new TypeConverter.StandardValuesCollection(new string[] { 
                "Fill", "FillByIDRADNOMJESTO", "FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA", "FillByIDSTRUKA", "FillByIDBRACNOSTANJE", "FillByIDORGDIO", "FillByOPCINASTANOVANJAIDOPCINE", "FillByOPCINARADAIDOPCINE", "FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA", "FillByJMBG", "FillByIDRADNOVRIJEME", "FillByIDDRZAVLJANSTVO", "FillByIDUGOVORORADU", "FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA", "FillByIDIPIDENT", "FillByIDSPOL", 
                "FillByIDBANKE", "FillByIDBENEFICIRANI", "FillByIDTITULA"
             });
            this.AfterRowRegionScroll += new RowScrollRegionEventHandler(this.Grid_AfterRowRegionScroll);
            this.AfterSelectChange += new AfterSelectChangeEventHandler(this.Grid_AfterSelectChange);
        }

        private void BindDataGrid()
        {
            this.dv1 = new System.Data.DataView();
            this.dv1.Table = this.dsRADNIKDataSet1.RADNIK;
            BindingSource source = new BindingSource(this.dv1, "");
            this.DataSource = source;
        }

        private void ContinuePainting()
        {
            DeklaritDataGrid.NativeMethods.SendMessage(this.Handle, 11, 1, (int) IntPtr.Zero);
            this.Invalidate(true);
            this.Update();
        }

        public virtual void Fill()
        {
            this.PreFill();
            this.dsRADNIKDataSet1 = new RADNIKDataSet();
            this.m_StartRow = 0;
            this.Cursor = Cursors.WaitCursor;
            this.m_GridLoading = true;
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.FillDataThread), Thread.CurrentPrincipal);
        }

        private void FillDataThread(object state)
        {
            Thread.CurrentPrincipal = (IPrincipal) state;
            try
            {
                if (this.FillByPage)
                {
                    if (this.FillMethod == "Fill")
                    {
                        this.DataAdapter.FillPage(this.dsRADNIKDataSet1, 0, this.PageSize);
                    }
                    else
                    {
                        MethodInfo info = this.DataAdapter.GetType().GetMethod("FillPageBy" + this.FillMethod.Substring(6));
                        this.InvokeFillByMethod(this.FillMethod, (IDataAdapter) this.DataAdapter, this.dsRADNIKDataSet1, info, 0, this.PageSize);
                    }
                }
                else if (this.FillMethod == "Fill")
                {
                    this.DataAdapter.Fill(this.dsRADNIKDataSet1);
                }
                else
                {
                    MethodInfo info2 = this.DataAdapter.GetType().GetMethod(this.FillMethod);
                    this.InvokeFillByMethod(this.FillMethod, (IDataAdapter) this.DataAdapter, this.dsRADNIKDataSet1, info2);
                }
                MethodInvoker method = new MethodInvoker(this.ResumeBindingPostThreadFirst);
                if (this.InvokeRequired)
                {
                    this.Invoke(method);
                }
                else
                {
                    this.ResumeBindingPostThreadFirst();
                }
            }
            catch (System.Exception exception1)
            {
                MessageBox.Show("ex: "+exception1);
                //throw exception1;
            }
        }

        private void Grid_AfterRowRegionScroll(object sender, RowScrollRegionEventArgs e)
        {
            UltraGridRow firstRow = this.ActiveRowScrollRegion.FirstRow;
            if ((!(firstRow is UltraGridGroupByRow) && !this.GridLoading) && ((firstRow.Index + this.ActiveRowScrollRegion.VisibleRows.Count) >= this.Rows.Count))
            {
                this.m_StartRow += this.m_PageSize;
                if ((this.m_StartRow < ((this.m_PageSize + this.Rows.Count) + 1)) && (this.m_StartRow >= this.Rows.Count))
                {
                    this.Refill(this.m_StartRow);
                }
            }
        }

        private void Grid_AfterSelectChange(object sender, AfterSelectChangeEventArgs args)
        {
            if (this.ActiveRow != null)
            {
                this.ActiveRow.Selected = true;
            }
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            if (!this.DesignMode)
            {
                this.MyLoadData();
            }
        }

        public virtual void MyLoadData()
        {
            if (this.FillAtStartup)
            {
                this.Fill();
            }
        }

        private void PreFill()
        {
            this.currentRow = this.CurrentRowIndex;
            this.SuspendLayout();
            this.BindingContext[this.DataView].SuspendBinding();
            this.BeginUpdate();
        }

        public virtual void Refill(int startRow)
        {
            this.PreFill();
            this.Cursor = Cursors.WaitCursor;
            this.m_GridLoading = true;
            this.StopPainting();
            this.startRowThread = startRow;
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.ReFillDataThread), Thread.CurrentPrincipal);
        }

        private void ReFillDataThread(object state)
        {
            Thread.CurrentPrincipal = (IPrincipal) state;
            try
            {
                if (this.FillByPage)
                {
                    if (this.FillMethod == "Fill")
                    {
                        this.DataAdapter.FillPage(this.dsRADNIKDataSet1, this.startRowThread, this.PageSize);
                    }
                    else
                    {
                        MethodInfo info = this.DataAdapter.GetType().GetMethod("FillPageBy" + this.FillMethod.Substring(6));
                        this.InvokeFillByMethod(this.FillMethod, (IDataAdapter) this.DataAdapter, this.dsRADNIKDataSet1, info, this.startRowThread, this.PageSize);
                    }
                }
                MethodInvoker method = new MethodInvoker(this.ResumeBindingPostThread);
                if (this.InvokeRequired)
                {
                    this.Invoke(method);
                }
                else
                {
                    this.ResumeBindingPostThread();
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        private void ResumeBindingPostThread()
        {
            this.Cursor = Cursors.Default;
            this.EndUpdate();
            this.BindDataGrid();
            this.Text = "Zaposlenici : " + this.DataView.Count.ToString(CultureInfo.InvariantCulture) + " " + Deklarit.Resources.Resources.Rows;
            this.BindingContext[this.DataView].ResumeBinding();
            this.ResumeLayout();
            this.ActiveRow = this.Rows.GetRowWithListIndex(this.currentRow);
            this.m_GridLoading = false;
            this.ContinuePainting();
        }

        private void ResumeBindingPostThreadFirst()
        {
            this.ResumeBindingPostThread();
            ColumnEnumerator enumerator = this.DisplayLayout.Bands[0].Columns.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.PerformAutoResize();
            }
        }

        private void StopPainting()
        {
            DeklaritDataGrid.NativeMethods.SendMessage(this.Handle, 11, 0, (int) IntPtr.Zero);
        }

        public int CurrentRowIndex
        {
            get
            {
                if (this.ActiveRow == null)
                {
                    return -1;
                }
                UltraGridRow activeRow = this.ActiveRow;
                while ((activeRow.ParentRow != null) && !(activeRow.ParentRow is UltraGridGroupByRow))
                {
                    activeRow = activeRow.ParentRow;
                }
                return activeRow.ListIndex;
            }
        }

        [Category("Deklarit Work With "), Browsable(false)]
        public virtual IRADNIKDataAdapter DataAdapter
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

        [Category("Deklarit Work With "), Browsable(false)]
        public virtual RADNIKDataSet DataSet
        {
            get
            {
                return this.dsRADNIKDataSet1;
            }
            set
            {
                this.dsRADNIKDataSet1 = value;
            }
        }

        [Browsable(false), Category("Deklarit Work With ")]
        public virtual System.Data.DataView DataView
        {
            get
            {
                return this.dv1;
            }
        }

        [Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
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

        [DefaultValue(true), Category("Deklarit Work With ")]
        public virtual bool FillByPage
        {
            get
            {
                return this.m_FillByPage;
            }
            set
            {
                this.m_FillByPage = value;
            }
        }

        [Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With ")]
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

        [TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), Category("Deklarit Work With "), DefaultValue("Fill")]
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

        [Browsable(false), DefaultValue(false)]
        public virtual bool GridLoading
        {
            get
            {
                return this.m_GridLoading;
            }
        }

        [DefaultValue(60), Category("Deklarit Work With ")]
        public virtual int PageSize
        {
            get
            {
                return this.m_PageSize;
            }
            set
            {
                this.m_PageSize = value;
            }
        }
    }
}

