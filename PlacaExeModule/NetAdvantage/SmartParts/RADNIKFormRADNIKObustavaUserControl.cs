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
    public class RADNIKFormRADNIKObustavaUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkOBUSTAVAAKTIVNA")]
        private UltraCheckEditor _checkOBUSTAVAAKTIVNA;
        [AccessedThroughProperty("checkZADPOSTOTNAODBRUTA")]
        private UltraCheckEditor _checkZADPOSTOTNAODBRUTA;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1OBUSTAVAAKTIVNA")]
        private UltraLabel _label1OBUSTAVAAKTIVNA;
        [AccessedThroughProperty("label1OTPLACENIBROJRATA")]
        private UltraLabel _label1OTPLACENIBROJRATA;
        [AccessedThroughProperty("label1OTPLACENIIZNOS")]
        private UltraLabel _label1OTPLACENIIZNOS;
        [AccessedThroughProperty("label1ZADISPLACENOKASA")]
        private UltraLabel _label1ZADISPLACENOKASA;
        [AccessedThroughProperty("label1ZADIZNOSOBUSTAVE")]
        private UltraLabel _label1ZADIZNOSOBUSTAVE;
        [AccessedThroughProperty("label1ZADOBUSTAVAIDOBUSTAVA")]
        private UltraLabel _label1ZADOBUSTAVAIDOBUSTAVA;
        [AccessedThroughProperty("label1ZADOBUSTAVANAZIVOBUSTAVA")]
        private UltraLabel _label1ZADOBUSTAVANAZIVOBUSTAVA;
        [AccessedThroughProperty("label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE")]
        private UltraLabel _label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE;
        [AccessedThroughProperty("label1ZADOBUSTAVAVRSTAOBUSTAVE")]
        private UltraLabel _label1ZADOBUSTAVAVRSTAOBUSTAVE;
        [AccessedThroughProperty("label1ZADPOSTOTAKOBUSTAVE")]
        private UltraLabel _label1ZADPOSTOTAKOBUSTAVE;
        [AccessedThroughProperty("label1ZADPOSTOTNAODBRUTA")]
        private UltraLabel _label1ZADPOSTOTNAODBRUTA;
        [AccessedThroughProperty("label1ZADSALDOKASA")]
        private UltraLabel _label1ZADSALDOKASA;
        [AccessedThroughProperty("labelOTPLACENIBROJRATA")]
        private UltraLabel _labelOTPLACENIBROJRATA;
        [AccessedThroughProperty("labelOTPLACENIIZNOS")]
        private UltraLabel _labelOTPLACENIIZNOS;
        [AccessedThroughProperty("labelZADOBUSTAVANAZIVOBUSTAVA")]
        private UltraLabel _labelZADOBUSTAVANAZIVOBUSTAVA;
        [AccessedThroughProperty("labelZADOBUSTAVANAZIVVRSTAOBUSTAVE")]
        private UltraLabel _labelZADOBUSTAVANAZIVVRSTAOBUSTAVE;
        [AccessedThroughProperty("labelZADOBUSTAVAVRSTAOBUSTAVE")]
        private UltraLabel _labelZADOBUSTAVAVRSTAOBUSTAVE;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textZADISPLACENOKASA")]
        private UltraNumericEditor _textZADISPLACENOKASA;
        [AccessedThroughProperty("textZADIZNOSOBUSTAVE")]
        private UltraNumericEditor _textZADIZNOSOBUSTAVE;
        [AccessedThroughProperty("textZADOBUSTAVAIDOBUSTAVA")]
        private UltraNumericEditor _textZADOBUSTAVAIDOBUSTAVA;
        [AccessedThroughProperty("textZADPOSTOTAKOBUSTAVE")]
        private UltraNumericEditor _textZADPOSTOTAKOBUSTAVE;
        [AccessedThroughProperty("textZADSALDOKASA")]
        private UltraNumericEditor _textZADSALDOKASA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRADNIKObustava;
        private IContainer components = null;
        private RADNIKDataSet dsRADNIKDataSet1;
        protected TableLayoutPanel layoutManagerformRADNIKObustava;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RADNIKDataSet.RADNIKObustavaRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RADNIKObustava";
        private string m_FrameworkDescription = StringResources.RADNIKDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        public RADNIKFormRADNIKObustavaUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("RADNIKObustavaAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("RADNIKObustavaAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (RADNIKDataSet.RADNIKObustavaRow) ((DataRowView) this.bindingSourceRADNIKObustava.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CallPromptOBUSTAVAZADOBUSTAVAIDOBUSTAVA(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.RADNIKController.SelectOBUSTAVAZADOBUSTAVAIDOBUSTAVA(fillMethod, fillByRow);
            this.UpdateValuesOBUSTAVAZADOBUSTAVAIDOBUSTAVA(result);
        }

        private void CallViewOBUSTAVAZADOBUSTAVAIDOBUSTAVA(object sender, EventArgs e)
        {
            DataRow result = this.RADNIKController.ShowOBUSTAVAZADOBUSTAVAIDOBUSTAVA(this.m_CurrentRow);
            this.UpdateValuesOBUSTAVAZADOBUSTAVAIDOBUSTAVA(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsRADNIKDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceRADNIKObustava.DataSource = this.RADNIKController.DataSet;
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
            this.bindingSourceRADNIKObustava.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsRADNIKDataSet1.Tables["RADNIKObustava"]);
            this.bindingSourceRADNIKObustava.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RADNIK", this.m_Mode, this.dsRADNIKDataSet1, this.dsRADNIKDataSet1.RADNIKObustava.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("CheckState", this.bindingSourceRADNIKObustava, "OBUSTAVAAKTIVNA", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkOBUSTAVAAKTIVNA.DataBindings["CheckState"] != null)
            {
                this.checkOBUSTAVAAKTIVNA.DataBindings.Remove(this.checkOBUSTAVAAKTIVNA.DataBindings["CheckState"]);
            }
            this.checkOBUSTAVAAKTIVNA.DataBindings.Add(binding);
            Binding binding4 = new Binding("CheckState", this.bindingSourceRADNIKObustava, "ZADPOSTOTNAODBRUTA", true);
            binding4.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding4.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkZADPOSTOTNAODBRUTA.DataBindings["CheckState"] != null)
            {
                this.checkZADPOSTOTNAODBRUTA.DataBindings.Remove(this.checkZADPOSTOTNAODBRUTA.DataBindings["CheckState"]);
            }
            this.checkZADPOSTOTNAODBRUTA.DataBindings.Add(binding4);
            Binding binding3 = new Binding("Text", this.bindingSourceRADNIKObustava, "OTPLACENIIZNOS", true);
            binding3.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelOTPLACENIIZNOS.DataBindings["Text"] != null)
            {
                this.labelOTPLACENIIZNOS.DataBindings.Remove(this.labelOTPLACENIIZNOS.DataBindings["Text"]);
            }
            this.labelOTPLACENIIZNOS.DataBindings.Add(binding3);
            Binding binding2 = new Binding("Text", this.bindingSourceRADNIKObustava, "OTPLACENIBROJRATA", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelOTPLACENIBROJRATA.DataBindings["Text"] != null)
            {
                this.labelOTPLACENIBROJRATA.DataBindings.Remove(this.labelOTPLACENIBROJRATA.DataBindings["Text"]);
            }
            this.labelOTPLACENIBROJRATA.DataBindings.Add(binding2);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (RADNIKDataSet.RADNIKObustavaRow) ((DataRowView) this.bindingSourceRADNIKObustava.Current).Row;
                this.textZADOBUSTAVAIDOBUSTAVA.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textZADOBUSTAVAIDOBUSTAVA.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (RADNIKDataSet.RADNIKObustavaRow) ((DataRowView) this.bindingSourceRADNIKObustava.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(RADNIKFormRADNIKObustavaUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRADNIKObustava = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIKObustava).BeginInit();
            this.layoutManagerformRADNIKObustava = new TableLayoutPanel();
            this.layoutManagerformRADNIKObustava.SuspendLayout();
            this.layoutManagerformRADNIKObustava.AutoSize = true;
            this.layoutManagerformRADNIKObustava.Dock = DockStyle.Fill;
            this.layoutManagerformRADNIKObustava.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRADNIKObustava.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRADNIKObustava.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRADNIKObustava.Size = size;
            this.layoutManagerformRADNIKObustava.ColumnCount = 2;
            this.layoutManagerformRADNIKObustava.RowCount = 13;
            this.layoutManagerformRADNIKObustava.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIKObustava.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIKObustava.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKObustava.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKObustava.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKObustava.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKObustava.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKObustava.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKObustava.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKObustava.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKObustava.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKObustava.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKObustava.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKObustava.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKObustava.RowStyles.Add(new RowStyle());
            this.label1ZADOBUSTAVAIDOBUSTAVA = new UltraLabel();
            this.textZADOBUSTAVAIDOBUSTAVA = new UltraNumericEditor();
            this.label1ZADOBUSTAVANAZIVOBUSTAVA = new UltraLabel();
            this.labelZADOBUSTAVANAZIVOBUSTAVA = new UltraLabel();
            this.label1ZADOBUSTAVAVRSTAOBUSTAVE = new UltraLabel();
            this.labelZADOBUSTAVAVRSTAOBUSTAVE = new UltraLabel();
            this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE = new UltraLabel();
            this.labelZADOBUSTAVANAZIVVRSTAOBUSTAVE = new UltraLabel();
            this.label1OBUSTAVAAKTIVNA = new UltraLabel();
            this.checkOBUSTAVAAKTIVNA = new UltraCheckEditor();
            this.label1ZADIZNOSOBUSTAVE = new UltraLabel();
            this.textZADIZNOSOBUSTAVE = new UltraNumericEditor();
            this.label1ZADPOSTOTAKOBUSTAVE = new UltraLabel();
            this.textZADPOSTOTAKOBUSTAVE = new UltraNumericEditor();
            this.label1ZADPOSTOTNAODBRUTA = new UltraLabel();
            this.checkZADPOSTOTNAODBRUTA = new UltraCheckEditor();
            this.label1ZADSALDOKASA = new UltraLabel();
            this.textZADSALDOKASA = new UltraNumericEditor();
            this.label1ZADISPLACENOKASA = new UltraLabel();
            this.textZADISPLACENOKASA = new UltraNumericEditor();
            this.label1OTPLACENIIZNOS = new UltraLabel();
            this.labelOTPLACENIIZNOS = new UltraLabel();
            this.label1OTPLACENIBROJRATA = new UltraLabel();
            this.labelOTPLACENIBROJRATA = new UltraLabel();
            ((ISupportInitialize) this.textZADOBUSTAVAIDOBUSTAVA).BeginInit();
            ((ISupportInitialize) this.textZADIZNOSOBUSTAVE).BeginInit();
            ((ISupportInitialize) this.textZADPOSTOTAKOBUSTAVE).BeginInit();
            ((ISupportInitialize) this.textZADSALDOKASA).BeginInit();
            ((ISupportInitialize) this.textZADISPLACENOKASA).BeginInit();
            this.dsRADNIKDataSet1 = new RADNIKDataSet();
            this.dsRADNIKDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRADNIKDataSet1.DataSetName = "dsRADNIK";
            this.dsRADNIKDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRADNIKObustava.DataSource = this.dsRADNIKDataSet1;
            this.bindingSourceRADNIKObustava.DataMember = "RADNIKObustava";
            ((ISupportInitialize) this.bindingSourceRADNIKObustava).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1ZADOBUSTAVAIDOBUSTAVA.Location = point;
            this.label1ZADOBUSTAVAIDOBUSTAVA.Name = "label1ZADOBUSTAVAIDOBUSTAVA";
            this.label1ZADOBUSTAVAIDOBUSTAVA.TabIndex = 1;
            this.label1ZADOBUSTAVAIDOBUSTAVA.Tag = "labelZADOBUSTAVAIDOBUSTAVA";
            this.label1ZADOBUSTAVAIDOBUSTAVA.Text = "Šifra:";
            this.label1ZADOBUSTAVAIDOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1ZADOBUSTAVAIDOBUSTAVA.AutoSize = true;
            this.label1ZADOBUSTAVAIDOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1ZADOBUSTAVAIDOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADOBUSTAVAIDOBUSTAVA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1ZADOBUSTAVAIDOBUSTAVA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1ZADOBUSTAVAIDOBUSTAVA.ImageSize = size;
            this.label1ZADOBUSTAVAIDOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1ZADOBUSTAVAIDOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.label1ZADOBUSTAVAIDOBUSTAVA, 0, 0);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.label1ZADOBUSTAVAIDOBUSTAVA, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.label1ZADOBUSTAVAIDOBUSTAVA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1ZADOBUSTAVAIDOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADOBUSTAVAIDOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1ZADOBUSTAVAIDOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADOBUSTAVAIDOBUSTAVA.Location = point;
            this.textZADOBUSTAVAIDOBUSTAVA.Name = "textZADOBUSTAVAIDOBUSTAVA";
            this.textZADOBUSTAVAIDOBUSTAVA.Tag = "ZADOBUSTAVAIDOBUSTAVA";
            this.textZADOBUSTAVAIDOBUSTAVA.TabIndex = 0;
            this.textZADOBUSTAVAIDOBUSTAVA.Anchor = AnchorStyles.Left;
            this.textZADOBUSTAVAIDOBUSTAVA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADOBUSTAVAIDOBUSTAVA.ReadOnly = false;
            this.textZADOBUSTAVAIDOBUSTAVA.PromptChar = ' ';
            this.textZADOBUSTAVAIDOBUSTAVA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textZADOBUSTAVAIDOBUSTAVA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKObustava, "ZADOBUSTAVAIDOBUSTAVA"));
            this.textZADOBUSTAVAIDOBUSTAVA.NumericType = NumericType.Integer;
            this.textZADOBUSTAVAIDOBUSTAVA.MaskInput = "{LOC}-nnnnnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonOBUSTAVAZADOBUSTAVAIDOBUSTAVA",
                Tag = "editorButtonOBUSTAVAZADOBUSTAVAIDOBUSTAVA",
                Text = "..."
            };
            this.textZADOBUSTAVAIDOBUSTAVA.ButtonsRight.Add(button);
            this.textZADOBUSTAVAIDOBUSTAVA.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOBUSTAVAZADOBUSTAVAIDOBUSTAVA);
            this.layoutManagerformRADNIKObustava.Controls.Add(this.textZADOBUSTAVAIDOBUSTAVA, 1, 0);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.textZADOBUSTAVAIDOBUSTAVA, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.textZADOBUSTAVAIDOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADOBUSTAVAIDOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textZADOBUSTAVAIDOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textZADOBUSTAVAIDOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADOBUSTAVANAZIVOBUSTAVA.Location = point;
            this.label1ZADOBUSTAVANAZIVOBUSTAVA.Name = "label1ZADOBUSTAVANAZIVOBUSTAVA";
            this.label1ZADOBUSTAVANAZIVOBUSTAVA.TabIndex = 1;
            this.label1ZADOBUSTAVANAZIVOBUSTAVA.Tag = "labelZADOBUSTAVANAZIVOBUSTAVA";
            this.label1ZADOBUSTAVANAZIVOBUSTAVA.Text = "Obustava:";
            this.label1ZADOBUSTAVANAZIVOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1ZADOBUSTAVANAZIVOBUSTAVA.AutoSize = true;
            this.label1ZADOBUSTAVANAZIVOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1ZADOBUSTAVANAZIVOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADOBUSTAVANAZIVOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1ZADOBUSTAVANAZIVOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.label1ZADOBUSTAVANAZIVOBUSTAVA, 0, 1);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.label1ZADOBUSTAVANAZIVOBUSTAVA, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.label1ZADOBUSTAVANAZIVOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADOBUSTAVANAZIVOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADOBUSTAVANAZIVOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x4e, 0x17);
            this.label1ZADOBUSTAVANAZIVOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelZADOBUSTAVANAZIVOBUSTAVA.Location = point;
            this.labelZADOBUSTAVANAZIVOBUSTAVA.Name = "labelZADOBUSTAVANAZIVOBUSTAVA";
            this.labelZADOBUSTAVANAZIVOBUSTAVA.Tag = "ZADOBUSTAVANAZIVOBUSTAVA";
            this.labelZADOBUSTAVANAZIVOBUSTAVA.TabIndex = 0;
            this.labelZADOBUSTAVANAZIVOBUSTAVA.Anchor = AnchorStyles.Left;
            this.labelZADOBUSTAVANAZIVOBUSTAVA.BackColor = Color.Transparent;
            this.labelZADOBUSTAVANAZIVOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKObustava, "ZADOBUSTAVANAZIVOBUSTAVA"));
            this.labelZADOBUSTAVANAZIVOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.labelZADOBUSTAVANAZIVOBUSTAVA, 1, 1);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.labelZADOBUSTAVANAZIVOBUSTAVA, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.labelZADOBUSTAVANAZIVOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelZADOBUSTAVANAZIVOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelZADOBUSTAVANAZIVOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelZADOBUSTAVANAZIVOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADOBUSTAVAVRSTAOBUSTAVE.Location = point;
            this.label1ZADOBUSTAVAVRSTAOBUSTAVE.Name = "label1ZADOBUSTAVAVRSTAOBUSTAVE";
            this.label1ZADOBUSTAVAVRSTAOBUSTAVE.TabIndex = 1;
            this.label1ZADOBUSTAVAVRSTAOBUSTAVE.Tag = "labelZADOBUSTAVAVRSTAOBUSTAVE";
            this.label1ZADOBUSTAVAVRSTAOBUSTAVE.Text = "Vrsta:";
            this.label1ZADOBUSTAVAVRSTAOBUSTAVE.StyleSetName = "FieldUltraLabel";
            this.label1ZADOBUSTAVAVRSTAOBUSTAVE.AutoSize = true;
            this.label1ZADOBUSTAVAVRSTAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.label1ZADOBUSTAVAVRSTAOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADOBUSTAVAVRSTAOBUSTAVE.Appearance.ForeColor = Color.Black;
            this.label1ZADOBUSTAVAVRSTAOBUSTAVE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.label1ZADOBUSTAVAVRSTAOBUSTAVE, 0, 2);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.label1ZADOBUSTAVAVRSTAOBUSTAVE, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.label1ZADOBUSTAVAVRSTAOBUSTAVE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADOBUSTAVAVRSTAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADOBUSTAVAVRSTAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x34, 0x17);
            this.label1ZADOBUSTAVAVRSTAOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelZADOBUSTAVAVRSTAOBUSTAVE.Location = point;
            this.labelZADOBUSTAVAVRSTAOBUSTAVE.Name = "labelZADOBUSTAVAVRSTAOBUSTAVE";
            this.labelZADOBUSTAVAVRSTAOBUSTAVE.Tag = "ZADOBUSTAVAVRSTAOBUSTAVE";
            this.labelZADOBUSTAVAVRSTAOBUSTAVE.TabIndex = 0;
            this.labelZADOBUSTAVAVRSTAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.labelZADOBUSTAVAVRSTAOBUSTAVE.BackColor = Color.Transparent;
            this.labelZADOBUSTAVAVRSTAOBUSTAVE.Appearance.TextHAlign = HAlign.Left;
            this.labelZADOBUSTAVAVRSTAOBUSTAVE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKObustava, "ZADOBUSTAVAVRSTAOBUSTAVE"));
            this.labelZADOBUSTAVAVRSTAOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.labelZADOBUSTAVAVRSTAOBUSTAVE, 1, 2);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.labelZADOBUSTAVAVRSTAOBUSTAVE, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.labelZADOBUSTAVAVRSTAOBUSTAVE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelZADOBUSTAVAVRSTAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.labelZADOBUSTAVAVRSTAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.labelZADOBUSTAVAVRSTAOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE.Location = point;
            this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE.Name = "label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE";
            this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE.TabIndex = 1;
            this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE.Tag = "labelZADOBUSTAVANAZIVVRSTAOBUSTAVE";
            this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE.Text = "Naziv vrste obustave:";
            this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE.StyleSetName = "FieldUltraLabel";
            this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE.AutoSize = true;
            this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE.Appearance.ForeColor = Color.Black;
            this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE, 0, 3);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x95, 0x17);
            this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelZADOBUSTAVANAZIVVRSTAOBUSTAVE.Location = point;
            this.labelZADOBUSTAVANAZIVVRSTAOBUSTAVE.Name = "labelZADOBUSTAVANAZIVVRSTAOBUSTAVE";
            this.labelZADOBUSTAVANAZIVVRSTAOBUSTAVE.Tag = "ZADOBUSTAVANAZIVVRSTAOBUSTAVE";
            this.labelZADOBUSTAVANAZIVVRSTAOBUSTAVE.TabIndex = 0;
            this.labelZADOBUSTAVANAZIVVRSTAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.labelZADOBUSTAVANAZIVVRSTAOBUSTAVE.BackColor = Color.Transparent;
            this.labelZADOBUSTAVANAZIVVRSTAOBUSTAVE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKObustava, "ZADOBUSTAVANAZIVVRSTAOBUSTAVE"));
            this.labelZADOBUSTAVANAZIVVRSTAOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.labelZADOBUSTAVANAZIVVRSTAOBUSTAVE, 1, 3);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.labelZADOBUSTAVANAZIVVRSTAOBUSTAVE, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.labelZADOBUSTAVANAZIVVRSTAOBUSTAVE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelZADOBUSTAVANAZIVVRSTAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelZADOBUSTAVANAZIVVRSTAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelZADOBUSTAVANAZIVVRSTAOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBUSTAVAAKTIVNA.Location = point;
            this.label1OBUSTAVAAKTIVNA.Name = "label1OBUSTAVAAKTIVNA";
            this.label1OBUSTAVAAKTIVNA.TabIndex = 1;
            this.label1OBUSTAVAAKTIVNA.Tag = "labelOBUSTAVAAKTIVNA";
            this.label1OBUSTAVAAKTIVNA.Text = "Obračunavaj obustavu:";
            this.label1OBUSTAVAAKTIVNA.StyleSetName = "FieldUltraLabel";
            this.label1OBUSTAVAAKTIVNA.AutoSize = true;
            this.label1OBUSTAVAAKTIVNA.Anchor = AnchorStyles.Left;
            this.label1OBUSTAVAAKTIVNA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBUSTAVAAKTIVNA.Appearance.ForeColor = Color.Black;
            this.label1OBUSTAVAAKTIVNA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.label1OBUSTAVAAKTIVNA, 0, 4);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.label1OBUSTAVAAKTIVNA, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.label1OBUSTAVAAKTIVNA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBUSTAVAAKTIVNA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBUSTAVAAKTIVNA.MinimumSize = size;
            size = new System.Drawing.Size(0x9f, 0x17);
            this.label1OBUSTAVAAKTIVNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkOBUSTAVAAKTIVNA.Location = point;
            this.checkOBUSTAVAAKTIVNA.Name = "checkOBUSTAVAAKTIVNA";
            this.checkOBUSTAVAAKTIVNA.Tag = "OBUSTAVAAKTIVNA";
            this.checkOBUSTAVAAKTIVNA.TabIndex = 0;
            this.checkOBUSTAVAAKTIVNA.Anchor = AnchorStyles.Left;
            this.checkOBUSTAVAAKTIVNA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkOBUSTAVAAKTIVNA.Enabled = true;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.checkOBUSTAVAAKTIVNA, 1, 4);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.checkOBUSTAVAAKTIVNA, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.checkOBUSTAVAAKTIVNA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkOBUSTAVAAKTIVNA.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkOBUSTAVAAKTIVNA.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkOBUSTAVAAKTIVNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADIZNOSOBUSTAVE.Location = point;
            this.label1ZADIZNOSOBUSTAVE.Name = "label1ZADIZNOSOBUSTAVE";
            this.label1ZADIZNOSOBUSTAVE.TabIndex = 1;
            this.label1ZADIZNOSOBUSTAVE.Tag = "labelZADIZNOSOBUSTAVE";
            this.label1ZADIZNOSOBUSTAVE.Text = "Iznos obustave:";
            this.label1ZADIZNOSOBUSTAVE.StyleSetName = "FieldUltraLabel";
            this.label1ZADIZNOSOBUSTAVE.AutoSize = true;
            this.label1ZADIZNOSOBUSTAVE.Anchor = AnchorStyles.Left;
            this.label1ZADIZNOSOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADIZNOSOBUSTAVE.Appearance.ForeColor = Color.Black;
            this.label1ZADIZNOSOBUSTAVE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.label1ZADIZNOSOBUSTAVE, 0, 5);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.label1ZADIZNOSOBUSTAVE, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.label1ZADIZNOSOBUSTAVE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADIZNOSOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADIZNOSOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x72, 0x17);
            this.label1ZADIZNOSOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADIZNOSOBUSTAVE.Location = point;
            this.textZADIZNOSOBUSTAVE.Name = "textZADIZNOSOBUSTAVE";
            this.textZADIZNOSOBUSTAVE.Tag = "ZADIZNOSOBUSTAVE";
            this.textZADIZNOSOBUSTAVE.TabIndex = 0;
            this.textZADIZNOSOBUSTAVE.Anchor = AnchorStyles.Left;
            this.textZADIZNOSOBUSTAVE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADIZNOSOBUSTAVE.ReadOnly = false;
            this.textZADIZNOSOBUSTAVE.PromptChar = ' ';
            this.textZADIZNOSOBUSTAVE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textZADIZNOSOBUSTAVE.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKObustava, "ZADIZNOSOBUSTAVE"));
            this.textZADIZNOSOBUSTAVE.NumericType = NumericType.Double;
            this.textZADIZNOSOBUSTAVE.MaxValue = 79228162514264337593543950335M;
            this.textZADIZNOSOBUSTAVE.MinValue = -79228162514264337593543950335M;
            this.textZADIZNOSOBUSTAVE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformRADNIKObustava.Controls.Add(this.textZADIZNOSOBUSTAVE, 1, 5);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.textZADIZNOSOBUSTAVE, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.textZADIZNOSOBUSTAVE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADIZNOSOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADIZNOSOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADIZNOSOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADPOSTOTAKOBUSTAVE.Location = point;
            this.label1ZADPOSTOTAKOBUSTAVE.Name = "label1ZADPOSTOTAKOBUSTAVE";
            this.label1ZADPOSTOTAKOBUSTAVE.TabIndex = 1;
            this.label1ZADPOSTOTAKOBUSTAVE.Tag = "labelZADPOSTOTAKOBUSTAVE";
            this.label1ZADPOSTOTAKOBUSTAVE.Text = "Postotak obustave:";
            this.label1ZADPOSTOTAKOBUSTAVE.StyleSetName = "FieldUltraLabel";
            this.label1ZADPOSTOTAKOBUSTAVE.AutoSize = true;
            this.label1ZADPOSTOTAKOBUSTAVE.Anchor = AnchorStyles.Left;
            this.label1ZADPOSTOTAKOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADPOSTOTAKOBUSTAVE.Appearance.ForeColor = Color.Black;
            this.label1ZADPOSTOTAKOBUSTAVE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.label1ZADPOSTOTAKOBUSTAVE, 0, 6);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.label1ZADPOSTOTAKOBUSTAVE, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.label1ZADPOSTOTAKOBUSTAVE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADPOSTOTAKOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADPOSTOTAKOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x86, 0x17);
            this.label1ZADPOSTOTAKOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADPOSTOTAKOBUSTAVE.Location = point;
            this.textZADPOSTOTAKOBUSTAVE.Name = "textZADPOSTOTAKOBUSTAVE";
            this.textZADPOSTOTAKOBUSTAVE.Tag = "ZADPOSTOTAKOBUSTAVE";
            this.textZADPOSTOTAKOBUSTAVE.TabIndex = 0;
            this.textZADPOSTOTAKOBUSTAVE.Anchor = AnchorStyles.Left;
            this.textZADPOSTOTAKOBUSTAVE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADPOSTOTAKOBUSTAVE.ReadOnly = false;
            this.textZADPOSTOTAKOBUSTAVE.PromptChar = ' ';
            this.textZADPOSTOTAKOBUSTAVE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textZADPOSTOTAKOBUSTAVE.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKObustava, "ZADPOSTOTAKOBUSTAVE"));
            this.textZADPOSTOTAKOBUSTAVE.NumericType = NumericType.Double;
            this.textZADPOSTOTAKOBUSTAVE.MaxValue = 79228162514264337593543950335M;
            this.textZADPOSTOTAKOBUSTAVE.MinValue = -79228162514264337593543950335M;
            this.textZADPOSTOTAKOBUSTAVE.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformRADNIKObustava.Controls.Add(this.textZADPOSTOTAKOBUSTAVE, 1, 6);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.textZADPOSTOTAKOBUSTAVE, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.textZADPOSTOTAKOBUSTAVE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADPOSTOTAKOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textZADPOSTOTAKOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textZADPOSTOTAKOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADPOSTOTNAODBRUTA.Location = point;
            this.label1ZADPOSTOTNAODBRUTA.Name = "label1ZADPOSTOTNAODBRUTA";
            this.label1ZADPOSTOTNAODBRUTA.TabIndex = 1;
            this.label1ZADPOSTOTNAODBRUTA.Tag = "labelZADPOSTOTNAODBRUTA";
            this.label1ZADPOSTOTNAODBRUTA.Text = "Postotna obs. na bruto iznos:";
            this.label1ZADPOSTOTNAODBRUTA.StyleSetName = "FieldUltraLabel";
            this.label1ZADPOSTOTNAODBRUTA.AutoSize = true;
            this.label1ZADPOSTOTNAODBRUTA.Anchor = AnchorStyles.Left;
            this.label1ZADPOSTOTNAODBRUTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADPOSTOTNAODBRUTA.Appearance.ForeColor = Color.Black;
            this.label1ZADPOSTOTNAODBRUTA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.label1ZADPOSTOTNAODBRUTA, 0, 7);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.label1ZADPOSTOTNAODBRUTA, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.label1ZADPOSTOTNAODBRUTA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADPOSTOTNAODBRUTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADPOSTOTNAODBRUTA.MinimumSize = size;
            size = new System.Drawing.Size(0xc4, 0x17);
            this.label1ZADPOSTOTNAODBRUTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkZADPOSTOTNAODBRUTA.Location = point;
            this.checkZADPOSTOTNAODBRUTA.Name = "checkZADPOSTOTNAODBRUTA";
            this.checkZADPOSTOTNAODBRUTA.Tag = "ZADPOSTOTNAODBRUTA";
            this.checkZADPOSTOTNAODBRUTA.TabIndex = 0;
            this.checkZADPOSTOTNAODBRUTA.Anchor = AnchorStyles.Left;
            this.checkZADPOSTOTNAODBRUTA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkZADPOSTOTNAODBRUTA.Enabled = true;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.checkZADPOSTOTNAODBRUTA, 1, 7);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.checkZADPOSTOTNAODBRUTA, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.checkZADPOSTOTNAODBRUTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkZADPOSTOTNAODBRUTA.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkZADPOSTOTNAODBRUTA.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkZADPOSTOTNAODBRUTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADSALDOKASA.Location = point;
            this.label1ZADSALDOKASA.Name = "label1ZADSALDOKASA";
            this.label1ZADSALDOKASA.TabIndex = 1;
            this.label1ZADSALDOKASA.Tag = "labelZADSALDOKASA";
            this.label1ZADSALDOKASA.Text = "Saldo kase iz drugog programa:";
            this.label1ZADSALDOKASA.StyleSetName = "FieldUltraLabel";
            this.label1ZADSALDOKASA.AutoSize = true;
            this.label1ZADSALDOKASA.Anchor = AnchorStyles.Left;
            this.label1ZADSALDOKASA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADSALDOKASA.Appearance.ForeColor = Color.Black;
            this.label1ZADSALDOKASA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.label1ZADSALDOKASA, 0, 8);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.label1ZADSALDOKASA, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.label1ZADSALDOKASA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADSALDOKASA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADSALDOKASA.MinimumSize = size;
            size = new System.Drawing.Size(0xd3, 0x17);
            this.label1ZADSALDOKASA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADSALDOKASA.Location = point;
            this.textZADSALDOKASA.Name = "textZADSALDOKASA";
            this.textZADSALDOKASA.Tag = "ZADSALDOKASA";
            this.textZADSALDOKASA.TabIndex = 0;
            this.textZADSALDOKASA.Anchor = AnchorStyles.Left;
            this.textZADSALDOKASA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADSALDOKASA.ReadOnly = false;
            this.textZADSALDOKASA.PromptChar = ' ';
            this.textZADSALDOKASA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textZADSALDOKASA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKObustava, "ZADSALDOKASA"));
            this.textZADSALDOKASA.NumericType = NumericType.Double;
            this.textZADSALDOKASA.MaxValue = 79228162514264337593543950335M;
            this.textZADSALDOKASA.MinValue = -79228162514264337593543950335M;
            this.textZADSALDOKASA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformRADNIKObustava.Controls.Add(this.textZADSALDOKASA, 1, 8);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.textZADSALDOKASA, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.textZADSALDOKASA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADSALDOKASA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADSALDOKASA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADSALDOKASA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADISPLACENOKASA.Location = point;
            this.label1ZADISPLACENOKASA.Name = "label1ZADISPLACENOKASA";
            this.label1ZADISPLACENOKASA.TabIndex = 1;
            this.label1ZADISPLACENOKASA.Tag = "labelZADISPLACENOKASA";
            this.label1ZADISPLACENOKASA.Text = "Isplaćeni iz kase:";
            this.label1ZADISPLACENOKASA.StyleSetName = "FieldUltraLabel";
            this.label1ZADISPLACENOKASA.AutoSize = true;
            this.label1ZADISPLACENOKASA.Anchor = AnchorStyles.Left;
            this.label1ZADISPLACENOKASA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADISPLACENOKASA.Appearance.ForeColor = Color.Black;
            this.label1ZADISPLACENOKASA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.label1ZADISPLACENOKASA, 0, 9);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.label1ZADISPLACENOKASA, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.label1ZADISPLACENOKASA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADISPLACENOKASA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADISPLACENOKASA.MinimumSize = size;
            size = new System.Drawing.Size(0x7a, 0x17);
            this.label1ZADISPLACENOKASA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADISPLACENOKASA.Location = point;
            this.textZADISPLACENOKASA.Name = "textZADISPLACENOKASA";
            this.textZADISPLACENOKASA.Tag = "ZADISPLACENOKASA";
            this.textZADISPLACENOKASA.TabIndex = 0;
            this.textZADISPLACENOKASA.Anchor = AnchorStyles.Left;
            this.textZADISPLACENOKASA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADISPLACENOKASA.ReadOnly = false;
            this.textZADISPLACENOKASA.PromptChar = ' ';
            this.textZADISPLACENOKASA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textZADISPLACENOKASA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKObustava, "ZADISPLACENOKASA"));
            this.textZADISPLACENOKASA.NumericType = NumericType.Double;
            this.textZADISPLACENOKASA.MaxValue = 79228162514264337593543950335M;
            this.textZADISPLACENOKASA.MinValue = -79228162514264337593543950335M;
            this.textZADISPLACENOKASA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformRADNIKObustava.Controls.Add(this.textZADISPLACENOKASA, 1, 9);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.textZADISPLACENOKASA, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.textZADISPLACENOKASA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADISPLACENOKASA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADISPLACENOKASA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADISPLACENOKASA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OTPLACENIIZNOS.Location = point;
            this.label1OTPLACENIIZNOS.Name = "label1OTPLACENIIZNOS";
            this.label1OTPLACENIIZNOS.TabIndex = 1;
            this.label1OTPLACENIIZNOS.Tag = "labelOTPLACENIIZNOS";
            this.label1OTPLACENIIZNOS.Text = "Ukupno otplaćeno (iznos):";
            this.label1OTPLACENIIZNOS.StyleSetName = "FieldUltraLabel";
            this.label1OTPLACENIIZNOS.AutoSize = true;
            this.label1OTPLACENIIZNOS.Anchor = AnchorStyles.Left;
            this.label1OTPLACENIIZNOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1OTPLACENIIZNOS.Appearance.ForeColor = Color.Black;
            this.label1OTPLACENIIZNOS.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.label1OTPLACENIIZNOS, 0, 10);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.label1OTPLACENIIZNOS, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.label1OTPLACENIIZNOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OTPLACENIIZNOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OTPLACENIIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0xb2, 0x17);
            this.label1OTPLACENIIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelOTPLACENIIZNOS.Location = point;
            this.labelOTPLACENIIZNOS.Name = "labelOTPLACENIIZNOS";
            this.labelOTPLACENIIZNOS.Tag = "OTPLACENIIZNOS";
            this.labelOTPLACENIIZNOS.TabIndex = 0;
            this.labelOTPLACENIIZNOS.Anchor = AnchorStyles.Left;
            this.labelOTPLACENIIZNOS.BackColor = Color.Transparent;
            this.labelOTPLACENIIZNOS.Appearance.TextHAlign = HAlign.Left;
            this.labelOTPLACENIIZNOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.labelOTPLACENIIZNOS, 1, 10);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.labelOTPLACENIIZNOS, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.labelOTPLACENIIZNOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelOTPLACENIIZNOS.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelOTPLACENIIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelOTPLACENIIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OTPLACENIBROJRATA.Location = point;
            this.label1OTPLACENIBROJRATA.Name = "label1OTPLACENIBROJRATA";
            this.label1OTPLACENIBROJRATA.TabIndex = 1;
            this.label1OTPLACENIBROJRATA.Tag = "labelOTPLACENIBROJRATA";
            this.label1OTPLACENIBROJRATA.Text = "Ukupno otplaćeno (rata):";
            this.label1OTPLACENIBROJRATA.StyleSetName = "FieldUltraLabel";
            this.label1OTPLACENIBROJRATA.AutoSize = true;
            this.label1OTPLACENIBROJRATA.Anchor = AnchorStyles.Left;
            this.label1OTPLACENIBROJRATA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OTPLACENIBROJRATA.Appearance.ForeColor = Color.Black;
            this.label1OTPLACENIBROJRATA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.label1OTPLACENIBROJRATA, 0, 11);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.label1OTPLACENIBROJRATA, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.label1OTPLACENIBROJRATA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OTPLACENIBROJRATA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OTPLACENIBROJRATA.MinimumSize = size;
            size = new System.Drawing.Size(0xac, 0x17);
            this.label1OTPLACENIBROJRATA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelOTPLACENIBROJRATA.Location = point;
            this.labelOTPLACENIBROJRATA.Name = "labelOTPLACENIBROJRATA";
            this.labelOTPLACENIBROJRATA.Tag = "OTPLACENIBROJRATA";
            this.labelOTPLACENIBROJRATA.TabIndex = 0;
            this.labelOTPLACENIBROJRATA.Anchor = AnchorStyles.Left;
            this.labelOTPLACENIBROJRATA.BackColor = Color.Transparent;
            this.labelOTPLACENIBROJRATA.Appearance.TextHAlign = HAlign.Left;
            this.labelOTPLACENIBROJRATA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKObustava.Controls.Add(this.labelOTPLACENIBROJRATA, 1, 11);
            this.layoutManagerformRADNIKObustava.SetColumnSpan(this.labelOTPLACENIBROJRATA, 1);
            this.layoutManagerformRADNIKObustava.SetRowSpan(this.labelOTPLACENIBROJRATA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelOTPLACENIBROJRATA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelOTPLACENIBROJRATA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelOTPLACENIBROJRATA.Size = size;
            this.Controls.Add(this.layoutManagerformRADNIKObustava);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRADNIKObustava;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RADNIKFormRADNIKObustavaUserControl";
            this.Text = " Obustave";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RADNIKFormUserControl_Load);
            this.layoutManagerformRADNIKObustava.ResumeLayout(false);
            this.layoutManagerformRADNIKObustava.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRADNIKObustava).EndInit();
            ((ISupportInitialize) this.textZADOBUSTAVAIDOBUSTAVA).EndInit();
            ((ISupportInitialize) this.textZADIZNOSOBUSTAVE).EndInit();
            ((ISupportInitialize) this.textZADPOSTOTAKOBUSTAVE).EndInit();
            ((ISupportInitialize) this.textZADSALDOKASA).EndInit();
            ((ISupportInitialize) this.textZADISPLACENOKASA).EndInit();
            this.dsRADNIKDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RADNIKController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIKObustava, this.RADNIKController.WorkItem, this))
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
            this.label1ZADOBUSTAVAIDOBUSTAVA.Text = StringResources.RADNIKZADOBUSTAVAIDOBUSTAVADescription;
            this.label1ZADOBUSTAVANAZIVOBUSTAVA.Text = StringResources.RADNIKZADOBUSTAVANAZIVOBUSTAVADescription;
            this.label1ZADOBUSTAVAVRSTAOBUSTAVE.Text = StringResources.RADNIKZADOBUSTAVAVRSTAOBUSTAVEDescription;
            this.label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE.Text = StringResources.RADNIKZADOBUSTAVANAZIVVRSTAOBUSTAVEDescription;
            this.label1OBUSTAVAAKTIVNA.Text = StringResources.RADNIKOBUSTAVAAKTIVNADescription;
            this.label1ZADIZNOSOBUSTAVE.Text = StringResources.RADNIKZADIZNOSOBUSTAVEDescription;
            this.label1ZADPOSTOTAKOBUSTAVE.Text = StringResources.RADNIKZADPOSTOTAKOBUSTAVEDescription;
            this.label1ZADPOSTOTNAODBRUTA.Text = StringResources.RADNIKZADPOSTOTNAODBRUTADescription;
            this.label1ZADSALDOKASA.Text = StringResources.RADNIKZADSALDOKASADescription;
            this.label1ZADISPLACENOKASA.Text = StringResources.RADNIKZADISPLACENOKASADescription;
            this.label1OTPLACENIIZNOS.Text = StringResources.RADNIKOTPLACENIIZNOSDescription;
            this.label1OTPLACENIBROJRATA.Text = StringResources.RADNIKOTPLACENIBROJRATADescription;
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
            this.Text = StringResources.RADNIKRADNIKObustavaLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIKObustava|RADNIKObustava"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIKObustava, "RADNIKObustava|RADNIKObustava");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("RADNIKObustavaSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetFocusInFirstField()
        {
            this.textZADOBUSTAVAIDOBUSTAVA.Focus();
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

        private void UpdateValuesOBUSTAVAZADOBUSTAVAIDOBUSTAVA(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceRADNIKObustava.Current).Row["ZADOBUSTAVAIDOBUSTAVA"] = RuntimeHelpers.GetObjectValue(result["IDOBUSTAVA"]);
                ((DataRowView) this.bindingSourceRADNIKObustava.Current).Row["ZADOBUSTAVANAZIVOBUSTAVA"] = RuntimeHelpers.GetObjectValue(result["NAZIVOBUSTAVA"]);
                ((DataRowView) this.bindingSourceRADNIKObustava.Current).Row["ZADOBUSTAVAZRNOBUSTAVA"] = RuntimeHelpers.GetObjectValue(result["ZRNOBUSTAVA"]);
                ((DataRowView) this.bindingSourceRADNIKObustava.Current).Row["ZADOBUSTAVAVBDIOBUSTAVA"] = RuntimeHelpers.GetObjectValue(result["VBDIOBUSTAVA"]);
                ((DataRowView) this.bindingSourceRADNIKObustava.Current).Row["ZADOBUSTAVAVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(result["VRSTAOBUSTAVE"]);
                ((DataRowView) this.bindingSourceRADNIKObustava.Current).Row["ZADOBUSTAVANAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(result["NAZIVVRSTAOBUSTAVE"]);
                this.bindingSourceRADNIKObustava.ResetCurrentItem();
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

        protected virtual UltraCheckEditor checkOBUSTAVAAKTIVNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkOBUSTAVAAKTIVNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkOBUSTAVAAKTIVNA = value;
            }
        }

        protected virtual UltraCheckEditor checkZADPOSTOTNAODBRUTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkZADPOSTOTNAODBRUTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkZADPOSTOTNAODBRUTA = value;
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

        protected virtual UltraLabel label1OBUSTAVAAKTIVNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBUSTAVAAKTIVNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBUSTAVAAKTIVNA = value;
            }
        }

        protected virtual UltraLabel label1OTPLACENIBROJRATA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OTPLACENIBROJRATA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OTPLACENIBROJRATA = value;
            }
        }

        protected virtual UltraLabel label1OTPLACENIIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OTPLACENIIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OTPLACENIIZNOS = value;
            }
        }

        protected virtual UltraLabel label1ZADISPLACENOKASA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADISPLACENOKASA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADISPLACENOKASA = value;
            }
        }

        protected virtual UltraLabel label1ZADIZNOSOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADIZNOSOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADIZNOSOBUSTAVE = value;
            }
        }

        protected virtual UltraLabel label1ZADOBUSTAVAIDOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADOBUSTAVAIDOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADOBUSTAVAIDOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1ZADOBUSTAVANAZIVOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADOBUSTAVANAZIVOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADOBUSTAVANAZIVOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADOBUSTAVANAZIVVRSTAOBUSTAVE = value;
            }
        }

        protected virtual UltraLabel label1ZADOBUSTAVAVRSTAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADOBUSTAVAVRSTAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADOBUSTAVAVRSTAOBUSTAVE = value;
            }
        }

        protected virtual UltraLabel label1ZADPOSTOTAKOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADPOSTOTAKOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADPOSTOTAKOBUSTAVE = value;
            }
        }

        protected virtual UltraLabel label1ZADPOSTOTNAODBRUTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADPOSTOTNAODBRUTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADPOSTOTNAODBRUTA = value;
            }
        }

        protected virtual UltraLabel label1ZADSALDOKASA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADSALDOKASA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADSALDOKASA = value;
            }
        }

        protected virtual UltraLabel labelOTPLACENIBROJRATA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelOTPLACENIBROJRATA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelOTPLACENIBROJRATA = value;
            }
        }

        protected virtual UltraLabel labelOTPLACENIIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelOTPLACENIIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelOTPLACENIIZNOS = value;
            }
        }

        protected virtual UltraLabel labelZADOBUSTAVANAZIVOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZADOBUSTAVANAZIVOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZADOBUSTAVANAZIVOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel labelZADOBUSTAVANAZIVVRSTAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZADOBUSTAVANAZIVVRSTAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZADOBUSTAVANAZIVVRSTAOBUSTAVE = value;
            }
        }

        protected virtual UltraLabel labelZADOBUSTAVAVRSTAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZADOBUSTAVAVRSTAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZADOBUSTAVAVRSTAOBUSTAVE = value;
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

        protected virtual UltraNumericEditor textZADISPLACENOKASA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADISPLACENOKASA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADISPLACENOKASA = value;
            }
        }

        protected virtual UltraNumericEditor textZADIZNOSOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADIZNOSOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADIZNOSOBUSTAVE = value;
            }
        }

        protected virtual UltraNumericEditor textZADOBUSTAVAIDOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADOBUSTAVAIDOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADOBUSTAVAIDOBUSTAVA = value;
            }
        }

        protected virtual UltraNumericEditor textZADPOSTOTAKOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADPOSTOTAKOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADPOSTOTAKOBUSTAVE = value;
            }
        }

        protected virtual UltraNumericEditor textZADSALDOKASA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADSALDOKASA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADSALDOKASA = value;
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

