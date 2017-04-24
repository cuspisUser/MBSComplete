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

    public class GKSTAVKADataGrid : DeklaritDataGrid
    {
        private int currentRow;
        private GKSTAVKADataSet dsGKSTAVKADataSet1 = new GKSTAVKADataSet();
        private System.Data.DataView dv1;
        private int m_FillByBROJSTAVKEBROJSTAVKE;
        private short m_FillByGKGODIDGODINEGKGODIDGODINE;
        private int m_FillByIDDOKUMENTBROJDOKUMENTABROJDOKUMENTA;
        private int m_FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEBROJDOKUMENTA;
        private short m_FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEGKGODIDGODINE;
        private int m_FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEIDDOKUMENT;
        private int m_FillByIDDOKUMENTBROJDOKUMENTAIDDOKUMENT;
        private int m_FillByIDDOKUMENTIDDOKUMENT;
        private string m_FillByIDKONTOIDKONTO;
        private int m_FillByIDMJESTOTROSKAIDMJESTOTROSKA;
        private int m_FillByIDORGJEDIDORGJED;
        private int m_FillByIDPARTNERIDPARTNER;
        private bool m_FillByPage = false;
        private string m_FillMethod = "Fill";
        private bool m_GridLoading;
        private int m_PageSize = 60;
        private int m_StartRow;
        private int startRowThread;
        private const int WM_SETREDRAW = 11;

        public GKSTAVKADataGrid()
        {
            this.BindDataGrid();
            DeklaritDataGrid.myFillMethods = new TypeConverter.StandardValuesCollection(new string[] { "Fill", "FillByIDKONTO", "FillByGKGODIDGODINE", "FillByIDDOKUMENT", "FillByIDDOKUMENTBROJDOKUMENTA", "FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE", "FillByBROJSTAVKE", "FillByIDMJESTOTROSKA", "FillByIDORGJED", "FillByIDPARTNER" });
            this.AfterRowRegionScroll += new RowScrollRegionEventHandler(this.Grid_AfterRowRegionScroll);
            this.AfterSelectChange += new AfterSelectChangeEventHandler(this.Grid_AfterSelectChange);
        }

        private void BindDataGrid()
        {
            this.dv1 = new System.Data.DataView();
            this.dv1.Table = this.dsGKSTAVKADataSet1.GKSTAVKA;
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
            this.dsGKSTAVKADataSet1 = new GKSTAVKADataSet();
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
                        this.DataAdapter.FillPage(this.dsGKSTAVKADataSet1, 0, this.PageSize);
                    }
                    else
                    {
                        MethodInfo info = this.DataAdapter.GetType().GetMethod("FillPageBy" + this.FillMethod.Substring(6));
                        this.InvokeFillByMethod(this.FillMethod, (IDataAdapter) this.DataAdapter, this.dsGKSTAVKADataSet1, info, 0, this.PageSize);
                    }
                }
                else if (this.FillMethod == "Fill")
                {
                    this.DataAdapter.Fill(this.dsGKSTAVKADataSet1);
                }
                else
                {
                    MethodInfo info2 = this.DataAdapter.GetType().GetMethod(this.FillMethod);
                    this.InvokeFillByMethod(this.FillMethod, (IDataAdapter) this.DataAdapter, this.dsGKSTAVKADataSet1, info2);
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
                    if (this.FillMethod == "Fill")
                    {
                        this.DataAdapter.FillPage(this.dsGKSTAVKADataSet1, this.startRowThread, this.PageSize);
                    }
                    else
                    {
                        MethodInfo info = this.DataAdapter.GetType().GetMethod("FillPageBy" + this.FillMethod.Substring(6));
                        this.InvokeFillByMethod(this.FillMethod, (IDataAdapter) this.DataAdapter, this.dsGKSTAVKADataSet1, info, this.startRowThread, this.PageSize);
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
            this.Text = "GKSTAVKA : " + this.DataView.Count.ToString(CultureInfo.InvariantCulture) + " " + Deklarit.Resources.Resources.Rows;
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
        public virtual IGKSTAVKADataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.GetGKSTAVKADataAdapter();
                }
                return null;
            }
        }

        [Category("Deklarit Work With "), Browsable(false)]
        public virtual GKSTAVKADataSet DataSet
        {
            get
            {
                return this.dsGKSTAVKADataSet1;
            }
            set
            {
                this.dsGKSTAVKADataSet1 = value;
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
        public virtual int FillByBROJSTAVKEBROJSTAVKE
        {
            get
            {
                return this.m_FillByBROJSTAVKEBROJSTAVKE;
            }
            set
            {
                this.m_FillByBROJSTAVKEBROJSTAVKE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual short FillByGKGODIDGODINEGKGODIDGODINE
        {
            get
            {
                return this.m_FillByGKGODIDGODINEGKGODIDGODINE;
            }
            set
            {
                this.m_FillByGKGODIDGODINEGKGODIDGODINE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDDOKUMENTBROJDOKUMENTABROJDOKUMENTA
        {
            get
            {
                return this.m_FillByIDDOKUMENTBROJDOKUMENTABROJDOKUMENTA;
            }
            set
            {
                this.m_FillByIDDOKUMENTBROJDOKUMENTABROJDOKUMENTA = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEBROJDOKUMENTA
        {
            get
            {
                return this.m_FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEBROJDOKUMENTA;
            }
            set
            {
                this.m_FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEBROJDOKUMENTA = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual short FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEGKGODIDGODINE
        {
            get
            {
                return this.m_FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEGKGODIDGODINE;
            }
            set
            {
                this.m_FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEGKGODIDGODINE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEIDDOKUMENT
        {
            get
            {
                return this.m_FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEIDDOKUMENT;
            }
            set
            {
                this.m_FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEIDDOKUMENT = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDDOKUMENTBROJDOKUMENTAIDDOKUMENT
        {
            get
            {
                return this.m_FillByIDDOKUMENTBROJDOKUMENTAIDDOKUMENT;
            }
            set
            {
                this.m_FillByIDDOKUMENTBROJDOKUMENTAIDDOKUMENT = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDDOKUMENTIDDOKUMENT
        {
            get
            {
                return this.m_FillByIDDOKUMENTIDDOKUMENT;
            }
            set
            {
                this.m_FillByIDDOKUMENTIDDOKUMENT = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual string FillByIDKONTOIDKONTO
        {
            get
            {
                return this.m_FillByIDKONTOIDKONTO;
            }
            set
            {
                this.m_FillByIDKONTOIDKONTO = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDMJESTOTROSKAIDMJESTOTROSKA
        {
            get
            {
                return this.m_FillByIDMJESTOTROSKAIDMJESTOTROSKA;
            }
            set
            {
                this.m_FillByIDMJESTOTROSKAIDMJESTOTROSKA = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDORGJEDIDORGJED
        {
            get
            {
                return this.m_FillByIDORGJEDIDORGJED;
            }
            set
            {
                this.m_FillByIDORGJEDIDORGJED = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDPARTNERIDPARTNER
        {
            get
            {
                return this.m_FillByIDPARTNERIDPARTNER;
            }
            set
            {
                this.m_FillByIDPARTNERIDPARTNER = value;
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

        [TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), DefaultValue("Fill"), Category("Deklarit Work With ")]
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

        [DefaultValue(false), Browsable(false)]
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

