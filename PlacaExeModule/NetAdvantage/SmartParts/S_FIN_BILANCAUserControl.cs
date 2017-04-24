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
    public class S_FIN_BILANCAUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("datePickerRAZDOBLJEDO")]
        private UltraDateTimeEditor _datePickerRAZDOBLJEDO;
        [AccessedThroughProperty("datePickerRAZDOBLJEOD")]
        private UltraDateTimeEditor _datePickerRAZDOBLJEOD;
        [AccessedThroughProperty("label1ANA")]
        private UltraLabel _label1ANA;
        [AccessedThroughProperty("label1DOK")]
        private UltraLabel _label1DOK;
        [AccessedThroughProperty("label1KLASA")]
        private UltraLabel _label1KLASA;
        [AccessedThroughProperty("label1MT")]
        private UltraLabel _label1MT;
        [AccessedThroughProperty("label1ORG")]
        private UltraLabel _label1ORG;
        [AccessedThroughProperty("label1RAZDOBLJEDO")]
        private UltraLabel _label1RAZDOBLJEDO;
        [AccessedThroughProperty("label1RAZDOBLJEOD")]
        private UltraLabel _label1RAZDOBLJEOD;
        [AccessedThroughProperty("label1SKR")]
        private UltraLabel _label1SKR;
        [AccessedThroughProperty("label1VRSTABILANCE")]
        private UltraLabel _label1VRSTABILANCE;
        [AccessedThroughProperty("textANA")]
        private UltraNumericEditor _textANA;
        [AccessedThroughProperty("textDOK")]
        private UltraTextEditor _textDOK;
        [AccessedThroughProperty("textKLASA")]
        private UltraTextEditor _textKLASA;
        [AccessedThroughProperty("textMT")]
        private UltraTextEditor _textMT;
        [AccessedThroughProperty("textORG")]
        private UltraTextEditor _textORG;
        [AccessedThroughProperty("textSKR")]
        private UltraNumericEditor _textSKR;
        [AccessedThroughProperty("textVRSTABILANCE")]
        private UltraNumericEditor _textVRSTABILANCE;
        [AccessedThroughProperty("userControlDataGridS_FIN_BILANCA")]
        private S_FIN_BILANCAUserDataGrid _userControlDataGridS_FIN_BILANCA;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_FIN_BILANCA;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_FIN_BILANCAUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_FIN_BILANCADescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_FIN_BILANCADescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_FIN_BILANCA.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_FIN_BILANCADataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_FIN_BILANCADataSet>(this.userControlDataGridS_FIN_BILANCA.DataGrid);
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
            if ((this.userControlDataGridS_FIN_BILANCA.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_FIN_BILANCA.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_FIN_BILANCA.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_FIN_BILANCA.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_FIN_BILANCA.DataGrid.FillByPage;
                this.userControlDataGridS_FIN_BILANCA.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_FIN_BILANCA.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                if (this.datePickerRAZDOBLJEOD.Value == null)
                {
                    this.userControlDataGridS_FIN_BILANCA.ParameterRAZDOBLJEOD = DateTime.MinValue;
                }
                else
                {
                    this.userControlDataGridS_FIN_BILANCA.ParameterRAZDOBLJEOD = DateTime.Parse(this.datePickerRAZDOBLJEOD.Value.ToString(), CultureInfo.CurrentCulture);
                }
                if (this.datePickerRAZDOBLJEDO.Value == null)
                {
                    this.userControlDataGridS_FIN_BILANCA.ParameterRAZDOBLJEDO = DateTime.MinValue;
                }
                else
                {
                    this.userControlDataGridS_FIN_BILANCA.ParameterRAZDOBLJEDO = DateTime.Parse(this.datePickerRAZDOBLJEDO.Value.ToString(), CultureInfo.CurrentCulture);
                }
                this.userControlDataGridS_FIN_BILANCA.ParameterORG = this.textORG.Text;
                this.userControlDataGridS_FIN_BILANCA.ParameterMT = this.textMT.Text;
                this.userControlDataGridS_FIN_BILANCA.ParameterDOK = this.textDOK.Text;
                this.userControlDataGridS_FIN_BILANCA.ParameterANA = short.Parse(this.textANA.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_FIN_BILANCA.ParameterSKR = short.Parse(this.textSKR.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_FIN_BILANCA.ParameterKLASA = this.textKLASA.Text;
                this.userControlDataGridS_FIN_BILANCA.ParameterVRSTABILANCE = short.Parse(this.textVRSTABILANCE.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_FIN_BILANCA.Fill();
                ((S_FIN_BILANCAWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_FIN_BILANCA.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("RAZDOBLJEOD", typeof(DateTime));
            table2.Columns.Add(column);
            column = new DataColumn("RAZDOBLJEDO", typeof(DateTime));
            table2.Columns.Add(column);
            column = new DataColumn("ORG", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("MT", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("DOK", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("ANA", typeof(short));
            table2.Columns.Add(column);
            column = new DataColumn("SKR", typeof(short));
            table2.Columns.Add(column);
            column = new DataColumn("KLASA", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("VRSTABILANCE", typeof(short));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            if (this.datePickerRAZDOBLJEOD.Value == null)
            {
                row2["RAZDOBLJEOD"] = DateTime.MinValue;
            }
            else
            {
                row2["RAZDOBLJEOD"] = DateTime.Parse(this.datePickerRAZDOBLJEOD.Value.ToString(), CultureInfo.CurrentCulture);
            }
            if (this.datePickerRAZDOBLJEDO.Value == null)
            {
                row2["RAZDOBLJEDO"] = DateTime.MinValue;
            }
            else
            {
                row2["RAZDOBLJEDO"] = DateTime.Parse(this.datePickerRAZDOBLJEDO.Value.ToString(), CultureInfo.CurrentCulture);
            }
            row2["ORG"] = this.textORG.Text;
            row2["MT"] = this.textMT.Text;
            row2["DOK"] = this.textDOK.Text;
            row2["ANA"] = short.Parse(this.textANA.Value.ToString(), CultureInfo.CurrentCulture);
            row2["SKR"] = short.Parse(this.textSKR.Value.ToString(), CultureInfo.CurrentCulture);
            row2["KLASA"] = this.textKLASA.Text;
            row2["VRSTABILANCE"] = short.Parse(this.textVRSTABILANCE.Value.ToString(), CultureInfo.CurrentCulture);
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
            ResourceManager manager = new ResourceManager(typeof(S_FIN_BILANCAUserControl));
            this.layoutManagerformS_FIN_BILANCA = new TableLayoutPanel();
            this.layoutManagerformS_FIN_BILANCA.SuspendLayout();
            this.layoutManagerformS_FIN_BILANCA.AutoSize = true;
            this.layoutManagerformS_FIN_BILANCA.Dock = DockStyle.Fill;
            this.layoutManagerformS_FIN_BILANCA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_FIN_BILANCA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_FIN_BILANCA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_FIN_BILANCA.Size = size;
            this.layoutManagerformS_FIN_BILANCA.ColumnCount = 2;
            this.layoutManagerformS_FIN_BILANCA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_FIN_BILANCA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_FIN_BILANCA.RowCount = 10;
            this.layoutManagerformS_FIN_BILANCA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_BILANCA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_BILANCA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_BILANCA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_BILANCA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_BILANCA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_BILANCA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_BILANCA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_BILANCA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_BILANCA.RowStyles.Add(new RowStyle());
            this.label1RAZDOBLJEOD = new UltraLabel();
            this.datePickerRAZDOBLJEOD = new UltraDateTimeEditor();
            this.label1RAZDOBLJEDO = new UltraLabel();
            this.datePickerRAZDOBLJEDO = new UltraDateTimeEditor();
            this.label1ORG = new UltraLabel();
            this.textORG = new UltraTextEditor();
            this.label1MT = new UltraLabel();
            this.textMT = new UltraTextEditor();
            this.label1DOK = new UltraLabel();
            this.textDOK = new UltraTextEditor();
            this.label1ANA = new UltraLabel();
            this.textANA = new UltraNumericEditor();
            this.label1SKR = new UltraLabel();
            this.textSKR = new UltraNumericEditor();
            this.label1KLASA = new UltraLabel();
            this.textKLASA = new UltraTextEditor();
            this.label1VRSTABILANCE = new UltraLabel();
            this.textVRSTABILANCE = new UltraNumericEditor();
            this.userControlDataGridS_FIN_BILANCA = new S_FIN_BILANCAUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textORG).BeginInit();
            ((ISupportInitialize) this.textMT).BeginInit();
            ((ISupportInitialize) this.textDOK).BeginInit();
            ((ISupportInitialize) this.textANA).BeginInit();
            ((ISupportInitialize) this.textSKR).BeginInit();
            ((ISupportInitialize) this.textKLASA).BeginInit();
            ((ISupportInitialize) this.textVRSTABILANCE).BeginInit();
            this.SuspendLayout();
            this.label1RAZDOBLJEOD.Name = "label1RAZDOBLJEOD";
            this.label1RAZDOBLJEOD.TabIndex = 1;
            this.label1RAZDOBLJEOD.Tag = "labelRAZDOBLJEOD";
            this.label1RAZDOBLJEOD.AutoSize = true;
            this.label1RAZDOBLJEOD.StyleSetName = "FieldUltraLabel";
            this.label1RAZDOBLJEOD.Text = "RAZDOBLJEOD  :";
            this.label1RAZDOBLJEOD.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAZDOBLJEOD.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1RAZDOBLJEOD.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.label1RAZDOBLJEOD, 0, 0);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.label1RAZDOBLJEOD, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.label1RAZDOBLJEOD, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1RAZDOBLJEOD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAZDOBLJEOD.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerRAZDOBLJEOD.Location = point;
            this.datePickerRAZDOBLJEOD.Name = "datePickerRAZDOBLJEOD";
            this.datePickerRAZDOBLJEOD.Tag = "RAZDOBLJEOD";
            this.datePickerRAZDOBLJEOD.TabIndex = 0;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerRAZDOBLJEOD.Size = size;
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.datePickerRAZDOBLJEOD, 1, 0);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.datePickerRAZDOBLJEOD, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.datePickerRAZDOBLJEOD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerRAZDOBLJEOD.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerRAZDOBLJEOD.MinimumSize = size;
            this.label1RAZDOBLJEDO.Name = "label1RAZDOBLJEDO";
            this.label1RAZDOBLJEDO.TabIndex = 1;
            this.label1RAZDOBLJEDO.Tag = "labelRAZDOBLJEDO";
            this.label1RAZDOBLJEDO.AutoSize = true;
            this.label1RAZDOBLJEDO.StyleSetName = "FieldUltraLabel";
            this.label1RAZDOBLJEDO.Text = "RAZDOBLJEDO  :";
            this.label1RAZDOBLJEDO.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAZDOBLJEDO.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1RAZDOBLJEDO.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.label1RAZDOBLJEDO, 0, 1);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.label1RAZDOBLJEDO, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.label1RAZDOBLJEDO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RAZDOBLJEDO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAZDOBLJEDO.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerRAZDOBLJEDO.Location = point;
            this.datePickerRAZDOBLJEDO.Name = "datePickerRAZDOBLJEDO";
            this.datePickerRAZDOBLJEDO.Tag = "RAZDOBLJEDO";
            this.datePickerRAZDOBLJEDO.TabIndex = 1;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerRAZDOBLJEDO.Size = size;
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.datePickerRAZDOBLJEDO, 1, 1);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.datePickerRAZDOBLJEDO, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.datePickerRAZDOBLJEDO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerRAZDOBLJEDO.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerRAZDOBLJEDO.MinimumSize = size;
            this.label1ORG.Name = "label1ORG";
            this.label1ORG.TabIndex = 1;
            this.label1ORG.Tag = "labelORG";
            this.label1ORG.AutoSize = true;
            this.label1ORG.StyleSetName = "FieldUltraLabel";
            this.label1ORG.Text = "ORG  :";
            this.label1ORG.Appearance.TextVAlign = VAlign.Middle;
            this.label1ORG.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ORG.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.label1ORG, 0, 2);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.label1ORG, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.label1ORG, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ORG.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ORG.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textORG.Location = point;
            this.textORG.Name = "textORG";
            this.textORG.Tag = "ORG";
            this.textORG.TabIndex = 2;
            size = new System.Drawing.Size(0x240, 220);
            this.textORG.Size = size;
            this.textORG.MaxLength = 0x3e8;
            this.textORG.Multiline = true;
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.textORG, 1, 2);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.textORG, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.textORG, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textORG.Margin = padding;
            size = new System.Drawing.Size(0x240, 220);
            this.textORG.MinimumSize = size;
            this.textORG.Dock = DockStyle.Fill;
            this.label1MT.Name = "label1MT";
            this.label1MT.TabIndex = 1;
            this.label1MT.Tag = "labelMT";
            this.label1MT.AutoSize = true;
            this.label1MT.StyleSetName = "FieldUltraLabel";
            this.label1MT.Text = "MT  :";
            this.label1MT.Appearance.TextVAlign = VAlign.Middle;
            this.label1MT.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1MT.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.label1MT, 0, 3);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.label1MT, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.label1MT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MT.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textMT.Location = point;
            this.textMT.Name = "textMT";
            this.textMT.Tag = "MT";
            this.textMT.TabIndex = 3;
            size = new System.Drawing.Size(0x240, 220);
            this.textMT.Size = size;
            this.textMT.MaxLength = 0x3e8;
            this.textMT.Multiline = true;
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.textMT, 1, 3);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.textMT, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.textMT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMT.Margin = padding;
            size = new System.Drawing.Size(0x240, 220);
            this.textMT.MinimumSize = size;
            this.textMT.Dock = DockStyle.Fill;
            this.label1DOK.Name = "label1DOK";
            this.label1DOK.TabIndex = 1;
            this.label1DOK.Tag = "labelDOK";
            this.label1DOK.AutoSize = true;
            this.label1DOK.StyleSetName = "FieldUltraLabel";
            this.label1DOK.Text = "DOK  :";
            this.label1DOK.Appearance.TextVAlign = VAlign.Middle;
            this.label1DOK.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1DOK.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.label1DOK, 0, 4);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.label1DOK, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.label1DOK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DOK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DOK.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textDOK.Location = point;
            this.textDOK.Name = "textDOK";
            this.textDOK.Tag = "DOK";
            this.textDOK.TabIndex = 4;
            size = new System.Drawing.Size(0x240, 220);
            this.textDOK.Size = size;
            this.textDOK.MaxLength = 0x3e8;
            this.textDOK.Multiline = true;
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.textDOK, 1, 4);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.textDOK, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.textDOK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDOK.Margin = padding;
            size = new System.Drawing.Size(0x240, 220);
            this.textDOK.MinimumSize = size;
            this.textDOK.Dock = DockStyle.Fill;
            this.label1ANA.Name = "label1ANA";
            this.label1ANA.TabIndex = 1;
            this.label1ANA.Tag = "labelANA";
            this.label1ANA.AutoSize = true;
            this.label1ANA.StyleSetName = "FieldUltraLabel";
            this.label1ANA.Text = "ANA  :";
            this.label1ANA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ANA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ANA.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.label1ANA, 0, 5);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.label1ANA, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.label1ANA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ANA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ANA.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textANA.Location = point;
            this.textANA.Name = "textANA";
            this.textANA.Tag = "ANA";
            this.textANA.TabIndex = 5;
            size = new System.Drawing.Size(0x18, 0x16);
            this.textANA.Size = size;
            this.textANA.PromptChar = ' ';
            this.textANA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textANA.NumericType = NumericType.Integer;
            this.textANA.MaskInput = "{LOC}-n";
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.textANA, 1, 5);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.textANA, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.textANA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textANA.Margin = padding;
            size = new System.Drawing.Size(0x18, 0x16);
            this.textANA.MinimumSize = size;
            this.label1SKR.Name = "label1SKR";
            this.label1SKR.TabIndex = 1;
            this.label1SKR.Tag = "labelSKR";
            this.label1SKR.AutoSize = true;
            this.label1SKR.StyleSetName = "FieldUltraLabel";
            this.label1SKR.Text = "SKR  :";
            this.label1SKR.Appearance.TextVAlign = VAlign.Middle;
            this.label1SKR.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1SKR.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.label1SKR, 0, 6);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.label1SKR, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.label1SKR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SKR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SKR.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textSKR.Location = point;
            this.textSKR.Name = "textSKR";
            this.textSKR.Tag = "SKR";
            this.textSKR.TabIndex = 6;
            size = new System.Drawing.Size(0x18, 0x16);
            this.textSKR.Size = size;
            this.textSKR.PromptChar = ' ';
            this.textSKR.Enter += new EventHandler(this.numericEditor_Enter);
            this.textSKR.NumericType = NumericType.Integer;
            this.textSKR.MaskInput = "{LOC}-n";
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.textSKR, 1, 6);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.textSKR, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.textSKR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSKR.Margin = padding;
            size = new System.Drawing.Size(0x18, 0x16);
            this.textSKR.MinimumSize = size;
            this.label1KLASA.Name = "label1KLASA";
            this.label1KLASA.TabIndex = 1;
            this.label1KLASA.Tag = "labelKLASA";
            this.label1KLASA.AutoSize = true;
            this.label1KLASA.StyleSetName = "FieldUltraLabel";
            this.label1KLASA.Text = "KLASA  :";
            this.label1KLASA.Appearance.TextVAlign = VAlign.Middle;
            this.label1KLASA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1KLASA.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.label1KLASA, 0, 7);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.label1KLASA, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.label1KLASA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KLASA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KLASA.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textKLASA.Location = point;
            this.textKLASA.Name = "textKLASA";
            this.textKLASA.Tag = "KLASA";
            this.textKLASA.TabIndex = 7;
            size = new System.Drawing.Size(0x17, 0x16);
            this.textKLASA.Size = size;
            this.textKLASA.MaxLength = 1;
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.textKLASA, 1, 7);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.textKLASA, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.textKLASA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textKLASA.Margin = padding;
            size = new System.Drawing.Size(0x17, 0x16);
            this.textKLASA.MinimumSize = size;
            this.label1VRSTABILANCE.Name = "label1VRSTABILANCE";
            this.label1VRSTABILANCE.TabIndex = 1;
            this.label1VRSTABILANCE.Tag = "labelVRSTABILANCE";
            this.label1VRSTABILANCE.AutoSize = true;
            this.label1VRSTABILANCE.StyleSetName = "FieldUltraLabel";
            this.label1VRSTABILANCE.Text = "VRSTABILANCE  :";
            this.label1VRSTABILANCE.Appearance.TextVAlign = VAlign.Middle;
            this.label1VRSTABILANCE.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1VRSTABILANCE.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.label1VRSTABILANCE, 0, 8);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.label1VRSTABILANCE, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.label1VRSTABILANCE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VRSTABILANCE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VRSTABILANCE.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textVRSTABILANCE.Location = point;
            this.textVRSTABILANCE.Name = "textVRSTABILANCE";
            this.textVRSTABILANCE.Tag = "VRSTABILANCE";
            this.textVRSTABILANCE.TabIndex = 8;
            size = new System.Drawing.Size(0x18, 0x16);
            this.textVRSTABILANCE.Size = size;
            this.textVRSTABILANCE.PromptChar = ' ';
            this.textVRSTABILANCE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textVRSTABILANCE.NumericType = NumericType.Integer;
            this.textVRSTABILANCE.MaskInput = "{LOC}-n";
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.textVRSTABILANCE, 1, 8);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.textVRSTABILANCE, 1);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.textVRSTABILANCE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVRSTABILANCE.Margin = padding;
            size = new System.Drawing.Size(0x18, 0x16);
            this.textVRSTABILANCE.MinimumSize = size;
            this.layoutManagerformS_FIN_BILANCA.Controls.Add(this.userControlDataGridS_FIN_BILANCA, 0, 9);
            this.layoutManagerformS_FIN_BILANCA.SetColumnSpan(this.userControlDataGridS_FIN_BILANCA, 2);
            this.layoutManagerformS_FIN_BILANCA.SetRowSpan(this.userControlDataGridS_FIN_BILANCA, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_FIN_BILANCA.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_FIN_BILANCA.MinimumSize = size;
            this.userControlDataGridS_FIN_BILANCA.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_FIN_BILANCA);
            this.userControlDataGridS_FIN_BILANCA.Name = "userControlDataGridS_FIN_BILANCA";
            this.userControlDataGridS_FIN_BILANCA.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_BILANCA.DockPadding.All = 5;
            this.userControlDataGridS_FIN_BILANCA.FillAtStartup = false;
            this.userControlDataGridS_FIN_BILANCA.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_BILANCA.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_FIN_BILANCA.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_FIN_BILANCA.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_FIN_BILANCAWorkWith";
            this.Text = "Work With S_FIN_BILANCA";
            this.Load += new EventHandler(this.S_FIN_BILANCAUserControl_Load);
            this.layoutManagerformS_FIN_BILANCA.ResumeLayout(false);
            this.layoutManagerformS_FIN_BILANCA.PerformLayout();
            ((ISupportInitialize) this.textORG).EndInit();
            ((ISupportInitialize) this.textMT).EndInit();
            ((ISupportInitialize) this.textDOK).EndInit();
            ((ISupportInitialize) this.textANA).EndInit();
            ((ISupportInitialize) this.textSKR).EndInit();
            ((ISupportInitialize) this.textKLASA).EndInit();
            ((ISupportInitialize) this.textVRSTABILANCE).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.datePickerRAZDOBLJEOD.Text = "";
            this.datePickerRAZDOBLJEDO.Text = "";
            this.textORG.Text = "";
            this.textMT.Text = "";
            this.textDOK.Text = "";
            this.textANA.Text = "0";
            this.textSKR.Text = "0";
            this.textKLASA.Text = "";
            this.textVRSTABILANCE.Text = "0";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("RAZDOBLJEOD") && (this.m_FillByRow["RAZDOBLJEOD"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.datePickerRAZDOBLJEOD, this.m_FillByRow["RAZDOBLJEOD"].ToString(), this.m_FillByRow.Table.Columns["RAZDOBLJEOD"].DataType);
                    this.parameterSeted = true;
                    this.datePickerRAZDOBLJEOD.Visible = false;
                    this.label1RAZDOBLJEOD.Visible = false;
                    str = str + "," + this.m_FillByRow["RAZDOBLJEOD"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("RAZDOBLJEDO") && (this.m_FillByRow["RAZDOBLJEDO"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.datePickerRAZDOBLJEDO, this.m_FillByRow["RAZDOBLJEDO"].ToString(), this.m_FillByRow.Table.Columns["RAZDOBLJEDO"].DataType);
                    this.parameterSeted = true;
                    this.datePickerRAZDOBLJEDO.Visible = false;
                    this.label1RAZDOBLJEDO.Visible = false;
                    str = str + "," + this.m_FillByRow["RAZDOBLJEDO"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("ORG") && (this.m_FillByRow["ORG"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textORG, this.m_FillByRow["ORG"].ToString(), this.m_FillByRow.Table.Columns["ORG"].DataType);
                    this.parameterSeted = true;
                    this.textORG.Visible = false;
                    this.label1ORG.Visible = false;
                    str = str + "," + this.m_FillByRow["ORG"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("MT") && (this.m_FillByRow["MT"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textMT, this.m_FillByRow["MT"].ToString(), this.m_FillByRow.Table.Columns["MT"].DataType);
                    this.parameterSeted = true;
                    this.textMT.Visible = false;
                    this.label1MT.Visible = false;
                    str = str + "," + this.m_FillByRow["MT"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("DOK") && (this.m_FillByRow["DOK"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textDOK, this.m_FillByRow["DOK"].ToString(), this.m_FillByRow.Table.Columns["DOK"].DataType);
                    this.parameterSeted = true;
                    this.textDOK.Visible = false;
                    this.label1DOK.Visible = false;
                    str = str + "," + this.m_FillByRow["DOK"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("ANA") && (this.m_FillByRow["ANA"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textANA, this.m_FillByRow["ANA"].ToString(), this.m_FillByRow.Table.Columns["ANA"].DataType);
                    this.parameterSeted = true;
                    this.textANA.Visible = false;
                    this.label1ANA.Visible = false;
                    str = str + "," + this.m_FillByRow["ANA"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("SKR") && (this.m_FillByRow["SKR"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textSKR, this.m_FillByRow["SKR"].ToString(), this.m_FillByRow.Table.Columns["SKR"].DataType);
                    this.parameterSeted = true;
                    this.textSKR.Visible = false;
                    this.label1SKR.Visible = false;
                    str = str + "," + this.m_FillByRow["SKR"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("KLASA") && (this.m_FillByRow["KLASA"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textKLASA, this.m_FillByRow["KLASA"].ToString(), this.m_FillByRow.Table.Columns["KLASA"].DataType);
                    this.parameterSeted = true;
                    this.textKLASA.Visible = false;
                    this.label1KLASA.Visible = false;
                    str = str + "," + this.m_FillByRow["KLASA"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("VRSTABILANCE") && (this.m_FillByRow["VRSTABILANCE"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textVRSTABILANCE, this.m_FillByRow["VRSTABILANCE"].ToString(), this.m_FillByRow.Table.Columns["VRSTABILANCE"].DataType);
                    this.parameterSeted = true;
                    this.textVRSTABILANCE.Visible = false;
                    this.label1VRSTABILANCE.Visible = false;
                    str = str + "," + this.m_FillByRow["VRSTABILANCE"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_FIN_BILANCA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_FIN_BILANCA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridS_FIN_BILANCA.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_FIN_BILANCA.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_FIN_BILANCADataAdapter().Update(this.userControlDataGridS_FIN_BILANCA.DataGrid.DataSet);
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
            this.label1RAZDOBLJEOD.Text = StringResources.S_FIN_BILANCARAZDOBLJEODParameter;
            this.label1RAZDOBLJEDO.Text = StringResources.S_FIN_BILANCARAZDOBLJEDOParameter;
            this.label1ORG.Text = StringResources.S_FIN_BILANCAORGParameter;
            this.label1MT.Text = StringResources.S_FIN_BILANCAMTParameter;
            this.label1DOK.Text = StringResources.S_FIN_BILANCADOKParameter;
            this.label1ANA.Text = StringResources.S_FIN_BILANCAANAParameter;
            this.label1SKR.Text = StringResources.S_FIN_BILANCASKRParameter;
            this.label1KLASA.Text = StringResources.S_FIN_BILANCAKLASAParameter;
            this.label1VRSTABILANCE.Text = StringResources.S_FIN_BILANCAVRSTABILANCEParameter;
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

        private void S_FIN_BILANCAUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_FIN_BILANCA.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_FIN_BILANCA.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_FIN_BILANCA.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_FIN_BILANCA.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_FIN_BILANCA.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_FIN_BILANCA.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_FIN_BILANCA.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_FIN_BILANCA.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_FIN_BILANCA.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_FIN_BILANCA.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_FIN_BILANCA.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_FIN_BILANCA ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_FIN_BILANCA ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_FIN_BILANCAController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_FIN_BILANCA.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_FIN_BILANCA.DataView[this.userControlDataGridS_FIN_BILANCA.DataGrid.CurrentRowIndex].Row;
            }
        }

        protected virtual UltraDateTimeEditor datePickerRAZDOBLJEDO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerRAZDOBLJEDO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerRAZDOBLJEDO = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerRAZDOBLJEOD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerRAZDOBLJEOD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerRAZDOBLJEOD = value;
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

        protected virtual UltraLabel label1ANA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ANA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ANA = value;
            }
        }

        protected virtual UltraLabel label1DOK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DOK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DOK = value;
            }
        }

        protected virtual UltraLabel label1KLASA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KLASA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KLASA = value;
            }
        }

        protected virtual UltraLabel label1MT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MT = value;
            }
        }

        protected virtual UltraLabel label1ORG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ORG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ORG = value;
            }
        }

        protected virtual UltraLabel label1RAZDOBLJEDO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAZDOBLJEDO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAZDOBLJEDO = value;
            }
        }

        protected virtual UltraLabel label1RAZDOBLJEOD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAZDOBLJEOD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAZDOBLJEOD = value;
            }
        }

        protected virtual UltraLabel label1SKR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SKR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SKR = value;
            }
        }

        protected virtual UltraLabel label1VRSTABILANCE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VRSTABILANCE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VRSTABILANCE = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraNumericEditor textANA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textANA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textANA = value;
            }
        }

        protected virtual UltraTextEditor textDOK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDOK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDOK = value;
            }
        }

        protected virtual UltraTextEditor textKLASA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textKLASA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textKLASA = value;
            }
        }

        protected virtual UltraTextEditor textMT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMT = value;
            }
        }

        protected virtual UltraTextEditor textORG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textORG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textORG = value;
            }
        }

        protected virtual UltraNumericEditor textSKR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSKR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSKR = value;
            }
        }

        protected virtual UltraNumericEditor textVRSTABILANCE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVRSTABILANCE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVRSTABILANCE = value;
            }
        }

        protected virtual S_FIN_BILANCAUserDataGrid userControlDataGridS_FIN_BILANCA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_FIN_BILANCA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_FIN_BILANCA = value;
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

