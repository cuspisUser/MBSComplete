namespace NetAdvantage.SmartParts
{
    using Deklarit.Controls;
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

    public class UCENIKUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with UCENIK";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with UCENIK";
        private UCENIKDataGrid userControlDataGridUCENIK;

        public UCENIKUserDataGrid()
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
            this.userControlDataGridUCENIK = new UCENIKDataGrid();
            ((ISupportInitialize) this.userControlDataGridUCENIK).BeginInit();
            UltraGridBand band = new UltraGridBand("UCENIK", -1);
            UltraGridColumn column2 = new UltraGridColumn("IDUCENIK");
            UltraGridColumn column11 = new UltraGridColumn("PREZIMEUCENIK");
            UltraGridColumn column4 = new UltraGridColumn("IMEUCENIK");
            UltraGridColumn column9 = new UltraGridColumn("OIBUCENIK");
            UltraGridColumn column12 = new UltraGridColumn("RAZRED");
            UltraGridColumn column8 = new UltraGridColumn("ODJELJENJE");
            UltraGridColumn column13 = new UltraGridColumn("SPOLUCENIKA");
            UltraGridColumn column14 = new UltraGridColumn("ULICAIBROJ");
            UltraGridColumn column6 = new UltraGridColumn("NASELJE");
            UltraGridColumn column5 = new UltraGridColumn("JMBGUCENIKA");
            UltraGridColumn column = new UltraGridColumn("DATUMRODJENJAUCENIKA");
            UltraGridColumn column3 = new UltraGridColumn("IMERODITELJA");
            UltraGridColumn column10 = new UltraGridColumn("POSTANSKIBROJ");
            UltraGridColumn column7 = new UltraGridColumn("NAZIVPOSTE");
            UltraGridColumn column20 = new UltraGridColumn("ID_Opcine");
            UltraGridColumn column21 = new UltraGridColumn("PrezimeRoditelj");
            UltraGridColumn column22 = new UltraGridColumn("OIBRoditelj");
            UltraGridColumn column23 = new UltraGridColumn("IBANRoditelj");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.UCENIKIDUCENIKDescription;
            column2.Width = 0x41;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.UCENIKPREZIMEUCENIKDescription;
            column11.Width = 0x128;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.UCENIKIMEUCENIKDescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.UCENIKOIBUCENIKDescription;
            column9.Width = 0x5d;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.UCENIKRAZREDDescription;
            column12.Width = 0x3a;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnn";
            column12.PromptChar = ' ';
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.UCENIKODJELJENJEDescription;
            column8.Width = 0x56;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.UCENIKSPOLUCENIKADescription;
            column13.Width = 0x5d;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.UCENIKULICAIBROJDescription;
            column14.Width = 0x128;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.UCENIKNASELJEDescription;
            column6.Width = 0x128;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.UCENIKJMBGUCENIKADescription;
            column5.Width = 0x6b;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.UCENIKDATUMRODJENJAUCENIKADescription;
            column.Width = 0x9c;
            column.MinValue = DateTime.MinValue;
            column.MaxValue = DateTime.MaxValue;
            column.Format = "d";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.UCENIKIMERODITELJADescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.UCENIKPOSTANSKIBROJDescription;
            column10.Width = 0x6b;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.UCENIKNAZIVPOSTEDescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;

            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.UCENIKID_OpcineDescription;
            column20.Width = 0x128;
            column20.Format = "";
            column20.CellAppearance = appearance7;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 14;

            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.UCENIKID_OpcineDescription;
            column21.Width = 0x128;
            column21.Format = "";
            column21.CellAppearance = appearance7;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 15;


            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.UCENIKID_OpcineDescription;
            column22.Width = 0x128;
            column22.Format = "";
            column22.CellAppearance = appearance7;
            band.Columns.Add(column22);
            column22.Header.VisiblePosition = 16;

            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.UCENIKID_OpcineDescription;
            column23.Width = 0x128;
            column23.Format = "";
            column23.CellAppearance = appearance7;
            band.Columns.Add(column23);
            column21.Header.VisiblePosition = 13;

            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 1;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 2;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 3;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 4;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 5;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 6;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 7;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 8;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 9;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 10;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 11;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 12;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 13;
            this.userControlDataGridUCENIK.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridUCENIK.Location = point;
            this.userControlDataGridUCENIK.Name = "userControlDataGridUCENIK";
            this.userControlDataGridUCENIK.Tag = "UCENIK";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridUCENIK.Size = size;
            this.userControlDataGridUCENIK.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridUCENIK.Dock = DockStyle.Fill;
            this.userControlDataGridUCENIK.FillAtStartup = false;
            this.userControlDataGridUCENIK.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridUCENIK.InitializeRow += new InitializeRowEventHandler(this.UCENIKUserDataGrid_InitializeRow);
            this.userControlDataGridUCENIK.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridUCENIK });
            this.Name = "UCENIKUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.UCENIKUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridUCENIK).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
        }

        private void UCENIKUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void UCENIKUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual UCENIKDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridUCENIK;
            }
            set
            {
                this.userControlDataGridUCENIK = value;
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

        [Category("Deklarit Work With ")]
        public virtual string FillByPOSTANSKIBROJPOSTANSKIBROJ
        {
            get
            {
                return this.DataGrid.FillByPOSTANSKIBROJPOSTANSKIBROJ;
            }
            set
            {
                this.DataGrid.FillByPOSTANSKIBROJPOSTANSKIBROJ = value;
            }
        }

        [DefaultValue("Fill"), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), Category("Deklarit Work With ")]
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

