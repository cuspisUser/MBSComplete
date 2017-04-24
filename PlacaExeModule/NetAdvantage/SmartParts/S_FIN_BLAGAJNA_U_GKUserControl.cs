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
    public class S_FIN_BLAGAJNA_U_GKUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("datePickerDAT1")]
        private UltraDateTimeEditor _datePickerDAT1;
        [AccessedThroughProperty("datePickerDAT2")]
        private UltraDateTimeEditor _datePickerDAT2;
        [AccessedThroughProperty("label1BLAG")]
        private UltraLabel _label1BLAG;
        [AccessedThroughProperty("label1DAT1")]
        private UltraLabel _label1DAT1;
        [AccessedThroughProperty("label1DAT2")]
        private UltraLabel _label1DAT2;
        [AccessedThroughProperty("textBLAG")]
        private UltraNumericEditor _textBLAG;
        [AccessedThroughProperty("userControlDataGridS_FIN_BLAGAJNA_U_GK")]
        private S_FIN_BLAGAJNA_U_GKUserDataGrid _userControlDataGridS_FIN_BLAGAJNA_U_GK;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_FIN_BLAGAJNA_U_GK;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_FIN_BLAGAJNA_U_GKUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_FIN_BLAGAJNA_U_GKDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_FIN_BLAGAJNA_U_GKDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_FIN_BLAGAJNA_U_GKDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_FIN_BLAGAJNA_U_GKDataSet>(this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid);
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
            if ((this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.FillByPage;
                this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                if (this.datePickerDAT1.Value == null)
                {
                    this.userControlDataGridS_FIN_BLAGAJNA_U_GK.ParameterDAT1 = DateTime.MinValue;
                }
                else
                {
                    this.userControlDataGridS_FIN_BLAGAJNA_U_GK.ParameterDAT1 = DateTime.Parse(this.datePickerDAT1.Value.ToString(), CultureInfo.CurrentCulture);
                }
                if (this.datePickerDAT2.Value == null)
                {
                    this.userControlDataGridS_FIN_BLAGAJNA_U_GK.ParameterDAT2 = DateTime.MinValue;
                }
                else
                {
                    this.userControlDataGridS_FIN_BLAGAJNA_U_GK.ParameterDAT2 = DateTime.Parse(this.datePickerDAT2.Value.ToString(), CultureInfo.CurrentCulture);
                }
                this.userControlDataGridS_FIN_BLAGAJNA_U_GK.ParameterBLAG = int.Parse(this.textBLAG.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_FIN_BLAGAJNA_U_GK.Fill();
                ((S_FIN_BLAGAJNA_U_GKWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("DAT1", typeof(DateTime));
            table2.Columns.Add(column);
            column = new DataColumn("DAT2", typeof(DateTime));
            table2.Columns.Add(column);
            column = new DataColumn("BLAG", typeof(int));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            if (this.datePickerDAT1.Value == null)
            {
                row2["DAT1"] = DateTime.MinValue;
            }
            else
            {
                row2["DAT1"] = DateTime.Parse(this.datePickerDAT1.Value.ToString(), CultureInfo.CurrentCulture);
            }
            if (this.datePickerDAT2.Value == null)
            {
                row2["DAT2"] = DateTime.MinValue;
            }
            else
            {
                row2["DAT2"] = DateTime.Parse(this.datePickerDAT2.Value.ToString(), CultureInfo.CurrentCulture);
            }
            row2["BLAG"] = int.Parse(this.textBLAG.Value.ToString(), CultureInfo.CurrentCulture);
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
            ResourceManager manager = new ResourceManager(typeof(S_FIN_BLAGAJNA_U_GKUserControl));
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK = new TableLayoutPanel();
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.SuspendLayout();
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.AutoSize = true;
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.Dock = DockStyle.Fill;
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.Size = size;
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.ColumnCount = 2;
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.RowCount = 4;
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.RowStyles.Add(new RowStyle());
            this.label1DAT1 = new UltraLabel();
            this.datePickerDAT1 = new UltraDateTimeEditor();
            this.label1DAT2 = new UltraLabel();
            this.datePickerDAT2 = new UltraDateTimeEditor();
            this.label1BLAG = new UltraLabel();
            this.textBLAG = new UltraNumericEditor();
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK = new S_FIN_BLAGAJNA_U_GKUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textBLAG).BeginInit();
            this.SuspendLayout();
            this.label1DAT1.Name = "label1DAT1";
            this.label1DAT1.TabIndex = 1;
            this.label1DAT1.Tag = "labelDAT1";
            this.label1DAT1.AutoSize = true;
            this.label1DAT1.StyleSetName = "FieldUltraLabel";
            this.label1DAT1.Text = "DA T1  :";
            this.label1DAT1.Appearance.TextVAlign = VAlign.Middle;
            this.label1DAT1.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1DAT1.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.Controls.Add(this.label1DAT1, 0, 0);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.SetColumnSpan(this.label1DAT1, 1);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.SetRowSpan(this.label1DAT1, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1DAT1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DAT1.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDAT1.Location = point;
            this.datePickerDAT1.Name = "datePickerDAT1";
            this.datePickerDAT1.Tag = "DAT1";
            this.datePickerDAT1.TabIndex = 0;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDAT1.Size = size;
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.Controls.Add(this.datePickerDAT1, 1, 0);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.SetColumnSpan(this.datePickerDAT1, 1);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.SetRowSpan(this.datePickerDAT1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDAT1.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDAT1.MinimumSize = size;
            this.label1DAT2.Name = "label1DAT2";
            this.label1DAT2.TabIndex = 1;
            this.label1DAT2.Tag = "labelDAT2";
            this.label1DAT2.AutoSize = true;
            this.label1DAT2.StyleSetName = "FieldUltraLabel";
            this.label1DAT2.Text = "DA T2  :";
            this.label1DAT2.Appearance.TextVAlign = VAlign.Middle;
            this.label1DAT2.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1DAT2.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.Controls.Add(this.label1DAT2, 0, 1);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.SetColumnSpan(this.label1DAT2, 1);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.SetRowSpan(this.label1DAT2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DAT2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DAT2.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDAT2.Location = point;
            this.datePickerDAT2.Name = "datePickerDAT2";
            this.datePickerDAT2.Tag = "DAT2";
            this.datePickerDAT2.TabIndex = 1;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDAT2.Size = size;
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.Controls.Add(this.datePickerDAT2, 1, 1);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.SetColumnSpan(this.datePickerDAT2, 1);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.SetRowSpan(this.datePickerDAT2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDAT2.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDAT2.MinimumSize = size;
            this.label1BLAG.Name = "label1BLAG";
            this.label1BLAG.TabIndex = 1;
            this.label1BLAG.Tag = "labelBLAG";
            this.label1BLAG.AutoSize = true;
            this.label1BLAG.StyleSetName = "FieldUltraLabel";
            this.label1BLAG.Text = "BLAG  :";
            this.label1BLAG.Appearance.TextVAlign = VAlign.Middle;
            this.label1BLAG.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1BLAG.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.Controls.Add(this.label1BLAG, 0, 2);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.SetColumnSpan(this.label1BLAG, 1);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.SetRowSpan(this.label1BLAG, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1BLAG.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BLAG.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textBLAG.Location = point;
            this.textBLAG.Name = "textBLAG";
            this.textBLAG.Tag = "BLAG";
            this.textBLAG.TabIndex = 2;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textBLAG.Size = size;
            this.textBLAG.PromptChar = ' ';
            this.textBLAG.Enter += new EventHandler(this.numericEditor_Enter);
            this.textBLAG.NumericType = NumericType.Integer;
            this.textBLAG.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.Controls.Add(this.textBLAG, 1, 2);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.SetColumnSpan(this.textBLAG, 1);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.SetRowSpan(this.textBLAG, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBLAG.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textBLAG.MinimumSize = size;
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.Controls.Add(this.userControlDataGridS_FIN_BLAGAJNA_U_GK, 0, 3);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.SetColumnSpan(this.userControlDataGridS_FIN_BLAGAJNA_U_GK, 2);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.SetRowSpan(this.userControlDataGridS_FIN_BLAGAJNA_U_GK, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.MinimumSize = size;
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_FIN_BLAGAJNA_U_GK);
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.Name = "userControlDataGridS_FIN_BLAGAJNA_U_GK";
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DockPadding.All = 5;
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.FillAtStartup = false;
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_FIN_BLAGAJNA_U_GKWorkWith";
            this.Text = "Work With S_FIN_BLAGAJNA_U_GK";
            this.Load += new EventHandler(this.S_FIN_BLAGAJNA_U_GKUserControl_Load);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.ResumeLayout(false);
            this.layoutManagerformS_FIN_BLAGAJNA_U_GK.PerformLayout();
            ((ISupportInitialize) this.textBLAG).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.datePickerDAT1.Text = "";
            this.datePickerDAT2.Text = "";
            this.textBLAG.Text = "0";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("DAT1") && (this.m_FillByRow["DAT1"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.datePickerDAT1, this.m_FillByRow["DAT1"].ToString(), this.m_FillByRow.Table.Columns["DAT1"].DataType);
                    this.parameterSeted = true;
                    this.datePickerDAT1.Visible = false;
                    this.label1DAT1.Visible = false;
                    str = str + "," + this.m_FillByRow["DAT1"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("DAT2") && (this.m_FillByRow["DAT2"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.datePickerDAT2, this.m_FillByRow["DAT2"].ToString(), this.m_FillByRow.Table.Columns["DAT2"].DataType);
                    this.parameterSeted = true;
                    this.datePickerDAT2.Visible = false;
                    this.label1DAT2.Visible = false;
                    str = str + "," + this.m_FillByRow["DAT2"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("BLAG") && (this.m_FillByRow["BLAG"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textBLAG, this.m_FillByRow["BLAG"].ToString(), this.m_FillByRow.Table.Columns["BLAG"].DataType);
                    this.parameterSeted = true;
                    this.textBLAG.Visible = false;
                    this.label1BLAG.Visible = false;
                    str = str + "," + this.m_FillByRow["BLAG"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_FIN_BLAGAJNA_U_GK " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_FIN_BLAGAJNA_U_GK " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_FIN_BLAGAJNA_U_GKDataAdapter().Update(this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.DataSet);
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
            this.label1DAT1.Text = StringResources.S_FIN_BLAGAJNA_U_GKDAT1Parameter;
            this.label1DAT2.Text = StringResources.S_FIN_BLAGAJNA_U_GKDAT2Parameter;
            this.label1BLAG.Text = StringResources.S_FIN_BLAGAJNA_U_GKBLAGParameter;
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

        private void S_FIN_BLAGAJNA_U_GKUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_FIN_BLAGAJNA_U_GK ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_FIN_BLAGAJNA_U_GK ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_FIN_BLAGAJNA_U_GKController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataView[this.userControlDataGridS_FIN_BLAGAJNA_U_GK.DataGrid.CurrentRowIndex].Row;
            }
        }

        protected virtual UltraDateTimeEditor datePickerDAT1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDAT1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDAT1 = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerDAT2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDAT2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDAT2 = value;
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

        protected virtual UltraLabel label1BLAG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BLAG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BLAG = value;
            }
        }

        protected virtual UltraLabel label1DAT1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DAT1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DAT1 = value;
            }
        }

        protected virtual UltraLabel label1DAT2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DAT2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DAT2 = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraNumericEditor textBLAG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBLAG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textBLAG = value;
            }
        }

        protected virtual S_FIN_BLAGAJNA_U_GKUserDataGrid userControlDataGridS_FIN_BLAGAJNA_U_GK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_FIN_BLAGAJNA_U_GK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_FIN_BLAGAJNA_U_GK = value;
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

