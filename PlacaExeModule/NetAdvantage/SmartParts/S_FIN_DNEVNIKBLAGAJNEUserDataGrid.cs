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

    public class S_FIN_DNEVNIKBLAGAJNEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_FIN_DNEVNIKBLAGAJNE";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_FIN_DNEVNIKBLAGAJNE";
        private S_FIN_DNEVNIKBLAGAJNEDataGrid userControlDataGridS_FIN_DNEVNIKBLAGAJNE;

        public S_FIN_DNEVNIKBLAGAJNEUserDataGrid()
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
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE = new S_FIN_DNEVNIKBLAGAJNEDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE).BeginInit();
            UltraGridBand band = new UltraGridBand("S_FIN_DNEVNIKBLAGAJNE", -1);
            UltraGridColumn column7 = new UltraGridColumn("NAZIVVRSTEDOK");
            UltraGridColumn column2 = new UltraGridColumn("BLGDATUMDOKUMENTA");
            UltraGridColumn column = new UltraGridColumn("BLGBROJDOKUMENTA");
            UltraGridColumn column4 = new UltraGridColumn("IDBLGVRSTEDOK");
            UltraGridColumn column3 = new UltraGridColumn("BLGSVRHA");
            UltraGridColumn column8 = new UltraGridColumn("PRIMITAK");
            UltraGridColumn column5 = new UltraGridColumn("IZDATAK");
            UltraGridColumn column6 = new UltraGridColumn("KONTA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNENAZIVVRSTEDOKDescription;
            column7.Width = 0xe2;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNEBLGDATUMDOKUMENTADescription;
            column2.Width = 0x87;
            column2.MinValue = DateTime.MinValue;
            column2.MaxValue = DateTime.MaxValue;
            column2.Format = "d";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNEBLGBROJDOKUMENTADescription;
            column.Width = 0x7e;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNEIDBLGVRSTEDOKDescription;
            column4.Width = 0x69;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnn";
            column4.PromptChar = ' ';
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNEBLGSVRHADescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNEPRIMITAKDescription;
            column8.Width = 0x66;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNEIZDATAKDescription;
            column5.Width = 0x66;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_FIN_DNEVNIKBLAGAJNEKONTADescription;
            column6.Width = 0x128;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 4;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 5;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 6;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 7;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Location = point;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Name = "userControlDataGridS_FIN_DNEVNIKBLAGAJNE";
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Tag = "S_FIN_DNEVNIKBLAGAJNE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Size = size;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.FillAtStartup = false;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.InitializeRow += new InitializeRowEventHandler(this.S_FIN_DNEVNIKBLAGAJNEUserDataGrid_InitializeRow);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE });
            this.Name = "S_FIN_DNEVNIKBLAGAJNEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_FIN_DNEVNIKBLAGAJNEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE).EndInit();
            this.ResumeLayout(false);
        }

        private void S_FIN_DNEVNIKBLAGAJNEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_FIN_DNEVNIKBLAGAJNEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_FIN_DNEVNIKBLAGAJNEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE;
            }
            set
            {
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE = value;
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
        public virtual int Parameterblag
        {
            get
            {
                return this.DataGrid.Parameterblag;
            }
            set
            {
                this.DataGrid.Parameterblag = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual DateTime Parameterdat1
        {
            get
            {
                return this.DataGrid.Parameterdat1;
            }
            set
            {
                this.DataGrid.Parameterdat1 = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual DateTime Parameterdat2
        {
            get
            {
                return this.DataGrid.Parameterdat2;
            }
            set
            {
                this.DataGrid.Parameterdat2 = value;
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

