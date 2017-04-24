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

    public class VIRMANIUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with VIRMANI";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with VIRMANI";
        private VIRMANIDataGrid userControlDataGridVIRMANI;

        public VIRMANIUserDataGrid()
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
            this.userControlDataGridVIRMANI = new VIRMANIDataGrid();
            ((ISupportInitialize) this.userControlDataGridVIRMANI).BeginInit();
            UltraGridBand band = new UltraGridBand("VIRMANI", -1);
            UltraGridColumn column5 = new UltraGridColumn("IDVIRMAN");
            UltraGridColumn column21 = new UltraGridColumn("SIFRAOBRACUNAVIRMAN");
            UltraGridColumn column13 = new UltraGridColumn("PLA1");
            UltraGridColumn column14 = new UltraGridColumn("PLA2");
            UltraGridColumn column15 = new UltraGridColumn("PLA3");
            UltraGridColumn column = new UltraGridColumn("BROJRACUNAPLA");
            UltraGridColumn column9 = new UltraGridColumn("MODELZADUZENJA");
            UltraGridColumn column17 = new UltraGridColumn("POZIVZADUZENJA");
            UltraGridColumn column18 = new UltraGridColumn("PRI1");
            UltraGridColumn column19 = new UltraGridColumn("PRI2");
            UltraGridColumn column20 = new UltraGridColumn("PRI3");
            UltraGridColumn column2 = new UltraGridColumn("BROJRACUNAPRI");
            UltraGridColumn column8 = new UltraGridColumn("MODELODOBRENJA");
            UltraGridColumn column16 = new UltraGridColumn("POZIVODOBRENJA");
            UltraGridColumn column22 = new UltraGridColumn("SIFRAOPISAPLACANJAVIRMAN");
            UltraGridColumn column11 = new UltraGridColumn("OPISPLACANJAVIRMAN");
            UltraGridColumn column4 = new UltraGridColumn("DATUMVALUTE");
            UltraGridColumn column3 = new UltraGridColumn("DATUMPODNOSENJA");
            UltraGridColumn column7 = new UltraGridColumn("IZVORDOKUMENTA");
            UltraGridColumn column12 = new UltraGridColumn("OZNACEN");
            UltraGridColumn column6 = new UltraGridColumn("IZNOS");
            UltraGridColumn column10 = new UltraGridColumn("NAMJENA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.VIRMANIIDVIRMANDescription;
            column5.Width = 0x48;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnn";
            column5.PromptChar = ' ';
            column5.Format = "";
            column5.CellAppearance = appearance5;
            column5.Hidden = true;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.VIRMANISIFRAOBRACUNAVIRMANDescription;
            column21.Width = 0x95;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.VIRMANIPLA1Description;
            column13.Width = 0x9c;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.VIRMANIPLA2Description;
            column14.Width = 0x9c;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.VIRMANIPLA3Description;
            column15.Width = 0x9c;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.VIRMANIBROJRACUNAPLADescription;
            column.Width = 0x8e;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.VIRMANIMODELZADUZENJADescription;
            column9.Width = 0x72;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.VIRMANIPOZIVZADUZENJADescription;
            column17.Width = 170;
            column17.Format = "";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.VIRMANIPRI1Description;
            column18.Width = 0x9c;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.VIRMANIPRI2Description;
            column19.Width = 0x9c;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.VIRMANIPRI3Description;
            column20.Width = 0x9c;
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.VIRMANIBROJRACUNAPRIDescription;
            column2.Width = 0x8e;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.VIRMANIMODELODOBRENJADescription;
            column8.Width = 0x72;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.VIRMANIPOZIVODOBRENJADescription;
            column16.Width = 170;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.VIRMANISIFRAOPISAPLACANJAVIRMANDescription;
            column22.Width = 0xb8;
            column22.Format = "";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.VIRMANIOPISPLACANJAVIRMANDescription;
            column11.Width = 0x10c;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.VIRMANIDATUMVALUTEDescription;
            column4.Width = 100;
            column4.MinValue = DateTime.MinValue;
            column4.MaxValue = DateTime.MaxValue;
            column4.Format = "d";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.VIRMANIDATUMPODNOSENJADescription;
            column3.Width = 0x79;
            column3.MinValue = DateTime.MinValue;
            column3.MaxValue = DateTime.MaxValue;
            column3.Format = "d";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.VIRMANIIZVORDOKUMENTADescription;
            column7.Width = 0x72;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.VIRMANIOZNACENDescription;
            column12.Width = 0x41;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.VIRMANIIZNOSDescription;
            column6.Width = 0x66;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.VIRMANINAMJENADescription;
            column10.Width = 0x9c;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 0;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 1;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 2;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 4;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 5;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 6;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 7;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 8;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 9;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 10;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 11;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 12;
            band.Columns.Add(column22);
            column22.Header.VisiblePosition = 13;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 14;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 15;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0x10;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 0x11;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 0x12;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 0x13;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 20;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 0x15;
            this.userControlDataGridVIRMANI.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridVIRMANI.Location = point;
            this.userControlDataGridVIRMANI.Name = "userControlDataGridVIRMANI";
            this.userControlDataGridVIRMANI.Tag = "VIRMANI";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridVIRMANI.Size = size;
            this.userControlDataGridVIRMANI.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridVIRMANI.Dock = DockStyle.Fill;
            this.userControlDataGridVIRMANI.FillAtStartup = false;
            this.userControlDataGridVIRMANI.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridVIRMANI.InitializeRow += new InitializeRowEventHandler(this.VIRMANIUserDataGrid_InitializeRow);
            this.userControlDataGridVIRMANI.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridVIRMANI });
            this.Name = "VIRMANIUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.VIRMANIUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridVIRMANI).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
        }

        private void VIRMANIUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void VIRMANIUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual VIRMANIDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridVIRMANI;
            }
            set
            {
                this.userControlDataGridVIRMANI = value;
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

        [Category("Deklarit Work With ")]
        public virtual string FillBySIFRAOBRACUNAVIRMANSIFRAOBRACUNAVIRMAN
        {
            get
            {
                return this.DataGrid.FillBySIFRAOBRACUNAVIRMANSIFRAOBRACUNAVIRMAN;
            }
            set
            {
                this.DataGrid.FillBySIFRAOBRACUNAVIRMANSIFRAOBRACUNAVIRMAN = value;
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

