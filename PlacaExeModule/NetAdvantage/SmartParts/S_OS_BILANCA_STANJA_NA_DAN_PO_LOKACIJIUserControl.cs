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
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using Placa;

    [SmartPart]
    public class S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("datePickerDATUM")]
        private UltraDateTimeEditor _datePickerDATUM;
        [AccessedThroughProperty("label1DATUM")]
        private UltraLabel _label1DATUM;
        [AccessedThroughProperty("label1SORT")]
        private UltraLabel _label1SORT;
        [AccessedThroughProperty("label1VRSTA")]
        private UltraLabel _label1VRSTA;
        [AccessedThroughProperty("textSORT")]
        private UltraTextEditor _textSORT;
        [AccessedThroughProperty("textVRSTA")]
        private UltraNumericEditor _textVRSTA;
        [AccessedThroughProperty("userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI")]
        private S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIUserDataGrid _userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataSet>(this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid);
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
            if ((this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.FillByPage;
                this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                if (this.datePickerDATUM.Value == null)
                {
                    this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.ParameterDATUM = DateTime.MinValue;
                }
                else
                {
                    this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.ParameterDATUM = DateTime.Parse(this.datePickerDATUM.Value.ToString(), CultureInfo.CurrentCulture);
                }
                this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.ParameterSORT = this.textSORT.Text;
                this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.ParameterVRSTA = int.Parse(this.textVRSTA.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Fill();
                ((S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("DATUM", typeof(DateTime));
            table2.Columns.Add(column);
            column = new DataColumn("SORT", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("VRSTA", typeof(int));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            if (this.datePickerDATUM.Value == null)
            {
                row2["DATUM"] = DateTime.MinValue;
            }
            else
            {
                row2["DATUM"] = DateTime.Parse(this.datePickerDATUM.Value.ToString(), CultureInfo.CurrentCulture);
            }
            row2["SORT"] = this.textSORT.Text;
            row2["VRSTA"] = int.Parse(this.textVRSTA.Value.ToString(), CultureInfo.CurrentCulture);
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
            ResourceManager manager = new ResourceManager(typeof(S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIUserControl));
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI = new TableLayoutPanel();
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.SuspendLayout();
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.AutoSize = true;
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Dock = DockStyle.Fill;
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Size = size;
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.ColumnCount = 2;
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.RowCount = 4;
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.RowStyles.Add(new RowStyle());
            this.label1DATUM = new UltraLabel();
            this.datePickerDATUM = new UltraDateTimeEditor();
            this.label1SORT = new UltraLabel();
            this.textSORT = new UltraTextEditor();
            this.label1VRSTA = new UltraLabel();
            this.textVRSTA = new UltraNumericEditor();
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI = new S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textSORT).BeginInit();
            ((ISupportInitialize) this.textVRSTA).BeginInit();
            this.SuspendLayout();
            this.label1DATUM.Name = "label1DATUM";
            this.label1DATUM.TabIndex = 1;
            this.label1DATUM.Tag = "labelDATUM";
            this.label1DATUM.AutoSize = true;
            this.label1DATUM.StyleSetName = "FieldUltraLabel";
            this.label1DATUM.Text = "DATUM  :";
            this.label1DATUM.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUM.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1DATUM.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Controls.Add(this.label1DATUM, 0, 0);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.SetColumnSpan(this.label1DATUM, 1);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.SetRowSpan(this.label1DATUM, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1DATUM.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUM.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUM.Location = point;
            this.datePickerDATUM.Name = "datePickerDATUM";
            this.datePickerDATUM.Tag = "DATUM";
            this.datePickerDATUM.TabIndex = 0;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUM.Size = size;
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Controls.Add(this.datePickerDATUM, 1, 0);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.SetColumnSpan(this.datePickerDATUM, 1);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.SetRowSpan(this.datePickerDATUM, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUM.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUM.MinimumSize = size;
            this.label1SORT.Name = "label1SORT";
            this.label1SORT.TabIndex = 1;
            this.label1SORT.Tag = "labelSORT";
            this.label1SORT.AutoSize = true;
            this.label1SORT.StyleSetName = "FieldUltraLabel";
            this.label1SORT.Text = "SORT  :";
            this.label1SORT.Appearance.TextVAlign = VAlign.Middle;
            this.label1SORT.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1SORT.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Controls.Add(this.label1SORT, 0, 1);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.SetColumnSpan(this.label1SORT, 1);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.SetRowSpan(this.label1SORT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SORT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SORT.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textSORT.Location = point;
            this.textSORT.Name = "textSORT";
            this.textSORT.Tag = "SORT";
            this.textSORT.TabIndex = 1;
            size = new System.Drawing.Size(0x17, 0x16);
            this.textSORT.Size = size;
            this.textSORT.MaxLength = 1;
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Controls.Add(this.textSORT, 1, 1);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.SetColumnSpan(this.textSORT, 1);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.SetRowSpan(this.textSORT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSORT.Margin = padding;
            size = new System.Drawing.Size(0x17, 0x16);
            this.textSORT.MinimumSize = size;
            this.label1VRSTA.Name = "label1VRSTA";
            this.label1VRSTA.TabIndex = 1;
            this.label1VRSTA.Tag = "labelVRSTA";
            this.label1VRSTA.AutoSize = true;
            this.label1VRSTA.StyleSetName = "FieldUltraLabel";
            this.label1VRSTA.Text = "VRSTA  :";
            this.label1VRSTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1VRSTA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1VRSTA.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Controls.Add(this.label1VRSTA, 0, 2);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.SetColumnSpan(this.label1VRSTA, 1);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.SetRowSpan(this.label1VRSTA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VRSTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VRSTA.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textVRSTA.Location = point;
            this.textVRSTA.Name = "textVRSTA";
            this.textVRSTA.Tag = "VRSTA";
            this.textVRSTA.TabIndex = 2;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textVRSTA.Size = size;
            this.textVRSTA.PromptChar = ' ';
            this.textVRSTA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textVRSTA.NumericType = NumericType.Integer;
            this.textVRSTA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Controls.Add(this.textVRSTA, 1, 2);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.SetColumnSpan(this.textVRSTA, 1);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.SetRowSpan(this.textVRSTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVRSTA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textVRSTA.MinimumSize = size;
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Controls.Add(this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI, 0, 3);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.SetColumnSpan(this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI, 2);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.SetRowSpan(this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.MinimumSize = size;
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI);
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Name = "userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI";
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Dock = DockStyle.Fill;
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DockPadding.All = 5;
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.FillAtStartup = false;
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIWorkWith";
            this.Text = "Work With S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI";
            this.Load += new EventHandler(this.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIUserControl_Load);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.ResumeLayout(false);
            this.layoutManagerformS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.PerformLayout();
            ((ISupportInitialize) this.textSORT).EndInit();
            ((ISupportInitialize) this.textVRSTA).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.datePickerDATUM.Text = "";
            this.textSORT.Text = "";
            this.textVRSTA.Text = "0";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("DATUM") && (this.m_FillByRow["DATUM"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.datePickerDATUM, this.m_FillByRow["DATUM"].ToString(), this.m_FillByRow.Table.Columns["DATUM"].DataType);
                    this.parameterSeted = true;
                    this.datePickerDATUM.Visible = false;
                    this.label1DATUM.Visible = false;
                    str = str + "," + this.m_FillByRow["DATUM"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("SORT") && (this.m_FillByRow["SORT"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textSORT, this.m_FillByRow["SORT"].ToString(), this.m_FillByRow.Table.Columns["SORT"].DataType);
                    this.parameterSeted = true;
                    this.textSORT.Visible = false;
                    this.label1SORT.Visible = false;
                    str = str + "," + this.m_FillByRow["SORT"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("VRSTA") && (this.m_FillByRow["VRSTA"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textVRSTA, this.m_FillByRow["VRSTA"].ToString(), this.m_FillByRow.Table.Columns["VRSTA"].DataType);
                    this.parameterSeted = true;
                    this.textVRSTA.Visible = false;
                    this.label1VRSTA.Visible = false;
                    str = str + "," + this.m_FillByRow["VRSTA"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                }
            }
        }

        private void Localize()
        {
            this.label1DATUM.Text = StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDATUMParameter;
            this.label1SORT.Text = StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJISORTParameter;
            this.label1VRSTA.Text = StringResources.S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIVRSTAParameter;
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

        private void S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.FillByPage = true;
                this.FillData();
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataView[this.userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI.DataGrid.CurrentRowIndex].Row;
            }
        }

        protected virtual UltraDateTimeEditor datePickerDATUM
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDATUM;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDATUM = value;
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

        protected virtual UltraLabel label1DATUM
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DATUM;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DATUM = value;
            }
        }

        protected virtual UltraLabel label1SORT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SORT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SORT = value;
            }
        }

        protected virtual UltraLabel label1VRSTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VRSTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VRSTA = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraTextEditor textSORT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSORT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSORT = value;
            }
        }

        protected virtual UltraNumericEditor textVRSTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVRSTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVRSTA = value;
            }
        }

        protected virtual S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIUserDataGrid userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJI = value;
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

