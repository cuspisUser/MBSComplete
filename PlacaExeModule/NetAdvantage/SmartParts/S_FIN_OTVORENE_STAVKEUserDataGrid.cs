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

    public class S_FIN_OTVORENE_STAVKEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_FIN_OTVORENE_STAVKE";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_FIN_OTVORENE_STAVKE";
        private S_FIN_OTVORENE_STAVKEDataGrid userControlDataGridS_FIN_OTVORENE_STAVKE;

        public S_FIN_OTVORENE_STAVKEUserDataGrid()
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
            this.userControlDataGridS_FIN_OTVORENE_STAVKE = new S_FIN_OTVORENE_STAVKEDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_FIN_OTVORENE_STAVKE).BeginInit();
            UltraGridBand band = new UltraGridBand("S_FIN_OTVORENE_STAVKE", -1);
            UltraGridColumn column6 = new UltraGridColumn("duguje");
            UltraGridColumn column23 = new UltraGridColumn("POTRAZUJE");
            UltraGridColumn column12 = new UltraGridColumn("konto");
            UltraGridColumn column4 = new UltraGridColumn("DATUMDVO");
            UltraGridColumn column5 = new UltraGridColumn("DATUMVALUTE");
            UltraGridColumn column3 = new UltraGridColumn("DATUMDOK");
            UltraGridColumn column24 = new UltraGridColumn("SKRACENI");
            UltraGridColumn column = new UltraGridColumn("BROJDOK");
            UltraGridColumn column2 = new UltraGridColumn("BROJSTAVKE");
            UltraGridColumn column18 = new UltraGridColumn("OPISKNJIZENJA");
            UltraGridColumn column11 = new UltraGridColumn("IDPARTNER");
            UltraGridColumn column20 = new UltraGridColumn("OTVORENO");
            UltraGridColumn column14 = new UltraGridColumn("NAZIV");
            UltraGridColumn column7 = new UltraGridColumn("IDDOKUMENT");
            UltraGridColumn column17 = new UltraGridColumn("NAZIVPARTNER");
            UltraGridColumn column10 = new UltraGridColumn("IDORGJED");
            UltraGridColumn column9 = new UltraGridColumn("IDMJESTOTROSKA");
            UltraGridColumn column13 = new UltraGridColumn("MB");
            UltraGridColumn column21 = new UltraGridColumn("PARTNERMJESTO");
            UltraGridColumn column22 = new UltraGridColumn("PARTNERULICA");
            UltraGridColumn column8 = new UltraGridColumn("IDGKSTAVKA");
            UltraGridColumn column19 = new UltraGridColumn("ORIGINALNIDOKUMENT");
            UltraGridColumn column16 = new UltraGridColumn("NAZIVOJ");
            UltraGridColumn column15 = new UltraGridColumn("NAZIVMT");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEdugujeDescription;
            column6.Width = 0x66;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEPOTRAZUJEDescription;
            column23.Width = 0x66;
            appearance23.TextHAlign = HAlign.Right;
            column23.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column23.PromptChar = ' ';
            column23.Format = "F2";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEkontoDescription;
            column12.Width = 0x79;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEDATUMDVODescription;
            column4.Width = 100;
            column4.MinValue = DateTime.MinValue;
            column4.MaxValue = DateTime.MaxValue;
            column4.Format = "d";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEDATUMVALUTEDescription;
            column5.Width = 100;
            column5.MinValue = DateTime.MinValue;
            column5.MaxValue = DateTime.MaxValue;
            column5.Format = "d";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEDATUMDOKDescription;
            column3.Width = 100;
            column3.MinValue = DateTime.MinValue;
            column3.MaxValue = DateTime.MaxValue;
            column3.Format = "d";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKESKRACENIDescription;
            column24.Width = 0x128;
            column24.Format = "";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEBROJDOKDescription;
            column.Width = 0x48;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEBROJSTAVKEDescription;
            column2.Width = 0x55;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEOPISKNJIZENJADescription;
            column18.Width = 0x128;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEIDPARTNERDescription;
            column11.Width = 0x70;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEOTVORENODescription;
            column20.Width = 0x66;
            appearance20.TextHAlign = HAlign.Right;
            column20.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column20.PromptChar = ' ';
            column20.Format = "F2";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKENAZIVDescription;
            column14.Width = 0x128;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEIDDOKUMENTDescription;
            column7.Width = 0x77;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnn";
            column7.PromptChar = ' ';
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKENAZIVPARTNERDescription;
            column17.Width = 0x128;
            column17.Format = "";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEIDORGJEDDescription;
            column10.Width = 0x48;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnn";
            column10.PromptChar = ' ';
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEIDMJESTOTROSKADescription;
            column9.Width = 0x48;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnn";
            column9.PromptChar = ' ';
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEMBDescription;
            column13.Width = 0x6b;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEPARTNERMJESTODescription;
            column21.Width = 0x128;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEPARTNERULICADescription;
            column22.Width = 0x128;
            column22.Format = "";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEIDGKSTAVKADescription;
            column8.Width = 0x55;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnn";
            column8.PromptChar = ' ';
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKEORIGINALNIDOKUMENTDescription;
            column19.Width = 0x128;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKENAZIVOJDescription;
            column16.Width = 0x128;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.S_FIN_OTVORENE_STAVKENAZIVMTDescription;
            column15.Width = 0x128;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 0;
            band.Columns.Add(column23);
            column23.Header.VisiblePosition = 1;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 4;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 5;
            band.Columns.Add(column24);
            column24.Header.VisiblePosition = 6;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 7;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 8;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 9;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 10;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 11;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 12;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 13;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 14;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 15;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 0x10;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 0x11;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 0x12;
            band.Columns.Add(column22);
            column22.Header.VisiblePosition = 0x13;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 20;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 0x15;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 0x16;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 0x17;
            this.userControlDataGridS_FIN_OTVORENE_STAVKE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_OTVORENE_STAVKE.Location = point;
            this.userControlDataGridS_FIN_OTVORENE_STAVKE.Name = "userControlDataGridS_FIN_OTVORENE_STAVKE";
            this.userControlDataGridS_FIN_OTVORENE_STAVKE.Tag = "S_FIN_OTVORENE_STAVKE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_FIN_OTVORENE_STAVKE.Size = size;
            this.userControlDataGridS_FIN_OTVORENE_STAVKE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_FIN_OTVORENE_STAVKE.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_OTVORENE_STAVKE.FillAtStartup = false;
            this.userControlDataGridS_FIN_OTVORENE_STAVKE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_FIN_OTVORENE_STAVKE.InitializeRow += new InitializeRowEventHandler(this.S_FIN_OTVORENE_STAVKEUserDataGrid_InitializeRow);
            this.userControlDataGridS_FIN_OTVORENE_STAVKE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_FIN_OTVORENE_STAVKE });
            this.Name = "S_FIN_OTVORENE_STAVKEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_FIN_OTVORENE_STAVKEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_FIN_OTVORENE_STAVKE).EndInit();
            this.ResumeLayout(false);
        }

        private void S_FIN_OTVORENE_STAVKEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_FIN_OTVORENE_STAVKEUserDataGrid_Load(object sender, EventArgs e)
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
            DataSet dataSet = new PARTNERDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetPARTNERDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["PARTNER"]) {
                Sort = "PT"
            };
            CreateValueList(this.DataGrid, "PARTNERIDPARTNER", dataList, "IDPARTNER", "PT");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["S_FIN_OTVORENE_STAVKE"].Columns["IDPARTNER"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["PARTNERIDPARTNER"];
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
        public virtual S_FIN_OTVORENE_STAVKEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_FIN_OTVORENE_STAVKE;
            }
            set
            {
                this.userControlDataGridS_FIN_OTVORENE_STAVKE = value;
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
        public virtual string ParameterDODATNIUVJET
        {
            get
            {
                return this.DataGrid.ParameterDODATNIUVJET;
            }
            set
            {
                this.DataGrid.ParameterDODATNIUVJET = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterDOK
        {
            get
            {
                return this.DataGrid.ParameterDOK;
            }
            set
            {
                this.DataGrid.ParameterDOK = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual short ParameterGODINA
        {
            get
            {
                return this.DataGrid.ParameterGODINA;
            }
            set
            {
                this.DataGrid.ParameterGODINA = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterIDAKTIVNOST
        {
            get
            {
                return this.DataGrid.ParameterIDAKTIVNOST;
            }
            set
            {
                this.DataGrid.ParameterIDAKTIVNOST = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterIDPARTNER
        {
            get
            {
                return this.DataGrid.ParameterIDPARTNER;
            }
            set
            {
                this.DataGrid.ParameterIDPARTNER = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterMT
        {
            get
            {
                return this.DataGrid.ParameterMT;
            }
            set
            {
                this.DataGrid.ParameterMT = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterORG
        {
            get
            {
                return this.DataGrid.ParameterORG;
            }
            set
            {
                this.DataGrid.ParameterORG = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterPOCETNIKONTO
        {
            get
            {
                return this.DataGrid.ParameterPOCETNIKONTO;
            }
            set
            {
                this.DataGrid.ParameterPOCETNIKONTO = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual DateTime ParameterRAZDOBLJEDO
        {
            get
            {
                return this.DataGrid.ParameterRAZDOBLJEDO;
            }
            set
            {
                this.DataGrid.ParameterRAZDOBLJEDO = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual DateTime ParameterRAZDOBLJEOD
        {
            get
            {
                return this.DataGrid.ParameterRAZDOBLJEOD;
            }
            set
            {
                this.DataGrid.ParameterRAZDOBLJEOD = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterZAVRSNIKONTO
        {
            get
            {
                return this.DataGrid.ParameterZAVRSNIKONTO;
            }
            set
            {
                this.DataGrid.ParameterZAVRSNIKONTO = value;
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

