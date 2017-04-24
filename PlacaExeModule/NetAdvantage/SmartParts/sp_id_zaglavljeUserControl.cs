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
    public class sp_id_zaglavljeUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1GODINAISPLATE")]
        private UltraLabel _label1GODINAISPLATE;
        [AccessedThroughProperty("label1IDOBRACUN")]
        private UltraLabel _label1IDOBRACUN;
        [AccessedThroughProperty("label1MJESECISPLATE")]
        private UltraLabel _label1MJESECISPLATE;
        [AccessedThroughProperty("label1VOLONTERI")]
        private UltraLabel _label1VOLONTERI;
        [AccessedThroughProperty("textGODINAISPLATE")]
        private UltraTextEditor _textGODINAISPLATE;
        [AccessedThroughProperty("textIDOBRACUN")]
        private UltraTextEditor _textIDOBRACUN;
        [AccessedThroughProperty("textMJESECISPLATE")]
        private UltraTextEditor _textMJESECISPLATE;
        [AccessedThroughProperty("textVOLONTERI")]
        private UltraNumericEditor _textVOLONTERI;
        [AccessedThroughProperty("userControlDataGridsp_id_zaglavlje")]
        private sp_id_zaglavljeUserDataGrid _userControlDataGridsp_id_zaglavlje;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformsp_id_zaglavlje;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public sp_id_zaglavljeUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.sp_id_zaglavljeDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.sp_id_zaglavljeDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridsp_id_zaglavlje.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<sp_id_zaglavljeDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<sp_id_zaglavljeDataSet>(this.userControlDataGridsp_id_zaglavlje.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        private void CallPromptOBRACUNIDOBRACUN(object sender, EditorButtonEventArgs e)
        {
            sp_id_zaglavljeController controller = this.Controller.WorkItem.Items.AddNew<sp_id_zaglavljeController>();
            DataRow parameterRow = this.GetParameterRow();
            DataRow row = controller.SelectOBRACUNIDOBRACUN("", parameterRow);
            if (row != null)
            {
                this.textIDOBRACUN.Text = row["IDOBRACUN"].ToString();
            }
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
            if ((this.userControlDataGridsp_id_zaglavlje.DataGrid.Rows.Count > 0) && (this.userControlDataGridsp_id_zaglavlje.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridsp_id_zaglavlje.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridsp_id_zaglavlje.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridsp_id_zaglavlje.DataGrid.FillByPage;
                this.userControlDataGridsp_id_zaglavlje.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridsp_id_zaglavlje.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridsp_id_zaglavlje.ParameterIDOBRACUN = this.textIDOBRACUN.Text;
                this.userControlDataGridsp_id_zaglavlje.ParameterMJESECISPLATE = this.textMJESECISPLATE.Text;
                this.userControlDataGridsp_id_zaglavlje.ParameterGODINAISPLATE = this.textGODINAISPLATE.Text;
                this.userControlDataGridsp_id_zaglavlje.ParameterVOLONTERI = short.Parse(this.textVOLONTERI.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridsp_id_zaglavlje.Fill();
                ((sp_id_zaglavljeWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridsp_id_zaglavlje.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("IDOBRACUN", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("MJESECISPLATE", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("GODINAISPLATE", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("VOLONTERI", typeof(short));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["IDOBRACUN"] = this.textIDOBRACUN.Text;
            row2["MJESECISPLATE"] = this.textMJESECISPLATE.Text;
            row2["GODINAISPLATE"] = this.textGODINAISPLATE.Text;
            row2["VOLONTERI"] = short.Parse(this.textVOLONTERI.Value.ToString(), CultureInfo.CurrentCulture);
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
            ResourceManager manager = new ResourceManager(typeof(sp_id_zaglavljeUserControl));
            this.layoutManagerformsp_id_zaglavlje = new TableLayoutPanel();
            this.layoutManagerformsp_id_zaglavlje.SuspendLayout();
            this.layoutManagerformsp_id_zaglavlje.AutoSize = true;
            this.layoutManagerformsp_id_zaglavlje.Dock = DockStyle.Fill;
            this.layoutManagerformsp_id_zaglavlje.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformsp_id_zaglavlje.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformsp_id_zaglavlje.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformsp_id_zaglavlje.Size = size;
            this.layoutManagerformsp_id_zaglavlje.ColumnCount = 2;
            this.layoutManagerformsp_id_zaglavlje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformsp_id_zaglavlje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformsp_id_zaglavlje.RowCount = 5;
            this.layoutManagerformsp_id_zaglavlje.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_id_zaglavlje.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_id_zaglavlje.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_id_zaglavlje.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_id_zaglavlje.RowStyles.Add(new RowStyle());
            this.label1IDOBRACUN = new UltraLabel();
            this.textIDOBRACUN = new UltraTextEditor();
            this.label1MJESECISPLATE = new UltraLabel();
            this.textMJESECISPLATE = new UltraTextEditor();
            this.label1GODINAISPLATE = new UltraLabel();
            this.textGODINAISPLATE = new UltraTextEditor();
            this.label1VOLONTERI = new UltraLabel();
            this.textVOLONTERI = new UltraNumericEditor();
            this.userControlDataGridsp_id_zaglavlje = new sp_id_zaglavljeUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textIDOBRACUN).BeginInit();
            ((ISupportInitialize) this.textMJESECISPLATE).BeginInit();
            ((ISupportInitialize) this.textGODINAISPLATE).BeginInit();
            ((ISupportInitialize) this.textVOLONTERI).BeginInit();
            this.SuspendLayout();
            this.label1IDOBRACUN.Name = "label1IDOBRACUN";
            this.label1IDOBRACUN.TabIndex = 1;
            this.label1IDOBRACUN.Tag = "labelIDOBRACUN";
            this.label1IDOBRACUN.AutoSize = true;
            this.label1IDOBRACUN.StyleSetName = "FieldUltraLabel";
            this.label1IDOBRACUN.Text = "IDOBRACUN           :";
            this.label1IDOBRACUN.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOBRACUN.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1IDOBRACUN.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_id_zaglavlje.Controls.Add(this.label1IDOBRACUN, 0, 0);
            this.layoutManagerformsp_id_zaglavlje.SetColumnSpan(this.label1IDOBRACUN, 1);
            this.layoutManagerformsp_id_zaglavlje.SetRowSpan(this.label1IDOBRACUN, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDOBRACUN.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDOBRACUN.Location = point;
            this.textIDOBRACUN.Name = "textIDOBRACUN";
            this.textIDOBRACUN.Tag = "IDOBRACUN";
            this.textIDOBRACUN.TabIndex = 0;
            size = new System.Drawing.Size(0x71, 0x16);
            this.textIDOBRACUN.Size = size;
            this.textIDOBRACUN.MaxLength = 11;
            EditorButton button = new EditorButton {
                Key = "editorButtonOBRACUNIDOBRACUN",
                Tag = "editorButtonOBRACUNIDOBRACUN",
                Text = "..."
            };
            this.textIDOBRACUN.ButtonsRight.Add(button);
            this.textIDOBRACUN.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOBRACUNIDOBRACUN);
            this.layoutManagerformsp_id_zaglavlje.Controls.Add(this.textIDOBRACUN, 1, 0);
            this.layoutManagerformsp_id_zaglavlje.SetColumnSpan(this.textIDOBRACUN, 1);
            this.layoutManagerformsp_id_zaglavlje.SetRowSpan(this.textIDOBRACUN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0x71, 0x16);
            this.textIDOBRACUN.MinimumSize = size;
            this.label1MJESECISPLATE.Name = "label1MJESECISPLATE";
            this.label1MJESECISPLATE.TabIndex = 1;
            this.label1MJESECISPLATE.Tag = "labelMJESECISPLATE";
            this.label1MJESECISPLATE.AutoSize = true;
            this.label1MJESECISPLATE.StyleSetName = "FieldUltraLabel";
            this.label1MJESECISPLATE.Text = "MJESECISPLATE           :";
            this.label1MJESECISPLATE.Appearance.TextVAlign = VAlign.Middle;
            this.label1MJESECISPLATE.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1MJESECISPLATE.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_id_zaglavlje.Controls.Add(this.label1MJESECISPLATE, 0, 1);
            this.layoutManagerformsp_id_zaglavlje.SetColumnSpan(this.label1MJESECISPLATE, 1);
            this.layoutManagerformsp_id_zaglavlje.SetRowSpan(this.label1MJESECISPLATE, 1);
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
            this.layoutManagerformsp_id_zaglavlje.Controls.Add(this.textMJESECISPLATE, 1, 1);
            this.layoutManagerformsp_id_zaglavlje.SetColumnSpan(this.textMJESECISPLATE, 1);
            this.layoutManagerformsp_id_zaglavlje.SetRowSpan(this.textMJESECISPLATE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMJESECISPLATE.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMJESECISPLATE.MinimumSize = size;
            this.label1GODINAISPLATE.Name = "label1GODINAISPLATE";
            this.label1GODINAISPLATE.TabIndex = 1;
            this.label1GODINAISPLATE.Tag = "labelGODINAISPLATE";
            this.label1GODINAISPLATE.AutoSize = true;
            this.label1GODINAISPLATE.StyleSetName = "FieldUltraLabel";
            this.label1GODINAISPLATE.Text = "GODINAISPLATE           :";
            this.label1GODINAISPLATE.Appearance.TextVAlign = VAlign.Middle;
            this.label1GODINAISPLATE.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1GODINAISPLATE.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_id_zaglavlje.Controls.Add(this.label1GODINAISPLATE, 0, 2);
            this.layoutManagerformsp_id_zaglavlje.SetColumnSpan(this.label1GODINAISPLATE, 1);
            this.layoutManagerformsp_id_zaglavlje.SetRowSpan(this.label1GODINAISPLATE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1GODINAISPLATE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1GODINAISPLATE.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textGODINAISPLATE.Location = point;
            this.textGODINAISPLATE.Name = "textGODINAISPLATE";
            this.textGODINAISPLATE.Tag = "GODINAISPLATE";
            this.textGODINAISPLATE.TabIndex = 2;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textGODINAISPLATE.Size = size;
            this.textGODINAISPLATE.MaxLength = 4;
            this.layoutManagerformsp_id_zaglavlje.Controls.Add(this.textGODINAISPLATE, 1, 2);
            this.layoutManagerformsp_id_zaglavlje.SetColumnSpan(this.textGODINAISPLATE, 1);
            this.layoutManagerformsp_id_zaglavlje.SetRowSpan(this.textGODINAISPLATE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textGODINAISPLATE.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textGODINAISPLATE.MinimumSize = size;
            this.label1VOLONTERI.Name = "label1VOLONTERI";
            this.label1VOLONTERI.TabIndex = 1;
            this.label1VOLONTERI.Tag = "labelVOLONTERI";
            this.label1VOLONTERI.AutoSize = true;
            this.label1VOLONTERI.StyleSetName = "FieldUltraLabel";
            this.label1VOLONTERI.Text = "VOLONTERI  :";
            this.label1VOLONTERI.Appearance.TextVAlign = VAlign.Middle;
            this.label1VOLONTERI.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1VOLONTERI.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_id_zaglavlje.Controls.Add(this.label1VOLONTERI, 0, 3);
            this.layoutManagerformsp_id_zaglavlje.SetColumnSpan(this.label1VOLONTERI, 1);
            this.layoutManagerformsp_id_zaglavlje.SetRowSpan(this.label1VOLONTERI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VOLONTERI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VOLONTERI.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textVOLONTERI.Location = point;
            this.textVOLONTERI.Name = "textVOLONTERI";
            this.textVOLONTERI.Tag = "VOLONTERI";
            this.textVOLONTERI.TabIndex = 3;
            size = new System.Drawing.Size(0x18, 0x16);
            this.textVOLONTERI.Size = size;
            this.textVOLONTERI.PromptChar = ' ';
            this.textVOLONTERI.Enter += new EventHandler(this.numericEditor_Enter);
            this.textVOLONTERI.NumericType = NumericType.Integer;
            this.textVOLONTERI.MaskInput = "{LOC}-n";
            this.layoutManagerformsp_id_zaglavlje.Controls.Add(this.textVOLONTERI, 1, 3);
            this.layoutManagerformsp_id_zaglavlje.SetColumnSpan(this.textVOLONTERI, 1);
            this.layoutManagerformsp_id_zaglavlje.SetRowSpan(this.textVOLONTERI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVOLONTERI.Margin = padding;
            size = new System.Drawing.Size(0x18, 0x16);
            this.textVOLONTERI.MinimumSize = size;
            this.layoutManagerformsp_id_zaglavlje.Controls.Add(this.userControlDataGridsp_id_zaglavlje, 0, 4);
            this.layoutManagerformsp_id_zaglavlje.SetColumnSpan(this.userControlDataGridsp_id_zaglavlje, 2);
            this.layoutManagerformsp_id_zaglavlje.SetRowSpan(this.userControlDataGridsp_id_zaglavlje, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridsp_id_zaglavlje.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridsp_id_zaglavlje.MinimumSize = size;
            this.userControlDataGridsp_id_zaglavlje.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformsp_id_zaglavlje);
            this.userControlDataGridsp_id_zaglavlje.Name = "userControlDataGridsp_id_zaglavlje";
            this.userControlDataGridsp_id_zaglavlje.Dock = DockStyle.Fill;
            this.userControlDataGridsp_id_zaglavlje.DockPadding.All = 5;
            this.userControlDataGridsp_id_zaglavlje.FillAtStartup = false;
            this.userControlDataGridsp_id_zaglavlje.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridsp_id_zaglavlje.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridsp_id_zaglavlje.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridsp_id_zaglavlje.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "sp_id_zaglavljeWorkWith";
            this.Text = "Work With sp_id_zaglavlje";
            this.Load += new EventHandler(this.sp_id_zaglavljeUserControl_Load);
            this.layoutManagerformsp_id_zaglavlje.ResumeLayout(false);
            this.layoutManagerformsp_id_zaglavlje.PerformLayout();
            ((ISupportInitialize) this.textIDOBRACUN).EndInit();
            ((ISupportInitialize) this.textMJESECISPLATE).EndInit();
            ((ISupportInitialize) this.textGODINAISPLATE).EndInit();
            ((ISupportInitialize) this.textVOLONTERI).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textIDOBRACUN.Text = "";
            this.textMJESECISPLATE.Text = "";
            this.textGODINAISPLATE.Text = "";
            this.textVOLONTERI.Text = "0";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("IDOBRACUN") && (this.m_FillByRow["IDOBRACUN"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textIDOBRACUN, this.m_FillByRow["IDOBRACUN"].ToString(), this.m_FillByRow.Table.Columns["IDOBRACUN"].DataType);
                    this.parameterSeted = true;
                    this.textIDOBRACUN.Visible = false;
                    this.label1IDOBRACUN.Visible = false;
                    str = str + "," + this.m_FillByRow["IDOBRACUN"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("MJESECISPLATE") && (this.m_FillByRow["MJESECISPLATE"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textMJESECISPLATE, this.m_FillByRow["MJESECISPLATE"].ToString(), this.m_FillByRow.Table.Columns["MJESECISPLATE"].DataType);
                    this.parameterSeted = true;
                    this.textMJESECISPLATE.Visible = false;
                    this.label1MJESECISPLATE.Visible = false;
                    str = str + "," + this.m_FillByRow["MJESECISPLATE"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("GODINAISPLATE") && (this.m_FillByRow["GODINAISPLATE"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textGODINAISPLATE, this.m_FillByRow["GODINAISPLATE"].ToString(), this.m_FillByRow.Table.Columns["GODINAISPLATE"].DataType);
                    this.parameterSeted = true;
                    this.textGODINAISPLATE.Visible = false;
                    this.label1GODINAISPLATE.Visible = false;
                    str = str + "," + this.m_FillByRow["GODINAISPLATE"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("VOLONTERI") && (this.m_FillByRow["VOLONTERI"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textVOLONTERI, this.m_FillByRow["VOLONTERI"].ToString(), this.m_FillByRow.Table.Columns["VOLONTERI"].DataType);
                    this.parameterSeted = true;
                    this.textVOLONTERI.Visible = false;
                    this.label1VOLONTERI.Visible = false;
                    str = str + "," + this.m_FillByRow["VOLONTERI"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "sp_id_zaglavlje " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "sp_id_zaglavlje " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridsp_id_zaglavlje.DataGrid.DataSet.Clear();
                    this.userControlDataGridsp_id_zaglavlje.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new sp_id_zaglavljeDataAdapter().Update(this.userControlDataGridsp_id_zaglavlje.DataGrid.DataSet);
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
            this.label1IDOBRACUN.Text = StringResources.sp_id_zaglavljeIDOBRACUNParameter;
            this.label1MJESECISPLATE.Text = StringResources.sp_id_zaglavljeMJESECISPLATEParameter;
            this.label1GODINAISPLATE.Text = StringResources.sp_id_zaglavljeGODINAISPLATEParameter;
            this.label1VOLONTERI.Text = StringResources.sp_id_zaglavljeVOLONTERIParameter;
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

        [LocalCommandHandler("ExportXml")]
        public void SaveToXml(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog {
                DefaultExt = "xml",
                Filter = "XML file (*.xml)|*.xml"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.userControlDataGridsp_id_zaglavlje.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridsp_id_zaglavlje.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} sp_id_zaglavlje ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} sp_id_zaglavlje ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void sp_id_zaglavljeUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridsp_id_zaglavlje.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridsp_id_zaglavlje.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridsp_id_zaglavlje.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridsp_id_zaglavlje.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridsp_id_zaglavlje.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridsp_id_zaglavlje.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridsp_id_zaglavlje.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridsp_id_zaglavlje.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridsp_id_zaglavlje.DataGrid.FillByPage = true;
                this.FillData();
            }
        }

        [CreateNew]
        public sp_id_zaglavljeController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridsp_id_zaglavlje.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridsp_id_zaglavlje.DataView[this.userControlDataGridsp_id_zaglavlje.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1IDOBRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDOBRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDOBRACUN = value;
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

        protected virtual UltraLabel label1VOLONTERI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VOLONTERI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VOLONTERI = value;
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

        protected virtual UltraTextEditor textIDOBRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDOBRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDOBRACUN = value;
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

        protected virtual UltraNumericEditor textVOLONTERI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVOLONTERI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVOLONTERI = value;
            }
        }

        protected virtual sp_id_zaglavljeUserDataGrid userControlDataGridsp_id_zaglavlje
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridsp_id_zaglavlje;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridsp_id_zaglavlje = value;
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

