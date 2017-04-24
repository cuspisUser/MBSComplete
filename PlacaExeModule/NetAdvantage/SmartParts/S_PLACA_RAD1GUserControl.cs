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
    public class S_PLACA_RAD1GUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("datePickerDATUMNAKOJIRACUNAMSTAROST")]
        private UltraDateTimeEditor _datePickerDATUMNAKOJIRACUNAMSTAROST;
        [AccessedThroughProperty("label1DATUMNAKOJIRACUNAMSTAROST")]
        private UltraLabel _label1DATUMNAKOJIRACUNAMSTAROST;
        [AccessedThroughProperty("label1GODINAISPLATE")]
        private UltraLabel _label1GODINAISPLATE;
        [AccessedThroughProperty("label1MJESECISPLATE")]
        private UltraLabel _label1MJESECISPLATE;
        [AccessedThroughProperty("label1MJESECODLASKA")]
        private UltraLabel _label1MJESECODLASKA;
        [AccessedThroughProperty("textGODINAISPLATE")]
        private UltraTextEditor _textGODINAISPLATE;
        [AccessedThroughProperty("textMJESECISPLATE")]
        private UltraTextEditor _textMJESECISPLATE;
        [AccessedThroughProperty("textMJESECODLASKA")]
        private UltraTextEditor _textMJESECODLASKA;
        [AccessedThroughProperty("userControlDataGridS_PLACA_RAD1G")]
        private S_PLACA_RAD1GUserDataGrid _userControlDataGridS_PLACA_RAD1G;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_PLACA_RAD1G;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_PLACA_RAD1GUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_PLACA_RAD1GDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_PLACA_RAD1GDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_PLACA_RAD1G.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_PLACA_RAD1GDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_PLACA_RAD1GDataSet>(this.userControlDataGridS_PLACA_RAD1G.DataGrid);
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
            if ((this.userControlDataGridS_PLACA_RAD1G.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_PLACA_RAD1G.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_PLACA_RAD1G.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_PLACA_RAD1G.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_PLACA_RAD1G.DataGrid.FillByPage;
                this.userControlDataGridS_PLACA_RAD1G.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_PLACA_RAD1G.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_PLACA_RAD1G.ParameterGODINAISPLATE = this.textGODINAISPLATE.Text;
                this.userControlDataGridS_PLACA_RAD1G.ParameterMJESECISPLATE = this.textMJESECISPLATE.Text;
                if (this.datePickerDATUMNAKOJIRACUNAMSTAROST.Value == null)
                {
                    this.userControlDataGridS_PLACA_RAD1G.ParameterDATUMNAKOJIRACUNAMSTAROST = DateTime.MinValue;
                }
                else
                {
                    this.userControlDataGridS_PLACA_RAD1G.ParameterDATUMNAKOJIRACUNAMSTAROST = DateTime.Parse(this.datePickerDATUMNAKOJIRACUNAMSTAROST.Value.ToString(), CultureInfo.CurrentCulture);
                }
                this.userControlDataGridS_PLACA_RAD1G.ParameterMJESECODLASKA = this.textMJESECODLASKA.Text;
                this.userControlDataGridS_PLACA_RAD1G.Fill();
                ((S_PLACA_RAD1GWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_PLACA_RAD1G.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("GODINAISPLATE", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("MJESECISPLATE", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("DATUMNAKOJIRACUNAMSTAROST", typeof(DateTime));
            table2.Columns.Add(column);
            column = new DataColumn("MJESECODLASKA", typeof(string));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["GODINAISPLATE"] = this.textGODINAISPLATE.Text;
            row2["MJESECISPLATE"] = this.textMJESECISPLATE.Text;
            if (this.datePickerDATUMNAKOJIRACUNAMSTAROST.Value == null)
            {
                row2["DATUMNAKOJIRACUNAMSTAROST"] = DateTime.MinValue;
            }
            else
            {
                row2["DATUMNAKOJIRACUNAMSTAROST"] = DateTime.Parse(this.datePickerDATUMNAKOJIRACUNAMSTAROST.Value.ToString(), CultureInfo.CurrentCulture);
            }
            row2["MJESECODLASKA"] = this.textMJESECODLASKA.Text;
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
            ResourceManager manager = new ResourceManager(typeof(S_PLACA_RAD1GUserControl));
            this.layoutManagerformS_PLACA_RAD1G = new TableLayoutPanel();
            this.layoutManagerformS_PLACA_RAD1G.SuspendLayout();
            this.layoutManagerformS_PLACA_RAD1G.AutoSize = true;
            this.layoutManagerformS_PLACA_RAD1G.Dock = DockStyle.Fill;
            this.layoutManagerformS_PLACA_RAD1G.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_PLACA_RAD1G.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_PLACA_RAD1G.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_PLACA_RAD1G.Size = size;
            this.layoutManagerformS_PLACA_RAD1G.ColumnCount = 2;
            this.layoutManagerformS_PLACA_RAD1G.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_PLACA_RAD1G.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_PLACA_RAD1G.RowCount = 5;
            this.layoutManagerformS_PLACA_RAD1G.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_PLACA_RAD1G.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_PLACA_RAD1G.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_PLACA_RAD1G.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_PLACA_RAD1G.RowStyles.Add(new RowStyle());
            this.label1GODINAISPLATE = new UltraLabel();
            this.textGODINAISPLATE = new UltraTextEditor();
            this.label1MJESECISPLATE = new UltraLabel();
            this.textMJESECISPLATE = new UltraTextEditor();
            this.label1DATUMNAKOJIRACUNAMSTAROST = new UltraLabel();
            this.datePickerDATUMNAKOJIRACUNAMSTAROST = new UltraDateTimeEditor();
            this.label1MJESECODLASKA = new UltraLabel();
            this.textMJESECODLASKA = new UltraTextEditor();
            this.userControlDataGridS_PLACA_RAD1G = new S_PLACA_RAD1GUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textGODINAISPLATE).BeginInit();
            ((ISupportInitialize) this.textMJESECISPLATE).BeginInit();
            ((ISupportInitialize) this.textMJESECODLASKA).BeginInit();
            this.SuspendLayout();
            this.label1GODINAISPLATE.Name = "label1GODINAISPLATE";
            this.label1GODINAISPLATE.TabIndex = 1;
            this.label1GODINAISPLATE.Tag = "labelGODINAISPLATE";
            this.label1GODINAISPLATE.AutoSize = true;
            this.label1GODINAISPLATE.StyleSetName = "FieldUltraLabel";
            this.label1GODINAISPLATE.Text = "GODINAISPLATE    :";
            this.label1GODINAISPLATE.Appearance.TextVAlign = VAlign.Middle;
            this.label1GODINAISPLATE.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1GODINAISPLATE.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_PLACA_RAD1G.Controls.Add(this.label1GODINAISPLATE, 0, 0);
            this.layoutManagerformS_PLACA_RAD1G.SetColumnSpan(this.label1GODINAISPLATE, 1);
            this.layoutManagerformS_PLACA_RAD1G.SetRowSpan(this.label1GODINAISPLATE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1GODINAISPLATE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1GODINAISPLATE.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textGODINAISPLATE.Location = point;
            this.textGODINAISPLATE.Name = "textGODINAISPLATE";
            this.textGODINAISPLATE.Tag = "GODINAISPLATE";
            this.textGODINAISPLATE.TabIndex = 0;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textGODINAISPLATE.Size = size;
            this.textGODINAISPLATE.MaxLength = 4;
            this.layoutManagerformS_PLACA_RAD1G.Controls.Add(this.textGODINAISPLATE, 1, 0);
            this.layoutManagerformS_PLACA_RAD1G.SetColumnSpan(this.textGODINAISPLATE, 1);
            this.layoutManagerformS_PLACA_RAD1G.SetRowSpan(this.textGODINAISPLATE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textGODINAISPLATE.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textGODINAISPLATE.MinimumSize = size;
            this.label1MJESECISPLATE.Name = "label1MJESECISPLATE";
            this.label1MJESECISPLATE.TabIndex = 1;
            this.label1MJESECISPLATE.Tag = "labelMJESECISPLATE";
            this.label1MJESECISPLATE.AutoSize = true;
            this.label1MJESECISPLATE.StyleSetName = "FieldUltraLabel";
            this.label1MJESECISPLATE.Text = "MJESECISPLATE    :";
            this.label1MJESECISPLATE.Appearance.TextVAlign = VAlign.Middle;
            this.label1MJESECISPLATE.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1MJESECISPLATE.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_PLACA_RAD1G.Controls.Add(this.label1MJESECISPLATE, 0, 1);
            this.layoutManagerformS_PLACA_RAD1G.SetColumnSpan(this.label1MJESECISPLATE, 1);
            this.layoutManagerformS_PLACA_RAD1G.SetRowSpan(this.label1MJESECISPLATE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MJESECISPLATE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MJESECISPLATE.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textMJESECISPLATE.Location = point;
            this.textMJESECISPLATE.Name = "textMJESECISPLATE";
            this.textMJESECISPLATE.Tag = "MJESECISPLATE";
            this.textMJESECISPLATE.TabIndex = 1;
            size = new System.Drawing.Size(30, 0x16);
            this.textMJESECISPLATE.Size = size;
            this.textMJESECISPLATE.MaxLength = 2;
            this.layoutManagerformS_PLACA_RAD1G.Controls.Add(this.textMJESECISPLATE, 1, 1);
            this.layoutManagerformS_PLACA_RAD1G.SetColumnSpan(this.textMJESECISPLATE, 1);
            this.layoutManagerformS_PLACA_RAD1G.SetRowSpan(this.textMJESECISPLATE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMJESECISPLATE.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMJESECISPLATE.MinimumSize = size;
            this.label1DATUMNAKOJIRACUNAMSTAROST.Name = "label1DATUMNAKOJIRACUNAMSTAROST";
            this.label1DATUMNAKOJIRACUNAMSTAROST.TabIndex = 1;
            this.label1DATUMNAKOJIRACUNAMSTAROST.Tag = "labelDATUMNAKOJIRACUNAMSTAROST";
            this.label1DATUMNAKOJIRACUNAMSTAROST.AutoSize = true;
            this.label1DATUMNAKOJIRACUNAMSTAROST.StyleSetName = "FieldUltraLabel";
            this.label1DATUMNAKOJIRACUNAMSTAROST.Text = "DATUMNAKOJIRACUNAMSTAROST    :";
            this.label1DATUMNAKOJIRACUNAMSTAROST.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMNAKOJIRACUNAMSTAROST.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1DATUMNAKOJIRACUNAMSTAROST.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_PLACA_RAD1G.Controls.Add(this.label1DATUMNAKOJIRACUNAMSTAROST, 0, 2);
            this.layoutManagerformS_PLACA_RAD1G.SetColumnSpan(this.label1DATUMNAKOJIRACUNAMSTAROST, 1);
            this.layoutManagerformS_PLACA_RAD1G.SetRowSpan(this.label1DATUMNAKOJIRACUNAMSTAROST, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DATUMNAKOJIRACUNAMSTAROST.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUMNAKOJIRACUNAMSTAROST.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUMNAKOJIRACUNAMSTAROST.Location = point;
            this.datePickerDATUMNAKOJIRACUNAMSTAROST.Name = "datePickerDATUMNAKOJIRACUNAMSTAROST";
            this.datePickerDATUMNAKOJIRACUNAMSTAROST.Tag = "DATUMNAKOJIRACUNAMSTAROST";
            this.datePickerDATUMNAKOJIRACUNAMSTAROST.TabIndex = 2;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMNAKOJIRACUNAMSTAROST.Size = size;
            this.layoutManagerformS_PLACA_RAD1G.Controls.Add(this.datePickerDATUMNAKOJIRACUNAMSTAROST, 1, 2);
            this.layoutManagerformS_PLACA_RAD1G.SetColumnSpan(this.datePickerDATUMNAKOJIRACUNAMSTAROST, 1);
            this.layoutManagerformS_PLACA_RAD1G.SetRowSpan(this.datePickerDATUMNAKOJIRACUNAMSTAROST, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUMNAKOJIRACUNAMSTAROST.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMNAKOJIRACUNAMSTAROST.MinimumSize = size;
            this.label1MJESECODLASKA.Name = "label1MJESECODLASKA";
            this.label1MJESECODLASKA.TabIndex = 1;
            this.label1MJESECODLASKA.Tag = "labelMJESECODLASKA";
            this.label1MJESECODLASKA.AutoSize = true;
            this.label1MJESECODLASKA.StyleSetName = "FieldUltraLabel";
            this.label1MJESECODLASKA.Text = "MJESECODLASKA :";
            this.label1MJESECODLASKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MJESECODLASKA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1MJESECODLASKA.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_PLACA_RAD1G.Controls.Add(this.label1MJESECODLASKA, 0, 3);
            this.layoutManagerformS_PLACA_RAD1G.SetColumnSpan(this.label1MJESECODLASKA, 1);
            this.layoutManagerformS_PLACA_RAD1G.SetRowSpan(this.label1MJESECODLASKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MJESECODLASKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MJESECODLASKA.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textMJESECODLASKA.Location = point;
            this.textMJESECODLASKA.Name = "textMJESECODLASKA";
            this.textMJESECODLASKA.Tag = "MJESECODLASKA";
            this.textMJESECODLASKA.TabIndex = 3;
            size = new System.Drawing.Size(30, 0x16);
            this.textMJESECODLASKA.Size = size;
            this.textMJESECODLASKA.MaxLength = 2;
            this.layoutManagerformS_PLACA_RAD1G.Controls.Add(this.textMJESECODLASKA, 1, 3);
            this.layoutManagerformS_PLACA_RAD1G.SetColumnSpan(this.textMJESECODLASKA, 1);
            this.layoutManagerformS_PLACA_RAD1G.SetRowSpan(this.textMJESECODLASKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMJESECODLASKA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMJESECODLASKA.MinimumSize = size;
            this.layoutManagerformS_PLACA_RAD1G.Controls.Add(this.userControlDataGridS_PLACA_RAD1G, 0, 4);
            this.layoutManagerformS_PLACA_RAD1G.SetColumnSpan(this.userControlDataGridS_PLACA_RAD1G, 2);
            this.layoutManagerformS_PLACA_RAD1G.SetRowSpan(this.userControlDataGridS_PLACA_RAD1G, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_PLACA_RAD1G.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_PLACA_RAD1G.MinimumSize = size;
            this.userControlDataGridS_PLACA_RAD1G.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_PLACA_RAD1G);
            this.userControlDataGridS_PLACA_RAD1G.Name = "userControlDataGridS_PLACA_RAD1G";
            this.userControlDataGridS_PLACA_RAD1G.Dock = DockStyle.Fill;
            this.userControlDataGridS_PLACA_RAD1G.DockPadding.All = 5;
            this.userControlDataGridS_PLACA_RAD1G.FillAtStartup = false;
            this.userControlDataGridS_PLACA_RAD1G.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_PLACA_RAD1G.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_PLACA_RAD1G.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_PLACA_RAD1G.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_PLACA_RAD1GWorkWith";
            this.Text = "Work With S_PLACA_RAD1G";
            this.Load += new EventHandler(this.S_PLACA_RAD1GUserControl_Load);
            this.layoutManagerformS_PLACA_RAD1G.ResumeLayout(false);
            this.layoutManagerformS_PLACA_RAD1G.PerformLayout();
            ((ISupportInitialize) this.textGODINAISPLATE).EndInit();
            ((ISupportInitialize) this.textMJESECISPLATE).EndInit();
            ((ISupportInitialize) this.textMJESECODLASKA).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textGODINAISPLATE.Text = "";
            this.textMJESECISPLATE.Text = "";
            this.datePickerDATUMNAKOJIRACUNAMSTAROST.Text = "";
            this.textMJESECODLASKA.Text = "";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("GODINAISPLATE") && (this.m_FillByRow["GODINAISPLATE"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textGODINAISPLATE, this.m_FillByRow["GODINAISPLATE"].ToString(), this.m_FillByRow.Table.Columns["GODINAISPLATE"].DataType);
                    this.parameterSeted = true;
                    this.textGODINAISPLATE.Visible = false;
                    this.label1GODINAISPLATE.Visible = false;
                    str = str + "," + this.m_FillByRow["GODINAISPLATE"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("MJESECISPLATE") && (this.m_FillByRow["MJESECISPLATE"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textMJESECISPLATE, this.m_FillByRow["MJESECISPLATE"].ToString(), this.m_FillByRow.Table.Columns["MJESECISPLATE"].DataType);
                    this.parameterSeted = true;
                    this.textMJESECISPLATE.Visible = false;
                    this.label1MJESECISPLATE.Visible = false;
                    str = str + "," + this.m_FillByRow["MJESECISPLATE"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("DATUMNAKOJIRACUNAMSTAROST") && (this.m_FillByRow["DATUMNAKOJIRACUNAMSTAROST"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.datePickerDATUMNAKOJIRACUNAMSTAROST, this.m_FillByRow["DATUMNAKOJIRACUNAMSTAROST"].ToString(), this.m_FillByRow.Table.Columns["DATUMNAKOJIRACUNAMSTAROST"].DataType);
                    this.parameterSeted = true;
                    this.datePickerDATUMNAKOJIRACUNAMSTAROST.Visible = false;
                    this.label1DATUMNAKOJIRACUNAMSTAROST.Visible = false;
                    str = str + "," + this.m_FillByRow["DATUMNAKOJIRACUNAMSTAROST"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("MJESECODLASKA") && (this.m_FillByRow["MJESECODLASKA"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textMJESECODLASKA, this.m_FillByRow["MJESECODLASKA"].ToString(), this.m_FillByRow.Table.Columns["MJESECODLASKA"].DataType);
                    this.parameterSeted = true;
                    this.textMJESECODLASKA.Visible = false;
                    this.label1MJESECODLASKA.Visible = false;
                    str = str + "," + this.m_FillByRow["MJESECODLASKA"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_PLACA_RAD1G " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_PLACA_RAD1G " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridS_PLACA_RAD1G.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_PLACA_RAD1G.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_PLACA_RAD1GDataAdapter().Update(this.userControlDataGridS_PLACA_RAD1G.DataGrid.DataSet);
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
            this.label1GODINAISPLATE.Text = StringResources.S_PLACA_RAD1GGODINAISPLATEParameter;
            this.label1MJESECISPLATE.Text = StringResources.S_PLACA_RAD1GMJESECISPLATEParameter;
            this.label1DATUMNAKOJIRACUNAMSTAROST.Text = StringResources.S_PLACA_RAD1GDATUMNAKOJIRACUNAMSTAROSTParameter;
            this.label1MJESECODLASKA.Text = StringResources.S_PLACA_RAD1GMJESECODLASKAParameter;
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

        private void S_PLACA_RAD1GUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_PLACA_RAD1G.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_PLACA_RAD1G.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_PLACA_RAD1G.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_PLACA_RAD1G.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_PLACA_RAD1G.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_PLACA_RAD1G.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_PLACA_RAD1G.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_PLACA_RAD1G.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_PLACA_RAD1G.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_PLACA_RAD1G.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_PLACA_RAD1G.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_PLACA_RAD1G ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_PLACA_RAD1G ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_PLACA_RAD1GController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_PLACA_RAD1G.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_PLACA_RAD1G.DataView[this.userControlDataGridS_PLACA_RAD1G.DataGrid.CurrentRowIndex].Row;
            }
        }

        protected virtual UltraDateTimeEditor datePickerDATUMNAKOJIRACUNAMSTAROST
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDATUMNAKOJIRACUNAMSTAROST;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDATUMNAKOJIRACUNAMSTAROST = value;
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

        protected virtual UltraLabel label1DATUMNAKOJIRACUNAMSTAROST
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DATUMNAKOJIRACUNAMSTAROST;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DATUMNAKOJIRACUNAMSTAROST = value;
            }
        }

        protected virtual UltraLabel label1GODINAISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1GODINAISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1GODINAISPLATE = value;
            }
        }

        protected virtual UltraLabel label1MJESECISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MJESECISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MJESECISPLATE = value;
            }
        }

        protected virtual UltraLabel label1MJESECODLASKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MJESECODLASKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MJESECODLASKA = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraTextEditor textGODINAISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textGODINAISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textGODINAISPLATE = value;
            }
        }

        protected virtual UltraTextEditor textMJESECISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMJESECISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMJESECISPLATE = value;
            }
        }

        protected virtual UltraTextEditor textMJESECODLASKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMJESECODLASKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMJESECODLASKA = value;
            }
        }

        protected virtual S_PLACA_RAD1GUserDataGrid userControlDataGridS_PLACA_RAD1G
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_PLACA_RAD1G;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_PLACA_RAD1G = value;
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

