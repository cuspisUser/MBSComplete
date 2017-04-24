namespace NetAdvantage.SmartParts
{
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

    public class S_OD_BOLOVANJE_POSLODAVACUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_OD_BOLOVANJE_POSLODAVAC";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_OD_BOLOVANJE_POSLODAVAC";
        private S_OD_BOLOVANJE_POSLODAVACDataGrid userControlDataGridS_OD_BOLOVANJE_POSLODAVAC;

        public S_OD_BOLOVANJE_POSLODAVACUserDataGrid()
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
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC = new S_OD_BOLOVANJE_POSLODAVACDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC).BeginInit();
            UltraGridBand band = new UltraGridBand("S_OD_BOLOVANJE_POSLODAVAC", -1);
            UltraGridColumn column2 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column5 = new UltraGridColumn("PREZIME");
            UltraGridColumn column3 = new UltraGridColumn("IME");
            UltraGridColumn column4 = new UltraGridColumn("IZNOSBRUTO");
            UltraGridColumn column6 = new UltraGridColumn("SATIUKUPNO");
            UltraGridColumn column = new UltraGridColumn("GODINAMJESEC");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_OD_BOLOVANJE_POSLODAVACIDRADNIKDescription;
            column2.Width = 0x69;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.S_OD_BOLOVANJE_POSLODAVACPREZIMEDescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_OD_BOLOVANJE_POSLODAVACIMEDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_OD_BOLOVANJE_POSLODAVACIZNOSBRUTODescription;
            column4.Width = 0x66;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.S_OD_BOLOVANJE_POSLODAVACSATIUKUPNODescription;
            column6.Width = 0x66;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_OD_BOLOVANJE_POSLODAVACGODINAMJESECDescription;
            column.Width = 100;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 4;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 5;
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.Location = point;
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.Name = "userControlDataGridS_OD_BOLOVANJE_POSLODAVAC";
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.Tag = "S_OD_BOLOVANJE_POSLODAVAC";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.Size = size;
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.Dock = DockStyle.Fill;
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.FillAtStartup = false;
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.InitializeRow += new InitializeRowEventHandler(this.S_OD_BOLOVANJE_POSLODAVACUserDataGrid_InitializeRow);
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC });
            this.Name = "S_OD_BOLOVANJE_POSLODAVACUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_OD_BOLOVANJE_POSLODAVACUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC).EndInit();
            this.ResumeLayout(false);
        }

        private void S_OD_BOLOVANJE_POSLODAVACUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_OD_BOLOVANJE_POSLODAVACUserDataGrid_Load(object sender, EventArgs e)
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
            PregledRadnikaComboBox box = new PregledRadnikaComboBox();
            box.Fill();
            System.Data.DataView defaultView = box.DataSet.Tables["RADNIK"].DefaultView;
            defaultView.Sort = "SPOJENOPREZIME";
            CreateValueList(this.DataGrid, "RADNIKIDRADNIK", defaultView, "IDRADNIK", "SPOJENOPREZIME");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["S_OD_BOLOVANJE_POSLODAVAC"].Columns["IDRADNIK"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["RADNIKIDRADNIK"];
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
        public virtual S_OD_BOLOVANJE_POSLODAVACDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC;
            }
            set
            {
                this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC = value;
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

        [DefaultValue(true), Description("True= Fill at Startup. False= Not Fill"), Category("Deklarit Work With ")]
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

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameterdooo
        {
            get
            {
                return this.DataGrid.Parameterdooo;
            }
            set
            {
                this.DataGrid.Parameterdooo = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterIDRADNIK
        {
            get
            {
                return this.DataGrid.ParameterIDRADNIK;
            }
            set
            {
                this.DataGrid.ParameterIDRADNIK = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameterodd
        {
            get
            {
                return this.DataGrid.Parameterodd;
            }
            set
            {
                this.DataGrid.Parameterodd = value;
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

