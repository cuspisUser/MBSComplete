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

    public class sp_VIRMANIDataGrid : DeklaritDataGrid
    {
        private int currentRow;
        private sp_VIRMANIDataSet dssp_VIRMANIDataSet1 = new sp_VIRMANIDataSet();
        private System.Data.DataView dv1;
        private bool m_FillByPage = true;
        private bool m_GridLoading;
        private int m_PageSize = 60;
        private string m_Parameterdd = "";
        private string m_ParameterIDOBRACUN = "";
        private string m_Parametermb = "";
        private string m_Parameterpl1 = "";
        private string m_Parameterpl2 = "";
        private string m_Parameterpl3 = "";
        private string m_Parameterporeziprirezodvojeno = "";
        private string m_Parametervbd = "";
        private string m_Parameterzaduzenje = "";
        private string m_Parameterzrn = "";
        private int m_StartRow;
        private int startRowThread;
        private const int WM_SETREDRAW = 11;

        public sp_VIRMANIDataGrid()
        {
            this.BindDataGrid();
            this.AfterRowRegionScroll += new RowScrollRegionEventHandler(this.Grid_AfterRowRegionScroll);
            this.AfterSelectChange += new AfterSelectChangeEventHandler(this.Grid_AfterSelectChange);
        }

        private void BindDataGrid()
        {
            this.dv1 = new System.Data.DataView();
            this.dv1.Table = this.dssp_VIRMANIDataSet1.sp_VIRMANI;
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
            this.dssp_VIRMANIDataSet1 = new sp_VIRMANIDataSet();
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
                    this.DataAdapter.FillPage(this.dssp_VIRMANIDataSet1, this.m_ParameterIDOBRACUN, this.m_Parameterzaduzenje, this.m_Parameterporeziprirezodvojeno, this.m_Parameterpl1, this.m_Parameterpl2, this.m_Parameterpl3, this.m_Parametervbd, this.m_Parameterzrn, this.m_Parametermb, this.m_Parameterdd, 0, this.PageSize);
                }
                else
                {
                    this.DataAdapter.Fill(this.dssp_VIRMANIDataSet1, this.m_ParameterIDOBRACUN, this.m_Parameterzaduzenje, this.m_Parameterporeziprirezodvojeno, this.m_Parameterpl1, this.m_Parameterpl2, this.m_Parameterpl3, this.m_Parametervbd, this.m_Parameterzrn, this.m_Parametermb, this.m_Parameterdd);
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
                    this.DataAdapter.FillPage(this.dssp_VIRMANIDataSet1, this.m_ParameterIDOBRACUN, this.m_Parameterzaduzenje, this.m_Parameterporeziprirezodvojeno, this.m_Parameterpl1, this.m_Parameterpl2, this.m_Parameterpl3, this.m_Parametervbd, this.m_Parameterzrn, this.m_Parametermb, this.m_Parameterdd, this.startRowThread, this.PageSize);
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
            this.Text = "sp_VIRMANI : " + this.DataView.Count.ToString(CultureInfo.InvariantCulture) + " " + Deklarit.Resources.Resources.Rows;
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

        [Browsable(false), Category("Deklarit Work With ")]
        public virtual Isp_VIRMANIDataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.Getsp_VIRMANIDataAdapter();
                }
                return null;
            }
        }

        [Category("Deklarit Work With "), Browsable(false)]
        public virtual sp_VIRMANIDataSet DataSet
        {
            get
            {
                return this.dssp_VIRMANIDataSet1;
            }
            set
            {
                this.dssp_VIRMANIDataSet1 = value;
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

        [DefaultValue(false), Browsable(false)]
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
        public virtual string Parameterdd
        {
            get
            {
                return this.m_Parameterdd;
            }
            set
            {
                this.m_Parameterdd = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterIDOBRACUN
        {
            get
            {
                return this.m_ParameterIDOBRACUN;
            }
            set
            {
                this.m_ParameterIDOBRACUN = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parametermb
        {
            get
            {
                return this.m_Parametermb;
            }
            set
            {
                this.m_Parametermb = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameterpl1
        {
            get
            {
                return this.m_Parameterpl1;
            }
            set
            {
                this.m_Parameterpl1 = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameterpl2
        {
            get
            {
                return this.m_Parameterpl2;
            }
            set
            {
                this.m_Parameterpl2 = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameterpl3
        {
            get
            {
                return this.m_Parameterpl3;
            }
            set
            {
                this.m_Parameterpl3 = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameterporeziprirezodvojeno
        {
            get
            {
                return this.m_Parameterporeziprirezodvojeno;
            }
            set
            {
                this.m_Parameterporeziprirezodvojeno = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parametervbd
        {
            get
            {
                return this.m_Parametervbd;
            }
            set
            {
                this.m_Parametervbd = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameterzaduzenje
        {
            get
            {
                return this.m_Parameterzaduzenje;
            }
            set
            {
                this.m_Parameterzaduzenje = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameterzrn
        {
            get
            {
                return this.m_Parameterzrn;
            }
            set
            {
                this.m_Parameterzrn = value;
            }
        }
    }
}

