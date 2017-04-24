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

    public class PROIZVODUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with PROIZVOD";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with PROIZVOD";
        private PROIZVODDataGrid userControlDataGridPROIZVOD;

        public PROIZVODUserDataGrid()
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
            this.userControlDataGridPROIZVOD = new PROIZVODDataGrid();
            ((ISupportInitialize) this.userControlDataGridPROIZVOD).BeginInit();
            UltraGridBand band = new UltraGridBand("PROIZVOD", -1);
            UltraGridColumn column5 = new UltraGridColumn("IDPROIZVOD");
            UltraGridColumn column7 = new UltraGridColumn("NAZIVPROIZVOD");
            UltraGridColumn column2 = new UltraGridColumn("FINPOREZIDPOREZ");
            UltraGridColumn column3 = new UltraGridColumn("FINPOREZSTOPA");
            UltraGridColumn column = new UltraGridColumn("CIJENA");
            UltraGridColumn column4 = new UltraGridColumn("IDJEDINICAMJERE");
            UltraGridColumn column6 = new UltraGridColumn("NAZIVJEDINICAMJERE");
            UltraGridColumn column8 = new UltraGridColumn("Grupa");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.PROIZVODIDPROIZVODDescription;
            column5.Width = 0x63;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnn";
            column5.PromptChar = ' ';
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.PROIZVODNAZIVPROIZVODDescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance7;

            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.GrupaDescripton;
            column8.Width = 0x128;
            column8.Format = "";
            column8.CellAppearance = appearance7;

            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.PROIZVODFINPOREZIDPOREZDescription;
            column2.Width = 0x77;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.PROIZVODFINPOREZSTOPADescription;
            column3.Width = 0x6d;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.PROIZVODCIJENADescription;
            column.Width = 0x52;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn.nnnn";
            column.PromptChar = ' ';
            column.Format = "F4";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.PROIZVODIDJEDINICAMJEREDescription;
            column4.Width = 0x7e;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.PROIZVODNAZIVJEDINICAMJEREDescription;
            column6.Width = 0x128;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 0;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 4;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 5;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 6;
            band.Columns.Add(column8);
            column6.Header.VisiblePosition = 7;
            this.userControlDataGridPROIZVOD.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridPROIZVOD.Location = point;
            this.userControlDataGridPROIZVOD.Name = "userControlDataGridPROIZVOD";
            this.userControlDataGridPROIZVOD.Tag = "PROIZVOD";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridPROIZVOD.Size = size;
            this.userControlDataGridPROIZVOD.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridPROIZVOD.Dock = DockStyle.Fill;
            this.userControlDataGridPROIZVOD.FillAtStartup = false;
            this.userControlDataGridPROIZVOD.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridPROIZVOD.InitializeRow += new InitializeRowEventHandler(this.PROIZVODUserDataGrid_InitializeRow);
            this.userControlDataGridPROIZVOD.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridPROIZVOD });
            this.Name = "PROIZVODUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.PROIZVODUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridPROIZVOD).EndInit();
            this.ResumeLayout(false);
        }

        private void PROIZVODUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void PROIZVODUserDataGrid_Load(object sender, EventArgs e)
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
            DataSet dataSet = new FINPOREZDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetFINPOREZDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["FINPOREZ"]) {
                Sort = "FINPOREZNAZIVPOREZ"
            };
            CreateValueList(this.DataGrid, "FINPOREZFINPOREZIDPOREZ", dataList, "FINPOREZIDPOREZ", "FINPOREZNAZIVPOREZ");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["PROIZVOD"].Columns["FINPOREZIDPOREZ"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["FINPOREZFINPOREZIDPOREZ"];
            if (setColumnsWidth)
            {
                column.Width = 280;
            }
            DataSet set2 = new JEDINICAMJEREDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetJEDINICAMJEREDataAdapter().Fill(set2);
            }
            System.Data.DataView view2 = new System.Data.DataView(set2.Tables["JEDINICAMJERE"]) {
                Sort = "NAZIVJEDINICAMJERE"
            };
            CreateValueList(this.DataGrid, "JEDINICAMJEREIDJEDINICAMJERE", view2, "IDJEDINICAMJERE", "NAZIVJEDINICAMJERE");
            UltraGridColumn column2 = this.DataGrid.DisplayLayout.Bands["PROIZVOD"].Columns["IDJEDINICAMJERE"];
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.DataGrid.DisplayLayout.ValueLists["JEDINICAMJEREIDJEDINICAMJERE"];
            if (setColumnsWidth)
            {
                column2.Width = 370;
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
        public virtual PROIZVODDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridPROIZVOD;
            }
            set
            {
                this.userControlDataGridPROIZVOD = value;
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

        [Description("True= Fill at Startup. False= Not Fill"), Category("Deklarit Work With "), DefaultValue(true)]
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
        public virtual int FillByFINPOREZIDPOREZFINPOREZIDPOREZ
        {
            get
            {
                return this.DataGrid.FillByFINPOREZIDPOREZFINPOREZIDPOREZ;
            }
            set
            {
                this.DataGrid.FillByFINPOREZIDPOREZFINPOREZIDPOREZ = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual int FillByIDJEDINICAMJEREIDJEDINICAMJERE
        {
            get
            {
                return this.DataGrid.FillByIDJEDINICAMJEREIDJEDINICAMJERE;
            }
            set
            {
                this.DataGrid.FillByIDJEDINICAMJEREIDJEDINICAMJERE = value;
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

