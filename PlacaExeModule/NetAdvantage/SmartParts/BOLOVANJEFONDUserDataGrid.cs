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

    public class BOLOVANJEFONDUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with BOLOVANJEFOND";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with BOLOVANJEFOND";
        private BOLOVANJEFONDDataGrid userControlDataGridBOLOVANJEFOND;

        public BOLOVANJEFONDUserDataGrid()
        {
            this.InitializeComponent();
        }

        private void BOLOVANJEFONDUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void BOLOVANJEFONDUserDataGrid_Load(object sender, EventArgs e)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BOLOVANJEFONDUserDataGrid));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BOLOVANJEFOND", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ELEMENTBOLOVANJEIDELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ELEMENTBOLOVANJENAZIVELEMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KOLONA");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.userControlDataGridBOLOVANJEFOND = new NetAdvantage.Controls.BOLOVANJEFONDDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.userControlDataGridBOLOVANJEFOND)).BeginInit();
            this.SuspendLayout();
            // 
            // userControlDataGridBOLOVANJEFOND
            // 
            appearance1.TextHAlignAsString = "Left";
            this.userControlDataGridBOLOVANJEFOND.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Format = "";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 112;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Format = "";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 296;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance3.TextHAlignAsString = "Right";
            ultraGridColumn3.CellAppearance = appearance3;
            ultraGridColumn3.Format = "";
            ultraGridColumn3.Header.Caption = "Kolona ER-1 obrasca";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.MaskInput = "{LOC}-n";
            ultraGridColumn3.PromptChar = ' ';
            ultraGridColumn3.Width = 132;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3});
            this.userControlDataGridBOLOVANJEFOND.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.userControlDataGridBOLOVANJEFOND.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.userControlDataGridBOLOVANJEFOND.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlDataGridBOLOVANJEFOND.FillAtStartup = false;
            this.userControlDataGridBOLOVANJEFOND.FillByPage = false;
            this.userControlDataGridBOLOVANJEFOND.Location = new System.Drawing.Point(0, 0);
            this.userControlDataGridBOLOVANJEFOND.Name = "userControlDataGridBOLOVANJEFOND";
            this.userControlDataGridBOLOVANJEFOND.Size = new System.Drawing.Size(512, 324);
            this.userControlDataGridBOLOVANJEFOND.TabIndex = 0;
            this.userControlDataGridBOLOVANJEFOND.Tag = "BOLOVANJEFOND";
            this.userControlDataGridBOLOVANJEFOND.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.BOLOVANJEFONDUserDataGrid_InitializeRow);
            // 
            // BOLOVANJEFONDUserDataGrid
            // 
            this.Controls.Add(this.userControlDataGridBOLOVANJEFOND);
            this.Name = "BOLOVANJEFONDUserDataGrid";
            this.Size = new System.Drawing.Size(512, 324);
            this.Load += new System.EventHandler(this.BOLOVANJEFONDUserDataGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userControlDataGridBOLOVANJEFOND)).EndInit();
            this.ResumeLayout(false);

        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
            if (DataAdapterFactory.Provider == null)
            {
                DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
            }
            DataSet dataSet = new ELEMENTDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetELEMENTDataAdapter().Fill(dataSet);
            }
            System.Data.DataView dataList = new System.Data.DataView(dataSet.Tables["ELEMENT"]) {
                Sort = "EL"
            };
            CreateValueList(this.DataGrid, "ELEMENTELEMENTBOLOVANJEIDELEMENT", dataList, "IDELEMENT", "EL");
            UltraGridColumn column = this.DataGrid.DisplayLayout.Bands["BOLOVANJEFOND"].Columns["ELEMENTBOLOVANJEIDELEMENT"];
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.DataGrid.DisplayLayout.ValueLists["ELEMENTELEMENTBOLOVANJEIDELEMENT"];
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
        public virtual BOLOVANJEFONDDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridBOLOVANJEFOND;
            }
            set
            {
                this.userControlDataGridBOLOVANJEFOND = value;
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

