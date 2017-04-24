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

    public class RAD1VEZASPOLUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Veza RAD1 i spol";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Veza RAD1 i spol";
        private RAD1VEZASPOLDataGrid userControlDataGridRAD1VEZASPOL;

        public RAD1VEZASPOLUserDataGrid()
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
            this.userControlDataGridRAD1VEZASPOL = new RAD1VEZASPOLDataGrid();
            ((ISupportInitialize) this.userControlDataGridRAD1VEZASPOL).BeginInit();
            UltraGridBand band = new UltraGridBand("RAD1VEZASPOL", -1);
            UltraGridColumn column2 = new UltraGridColumn("RAD1SPOLID");
            UltraGridColumn column = new UltraGridColumn("IDSPOL");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.RAD1VEZASPOLRAD1SPOLIDDescription;
            column2.Width = 0x92;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.RAD1VEZASPOLIDSPOLDescription;
            column.Width = 0xcf;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 1;
            this.userControlDataGridRAD1VEZASPOL.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridRAD1VEZASPOL.Location = point;
            this.userControlDataGridRAD1VEZASPOL.Name = "userControlDataGridRAD1VEZASPOL";
            this.userControlDataGridRAD1VEZASPOL.Tag = "RAD1VEZASPOL";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridRAD1VEZASPOL.Size = size;
            this.userControlDataGridRAD1VEZASPOL.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridRAD1VEZASPOL.Dock = DockStyle.Fill;
            this.userControlDataGridRAD1VEZASPOL.FillAtStartup = false;
            this.userControlDataGridRAD1VEZASPOL.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridRAD1VEZASPOL.InitializeRow += new InitializeRowEventHandler(this.RAD1VEZASPOLUserDataGrid_InitializeRow);
            this.userControlDataGridRAD1VEZASPOL.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridRAD1VEZASPOL });
            this.Name = "RAD1VEZASPOLUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.RAD1VEZASPOLUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridRAD1VEZASPOL).EndInit();
            this.ResumeLayout(false);
        }

        private void RAD1VEZASPOLUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void RAD1VEZASPOLUserDataGrid_Load(object sender, EventArgs e)
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
            DataSet dataSet = new RAD1SPOLDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetRAD1SPOLDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["RAD1SPOL"]) {
                Sort = "RAD1SPOLNAZIV"
            };
            CreateValueList(this.DataGrid, "RAD1SPOLRAD1SPOLID", dataList, "RAD1SPOLID", "RAD1SPOLNAZIV");
            UltraGridColumn column2 = this.DataGrid.DisplayLayout.Bands["RAD1VEZASPOL"].Columns["RAD1SPOLID"];
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.DataGrid.DisplayLayout.ValueLists["RAD1SPOLRAD1SPOLID"];
            if (setColumnsWidth)
            {
                column2.Width = 190;
            }
            DataSet set = new SPOLDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSPOLDataAdapter().Fill(set);
            }
            System.Data.DataView view = new System.Data.DataView(set.Tables["SPOL"]) {
                Sort = "NAZIVSPOL"
            };
            CreateValueList(this.DataGrid, "SPOLIDSPOL", view, "IDSPOL", "NAZIVSPOL");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["RAD1VEZASPOL"].Columns["IDSPOL"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["SPOLIDSPOL"];
            if (setColumnsWidth)
            {
                column.Width = 190;
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
        public virtual RAD1VEZASPOLDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridRAD1VEZASPOL;
            }
            set
            {
                this.userControlDataGridRAD1VEZASPOL = value;
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

        [Category("Deklarit Work With ")]
        public virtual int FillByIDSPOLIDSPOL
        {
            get
            {
                return this.DataGrid.FillByIDSPOLIDSPOL;
            }
            set
            {
                this.DataGrid.FillByIDSPOLIDSPOL = value;
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
        public virtual int FillByRAD1SPOLIDRAD1SPOLID
        {
            get
            {
                return this.DataGrid.FillByRAD1SPOLIDRAD1SPOLID;
            }
            set
            {
                this.DataGrid.FillByRAD1SPOLIDRAD1SPOLID = value;
            }
        }

        [Category("Deklarit Work With "), DefaultValue("Fill"), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter))]
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

