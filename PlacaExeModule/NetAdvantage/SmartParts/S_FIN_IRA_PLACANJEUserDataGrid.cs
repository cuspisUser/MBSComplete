namespace NetAdvantage.SmartParts
{
    using Infragistics.Win;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using NetAdvantage.Controls;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class S_FIN_IRA_PLACANJEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_FIN_IRA_PLACANJE";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_FIN_IRA_PLACANJE";
        private S_FIN_IRA_PLACANJEDataGrid userControlDataGridS_FIN_IRA_PLACANJE;

        public S_FIN_IRA_PLACANJEUserDataGrid()
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
            this.userControlDataGridS_FIN_IRA_PLACANJE = new S_FIN_IRA_PLACANJEDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_FIN_IRA_PLACANJE).BeginInit();
            UltraGridBand band = new UltraGridBand("S_FIN_IRA_PLACANJE", -1);
            UltraGridColumn column26 = new UltraGridColumn("ZATVARANJE_IZNOS");
            UltraGridColumn column25 = new UltraGridColumn("ZATVARANJE_DATUM");
            UltraGridColumn column2 = new UltraGridColumn("IRABROJ");
            UltraGridColumn column = new UltraGridColumn("IDTIPIRA");
            UltraGridColumn column7 = new UltraGridColumn("IRAPARTNERIDPARTNER");
            UltraGridColumn column8 = new UltraGridColumn("IRAUKUPNO");
            UltraGridColumn column9 = new UltraGridColumn("IRAVALUTA");
            UltraGridColumn column6 = new UltraGridColumn("IRANAPOMENA");
            UltraGridColumn column3 = new UltraGridColumn("IRADATUM");
            UltraGridColumn column5 = new UltraGridColumn("IRAGODIDGODINE");
            UltraGridColumn column4 = new UltraGridColumn("IRADOKIDDOKUMENT");
            UltraGridColumn column12 = new UltraGridColumn("NAZIVPARTNER");
            UltraGridColumn column19 = new UltraGridColumn("PARTNEROIB");
            UltraGridColumn column23 = new UltraGridColumn("Status");
            UltraGridColumn column13 = new UltraGridColumn("NEPODLEZE");
            UltraGridColumn column10 = new UltraGridColumn("IZVOZ");
            UltraGridColumn column11 = new UltraGridColumn("MEDJTRANS");
            UltraGridColumn column24 = new UltraGridColumn("TUZEMSTVO");
            UltraGridColumn column18 = new UltraGridColumn("OSTALO");
            UltraGridColumn column14 = new UltraGridColumn("NULA");
            UltraGridColumn column15 = new UltraGridColumn("OSN10");
            UltraGridColumn column16 = new UltraGridColumn("OSN22");
            UltraGridColumn column17 = new UltraGridColumn("OSN23");
            UltraGridColumn column20 = new UltraGridColumn("PDV10");
            UltraGridColumn column21 = new UltraGridColumn("PDV22");
            UltraGridColumn column22 = new UltraGridColumn("PDV23");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.NoEdit;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.S_FIN_IRA_PLACANJEZATVARANJE_IZNOSDescription;
            column26.Width = 0x88;
            appearance26.TextHAlign = HAlign.Right;
            column26.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column26.PromptChar = ' ';
            column26.Format = "F2";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.S_FIN_IRA_PLACANJEZATVARANJE_DATUMDescription;
            column25.Width = 0x87;
            column25.MinValue = DateTime.MinValue;
            column25.MaxValue = DateTime.MaxValue;
            column25.Format = "d";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_FIN_IRA_PLACANJEIRABROJDescription;
            column2.Width = 0x48;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_FIN_IRA_PLACANJEIDTIPIRADescription;
            column.Width = 0x48;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_FIN_IRA_PLACANJEIRAPARTNERIDPARTNERDescription;
            column7.Width = 0x70;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnn";
            column7.PromptChar = ' ';
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_FIN_IRA_PLACANJEIRAUKUPNODescription;
            column8.Width = 0x66;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.S_FIN_IRA_PLACANJEIRAVALUTADescription;
            column9.Width = 100;
            column9.MinValue = DateTime.MinValue;
            column9.MaxValue = DateTime.MaxValue;
            column9.Format = "d";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_FIN_IRA_PLACANJEIRANAPOMENADescription;
            column6.Width = 0x128;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_FIN_IRA_PLACANJEIRADATUMDescription;
            column3.Width = 100;
            column3.MinValue = DateTime.MinValue;
            column3.MaxValue = DateTime.MaxValue;
            column3.Format = "d";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_FIN_IRA_PLACANJEIRAGODIDGODINEDescription;
            column5.Width = 0x48;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnn";
            column5.PromptChar = ' ';
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_FIN_IRA_PLACANJEIRADOKIDDOKUMENTDescription;
            column4.Width = 0x77;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnn";
            column4.PromptChar = ' ';
            column4.Format = "#######";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.S_FIN_IRA_PLACANJENAZIVPARTNERDescription;
            column12.Width = 0x128;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.S_FIN_IRA_PLACANJEPARTNEROIBDescription;
            column19.Width = 0x5d;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.S_FIN_IRA_PLACANJEStatusDescription;
            column23.Width = 0x79;
            column23.Format = "";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.S_FIN_IRA_PLACANJENEPODLEZEDescription;
            column13.Width = 0x66;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column13.PromptChar = ' ';
            column13.Format = "F2";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.S_FIN_IRA_PLACANJEIZVOZDescription;
            column10.Width = 0x66;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.S_FIN_IRA_PLACANJEMEDJTRANSDescription;
            column11.Width = 0x66;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.S_FIN_IRA_PLACANJETUZEMSTVODescription;
            column24.Width = 0x66;
            appearance24.TextHAlign = HAlign.Right;
            column24.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column24.PromptChar = ' ';
            column24.Format = "F2";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.S_FIN_IRA_PLACANJEOSTALODescription;
            column18.Width = 0x66;
            appearance18.TextHAlign = HAlign.Right;
            column18.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column18.PromptChar = ' ';
            column18.Format = "F2";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.S_FIN_IRA_PLACANJENULADescription;
            column14.Width = 0x66;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.S_FIN_IRA_PLACANJEOSN10Description;
            column15.Width = 0x66;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column15.PromptChar = ' ';
            column15.Format = "F2";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.S_FIN_IRA_PLACANJEOSN22Description;
            column16.Width = 0x66;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column16.PromptChar = ' ';
            column16.Format = "F2";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.S_FIN_IRA_PLACANJEOSN23Description;
            column17.Width = 0x66;
            appearance17.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column17.PromptChar = ' ';
            column17.Format = "F2";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.S_FIN_IRA_PLACANJEPDV10Description;
            column20.Width = 0x66;
            appearance20.TextHAlign = HAlign.Right;
            column20.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column20.PromptChar = ' ';
            column20.Format = "F2";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.S_FIN_IRA_PLACANJEPDV22Description;
            column21.Width = 0x66;
            appearance21.TextHAlign = HAlign.Right;
            column21.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column21.PromptChar = ' ';
            column21.Format = "F2";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.S_FIN_IRA_PLACANJEPDV23Description;
            column22.Width = 0x66;
            appearance22.TextHAlign = HAlign.Right;
            column22.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column22.PromptChar = ' ';
            column22.Format = "F2";
            column22.CellAppearance = appearance22;
            band.Columns.Add(column26);
            column26.Header.VisiblePosition = 0;
            band.Columns.Add(column25);
            column25.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 3;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 4;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 5;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 6;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 7;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 8;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 9;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 10;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 11;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 12;
            band.Columns.Add(column23);
            column23.Header.VisiblePosition = 13;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 14;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 15;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 0x10;
            band.Columns.Add(column24);
            column24.Header.VisiblePosition = 0x11;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 0x12;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 0x13;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 20;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 0x15;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 0x16;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 0x17;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 0x18;
            band.Columns.Add(column22);
            column22.Header.VisiblePosition = 0x19;
            this.userControlDataGridS_FIN_IRA_PLACANJE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_IRA_PLACANJE.Location = point;
            this.userControlDataGridS_FIN_IRA_PLACANJE.Name = "userControlDataGridS_FIN_IRA_PLACANJE";
            this.userControlDataGridS_FIN_IRA_PLACANJE.Tag = "S_FIN_IRA_PLACANJE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_FIN_IRA_PLACANJE.Size = size;
            this.userControlDataGridS_FIN_IRA_PLACANJE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_FIN_IRA_PLACANJE.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_IRA_PLACANJE.FillAtStartup = false;
            this.userControlDataGridS_FIN_IRA_PLACANJE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_FIN_IRA_PLACANJE.InitializeRow += new InitializeRowEventHandler(this.S_FIN_IRA_PLACANJEUserDataGrid_InitializeRow);
            this.userControlDataGridS_FIN_IRA_PLACANJE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_FIN_IRA_PLACANJE });
            this.Name = "S_FIN_IRA_PLACANJEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_FIN_IRA_PLACANJEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_FIN_IRA_PLACANJE).EndInit();
            this.ResumeLayout(false);
        }

        private void S_FIN_IRA_PLACANJEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_FIN_IRA_PLACANJEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_FIN_IRA_PLACANJEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_FIN_IRA_PLACANJE;
            }
            set
            {
                this.userControlDataGridS_FIN_IRA_PLACANJE = value;
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
        public virtual int ParameterIDDOKUMENT
        {
            get
            {
                return this.DataGrid.ParameterIDDOKUMENT;
            }
            set
            {
                this.DataGrid.ParameterIDDOKUMENT = value;
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

