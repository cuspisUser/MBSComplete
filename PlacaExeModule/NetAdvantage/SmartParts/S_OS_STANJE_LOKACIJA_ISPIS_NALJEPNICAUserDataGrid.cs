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

    public class S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with ";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with ";
        private S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataGrid userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA;

        public S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAUserDataGrid()
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
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA = new S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataGrid();
            ((ISupportInitialize) this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA).BeginInit();
            UltraGridBand band = new UltraGridBand("S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA", -1);
            UltraGridColumn column = new UltraGridColumn("IDLOKACIJE");
            UltraGridColumn column2 = new UltraGridColumn("INVBROJ");
            UltraGridColumn column7 = new UltraGridColumn("ULAZ");
            UltraGridColumn column3 = new UltraGridColumn("IZLAZ");
            UltraGridColumn column6 = new UltraGridColumn("STANJE");
            UltraGridColumn column5 = new UltraGridColumn("OPISLOKACIJE");
            UltraGridColumn column4 = new UltraGridColumn("NAZIVOS");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAIDLOKACIJEDescription;
            column.Width = 0x48;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAINVBROJDescription;
            column2.Width = 0x77;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAULAZDescription;
            column7.Width = 0x66;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAIZLAZDescription;
            column3.Width = 0x66;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASTANJEDescription;
            column6.Width = 0x66;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAOPISLOKACIJEDescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICANAZIVOSDescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 2;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 3;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 4;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 5;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 6;
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Location = point;
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Name = "userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA";
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Tag = "S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Size = size;
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Dock = DockStyle.Fill;
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.FillAtStartup = false;
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.InitializeRow += new InitializeRowEventHandler(this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAUserDataGrid_InitializeRow);
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA });
            this.Name = "S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA).EndInit();
            this.ResumeLayout(false);
        }

        private void S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAUserDataGrid_Load(object sender, EventArgs e)
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
            DataSet dataSet = new LOKACIJEDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetLOKACIJEDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["LOKACIJE"]) {
                Sort = "LOK"
            };
            CreateValueList(this.DataGrid, "LOKACIJEIDLOKACIJE", dataList, "IDLOKACIJE", "LOK");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA"].Columns["IDLOKACIJE"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["LOKACIJEIDLOKACIJE"];
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
        public virtual S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA;
            }
            set
            {
                this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA = value;
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
        public virtual int ParameterIDLOKACIJE
        {
            get
            {
                return this.DataGrid.ParameterIDLOKACIJE;
            }
            set
            {
                this.DataGrid.ParameterIDLOKACIJE = value;
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

