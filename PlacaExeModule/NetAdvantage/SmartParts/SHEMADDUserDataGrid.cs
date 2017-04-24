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

    public class SHEMADDUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Shema drugi dohodak";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Shema drugi dohodak";
        private SHEMADDDataGrid userControlDataGridSHEMADD;

        public SHEMADDUserDataGrid()
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
            this.userControlDataGridSHEMADD = new SHEMADDDataGrid();
            ((ISupportInitialize) this.userControlDataGridSHEMADD).BeginInit();
            UltraGridBand band = new UltraGridBand("SHEMADD", -1);
            UltraGridColumn column = new UltraGridColumn("IDSHEMADD");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVSHEMADD");
            UltraGridColumn column9 = new UltraGridColumn("SHEMADDOJIDORGJED");
            UltraGridBand band2 = new UltraGridBand("SHEMADD_SHEMADDSHEMADDDOPRINOS", 0);
            UltraGridColumn column3 = new UltraGridColumn("IDSHEMADD");
            UltraGridColumn column6 = new UltraGridColumn("SHEMADDDOPRINOSIDDOPRINOS");
            UltraGridColumn column4 = new UltraGridColumn("KONTODOPIDKONTO");
            UltraGridColumn column5 = new UltraGridColumn("MTDOPIDMJESTOTROSKA");
            UltraGridColumn column8 = new UltraGridColumn("STRANEDOPIDSTRANEKNJIZENJA");
            UltraGridColumn column7 = new UltraGridColumn("SHEMADDDOPRINOSNAZIVDOPRINOS");
            UltraGridBand band3 = new UltraGridBand("SHEMADD_SHEMADDSHEMADDSTANDARD", 0);
            UltraGridColumn column11 = new UltraGridColumn("IDSHEMADD");
            UltraGridColumn column15 = new UltraGridColumn("SHEMADDSTANDARDID");
            UltraGridColumn column10 = new UltraGridColumn("IDDDVRSTEIZNOSA");
            UltraGridColumn column12 = new UltraGridColumn("KONTODDVRSTAIZNOSAIDKONTO");
            UltraGridColumn column13 = new UltraGridColumn("MTDDVRSTAIZNOSAIDMJESTOTROSKA");
            UltraGridColumn column16 = new UltraGridColumn("STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA");
            UltraGridColumn column14 = new UltraGridColumn("NAZIVDDVRSTEIZNOSA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.SHEMADDIDSHEMADDDescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.SHEMADDNAZIVSHEMADDDescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.SHEMADDSHEMADDOJIDORGJEDDescription;
            column9.Width = 0x48;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.SHEMADDIDSHEMADDDescription;
            column3.Width = 0x33;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            column3.Hidden = true;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.SHEMADDSHEMADDDOPRINOSIDDOPRINOSDescription;
            column6.Width = 0x77;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnn";
            column6.PromptChar = ' ';
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.SHEMADDKONTODOPIDKONTODescription;
            column4.Width = 0x72;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.SHEMADDMTDOPIDMJESTOTROSKADescription;
            column5.Width = 0x48;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.SHEMADDSTRANEDOPIDSTRANEKNJIZENJADescription;
            column8.Width = 0x63;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.SHEMADDSHEMADDDOPRINOSNAZIVDOPRINOSDescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            band2.Columns.Add(column3);
            column3.Header.VisiblePosition = 0;
            band2.Columns.Add(column6);
            column6.Header.VisiblePosition = 1;
            band2.Columns.Add(column4);
            column4.Header.VisiblePosition = 2;
            band2.Columns.Add(column5);
            column5.Header.VisiblePosition = 3;
            band2.Columns.Add(column8);
            column8.Header.VisiblePosition = 4;
            band2.Columns.Add(column7);
            column7.Header.VisiblePosition = 5;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.SHEMADDIDSHEMADDDescription;
            column11.Width = 0x33;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnn";
            column11.PromptChar = ' ';
            column11.Format = "";
            column11.CellAppearance = appearance11;
            column11.Hidden = true;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.SHEMADDSHEMADDSTANDARDIDDescription;
            column15.Width = 0x10c;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            column15.Hidden = true;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.SHEMADDIDDDVRSTEIZNOSADescription;
            column10.Width = 0x63;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnn";
            column10.PromptChar = ' ';
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.SHEMADDKONTODDVRSTAIZNOSAIDKONTODescription;
            column12.Width = 0x72;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.SHEMADDMTDDVRSTAIZNOSAIDMJESTOTROSKADescription;
            column13.Width = 0x48;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.SHEMADDSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJADescription;
            column16.Width = 0x63;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.SHEMADDNAZIVDDVRSTEIZNOSADescription;
            column14.Width = 0x128;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            band3.Columns.Add(column11);
            column11.Header.VisiblePosition = 0;
            band3.Columns.Add(column10);
            column10.Header.VisiblePosition = 1;
            band3.Columns.Add(column12);
            column12.Header.VisiblePosition = 2;
            band3.Columns.Add(column13);
            column13.Header.VisiblePosition = 3;
            band3.Columns.Add(column16);
            column16.Header.VisiblePosition = 4;
            band3.Columns.Add(column14);
            column14.Header.VisiblePosition = 5;
            band3.Columns.Add(column15);
            column15.Header.VisiblePosition = 6;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 2;
            this.userControlDataGridSHEMADD.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridSHEMADD.Location = point;
            this.userControlDataGridSHEMADD.Name = "userControlDataGridSHEMADD";
            this.userControlDataGridSHEMADD.Tag = "SHEMADD";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridSHEMADD.Size = size;
            this.userControlDataGridSHEMADD.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridSHEMADD.Dock = DockStyle.Fill;
            this.userControlDataGridSHEMADD.FillAtStartup = false;
            this.userControlDataGridSHEMADD.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridSHEMADD.InitializeRow += new InitializeRowEventHandler(this.SHEMADDUserDataGrid_InitializeRow);
            this.userControlDataGridSHEMADD.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridSHEMADD.DisplayLayout.BandsSerializer.Add(band2);
            this.userControlDataGridSHEMADD.DisplayLayout.BandsSerializer.Add(band3);
            this.Controls.AddRange(new Control[] { this.userControlDataGridSHEMADD });
            this.Name = "SHEMADDUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.SHEMADDUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridSHEMADD).EndInit();
            this.ResumeLayout(false);
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
            CreateValueList(this.DataGrid, "ORGJEDSHEMADDOJIDORGJED", dataList, "IDORGJED", "oj");
            UltraGridColumn column4 = this.DataGrid.DisplayLayout.Bands["SHEMADD"].Columns["SHEMADDOJIDORGJED"];
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column4.ValueList = this.DataGrid.DisplayLayout.ValueLists["ORGJEDSHEMADDOJIDORGJED"];
            if (setColumnsWidth)
            {
                column4.Width = 370;
            }
            DataSet set = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(set);
            }
            System.Data.DataView view = new System.Data.DataView(set.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.DataGrid, "KONTOKONTODOPIDKONTO", view, "IDKONTO", "KONT");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["SHEMADD_SHEMADDSHEMADDDOPRINOS"].Columns["KONTODOPIDKONTO"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["KONTOKONTODOPIDKONTO"];
            if (setColumnsWidth)
            {
                column.Width = 370;
            }
            DataSet set2 = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(set2);
            }
            System.Data.DataView view2 = new System.Data.DataView(set2.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.DataGrid, "MJESTOTROSKAMTDOPIDMJESTOTROSKA", view2, "IDMJESTOTROSKA", "mt");
            UltraGridColumn column2 = this.DataGrid.DisplayLayout.Bands["SHEMADD_SHEMADDSHEMADDDOPRINOS"].Columns["MTDOPIDMJESTOTROSKA"];
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.DataGrid.DisplayLayout.ValueLists["MJESTOTROSKAMTDOPIDMJESTOTROSKA"];
            if (setColumnsWidth)
            {
                column2.Width = 370;
            }
            DataSet set3 = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(set3);
            }
            System.Data.DataView view3 = new System.Data.DataView(set3.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.DataGrid, "STRANEKNJIZENJASTRANEDOPIDSTRANEKNJIZENJA", view3, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA");
            UltraGridColumn column3 = this.DataGrid.DisplayLayout.Bands["SHEMADD_SHEMADDSHEMADDDOPRINOS"].Columns["STRANEDOPIDSTRANEKNJIZENJA"];
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column3.ValueList = this.DataGrid.DisplayLayout.ValueLists["STRANEKNJIZENJASTRANEDOPIDSTRANEKNJIZENJA"];
            if (setColumnsWidth)
            {
                column3.Width = 280;
            }
            DataSet set5 = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(set5);
            }
            System.Data.DataView view5 = new System.Data.DataView(set5.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.DataGrid, "KONTOKONTODDVRSTAIZNOSAIDKONTO", view5, "IDKONTO", "KONT");
            UltraGridColumn column5 = this.DataGrid.DisplayLayout.Bands["SHEMADD_SHEMADDSHEMADDSTANDARD"].Columns["KONTODDVRSTAIZNOSAIDKONTO"];
            column5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column5.ValueList = this.DataGrid.DisplayLayout.ValueLists["KONTOKONTODDVRSTAIZNOSAIDKONTO"];
            if (setColumnsWidth)
            {
                column5.Width = 370;
            }
            DataSet set6 = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(set6);
            }
            System.Data.DataView view6 = new System.Data.DataView(set6.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.DataGrid, "MJESTOTROSKAMTDDVRSTAIZNOSAIDMJESTOTROSKA", view6, "IDMJESTOTROSKA", "mt");
            UltraGridColumn column6 = this.DataGrid.DisplayLayout.Bands["SHEMADD_SHEMADDSHEMADDSTANDARD"].Columns["MTDDVRSTAIZNOSAIDMJESTOTROSKA"];
            column6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column6.ValueList = this.DataGrid.DisplayLayout.ValueLists["MJESTOTROSKAMTDDVRSTAIZNOSAIDMJESTOTROSKA"];
            if (setColumnsWidth)
            {
                column6.Width = 370;
            }
            DataSet set7 = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(set7);
            }
            System.Data.DataView view7 = new System.Data.DataView(set7.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.DataGrid, "STRANEKNJIZENJASTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA", view7, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA");
            UltraGridColumn column7 = this.DataGrid.DisplayLayout.Bands["SHEMADD_SHEMADDSHEMADDSTANDARD"].Columns["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"];
            column7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column7.ValueList = this.DataGrid.DisplayLayout.ValueLists["STRANEKNJIZENJASTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"];
            if (setColumnsWidth)
            {
                column7.Width = 280;
            }
        }

        private void SHEMADDUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void SHEMADDUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual SHEMADDDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridSHEMADD;
            }
            set
            {
                this.userControlDataGridSHEMADD = value;
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

        [Description("True= Fill at Startup. False= Not Fill"), Category("Deklarit Work With "), DefaultValue(true)]
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

        [Category("Deklarit Work With ")]
        public virtual int FillBySHEMADDOJIDORGJEDSHEMADDOJIDORGJED
        {
            get
            {
                return this.DataGrid.FillBySHEMADDOJIDORGJEDSHEMADDOJIDORGJED;
            }
            set
            {
                this.DataGrid.FillBySHEMADDOJIDORGJEDSHEMADDOJIDORGJED = value;
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

