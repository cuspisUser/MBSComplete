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
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class S_FIN_DNEVNIKBLAGAJNEUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("datePickerdat1")]
        private UltraDateTimeEditor _datePickerdat1;
        [AccessedThroughProperty("datePickerdat2")]
        private UltraDateTimeEditor _datePickerdat2;
        [AccessedThroughProperty("label1blag")]
        private UltraLabel _label1blag;
        [AccessedThroughProperty("label1dat1")]
        private UltraLabel _label1dat1;
        [AccessedThroughProperty("label1dat2")]
        private UltraLabel _label1dat2;
        [AccessedThroughProperty("textblag")]
        private UltraNumericEditor _textblag;
        [AccessedThroughProperty("userControlDataGridS_FIN_DNEVNIKBLAGAJNE")]
        private S_FIN_DNEVNIKBLAGAJNEUserDataGrid _userControlDataGridS_FIN_DNEVNIKBLAGAJNE;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_FIN_DNEVNIKBLAGAJNE;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_FIN_DNEVNIKBLAGAJNEUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_FIN_DNEVNIKBLAGAJNEDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_FIN_DNEVNIKBLAGAJNEDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_FIN_DNEVNIKBLAGAJNEDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_FIN_DNEVNIKBLAGAJNEDataSet>(this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid);
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
            if ((this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.FillByPage;
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                if (this.datePickerdat1.Value == null)
                {
                    this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Parameterdat1 = DateTime.MinValue;
                }
                else
                {
                    this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Parameterdat1 = DateTime.Parse(this.datePickerdat1.Value.ToString(), CultureInfo.CurrentCulture);
                }
                if (this.datePickerdat2.Value == null)
                {
                    this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Parameterdat2 = DateTime.MinValue;
                }
                else
                {
                    this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Parameterdat2 = DateTime.Parse(this.datePickerdat2.Value.ToString(), CultureInfo.CurrentCulture);
                }
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Parameterblag = int.Parse(this.textblag.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Fill();
                ((S_FIN_DNEVNIKBLAGAJNEWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("dat1", typeof(DateTime));
            table2.Columns.Add(column);
            column = new DataColumn("dat2", typeof(DateTime));
            table2.Columns.Add(column);
            column = new DataColumn("blag", typeof(int));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            if (this.datePickerdat1.Value == null)
            {
                row2["dat1"] = DateTime.MinValue;
            }
            else
            {
                row2["dat1"] = DateTime.Parse(this.datePickerdat1.Value.ToString(), CultureInfo.CurrentCulture);
            }
            if (this.datePickerdat2.Value == null)
            {
                row2["dat2"] = DateTime.MinValue;
            }
            else
            {
                row2["dat2"] = DateTime.Parse(this.datePickerdat2.Value.ToString(), CultureInfo.CurrentCulture);
            }
            row2["blag"] = int.Parse(this.textblag.Value.ToString(), CultureInfo.CurrentCulture);
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
            ResourceManager manager = new ResourceManager(typeof(S_FIN_DNEVNIKBLAGAJNEUserControl));
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE = new TableLayoutPanel();
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.SuspendLayout();
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.AutoSize = true;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.Dock = DockStyle.Fill;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.Size = size;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.ColumnCount = 2;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.RowCount = 4;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.RowStyles.Add(new RowStyle());
            this.label1dat1 = new UltraLabel();
            this.datePickerdat1 = new UltraDateTimeEditor();
            this.label1dat2 = new UltraLabel();
            this.datePickerdat2 = new UltraDateTimeEditor();
            this.label1blag = new UltraLabel();
            this.textblag = new UltraNumericEditor();
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE = new S_FIN_DNEVNIKBLAGAJNEUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textblag).BeginInit();
            this.SuspendLayout();
            this.label1dat1.Name = "label1dat1";
            this.label1dat1.TabIndex = 1;
            this.label1dat1.Tag = "labeldat1";
            this.label1dat1.AutoSize = true;
            this.label1dat1.StyleSetName = "FieldUltraLabel";
            this.label1dat1.Text = "dat1  :";
            this.label1dat1.Appearance.TextVAlign = VAlign.Middle;
            this.label1dat1.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1dat1.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.Controls.Add(this.label1dat1, 0, 0);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.SetColumnSpan(this.label1dat1, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.SetRowSpan(this.label1dat1, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1dat1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1dat1.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerdat1.Location = point;
            this.datePickerdat1.Name = "datePickerdat1";
            this.datePickerdat1.Tag = "dat1";
            this.datePickerdat1.TabIndex = 0;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerdat1.Size = size;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.Controls.Add(this.datePickerdat1, 1, 0);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.SetColumnSpan(this.datePickerdat1, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.SetRowSpan(this.datePickerdat1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerdat1.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerdat1.MinimumSize = size;
            this.label1dat2.Name = "label1dat2";
            this.label1dat2.TabIndex = 1;
            this.label1dat2.Tag = "labeldat2";
            this.label1dat2.AutoSize = true;
            this.label1dat2.StyleSetName = "FieldUltraLabel";
            this.label1dat2.Text = "dat2  :";
            this.label1dat2.Appearance.TextVAlign = VAlign.Middle;
            this.label1dat2.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1dat2.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.Controls.Add(this.label1dat2, 0, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.SetColumnSpan(this.label1dat2, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.SetRowSpan(this.label1dat2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1dat2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1dat2.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerdat2.Location = point;
            this.datePickerdat2.Name = "datePickerdat2";
            this.datePickerdat2.Tag = "dat2";
            this.datePickerdat2.TabIndex = 1;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerdat2.Size = size;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.Controls.Add(this.datePickerdat2, 1, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.SetColumnSpan(this.datePickerdat2, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.SetRowSpan(this.datePickerdat2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerdat2.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerdat2.MinimumSize = size;
            this.label1blag.Name = "label1blag";
            this.label1blag.TabIndex = 1;
            this.label1blag.Tag = "labelblag";
            this.label1blag.AutoSize = true;
            this.label1blag.StyleSetName = "FieldUltraLabel";
            this.label1blag.Text = "blag  :";
            this.label1blag.Appearance.TextVAlign = VAlign.Middle;
            this.label1blag.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1blag.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.Controls.Add(this.label1blag, 0, 2);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.SetColumnSpan(this.label1blag, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.SetRowSpan(this.label1blag, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1blag.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1blag.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textblag.Location = point;
            this.textblag.Name = "textblag";
            this.textblag.Tag = "blag";
            this.textblag.TabIndex = 2;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textblag.Size = size;
            this.textblag.PromptChar = ' ';
            this.textblag.Enter += new EventHandler(this.numericEditor_Enter);
            this.textblag.NumericType = NumericType.Integer;
            this.textblag.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.Controls.Add(this.textblag, 1, 2);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.SetColumnSpan(this.textblag, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.SetRowSpan(this.textblag, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textblag.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textblag.MinimumSize = size;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.Controls.Add(this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE, 0, 3);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.SetColumnSpan(this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE, 2);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.SetRowSpan(this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.MinimumSize = size;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Name = "userControlDataGridS_FIN_DNEVNIKBLAGAJNE";
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DockPadding.All = 5;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.FillAtStartup = false;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_FIN_DNEVNIKBLAGAJNEWorkWith";
            this.Text = "Work With S_FIN_DNEVNIKBLAGAJNE";
            this.Load += new EventHandler(this.S_FIN_DNEVNIKBLAGAJNEUserControl_Load);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.ResumeLayout(false);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNE.PerformLayout();
            ((ISupportInitialize) this.textblag).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.datePickerdat1.Text = "";
            this.datePickerdat2.Text = "";
            this.textblag.Text = "0";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("dat1") && (this.m_FillByRow["dat1"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.datePickerdat1, this.m_FillByRow["dat1"].ToString(), this.m_FillByRow.Table.Columns["dat1"].DataType);
                    this.parameterSeted = true;
                    this.datePickerdat1.Visible = false;
                    this.label1dat1.Visible = false;
                    str = str + "," + this.m_FillByRow["dat1"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("dat2") && (this.m_FillByRow["dat2"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.datePickerdat2, this.m_FillByRow["dat2"].ToString(), this.m_FillByRow.Table.Columns["dat2"].DataType);
                    this.parameterSeted = true;
                    this.datePickerdat2.Visible = false;
                    this.label1dat2.Visible = false;
                    str = str + "," + this.m_FillByRow["dat2"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("blag") && (this.m_FillByRow["blag"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textblag, this.m_FillByRow["blag"].ToString(), this.m_FillByRow.Table.Columns["blag"].DataType);
                    this.parameterSeted = true;
                    this.textblag.Visible = false;
                    this.label1blag.Visible = false;
                    str = str + "," + this.m_FillByRow["blag"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_FIN_DNEVNIKBLAGAJNE " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_FIN_DNEVNIKBLAGAJNE " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_FIN_DNEVNIKBLAGAJNEDataAdapter().Update(this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.DataSet);
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
            this.label1dat1.Text = StringResources.S_FIN_DNEVNIKBLAGAJNEdat1Parameter;
            this.label1dat2.Text = StringResources.S_FIN_DNEVNIKBLAGAJNEdat2Parameter;
            this.label1blag.Text = StringResources.S_FIN_DNEVNIKBLAGAJNEblagParameter;
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

        private void S_FIN_DNEVNIKBLAGAJNEUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_FIN_DNEVNIKBLAGAJNE ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_FIN_DNEVNIKBLAGAJNE ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_FIN_DNEVNIKBLAGAJNEController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataView[this.userControlDataGridS_FIN_DNEVNIKBLAGAJNE.DataGrid.CurrentRowIndex].Row;
            }
        }

        protected virtual UltraDateTimeEditor datePickerdat1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerdat1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerdat1 = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerdat2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerdat2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerdat2 = value;
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

        protected virtual UltraLabel label1blag
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1blag;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1blag = value;
            }
        }

        protected virtual UltraLabel label1dat1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1dat1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1dat1 = value;
            }
        }

        protected virtual UltraLabel label1dat2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1dat2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1dat2 = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraNumericEditor textblag
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textblag;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textblag = value;
            }
        }

        protected virtual S_FIN_DNEVNIKBLAGAJNEUserDataGrid userControlDataGridS_FIN_DNEVNIKBLAGAJNE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_FIN_DNEVNIKBLAGAJNE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_FIN_DNEVNIKBLAGAJNE = value;
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

