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

    public class ZAPOSLENIUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with ZAPOSLENI";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with ZAPOSLENI";
        private ZAPOSLENIDataGrid userControlDataGridZAPOSLENI;

        public ZAPOSLENIUserDataGrid()
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
            this.userControlDataGridZAPOSLENI = new ZAPOSLENIDataGrid();
            ((ISupportInitialize) this.userControlDataGridZAPOSLENI).BeginInit();
            UltraGridBand band = new UltraGridBand("ZAPOSLENI", -1);
            UltraGridColumn column2 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column = new UltraGridColumn("DATUMZAPOSLENJA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.ZAPOSLENIIDRADNIKDescription;
            column2.Width = 0x69;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.ZAPOSLENIDATUMZAPOSLENJADescription;
            column.Width = 0xe2;
            column.MinValue = DateTime.MinValue;
            column.MaxValue = DateTime.MaxValue;
            column.Format = "d";
            column.CellAppearance = appearance;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 1;
            this.userControlDataGridZAPOSLENI.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridZAPOSLENI.Location = point;
            this.userControlDataGridZAPOSLENI.Name = "userControlDataGridZAPOSLENI";
            this.userControlDataGridZAPOSLENI.Tag = "ZAPOSLENI";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridZAPOSLENI.Size = size;
            this.userControlDataGridZAPOSLENI.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridZAPOSLENI.Dock = DockStyle.Fill;
            this.userControlDataGridZAPOSLENI.FillAtStartup = false;
            this.userControlDataGridZAPOSLENI.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridZAPOSLENI.InitializeRow += new InitializeRowEventHandler(this.ZAPOSLENIUserDataGrid_InitializeRow);
            this.userControlDataGridZAPOSLENI.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridZAPOSLENI });
            this.Name = "ZAPOSLENIUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.ZAPOSLENIUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridZAPOSLENI).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
            if (DataAdapterFactory.Provider == null)
            {
                DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
            }
            PregledRadnikaComboBox box = new PregledRadnikaComboBox();
            box.Fill();
            System.Data.DataView defaultView = box.DataSet.Tables["RADNIK"].DefaultView;
            defaultView.Sort = "SPOJENOPREZIME";
            CreateValueList(this.DataGrid, "RADNIKIDRADNIK", defaultView, "IDRADNIK", "SPOJENOPREZIME");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["ZAPOSLENI"].Columns["IDRADNIK"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["RADNIKIDRADNIK"];
            if (setColumnsWidth)
            {
                column.Width = 370;
            }
        }

        private void ZAPOSLENIUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void ZAPOSLENIUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual ZAPOSLENIDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridZAPOSLENI;
            }
            set
            {
                this.userControlDataGridZAPOSLENI = value;
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

        [Category("Deklarit Work With ")]
        public virtual int FillByIDRADNIKIDRADNIK
        {
            get
            {
                return this.DataGrid.FillByIDRADNIKIDRADNIK;
            }
            set
            {
                this.DataGrid.FillByIDRADNIKIDRADNIK = value;
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

