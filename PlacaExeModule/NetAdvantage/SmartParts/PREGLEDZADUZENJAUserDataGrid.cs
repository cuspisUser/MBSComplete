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

    public class PREGLEDZADUZENJAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with PREGLEDZADUZENJA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with PREGLEDZADUZENJA";
        private PREGLEDZADUZENJADataGrid userControlDataGridPREGLEDZADUZENJA;

        public PREGLEDZADUZENJAUserDataGrid()
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
            this.userControlDataGridPREGLEDZADUZENJA = new PREGLEDZADUZENJADataGrid();
            ((ISupportInitialize) this.userControlDataGridPREGLEDZADUZENJA).BeginInit();
            UltraGridBand band = new UltraGridBand("PARTNERZADUZENJE", -1);
            UltraGridColumn column6 = new UltraGridColumn("IDPARTNER");
            UltraGridColumn column12 = new UltraGridColumn("NAZIVPARTNER");
            UltraGridColumn column14 = new UltraGridColumn("PARTNEROIB");
            UltraGridColumn column13 = new UltraGridColumn("NAZIVPROIZVOD");
            UltraGridColumn column7 = new UltraGridColumn("IDPROIZVOD");
            UltraGridColumn column8 = new UltraGridColumn("IDZADUZENJE");
            UltraGridColumn column11 = new UltraGridColumn("KOLICINAZADUZENJA");
            UltraGridColumn column2 = new UltraGridColumn("CIJENAZADUZENJA");
            UltraGridColumn column5 = new UltraGridColumn("FINPOREZSTOPA");
            UltraGridColumn column10 = new UltraGridColumn("IZNOSZADUZENJA");
            UltraGridColumn column15 = new UltraGridColumn("RABATZADUZENJA");
            UltraGridColumn column9 = new UltraGridColumn("IZNOSRABATAZADUZENJE");
            UltraGridColumn column3 = new UltraGridColumn("CIJENAZAFAKTURU");
            UltraGridColumn column16 = new UltraGridColumn("UGOVORBROJ");
            UltraGridColumn column4 = new UltraGridColumn("DATUMUGOVORA");
            UltraGridColumn column = new UltraGridColumn("AKTIVNO");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.PREGLEDZADUZENJAIDPARTNERDescription;
            column6.Width = 0x70;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnn";
            column6.PromptChar = ' ';
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.PREGLEDZADUZENJANAZIVPARTNERDescription;
            column12.Width = 0x128;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.PREGLEDZADUZENJAPARTNEROIBDescription;
            column14.Width = 0x5d;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.PREGLEDZADUZENJANAZIVPROIZVODDescription;
            column13.Width = 0x128;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.PREGLEDZADUZENJAIDPROIZVODDescription;
            column7.Width = 0x55;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnn";
            column7.PromptChar = ' ';
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.PREGLEDZADUZENJAIDZADUZENJEDescription;
            column8.Width = 0x4e;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnn";
            column8.PromptChar = ' ';
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.PREGLEDZADUZENJAKOLICINAZADUZENJADescription;
            column11.Width = 0x88;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.PREGLEDZADUZENJACIJENAZADUZENJADescription;
            column2.Width = 0x7b;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.PREGLEDZADUZENJAFINPOREZSTOPADescription;
            column5.Width = 0x6d;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.PREGLEDZADUZENJAIZNOSZADUZENJADescription;
            column10.Width = 0x74;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.PREGLEDZADUZENJARABATZADUZENJADescription;
            column15.Width = 0x74;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnn.nn";
            column15.PromptChar = ' ';
            column15.Format = "F2";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.PREGLEDZADUZENJAIZNOSRABATAZADUZENJEDescription;
            column9.Width = 0x9c;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.PREGLEDZADUZENJACIJENAZAFAKTURUDescription;
            column3.Width = 0x7b;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.PREGLEDZADUZENJAUGOVORBROJDescription;
            column16.Width = 0x128;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.PREGLEDZADUZENJADATUMUGOVORADescription;
            column4.Width = 100;
            column4.MinValue = DateTime.MinValue;
            column4.MaxValue = DateTime.MaxValue;
            column4.Format = "d";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.PREGLEDZADUZENJAAKTIVNODescription;
            column.Width = 0x41;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 0;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 1;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 2;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 3;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 4;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 5;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 6;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 7;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 8;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 9;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 10;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 11;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 12;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 13;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 14;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 15;
            this.userControlDataGridPREGLEDZADUZENJA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridPREGLEDZADUZENJA.Location = point;
            this.userControlDataGridPREGLEDZADUZENJA.Name = "userControlDataGridPREGLEDZADUZENJA";
            this.userControlDataGridPREGLEDZADUZENJA.Tag = "PARTNERZADUZENJE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridPREGLEDZADUZENJA.Size = size;
            this.userControlDataGridPREGLEDZADUZENJA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridPREGLEDZADUZENJA.Dock = DockStyle.Fill;
            this.userControlDataGridPREGLEDZADUZENJA.FillAtStartup = false;
            this.userControlDataGridPREGLEDZADUZENJA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridPREGLEDZADUZENJA.InitializeRow += new InitializeRowEventHandler(this.PREGLEDZADUZENJAUserDataGrid_InitializeRow);
            this.userControlDataGridPREGLEDZADUZENJA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridPREGLEDZADUZENJA });
            this.Name = "PREGLEDZADUZENJAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.PREGLEDZADUZENJAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridPREGLEDZADUZENJA).EndInit();
            this.ResumeLayout(false);
        }

        private void PREGLEDZADUZENJAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void PREGLEDZADUZENJAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual PREGLEDZADUZENJADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridPREGLEDZADUZENJA;
            }
            set
            {
                this.userControlDataGridPREGLEDZADUZENJA = value;
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

