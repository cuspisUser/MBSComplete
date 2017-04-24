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

    public class SHEMAIRAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Shema kontiranja IRA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Shema kontiranja IRA";
        private SHEMAIRADataGrid userControlDataGridSHEMAIRA;

        public SHEMAIRAUserDataGrid()
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
            this.userControlDataGridSHEMAIRA = new SHEMAIRADataGrid();
            ((ISupportInitialize) this.userControlDataGridSHEMAIRA).BeginInit();
            UltraGridBand band = new UltraGridBand("SHEMAIRA", -1);
            UltraGridColumn column = new UltraGridColumn("IDSHEMAIRA");
            UltraGridColumn column2 = new UltraGridColumn("NAZIVSHEMAIRA");
            UltraGridColumn column3 = new UltraGridColumn("SHEMAIRADOKIDDOKUMENT");
            UltraGridBand band2 = new UltraGridBand("SHEMAIRA_SHEMAIRASHEMAIRAKONTIRANJE", 0);
            UltraGridColumn column5 = new UltraGridColumn("IDSHEMAIRA");
            UltraGridColumn column6 = new UltraGridColumn("SHEMAIRAKONTOIDKONTO");
            UltraGridColumn column9 = new UltraGridColumn("SHEMAIRASTRANEIDSTRANEKNJIZENJA");
            UltraGridColumn column4 = new UltraGridColumn("IDIRAVRSTAIZNOSA");
            UltraGridColumn column7 = new UltraGridColumn("SHEMAIRAMTIDMJESTOTROSKA");
            UltraGridColumn column8 = new UltraGridColumn("SHEMAIRAOJIDORGJED");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.SHEMAIRAIDSHEMAIRADescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.SHEMAIRANAZIVSHEMAIRADescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.SHEMAIRASHEMAIRADOKIDDOKUMENTDescription;
            column3.Width = 0x48;
            column3.Format = "#######";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.SHEMAIRAIDSHEMAIRADescription;
            column5.Width = 0x33;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnn";
            column5.PromptChar = ' ';
            column5.Format = "";
            column5.CellAppearance = appearance5;
            column5.Hidden = true;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.SHEMAIRASHEMAIRAKONTOIDKONTODescription;
            column6.Width = 0x72;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.SHEMAIRASHEMAIRASTRANEIDSTRANEKNJIZENJADescription;
            column9.Width = 0x7e;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.SHEMAIRAIDIRAVRSTAIZNOSADescription;
            column4.Width = 0x63;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.SHEMAIRASHEMAIRAMTIDMJESTOTROSKADescription;
            column7.Width = 0x48;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.SHEMAIRASHEMAIRAOJIDORGJEDDescription;
            column8.Width = 0x48;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            band2.Columns.Add(column5);
            column5.Header.VisiblePosition = 0;
            band2.Columns.Add(column6);
            column6.Header.VisiblePosition = 1;
            band2.Columns.Add(column9);
            column9.Header.VisiblePosition = 2;
            band2.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
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
            this.userControlDataGridSHEMAIRA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridSHEMAIRA.Location = point;
            this.userControlDataGridSHEMAIRA.Name = "userControlDataGridSHEMAIRA";
            this.userControlDataGridSHEMAIRA.Tag = "SHEMAIRA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridSHEMAIRA.Size = size;
            this.userControlDataGridSHEMAIRA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridSHEMAIRA.Dock = DockStyle.Fill;
            this.userControlDataGridSHEMAIRA.FillAtStartup = false;
            this.userControlDataGridSHEMAIRA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridSHEMAIRA.InitializeRow += new InitializeRowEventHandler(this.SHEMAIRAUserDataGrid_InitializeRow);
            this.userControlDataGridSHEMAIRA.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridSHEMAIRA.DisplayLayout.BandsSerializer.Add(band2);
            this.Controls.AddRange(new Control[] { this.userControlDataGridSHEMAIRA });
            this.Name = "SHEMAIRAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.SHEMAIRAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridSHEMAIRA).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
            if (DataAdapterFactory.Provider == null)
            {
                DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
            }
            DataSet dataSet = new DOKUMENTDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetDOKUMENTDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["DOKUMENT"]) {
                Sort = "NAZIVDOKUMENT"
            };
            CreateValueList(this.DataGrid, "DOKUMENTSHEMAIRADOKIDDOKUMENT", dataList, "IDDOKUMENT", "NAZIVDOKUMENT");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["SHEMAIRA"].Columns["SHEMAIRADOKIDDOKUMENT"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["DOKUMENTSHEMAIRADOKIDDOKUMENT"];
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
            CreateValueList(this.DataGrid, "KONTOSHEMAIRAKONTOIDKONTO", view3, "IDKONTO", "KONT");
            UltraGridColumn column3 = this.DataGrid.DisplayLayout.Bands["SHEMAIRA_SHEMAIRASHEMAIRAKONTIRANJE"].Columns["SHEMAIRAKONTOIDKONTO"];
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column3.ValueList = this.DataGrid.DisplayLayout.ValueLists["KONTOSHEMAIRAKONTOIDKONTO"];
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
            CreateValueList(this.DataGrid, "STRANEKNJIZENJASHEMAIRASTRANEIDSTRANEKNJIZENJA", view6, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA");
            UltraGridColumn column6 = this.DataGrid.DisplayLayout.Bands["SHEMAIRA_SHEMAIRASHEMAIRAKONTIRANJE"].Columns["SHEMAIRASTRANEIDSTRANEKNJIZENJA"];
            column6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column6.ValueList = this.DataGrid.DisplayLayout.ValueLists["STRANEKNJIZENJASHEMAIRASTRANEIDSTRANEKNJIZENJA"];
            if (setColumnsWidth)
            {
                column6.Width = 280;
            }
            DataSet set2 = new IRAVRSTAIZNOSADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetIRAVRSTAIZNOSADataAdapter().Fill(set2);
            }
            System.Data.DataView view2 = new System.Data.DataView(set2.Tables["IRAVRSTAIZNOSA"]) {
                Sort = "IRAVRSTAIZNOSANAZIV"
            };
            CreateValueList(this.DataGrid, "IRAVRSTAIZNOSAIDIRAVRSTAIZNOSA", view2, "IDIRAVRSTAIZNOSA", "IRAVRSTAIZNOSANAZIV");
            UltraGridColumn column2 = this.DataGrid.DisplayLayout.Bands["SHEMAIRA_SHEMAIRASHEMAIRAKONTIRANJE"].Columns["IDIRAVRSTAIZNOSA"];
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.DataGrid.DisplayLayout.ValueLists["IRAVRSTAIZNOSAIDIRAVRSTAIZNOSA"];
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
            CreateValueList(this.DataGrid, "MJESTOTROSKASHEMAIRAMTIDMJESTOTROSKA", view4, "IDMJESTOTROSKA", "mt");
            UltraGridColumn column4 = this.DataGrid.DisplayLayout.Bands["SHEMAIRA_SHEMAIRASHEMAIRAKONTIRANJE"].Columns["SHEMAIRAMTIDMJESTOTROSKA"];
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column4.ValueList = this.DataGrid.DisplayLayout.ValueLists["MJESTOTROSKASHEMAIRAMTIDMJESTOTROSKA"];
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
            CreateValueList(this.DataGrid, "ORGJEDSHEMAIRAOJIDORGJED", view5, "IDORGJED", "oj");
            UltraGridColumn column5 = this.DataGrid.DisplayLayout.Bands["SHEMAIRA_SHEMAIRASHEMAIRAKONTIRANJE"].Columns["SHEMAIRAOJIDORGJED"];
            column5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column5.ValueList = this.DataGrid.DisplayLayout.ValueLists["ORGJEDSHEMAIRAOJIDORGJED"];
            if (setColumnsWidth)
            {
                column5.Width = 370;
            }
        }

        private void SHEMAIRAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void SHEMAIRAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual SHEMAIRADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridSHEMAIRA;
            }
            set
            {
                this.userControlDataGridSHEMAIRA = value;
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

        [DefaultValue(true), Category("Deklarit Work With "), Description("True= Fill at Startup. False= Not Fill")]
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
        public virtual int FillBySHEMAIRADOKIDDOKUMENTSHEMAIRADOKIDDOKUMENT
        {
            get
            {
                return this.DataGrid.FillBySHEMAIRADOKIDDOKUMENTSHEMAIRADOKIDDOKUMENT;
            }
            set
            {
                this.DataGrid.FillBySHEMAIRADOKIDDOKUMENTSHEMAIRADOKIDDOKUMENT = value;
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

