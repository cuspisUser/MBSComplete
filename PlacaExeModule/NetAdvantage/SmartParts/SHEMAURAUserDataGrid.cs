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

    public class SHEMAURAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Shema kontiranja URA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Shema kontiranja URA";
        private SHEMAURADataGrid userControlDataGridSHEMAURA;

        public SHEMAURAUserDataGrid()
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
            this.userControlDataGridSHEMAURA = new SHEMAURADataGrid();
            ((ISupportInitialize) this.userControlDataGridSHEMAURA).BeginInit();
            UltraGridBand band = new UltraGridBand("SHEMAURA", -1);
            UltraGridColumn column = new UltraGridColumn("IDSHEMAURA");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVSHEMAURA");
            UltraGridColumn column3 = new UltraGridColumn("PARTNERSHEMAURAIDPARTNER");
            UltraGridBand band2 = new UltraGridBand("SHEMAURA_SHEMAURASHEMAURAKONTIRANJE", 0);
            UltraGridColumn column4 = new UltraGridColumn("IDSHEMAURA");
            UltraGridColumn column6 = new UltraGridColumn("SHEMAURAKONTOIDKONTO");
            UltraGridColumn column9 = new UltraGridColumn("SHEMAURASTRANEIDSTRANEKNJIZENJA");
            UltraGridColumn column5 = new UltraGridColumn("IDURAVRSTAIZNOSA");
            UltraGridColumn column7 = new UltraGridColumn("SHEMAURAMTIDMJESTOTROSKA");
            UltraGridColumn column8 = new UltraGridColumn("SHEMAURAOJIDORGJED");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.SHEMAURAIDSHEMAURADescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.SHEMAURANAZIVSHEMAURADescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.SHEMAURAPARTNERSHEMAURAIDPARTNERDescription;
            column3.Width = 0x4e;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.SHEMAURAIDSHEMAURADescription;
            column4.Width = 0x33;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnn";
            column4.PromptChar = ' ';
            column4.Format = "";
            column4.CellAppearance = appearance4;
            column4.Hidden = true;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.SHEMAURASHEMAURAKONTOIDKONTODescription;
            column6.Width = 0x72;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.SHEMAURASHEMAURASTRANEIDSTRANEKNJIZENJADescription;
            column9.Width = 0x7e;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.SHEMAURAIDURAVRSTAIZNOSADescription;
            column5.Width = 0x63;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.SHEMAURASHEMAURAMTIDMJESTOTROSKADescription;
            column7.Width = 0x48;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.SHEMAURASHEMAURAOJIDORGJEDDescription;
            column8.Width = 0x48;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            band2.Columns.Add(column4);
            column4.Header.VisiblePosition = 0;
            band2.Columns.Add(column6);
            column6.Header.VisiblePosition = 1;
            band2.Columns.Add(column9);
            column9.Header.VisiblePosition = 2;
            band2.Columns.Add(column5);
            column5.Header.VisiblePosition = 3;
            band2.Columns.Add(column7);
            column7.Header.VisiblePosition = 4;
            band2.Columns.Add(column8);
            column8.Header.VisiblePosition = 5;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            this.userControlDataGridSHEMAURA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridSHEMAURA.Location = point;
            this.userControlDataGridSHEMAURA.Name = "userControlDataGridSHEMAURA";
            this.userControlDataGridSHEMAURA.Tag = "SHEMAURA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridSHEMAURA.Size = size;
            this.userControlDataGridSHEMAURA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridSHEMAURA.Dock = DockStyle.Fill;
            this.userControlDataGridSHEMAURA.FillAtStartup = false;
            this.userControlDataGridSHEMAURA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridSHEMAURA.InitializeRow += new InitializeRowEventHandler(this.SHEMAURAUserDataGrid_InitializeRow);
            this.userControlDataGridSHEMAURA.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridSHEMAURA.DisplayLayout.BandsSerializer.Add(band2);
            this.Controls.AddRange(new Control[] { this.userControlDataGridSHEMAURA });
            this.Name = "SHEMAURAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.SHEMAURAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridSHEMAURA).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
            if (DataAdapterFactory.Provider == null)
            {
                DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
            }
            DataSet dataSet = new PARTNERDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetPARTNERDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["PARTNER"]) {
                Sort = "PT"
            };
            CreateValueList(this.DataGrid, "PARTNERPARTNERSHEMAURAIDPARTNER", dataList, "IDPARTNER", "PT");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["SHEMAURA"].Columns["PARTNERSHEMAURAIDPARTNER"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["PARTNERPARTNERSHEMAURAIDPARTNER"];
            if (setColumnsWidth)
            {
                column.Width = 370;
            }
            DataSet set3 = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(set3);
            }
            System.Data.DataView view3 = new System.Data.DataView(set3.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.DataGrid, "KONTOSHEMAURAKONTOIDKONTO", view3, "IDKONTO", "KONT");
            UltraGridColumn column3 = this.DataGrid.DisplayLayout.Bands["SHEMAURA_SHEMAURASHEMAURAKONTIRANJE"].Columns["SHEMAURAKONTOIDKONTO"];
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column3.ValueList = this.DataGrid.DisplayLayout.ValueLists["KONTOSHEMAURAKONTOIDKONTO"];
            if (setColumnsWidth)
            {
                column3.Width = 370;
            }
            DataSet set6 = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(set6);
            }
            System.Data.DataView view6 = new System.Data.DataView(set6.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.DataGrid, "STRANEKNJIZENJASHEMAURASTRANEIDSTRANEKNJIZENJA", view6, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA");
            UltraGridColumn column6 = this.DataGrid.DisplayLayout.Bands["SHEMAURA_SHEMAURASHEMAURAKONTIRANJE"].Columns["SHEMAURASTRANEIDSTRANEKNJIZENJA"];
            column6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column6.ValueList = this.DataGrid.DisplayLayout.ValueLists["STRANEKNJIZENJASHEMAURASTRANEIDSTRANEKNJIZENJA"];
            if (setColumnsWidth)
            {
                column6.Width = 280;
            }
            DataSet set2 = new URAVRSTAIZNOSADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetURAVRSTAIZNOSADataAdapter().Fill(set2);
            }
            System.Data.DataView view2 = new System.Data.DataView(set2.Tables["URAVRSTAIZNOSA"]) {
                Sort = "URAVRSTAIZNOSANAZIV"
            };
            CreateValueList(this.DataGrid, "URAVRSTAIZNOSAIDURAVRSTAIZNOSA", view2, "IDURAVRSTAIZNOSA", "URAVRSTAIZNOSANAZIV");
            UltraGridColumn column2 = this.DataGrid.DisplayLayout.Bands["SHEMAURA_SHEMAURASHEMAURAKONTIRANJE"].Columns["IDURAVRSTAIZNOSA"];
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.DataGrid.DisplayLayout.ValueLists["URAVRSTAIZNOSAIDURAVRSTAIZNOSA"];
            if (setColumnsWidth)
            {
                column2.Width = 280;
            }
            DataSet set4 = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(set4);
            }
            System.Data.DataView view4 = new System.Data.DataView(set4.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.DataGrid, "MJESTOTROSKASHEMAURAMTIDMJESTOTROSKA", view4, "IDMJESTOTROSKA", "mt");
            UltraGridColumn column4 = this.DataGrid.DisplayLayout.Bands["SHEMAURA_SHEMAURASHEMAURAKONTIRANJE"].Columns["SHEMAURAMTIDMJESTOTROSKA"];
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column4.ValueList = this.DataGrid.DisplayLayout.ValueLists["MJESTOTROSKASHEMAURAMTIDMJESTOTROSKA"];
            if (setColumnsWidth)
            {
                column4.Width = 370;
            }
            DataSet set5 = new ORGJEDDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetORGJEDDataAdapter().Fill(set5);
            }
            System.Data.DataView view5 = new System.Data.DataView(set5.Tables["ORGJED"]) {
                Sort = "oj"
            };
            CreateValueList(this.DataGrid, "ORGJEDSHEMAURAOJIDORGJED", view5, "IDORGJED", "oj");
            UltraGridColumn column5 = this.DataGrid.DisplayLayout.Bands["SHEMAURA_SHEMAURASHEMAURAKONTIRANJE"].Columns["SHEMAURAOJIDORGJED"];
            column5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column5.ValueList = this.DataGrid.DisplayLayout.ValueLists["ORGJEDSHEMAURAOJIDORGJED"];
            if (setColumnsWidth)
            {
                column5.Width = 370;
            }
        }

        private void SHEMAURAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void SHEMAURAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual SHEMAURADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridSHEMAURA;
            }
            set
            {
                this.userControlDataGridSHEMAURA = value;
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

        [Description("True= Fill at Startup. False= Not Fill"), DefaultValue(true), Category("Deklarit Work With ")]
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
        public virtual int FillByPARTNERSHEMAURAIDPARTNERPARTNERSHEMAURAIDPARTNER
        {
            get
            {
                return this.DataGrid.FillByPARTNERSHEMAURAIDPARTNERPARTNERSHEMAURAIDPARTNER;
            }
            set
            {
                this.DataGrid.FillByPARTNERSHEMAURAIDPARTNERPARTNERSHEMAURAIDPARTNER = value;
            }
        }

        [DefaultValue("Fill"), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), Category("Deklarit Work With ")]
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

