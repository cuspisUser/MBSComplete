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

    public class S_PLACA_KREDITI_KARTICEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_PLACA_KREDITI_KARTICE";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_PLACA_KREDITI_KARTICE";
        private S_PLACA_KREDITI_KARTICEDataGrid userControlDataGridS_PLACA_KREDITI_KARTICE;

        public S_PLACA_KREDITI_KARTICEUserDataGrid()
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
            this.userControlDataGridS_PLACA_KREDITI_KARTICE = new S_PLACA_KREDITI_KARTICEDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_PLACA_KREDITI_KARTICE).BeginInit();
            UltraGridBand band = new UltraGridBand("S_PLACA_KREDITI_KARTICE", -1);
            UltraGridColumn column4 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column7 = new UltraGridColumn("NAZIVOBUSTAVA");
            UltraGridColumn column6 = new UltraGridColumn("IZNOSOBUSTAVE");
            UltraGridColumn column8 = new UltraGridColumn("POSTOTAKOBUSTAVE");
            UltraGridColumn column11 = new UltraGridColumn("UKUNAMA");
            UltraGridColumn column5 = new UltraGridColumn("ISPLACENOKASA");
            UltraGridColumn column9 = new UltraGridColumn("SALDOKASA");
            UltraGridColumn column = new UltraGridColumn("DATUM");
            UltraGridColumn column2 = new UltraGridColumn("DATUMUGOVORA");
            UltraGridColumn column12 = new UltraGridColumn("vrsta");
            UltraGridColumn column3 = new UltraGridColumn("IDOBRACUN");
            UltraGridColumn column10 = new UltraGridColumn("SIFRAZAKARTICU");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_PLACA_KREDITI_KARTICEIDRADNIKDescription;
            column4.Width = 0x69;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnn";
            column4.PromptChar = ' ';
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_PLACA_KREDITI_KARTICENAZIVOBUSTAVADescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_PLACA_KREDITI_KARTICEIZNOSOBUSTAVEDescription;
            column6.Width = 0x6d;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_PLACA_KREDITI_KARTICEPOSTOTAKOBUSTAVEDescription;
            column8.Width = 0x81;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.S_PLACA_KREDITI_KARTICEUKUNAMADescription;
            column11.Width = 0x66;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_PLACA_KREDITI_KARTICEISPLACENOKASADescription;
            column5.Width = 0x6d;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.S_PLACA_KREDITI_KARTICESALDOKASADescription;
            column9.Width = 0x66;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_PLACA_KREDITI_KARTICEDATUMDescription;
            column.Width = 100;
            column.MinValue = DateTime.MinValue;
            column.MaxValue = DateTime.MaxValue;
            column.Format = "d";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_PLACA_KREDITI_KARTICEDATUMUGOVORADescription;
            column2.Width = 100;
            column2.MinValue = DateTime.MinValue;
            column2.MaxValue = DateTime.MaxValue;
            column2.Format = "d";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.S_PLACA_KREDITI_KARTICEvrstaDescription;
            column12.Width = 0x128;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_PLACA_KREDITI_KARTICEIDOBRACUNDescription;
            column3.Width = 0x5d;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.S_PLACA_KREDITI_KARTICESIFRAZAKARTICUDescription;
            column10.Width = 0x70;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnn";
            column10.PromptChar = ' ';
            column10.Format = "";
            column10.CellAppearance = appearance10;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 0;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 1;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 2;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 3;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 4;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 5;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 6;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 7;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 8;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 9;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 10;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 11;
            this.userControlDataGridS_PLACA_KREDITI_KARTICE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_PLACA_KREDITI_KARTICE.Location = point;
            this.userControlDataGridS_PLACA_KREDITI_KARTICE.Name = "userControlDataGridS_PLACA_KREDITI_KARTICE";
            this.userControlDataGridS_PLACA_KREDITI_KARTICE.Tag = "S_PLACA_KREDITI_KARTICE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_PLACA_KREDITI_KARTICE.Size = size;
            this.userControlDataGridS_PLACA_KREDITI_KARTICE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_PLACA_KREDITI_KARTICE.Dock = DockStyle.Fill;
            this.userControlDataGridS_PLACA_KREDITI_KARTICE.FillAtStartup = false;
            this.userControlDataGridS_PLACA_KREDITI_KARTICE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_PLACA_KREDITI_KARTICE.InitializeRow += new InitializeRowEventHandler(this.S_PLACA_KREDITI_KARTICEUserDataGrid_InitializeRow);
            this.userControlDataGridS_PLACA_KREDITI_KARTICE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_PLACA_KREDITI_KARTICE });
            this.Name = "S_PLACA_KREDITI_KARTICEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_PLACA_KREDITI_KARTICEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_PLACA_KREDITI_KARTICE).EndInit();
            this.ResumeLayout(false);
        }

        private void S_PLACA_KREDITI_KARTICEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_PLACA_KREDITI_KARTICEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_PLACA_KREDITI_KARTICEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_PLACA_KREDITI_KARTICE;
            }
            set
            {
                this.userControlDataGridS_PLACA_KREDITI_KARTICE = value;
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

        [Category("Deklarit Work With "), Description("True= Fill at Startup. False= Not Fill"), DefaultValue(true)]
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

