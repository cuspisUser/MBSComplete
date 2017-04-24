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

    public class S_FIN_KONTO_KARTICEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_FIN_KONTO_KARTICE";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_FIN_KONTO_KARTICE";
        private S_FIN_KONTO_KARTICEDataGrid userControlDataGridS_FIN_KONTO_KARTICE;

        public S_FIN_KONTO_KARTICEUserDataGrid()
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
            this.userControlDataGridS_FIN_KONTO_KARTICE = new S_FIN_KONTO_KARTICEDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_FIN_KONTO_KARTICE).BeginInit();
            UltraGridBand band = new UltraGridBand("S_FIN_KONTO_KARTICE", -1);
            UltraGridColumn column4 = new UltraGridColumn("duguje");
            UltraGridColumn column14 = new UltraGridColumn("POTRAZUJE");
            UltraGridColumn column8 = new UltraGridColumn("konto");
            UltraGridColumn column3 = new UltraGridColumn("DATUMDOK");
            UltraGridColumn column16 = new UltraGridColumn("SKRACENI");
            UltraGridColumn column = new UltraGridColumn("BROJDOK");
            UltraGridColumn column2 = new UltraGridColumn("BROJSTAVKE");
            UltraGridColumn column12 = new UltraGridColumn("OPISKNJIZENJA");
            UltraGridColumn column9 = new UltraGridColumn("NAZIVKONTO");
            UltraGridColumn column5 = new UltraGridColumn("IDDOKUMENT");
            UltraGridColumn column7 = new UltraGridColumn("IDORGJED");
            UltraGridColumn column6 = new UltraGridColumn("IDMJESTOTROSKA");
            UltraGridColumn column13 = new UltraGridColumn("ORIGINALNIDOKUMENT");
            UltraGridColumn column11 = new UltraGridColumn("NAZIVOJ");
            UltraGridColumn column10 = new UltraGridColumn("NAZIVMT");
            UltraGridColumn column15 = new UltraGridColumn("PS");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_FIN_KONTO_KARTICEdugujeDescription;
            column4.Width = 0x66;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.S_FIN_KONTO_KARTICEPOTRAZUJEDescription;
            column14.Width = 0x66;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_FIN_KONTO_KARTICEkontoDescription;
            column8.Width = 0x79;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_FIN_KONTO_KARTICEDATUMDOKDescription;
            column3.Width = 100;
            column3.MinValue = DateTime.MinValue;
            column3.MaxValue = DateTime.MaxValue;
            column3.Format = "d";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.S_FIN_KONTO_KARTICESKRACENIDescription;
            column16.Width = 0x128;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_FIN_KONTO_KARTICEBROJDOKDescription;
            column.Width = 0x48;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_FIN_KONTO_KARTICEBROJSTAVKEDescription;
            column2.Width = 0x55;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.S_FIN_KONTO_KARTICEOPISKNJIZENJADescription;
            column12.Width = 0x128;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.S_FIN_KONTO_KARTICENAZIVKONTODescription;
            column9.Width = 0x128;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_FIN_KONTO_KARTICEIDDOKUMENTDescription;
            column5.Width = 0x77;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnn";
            column5.PromptChar = ' ';
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_FIN_KONTO_KARTICEIDORGJEDDescription;
            column7.Width = 0x48;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnn";
            column7.PromptChar = ' ';
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_FIN_KONTO_KARTICEIDMJESTOTROSKADescription;
            column6.Width = 0x48;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnn";
            column6.PromptChar = ' ';
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.S_FIN_KONTO_KARTICEORIGINALNIDOKUMENTDescription;
            column13.Width = 0x128;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.S_FIN_KONTO_KARTICENAZIVOJDescription;
            column11.Width = 0x128;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.S_FIN_KONTO_KARTICENAZIVMTDescription;
            column10.Width = 0x128;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.S_FIN_KONTO_KARTICEPSDescription;
            column15.Width = 30;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 0;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 1;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 2;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 3;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 4;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 5;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 6;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 7;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 8;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 9;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 10;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 11;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 12;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 13;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 14;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 15;
            this.userControlDataGridS_FIN_KONTO_KARTICE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_KONTO_KARTICE.Location = point;
            this.userControlDataGridS_FIN_KONTO_KARTICE.Name = "userControlDataGridS_FIN_KONTO_KARTICE";
            this.userControlDataGridS_FIN_KONTO_KARTICE.Tag = "S_FIN_KONTO_KARTICE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_FIN_KONTO_KARTICE.Size = size;
            this.userControlDataGridS_FIN_KONTO_KARTICE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_FIN_KONTO_KARTICE.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_KONTO_KARTICE.FillAtStartup = false;
            this.userControlDataGridS_FIN_KONTO_KARTICE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_FIN_KONTO_KARTICE.InitializeRow += new InitializeRowEventHandler(this.S_FIN_KONTO_KARTICEUserDataGrid_InitializeRow);
            this.userControlDataGridS_FIN_KONTO_KARTICE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_FIN_KONTO_KARTICE });
            this.Name = "S_FIN_KONTO_KARTICEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_FIN_KONTO_KARTICEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_FIN_KONTO_KARTICE).EndInit();
            this.ResumeLayout(false);
        }

        private void S_FIN_KONTO_KARTICEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_FIN_KONTO_KARTICEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_FIN_KONTO_KARTICEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_FIN_KONTO_KARTICE;
            }
            set
            {
                this.userControlDataGridS_FIN_KONTO_KARTICE = value;
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

        [Category("Deklarit Work With "), DefaultValue(true), Description("True= Fill at Startup. False= Not Fill")]
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
        public virtual int ParameterDOK
        {
            get
            {
                return this.DataGrid.ParameterDOK;
            }
            set
            {
                this.DataGrid.ParameterDOK = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterMT
        {
            get
            {
                return this.DataGrid.ParameterMT;
            }
            set
            {
                this.DataGrid.ParameterMT = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterORG
        {
            get
            {
                return this.DataGrid.ParameterORG;
            }
            set
            {
                this.DataGrid.ParameterORG = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterPOCETNIKONTO
        {
            get
            {
                return this.DataGrid.ParameterPOCETNIKONTO;
            }
            set
            {
                this.DataGrid.ParameterPOCETNIKONTO = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual DateTime ParameterRAZDOBLJEDO
        {
            get
            {
                return this.DataGrid.ParameterRAZDOBLJEDO;
            }
            set
            {
                this.DataGrid.ParameterRAZDOBLJEDO = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual DateTime ParameterRAZDOBLJEOD
        {
            get
            {
                return this.DataGrid.ParameterRAZDOBLJEOD;
            }
            set
            {
                this.DataGrid.ParameterRAZDOBLJEOD = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterZAVRSNIKONTO
        {
            get
            {
                return this.DataGrid.ParameterZAVRSNIKONTO;
            }
            set
            {
                this.DataGrid.ParameterZAVRSNIKONTO = value;
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

