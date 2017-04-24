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

    public class S_OS_REKAP_TEMELJNICEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_OS_REKAP_TEMELJNICE";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_OS_REKAP_TEMELJNICE";
        private S_OS_REKAP_TEMELJNICEDataGrid userControlDataGridS_OS_REKAP_TEMELJNICE;

        public S_OS_REKAP_TEMELJNICEUserDataGrid()
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
            this.userControlDataGridS_OS_REKAP_TEMELJNICE = new S_OS_REKAP_TEMELJNICEDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_OS_REKAP_TEMELJNICE).BeginInit();
            UltraGridBand band = new UltraGridBand("S_OS_REKAP_TEMELJNICE", -1);
            UltraGridColumn column4 = new UltraGridColumn("KTONABAVKEIDKONTO");
            UltraGridColumn column2 = new UltraGridColumn("KTOISPRAVKAIDKONTO");
            UltraGridColumn column3 = new UltraGridColumn("KTOIZVORAIDKONTO");
            UltraGridColumn column7 = new UltraGridColumn("OSDUGUJE");
            UltraGridColumn column9 = new UltraGridColumn("OSPOTRAZUJE");
            UltraGridColumn column = new UltraGridColumn("IDOSDOKUMENT");
            UltraGridColumn column5 = new UltraGridColumn("OSBROJDOKUMENTA");
            UltraGridColumn column6 = new UltraGridColumn("OSDATUMDOK");
            UltraGridColumn column8 = new UltraGridColumn("OSOPIS");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_OS_REKAP_TEMELJNICEKTONABAVKEIDKONTODescription;
            column4.Width = 0x72;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_OS_REKAP_TEMELJNICEKTOISPRAVKAIDKONTODescription;
            column2.Width = 0x72;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_OS_REKAP_TEMELJNICEKTOIZVORAIDKONTODescription;
            column3.Width = 0x72;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_OS_REKAP_TEMELJNICEOSDUGUJEDescription;
            column7.Width = 0x66;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.S_OS_REKAP_TEMELJNICEOSPOTRAZUJEDescription;
            column9.Width = 0x66;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_OS_REKAP_TEMELJNICEIDOSDOKUMENTDescription;
            column.Width = 0x63;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_OS_REKAP_TEMELJNICEOSBROJDOKUMENTADescription;
            column5.Width = 0x77;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnn";
            column5.PromptChar = ' ';
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_OS_REKAP_TEMELJNICEOSDATUMDOKDescription;
            column6.Width = 100;
            column6.MinValue = DateTime.MinValue;
            column6.MaxValue = DateTime.MaxValue;
            column6.Format = "d";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_OS_REKAP_TEMELJNICEOSOPISDescription;
            column8.Width = 0x128;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 3;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 4;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 5;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 6;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 7;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 8;
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.Location = point;
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.Name = "userControlDataGridS_OS_REKAP_TEMELJNICE";
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.Tag = "S_OS_REKAP_TEMELJNICE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.Size = size;
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.Dock = DockStyle.Fill;
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.FillAtStartup = false;
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.InitializeRow += new InitializeRowEventHandler(this.S_OS_REKAP_TEMELJNICEUserDataGrid_InitializeRow);
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_OS_REKAP_TEMELJNICE });
            this.Name = "S_OS_REKAP_TEMELJNICEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_OS_REKAP_TEMELJNICEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_OS_REKAP_TEMELJNICE).EndInit();
            this.ResumeLayout(false);
        }

        private void S_OS_REKAP_TEMELJNICEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_OS_REKAP_TEMELJNICEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_OS_REKAP_TEMELJNICEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_OS_REKAP_TEMELJNICE;
            }
            set
            {
                this.userControlDataGridS_OS_REKAP_TEMELJNICE = value;
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
        public virtual int ParameterBROJOSTEMELJNICE
        {
            get
            {
                return this.DataGrid.ParameterBROJOSTEMELJNICE;
            }
            set
            {
                this.DataGrid.ParameterBROJOSTEMELJNICE = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int Parametervrstaostemeljnice
        {
            get
            {
                return this.DataGrid.Parametervrstaostemeljnice;
            }
            set
            {
                this.DataGrid.Parametervrstaostemeljnice = value;
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

