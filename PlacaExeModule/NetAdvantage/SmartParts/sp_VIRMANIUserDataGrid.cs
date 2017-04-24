namespace NetAdvantage.SmartParts
{
    using Infragistics.Win;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using NetAdvantage.Controls;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class sp_VIRMANIUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with sp_VIRMANI";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with sp_VIRMANI";
        private sp_VIRMANIDataGrid userControlDataGridsp_VIRMANI;

        public sp_VIRMANIUserDataGrid()
        {
            this.InitializeComponent();
        }

        private static void CreateValueList(UltraGrid dataGrid1, string valueListName, System.Data.DataView dataList, string Id, string Name)
        {
            ValueList list = null;
            if (dataGrid1.DisplayLayout.ValueLists.Exists(valueListName) && (dataGrid1.DisplayLayout.ValueLists[valueListName].ValueListItems.Count != dataList.Count))
            {
                dataGrid1.DisplayLayout.ValueLists.Remove(valueListName);
                list = dataGrid1.DisplayLayout.ValueLists.Add(valueListName);
            }
            if (!dataGrid1.DisplayLayout.ValueLists.Exists(valueListName))
            {
                list = dataGrid1.DisplayLayout.ValueLists.Add(valueListName);
            }
            if (list != null)
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = dataList.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRowView current = (DataRowView) enumerator.Current;
                        DataRow row = current.Row;
                        ValueListItem item = new ValueListItem {
                            DataValue = RuntimeHelpers.GetObjectValue(row[Id]),
                            DisplayText = row[Name].ToString()
                        };
                        list.ValueListItems.Add(item);
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                list.Tag = dataList;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Fill()
        {
            this.SetComboBoxColumnProperties(false);
            this.DataGrid.Fill();
        }

        private void InitializeComponent()
        {
            this.userControlDataGridsp_VIRMANI = new sp_VIRMANIDataGrid();
            ((ISupportInitialize) this.userControlDataGridsp_VIRMANI).BeginInit();
            UltraGridBand band = new UltraGridBand("sp_VIRMANI", -1);
            UltraGridColumn column20 = new UltraGridColumn("SIFRAOBRACUNAVIRMAN");
            UltraGridColumn column12 = new UltraGridColumn("PLA1");
            UltraGridColumn column13 = new UltraGridColumn("PLA2");
            UltraGridColumn column14 = new UltraGridColumn("PLA3");
            UltraGridColumn column = new UltraGridColumn("BROJRACUNAPLA");
            UltraGridColumn column8 = new UltraGridColumn("MODELZADUZENJA");
            UltraGridColumn column16 = new UltraGridColumn("POZIVZADUZENJA");
            UltraGridColumn column17 = new UltraGridColumn("PRI1");
            UltraGridColumn column18 = new UltraGridColumn("PRI2");
            UltraGridColumn column19 = new UltraGridColumn("PRI3");
            UltraGridColumn column2 = new UltraGridColumn("BROJRACUNAPRI");
            UltraGridColumn column7 = new UltraGridColumn("MODELODOBRENJA");
            UltraGridColumn column15 = new UltraGridColumn("POZIVODOBRENJA");
            UltraGridColumn column21 = new UltraGridColumn("SIFRAOPISAPLACANJAVIRMAN");
            UltraGridColumn column10 = new UltraGridColumn("OPISPLACANJAVIRMAN");
            UltraGridColumn column4 = new UltraGridColumn("DATUMVALUTE");
            UltraGridColumn column3 = new UltraGridColumn("DATUMPODNOSENJA");
            UltraGridColumn column6 = new UltraGridColumn("IZVORDOKUMENTA");
            UltraGridColumn column11 = new UltraGridColumn("OZNACEN");
            UltraGridColumn column5 = new UltraGridColumn("IZNOS");
            UltraGridColumn column9 = new UltraGridColumn("NAMJENA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.sp_VIRMANISIFRAOBRACUNAVIRMANDescription;
            column20.Width = 0x95;
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.sp_VIRMANIPLA1Description;
            column12.Width = 0x9c;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.sp_VIRMANIPLA2Description;
            column13.Width = 0x9c;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.sp_VIRMANIPLA3Description;
            column14.Width = 0x9c;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.sp_VIRMANIBROJRACUNAPLADescription;
            column.Width = 0x8e;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.sp_VIRMANIMODELZADUZENJADescription;
            column8.Width = 0x72;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.sp_VIRMANIPOZIVZADUZENJADescription;
            column16.Width = 170;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.sp_VIRMANIPRI1Description;
            column17.Width = 0x9c;
            column17.Format = "";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.sp_VIRMANIPRI2Description;
            column18.Width = 0x9c;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.sp_VIRMANIPRI3Description;
            column19.Width = 0x9c;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.sp_VIRMANIBROJRACUNAPRIDescription;
            column2.Width = 0x8e;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.sp_VIRMANIMODELODOBRENJADescription;
            column7.Width = 0x72;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.sp_VIRMANIPOZIVODOBRENJADescription;
            column15.Width = 170;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.sp_VIRMANISIFRAOPISAPLACANJAVIRMANDescription;
            column21.Width = 0xb8;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.sp_VIRMANIOPISPLACANJAVIRMANDescription;
            column10.Width = 0x10c;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.sp_VIRMANIDATUMVALUTEDescription;
            column4.Width = 100;
            column4.MinValue = DateTime.MinValue;
            column4.MaxValue = DateTime.MaxValue;
            column4.Format = "d";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.sp_VIRMANIDATUMPODNOSENJADescription;
            column3.Width = 0x79;
            column3.MinValue = DateTime.MinValue;
            column3.MaxValue = DateTime.MaxValue;
            column3.Format = "d";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.sp_VIRMANIIZVORDOKUMENTADescription;
            column6.Width = 0x72;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.sp_VIRMANIOZNACENDescription;
            column11.Width = 0x41;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.sp_VIRMANIIZNOSDescription;
            column5.Width = 0x66;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.sp_VIRMANINAMJENADescription;
            column9.Width = 0x9c;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 0;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 1;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 2;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 4;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 5;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 6;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 7;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 8;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 9;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 10;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 11;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 12;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 13;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 14;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 15;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0x10;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 0x11;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 0x12;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 0x13;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 20;
            this.userControlDataGridsp_VIRMANI.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridsp_VIRMANI.Location = point;
            this.userControlDataGridsp_VIRMANI.Name = "userControlDataGridsp_VIRMANI";
            this.userControlDataGridsp_VIRMANI.Tag = "sp_VIRMANI";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridsp_VIRMANI.Size = size;
            this.userControlDataGridsp_VIRMANI.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridsp_VIRMANI.Dock = DockStyle.Fill;
            this.userControlDataGridsp_VIRMANI.FillAtStartup = false;
            this.userControlDataGridsp_VIRMANI.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridsp_VIRMANI.InitializeRow += new InitializeRowEventHandler(this.sp_VIRMANIUserDataGrid_InitializeRow);
            this.userControlDataGridsp_VIRMANI.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridsp_VIRMANI });
            this.Name = "sp_VIRMANIUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.sp_VIRMANIUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridsp_VIRMANI).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
        }

        private void sp_VIRMANIUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void sp_VIRMANIUserDataGrid_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.SetComboBoxColumnProperties(true);
                if (this.FillAtStartup)
                {
                    this.DataGrid.Fill();
                }
            }
        }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.DataView[this.DataGrid.CurrentRowIndex].Row;
            }
        }

        [Browsable(false)]
        public virtual sp_VIRMANIDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridsp_VIRMANI;
            }
            set
            {
                this.userControlDataGridsp_VIRMANI = value;
            }
        }

        [Browsable(false), Category("Deklarit Work With ")]
        public virtual System.Data.DataView DataView
        {
            get
            {
                return this.DataGrid.DataView;
            }
        }

        public string Description
        {
            get
            {
                return this.m_Description;
            }
            set
            {
                this.m_Description = value;
            }
        }

        [DefaultValue(true), Description("True= Fill at Startup. False= Not Fill"), Category("Deklarit Work With ")]
        public virtual bool FillAtStartup
        {
            get
            {
                return this.m_FillAtStartup;
            }
            set
            {
                this.m_FillAtStartup = value;
            }
        }

        [DefaultValue(true), Category("Deklarit Work With ")]
        public virtual bool FillByPage
        {
            get
            {
                return this.DataGrid.FillByPage;
            }
            set
            {
                this.DataGrid.FillByPage = value;
            }
        }

        string Microsoft.Practices.CompositeUI.SmartParts.ISmartPartInfo.Description
        {
            get
            {
                return this.m_Description;
            }
            set
            {
                this.m_Description = value;
            }
        }

        string Microsoft.Practices.CompositeUI.SmartParts.ISmartPartInfo.Title
        {
            get
            {
                return this.m_Title;
            }
            set
            {
                this.m_Title = value;
            }
        }

        [DefaultValue(60), Category("Deklarit Work With ")]
        public virtual int PageSize
        {
            get
            {
                return this.DataGrid.PageSize;
            }
            set
            {
                this.DataGrid.PageSize = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameterdd
        {
            get
            {
                return this.DataGrid.Parameterdd;
            }
            set
            {
                this.DataGrid.Parameterdd = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterIDOBRACUN
        {
            get
            {
                return this.DataGrid.ParameterIDOBRACUN;
            }
            set
            {
                this.DataGrid.ParameterIDOBRACUN = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parametermb
        {
            get
            {
                return this.DataGrid.Parametermb;
            }
            set
            {
                this.DataGrid.Parametermb = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameterpl1
        {
            get
            {
                return this.DataGrid.Parameterpl1;
            }
            set
            {
                this.DataGrid.Parameterpl1 = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameterpl2
        {
            get
            {
                return this.DataGrid.Parameterpl2;
            }
            set
            {
                this.DataGrid.Parameterpl2 = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameterpl3
        {
            get
            {
                return this.DataGrid.Parameterpl3;
            }
            set
            {
                this.DataGrid.Parameterpl3 = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameterporeziprirezodvojeno
        {
            get
            {
                return this.DataGrid.Parameterporeziprirezodvojeno;
            }
            set
            {
                this.DataGrid.Parameterporeziprirezodvojeno = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parametervbd
        {
            get
            {
                return this.DataGrid.Parametervbd;
            }
            set
            {
                this.DataGrid.Parametervbd = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameterzaduzenje
        {
            get
            {
                return this.DataGrid.Parameterzaduzenje;
            }
            set
            {
                this.DataGrid.Parameterzaduzenje = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameterzrn
        {
            get
            {
                return this.DataGrid.Parameterzrn;
            }
            set
            {
                this.DataGrid.Parameterzrn = value;
            }
        }

        public string Title
        {
            get
            {
                return this.m_Title;
            }
            set
            {
                this.m_Title = value;
            }
        }
    }
}

