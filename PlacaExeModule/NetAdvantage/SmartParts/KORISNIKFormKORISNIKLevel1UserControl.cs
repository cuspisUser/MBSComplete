namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Win;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.EventBroker;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using NetAdvantage.Controls;
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
    public class KORISNIKFormKORISNIKLevel1UserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkPOREZIPRIREZZAJEDNICKI")]
        private UltraCheckEditor _checkPOREZIPRIREZZAJEDNICKI;
        [AccessedThroughProperty("checkPOZIVIZADUZENJA")]
        private UltraCheckEditor _checkPOZIVIZADUZENJA;
        [AccessedThroughProperty("comboSIFRAIZVORA")]
        private IZVORDOKUMENTAComboBox _comboSIFRAIZVORA;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDZIRO")]
        private UltraLabel _label1IDZIRO;
        [AccessedThroughProperty("label1MJESTOZIRO")]
        private UltraLabel _label1MJESTOZIRO;
        [AccessedThroughProperty("label1NAZIVIZVORA")]
        private UltraLabel _label1NAZIVIZVORA;
        [AccessedThroughProperty("label1NAZIVZIRO")]
        private UltraLabel _label1NAZIVZIRO;
        [AccessedThroughProperty("label1POREZIPRIREZZAJEDNICKI")]
        private UltraLabel _label1POREZIPRIREZZAJEDNICKI;
        [AccessedThroughProperty("label1POZIVIZADUZENJA")]
        private UltraLabel _label1POZIVIZADUZENJA;
        [AccessedThroughProperty("label1SIFRAIZVORA")]
        private UltraLabel _label1SIFRAIZVORA;
        [AccessedThroughProperty("label1ULICAZIRO")]
        private UltraLabel _label1ULICAZIRO;
        [AccessedThroughProperty("label1VBDIKORISNIK")]
        private UltraLabel _label1VBDIKORISNIK;
        [AccessedThroughProperty("label1ZIROKORISNIK")]
        private UltraLabel _label1ZIROKORISNIK;
        [AccessedThroughProperty("labelNAZIVIZVORA")]
        private UltraLabel _labelNAZIVIZVORA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDZIRO")]
        private UltraNumericEditor _textIDZIRO;
        [AccessedThroughProperty("textMJESTOZIRO")]
        private UltraTextEditor _textMJESTOZIRO;
        [AccessedThroughProperty("textNAZIVZIRO")]
        private UltraTextEditor _textNAZIVZIRO;
        [AccessedThroughProperty("textULICAZIRO")]
        private UltraTextEditor _textULICAZIRO;
        [AccessedThroughProperty("textVBDIKORISNIK")]
        private UltraTextEditor _textVBDIKORISNIK;
        [AccessedThroughProperty("textZIROKORISNIK")]
        private UltraTextEditor _textZIROKORISNIK;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceKORISNIKLevel1;
        private IContainer components = null;
        private KORISNIKDataSet dsKORISNIKDataSet1;
        protected TableLayoutPanel layoutManagerformKORISNIKLevel1;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private KORISNIKDataSet.KORISNIKLevel1Row m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "KORISNIKLevel1";
        private string m_FrameworkDescription = StringResources.KORISNIKDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public KORISNIKFormKORISNIKLevel1UserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("KORISNIKLevel1AddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("KORISNIKLevel1AddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (KORISNIKDataSet.KORISNIKLevel1Row) ((DataRowView) this.bindingSourceKORISNIKLevel1.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }


        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsKORISNIKDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceKORISNIKLevel1.DataSource = this.KORISNIKController.DataSet;
            this.dsKORISNIKDataSet1 = this.KORISNIKController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/IZVORDOKUMENTA", Thread=ThreadOption.UserInterface)]
        public void comboSIFRAIZVORA_Add(object sender, ComponentEventArgs e)
        {
            this.comboSIFRAIZVORA.Fill();
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
            this.dsKORISNIKDataSet1 = (KORISNIKDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceKORISNIKLevel1.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsKORISNIKDataSet1.Tables["KORISNIKLevel1"]);
            this.bindingSourceKORISNIKLevel1.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "KORISNIK", this.m_Mode, this.dsKORISNIKDataSet1, this.dsKORISNIKDataSet1.KORISNIKLevel1.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("CheckState", this.bindingSourceKORISNIKLevel1, "POREZIPRIREZZAJEDNICKI", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkPOREZIPRIREZZAJEDNICKI.DataBindings["CheckState"] != null)
            {
                this.checkPOREZIPRIREZZAJEDNICKI.DataBindings.Remove(this.checkPOREZIPRIREZZAJEDNICKI.DataBindings["CheckState"]);
            }
            this.checkPOREZIPRIREZZAJEDNICKI.DataBindings.Add(binding);
            Binding binding2 = new Binding("CheckState", this.bindingSourceKORISNIKLevel1, "POZIVIZADUZENJA", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding2.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkPOZIVIZADUZENJA.DataBindings["CheckState"] != null)
            {
                this.checkPOZIVIZADUZENJA.DataBindings.Remove(this.checkPOZIVIZADUZENJA.DataBindings["CheckState"]);
            }
            this.checkPOZIVIZADUZENJA.DataBindings.Add(binding2);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (KORISNIKDataSet.KORISNIKLevel1Row) ((DataRowView) this.bindingSourceKORISNIKLevel1.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (KORISNIKDataSet.KORISNIKLevel1Row) ((DataRowView) this.bindingSourceKORISNIKLevel1.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(KORISNIKFormKORISNIKLevel1UserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceKORISNIKLevel1 = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceKORISNIKLevel1).BeginInit();
            this.layoutManagerformKORISNIKLevel1 = new TableLayoutPanel();
            this.layoutManagerformKORISNIKLevel1.SuspendLayout();
            this.layoutManagerformKORISNIKLevel1.AutoSize = true;
            this.layoutManagerformKORISNIKLevel1.Dock = DockStyle.Fill;
            this.layoutManagerformKORISNIKLevel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformKORISNIKLevel1.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformKORISNIKLevel1.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformKORISNIKLevel1.Size = size;
            this.layoutManagerformKORISNIKLevel1.ColumnCount = 2;
            this.layoutManagerformKORISNIKLevel1.RowCount = 11;
            this.layoutManagerformKORISNIKLevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformKORISNIKLevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformKORISNIKLevel1.RowStyles.Add(new RowStyle());
            this.layoutManagerformKORISNIKLevel1.RowStyles.Add(new RowStyle());
            this.layoutManagerformKORISNIKLevel1.RowStyles.Add(new RowStyle());
            this.layoutManagerformKORISNIKLevel1.RowStyles.Add(new RowStyle());
            this.layoutManagerformKORISNIKLevel1.RowStyles.Add(new RowStyle());
            this.layoutManagerformKORISNIKLevel1.RowStyles.Add(new RowStyle());
            this.layoutManagerformKORISNIKLevel1.RowStyles.Add(new RowStyle());
            this.layoutManagerformKORISNIKLevel1.RowStyles.Add(new RowStyle());
            this.layoutManagerformKORISNIKLevel1.RowStyles.Add(new RowStyle());
            this.layoutManagerformKORISNIKLevel1.RowStyles.Add(new RowStyle());
            this.layoutManagerformKORISNIKLevel1.RowStyles.Add(new RowStyle());
            this.label1IDZIRO = new UltraLabel();
            this.textIDZIRO = new UltraNumericEditor();
            this.label1NAZIVZIRO = new UltraLabel();
            this.textNAZIVZIRO = new UltraTextEditor();
            this.label1ULICAZIRO = new UltraLabel();
            this.textULICAZIRO = new UltraTextEditor();
            this.label1MJESTOZIRO = new UltraLabel();
            this.textMJESTOZIRO = new UltraTextEditor();
            this.label1VBDIKORISNIK = new UltraLabel();
            this.textVBDIKORISNIK = new UltraTextEditor();
            this.label1ZIROKORISNIK = new UltraLabel();
            this.textZIROKORISNIK = new UltraTextEditor();
            this.label1SIFRAIZVORA = new UltraLabel();
            this.comboSIFRAIZVORA = new IZVORDOKUMENTAComboBox();
            this.label1NAZIVIZVORA = new UltraLabel();
            this.labelNAZIVIZVORA = new UltraLabel();
            this.label1POREZIPRIREZZAJEDNICKI = new UltraLabel();
            this.checkPOREZIPRIREZZAJEDNICKI = new UltraCheckEditor();
            this.label1POZIVIZADUZENJA = new UltraLabel();
            this.checkPOZIVIZADUZENJA = new UltraCheckEditor();
            ((ISupportInitialize) this.textIDZIRO).BeginInit();
            ((ISupportInitialize) this.textNAZIVZIRO).BeginInit();
            ((ISupportInitialize) this.textULICAZIRO).BeginInit();
            ((ISupportInitialize) this.textMJESTOZIRO).BeginInit();
            ((ISupportInitialize) this.textVBDIKORISNIK).BeginInit();
            ((ISupportInitialize) this.textZIROKORISNIK).BeginInit();
            this.dsKORISNIKDataSet1 = new KORISNIKDataSet();
            this.dsKORISNIKDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsKORISNIKDataSet1.DataSetName = "dsKORISNIK";
            this.dsKORISNIKDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceKORISNIKLevel1.DataSource = this.dsKORISNIKDataSet1;
            this.bindingSourceKORISNIKLevel1.DataMember = "KORISNIKLevel1";
            ((ISupportInitialize) this.bindingSourceKORISNIKLevel1).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDZIRO.Location = point;
            this.label1IDZIRO.Name = "label1IDZIRO";
            this.label1IDZIRO.TabIndex = 1;
            this.label1IDZIRO.Tag = "labelIDZIRO";
            this.label1IDZIRO.Text = "Šifra:";
            this.label1IDZIRO.StyleSetName = "FieldUltraLabel";
            this.label1IDZIRO.AutoSize = true;
            this.label1IDZIRO.Anchor = AnchorStyles.Left;
            this.label1IDZIRO.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDZIRO.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDZIRO.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDZIRO.ImageSize = size;
            this.label1IDZIRO.Appearance.ForeColor = Color.Black;
            this.label1IDZIRO.BackColor = Color.Transparent;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.label1IDZIRO, 0, 0);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.label1IDZIRO, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.label1IDZIRO, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDZIRO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDZIRO.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDZIRO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDZIRO.Location = point;
            this.textIDZIRO.Name = "textIDZIRO";
            this.textIDZIRO.Tag = "IDZIRO";
            this.textIDZIRO.TabIndex = 0;
            this.textIDZIRO.Anchor = AnchorStyles.Left;
            this.textIDZIRO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDZIRO.ReadOnly = false;
            this.textIDZIRO.PromptChar = ' ';
            this.textIDZIRO.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDZIRO.DataBindings.Add(new Binding("Value", this.bindingSourceKORISNIKLevel1, "IDZIRO"));
            this.textIDZIRO.NumericType = NumericType.Integer;
            this.textIDZIRO.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.textIDZIRO, 1, 0);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.textIDZIRO, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.textIDZIRO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDZIRO.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDZIRO.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDZIRO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVZIRO.Location = point;
            this.label1NAZIVZIRO.Name = "label1NAZIVZIRO";
            this.label1NAZIVZIRO.TabIndex = 1;
            this.label1NAZIVZIRO.Tag = "labelNAZIVZIRO";
            this.label1NAZIVZIRO.Text = "Platitelj (1) na virmanu:";
            this.label1NAZIVZIRO.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVZIRO.AutoSize = true;
            this.label1NAZIVZIRO.Anchor = AnchorStyles.Left;
            this.label1NAZIVZIRO.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVZIRO.Appearance.ForeColor = Color.Black;
            this.label1NAZIVZIRO.BackColor = Color.Transparent;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.label1NAZIVZIRO, 0, 1);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.label1NAZIVZIRO, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.label1NAZIVZIRO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVZIRO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVZIRO.MinimumSize = size;
            size = new System.Drawing.Size(0xa4, 0x17);
            this.label1NAZIVZIRO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVZIRO.Location = point;
            this.textNAZIVZIRO.Name = "textNAZIVZIRO";
            this.textNAZIVZIRO.Tag = "NAZIVZIRO";
            this.textNAZIVZIRO.TabIndex = 0;
            this.textNAZIVZIRO.Anchor = AnchorStyles.Left;
            this.textNAZIVZIRO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVZIRO.ReadOnly = false;
            this.textNAZIVZIRO.DataBindings.Add(new Binding("Text", this.bindingSourceKORISNIKLevel1, "NAZIVZIRO"));
            this.textNAZIVZIRO.MaxLength = 20;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.textNAZIVZIRO, 1, 1);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.textNAZIVZIRO, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.textNAZIVZIRO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVZIRO.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textNAZIVZIRO.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textNAZIVZIRO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ULICAZIRO.Location = point;
            this.label1ULICAZIRO.Name = "label1ULICAZIRO";
            this.label1ULICAZIRO.TabIndex = 1;
            this.label1ULICAZIRO.Tag = "labelULICAZIRO";
            this.label1ULICAZIRO.Text = "Platitelj (2) na virmanu:";
            this.label1ULICAZIRO.StyleSetName = "FieldUltraLabel";
            this.label1ULICAZIRO.AutoSize = true;
            this.label1ULICAZIRO.Anchor = AnchorStyles.Left;
            this.label1ULICAZIRO.Appearance.TextVAlign = VAlign.Middle;
            this.label1ULICAZIRO.Appearance.ForeColor = Color.Black;
            this.label1ULICAZIRO.BackColor = Color.Transparent;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.label1ULICAZIRO, 0, 2);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.label1ULICAZIRO, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.label1ULICAZIRO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ULICAZIRO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ULICAZIRO.MinimumSize = size;
            size = new System.Drawing.Size(0xa4, 0x17);
            this.label1ULICAZIRO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textULICAZIRO.Location = point;
            this.textULICAZIRO.Name = "textULICAZIRO";
            this.textULICAZIRO.Tag = "ULICAZIRO";
            this.textULICAZIRO.TabIndex = 0;
            this.textULICAZIRO.Anchor = AnchorStyles.Left;
            this.textULICAZIRO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textULICAZIRO.ReadOnly = false;
            this.textULICAZIRO.DataBindings.Add(new Binding("Text", this.bindingSourceKORISNIKLevel1, "ULICAZIRO"));
            this.textULICAZIRO.MaxLength = 20;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.textULICAZIRO, 1, 2);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.textULICAZIRO, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.textULICAZIRO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textULICAZIRO.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textULICAZIRO.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textULICAZIRO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MJESTOZIRO.Location = point;
            this.label1MJESTOZIRO.Name = "label1MJESTOZIRO";
            this.label1MJESTOZIRO.TabIndex = 1;
            this.label1MJESTOZIRO.Tag = "labelMJESTOZIRO";
            this.label1MJESTOZIRO.Text = "Platitelj (3) na virmanu:";
            this.label1MJESTOZIRO.StyleSetName = "FieldUltraLabel";
            this.label1MJESTOZIRO.AutoSize = true;
            this.label1MJESTOZIRO.Anchor = AnchorStyles.Left;
            this.label1MJESTOZIRO.Appearance.TextVAlign = VAlign.Middle;
            this.label1MJESTOZIRO.Appearance.ForeColor = Color.Black;
            this.label1MJESTOZIRO.BackColor = Color.Transparent;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.label1MJESTOZIRO, 0, 3);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.label1MJESTOZIRO, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.label1MJESTOZIRO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MJESTOZIRO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MJESTOZIRO.MinimumSize = size;
            size = new System.Drawing.Size(0xa4, 0x17);
            this.label1MJESTOZIRO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMJESTOZIRO.Location = point;
            this.textMJESTOZIRO.Name = "textMJESTOZIRO";
            this.textMJESTOZIRO.Tag = "MJESTOZIRO";
            this.textMJESTOZIRO.TabIndex = 0;
            this.textMJESTOZIRO.Anchor = AnchorStyles.Left;
            this.textMJESTOZIRO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMJESTOZIRO.ReadOnly = false;
            this.textMJESTOZIRO.DataBindings.Add(new Binding("Text", this.bindingSourceKORISNIKLevel1, "MJESTOZIRO"));
            this.textMJESTOZIRO.MaxLength = 20;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.textMJESTOZIRO, 1, 3);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.textMJESTOZIRO, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.textMJESTOZIRO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMJESTOZIRO.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textMJESTOZIRO.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textMJESTOZIRO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VBDIKORISNIK.Location = point;
            this.label1VBDIKORISNIK.Name = "label1VBDIKORISNIK";
            this.label1VBDIKORISNIK.TabIndex = 1;
            this.label1VBDIKORISNIK.Tag = "labelVBDIKORISNIK";
            this.label1VBDIKORISNIK.Text = "VBDI Žrn-a:";
            this.label1VBDIKORISNIK.StyleSetName = "FieldUltraLabel";
            this.label1VBDIKORISNIK.AutoSize = true;
            this.label1VBDIKORISNIK.Anchor = AnchorStyles.Left;
            this.label1VBDIKORISNIK.Appearance.TextVAlign = VAlign.Middle;
            this.label1VBDIKORISNIK.Appearance.ForeColor = Color.Black;
            this.label1VBDIKORISNIK.BackColor = Color.Transparent;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.label1VBDIKORISNIK, 0, 4);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.label1VBDIKORISNIK, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.label1VBDIKORISNIK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VBDIKORISNIK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VBDIKORISNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x58, 0x17);
            this.label1VBDIKORISNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVBDIKORISNIK.Location = point;
            this.textVBDIKORISNIK.Name = "textVBDIKORISNIK";
            this.textVBDIKORISNIK.Tag = "VBDIKORISNIK";
            this.textVBDIKORISNIK.TabIndex = 0;
            this.textVBDIKORISNIK.Anchor = AnchorStyles.Left;
            this.textVBDIKORISNIK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVBDIKORISNIK.ReadOnly = false;
            this.textVBDIKORISNIK.DataBindings.Add(new Binding("Text", this.bindingSourceKORISNIKLevel1, "VBDIKORISNIK"));
            this.textVBDIKORISNIK.MaxLength = 7;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.textVBDIKORISNIK, 1, 4);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.textVBDIKORISNIK, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.textVBDIKORISNIK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVBDIKORISNIK.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textVBDIKORISNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textVBDIKORISNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZIROKORISNIK.Location = point;
            this.label1ZIROKORISNIK.Name = "label1ZIROKORISNIK";
            this.label1ZIROKORISNIK.TabIndex = 1;
            this.label1ZIROKORISNIK.Tag = "labelZIROKORISNIK";
            this.label1ZIROKORISNIK.Text = "Žrn:";
            this.label1ZIROKORISNIK.StyleSetName = "FieldUltraLabel";
            this.label1ZIROKORISNIK.AutoSize = true;
            this.label1ZIROKORISNIK.Anchor = AnchorStyles.Left;
            this.label1ZIROKORISNIK.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZIROKORISNIK.Appearance.ForeColor = Color.Black;
            this.label1ZIROKORISNIK.BackColor = Color.Transparent;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.label1ZIROKORISNIK, 0, 5);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.label1ZIROKORISNIK, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.label1ZIROKORISNIK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZIROKORISNIK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZIROKORISNIK.MinimumSize = size;
            size = new System.Drawing.Size(40, 0x17);
            this.label1ZIROKORISNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZIROKORISNIK.Location = point;
            this.textZIROKORISNIK.Name = "textZIROKORISNIK";
            this.textZIROKORISNIK.Tag = "ZIROKORISNIK";
            this.textZIROKORISNIK.TabIndex = 0;
            this.textZIROKORISNIK.Anchor = AnchorStyles.Left;
            this.textZIROKORISNIK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZIROKORISNIK.ReadOnly = false;
            this.textZIROKORISNIK.DataBindings.Add(new Binding("Text", this.bindingSourceKORISNIKLevel1, "ZIROKORISNIK"));
            this.textZIROKORISNIK.MaxLength = 10;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.textZIROKORISNIK, 1, 5);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.textZIROKORISNIK, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.textZIROKORISNIK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZIROKORISNIK.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZIROKORISNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZIROKORISNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SIFRAIZVORA.Location = point;
            this.label1SIFRAIZVORA.Name = "label1SIFRAIZVORA";
            this.label1SIFRAIZVORA.TabIndex = 1;
            this.label1SIFRAIZVORA.Tag = "labelSIFRAIZVORA";
            this.label1SIFRAIZVORA.Text = "Izvor dok:";
            this.label1SIFRAIZVORA.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAIZVORA.AutoSize = true;
            this.label1SIFRAIZVORA.Anchor = AnchorStyles.Left;
            this.label1SIFRAIZVORA.Appearance.TextVAlign = VAlign.Middle;
            this.label1SIFRAIZVORA.Appearance.ForeColor = Color.Black;
            this.label1SIFRAIZVORA.BackColor = Color.Transparent;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.label1SIFRAIZVORA, 0, 6);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.label1SIFRAIZVORA, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.label1SIFRAIZVORA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SIFRAIZVORA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SIFRAIZVORA.MinimumSize = size;
            size = new System.Drawing.Size(0x4e, 0x17);
            this.label1SIFRAIZVORA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSIFRAIZVORA.Location = point;
            this.comboSIFRAIZVORA.Name = "comboSIFRAIZVORA";
            this.comboSIFRAIZVORA.Tag = "SIFRAIZVORA";
            this.comboSIFRAIZVORA.TabIndex = 0;
            this.comboSIFRAIZVORA.Anchor = AnchorStyles.Left;
            this.comboSIFRAIZVORA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSIFRAIZVORA.DropDownStyle = DropDownStyle.DropDown;
            this.comboSIFRAIZVORA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSIFRAIZVORA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSIFRAIZVORA.Enabled = true;
            this.comboSIFRAIZVORA.DataBindings.Add(new Binding("Value", this.bindingSourceKORISNIKLevel1, "SIFRAIZVORA"));
            this.comboSIFRAIZVORA.ShowPictureBox = true;
            this.comboSIFRAIZVORA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSIFRAIZVORA);
            this.comboSIFRAIZVORA.ValueMember = "SIFRAIZVORA";
            this.comboSIFRAIZVORA.SelectionChanged += new EventHandler(this.SelectedIndexChangedSIFRAIZVORA);
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.comboSIFRAIZVORA, 1, 6);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.comboSIFRAIZVORA, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.comboSIFRAIZVORA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSIFRAIZVORA.Margin = padding;
            size = new System.Drawing.Size(0x4d, 0x17);
            this.comboSIFRAIZVORA.MinimumSize = size;
            size = new System.Drawing.Size(0x4d, 0x17);
            this.comboSIFRAIZVORA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVIZVORA.Location = point;
            this.label1NAZIVIZVORA.Name = "label1NAZIVIZVORA";
            this.label1NAZIVIZVORA.TabIndex = 1;
            this.label1NAZIVIZVORA.Tag = "labelNAZIVIZVORA";
            this.label1NAZIVIZVORA.Text = "NAZIVIZVORA:";
            this.label1NAZIVIZVORA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVIZVORA.AutoSize = true;
            this.label1NAZIVIZVORA.Anchor = AnchorStyles.Left;
            this.label1NAZIVIZVORA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVIZVORA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVIZVORA.BackColor = Color.Transparent;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.label1NAZIVIZVORA, 0, 7);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.label1NAZIVIZVORA, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.label1NAZIVIZVORA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVIZVORA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVIZVORA.MinimumSize = size;
            size = new System.Drawing.Size(0x6c, 0x17);
            this.label1NAZIVIZVORA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVIZVORA.Location = point;
            this.labelNAZIVIZVORA.Name = "labelNAZIVIZVORA";
            this.labelNAZIVIZVORA.Tag = "NAZIVIZVORA";
            this.labelNAZIVIZVORA.TabIndex = 0;
            this.labelNAZIVIZVORA.Anchor = AnchorStyles.Left;
            this.labelNAZIVIZVORA.BackColor = Color.Transparent;
            this.labelNAZIVIZVORA.DataBindings.Add(new Binding("Text", this.bindingSourceKORISNIKLevel1, "NAZIVIZVORA"));
            this.labelNAZIVIZVORA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.labelNAZIVIZVORA, 1, 7);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.labelNAZIVIZVORA, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.labelNAZIVIZVORA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVIZVORA.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelNAZIVIZVORA.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelNAZIVIZVORA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POREZIPRIREZZAJEDNICKI.Location = point;
            this.label1POREZIPRIREZZAJEDNICKI.Name = "label1POREZIPRIREZZAJEDNICKI";
            this.label1POREZIPRIREZZAJEDNICKI.TabIndex = 1;
            this.label1POREZIPRIREZZAJEDNICKI.Tag = "labelPOREZIPRIREZZAJEDNICKI";
            this.label1POREZIPRIREZZAJEDNICKI.Text = "Zajednički virman poreza i prireza:";
            this.label1POREZIPRIREZZAJEDNICKI.StyleSetName = "FieldUltraLabel";
            this.label1POREZIPRIREZZAJEDNICKI.AutoSize = true;
            this.label1POREZIPRIREZZAJEDNICKI.Anchor = AnchorStyles.Left;
            this.label1POREZIPRIREZZAJEDNICKI.Appearance.TextVAlign = VAlign.Middle;
            this.label1POREZIPRIREZZAJEDNICKI.Appearance.ForeColor = Color.Black;
            this.label1POREZIPRIREZZAJEDNICKI.BackColor = Color.Transparent;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.label1POREZIPRIREZZAJEDNICKI, 0, 8);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.label1POREZIPRIREZZAJEDNICKI, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.label1POREZIPRIREZZAJEDNICKI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POREZIPRIREZZAJEDNICKI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POREZIPRIREZZAJEDNICKI.MinimumSize = size;
            size = new System.Drawing.Size(230, 0x17);
            this.label1POREZIPRIREZZAJEDNICKI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkPOREZIPRIREZZAJEDNICKI.Location = point;
            this.checkPOREZIPRIREZZAJEDNICKI.Name = "checkPOREZIPRIREZZAJEDNICKI";
            this.checkPOREZIPRIREZZAJEDNICKI.Tag = "POREZIPRIREZZAJEDNICKI";
            this.checkPOREZIPRIREZZAJEDNICKI.TabIndex = 0;
            this.checkPOREZIPRIREZZAJEDNICKI.Anchor = AnchorStyles.Left;
            this.checkPOREZIPRIREZZAJEDNICKI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkPOREZIPRIREZZAJEDNICKI.Enabled = true;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.checkPOREZIPRIREZZAJEDNICKI, 1, 8);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.checkPOREZIPRIREZZAJEDNICKI, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.checkPOREZIPRIREZZAJEDNICKI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkPOREZIPRIREZZAJEDNICKI.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkPOREZIPRIREZZAJEDNICKI.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkPOREZIPRIREZZAJEDNICKI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POZIVIZADUZENJA.Location = point;
            this.label1POZIVIZADUZENJA.Name = "label1POZIVIZADUZENJA";
            this.label1POZIVIZADUZENJA.TabIndex = 1;
            this.label1POZIVIZADUZENJA.Tag = "labelPOZIVIZADUZENJA";
            this.label1POZIVIZADUZENJA.Text = "Pozivi na broj zaduženja na virmanima:";
            this.label1POZIVIZADUZENJA.StyleSetName = "FieldUltraLabel";
            this.label1POZIVIZADUZENJA.AutoSize = true;
            this.label1POZIVIZADUZENJA.Anchor = AnchorStyles.Left;
            this.label1POZIVIZADUZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1POZIVIZADUZENJA.Appearance.ForeColor = Color.Black;
            this.label1POZIVIZADUZENJA.BackColor = Color.Transparent;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.label1POZIVIZADUZENJA, 0, 9);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.label1POZIVIZADUZENJA, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.label1POZIVIZADUZENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POZIVIZADUZENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POZIVIZADUZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x103, 0x17);
            this.label1POZIVIZADUZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkPOZIVIZADUZENJA.Location = point;
            this.checkPOZIVIZADUZENJA.Name = "checkPOZIVIZADUZENJA";
            this.checkPOZIVIZADUZENJA.Tag = "POZIVIZADUZENJA";
            this.checkPOZIVIZADUZENJA.TabIndex = 0;
            this.checkPOZIVIZADUZENJA.Anchor = AnchorStyles.Left;
            this.checkPOZIVIZADUZENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkPOZIVIZADUZENJA.Enabled = true;
            this.layoutManagerformKORISNIKLevel1.Controls.Add(this.checkPOZIVIZADUZENJA, 1, 9);
            this.layoutManagerformKORISNIKLevel1.SetColumnSpan(this.checkPOZIVIZADUZENJA, 1);
            this.layoutManagerformKORISNIKLevel1.SetRowSpan(this.checkPOZIVIZADUZENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkPOZIVIZADUZENJA.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkPOZIVIZADUZENJA.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkPOZIVIZADUZENJA.Size = size;
            this.Controls.Add(this.layoutManagerformKORISNIKLevel1);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceKORISNIKLevel1;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "KORISNIKFormKORISNIKLevel1UserControl";
            this.Text = " Podaci o isplatnim Žrn-ima korisnika";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.KORISNIKFormUserControl_Load);
            this.layoutManagerformKORISNIKLevel1.ResumeLayout(false);
            this.layoutManagerformKORISNIKLevel1.PerformLayout();
            ((ISupportInitialize) this.bindingSourceKORISNIKLevel1).EndInit();
            ((ISupportInitialize) this.textIDZIRO).EndInit();
            ((ISupportInitialize) this.textNAZIVZIRO).EndInit();
            ((ISupportInitialize) this.textULICAZIRO).EndInit();
            ((ISupportInitialize) this.textMJESTOZIRO).EndInit();
            ((ISupportInitialize) this.textVBDIKORISNIK).EndInit();
            ((ISupportInitialize) this.textZIROKORISNIK).EndInit();
            this.dsKORISNIKDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.KORISNIKController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceKORISNIKLevel1, this.KORISNIKController.WorkItem, this))
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

        private void KORISNIKFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.KORISNIKKORISNIKLevel1LevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void Localize()
        {
            this.label1IDZIRO.Text = StringResources.KORISNIKIDZIRODescription;
            this.label1NAZIVZIRO.Text = StringResources.KORISNIKNAZIVZIRODescription;
            this.label1ULICAZIRO.Text = StringResources.KORISNIKULICAZIRODescription;
            this.label1MJESTOZIRO.Text = StringResources.KORISNIKMJESTOZIRODescription;
            this.label1VBDIKORISNIK.Text = StringResources.KORISNIKVBDIKORISNIKDescription;
            this.label1ZIROKORISNIK.Text = StringResources.KORISNIKZIROKORISNIKDescription;
            this.label1SIFRAIZVORA.Text = StringResources.KORISNIKSIFRAIZVORADescription;
            this.label1NAZIVIZVORA.Text = StringResources.KORISNIKNAZIVIZVORADescription;
            this.label1POREZIPRIREZZAJEDNICKI.Text = StringResources.KORISNIKPOREZIPRIREZZAJEDNICKIDescription;
            this.label1POZIVIZADUZENJA.Text = StringResources.KORISNIKPOZIVIZADUZENJADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedSIFRAIZVORA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("IZVORDOKUMENTA", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.KORISNIKController.WorkItem.Items.Contains("KORISNIKLevel1|KORISNIKLevel1"))
            {
                this.KORISNIKController.WorkItem.Items.Add(this.bindingSourceKORISNIKLevel1, "KORISNIKLevel1|KORISNIKLevel1");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("KORISNIKLevel1SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedSIFRAIZVORA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSIFRAIZVORA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSIFRAIZVORA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceKORISNIKLevel1.Current).Row["SIFRAIZVORA"] = RuntimeHelpers.GetObjectValue(row["SIFRAIZVORA"]);
                    ((DataRowView) this.bindingSourceKORISNIKLevel1.Current).Row["NAZIVIZVORA"] = RuntimeHelpers.GetObjectValue(row["NAZIVIZVORA"]);
                    this.bindingSourceKORISNIKLevel1.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDZIRO.Focus();
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

        protected virtual UltraCheckEditor checkPOREZIPRIREZZAJEDNICKI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkPOREZIPRIREZZAJEDNICKI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkPOREZIPRIREZZAJEDNICKI = value;
            }
        }

        protected virtual UltraCheckEditor checkPOZIVIZADUZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkPOZIVIZADUZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkPOZIVIZADUZENJA = value;
            }
        }

        protected virtual IZVORDOKUMENTAComboBox comboSIFRAIZVORA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSIFRAIZVORA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSIFRAIZVORA = value;
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.KORISNIKController KORISNIKController { get; set; }

        protected virtual UltraLabel label1IDZIRO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDZIRO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDZIRO = value;
            }
        }

        protected virtual UltraLabel label1MJESTOZIRO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MJESTOZIRO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MJESTOZIRO = value;
            }
        }

        protected virtual UltraLabel label1NAZIVIZVORA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVIZVORA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVIZVORA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVZIRO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVZIRO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVZIRO = value;
            }
        }

        protected virtual UltraLabel label1POREZIPRIREZZAJEDNICKI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POREZIPRIREZZAJEDNICKI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POREZIPRIREZZAJEDNICKI = value;
            }
        }

        protected virtual UltraLabel label1POZIVIZADUZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POZIVIZADUZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POZIVIZADUZENJA = value;
            }
        }

        protected virtual UltraLabel label1SIFRAIZVORA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SIFRAIZVORA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SIFRAIZVORA = value;
            }
        }

        protected virtual UltraLabel label1ULICAZIRO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ULICAZIRO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ULICAZIRO = value;
            }
        }

        protected virtual UltraLabel label1VBDIKORISNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VBDIKORISNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VBDIKORISNIK = value;
            }
        }

        protected virtual UltraLabel label1ZIROKORISNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZIROKORISNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZIROKORISNIK = value;
            }
        }

        protected virtual UltraLabel labelNAZIVIZVORA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVIZVORA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVIZVORA = value;
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

        protected virtual UltraNumericEditor textIDZIRO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDZIRO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDZIRO = value;
            }
        }

        protected virtual UltraTextEditor textMJESTOZIRO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMJESTOZIRO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMJESTOZIRO = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVZIRO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVZIRO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVZIRO = value;
            }
        }

        protected virtual UltraTextEditor textULICAZIRO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textULICAZIRO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textULICAZIRO = value;
            }
        }

        protected virtual UltraTextEditor textVBDIKORISNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVBDIKORISNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVBDIKORISNIK = value;
            }
        }

        protected virtual UltraTextEditor textZIROKORISNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZIROKORISNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZIROKORISNIK = value;
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

