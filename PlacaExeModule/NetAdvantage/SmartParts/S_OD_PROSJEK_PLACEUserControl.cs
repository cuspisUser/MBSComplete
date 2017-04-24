namespace NetAdvantage.SmartParts
{
    using Deklarit;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Practices.CompositeUI.NetAdvantage.Services;
    using Deklarit.Practices.CompositeUI.Services;
    using Deklarit.Resources;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.Printing;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinGrid.ExcelExport;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using NetAdvantage.Controls;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class S_OD_PROSJEK_PLACEUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("comboIDRADNIK")]
        private PregledRadnikaComboBox _comboIDRADNIK;
        [AccessedThroughProperty("label1DOOO")]
        private UltraLabel _label1DOOO;
        [AccessedThroughProperty("label1IDRADNIK")]
        private UltraLabel _label1IDRADNIK;
        [AccessedThroughProperty("label1ODD")]
        private UltraLabel _label1ODD;
        [AccessedThroughProperty("textDOOO")]
        private UltraTextEditor _textDOOO;
        [AccessedThroughProperty("textODD")]
        private UltraTextEditor _textODD;
        [AccessedThroughProperty("userControlDataGridS_OD_PROSJEK_PLACE")]
        private S_OD_PROSJEK_PLACEUserDataGrid _userControlDataGridS_OD_PROSJEK_PLACE;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_OD_PROSJEK_PLACE;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_OD_PROSJEK_PLACEUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_OD_PROSJEK_PLACEDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_OD_PROSJEK_PLACEDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_OD_PROSJEK_PLACEDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_OD_PROSJEK_PLACEDataSet>(this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        private void DataGrid_AfterRowActivate(object sender, EventArgs e)
        {
            DataRow currentDataRow = this.CurrentDataRow;
        }

        private void DataGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
        }

        private void DataGrid_SetFocus()
        {
            if ((this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.Rows[0].Activate();
            }
        }

        private void DefaultAction()
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        [LocalCommandHandler("ExportExcel")]
        public void ExportExcelHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                SaveFileDialog dialog = new SaveFileDialog {
                    DefaultExt = "xls",
                    Filter = "Excel file (*.xls)|*.xls"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.FillByPage;
                this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_OD_PROSJEK_PLACE.ParameterODD = this.textODD.Text;
                this.userControlDataGridS_OD_PROSJEK_PLACE.ParameterDOOO = this.textDOOO.Text;
                this.userControlDataGridS_OD_PROSJEK_PLACE.ParameterIDRADNIK = int.Parse(this.comboIDRADNIK.Value.ToString());
                this.userControlDataGridS_OD_PROSJEK_PLACE.Fill();
                ((S_OD_PROSJEK_PLACEWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_OD_PROSJEK_PLACE.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("ODD", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("DOOO", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("IDRADNIK", typeof(int));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["ODD"] = this.textODD.Text;
            row2["DOOO"] = this.textDOOO.Text;
            row2["IDRADNIK"] = int.Parse(this.comboIDRADNIK.Value.ToString());
            return row2;
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(S_OD_PROSJEK_PLACEUserControl));
            this.layoutManagerformS_OD_PROSJEK_PLACE = new TableLayoutPanel();
            this.layoutManagerformS_OD_PROSJEK_PLACE.SuspendLayout();
            this.layoutManagerformS_OD_PROSJEK_PLACE.AutoSize = true;
            this.layoutManagerformS_OD_PROSJEK_PLACE.Dock = DockStyle.Fill;
            this.layoutManagerformS_OD_PROSJEK_PLACE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_OD_PROSJEK_PLACE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_OD_PROSJEK_PLACE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_OD_PROSJEK_PLACE.Size = size;
            this.layoutManagerformS_OD_PROSJEK_PLACE.ColumnCount = 2;
            this.layoutManagerformS_OD_PROSJEK_PLACE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OD_PROSJEK_PLACE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OD_PROSJEK_PLACE.RowCount = 4;
            this.layoutManagerformS_OD_PROSJEK_PLACE.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OD_PROSJEK_PLACE.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OD_PROSJEK_PLACE.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OD_PROSJEK_PLACE.RowStyles.Add(new RowStyle());
            this.label1ODD = new UltraLabel();
            this.textODD = new UltraTextEditor();
            this.label1DOOO = new UltraLabel();
            this.textDOOO = new UltraTextEditor();
            this.label1IDRADNIK = new UltraLabel();
            this.comboIDRADNIK = new PregledRadnikaComboBox();
            this.userControlDataGridS_OD_PROSJEK_PLACE = new S_OD_PROSJEK_PLACEUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textODD).BeginInit();
            ((ISupportInitialize) this.textDOOO).BeginInit();
            this.SuspendLayout();
            this.label1ODD.Name = "label1ODD";
            this.label1ODD.TabIndex = 1;
            this.label1ODD.Tag = "labelODD";
            this.label1ODD.AutoSize = true;
            this.label1ODD.StyleSetName = "FieldUltraLabel";
            this.label1ODD.Text = "ODD      :";
            this.label1ODD.Appearance.TextVAlign = VAlign.Middle;
            this.label1ODD.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ODD.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OD_PROSJEK_PLACE.Controls.Add(this.label1ODD, 0, 0);
            this.layoutManagerformS_OD_PROSJEK_PLACE.SetColumnSpan(this.label1ODD, 1);
            this.layoutManagerformS_OD_PROSJEK_PLACE.SetRowSpan(this.label1ODD, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1ODD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ODD.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textODD.Location = point;
            this.textODD.Name = "textODD";
            this.textODD.Tag = "ODD";
            this.textODD.TabIndex = 0;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textODD.Size = size;
            this.textODD.MaxLength = 7;
            this.layoutManagerformS_OD_PROSJEK_PLACE.Controls.Add(this.textODD, 1, 0);
            this.layoutManagerformS_OD_PROSJEK_PLACE.SetColumnSpan(this.textODD, 1);
            this.layoutManagerformS_OD_PROSJEK_PLACE.SetRowSpan(this.textODD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textODD.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textODD.MinimumSize = size;
            this.label1DOOO.Name = "label1DOOO";
            this.label1DOOO.TabIndex = 1;
            this.label1DOOO.Tag = "labelDOOO";
            this.label1DOOO.AutoSize = true;
            this.label1DOOO.StyleSetName = "FieldUltraLabel";
            this.label1DOOO.Text = "DOOO      :";
            this.label1DOOO.Appearance.TextVAlign = VAlign.Middle;
            this.label1DOOO.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1DOOO.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OD_PROSJEK_PLACE.Controls.Add(this.label1DOOO, 0, 1);
            this.layoutManagerformS_OD_PROSJEK_PLACE.SetColumnSpan(this.label1DOOO, 1);
            this.layoutManagerformS_OD_PROSJEK_PLACE.SetRowSpan(this.label1DOOO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DOOO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DOOO.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textDOOO.Location = point;
            this.textDOOO.Name = "textDOOO";
            this.textDOOO.Tag = "DOOO";
            this.textDOOO.TabIndex = 1;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textDOOO.Size = size;
            this.textDOOO.MaxLength = 7;
            this.layoutManagerformS_OD_PROSJEK_PLACE.Controls.Add(this.textDOOO, 1, 1);
            this.layoutManagerformS_OD_PROSJEK_PLACE.SetColumnSpan(this.textDOOO, 1);
            this.layoutManagerformS_OD_PROSJEK_PLACE.SetRowSpan(this.textDOOO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDOOO.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textDOOO.MinimumSize = size;
            this.label1IDRADNIK.Name = "label1IDRADNIK";
            this.label1IDRADNIK.TabIndex = 1;
            this.label1IDRADNIK.Tag = "labelIDRADNIK";
            this.label1IDRADNIK.AutoSize = true;
            this.label1IDRADNIK.StyleSetName = "FieldUltraLabel";
            this.label1IDRADNIK.Text = "IDRADNIK      :";
            this.label1IDRADNIK.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDRADNIK.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1IDRADNIK.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OD_PROSJEK_PLACE.Controls.Add(this.label1IDRADNIK, 0, 2);
            this.layoutManagerformS_OD_PROSJEK_PLACE.SetColumnSpan(this.label1IDRADNIK, 1);
            this.layoutManagerformS_OD_PROSJEK_PLACE.SetRowSpan(this.label1IDRADNIK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDRADNIK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDRADNIK.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDRADNIK.Location = point;
            this.comboIDRADNIK.Name = "comboIDRADNIK";
            this.comboIDRADNIK.Tag = "IDRADNIK";
            this.comboIDRADNIK.TabIndex = 2;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDRADNIK.Size = size;
            this.comboIDRADNIK.DropDownStyle = DropDownStyle.DropDownList;
            this.comboIDRADNIK.AddEmptyValue = true;
            this.layoutManagerformS_OD_PROSJEK_PLACE.Controls.Add(this.comboIDRADNIK, 1, 2);
            this.layoutManagerformS_OD_PROSJEK_PLACE.SetColumnSpan(this.comboIDRADNIK, 1);
            this.layoutManagerformS_OD_PROSJEK_PLACE.SetRowSpan(this.comboIDRADNIK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDRADNIK.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDRADNIK.MinimumSize = size;
            this.layoutManagerformS_OD_PROSJEK_PLACE.Controls.Add(this.userControlDataGridS_OD_PROSJEK_PLACE, 0, 3);
            this.layoutManagerformS_OD_PROSJEK_PLACE.SetColumnSpan(this.userControlDataGridS_OD_PROSJEK_PLACE, 2);
            this.layoutManagerformS_OD_PROSJEK_PLACE.SetRowSpan(this.userControlDataGridS_OD_PROSJEK_PLACE, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_OD_PROSJEK_PLACE.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_OD_PROSJEK_PLACE.MinimumSize = size;
            this.userControlDataGridS_OD_PROSJEK_PLACE.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_OD_PROSJEK_PLACE);
            this.userControlDataGridS_OD_PROSJEK_PLACE.Name = "userControlDataGridS_OD_PROSJEK_PLACE";
            this.userControlDataGridS_OD_PROSJEK_PLACE.Dock = DockStyle.Fill;
            this.userControlDataGridS_OD_PROSJEK_PLACE.DockPadding.All = 5;
            this.userControlDataGridS_OD_PROSJEK_PLACE.FillAtStartup = false;
            this.userControlDataGridS_OD_PROSJEK_PLACE.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OD_PROSJEK_PLACE.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_OD_PROSJEK_PLACE.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_OD_PROSJEK_PLACEWorkWith";
            this.Text = "Work With S_OD_PROSJEK_PLACE";
            this.Load += new EventHandler(this.S_OD_PROSJEK_PLACEUserControl_Load);
            this.layoutManagerformS_OD_PROSJEK_PLACE.ResumeLayout(false);
            this.layoutManagerformS_OD_PROSJEK_PLACE.PerformLayout();
            ((ISupportInitialize) this.textODD).EndInit();
            ((ISupportInitialize) this.textDOOO).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textODD.Text = "";
            this.textDOOO.Text = "";
            this.comboIDRADNIK.SelectedIndex = 0;
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("ODD") && (this.m_FillByRow["ODD"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textODD, this.m_FillByRow["ODD"].ToString(), this.m_FillByRow.Table.Columns["ODD"].DataType);
                    this.parameterSeted = true;
                    this.textODD.Visible = false;
                    this.label1ODD.Visible = false;
                    str = str + "," + this.m_FillByRow["ODD"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("DOOO") && (this.m_FillByRow["DOOO"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textDOOO, this.m_FillByRow["DOOO"].ToString(), this.m_FillByRow.Table.Columns["DOOO"].DataType);
                    this.parameterSeted = true;
                    this.textDOOO.Visible = false;
                    this.label1DOOO.Visible = false;
                    str = str + "," + this.m_FillByRow["DOOO"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("IDRADNIK") && (this.m_FillByRow["IDRADNIK"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.comboIDRADNIK, this.m_FillByRow["IDRADNIK"].ToString(), this.m_FillByRow.Table.Columns["IDRADNIK"].DataType);
                    this.parameterSeted = true;
                    this.comboIDRADNIK.Visible = false;
                    this.label1IDRADNIK.Visible = false;
                    str = str + "," + this.m_FillByRow["IDRADNIK"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_OD_PROSJEK_PLACE " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_OD_PROSJEK_PLACE " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                }
            }
        }

        [LocalCommandHandler("ImportXml")]
        public void LoadFromXml(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                DefaultExt = "xml",
                Filter = "XML file (*.xml)|*.xml"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_OD_PROSJEK_PLACEDataAdapter().Update(this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.DataSet);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                    
                }
            }
            this.FillData();
        }

        private void Localize()
        {
            this.label1ODD.Text = StringResources.S_OD_PROSJEK_PLACEODDParameter;
            this.label1DOOO.Text = StringResources.S_OD_PROSJEK_PLACEDOOOParameter;
            this.label1IDRADNIK.Text = StringResources.S_OD_PROSJEK_PLACEIDRADNIKParameter;
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        [LocalCommandHandler("Print")]
        public void PrintHandler(object sender, EventArgs e)
        {
            if (Information.IsNothing(this.ultraPrintPreviewDialog1.Document))
            {
                this.ultraPrintPreviewDialog1.Document = this.ultraGridPrintDocument1;
                this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
                this.ultraPrintPreviewDialog1.Document.DocumentName = "";
                this.ultraPrintPreviewDialog1.Text = "";
            }
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.ultraPrintPreviewDialog1.ShowDialog(this);
            }
        }

        public void RefreshGrid(object sender, ComponentEventArgs args)
        {
            this.FillData();
        }

        [LocalCommandHandler("Refresh")]
        public void RefreshHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.FillData();
            }
        }

        private void S_OD_PROSJEK_PLACEUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.FillByPage = true;
                this.FillData();
            }
        }

        [LocalCommandHandler("ExportXml")]
        public void SaveToXml(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog {
                DefaultExt = "xml",
                Filter = "XML file (*.xml)|*.xml"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.DisplayLayout.UIElement.LastElementEntered;
            if (lastElementEntered is RowUIElement)
            {
                ancestor = (RowUIElement) lastElementEntered;
            }
            else
            {
                ancestor = (RowUIElement) lastElementEntered.GetAncestor(typeof(RowUIElement));
            }
            if (ancestor != null)
            {
                this.SelectHandler(RuntimeHelpers.GetObjectValue(sender), e);
            }
        }

        [LocalCommandHandler("Select")]
        public void SelectHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.m_RowSelected = this.CurrentDataRow;
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetSmartPartInfoInformation()
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.smartPartInfo1.Title = string.Format("{0} S_OD_PROSJEK_PLACE ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_OD_PROSJEK_PLACE ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        protected virtual PregledRadnikaComboBox comboIDRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDRADNIK = value;
            }
        }

        [CreateNew]
        public S_OD_PROSJEK_PLACEController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_OD_PROSJEK_PLACE.DataView[this.userControlDataGridS_OD_PROSJEK_PLACE.DataGrid.CurrentRowIndex].Row;
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.FillByRow
        {
            set
            {
                this.m_FillByRow = value;
                this.SetSmartPartInfoInformation();
            }
        }

        string Deklarit.Practices.CompositeUI.IFilteredView.FillMethod
        {
            set
            {
                this.m_FillByMethod = value;
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode Deklarit.Practices.CompositeUI.IFilteredView.WorkWithMode
        {
            set
            {
                this.m_WorkWithMode = value;
                this.SetSmartPartInfoInformation();
            }
        }

        public DataRow FillByRow
        {
            set
            {
                this.m_FillByRow = value;
                this.SetSmartPartInfoInformation();
            }
        }

        public string FillMethod
        {
            set
            {
                this.m_FillByMethod = value;
            }
        }

        protected virtual UltraLabel label1DOOO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DOOO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DOOO = value;
            }
        }

        protected virtual UltraLabel label1IDRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDRADNIK = value;
            }
        }

        protected virtual UltraLabel label1ODD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ODD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ODD = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraTextEditor textDOOO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDOOO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDOOO = value;
            }
        }

        protected virtual UltraTextEditor textODD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textODD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textODD = value;
            }
        }

        protected virtual S_OD_PROSJEK_PLACEUserDataGrid userControlDataGridS_OD_PROSJEK_PLACE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_OD_PROSJEK_PLACE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_OD_PROSJEK_PLACE = value;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
                this.m_WorkWithMode = value;
                this.SetSmartPartInfoInformation();
            }
        }
    }
}

