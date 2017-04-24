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

    public class V_DD_PREGLED_OBRACUNAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with V_DD_PREGLED_OBRACUNA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with V_DD_PREGLED_OBRACUNA";
        private V_DD_PREGLED_OBRACUNADataGrid userControlDataGridV_DD_PREGLED_OBRACUNA;

        public V_DD_PREGLED_OBRACUNAUserDataGrid()
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
            this.userControlDataGridV_DD_PREGLED_OBRACUNA = new V_DD_PREGLED_OBRACUNADataGrid();
            ((ISupportInitialize) this.userControlDataGridV_DD_PREGLED_OBRACUNA).BeginInit();
            UltraGridBand band = new UltraGridBand("V_DD_PREGLED_OBRACUNA", -1);
            UltraGridColumn column2 = new UltraGridColumn("DDOBRACUNIDOBRACUN");
            UltraGridColumn column3 = new UltraGridColumn("DDOPISOBRACUN");
            UltraGridColumn column = new UltraGridColumn("DDDATUMOBRACUNA");
            UltraGridColumn column5 = new UltraGridColumn("DDZAKLJUCAN");
            UltraGridColumn column4 = new UltraGridColumn("DDRSM");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.V_DD_PREGLED_OBRACUNADDOBRACUNIDOBRACUNDescription;
            column2.Width = 0x72;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.V_DD_PREGLED_OBRACUNADDOPISOBRACUNDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.V_DD_PREGLED_OBRACUNADDDATUMOBRACUNADescription;
            column.Width = 0x72;
            column.MinValue = DateTime.MinValue;
            column.MaxValue = DateTime.MaxValue;
            column.Format = "d";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.V_DD_PREGLED_OBRACUNADDZAKLJUCANDescription;
            column5.Width = 0x5d;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.V_DD_PREGLED_OBRACUNADDRSMDescription;
            column4.Width = 0x33;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 3;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 4;
            this.userControlDataGridV_DD_PREGLED_OBRACUNA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridV_DD_PREGLED_OBRACUNA.Location = point;
            this.userControlDataGridV_DD_PREGLED_OBRACUNA.Name = "userControlDataGridV_DD_PREGLED_OBRACUNA";
            this.userControlDataGridV_DD_PREGLED_OBRACUNA.Tag = "V_DD_PREGLED_OBRACUNA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridV_DD_PREGLED_OBRACUNA.Size = size;
            this.userControlDataGridV_DD_PREGLED_OBRACUNA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridV_DD_PREGLED_OBRACUNA.Dock = DockStyle.Fill;
            this.userControlDataGridV_DD_PREGLED_OBRACUNA.FillAtStartup = false;
            this.userControlDataGridV_DD_PREGLED_OBRACUNA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridV_DD_PREGLED_OBRACUNA.InitializeRow += new InitializeRowEventHandler(this.V_DD_PREGLED_OBRACUNAUserDataGrid_InitializeRow);
            this.userControlDataGridV_DD_PREGLED_OBRACUNA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridV_DD_PREGLED_OBRACUNA });
            this.Name = "V_DD_PREGLED_OBRACUNAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.V_DD_PREGLED_OBRACUNAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridV_DD_PREGLED_OBRACUNA).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
        }

        private void V_DD_PREGLED_OBRACUNAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void V_DD_PREGLED_OBRACUNAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual V_DD_PREGLED_OBRACUNADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridV_DD_PREGLED_OBRACUNA;
            }
            set
            {
                this.userControlDataGridV_DD_PREGLED_OBRACUNA = value;
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

