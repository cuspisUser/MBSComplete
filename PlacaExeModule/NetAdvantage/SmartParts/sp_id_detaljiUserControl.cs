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
    public class sp_id_detaljiUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1godinaISPLATE")]
        private UltraLabel _label1godinaISPLATE;
        [AccessedThroughProperty("label1idobracun")]
        private UltraLabel _label1idobracun;
        [AccessedThroughProperty("label1mjeseCISPLATE")]
        private UltraLabel _label1mjeseCISPLATE;
        [AccessedThroughProperty("label1VOLONTERI")]
        private UltraLabel _label1VOLONTERI;
        [AccessedThroughProperty("textgodinaISPLATE")]
        private UltraTextEditor _textgodinaISPLATE;
        [AccessedThroughProperty("textidobracun")]
        private UltraTextEditor _textidobracun;
        [AccessedThroughProperty("textmjeseCISPLATE")]
        private UltraTextEditor _textmjeseCISPLATE;
        [AccessedThroughProperty("textVOLONTERI")]
        private UltraNumericEditor _textVOLONTERI;
        [AccessedThroughProperty("userControlDataGridsp_id_detalji")]
        private sp_id_detaljiUserDataGrid _userControlDataGridsp_id_detalji;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformsp_id_detalji;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public sp_id_detaljiUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.sp_id_detaljiDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.sp_id_detaljiDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridsp_id_detalji.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<sp_id_detaljiDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<sp_id_detaljiDataSet>(this.userControlDataGridsp_id_detalji.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        private void CallPromptOBRACUNidobracun(object sender, EditorButtonEventArgs e)
        {
            sp_id_detaljiController controller = this.Controller.WorkItem.Items.AddNew<sp_id_detaljiController>();
            DataRow parameterRow = this.GetParameterRow();
            DataRow row = controller.SelectOBRACUNidobracun("", parameterRow);
            if (row != null)
            {
                this.textidobracun.Text = row["IDOBRACUN"].ToString();
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
            if ((this.userControlDataGridsp_id_detalji.DataGrid.Rows.Count > 0) && (this.userControlDataGridsp_id_detalji.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridsp_id_detalji.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridsp_id_detalji.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridsp_id_detalji.DataGrid.FillByPage;
                this.userControlDataGridsp_id_detalji.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridsp_id_detalji.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridsp_id_detalji.Parameteridobracun = this.textidobracun.Text;
                this.userControlDataGridsp_id_detalji.ParametermjeseCISPLATE = this.textmjeseCISPLATE.Text;
                this.userControlDataGridsp_id_detalji.ParametergodinaISPLATE = this.textgodinaISPLATE.Text;
                this.userControlDataGridsp_id_detalji.ParameterVOLONTERI = short.Parse(this.textVOLONTERI.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridsp_id_detalji.Fill();
                ((sp_id_detaljiWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridsp_id_detalji.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("idobracun", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("mjeseCISPLATE", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("godinaISPLATE", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("VOLONTERI", typeof(short));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["idobracun"] = this.textidobracun.Text;
            row2["mjeseCISPLATE"] = this.textmjeseCISPLATE.Text;
            row2["godinaISPLATE"] = this.textgodinaISPLATE.Text;
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
            ResourceManager manager = new ResourceManager(typeof(sp_id_detaljiUserControl));
            this.layoutManagerformsp_id_detalji = new TableLayoutPanel();
            this.layoutManagerformsp_id_detalji.SuspendLayout();
            this.layoutManagerformsp_id_detalji.AutoSize = true;
            this.layoutManagerformsp_id_detalji.Dock = DockStyle.Fill;
            this.layoutManagerformsp_id_detalji.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformsp_id_detalji.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformsp_id_detalji.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformsp_id_detalji.Size = size;
            this.layoutManagerformsp_id_detalji.ColumnCount = 2;
            this.layoutManagerformsp_id_detalji.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformsp_id_detalji.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformsp_id_detalji.RowCount = 5;
            this.layoutManagerformsp_id_detalji.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_id_detalji.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_id_detalji.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_id_detalji.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_id_detalji.RowStyles.Add(new RowStyle());
            this.label1idobracun = new UltraLabel();
            this.textidobracun = new UltraTextEditor();
            this.label1mjeseCISPLATE = new UltraLabel();
            this.textmjeseCISPLATE = new UltraTextEditor();
            this.label1godinaISPLATE = new UltraLabel();
            this.textgodinaISPLATE = new UltraTextEditor();
            this.label1VOLONTERI = new UltraLabel();
            this.textVOLONTERI = new UltraNumericEditor();
            this.userControlDataGridsp_id_detalji = new sp_id_detaljiUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textidobracun).BeginInit();
            ((ISupportInitialize) this.textmjeseCISPLATE).BeginInit();
            ((ISupportInitialize) this.textgodinaISPLATE).BeginInit();
            ((ISupportInitialize) this.textVOLONTERI).BeginInit();
            this.SuspendLayout();
            this.label1idobracun.Name = "label1idobracun";
            this.label1idobracun.TabIndex = 1;
            this.label1idobracun.Tag = "labelidobracun";
            this.label1idobracun.AutoSize = true;
            this.label1idobracun.StyleSetName = "FieldUltraLabel";
            this.label1idobracun.Text = "idobracun    :";
            this.label1idobracun.Appearance.TextVAlign = VAlign.Middle;
            this.label1idobracun.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1idobracun.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_id_detalji.Controls.Add(this.label1idobracun, 0, 0);
            this.layoutManagerformsp_id_detalji.SetColumnSpan(this.label1idobracun, 1);
            this.layoutManagerformsp_id_detalji.SetRowSpan(this.label1idobracun, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1idobracun.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1idobracun.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textidobracun.Location = point;
            this.textidobracun.Name = "textidobracun";
            this.textidobracun.Tag = "idobracun";
            this.textidobracun.TabIndex = 0;
            size = new System.Drawing.Size(0x71, 0x16);
            this.textidobracun.Size = size;
            this.textidobracun.MaxLength = 11;
            EditorButton button = new EditorButton {
                Key = "editorButtonOBRACUNidobracun",
                Tag = "editorButtonOBRACUNidobracun",
                Text = "..."
            };
            this.textidobracun.ButtonsRight.Add(button);
            this.textidobracun.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOBRACUNidobracun);
            this.layoutManagerformsp_id_detalji.Controls.Add(this.textidobracun, 1, 0);
            this.layoutManagerformsp_id_detalji.SetColumnSpan(this.textidobracun, 1);
            this.layoutManagerformsp_id_detalji.SetRowSpan(this.textidobracun, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textidobracun.Margin = padding;
            size = new System.Drawing.Size(0x71, 0x16);
            this.textidobracun.MinimumSize = size;
            this.label1mjeseCISPLATE.Name = "label1mjeseCISPLATE";
            this.label1mjeseCISPLATE.TabIndex = 1;
            this.label1mjeseCISPLATE.Tag = "labelmjeseCISPLATE";
            this.label1mjeseCISPLATE.AutoSize = true;
            this.label1mjeseCISPLATE.StyleSetName = "FieldUltraLabel";
            this.label1mjeseCISPLATE.Text = "mjese CISPLATE    :";
            this.label1mjeseCISPLATE.Appearance.TextVAlign = VAlign.Middle;
            this.label1mjeseCISPLATE.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1mjeseCISPLATE.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_id_detalji.Controls.Add(this.label1mjeseCISPLATE, 0, 1);
            this.layoutManagerformsp_id_detalji.SetColumnSpan(this.label1mjeseCISPLATE, 1);
            this.layoutManagerformsp_id_detalji.SetRowSpan(this.label1mjeseCISPLATE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1mjeseCISPLATE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1mjeseCISPLATE.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textmjeseCISPLATE.Location = point;
            this.textmjeseCISPLATE.Name = "textmjeseCISPLATE";
            this.textmjeseCISPLATE.Tag = "mjeseCISPLATE";
            this.textmjeseCISPLATE.TabIndex = 1;
            size = new System.Drawing.Size(30, 0x16);
            this.textmjeseCISPLATE.Size = size;
            this.textmjeseCISPLATE.MaxLength = 2;
            this.layoutManagerformsp_id_detalji.Controls.Add(this.textmjeseCISPLATE, 1, 1);
            this.layoutManagerformsp_id_detalji.SetColumnSpan(this.textmjeseCISPLATE, 1);
            this.layoutManagerformsp_id_detalji.SetRowSpan(this.textmjeseCISPLATE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textmjeseCISPLATE.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textmjeseCISPLATE.MinimumSize = size;
            this.label1godinaISPLATE.Name = "label1godinaISPLATE";
            this.label1godinaISPLATE.TabIndex = 1;
            this.label1godinaISPLATE.Tag = "labelgodinaISPLATE";
            this.label1godinaISPLATE.AutoSize = true;
            this.label1godinaISPLATE.StyleSetName = "FieldUltraLabel";
            this.label1godinaISPLATE.Text = "godina ISPLATE    :";
            this.label1godinaISPLATE.Appearance.TextVAlign = VAlign.Middle;
            this.label1godinaISPLATE.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1godinaISPLATE.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_id_detalji.Controls.Add(this.label1godinaISPLATE, 0, 2);
            this.layoutManagerformsp_id_detalji.SetColumnSpan(this.label1godinaISPLATE, 1);
            this.layoutManagerformsp_id_detalji.SetRowSpan(this.label1godinaISPLATE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1godinaISPLATE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1godinaISPLATE.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textgodinaISPLATE.Location = point;
            this.textgodinaISPLATE.Name = "textgodinaISPLATE";
            this.textgodinaISPLATE.Tag = "godinaISPLATE";
            this.textgodinaISPLATE.TabIndex = 2;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textgodinaISPLATE.Size = size;
            this.textgodinaISPLATE.MaxLength = 4;
            this.layoutManagerformsp_id_detalji.Controls.Add(this.textgodinaISPLATE, 1, 2);
            this.layoutManagerformsp_id_detalji.SetColumnSpan(this.textgodinaISPLATE, 1);
            this.layoutManagerformsp_id_detalji.SetRowSpan(this.textgodinaISPLATE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textgodinaISPLATE.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textgodinaISPLATE.MinimumSize = size;
            this.label1VOLONTERI.Name = "label1VOLONTERI";
            this.label1VOLONTERI.TabIndex = 1;
            this.label1VOLONTERI.Tag = "labelVOLONTERI";
            this.label1VOLONTERI.AutoSize = true;
            this.label1VOLONTERI.StyleSetName = "FieldUltraLabel";
            this.label1VOLONTERI.Text = "VOLONTERI :";
            this.label1VOLONTERI.Appearance.TextVAlign = VAlign.Middle;
            this.label1VOLONTERI.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1VOLONTERI.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_id_detalji.Controls.Add(this.label1VOLONTERI, 0, 3);
            this.layoutManagerformsp_id_detalji.SetColumnSpan(this.label1VOLONTERI, 1);
            this.layoutManagerformsp_id_detalji.SetRowSpan(this.label1VOLONTERI, 1);
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
            this.layoutManagerformsp_id_detalji.Controls.Add(this.textVOLONTERI, 1, 3);
            this.layoutManagerformsp_id_detalji.SetColumnSpan(this.textVOLONTERI, 1);
            this.layoutManagerformsp_id_detalji.SetRowSpan(this.textVOLONTERI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVOLONTERI.Margin = padding;
            size = new System.Drawing.Size(0x18, 0x16);
            this.textVOLONTERI.MinimumSize = size;
            this.layoutManagerformsp_id_detalji.Controls.Add(this.userControlDataGridsp_id_detalji, 0, 4);
            this.layoutManagerformsp_id_detalji.SetColumnSpan(this.userControlDataGridsp_id_detalji, 2);
            this.layoutManagerformsp_id_detalji.SetRowSpan(this.userControlDataGridsp_id_detalji, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridsp_id_detalji.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridsp_id_detalji.MinimumSize = size;
            this.userControlDataGridsp_id_detalji.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformsp_id_detalji);
            this.userControlDataGridsp_id_detalji.Name = "userControlDataGridsp_id_detalji";
            this.userControlDataGridsp_id_detalji.Dock = DockStyle.Fill;
            this.userControlDataGridsp_id_detalji.DockPadding.All = 5;
            this.userControlDataGridsp_id_detalji.FillAtStartup = false;
            this.userControlDataGridsp_id_detalji.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridsp_id_detalji.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridsp_id_detalji.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridsp_id_detalji.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "sp_id_detaljiWorkWith";
            this.Text = "Work With sp_id_detalji";
            this.Load += new EventHandler(this.sp_id_detaljiUserControl_Load);
            this.layoutManagerformsp_id_detalji.ResumeLayout(false);
            this.layoutManagerformsp_id_detalji.PerformLayout();
            ((ISupportInitialize) this.textidobracun).EndInit();
            ((ISupportInitialize) this.textmjeseCISPLATE).EndInit();
            ((ISupportInitialize) this.textgodinaISPLATE).EndInit();
            ((ISupportInitialize) this.textVOLONTERI).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textidobracun.Text = "";
            this.textmjeseCISPLATE.Text = "";
            this.textgodinaISPLATE.Text = "";
            this.textVOLONTERI.Text = "0";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("idobracun") && (this.m_FillByRow["idobracun"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textidobracun, this.m_FillByRow["idobracun"].ToString(), this.m_FillByRow.Table.Columns["idobracun"].DataType);
                    this.parameterSeted = true;
                    this.textidobracun.Visible = false;
                    this.label1idobracun.Visible = false;
                    str = str + "," + this.m_FillByRow["idobracun"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("mjeseCISPLATE") && (this.m_FillByRow["mjeseCISPLATE"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textmjeseCISPLATE, this.m_FillByRow["mjeseCISPLATE"].ToString(), this.m_FillByRow.Table.Columns["mjeseCISPLATE"].DataType);
                    this.parameterSeted = true;
                    this.textmjeseCISPLATE.Visible = false;
                    this.label1mjeseCISPLATE.Visible = false;
                    str = str + "," + this.m_FillByRow["mjeseCISPLATE"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("godinaISPLATE") && (this.m_FillByRow["godinaISPLATE"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textgodinaISPLATE, this.m_FillByRow["godinaISPLATE"].ToString(), this.m_FillByRow.Table.Columns["godinaISPLATE"].DataType);
                    this.parameterSeted = true;
                    this.textgodinaISPLATE.Visible = false;
                    this.label1godinaISPLATE.Visible = false;
                    str = str + "," + this.m_FillByRow["godinaISPLATE"].ToString() + " ";
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
                        this.Text = Deklarit.Resources.Resources.Select + "sp_id_detalji " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "sp_id_detalji " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridsp_id_detalji.DataGrid.DataSet.Clear();
                    this.userControlDataGridsp_id_detalji.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new sp_id_detaljiDataAdapter().Update(this.userControlDataGridsp_id_detalji.DataGrid.DataSet);
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
            this.label1idobracun.Text = StringResources.sp_id_detaljiidobracunParameter;
            this.label1mjeseCISPLATE.Text = StringResources.sp_id_detaljimjeseCISPLATEParameter;
            this.label1godinaISPLATE.Text = StringResources.sp_id_detaljigodinaISPLATEParameter;
            this.label1VOLONTERI.Text = StringResources.sp_id_detaljiVOLONTERIParameter;
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
                this.userControlDataGridsp_id_detalji.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridsp_id_detalji.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} sp_id_detalji ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} sp_id_detalji ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void sp_id_detaljiUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridsp_id_detalji.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridsp_id_detalji.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridsp_id_detalji.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridsp_id_detalji.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridsp_id_detalji.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridsp_id_detalji.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridsp_id_detalji.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridsp_id_detalji.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridsp_id_detalji.DataGrid.FillByPage = true;
                this.FillData();
            }
        }

        [CreateNew]
        public sp_id_detaljiController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridsp_id_detalji.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridsp_id_detalji.DataView[this.userControlDataGridsp_id_detalji.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1godinaISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1godinaISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1godinaISPLATE = value;
            }
        }

        protected virtual UltraLabel label1idobracun
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1idobracun;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1idobracun = value;
            }
        }

        protected virtual UltraLabel label1mjeseCISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1mjeseCISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1mjeseCISPLATE = value;
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

        protected virtual UltraTextEditor textgodinaISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textgodinaISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textgodinaISPLATE = value;
            }
        }

        protected virtual UltraTextEditor textidobracun
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textidobracun;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textidobracun = value;
            }
        }

        protected virtual UltraTextEditor textmjeseCISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textmjeseCISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textmjeseCISPLATE = value;
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

        protected virtual sp_id_detaljiUserDataGrid userControlDataGridsp_id_detalji
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridsp_id_detalji;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridsp_id_detalji = value;
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

