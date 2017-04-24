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

    public class GKSTAVKAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with GKSTAVKA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with GKSTAVKA";
        private GKSTAVKADataGrid userControlDataGridGKSTAVKA;

        public GKSTAVKAUserDataGrid()
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

        private void GKSTAVKAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void GKSTAVKAUserDataGrid_Load(object sender, EventArgs e)
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
            this.userControlDataGridGKSTAVKA = new GKSTAVKADataGrid();
            ((ISupportInitialize) this.userControlDataGridGKSTAVKA).BeginInit();
            UltraGridBand band = new UltraGridBand("GKSTAVKA", -1);
            UltraGridColumn column10 = new UltraGridColumn("IDGKSTAVKA");
            UltraGridColumn column8 = new UltraGridColumn("IDAKTIVNOST");
            UltraGridColumn column3 = new UltraGridColumn("DATUMDOKUMENTA");
            UltraGridColumn column = new UltraGridColumn("BROJDOKUMENTA");
            UltraGridColumn column2 = new UltraGridColumn("BROJSTAVKE");
            UltraGridColumn column9 = new UltraGridColumn("IDDOKUMENT");
            UltraGridColumn column16 = new UltraGridColumn("NAZIVDOKUMENT");
            UltraGridColumn column12 = new UltraGridColumn("IDMJESTOTROSKA");
            UltraGridColumn column18 = new UltraGridColumn("NAZIVMJESTOTROSKA");
            UltraGridColumn column13 = new UltraGridColumn("IDORGJED");
            UltraGridColumn column19 = new UltraGridColumn("NAZIVORGJED");
            UltraGridColumn column11 = new UltraGridColumn("IDKONTO");
            UltraGridColumn column17 = new UltraGridColumn("NAZIVKONTO");
            UltraGridColumn column15 = new UltraGridColumn("NAZIVAKTIVNOST");
            UltraGridColumn column21 = new UltraGridColumn("OPIS");
            UltraGridColumn column5 = new UltraGridColumn("duguje");
            UltraGridColumn column23 = new UltraGridColumn("POTRAZUJE");
            UltraGridColumn column4 = new UltraGridColumn("DATUMPRIJAVE");
            UltraGridColumn column14 = new UltraGridColumn("IDPARTNER");
            UltraGridColumn column20 = new UltraGridColumn("NAZIVPARTNER");
            UltraGridColumn column25 = new UltraGridColumn("ZATVORENIIZNOS");
            UltraGridColumn column6 = new UltraGridColumn("GKDATUMVALUTE");
            UltraGridColumn column24 = new UltraGridColumn("statusgk");
            UltraGridColumn column22 = new UltraGridColumn("ORIGINALNIDOKUMENT");
            UltraGridColumn column7 = new UltraGridColumn("GKGODIDGODINE");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.GKSTAVKAIDGKSTAVKADescription;
            column10.Width = 0x55;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnn";
            column10.PromptChar = ' ';
            column10.Format = "";
            column10.CellAppearance = appearance10;
            column10.Hidden = true;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.GKSTAVKAIDAKTIVNOSTDescription;
            column8.Width = 0x7e;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnn";
            column8.PromptChar = ' ';
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.GKSTAVKADATUMDOKUMENTADescription;
            column3.Width = 100;
            column3.MinValue = DateTime.MinValue;
            column3.MaxValue = DateTime.MaxValue;
            column3.Format = "d";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.GKSTAVKABROJDOKUMENTADescription;
            column.Width = 0x4e;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.GKSTAVKABROJSTAVKEDescription;
            column2.Width = 0x3a;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.GKSTAVKAIDDOKUMENTDescription;
            column9.Width = 0x77;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.GKSTAVKANAZIVDOKUMENTDescription;
            column16.Width = 0x128;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.GKSTAVKAIDMJESTOTROSKADescription;
            column12.Width = 0x48;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.GKSTAVKANAZIVMJESTOTROSKADescription;
            column18.Width = 0x128;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.GKSTAVKAIDORGJEDDescription;
            column13.Width = 0x48;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.GKSTAVKANAZIVORGJEDDescription;
            column19.Width = 0x128;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.GKSTAVKAIDKONTODescription;
            column11.Width = 0x72;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.GKSTAVKANAZIVKONTODescription;
            column17.Width = 0x128;
            column17.Format = "";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.GKSTAVKANAZIVAKTIVNOSTDescription;
            column15.Width = 0x128;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.GKSTAVKAOPISDescription;
            column21.Width = 0x128;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.GKSTAVKAdugujeDescription;
            column5.Width = 0x66;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.GKSTAVKAPOTRAZUJEDescription;
            column23.Width = 0x66;
            appearance23.TextHAlign = HAlign.Right;
            column23.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column23.PromptChar = ' ';
            column23.Format = "F2";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.GKSTAVKADATUMPRIJAVEDescription;
            column4.Width = 100;
            column4.MinValue = DateTime.MinValue;
            column4.MaxValue = DateTime.MaxValue;
            column4.Format = "d";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.GKSTAVKAIDPARTNERDescription;
            column14.Width = 0x70;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.GKSTAVKANAZIVPARTNERDescription;
            column20.Width = 0x128;
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.GKSTAVKAZATVORENIIZNOSDescription;
            column25.Width = 0x7b;
            appearance25.TextHAlign = HAlign.Right;
            column25.MaskInput = "{LOC}-nnnnnn.nn";
            column25.PromptChar = ' ';
            column25.Format = "F2";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.GKSTAVKAGKDATUMVALUTEDescription;
            column6.Width = 100;
            column6.MinValue = DateTime.MinValue;
            column6.MaxValue = DateTime.MaxValue;
            column6.Format = "d";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.GKSTAVKAstatusgkDescription;
            column24.Width = 0x48;
            column24.Format = "";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.GKSTAVKAORIGINALNIDOKUMENTDescription;
            column22.Width = 0x128;
            column22.Format = "";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.GKSTAVKAGKGODIDGODINEDescription;
            column7.Width = 0x3a;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnn";
            column7.PromptChar = ' ';
            column7.Format = "";
            column7.CellAppearance = appearance7;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 3;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 4;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 5;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 6;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 7;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 8;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 9;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 10;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 11;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 12;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 13;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 14;
            band.Columns.Add(column23);
            column23.Header.VisiblePosition = 15;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 0x10;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 0x11;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 0x12;
            band.Columns.Add(column25);
            column25.Header.VisiblePosition = 0x13;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 20;
            band.Columns.Add(column24);
            column24.Header.VisiblePosition = 0x15;
            band.Columns.Add(column22);
            column22.Header.VisiblePosition = 0x16;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 0x17;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 0x18;
            this.userControlDataGridGKSTAVKA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridGKSTAVKA.Location = point;
            this.userControlDataGridGKSTAVKA.Name = "userControlDataGridGKSTAVKA";
            this.userControlDataGridGKSTAVKA.Tag = "GKSTAVKA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridGKSTAVKA.Size = size;
            this.userControlDataGridGKSTAVKA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridGKSTAVKA.Dock = DockStyle.Fill;
            this.userControlDataGridGKSTAVKA.FillAtStartup = false;
            this.userControlDataGridGKSTAVKA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridGKSTAVKA.InitializeRow += new InitializeRowEventHandler(this.GKSTAVKAUserDataGrid_InitializeRow);
            this.userControlDataGridGKSTAVKA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridGKSTAVKA });
            this.Name = "GKSTAVKAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.GKSTAVKAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridGKSTAVKA).EndInit();
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
            CreateValueList(this.DataGrid, "DOKUMENTIDDOKUMENT", dataList, "IDDOKUMENT", "NAZIVDOKUMENT");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["GKSTAVKA"].Columns["IDDOKUMENT"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["DOKUMENTIDDOKUMENT"];
            if (setColumnsWidth)
            {
                column.Width = 370;
            }
            DataSet set3 = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(set3);
            }
            System.Data.DataView view3 = new System.Data.DataView(set3.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.DataGrid, "MJESTOTROSKAIDMJESTOTROSKA", view3, "IDMJESTOTROSKA", "mt");
            UltraGridColumn column3 = this.DataGrid.DisplayLayout.Bands["GKSTAVKA"].Columns["IDMJESTOTROSKA"];
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column3.ValueList = this.DataGrid.DisplayLayout.ValueLists["MJESTOTROSKAIDMJESTOTROSKA"];
            if (setColumnsWidth)
            {
                column3.Width = 370;
            }
            DataSet set4 = new ORGJEDDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetORGJEDDataAdapter().Fill(set4);
            }
            System.Data.DataView view4 = new System.Data.DataView(set4.Tables["ORGJED"]) {
                Sort = "oj"
            };
            CreateValueList(this.DataGrid, "ORGJEDIDORGJED", view4, "IDORGJED", "oj");
            UltraGridColumn column4 = this.DataGrid.DisplayLayout.Bands["GKSTAVKA"].Columns["IDORGJED"];
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column4.ValueList = this.DataGrid.DisplayLayout.ValueLists["ORGJEDIDORGJED"];
            if (setColumnsWidth)
            {
                column4.Width = 370;
            }
            DataSet set2 = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(set2);
            }
            System.Data.DataView view2 = new System.Data.DataView(set2.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.DataGrid, "KONTOIDKONTO", view2, "IDKONTO", "KONT");
            UltraGridColumn column2 = this.DataGrid.DisplayLayout.Bands["GKSTAVKA"].Columns["IDKONTO"];
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.DataGrid.DisplayLayout.ValueLists["KONTOIDKONTO"];
            if (setColumnsWidth)
            {
                column2.Width = 370;
            }
            DataSet set5 = new PARTNERDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetPARTNERDataAdapter().Fill(set5);
            }
            System.Data.DataView view5 = new System.Data.DataView(set5.Tables["PARTNER"]) {
                Sort = "PT"
            };
            CreateValueList(this.DataGrid, "PARTNERIDPARTNER", view5, "IDPARTNER", "PT");
            UltraGridColumn column5 = this.DataGrid.DisplayLayout.Bands["GKSTAVKA"].Columns["IDPARTNER"];
            column5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column5.ValueList = this.DataGrid.DisplayLayout.ValueLists["PARTNERIDPARTNER"];
            if (setColumnsWidth)
            {
                column5.Width = 370;
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
        public virtual GKSTAVKADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridGKSTAVKA;
            }
            set
            {
                this.userControlDataGridGKSTAVKA = value;
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

        [Category("Deklarit Work With ")]
        public virtual int FillByBROJSTAVKEBROJSTAVKE
        {
            get
            {
                return this.DataGrid.FillByBROJSTAVKEBROJSTAVKE;
            }
            set
            {
                this.DataGrid.FillByBROJSTAVKEBROJSTAVKE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual short FillByGKGODIDGODINEGKGODIDGODINE
        {
            get
            {
                return this.DataGrid.FillByGKGODIDGODINEGKGODIDGODINE;
            }
            set
            {
                this.DataGrid.FillByGKGODIDGODINEGKGODIDGODINE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDDOKUMENTBROJDOKUMENTABROJDOKUMENTA
        {
            get
            {
                return this.DataGrid.FillByIDDOKUMENTBROJDOKUMENTABROJDOKUMENTA;
            }
            set
            {
                this.DataGrid.FillByIDDOKUMENTBROJDOKUMENTABROJDOKUMENTA = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEBROJDOKUMENTA
        {
            get
            {
                return this.DataGrid.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEBROJDOKUMENTA;
            }
            set
            {
                this.DataGrid.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEBROJDOKUMENTA = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual short FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEGKGODIDGODINE
        {
            get
            {
                return this.DataGrid.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEGKGODIDGODINE;
            }
            set
            {
                this.DataGrid.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEGKGODIDGODINE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEIDDOKUMENT
        {
            get
            {
                return this.DataGrid.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEIDDOKUMENT;
            }
            set
            {
                this.DataGrid.FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINEIDDOKUMENT = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDDOKUMENTBROJDOKUMENTAIDDOKUMENT
        {
            get
            {
                return this.DataGrid.FillByIDDOKUMENTBROJDOKUMENTAIDDOKUMENT;
            }
            set
            {
                this.DataGrid.FillByIDDOKUMENTBROJDOKUMENTAIDDOKUMENT = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDDOKUMENTIDDOKUMENT
        {
            get
            {
                return this.DataGrid.FillByIDDOKUMENTIDDOKUMENT;
            }
            set
            {
                this.DataGrid.FillByIDDOKUMENTIDDOKUMENT = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual string FillByIDKONTOIDKONTO
        {
            get
            {
                return this.DataGrid.FillByIDKONTOIDKONTO;
            }
            set
            {
                this.DataGrid.FillByIDKONTOIDKONTO = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDMJESTOTROSKAIDMJESTOTROSKA
        {
            get
            {
                return this.DataGrid.FillByIDMJESTOTROSKAIDMJESTOTROSKA;
            }
            set
            {
                this.DataGrid.FillByIDMJESTOTROSKAIDMJESTOTROSKA = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDORGJEDIDORGJED
        {
            get
            {
                return this.DataGrid.FillByIDORGJEDIDORGJED;
            }
            set
            {
                this.DataGrid.FillByIDORGJEDIDORGJED = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDPARTNERIDPARTNER
        {
            get
            {
                return this.DataGrid.FillByIDPARTNERIDPARTNER;
            }
            set
            {
                this.DataGrid.FillByIDPARTNERIDPARTNER = value;
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

