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

    public class PARTNERUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with PARTNER";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with PARTNER";
        private PARTNERDataGrid userControlDataGridPARTNER;

        public PARTNERUserDataGrid()
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
            this.userControlDataGridPARTNER = new PARTNERDataGrid();
            ((ISupportInitialize) this.userControlDataGridPARTNER).BeginInit();
            UltraGridBand band = new UltraGridBand("PARTNER", -1);
            UltraGridColumn column = new UltraGridColumn("IDPARTNER");
            UltraGridColumn column3 = new UltraGridColumn("NAZIVPARTNER");
            UltraGridColumn column2 = new UltraGridColumn("MB");
            UltraGridColumn column6 = new UltraGridColumn("PARTNERMJESTO");
            UltraGridColumn column9 = new UltraGridColumn("PARTNERULICA");
            UltraGridColumn column4 = new UltraGridColumn("PARTNEREMAIL");
            UltraGridColumn column7 = new UltraGridColumn("PARTNEROIB");
            UltraGridColumn column5 = new UltraGridColumn("PARTNERFAX");
            UltraGridColumn column8 = new UltraGridColumn("PARTNERTELEFON");
            UltraGridColumn column10 = new UltraGridColumn("PARTNERZIRO1");
            UltraGridColumn column11 = new UltraGridColumn("PARTNERZIRO2");
            UltraGridColumn column12 = new UltraGridColumn("PT");
            UltraGridBand band2 = new UltraGridBand("PARTNER_PARTNERZADUZENJE", 0);
            UltraGridColumn column18 = new UltraGridColumn("IDPARTNER");
            UltraGridColumn column20 = new UltraGridColumn("IDZADUZENJE");
            UltraGridColumn column19 = new UltraGridColumn("IDPROIZVOD");
            UltraGridColumn column24 = new UltraGridColumn("NAZIVPROIZVOD");
            UltraGridColumn column14 = new UltraGridColumn("CIJENA");
            UltraGridColumn column23 = new UltraGridColumn("KOLICINAZADUZENJA");
            UltraGridColumn column15 = new UltraGridColumn("CIJENAZADUZENJA");
            UltraGridColumn column22 = new UltraGridColumn("IZNOSZADUZENJA");
            UltraGridColumn column25 = new UltraGridColumn("RABATZADUZENJA");
            UltraGridColumn column21 = new UltraGridColumn("IZNOSRABATAZADUZENJE");
            UltraGridColumn column16 = new UltraGridColumn("CIJENAZAFAKTURU");
            UltraGridColumn column26 = new UltraGridColumn("UGOVORBROJ");
            UltraGridColumn column17 = new UltraGridColumn("DATUMUGOVORA");
            UltraGridColumn column13 = new UltraGridColumn("AKTIVNO");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.PARTNERIDPARTNERDescription;
            column.Width = 0x4e;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.PARTNERNAZIVPARTNERDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.PARTNERMBDescription;
            column2.Width = 0x6b;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.PARTNERPARTNERMJESTODescription;
            column6.Width = 0x128;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.PARTNERPARTNERULICADescription;
            column9.Width = 0x128;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.PARTNERPARTNEREMAILDescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.PARTNERPARTNEROIBDescription;
            column7.Width = 0x5d;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.PARTNERPARTNERFAXDescription;
            column5.Width = 0x9c;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.PARTNERPARTNERTELEFONDescription;
            column8.Width = 0x128;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.PARTNERPARTNERZIRO1Description;
            column10.Width = 0x8e;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.PARTNERPARTNERZIRO2Description;
            column11.Width = 0x8e;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.PARTNERPTDescription;
            column12.Width = 0x128;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.PARTNERIDPARTNERDescription;
            column18.Width = 0x4e;
            appearance18.TextHAlign = HAlign.Right;
            column18.MaskInput = "{LOC}-nnnnnnnnn";
            column18.PromptChar = ' ';
            column18.Format = "";
            column18.CellAppearance = appearance18;
            column18.Hidden = true;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.PARTNERIDZADUZENJEDescription;
            column20.Width = 0x4e;
            appearance20.TextHAlign = HAlign.Right;
            column20.MaskInput = "{LOC}-nnnnn";
            column20.PromptChar = ' ';
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.PARTNERIDPROIZVODDescription;
            column19.Width = 0x55;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.PARTNERNAZIVPROIZVODDescription;
            column24.Width = 0x128;
            column24.Format = "";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.PARTNERCIJENADescription;
            column14.Width = 0x52;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnn.nnnn";
            column14.PromptChar = ' ';
            column14.Format = "F4";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.PARTNERKOLICINAZADUZENJADescription;
            column23.Width = 0x4b;
            appearance23.TextHAlign = HAlign.Right;
            column23.MaskInput = "{LOC}-nnn.nn";
            column23.PromptChar = ' ';
            column23.Format = "F2";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.PARTNERCIJENAZADUZENJADescription;
            column15.Width = 0x66;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column15.PromptChar = ' ';
            column15.Format = "F2";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.PARTNERIZNOSZADUZENJADescription;
            column22.Width = 0x66;
            appearance22.TextHAlign = HAlign.Right;
            column22.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column22.PromptChar = ' ';
            column22.Format = "F2";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.PARTNERRABATZADUZENJADescription;
            column25.Width = 0x45;
            appearance25.TextHAlign = HAlign.Right;
            column25.MaskInput = "{LOC}-nnn.nn";
            column25.PromptChar = ' ';
            column25.Format = "F2";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.PARTNERIZNOSRABATAZADUZENJEDescription;
            column21.Width = 0x66;
            appearance21.TextHAlign = HAlign.Right;
            column21.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column21.PromptChar = ' ';
            column21.Format = "F2";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.PARTNERCIJENAZAFAKTURUDescription;
            column16.Width = 170;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column16.PromptChar = ' ';
            column16.Format = "F2";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.NoEdit;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.PARTNERUGOVORBROJDescription;
            column26.Width = 0x128;
            column26.Format = "";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.PARTNERDATUMUGOVORADescription;
            column17.Width = 100;
            column17.MinValue = DateTime.MinValue;
            column17.MaxValue = DateTime.MaxValue;
            column17.Format = "d";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.PARTNERAKTIVNODescription;
            column13.Width = 0x41;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            band2.Columns.Add(column18);
            column18.Header.VisiblePosition = 0;
            band2.Columns.Add(column20);
            column20.Header.VisiblePosition = 1;
            band2.Columns.Add(column19);
            column19.Header.VisiblePosition = 2;
            band2.Columns.Add(column24);
            column24.Header.VisiblePosition = 3;
            band2.Columns.Add(column14);
            column14.Header.VisiblePosition = 4;
            band2.Columns.Add(column23);
            column23.Header.VisiblePosition = 5;
            band2.Columns.Add(column15);
            column15.Header.VisiblePosition = 6;
            band2.Columns.Add(column22);
            column22.Header.VisiblePosition = 7;
            band2.Columns.Add(column25);
            column25.Header.VisiblePosition = 8;
            band2.Columns.Add(column21);
            column21.Header.VisiblePosition = 9;
            band2.Columns.Add(column16);
            column16.Header.VisiblePosition = 10;
            band2.Columns.Add(column26);
            column26.Header.VisiblePosition = 11;
            band2.Columns.Add(column17);
            column17.Header.VisiblePosition = 12;
            band2.Columns.Add(column13);
            column13.Header.VisiblePosition = 13;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 3;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 4;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 5;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 6;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 7;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 8;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 9;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 10;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 11;
            this.userControlDataGridPARTNER.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridPARTNER.Location = point;
            this.userControlDataGridPARTNER.Name = "userControlDataGridPARTNER";
            this.userControlDataGridPARTNER.Tag = "PARTNER";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridPARTNER.Size = size;
            this.userControlDataGridPARTNER.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridPARTNER.Dock = DockStyle.Fill;
            this.userControlDataGridPARTNER.FillAtStartup = false;
            this.userControlDataGridPARTNER.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridPARTNER.InitializeRow += new InitializeRowEventHandler(this.PARTNERUserDataGrid_InitializeRow);
            this.userControlDataGridPARTNER.DisplayLayout.BandsSerializer.Add(band);
            this.userControlDataGridPARTNER.DisplayLayout.BandsSerializer.Add(band2);
            this.Controls.AddRange(new Control[] { this.userControlDataGridPARTNER });
            this.Name = "PARTNERUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.PARTNERUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridPARTNER).EndInit();
            this.ResumeLayout(false);
        }

        private void PARTNERUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void PARTNERUserDataGrid_Load(object sender, EventArgs e)
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
            DataSet dataSet = new PROIZVODDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetPROIZVODDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["PROIZVOD"]) {
                Sort = "NAZIVPROIZVOD"
            };
            CreateValueList(this.DataGrid, "PROIZVODIDPROIZVOD", dataList, "IDPROIZVOD", "NAZIVPROIZVOD");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["PARTNER_PARTNERZADUZENJE"].Columns["IDPROIZVOD"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["PROIZVODIDPROIZVOD"];
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
        public virtual PARTNERDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridPARTNER;
            }
            set
            {
                this.userControlDataGridPARTNER = value;
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

