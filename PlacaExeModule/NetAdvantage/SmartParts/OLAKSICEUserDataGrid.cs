namespace NetAdvantage.SmartParts
{
    using Deklarit.Controls;
    using Infragistics.Win;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using NetAdvantage.Controls;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class OLAKSICEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Osiguranja-Olakšice";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Osiguranja-Olakšice";
        private OLAKSICEDataGrid userControlDataGridOLAKSICE;

        public OLAKSICEUserDataGrid()
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
            this.userControlDataGridOLAKSICE = new OLAKSICEDataGrid();
            ((ISupportInitialize) this.userControlDataGridOLAKSICE).BeginInit();
            UltraGridBand band = new UltraGridBand("OLAKSICE", -1);
            UltraGridColumn column2 = new UltraGridColumn("IDOLAKSICE");
            UltraGridColumn column6 = new UltraGridColumn("NAZIVOLAKSICE");
            UltraGridColumn column = new UltraGridColumn("IDGRUPEOLAKSICA");
            UltraGridColumn column5 = new UltraGridColumn("NAZIVGRUPEOLAKSICA");
            UltraGridColumn column4 = new UltraGridColumn("MAXIMALNIIZNOSGRUPE");
            UltraGridColumn column3 = new UltraGridColumn("IDTIPOLAKSICE");
            UltraGridColumn column7 = new UltraGridColumn("NAZIVTIPOLAKSICE");
            UltraGridColumn column11 = new UltraGridColumn("VBDIOLAKSICA");
            UltraGridColumn column12 = new UltraGridColumn("ZRNOLAKSICA");
            UltraGridColumn column8 = new UltraGridColumn("PRIMATELJOLAKSICA1");
            UltraGridColumn column9 = new UltraGridColumn("PRIMATELJOLAKSICA2");
            UltraGridColumn column10 = new UltraGridColumn("PRIMATELJOLAKSICA3");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.OLAKSICEIDOLAKSICEDescription;
            column2.Width = 0x70;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.OLAKSICENAZIVOLAKSICEDescription;
            column6.Width = 0x128;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.OLAKSICEIDGRUPEOLAKSICADescription;
            column.Width = 0x99;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.OLAKSICENAZIVGRUPEOLAKSICADescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.OLAKSICEMAXIMALNIIZNOSGRUPEDescription;
            column4.Width = 210;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.OLAKSICEIDTIPOLAKSICEDescription;
            column3.Width = 0x63;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.OLAKSICENAZIVTIPOLAKSICEDescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.OLAKSICEVBDIOLAKSICADescription;
            column11.Width = 0xbf;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.OLAKSICEZRNOLAKSICADescription;
            column12.Width = 0xbf;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.OLAKSICEPRIMATELJOLAKSICA1Description;
            column8.Width = 170;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.OLAKSICEPRIMATELJOLAKSICA2Description;
            column9.Width = 170;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.OLAKSICEPRIMATELJOLAKSICA3Description;
            column10.Width = 170;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 3;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 4;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 5;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 6;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 7;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 8;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 9;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 10;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 11;
            this.userControlDataGridOLAKSICE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridOLAKSICE.Location = point;
            this.userControlDataGridOLAKSICE.Name = "userControlDataGridOLAKSICE";
            this.userControlDataGridOLAKSICE.Tag = "OLAKSICE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridOLAKSICE.Size = size;
            this.userControlDataGridOLAKSICE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridOLAKSICE.Dock = DockStyle.Fill;
            this.userControlDataGridOLAKSICE.FillAtStartup = false;
            this.userControlDataGridOLAKSICE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridOLAKSICE.InitializeRow += new InitializeRowEventHandler(this.OLAKSICEUserDataGrid_InitializeRow);
            this.userControlDataGridOLAKSICE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridOLAKSICE });
            this.Name = "OLAKSICEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.OLAKSICEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridOLAKSICE).EndInit();
            this.ResumeLayout(false);
        }

        private void OLAKSICEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void OLAKSICEUserDataGrid_Load(object sender, EventArgs e)
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
            if (DataAdapterFactory.Provider == null)
            {
                DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
            }
            DataSet dataSet = new TIPOLAKSICEDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetTIPOLAKSICEDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["TIPOLAKSICE"]) {
                Sort = "NAZIVTIPOLAKSICE"
            };
            CreateValueList(this.DataGrid, "TIPOLAKSICEIDTIPOLAKSICE", dataList, "IDTIPOLAKSICE", "NAZIVTIPOLAKSICE");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["OLAKSICE"].Columns["IDTIPOLAKSICE"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["TIPOLAKSICEIDTIPOLAKSICE"];
            if (setColumnsWidth)
            {
                column.Width = 370;
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
        public virtual OLAKSICEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridOLAKSICE;
            }
            set
            {
                this.userControlDataGridOLAKSICE = value;
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

        [Category("Deklarit Work With ")]
        public virtual int FillByIDGRUPEOLAKSICAIDGRUPEOLAKSICA
        {
            get
            {
                return this.DataGrid.FillByIDGRUPEOLAKSICAIDGRUPEOLAKSICA;
            }
            set
            {
                this.DataGrid.FillByIDGRUPEOLAKSICAIDGRUPEOLAKSICA = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDTIPOLAKSICEIDTIPOLAKSICE
        {
            get
            {
                return this.DataGrid.FillByIDTIPOLAKSICEIDTIPOLAKSICE;
            }
            set
            {
                this.DataGrid.FillByIDTIPOLAKSICEIDTIPOLAKSICE = value;
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

        [TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), DefaultValue("Fill"), Category("Deklarit Work With ")]
        public virtual string FillMethod
        {
            get
            {
                return this.DataGrid.FillMethod;
            }
            set
            {
                this.DataGrid.FillMethod = value;
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

