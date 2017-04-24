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

    public class PLANUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with PLAN";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with PLAN";
        private PLANDataGrid userControlDataGridPLAN;

        public PLANUserDataGrid()
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
            this.userControlDataGridPLAN = new PLANDataGrid();
            ((ISupportInitialize) this.userControlDataGridPLAN).BeginInit();
            UltraGridBand band = new UltraGridBand("PLAN", -1);
            UltraGridColumn column = new UltraGridColumn("IDPLAN");
            UltraGridColumn column11 = new UltraGridColumn("PLANGODINAIDGODINE");
            UltraGridColumn column12 = new UltraGridColumn("RADNINAZIVPLANA");
            UltraGridBand band2 = new UltraGridBand("PLAN_PLANORG", 0);
            UltraGridColumn column2 = new UltraGridColumn("IDPLAN");
            UltraGridColumn column8 = new UltraGridColumn("PLANGODINAIDGODINE");
            UltraGridColumn column9 = new UltraGridColumn("PLANOJIDORGJED");
            UltraGridColumn column10 = new UltraGridColumn("PLANOJNAZIVORGJED");
            UltraGridBand band3 = new UltraGridBand("PLANORG_PLANORGKON", 1);
            UltraGridColumn column3 = new UltraGridColumn("IDPLAN");
            UltraGridColumn column4 = new UltraGridColumn("PLANGODINAIDGODINE");
            UltraGridColumn column7 = new UltraGridColumn("PLANOJIDORGJED");
            UltraGridColumn column6 = new UltraGridColumn("PLANKONTOIDKONTO");
            UltraGridColumn column5 = new UltraGridColumn("PLANIRANIIZNOS");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.PLANIDPLANDescription;
            column.Width = 0x3a;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.PLANPLANGODINAIDGODINEDescription;
            column11.Width = 0x48;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnn";
            column11.PromptChar = ' ';
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.PLANRADNINAZIVPLANADescription;
            column12.Width = 0x128;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.PLANIDPLANDescription;
            column2.Width = 0x3a;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            column2.Hidden = true;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.PLANPLANGODINAIDGODINEDescription;
            column8.Width = 0x48;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnn";
            column8.PromptChar = ' ';
            column8.Format = "";
            column8.CellAppearance = appearance8;
            column8.Hidden = true;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.PLANPLANOJIDORGJEDDescription;
            column9.Width = 0x48;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.PLANPLANOJNAZIVORGJEDDescription;
            column10.Width = 0x128;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.PLANIDPLANDescription;
            column3.Width = 0x3a;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            column3.Hidden = true;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.PLANPLANGODINAIDGODINEDescription;
            column4.Width = 0x48;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnn";
            column4.PromptChar = ' ';
            column4.Format = "";
            column4.CellAppearance = appearance4;
            column4.Hidden = true;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.PLANPLANOJIDORGJEDDescription;
            column7.Width = 0x48;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            column7.Hidden = true;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.PLANPLANKONTOIDKONTODescription;
            column6.Width = 0x72;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.PLANPLANIRANIIZNOSDescription;
            column5.Width = 0x74;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            band3.Columns.Add(column3);
            column3.Header.VisiblePosition = 0;
            band3.Columns.Add(column4);
            column4.Header.VisiblePosition = 1;
            band3.Columns.Add(column7);
            column7.Header.VisiblePosition = 2;
            band3.Columns.Add(column6);
            column6.Header.VisiblePosition = 3;
            band3.Columns.Add(column5);
            column5.Header.VisiblePosition = 4;
            band2.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band2.Columns.Add(column8);
            column8.Header.VisiblePosition = 1;
            band2.Columns.Add(column9);
            column9.Header.VisiblePosition = 2;
            band2.Columns.Add(column10);
            column10.Header.VisiblePosition = 3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 1;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 2;
            this.userControlDataGridPLAN.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridPLAN.Location = point;
            this.userControlDataGridPLAN.Name = "userControlDataGridPLAN";
            this.userControlDataGridPLAN.Tag = "PLAN";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridPLAN.Size = size;
            this.userControlDataGridPLAN.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridPLAN.Dock = DockStyle.Fill;
            this.userControlDataGridPLAN.FillAtStartup = false;
            this.userControlDataGridPLAN.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridPLAN.InitializeRow += new InitializeRowEventHandler(this.PLANUserDataGrid_InitializeRow);
            this.userControlDataGridPLAN.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridPLAN.DisplayLayout.BandsSerializer.Add(band2);
            this.userControlDataGridPLAN.DisplayLayout.BandsSerializer.Add(band3);
            this.Controls.AddRange(new Control[] { this.userControlDataGridPLAN });
            this.Name = "PLANUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.PLANUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridPLAN).EndInit();
            this.ResumeLayout(false);
        }

        private void PLANUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void PLANUserDataGrid_Load(object sender, EventArgs e)
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
            DataSet dataSet = new ORGJEDDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetORGJEDDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["ORGJED"]) {
                Sort = "oj"
            };
            CreateValueList(this.DataGrid, "ORGJEDPLANOJIDORGJED", dataList, "IDORGJED", "oj");
            UltraGridColumn column3 = this.DataGrid.DisplayLayout.Bands["PLAN_PLANORG"].Columns["PLANOJIDORGJED"];
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column3.ValueList = this.DataGrid.DisplayLayout.ValueLists["ORGJEDPLANOJIDORGJED"];
            if (setColumnsWidth)
            {
                column3.Width = 370;
            }
            DataSet set2 = new ORGJEDDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetORGJEDDataAdapter().Fill(set2);
            }
            System.Data.DataView view2 = new System.Data.DataView(set2.Tables["ORGJED"]) {
                Sort = "oj"
            };
            CreateValueList(this.DataGrid, "ORGJEDPLANOJIDORGJED", view2, "IDORGJED", "oj");
            UltraGridColumn column2 = this.DataGrid.DisplayLayout.Bands["PLANORG_PLANORGKON"].Columns["PLANOJIDORGJED"];
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.DataGrid.DisplayLayout.ValueLists["ORGJEDPLANOJIDORGJED"];
            if (setColumnsWidth)
            {
                column2.Width = 370;
            }
            DataSet set = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(set);
            }
            System.Data.DataView view = new System.Data.DataView(set.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.DataGrid, "KONTOPLANKONTOIDKONTO", view, "IDKONTO", "KONT");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["PLANORG_PLANORGKON"].Columns["PLANKONTOIDKONTO"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["KONTOPLANKONTOIDKONTO"];
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
        public virtual PLANDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridPLAN;
            }
            set
            {
                this.userControlDataGridPLAN = value;
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
        public virtual int FillByIDPLANIDPLAN
        {
            get
            {
                return this.DataGrid.FillByIDPLANIDPLAN;
            }
            set
            {
                this.DataGrid.FillByIDPLANIDPLAN = value;
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

        [Category("Deklarit Work With ")]
        public virtual short FillByPLANGODINAIDGODINEPLANGODINAIDGODINE
        {
            get
            {
                return this.DataGrid.FillByPLANGODINAIDGODINEPLANGODINAIDGODINE;
            }
            set
            {
                this.DataGrid.FillByPLANGODINAIDGODINEPLANGODINAIDGODINE = value;
            }
        }

        [Category("Deklarit Work With "), DefaultValue("Fill"), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter))]
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

