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

    public class S_OS_BROJ_I_DATUMUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_OS_BROJ_I_DATUM";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_OS_BROJ_I_DATUM";
        private S_OS_BROJ_I_DATUMDataGrid userControlDataGridS_OS_BROJ_I_DATUM;

        public S_OS_BROJ_I_DATUMUserDataGrid()
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
            this.userControlDataGridS_OS_BROJ_I_DATUM = new S_OS_BROJ_I_DATUMDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_OS_BROJ_I_DATUM).BeginInit();
            UltraGridBand band = new UltraGridBand("S_OS_BROJ_I_DATUM", -1);
            UltraGridColumn column = new UltraGridColumn("BROJDOK");
            UltraGridColumn column2 = new UltraGridColumn("ZADNJIDATUM");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_OS_BROJ_I_DATUMBROJDOKDescription;
            column.Width = 0x48;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_OS_BROJ_I_DATUMZADNJIDATUMDescription;
            column2.Width = 100;
            column2.MinValue = DateTime.MinValue;
            column2.MaxValue = DateTime.MaxValue;
            column2.Format = "d";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            this.userControlDataGridS_OS_BROJ_I_DATUM.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OS_BROJ_I_DATUM.Location = point;
            this.userControlDataGridS_OS_BROJ_I_DATUM.Name = "userControlDataGridS_OS_BROJ_I_DATUM";
            this.userControlDataGridS_OS_BROJ_I_DATUM.Tag = "S_OS_BROJ_I_DATUM";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_OS_BROJ_I_DATUM.Size = size;
            this.userControlDataGridS_OS_BROJ_I_DATUM.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_OS_BROJ_I_DATUM.Dock = DockStyle.Fill;
            this.userControlDataGridS_OS_BROJ_I_DATUM.FillAtStartup = false;
            this.userControlDataGridS_OS_BROJ_I_DATUM.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_OS_BROJ_I_DATUM.InitializeRow += new InitializeRowEventHandler(this.S_OS_BROJ_I_DATUMUserDataGrid_InitializeRow);
            this.userControlDataGridS_OS_BROJ_I_DATUM.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_OS_BROJ_I_DATUM });
            this.Name = "S_OS_BROJ_I_DATUMUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_OS_BROJ_I_DATUMUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_OS_BROJ_I_DATUM).EndInit();
            this.ResumeLayout(false);
        }

        private void S_OS_BROJ_I_DATUMUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_OS_BROJ_I_DATUMUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_OS_BROJ_I_DATUMDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_OS_BROJ_I_DATUM;
            }
            set
            {
                this.userControlDataGridS_OS_BROJ_I_DATUM = value;
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

