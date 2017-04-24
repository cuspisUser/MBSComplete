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

    public class AMSKUPINEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Amortizacijske skupine";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Amortizacijske skupine";
        private AMSKUPINEDataGrid userControlDataGridAMSKUPINE;

        public AMSKUPINEUserDataGrid()
        {
            this.InitializeComponent();
        }

        private void AMSKUPINEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void AMSKUPINEUserDataGrid_Load(object sender, EventArgs e)
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
            this.userControlDataGridAMSKUPINE = new AMSKUPINEDataGrid();
            ((ISupportInitialize) this.userControlDataGridAMSKUPINE).BeginInit();
            UltraGridBand band = new UltraGridBand("AMSKUPINE", -1);
            UltraGridColumn column3 = new UltraGridColumn("IDAMSKUPINE");
            UltraGridColumn column4 = new UltraGridColumn("KRATKASIFRA");
            UltraGridColumn column8 = new UltraGridColumn("OPISAMSKUPINE");
            UltraGridColumn column2 = new UltraGridColumn("AMSKUPINASTOPA");
            UltraGridColumn column7 = new UltraGridColumn("KTONABAVKEIDKONTO");
            UltraGridColumn column5 = new UltraGridColumn("KTOISPRAVKAIDKONTO");
            UltraGridColumn column6 = new UltraGridColumn("KTOIZVORAIDKONTO");
            UltraGridColumn column = new UltraGridColumn("AM");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.AMSKUPINEIDAMSKUPINEDescription;
            column3.Width = 0x33;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.AMSKUPINEKRATKASIFRADescription;
            column4.Width = 0x79;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.AMSKUPINEOPISAMSKUPINEDescription;
            column8.Width = 0x128;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.AMSKUPINEAMSKUPINASTOPADescription;
            column2.Width = 0x9c;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.AMSKUPINEKTONABAVKEIDKONTODescription;
            column7.Width = 0x72;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.AMSKUPINEKTOISPRAVKAIDKONTODescription;
            column5.Width = 0x72;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.AMSKUPINEKTOIZVORAIDKONTODescription;
            column6.Width = 0x72;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.AMSKUPINEAMDescription;
            column.Width = 0x128;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 1;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 2;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 3;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 4;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 5;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 6;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 7;
            this.userControlDataGridAMSKUPINE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridAMSKUPINE.Location = point;
            this.userControlDataGridAMSKUPINE.Name = "userControlDataGridAMSKUPINE";
            this.userControlDataGridAMSKUPINE.Tag = "AMSKUPINE";
            this.userControlDataGridAMSKUPINE.Size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridAMSKUPINE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridAMSKUPINE.Dock = DockStyle.Fill;
            this.userControlDataGridAMSKUPINE.FillAtStartup = false;
            this.userControlDataGridAMSKUPINE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridAMSKUPINE.InitializeRow += new InitializeRowEventHandler(this.AMSKUPINEUserDataGrid_InitializeRow);
            this.userControlDataGridAMSKUPINE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridAMSKUPINE });
            this.Name = "AMSKUPINEUserDataGrid";
            this.Size = new System.Drawing.Size(0x200, 0x144);
            this.Load += new EventHandler(this.AMSKUPINEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridAMSKUPINE).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
            if (DataAdapterFactory.Provider == null)
            {
                DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
            }
            DataSet dataSet = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.DataGrid, "KONTOKTONABAVKEIDKONTO", dataList, "IDKONTO", "KONT");
            UltraGridColumn column3 = this.DataGrid.DisplayLayout.Bands["AMSKUPINE"].Columns["KTONABAVKEIDKONTO"];
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column3.ValueList = this.DataGrid.DisplayLayout.ValueLists["KONTOKTONABAVKEIDKONTO"];
            if (setColumnsWidth)
            {
                column3.Width = 370;
            }
            DataSet set = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(set);
            }
            System.Data.DataView view = new System.Data.DataView(set.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.DataGrid, "KONTOKTOISPRAVKAIDKONTO", view, "IDKONTO", "KONT");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["AMSKUPINE"].Columns["KTOISPRAVKAIDKONTO"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["KONTOKTOISPRAVKAIDKONTO"];
            if (setColumnsWidth)
            {
                column.Width = 370;
            }
            DataSet set2 = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(set2);
            }
            System.Data.DataView view2 = new System.Data.DataView(set2.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.DataGrid, "KONTOKTOIZVORAIDKONTO", view2, "IDKONTO", "KONT");
            UltraGridColumn column2 = this.DataGrid.DisplayLayout.Bands["AMSKUPINE"].Columns["KTOIZVORAIDKONTO"];
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.DataGrid.DisplayLayout.ValueLists["KONTOKTOIZVORAIDKONTO"];
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
        public virtual AMSKUPINEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridAMSKUPINE;
            }
            set
            {
                this.userControlDataGridAMSKUPINE = value;
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
        public virtual string FillByKTOISPRAVKAIDKONTOKTOISPRAVKAIDKONTO
        {
            get
            {
                return this.DataGrid.FillByKTOISPRAVKAIDKONTOKTOISPRAVKAIDKONTO;
            }
            set
            {
                this.DataGrid.FillByKTOISPRAVKAIDKONTOKTOISPRAVKAIDKONTO = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual string FillByKTOIZVORAIDKONTOKTOIZVORAIDKONTO
        {
            get
            {
                return this.DataGrid.FillByKTOIZVORAIDKONTOKTOIZVORAIDKONTO;
            }
            set
            {
                this.DataGrid.FillByKTOIZVORAIDKONTOKTOIZVORAIDKONTO = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual string FillByKTONABAVKEIDKONTOKTONABAVKEIDKONTO
        {
            get
            {
                return this.DataGrid.FillByKTONABAVKEIDKONTOKTONABAVKEIDKONTO;
            }
            set
            {
                this.DataGrid.FillByKTONABAVKEIDKONTOKTONABAVKEIDKONTO = value;
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

