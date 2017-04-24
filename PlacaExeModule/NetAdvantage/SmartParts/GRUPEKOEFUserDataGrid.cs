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

    public class GRUPEKOEFUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Grupe koeficijenata";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Grupe koeficijenata";
        private GRUPEKOEFDataGrid userControlDataGridGRUPEKOEF;

        public GRUPEKOEFUserDataGrid()
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

        private void GRUPEKOEFUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void GRUPEKOEFUserDataGrid_Load(object sender, EventArgs e)
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

        private void InitializeComponent()
        {
            this.userControlDataGridGRUPEKOEF = new GRUPEKOEFDataGrid();
            ((ISupportInitialize) this.userControlDataGridGRUPEKOEF).BeginInit();
            UltraGridBand band = new UltraGridBand("GRUPEKOEF", -1);
            UltraGridColumn column = new UltraGridColumn("IDGRUPEKOEF");
            UltraGridColumn column6 = new UltraGridColumn("NAZIVGRUPEKOEF");
            UltraGridBand band2 = new UltraGridBand("GRUPEKOEF_GRUPEKOEFLevel1", 0);
            UltraGridColumn column3 = new UltraGridColumn("IDGRUPEKOEF");
            UltraGridColumn column2 = new UltraGridColumn("IDELEMENT");
            UltraGridColumn column5 = new UltraGridColumn("NAZIVELEMENT");
            UltraGridColumn column4 = new UltraGridColumn("IDMZOSTABLICE");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.GRUPEKOEFIDGRUPEKOEFDescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.GRUPEKOEFNAZIVGRUPEKOEFDescription;
            column6.Width = 0x128;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.GRUPEKOEFIDGRUPEKOEFDescription;
            column3.Width = 0x33;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            column3.Hidden = true;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.GRUPEKOEFIDELEMENTDescription;
            column2.Width = 0x70;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.GRUPEKOEFNAZIVELEMENTDescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.GRUPEKOEFIDMZOSTABLICEDescription;
            column4.Width = 0x63;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnn";
            column4.PromptChar = ' ';
            column4.Format = "";
            column4.CellAppearance = appearance4;
            band2.Columns.Add(column3);
            column3.Header.VisiblePosition = 0;
            band2.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band2.Columns.Add(column5);
            column5.Header.VisiblePosition = 2;
            band2.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 1;
            this.userControlDataGridGRUPEKOEF.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridGRUPEKOEF.Location = point;
            this.userControlDataGridGRUPEKOEF.Name = "userControlDataGridGRUPEKOEF";
            this.userControlDataGridGRUPEKOEF.Tag = "GRUPEKOEF";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridGRUPEKOEF.Size = size;
            this.userControlDataGridGRUPEKOEF.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridGRUPEKOEF.Dock = DockStyle.Fill;
            this.userControlDataGridGRUPEKOEF.FillAtStartup = false;
            this.userControlDataGridGRUPEKOEF.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridGRUPEKOEF.InitializeRow += new InitializeRowEventHandler(this.GRUPEKOEFUserDataGrid_InitializeRow);
            this.userControlDataGridGRUPEKOEF.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridGRUPEKOEF.DisplayLayout.BandsSerializer.Add(band2);
            this.Controls.AddRange(new Control[] { this.userControlDataGridGRUPEKOEF });
            this.Name = "GRUPEKOEFUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.GRUPEKOEFUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridGRUPEKOEF).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
            if (DataAdapterFactory.Provider == null)
            {
                DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
            }
            DataSet dataSet = new ELEMENTDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetELEMENTDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["ELEMENT"]) {
                Sort = "EL"
            };
            CreateValueList(this.DataGrid, "ELEMENTIDELEMENT", dataList, "IDELEMENT", "EL");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["GRUPEKOEF_GRUPEKOEFLevel1"].Columns["IDELEMENT"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["ELEMENTIDELEMENT"];
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
        public virtual GRUPEKOEFDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridGRUPEKOEF;
            }
            set
            {
                this.userControlDataGridGRUPEKOEF = value;
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

        [TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), Category("Deklarit Work With "), DefaultValue("Fill")]
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

