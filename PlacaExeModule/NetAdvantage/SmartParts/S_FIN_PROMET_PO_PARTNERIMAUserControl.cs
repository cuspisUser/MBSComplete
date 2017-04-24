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
    public class S_FIN_PROMET_PO_PARTNERIMAUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("datePickerRAZDOBLJEDO")]
        private UltraDateTimeEditor _datePickerRAZDOBLJEDO;
        [AccessedThroughProperty("datePickerRAZDOBLJEOD")]
        private UltraDateTimeEditor _datePickerRAZDOBLJEOD;
        [AccessedThroughProperty("label1DODATNIUVJET")]
        private UltraLabel _label1DODATNIUVJET;
        [AccessedThroughProperty("label1DOPARTNERA")]
        private UltraLabel _label1DOPARTNERA;
        [AccessedThroughProperty("label1IDAKTIVNOST")]
        private UltraLabel _label1IDAKTIVNOST;
        [AccessedThroughProperty("label1MT")]
        private UltraLabel _label1MT;
        [AccessedThroughProperty("label1ODPARTNERA")]
        private UltraLabel _label1ODPARTNERA;
        [AccessedThroughProperty("label1ORG")]
        private UltraLabel _label1ORG;
        [AccessedThroughProperty("label1POCETNIKONTO")]
        private UltraLabel _label1POCETNIKONTO;
        [AccessedThroughProperty("label1RAZDOBLJEDO")]
        private UltraLabel _label1RAZDOBLJEDO;
        [AccessedThroughProperty("label1RAZDOBLJEOD")]
        private UltraLabel _label1RAZDOBLJEOD;
        [AccessedThroughProperty("label1ZAVRSNIKONTO")]
        private UltraLabel _label1ZAVRSNIKONTO;
        [AccessedThroughProperty("textDODATNIUVJET")]
        private UltraTextEditor _textDODATNIUVJET;
        [AccessedThroughProperty("textDOPARTNERA")]
        private UltraNumericEditor _textDOPARTNERA;
        [AccessedThroughProperty("textIDAKTIVNOST")]
        private UltraNumericEditor _textIDAKTIVNOST;
        [AccessedThroughProperty("textMT")]
        private UltraNumericEditor _textMT;
        [AccessedThroughProperty("textODPARTNERA")]
        private UltraNumericEditor _textODPARTNERA;
        [AccessedThroughProperty("textORG")]
        private UltraNumericEditor _textORG;
        [AccessedThroughProperty("textPOCETNIKONTO")]
        private UltraTextEditor _textPOCETNIKONTO;
        [AccessedThroughProperty("textZAVRSNIKONTO")]
        private UltraTextEditor _textZAVRSNIKONTO;
        [AccessedThroughProperty("userControlDataGridS_FIN_PROMET_PO_PARTNERIMA")]
        private S_FIN_PROMET_PO_PARTNERIMAUserDataGrid _userControlDataGridS_FIN_PROMET_PO_PARTNERIMA;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_FIN_PROMET_PO_PARTNERIMA;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_FIN_PROMET_PO_PARTNERIMAUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_FIN_PROMET_PO_PARTNERIMADescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_FIN_PROMET_PO_PARTNERIMADescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_FIN_PROMET_PO_PARTNERIMADataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_FIN_PROMET_PO_PARTNERIMADataSet>(this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid);
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
            if ((this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.FillByPage;
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.ParameterODPARTNERA = int.Parse(this.textODPARTNERA.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.ParameterDOPARTNERA = int.Parse(this.textDOPARTNERA.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.ParameterMT = int.Parse(this.textMT.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.ParameterORG = int.Parse(this.textORG.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.ParameterIDAKTIVNOST = int.Parse(this.textIDAKTIVNOST.Value.ToString(), CultureInfo.CurrentCulture);
                if (this.datePickerRAZDOBLJEOD.Value == null)
                {
                    this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.ParameterRAZDOBLJEOD = DateTime.MinValue;
                }
                else
                {
                    this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.ParameterRAZDOBLJEOD = DateTime.Parse(this.datePickerRAZDOBLJEOD.Value.ToString(), CultureInfo.CurrentCulture);
                }
                if (this.datePickerRAZDOBLJEDO.Value == null)
                {
                    this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.ParameterRAZDOBLJEDO = DateTime.MinValue;
                }
                else
                {
                    this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.ParameterRAZDOBLJEDO = DateTime.Parse(this.datePickerRAZDOBLJEDO.Value.ToString(), CultureInfo.CurrentCulture);
                }
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.ParameterDODATNIUVJET = this.textDODATNIUVJET.Text;
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.ParameterPOCETNIKONTO = this.textPOCETNIKONTO.Text;
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.ParameterZAVRSNIKONTO = this.textZAVRSNIKONTO.Text;
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.Fill();
                ((S_FIN_PROMET_PO_PARTNERIMAWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("ODPARTNERA", typeof(int));
            table2.Columns.Add(column);
            column = new DataColumn("DOPARTNERA", typeof(int));
            table2.Columns.Add(column);
            column = new DataColumn("MT", typeof(int));
            table2.Columns.Add(column);
            column = new DataColumn("ORG", typeof(int));
            table2.Columns.Add(column);
            column = new DataColumn("IDAKTIVNOST", typeof(int));
            table2.Columns.Add(column);
            column = new DataColumn("RAZDOBLJEOD", typeof(DateTime));
            table2.Columns.Add(column);
            column = new DataColumn("RAZDOBLJEDO", typeof(DateTime));
            table2.Columns.Add(column);
            column = new DataColumn("DODATNIUVJET", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("POCETNIKONTO", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("ZAVRSNIKONTO", typeof(string));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["ODPARTNERA"] = int.Parse(this.textODPARTNERA.Value.ToString(), CultureInfo.CurrentCulture);
            row2["DOPARTNERA"] = int.Parse(this.textDOPARTNERA.Value.ToString(), CultureInfo.CurrentCulture);
            row2["MT"] = int.Parse(this.textMT.Value.ToString(), CultureInfo.CurrentCulture);
            row2["ORG"] = int.Parse(this.textORG.Value.ToString(), CultureInfo.CurrentCulture);
            row2["IDAKTIVNOST"] = int.Parse(this.textIDAKTIVNOST.Value.ToString(), CultureInfo.CurrentCulture);
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
            row2["DODATNIUVJET"] = this.textDODATNIUVJET.Text;
            row2["POCETNIKONTO"] = this.textPOCETNIKONTO.Text;
            row2["ZAVRSNIKONTO"] = this.textZAVRSNIKONTO.Text;
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
            ResourceManager manager = new ResourceManager(typeof(S_FIN_PROMET_PO_PARTNERIMAUserControl));
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA = new TableLayoutPanel();
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SuspendLayout();
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.AutoSize = true;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Dock = DockStyle.Fill;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Size = size;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.ColumnCount = 2;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.RowCount = 11;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.RowStyles.Add(new RowStyle());
            this.label1ODPARTNERA = new UltraLabel();
            this.textODPARTNERA = new UltraNumericEditor();
            this.label1DOPARTNERA = new UltraLabel();
            this.textDOPARTNERA = new UltraNumericEditor();
            this.label1MT = new UltraLabel();
            this.textMT = new UltraNumericEditor();
            this.label1ORG = new UltraLabel();
            this.textORG = new UltraNumericEditor();
            this.label1IDAKTIVNOST = new UltraLabel();
            this.textIDAKTIVNOST = new UltraNumericEditor();
            this.label1RAZDOBLJEOD = new UltraLabel();
            this.datePickerRAZDOBLJEOD = new UltraDateTimeEditor();
            this.label1RAZDOBLJEDO = new UltraLabel();
            this.datePickerRAZDOBLJEDO = new UltraDateTimeEditor();
            this.label1DODATNIUVJET = new UltraLabel();
            this.textDODATNIUVJET = new UltraTextEditor();
            this.label1POCETNIKONTO = new UltraLabel();
            this.textPOCETNIKONTO = new UltraTextEditor();
            this.label1ZAVRSNIKONTO = new UltraLabel();
            this.textZAVRSNIKONTO = new UltraTextEditor();
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA = new S_FIN_PROMET_PO_PARTNERIMAUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textODPARTNERA).BeginInit();
            ((ISupportInitialize) this.textDOPARTNERA).BeginInit();
            ((ISupportInitialize) this.textMT).BeginInit();
            ((ISupportInitialize) this.textORG).BeginInit();
            ((ISupportInitialize) this.textIDAKTIVNOST).BeginInit();
            ((ISupportInitialize) this.textDODATNIUVJET).BeginInit();
            ((ISupportInitialize) this.textPOCETNIKONTO).BeginInit();
            ((ISupportInitialize) this.textZAVRSNIKONTO).BeginInit();
            this.SuspendLayout();
            this.label1ODPARTNERA.Name = "label1ODPARTNERA";
            this.label1ODPARTNERA.TabIndex = 1;
            this.label1ODPARTNERA.Tag = "labelODPARTNERA";
            this.label1ODPARTNERA.AutoSize = true;
            this.label1ODPARTNERA.StyleSetName = "FieldUltraLabel";
            this.label1ODPARTNERA.Text = "ODPARTNERA  :";
            this.label1ODPARTNERA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ODPARTNERA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ODPARTNERA.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.label1ODPARTNERA, 0, 0);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.label1ODPARTNERA, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.label1ODPARTNERA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1ODPARTNERA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ODPARTNERA.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textODPARTNERA.Location = point;
            this.textODPARTNERA.Name = "textODPARTNERA";
            this.textODPARTNERA.Tag = "ODPARTNERA";
            this.textODPARTNERA.TabIndex = 0;
            size = new System.Drawing.Size(0x4e, 0x16);
            this.textODPARTNERA.Size = size;
            this.textODPARTNERA.PromptChar = ' ';
            this.textODPARTNERA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textODPARTNERA.NumericType = NumericType.Integer;
            this.textODPARTNERA.MaskInput = "{LOC}-nnnnnnnnn";
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.textODPARTNERA, 1, 0);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.textODPARTNERA, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.textODPARTNERA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textODPARTNERA.Margin = padding;
            size = new System.Drawing.Size(0x4e, 0x16);
            this.textODPARTNERA.MinimumSize = size;
            this.label1DOPARTNERA.Name = "label1DOPARTNERA";
            this.label1DOPARTNERA.TabIndex = 1;
            this.label1DOPARTNERA.Tag = "labelDOPARTNERA";
            this.label1DOPARTNERA.AutoSize = true;
            this.label1DOPARTNERA.StyleSetName = "FieldUltraLabel";
            this.label1DOPARTNERA.Text = "DOPARTNERA  :";
            this.label1DOPARTNERA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DOPARTNERA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1DOPARTNERA.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.label1DOPARTNERA, 0, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.label1DOPARTNERA, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.label1DOPARTNERA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DOPARTNERA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DOPARTNERA.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textDOPARTNERA.Location = point;
            this.textDOPARTNERA.Name = "textDOPARTNERA";
            this.textDOPARTNERA.Tag = "DOPARTNERA";
            this.textDOPARTNERA.TabIndex = 1;
            size = new System.Drawing.Size(0x4e, 0x16);
            this.textDOPARTNERA.Size = size;
            this.textDOPARTNERA.PromptChar = ' ';
            this.textDOPARTNERA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textDOPARTNERA.NumericType = NumericType.Integer;
            this.textDOPARTNERA.MaskInput = "{LOC}-nnnnnnnnn";
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.textDOPARTNERA, 1, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.textDOPARTNERA, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.textDOPARTNERA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDOPARTNERA.Margin = padding;
            size = new System.Drawing.Size(0x4e, 0x16);
            this.textDOPARTNERA.MinimumSize = size;
            this.label1MT.Name = "label1MT";
            this.label1MT.TabIndex = 1;
            this.label1MT.Tag = "labelMT";
            this.label1MT.AutoSize = true;
            this.label1MT.StyleSetName = "FieldUltraLabel";
            this.label1MT.Text = "MT  :";
            this.label1MT.Appearance.TextVAlign = VAlign.Middle;
            this.label1MT.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1MT.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.label1MT, 0, 2);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.label1MT, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.label1MT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MT.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textMT.Location = point;
            this.textMT.Name = "textMT";
            this.textMT.Tag = "MT";
            this.textMT.TabIndex = 2;
            size = new System.Drawing.Size(0x4e, 0x16);
            this.textMT.Size = size;
            this.textMT.PromptChar = ' ';
            this.textMT.Enter += new EventHandler(this.numericEditor_Enter);
            this.textMT.NumericType = NumericType.Integer;
            this.textMT.MaskInput = "{LOC}-nnnnnnnnn";
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.textMT, 1, 2);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.textMT, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.textMT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMT.Margin = padding;
            size = new System.Drawing.Size(0x4e, 0x16);
            this.textMT.MinimumSize = size;
            this.label1ORG.Name = "label1ORG";
            this.label1ORG.TabIndex = 1;
            this.label1ORG.Tag = "labelORG";
            this.label1ORG.AutoSize = true;
            this.label1ORG.StyleSetName = "FieldUltraLabel";
            this.label1ORG.Text = "ORG  :";
            this.label1ORG.Appearance.TextVAlign = VAlign.Middle;
            this.label1ORG.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ORG.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.label1ORG, 0, 3);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.label1ORG, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.label1ORG, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ORG.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ORG.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textORG.Location = point;
            this.textORG.Name = "textORG";
            this.textORG.Tag = "ORG";
            this.textORG.TabIndex = 3;
            size = new System.Drawing.Size(0x4e, 0x16);
            this.textORG.Size = size;
            this.textORG.PromptChar = ' ';
            this.textORG.Enter += new EventHandler(this.numericEditor_Enter);
            this.textORG.NumericType = NumericType.Integer;
            this.textORG.MaskInput = "{LOC}-nnnnnnnnn";
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.textORG, 1, 3);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.textORG, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.textORG, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textORG.Margin = padding;
            size = new System.Drawing.Size(0x4e, 0x16);
            this.textORG.MinimumSize = size;
            this.label1IDAKTIVNOST.Name = "label1IDAKTIVNOST";
            this.label1IDAKTIVNOST.TabIndex = 1;
            this.label1IDAKTIVNOST.Tag = "labelIDAKTIVNOST";
            this.label1IDAKTIVNOST.AutoSize = true;
            this.label1IDAKTIVNOST.StyleSetName = "FieldUltraLabel";
            this.label1IDAKTIVNOST.Text = "IDAKTIVNOST  :";
            this.label1IDAKTIVNOST.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDAKTIVNOST.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1IDAKTIVNOST.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.label1IDAKTIVNOST, 0, 4);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.label1IDAKTIVNOST, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.label1IDAKTIVNOST, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDAKTIVNOST.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDAKTIVNOST.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDAKTIVNOST.Location = point;
            this.textIDAKTIVNOST.Name = "textIDAKTIVNOST";
            this.textIDAKTIVNOST.Tag = "IDAKTIVNOST";
            this.textIDAKTIVNOST.TabIndex = 4;
            size = new System.Drawing.Size(0x4e, 0x16);
            this.textIDAKTIVNOST.Size = size;
            this.textIDAKTIVNOST.PromptChar = ' ';
            this.textIDAKTIVNOST.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDAKTIVNOST.NumericType = NumericType.Integer;
            this.textIDAKTIVNOST.MaskInput = "{LOC}-nnnnnnnnn";
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.textIDAKTIVNOST, 1, 4);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.textIDAKTIVNOST, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.textIDAKTIVNOST, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDAKTIVNOST.Margin = padding;
            size = new System.Drawing.Size(0x4e, 0x16);
            this.textIDAKTIVNOST.MinimumSize = size;
            this.label1RAZDOBLJEOD.Name = "label1RAZDOBLJEOD";
            this.label1RAZDOBLJEOD.TabIndex = 1;
            this.label1RAZDOBLJEOD.Tag = "labelRAZDOBLJEOD";
            this.label1RAZDOBLJEOD.AutoSize = true;
            this.label1RAZDOBLJEOD.StyleSetName = "FieldUltraLabel";
            this.label1RAZDOBLJEOD.Text = "RAZDOBLJEOD  :";
            this.label1RAZDOBLJEOD.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAZDOBLJEOD.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1RAZDOBLJEOD.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.label1RAZDOBLJEOD, 0, 5);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.label1RAZDOBLJEOD, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.label1RAZDOBLJEOD, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RAZDOBLJEOD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAZDOBLJEOD.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerRAZDOBLJEOD.Location = point;
            this.datePickerRAZDOBLJEOD.Name = "datePickerRAZDOBLJEOD";
            this.datePickerRAZDOBLJEOD.Tag = "RAZDOBLJEOD";
            this.datePickerRAZDOBLJEOD.TabIndex = 5;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerRAZDOBLJEOD.Size = size;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.datePickerRAZDOBLJEOD, 1, 5);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.datePickerRAZDOBLJEOD, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.datePickerRAZDOBLJEOD, 1);
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
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.label1RAZDOBLJEDO, 0, 6);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.label1RAZDOBLJEDO, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.label1RAZDOBLJEDO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RAZDOBLJEDO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAZDOBLJEDO.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerRAZDOBLJEDO.Location = point;
            this.datePickerRAZDOBLJEDO.Name = "datePickerRAZDOBLJEDO";
            this.datePickerRAZDOBLJEDO.Tag = "RAZDOBLJEDO";
            this.datePickerRAZDOBLJEDO.TabIndex = 6;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerRAZDOBLJEDO.Size = size;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.datePickerRAZDOBLJEDO, 1, 6);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.datePickerRAZDOBLJEDO, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.datePickerRAZDOBLJEDO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerRAZDOBLJEDO.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerRAZDOBLJEDO.MinimumSize = size;
            this.label1DODATNIUVJET.Name = "label1DODATNIUVJET";
            this.label1DODATNIUVJET.TabIndex = 1;
            this.label1DODATNIUVJET.Tag = "labelDODATNIUVJET";
            this.label1DODATNIUVJET.AutoSize = true;
            this.label1DODATNIUVJET.StyleSetName = "FieldUltraLabel";
            this.label1DODATNIUVJET.Text = "DODATNIUVJET  :";
            this.label1DODATNIUVJET.Appearance.TextVAlign = VAlign.Middle;
            this.label1DODATNIUVJET.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1DODATNIUVJET.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.label1DODATNIUVJET, 0, 7);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.label1DODATNIUVJET, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.label1DODATNIUVJET, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DODATNIUVJET.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DODATNIUVJET.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textDODATNIUVJET.Location = point;
            this.textDODATNIUVJET.Name = "textDODATNIUVJET";
            this.textDODATNIUVJET.Tag = "DODATNIUVJET";
            this.textDODATNIUVJET.TabIndex = 7;
            size = new System.Drawing.Size(30, 0x16);
            this.textDODATNIUVJET.Size = size;
            this.textDODATNIUVJET.MaxLength = 2;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.textDODATNIUVJET, 1, 7);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.textDODATNIUVJET, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.textDODATNIUVJET, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDODATNIUVJET.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textDODATNIUVJET.MinimumSize = size;
            this.label1POCETNIKONTO.Name = "label1POCETNIKONTO";
            this.label1POCETNIKONTO.TabIndex = 1;
            this.label1POCETNIKONTO.Tag = "labelPOCETNIKONTO";
            this.label1POCETNIKONTO.AutoSize = true;
            this.label1POCETNIKONTO.StyleSetName = "FieldUltraLabel";
            this.label1POCETNIKONTO.Text = "POCETNIKONTO  :";
            this.label1POCETNIKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1POCETNIKONTO.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1POCETNIKONTO.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.label1POCETNIKONTO, 0, 8);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.label1POCETNIKONTO, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.label1POCETNIKONTO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POCETNIKONTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POCETNIKONTO.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOCETNIKONTO.Location = point;
            this.textPOCETNIKONTO.Name = "textPOCETNIKONTO";
            this.textPOCETNIKONTO.Tag = "POCETNIKONTO";
            this.textPOCETNIKONTO.TabIndex = 8;
            size = new System.Drawing.Size(0x79, 0x16);
            this.textPOCETNIKONTO.Size = size;
            this.textPOCETNIKONTO.MaxLength = 15;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.textPOCETNIKONTO, 1, 8);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.textPOCETNIKONTO, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.textPOCETNIKONTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOCETNIKONTO.Margin = padding;
            size = new System.Drawing.Size(0x79, 0x16);
            this.textPOCETNIKONTO.MinimumSize = size;
            this.label1ZAVRSNIKONTO.Name = "label1ZAVRSNIKONTO";
            this.label1ZAVRSNIKONTO.TabIndex = 1;
            this.label1ZAVRSNIKONTO.Tag = "labelZAVRSNIKONTO";
            this.label1ZAVRSNIKONTO.AutoSize = true;
            this.label1ZAVRSNIKONTO.StyleSetName = "FieldUltraLabel";
            this.label1ZAVRSNIKONTO.Text = "ZAVRSNIKONTO  :";
            this.label1ZAVRSNIKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZAVRSNIKONTO.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ZAVRSNIKONTO.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.label1ZAVRSNIKONTO, 0, 9);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.label1ZAVRSNIKONTO, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.label1ZAVRSNIKONTO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZAVRSNIKONTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZAVRSNIKONTO.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textZAVRSNIKONTO.Location = point;
            this.textZAVRSNIKONTO.Name = "textZAVRSNIKONTO";
            this.textZAVRSNIKONTO.Tag = "ZAVRSNIKONTO";
            this.textZAVRSNIKONTO.TabIndex = 9;
            size = new System.Drawing.Size(0x79, 0x16);
            this.textZAVRSNIKONTO.Size = size;
            this.textZAVRSNIKONTO.MaxLength = 15;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.textZAVRSNIKONTO, 1, 9);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.textZAVRSNIKONTO, 1);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.textZAVRSNIKONTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZAVRSNIKONTO.Margin = padding;
            size = new System.Drawing.Size(0x79, 0x16);
            this.textZAVRSNIKONTO.MinimumSize = size;
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.Controls.Add(this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA, 0, 10);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetColumnSpan(this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA, 2);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.SetRowSpan(this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.MinimumSize = size;
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA);
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.Name = "userControlDataGridS_FIN_PROMET_PO_PARTNERIMA";
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DockPadding.All = 5;
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.FillAtStartup = false;
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_FIN_PROMET_PO_PARTNERIMAWorkWith";
            this.Text = "Work With S_FIN_PROMET_PO_PARTNERIMA";
            this.Load += new EventHandler(this.S_FIN_PROMET_PO_PARTNERIMAUserControl_Load);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.ResumeLayout(false);
            this.layoutManagerformS_FIN_PROMET_PO_PARTNERIMA.PerformLayout();
            ((ISupportInitialize) this.textODPARTNERA).EndInit();
            ((ISupportInitialize) this.textDOPARTNERA).EndInit();
            ((ISupportInitialize) this.textMT).EndInit();
            ((ISupportInitialize) this.textORG).EndInit();
            ((ISupportInitialize) this.textIDAKTIVNOST).EndInit();
            ((ISupportInitialize) this.textDODATNIUVJET).EndInit();
            ((ISupportInitialize) this.textPOCETNIKONTO).EndInit();
            ((ISupportInitialize) this.textZAVRSNIKONTO).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textODPARTNERA.Text = "0";
            this.textDOPARTNERA.Text = "0";
            this.textMT.Text = "0";
            this.textORG.Text = "0";
            this.textIDAKTIVNOST.Text = "0";
            this.datePickerRAZDOBLJEOD.Text = "";
            this.datePickerRAZDOBLJEDO.Text = "";
            this.textDODATNIUVJET.Text = "";
            this.textPOCETNIKONTO.Text = "";
            this.textZAVRSNIKONTO.Text = "";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("ODPARTNERA") && (this.m_FillByRow["ODPARTNERA"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textODPARTNERA, this.m_FillByRow["ODPARTNERA"].ToString(), this.m_FillByRow.Table.Columns["ODPARTNERA"].DataType);
                    this.parameterSeted = true;
                    this.textODPARTNERA.Visible = false;
                    this.label1ODPARTNERA.Visible = false;
                    str = str + "," + this.m_FillByRow["ODPARTNERA"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("DOPARTNERA") && (this.m_FillByRow["DOPARTNERA"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textDOPARTNERA, this.m_FillByRow["DOPARTNERA"].ToString(), this.m_FillByRow.Table.Columns["DOPARTNERA"].DataType);
                    this.parameterSeted = true;
                    this.textDOPARTNERA.Visible = false;
                    this.label1DOPARTNERA.Visible = false;
                    str = str + "," + this.m_FillByRow["DOPARTNERA"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("MT") && (this.m_FillByRow["MT"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textMT, this.m_FillByRow["MT"].ToString(), this.m_FillByRow.Table.Columns["MT"].DataType);
                    this.parameterSeted = true;
                    this.textMT.Visible = false;
                    this.label1MT.Visible = false;
                    str = str + "," + this.m_FillByRow["MT"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("ORG") && (this.m_FillByRow["ORG"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textORG, this.m_FillByRow["ORG"].ToString(), this.m_FillByRow.Table.Columns["ORG"].DataType);
                    this.parameterSeted = true;
                    this.textORG.Visible = false;
                    this.label1ORG.Visible = false;
                    str = str + "," + this.m_FillByRow["ORG"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("IDAKTIVNOST") && (this.m_FillByRow["IDAKTIVNOST"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textIDAKTIVNOST, this.m_FillByRow["IDAKTIVNOST"].ToString(), this.m_FillByRow.Table.Columns["IDAKTIVNOST"].DataType);
                    this.parameterSeted = true;
                    this.textIDAKTIVNOST.Visible = false;
                    this.label1IDAKTIVNOST.Visible = false;
                    str = str + "," + this.m_FillByRow["IDAKTIVNOST"].ToString() + " ";
                }
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
                if (this.m_FillByRow.Table.Columns.Contains("DODATNIUVJET") && (this.m_FillByRow["DODATNIUVJET"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textDODATNIUVJET, this.m_FillByRow["DODATNIUVJET"].ToString(), this.m_FillByRow.Table.Columns["DODATNIUVJET"].DataType);
                    this.parameterSeted = true;
                    this.textDODATNIUVJET.Visible = false;
                    this.label1DODATNIUVJET.Visible = false;
                    str = str + "," + this.m_FillByRow["DODATNIUVJET"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("POCETNIKONTO") && (this.m_FillByRow["POCETNIKONTO"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textPOCETNIKONTO, this.m_FillByRow["POCETNIKONTO"].ToString(), this.m_FillByRow.Table.Columns["POCETNIKONTO"].DataType);
                    this.parameterSeted = true;
                    this.textPOCETNIKONTO.Visible = false;
                    this.label1POCETNIKONTO.Visible = false;
                    str = str + "," + this.m_FillByRow["POCETNIKONTO"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("ZAVRSNIKONTO") && (this.m_FillByRow["ZAVRSNIKONTO"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textZAVRSNIKONTO, this.m_FillByRow["ZAVRSNIKONTO"].ToString(), this.m_FillByRow.Table.Columns["ZAVRSNIKONTO"].DataType);
                    this.parameterSeted = true;
                    this.textZAVRSNIKONTO.Visible = false;
                    this.label1ZAVRSNIKONTO.Visible = false;
                    str = str + "," + this.m_FillByRow["ZAVRSNIKONTO"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_FIN_PROMET_PO_PARTNERIMA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_FIN_PROMET_PO_PARTNERIMA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_FIN_PROMET_PO_PARTNERIMADataAdapter().Update(this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.DataSet);
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
            this.label1ODPARTNERA.Text = StringResources.S_FIN_PROMET_PO_PARTNERIMAODPARTNERAParameter;
            this.label1DOPARTNERA.Text = StringResources.S_FIN_PROMET_PO_PARTNERIMADOPARTNERAParameter;
            this.label1MT.Text = StringResources.S_FIN_PROMET_PO_PARTNERIMAMTParameter;
            this.label1ORG.Text = StringResources.S_FIN_PROMET_PO_PARTNERIMAORGParameter;
            this.label1IDAKTIVNOST.Text = StringResources.S_FIN_PROMET_PO_PARTNERIMAIDAKTIVNOSTParameter;
            this.label1RAZDOBLJEOD.Text = StringResources.S_FIN_PROMET_PO_PARTNERIMARAZDOBLJEODParameter;
            this.label1RAZDOBLJEDO.Text = StringResources.S_FIN_PROMET_PO_PARTNERIMARAZDOBLJEDOParameter;
            this.label1DODATNIUVJET.Text = StringResources.S_FIN_PROMET_PO_PARTNERIMADODATNIUVJETParameter;
            this.label1POCETNIKONTO.Text = StringResources.S_FIN_PROMET_PO_PARTNERIMAPOCETNIKONTOParameter;
            this.label1ZAVRSNIKONTO.Text = StringResources.S_FIN_PROMET_PO_PARTNERIMAZAVRSNIKONTOParameter;
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

        private void S_FIN_PROMET_PO_PARTNERIMAUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_FIN_PROMET_PO_PARTNERIMA ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_FIN_PROMET_PO_PARTNERIMA ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_FIN_PROMET_PO_PARTNERIMAController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataView[this.userControlDataGridS_FIN_PROMET_PO_PARTNERIMA.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1DODATNIUVJET
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DODATNIUVJET;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DODATNIUVJET = value;
            }
        }

        protected virtual UltraLabel label1DOPARTNERA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DOPARTNERA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DOPARTNERA = value;
            }
        }

        protected virtual UltraLabel label1IDAKTIVNOST
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDAKTIVNOST;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDAKTIVNOST = value;
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

        protected virtual UltraLabel label1ODPARTNERA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ODPARTNERA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ODPARTNERA = value;
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

        protected virtual UltraLabel label1POCETNIKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POCETNIKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POCETNIKONTO = value;
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

        protected virtual UltraLabel label1ZAVRSNIKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZAVRSNIKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZAVRSNIKONTO = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraTextEditor textDODATNIUVJET
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDODATNIUVJET;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDODATNIUVJET = value;
            }
        }

        protected virtual UltraNumericEditor textDOPARTNERA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDOPARTNERA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDOPARTNERA = value;
            }
        }

        protected virtual UltraNumericEditor textIDAKTIVNOST
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDAKTIVNOST;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDAKTIVNOST = value;
            }
        }

        protected virtual UltraNumericEditor textMT
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

        protected virtual UltraNumericEditor textODPARTNERA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textODPARTNERA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textODPARTNERA = value;
            }
        }

        protected virtual UltraNumericEditor textORG
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

        protected virtual UltraTextEditor textPOCETNIKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOCETNIKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOCETNIKONTO = value;
            }
        }

        protected virtual UltraTextEditor textZAVRSNIKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZAVRSNIKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZAVRSNIKONTO = value;
            }
        }

        protected virtual S_FIN_PROMET_PO_PARTNERIMAUserDataGrid userControlDataGridS_FIN_PROMET_PO_PARTNERIMA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_FIN_PROMET_PO_PARTNERIMA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_FIN_PROMET_PO_PARTNERIMA = value;
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

