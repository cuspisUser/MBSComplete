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

    public class S_FIN_DNEVNIKBLAGAJNEODDOUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_FIN_DNEVNIKBLAGAJNEODDO";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_FIN_DNEVNIKBLAGAJNEODDO";
        private S_FIN_DNEVNIKBLAGAJNEODDODataGrid userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO;

        public S_FIN_DNEVNIKBLAGAJNEODDOUserDataGrid()
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
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO = new S_FIN_DNEVNIKBLAGAJNEODDODataGrid();
            ((ISupportInitialize) this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO).BeginInit();
            UltraGridBand band = new UltraGridBand("S_FIN_DNEVNIKBLAGAJNEODDO", -1);
            UltraGridColumn column8 = new UltraGridColumn("NAZIVVRSTEDOK");
            UltraGridColumn column2 = new UltraGridColumn("BLGDATUMDOKUMENTA");
            UltraGridColumn column = new UltraGridColumn("BLGBROJDOKUMENTA");
            UltraGridColumn column5 = new UltraGridColumn("IDBLGVRSTEDOK");
            UltraGridColumn column4 = new UltraGridColumn("BLGSVRHA");
            UltraGridColumn column9 = new UltraGridColumn("PRIMITAK");
            UltraGridColumn column6 = new UltraGridColumn("IZDATAK");
            UltraGridColumn column3 = new UltraGridColumn("BLGSLOVIMA");
            UltraGridColumn column7 = new UltraGridColumn("KONTA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNEODDONAZIVVRSTEDOKDescription;
            column8.Width = 0xe2;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNEODDOBLGDATUMDOKUMENTADescription;
            column2.Width = 0x87;
            column2.MinValue = DateTime.MinValue;
            column2.MaxValue = DateTime.MaxValue;
            column2.Format = "d";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNEODDOBLGBROJDOKUMENTADescription;
            column.Width = 0x7e;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNEODDOIDBLGVRSTEDOKDescription;
            column5.Width = 0x69;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnn";
            column5.PromptChar = ' ';
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNEODDOBLGSVRHADescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNEODDOPRIMITAKDescription;
            column9.Width = 0x66;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNEODDOIZDATAKDescription;
            column6.Width = 0x66;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNEODDOBLGSLOVIMADescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNEODDOKONTADescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 3;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 4;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 5;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 6;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 7;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 8;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.Location = point;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.Name = "userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO";
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.Tag = "S_FIN_DNEVNIKBLAGAJNEODDO";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.Size = size;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.FillAtStartup = false;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.InitializeRow += new InitializeRowEventHandler(this.S_FIN_DNEVNIKBLAGAJNEODDOUserDataGrid_InitializeRow);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO });
            this.Name = "S_FIN_DNEVNIKBLAGAJNEODDOUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_FIN_DNEVNIKBLAGAJNEODDOUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO).EndInit();
            this.ResumeLayout(false);
        }

        private void S_FIN_DNEVNIKBLAGAJNEODDOUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_FIN_DNEVNIKBLAGAJNEODDOUserDataGrid_Load(object sender, EventArgs e)
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

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
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
        public virtual S_FIN_DNEVNIKBLAGAJNEODDODataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO;
            }
            set
            {
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO = value;
            }
        }

        [Category("Deklarit Work With "), Browsable(false)]
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

        [Category("Deklarit Work With "), DefaultValue(true)]
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

        [Category("Deklarit Work With "), DefaultValue(60)]
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
        public virtual short ParameterAKTIVNAGODINA
        {
            get
            {
                return this.DataGrid.ParameterAKTIVNAGODINA;
            }
            set
            {
                this.DataGrid.ParameterAKTIVNAGODINA = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterBLAG
        {
            get
            {
                return this.DataGrid.ParameterBLAG;
            }
            set
            {
                this.DataGrid.ParameterBLAG = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterDOO
        {
            get
            {
                return this.DataGrid.ParameterDOO;
            }
            set
            {
                this.DataGrid.ParameterDOO = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterODD
        {
            get
            {
                return this.DataGrid.ParameterODD;
            }
            set
            {
                this.DataGrid.ParameterODD = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterVRSTA
        {
            get
            {
                return this.DataGrid.ParameterVRSTA;
            }
            set
            {
                this.DataGrid.ParameterVRSTA = value;
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

