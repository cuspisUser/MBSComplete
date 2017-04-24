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
    public class OBRACUNFormOBRACUNKreditiUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("datePickerDATUMUGOVORA")]
        private UltraDateTimeEditor _datePickerDATUMUGOVORA;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1BRRATADOSADA")]
        private UltraLabel _label1BRRATADOSADA;
        [AccessedThroughProperty("label1DATUMUGOVORA")]
        private UltraLabel _label1DATUMUGOVORA;
        [AccessedThroughProperty("label1DOSADAOBUSTAVLJENO")]
        private UltraLabel _label1DOSADAOBUSTAVLJENO;
        [AccessedThroughProperty("label1IDKREDITOR")]
        private UltraLabel _label1IDKREDITOR;
        [AccessedThroughProperty("label1NAZIVKREDITOR")]
        private UltraLabel _label1NAZIVKREDITOR;
        [AccessedThroughProperty("label1OBRACUNATIKUNSKIIZNOS")]
        private UltraLabel _label1OBRACUNATIKUNSKIIZNOS;
        [AccessedThroughProperty("label1OBRIZNOSRATEKREDITOR")]
        private UltraLabel _label1OBRIZNOSRATEKREDITOR;
        [AccessedThroughProperty("label1OBRMOKREDITOR")]
        private UltraLabel _label1OBRMOKREDITOR;
        [AccessedThroughProperty("label1OBRMZKREDITOR")]
        private UltraLabel _label1OBRMZKREDITOR;
        [AccessedThroughProperty("label1OBROPISPLACANJAKREDITOR")]
        private UltraLabel _label1OBROPISPLACANJAKREDITOR;
        [AccessedThroughProperty("label1OBRPOKREDITOR")]
        private UltraLabel _label1OBRPOKREDITOR;
        [AccessedThroughProperty("label1OBRPZKREDITOR")]
        private UltraLabel _label1OBRPZKREDITOR;
        [AccessedThroughProperty("label1OBRSIFRAOPISAPLACANJAKREDITOR")]
        private UltraLabel _label1OBRSIFRAOPISAPLACANJAKREDITOR;
        [AccessedThroughProperty("label1PRIMATELJKREDITOR1")]
        private UltraLabel _label1PRIMATELJKREDITOR1;
        [AccessedThroughProperty("label1PRIMATELJKREDITOR2")]
        private UltraLabel _label1PRIMATELJKREDITOR2;
        [AccessedThroughProperty("label1PRIMATELJKREDITOR3")]
        private UltraLabel _label1PRIMATELJKREDITOR3;
        [AccessedThroughProperty("label1UKUPNIZNOSKREDITA")]
        private UltraLabel _label1UKUPNIZNOSKREDITA;
        [AccessedThroughProperty("label1VBDIKREDITOR")]
        private UltraLabel _label1VBDIKREDITOR;
        [AccessedThroughProperty("label1VECOTPLACENOBROJRATA")]
        private UltraLabel _label1VECOTPLACENOBROJRATA;
        [AccessedThroughProperty("label1VECOTPLACENOUKUPNIIZNOS")]
        private UltraLabel _label1VECOTPLACENOUKUPNIIZNOS;
        [AccessedThroughProperty("label1ZRNKREDITOR")]
        private UltraLabel _label1ZRNKREDITOR;
        [AccessedThroughProperty("labelBRRATADOSADA")]
        private UltraLabel _labelBRRATADOSADA;
        [AccessedThroughProperty("labelDOSADAOBUSTAVLJENO")]
        private UltraLabel _labelDOSADAOBUSTAVLJENO;
        [AccessedThroughProperty("labelNAZIVKREDITOR")]
        private UltraLabel _labelNAZIVKREDITOR;
        [AccessedThroughProperty("labelPRIMATELJKREDITOR1")]
        private UltraLabel _labelPRIMATELJKREDITOR1;
        [AccessedThroughProperty("labelPRIMATELJKREDITOR2")]
        private UltraLabel _labelPRIMATELJKREDITOR2;
        [AccessedThroughProperty("labelPRIMATELJKREDITOR3")]
        private UltraLabel _labelPRIMATELJKREDITOR3;
        [AccessedThroughProperty("labelVBDIKREDITOR")]
        private UltraLabel _labelVBDIKREDITOR;
        [AccessedThroughProperty("labelZRNKREDITOR")]
        private UltraLabel _labelZRNKREDITOR;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDKREDITOR")]
        private UltraNumericEditor _textIDKREDITOR;
        [AccessedThroughProperty("textOBRACUNATIKUNSKIIZNOS")]
        private UltraNumericEditor _textOBRACUNATIKUNSKIIZNOS;
        [AccessedThroughProperty("textOBRIZNOSRATEKREDITOR")]
        private UltraNumericEditor _textOBRIZNOSRATEKREDITOR;
        [AccessedThroughProperty("textOBRMOKREDITOR")]
        private UltraTextEditor _textOBRMOKREDITOR;
        [AccessedThroughProperty("textOBRMZKREDITOR")]
        private UltraTextEditor _textOBRMZKREDITOR;
        [AccessedThroughProperty("textOBROPISPLACANJAKREDITOR")]
        private UltraTextEditor _textOBROPISPLACANJAKREDITOR;
        [AccessedThroughProperty("textOBRPOKREDITOR")]
        private UltraTextEditor _textOBRPOKREDITOR;
        [AccessedThroughProperty("textOBRPZKREDITOR")]
        private UltraTextEditor _textOBRPZKREDITOR;
        [AccessedThroughProperty("textOBRSIFRAOPISAPLACANJAKREDITOR")]
        private UltraTextEditor _textOBRSIFRAOPISAPLACANJAKREDITOR;
        [AccessedThroughProperty("textUKUPNIZNOSKREDITA")]
        private UltraNumericEditor _textUKUPNIZNOSKREDITA;
        [AccessedThroughProperty("textVECOTPLACENOBROJRATA")]
        private UltraNumericEditor _textVECOTPLACENOBROJRATA;
        [AccessedThroughProperty("textVECOTPLACENOUKUPNIIZNOS")]
        private UltraNumericEditor _textVECOTPLACENOUKUPNIIZNOS;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceOBRACUNKrediti;
        private IContainer components = null;
        private OBRACUNDataSet dsOBRACUNDataSet1;
        protected TableLayoutPanel layoutManagerformOBRACUNKrediti;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OBRACUNDataSet.OBRACUNKreditiRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "OBRACUNKrediti";
        private string m_FrameworkDescription = StringResources.OBRACUNDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        public OBRACUNFormOBRACUNKreditiUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("OBRACUNKreditiAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("OBRACUNKreditiAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (OBRACUNDataSet.OBRACUNKreditiRow) ((DataRowView) this.bindingSourceOBRACUNKrediti.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CallPromptKREDITORIDKREDITOR(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.OBRACUNController.SelectKREDITORIDKREDITOR(fillMethod, fillByRow);
            this.UpdateValuesKREDITORIDKREDITOR(result);
        }

        private void CallViewKREDITORIDKREDITOR(object sender, EventArgs e)
        {
            DataRow result = this.OBRACUNController.ShowKREDITORIDKREDITOR(this.m_CurrentRow);
            this.UpdateValuesKREDITORIDKREDITOR(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsOBRACUNDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceOBRACUNKrediti.DataSource = this.OBRACUNController.DataSet;
            this.dsOBRACUNDataSet1 = this.OBRACUNController.DataSet;
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
            this.dsOBRACUNDataSet1 = (OBRACUNDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceOBRACUNKrediti.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsOBRACUNDataSet1.Tables["OBRACUNKrediti"]);
            this.bindingSourceOBRACUNKrediti.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OBRACUN", this.m_Mode, this.dsOBRACUNDataSet1, this.dsOBRACUNDataSet1.OBRACUNKrediti.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding2 = new Binding("Text", this.bindingSourceOBRACUNKrediti, "DATUMUGOVORA", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding2.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerDATUMUGOVORA.DataBindings["Text"] != null)
            {
                this.datePickerDATUMUGOVORA.DataBindings.Remove(this.datePickerDATUMUGOVORA.DataBindings["Text"]);
            }
            this.datePickerDATUMUGOVORA.DataBindings.Add(binding2);
            Binding binding3 = new Binding("Text", this.bindingSourceOBRACUNKrediti, "DOSADAOBUSTAVLJENO", true);
            binding3.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelDOSADAOBUSTAVLJENO.DataBindings["Text"] != null)
            {
                this.labelDOSADAOBUSTAVLJENO.DataBindings.Remove(this.labelDOSADAOBUSTAVLJENO.DataBindings["Text"]);
            }
            this.labelDOSADAOBUSTAVLJENO.DataBindings.Add(binding3);
            Binding binding = new Binding("Text", this.bindingSourceOBRACUNKrediti, "BRRATADOSADA", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelBRRATADOSADA.DataBindings["Text"] != null)
            {
                this.labelBRRATADOSADA.DataBindings.Remove(this.labelBRRATADOSADA.DataBindings["Text"]);
            }
            this.labelBRRATADOSADA.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (OBRACUNDataSet.OBRACUNKreditiRow) ((DataRowView) this.bindingSourceOBRACUNKrediti.Current).Row;
                this.textIDKREDITOR.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textIDKREDITOR.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (OBRACUNDataSet.OBRACUNKreditiRow) ((DataRowView) this.bindingSourceOBRACUNKrediti.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(OBRACUNFormOBRACUNKreditiUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceOBRACUNKrediti = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOBRACUNKrediti).BeginInit();
            this.layoutManagerformOBRACUNKrediti = new TableLayoutPanel();
            this.layoutManagerformOBRACUNKrediti.SuspendLayout();
            this.layoutManagerformOBRACUNKrediti.AutoSize = true;
            this.layoutManagerformOBRACUNKrediti.Dock = DockStyle.Fill;
            this.layoutManagerformOBRACUNKrediti.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformOBRACUNKrediti.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformOBRACUNKrediti.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformOBRACUNKrediti.Size = size;
            this.layoutManagerformOBRACUNKrediti.ColumnCount = 2;
            this.layoutManagerformOBRACUNKrediti.RowCount = 0x16;
            this.layoutManagerformOBRACUNKrediti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOBRACUNKrediti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.label1IDKREDITOR = new UltraLabel();
            this.textIDKREDITOR = new UltraNumericEditor();
            this.label1DATUMUGOVORA = new UltraLabel();
            this.datePickerDATUMUGOVORA = new UltraDateTimeEditor();
            this.label1NAZIVKREDITOR = new UltraLabel();
            this.labelNAZIVKREDITOR = new UltraLabel();
            this.label1VBDIKREDITOR = new UltraLabel();
            this.labelVBDIKREDITOR = new UltraLabel();
            this.label1ZRNKREDITOR = new UltraLabel();
            this.labelZRNKREDITOR = new UltraLabel();
            this.label1PRIMATELJKREDITOR1 = new UltraLabel();
            this.labelPRIMATELJKREDITOR1 = new UltraLabel();
            this.label1PRIMATELJKREDITOR2 = new UltraLabel();
            this.labelPRIMATELJKREDITOR2 = new UltraLabel();
            this.label1PRIMATELJKREDITOR3 = new UltraLabel();
            this.labelPRIMATELJKREDITOR3 = new UltraLabel();
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR = new UltraLabel();
            this.textOBRSIFRAOPISAPLACANJAKREDITOR = new UltraTextEditor();
            this.label1OBROPISPLACANJAKREDITOR = new UltraLabel();
            this.textOBROPISPLACANJAKREDITOR = new UltraTextEditor();
            this.label1OBRMOKREDITOR = new UltraLabel();
            this.textOBRMOKREDITOR = new UltraTextEditor();
            this.label1OBRPOKREDITOR = new UltraLabel();
            this.textOBRPOKREDITOR = new UltraTextEditor();
            this.label1OBRMZKREDITOR = new UltraLabel();
            this.textOBRMZKREDITOR = new UltraTextEditor();
            this.label1OBRPZKREDITOR = new UltraLabel();
            this.textOBRPZKREDITOR = new UltraTextEditor();
            this.label1OBRIZNOSRATEKREDITOR = new UltraLabel();
            this.textOBRIZNOSRATEKREDITOR = new UltraNumericEditor();
            this.label1OBRACUNATIKUNSKIIZNOS = new UltraLabel();
            this.textOBRACUNATIKUNSKIIZNOS = new UltraNumericEditor();
            this.label1VECOTPLACENOBROJRATA = new UltraLabel();
            this.textVECOTPLACENOBROJRATA = new UltraNumericEditor();
            this.label1VECOTPLACENOUKUPNIIZNOS = new UltraLabel();
            this.textVECOTPLACENOUKUPNIIZNOS = new UltraNumericEditor();
            this.label1UKUPNIZNOSKREDITA = new UltraLabel();
            this.textUKUPNIZNOSKREDITA = new UltraNumericEditor();
            this.label1DOSADAOBUSTAVLJENO = new UltraLabel();
            this.labelDOSADAOBUSTAVLJENO = new UltraLabel();
            this.label1BRRATADOSADA = new UltraLabel();
            this.labelBRRATADOSADA = new UltraLabel();
            ((ISupportInitialize) this.textIDKREDITOR).BeginInit();
            ((ISupportInitialize) this.textOBRSIFRAOPISAPLACANJAKREDITOR).BeginInit();
            ((ISupportInitialize) this.textOBROPISPLACANJAKREDITOR).BeginInit();
            ((ISupportInitialize) this.textOBRMOKREDITOR).BeginInit();
            ((ISupportInitialize) this.textOBRPOKREDITOR).BeginInit();
            ((ISupportInitialize) this.textOBRMZKREDITOR).BeginInit();
            ((ISupportInitialize) this.textOBRPZKREDITOR).BeginInit();
            ((ISupportInitialize) this.textOBRIZNOSRATEKREDITOR).BeginInit();
            ((ISupportInitialize) this.textOBRACUNATIKUNSKIIZNOS).BeginInit();
            ((ISupportInitialize) this.textVECOTPLACENOBROJRATA).BeginInit();
            ((ISupportInitialize) this.textVECOTPLACENOUKUPNIIZNOS).BeginInit();
            ((ISupportInitialize) this.textUKUPNIZNOSKREDITA).BeginInit();
            this.dsOBRACUNDataSet1 = new OBRACUNDataSet();
            this.dsOBRACUNDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsOBRACUNDataSet1.DataSetName = "dsOBRACUN";
            this.dsOBRACUNDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceOBRACUNKrediti.DataSource = this.dsOBRACUNDataSet1;
            this.bindingSourceOBRACUNKrediti.DataMember = "OBRACUNKrediti";
            ((ISupportInitialize) this.bindingSourceOBRACUNKrediti).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDKREDITOR.Location = point;
            this.label1IDKREDITOR.Name = "label1IDKREDITOR";
            this.label1IDKREDITOR.TabIndex = 1;
            this.label1IDKREDITOR.Tag = "labelIDKREDITOR";
            this.label1IDKREDITOR.Text = "IDKREDITOR:";
            this.label1IDKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1IDKREDITOR.AutoSize = true;
            this.label1IDKREDITOR.Anchor = AnchorStyles.Left;
            this.label1IDKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDKREDITOR.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDKREDITOR.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDKREDITOR.ImageSize = size;
            this.label1IDKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1IDKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1IDKREDITOR, 0, 0);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1IDKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1IDKREDITOR, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x62, 0x17);
            this.label1IDKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDKREDITOR.Location = point;
            this.textIDKREDITOR.Name = "textIDKREDITOR";
            this.textIDKREDITOR.Tag = "IDKREDITOR";
            this.textIDKREDITOR.TabIndex = 0;
            this.textIDKREDITOR.Anchor = AnchorStyles.Left;
            this.textIDKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDKREDITOR.ReadOnly = false;
            this.textIDKREDITOR.PromptChar = ' ';
            this.textIDKREDITOR.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDKREDITOR.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUNKrediti, "IDKREDITOR"));
            this.textIDKREDITOR.NumericType = NumericType.Integer;
            this.textIDKREDITOR.MaskInput = "99999999";
            EditorButton button = new EditorButton {
                Key = "editorButtonKREDITORIDKREDITOR",
                Tag = "editorButtonKREDITORIDKREDITOR",
                Text = "..."
            };
            this.textIDKREDITOR.ButtonsRight.Add(button);
            this.textIDKREDITOR.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptKREDITORIDKREDITOR);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textIDKREDITOR, 1, 0);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.textIDKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.textIDKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textIDKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textIDKREDITOR.Size = size;
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
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1DATUMUGOVORA, 0, 1);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1DATUMUGOVORA, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1DATUMUGOVORA, 1);
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
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.datePickerDATUMUGOVORA, 1, 1);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.datePickerDATUMUGOVORA, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.datePickerDATUMUGOVORA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUMUGOVORA.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMUGOVORA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMUGOVORA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVKREDITOR.Location = point;
            this.label1NAZIVKREDITOR.Name = "label1NAZIVKREDITOR";
            this.label1NAZIVKREDITOR.TabIndex = 1;
            this.label1NAZIVKREDITOR.Tag = "labelNAZIVKREDITOR";
            this.label1NAZIVKREDITOR.Text = "NAZIVKREDITOR:";
            this.label1NAZIVKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVKREDITOR.AutoSize = true;
            this.label1NAZIVKREDITOR.Anchor = AnchorStyles.Left;
            this.label1NAZIVKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1NAZIVKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1NAZIVKREDITOR, 0, 2);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1NAZIVKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1NAZIVKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x7e, 0x17);
            this.label1NAZIVKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVKREDITOR.Location = point;
            this.labelNAZIVKREDITOR.Name = "labelNAZIVKREDITOR";
            this.labelNAZIVKREDITOR.Tag = "NAZIVKREDITOR";
            this.labelNAZIVKREDITOR.TabIndex = 0;
            this.labelNAZIVKREDITOR.Anchor = AnchorStyles.Left;
            this.labelNAZIVKREDITOR.BackColor = Color.Transparent;
            this.labelNAZIVKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "NAZIVKREDITOR"));
            this.labelNAZIVKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.labelNAZIVKREDITOR, 1, 2);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.labelNAZIVKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.labelNAZIVKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelNAZIVKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelNAZIVKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VBDIKREDITOR.Location = point;
            this.label1VBDIKREDITOR.Name = "label1VBDIKREDITOR";
            this.label1VBDIKREDITOR.TabIndex = 1;
            this.label1VBDIKREDITOR.Tag = "labelVBDIKREDITOR";
            this.label1VBDIKREDITOR.Text = "VBDIKREDITOR:";
            this.label1VBDIKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1VBDIKREDITOR.AutoSize = true;
            this.label1VBDIKREDITOR.Anchor = AnchorStyles.Left;
            this.label1VBDIKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1VBDIKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1VBDIKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1VBDIKREDITOR, 0, 3);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1VBDIKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1VBDIKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VBDIKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VBDIKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x76, 0x17);
            this.label1VBDIKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelVBDIKREDITOR.Location = point;
            this.labelVBDIKREDITOR.Name = "labelVBDIKREDITOR";
            this.labelVBDIKREDITOR.Tag = "VBDIKREDITOR";
            this.labelVBDIKREDITOR.TabIndex = 0;
            this.labelVBDIKREDITOR.Anchor = AnchorStyles.Left;
            this.labelVBDIKREDITOR.BackColor = Color.Transparent;
            this.labelVBDIKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "VBDIKREDITOR"));
            this.labelVBDIKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.labelVBDIKREDITOR, 1, 3);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.labelVBDIKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.labelVBDIKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelVBDIKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.labelVBDIKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.labelVBDIKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZRNKREDITOR.Location = point;
            this.label1ZRNKREDITOR.Name = "label1ZRNKREDITOR";
            this.label1ZRNKREDITOR.TabIndex = 1;
            this.label1ZRNKREDITOR.Tag = "labelZRNKREDITOR";
            this.label1ZRNKREDITOR.Text = "ZRNKREDITOR:";
            this.label1ZRNKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1ZRNKREDITOR.AutoSize = true;
            this.label1ZRNKREDITOR.Anchor = AnchorStyles.Left;
            this.label1ZRNKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZRNKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1ZRNKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1ZRNKREDITOR, 0, 4);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1ZRNKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1ZRNKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZRNKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZRNKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x70, 0x17);
            this.label1ZRNKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelZRNKREDITOR.Location = point;
            this.labelZRNKREDITOR.Name = "labelZRNKREDITOR";
            this.labelZRNKREDITOR.Tag = "ZRNKREDITOR";
            this.labelZRNKREDITOR.TabIndex = 0;
            this.labelZRNKREDITOR.Anchor = AnchorStyles.Left;
            this.labelZRNKREDITOR.BackColor = Color.Transparent;
            this.labelZRNKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "ZRNKREDITOR"));
            this.labelZRNKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.labelZRNKREDITOR, 1, 4);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.labelZRNKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.labelZRNKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelZRNKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.labelZRNKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.labelZRNKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJKREDITOR1.Location = point;
            this.label1PRIMATELJKREDITOR1.Name = "label1PRIMATELJKREDITOR1";
            this.label1PRIMATELJKREDITOR1.TabIndex = 1;
            this.label1PRIMATELJKREDITOR1.Tag = "labelPRIMATELJKREDITOR1";
            this.label1PRIMATELJKREDITOR1.Text = "PRIMATELJKREDITO R1:";
            this.label1PRIMATELJKREDITOR1.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJKREDITOR1.AutoSize = true;
            this.label1PRIMATELJKREDITOR1.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJKREDITOR1.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJKREDITOR1.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJKREDITOR1.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1PRIMATELJKREDITOR1, 0, 5);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1PRIMATELJKREDITOR1, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1PRIMATELJKREDITOR1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJKREDITOR1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJKREDITOR1.MinimumSize = size;
            size = new System.Drawing.Size(0xa8, 0x17);
            this.label1PRIMATELJKREDITOR1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPRIMATELJKREDITOR1.Location = point;
            this.labelPRIMATELJKREDITOR1.Name = "labelPRIMATELJKREDITOR1";
            this.labelPRIMATELJKREDITOR1.Tag = "PRIMATELJKREDITOR1";
            this.labelPRIMATELJKREDITOR1.TabIndex = 0;
            this.labelPRIMATELJKREDITOR1.Anchor = AnchorStyles.Left;
            this.labelPRIMATELJKREDITOR1.BackColor = Color.Transparent;
            this.labelPRIMATELJKREDITOR1.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "PRIMATELJKREDITOR1"));
            this.labelPRIMATELJKREDITOR1.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.labelPRIMATELJKREDITOR1, 1, 5);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.labelPRIMATELJKREDITOR1, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.labelPRIMATELJKREDITOR1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPRIMATELJKREDITOR1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJKREDITOR1.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJKREDITOR1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJKREDITOR2.Location = point;
            this.label1PRIMATELJKREDITOR2.Name = "label1PRIMATELJKREDITOR2";
            this.label1PRIMATELJKREDITOR2.TabIndex = 1;
            this.label1PRIMATELJKREDITOR2.Tag = "labelPRIMATELJKREDITOR2";
            this.label1PRIMATELJKREDITOR2.Text = "PRIMATELJKREDITO R2:";
            this.label1PRIMATELJKREDITOR2.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJKREDITOR2.AutoSize = true;
            this.label1PRIMATELJKREDITOR2.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJKREDITOR2.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJKREDITOR2.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJKREDITOR2.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1PRIMATELJKREDITOR2, 0, 6);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1PRIMATELJKREDITOR2, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1PRIMATELJKREDITOR2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJKREDITOR2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJKREDITOR2.MinimumSize = size;
            size = new System.Drawing.Size(0xa8, 0x17);
            this.label1PRIMATELJKREDITOR2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPRIMATELJKREDITOR2.Location = point;
            this.labelPRIMATELJKREDITOR2.Name = "labelPRIMATELJKREDITOR2";
            this.labelPRIMATELJKREDITOR2.Tag = "PRIMATELJKREDITOR2";
            this.labelPRIMATELJKREDITOR2.TabIndex = 0;
            this.labelPRIMATELJKREDITOR2.Anchor = AnchorStyles.Left;
            this.labelPRIMATELJKREDITOR2.BackColor = Color.Transparent;
            this.labelPRIMATELJKREDITOR2.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "PRIMATELJKREDITOR2"));
            this.labelPRIMATELJKREDITOR2.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.labelPRIMATELJKREDITOR2, 1, 6);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.labelPRIMATELJKREDITOR2, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.labelPRIMATELJKREDITOR2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPRIMATELJKREDITOR2.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJKREDITOR2.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJKREDITOR2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJKREDITOR3.Location = point;
            this.label1PRIMATELJKREDITOR3.Name = "label1PRIMATELJKREDITOR3";
            this.label1PRIMATELJKREDITOR3.TabIndex = 1;
            this.label1PRIMATELJKREDITOR3.Tag = "labelPRIMATELJKREDITOR3";
            this.label1PRIMATELJKREDITOR3.Text = "PRIMATELJKREDITO R3:";
            this.label1PRIMATELJKREDITOR3.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJKREDITOR3.AutoSize = true;
            this.label1PRIMATELJKREDITOR3.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJKREDITOR3.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJKREDITOR3.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJKREDITOR3.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1PRIMATELJKREDITOR3, 0, 7);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1PRIMATELJKREDITOR3, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1PRIMATELJKREDITOR3, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJKREDITOR3.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJKREDITOR3.MinimumSize = size;
            size = new System.Drawing.Size(0xa8, 0x17);
            this.label1PRIMATELJKREDITOR3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPRIMATELJKREDITOR3.Location = point;
            this.labelPRIMATELJKREDITOR3.Name = "labelPRIMATELJKREDITOR3";
            this.labelPRIMATELJKREDITOR3.Tag = "PRIMATELJKREDITOR3";
            this.labelPRIMATELJKREDITOR3.TabIndex = 0;
            this.labelPRIMATELJKREDITOR3.Anchor = AnchorStyles.Left;
            this.labelPRIMATELJKREDITOR3.BackColor = Color.Transparent;
            this.labelPRIMATELJKREDITOR3.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "PRIMATELJKREDITOR3"));
            this.labelPRIMATELJKREDITOR3.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.labelPRIMATELJKREDITOR3, 1, 7);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.labelPRIMATELJKREDITOR3, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.labelPRIMATELJKREDITOR3, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPRIMATELJKREDITOR3.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJKREDITOR3.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJKREDITOR3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Location = point;
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Name = "label1OBRSIFRAOPISAPLACANJAKREDITOR";
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.TabIndex = 1;
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Tag = "labelOBRSIFRAOPISAPLACANJAKREDITOR";
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Text = "SIFRAOPISAPLACANJAKREDITOR:";
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.AutoSize = true;
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Anchor = AnchorStyles.Left;
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1OBRSIFRAOPISAPLACANJAKREDITOR, 0, 8);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1OBRSIFRAOPISAPLACANJAKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1OBRSIFRAOPISAPLACANJAKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0xe4, 0x17);
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.Location = point;
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.Name = "textOBRSIFRAOPISAPLACANJAKREDITOR";
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.Tag = "OBRSIFRAOPISAPLACANJAKREDITOR";
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.TabIndex = 0;
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.Anchor = AnchorStyles.Left;
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.ReadOnly = false;
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "OBRSIFRAOPISAPLACANJAKREDITOR"));
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.MaxLength = 2;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textOBRSIFRAOPISAPLACANJAKREDITOR, 1, 8);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.textOBRSIFRAOPISAPLACANJAKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.textOBRSIFRAOPISAPLACANJAKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBROPISPLACANJAKREDITOR.Location = point;
            this.label1OBROPISPLACANJAKREDITOR.Name = "label1OBROPISPLACANJAKREDITOR";
            this.label1OBROPISPLACANJAKREDITOR.TabIndex = 1;
            this.label1OBROPISPLACANJAKREDITOR.Tag = "labelOBROPISPLACANJAKREDITOR";
            this.label1OBROPISPLACANJAKREDITOR.Text = "OBROPISPLACANJAKREDITOR:";
            this.label1OBROPISPLACANJAKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1OBROPISPLACANJAKREDITOR.AutoSize = true;
            this.label1OBROPISPLACANJAKREDITOR.Anchor = AnchorStyles.Left;
            this.label1OBROPISPLACANJAKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBROPISPLACANJAKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1OBROPISPLACANJAKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1OBROPISPLACANJAKREDITOR, 0, 9);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1OBROPISPLACANJAKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1OBROPISPLACANJAKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBROPISPLACANJAKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBROPISPLACANJAKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0xd1, 0x17);
            this.label1OBROPISPLACANJAKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBROPISPLACANJAKREDITOR.Location = point;
            this.textOBROPISPLACANJAKREDITOR.Name = "textOBROPISPLACANJAKREDITOR";
            this.textOBROPISPLACANJAKREDITOR.Tag = "OBROPISPLACANJAKREDITOR";
            this.textOBROPISPLACANJAKREDITOR.TabIndex = 0;
            this.textOBROPISPLACANJAKREDITOR.Anchor = AnchorStyles.Left;
            this.textOBROPISPLACANJAKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBROPISPLACANJAKREDITOR.ReadOnly = false;
            this.textOBROPISPLACANJAKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "OBROPISPLACANJAKREDITOR"));
            this.textOBROPISPLACANJAKREDITOR.MaxLength = 0x24;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textOBROPISPLACANJAKREDITOR, 1, 9);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.textOBROPISPLACANJAKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.textOBROPISPLACANJAKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBROPISPLACANJAKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOBROPISPLACANJAKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOBROPISPLACANJAKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRMOKREDITOR.Location = point;
            this.label1OBRMOKREDITOR.Name = "label1OBRMOKREDITOR";
            this.label1OBRMOKREDITOR.TabIndex = 1;
            this.label1OBRMOKREDITOR.Tag = "labelOBRMOKREDITOR";
            this.label1OBRMOKREDITOR.Text = "OBRMOKREDITOR:";
            this.label1OBRMOKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1OBRMOKREDITOR.AutoSize = true;
            this.label1OBRMOKREDITOR.Anchor = AnchorStyles.Left;
            this.label1OBRMOKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRMOKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1OBRMOKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1OBRMOKREDITOR, 0, 10);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1OBRMOKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1OBRMOKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRMOKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRMOKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x85, 0x17);
            this.label1OBRMOKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBRMOKREDITOR.Location = point;
            this.textOBRMOKREDITOR.Name = "textOBRMOKREDITOR";
            this.textOBRMOKREDITOR.Tag = "OBRMOKREDITOR";
            this.textOBRMOKREDITOR.TabIndex = 0;
            this.textOBRMOKREDITOR.Anchor = AnchorStyles.Left;
            this.textOBRMOKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBRMOKREDITOR.ContextMenu = this.contextMenu1;
            this.textOBRMOKREDITOR.ReadOnly = false;
            this.textOBRMOKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "OBRMOKREDITOR"));
            this.textOBRMOKREDITOR.Nullable = true;
            this.textOBRMOKREDITOR.MaxLength = 2;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textOBRMOKREDITOR, 1, 10);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.textOBRMOKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.textOBRMOKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBRMOKREDITOR.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textOBRMOKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textOBRMOKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRPOKREDITOR.Location = point;
            this.label1OBRPOKREDITOR.Name = "label1OBRPOKREDITOR";
            this.label1OBRPOKREDITOR.TabIndex = 1;
            this.label1OBRPOKREDITOR.Tag = "labelOBRPOKREDITOR";
            this.label1OBRPOKREDITOR.Text = "OBRPOKREDITOR:";
            this.label1OBRPOKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1OBRPOKREDITOR.AutoSize = true;
            this.label1OBRPOKREDITOR.Anchor = AnchorStyles.Left;
            this.label1OBRPOKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRPOKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1OBRPOKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1OBRPOKREDITOR, 0, 11);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1OBRPOKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1OBRPOKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRPOKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRPOKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(130, 0x17);
            this.label1OBRPOKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBRPOKREDITOR.Location = point;
            this.textOBRPOKREDITOR.Name = "textOBRPOKREDITOR";
            this.textOBRPOKREDITOR.Tag = "OBRPOKREDITOR";
            this.textOBRPOKREDITOR.TabIndex = 0;
            this.textOBRPOKREDITOR.Anchor = AnchorStyles.Left;
            this.textOBRPOKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBRPOKREDITOR.ContextMenu = this.contextMenu1;
            this.textOBRPOKREDITOR.ReadOnly = false;
            this.textOBRPOKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "OBRPOKREDITOR"));
            this.textOBRPOKREDITOR.Nullable = true;
            this.textOBRPOKREDITOR.MaxLength = 0x16;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textOBRPOKREDITOR, 1, 11);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.textOBRPOKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.textOBRPOKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBRPOKREDITOR.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textOBRPOKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textOBRPOKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRMZKREDITOR.Location = point;
            this.label1OBRMZKREDITOR.Name = "label1OBRMZKREDITOR";
            this.label1OBRMZKREDITOR.TabIndex = 1;
            this.label1OBRMZKREDITOR.Tag = "labelOBRMZKREDITOR";
            this.label1OBRMZKREDITOR.Text = "OBRMZKREDITOR:";
            this.label1OBRMZKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1OBRMZKREDITOR.AutoSize = true;
            this.label1OBRMZKREDITOR.Anchor = AnchorStyles.Left;
            this.label1OBRMZKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRMZKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1OBRMZKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1OBRMZKREDITOR, 0, 12);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1OBRMZKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1OBRMZKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRMZKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRMZKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x83, 0x17);
            this.label1OBRMZKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBRMZKREDITOR.Location = point;
            this.textOBRMZKREDITOR.Name = "textOBRMZKREDITOR";
            this.textOBRMZKREDITOR.Tag = "OBRMZKREDITOR";
            this.textOBRMZKREDITOR.TabIndex = 0;
            this.textOBRMZKREDITOR.Anchor = AnchorStyles.Left;
            this.textOBRMZKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBRMZKREDITOR.ContextMenu = this.contextMenu1;
            this.textOBRMZKREDITOR.ReadOnly = false;
            this.textOBRMZKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "OBRMZKREDITOR"));
            this.textOBRMZKREDITOR.Nullable = true;
            this.textOBRMZKREDITOR.MaxLength = 2;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textOBRMZKREDITOR, 1, 12);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.textOBRMZKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.textOBRMZKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBRMZKREDITOR.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textOBRMZKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textOBRMZKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRPZKREDITOR.Location = point;
            this.label1OBRPZKREDITOR.Name = "label1OBRPZKREDITOR";
            this.label1OBRPZKREDITOR.TabIndex = 1;
            this.label1OBRPZKREDITOR.Tag = "labelOBRPZKREDITOR";
            this.label1OBRPZKREDITOR.Text = "OBRPZKREDITOR:";
            this.label1OBRPZKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1OBRPZKREDITOR.AutoSize = true;
            this.label1OBRPZKREDITOR.Anchor = AnchorStyles.Left;
            this.label1OBRPZKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRPZKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1OBRPZKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1OBRPZKREDITOR, 0, 13);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1OBRPZKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1OBRPZKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRPZKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRPZKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x80, 0x17);
            this.label1OBRPZKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBRPZKREDITOR.Location = point;
            this.textOBRPZKREDITOR.Name = "textOBRPZKREDITOR";
            this.textOBRPZKREDITOR.Tag = "OBRPZKREDITOR";
            this.textOBRPZKREDITOR.TabIndex = 0;
            this.textOBRPZKREDITOR.Anchor = AnchorStyles.Left;
            this.textOBRPZKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBRPZKREDITOR.ContextMenu = this.contextMenu1;
            this.textOBRPZKREDITOR.ReadOnly = false;
            this.textOBRPZKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "OBRPZKREDITOR"));
            this.textOBRPZKREDITOR.Nullable = true;
            this.textOBRPZKREDITOR.MaxLength = 0x16;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textOBRPZKREDITOR, 1, 13);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.textOBRPZKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.textOBRPZKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBRPZKREDITOR.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textOBRPZKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textOBRPZKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRIZNOSRATEKREDITOR.Location = point;
            this.label1OBRIZNOSRATEKREDITOR.Name = "label1OBRIZNOSRATEKREDITOR";
            this.label1OBRIZNOSRATEKREDITOR.TabIndex = 1;
            this.label1OBRIZNOSRATEKREDITOR.Tag = "labelOBRIZNOSRATEKREDITOR";
            this.label1OBRIZNOSRATEKREDITOR.Text = "OBRIZNOSRATEKREDITOR:";
            this.label1OBRIZNOSRATEKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1OBRIZNOSRATEKREDITOR.AutoSize = true;
            this.label1OBRIZNOSRATEKREDITOR.Anchor = AnchorStyles.Left;
            this.label1OBRIZNOSRATEKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRIZNOSRATEKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1OBRIZNOSRATEKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1OBRIZNOSRATEKREDITOR, 0, 14);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1OBRIZNOSRATEKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1OBRIZNOSRATEKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRIZNOSRATEKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRIZNOSRATEKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0xba, 0x17);
            this.label1OBRIZNOSRATEKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBRIZNOSRATEKREDITOR.Location = point;
            this.textOBRIZNOSRATEKREDITOR.Name = "textOBRIZNOSRATEKREDITOR";
            this.textOBRIZNOSRATEKREDITOR.Tag = "OBRIZNOSRATEKREDITOR";
            this.textOBRIZNOSRATEKREDITOR.TabIndex = 0;
            this.textOBRIZNOSRATEKREDITOR.Anchor = AnchorStyles.Left;
            this.textOBRIZNOSRATEKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBRIZNOSRATEKREDITOR.ReadOnly = false;
            this.textOBRIZNOSRATEKREDITOR.PromptChar = ' ';
            this.textOBRIZNOSRATEKREDITOR.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOBRIZNOSRATEKREDITOR.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUNKrediti, "OBRIZNOSRATEKREDITOR"));
            this.textOBRIZNOSRATEKREDITOR.NumericType = NumericType.Double;
            this.textOBRIZNOSRATEKREDITOR.MaxValue = 79228162514264337593543950335M;
            this.textOBRIZNOSRATEKREDITOR.MinValue = -79228162514264337593543950335M;
            this.textOBRIZNOSRATEKREDITOR.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textOBRIZNOSRATEKREDITOR, 1, 14);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.textOBRIZNOSRATEKREDITOR, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.textOBRIZNOSRATEKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBRIZNOSRATEKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRIZNOSRATEKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRIZNOSRATEKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRACUNATIKUNSKIIZNOS.Location = point;
            this.label1OBRACUNATIKUNSKIIZNOS.Name = "label1OBRACUNATIKUNSKIIZNOS";
            this.label1OBRACUNATIKUNSKIIZNOS.TabIndex = 1;
            this.label1OBRACUNATIKUNSKIIZNOS.Tag = "labelOBRACUNATIKUNSKIIZNOS";
            this.label1OBRACUNATIKUNSKIIZNOS.Text = "OBRACUNATIKUNSKIIZNOS:";
            this.label1OBRACUNATIKUNSKIIZNOS.StyleSetName = "FieldUltraLabel";
            this.label1OBRACUNATIKUNSKIIZNOS.AutoSize = true;
            this.label1OBRACUNATIKUNSKIIZNOS.Anchor = AnchorStyles.Left;
            this.label1OBRACUNATIKUNSKIIZNOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRACUNATIKUNSKIIZNOS.Appearance.ForeColor = Color.Black;
            this.label1OBRACUNATIKUNSKIIZNOS.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1OBRACUNATIKUNSKIIZNOS, 0, 15);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1OBRACUNATIKUNSKIIZNOS, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1OBRACUNATIKUNSKIIZNOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRACUNATIKUNSKIIZNOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRACUNATIKUNSKIIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0xc2, 0x17);
            this.label1OBRACUNATIKUNSKIIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBRACUNATIKUNSKIIZNOS.Location = point;
            this.textOBRACUNATIKUNSKIIZNOS.Name = "textOBRACUNATIKUNSKIIZNOS";
            this.textOBRACUNATIKUNSKIIZNOS.Tag = "OBRACUNATIKUNSKIIZNOS";
            this.textOBRACUNATIKUNSKIIZNOS.TabIndex = 0;
            this.textOBRACUNATIKUNSKIIZNOS.Anchor = AnchorStyles.Left;
            this.textOBRACUNATIKUNSKIIZNOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBRACUNATIKUNSKIIZNOS.ReadOnly = false;
            this.textOBRACUNATIKUNSKIIZNOS.PromptChar = ' ';
            this.textOBRACUNATIKUNSKIIZNOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOBRACUNATIKUNSKIIZNOS.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUNKrediti, "OBRACUNATIKUNSKIIZNOS"));
            this.textOBRACUNATIKUNSKIIZNOS.NumericType = NumericType.Double;
            this.textOBRACUNATIKUNSKIIZNOS.MaxValue = 79228162514264337593543950335M;
            this.textOBRACUNATIKUNSKIIZNOS.MinValue = -79228162514264337593543950335M;
            this.textOBRACUNATIKUNSKIIZNOS.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textOBRACUNATIKUNSKIIZNOS, 1, 15);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.textOBRACUNATIKUNSKIIZNOS, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.textOBRACUNATIKUNSKIIZNOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBRACUNATIKUNSKIIZNOS.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRACUNATIKUNSKIIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRACUNATIKUNSKIIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VECOTPLACENOBROJRATA.Location = point;
            this.label1VECOTPLACENOBROJRATA.Name = "label1VECOTPLACENOBROJRATA";
            this.label1VECOTPLACENOBROJRATA.TabIndex = 1;
            this.label1VECOTPLACENOBROJRATA.Tag = "labelVECOTPLACENOBROJRATA";
            this.label1VECOTPLACENOBROJRATA.Text = ":";
            this.label1VECOTPLACENOBROJRATA.StyleSetName = "FieldUltraLabel";
            this.label1VECOTPLACENOBROJRATA.AutoSize = true;
            this.label1VECOTPLACENOBROJRATA.Anchor = AnchorStyles.Left;
            this.label1VECOTPLACENOBROJRATA.Appearance.TextVAlign = VAlign.Middle;
            this.label1VECOTPLACENOBROJRATA.Appearance.ForeColor = Color.Black;
            this.label1VECOTPLACENOBROJRATA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1VECOTPLACENOBROJRATA, 0, 0x10);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1VECOTPLACENOBROJRATA, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1VECOTPLACENOBROJRATA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VECOTPLACENOBROJRATA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VECOTPLACENOBROJRATA.MinimumSize = size;
            size = new System.Drawing.Size(0x13, 0x17);
            this.label1VECOTPLACENOBROJRATA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVECOTPLACENOBROJRATA.Location = point;
            this.textVECOTPLACENOBROJRATA.Name = "textVECOTPLACENOBROJRATA";
            this.textVECOTPLACENOBROJRATA.Tag = "VECOTPLACENOBROJRATA";
            this.textVECOTPLACENOBROJRATA.TabIndex = 0;
            this.textVECOTPLACENOBROJRATA.Anchor = AnchorStyles.Left;
            this.textVECOTPLACENOBROJRATA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVECOTPLACENOBROJRATA.ReadOnly = false;
            this.textVECOTPLACENOBROJRATA.PromptChar = ' ';
            this.textVECOTPLACENOBROJRATA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textVECOTPLACENOBROJRATA.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUNKrediti, "VECOTPLACENOBROJRATA"));
            this.textVECOTPLACENOBROJRATA.NumericType = NumericType.Double;
            this.textVECOTPLACENOBROJRATA.MaxValue = 79228162514264337593543950335M;
            this.textVECOTPLACENOBROJRATA.MinValue = -79228162514264337593543950335M;
            this.textVECOTPLACENOBROJRATA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textVECOTPLACENOBROJRATA, 1, 0x10);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.textVECOTPLACENOBROJRATA, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.textVECOTPLACENOBROJRATA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVECOTPLACENOBROJRATA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textVECOTPLACENOBROJRATA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textVECOTPLACENOBROJRATA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VECOTPLACENOUKUPNIIZNOS.Location = point;
            this.label1VECOTPLACENOUKUPNIIZNOS.Name = "label1VECOTPLACENOUKUPNIIZNOS";
            this.label1VECOTPLACENOUKUPNIIZNOS.TabIndex = 1;
            this.label1VECOTPLACENOUKUPNIIZNOS.Tag = "labelVECOTPLACENOUKUPNIIZNOS";
            this.label1VECOTPLACENOUKUPNIIZNOS.Text = ":";
            this.label1VECOTPLACENOUKUPNIIZNOS.StyleSetName = "FieldUltraLabel";
            this.label1VECOTPLACENOUKUPNIIZNOS.AutoSize = true;
            this.label1VECOTPLACENOUKUPNIIZNOS.Anchor = AnchorStyles.Left;
            this.label1VECOTPLACENOUKUPNIIZNOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1VECOTPLACENOUKUPNIIZNOS.Appearance.ForeColor = Color.Black;
            this.label1VECOTPLACENOUKUPNIIZNOS.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1VECOTPLACENOUKUPNIIZNOS, 0, 0x11);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1VECOTPLACENOUKUPNIIZNOS, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1VECOTPLACENOUKUPNIIZNOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VECOTPLACENOUKUPNIIZNOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VECOTPLACENOUKUPNIIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x13, 0x17);
            this.label1VECOTPLACENOUKUPNIIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVECOTPLACENOUKUPNIIZNOS.Location = point;
            this.textVECOTPLACENOUKUPNIIZNOS.Name = "textVECOTPLACENOUKUPNIIZNOS";
            this.textVECOTPLACENOUKUPNIIZNOS.Tag = "VECOTPLACENOUKUPNIIZNOS";
            this.textVECOTPLACENOUKUPNIIZNOS.TabIndex = 0;
            this.textVECOTPLACENOUKUPNIIZNOS.Anchor = AnchorStyles.Left;
            this.textVECOTPLACENOUKUPNIIZNOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVECOTPLACENOUKUPNIIZNOS.ReadOnly = false;
            this.textVECOTPLACENOUKUPNIIZNOS.PromptChar = ' ';
            this.textVECOTPLACENOUKUPNIIZNOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textVECOTPLACENOUKUPNIIZNOS.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUNKrediti, "VECOTPLACENOUKUPNIIZNOS"));
            this.textVECOTPLACENOUKUPNIIZNOS.NumericType = NumericType.Double;
            this.textVECOTPLACENOUKUPNIIZNOS.MaxValue = 79228162514264337593543950335M;
            this.textVECOTPLACENOUKUPNIIZNOS.MinValue = -79228162514264337593543950335M;
            this.textVECOTPLACENOUKUPNIIZNOS.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textVECOTPLACENOUKUPNIIZNOS, 1, 0x11);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.textVECOTPLACENOUKUPNIIZNOS, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.textVECOTPLACENOUKUPNIIZNOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVECOTPLACENOUKUPNIIZNOS.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textVECOTPLACENOUKUPNIIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textVECOTPLACENOUKUPNIIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1UKUPNIZNOSKREDITA.Location = point;
            this.label1UKUPNIZNOSKREDITA.Name = "label1UKUPNIZNOSKREDITA";
            this.label1UKUPNIZNOSKREDITA.TabIndex = 1;
            this.label1UKUPNIZNOSKREDITA.Tag = "labelUKUPNIZNOSKREDITA";
            this.label1UKUPNIZNOSKREDITA.Text = ":";
            this.label1UKUPNIZNOSKREDITA.StyleSetName = "FieldUltraLabel";
            this.label1UKUPNIZNOSKREDITA.AutoSize = true;
            this.label1UKUPNIZNOSKREDITA.Anchor = AnchorStyles.Left;
            this.label1UKUPNIZNOSKREDITA.Appearance.TextVAlign = VAlign.Middle;
            this.label1UKUPNIZNOSKREDITA.Appearance.ForeColor = Color.Black;
            this.label1UKUPNIZNOSKREDITA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1UKUPNIZNOSKREDITA, 0, 0x12);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1UKUPNIZNOSKREDITA, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1UKUPNIZNOSKREDITA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1UKUPNIZNOSKREDITA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1UKUPNIZNOSKREDITA.MinimumSize = size;
            size = new System.Drawing.Size(0x13, 0x17);
            this.label1UKUPNIZNOSKREDITA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textUKUPNIZNOSKREDITA.Location = point;
            this.textUKUPNIZNOSKREDITA.Name = "textUKUPNIZNOSKREDITA";
            this.textUKUPNIZNOSKREDITA.Tag = "UKUPNIZNOSKREDITA";
            this.textUKUPNIZNOSKREDITA.TabIndex = 0;
            this.textUKUPNIZNOSKREDITA.Anchor = AnchorStyles.Left;
            this.textUKUPNIZNOSKREDITA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textUKUPNIZNOSKREDITA.ReadOnly = false;
            this.textUKUPNIZNOSKREDITA.PromptChar = ' ';
            this.textUKUPNIZNOSKREDITA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textUKUPNIZNOSKREDITA.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUNKrediti, "UKUPNIZNOSKREDITA"));
            this.textUKUPNIZNOSKREDITA.NumericType = NumericType.Double;
            this.textUKUPNIZNOSKREDITA.MaxValue = 79228162514264337593543950335M;
            this.textUKUPNIZNOSKREDITA.MinValue = -79228162514264337593543950335M;
            this.textUKUPNIZNOSKREDITA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textUKUPNIZNOSKREDITA, 1, 0x12);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.textUKUPNIZNOSKREDITA, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.textUKUPNIZNOSKREDITA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textUKUPNIZNOSKREDITA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textUKUPNIZNOSKREDITA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textUKUPNIZNOSKREDITA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DOSADAOBUSTAVLJENO.Location = point;
            this.label1DOSADAOBUSTAVLJENO.Name = "label1DOSADAOBUSTAVLJENO";
            this.label1DOSADAOBUSTAVLJENO.TabIndex = 1;
            this.label1DOSADAOBUSTAVLJENO.Tag = "labelDOSADAOBUSTAVLJENO";
            this.label1DOSADAOBUSTAVLJENO.Text = ":";
            this.label1DOSADAOBUSTAVLJENO.StyleSetName = "FieldUltraLabel";
            this.label1DOSADAOBUSTAVLJENO.AutoSize = true;
            this.label1DOSADAOBUSTAVLJENO.Anchor = AnchorStyles.Left;
            this.label1DOSADAOBUSTAVLJENO.Appearance.TextVAlign = VAlign.Middle;
            this.label1DOSADAOBUSTAVLJENO.Appearance.ForeColor = Color.Black;
            this.label1DOSADAOBUSTAVLJENO.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1DOSADAOBUSTAVLJENO, 0, 0x13);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1DOSADAOBUSTAVLJENO, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1DOSADAOBUSTAVLJENO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DOSADAOBUSTAVLJENO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DOSADAOBUSTAVLJENO.MinimumSize = size;
            size = new System.Drawing.Size(0x13, 0x17);
            this.label1DOSADAOBUSTAVLJENO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelDOSADAOBUSTAVLJENO.Location = point;
            this.labelDOSADAOBUSTAVLJENO.Name = "labelDOSADAOBUSTAVLJENO";
            this.labelDOSADAOBUSTAVLJENO.Tag = "DOSADAOBUSTAVLJENO";
            this.labelDOSADAOBUSTAVLJENO.TabIndex = 0;
            this.labelDOSADAOBUSTAVLJENO.Anchor = AnchorStyles.Left;
            this.labelDOSADAOBUSTAVLJENO.BackColor = Color.Transparent;
            this.labelDOSADAOBUSTAVLJENO.Appearance.TextHAlign = HAlign.Left;
            this.labelDOSADAOBUSTAVLJENO.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.labelDOSADAOBUSTAVLJENO, 1, 0x13);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.labelDOSADAOBUSTAVLJENO, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.labelDOSADAOBUSTAVLJENO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelDOSADAOBUSTAVLJENO.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelDOSADAOBUSTAVLJENO.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelDOSADAOBUSTAVLJENO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1BRRATADOSADA.Location = point;
            this.label1BRRATADOSADA.Name = "label1BRRATADOSADA";
            this.label1BRRATADOSADA.TabIndex = 1;
            this.label1BRRATADOSADA.Tag = "labelBRRATADOSADA";
            this.label1BRRATADOSADA.Text = ":";
            this.label1BRRATADOSADA.StyleSetName = "FieldUltraLabel";
            this.label1BRRATADOSADA.AutoSize = true;
            this.label1BRRATADOSADA.Anchor = AnchorStyles.Left;
            this.label1BRRATADOSADA.Appearance.TextVAlign = VAlign.Middle;
            this.label1BRRATADOSADA.Appearance.ForeColor = Color.Black;
            this.label1BRRATADOSADA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1BRRATADOSADA, 0, 20);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.label1BRRATADOSADA, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.label1BRRATADOSADA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1BRRATADOSADA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BRRATADOSADA.MinimumSize = size;
            size = new System.Drawing.Size(0x13, 0x17);
            this.label1BRRATADOSADA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelBRRATADOSADA.Location = point;
            this.labelBRRATADOSADA.Name = "labelBRRATADOSADA";
            this.labelBRRATADOSADA.Tag = "BRRATADOSADA";
            this.labelBRRATADOSADA.TabIndex = 0;
            this.labelBRRATADOSADA.Anchor = AnchorStyles.Left;
            this.labelBRRATADOSADA.BackColor = Color.Transparent;
            this.labelBRRATADOSADA.Appearance.TextHAlign = HAlign.Left;
            this.labelBRRATADOSADA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.labelBRRATADOSADA, 1, 20);
            this.layoutManagerformOBRACUNKrediti.SetColumnSpan(this.labelBRRATADOSADA, 1);
            this.layoutManagerformOBRACUNKrediti.SetRowSpan(this.labelBRRATADOSADA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelBRRATADOSADA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelBRRATADOSADA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelBRRATADOSADA.Size = size;
            this.Controls.Add(this.layoutManagerformOBRACUNKrediti);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceOBRACUNKrediti;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "OBRACUNFormOBRACUNKreditiUserControl";
            this.Text = " ObracunKrediti";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OBRACUNFormUserControl_Load);
            this.layoutManagerformOBRACUNKrediti.ResumeLayout(false);
            this.layoutManagerformOBRACUNKrediti.PerformLayout();
            ((ISupportInitialize) this.bindingSourceOBRACUNKrediti).EndInit();
            ((ISupportInitialize) this.textIDKREDITOR).EndInit();
            ((ISupportInitialize) this.textOBRSIFRAOPISAPLACANJAKREDITOR).EndInit();
            ((ISupportInitialize) this.textOBROPISPLACANJAKREDITOR).EndInit();
            ((ISupportInitialize) this.textOBRMOKREDITOR).EndInit();
            ((ISupportInitialize) this.textOBRPOKREDITOR).EndInit();
            ((ISupportInitialize) this.textOBRMZKREDITOR).EndInit();
            ((ISupportInitialize) this.textOBRPZKREDITOR).EndInit();
            ((ISupportInitialize) this.textOBRIZNOSRATEKREDITOR).EndInit();
            ((ISupportInitialize) this.textOBRACUNATIKUNSKIIZNOS).EndInit();
            ((ISupportInitialize) this.textVECOTPLACENOBROJRATA).EndInit();
            ((ISupportInitialize) this.textVECOTPLACENOUKUPNIIZNOS).EndInit();
            ((ISupportInitialize) this.textUKUPNIZNOSKREDITA).EndInit();
            this.dsOBRACUNDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OBRACUNController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceOBRACUNKrediti, this.OBRACUNController.WorkItem, this))
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
            this.label1IDKREDITOR.Text = StringResources.OBRACUNIDKREDITORDescription;
            this.label1DATUMUGOVORA.Text = StringResources.OBRACUNDATUMUGOVORADescription;
            this.label1NAZIVKREDITOR.Text = StringResources.OBRACUNNAZIVKREDITORDescription;
            this.label1VBDIKREDITOR.Text = StringResources.OBRACUNVBDIKREDITORDescription;
            this.label1ZRNKREDITOR.Text = StringResources.OBRACUNZRNKREDITORDescription;
            this.label1PRIMATELJKREDITOR1.Text = StringResources.OBRACUNPRIMATELJKREDITOR1Description;
            this.label1PRIMATELJKREDITOR2.Text = StringResources.OBRACUNPRIMATELJKREDITOR2Description;
            this.label1PRIMATELJKREDITOR3.Text = StringResources.OBRACUNPRIMATELJKREDITOR3Description;
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Text = StringResources.OBRACUNOBRSIFRAOPISAPLACANJAKREDITORDescription;
            this.label1OBROPISPLACANJAKREDITOR.Text = StringResources.OBRACUNOBROPISPLACANJAKREDITORDescription;
            this.label1OBRMOKREDITOR.Text = StringResources.OBRACUNOBRMOKREDITORDescription;
            this.label1OBRPOKREDITOR.Text = StringResources.OBRACUNOBRPOKREDITORDescription;
            this.label1OBRMZKREDITOR.Text = StringResources.OBRACUNOBRMZKREDITORDescription;
            this.label1OBRPZKREDITOR.Text = StringResources.OBRACUNOBRPZKREDITORDescription;
            this.label1OBRIZNOSRATEKREDITOR.Text = StringResources.OBRACUNOBRIZNOSRATEKREDITORDescription;
            this.label1OBRACUNATIKUNSKIIZNOS.Text = StringResources.OBRACUNOBRACUNATIKUNSKIIZNOSDescription;
            this.label1VECOTPLACENOBROJRATA.Text = StringResources.OBRACUNVECOTPLACENOBROJRATADescription;
            this.label1VECOTPLACENOUKUPNIIZNOS.Text = StringResources.OBRACUNVECOTPLACENOUKUPNIIZNOSDescription;
            this.label1UKUPNIZNOSKREDITA.Text = StringResources.OBRACUNUKUPNIZNOSKREDITADescription;
            this.label1DOSADAOBUSTAVLJENO.Text = StringResources.OBRACUNDOSADAOBUSTAVLJENODescription;
            this.label1BRRATADOSADA.Text = StringResources.OBRACUNBRRATADOSADADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewRSMA")]
        public void NewRSMAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OBRACUNController.NewRSMA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void OBRACUNFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.OBRACUNOBRACUNKreditiLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.OBRACUNController.WorkItem.Items.Contains("OBRACUNKrediti|OBRACUNKrediti"))
            {
                this.OBRACUNController.WorkItem.Items.Add(this.bindingSourceOBRACUNKrediti, "OBRACUNKrediti|OBRACUNKrediti");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("OBRACUNKreditiSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDKREDITOR.Focus();
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

        private void UpdateValuesKREDITORIDKREDITOR(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceOBRACUNKrediti.Current).Row["IDKREDITOR"] = RuntimeHelpers.GetObjectValue(result["IDKREDITOR"]);
                ((DataRowView) this.bindingSourceOBRACUNKrediti.Current).Row["NAZIVKREDITOR"] = RuntimeHelpers.GetObjectValue(result["NAZIVKREDITOR"]);
                ((DataRowView) this.bindingSourceOBRACUNKrediti.Current).Row["VBDIKREDITOR"] = RuntimeHelpers.GetObjectValue(result["VBDIKREDITOR"]);
                ((DataRowView) this.bindingSourceOBRACUNKrediti.Current).Row["ZRNKREDITOR"] = RuntimeHelpers.GetObjectValue(result["ZRNKREDITOR"]);
                ((DataRowView) this.bindingSourceOBRACUNKrediti.Current).Row["PRIMATELJKREDITOR1"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJKREDITOR1"]);
                ((DataRowView) this.bindingSourceOBRACUNKrediti.Current).Row["PRIMATELJKREDITOR2"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJKREDITOR2"]);
                ((DataRowView) this.bindingSourceOBRACUNKrediti.Current).Row["PRIMATELJKREDITOR3"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJKREDITOR3"]);
                this.bindingSourceOBRACUNKrediti.ResetCurrentItem();
            }
        }

        [LocalCommandHandler("ViewRSMA")]
        public void ViewRSMAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OBRACUNController.ViewRSMA(this.m_CurrentRow);
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

        protected virtual UltraLabel label1BRRATADOSADA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BRRATADOSADA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BRRATADOSADA = value;
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

        protected virtual UltraLabel label1DOSADAOBUSTAVLJENO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DOSADAOBUSTAVLJENO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DOSADAOBUSTAVLJENO = value;
            }
        }

        protected virtual UltraLabel label1IDKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1NAZIVKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1OBRACUNATIKUNSKIIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRACUNATIKUNSKIIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRACUNATIKUNSKIIZNOS = value;
            }
        }

        protected virtual UltraLabel label1OBRIZNOSRATEKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRIZNOSRATEKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRIZNOSRATEKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1OBRMOKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRMOKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRMOKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1OBRMZKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRMZKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRMZKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1OBROPISPLACANJAKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBROPISPLACANJAKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBROPISPLACANJAKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1OBRPOKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRPOKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRPOKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1OBRPZKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRPZKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRPZKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1OBRSIFRAOPISAPLACANJAKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRSIFRAOPISAPLACANJAKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRSIFRAOPISAPLACANJAKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJKREDITOR1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJKREDITOR1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJKREDITOR1 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJKREDITOR2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJKREDITOR2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJKREDITOR2 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJKREDITOR3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJKREDITOR3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJKREDITOR3 = value;
            }
        }

        protected virtual UltraLabel label1UKUPNIZNOSKREDITA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1UKUPNIZNOSKREDITA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1UKUPNIZNOSKREDITA = value;
            }
        }

        protected virtual UltraLabel label1VBDIKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VBDIKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VBDIKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1VECOTPLACENOBROJRATA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VECOTPLACENOBROJRATA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VECOTPLACENOBROJRATA = value;
            }
        }

        protected virtual UltraLabel label1VECOTPLACENOUKUPNIIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VECOTPLACENOUKUPNIIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VECOTPLACENOUKUPNIIZNOS = value;
            }
        }

        protected virtual UltraLabel label1ZRNKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZRNKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZRNKREDITOR = value;
            }
        }

        protected virtual UltraLabel labelBRRATADOSADA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelBRRATADOSADA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelBRRATADOSADA = value;
            }
        }

        protected virtual UltraLabel labelDOSADAOBUSTAVLJENO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelDOSADAOBUSTAVLJENO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelDOSADAOBUSTAVLJENO = value;
            }
        }

        protected virtual UltraLabel labelNAZIVKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVKREDITOR = value;
            }
        }

        protected virtual UltraLabel labelPRIMATELJKREDITOR1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPRIMATELJKREDITOR1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPRIMATELJKREDITOR1 = value;
            }
        }

        protected virtual UltraLabel labelPRIMATELJKREDITOR2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPRIMATELJKREDITOR2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPRIMATELJKREDITOR2 = value;
            }
        }

        protected virtual UltraLabel labelPRIMATELJKREDITOR3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPRIMATELJKREDITOR3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPRIMATELJKREDITOR3 = value;
            }
        }

        protected virtual UltraLabel labelVBDIKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelVBDIKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelVBDIKREDITOR = value;
            }
        }

        protected virtual UltraLabel labelZRNKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZRNKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZRNKREDITOR = value;
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.OBRACUNController OBRACUNController { get; set; }

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

        protected virtual UltraNumericEditor textIDKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDKREDITOR = value;
            }
        }

        protected virtual UltraNumericEditor textOBRACUNATIKUNSKIIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRACUNATIKUNSKIIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRACUNATIKUNSKIIZNOS = value;
            }
        }

        protected virtual UltraNumericEditor textOBRIZNOSRATEKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRIZNOSRATEKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRIZNOSRATEKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textOBRMOKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRMOKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRMOKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textOBRMZKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRMZKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRMZKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textOBROPISPLACANJAKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBROPISPLACANJAKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBROPISPLACANJAKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textOBRPOKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRPOKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRPOKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textOBRPZKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRPZKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRPZKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textOBRSIFRAOPISAPLACANJAKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRSIFRAOPISAPLACANJAKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRSIFRAOPISAPLACANJAKREDITOR = value;
            }
        }

        protected virtual UltraNumericEditor textUKUPNIZNOSKREDITA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textUKUPNIZNOSKREDITA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textUKUPNIZNOSKREDITA = value;
            }
        }

        protected virtual UltraNumericEditor textVECOTPLACENOBROJRATA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVECOTPLACENOBROJRATA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVECOTPLACENOBROJRATA = value;
            }
        }

        protected virtual UltraNumericEditor textVECOTPLACENOUKUPNIIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVECOTPLACENOUKUPNIIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVECOTPLACENOUKUPNIIZNOS = value;
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

