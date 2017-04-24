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

    public class OSRAZMJESTAJUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with OSRAZMJESTAJ";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with OSRAZMJESTAJ";
        private OSRAZMJESTAJDataGrid userControlDataGridOSRAZMJESTAJ;

        public OSRAZMJESTAJUserDataGrid()
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
            this.userControlDataGridOSRAZMJESTAJ = new OSRAZMJESTAJDataGrid();
            ((ISupportInitialize) this.userControlDataGridOSRAZMJESTAJ).BeginInit();
            UltraGridBand band = new UltraGridBand("OSRAZMJESTAJ", -1);
            UltraGridColumn column2 = new UltraGridColumn("IDOSRAZMJESTAJ");
            UltraGridColumn column = new UltraGridColumn("IDLOKACIJE");
            UltraGridColumn column3 = new UltraGridColumn("INVBROJ");
            UltraGridColumn column5 = new UltraGridColumn("KOLICINAULAZA");
            UltraGridColumn column4 = new UltraGridColumn("KOLICINARASHODA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.OSRAZMJESTAJIDOSRAZMJESTAJDescription;
            column2.Width = 0x10c;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            column2.Hidden = true;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.OSRAZMJESTAJIDLOKACIJEDescription;
            column.Width = 0x48;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.OSRAZMJESTAJINVBROJDescription;
            column3.Width = 0x77;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.OSRAZMJESTAJKOLICINAULAZADescription;
            column5.Width = 0x74;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.OSRAZMJESTAJKOLICINARASHODADescription;
            column4.Width = 0x81;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 4;
            this.userControlDataGridOSRAZMJESTAJ.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridOSRAZMJESTAJ.Location = point;
            this.userControlDataGridOSRAZMJESTAJ.Name = "userControlDataGridOSRAZMJESTAJ";
            this.userControlDataGridOSRAZMJESTAJ.Tag = "OSRAZMJESTAJ";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridOSRAZMJESTAJ.Size = size;
            this.userControlDataGridOSRAZMJESTAJ.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridOSRAZMJESTAJ.Dock = DockStyle.Fill;
            this.userControlDataGridOSRAZMJESTAJ.FillAtStartup = false;
            this.userControlDataGridOSRAZMJESTAJ.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridOSRAZMJESTAJ.InitializeRow += new InitializeRowEventHandler(this.OSRAZMJESTAJUserDataGrid_InitializeRow);
            this.userControlDataGridOSRAZMJESTAJ.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridOSRAZMJESTAJ });
            this.Name = "OSRAZMJESTAJUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.OSRAZMJESTAJUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridOSRAZMJESTAJ).EndInit();
            this.ResumeLayout(false);
        }

        private void OSRAZMJESTAJUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void OSRAZMJESTAJUserDataGrid_Load(object sender, EventArgs e)
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
            DataSet dataSet = new LOKACIJEDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetLOKACIJEDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["LOKACIJE"]) {
                Sort = "LOK"
            };
            CreateValueList(this.DataGrid, "LOKACIJEIDLOKACIJE", dataList, "IDLOKACIJE", "LOK");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["OSRAZMJESTAJ"].Columns["IDLOKACIJE"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["LOKACIJEIDLOKACIJE"];
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
        public virtual OSRAZMJESTAJDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridOSRAZMJESTAJ;
            }
            set
            {
                this.userControlDataGridOSRAZMJESTAJ = value;
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
        public virtual int FillByIDLOKACIJEIDLOKACIJE
        {
            get
            {
                return this.DataGrid.FillByIDLOKACIJEIDLOKACIJE;
            }
            set
            {
                this.DataGrid.FillByIDLOKACIJEIDLOKACIJE = value;
            }
        }

        [Category("Deklarit Work With ")]
        public virtual long FillByINVBROJINVBROJ
        {
            get
            {
                return this.DataGrid.FillByINVBROJINVBROJ;
            }
            set
            {
                this.DataGrid.FillByINVBROJINVBROJ = value;
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

