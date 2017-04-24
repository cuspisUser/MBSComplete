namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Win;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class RADNIKFormRADNIKKreditiUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkKREDITAKTIVAN")]
        private UltraCheckEditor _checkKREDITAKTIVAN;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("datePickerDATUMUGOVORA")]
        private UltraDateTimeEditor _datePickerDATUMUGOVORA;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1DATUMUGOVORA")]
        private UltraLabel _label1DATUMUGOVORA;
        [AccessedThroughProperty("label1KREDITAKTIVAN")]
        private UltraLabel _label1KREDITAKTIVAN;
        [AccessedThroughProperty("label1KREDITOTPLACENIIZNOS")]
        private UltraLabel _label1KREDITOTPLACENIIZNOS;
        [AccessedThroughProperty("label1KREDITOTPLACENORATA")]
        private UltraLabel _label1KREDITOTPLACENORATA;
        [AccessedThroughProperty("label1MOKREDITOR")]
        private UltraLabel _label1MOKREDITOR;
        [AccessedThroughProperty("label1MZKREDITOR")]
        private UltraLabel _label1MZKREDITOR;
        [AccessedThroughProperty("label1OPISPLACANJAKREDITOR")]
        private UltraLabel _label1OPISPLACANJAKREDITOR;
        [AccessedThroughProperty("label1PARTIJAKREDITASPECIFIKACIJA")]
        private UltraLabel _label1PARTIJAKREDITASPECIFIKACIJA;
        [AccessedThroughProperty("label1POKREDITOR")]
        private UltraLabel _label1POKREDITOR;
        [AccessedThroughProperty("label1PZKREDITOR")]
        private UltraLabel _label1PZKREDITOR;
        [AccessedThroughProperty("label1SIFRAOPISAPLACANJAKREDITOR")]
        private UltraLabel _label1SIFRAOPISAPLACANJAKREDITOR;
        [AccessedThroughProperty("label1ZADBROJRATAOBUSTAVE")]
        private UltraLabel _label1ZADBROJRATAOBUSTAVE;
        [AccessedThroughProperty("label1ZADIZNOSRATEKREDITA")]
        private UltraLabel _label1ZADIZNOSRATEKREDITA;
        [AccessedThroughProperty("label1ZADKREDITIIDKREDITOR")]
        private UltraLabel _label1ZADKREDITIIDKREDITOR;
        [AccessedThroughProperty("label1ZADKREDITINAZIVKREDITOR")]
        private UltraLabel _label1ZADKREDITINAZIVKREDITOR;
        [AccessedThroughProperty("label1ZADKREDITIPRIMATELJKREDITOR1")]
        private UltraLabel _label1ZADKREDITIPRIMATELJKREDITOR1;
        [AccessedThroughProperty("label1ZADKREDITIPRIMATELJKREDITOR2")]
        private UltraLabel _label1ZADKREDITIPRIMATELJKREDITOR2;
        [AccessedThroughProperty("label1ZADKREDITIPRIMATELJKREDITOR3")]
        private UltraLabel _label1ZADKREDITIPRIMATELJKREDITOR3;
        [AccessedThroughProperty("label1ZADUKUPNIZNOSKREDITA")]
        private UltraLabel _label1ZADUKUPNIZNOSKREDITA;
        [AccessedThroughProperty("label1ZADVECOTPLACENOBROJRATA")]
        private UltraLabel _label1ZADVECOTPLACENOBROJRATA;
        [AccessedThroughProperty("label1ZADVECOTPLACENOUKUPNIIZNOS")]
        private UltraLabel _label1ZADVECOTPLACENOUKUPNIIZNOS;
        [AccessedThroughProperty("labelKREDITOTPLACENIIZNOS")]
        private UltraLabel _labelKREDITOTPLACENIIZNOS;
        [AccessedThroughProperty("labelKREDITOTPLACENORATA")]
        private UltraLabel _labelKREDITOTPLACENORATA;
        [AccessedThroughProperty("labelZADKREDITINAZIVKREDITOR")]
        private UltraLabel _labelZADKREDITINAZIVKREDITOR;
        [AccessedThroughProperty("labelZADKREDITIPRIMATELJKREDITOR1")]
        private UltraLabel _labelZADKREDITIPRIMATELJKREDITOR1;
        [AccessedThroughProperty("labelZADKREDITIPRIMATELJKREDITOR2")]
        private UltraLabel _labelZADKREDITIPRIMATELJKREDITOR2;
        [AccessedThroughProperty("labelZADKREDITIPRIMATELJKREDITOR3")]
        private UltraLabel _labelZADKREDITIPRIMATELJKREDITOR3;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textMOKREDITOR")]
        private UltraTextEditor _textMOKREDITOR;
        [AccessedThroughProperty("textMZKREDITOR")]
        private UltraTextEditor _textMZKREDITOR;
        [AccessedThroughProperty("textOPISPLACANJAKREDITOR")]
        private UltraTextEditor _textOPISPLACANJAKREDITOR;
        [AccessedThroughProperty("textPARTIJAKREDITASPECIFIKACIJA")]
        private UltraTextEditor _textPARTIJAKREDITASPECIFIKACIJA;
        [AccessedThroughProperty("textPOKREDITOR")]
        private UltraTextEditor _textPOKREDITOR;
        [AccessedThroughProperty("textPZKREDITOR")]
        private UltraTextEditor _textPZKREDITOR;
        [AccessedThroughProperty("textSIFRAOPISAPLACANJAKREDITOR")]
        private UltraTextEditor _textSIFRAOPISAPLACANJAKREDITOR;
        [AccessedThroughProperty("textZADBROJRATAOBUSTAVE")]
        private UltraNumericEditor _textZADBROJRATAOBUSTAVE;
        [AccessedThroughProperty("textZADIZNOSRATEKREDITA")]
        private UltraNumericEditor _textZADIZNOSRATEKREDITA;
        [AccessedThroughProperty("textZADKREDITIIDKREDITOR")]
        private UltraNumericEditor _textZADKREDITIIDKREDITOR;
        [AccessedThroughProperty("textZADUKUPNIZNOSKREDITA")]
        private UltraNumericEditor _textZADUKUPNIZNOSKREDITA;
        [AccessedThroughProperty("textZADVECOTPLACENOBROJRATA")]
        private UltraNumericEditor _textZADVECOTPLACENOBROJRATA;
        [AccessedThroughProperty("textZADVECOTPLACENOUKUPNIIZNOS")]
        private UltraNumericEditor _textZADVECOTPLACENOUKUPNIIZNOS;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRADNIKKrediti;
        private IContainer components = null;
        private RADNIKDataSet dsRADNIKDataSet1;
        protected TableLayoutPanel layoutManagerformRADNIKKrediti;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RADNIKDataSet.RADNIKKreditiRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RADNIKKrediti";
        private string m_FrameworkDescription = StringResources.RADNIKDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        public RADNIKFormRADNIKKreditiUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("RADNIKKreditiAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("RADNIKKreditiAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (RADNIKDataSet.RADNIKKreditiRow) ((DataRowView) this.bindingSourceRADNIKKrediti.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CallPromptKREDITORZADKREDITIIDKREDITOR(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.RADNIKController.SelectKREDITORZADKREDITIIDKREDITOR(fillMethod, fillByRow);
            this.UpdateValuesKREDITORZADKREDITIIDKREDITOR(result);
        }

        private void CallViewKREDITORZADKREDITIIDKREDITOR(object sender, EventArgs e)
        {
            DataRow result = this.RADNIKController.ShowKREDITORZADKREDITIIDKREDITOR(this.m_CurrentRow);
            this.UpdateValuesKREDITORZADKREDITIIDKREDITOR(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsRADNIKDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceRADNIKKrediti.DataSource = this.RADNIKController.DataSet;
            this.dsRADNIKDataSet1 = this.RADNIKController.DataSet;
        }

        private void contextMenu1_Popup(object sender, EventArgs e)
        {
            this.m_BaseMethods.ContextMenu1PopupBase(this.contextMenu1, this.m_CurrentRow);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EndEditCurrentRow()
        {
        }

        public void Initialize(DeklaritMode mode, DataRow parentRow, bool isCopy)
        {
            this.m_ParentRow = parentRow;
            this.dsRADNIKDataSet1 = (RADNIKDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceRADNIKKrediti.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsRADNIKDataSet1.Tables["RADNIKKrediti"]);
            this.bindingSourceRADNIKKrediti.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RADNIK", this.m_Mode, this.dsRADNIKDataSet1, this.dsRADNIKDataSet1.RADNIKKrediti.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceRADNIKKrediti, "DATUMUGOVORA", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerDATUMUGOVORA.DataBindings["Text"] != null)
            {
                this.datePickerDATUMUGOVORA.DataBindings.Remove(this.datePickerDATUMUGOVORA.DataBindings["Text"]);
            }
            this.datePickerDATUMUGOVORA.DataBindings.Add(binding);
            Binding binding2 = new Binding("CheckState", this.bindingSourceRADNIKKrediti, "KREDITAKTIVAN", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding2.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkKREDITAKTIVAN.DataBindings["CheckState"] != null)
            {
                this.checkKREDITAKTIVAN.DataBindings.Remove(this.checkKREDITAKTIVAN.DataBindings["CheckState"]);
            }
            this.checkKREDITAKTIVAN.DataBindings.Add(binding2);
            Binding binding3 = new Binding("Text", this.bindingSourceRADNIKKrediti, "KREDITOTPLACENIIZNOS", true);
            binding3.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelKREDITOTPLACENIIZNOS.DataBindings["Text"] != null)
            {
                this.labelKREDITOTPLACENIIZNOS.DataBindings.Remove(this.labelKREDITOTPLACENIIZNOS.DataBindings["Text"]);
            }
            this.labelKREDITOTPLACENIIZNOS.DataBindings.Add(binding3);
            Binding binding4 = new Binding("Text", this.bindingSourceRADNIKKrediti, "KREDITOTPLACENORATA", true);
            binding4.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelKREDITOTPLACENORATA.DataBindings["Text"] != null)
            {
                this.labelKREDITOTPLACENORATA.DataBindings.Remove(this.labelKREDITOTPLACENORATA.DataBindings["Text"]);
            }
            this.labelKREDITOTPLACENORATA.DataBindings.Add(binding4);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (RADNIKDataSet.RADNIKKreditiRow) ((DataRowView) this.bindingSourceRADNIKKrediti.Current).Row;
                this.textZADKREDITIIDKREDITOR.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textZADKREDITIIDKREDITOR.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (RADNIKDataSet.RADNIKKreditiRow) ((DataRowView) this.bindingSourceRADNIKKrediti.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(RADNIKFormRADNIKKreditiUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRADNIKKrediti = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIKKrediti).BeginInit();
            this.layoutManagerformRADNIKKrediti = new TableLayoutPanel();
            this.layoutManagerformRADNIKKrediti.SuspendLayout();
            this.layoutManagerformRADNIKKrediti.AutoSize = true;
            this.layoutManagerformRADNIKKrediti.Dock = DockStyle.Fill;
            this.layoutManagerformRADNIKKrediti.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRADNIKKrediti.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRADNIKKrediti.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRADNIKKrediti.Size = size;
            this.layoutManagerformRADNIKKrediti.ColumnCount = 2;
            this.layoutManagerformRADNIKKrediti.RowCount = 0x16;
            this.layoutManagerformRADNIKKrediti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIKKrediti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKKrediti.RowStyles.Add(new RowStyle());
            this.label1ZADKREDITIIDKREDITOR = new UltraLabel();
            this.textZADKREDITIIDKREDITOR = new UltraNumericEditor();
            this.label1DATUMUGOVORA = new UltraLabel();
            this.datePickerDATUMUGOVORA = new UltraDateTimeEditor();
            this.label1KREDITAKTIVAN = new UltraLabel();
            this.checkKREDITAKTIVAN = new UltraCheckEditor();
            this.label1ZADKREDITINAZIVKREDITOR = new UltraLabel();
            this.labelZADKREDITINAZIVKREDITOR = new UltraLabel();
            this.label1ZADKREDITIPRIMATELJKREDITOR1 = new UltraLabel();
            this.labelZADKREDITIPRIMATELJKREDITOR1 = new UltraLabel();
            this.label1ZADKREDITIPRIMATELJKREDITOR2 = new UltraLabel();
            this.labelZADKREDITIPRIMATELJKREDITOR2 = new UltraLabel();
            this.label1ZADKREDITIPRIMATELJKREDITOR3 = new UltraLabel();
            this.labelZADKREDITIPRIMATELJKREDITOR3 = new UltraLabel();
            this.label1SIFRAOPISAPLACANJAKREDITOR = new UltraLabel();
            this.textSIFRAOPISAPLACANJAKREDITOR = new UltraTextEditor();
            this.label1OPISPLACANJAKREDITOR = new UltraLabel();
            this.textOPISPLACANJAKREDITOR = new UltraTextEditor();
            this.label1MOKREDITOR = new UltraLabel();
            this.textMOKREDITOR = new UltraTextEditor();
            this.label1POKREDITOR = new UltraLabel();
            this.textPOKREDITOR = new UltraTextEditor();
            this.label1MZKREDITOR = new UltraLabel();
            this.textMZKREDITOR = new UltraTextEditor();
            this.label1PZKREDITOR = new UltraLabel();
            this.textPZKREDITOR = new UltraTextEditor();
            this.label1ZADIZNOSRATEKREDITA = new UltraLabel();
            this.textZADIZNOSRATEKREDITA = new UltraNumericEditor();
            this.label1ZADBROJRATAOBUSTAVE = new UltraLabel();
            this.textZADBROJRATAOBUSTAVE = new UltraNumericEditor();
            this.label1ZADUKUPNIZNOSKREDITA = new UltraLabel();
            this.textZADUKUPNIZNOSKREDITA = new UltraNumericEditor();
            this.label1ZADVECOTPLACENOBROJRATA = new UltraLabel();
            this.textZADVECOTPLACENOBROJRATA = new UltraNumericEditor();
            this.label1ZADVECOTPLACENOUKUPNIIZNOS = new UltraLabel();
            this.textZADVECOTPLACENOUKUPNIIZNOS = new UltraNumericEditor();
            this.label1KREDITOTPLACENIIZNOS = new UltraLabel();
            this.labelKREDITOTPLACENIIZNOS = new UltraLabel();
            this.label1KREDITOTPLACENORATA = new UltraLabel();
            this.labelKREDITOTPLACENORATA = new UltraLabel();
            this.label1PARTIJAKREDITASPECIFIKACIJA = new UltraLabel();
            this.textPARTIJAKREDITASPECIFIKACIJA = new UltraTextEditor();
            ((ISupportInitialize) this.textZADKREDITIIDKREDITOR).BeginInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJAKREDITOR).BeginInit();
            ((ISupportInitialize) this.textOPISPLACANJAKREDITOR).BeginInit();
            ((ISupportInitialize) this.textMOKREDITOR).BeginInit();
            ((ISupportInitialize) this.textPOKREDITOR).BeginInit();
            ((ISupportInitialize) this.textMZKREDITOR).BeginInit();
            ((ISupportInitialize) this.textPZKREDITOR).BeginInit();
            ((ISupportInitialize) this.textZADIZNOSRATEKREDITA).BeginInit();
            ((ISupportInitialize) this.textZADBROJRATAOBUSTAVE).BeginInit();
            ((ISupportInitialize) this.textZADUKUPNIZNOSKREDITA).BeginInit();
            ((ISupportInitialize) this.textZADVECOTPLACENOBROJRATA).BeginInit();
            ((ISupportInitialize) this.textZADVECOTPLACENOUKUPNIIZNOS).BeginInit();
            ((ISupportInitialize) this.textPARTIJAKREDITASPECIFIKACIJA).BeginInit();
            this.dsRADNIKDataSet1 = new RADNIKDataSet();
            this.dsRADNIKDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRADNIKDataSet1.DataSetName = "dsRADNIK";
            this.dsRADNIKDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRADNIKKrediti.DataSource = this.dsRADNIKDataSet1;
            this.bindingSourceRADNIKKrediti.DataMember = "RADNIKKrediti";
            ((ISupportInitialize) this.bindingSourceRADNIKKrediti).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1ZADKREDITIIDKREDITOR.Location = point;
            this.label1ZADKREDITIIDKREDITOR.Name = "label1ZADKREDITIIDKREDITOR";
            this.label1ZADKREDITIIDKREDITOR.TabIndex = 1;
            this.label1ZADKREDITIIDKREDITOR.Tag = "labelZADKREDITIIDKREDITOR";
            this.label1ZADKREDITIIDKREDITOR.Text = "Šifra:";
            this.label1ZADKREDITIIDKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1ZADKREDITIIDKREDITOR.AutoSize = true;
            this.label1ZADKREDITIIDKREDITOR.Anchor = AnchorStyles.Left;
            this.label1ZADKREDITIIDKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADKREDITIIDKREDITOR.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1ZADKREDITIIDKREDITOR.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1ZADKREDITIIDKREDITOR.ImageSize = size;
            this.label1ZADKREDITIIDKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1ZADKREDITIIDKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1ZADKREDITIIDKREDITOR, 0, 0);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1ZADKREDITIIDKREDITOR, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1ZADKREDITIIDKREDITOR, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1ZADKREDITIIDKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADKREDITIIDKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1ZADKREDITIIDKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADKREDITIIDKREDITOR.Location = point;
            this.textZADKREDITIIDKREDITOR.Name = "textZADKREDITIIDKREDITOR";
            this.textZADKREDITIIDKREDITOR.Tag = "ZADKREDITIIDKREDITOR";
            this.textZADKREDITIIDKREDITOR.TabIndex = 0;
            this.textZADKREDITIIDKREDITOR.Anchor = AnchorStyles.Left;
            this.textZADKREDITIIDKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADKREDITIIDKREDITOR.ReadOnly = false;
            this.textZADKREDITIIDKREDITOR.PromptChar = ' ';
            this.textZADKREDITIIDKREDITOR.Enter += new EventHandler(this.numericEditor_Enter);
            this.textZADKREDITIIDKREDITOR.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKKrediti, "ZADKREDITIIDKREDITOR"));
            this.textZADKREDITIIDKREDITOR.NumericType = NumericType.Integer;
            this.textZADKREDITIIDKREDITOR.MaskInput = "99999999";
            EditorButton button = new EditorButton {
                Key = "editorButtonKREDITORZADKREDITIIDKREDITOR",
                Tag = "editorButtonKREDITORZADKREDITIIDKREDITOR",
                Text = "..."
            };
            this.textZADKREDITIIDKREDITOR.ButtonsRight.Add(button);
            this.textZADKREDITIIDKREDITOR.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptKREDITORZADKREDITIIDKREDITOR);
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.textZADKREDITIIDKREDITOR, 1, 0);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.textZADKREDITIIDKREDITOR, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.textZADKREDITIIDKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADKREDITIIDKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textZADKREDITIIDKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textZADKREDITIIDKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DATUMUGOVORA.Location = point;
            this.label1DATUMUGOVORA.Name = "label1DATUMUGOVORA";
            this.label1DATUMUGOVORA.TabIndex = 1;
            this.label1DATUMUGOVORA.Tag = "labelDATUMUGOVORA";
            this.label1DATUMUGOVORA.Text = "DATUMUGOVORA:";
            this.label1DATUMUGOVORA.StyleSetName = "FieldUltraLabel";
            this.label1DATUMUGOVORA.AutoSize = true;
            this.label1DATUMUGOVORA.Anchor = AnchorStyles.Left;
            this.label1DATUMUGOVORA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMUGOVORA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1DATUMUGOVORA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1DATUMUGOVORA.ImageSize = size;
            this.label1DATUMUGOVORA.Appearance.ForeColor = Color.Black;
            this.label1DATUMUGOVORA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1DATUMUGOVORA, 0, 1);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1DATUMUGOVORA, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1DATUMUGOVORA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DATUMUGOVORA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUMUGOVORA.MinimumSize = size;
            size = new System.Drawing.Size(0x7d, 0x17);
            this.label1DATUMUGOVORA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUMUGOVORA.Location = point;
            this.datePickerDATUMUGOVORA.Name = "datePickerDATUMUGOVORA";
            this.datePickerDATUMUGOVORA.Tag = "DATUMUGOVORA";
            this.datePickerDATUMUGOVORA.TabIndex = 0;
            this.datePickerDATUMUGOVORA.Anchor = AnchorStyles.Left;
            this.datePickerDATUMUGOVORA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUMUGOVORA.Enabled = true;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.datePickerDATUMUGOVORA, 1, 1);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.datePickerDATUMUGOVORA, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.datePickerDATUMUGOVORA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUMUGOVORA.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMUGOVORA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMUGOVORA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KREDITAKTIVAN.Location = point;
            this.label1KREDITAKTIVAN.Name = "label1KREDITAKTIVAN";
            this.label1KREDITAKTIVAN.TabIndex = 1;
            this.label1KREDITAKTIVAN.Tag = "labelKREDITAKTIVAN";
            this.label1KREDITAKTIVAN.Text = "Obračunavaj kredit:";
            this.label1KREDITAKTIVAN.StyleSetName = "FieldUltraLabel";
            this.label1KREDITAKTIVAN.AutoSize = true;
            this.label1KREDITAKTIVAN.Anchor = AnchorStyles.Left;
            this.label1KREDITAKTIVAN.Appearance.TextVAlign = VAlign.Middle;
            this.label1KREDITAKTIVAN.Appearance.ForeColor = Color.Black;
            this.label1KREDITAKTIVAN.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1KREDITAKTIVAN, 0, 2);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1KREDITAKTIVAN, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1KREDITAKTIVAN, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KREDITAKTIVAN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KREDITAKTIVAN.MinimumSize = size;
            size = new System.Drawing.Size(0x8a, 0x17);
            this.label1KREDITAKTIVAN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkKREDITAKTIVAN.Location = point;
            this.checkKREDITAKTIVAN.Name = "checkKREDITAKTIVAN";
            this.checkKREDITAKTIVAN.Tag = "KREDITAKTIVAN";
            this.checkKREDITAKTIVAN.TabIndex = 0;
            this.checkKREDITAKTIVAN.Anchor = AnchorStyles.Left;
            this.checkKREDITAKTIVAN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkKREDITAKTIVAN.Enabled = true;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.checkKREDITAKTIVAN, 1, 2);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.checkKREDITAKTIVAN, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.checkKREDITAKTIVAN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkKREDITAKTIVAN.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkKREDITAKTIVAN.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkKREDITAKTIVAN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADKREDITINAZIVKREDITOR.Location = point;
            this.label1ZADKREDITINAZIVKREDITOR.Name = "label1ZADKREDITINAZIVKREDITOR";
            this.label1ZADKREDITINAZIVKREDITOR.TabIndex = 1;
            this.label1ZADKREDITINAZIVKREDITOR.Tag = "labelZADKREDITINAZIVKREDITOR";
            this.label1ZADKREDITINAZIVKREDITOR.Text = "Kreditor:";
            this.label1ZADKREDITINAZIVKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1ZADKREDITINAZIVKREDITOR.AutoSize = true;
            this.label1ZADKREDITINAZIVKREDITOR.Anchor = AnchorStyles.Left;
            this.label1ZADKREDITINAZIVKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADKREDITINAZIVKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1ZADKREDITINAZIVKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1ZADKREDITINAZIVKREDITOR, 0, 3);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1ZADKREDITINAZIVKREDITOR, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1ZADKREDITINAZIVKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADKREDITINAZIVKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADKREDITINAZIVKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(70, 0x17);
            this.label1ZADKREDITINAZIVKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelZADKREDITINAZIVKREDITOR.Location = point;
            this.labelZADKREDITINAZIVKREDITOR.Name = "labelZADKREDITINAZIVKREDITOR";
            this.labelZADKREDITINAZIVKREDITOR.Tag = "ZADKREDITINAZIVKREDITOR";
            this.labelZADKREDITINAZIVKREDITOR.TabIndex = 0;
            this.labelZADKREDITINAZIVKREDITOR.Anchor = AnchorStyles.Left;
            this.labelZADKREDITINAZIVKREDITOR.BackColor = Color.Transparent;
            this.labelZADKREDITINAZIVKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKKrediti, "ZADKREDITINAZIVKREDITOR"));
            this.labelZADKREDITINAZIVKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.labelZADKREDITINAZIVKREDITOR, 1, 3);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.labelZADKREDITINAZIVKREDITOR, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.labelZADKREDITINAZIVKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelZADKREDITINAZIVKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelZADKREDITINAZIVKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelZADKREDITINAZIVKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADKREDITIPRIMATELJKREDITOR1.Location = point;
            this.label1ZADKREDITIPRIMATELJKREDITOR1.Name = "label1ZADKREDITIPRIMATELJKREDITOR1";
            this.label1ZADKREDITIPRIMATELJKREDITOR1.TabIndex = 1;
            this.label1ZADKREDITIPRIMATELJKREDITOR1.Tag = "labelZADKREDITIPRIMATELJKREDITOR1";
            this.label1ZADKREDITIPRIMATELJKREDITOR1.Text = "Primatelj kredita (1):";
            this.label1ZADKREDITIPRIMATELJKREDITOR1.StyleSetName = "FieldUltraLabel";
            this.label1ZADKREDITIPRIMATELJKREDITOR1.AutoSize = true;
            this.label1ZADKREDITIPRIMATELJKREDITOR1.Anchor = AnchorStyles.Left;
            this.label1ZADKREDITIPRIMATELJKREDITOR1.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADKREDITIPRIMATELJKREDITOR1.Appearance.ForeColor = Color.Black;
            this.label1ZADKREDITIPRIMATELJKREDITOR1.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1ZADKREDITIPRIMATELJKREDITOR1, 0, 4);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1ZADKREDITIPRIMATELJKREDITOR1, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1ZADKREDITIPRIMATELJKREDITOR1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADKREDITIPRIMATELJKREDITOR1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADKREDITIPRIMATELJKREDITOR1.MinimumSize = size;
            size = new System.Drawing.Size(0x93, 0x17);
            this.label1ZADKREDITIPRIMATELJKREDITOR1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelZADKREDITIPRIMATELJKREDITOR1.Location = point;
            this.labelZADKREDITIPRIMATELJKREDITOR1.Name = "labelZADKREDITIPRIMATELJKREDITOR1";
            this.labelZADKREDITIPRIMATELJKREDITOR1.Tag = "ZADKREDITIPRIMATELJKREDITOR1";
            this.labelZADKREDITIPRIMATELJKREDITOR1.TabIndex = 0;
            this.labelZADKREDITIPRIMATELJKREDITOR1.Anchor = AnchorStyles.Left;
            this.labelZADKREDITIPRIMATELJKREDITOR1.BackColor = Color.Transparent;
            this.labelZADKREDITIPRIMATELJKREDITOR1.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKKrediti, "ZADKREDITIPRIMATELJKREDITOR1"));
            this.labelZADKREDITIPRIMATELJKREDITOR1.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.labelZADKREDITIPRIMATELJKREDITOR1, 1, 4);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.labelZADKREDITIPRIMATELJKREDITOR1, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.labelZADKREDITIPRIMATELJKREDITOR1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelZADKREDITIPRIMATELJKREDITOR1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelZADKREDITIPRIMATELJKREDITOR1.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelZADKREDITIPRIMATELJKREDITOR1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADKREDITIPRIMATELJKREDITOR2.Location = point;
            this.label1ZADKREDITIPRIMATELJKREDITOR2.Name = "label1ZADKREDITIPRIMATELJKREDITOR2";
            this.label1ZADKREDITIPRIMATELJKREDITOR2.TabIndex = 1;
            this.label1ZADKREDITIPRIMATELJKREDITOR2.Tag = "labelZADKREDITIPRIMATELJKREDITOR2";
            this.label1ZADKREDITIPRIMATELJKREDITOR2.Text = "Primatelj kredita (2):";
            this.label1ZADKREDITIPRIMATELJKREDITOR2.StyleSetName = "FieldUltraLabel";
            this.label1ZADKREDITIPRIMATELJKREDITOR2.AutoSize = true;
            this.label1ZADKREDITIPRIMATELJKREDITOR2.Anchor = AnchorStyles.Left;
            this.label1ZADKREDITIPRIMATELJKREDITOR2.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADKREDITIPRIMATELJKREDITOR2.Appearance.ForeColor = Color.Black;
            this.label1ZADKREDITIPRIMATELJKREDITOR2.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1ZADKREDITIPRIMATELJKREDITOR2, 0, 5);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1ZADKREDITIPRIMATELJKREDITOR2, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1ZADKREDITIPRIMATELJKREDITOR2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADKREDITIPRIMATELJKREDITOR2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADKREDITIPRIMATELJKREDITOR2.MinimumSize = size;
            size = new System.Drawing.Size(0x93, 0x17);
            this.label1ZADKREDITIPRIMATELJKREDITOR2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelZADKREDITIPRIMATELJKREDITOR2.Location = point;
            this.labelZADKREDITIPRIMATELJKREDITOR2.Name = "labelZADKREDITIPRIMATELJKREDITOR2";
            this.labelZADKREDITIPRIMATELJKREDITOR2.Tag = "ZADKREDITIPRIMATELJKREDITOR2";
            this.labelZADKREDITIPRIMATELJKREDITOR2.TabIndex = 0;
            this.labelZADKREDITIPRIMATELJKREDITOR2.Anchor = AnchorStyles.Left;
            this.labelZADKREDITIPRIMATELJKREDITOR2.BackColor = Color.Transparent;
            this.labelZADKREDITIPRIMATELJKREDITOR2.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKKrediti, "ZADKREDITIPRIMATELJKREDITOR2"));
            this.labelZADKREDITIPRIMATELJKREDITOR2.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.labelZADKREDITIPRIMATELJKREDITOR2, 1, 5);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.labelZADKREDITIPRIMATELJKREDITOR2, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.labelZADKREDITIPRIMATELJKREDITOR2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelZADKREDITIPRIMATELJKREDITOR2.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelZADKREDITIPRIMATELJKREDITOR2.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelZADKREDITIPRIMATELJKREDITOR2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADKREDITIPRIMATELJKREDITOR3.Location = point;
            this.label1ZADKREDITIPRIMATELJKREDITOR3.Name = "label1ZADKREDITIPRIMATELJKREDITOR3";
            this.label1ZADKREDITIPRIMATELJKREDITOR3.TabIndex = 1;
            this.label1ZADKREDITIPRIMATELJKREDITOR3.Tag = "labelZADKREDITIPRIMATELJKREDITOR3";
            this.label1ZADKREDITIPRIMATELJKREDITOR3.Text = "Primatelj kredita (2):";
            this.label1ZADKREDITIPRIMATELJKREDITOR3.StyleSetName = "FieldUltraLabel";
            this.label1ZADKREDITIPRIMATELJKREDITOR3.AutoSize = true;
            this.label1ZADKREDITIPRIMATELJKREDITOR3.Anchor = AnchorStyles.Left;
            this.label1ZADKREDITIPRIMATELJKREDITOR3.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADKREDITIPRIMATELJKREDITOR3.Appearance.ForeColor = Color.Black;
            this.label1ZADKREDITIPRIMATELJKREDITOR3.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1ZADKREDITIPRIMATELJKREDITOR3, 0, 6);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1ZADKREDITIPRIMATELJKREDITOR3, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1ZADKREDITIPRIMATELJKREDITOR3, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADKREDITIPRIMATELJKREDITOR3.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADKREDITIPRIMATELJKREDITOR3.MinimumSize = size;
            size = new System.Drawing.Size(0x93, 0x17);
            this.label1ZADKREDITIPRIMATELJKREDITOR3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelZADKREDITIPRIMATELJKREDITOR3.Location = point;
            this.labelZADKREDITIPRIMATELJKREDITOR3.Name = "labelZADKREDITIPRIMATELJKREDITOR3";
            this.labelZADKREDITIPRIMATELJKREDITOR3.Tag = "ZADKREDITIPRIMATELJKREDITOR3";
            this.labelZADKREDITIPRIMATELJKREDITOR3.TabIndex = 0;
            this.labelZADKREDITIPRIMATELJKREDITOR3.Anchor = AnchorStyles.Left;
            this.labelZADKREDITIPRIMATELJKREDITOR3.BackColor = Color.Transparent;
            this.labelZADKREDITIPRIMATELJKREDITOR3.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKKrediti, "ZADKREDITIPRIMATELJKREDITOR3"));
            this.labelZADKREDITIPRIMATELJKREDITOR3.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.labelZADKREDITIPRIMATELJKREDITOR3, 1, 6);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.labelZADKREDITIPRIMATELJKREDITOR3, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.labelZADKREDITIPRIMATELJKREDITOR3, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelZADKREDITIPRIMATELJKREDITOR3.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelZADKREDITIPRIMATELJKREDITOR3.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelZADKREDITIPRIMATELJKREDITOR3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SIFRAOPISAPLACANJAKREDITOR.Location = point;
            this.label1SIFRAOPISAPLACANJAKREDITOR.Name = "label1SIFRAOPISAPLACANJAKREDITOR";
            this.label1SIFRAOPISAPLACANJAKREDITOR.TabIndex = 1;
            this.label1SIFRAOPISAPLACANJAKREDITOR.Tag = "labelSIFRAOPISAPLACANJAKREDITOR";
            this.label1SIFRAOPISAPLACANJAKREDITOR.Text = "Šifra opisa plaćanja:";
            this.label1SIFRAOPISAPLACANJAKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAOPISAPLACANJAKREDITOR.AutoSize = true;
            this.label1SIFRAOPISAPLACANJAKREDITOR.Anchor = AnchorStyles.Left;
            this.label1SIFRAOPISAPLACANJAKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1SIFRAOPISAPLACANJAKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1SIFRAOPISAPLACANJAKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1SIFRAOPISAPLACANJAKREDITOR, 0, 7);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1SIFRAOPISAPLACANJAKREDITOR, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1SIFRAOPISAPLACANJAKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SIFRAOPISAPLACANJAKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SIFRAOPISAPLACANJAKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 0x17);
            this.label1SIFRAOPISAPLACANJAKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSIFRAOPISAPLACANJAKREDITOR.Location = point;
            this.textSIFRAOPISAPLACANJAKREDITOR.Name = "textSIFRAOPISAPLACANJAKREDITOR";
            this.textSIFRAOPISAPLACANJAKREDITOR.Tag = "SIFRAOPISAPLACANJAKREDITOR";
            this.textSIFRAOPISAPLACANJAKREDITOR.TabIndex = 0;
            this.textSIFRAOPISAPLACANJAKREDITOR.Anchor = AnchorStyles.Left;
            this.textSIFRAOPISAPLACANJAKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSIFRAOPISAPLACANJAKREDITOR.ReadOnly = false;
            this.textSIFRAOPISAPLACANJAKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKKrediti, "SIFRAOPISAPLACANJAKREDITOR"));
            this.textSIFRAOPISAPLACANJAKREDITOR.MaxLength = 2;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.textSIFRAOPISAPLACANJAKREDITOR, 1, 7);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.textSIFRAOPISAPLACANJAKREDITOR, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.textSIFRAOPISAPLACANJAKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSIFRAOPISAPLACANJAKREDITOR.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJAKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJAKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISPLACANJAKREDITOR.Location = point;
            this.label1OPISPLACANJAKREDITOR.Name = "label1OPISPLACANJAKREDITOR";
            this.label1OPISPLACANJAKREDITOR.TabIndex = 1;
            this.label1OPISPLACANJAKREDITOR.Tag = "labelOPISPLACANJAKREDITOR";
            this.label1OPISPLACANJAKREDITOR.Text = "Opis plaćanja kredit:";
            this.label1OPISPLACANJAKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1OPISPLACANJAKREDITOR.AutoSize = true;
            this.label1OPISPLACANJAKREDITOR.Anchor = AnchorStyles.Left;
            this.label1OPISPLACANJAKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISPLACANJAKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1OPISPLACANJAKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1OPISPLACANJAKREDITOR, 0, 8);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1OPISPLACANJAKREDITOR, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1OPISPLACANJAKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISPLACANJAKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISPLACANJAKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x8f, 0x17);
            this.label1OPISPLACANJAKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPISPLACANJAKREDITOR.Location = point;
            this.textOPISPLACANJAKREDITOR.Name = "textOPISPLACANJAKREDITOR";
            this.textOPISPLACANJAKREDITOR.Tag = "OPISPLACANJAKREDITOR";
            this.textOPISPLACANJAKREDITOR.TabIndex = 0;
            this.textOPISPLACANJAKREDITOR.Anchor = AnchorStyles.Left;
            this.textOPISPLACANJAKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPISPLACANJAKREDITOR.ReadOnly = false;
            this.textOPISPLACANJAKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKKrediti, "OPISPLACANJAKREDITOR"));
            this.textOPISPLACANJAKREDITOR.MaxLength = 0x24;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.textOPISPLACANJAKREDITOR, 1, 8);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.textOPISPLACANJAKREDITOR, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.textOPISPLACANJAKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPISPLACANJAKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJAKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJAKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MOKREDITOR.Location = point;
            this.label1MOKREDITOR.Name = "label1MOKREDITOR";
            this.label1MOKREDITOR.TabIndex = 1;
            this.label1MOKREDITOR.Tag = "labelMOKREDITOR";
            this.label1MOKREDITOR.Text = "Model odobrenja:";
            this.label1MOKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1MOKREDITOR.AutoSize = true;
            this.label1MOKREDITOR.Anchor = AnchorStyles.Left;
            this.label1MOKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1MOKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1MOKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1MOKREDITOR, 0, 9);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1MOKREDITOR, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1MOKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MOKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MOKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 0x17);
            this.label1MOKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMOKREDITOR.Location = point;
            this.textMOKREDITOR.Name = "textMOKREDITOR";
            this.textMOKREDITOR.Tag = "MOKREDITOR";
            this.textMOKREDITOR.TabIndex = 0;
            this.textMOKREDITOR.Anchor = AnchorStyles.Left;
            this.textMOKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMOKREDITOR.ContextMenu = this.contextMenu1;
            this.textMOKREDITOR.ReadOnly = false;
            this.textMOKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKKrediti, "MOKREDITOR"));
            this.textMOKREDITOR.Nullable = true;
            this.textMOKREDITOR.MaxLength = 2;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.textMOKREDITOR, 1, 9);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.textMOKREDITOR, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.textMOKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMOKREDITOR.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMOKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMOKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POKREDITOR.Location = point;
            this.label1POKREDITOR.Name = "label1POKREDITOR";
            this.label1POKREDITOR.TabIndex = 1;
            this.label1POKREDITOR.Tag = "labelPOKREDITOR";
            this.label1POKREDITOR.Text = "Poziv na broj odobrenja:";
            this.label1POKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1POKREDITOR.AutoSize = true;
            this.label1POKREDITOR.Anchor = AnchorStyles.Left;
            this.label1POKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1POKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1POKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1POKREDITOR, 0, 10);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1POKREDITOR, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1POKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0xa7, 0x17);
            this.label1POKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOKREDITOR.Location = point;
            this.textPOKREDITOR.Name = "textPOKREDITOR";
            this.textPOKREDITOR.Tag = "POKREDITOR";
            this.textPOKREDITOR.TabIndex = 0;
            this.textPOKREDITOR.Anchor = AnchorStyles.Left;
            this.textPOKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOKREDITOR.ContextMenu = this.contextMenu1;
            this.textPOKREDITOR.ReadOnly = false;
            this.textPOKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKKrediti, "POKREDITOR"));
            this.textPOKREDITOR.Nullable = true;
            this.textPOKREDITOR.MaxLength = 0x16;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.textPOKREDITOR, 1, 10);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.textPOKREDITOR, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.textPOKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOKREDITOR.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MZKREDITOR.Location = point;
            this.label1MZKREDITOR.Name = "label1MZKREDITOR";
            this.label1MZKREDITOR.TabIndex = 1;
            this.label1MZKREDITOR.Tag = "labelMZKREDITOR";
            this.label1MZKREDITOR.Text = "Model zaduženja:";
            this.label1MZKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1MZKREDITOR.AutoSize = true;
            this.label1MZKREDITOR.Anchor = AnchorStyles.Left;
            this.label1MZKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1MZKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1MZKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1MZKREDITOR, 0, 11);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1MZKREDITOR, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1MZKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MZKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MZKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 0x17);
            this.label1MZKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMZKREDITOR.Location = point;
            this.textMZKREDITOR.Name = "textMZKREDITOR";
            this.textMZKREDITOR.Tag = "MZKREDITOR";
            this.textMZKREDITOR.TabIndex = 0;
            this.textMZKREDITOR.Anchor = AnchorStyles.Left;
            this.textMZKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMZKREDITOR.ContextMenu = this.contextMenu1;
            this.textMZKREDITOR.ReadOnly = false;
            this.textMZKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKKrediti, "MZKREDITOR"));
            this.textMZKREDITOR.Nullable = true;
            this.textMZKREDITOR.MaxLength = 2;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.textMZKREDITOR, 1, 11);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.textMZKREDITOR, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.textMZKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMZKREDITOR.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMZKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMZKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PZKREDITOR.Location = point;
            this.label1PZKREDITOR.Name = "label1PZKREDITOR";
            this.label1PZKREDITOR.TabIndex = 1;
            this.label1PZKREDITOR.Tag = "labelPZKREDITOR";
            this.label1PZKREDITOR.Text = "Poziv na broj zaduženja:";
            this.label1PZKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1PZKREDITOR.AutoSize = true;
            this.label1PZKREDITOR.Anchor = AnchorStyles.Left;
            this.label1PZKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1PZKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1PZKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1PZKREDITOR, 0, 12);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1PZKREDITOR, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1PZKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PZKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PZKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0xa7, 0x17);
            this.label1PZKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPZKREDITOR.Location = point;
            this.textPZKREDITOR.Name = "textPZKREDITOR";
            this.textPZKREDITOR.Tag = "PZKREDITOR";
            this.textPZKREDITOR.TabIndex = 0;
            this.textPZKREDITOR.Anchor = AnchorStyles.Left;
            this.textPZKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPZKREDITOR.ContextMenu = this.contextMenu1;
            this.textPZKREDITOR.ReadOnly = false;
            this.textPZKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKKrediti, "PZKREDITOR"));
            this.textPZKREDITOR.Nullable = true;
            this.textPZKREDITOR.MaxLength = 0x16;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.textPZKREDITOR, 1, 12);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.textPZKREDITOR, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.textPZKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPZKREDITOR.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPZKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPZKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADIZNOSRATEKREDITA.Location = point;
            this.label1ZADIZNOSRATEKREDITA.Name = "label1ZADIZNOSRATEKREDITA";
            this.label1ZADIZNOSRATEKREDITA.TabIndex = 1;
            this.label1ZADIZNOSRATEKREDITA.Tag = "labelZADIZNOSRATEKREDITA";
            this.label1ZADIZNOSRATEKREDITA.Text = "Iznos rate kredita:";
            this.label1ZADIZNOSRATEKREDITA.StyleSetName = "FieldUltraLabel";
            this.label1ZADIZNOSRATEKREDITA.AutoSize = true;
            this.label1ZADIZNOSRATEKREDITA.Anchor = AnchorStyles.Left;
            this.label1ZADIZNOSRATEKREDITA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADIZNOSRATEKREDITA.Appearance.ForeColor = Color.Black;
            this.label1ZADIZNOSRATEKREDITA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1ZADIZNOSRATEKREDITA, 0, 13);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1ZADIZNOSRATEKREDITA, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1ZADIZNOSRATEKREDITA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADIZNOSRATEKREDITA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADIZNOSRATEKREDITA.MinimumSize = size;
            size = new System.Drawing.Size(130, 0x17);
            this.label1ZADIZNOSRATEKREDITA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADIZNOSRATEKREDITA.Location = point;
            this.textZADIZNOSRATEKREDITA.Name = "textZADIZNOSRATEKREDITA";
            this.textZADIZNOSRATEKREDITA.Tag = "ZADIZNOSRATEKREDITA";
            this.textZADIZNOSRATEKREDITA.TabIndex = 0;
            this.textZADIZNOSRATEKREDITA.Anchor = AnchorStyles.Left;
            this.textZADIZNOSRATEKREDITA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADIZNOSRATEKREDITA.ReadOnly = false;
            this.textZADIZNOSRATEKREDITA.PromptChar = ' ';
            this.textZADIZNOSRATEKREDITA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textZADIZNOSRATEKREDITA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKKrediti, "ZADIZNOSRATEKREDITA"));
            this.textZADIZNOSRATEKREDITA.NumericType = NumericType.Double;
            this.textZADIZNOSRATEKREDITA.MaxValue = 79228162514264337593543950335M;
            this.textZADIZNOSRATEKREDITA.MinValue = -79228162514264337593543950335M;
            this.textZADIZNOSRATEKREDITA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.textZADIZNOSRATEKREDITA, 1, 13);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.textZADIZNOSRATEKREDITA, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.textZADIZNOSRATEKREDITA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADIZNOSRATEKREDITA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADIZNOSRATEKREDITA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADIZNOSRATEKREDITA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADBROJRATAOBUSTAVE.Location = point;
            this.label1ZADBROJRATAOBUSTAVE.Name = "label1ZADBROJRATAOBUSTAVE";
            this.label1ZADBROJRATAOBUSTAVE.TabIndex = 1;
            this.label1ZADBROJRATAOBUSTAVE.Tag = "labelZADBROJRATAOBUSTAVE";
            this.label1ZADBROJRATAOBUSTAVE.Text = "Broj rata kredita:";
            this.label1ZADBROJRATAOBUSTAVE.StyleSetName = "FieldUltraLabel";
            this.label1ZADBROJRATAOBUSTAVE.AutoSize = true;
            this.label1ZADBROJRATAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.label1ZADBROJRATAOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADBROJRATAOBUSTAVE.Appearance.ForeColor = Color.Black;
            this.label1ZADBROJRATAOBUSTAVE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1ZADBROJRATAOBUSTAVE, 0, 14);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1ZADBROJRATAOBUSTAVE, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1ZADBROJRATAOBUSTAVE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADBROJRATAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADBROJRATAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x7a, 0x17);
            this.label1ZADBROJRATAOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADBROJRATAOBUSTAVE.Location = point;
            this.textZADBROJRATAOBUSTAVE.Name = "textZADBROJRATAOBUSTAVE";
            this.textZADBROJRATAOBUSTAVE.Tag = "ZADBROJRATAOBUSTAVE";
            this.textZADBROJRATAOBUSTAVE.TabIndex = 0;
            this.textZADBROJRATAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.textZADBROJRATAOBUSTAVE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADBROJRATAOBUSTAVE.ReadOnly = false;
            this.textZADBROJRATAOBUSTAVE.PromptChar = ' ';
            this.textZADBROJRATAOBUSTAVE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textZADBROJRATAOBUSTAVE.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKKrediti, "ZADBROJRATAOBUSTAVE"));
            this.textZADBROJRATAOBUSTAVE.NumericType = NumericType.Double;
            this.textZADBROJRATAOBUSTAVE.MaxValue = 79228162514264337593543950335M;
            this.textZADBROJRATAOBUSTAVE.MinValue = -79228162514264337593543950335M;
            this.textZADBROJRATAOBUSTAVE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.textZADBROJRATAOBUSTAVE, 1, 14);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.textZADBROJRATAOBUSTAVE, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.textZADBROJRATAOBUSTAVE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADBROJRATAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADBROJRATAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADBROJRATAOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADUKUPNIZNOSKREDITA.Location = point;
            this.label1ZADUKUPNIZNOSKREDITA.Name = "label1ZADUKUPNIZNOSKREDITA";
            this.label1ZADUKUPNIZNOSKREDITA.TabIndex = 1;
            this.label1ZADUKUPNIZNOSKREDITA.Tag = "labelZADUKUPNIZNOSKREDITA";
            this.label1ZADUKUPNIZNOSKREDITA.Text = "Ukupni iznos kredita:";
            this.label1ZADUKUPNIZNOSKREDITA.StyleSetName = "FieldUltraLabel";
            this.label1ZADUKUPNIZNOSKREDITA.AutoSize = true;
            this.label1ZADUKUPNIZNOSKREDITA.Anchor = AnchorStyles.Left;
            this.label1ZADUKUPNIZNOSKREDITA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADUKUPNIZNOSKREDITA.Appearance.ForeColor = Color.Black;
            this.label1ZADUKUPNIZNOSKREDITA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1ZADUKUPNIZNOSKREDITA, 0, 15);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1ZADUKUPNIZNOSKREDITA, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1ZADUKUPNIZNOSKREDITA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADUKUPNIZNOSKREDITA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADUKUPNIZNOSKREDITA.MinimumSize = size;
            size = new System.Drawing.Size(0x92, 0x17);
            this.label1ZADUKUPNIZNOSKREDITA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADUKUPNIZNOSKREDITA.Location = point;
            this.textZADUKUPNIZNOSKREDITA.Name = "textZADUKUPNIZNOSKREDITA";
            this.textZADUKUPNIZNOSKREDITA.Tag = "ZADUKUPNIZNOSKREDITA";
            this.textZADUKUPNIZNOSKREDITA.TabIndex = 0;
            this.textZADUKUPNIZNOSKREDITA.Anchor = AnchorStyles.Left;
            this.textZADUKUPNIZNOSKREDITA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADUKUPNIZNOSKREDITA.ReadOnly = false;
            this.textZADUKUPNIZNOSKREDITA.PromptChar = ' ';
            this.textZADUKUPNIZNOSKREDITA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textZADUKUPNIZNOSKREDITA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKKrediti, "ZADUKUPNIZNOSKREDITA"));
            this.textZADUKUPNIZNOSKREDITA.NumericType = NumericType.Double;
            this.textZADUKUPNIZNOSKREDITA.MaxValue = 79228162514264337593543950335M;
            this.textZADUKUPNIZNOSKREDITA.MinValue = -79228162514264337593543950335M;
            this.textZADUKUPNIZNOSKREDITA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.textZADUKUPNIZNOSKREDITA, 1, 15);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.textZADUKUPNIZNOSKREDITA, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.textZADUKUPNIZNOSKREDITA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADUKUPNIZNOSKREDITA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADUKUPNIZNOSKREDITA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADUKUPNIZNOSKREDITA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADVECOTPLACENOBROJRATA.Location = point;
            this.label1ZADVECOTPLACENOBROJRATA.Name = "label1ZADVECOTPLACENOBROJRATA";
            this.label1ZADVECOTPLACENOBROJRATA.TabIndex = 1;
            this.label1ZADVECOTPLACENOBROJRATA.Tag = "labelZADVECOTPLACENOBROJRATA";
            this.label1ZADVECOTPLACENOBROJRATA.Text = "Prijenos otplaćenih rata iz drugog programa:";
            this.label1ZADVECOTPLACENOBROJRATA.StyleSetName = "FieldUltraLabel";
            this.label1ZADVECOTPLACENOBROJRATA.AutoSize = true;
            this.label1ZADVECOTPLACENOBROJRATA.Anchor = AnchorStyles.Left;
            this.label1ZADVECOTPLACENOBROJRATA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADVECOTPLACENOBROJRATA.Appearance.ForeColor = Color.Black;
            this.label1ZADVECOTPLACENOBROJRATA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1ZADVECOTPLACENOBROJRATA, 0, 0x10);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1ZADVECOTPLACENOBROJRATA, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1ZADVECOTPLACENOBROJRATA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADVECOTPLACENOBROJRATA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADVECOTPLACENOBROJRATA.MinimumSize = size;
            size = new System.Drawing.Size(0x125, 0x17);
            this.label1ZADVECOTPLACENOBROJRATA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADVECOTPLACENOBROJRATA.Location = point;
            this.textZADVECOTPLACENOBROJRATA.Name = "textZADVECOTPLACENOBROJRATA";
            this.textZADVECOTPLACENOBROJRATA.Tag = "ZADVECOTPLACENOBROJRATA";
            this.textZADVECOTPLACENOBROJRATA.TabIndex = 0;
            this.textZADVECOTPLACENOBROJRATA.Anchor = AnchorStyles.Left;
            this.textZADVECOTPLACENOBROJRATA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADVECOTPLACENOBROJRATA.ReadOnly = false;
            this.textZADVECOTPLACENOBROJRATA.PromptChar = ' ';
            this.textZADVECOTPLACENOBROJRATA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textZADVECOTPLACENOBROJRATA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKKrediti, "ZADVECOTPLACENOBROJRATA"));
            this.textZADVECOTPLACENOBROJRATA.NumericType = NumericType.Double;
            this.textZADVECOTPLACENOBROJRATA.MaxValue = 79228162514264337593543950335M;
            this.textZADVECOTPLACENOBROJRATA.MinValue = -79228162514264337593543950335M;
            this.textZADVECOTPLACENOBROJRATA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.textZADVECOTPLACENOBROJRATA, 1, 0x10);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.textZADVECOTPLACENOBROJRATA, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.textZADVECOTPLACENOBROJRATA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADVECOTPLACENOBROJRATA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADVECOTPLACENOBROJRATA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADVECOTPLACENOBROJRATA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADVECOTPLACENOUKUPNIIZNOS.Location = point;
            this.label1ZADVECOTPLACENOUKUPNIIZNOS.Name = "label1ZADVECOTPLACENOUKUPNIIZNOS";
            this.label1ZADVECOTPLACENOUKUPNIIZNOS.TabIndex = 1;
            this.label1ZADVECOTPLACENOUKUPNIIZNOS.Tag = "labelZADVECOTPLACENOUKUPNIIZNOS";
            this.label1ZADVECOTPLACENOUKUPNIIZNOS.Text = "Prijenos otplaćenog iznosa iz drugog programa:";
            this.label1ZADVECOTPLACENOUKUPNIIZNOS.StyleSetName = "FieldUltraLabel";
            this.label1ZADVECOTPLACENOUKUPNIIZNOS.AutoSize = true;
            this.label1ZADVECOTPLACENOUKUPNIIZNOS.Anchor = AnchorStyles.Left;
            this.label1ZADVECOTPLACENOUKUPNIIZNOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADVECOTPLACENOUKUPNIIZNOS.Appearance.ForeColor = Color.Black;
            this.label1ZADVECOTPLACENOUKUPNIIZNOS.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1ZADVECOTPLACENOUKUPNIIZNOS, 0, 0x11);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1ZADVECOTPLACENOUKUPNIIZNOS, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1ZADVECOTPLACENOUKUPNIIZNOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADVECOTPLACENOUKUPNIIZNOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADVECOTPLACENOUKUPNIIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x137, 0x17);
            this.label1ZADVECOTPLACENOUKUPNIIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADVECOTPLACENOUKUPNIIZNOS.Location = point;
            this.textZADVECOTPLACENOUKUPNIIZNOS.Name = "textZADVECOTPLACENOUKUPNIIZNOS";
            this.textZADVECOTPLACENOUKUPNIIZNOS.Tag = "ZADVECOTPLACENOUKUPNIIZNOS";
            this.textZADVECOTPLACENOUKUPNIIZNOS.TabIndex = 0;
            this.textZADVECOTPLACENOUKUPNIIZNOS.Anchor = AnchorStyles.Left;
            this.textZADVECOTPLACENOUKUPNIIZNOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADVECOTPLACENOUKUPNIIZNOS.ReadOnly = false;
            this.textZADVECOTPLACENOUKUPNIIZNOS.PromptChar = ' ';
            this.textZADVECOTPLACENOUKUPNIIZNOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textZADVECOTPLACENOUKUPNIIZNOS.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKKrediti, "ZADVECOTPLACENOUKUPNIIZNOS"));
            this.textZADVECOTPLACENOUKUPNIIZNOS.NumericType = NumericType.Double;
            this.textZADVECOTPLACENOUKUPNIIZNOS.MaxValue = 79228162514264337593543950335M;
            this.textZADVECOTPLACENOUKUPNIIZNOS.MinValue = -79228162514264337593543950335M;
            this.textZADVECOTPLACENOUKUPNIIZNOS.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.textZADVECOTPLACENOUKUPNIIZNOS, 1, 0x11);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.textZADVECOTPLACENOUKUPNIIZNOS, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.textZADVECOTPLACENOUKUPNIIZNOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADVECOTPLACENOUKUPNIIZNOS.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADVECOTPLACENOUKUPNIIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADVECOTPLACENOUKUPNIIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KREDITOTPLACENIIZNOS.Location = point;
            this.label1KREDITOTPLACENIIZNOS.Name = "label1KREDITOTPLACENIIZNOS";
            this.label1KREDITOTPLACENIIZNOS.TabIndex = 1;
            this.label1KREDITOTPLACENIIZNOS.Tag = "labelKREDITOTPLACENIIZNOS";
            this.label1KREDITOTPLACENIIZNOS.Text = "Ukupno otplaćeno (iznos):";
            this.label1KREDITOTPLACENIIZNOS.StyleSetName = "FieldUltraLabel";
            this.label1KREDITOTPLACENIIZNOS.AutoSize = true;
            this.label1KREDITOTPLACENIIZNOS.Anchor = AnchorStyles.Left;
            this.label1KREDITOTPLACENIIZNOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1KREDITOTPLACENIIZNOS.Appearance.ForeColor = Color.Black;
            this.label1KREDITOTPLACENIIZNOS.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1KREDITOTPLACENIIZNOS, 0, 0x12);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1KREDITOTPLACENIIZNOS, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1KREDITOTPLACENIIZNOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KREDITOTPLACENIIZNOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KREDITOTPLACENIIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0xb2, 0x17);
            this.label1KREDITOTPLACENIIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelKREDITOTPLACENIIZNOS.Location = point;
            this.labelKREDITOTPLACENIIZNOS.Name = "labelKREDITOTPLACENIIZNOS";
            this.labelKREDITOTPLACENIIZNOS.Tag = "KREDITOTPLACENIIZNOS";
            this.labelKREDITOTPLACENIIZNOS.TabIndex = 0;
            this.labelKREDITOTPLACENIIZNOS.Anchor = AnchorStyles.Left;
            this.labelKREDITOTPLACENIIZNOS.BackColor = Color.Transparent;
            this.labelKREDITOTPLACENIIZNOS.Appearance.TextHAlign = HAlign.Left;
            this.labelKREDITOTPLACENIIZNOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.labelKREDITOTPLACENIIZNOS, 1, 0x12);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.labelKREDITOTPLACENIIZNOS, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.labelKREDITOTPLACENIIZNOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelKREDITOTPLACENIIZNOS.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelKREDITOTPLACENIIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelKREDITOTPLACENIIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KREDITOTPLACENORATA.Location = point;
            this.label1KREDITOTPLACENORATA.Name = "label1KREDITOTPLACENORATA";
            this.label1KREDITOTPLACENORATA.TabIndex = 1;
            this.label1KREDITOTPLACENORATA.Tag = "labelKREDITOTPLACENORATA";
            this.label1KREDITOTPLACENORATA.Text = "Ukupno otplaćeno (broj rata):";
            this.label1KREDITOTPLACENORATA.StyleSetName = "FieldUltraLabel";
            this.label1KREDITOTPLACENORATA.AutoSize = true;
            this.label1KREDITOTPLACENORATA.Anchor = AnchorStyles.Left;
            this.label1KREDITOTPLACENORATA.Appearance.TextVAlign = VAlign.Middle;
            this.label1KREDITOTPLACENORATA.Appearance.ForeColor = Color.Black;
            this.label1KREDITOTPLACENORATA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1KREDITOTPLACENORATA, 0, 0x13);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1KREDITOTPLACENORATA, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1KREDITOTPLACENORATA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KREDITOTPLACENORATA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KREDITOTPLACENORATA.MinimumSize = size;
            size = new System.Drawing.Size(0xc9, 0x17);
            this.label1KREDITOTPLACENORATA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelKREDITOTPLACENORATA.Location = point;
            this.labelKREDITOTPLACENORATA.Name = "labelKREDITOTPLACENORATA";
            this.labelKREDITOTPLACENORATA.Tag = "KREDITOTPLACENORATA";
            this.labelKREDITOTPLACENORATA.TabIndex = 0;
            this.labelKREDITOTPLACENORATA.Anchor = AnchorStyles.Left;
            this.labelKREDITOTPLACENORATA.BackColor = Color.Transparent;
            this.labelKREDITOTPLACENORATA.Appearance.TextHAlign = HAlign.Left;
            this.labelKREDITOTPLACENORATA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.labelKREDITOTPLACENORATA, 1, 0x13);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.labelKREDITOTPLACENORATA, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.labelKREDITOTPLACENORATA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelKREDITOTPLACENORATA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelKREDITOTPLACENORATA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelKREDITOTPLACENORATA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PARTIJAKREDITASPECIFIKACIJA.Location = point;
            this.label1PARTIJAKREDITASPECIFIKACIJA.Name = "label1PARTIJAKREDITASPECIFIKACIJA";
            this.label1PARTIJAKREDITASPECIFIKACIJA.TabIndex = 1;
            this.label1PARTIJAKREDITASPECIFIKACIJA.Tag = "labelPARTIJAKREDITASPECIFIKACIJA";
            this.label1PARTIJAKREDITASPECIFIKACIJA.Text = "Partija kredita za specifikaciju:";
            this.label1PARTIJAKREDITASPECIFIKACIJA.StyleSetName = "FieldUltraLabel";
            this.label1PARTIJAKREDITASPECIFIKACIJA.AutoSize = true;
            this.label1PARTIJAKREDITASPECIFIKACIJA.Anchor = AnchorStyles.Left;
            this.label1PARTIJAKREDITASPECIFIKACIJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1PARTIJAKREDITASPECIFIKACIJA.Appearance.ForeColor = Color.Black;
            this.label1PARTIJAKREDITASPECIFIKACIJA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.label1PARTIJAKREDITASPECIFIKACIJA, 0, 20);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.label1PARTIJAKREDITASPECIFIKACIJA, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.label1PARTIJAKREDITASPECIFIKACIJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PARTIJAKREDITASPECIFIKACIJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PARTIJAKREDITASPECIFIKACIJA.MinimumSize = size;
            size = new System.Drawing.Size(0xcf, 0x17);
            this.label1PARTIJAKREDITASPECIFIKACIJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPARTIJAKREDITASPECIFIKACIJA.Location = point;
            this.textPARTIJAKREDITASPECIFIKACIJA.Name = "textPARTIJAKREDITASPECIFIKACIJA";
            this.textPARTIJAKREDITASPECIFIKACIJA.Tag = "PARTIJAKREDITASPECIFIKACIJA";
            this.textPARTIJAKREDITASPECIFIKACIJA.TabIndex = 0;
            this.textPARTIJAKREDITASPECIFIKACIJA.Anchor = AnchorStyles.Left;
            this.textPARTIJAKREDITASPECIFIKACIJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPARTIJAKREDITASPECIFIKACIJA.ContextMenu = this.contextMenu1;
            this.textPARTIJAKREDITASPECIFIKACIJA.ReadOnly = false;
            this.textPARTIJAKREDITASPECIFIKACIJA.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKKrediti, "PARTIJAKREDITASPECIFIKACIJA"));
            this.textPARTIJAKREDITASPECIFIKACIJA.Nullable = true;
            this.textPARTIJAKREDITASPECIFIKACIJA.MaxLength = 0x16;
            this.layoutManagerformRADNIKKrediti.Controls.Add(this.textPARTIJAKREDITASPECIFIKACIJA, 1, 20);
            this.layoutManagerformRADNIKKrediti.SetColumnSpan(this.textPARTIJAKREDITASPECIFIKACIJA, 1);
            this.layoutManagerformRADNIKKrediti.SetRowSpan(this.textPARTIJAKREDITASPECIFIKACIJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPARTIJAKREDITASPECIFIKACIJA.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPARTIJAKREDITASPECIFIKACIJA.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPARTIJAKREDITASPECIFIKACIJA.Size = size;
            this.Controls.Add(this.layoutManagerformRADNIKKrediti);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRADNIKKrediti;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RADNIKFormRADNIKKreditiUserControl";
            this.Text = " Krediti radnika";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RADNIKFormUserControl_Load);
            this.layoutManagerformRADNIKKrediti.ResumeLayout(false);
            this.layoutManagerformRADNIKKrediti.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRADNIKKrediti).EndInit();
            ((ISupportInitialize) this.textZADKREDITIIDKREDITOR).EndInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJAKREDITOR).EndInit();
            ((ISupportInitialize) this.textOPISPLACANJAKREDITOR).EndInit();
            ((ISupportInitialize) this.textMOKREDITOR).EndInit();
            ((ISupportInitialize) this.textPOKREDITOR).EndInit();
            ((ISupportInitialize) this.textMZKREDITOR).EndInit();
            ((ISupportInitialize) this.textPZKREDITOR).EndInit();
            ((ISupportInitialize) this.textZADIZNOSRATEKREDITA).EndInit();
            ((ISupportInitialize) this.textZADBROJRATAOBUSTAVE).EndInit();
            ((ISupportInitialize) this.textZADUKUPNIZNOSKREDITA).EndInit();
            ((ISupportInitialize) this.textZADVECOTPLACENOBROJRATA).EndInit();
            ((ISupportInitialize) this.textZADVECOTPLACENOUKUPNIIZNOS).EndInit();
            ((ISupportInitialize) this.textPARTIJAKREDITASPECIFIKACIJA).EndInit();
            this.dsRADNIKDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RADNIKController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIKKrediti, this.RADNIKController.WorkItem, this))
            {
                return false;
            }
            this.EndEditCurrentRow();
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void Localize()
        {
            this.label1ZADKREDITIIDKREDITOR.Text = StringResources.RADNIKZADKREDITIIDKREDITORDescription;
            this.label1DATUMUGOVORA.Text = StringResources.RADNIKDATUMUGOVORADescription;
            this.label1KREDITAKTIVAN.Text = StringResources.RADNIKKREDITAKTIVANDescription;
            this.label1ZADKREDITINAZIVKREDITOR.Text = StringResources.RADNIKZADKREDITINAZIVKREDITORDescription;
            this.label1ZADKREDITIPRIMATELJKREDITOR1.Text = StringResources.RADNIKZADKREDITIPRIMATELJKREDITOR1Description;
            this.label1ZADKREDITIPRIMATELJKREDITOR2.Text = StringResources.RADNIKZADKREDITIPRIMATELJKREDITOR2Description;
            this.label1ZADKREDITIPRIMATELJKREDITOR3.Text = StringResources.RADNIKZADKREDITIPRIMATELJKREDITOR3Description;
            this.label1SIFRAOPISAPLACANJAKREDITOR.Text = StringResources.RADNIKSIFRAOPISAPLACANJAKREDITORDescription;
            this.label1OPISPLACANJAKREDITOR.Text = StringResources.RADNIKOPISPLACANJAKREDITORDescription;
            this.label1MOKREDITOR.Text = StringResources.RADNIKMOKREDITORDescription;
            this.label1POKREDITOR.Text = StringResources.RADNIKPOKREDITORDescription;
            this.label1MZKREDITOR.Text = StringResources.RADNIKMZKREDITORDescription;
            this.label1PZKREDITOR.Text = StringResources.RADNIKPZKREDITORDescription;
            this.label1ZADIZNOSRATEKREDITA.Text = StringResources.RADNIKZADIZNOSRATEKREDITADescription;
            this.label1ZADBROJRATAOBUSTAVE.Text = StringResources.RADNIKZADBROJRATAOBUSTAVEDescription;
            this.label1ZADUKUPNIZNOSKREDITA.Text = StringResources.RADNIKZADUKUPNIZNOSKREDITADescription;
            this.label1ZADVECOTPLACENOBROJRATA.Text = StringResources.RADNIKZADVECOTPLACENOBROJRATADescription;
            this.label1ZADVECOTPLACENOUKUPNIIZNOS.Text = StringResources.RADNIKZADVECOTPLACENOUKUPNIIZNOSDescription;
            this.label1KREDITOTPLACENIIZNOS.Text = StringResources.RADNIKKREDITOTPLACENIIZNOSDescription;
            this.label1KREDITOTPLACENORATA.Text = StringResources.RADNIKKREDITOTPLACENORATADescription;
            this.label1PARTIJAKREDITASPECIFIKACIJA.Text = StringResources.RADNIKPARTIJAKREDITASPECIFIKACIJADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewGOOBRACUN")]
        public void NewGOOBRACUNHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.NewGOOBRACUN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewOTISLI")]
        public void NewOTISLIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.NewOTISLI(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewZAPOSLENI")]
        public void NewZAPOSLENIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.NewZAPOSLENI(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RADNIKFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RADNIKRADNIKKreditiLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIKKrediti|RADNIKKrediti"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIKKrediti, "RADNIKKrediti|RADNIKKrediti");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("RADNIKKreditiSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetFocusInFirstField()
        {
            this.textZADKREDITIIDKREDITOR.Focus();
        }

        private void SetNullItem_Click(object sender, EventArgs e)
        {
            this.m_BaseMethods.SetNullItemClickBase(RuntimeHelpers.GetObjectValue(sender), this.m_CurrentRow);
        }

        private void SetSize()
        {
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.m_FrameworkDescription, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void UpdateValuesKREDITORZADKREDITIIDKREDITOR(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceRADNIKKrediti.Current).Row["ZADKREDITIIDKREDITOR"] = RuntimeHelpers.GetObjectValue(result["IDKREDITOR"]);
                ((DataRowView) this.bindingSourceRADNIKKrediti.Current).Row["ZADKREDITINAZIVKREDITOR"] = RuntimeHelpers.GetObjectValue(result["NAZIVKREDITOR"]);
                ((DataRowView) this.bindingSourceRADNIKKrediti.Current).Row["ZADKREDITIPRIMATELJKREDITOR1"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJKREDITOR1"]);
                ((DataRowView) this.bindingSourceRADNIKKrediti.Current).Row["ZADKREDITIPRIMATELJKREDITOR2"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJKREDITOR2"]);
                ((DataRowView) this.bindingSourceRADNIKKrediti.Current).Row["ZADKREDITIPRIMATELJKREDITOR3"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJKREDITOR3"]);
                ((DataRowView) this.bindingSourceRADNIKKrediti.Current).Row["ZADKREDITIVBDIKREDITOR"] = RuntimeHelpers.GetObjectValue(result["VBDIKREDITOR"]);
                ((DataRowView) this.bindingSourceRADNIKKrediti.Current).Row["ZADKREDITIZRNKREDITOR"] = RuntimeHelpers.GetObjectValue(result["ZRNKREDITOR"]);
                this.bindingSourceRADNIKKrediti.ResetCurrentItem();
            }
        }

        [LocalCommandHandler("ViewGOOBRACUN")]
        public void ViewGOOBRACUNHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.ViewGOOBRACUN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewOTISLI")]
        public void ViewOTISLIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.ViewOTISLI(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewZAPOSLENI")]
        public void ViewZAPOSLENIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.ViewZAPOSLENI(this.m_CurrentRow);
            }
        }

        protected virtual UltraCheckEditor checkKREDITAKTIVAN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkKREDITAKTIVAN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkKREDITAKTIVAN = value;
            }
        }

        private ContextMenu contextMenu1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._contextMenu1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._contextMenu1 = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerDATUMUGOVORA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDATUMUGOVORA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDATUMUGOVORA = value;
            }
        }

        private ErrorProvider errorProvider1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._errorProvider1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._errorProvider1 = value;
            }
        }

        private ErrorProviderValidator errorProviderValidator1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._errorProviderValidator1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._errorProviderValidator1 = value;
            }
        }

        protected virtual UltraLabel label1DATUMUGOVORA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DATUMUGOVORA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DATUMUGOVORA = value;
            }
        }

        protected virtual UltraLabel label1KREDITAKTIVAN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KREDITAKTIVAN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KREDITAKTIVAN = value;
            }
        }

        protected virtual UltraLabel label1KREDITOTPLACENIIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KREDITOTPLACENIIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KREDITOTPLACENIIZNOS = value;
            }
        }

        protected virtual UltraLabel label1KREDITOTPLACENORATA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KREDITOTPLACENORATA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KREDITOTPLACENORATA = value;
            }
        }

        protected virtual UltraLabel label1MOKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MOKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MOKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1MZKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MZKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MZKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1OPISPLACANJAKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISPLACANJAKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISPLACANJAKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1PARTIJAKREDITASPECIFIKACIJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PARTIJAKREDITASPECIFIKACIJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PARTIJAKREDITASPECIFIKACIJA = value;
            }
        }

        protected virtual UltraLabel label1POKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1PZKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PZKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PZKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1SIFRAOPISAPLACANJAKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SIFRAOPISAPLACANJAKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SIFRAOPISAPLACANJAKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1ZADBROJRATAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADBROJRATAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADBROJRATAOBUSTAVE = value;
            }
        }

        protected virtual UltraLabel label1ZADIZNOSRATEKREDITA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADIZNOSRATEKREDITA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADIZNOSRATEKREDITA = value;
            }
        }

        protected virtual UltraLabel label1ZADKREDITIIDKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADKREDITIIDKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADKREDITIIDKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1ZADKREDITINAZIVKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADKREDITINAZIVKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADKREDITINAZIVKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1ZADKREDITIPRIMATELJKREDITOR1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADKREDITIPRIMATELJKREDITOR1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADKREDITIPRIMATELJKREDITOR1 = value;
            }
        }

        protected virtual UltraLabel label1ZADKREDITIPRIMATELJKREDITOR2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADKREDITIPRIMATELJKREDITOR2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADKREDITIPRIMATELJKREDITOR2 = value;
            }
        }

        protected virtual UltraLabel label1ZADKREDITIPRIMATELJKREDITOR3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADKREDITIPRIMATELJKREDITOR3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADKREDITIPRIMATELJKREDITOR3 = value;
            }
        }

        protected virtual UltraLabel label1ZADUKUPNIZNOSKREDITA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADUKUPNIZNOSKREDITA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADUKUPNIZNOSKREDITA = value;
            }
        }

        protected virtual UltraLabel label1ZADVECOTPLACENOBROJRATA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADVECOTPLACENOBROJRATA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADVECOTPLACENOBROJRATA = value;
            }
        }

        protected virtual UltraLabel label1ZADVECOTPLACENOUKUPNIIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADVECOTPLACENOUKUPNIIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADVECOTPLACENOUKUPNIIZNOS = value;
            }
        }

        protected virtual UltraLabel labelKREDITOTPLACENIIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelKREDITOTPLACENIIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelKREDITOTPLACENIIZNOS = value;
            }
        }

        protected virtual UltraLabel labelKREDITOTPLACENORATA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelKREDITOTPLACENORATA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelKREDITOTPLACENORATA = value;
            }
        }

        protected virtual UltraLabel labelZADKREDITINAZIVKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZADKREDITINAZIVKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZADKREDITINAZIVKREDITOR = value;
            }
        }

        protected virtual UltraLabel labelZADKREDITIPRIMATELJKREDITOR1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZADKREDITIPRIMATELJKREDITOR1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZADKREDITIPRIMATELJKREDITOR1 = value;
            }
        }

        protected virtual UltraLabel labelZADKREDITIPRIMATELJKREDITOR2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZADKREDITIPRIMATELJKREDITOR2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZADKREDITIPRIMATELJKREDITOR2 = value;
            }
        }

        protected virtual UltraLabel labelZADKREDITIPRIMATELJKREDITOR3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZADKREDITIPRIMATELJKREDITOR3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZADKREDITIPRIMATELJKREDITOR3 = value;
            }
        }

        public DeklaritMode Mode
        {
            get
            {
                return this.m_Mode;
            }
            set
            {
                this.m_Mode = value;
            }
        }

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.RADNIKController RADNIKController { get; set; }

        private MenuItem SetNullItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._SetNullItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._SetNullItem = value;
            }
        }

        protected virtual UltraTextEditor textMOKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMOKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMOKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textMZKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMZKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMZKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textOPISPLACANJAKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPISPLACANJAKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPISPLACANJAKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textPARTIJAKREDITASPECIFIKACIJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPARTIJAKREDITASPECIFIKACIJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPARTIJAKREDITASPECIFIKACIJA = value;
            }
        }

        protected virtual UltraTextEditor textPOKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textPZKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPZKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPZKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textSIFRAOPISAPLACANJAKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSIFRAOPISAPLACANJAKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSIFRAOPISAPLACANJAKREDITOR = value;
            }
        }

        protected virtual UltraNumericEditor textZADBROJRATAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADBROJRATAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADBROJRATAOBUSTAVE = value;
            }
        }

        protected virtual UltraNumericEditor textZADIZNOSRATEKREDITA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADIZNOSRATEKREDITA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADIZNOSRATEKREDITA = value;
            }
        }

        protected virtual UltraNumericEditor textZADKREDITIIDKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADKREDITIIDKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADKREDITIIDKREDITOR = value;
            }
        }

        protected virtual UltraNumericEditor textZADUKUPNIZNOSKREDITA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADUKUPNIZNOSKREDITA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADUKUPNIZNOSKREDITA = value;
            }
        }

        protected virtual UltraNumericEditor textZADVECOTPLACENOBROJRATA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADVECOTPLACENOBROJRATA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADVECOTPLACENOBROJRATA = value;
            }
        }

        protected virtual UltraNumericEditor textZADVECOTPLACENOUKUPNIIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADVECOTPLACENOUKUPNIIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADVECOTPLACENOUKUPNIIZNOS = value;
            }
        }

        private System.Windows.Forms.ToolTip toolTip1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._toolTip1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._toolTip1 = value;
            }
        }
    }
}

