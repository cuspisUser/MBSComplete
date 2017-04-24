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

    public class sp_maticni_kartonDataGrid : DeklaritDataGrid
    {
        private int currentRow;
        private sp_maticni_kartonDataSet dssp_maticni_kartonDataSet1 = new sp_maticni_kartonDataSet();
        private System.Data.DataView dv1;
        private bool m_FillByPage = true;
        private bool m_GridLoading;
        private int m_PageSize = 60;
        private string m_Parametergodina = "";
        private int m_Parameteridradnik_do = 0;
        private int m_Parameteridradnik_od = 0;
        private bool m_Parameterukljucenobruto = false;
        private bool m_Parameterukljucenodoprinosiiz = false;
        private bool m_Parameterukljucenodoprinosina = false;
        private bool m_Parameterukljucenoisplata = false;
        private bool m_Parameterukljucenonetonaknade = false;
        private bool m_Parameterukljucenonetoplaca = false;
        private bool m_Parameterukljucenoobustave = false;
        private bool m_Parameterukljucenoolaksice = false;
        private bool m_Parameterukljucenooo = false;
        private bool m_Parameterukljucenoporezi = false;
        private bool m_Parameterzbirni = false;
        private int m_StartRow;
        private int startRowThread;
        private const int WM_SETREDRAW = 11;

        public sp_maticni_kartonDataGrid()
        {
            this.BindDataGrid();
            this.AfterRowRegionScroll += new RowScrollRegionEventHandler(this.Grid_AfterRowRegionScroll);
            this.AfterSelectChange += new AfterSelectChangeEventHandler(this.Grid_AfterSelectChange);
        }

        private void BindDataGrid()
        {
            this.dv1 = new System.Data.DataView();
            this.dv1.Table = this.dssp_maticni_kartonDataSet1.sp_maticni_karton;
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
            this.dssp_maticni_kartonDataSet1 = new sp_maticni_kartonDataSet();
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
                    this.DataAdapter.FillPage(this.dssp_maticni_kartonDataSet1, this.m_Parametergodina, this.m_Parameteridradnik_od, this.m_Parameteridradnik_do, this.m_Parameterzbirni, this.m_Parameterukljucenobruto, this.m_Parameterukljucenodoprinosiiz, this.m_Parameterukljucenodoprinosina, this.m_Parameterukljucenoporezi, this.m_Parameterukljucenooo, this.m_Parameterukljucenoobustave, this.m_Parameterukljucenoolaksice, this.m_Parameterukljucenonetoplaca, this.m_Parameterukljucenonetonaknade, this.m_Parameterukljucenoisplata, 0, this.PageSize);
                }
                else
                {
                    this.DataAdapter.Fill(this.dssp_maticni_kartonDataSet1, this.m_Parametergodina, this.m_Parameteridradnik_od, this.m_Parameteridradnik_do, this.m_Parameterzbirni, this.m_Parameterukljucenobruto, this.m_Parameterukljucenodoprinosiiz, this.m_Parameterukljucenodoprinosina, this.m_Parameterukljucenoporezi, this.m_Parameterukljucenooo, this.m_Parameterukljucenoobustave, this.m_Parameterukljucenoolaksice, this.m_Parameterukljucenonetoplaca, this.m_Parameterukljucenonetonaknade, this.m_Parameterukljucenoisplata);
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
                    this.DataAdapter.FillPage(this.dssp_maticni_kartonDataSet1, this.m_Parametergodina, this.m_Parameteridradnik_od, this.m_Parameteridradnik_do, this.m_Parameterzbirni, this.m_Parameterukljucenobruto, this.m_Parameterukljucenodoprinosiiz, this.m_Parameterukljucenodoprinosina, this.m_Parameterukljucenoporezi, this.m_Parameterukljucenooo, this.m_Parameterukljucenoobustave, this.m_Parameterukljucenoolaksice, this.m_Parameterukljucenonetoplaca, this.m_Parameterukljucenonetonaknade, this.m_Parameterukljucenoisplata, this.startRowThread, this.PageSize);
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
            this.Text = "sp_maticni_karton : " + this.DataView.Count.ToString(CultureInfo.InvariantCulture) + " " + Deklarit.Resources.Resources.Rows;
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
        public virtual Isp_maticni_kartonDataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.Getsp_maticni_kartonDataAdapter();
                }
                return null;
            }
        }

        [Category("Deklarit Work With "), Browsable(false)]
        public virtual sp_maticni_kartonDataSet DataSet
        {
            get
            {
                return this.dssp_maticni_kartonDataSet1;
            }
            set
            {
                this.dssp_maticni_kartonDataSet1 = value;
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

        [Category("Deklarit Work With "), DefaultValue(true)]
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
        public virtual string Parametergodina
        {
            get
            {
                return this.m_Parametergodina;
            }
            set
            {
                this.m_Parametergodina = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int Parameteridradnik_do
        {
            get
            {
                return this.m_Parameteridradnik_do;
            }
            set
            {
                this.m_Parameteridradnik_do = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int Parameteridradnik_od
        {
            get
            {
                return this.m_Parameteridradnik_od;
            }
            set
            {
                this.m_Parameteridradnik_od = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenobruto
        {
            get
            {
                return this.m_Parameterukljucenobruto;
            }
            set
            {
                this.m_Parameterukljucenobruto = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenodoprinosiiz
        {
            get
            {
                return this.m_Parameterukljucenodoprinosiiz;
            }
            set
            {
                this.m_Parameterukljucenodoprinosiiz = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenodoprinosina
        {
            get
            {
                return this.m_Parameterukljucenodoprinosina;
            }
            set
            {
                this.m_Parameterukljucenodoprinosina = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenoisplata
        {
            get
            {
                return this.m_Parameterukljucenoisplata;
            }
            set
            {
                this.m_Parameterukljucenoisplata = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenonetonaknade
        {
            get
            {
                return this.m_Parameterukljucenonetonaknade;
            }
            set
            {
                this.m_Parameterukljucenonetonaknade = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenonetoplaca
        {
            get
            {
                return this.m_Parameterukljucenonetoplaca;
            }
            set
            {
                this.m_Parameterukljucenonetoplaca = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenoobustave
        {
            get
            {
                return this.m_Parameterukljucenoobustave;
            }
            set
            {
                this.m_Parameterukljucenoobustave = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenoolaksice
        {
            get
            {
                return this.m_Parameterukljucenoolaksice;
            }
            set
            {
                this.m_Parameterukljucenoolaksice = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenooo
        {
            get
            {
                return this.m_Parameterukljucenooo;
            }
            set
            {
                this.m_Parameterukljucenooo = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenoporezi
        {
            get
            {
                return this.m_Parameterukljucenoporezi;
            }
            set
            {
                this.m_Parameterukljucenoporezi = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterzbirni
        {
            get
            {
                return this.m_Parameterzbirni;
            }
            set
            {
                this.m_Parameterzbirni = value;
            }
        }
    }
}

