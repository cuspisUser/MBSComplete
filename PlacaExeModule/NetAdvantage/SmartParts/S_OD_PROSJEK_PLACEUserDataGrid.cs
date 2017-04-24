namespace NetAdvantage.SmartParts
{
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

    public class S_OD_PROSJEK_PLACEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_OD_PROSJEK_PLACE";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_OD_PROSJEK_PLACE";
        private S_OD_PROSJEK_PLACEDataGrid userControlDataGridS_OD_PROSJEK_PLACE;

        public S_OD_PROSJEK_PLACEUserDataGrid()
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
            this.userControlDataGridS_OD_PROSJEK_PLACE = new S_OD_PROSJEK_PLACEDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_OD_PROSJEK_PLACE).BeginInit();
            UltraGridBand band = new UltraGridBand("S_OD_PROSJEK_PLACE", -1);
            UltraGridColumn column6 = new UltraGridColumn("netoplaca");
            UltraGridColumn column3 = new UltraGridColumn("IME");
            UltraGridColumn column7 = new UltraGridColumn("PREZIME");
            UltraGridColumn column2 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column8 = new UltraGridColumn("ulica");
            UltraGridColumn column4 = new UltraGridColumn("kucnibroj");
            UltraGridColumn column5 = new UltraGridColumn("mjesto");
            UltraGridColumn column = new UltraGridColumn("GODINAMJESEC");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_OD_PROSJEK_PLACEnetoplacaDescription;
            column6.Width = 0x66;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_OD_PROSJEK_PLACEIMEDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_OD_PROSJEK_PLACEPREZIMEDescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_OD_PROSJEK_PLACEIDRADNIKDescription;
            column2.Width = 0x69;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_OD_PROSJEK_PLACEulicaDescription;
            column8.Width = 0x128;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_OD_PROSJEK_PLACEkucnibrojDescription;
            column4.Width = 0x56;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_OD_PROSJEK_PLACEmjestoDescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_OD_PROSJEK_PLACEGODINAMJESECDescription;
            column.Width = 100;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 2;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 3;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 4;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 5;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 6;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 7;
            this.userControlDataGridS_OD_PROSJEK_PLACE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OD_PROSJEK_PLACE.Location = point;
            this.userControlDataGridS_OD_PROSJEK_PLACE.Name = "userControlDataGridS_OD_PROSJEK_PLACE";
            this.userControlDataGridS_OD_PROSJEK_PLACE.Tag = "S_OD_PROSJEK_PLACE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_OD_PROSJEK_PLACE.Size = size;
            this.userControlDataGridS_OD_PROSJEK_PLACE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_OD_PROSJEK_PLACE.Dock = DockStyle.Fill;
            this.userControlDataGridS_OD_PROSJEK_PLACE.FillAtStartup = false;
            this.userControlDataGridS_OD_PROSJEK_PLACE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_OD_PROSJEK_PLACE.InitializeRow += new InitializeRowEventHandler(this.S_OD_PROSJEK_PLACEUserDataGrid_InitializeRow);
            this.userControlDataGridS_OD_PROSJEK_PLACE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_OD_PROSJEK_PLACE });
            this.Name = "S_OD_PROSJEK_PLACEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_OD_PROSJEK_PLACEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_OD_PROSJEK_PLACE).EndInit();
            this.ResumeLayout(false);
        }

        private void S_OD_PROSJEK_PLACEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_OD_PROSJEK_PLACEUserDataGrid_Load(object sender, EventArgs e)
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
            PregledRadnikaComboBox box = new PregledRadnikaComboBox();
            box.Fill();
            System.Data.DataView defaultView = box.DataSet.Tables["RADNIK"].DefaultView;
            defaultView.Sort = "SPOJENOPREZIME";
            CreateValueList(this.DataGrid, "RADNIKIDRADNIK", defaultView, "IDRADNIK", "SPOJENOPREZIME");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["S_OD_PROSJEK_PLACE"].Columns["IDRADNIK"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["RADNIKIDRADNIK"];
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
        public virtual S_OD_PROSJEK_PLACEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_OD_PROSJEK_PLACE;
            }
            set
            {
                this.userControlDataGridS_OD_PROSJEK_PLACE = value;
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
        public virtual string ParameterDOOO
        {
            get
            {
                return this.DataGrid.ParameterDOOO;
            }
            set
            {
                this.DataGrid.ParameterDOOO = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterIDRADNIK
        {
            get
            {
                return this.DataGrid.ParameterIDRADNIK;
            }
            set
            {
                this.DataGrid.ParameterIDRADNIK = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterODD
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

