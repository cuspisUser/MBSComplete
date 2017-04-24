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

    public class SP_LISTA_IZNOSA_RADNIKADataGrid : DeklaritDataGrid
    {
        private int currentRow;
        private SP_LISTA_IZNOSA_RADNIKADataSet dsSP_LISTA_IZNOSA_RADNIKADataSet1 = new SP_LISTA_IZNOSA_RADNIKADataSet();
        private System.Data.DataView dv1;
        private bool m_FillByPage = true;
        private bool m_GridLoading;
        private int m_PageSize = 60;
        private string m_ParameterGODINAOBRACUNA = "";
        private string m_ParameterIDOBRACUN = "";
        private string m_ParameterMJESECOBRACUNA = "";
        private int m_ParameterSORT = 0;
        private int m_StartRow;
        private int startRowThread;
        private const int WM_SETREDRAW = 11;

        public SP_LISTA_IZNOSA_RADNIKADataGrid()
        {
            this.BindDataGrid();
            this.AfterRowRegionScroll += new RowScrollRegionEventHandler(this.Grid_AfterRowRegionScroll);
            this.AfterSelectChange += new AfterSelectChangeEventHandler(this.Grid_AfterSelectChange);
        }

        private void BindDataGrid()
        {
            this.dv1 = new System.Data.DataView();
            this.dv1.Table = this.dsSP_LISTA_IZNOSA_RADNIKADataSet1.SP_LISTA_IZNOSA_RADNIKA;
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
            this.dsSP_LISTA_IZNOSA_RADNIKADataSet1 = new SP_LISTA_IZNOSA_RADNIKADataSet();
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
                    this.DataAdapter.FillPage(this.dsSP_LISTA_IZNOSA_RADNIKADataSet1, this.m_ParameterIDOBRACUN, this.m_ParameterMJESECOBRACUNA, this.m_ParameterGODINAOBRACUNA, this.m_ParameterSORT, 0, this.PageSize);
                }
                else
                {
                    this.DataAdapter.Fill(this.dsSP_LISTA_IZNOSA_RADNIKADataSet1, this.m_ParameterIDOBRACUN, this.m_ParameterMJESECOBRACUNA, this.m_ParameterGODINAOBRACUNA, this.m_ParameterSORT);
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
                    this.DataAdapter.FillPage(this.dsSP_LISTA_IZNOSA_RADNIKADataSet1, this.m_ParameterIDOBRACUN, this.m_ParameterMJESECOBRACUNA, this.m_ParameterGODINAOBRACUNA, this.m_ParameterSORT, this.startRowThread, this.PageSize);
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
            this.Text = "SP_LISTA_IZNOSA_RADNIKA : " + this.DataView.Count.ToString(CultureInfo.InvariantCulture) + " " + Deklarit.Resources.Resources.Rows;
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
        public virtual ISP_LISTA_IZNOSA_RADNIKADataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.GetSP_LISTA_IZNOSA_RADNIKADataAdapter();
                }
                return null;
            }
        }

        [Category("Deklarit Work With "), Browsable(false)]
        public virtual SP_LISTA_IZNOSA_RADNIKADataSet DataSet
        {
            get
            {
                return this.dsSP_LISTA_IZNOSA_RADNIKADataSet1;
            }
            set
            {
                this.dsSP_LISTA_IZNOSA_RADNIKADataSet1 = value;
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
        public virtual string ParameterGODINAOBRACUNA
        {
            get
            {
                return this.m_ParameterGODINAOBRACUNA;
            }
            set
            {
                this.m_ParameterGODINAOBRACUNA = value;
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
        public virtual string ParameterMJESECOBRACUNA
        {
            get
            {
                return this.m_ParameterMJESECOBRACUNA;
            }
            set
            {
                this.m_ParameterMJESECOBRACUNA = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterSORT
        {
            get
            {
                return this.m_ParameterSORT;
            }
            set
            {
                this.m_ParameterSORT = value;
            }
        }
    }
}

