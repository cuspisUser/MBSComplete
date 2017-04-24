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

    public class RAD1MELEMENTIVEZAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Veza RAD1M elementi i elementi";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Veza RAD1M elementi i elementi";
        private RAD1MELEMENTIVEZADataGrid userControlDataGridRAD1MELEMENTIVEZA;

        public RAD1MELEMENTIVEZAUserDataGrid()
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
            this.userControlDataGridRAD1MELEMENTIVEZA = new RAD1MELEMENTIVEZADataGrid();
            ((ISupportInitialize) this.userControlDataGridRAD1MELEMENTIVEZA).BeginInit();
            UltraGridBand band = new UltraGridBand("RAD1MELEMENTIVEZA", -1);
            UltraGridColumn column2 = new UltraGridColumn("RAD1ELEMENTIID");
            UltraGridColumn column = new UltraGridColumn("IDELEMENT");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.RAD1MELEMENTIVEZARAD1ELEMENTIIDDescription;
            column2.Width = 0xba;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.RAD1MELEMENTIVEZAIDELEMENTDescription;
            column.Width = 0xba;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 1;
            this.userControlDataGridRAD1MELEMENTIVEZA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridRAD1MELEMENTIVEZA.Location = point;
            this.userControlDataGridRAD1MELEMENTIVEZA.Name = "userControlDataGridRAD1MELEMENTIVEZA";
            this.userControlDataGridRAD1MELEMENTIVEZA.Tag = "RAD1MELEMENTIVEZA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridRAD1MELEMENTIVEZA.Size = size;
            this.userControlDataGridRAD1MELEMENTIVEZA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridRAD1MELEMENTIVEZA.Dock = DockStyle.Fill;
            this.userControlDataGridRAD1MELEMENTIVEZA.FillAtStartup = false;
            this.userControlDataGridRAD1MELEMENTIVEZA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridRAD1MELEMENTIVEZA.InitializeRow += new InitializeRowEventHandler(this.RAD1MELEMENTIVEZAUserDataGrid_InitializeRow);
            this.userControlDataGridRAD1MELEMENTIVEZA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridRAD1MELEMENTIVEZA });
            this.Name = "RAD1MELEMENTIVEZAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.RAD1MELEMENTIVEZAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridRAD1MELEMENTIVEZA).EndInit();
            this.ResumeLayout(false);
        }

        private void RAD1MELEMENTIVEZAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void RAD1MELEMENTIVEZAUserDataGrid_Load(object sender, EventArgs e)
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
            DataSet dataSet = new RAD1MELEMENTIDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetRAD1MELEMENTIDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["RAD1MELEMENTI"]) {
                Sort = "RAD1ELEMENTINAZIV"
            };
            CreateValueList(this.DataGrid, "RAD1MELEMENTIRAD1ELEMENTIID", dataList, "RAD1ELEMENTIID", "RAD1ELEMENTINAZIV");
            UltraGridColumn column2 = this.DataGrid.DisplayLayout.Bands["RAD1MELEMENTIVEZA"].Columns["RAD1ELEMENTIID"];
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.DataGrid.DisplayLayout.ValueLists["RAD1MELEMENTIRAD1ELEMENTIID"];
            if (setColumnsWidth)
            {
                column2.Width = 370;
            }
            DataSet set = new ELEMENTDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetELEMENTDataAdapter().Fill(set);
            }
            System.Data.DataView view = new System.Data.DataView(set.Tables["ELEMENT"]) {
                Sort = "EL"
            };
            CreateValueList(this.DataGrid, "ELEMENTIDELEMENT", view, "IDELEMENT", "EL");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["RAD1MELEMENTIVEZA"].Columns["IDELEMENT"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["ELEMENTIDELEMENT"];
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
        public virtual RAD1MELEMENTIVEZADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridRAD1MELEMENTIVEZA;
            }
            set
            {
                this.userControlDataGridRAD1MELEMENTIVEZA = value;
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
        public virtual int FillByIDELEMENTIDELEMENT
        {
            get
            {
                return this.DataGrid.FillByIDELEMENTIDELEMENT;
            }
            set
            {
                this.DataGrid.FillByIDELEMENTIDELEMENT = value;
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
        public virtual int FillByRAD1ELEMENTIIDRAD1ELEMENTIID
        {
            get
            {
                return this.DataGrid.FillByRAD1ELEMENTIIDRAD1ELEMENTIID;
            }
            set
            {
                this.DataGrid.FillByRAD1ELEMENTIIDRAD1ELEMENTIID = value;
            }
        }

        [TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), DefaultValue("Fill"), Category("Deklarit Work With ")]
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

