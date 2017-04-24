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
    public class VIRMANIFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkOZNACEN")]
        private UltraCheckEditor _checkOZNACEN;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("datePickerDATUMPODNOSENJA")]
        private UltraDateTimeEditor _datePickerDATUMPODNOSENJA;
        [AccessedThroughProperty("datePickerDATUMVALUTE")]
        private UltraDateTimeEditor _datePickerDATUMVALUTE;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1BROJRACUNAPLA")]
        private UltraLabel _label1BROJRACUNAPLA;
        [AccessedThroughProperty("label1BROJRACUNAPRI")]
        private UltraLabel _label1BROJRACUNAPRI;
        [AccessedThroughProperty("label1DATUMPODNOSENJA")]
        private UltraLabel _label1DATUMPODNOSENJA;
        [AccessedThroughProperty("label1DATUMVALUTE")]
        private UltraLabel _label1DATUMVALUTE;
        [AccessedThroughProperty("label1IZNOS")]
        private UltraLabel _label1IZNOS;
        [AccessedThroughProperty("label1IZVORDOKUMENTA")]
        private UltraLabel _label1IZVORDOKUMENTA;
        [AccessedThroughProperty("label1MODELODOBRENJA")]
        private UltraLabel _label1MODELODOBRENJA;
        [AccessedThroughProperty("label1MODELZADUZENJA")]
        private UltraLabel _label1MODELZADUZENJA;
        [AccessedThroughProperty("label1NAMJENA")]
        private UltraLabel _label1NAMJENA;
        [AccessedThroughProperty("label1OPISPLACANJAVIRMAN")]
        private UltraLabel _label1OPISPLACANJAVIRMAN;
        [AccessedThroughProperty("label1OZNACEN")]
        private UltraLabel _label1OZNACEN;
        [AccessedThroughProperty("label1PLA1")]
        private UltraLabel _label1PLA1;
        [AccessedThroughProperty("label1PLA2")]
        private UltraLabel _label1PLA2;
        [AccessedThroughProperty("label1PLA3")]
        private UltraLabel _label1PLA3;
        [AccessedThroughProperty("label1POZIVODOBRENJA")]
        private UltraLabel _label1POZIVODOBRENJA;
        [AccessedThroughProperty("label1POZIVZADUZENJA")]
        private UltraLabel _label1POZIVZADUZENJA;
        [AccessedThroughProperty("label1PRI1")]
        private UltraLabel _label1PRI1;
        [AccessedThroughProperty("label1PRI2")]
        private UltraLabel _label1PRI2;
        [AccessedThroughProperty("label1PRI3")]
        private UltraLabel _label1PRI3;
        [AccessedThroughProperty("label1SIFRAOBRACUNAVIRMAN")]
        private UltraLabel _label1SIFRAOBRACUNAVIRMAN;
        [AccessedThroughProperty("label1SIFRAOPISAPLACANJAVIRMAN")]
        private UltraLabel _label1SIFRAOPISAPLACANJAVIRMAN;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textBROJRACUNAPLA")]
        private UltraTextEditor _textBROJRACUNAPLA;
        [AccessedThroughProperty("textBROJRACUNAPRI")]
        private UltraTextEditor _textBROJRACUNAPRI;
        [AccessedThroughProperty("textIZNOS")]
        private UltraNumericEditor _textIZNOS;
        [AccessedThroughProperty("textIZVORDOKUMENTA")]
        private UltraTextEditor _textIZVORDOKUMENTA;
        [AccessedThroughProperty("textMODELODOBRENJA")]
        private UltraTextEditor _textMODELODOBRENJA;
        [AccessedThroughProperty("textMODELZADUZENJA")]
        private UltraTextEditor _textMODELZADUZENJA;
        [AccessedThroughProperty("textNAMJENA")]
        private UltraTextEditor _textNAMJENA;
        [AccessedThroughProperty("textOPISPLACANJAVIRMAN")]
        private UltraTextEditor _textOPISPLACANJAVIRMAN;
        [AccessedThroughProperty("textPLA1")]
        private UltraTextEditor _textPLA1;
        [AccessedThroughProperty("textPLA2")]
        private UltraTextEditor _textPLA2;
        [AccessedThroughProperty("textPLA3")]
        private UltraTextEditor _textPLA3;
        [AccessedThroughProperty("textPOZIVODOBRENJA")]
        private UltraTextEditor _textPOZIVODOBRENJA;
        [AccessedThroughProperty("textPOZIVZADUZENJA")]
        private UltraTextEditor _textPOZIVZADUZENJA;
        [AccessedThroughProperty("textPRI1")]
        private UltraTextEditor _textPRI1;
        [AccessedThroughProperty("textPRI2")]
        private UltraTextEditor _textPRI2;
        [AccessedThroughProperty("textPRI3")]
        private UltraTextEditor _textPRI3;
        [AccessedThroughProperty("textSIFRAOBRACUNAVIRMAN")]
        private UltraTextEditor _textSIFRAOBRACUNAVIRMAN;
        [AccessedThroughProperty("textSIFRAOPISAPLACANJAVIRMAN")]
        private UltraTextEditor _textSIFRAOPISAPLACANJAVIRMAN;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceVIRMANI;
        private IContainer components = null;
        private VIRMANIDataSet dsVIRMANIDataSet1;
        protected TableLayoutPanel layoutManagerformVIRMANI;
        private bool m_AutoNumber = true;
        private GenericFormClass m_BaseMethods;
        private VIRMANIDataSet.VIRMANIRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "VIRMANI";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.VIRMANIDescription;
        private DeklaritMode m_Mode;

        public VIRMANIFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceVIRMANI.DataSource = this.VIRMANIController.DataSet;
            this.dsVIRMANIDataSet1 = this.VIRMANIController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void contextMenu1_Popup(object sender, EventArgs e)
        {
            this.m_BaseMethods.ContextMenu1PopupBase(this.contextMenu1, this.m_CurrentRow);
        }

        [LocalCommandHandler("DeleteInstance")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.dsVIRMANIDataSet1.VIRMANI.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ((DataRow) enumerator.Current).Delete();
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                if (this.VIRMANIController.Update(this))
                {
                    this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "VIRMANI", this.m_Mode, this.dsVIRMANIDataSet1, this.dsVIRMANIDataSet1.VIRMANI.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding2 = new Binding("Text", this.bindingSourceVIRMANI, "DATUMVALUTE", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding2.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParse);
            if (this.datePickerDATUMVALUTE.DataBindings["Text"] != null)
            {
                this.datePickerDATUMVALUTE.DataBindings.Remove(this.datePickerDATUMVALUTE.DataBindings["Text"]);
            }
            this.datePickerDATUMVALUTE.DataBindings.Add(binding2);
            Binding binding = new Binding("Text", this.bindingSourceVIRMANI, "DATUMPODNOSENJA", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParse);
            if (this.datePickerDATUMPODNOSENJA.DataBindings["Text"] != null)
            {
                this.datePickerDATUMPODNOSENJA.DataBindings.Remove(this.datePickerDATUMPODNOSENJA.DataBindings["Text"]);
            }
            this.datePickerDATUMPODNOSENJA.DataBindings.Add(binding);
            Binding binding3 = new Binding("CheckState", this.bindingSourceVIRMANI, "OZNACEN", true);
            binding3.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding3.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkOZNACEN.DataBindings["CheckState"] != null)
            {
                this.checkOZNACEN.DataBindings.Remove(this.checkOZNACEN.DataBindings["CheckState"]);
            }
            this.checkOZNACEN.DataBindings.Add(binding3);
            this.checkOZNACEN.ThreeState = true;
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsVIRMANIDataSet1.VIRMANI[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (VIRMANIDataSet.VIRMANIRow) ((DataRowView) this.bindingSourceVIRMANI.AddNew()).Row;
                foreach (string str in DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, foreignKeys))
                {
                    this.m_BaseMethods.SetReadOnly(str, true);
                    this.m_BaseMethods.GetLabelControl(str).Visible = false;
                    this.m_BaseMethods.GetControl(str).Visible = false;
                }
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(VIRMANIFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceVIRMANI = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceVIRMANI).BeginInit();
            this.layoutManagerformVIRMANI = new TableLayoutPanel();
            this.layoutManagerformVIRMANI.SuspendLayout();
            this.layoutManagerformVIRMANI.AutoSize = true;
            this.layoutManagerformVIRMANI.Dock = DockStyle.Fill;
            this.layoutManagerformVIRMANI.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformVIRMANI.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformVIRMANI.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformVIRMANI.Size = size;
            this.layoutManagerformVIRMANI.ColumnCount = 2;
            this.layoutManagerformVIRMANI.RowCount = 0x16;
            this.layoutManagerformVIRMANI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformVIRMANI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.layoutManagerformVIRMANI.RowStyles.Add(new RowStyle());
            this.label1SIFRAOBRACUNAVIRMAN = new UltraLabel();
            this.textSIFRAOBRACUNAVIRMAN = new UltraTextEditor();
            this.label1PLA1 = new UltraLabel();
            this.textPLA1 = new UltraTextEditor();
            this.label1PLA2 = new UltraLabel();
            this.textPLA2 = new UltraTextEditor();
            this.label1PLA3 = new UltraLabel();
            this.textPLA3 = new UltraTextEditor();
            this.label1BROJRACUNAPLA = new UltraLabel();
            this.textBROJRACUNAPLA = new UltraTextEditor();
            this.label1MODELZADUZENJA = new UltraLabel();
            this.textMODELZADUZENJA = new UltraTextEditor();
            this.label1POZIVZADUZENJA = new UltraLabel();
            this.textPOZIVZADUZENJA = new UltraTextEditor();
            this.label1PRI1 = new UltraLabel();
            this.textPRI1 = new UltraTextEditor();
            this.label1PRI2 = new UltraLabel();
            this.textPRI2 = new UltraTextEditor();
            this.label1PRI3 = new UltraLabel();
            this.textPRI3 = new UltraTextEditor();
            this.label1BROJRACUNAPRI = new UltraLabel();
            this.textBROJRACUNAPRI = new UltraTextEditor();
            this.label1MODELODOBRENJA = new UltraLabel();
            this.textMODELODOBRENJA = new UltraTextEditor();
            this.label1POZIVODOBRENJA = new UltraLabel();
            this.textPOZIVODOBRENJA = new UltraTextEditor();
            this.label1SIFRAOPISAPLACANJAVIRMAN = new UltraLabel();
            this.textSIFRAOPISAPLACANJAVIRMAN = new UltraTextEditor();
            this.label1OPISPLACANJAVIRMAN = new UltraLabel();
            this.textOPISPLACANJAVIRMAN = new UltraTextEditor();
            this.label1DATUMVALUTE = new UltraLabel();
            this.datePickerDATUMVALUTE = new UltraDateTimeEditor();
            this.label1DATUMPODNOSENJA = new UltraLabel();
            this.datePickerDATUMPODNOSENJA = new UltraDateTimeEditor();
            this.label1IZVORDOKUMENTA = new UltraLabel();
            this.textIZVORDOKUMENTA = new UltraTextEditor();
            this.label1OZNACEN = new UltraLabel();
            this.checkOZNACEN = new UltraCheckEditor();
            this.label1IZNOS = new UltraLabel();
            this.textIZNOS = new UltraNumericEditor();
            this.label1NAMJENA = new UltraLabel();
            this.textNAMJENA = new UltraTextEditor();
            ((ISupportInitialize) this.textSIFRAOBRACUNAVIRMAN).BeginInit();
            ((ISupportInitialize) this.textPLA1).BeginInit();
            ((ISupportInitialize) this.textPLA2).BeginInit();
            ((ISupportInitialize) this.textPLA3).BeginInit();
            ((ISupportInitialize) this.textBROJRACUNAPLA).BeginInit();
            ((ISupportInitialize) this.textMODELZADUZENJA).BeginInit();
            ((ISupportInitialize) this.textPOZIVZADUZENJA).BeginInit();
            ((ISupportInitialize) this.textPRI1).BeginInit();
            ((ISupportInitialize) this.textPRI2).BeginInit();
            ((ISupportInitialize) this.textPRI3).BeginInit();
            ((ISupportInitialize) this.textBROJRACUNAPRI).BeginInit();
            ((ISupportInitialize) this.textMODELODOBRENJA).BeginInit();
            ((ISupportInitialize) this.textPOZIVODOBRENJA).BeginInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJAVIRMAN).BeginInit();
            ((ISupportInitialize) this.textOPISPLACANJAVIRMAN).BeginInit();
            ((ISupportInitialize) this.textIZVORDOKUMENTA).BeginInit();
            ((ISupportInitialize) this.textIZNOS).BeginInit();
            ((ISupportInitialize) this.textNAMJENA).BeginInit();
            this.dsVIRMANIDataSet1 = new VIRMANIDataSet();
            this.dsVIRMANIDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsVIRMANIDataSet1.DataSetName = "dsVIRMANI";
            this.dsVIRMANIDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceVIRMANI.DataSource = this.dsVIRMANIDataSet1;
            this.bindingSourceVIRMANI.DataMember = "VIRMANI";
            ((ISupportInitialize) this.bindingSourceVIRMANI).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1SIFRAOBRACUNAVIRMAN.Location = point;
            this.label1SIFRAOBRACUNAVIRMAN.Name = "label1SIFRAOBRACUNAVIRMAN";
            this.label1SIFRAOBRACUNAVIRMAN.TabIndex = 1;
            this.label1SIFRAOBRACUNAVIRMAN.Tag = "labelSIFRAOBRACUNAVIRMAN";
            this.label1SIFRAOBRACUNAVIRMAN.Text = "SIFRAOBRACUNAVIRMAN:";
            this.label1SIFRAOBRACUNAVIRMAN.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAOBRACUNAVIRMAN.AutoSize = true;
            this.label1SIFRAOBRACUNAVIRMAN.Anchor = AnchorStyles.Left;
            this.label1SIFRAOBRACUNAVIRMAN.Appearance.TextVAlign = VAlign.Middle;
            this.label1SIFRAOBRACUNAVIRMAN.Appearance.ForeColor = Color.Black;
            this.label1SIFRAOBRACUNAVIRMAN.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1SIFRAOBRACUNAVIRMAN, 0, 0);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1SIFRAOBRACUNAVIRMAN, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1SIFRAOBRACUNAVIRMAN, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1SIFRAOBRACUNAVIRMAN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SIFRAOBRACUNAVIRMAN.MinimumSize = size;
            size = new System.Drawing.Size(0xb5, 0x17);
            this.label1SIFRAOBRACUNAVIRMAN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSIFRAOBRACUNAVIRMAN.Location = point;
            this.textSIFRAOBRACUNAVIRMAN.Name = "textSIFRAOBRACUNAVIRMAN";
            this.textSIFRAOBRACUNAVIRMAN.Tag = "SIFRAOBRACUNAVIRMAN";
            this.textSIFRAOBRACUNAVIRMAN.TabIndex = 0;
            this.textSIFRAOBRACUNAVIRMAN.Anchor = AnchorStyles.Left;
            this.textSIFRAOBRACUNAVIRMAN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSIFRAOBRACUNAVIRMAN.ReadOnly = false;
            this.textSIFRAOBRACUNAVIRMAN.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "SIFRAOBRACUNAVIRMAN"));
            this.textSIFRAOBRACUNAVIRMAN.MaxLength = 11;
            this.layoutManagerformVIRMANI.Controls.Add(this.textSIFRAOBRACUNAVIRMAN, 1, 0);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textSIFRAOBRACUNAVIRMAN, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textSIFRAOBRACUNAVIRMAN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSIFRAOBRACUNAVIRMAN.Margin = padding;
            size = new System.Drawing.Size(0x5d, 0x16);
            this.textSIFRAOBRACUNAVIRMAN.MinimumSize = size;
            size = new System.Drawing.Size(0x5d, 0x16);
            this.textSIFRAOBRACUNAVIRMAN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PLA1.Location = point;
            this.label1PLA1.Name = "label1PLA1";
            this.label1PLA1.TabIndex = 1;
            this.label1PLA1.Tag = "labelPLA1";
            this.label1PLA1.Text = "PL A1:";
            this.label1PLA1.StyleSetName = "FieldUltraLabel";
            this.label1PLA1.AutoSize = true;
            this.label1PLA1.Anchor = AnchorStyles.Left;
            this.label1PLA1.Appearance.TextVAlign = VAlign.Middle;
            this.label1PLA1.Appearance.ForeColor = Color.Black;
            this.label1PLA1.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1PLA1, 0, 1);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1PLA1, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1PLA1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PLA1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PLA1.MinimumSize = size;
            size = new System.Drawing.Size(0x36, 0x17);
            this.label1PLA1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPLA1.Location = point;
            this.textPLA1.Name = "textPLA1";
            this.textPLA1.Tag = "PLA1";
            this.textPLA1.TabIndex = 0;
            this.textPLA1.Anchor = AnchorStyles.Left;
            this.textPLA1.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPLA1.ContextMenu = this.contextMenu1;
            this.textPLA1.ReadOnly = false;
            this.textPLA1.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "PLA1"));
            this.textPLA1.Nullable = true;
            this.textPLA1.MaxLength = 20;
            this.layoutManagerformVIRMANI.Controls.Add(this.textPLA1, 1, 1);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textPLA1, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textPLA1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPLA1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPLA1.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPLA1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PLA2.Location = point;
            this.label1PLA2.Name = "label1PLA2";
            this.label1PLA2.TabIndex = 1;
            this.label1PLA2.Tag = "labelPLA2";
            this.label1PLA2.Text = "PL A2:";
            this.label1PLA2.StyleSetName = "FieldUltraLabel";
            this.label1PLA2.AutoSize = true;
            this.label1PLA2.Anchor = AnchorStyles.Left;
            this.label1PLA2.Appearance.TextVAlign = VAlign.Middle;
            this.label1PLA2.Appearance.ForeColor = Color.Black;
            this.label1PLA2.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1PLA2, 0, 2);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1PLA2, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1PLA2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PLA2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PLA2.MinimumSize = size;
            size = new System.Drawing.Size(0x36, 0x17);
            this.label1PLA2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPLA2.Location = point;
            this.textPLA2.Name = "textPLA2";
            this.textPLA2.Tag = "PLA2";
            this.textPLA2.TabIndex = 0;
            this.textPLA2.Anchor = AnchorStyles.Left;
            this.textPLA2.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPLA2.ContextMenu = this.contextMenu1;
            this.textPLA2.ReadOnly = false;
            this.textPLA2.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "PLA2"));
            this.textPLA2.Nullable = true;
            this.textPLA2.MaxLength = 20;
            this.layoutManagerformVIRMANI.Controls.Add(this.textPLA2, 1, 2);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textPLA2, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textPLA2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPLA2.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPLA2.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPLA2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PLA3.Location = point;
            this.label1PLA3.Name = "label1PLA3";
            this.label1PLA3.TabIndex = 1;
            this.label1PLA3.Tag = "labelPLA3";
            this.label1PLA3.Text = "PL A3:";
            this.label1PLA3.StyleSetName = "FieldUltraLabel";
            this.label1PLA3.AutoSize = true;
            this.label1PLA3.Anchor = AnchorStyles.Left;
            this.label1PLA3.Appearance.TextVAlign = VAlign.Middle;
            this.label1PLA3.Appearance.ForeColor = Color.Black;
            this.label1PLA3.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1PLA3, 0, 3);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1PLA3, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1PLA3, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PLA3.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PLA3.MinimumSize = size;
            size = new System.Drawing.Size(0x36, 0x17);
            this.label1PLA3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPLA3.Location = point;
            this.textPLA3.Name = "textPLA3";
            this.textPLA3.Tag = "PLA3";
            this.textPLA3.TabIndex = 0;
            this.textPLA3.Anchor = AnchorStyles.Left;
            this.textPLA3.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPLA3.ContextMenu = this.contextMenu1;
            this.textPLA3.ReadOnly = false;
            this.textPLA3.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "PLA3"));
            this.textPLA3.Nullable = true;
            this.textPLA3.MaxLength = 20;
            this.layoutManagerformVIRMANI.Controls.Add(this.textPLA3, 1, 3);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textPLA3, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textPLA3, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPLA3.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPLA3.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPLA3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1BROJRACUNAPLA.Location = point;
            this.label1BROJRACUNAPLA.Name = "label1BROJRACUNAPLA";
            this.label1BROJRACUNAPLA.TabIndex = 1;
            this.label1BROJRACUNAPLA.Tag = "labelBROJRACUNAPLA";
            this.label1BROJRACUNAPLA.Text = "BROJRACUNAPLA:";
            this.label1BROJRACUNAPLA.StyleSetName = "FieldUltraLabel";
            this.label1BROJRACUNAPLA.AutoSize = true;
            this.label1BROJRACUNAPLA.Anchor = AnchorStyles.Left;
            this.label1BROJRACUNAPLA.Appearance.TextVAlign = VAlign.Middle;
            this.label1BROJRACUNAPLA.Appearance.ForeColor = Color.Black;
            this.label1BROJRACUNAPLA.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1BROJRACUNAPLA, 0, 4);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1BROJRACUNAPLA, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1BROJRACUNAPLA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1BROJRACUNAPLA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BROJRACUNAPLA.MinimumSize = size;
            size = new System.Drawing.Size(0x81, 0x17);
            this.label1BROJRACUNAPLA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textBROJRACUNAPLA.Location = point;
            this.textBROJRACUNAPLA.Name = "textBROJRACUNAPLA";
            this.textBROJRACUNAPLA.Tag = "BROJRACUNAPLA";
            this.textBROJRACUNAPLA.TabIndex = 0;
            this.textBROJRACUNAPLA.Anchor = AnchorStyles.Left;
            this.textBROJRACUNAPLA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textBROJRACUNAPLA.ContextMenu = this.contextMenu1;
            this.textBROJRACUNAPLA.ReadOnly = false;
            this.textBROJRACUNAPLA.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "BROJRACUNAPLA"));
            this.textBROJRACUNAPLA.Nullable = true;
            this.textBROJRACUNAPLA.MaxLength = 0x12;
            this.layoutManagerformVIRMANI.Controls.Add(this.textBROJRACUNAPLA, 1, 4);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textBROJRACUNAPLA, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textBROJRACUNAPLA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBROJRACUNAPLA.Margin = padding;
            size = new System.Drawing.Size(0x8e, 0x16);
            this.textBROJRACUNAPLA.MinimumSize = size;
            size = new System.Drawing.Size(0x8e, 0x16);
            this.textBROJRACUNAPLA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MODELZADUZENJA.Location = point;
            this.label1MODELZADUZENJA.Name = "label1MODELZADUZENJA";
            this.label1MODELZADUZENJA.TabIndex = 1;
            this.label1MODELZADUZENJA.Tag = "labelMODELZADUZENJA";
            this.label1MODELZADUZENJA.Text = "MODELZADUZENJA:";
            this.label1MODELZADUZENJA.StyleSetName = "FieldUltraLabel";
            this.label1MODELZADUZENJA.AutoSize = true;
            this.label1MODELZADUZENJA.Anchor = AnchorStyles.Left;
            this.label1MODELZADUZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MODELZADUZENJA.Appearance.ForeColor = Color.Black;
            this.label1MODELZADUZENJA.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1MODELZADUZENJA, 0, 5);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1MODELZADUZENJA, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1MODELZADUZENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MODELZADUZENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MODELZADUZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x8a, 0x17);
            this.label1MODELZADUZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMODELZADUZENJA.Location = point;
            this.textMODELZADUZENJA.Name = "textMODELZADUZENJA";
            this.textMODELZADUZENJA.Tag = "MODELZADUZENJA";
            this.textMODELZADUZENJA.TabIndex = 0;
            this.textMODELZADUZENJA.Anchor = AnchorStyles.Left;
            this.textMODELZADUZENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMODELZADUZENJA.ContextMenu = this.contextMenu1;
            this.textMODELZADUZENJA.ReadOnly = false;
            this.textMODELZADUZENJA.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "MODELZADUZENJA"));
            this.textMODELZADUZENJA.Nullable = true;
            this.textMODELZADUZENJA.MaxLength = 2;
            this.layoutManagerformVIRMANI.Controls.Add(this.textMODELZADUZENJA, 1, 5);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textMODELZADUZENJA, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textMODELZADUZENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMODELZADUZENJA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMODELZADUZENJA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMODELZADUZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POZIVZADUZENJA.Location = point;
            this.label1POZIVZADUZENJA.Name = "label1POZIVZADUZENJA";
            this.label1POZIVZADUZENJA.TabIndex = 1;
            this.label1POZIVZADUZENJA.Tag = "labelPOZIVZADUZENJA";
            this.label1POZIVZADUZENJA.Text = "POZIVZADUZENJA:";
            this.label1POZIVZADUZENJA.StyleSetName = "FieldUltraLabel";
            this.label1POZIVZADUZENJA.AutoSize = true;
            this.label1POZIVZADUZENJA.Anchor = AnchorStyles.Left;
            this.label1POZIVZADUZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1POZIVZADUZENJA.Appearance.ForeColor = Color.Black;
            this.label1POZIVZADUZENJA.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1POZIVZADUZENJA, 0, 6);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1POZIVZADUZENJA, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1POZIVZADUZENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POZIVZADUZENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POZIVZADUZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x85, 0x17);
            this.label1POZIVZADUZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOZIVZADUZENJA.Location = point;
            this.textPOZIVZADUZENJA.Name = "textPOZIVZADUZENJA";
            this.textPOZIVZADUZENJA.Tag = "POZIVZADUZENJA";
            this.textPOZIVZADUZENJA.TabIndex = 0;
            this.textPOZIVZADUZENJA.Anchor = AnchorStyles.Left;
            this.textPOZIVZADUZENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOZIVZADUZENJA.ContextMenu = this.contextMenu1;
            this.textPOZIVZADUZENJA.ReadOnly = false;
            this.textPOZIVZADUZENJA.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "POZIVZADUZENJA"));
            this.textPOZIVZADUZENJA.Nullable = true;
            this.textPOZIVZADUZENJA.MaxLength = 0x16;
            this.layoutManagerformVIRMANI.Controls.Add(this.textPOZIVZADUZENJA, 1, 6);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textPOZIVZADUZENJA, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textPOZIVZADUZENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOZIVZADUZENJA.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOZIVZADUZENJA.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOZIVZADUZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRI1.Location = point;
            this.label1PRI1.Name = "label1PRI1";
            this.label1PRI1.TabIndex = 1;
            this.label1PRI1.Tag = "labelPRI1";
            this.label1PRI1.Text = "PR I1:";
            this.label1PRI1.StyleSetName = "FieldUltraLabel";
            this.label1PRI1.AutoSize = true;
            this.label1PRI1.Anchor = AnchorStyles.Left;
            this.label1PRI1.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRI1.Appearance.ForeColor = Color.Black;
            this.label1PRI1.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1PRI1, 0, 7);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1PRI1, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1PRI1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRI1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRI1.MinimumSize = size;
            size = new System.Drawing.Size(0x36, 0x17);
            this.label1PRI1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRI1.Location = point;
            this.textPRI1.Name = "textPRI1";
            this.textPRI1.Tag = "PRI1";
            this.textPRI1.TabIndex = 0;
            this.textPRI1.Anchor = AnchorStyles.Left;
            this.textPRI1.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRI1.ContextMenu = this.contextMenu1;
            this.textPRI1.ReadOnly = false;
            this.textPRI1.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "PRI1"));
            this.textPRI1.Nullable = true;
            this.textPRI1.MaxLength = 20;
            this.layoutManagerformVIRMANI.Controls.Add(this.textPRI1, 1, 7);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textPRI1, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textPRI1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRI1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRI1.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRI1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRI2.Location = point;
            this.label1PRI2.Name = "label1PRI2";
            this.label1PRI2.TabIndex = 1;
            this.label1PRI2.Tag = "labelPRI2";
            this.label1PRI2.Text = "PR I2:";
            this.label1PRI2.StyleSetName = "FieldUltraLabel";
            this.label1PRI2.AutoSize = true;
            this.label1PRI2.Anchor = AnchorStyles.Left;
            this.label1PRI2.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRI2.Appearance.ForeColor = Color.Black;
            this.label1PRI2.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1PRI2, 0, 8);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1PRI2, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1PRI2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRI2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRI2.MinimumSize = size;
            size = new System.Drawing.Size(0x36, 0x17);
            this.label1PRI2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRI2.Location = point;
            this.textPRI2.Name = "textPRI2";
            this.textPRI2.Tag = "PRI2";
            this.textPRI2.TabIndex = 0;
            this.textPRI2.Anchor = AnchorStyles.Left;
            this.textPRI2.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRI2.ContextMenu = this.contextMenu1;
            this.textPRI2.ReadOnly = false;
            this.textPRI2.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "PRI2"));
            this.textPRI2.Nullable = true;
            this.textPRI2.MaxLength = 20;
            this.layoutManagerformVIRMANI.Controls.Add(this.textPRI2, 1, 8);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textPRI2, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textPRI2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRI2.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRI2.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRI2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRI3.Location = point;
            this.label1PRI3.Name = "label1PRI3";
            this.label1PRI3.TabIndex = 1;
            this.label1PRI3.Tag = "labelPRI3";
            this.label1PRI3.Text = "PR I3:";
            this.label1PRI3.StyleSetName = "FieldUltraLabel";
            this.label1PRI3.AutoSize = true;
            this.label1PRI3.Anchor = AnchorStyles.Left;
            this.label1PRI3.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRI3.Appearance.ForeColor = Color.Black;
            this.label1PRI3.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1PRI3, 0, 9);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1PRI3, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1PRI3, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRI3.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRI3.MinimumSize = size;
            size = new System.Drawing.Size(0x36, 0x17);
            this.label1PRI3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRI3.Location = point;
            this.textPRI3.Name = "textPRI3";
            this.textPRI3.Tag = "PRI3";
            this.textPRI3.TabIndex = 0;
            this.textPRI3.Anchor = AnchorStyles.Left;
            this.textPRI3.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRI3.ContextMenu = this.contextMenu1;
            this.textPRI3.ReadOnly = false;
            this.textPRI3.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "PRI3"));
            this.textPRI3.Nullable = true;
            this.textPRI3.MaxLength = 20;
            this.layoutManagerformVIRMANI.Controls.Add(this.textPRI3, 1, 9);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textPRI3, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textPRI3, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRI3.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRI3.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRI3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1BROJRACUNAPRI.Location = point;
            this.label1BROJRACUNAPRI.Name = "label1BROJRACUNAPRI";
            this.label1BROJRACUNAPRI.TabIndex = 1;
            this.label1BROJRACUNAPRI.Tag = "labelBROJRACUNAPRI";
            this.label1BROJRACUNAPRI.Text = "BROJRACUNAPRI:";
            this.label1BROJRACUNAPRI.StyleSetName = "FieldUltraLabel";
            this.label1BROJRACUNAPRI.AutoSize = true;
            this.label1BROJRACUNAPRI.Anchor = AnchorStyles.Left;
            this.label1BROJRACUNAPRI.Appearance.TextVAlign = VAlign.Middle;
            this.label1BROJRACUNAPRI.Appearance.ForeColor = Color.Black;
            this.label1BROJRACUNAPRI.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1BROJRACUNAPRI, 0, 10);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1BROJRACUNAPRI, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1BROJRACUNAPRI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1BROJRACUNAPRI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BROJRACUNAPRI.MinimumSize = size;
            size = new System.Drawing.Size(0x80, 0x17);
            this.label1BROJRACUNAPRI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textBROJRACUNAPRI.Location = point;
            this.textBROJRACUNAPRI.Name = "textBROJRACUNAPRI";
            this.textBROJRACUNAPRI.Tag = "BROJRACUNAPRI";
            this.textBROJRACUNAPRI.TabIndex = 0;
            this.textBROJRACUNAPRI.Anchor = AnchorStyles.Left;
            this.textBROJRACUNAPRI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textBROJRACUNAPRI.ContextMenu = this.contextMenu1;
            this.textBROJRACUNAPRI.ReadOnly = false;
            this.textBROJRACUNAPRI.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "BROJRACUNAPRI"));
            this.textBROJRACUNAPRI.Nullable = true;
            this.textBROJRACUNAPRI.MaxLength = 0x12;
            this.layoutManagerformVIRMANI.Controls.Add(this.textBROJRACUNAPRI, 1, 10);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textBROJRACUNAPRI, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textBROJRACUNAPRI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBROJRACUNAPRI.Margin = padding;
            size = new System.Drawing.Size(0x8e, 0x16);
            this.textBROJRACUNAPRI.MinimumSize = size;
            size = new System.Drawing.Size(0x8e, 0x16);
            this.textBROJRACUNAPRI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MODELODOBRENJA.Location = point;
            this.label1MODELODOBRENJA.Name = "label1MODELODOBRENJA";
            this.label1MODELODOBRENJA.TabIndex = 1;
            this.label1MODELODOBRENJA.Tag = "labelMODELODOBRENJA";
            this.label1MODELODOBRENJA.Text = "MODELODOBRENJA:";
            this.label1MODELODOBRENJA.StyleSetName = "FieldUltraLabel";
            this.label1MODELODOBRENJA.AutoSize = true;
            this.label1MODELODOBRENJA.Anchor = AnchorStyles.Left;
            this.label1MODELODOBRENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MODELODOBRENJA.Appearance.ForeColor = Color.Black;
            this.label1MODELODOBRENJA.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1MODELODOBRENJA, 0, 11);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1MODELODOBRENJA, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1MODELODOBRENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MODELODOBRENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MODELODOBRENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 0x17);
            this.label1MODELODOBRENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMODELODOBRENJA.Location = point;
            this.textMODELODOBRENJA.Name = "textMODELODOBRENJA";
            this.textMODELODOBRENJA.Tag = "MODELODOBRENJA";
            this.textMODELODOBRENJA.TabIndex = 0;
            this.textMODELODOBRENJA.Anchor = AnchorStyles.Left;
            this.textMODELODOBRENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMODELODOBRENJA.ContextMenu = this.contextMenu1;
            this.textMODELODOBRENJA.ReadOnly = false;
            this.textMODELODOBRENJA.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "MODELODOBRENJA"));
            this.textMODELODOBRENJA.Nullable = true;
            this.textMODELODOBRENJA.MaxLength = 2;
            this.layoutManagerformVIRMANI.Controls.Add(this.textMODELODOBRENJA, 1, 11);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textMODELODOBRENJA, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textMODELODOBRENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMODELODOBRENJA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMODELODOBRENJA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMODELODOBRENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POZIVODOBRENJA.Location = point;
            this.label1POZIVODOBRENJA.Name = "label1POZIVODOBRENJA";
            this.label1POZIVODOBRENJA.TabIndex = 1;
            this.label1POZIVODOBRENJA.Tag = "labelPOZIVODOBRENJA";
            this.label1POZIVODOBRENJA.Text = "POZIVODOBRENJA:";
            this.label1POZIVODOBRENJA.StyleSetName = "FieldUltraLabel";
            this.label1POZIVODOBRENJA.AutoSize = true;
            this.label1POZIVODOBRENJA.Anchor = AnchorStyles.Left;
            this.label1POZIVODOBRENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1POZIVODOBRENJA.Appearance.ForeColor = Color.Black;
            this.label1POZIVODOBRENJA.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1POZIVODOBRENJA, 0, 12);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1POZIVODOBRENJA, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1POZIVODOBRENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POZIVODOBRENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POZIVODOBRENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x88, 0x17);
            this.label1POZIVODOBRENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOZIVODOBRENJA.Location = point;
            this.textPOZIVODOBRENJA.Name = "textPOZIVODOBRENJA";
            this.textPOZIVODOBRENJA.Tag = "POZIVODOBRENJA";
            this.textPOZIVODOBRENJA.TabIndex = 0;
            this.textPOZIVODOBRENJA.Anchor = AnchorStyles.Left;
            this.textPOZIVODOBRENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOZIVODOBRENJA.ContextMenu = this.contextMenu1;
            this.textPOZIVODOBRENJA.ReadOnly = false;
            this.textPOZIVODOBRENJA.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "POZIVODOBRENJA"));
            this.textPOZIVODOBRENJA.Nullable = true;
            this.textPOZIVODOBRENJA.MaxLength = 0x16;
            this.layoutManagerformVIRMANI.Controls.Add(this.textPOZIVODOBRENJA, 1, 12);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textPOZIVODOBRENJA, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textPOZIVODOBRENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOZIVODOBRENJA.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOZIVODOBRENJA.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOZIVODOBRENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SIFRAOPISAPLACANJAVIRMAN.Location = point;
            this.label1SIFRAOPISAPLACANJAVIRMAN.Name = "label1SIFRAOPISAPLACANJAVIRMAN";
            this.label1SIFRAOPISAPLACANJAVIRMAN.TabIndex = 1;
            this.label1SIFRAOPISAPLACANJAVIRMAN.Tag = "labelSIFRAOPISAPLACANJAVIRMAN";
            this.label1SIFRAOPISAPLACANJAVIRMAN.Text = "SIFRAOPISAPLACANJAVIRMAN:";
            this.label1SIFRAOPISAPLACANJAVIRMAN.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAOPISAPLACANJAVIRMAN.AutoSize = true;
            this.label1SIFRAOPISAPLACANJAVIRMAN.Anchor = AnchorStyles.Left;
            this.label1SIFRAOPISAPLACANJAVIRMAN.Appearance.TextVAlign = VAlign.Middle;
            this.label1SIFRAOPISAPLACANJAVIRMAN.Appearance.ForeColor = Color.Black;
            this.label1SIFRAOPISAPLACANJAVIRMAN.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1SIFRAOPISAPLACANJAVIRMAN, 0, 13);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1SIFRAOPISAPLACANJAVIRMAN, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1SIFRAOPISAPLACANJAVIRMAN, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SIFRAOPISAPLACANJAVIRMAN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SIFRAOPISAPLACANJAVIRMAN.MinimumSize = size;
            size = new System.Drawing.Size(0xd6, 0x17);
            this.label1SIFRAOPISAPLACANJAVIRMAN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSIFRAOPISAPLACANJAVIRMAN.Location = point;
            this.textSIFRAOPISAPLACANJAVIRMAN.Name = "textSIFRAOPISAPLACANJAVIRMAN";
            this.textSIFRAOPISAPLACANJAVIRMAN.Tag = "SIFRAOPISAPLACANJAVIRMAN";
            this.textSIFRAOPISAPLACANJAVIRMAN.TabIndex = 0;
            this.textSIFRAOPISAPLACANJAVIRMAN.Anchor = AnchorStyles.Left;
            this.textSIFRAOPISAPLACANJAVIRMAN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSIFRAOPISAPLACANJAVIRMAN.ContextMenu = this.contextMenu1;
            this.textSIFRAOPISAPLACANJAVIRMAN.ReadOnly = false;
            this.textSIFRAOPISAPLACANJAVIRMAN.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "SIFRAOPISAPLACANJAVIRMAN"));
            this.textSIFRAOPISAPLACANJAVIRMAN.Nullable = true;
            this.textSIFRAOPISAPLACANJAVIRMAN.MaxLength = 2;
            this.layoutManagerformVIRMANI.Controls.Add(this.textSIFRAOPISAPLACANJAVIRMAN, 1, 13);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textSIFRAOPISAPLACANJAVIRMAN, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textSIFRAOPISAPLACANJAVIRMAN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSIFRAOPISAPLACANJAVIRMAN.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJAVIRMAN.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJAVIRMAN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISPLACANJAVIRMAN.Location = point;
            this.label1OPISPLACANJAVIRMAN.Name = "label1OPISPLACANJAVIRMAN";
            this.label1OPISPLACANJAVIRMAN.TabIndex = 1;
            this.label1OPISPLACANJAVIRMAN.Tag = "labelOPISPLACANJAVIRMAN";
            this.label1OPISPLACANJAVIRMAN.Text = "OPISPLACANJAVIRMAN:";
            this.label1OPISPLACANJAVIRMAN.StyleSetName = "FieldUltraLabel";
            this.label1OPISPLACANJAVIRMAN.AutoSize = true;
            this.label1OPISPLACANJAVIRMAN.Anchor = AnchorStyles.Left;
            this.label1OPISPLACANJAVIRMAN.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISPLACANJAVIRMAN.Appearance.ForeColor = Color.Black;
            this.label1OPISPLACANJAVIRMAN.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1OPISPLACANJAVIRMAN, 0, 14);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1OPISPLACANJAVIRMAN, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1OPISPLACANJAVIRMAN, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISPLACANJAVIRMAN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISPLACANJAVIRMAN.MinimumSize = size;
            size = new System.Drawing.Size(0xa7, 0x17);
            this.label1OPISPLACANJAVIRMAN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPISPLACANJAVIRMAN.Location = point;
            this.textOPISPLACANJAVIRMAN.Name = "textOPISPLACANJAVIRMAN";
            this.textOPISPLACANJAVIRMAN.Tag = "OPISPLACANJAVIRMAN";
            this.textOPISPLACANJAVIRMAN.TabIndex = 0;
            this.textOPISPLACANJAVIRMAN.Anchor = AnchorStyles.Left;
            this.textOPISPLACANJAVIRMAN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPISPLACANJAVIRMAN.ContextMenu = this.contextMenu1;
            this.textOPISPLACANJAVIRMAN.ReadOnly = false;
            this.textOPISPLACANJAVIRMAN.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "OPISPLACANJAVIRMAN"));
            this.textOPISPLACANJAVIRMAN.Nullable = true;
            this.textOPISPLACANJAVIRMAN.MaxLength = 0x24;
            this.layoutManagerformVIRMANI.Controls.Add(this.textOPISPLACANJAVIRMAN, 1, 14);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textOPISPLACANJAVIRMAN, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textOPISPLACANJAVIRMAN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPISPLACANJAVIRMAN.Margin = padding;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJAVIRMAN.MinimumSize = size;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJAVIRMAN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DATUMVALUTE.Location = point;
            this.label1DATUMVALUTE.Name = "label1DATUMVALUTE";
            this.label1DATUMVALUTE.TabIndex = 1;
            this.label1DATUMVALUTE.Tag = "labelDATUMVALUTE";
            this.label1DATUMVALUTE.Text = "DATUMVALUTE:";
            this.label1DATUMVALUTE.StyleSetName = "FieldUltraLabel";
            this.label1DATUMVALUTE.AutoSize = true;
            this.label1DATUMVALUTE.Anchor = AnchorStyles.Left;
            this.label1DATUMVALUTE.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMVALUTE.Appearance.ForeColor = Color.Black;
            this.label1DATUMVALUTE.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1DATUMVALUTE, 0, 15);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1DATUMVALUTE, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1DATUMVALUTE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DATUMVALUTE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUMVALUTE.MinimumSize = size;
            size = new System.Drawing.Size(0x71, 0x17);
            this.label1DATUMVALUTE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUMVALUTE.Location = point;
            this.datePickerDATUMVALUTE.Name = "datePickerDATUMVALUTE";
            this.datePickerDATUMVALUTE.Tag = "DATUMVALUTE";
            this.datePickerDATUMVALUTE.TabIndex = 0;
            this.datePickerDATUMVALUTE.Anchor = AnchorStyles.Left;
            this.datePickerDATUMVALUTE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUMVALUTE.ContextMenu = this.contextMenu1;
            this.datePickerDATUMVALUTE.Enabled = true;
            this.layoutManagerformVIRMANI.Controls.Add(this.datePickerDATUMVALUTE, 1, 15);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.datePickerDATUMVALUTE, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.datePickerDATUMVALUTE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUMVALUTE.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMVALUTE.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMVALUTE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DATUMPODNOSENJA.Location = point;
            this.label1DATUMPODNOSENJA.Name = "label1DATUMPODNOSENJA";
            this.label1DATUMPODNOSENJA.TabIndex = 1;
            this.label1DATUMPODNOSENJA.Tag = "labelDATUMPODNOSENJA";
            this.label1DATUMPODNOSENJA.Text = "DATUMPODNOSENJA:";
            this.label1DATUMPODNOSENJA.StyleSetName = "FieldUltraLabel";
            this.label1DATUMPODNOSENJA.AutoSize = true;
            this.label1DATUMPODNOSENJA.Anchor = AnchorStyles.Left;
            this.label1DATUMPODNOSENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMPODNOSENJA.Appearance.ForeColor = Color.Black;
            this.label1DATUMPODNOSENJA.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1DATUMPODNOSENJA, 0, 0x10);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1DATUMPODNOSENJA, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1DATUMPODNOSENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DATUMPODNOSENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUMPODNOSENJA.MinimumSize = size;
            size = new System.Drawing.Size(150, 0x17);
            this.label1DATUMPODNOSENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUMPODNOSENJA.Location = point;
            this.datePickerDATUMPODNOSENJA.Name = "datePickerDATUMPODNOSENJA";
            this.datePickerDATUMPODNOSENJA.Tag = "DATUMPODNOSENJA";
            this.datePickerDATUMPODNOSENJA.TabIndex = 0;
            this.datePickerDATUMPODNOSENJA.Anchor = AnchorStyles.Left;
            this.datePickerDATUMPODNOSENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUMPODNOSENJA.ContextMenu = this.contextMenu1;
            this.datePickerDATUMPODNOSENJA.Enabled = true;
            this.layoutManagerformVIRMANI.Controls.Add(this.datePickerDATUMPODNOSENJA, 1, 0x10);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.datePickerDATUMPODNOSENJA, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.datePickerDATUMPODNOSENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUMPODNOSENJA.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMPODNOSENJA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMPODNOSENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IZVORDOKUMENTA.Location = point;
            this.label1IZVORDOKUMENTA.Name = "label1IZVORDOKUMENTA";
            this.label1IZVORDOKUMENTA.TabIndex = 1;
            this.label1IZVORDOKUMENTA.Tag = "labelIZVORDOKUMENTA";
            this.label1IZVORDOKUMENTA.Text = "IZVORDOKUMENTA:";
            this.label1IZVORDOKUMENTA.StyleSetName = "FieldUltraLabel";
            this.label1IZVORDOKUMENTA.AutoSize = true;
            this.label1IZVORDOKUMENTA.Anchor = AnchorStyles.Left;
            this.label1IZVORDOKUMENTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IZVORDOKUMENTA.Appearance.ForeColor = Color.Black;
            this.label1IZVORDOKUMENTA.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1IZVORDOKUMENTA, 0, 0x11);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1IZVORDOKUMENTA, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1IZVORDOKUMENTA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IZVORDOKUMENTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IZVORDOKUMENTA.MinimumSize = size;
            size = new System.Drawing.Size(140, 0x17);
            this.label1IZVORDOKUMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIZVORDOKUMENTA.Location = point;
            this.textIZVORDOKUMENTA.Name = "textIZVORDOKUMENTA";
            this.textIZVORDOKUMENTA.Tag = "IZVORDOKUMENTA";
            this.textIZVORDOKUMENTA.TabIndex = 0;
            this.textIZVORDOKUMENTA.Anchor = AnchorStyles.Left;
            this.textIZVORDOKUMENTA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIZVORDOKUMENTA.ContextMenu = this.contextMenu1;
            this.textIZVORDOKUMENTA.ReadOnly = false;
            this.textIZVORDOKUMENTA.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "IZVORDOKUMENTA"));
            this.textIZVORDOKUMENTA.Nullable = true;
            this.textIZVORDOKUMENTA.MaxLength = 3;
            this.layoutManagerformVIRMANI.Controls.Add(this.textIZVORDOKUMENTA, 1, 0x11);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textIZVORDOKUMENTA, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textIZVORDOKUMENTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIZVORDOKUMENTA.Margin = padding;
            size = new System.Drawing.Size(0x25, 0x16);
            this.textIZVORDOKUMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x25, 0x16);
            this.textIZVORDOKUMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OZNACEN.Location = point;
            this.label1OZNACEN.Name = "label1OZNACEN";
            this.label1OZNACEN.TabIndex = 1;
            this.label1OZNACEN.Tag = "labelOZNACEN";
            this.label1OZNACEN.Text = "OZNACEN:";
            this.label1OZNACEN.StyleSetName = "FieldUltraLabel";
            this.label1OZNACEN.AutoSize = true;
            this.label1OZNACEN.Anchor = AnchorStyles.Left;
            this.label1OZNACEN.Appearance.TextVAlign = VAlign.Middle;
            this.label1OZNACEN.Appearance.ForeColor = Color.Black;
            this.label1OZNACEN.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1OZNACEN, 0, 0x12);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1OZNACEN, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1OZNACEN, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OZNACEN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OZNACEN.MinimumSize = size;
            size = new System.Drawing.Size(80, 0x17);
            this.label1OZNACEN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkOZNACEN.Location = point;
            this.checkOZNACEN.Name = "checkOZNACEN";
            this.checkOZNACEN.Tag = "OZNACEN";
            this.checkOZNACEN.TabIndex = 0;
            this.checkOZNACEN.Anchor = AnchorStyles.Left;
            this.checkOZNACEN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkOZNACEN.ContextMenu = this.contextMenu1;
            this.checkOZNACEN.Enabled = true;
            this.layoutManagerformVIRMANI.Controls.Add(this.checkOZNACEN, 1, 0x12);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.checkOZNACEN, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.checkOZNACEN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkOZNACEN.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkOZNACEN.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkOZNACEN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IZNOS.Location = point;
            this.label1IZNOS.Name = "label1IZNOS";
            this.label1IZNOS.TabIndex = 1;
            this.label1IZNOS.Tag = "labelIZNOS";
            this.label1IZNOS.Text = "IZNOS:";
            this.label1IZNOS.StyleSetName = "FieldUltraLabel";
            this.label1IZNOS.AutoSize = true;
            this.label1IZNOS.Anchor = AnchorStyles.Left;
            this.label1IZNOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1IZNOS.Appearance.ForeColor = Color.Black;
            this.label1IZNOS.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1IZNOS, 0, 0x13);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1IZNOS, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1IZNOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IZNOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IZNOS.MinimumSize = size;
            size = new System.Drawing.Size(60, 0x17);
            this.label1IZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIZNOS.Location = point;
            this.textIZNOS.Name = "textIZNOS";
            this.textIZNOS.Tag = "IZNOS";
            this.textIZNOS.TabIndex = 0;
            this.textIZNOS.Anchor = AnchorStyles.Left;
            this.textIZNOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIZNOS.ContextMenu = this.contextMenu1;
            this.textIZNOS.ReadOnly = false;
            this.textIZNOS.PromptChar = ' ';
            this.textIZNOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIZNOS.DataBindings.Add(new Binding("Value", this.bindingSourceVIRMANI, "IZNOS"));
            this.textIZNOS.NumericType = NumericType.Double;
            this.textIZNOS.MaxValue = 79228162514264337593543950335M;
            this.textIZNOS.MinValue = -79228162514264337593543950335M;
            this.textIZNOS.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textIZNOS.Nullable = true;
            this.layoutManagerformVIRMANI.Controls.Add(this.textIZNOS, 1, 0x13);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textIZNOS, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textIZNOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIZNOS.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAMJENA.Location = point;
            this.label1NAMJENA.Name = "label1NAMJENA";
            this.label1NAMJENA.TabIndex = 1;
            this.label1NAMJENA.Tag = "labelNAMJENA";
            this.label1NAMJENA.Text = "NAMJENA:";
            this.label1NAMJENA.StyleSetName = "FieldUltraLabel";
            this.label1NAMJENA.AutoSize = true;
            this.label1NAMJENA.Anchor = AnchorStyles.Left;
            this.label1NAMJENA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAMJENA.Appearance.ForeColor = Color.Black;
            this.label1NAMJENA.BackColor = Color.Transparent;
            this.layoutManagerformVIRMANI.Controls.Add(this.label1NAMJENA, 0, 20);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.label1NAMJENA, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.label1NAMJENA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAMJENA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAMJENA.MinimumSize = size;
            size = new System.Drawing.Size(80, 0x17);
            this.label1NAMJENA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAMJENA.Location = point;
            this.textNAMJENA.Name = "textNAMJENA";
            this.textNAMJENA.Tag = "NAMJENA";
            this.textNAMJENA.TabIndex = 0;
            this.textNAMJENA.Anchor = AnchorStyles.Left;
            this.textNAMJENA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAMJENA.ReadOnly = false;
            this.textNAMJENA.DataBindings.Add(new Binding("Text", this.bindingSourceVIRMANI, "NAMJENA"));
            this.textNAMJENA.MaxLength = 20;
            this.layoutManagerformVIRMANI.Controls.Add(this.textNAMJENA, 1, 20);
            this.layoutManagerformVIRMANI.SetColumnSpan(this.textNAMJENA, 1);
            this.layoutManagerformVIRMANI.SetRowSpan(this.textNAMJENA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAMJENA.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textNAMJENA.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textNAMJENA.Size = size;
            this.Controls.Add(this.layoutManagerformVIRMANI);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceVIRMANI;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "VIRMANIFormUserControl";
            this.Text = "VIRMANI";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.VIRMANIFormUserControl_Load);
            this.layoutManagerformVIRMANI.ResumeLayout(false);
            this.layoutManagerformVIRMANI.PerformLayout();
            ((ISupportInitialize) this.bindingSourceVIRMANI).EndInit();
            ((ISupportInitialize) this.textSIFRAOBRACUNAVIRMAN).EndInit();
            ((ISupportInitialize) this.textPLA1).EndInit();
            ((ISupportInitialize) this.textPLA2).EndInit();
            ((ISupportInitialize) this.textPLA3).EndInit();
            ((ISupportInitialize) this.textBROJRACUNAPLA).EndInit();
            ((ISupportInitialize) this.textMODELZADUZENJA).EndInit();
            ((ISupportInitialize) this.textPOZIVZADUZENJA).EndInit();
            ((ISupportInitialize) this.textPRI1).EndInit();
            ((ISupportInitialize) this.textPRI2).EndInit();
            ((ISupportInitialize) this.textPRI3).EndInit();
            ((ISupportInitialize) this.textBROJRACUNAPRI).EndInit();
            ((ISupportInitialize) this.textMODELODOBRENJA).EndInit();
            ((ISupportInitialize) this.textPOZIVODOBRENJA).EndInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJAVIRMAN).EndInit();
            ((ISupportInitialize) this.textOPISPLACANJAVIRMAN).EndInit();
            ((ISupportInitialize) this.textIZVORDOKUMENTA).EndInit();
            ((ISupportInitialize) this.textIZNOS).EndInit();
            ((ISupportInitialize) this.textNAMJENA).EndInit();
            this.dsVIRMANIDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.VIRMANIController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceVIRMANI, this.VIRMANIController.WorkItem, this))
            {
                return false;
            }
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void Localize()
        {
            this.label1SIFRAOBRACUNAVIRMAN.Text = StringResources.VIRMANISIFRAOBRACUNAVIRMANDescription;
            this.label1PLA1.Text = StringResources.VIRMANIPLA1Description;
            this.label1PLA2.Text = StringResources.VIRMANIPLA2Description;
            this.label1PLA3.Text = StringResources.VIRMANIPLA3Description;
            this.label1BROJRACUNAPLA.Text = StringResources.VIRMANIBROJRACUNAPLADescription;
            this.label1MODELZADUZENJA.Text = StringResources.VIRMANIMODELZADUZENJADescription;
            this.label1POZIVZADUZENJA.Text = StringResources.VIRMANIPOZIVZADUZENJADescription;
            this.label1PRI1.Text = StringResources.VIRMANIPRI1Description;
            this.label1PRI2.Text = StringResources.VIRMANIPRI2Description;
            this.label1PRI3.Text = StringResources.VIRMANIPRI3Description;
            this.label1BROJRACUNAPRI.Text = StringResources.VIRMANIBROJRACUNAPRIDescription;
            this.label1MODELODOBRENJA.Text = StringResources.VIRMANIMODELODOBRENJADescription;
            this.label1POZIVODOBRENJA.Text = StringResources.VIRMANIPOZIVODOBRENJADescription;
            this.label1SIFRAOPISAPLACANJAVIRMAN.Text = StringResources.VIRMANISIFRAOPISAPLACANJAVIRMANDescription;
            this.label1OPISPLACANJAVIRMAN.Text = StringResources.VIRMANIOPISPLACANJAVIRMANDescription;
            this.label1DATUMVALUTE.Text = StringResources.VIRMANIDATUMVALUTEDescription;
            this.label1DATUMPODNOSENJA.Text = StringResources.VIRMANIDATUMPODNOSENJADescription;
            this.label1IZVORDOKUMENTA.Text = StringResources.VIRMANIIZVORDOKUMENTADescription;
            this.label1OZNACEN.Text = StringResources.VIRMANIOZNACENDescription;
            this.label1IZNOS.Text = StringResources.VIRMANIIZNOSDescription;
            this.label1NAMJENA.Text = StringResources.VIRMANINAMJENADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.VIRMANIController.WorkItem.Items.Contains("VIRMANI|VIRMANI"))
            {
                this.VIRMANIController.WorkItem.Items.Add(this.bindingSourceVIRMANI, "VIRMANI|VIRMANI");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsVIRMANIDataSet1.VIRMANI.Rows[0] != null) && this.m_BaseMethods.IsInsert())
            {
                this.m_Mode = DeklaritMode.Update;
                this.m_BaseMethods.Mode = this.m_Mode;
                this.m_BaseMethods.FormLoadStyle();
            }
        }

        [LocalCommandHandler("Save")]
        public void Save(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.VIRMANIController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.VIRMANIController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.VIRMANIController.Update(this))
            {
                this.VIRMANIController.DataSet = new VIRMANIDataSet();
                DataSetUtil.AddEmptyRow(this.VIRMANIController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.VIRMANIController.DataSet.VIRMANI[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textSIFRAOBRACUNAVIRMAN.Focus();
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

        private void VIRMANIFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.VIRMANIDescription;
            this.errorProvider1.ContainerControl = this;
        }

        protected virtual UltraCheckEditor checkOZNACEN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkOZNACEN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkOZNACEN = value;
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

        protected virtual UltraDateTimeEditor datePickerDATUMPODNOSENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDATUMPODNOSENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDATUMPODNOSENJA = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerDATUMVALUTE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDATUMVALUTE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDATUMVALUTE = value;
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

        protected virtual UltraLabel label1BROJRACUNAPLA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BROJRACUNAPLA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BROJRACUNAPLA = value;
            }
        }

        protected virtual UltraLabel label1BROJRACUNAPRI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BROJRACUNAPRI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BROJRACUNAPRI = value;
            }
        }

        protected virtual UltraLabel label1DATUMPODNOSENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DATUMPODNOSENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DATUMPODNOSENJA = value;
            }
        }

        protected virtual UltraLabel label1DATUMVALUTE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DATUMVALUTE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DATUMVALUTE = value;
            }
        }

        protected virtual UltraLabel label1IZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IZNOS = value;
            }
        }

        protected virtual UltraLabel label1IZVORDOKUMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IZVORDOKUMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IZVORDOKUMENTA = value;
            }
        }

        protected virtual UltraLabel label1MODELODOBRENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MODELODOBRENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MODELODOBRENJA = value;
            }
        }

        protected virtual UltraLabel label1MODELZADUZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MODELZADUZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MODELZADUZENJA = value;
            }
        }

        protected virtual UltraLabel label1NAMJENA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAMJENA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAMJENA = value;
            }
        }

        protected virtual UltraLabel label1OPISPLACANJAVIRMAN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISPLACANJAVIRMAN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISPLACANJAVIRMAN = value;
            }
        }

        protected virtual UltraLabel label1OZNACEN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OZNACEN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OZNACEN = value;
            }
        }

        protected virtual UltraLabel label1PLA1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PLA1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PLA1 = value;
            }
        }

        protected virtual UltraLabel label1PLA2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PLA2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PLA2 = value;
            }
        }

        protected virtual UltraLabel label1PLA3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PLA3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PLA3 = value;
            }
        }

        protected virtual UltraLabel label1POZIVODOBRENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POZIVODOBRENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POZIVODOBRENJA = value;
            }
        }

        protected virtual UltraLabel label1POZIVZADUZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POZIVZADUZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POZIVZADUZENJA = value;
            }
        }

        protected virtual UltraLabel label1PRI1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRI1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRI1 = value;
            }
        }

        protected virtual UltraLabel label1PRI2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRI2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRI2 = value;
            }
        }

        protected virtual UltraLabel label1PRI3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRI3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRI3 = value;
            }
        }

        protected virtual UltraLabel label1SIFRAOBRACUNAVIRMAN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SIFRAOBRACUNAVIRMAN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SIFRAOBRACUNAVIRMAN = value;
            }
        }

        protected virtual UltraLabel label1SIFRAOPISAPLACANJAVIRMAN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SIFRAOPISAPLACANJAVIRMAN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SIFRAOPISAPLACANJAVIRMAN = value;
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

        protected virtual UltraTextEditor textBROJRACUNAPLA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBROJRACUNAPLA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textBROJRACUNAPLA = value;
            }
        }

        protected virtual UltraTextEditor textBROJRACUNAPRI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBROJRACUNAPRI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textBROJRACUNAPRI = value;
            }
        }

        protected virtual UltraNumericEditor textIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIZNOS = value;
            }
        }

        protected virtual UltraTextEditor textIZVORDOKUMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIZVORDOKUMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIZVORDOKUMENTA = value;
            }
        }

        protected virtual UltraTextEditor textMODELODOBRENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMODELODOBRENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMODELODOBRENJA = value;
            }
        }

        protected virtual UltraTextEditor textMODELZADUZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMODELZADUZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMODELZADUZENJA = value;
            }
        }

        protected virtual UltraTextEditor textNAMJENA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAMJENA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAMJENA = value;
            }
        }

        protected virtual UltraTextEditor textOPISPLACANJAVIRMAN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPISPLACANJAVIRMAN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPISPLACANJAVIRMAN = value;
            }
        }

        protected virtual UltraTextEditor textPLA1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPLA1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPLA1 = value;
            }
        }

        protected virtual UltraTextEditor textPLA2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPLA2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPLA2 = value;
            }
        }

        protected virtual UltraTextEditor textPLA3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPLA3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPLA3 = value;
            }
        }

        protected virtual UltraTextEditor textPOZIVODOBRENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOZIVODOBRENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOZIVODOBRENJA = value;
            }
        }

        protected virtual UltraTextEditor textPOZIVZADUZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOZIVZADUZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOZIVZADUZENJA = value;
            }
        }

        protected virtual UltraTextEditor textPRI1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRI1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRI1 = value;
            }
        }

        protected virtual UltraTextEditor textPRI2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRI2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRI2 = value;
            }
        }

        protected virtual UltraTextEditor textPRI3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRI3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRI3 = value;
            }
        }

        protected virtual UltraTextEditor textSIFRAOBRACUNAVIRMAN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSIFRAOBRACUNAVIRMAN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSIFRAOBRACUNAVIRMAN = value;
            }
        }

        protected virtual UltraTextEditor textSIFRAOPISAPLACANJAVIRMAN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSIFRAOPISAPLACANJAVIRMAN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSIFRAOPISAPLACANJAVIRMAN = value;
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.VIRMANIController VIRMANIController { get; set; }
    }
}

