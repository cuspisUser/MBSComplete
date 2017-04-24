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
    public class OBRACUNFormObracunElementiUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkRAZDOBLJESESMIJEPREKLAPATI")]
        private UltraCheckEditor _checkRAZDOBLJESESMIJEPREKLAPATI;
        [AccessedThroughProperty("checkZBRAJASATEUFONDSATI")]
        private UltraCheckEditor _checkZBRAJASATEUFONDSATI;
        [AccessedThroughProperty("comboIDELEMENT")]
        private ELEMENTComboBox _comboIDELEMENT;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("datePickerELEMENTRAZDOBLJEDO")]
        private UltraDateTimeEditor _datePickerELEMENTRAZDOBLJEDO;
        [AccessedThroughProperty("datePickerELEMENTRAZDOBLJEOD")]
        private UltraDateTimeEditor _datePickerELEMENTRAZDOBLJEOD;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1ELEMENTRAZDOBLJEDO")]
        private UltraLabel _label1ELEMENTRAZDOBLJEDO;
        [AccessedThroughProperty("label1ELEMENTRAZDOBLJEOD")]
        private UltraLabel _label1ELEMENTRAZDOBLJEOD;
        [AccessedThroughProperty("label1IDELEMENT")]
        private UltraLabel _label1IDELEMENT;
        [AccessedThroughProperty("label1IDOSNOVAOSIGURANJA")]
        private UltraLabel _label1IDOSNOVAOSIGURANJA;
        [AccessedThroughProperty("label1IDVRSTAELEMENTA")]
        private UltraLabel _label1IDVRSTAELEMENTA;
        [AccessedThroughProperty("label1NAZIVELEMENT")]
        private UltraLabel _label1NAZIVELEMENT;
        [AccessedThroughProperty("label1NAZIVOSNOVAOSIGURANJA")]
        private UltraLabel _label1NAZIVOSNOVAOSIGURANJA;
        [AccessedThroughProperty("label1NAZIVVRSTAELEMENT")]
        private UltraLabel _label1NAZIVVRSTAELEMENT;
        [AccessedThroughProperty("label1OBRIZNOS")]
        private UltraLabel _label1OBRIZNOS;
        [AccessedThroughProperty("label1OBRPOSTOTAK")]
        private UltraLabel _label1OBRPOSTOTAK;
        [AccessedThroughProperty("label1OBRSATI")]
        private UltraLabel _label1OBRSATI;
        [AccessedThroughProperty("label1OBRSATNICA")]
        private UltraLabel _label1OBRSATNICA;
        [AccessedThroughProperty("label1RAZDOBLJESESMIJEPREKLAPATI")]
        private UltraLabel _label1RAZDOBLJESESMIJEPREKLAPATI;
        [AccessedThroughProperty("label1ZBRAJASATEUFONDSATI")]
        private UltraLabel _label1ZBRAJASATEUFONDSATI;
        [AccessedThroughProperty("labelIDOSNOVAOSIGURANJA")]
        private UltraLabel _labelIDOSNOVAOSIGURANJA;
        [AccessedThroughProperty("labelIDVRSTAELEMENTA")]
        private UltraLabel _labelIDVRSTAELEMENTA;
        [AccessedThroughProperty("labelNAZIVELEMENT")]
        private UltraLabel _labelNAZIVELEMENT;
        [AccessedThroughProperty("labelNAZIVOSNOVAOSIGURANJA")]
        private UltraLabel _labelNAZIVOSNOVAOSIGURANJA;
        [AccessedThroughProperty("labelNAZIVVRSTAELEMENT")]
        private UltraLabel _labelNAZIVVRSTAELEMENT;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textOBRIZNOS")]
        private UltraNumericEditor _textOBRIZNOS;
        [AccessedThroughProperty("textOBRPOSTOTAK")]
        private UltraNumericEditor _textOBRPOSTOTAK;
        [AccessedThroughProperty("textOBRSATI")]
        private UltraNumericEditor _textOBRSATI;
        [AccessedThroughProperty("textOBRSATNICA")]
        private UltraNumericEditor _textOBRSATNICA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceObracunElementi;
        private IContainer components = null;
        private OBRACUNDataSet dsOBRACUNDataSet1;
        protected TableLayoutPanel layoutManagerformObracunElementi;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OBRACUNDataSet.ObracunElementiRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "ObracunElementi";
        private string m_FrameworkDescription = StringResources.OBRACUNDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public OBRACUNFormObracunElementiUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("ObracunElementiAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("ObracunElementiAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (OBRACUNDataSet.ObracunElementiRow) ((DataRowView) this.bindingSourceObracunElementi.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsOBRACUNDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceObracunElementi.DataSource = this.OBRACUNController.DataSet;
            this.dsOBRACUNDataSet1 = this.OBRACUNController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ELEMENT", Thread=ThreadOption.UserInterface)]
        public void comboIDELEMENT_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDELEMENT.Fill();
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
            this.bindingSourceObracunElementi.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsOBRACUNDataSet1.Tables["ObracunElementi"]);
            this.bindingSourceObracunElementi.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OBRACUN", this.m_Mode, this.dsOBRACUNDataSet1, this.dsOBRACUNDataSet1.ObracunElementi.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding2 = new Binding("Text", this.bindingSourceObracunElementi, "ELEMENTRAZDOBLJEOD", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding2.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerELEMENTRAZDOBLJEOD.DataBindings["Text"] != null)
            {
                this.datePickerELEMENTRAZDOBLJEOD.DataBindings.Remove(this.datePickerELEMENTRAZDOBLJEOD.DataBindings["Text"]);
            }
            this.datePickerELEMENTRAZDOBLJEOD.DataBindings.Add(binding2);
            Binding binding = new Binding("Text", this.bindingSourceObracunElementi, "ELEMENTRAZDOBLJEDO", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerELEMENTRAZDOBLJEDO.DataBindings["Text"] != null)
            {
                this.datePickerELEMENTRAZDOBLJEDO.DataBindings.Remove(this.datePickerELEMENTRAZDOBLJEDO.DataBindings["Text"]);
            }
            this.datePickerELEMENTRAZDOBLJEDO.DataBindings.Add(binding);
            Binding binding3 = new Binding("CheckState", this.bindingSourceObracunElementi, "RAZDOBLJESESMIJEPREKLAPATI", true);
            binding3.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding3.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkRAZDOBLJESESMIJEPREKLAPATI.DataBindings["CheckState"] != null)
            {
                this.checkRAZDOBLJESESMIJEPREKLAPATI.DataBindings.Remove(this.checkRAZDOBLJESESMIJEPREKLAPATI.DataBindings["CheckState"]);
            }
            this.checkRAZDOBLJESESMIJEPREKLAPATI.DataBindings.Add(binding3);
            this.checkRAZDOBLJESESMIJEPREKLAPATI.ThreeState = true;
            Binding binding4 = new Binding("CheckState", this.bindingSourceObracunElementi, "ZBRAJASATEUFONDSATI", true);
            binding4.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding4.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkZBRAJASATEUFONDSATI.DataBindings["CheckState"] != null)
            {
                this.checkZBRAJASATEUFONDSATI.DataBindings.Remove(this.checkZBRAJASATEUFONDSATI.DataBindings["CheckState"]);
            }
            this.checkZBRAJASATEUFONDSATI.DataBindings.Add(binding4);
            this.checkZBRAJASATEUFONDSATI.ThreeState = true;
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (OBRACUNDataSet.ObracunElementiRow) ((DataRowView) this.bindingSourceObracunElementi.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (OBRACUNDataSet.ObracunElementiRow) ((DataRowView) this.bindingSourceObracunElementi.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(OBRACUNFormObracunElementiUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceObracunElementi = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceObracunElementi).BeginInit();
            this.layoutManagerformObracunElementi = new TableLayoutPanel();
            this.layoutManagerformObracunElementi.SuspendLayout();
            this.layoutManagerformObracunElementi.AutoSize = true;
            this.layoutManagerformObracunElementi.Dock = DockStyle.Fill;
            this.layoutManagerformObracunElementi.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformObracunElementi.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformObracunElementi.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformObracunElementi.Size = size;
            this.layoutManagerformObracunElementi.ColumnCount = 2;
            this.layoutManagerformObracunElementi.RowCount = 15;
            this.layoutManagerformObracunElementi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformObracunElementi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformObracunElementi.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunElementi.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunElementi.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunElementi.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunElementi.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunElementi.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunElementi.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunElementi.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunElementi.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunElementi.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunElementi.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunElementi.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunElementi.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunElementi.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunElementi.RowStyles.Add(new RowStyle());
            this.label1IDELEMENT = new UltraLabel();
            this.comboIDELEMENT = new ELEMENTComboBox();
            this.label1ELEMENTRAZDOBLJEOD = new UltraLabel();
            this.datePickerELEMENTRAZDOBLJEOD = new UltraDateTimeEditor();
            this.label1ELEMENTRAZDOBLJEDO = new UltraLabel();
            this.datePickerELEMENTRAZDOBLJEDO = new UltraDateTimeEditor();
            this.label1IDOSNOVAOSIGURANJA = new UltraLabel();
            this.labelIDOSNOVAOSIGURANJA = new UltraLabel();
            this.label1NAZIVOSNOVAOSIGURANJA = new UltraLabel();
            this.labelNAZIVOSNOVAOSIGURANJA = new UltraLabel();
            this.label1RAZDOBLJESESMIJEPREKLAPATI = new UltraLabel();
            this.checkRAZDOBLJESESMIJEPREKLAPATI = new UltraCheckEditor();
            this.label1OBRSATI = new UltraLabel();
            this.textOBRSATI = new UltraNumericEditor();
            this.label1OBRSATNICA = new UltraLabel();
            this.textOBRSATNICA = new UltraNumericEditor();
            this.label1OBRIZNOS = new UltraLabel();
            this.textOBRIZNOS = new UltraNumericEditor();
            this.label1NAZIVELEMENT = new UltraLabel();
            this.labelNAZIVELEMENT = new UltraLabel();
            this.label1IDVRSTAELEMENTA = new UltraLabel();
            this.labelIDVRSTAELEMENTA = new UltraLabel();
            this.label1NAZIVVRSTAELEMENT = new UltraLabel();
            this.labelNAZIVVRSTAELEMENT = new UltraLabel();
            this.label1OBRPOSTOTAK = new UltraLabel();
            this.textOBRPOSTOTAK = new UltraNumericEditor();
            this.label1ZBRAJASATEUFONDSATI = new UltraLabel();
            this.checkZBRAJASATEUFONDSATI = new UltraCheckEditor();
            ((ISupportInitialize) this.textOBRSATI).BeginInit();
            ((ISupportInitialize) this.textOBRSATNICA).BeginInit();
            ((ISupportInitialize) this.textOBRIZNOS).BeginInit();
            ((ISupportInitialize) this.textOBRPOSTOTAK).BeginInit();
            this.dsOBRACUNDataSet1 = new OBRACUNDataSet();
            this.dsOBRACUNDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsOBRACUNDataSet1.DataSetName = "dsOBRACUN";
            this.dsOBRACUNDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceObracunElementi.DataSource = this.dsOBRACUNDataSet1;
            this.bindingSourceObracunElementi.DataMember = "ObracunElementi";
            ((ISupportInitialize) this.bindingSourceObracunElementi).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDELEMENT.Location = point;
            this.label1IDELEMENT.Name = "label1IDELEMENT";
            this.label1IDELEMENT.TabIndex = 1;
            this.label1IDELEMENT.Tag = "labelIDELEMENT";
            this.label1IDELEMENT.Text = "Šifra elementa:";
            this.label1IDELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1IDELEMENT.AutoSize = true;
            this.label1IDELEMENT.Anchor = AnchorStyles.Left;
            this.label1IDELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDELEMENT.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDELEMENT.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDELEMENT.ImageSize = size;
            this.label1IDELEMENT.Appearance.ForeColor = Color.Black;
            this.label1IDELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformObracunElementi.Controls.Add(this.label1IDELEMENT, 0, 0);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.label1IDELEMENT, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.label1IDELEMENT, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x17);
            this.label1IDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDELEMENT.Location = point;
            this.comboIDELEMENT.Name = "comboIDELEMENT";
            this.comboIDELEMENT.Tag = "IDELEMENT";
            this.comboIDELEMENT.TabIndex = 0;
            this.comboIDELEMENT.Anchor = AnchorStyles.Left;
            this.comboIDELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDELEMENT.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDELEMENT.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDELEMENT.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDELEMENT.Enabled = true;
            this.comboIDELEMENT.DataBindings.Add(new Binding("Value", this.bindingSourceObracunElementi, "IDELEMENT"));
            this.comboIDELEMENT.ShowPictureBox = true;
            this.comboIDELEMENT.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDELEMENT);
            this.comboIDELEMENT.ValueMember = "IDELEMENT";
            this.comboIDELEMENT.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDELEMENT);
            this.layoutManagerformObracunElementi.Controls.Add(this.comboIDELEMENT, 1, 0);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.comboIDELEMENT, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.comboIDELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ELEMENTRAZDOBLJEOD.Location = point;
            this.label1ELEMENTRAZDOBLJEOD.Name = "label1ELEMENTRAZDOBLJEOD";
            this.label1ELEMENTRAZDOBLJEOD.TabIndex = 1;
            this.label1ELEMENTRAZDOBLJEOD.Tag = "labelELEMENTRAZDOBLJEOD";
            this.label1ELEMENTRAZDOBLJEOD.Text = ":";
            this.label1ELEMENTRAZDOBLJEOD.StyleSetName = "FieldUltraLabel";
            this.label1ELEMENTRAZDOBLJEOD.AutoSize = true;
            this.label1ELEMENTRAZDOBLJEOD.Anchor = AnchorStyles.Left;
            this.label1ELEMENTRAZDOBLJEOD.Appearance.TextVAlign = VAlign.Middle;
            this.label1ELEMENTRAZDOBLJEOD.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1ELEMENTRAZDOBLJEOD.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1ELEMENTRAZDOBLJEOD.ImageSize = size;
            this.label1ELEMENTRAZDOBLJEOD.Appearance.ForeColor = Color.Black;
            this.label1ELEMENTRAZDOBLJEOD.BackColor = Color.Transparent;
            this.layoutManagerformObracunElementi.Controls.Add(this.label1ELEMENTRAZDOBLJEOD, 0, 1);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.label1ELEMENTRAZDOBLJEOD, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.label1ELEMENTRAZDOBLJEOD, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ELEMENTRAZDOBLJEOD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ELEMENTRAZDOBLJEOD.MinimumSize = size;
            size = new System.Drawing.Size(0x10, 0x17);
            this.label1ELEMENTRAZDOBLJEOD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerELEMENTRAZDOBLJEOD.Location = point;
            this.datePickerELEMENTRAZDOBLJEOD.Name = "datePickerELEMENTRAZDOBLJEOD";
            this.datePickerELEMENTRAZDOBLJEOD.Tag = "ELEMENTRAZDOBLJEOD";
            this.datePickerELEMENTRAZDOBLJEOD.TabIndex = 0;
            this.datePickerELEMENTRAZDOBLJEOD.Anchor = AnchorStyles.Left;
            this.datePickerELEMENTRAZDOBLJEOD.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerELEMENTRAZDOBLJEOD.Enabled = true;
            this.layoutManagerformObracunElementi.Controls.Add(this.datePickerELEMENTRAZDOBLJEOD, 1, 1);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.datePickerELEMENTRAZDOBLJEOD, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.datePickerELEMENTRAZDOBLJEOD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerELEMENTRAZDOBLJEOD.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerELEMENTRAZDOBLJEOD.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerELEMENTRAZDOBLJEOD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ELEMENTRAZDOBLJEDO.Location = point;
            this.label1ELEMENTRAZDOBLJEDO.Name = "label1ELEMENTRAZDOBLJEDO";
            this.label1ELEMENTRAZDOBLJEDO.TabIndex = 1;
            this.label1ELEMENTRAZDOBLJEDO.Tag = "labelELEMENTRAZDOBLJEDO";
            this.label1ELEMENTRAZDOBLJEDO.Text = ":";
            this.label1ELEMENTRAZDOBLJEDO.StyleSetName = "FieldUltraLabel";
            this.label1ELEMENTRAZDOBLJEDO.AutoSize = true;
            this.label1ELEMENTRAZDOBLJEDO.Anchor = AnchorStyles.Left;
            this.label1ELEMENTRAZDOBLJEDO.Appearance.TextVAlign = VAlign.Middle;
            this.label1ELEMENTRAZDOBLJEDO.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1ELEMENTRAZDOBLJEDO.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1ELEMENTRAZDOBLJEDO.ImageSize = size;
            this.label1ELEMENTRAZDOBLJEDO.Appearance.ForeColor = Color.Black;
            this.label1ELEMENTRAZDOBLJEDO.BackColor = Color.Transparent;
            this.layoutManagerformObracunElementi.Controls.Add(this.label1ELEMENTRAZDOBLJEDO, 0, 2);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.label1ELEMENTRAZDOBLJEDO, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.label1ELEMENTRAZDOBLJEDO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ELEMENTRAZDOBLJEDO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ELEMENTRAZDOBLJEDO.MinimumSize = size;
            size = new System.Drawing.Size(0x10, 0x17);
            this.label1ELEMENTRAZDOBLJEDO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerELEMENTRAZDOBLJEDO.Location = point;
            this.datePickerELEMENTRAZDOBLJEDO.Name = "datePickerELEMENTRAZDOBLJEDO";
            this.datePickerELEMENTRAZDOBLJEDO.Tag = "ELEMENTRAZDOBLJEDO";
            this.datePickerELEMENTRAZDOBLJEDO.TabIndex = 0;
            this.datePickerELEMENTRAZDOBLJEDO.Anchor = AnchorStyles.Left;
            this.datePickerELEMENTRAZDOBLJEDO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerELEMENTRAZDOBLJEDO.Enabled = true;
            this.layoutManagerformObracunElementi.Controls.Add(this.datePickerELEMENTRAZDOBLJEDO, 1, 2);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.datePickerELEMENTRAZDOBLJEDO, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.datePickerELEMENTRAZDOBLJEDO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerELEMENTRAZDOBLJEDO.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerELEMENTRAZDOBLJEDO.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerELEMENTRAZDOBLJEDO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDOSNOVAOSIGURANJA.Location = point;
            this.label1IDOSNOVAOSIGURANJA.Name = "label1IDOSNOVAOSIGURANJA";
            this.label1IDOSNOVAOSIGURANJA.TabIndex = 1;
            this.label1IDOSNOVAOSIGURANJA.Tag = "labelIDOSNOVAOSIGURANJA";
            this.label1IDOSNOVAOSIGURANJA.Text = "Šifra osnove osiguranja:";
            this.label1IDOSNOVAOSIGURANJA.StyleSetName = "FieldUltraLabel";
            this.label1IDOSNOVAOSIGURANJA.AutoSize = true;
            this.label1IDOSNOVAOSIGURANJA.Anchor = AnchorStyles.Left;
            this.label1IDOSNOVAOSIGURANJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOSNOVAOSIGURANJA.Appearance.ForeColor = Color.Black;
            this.label1IDOSNOVAOSIGURANJA.BackColor = Color.Transparent;
            this.layoutManagerformObracunElementi.Controls.Add(this.label1IDOSNOVAOSIGURANJA, 0, 3);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.label1IDOSNOVAOSIGURANJA, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.label1IDOSNOVAOSIGURANJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDOSNOVAOSIGURANJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDOSNOVAOSIGURANJA.MinimumSize = size;
            size = new System.Drawing.Size(0xa5, 0x17);
            this.label1IDOSNOVAOSIGURANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelIDOSNOVAOSIGURANJA.Location = point;
            this.labelIDOSNOVAOSIGURANJA.Name = "labelIDOSNOVAOSIGURANJA";
            this.labelIDOSNOVAOSIGURANJA.Tag = "IDOSNOVAOSIGURANJA";
            this.labelIDOSNOVAOSIGURANJA.TabIndex = 0;
            this.labelIDOSNOVAOSIGURANJA.Anchor = AnchorStyles.Left;
            this.labelIDOSNOVAOSIGURANJA.BackColor = Color.Transparent;
            this.labelIDOSNOVAOSIGURANJA.DataBindings.Add(new Binding("Text", this.bindingSourceObracunElementi, "IDOSNOVAOSIGURANJA"));
            this.labelIDOSNOVAOSIGURANJA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunElementi.Controls.Add(this.labelIDOSNOVAOSIGURANJA, 1, 3);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.labelIDOSNOVAOSIGURANJA, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.labelIDOSNOVAOSIGURANJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelIDOSNOVAOSIGURANJA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.labelIDOSNOVAOSIGURANJA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.labelIDOSNOVAOSIGURANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVOSNOVAOSIGURANJA.Location = point;
            this.label1NAZIVOSNOVAOSIGURANJA.Name = "label1NAZIVOSNOVAOSIGURANJA";
            this.label1NAZIVOSNOVAOSIGURANJA.TabIndex = 1;
            this.label1NAZIVOSNOVAOSIGURANJA.Tag = "labelNAZIVOSNOVAOSIGURANJA";
            this.label1NAZIVOSNOVAOSIGURANJA.Text = "Naziv osnove osiguranja:";
            this.label1NAZIVOSNOVAOSIGURANJA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVOSNOVAOSIGURANJA.AutoSize = true;
            this.label1NAZIVOSNOVAOSIGURANJA.Anchor = AnchorStyles.Left;
            this.label1NAZIVOSNOVAOSIGURANJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVOSNOVAOSIGURANJA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVOSNOVAOSIGURANJA.BackColor = Color.Transparent;
            this.layoutManagerformObracunElementi.Controls.Add(this.label1NAZIVOSNOVAOSIGURANJA, 0, 4);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.label1NAZIVOSNOVAOSIGURANJA, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.label1NAZIVOSNOVAOSIGURANJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVOSNOVAOSIGURANJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVOSNOVAOSIGURANJA.MinimumSize = size;
            size = new System.Drawing.Size(0xab, 0x17);
            this.label1NAZIVOSNOVAOSIGURANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVOSNOVAOSIGURANJA.Location = point;
            this.labelNAZIVOSNOVAOSIGURANJA.Name = "labelNAZIVOSNOVAOSIGURANJA";
            this.labelNAZIVOSNOVAOSIGURANJA.Tag = "NAZIVOSNOVAOSIGURANJA";
            this.labelNAZIVOSNOVAOSIGURANJA.TabIndex = 0;
            this.labelNAZIVOSNOVAOSIGURANJA.Anchor = AnchorStyles.Left;
            this.labelNAZIVOSNOVAOSIGURANJA.BackColor = Color.Transparent;
            this.labelNAZIVOSNOVAOSIGURANJA.DataBindings.Add(new Binding("Text", this.bindingSourceObracunElementi, "NAZIVOSNOVAOSIGURANJA"));
            this.labelNAZIVOSNOVAOSIGURANJA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunElementi.Controls.Add(this.labelNAZIVOSNOVAOSIGURANJA, 1, 4);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.labelNAZIVOSNOVAOSIGURANJA, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.labelNAZIVOSNOVAOSIGURANJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVOSNOVAOSIGURANJA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVOSNOVAOSIGURANJA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVOSNOVAOSIGURANJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Location = point;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Name = "label1RAZDOBLJESESMIJEPREKLAPATI";
            this.label1RAZDOBLJESESMIJEPREKLAPATI.TabIndex = 1;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Tag = "labelRAZDOBLJESESMIJEPREKLAPATI";
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Text = "Razdoblje se smije preklapati:";
            this.label1RAZDOBLJESESMIJEPREKLAPATI.StyleSetName = "FieldUltraLabel";
            this.label1RAZDOBLJESESMIJEPREKLAPATI.AutoSize = true;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Anchor = AnchorStyles.Left;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Appearance.ForeColor = Color.Black;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.BackColor = Color.Transparent;
            this.layoutManagerformObracunElementi.Controls.Add(this.label1RAZDOBLJESESMIJEPREKLAPATI, 0, 5);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.label1RAZDOBLJESESMIJEPREKLAPATI, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.label1RAZDOBLJESESMIJEPREKLAPATI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAZDOBLJESESMIJEPREKLAPATI.MinimumSize = size;
            size = new System.Drawing.Size(0xca, 0x17);
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Location = point;
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Name = "checkRAZDOBLJESESMIJEPREKLAPATI";
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Tag = "RAZDOBLJESESMIJEPREKLAPATI";
            this.checkRAZDOBLJESESMIJEPREKLAPATI.TabIndex = 0;
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Anchor = AnchorStyles.Left;
            this.checkRAZDOBLJESESMIJEPREKLAPATI.BackColor = System.Drawing.SystemColors.ControlLight;
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Enabled = false;
            this.layoutManagerformObracunElementi.Controls.Add(this.checkRAZDOBLJESESMIJEPREKLAPATI, 1, 5);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.checkRAZDOBLJESESMIJEPREKLAPATI, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.checkRAZDOBLJESESMIJEPREKLAPATI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkRAZDOBLJESESMIJEPREKLAPATI.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkRAZDOBLJESESMIJEPREKLAPATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRSATI.Location = point;
            this.label1OBRSATI.Name = "label1OBRSATI";
            this.label1OBRSATI.TabIndex = 1;
            this.label1OBRSATI.Tag = "labelOBRSATI";
            this.label1OBRSATI.Text = ":";
            this.label1OBRSATI.StyleSetName = "FieldUltraLabel";
            this.label1OBRSATI.AutoSize = true;
            this.label1OBRSATI.Anchor = AnchorStyles.Left;
            this.label1OBRSATI.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRSATI.Appearance.ForeColor = Color.Black;
            this.label1OBRSATI.BackColor = Color.Transparent;
            this.layoutManagerformObracunElementi.Controls.Add(this.label1OBRSATI, 0, 6);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.label1OBRSATI, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.label1OBRSATI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRSATI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRSATI.MinimumSize = size;
            size = new System.Drawing.Size(0x13, 0x17);
            this.label1OBRSATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBRSATI.Location = point;
            this.textOBRSATI.Name = "textOBRSATI";
            this.textOBRSATI.Tag = "OBRSATI";
            this.textOBRSATI.TabIndex = 0;
            this.textOBRSATI.Anchor = AnchorStyles.Left;
            this.textOBRSATI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBRSATI.ReadOnly = false;
            this.textOBRSATI.PromptChar = ' ';
            this.textOBRSATI.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOBRSATI.DataBindings.Add(new Binding("Value", this.bindingSourceObracunElementi, "OBRSATI"));
            this.textOBRSATI.NumericType = NumericType.Double;
            this.textOBRSATI.MaxValue = 79228162514264337593543950335M;
            this.textOBRSATI.MinValue = -79228162514264337593543950335M;
            this.textOBRSATI.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformObracunElementi.Controls.Add(this.textOBRSATI, 1, 6);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.textOBRSATI, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.textOBRSATI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBRSATI.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textOBRSATI.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textOBRSATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRSATNICA.Location = point;
            this.label1OBRSATNICA.Name = "label1OBRSATNICA";
            this.label1OBRSATNICA.TabIndex = 1;
            this.label1OBRSATNICA.Tag = "labelOBRSATNICA";
            this.label1OBRSATNICA.Text = ":";
            this.label1OBRSATNICA.StyleSetName = "FieldUltraLabel";
            this.label1OBRSATNICA.AutoSize = true;
            this.label1OBRSATNICA.Anchor = AnchorStyles.Left;
            this.label1OBRSATNICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRSATNICA.Appearance.ForeColor = Color.Black;
            this.label1OBRSATNICA.BackColor = Color.Transparent;
            this.layoutManagerformObracunElementi.Controls.Add(this.label1OBRSATNICA, 0, 7);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.label1OBRSATNICA, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.label1OBRSATNICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRSATNICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRSATNICA.MinimumSize = size;
            size = new System.Drawing.Size(0x13, 0x17);
            this.label1OBRSATNICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBRSATNICA.Location = point;
            this.textOBRSATNICA.Name = "textOBRSATNICA";
            this.textOBRSATNICA.Tag = "OBRSATNICA";
            this.textOBRSATNICA.TabIndex = 0;
            this.textOBRSATNICA.Anchor = AnchorStyles.Left;
            this.textOBRSATNICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBRSATNICA.ReadOnly = false;
            this.textOBRSATNICA.PromptChar = ' ';
            this.textOBRSATNICA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOBRSATNICA.DataBindings.Add(new Binding("Value", this.bindingSourceObracunElementi, "OBRSATNICA"));
            this.textOBRSATNICA.NumericType = NumericType.Double;
            this.textOBRSATNICA.MaxValue = 79228162514264337593543950335M;
            this.textOBRSATNICA.MinValue = -79228162514264337593543950335M;
            this.textOBRSATNICA.MaskInput = "{LOC}-nnnn.nnnnnnnn";
            this.layoutManagerformObracunElementi.Controls.Add(this.textOBRSATNICA, 1, 7);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.textOBRSATNICA, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.textOBRSATNICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBRSATNICA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRSATNICA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRSATNICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRIZNOS.Location = point;
            this.label1OBRIZNOS.Name = "label1OBRIZNOS";
            this.label1OBRIZNOS.TabIndex = 1;
            this.label1OBRIZNOS.Tag = "labelOBRIZNOS";
            this.label1OBRIZNOS.Text = "OBRIZNOS:";
            this.label1OBRIZNOS.StyleSetName = "FieldUltraLabel";
            this.label1OBRIZNOS.AutoSize = true;
            this.label1OBRIZNOS.Anchor = AnchorStyles.Left;
            this.label1OBRIZNOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRIZNOS.Appearance.ForeColor = Color.Black;
            this.label1OBRIZNOS.BackColor = Color.Transparent;
            this.layoutManagerformObracunElementi.Controls.Add(this.label1OBRIZNOS, 0, 8);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.label1OBRIZNOS, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.label1OBRIZNOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRIZNOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x17);
            this.label1OBRIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBRIZNOS.Location = point;
            this.textOBRIZNOS.Name = "textOBRIZNOS";
            this.textOBRIZNOS.Tag = "OBRIZNOS";
            this.textOBRIZNOS.TabIndex = 0;
            this.textOBRIZNOS.Anchor = AnchorStyles.Left;
            this.textOBRIZNOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBRIZNOS.ReadOnly = false;
            this.textOBRIZNOS.PromptChar = ' ';
            this.textOBRIZNOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOBRIZNOS.DataBindings.Add(new Binding("Value", this.bindingSourceObracunElementi, "OBRIZNOS"));
            this.textOBRIZNOS.NumericType = NumericType.Double;
            this.textOBRIZNOS.MaxValue = 79228162514264337593543950335M;
            this.textOBRIZNOS.MinValue = -79228162514264337593543950335M;
            this.textOBRIZNOS.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformObracunElementi.Controls.Add(this.textOBRIZNOS, 1, 8);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.textOBRIZNOS, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.textOBRIZNOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBRIZNOS.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVELEMENT.Location = point;
            this.label1NAZIVELEMENT.Name = "label1NAZIVELEMENT";
            this.label1NAZIVELEMENT.TabIndex = 1;
            this.label1NAZIVELEMENT.Tag = "labelNAZIVELEMENT";
            this.label1NAZIVELEMENT.Text = "Naziv elementa:";
            this.label1NAZIVELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVELEMENT.AutoSize = true;
            this.label1NAZIVELEMENT.Anchor = AnchorStyles.Left;
            this.label1NAZIVELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVELEMENT.Appearance.ForeColor = Color.Black;
            this.label1NAZIVELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformObracunElementi.Controls.Add(this.label1NAZIVELEMENT, 0, 9);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.label1NAZIVELEMENT, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.label1NAZIVELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x73, 0x17);
            this.label1NAZIVELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVELEMENT.Location = point;
            this.labelNAZIVELEMENT.Name = "labelNAZIVELEMENT";
            this.labelNAZIVELEMENT.Tag = "NAZIVELEMENT";
            this.labelNAZIVELEMENT.TabIndex = 0;
            this.labelNAZIVELEMENT.Anchor = AnchorStyles.Left;
            this.labelNAZIVELEMENT.BackColor = Color.Transparent;
            this.labelNAZIVELEMENT.DataBindings.Add(new Binding("Text", this.bindingSourceObracunElementi, "NAZIVELEMENT"));
            this.labelNAZIVELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunElementi.Controls.Add(this.labelNAZIVELEMENT, 1, 9);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.labelNAZIVELEMENT, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.labelNAZIVELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDVRSTAELEMENTA.Location = point;
            this.label1IDVRSTAELEMENTA.Name = "label1IDVRSTAELEMENTA";
            this.label1IDVRSTAELEMENTA.TabIndex = 1;
            this.label1IDVRSTAELEMENTA.Tag = "labelIDVRSTAELEMENTA";
            this.label1IDVRSTAELEMENTA.Text = "Šifra Vrste elementa:";
            this.label1IDVRSTAELEMENTA.StyleSetName = "FieldUltraLabel";
            this.label1IDVRSTAELEMENTA.AutoSize = true;
            this.label1IDVRSTAELEMENTA.Anchor = AnchorStyles.Left;
            this.label1IDVRSTAELEMENTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDVRSTAELEMENTA.Appearance.ForeColor = Color.Black;
            this.label1IDVRSTAELEMENTA.BackColor = Color.Transparent;
            this.layoutManagerformObracunElementi.Controls.Add(this.label1IDVRSTAELEMENTA, 0, 10);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.label1IDVRSTAELEMENTA, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.label1IDVRSTAELEMENTA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDVRSTAELEMENTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDVRSTAELEMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x92, 0x17);
            this.label1IDVRSTAELEMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelIDVRSTAELEMENTA.Location = point;
            this.labelIDVRSTAELEMENTA.Name = "labelIDVRSTAELEMENTA";
            this.labelIDVRSTAELEMENTA.Tag = "IDVRSTAELEMENTA";
            this.labelIDVRSTAELEMENTA.TabIndex = 0;
            this.labelIDVRSTAELEMENTA.Anchor = AnchorStyles.Left;
            this.labelIDVRSTAELEMENTA.BackColor = Color.Transparent;
            this.labelIDVRSTAELEMENTA.Appearance.TextHAlign = HAlign.Left;
            this.labelIDVRSTAELEMENTA.DataBindings.Add(new Binding("Text", this.bindingSourceObracunElementi, "IDVRSTAELEMENTA"));
            this.labelIDVRSTAELEMENTA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunElementi.Controls.Add(this.labelIDVRSTAELEMENTA, 1, 10);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.labelIDVRSTAELEMENTA, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.labelIDVRSTAELEMENTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelIDVRSTAELEMENTA.Margin = padding;
            size = new System.Drawing.Size(0x2d, 0x16);
            this.labelIDVRSTAELEMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x16);
            this.labelIDVRSTAELEMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVVRSTAELEMENT.Location = point;
            this.label1NAZIVVRSTAELEMENT.Name = "label1NAZIVVRSTAELEMENT";
            this.label1NAZIVVRSTAELEMENT.TabIndex = 1;
            this.label1NAZIVVRSTAELEMENT.Tag = "labelNAZIVVRSTAELEMENT";
            this.label1NAZIVVRSTAELEMENT.Text = "Naziv vrste elementa:";
            this.label1NAZIVVRSTAELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVVRSTAELEMENT.AutoSize = true;
            this.label1NAZIVVRSTAELEMENT.Anchor = AnchorStyles.Left;
            this.label1NAZIVVRSTAELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVVRSTAELEMENT.Appearance.ForeColor = Color.Black;
            this.label1NAZIVVRSTAELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformObracunElementi.Controls.Add(this.label1NAZIVVRSTAELEMENT, 0, 11);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.label1NAZIVVRSTAELEMENT, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.label1NAZIVVRSTAELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVVRSTAELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVVRSTAELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(150, 0x17);
            this.label1NAZIVVRSTAELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVVRSTAELEMENT.Location = point;
            this.labelNAZIVVRSTAELEMENT.Name = "labelNAZIVVRSTAELEMENT";
            this.labelNAZIVVRSTAELEMENT.Tag = "NAZIVVRSTAELEMENT";
            this.labelNAZIVVRSTAELEMENT.TabIndex = 0;
            this.labelNAZIVVRSTAELEMENT.Anchor = AnchorStyles.Left;
            this.labelNAZIVVRSTAELEMENT.BackColor = Color.Transparent;
            this.labelNAZIVVRSTAELEMENT.DataBindings.Add(new Binding("Text", this.bindingSourceObracunElementi, "NAZIVVRSTAELEMENT"));
            this.labelNAZIVVRSTAELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunElementi.Controls.Add(this.labelNAZIVVRSTAELEMENT, 1, 11);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.labelNAZIVVRSTAELEMENT, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.labelNAZIVVRSTAELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVVRSTAELEMENT.Margin = padding;
            size = new System.Drawing.Size(0xbf, 0x16);
            this.labelNAZIVVRSTAELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0xbf, 0x16);
            this.labelNAZIVVRSTAELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRPOSTOTAK.Location = point;
            this.label1OBRPOSTOTAK.Name = "label1OBRPOSTOTAK";
            this.label1OBRPOSTOTAK.TabIndex = 1;
            this.label1OBRPOSTOTAK.Tag = "labelOBRPOSTOTAK";
            this.label1OBRPOSTOTAK.Text = ":";
            this.label1OBRPOSTOTAK.StyleSetName = "FieldUltraLabel";
            this.label1OBRPOSTOTAK.AutoSize = true;
            this.label1OBRPOSTOTAK.Anchor = AnchorStyles.Left;
            this.label1OBRPOSTOTAK.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRPOSTOTAK.Appearance.ForeColor = Color.Black;
            this.label1OBRPOSTOTAK.BackColor = Color.Transparent;
            this.layoutManagerformObracunElementi.Controls.Add(this.label1OBRPOSTOTAK, 0, 12);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.label1OBRPOSTOTAK, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.label1OBRPOSTOTAK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRPOSTOTAK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRPOSTOTAK.MinimumSize = size;
            size = new System.Drawing.Size(0x13, 0x17);
            this.label1OBRPOSTOTAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBRPOSTOTAK.Location = point;
            this.textOBRPOSTOTAK.Name = "textOBRPOSTOTAK";
            this.textOBRPOSTOTAK.Tag = "OBRPOSTOTAK";
            this.textOBRPOSTOTAK.TabIndex = 0;
            this.textOBRPOSTOTAK.Anchor = AnchorStyles.Left;
            this.textOBRPOSTOTAK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBRPOSTOTAK.ReadOnly = false;
            this.textOBRPOSTOTAK.PromptChar = ' ';
            this.textOBRPOSTOTAK.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOBRPOSTOTAK.DataBindings.Add(new Binding("Value", this.bindingSourceObracunElementi, "OBRPOSTOTAK"));
            this.textOBRPOSTOTAK.NumericType = NumericType.Double;
            this.textOBRPOSTOTAK.MaxValue = 79228162514264337593543950335M;
            this.textOBRPOSTOTAK.MinValue = -79228162514264337593543950335M;
            this.textOBRPOSTOTAK.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformObracunElementi.Controls.Add(this.textOBRPOSTOTAK, 1, 12);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.textOBRPOSTOTAK, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.textOBRPOSTOTAK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBRPOSTOTAK.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textOBRPOSTOTAK.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textOBRPOSTOTAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZBRAJASATEUFONDSATI.Location = point;
            this.label1ZBRAJASATEUFONDSATI.Name = "label1ZBRAJASATEUFONDSATI";
            this.label1ZBRAJASATEUFONDSATI.TabIndex = 1;
            this.label1ZBRAJASATEUFONDSATI.Tag = "labelZBRAJASATEUFONDSATI";
            this.label1ZBRAJASATEUFONDSATI.Text = "Sati ulaze u fond sati:";
            this.label1ZBRAJASATEUFONDSATI.StyleSetName = "FieldUltraLabel";
            this.label1ZBRAJASATEUFONDSATI.AutoSize = true;
            this.label1ZBRAJASATEUFONDSATI.Anchor = AnchorStyles.Left;
            this.label1ZBRAJASATEUFONDSATI.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZBRAJASATEUFONDSATI.Appearance.ForeColor = Color.Black;
            this.label1ZBRAJASATEUFONDSATI.BackColor = Color.Transparent;
            this.layoutManagerformObracunElementi.Controls.Add(this.label1ZBRAJASATEUFONDSATI, 0, 13);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.label1ZBRAJASATEUFONDSATI, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.label1ZBRAJASATEUFONDSATI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZBRAJASATEUFONDSATI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZBRAJASATEUFONDSATI.MinimumSize = size;
            size = new System.Drawing.Size(0x95, 0x17);
            this.label1ZBRAJASATEUFONDSATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkZBRAJASATEUFONDSATI.Location = point;
            this.checkZBRAJASATEUFONDSATI.Name = "checkZBRAJASATEUFONDSATI";
            this.checkZBRAJASATEUFONDSATI.Tag = "ZBRAJASATEUFONDSATI";
            this.checkZBRAJASATEUFONDSATI.TabIndex = 0;
            this.checkZBRAJASATEUFONDSATI.Anchor = AnchorStyles.Left;
            this.checkZBRAJASATEUFONDSATI.BackColor = System.Drawing.SystemColors.ControlLight;
            this.checkZBRAJASATEUFONDSATI.Enabled = false;
            this.layoutManagerformObracunElementi.Controls.Add(this.checkZBRAJASATEUFONDSATI, 1, 13);
            this.layoutManagerformObracunElementi.SetColumnSpan(this.checkZBRAJASATEUFONDSATI, 1);
            this.layoutManagerformObracunElementi.SetRowSpan(this.checkZBRAJASATEUFONDSATI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkZBRAJASATEUFONDSATI.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkZBRAJASATEUFONDSATI.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkZBRAJASATEUFONDSATI.Size = size;
            this.Controls.Add(this.layoutManagerformObracunElementi);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceObracunElementi;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "OBRACUNFormObracunElementiUserControl";
            this.Text = " ObracunElementi";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OBRACUNFormUserControl_Load);
            this.layoutManagerformObracunElementi.ResumeLayout(false);
            this.layoutManagerformObracunElementi.PerformLayout();
            ((ISupportInitialize) this.bindingSourceObracunElementi).EndInit();
            ((ISupportInitialize) this.textOBRSATI).EndInit();
            ((ISupportInitialize) this.textOBRSATNICA).EndInit();
            ((ISupportInitialize) this.textOBRIZNOS).EndInit();
            ((ISupportInitialize) this.textOBRPOSTOTAK).EndInit();
            this.dsOBRACUNDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OBRACUNController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceObracunElementi, this.OBRACUNController.WorkItem, this))
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
            this.label1IDELEMENT.Text = StringResources.OBRACUNIDELEMENTDescription;
            this.label1ELEMENTRAZDOBLJEOD.Text = StringResources.OBRACUNELEMENTRAZDOBLJEODDescription;
            this.label1ELEMENTRAZDOBLJEDO.Text = StringResources.OBRACUNELEMENTRAZDOBLJEDODescription;
            this.label1IDOSNOVAOSIGURANJA.Text = StringResources.OBRACUNIDOSNOVAOSIGURANJADescription;
            this.label1NAZIVOSNOVAOSIGURANJA.Text = StringResources.OBRACUNNAZIVOSNOVAOSIGURANJADescription;
            this.label1RAZDOBLJESESMIJEPREKLAPATI.Text = StringResources.OBRACUNRAZDOBLJESESMIJEPREKLAPATIDescription;
            this.label1OBRSATI.Text = StringResources.OBRACUNOBRSATIDescription;
            this.label1OBRSATNICA.Text = StringResources.OBRACUNOBRSATNICADescription;
            this.label1OBRIZNOS.Text = StringResources.OBRACUNOBRIZNOSDescription;
            this.label1NAZIVELEMENT.Text = StringResources.OBRACUNNAZIVELEMENTDescription;
            this.label1IDVRSTAELEMENTA.Text = StringResources.OBRACUNIDVRSTAELEMENTADescription;
            this.label1NAZIVVRSTAELEMENT.Text = StringResources.OBRACUNNAZIVVRSTAELEMENTDescription;
            this.label1OBRPOSTOTAK.Text = StringResources.OBRACUNOBRPOSTOTAKDescription;
            this.label1ZBRAJASATEUFONDSATI.Text = StringResources.OBRACUNZBRAJASATEUFONDSATIDescription;
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
            this.Text = StringResources.OBRACUNObracunElementiLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void PictureBoxClickedIDELEMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ELEMENT", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.OBRACUNController.WorkItem.Items.Contains("ObracunElementi|ObracunElementi"))
            {
                this.OBRACUNController.WorkItem.Items.Add(this.bindingSourceObracunElementi, "ObracunElementi|ObracunElementi");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("ObracunElementiSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedIDELEMENT(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDELEMENT.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDELEMENT.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceObracunElementi.Current).Row["IDELEMENT"] = RuntimeHelpers.GetObjectValue(row["IDELEMENT"]);
                    ((DataRowView) this.bindingSourceObracunElementi.Current).Row["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(row["NAZIVELEMENT"]);
                    ((DataRowView) this.bindingSourceObracunElementi.Current).Row["IDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(row["IDVRSTAELEMENTA"]);
                    ((DataRowView) this.bindingSourceObracunElementi.Current).Row["ZBRAJASATEUFONDSATI"] = RuntimeHelpers.GetObjectValue(row["ZBRAJASATEUFONDSATI"]);
                    ((DataRowView) this.bindingSourceObracunElementi.Current).Row["IDOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(row["IDOSNOVAOSIGURANJA"]);
                    ((DataRowView) this.bindingSourceObracunElementi.Current).Row["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(row["NAZIVVRSTAELEMENT"]);
                    ((DataRowView) this.bindingSourceObracunElementi.Current).Row["NAZIVOSNOVAOSIGURANJA"] = RuntimeHelpers.GetObjectValue(row["NAZIVOSNOVAOSIGURANJA"]);
                    ((DataRowView) this.bindingSourceObracunElementi.Current).Row["RAZDOBLJESESMIJEPREKLAPATI"] = RuntimeHelpers.GetObjectValue(row["RAZDOBLJESESMIJEPREKLAPATI"]);
                    this.bindingSourceObracunElementi.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboIDELEMENT.Focus();
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

        [LocalCommandHandler("ViewRSMA")]
        public void ViewRSMAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OBRACUNController.ViewRSMA(this.m_CurrentRow);
            }
        }

        protected virtual UltraCheckEditor checkRAZDOBLJESESMIJEPREKLAPATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkRAZDOBLJESESMIJEPREKLAPATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkRAZDOBLJESESMIJEPREKLAPATI = value;
            }
        }

        protected virtual UltraCheckEditor checkZBRAJASATEUFONDSATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkZBRAJASATEUFONDSATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkZBRAJASATEUFONDSATI = value;
            }
        }

        protected virtual ELEMENTComboBox comboIDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDELEMENT = value;
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

        protected virtual UltraDateTimeEditor datePickerELEMENTRAZDOBLJEDO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerELEMENTRAZDOBLJEDO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerELEMENTRAZDOBLJEDO = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerELEMENTRAZDOBLJEOD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerELEMENTRAZDOBLJEOD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerELEMENTRAZDOBLJEOD = value;
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

        protected virtual UltraLabel label1ELEMENTRAZDOBLJEDO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ELEMENTRAZDOBLJEDO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ELEMENTRAZDOBLJEDO = value;
            }
        }

        protected virtual UltraLabel label1ELEMENTRAZDOBLJEOD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ELEMENTRAZDOBLJEOD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ELEMENTRAZDOBLJEOD = value;
            }
        }

        protected virtual UltraLabel label1IDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDELEMENT = value;
            }
        }

        protected virtual UltraLabel label1IDOSNOVAOSIGURANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDOSNOVAOSIGURANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDOSNOVAOSIGURANJA = value;
            }
        }

        protected virtual UltraLabel label1IDVRSTAELEMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDVRSTAELEMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDVRSTAELEMENTA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVELEMENT = value;
            }
        }

        protected virtual UltraLabel label1NAZIVOSNOVAOSIGURANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVOSNOVAOSIGURANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVOSNOVAOSIGURANJA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVVRSTAELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVVRSTAELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVVRSTAELEMENT = value;
            }
        }

        protected virtual UltraLabel label1OBRIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRIZNOS = value;
            }
        }

        protected virtual UltraLabel label1OBRPOSTOTAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRPOSTOTAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRPOSTOTAK = value;
            }
        }

        protected virtual UltraLabel label1OBRSATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRSATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRSATI = value;
            }
        }

        protected virtual UltraLabel label1OBRSATNICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRSATNICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRSATNICA = value;
            }
        }

        protected virtual UltraLabel label1RAZDOBLJESESMIJEPREKLAPATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAZDOBLJESESMIJEPREKLAPATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAZDOBLJESESMIJEPREKLAPATI = value;
            }
        }

        protected virtual UltraLabel label1ZBRAJASATEUFONDSATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZBRAJASATEUFONDSATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZBRAJASATEUFONDSATI = value;
            }
        }

        protected virtual UltraLabel labelIDOSNOVAOSIGURANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelIDOSNOVAOSIGURANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelIDOSNOVAOSIGURANJA = value;
            }
        }

        protected virtual UltraLabel labelIDVRSTAELEMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelIDVRSTAELEMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelIDVRSTAELEMENTA = value;
            }
        }

        protected virtual UltraLabel labelNAZIVELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVELEMENT = value;
            }
        }

        protected virtual UltraLabel labelNAZIVOSNOVAOSIGURANJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVOSNOVAOSIGURANJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVOSNOVAOSIGURANJA = value;
            }
        }

        protected virtual UltraLabel labelNAZIVVRSTAELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVVRSTAELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVVRSTAELEMENT = value;
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

        protected virtual UltraNumericEditor textOBRIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRIZNOS = value;
            }
        }

        protected virtual UltraNumericEditor textOBRPOSTOTAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRPOSTOTAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRPOSTOTAK = value;
            }
        }

        protected virtual UltraNumericEditor textOBRSATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRSATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRSATI = value;
            }
        }

        protected virtual UltraNumericEditor textOBRSATNICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRSATNICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRSATNICA = value;
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

