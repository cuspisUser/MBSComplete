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

    public class URAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with URA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with URA";
        private URADataGrid userControlDataGridURA;

        public URAUserDataGrid()
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
            this.userControlDataGridURA = new URADataGrid();
            ((ISupportInitialize) this.userControlDataGridURA).BeginInit();
            UltraGridBand band = new UltraGridBand("URA", -1);
            UltraGridColumn column20 = new UltraGridColumn("URAGODIDGODINE");
            UltraGridColumn column19 = new UltraGridColumn("URADOKIDDOKUMENT");
            UltraGridColumn column16 = new UltraGridColumn("URABROJ");
            UltraGridColumn column23 = new UltraGridColumn("urapartnerIDPARTNER");
            UltraGridColumn column = new UltraGridColumn("IDTIPURA");
            UltraGridColumn column17 = new UltraGridColumn("URABROJRACUNADOBAVLJACA");
            UltraGridColumn column18 = new UltraGridColumn("URADATUM");
            UltraGridColumn column26 = new UltraGridColumn("URAVALUTA");
            UltraGridColumn column22 = new UltraGridColumn("URANAPOMENA");
            UltraGridColumn column21 = new UltraGridColumn("URAMODEL");
            UltraGridColumn column24 = new UltraGridColumn("URAPOZIVNABROJ");
            UltraGridColumn column25 = new UltraGridColumn("URAUKUPNO");
            UltraGridColumn column2 = new UltraGridColumn("OSNOVICA0");
            UltraGridColumn column3 = new UltraGridColumn("OSNOVICA10");
            UltraGridColumn column5 = new UltraGridColumn("OSNOVICA22");
            UltraGridColumn column7 = new UltraGridColumn("OSNOVICA23");
            UltraGridColumn column4 = new UltraGridColumn("OSNOVICA10NE");
            UltraGridColumn column6 = new UltraGridColumn("OSNOVICA22NE");
            UltraGridColumn column8 = new UltraGridColumn("OSNOVICA23NE");
            UltraGridColumn column9 = new UltraGridColumn("PDV10DA");
            UltraGridColumn column10 = new UltraGridColumn("PDV10NE");
            UltraGridColumn column11 = new UltraGridColumn("PDV22DA");
            UltraGridColumn column12 = new UltraGridColumn("PDV22NE");
            UltraGridColumn column13 = new UltraGridColumn("PDV23DA");
            UltraGridColumn column14 = new UltraGridColumn("PDV23NE");
            UltraGridColumn column15 = new UltraGridColumn("R2");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.URAURAGODIDGODINEDescription;
            column20.Width = 0x3a;
            appearance20.TextHAlign = HAlign.Right;
            column20.MaskInput = "{LOC}-nnnn";
            column20.PromptChar = ' ';
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.URAURADOKIDDOKUMENTDescription;
            column19.Width = 0x48;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.URAURABROJDescription;
            column16.Width = 0x48;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnnn";
            column16.PromptChar = ' ';
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.URAurapartnerIDPARTNERDescription;
            column23.Width = 0x4e;
            column23.Format = "";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.URAIDTIPURADescription;
            column.Width = 0x41;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.URAURABROJRACUNADOBAVLJACADescription;
            column17.Width = 0x128;
            column17.Format = "";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.URAURADATUMDescription;
            column18.Width = 100;
            column18.MinValue = DateTime.MinValue;
            column18.MaxValue = DateTime.MaxValue;
            column18.Format = "d";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.NoEdit;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.URAURAVALUTADescription;
            column26.Width = 100;
            column26.MinValue = DateTime.MinValue;
            column26.MaxValue = DateTime.MaxValue;
            column26.Format = "d";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.URAURANAPOMENADescription;
            column22.Width = 0x128;
            column22.Format = "";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.URAURAMODELDescription;
            column21.Width = 0x79;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            column21.Hidden = true;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.URAURAPOZIVNABROJDescription;
            column24.Width = 0xb1;
            column24.Format = "";
            column24.CellAppearance = appearance24;
            column24.Hidden = true;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.URAURAUKUPNODescription;
            column25.Width = 150;
            appearance25.TextHAlign = HAlign.Right;
            column25.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column25.PromptChar = ' ';
            column25.Format = "F2";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.URAOSNOVICA0Description;
            column2.Width = 0x66;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            column2.Hidden = true;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.URAOSNOVICA10Description;
            column3.Width = 0x66;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            column3.Hidden = true;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.URAOSNOVICA22Description;
            column5.Width = 0x66;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            column5.Hidden = true;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.URAOSNOVICA23Description;
            column7.Width = 0x66;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            column7.Hidden = true;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.URAOSNOVICA10NEDescription;
            column4.Width = 0xe7;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            column4.Hidden = true;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.URAOSNOVICA22NEDescription;
            column6.Width = 0xe7;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            column6.Hidden = true;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.URAOSNOVICA23NEDescription;
            column8.Width = 0xe7;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            column8.Hidden = true;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.URAPDV10DADescription;
            column9.Width = 0xb1;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            column9.Hidden = true;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.URAPDV10NEDescription;
            column10.Width = 190;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance10;
            column10.Hidden = true;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.URAPDV22DADescription;
            column11.Width = 0xb1;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance11;
            column11.Hidden = true;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.URAPDV22NEDescription;
            column12.Width = 0xc5;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance12;
            column12.Hidden = true;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.URAPDV23DADescription;
            column13.Width = 0xb1;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column13.PromptChar = ' ';
            column13.Format = "F2";
            column13.CellAppearance = appearance13;
            column13.Hidden = true;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.URAPDV23NEDescription;
            column14.Width = 0xc5;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance14;
            column14.Hidden = true;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.URAR2Description;
            column15.Width = 30;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            column15.Hidden = true;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 0;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 1;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 2;
            band.Columns.Add(column23);
            column23.Header.VisiblePosition = 3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 4;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 5;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 6;
            band.Columns.Add(column26);
            column26.Header.VisiblePosition = 7;
            band.Columns.Add(column22);
            column22.Header.VisiblePosition = 8;
            band.Columns.Add(column25);
            column25.Header.VisiblePosition = 9;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 10;
            band.Columns.Add(column24);
            column24.Header.VisiblePosition = 11;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 12;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 13;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 14;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 15;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 0x10;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 0x11;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 0x12;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 0x13;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 20;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 0x15;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 0x16;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 0x17;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 0x18;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 0x19;
            this.userControlDataGridURA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridURA.Location = point;
            this.userControlDataGridURA.Name = "userControlDataGridURA";
            this.userControlDataGridURA.Tag = "URA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridURA.Size = size;
            this.userControlDataGridURA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridURA.Dock = DockStyle.Fill;
            this.userControlDataGridURA.FillAtStartup = false;
            this.userControlDataGridURA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridURA.InitializeRow += new InitializeRowEventHandler(this.URAUserDataGrid_InitializeRow);
            this.userControlDataGridURA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridURA });
            this.Name = "URAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.URAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridURA).EndInit();
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
            CreateValueList(this.DataGrid, "DOKUMENTURADOKIDDOKUMENT", dataList, "IDDOKUMENT", "NAZIVDOKUMENT");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["URA"].Columns["URADOKIDDOKUMENT"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["DOKUMENTURADOKIDDOKUMENT"];
            if (setColumnsWidth)
            {
                column.Width = 370;
            }
            DataSet set2 = new PARTNERDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetPARTNERDataAdapter().Fill(set2);
            }
            System.Data.DataView view2 = new System.Data.DataView(set2.Tables["PARTNER"]) {
                Sort = "PT"
            };
            CreateValueList(this.DataGrid, "PARTNERurapartnerIDPARTNER", view2, "IDPARTNER", "PT");
            UltraGridColumn column2 = this.DataGrid.DisplayLayout.Bands["URA"].Columns["urapartnerIDPARTNER"];
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.DataGrid.DisplayLayout.ValueLists["PARTNERurapartnerIDPARTNER"];
            if (setColumnsWidth)
            {
                column2.Width = 370;
            }
        }

        private void URAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void URAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual URADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridURA;
            }
            set
            {
                this.userControlDataGridURA = value;
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

        [Category("Deklarit Work With ")]
        public virtual int FillByIDTIPURAIDTIPURA
        {
            get
            {
                return this.DataGrid.FillByIDTIPURAIDTIPURA;
            }
            set
            {
                this.DataGrid.FillByIDTIPURAIDTIPURA = value;
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
        public virtual int FillByURADOKIDDOKUMENTURADOKIDDOKUMENT
        {
            get
            {
                return this.DataGrid.FillByURADOKIDDOKUMENTURADOKIDDOKUMENT;
            }
            set
            {
                this.DataGrid.FillByURADOKIDDOKUMENTURADOKIDDOKUMENT = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByURAGODIDGODINEURADOKIDDOKUMENTURADOKIDDOKUMENT
        {
            get
            {
                return this.DataGrid.FillByURAGODIDGODINEURADOKIDDOKUMENTURADOKIDDOKUMENT;
            }
            set
            {
                this.DataGrid.FillByURAGODIDGODINEURADOKIDDOKUMENTURADOKIDDOKUMENT = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual short FillByURAGODIDGODINEURADOKIDDOKUMENTURAGODIDGODINE
        {
            get
            {
                return this.DataGrid.FillByURAGODIDGODINEURADOKIDDOKUMENTURAGODIDGODINE;
            }
            set
            {
                this.DataGrid.FillByURAGODIDGODINEURADOKIDDOKUMENTURAGODIDGODINE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual short FillByURAGODIDGODINEURAGODIDGODINE
        {
            get
            {
                return this.DataGrid.FillByURAGODIDGODINEURAGODIDGODINE;
            }
            set
            {
                this.DataGrid.FillByURAGODIDGODINEURAGODIDGODINE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByurapartnerIDPARTNERUrapartnerIDPARTNER
        {
            get
            {
                return this.DataGrid.FillByurapartnerIDPARTNERUrapartnerIDPARTNER;
            }
            set
            {
                this.DataGrid.FillByurapartnerIDPARTNERUrapartnerIDPARTNER = value;
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

