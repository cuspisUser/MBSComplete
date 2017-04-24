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
    using System.Security.Principal;
    using System.Threading;
    using System.Windows.Forms;

    public class S_FIN_OTVORENE_STAVKEDataGrid : DeklaritDataGrid
    {
        private int currentRow;
        private S_FIN_OTVORENE_STAVKEDataSet dsS_FIN_OTVORENE_STAVKEDataSet1 = new S_FIN_OTVORENE_STAVKEDataSet();
        private System.Data.DataView dv1;
        private bool m_FillByPage = true;
        private bool m_GridLoading;
        private int m_PageSize = 60;
        private string m_ParameterDODATNIUVJET = "";
        private int m_ParameterDOK = 0;
        private short m_ParameterGODINA = 0;
        private int m_ParameterIDAKTIVNOST = 0;
        private int m_ParameterIDPARTNER = 0;
        private int m_ParameterMT = 0;
        private int m_ParameterORG = 0;
        private string m_ParameterPOCETNIKONTO = "";
        private DateTime m_ParameterRAZDOBLJEDO = DateTime.Now;
        private DateTime m_ParameterRAZDOBLJEOD = DateTime.Now;
        private string m_ParameterZAVRSNIKONTO = "";
        private int m_StartRow;
        private int startRowThread;
        private const int WM_SETREDRAW = 11;

        public S_FIN_OTVORENE_STAVKEDataGrid()
        {
            this.BindDataGrid();
            this.AfterRowRegionScroll += new RowScrollRegionEventHandler(this.Grid_AfterRowRegionScroll);
            this.AfterSelectChange += new AfterSelectChangeEventHandler(this.Grid_AfterSelectChange);
        }

        private void BindDataGrid()
        {
            this.dv1 = new System.Data.DataView();
            this.dv1.Table = this.dsS_FIN_OTVORENE_STAVKEDataSet1.S_FIN_OTVORENE_STAVKE;
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
            this.dsS_FIN_OTVORENE_STAVKEDataSet1 = new S_FIN_OTVORENE_STAVKEDataSet();
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
                    this.DataAdapter.FillPage(this.dsS_FIN_OTVORENE_STAVKEDataSet1, this.m_ParameterORG, this.m_ParameterMT, this.m_ParameterDOK, this.m_ParameterRAZDOBLJEOD, this.m_ParameterRAZDOBLJEDO, this.m_ParameterPOCETNIKONTO, this.m_ParameterZAVRSNIKONTO, this.m_ParameterIDAKTIVNOST, this.m_ParameterIDPARTNER, this.m_ParameterDODATNIUVJET, this.m_ParameterGODINA, 0, this.PageSize);
                }
                else
                {
                    this.DataAdapter.Fill(this.dsS_FIN_OTVORENE_STAVKEDataSet1, this.m_ParameterORG, this.m_ParameterMT, this.m_ParameterDOK, this.m_ParameterRAZDOBLJEOD, this.m_ParameterRAZDOBLJEDO, this.m_ParameterPOCETNIKONTO, this.m_ParameterZAVRSNIKONTO, this.m_ParameterIDAKTIVNOST, this.m_ParameterIDPARTNER, this.m_ParameterDODATNIUVJET, this.m_ParameterGODINA);
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
                throw exception1;
                
                
                
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
                    this.DataAdapter.FillPage(this.dsS_FIN_OTVORENE_STAVKEDataSet1, this.m_ParameterORG, this.m_ParameterMT, this.m_ParameterDOK, this.m_ParameterRAZDOBLJEOD, this.m_ParameterRAZDOBLJEDO, this.m_ParameterPOCETNIKONTO, this.m_ParameterZAVRSNIKONTO, this.m_ParameterIDAKTIVNOST, this.m_ParameterIDPARTNER, this.m_ParameterDODATNIUVJET, this.m_ParameterGODINA, this.startRowThread, this.PageSize);
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
            this.Text = "S_FIN_OTVORENE_STAVKE : " + this.DataView.Count.ToString(CultureInfo.InvariantCulture) + " " + Deklarit.Resources.Resources.Rows;
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
        public virtual IS_FIN_OTVORENE_STAVKEDataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.GetS_FIN_OTVORENE_STAVKEDataAdapter();
                }
                return null;
            }
        }

        [Category("Deklarit Work With "), Browsable(false)]
        public virtual S_FIN_OTVORENE_STAVKEDataSet DataSet
        {
            get
            {
                return this.dsS_FIN_OTVORENE_STAVKEDataSet1;
            }
            set
            {
                this.dsS_FIN_OTVORENE_STAVKEDataSet1 = value;
            }
        }

        [Category("Deklarit Work With "), Browsable(false)]
        public virtual System.Data.DataView DataView
        {
            get
            {
                return this.dv1;
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

        [Browsable(false), DefaultValue(false)]
        public virtual bool GridLoading
        {
            get
            {
                return this.m_GridLoading;
            }
        }

        [Category("Deklarit Work With "), DefaultValue(60)]
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

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterDODATNIUVJET
        {
            get
            {
                return this.m_ParameterDODATNIUVJET;
            }
            set
            {
                this.m_ParameterDODATNIUVJET = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterDOK
        {
            get
            {
                return this.m_ParameterDOK;
            }
            set
            {
                this.m_ParameterDOK = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual short ParameterGODINA
        {
            get
            {
                return this.m_ParameterGODINA;
            }
            set
            {
                this.m_ParameterGODINA = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterIDAKTIVNOST
        {
            get
            {
                return this.m_ParameterIDAKTIVNOST;
            }
            set
            {
                this.m_ParameterIDAKTIVNOST = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterIDPARTNER
        {
            get
            {
                return this.m_ParameterIDPARTNER;
            }
            set
            {
                this.m_ParameterIDPARTNER = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterMT
        {
            get
            {
                return this.m_ParameterMT;
            }
            set
            {
                this.m_ParameterMT = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterORG
        {
            get
            {
                return this.m_ParameterORG;
            }
            set
            {
                this.m_ParameterORG = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterPOCETNIKONTO
        {
            get
            {
                return this.m_ParameterPOCETNIKONTO;
            }
            set
            {
                this.m_ParameterPOCETNIKONTO = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual DateTime ParameterRAZDOBLJEDO
        {
            get
            {
                return this.m_ParameterRAZDOBLJEDO;
            }
            set
            {
                this.m_ParameterRAZDOBLJEDO = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual DateTime ParameterRAZDOBLJEOD
        {
            get
            {
                return this.m_ParameterRAZDOBLJEOD;
            }
            set
            {
                this.m_ParameterRAZDOBLJEOD = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterZAVRSNIKONTO
        {
            get
            {
                return this.m_ParameterZAVRSNIKONTO;
            }
            set
            {
                this.m_ParameterZAVRSNIKONTO = value;
            }
        }
    }
}

