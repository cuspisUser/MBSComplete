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

    public class RAD1SPREMEVEZAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Veza RAD1 i strucne spreme";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Veza RAD1 i strucne spreme";
        private RAD1SPREMEVEZADataGrid userControlDataGridRAD1SPREMEVEZA;

        public RAD1SPREMEVEZAUserDataGrid()
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
            this.userControlDataGridRAD1SPREMEVEZA = new RAD1SPREMEVEZADataGrid();
            ((ISupportInitialize) this.userControlDataGridRAD1SPREMEVEZA).BeginInit();
            UltraGridBand band = new UltraGridBand("RAD1SPREMEVEZA", -1);
            UltraGridColumn column2 = new UltraGridColumn("RAD1IDSPREME");
            UltraGridColumn column = new UltraGridColumn("IDSTRUCNASPREMA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.RAD1SPREMEVEZARAD1IDSPREMEDescription;
            column2.Width = 0x92;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.RAD1SPREMEVEZAIDSTRUCNASPREMADescription;
            column.Width = 240;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 1;
            this.userControlDataGridRAD1SPREMEVEZA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridRAD1SPREMEVEZA.Location = point;
            this.userControlDataGridRAD1SPREMEVEZA.Name = "userControlDataGridRAD1SPREMEVEZA";
            this.userControlDataGridRAD1SPREMEVEZA.Tag = "RAD1SPREMEVEZA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridRAD1SPREMEVEZA.Size = size;
            this.userControlDataGridRAD1SPREMEVEZA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridRAD1SPREMEVEZA.Dock = DockStyle.Fill;
            this.userControlDataGridRAD1SPREMEVEZA.FillAtStartup = false;
            this.userControlDataGridRAD1SPREMEVEZA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridRAD1SPREMEVEZA.InitializeRow += new InitializeRowEventHandler(this.RAD1SPREMEVEZAUserDataGrid_InitializeRow);
            this.userControlDataGridRAD1SPREMEVEZA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridRAD1SPREMEVEZA });
            this.Name = "RAD1SPREMEVEZAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.RAD1SPREMEVEZAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridRAD1SPREMEVEZA).EndInit();
            this.ResumeLayout(false);
        }

        private void RAD1SPREMEVEZAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void RAD1SPREMEVEZAUserDataGrid_Load(object sender, EventArgs e)
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
            DataSet dataSet = new RAD1SPREMEDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetRAD1SPREMEDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["RAD1SPREME"]) {
                Sort = "RAD1NAZIVSPREME"
            };
            CreateValueList(this.DataGrid, "RAD1SPREMERAD1IDSPREME", dataList, "RAD1IDSPREME", "RAD1NAZIVSPREME");
            UltraGridColumn column2 = this.DataGrid.DisplayLayout.Bands["RAD1SPREMEVEZA"].Columns["RAD1IDSPREME"];
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.DataGrid.DisplayLayout.ValueLists["RAD1SPREMERAD1IDSPREME"];
            if (setColumnsWidth)
            {
                column2.Width = 370;
            }
            DataSet set = new STRUCNASPREMADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRUCNASPREMADataAdapter().Fill(set);
            }
            System.Data.DataView view = new System.Data.DataView(set.Tables["STRUCNASPREMA"]) {
                Sort = "NAZIVSTRUCNASPREMA"
            };
            CreateValueList(this.DataGrid, "STRUCNASPREMAIDSTRUCNASPREMA", view, "IDSTRUCNASPREMA", "NAZIVSTRUCNASPREMA");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["RAD1SPREMEVEZA"].Columns["IDSTRUCNASPREMA"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["STRUCNASPREMAIDSTRUCNASPREMA"];
            if (setColumnsWidth)
            {
                column.Width = 370;
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
        public virtual RAD1SPREMEVEZADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridRAD1SPREMEVEZA;
            }
            set
            {
                this.userControlDataGridRAD1SPREMEVEZA = value;
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

        [Category("Deklarit Work With "), DefaultValue(true), Description("True= Fill at Startup. False= Not Fill")]
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
        public virtual int FillByIDSTRUCNASPREMAIDSTRUCNASPREMA
        {
            get
            {
                return this.DataGrid.FillByIDSTRUCNASPREMAIDSTRUCNASPREMA;
            }
            set
            {
                this.DataGrid.FillByIDSTRUCNASPREMAIDSTRUCNASPREMA = value;
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
        public virtual int FillByRAD1IDSPREMERAD1IDSPREME
        {
            get
            {
                return this.DataGrid.FillByRAD1IDSPREMERAD1IDSPREME;
            }
            set
            {
                this.DataGrid.FillByRAD1IDSPREMERAD1IDSPREME = value;
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

