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
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class sp_VIRMANIUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1dd")]
        private UltraLabel _label1dd;
        [AccessedThroughProperty("label1IDOBRACUN")]
        private UltraLabel _label1IDOBRACUN;
        [AccessedThroughProperty("label1mb")]
        private UltraLabel _label1mb;
        [AccessedThroughProperty("label1pl1")]
        private UltraLabel _label1pl1;
        [AccessedThroughProperty("label1pl2")]
        private UltraLabel _label1pl2;
        [AccessedThroughProperty("label1pl3")]
        private UltraLabel _label1pl3;
        [AccessedThroughProperty("label1poreziprirezodvojeno")]
        private UltraLabel _label1poreziprirezodvojeno;
        [AccessedThroughProperty("label1vbd")]
        private UltraLabel _label1vbd;
        [AccessedThroughProperty("label1zaduzenje")]
        private UltraLabel _label1zaduzenje;
        [AccessedThroughProperty("label1zrn")]
        private UltraLabel _label1zrn;
        [AccessedThroughProperty("textdd")]
        private UltraTextEditor _textdd;
        [AccessedThroughProperty("textIDOBRACUN")]
        private UltraTextEditor _textIDOBRACUN;
        [AccessedThroughProperty("textmb")]
        private UltraTextEditor _textmb;
        [AccessedThroughProperty("textpl1")]
        private UltraTextEditor _textpl1;
        [AccessedThroughProperty("textpl2")]
        private UltraTextEditor _textpl2;
        [AccessedThroughProperty("textpl3")]
        private UltraTextEditor _textpl3;
        [AccessedThroughProperty("textporeziprirezodvojeno")]
        private UltraTextEditor _textporeziprirezodvojeno;
        [AccessedThroughProperty("textvbd")]
        private UltraTextEditor _textvbd;
        [AccessedThroughProperty("textzaduzenje")]
        private UltraTextEditor _textzaduzenje;
        [AccessedThroughProperty("textzrn")]
        private UltraTextEditor _textzrn;
        [AccessedThroughProperty("userControlDataGridsp_VIRMANI")]
        private sp_VIRMANIUserDataGrid _userControlDataGridsp_VIRMANI;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformsp_VIRMANI;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public sp_VIRMANIUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.sp_VIRMANIDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.sp_VIRMANIDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridsp_VIRMANI.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<sp_VIRMANIDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<sp_VIRMANIDataSet>(this.userControlDataGridsp_VIRMANI.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        private void CallPromptOBRACUNIDOBRACUN(object sender, EditorButtonEventArgs e)
        {
            sp_VIRMANIController controller = this.Controller.WorkItem.Items.AddNew<sp_VIRMANIController>();
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
            if ((this.userControlDataGridsp_VIRMANI.DataGrid.Rows.Count > 0) && (this.userControlDataGridsp_VIRMANI.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridsp_VIRMANI.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridsp_VIRMANI.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridsp_VIRMANI.DataGrid.FillByPage;
                this.userControlDataGridsp_VIRMANI.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridsp_VIRMANI.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridsp_VIRMANI.ParameterIDOBRACUN = this.textIDOBRACUN.Text;
                this.userControlDataGridsp_VIRMANI.Parameterzaduzenje = this.textzaduzenje.Text;
                this.userControlDataGridsp_VIRMANI.Parameterporeziprirezodvojeno = this.textporeziprirezodvojeno.Text;
                this.userControlDataGridsp_VIRMANI.Parameterpl1 = this.textpl1.Text;
                this.userControlDataGridsp_VIRMANI.Parameterpl2 = this.textpl2.Text;
                this.userControlDataGridsp_VIRMANI.Parameterpl3 = this.textpl3.Text;
                this.userControlDataGridsp_VIRMANI.Parametervbd = this.textvbd.Text;
                this.userControlDataGridsp_VIRMANI.Parameterzrn = this.textzrn.Text;
                this.userControlDataGridsp_VIRMANI.Parametermb = this.textmb.Text;
                this.userControlDataGridsp_VIRMANI.Parameterdd = this.textdd.Text;
                this.userControlDataGridsp_VIRMANI.Fill();
                ((sp_VIRMANIWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridsp_VIRMANI.DataView.Table.DataSet;
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
            column = new DataColumn("zaduzenje", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("poreziprirezodvojeno", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("pl1", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("pl2", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("pl3", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("vbd", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("zrn", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("mb", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("dd", typeof(string));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["IDOBRACUN"] = this.textIDOBRACUN.Text;
            row2["zaduzenje"] = this.textzaduzenje.Text;
            row2["poreziprirezodvojeno"] = this.textporeziprirezodvojeno.Text;
            row2["pl1"] = this.textpl1.Text;
            row2["pl2"] = this.textpl2.Text;
            row2["pl3"] = this.textpl3.Text;
            row2["vbd"] = this.textvbd.Text;
            row2["zrn"] = this.textzrn.Text;
            row2["mb"] = this.textmb.Text;
            row2["dd"] = this.textdd.Text;
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
            ResourceManager manager = new ResourceManager(typeof(sp_VIRMANIUserControl));
            this.layoutManagerformsp_VIRMANI = new TableLayoutPanel();
            this.layoutManagerformsp_VIRMANI.SuspendLayout();
            this.layoutManagerformsp_VIRMANI.AutoSize = true;
            this.layoutManagerformsp_VIRMANI.Dock = DockStyle.Fill;
            this.layoutManagerformsp_VIRMANI.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformsp_VIRMANI.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformsp_VIRMANI.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformsp_VIRMANI.Size = size;
            this.layoutManagerformsp_VIRMANI.ColumnCount = 2;
            this.layoutManagerformsp_VIRMANI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformsp_VIRMANI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformsp_VIRMANI.RowCount = 11;
            this.layoutManagerformsp_VIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_VIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_VIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_VIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_VIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_VIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_VIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_VIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_VIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_VIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_VIRMANI.RowStyles.Add(new RowStyle());
            this.label1IDOBRACUN = new UltraLabel();
            this.textIDOBRACUN = new UltraTextEditor();
            this.label1zaduzenje = new UltraLabel();
            this.textzaduzenje = new UltraTextEditor();
            this.label1poreziprirezodvojeno = new UltraLabel();
            this.textporeziprirezodvojeno = new UltraTextEditor();
            this.label1pl1 = new UltraLabel();
            this.textpl1 = new UltraTextEditor();
            this.label1pl2 = new UltraLabel();
            this.textpl2 = new UltraTextEditor();
            this.label1pl3 = new UltraLabel();
            this.textpl3 = new UltraTextEditor();
            this.label1vbd = new UltraLabel();
            this.textvbd = new UltraTextEditor();
            this.label1zrn = new UltraLabel();
            this.textzrn = new UltraTextEditor();
            this.label1mb = new UltraLabel();
            this.textmb = new UltraTextEditor();
            this.label1dd = new UltraLabel();
            this.textdd = new UltraTextEditor();
            this.userControlDataGridsp_VIRMANI = new sp_VIRMANIUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textIDOBRACUN).BeginInit();
            ((ISupportInitialize) this.textzaduzenje).BeginInit();
            ((ISupportInitialize) this.textporeziprirezodvojeno).BeginInit();
            ((ISupportInitialize) this.textpl1).BeginInit();
            ((ISupportInitialize) this.textpl2).BeginInit();
            ((ISupportInitialize) this.textpl3).BeginInit();
            ((ISupportInitialize) this.textvbd).BeginInit();
            ((ISupportInitialize) this.textzrn).BeginInit();
            ((ISupportInitialize) this.textmb).BeginInit();
            ((ISupportInitialize) this.textdd).BeginInit();
            this.SuspendLayout();
            this.label1IDOBRACUN.Name = "label1IDOBRACUN";
            this.label1IDOBRACUN.TabIndex = 1;
            this.label1IDOBRACUN.Tag = "labelIDOBRACUN";
            this.label1IDOBRACUN.AutoSize = true;
            this.label1IDOBRACUN.StyleSetName = "FieldUltraLabel";
            this.label1IDOBRACUN.Text = "IDOBRACUN            :";
            this.label1IDOBRACUN.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOBRACUN.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1IDOBRACUN.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.label1IDOBRACUN, 0, 0);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.label1IDOBRACUN, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.label1IDOBRACUN, 1);
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
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.textIDOBRACUN, 1, 0);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.textIDOBRACUN, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.textIDOBRACUN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0x71, 0x16);
            this.textIDOBRACUN.MinimumSize = size;
            this.label1zaduzenje.Name = "label1zaduzenje";
            this.label1zaduzenje.TabIndex = 1;
            this.label1zaduzenje.Tag = "labelzaduzenje";
            this.label1zaduzenje.AutoSize = true;
            this.label1zaduzenje.StyleSetName = "FieldUltraLabel";
            this.label1zaduzenje.Text = "zaduzenje       :";
            this.label1zaduzenje.Appearance.TextVAlign = VAlign.Middle;
            this.label1zaduzenje.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1zaduzenje.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.label1zaduzenje, 0, 1);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.label1zaduzenje, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.label1zaduzenje, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1zaduzenje.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1zaduzenje.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textzaduzenje.Location = point;
            this.textzaduzenje.Name = "textzaduzenje";
            this.textzaduzenje.Tag = "zaduzenje";
            this.textzaduzenje.TabIndex = 1;
            size = new System.Drawing.Size(0x17, 0x16);
            this.textzaduzenje.Size = size;
            this.textzaduzenje.MaxLength = 1;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.textzaduzenje, 1, 1);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.textzaduzenje, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.textzaduzenje, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textzaduzenje.Margin = padding;
            size = new System.Drawing.Size(0x17, 0x16);
            this.textzaduzenje.MinimumSize = size;
            this.label1poreziprirezodvojeno.Name = "label1poreziprirezodvojeno";
            this.label1poreziprirezodvojeno.TabIndex = 1;
            this.label1poreziprirezodvojeno.Tag = "labelporeziprirezodvojeno";
            this.label1poreziprirezodvojeno.AutoSize = true;
            this.label1poreziprirezodvojeno.StyleSetName = "FieldUltraLabel";
            this.label1poreziprirezodvojeno.Text = "poreziprirezodvojeno           :";
            this.label1poreziprirezodvojeno.Appearance.TextVAlign = VAlign.Middle;
            this.label1poreziprirezodvojeno.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1poreziprirezodvojeno.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.label1poreziprirezodvojeno, 0, 2);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.label1poreziprirezodvojeno, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.label1poreziprirezodvojeno, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1poreziprirezodvojeno.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1poreziprirezodvojeno.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textporeziprirezodvojeno.Location = point;
            this.textporeziprirezodvojeno.Name = "textporeziprirezodvojeno";
            this.textporeziprirezodvojeno.Tag = "poreziprirezodvojeno";
            this.textporeziprirezodvojeno.TabIndex = 2;
            size = new System.Drawing.Size(0x17, 0x16);
            this.textporeziprirezodvojeno.Size = size;
            this.textporeziprirezodvojeno.MaxLength = 1;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.textporeziprirezodvojeno, 1, 2);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.textporeziprirezodvojeno, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.textporeziprirezodvojeno, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textporeziprirezodvojeno.Margin = padding;
            size = new System.Drawing.Size(0x17, 0x16);
            this.textporeziprirezodvojeno.MinimumSize = size;
            this.label1pl1.Name = "label1pl1";
            this.label1pl1.TabIndex = 1;
            this.label1pl1.Tag = "labelpl1";
            this.label1pl1.AutoSize = true;
            this.label1pl1.StyleSetName = "FieldUltraLabel";
            this.label1pl1.Text = "pl1          :";
            this.label1pl1.Appearance.TextVAlign = VAlign.Middle;
            this.label1pl1.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1pl1.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.label1pl1, 0, 3);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.label1pl1, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.label1pl1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1pl1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1pl1.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textpl1.Location = point;
            this.textpl1.Name = "textpl1";
            this.textpl1.Tag = "pl1";
            this.textpl1.TabIndex = 3;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textpl1.Size = size;
            this.textpl1.MaxLength = 20;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.textpl1, 1, 3);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.textpl1, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.textpl1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textpl1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textpl1.MinimumSize = size;
            this.label1pl2.Name = "label1pl2";
            this.label1pl2.TabIndex = 1;
            this.label1pl2.Tag = "labelpl2";
            this.label1pl2.AutoSize = true;
            this.label1pl2.StyleSetName = "FieldUltraLabel";
            this.label1pl2.Text = "pl2          :";
            this.label1pl2.Appearance.TextVAlign = VAlign.Middle;
            this.label1pl2.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1pl2.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.label1pl2, 0, 4);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.label1pl2, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.label1pl2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1pl2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1pl2.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textpl2.Location = point;
            this.textpl2.Name = "textpl2";
            this.textpl2.Tag = "pl2";
            this.textpl2.TabIndex = 4;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textpl2.Size = size;
            this.textpl2.MaxLength = 20;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.textpl2, 1, 4);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.textpl2, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.textpl2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textpl2.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textpl2.MinimumSize = size;
            this.label1pl3.Name = "label1pl3";
            this.label1pl3.TabIndex = 1;
            this.label1pl3.Tag = "labelpl3";
            this.label1pl3.AutoSize = true;
            this.label1pl3.StyleSetName = "FieldUltraLabel";
            this.label1pl3.Text = "pl3          :";
            this.label1pl3.Appearance.TextVAlign = VAlign.Middle;
            this.label1pl3.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1pl3.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.label1pl3, 0, 5);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.label1pl3, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.label1pl3, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1pl3.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1pl3.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textpl3.Location = point;
            this.textpl3.Name = "textpl3";
            this.textpl3.Tag = "pl3";
            this.textpl3.TabIndex = 5;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textpl3.Size = size;
            this.textpl3.MaxLength = 20;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.textpl3, 1, 5);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.textpl3, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.textpl3, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textpl3.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textpl3.MinimumSize = size;
            this.label1vbd.Name = "label1vbd";
            this.label1vbd.TabIndex = 1;
            this.label1vbd.Tag = "labelvbd";
            this.label1vbd.AutoSize = true;
            this.label1vbd.StyleSetName = "FieldUltraLabel";
            this.label1vbd.Text = "vbd          :";
            this.label1vbd.Appearance.TextVAlign = VAlign.Middle;
            this.label1vbd.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1vbd.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.label1vbd, 0, 6);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.label1vbd, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.label1vbd, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1vbd.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1vbd.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textvbd.Location = point;
            this.textvbd.Name = "textvbd";
            this.textvbd.Tag = "vbd";
            this.textvbd.TabIndex = 6;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textvbd.Size = size;
            this.textvbd.MaxLength = 7;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.textvbd, 1, 6);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.textvbd, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.textvbd, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textvbd.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textvbd.MinimumSize = size;
            this.label1zrn.Name = "label1zrn";
            this.label1zrn.TabIndex = 1;
            this.label1zrn.Tag = "labelzrn";
            this.label1zrn.AutoSize = true;
            this.label1zrn.StyleSetName = "FieldUltraLabel";
            this.label1zrn.Text = "zrn          :";
            this.label1zrn.Appearance.TextVAlign = VAlign.Middle;
            this.label1zrn.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1zrn.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.label1zrn, 0, 7);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.label1zrn, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.label1zrn, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1zrn.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1zrn.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textzrn.Location = point;
            this.textzrn.Name = "textzrn";
            this.textzrn.Tag = "zrn";
            this.textzrn.TabIndex = 7;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textzrn.Size = size;
            this.textzrn.MaxLength = 10;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.textzrn, 1, 7);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.textzrn, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.textzrn, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textzrn.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textzrn.MinimumSize = size;
            this.label1mb.Name = "label1mb";
            this.label1mb.TabIndex = 1;
            this.label1mb.Tag = "labelmb";
            this.label1mb.AutoSize = true;
            this.label1mb.StyleSetName = "FieldUltraLabel";
            this.label1mb.Text = "mb         :";
            this.label1mb.Appearance.TextVAlign = VAlign.Middle;
            this.label1mb.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1mb.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.label1mb, 0, 8);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.label1mb, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.label1mb, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1mb.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1mb.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textmb.Location = point;
            this.textmb.Name = "textmb";
            this.textmb.Tag = "mb";
            this.textmb.TabIndex = 8;
            size = new System.Drawing.Size(0x72, 0x16);
            this.textmb.Size = size;
            this.textmb.MaxLength = 14;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.textmb, 1, 8);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.textmb, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.textmb, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textmb.Margin = padding;
            size = new System.Drawing.Size(0x72, 0x16);
            this.textmb.MinimumSize = size;
            this.label1dd.Name = "label1dd";
            this.label1dd.TabIndex = 1;
            this.label1dd.Tag = "labeldd";
            this.label1dd.AutoSize = true;
            this.label1dd.StyleSetName = "FieldUltraLabel";
            this.label1dd.Text = "dd  :";
            this.label1dd.Appearance.TextVAlign = VAlign.Middle;
            this.label1dd.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1dd.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.label1dd, 0, 9);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.label1dd, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.label1dd, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1dd.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1dd.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textdd.Location = point;
            this.textdd.Name = "textdd";
            this.textdd.Tag = "dd";
            this.textdd.TabIndex = 9;
            size = new System.Drawing.Size(0x17, 0x16);
            this.textdd.Size = size;
            this.textdd.MaxLength = 1;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.textdd, 1, 9);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.textdd, 1);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.textdd, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textdd.Margin = padding;
            size = new System.Drawing.Size(0x17, 0x16);
            this.textdd.MinimumSize = size;
            this.layoutManagerformsp_VIRMANI.Controls.Add(this.userControlDataGridsp_VIRMANI, 0, 10);
            this.layoutManagerformsp_VIRMANI.SetColumnSpan(this.userControlDataGridsp_VIRMANI, 2);
            this.layoutManagerformsp_VIRMANI.SetRowSpan(this.userControlDataGridsp_VIRMANI, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridsp_VIRMANI.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridsp_VIRMANI.MinimumSize = size;
            this.userControlDataGridsp_VIRMANI.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformsp_VIRMANI);
            this.userControlDataGridsp_VIRMANI.Name = "userControlDataGridsp_VIRMANI";
            this.userControlDataGridsp_VIRMANI.Dock = DockStyle.Fill;
            this.userControlDataGridsp_VIRMANI.DockPadding.All = 5;
            this.userControlDataGridsp_VIRMANI.FillAtStartup = false;
            this.userControlDataGridsp_VIRMANI.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridsp_VIRMANI.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridsp_VIRMANI.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridsp_VIRMANI.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "sp_VIRMANIWorkWith";
            this.Text = "Work With sp_VIRMANI";
            this.Load += new EventHandler(this.sp_VIRMANIUserControl_Load);
            this.layoutManagerformsp_VIRMANI.ResumeLayout(false);
            this.layoutManagerformsp_VIRMANI.PerformLayout();
            ((ISupportInitialize) this.textIDOBRACUN).EndInit();
            ((ISupportInitialize) this.textzaduzenje).EndInit();
            ((ISupportInitialize) this.textporeziprirezodvojeno).EndInit();
            ((ISupportInitialize) this.textpl1).EndInit();
            ((ISupportInitialize) this.textpl2).EndInit();
            ((ISupportInitialize) this.textpl3).EndInit();
            ((ISupportInitialize) this.textvbd).EndInit();
            ((ISupportInitialize) this.textzrn).EndInit();
            ((ISupportInitialize) this.textmb).EndInit();
            ((ISupportInitialize) this.textdd).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textIDOBRACUN.Text = "";
            this.textzaduzenje.Text = "";
            this.textporeziprirezodvojeno.Text = "";
            this.textpl1.Text = "";
            this.textpl2.Text = "";
            this.textpl3.Text = "";
            this.textvbd.Text = "";
            this.textzrn.Text = "";
            this.textmb.Text = "";
            this.textdd.Text = "";
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
                if (this.m_FillByRow.Table.Columns.Contains("zaduzenje") && (this.m_FillByRow["zaduzenje"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textzaduzenje, this.m_FillByRow["zaduzenje"].ToString(), this.m_FillByRow.Table.Columns["zaduzenje"].DataType);
                    this.parameterSeted = true;
                    this.textzaduzenje.Visible = false;
                    this.label1zaduzenje.Visible = false;
                    str = str + "," + this.m_FillByRow["zaduzenje"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("poreziprirezodvojeno") && (this.m_FillByRow["poreziprirezodvojeno"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textporeziprirezodvojeno, this.m_FillByRow["poreziprirezodvojeno"].ToString(), this.m_FillByRow.Table.Columns["poreziprirezodvojeno"].DataType);
                    this.parameterSeted = true;
                    this.textporeziprirezodvojeno.Visible = false;
                    this.label1poreziprirezodvojeno.Visible = false;
                    str = str + "," + this.m_FillByRow["poreziprirezodvojeno"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("pl1") && (this.m_FillByRow["pl1"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textpl1, this.m_FillByRow["pl1"].ToString(), this.m_FillByRow.Table.Columns["pl1"].DataType);
                    this.parameterSeted = true;
                    this.textpl1.Visible = false;
                    this.label1pl1.Visible = false;
                    str = str + "," + this.m_FillByRow["pl1"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("pl2") && (this.m_FillByRow["pl2"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textpl2, this.m_FillByRow["pl2"].ToString(), this.m_FillByRow.Table.Columns["pl2"].DataType);
                    this.parameterSeted = true;
                    this.textpl2.Visible = false;
                    this.label1pl2.Visible = false;
                    str = str + "," + this.m_FillByRow["pl2"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("pl3") && (this.m_FillByRow["pl3"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textpl3, this.m_FillByRow["pl3"].ToString(), this.m_FillByRow.Table.Columns["pl3"].DataType);
                    this.parameterSeted = true;
                    this.textpl3.Visible = false;
                    this.label1pl3.Visible = false;
                    str = str + "," + this.m_FillByRow["pl3"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("vbd") && (this.m_FillByRow["vbd"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textvbd, this.m_FillByRow["vbd"].ToString(), this.m_FillByRow.Table.Columns["vbd"].DataType);
                    this.parameterSeted = true;
                    this.textvbd.Visible = false;
                    this.label1vbd.Visible = false;
                    str = str + "," + this.m_FillByRow["vbd"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("zrn") && (this.m_FillByRow["zrn"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textzrn, this.m_FillByRow["zrn"].ToString(), this.m_FillByRow.Table.Columns["zrn"].DataType);
                    this.parameterSeted = true;
                    this.textzrn.Visible = false;
                    this.label1zrn.Visible = false;
                    str = str + "," + this.m_FillByRow["zrn"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("mb") && (this.m_FillByRow["mb"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textmb, this.m_FillByRow["mb"].ToString(), this.m_FillByRow.Table.Columns["mb"].DataType);
                    this.parameterSeted = true;
                    this.textmb.Visible = false;
                    this.label1mb.Visible = false;
                    str = str + "," + this.m_FillByRow["mb"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("dd") && (this.m_FillByRow["dd"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textdd, this.m_FillByRow["dd"].ToString(), this.m_FillByRow.Table.Columns["dd"].DataType);
                    this.parameterSeted = true;
                    this.textdd.Visible = false;
                    this.label1dd.Visible = false;
                    str = str + "," + this.m_FillByRow["dd"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "sp_VIRMANI " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "sp_VIRMANI " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridsp_VIRMANI.DataGrid.DataSet.Clear();
                    this.userControlDataGridsp_VIRMANI.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new sp_VIRMANIDataAdapter().Update(this.userControlDataGridsp_VIRMANI.DataGrid.DataSet);
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
            this.label1IDOBRACUN.Text = StringResources.sp_VIRMANIIDOBRACUNParameter;
            this.label1zaduzenje.Text = StringResources.sp_VIRMANIzaduzenjeParameter;
            this.label1poreziprirezodvojeno.Text = StringResources.sp_VIRMANIporeziprirezodvojenoParameter;
            this.label1pl1.Text = StringResources.sp_VIRMANIpl1Parameter;
            this.label1pl2.Text = StringResources.sp_VIRMANIpl2Parameter;
            this.label1pl3.Text = StringResources.sp_VIRMANIpl3Parameter;
            this.label1vbd.Text = StringResources.sp_VIRMANIvbdParameter;
            this.label1zrn.Text = StringResources.sp_VIRMANIzrnParameter;
            this.label1mb.Text = StringResources.sp_VIRMANImbParameter;
            this.label1dd.Text = StringResources.sp_VIRMANIddParameter;
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
                this.userControlDataGridsp_VIRMANI.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridsp_VIRMANI.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} sp_VIRMANI ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} sp_VIRMANI ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void sp_VIRMANIUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridsp_VIRMANI.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridsp_VIRMANI.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridsp_VIRMANI.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridsp_VIRMANI.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridsp_VIRMANI.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridsp_VIRMANI.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridsp_VIRMANI.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridsp_VIRMANI.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridsp_VIRMANI.DataGrid.FillByPage = true;
                this.FillData();
            }
        }

        [CreateNew]
        public sp_VIRMANIController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridsp_VIRMANI.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridsp_VIRMANI.DataView[this.userControlDataGridsp_VIRMANI.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1dd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1dd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1dd = value;
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

        protected virtual UltraLabel label1mb
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1mb;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1mb = value;
            }
        }

        protected virtual UltraLabel label1pl1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1pl1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1pl1 = value;
            }
        }

        protected virtual UltraLabel label1pl2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1pl2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1pl2 = value;
            }
        }

        protected virtual UltraLabel label1pl3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1pl3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1pl3 = value;
            }
        }

        protected virtual UltraLabel label1poreziprirezodvojeno
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1poreziprirezodvojeno;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1poreziprirezodvojeno = value;
            }
        }

        protected virtual UltraLabel label1vbd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1vbd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1vbd = value;
            }
        }

        protected virtual UltraLabel label1zaduzenje
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1zaduzenje;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1zaduzenje = value;
            }
        }

        protected virtual UltraLabel label1zrn
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1zrn;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1zrn = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraTextEditor textdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textdd = value;
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

        protected virtual UltraTextEditor textmb
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textmb;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textmb = value;
            }
        }

        protected virtual UltraTextEditor textpl1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textpl1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textpl1 = value;
            }
        }

        protected virtual UltraTextEditor textpl2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textpl2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textpl2 = value;
            }
        }

        protected virtual UltraTextEditor textpl3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textpl3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textpl3 = value;
            }
        }

        protected virtual UltraTextEditor textporeziprirezodvojeno
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textporeziprirezodvojeno;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textporeziprirezodvojeno = value;
            }
        }

        protected virtual UltraTextEditor textvbd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textvbd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textvbd = value;
            }
        }

        protected virtual UltraTextEditor textzaduzenje
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textzaduzenje;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textzaduzenje = value;
            }
        }

        protected virtual UltraTextEditor textzrn
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textzrn;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textzrn = value;
            }
        }

        protected virtual sp_VIRMANIUserDataGrid userControlDataGridsp_VIRMANI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridsp_VIRMANI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridsp_VIRMANI = value;
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

