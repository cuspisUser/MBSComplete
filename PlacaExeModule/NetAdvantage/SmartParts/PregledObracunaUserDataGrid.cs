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

    public class PregledObracunaUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with PregledObracuna";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with PregledObracuna";
        private PregledObracunaDataGrid userControlDataGridPregledObracuna;

        public PregledObracunaUserDataGrid()
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
            this.userControlDataGridPregledObracuna = new PregledObracunaDataGrid();
            ((ISupportInitialize) this.userControlDataGridPregledObracuna).BeginInit();
            UltraGridBand band = new UltraGridBand("PregledObracuna", -1);
            UltraGridColumn column6 = new UltraGridColumn("IDOBRACUN");
            UltraGridColumn column17 = new UltraGridColumn("VRSTAOBRACUNA");
            UltraGridColumn column9 = new UltraGridColumn("MJESECOBRACUNA");
            UltraGridColumn column4 = new UltraGridColumn("GODINAOBRACUNA");
            UltraGridColumn column7 = new UltraGridColumn("MJESECISPLATE");
            UltraGridColumn column3 = new UltraGridColumn("GODINAISPLATE");
            UltraGridColumn column = new UltraGridColumn("DATUMISPLATE");
            UltraGridColumn column16 = new UltraGridColumn("tjednifondsatiobracun");
            UltraGridColumn column8 = new UltraGridColumn("MJESECNIFONDSATIOBRACUN");
            UltraGridColumn column14 = new UltraGridColumn("OSNOVNIOO");
            UltraGridColumn column10 = new UltraGridColumn("OBRACUNSKAOSNOVICA");
            UltraGridColumn column2 = new UltraGridColumn("DATUMOBRACUNASTAZA");
            UltraGridColumn column13 = new UltraGridColumn("OBRPOSTOTNIH");
            UltraGridColumn column11 = new UltraGridColumn("OBRFIKSNIH");
            UltraGridColumn column12 = new UltraGridColumn("OBRKREDITNIH");
            UltraGridColumn column18 = new UltraGridColumn("ZAKLJ");
            UltraGridColumn column15 = new UltraGridColumn("SVRHAOBRACUNA");
            UltraGridColumn column5 = new UltraGridColumn("IDENTIFIKATOROBRASCA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.PregledObracunaIDOBRACUNDescription;
            column6.Width = 0x5d;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.PregledObracunaVRSTAOBRACUNADescription;
            column17.Width = 0x6b;
            column17.Format = "";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.PregledObracunaMJESECOBRACUNADescription;
            column9.Width = 0x79;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.PregledObracunaGODINAOBRACUNADescription;
            column4.Width = 0x79;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.PregledObracunaMJESECISPLATEDescription;
            column7.Width = 0x72;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.PregledObracunaGODINAISPLATEDescription;
            column3.Width = 0x72;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.PregledObracunaDATUMISPLATEDescription;
            column.Width = 0x6b;
            column.MinValue = DateTime.MinValue;
            column.MaxValue = DateTime.MaxValue;
            column.Format = "d";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.PregledObracunatjednifondsatiobracunDescription;
            column16.Width = 0x7e;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnn";
            column16.PromptChar = ' ';
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.PregledObracunaMJESECNIFONDSATIOBRACUNDescription;
            column8.Width = 0x8b;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnn";
            column8.PromptChar = ' ';
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.PregledObracunaOSNOVNIOODescription;
            column14.Width = 170;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.PregledObracunaOBRACUNSKAOSNOVICADescription;
            column10.Width = 150;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.PregledObracunaDATUMOBRACUNASTAZADescription;
            column2.Width = 0x8e;
            column2.MinValue = DateTime.MinValue;
            column2.MaxValue = DateTime.MaxValue;
            column2.Format = "d";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.PregledObracunaOBRPOSTOTNIHDescription;
            column13.Width = 100;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.PregledObracunaOBRFIKSNIHDescription;
            column11.Width = 0x56;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.PregledObracunaOBRKREDITNIHDescription;
            column12.Width = 100;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.PregledObracunaZAKLJDescription;
            column18.Width = 0x33;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.PregledObracunaSVRHAOBRACUNADescription;
            column15.Width = 0x128;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.PregledObracunaIDENTIFIKATOROBRASCADescription;
            column5.Width = 0x9c;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 0;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 1;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 4;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 5;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 6;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 7;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 8;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 9;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 10;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 11;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 12;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 13;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 14;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 15;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 0x10;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 0x11;
            this.userControlDataGridPregledObracuna.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridPregledObracuna.Location = point;
            this.userControlDataGridPregledObracuna.Name = "userControlDataGridPregledObracuna";
            this.userControlDataGridPregledObracuna.Tag = "PregledObracuna";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridPregledObracuna.Size = size;
            this.userControlDataGridPregledObracuna.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridPregledObracuna.Dock = DockStyle.Fill;
            this.userControlDataGridPregledObracuna.FillAtStartup = false;
            this.userControlDataGridPregledObracuna.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridPregledObracuna.InitializeRow += new InitializeRowEventHandler(this.PregledObracunaUserDataGrid_InitializeRow);
            this.userControlDataGridPregledObracuna.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridPregledObracuna });
            this.Name = "PregledObracunaUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.PregledObracunaUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridPregledObracuna).EndInit();
            this.ResumeLayout(false);
        }

        private void PregledObracunaUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void PregledObracunaUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual PregledObracunaDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridPregledObracuna;
            }
            set
            {
                this.userControlDataGridPregledObracuna = value;
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

