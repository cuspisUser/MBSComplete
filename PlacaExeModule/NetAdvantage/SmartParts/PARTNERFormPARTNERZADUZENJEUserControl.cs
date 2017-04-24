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
    public class PARTNERFormPARTNERZADUZENJEUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkAKTIVNO")]
        private UltraCheckEditor _checkAKTIVNO;
        [AccessedThroughProperty("comboIDPROIZVOD")]
        private PROIZVODComboBox _comboIDPROIZVOD;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("datePickerDATUMUGOVORA")]
        private UltraDateTimeEditor _datePickerDATUMUGOVORA;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1AKTIVNO")]
        private UltraLabel _label1AKTIVNO;
        [AccessedThroughProperty("label1CIJENA")]
        private UltraLabel _label1CIJENA;
        [AccessedThroughProperty("label1CIJENAZADUZENJA")]
        private UltraLabel _label1CIJENAZADUZENJA;
        [AccessedThroughProperty("label1CIJENAZAFAKTURU")]
        private UltraLabel _label1CIJENAZAFAKTURU;
        [AccessedThroughProperty("label1DATUMUGOVORA")]
        private UltraLabel _label1DATUMUGOVORA;
        [AccessedThroughProperty("label1IDPROIZVOD")]
        private UltraLabel _label1IDPROIZVOD;
        [AccessedThroughProperty("label1IZNOSRABATAZADUZENJE")]
        private UltraLabel _label1IZNOSRABATAZADUZENJE;
        [AccessedThroughProperty("label1IZNOSZADUZENJA")]
        private UltraLabel _label1IZNOSZADUZENJA;
        [AccessedThroughProperty("label1KOLICINAZADUZENJA")]
        private UltraLabel _label1KOLICINAZADUZENJA;
        [AccessedThroughProperty("label1RABATZADUZENJA")]
        private UltraLabel _label1RABATZADUZENJA;
        [AccessedThroughProperty("label1UGOVORBROJ")]
        private UltraLabel _label1UGOVORBROJ;
        [AccessedThroughProperty("labelCIJENA")]
        private UltraLabel _labelCIJENA;
        [AccessedThroughProperty("labelCIJENAZAFAKTURU")]
        private UltraLabel _labelCIJENAZAFAKTURU;
        [AccessedThroughProperty("labelIZNOSRABATAZADUZENJE")]
        private UltraLabel _labelIZNOSRABATAZADUZENJE;
        [AccessedThroughProperty("labelIZNOSZADUZENJA")]
        private UltraLabel _labelIZNOSZADUZENJA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textCIJENAZADUZENJA")]
        private UltraNumericEditor _textCIJENAZADUZENJA;
        [AccessedThroughProperty("textKOLICINAZADUZENJA")]
        private UltraNumericEditor _textKOLICINAZADUZENJA;
        [AccessedThroughProperty("textRABATZADUZENJA")]
        private UltraNumericEditor _textRABATZADUZENJA;
        [AccessedThroughProperty("textUGOVORBROJ")]
        private UltraTextEditor _textUGOVORBROJ;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourcePARTNERZADUZENJE;
        private IContainer components = null;
        private PARTNERDataSet dsPARTNERDataSet1;
        protected TableLayoutPanel layoutManagerformPARTNERZADUZENJE;
        private bool m_AutoNumber = true;
        private GenericFormClass m_BaseMethods;
        private PARTNERDataSet.PARTNERZADUZENJERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "PARTNERZADUZENJE";
        private string m_FrameworkDescription = StringResources.PARTNERDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public PARTNERFormPARTNERZADUZENJEUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("PARTNERZADUZENJEAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("PARTNERZADUZENJEAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (PARTNERDataSet.PARTNERZADUZENJERow) ((DataRowView) this.bindingSourcePARTNERZADUZENJE.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsPARTNERDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourcePARTNERZADUZENJE.DataSource = this.PARTNERController.DataSet;
            this.dsPARTNERDataSet1 = this.PARTNERController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/PROIZVOD", Thread=ThreadOption.UserInterface)]
        public void comboIDPROIZVOD_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDPROIZVOD.Fill();
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
            this.dsPARTNERDataSet1 = (PARTNERDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourcePARTNERZADUZENJE.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsPARTNERDataSet1.Tables["PARTNERZADUZENJE"]);
            this.bindingSourcePARTNERZADUZENJE.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "PARTNER", this.m_Mode, this.dsPARTNERDataSet1, this.dsPARTNERDataSet1.PARTNERZADUZENJE.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding2 = new Binding("Text", this.bindingSourcePARTNERZADUZENJE, "CIJENA", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelCIJENA.DataBindings["Text"] != null)
            {
                this.labelCIJENA.DataBindings.Remove(this.labelCIJENA.DataBindings["Text"]);
            }
            this.labelCIJENA.DataBindings.Add(binding2);
            Binding binding6 = new Binding("Text", this.bindingSourcePARTNERZADUZENJE, "IZNOSZADUZENJA", true);
            binding6.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelIZNOSZADUZENJA.DataBindings["Text"] != null)
            {
                this.labelIZNOSZADUZENJA.DataBindings.Remove(this.labelIZNOSZADUZENJA.DataBindings["Text"]);
            }
            this.labelIZNOSZADUZENJA.DataBindings.Add(binding6);
            Binding binding5 = new Binding("Text", this.bindingSourcePARTNERZADUZENJE, "IZNOSRABATAZADUZENJE", true);
            binding5.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelIZNOSRABATAZADUZENJE.DataBindings["Text"] != null)
            {
                this.labelIZNOSRABATAZADUZENJE.DataBindings.Remove(this.labelIZNOSRABATAZADUZENJE.DataBindings["Text"]);
            }
            this.labelIZNOSRABATAZADUZENJE.DataBindings.Add(binding5);
            Binding binding3 = new Binding("Text", this.bindingSourcePARTNERZADUZENJE, "CIJENAZAFAKTURU", true);
            binding3.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelCIJENAZAFAKTURU.DataBindings["Text"] != null)
            {
                this.labelCIJENAZAFAKTURU.DataBindings.Remove(this.labelCIJENAZAFAKTURU.DataBindings["Text"]);
            }
            this.labelCIJENAZAFAKTURU.DataBindings.Add(binding3);
            Binding binding4 = new Binding("Text", this.bindingSourcePARTNERZADUZENJE, "DATUMUGOVORA", true);
            binding4.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding4.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerDATUMUGOVORA.DataBindings["Text"] != null)
            {
                this.datePickerDATUMUGOVORA.DataBindings.Remove(this.datePickerDATUMUGOVORA.DataBindings["Text"]);
            }
            this.datePickerDATUMUGOVORA.DataBindings.Add(binding4);
            Binding binding = new Binding("CheckState", this.bindingSourcePARTNERZADUZENJE, "AKTIVNO", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkAKTIVNO.DataBindings["CheckState"] != null)
            {
                this.checkAKTIVNO.DataBindings.Remove(this.checkAKTIVNO.DataBindings["CheckState"]);
            }
            this.checkAKTIVNO.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (PARTNERDataSet.PARTNERZADUZENJERow) ((DataRowView) this.bindingSourcePARTNERZADUZENJE.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (PARTNERDataSet.PARTNERZADUZENJERow) ((DataRowView) this.bindingSourcePARTNERZADUZENJE.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(PARTNERFormPARTNERZADUZENJEUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourcePARTNERZADUZENJE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePARTNERZADUZENJE).BeginInit();
            this.layoutManagerformPARTNERZADUZENJE = new TableLayoutPanel();
            this.layoutManagerformPARTNERZADUZENJE.SuspendLayout();
            this.layoutManagerformPARTNERZADUZENJE.AutoSize = true;
            this.layoutManagerformPARTNERZADUZENJE.Dock = DockStyle.Fill;
            this.layoutManagerformPARTNERZADUZENJE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformPARTNERZADUZENJE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformPARTNERZADUZENJE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformPARTNERZADUZENJE.Size = size;
            this.layoutManagerformPARTNERZADUZENJE.ColumnCount = 2;
            this.layoutManagerformPARTNERZADUZENJE.RowCount = 12;
            this.layoutManagerformPARTNERZADUZENJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPARTNERZADUZENJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPARTNERZADUZENJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNERZADUZENJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNERZADUZENJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNERZADUZENJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNERZADUZENJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNERZADUZENJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNERZADUZENJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNERZADUZENJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNERZADUZENJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNERZADUZENJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNERZADUZENJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNERZADUZENJE.RowStyles.Add(new RowStyle());
            this.label1IDPROIZVOD = new UltraLabel();
            this.comboIDPROIZVOD = new PROIZVODComboBox();
            this.label1CIJENA = new UltraLabel();
            this.labelCIJENA = new UltraLabel();
            this.label1KOLICINAZADUZENJA = new UltraLabel();
            this.textKOLICINAZADUZENJA = new UltraNumericEditor();
            this.label1CIJENAZADUZENJA = new UltraLabel();
            this.textCIJENAZADUZENJA = new UltraNumericEditor();
            this.label1IZNOSZADUZENJA = new UltraLabel();
            this.labelIZNOSZADUZENJA = new UltraLabel();
            this.label1RABATZADUZENJA = new UltraLabel();
            this.textRABATZADUZENJA = new UltraNumericEditor();
            this.label1IZNOSRABATAZADUZENJE = new UltraLabel();
            this.labelIZNOSRABATAZADUZENJE = new UltraLabel();
            this.label1CIJENAZAFAKTURU = new UltraLabel();
            this.labelCIJENAZAFAKTURU = new UltraLabel();
            this.label1UGOVORBROJ = new UltraLabel();
            this.textUGOVORBROJ = new UltraTextEditor();
            this.label1DATUMUGOVORA = new UltraLabel();
            this.datePickerDATUMUGOVORA = new UltraDateTimeEditor();
            this.label1AKTIVNO = new UltraLabel();
            this.checkAKTIVNO = new UltraCheckEditor();
            ((ISupportInitialize) this.textKOLICINAZADUZENJA).BeginInit();
            ((ISupportInitialize) this.textCIJENAZADUZENJA).BeginInit();
            ((ISupportInitialize) this.textRABATZADUZENJA).BeginInit();
            ((ISupportInitialize) this.textUGOVORBROJ).BeginInit();
            this.dsPARTNERDataSet1 = new PARTNERDataSet();
            this.dsPARTNERDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsPARTNERDataSet1.DataSetName = "dsPARTNER";
            this.dsPARTNERDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourcePARTNERZADUZENJE.DataSource = this.dsPARTNERDataSet1;
            this.bindingSourcePARTNERZADUZENJE.DataMember = "PARTNERZADUZENJE";
            ((ISupportInitialize) this.bindingSourcePARTNERZADUZENJE).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDPROIZVOD.Location = point;
            this.label1IDPROIZVOD.Name = "label1IDPROIZVOD";
            this.label1IDPROIZVOD.TabIndex = 1;
            this.label1IDPROIZVOD.Tag = "labelIDPROIZVOD";
            this.label1IDPROIZVOD.Text = "IDPROIZVOD:";
            this.label1IDPROIZVOD.StyleSetName = "FieldUltraLabel";
            this.label1IDPROIZVOD.AutoSize = true;
            this.label1IDPROIZVOD.Anchor = AnchorStyles.Left;
            this.label1IDPROIZVOD.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDPROIZVOD.Appearance.ForeColor = Color.Black;
            this.label1IDPROIZVOD.BackColor = Color.Transparent;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.label1IDPROIZVOD, 0, 0);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.label1IDPROIZVOD, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.label1IDPROIZVOD, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDPROIZVOD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDPROIZVOD.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x17);
            this.label1IDPROIZVOD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDPROIZVOD.Location = point;
            this.comboIDPROIZVOD.Name = "comboIDPROIZVOD";
            this.comboIDPROIZVOD.Tag = "IDPROIZVOD";
            this.comboIDPROIZVOD.TabIndex = 0;
            this.comboIDPROIZVOD.Anchor = AnchorStyles.Left;
            this.comboIDPROIZVOD.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDPROIZVOD.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDPROIZVOD.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDPROIZVOD.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDPROIZVOD.Enabled = true;
            this.comboIDPROIZVOD.DataBindings.Add(new Binding("Value", this.bindingSourcePARTNERZADUZENJE, "IDPROIZVOD"));
            this.comboIDPROIZVOD.ShowPictureBox = true;
            this.comboIDPROIZVOD.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDPROIZVOD);
            this.comboIDPROIZVOD.ValueMember = "IDPROIZVOD";
            this.comboIDPROIZVOD.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDPROIZVOD);
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.comboIDPROIZVOD, 1, 0);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.comboIDPROIZVOD, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.comboIDPROIZVOD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDPROIZVOD.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDPROIZVOD.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDPROIZVOD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1CIJENA.Location = point;
            this.label1CIJENA.Name = "label1CIJENA";
            this.label1CIJENA.TabIndex = 1;
            this.label1CIJENA.Tag = "labelCIJENA";
            this.label1CIJENA.Text = "CIJENA:";
            this.label1CIJENA.StyleSetName = "FieldUltraLabel";
            this.label1CIJENA.AutoSize = true;
            this.label1CIJENA.Anchor = AnchorStyles.Left;
            this.label1CIJENA.Appearance.TextVAlign = VAlign.Middle;
            this.label1CIJENA.Appearance.ForeColor = Color.Black;
            this.label1CIJENA.BackColor = Color.Transparent;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.label1CIJENA, 0, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.label1CIJENA, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.label1CIJENA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1CIJENA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1CIJENA.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x17);
            this.label1CIJENA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelCIJENA.Location = point;
            this.labelCIJENA.Name = "labelCIJENA";
            this.labelCIJENA.Tag = "CIJENA";
            this.labelCIJENA.TabIndex = 0;
            this.labelCIJENA.Anchor = AnchorStyles.Left;
            this.labelCIJENA.BackColor = Color.Transparent;
            this.labelCIJENA.Appearance.TextHAlign = HAlign.Left;
            this.labelCIJENA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.labelCIJENA, 1, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.labelCIJENA, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.labelCIJENA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelCIJENA.Margin = padding;
            size = new System.Drawing.Size(0x52, 0x16);
            this.labelCIJENA.MinimumSize = size;
            size = new System.Drawing.Size(0x52, 0x16);
            this.labelCIJENA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KOLICINAZADUZENJA.Location = point;
            this.label1KOLICINAZADUZENJA.Name = "label1KOLICINAZADUZENJA";
            this.label1KOLICINAZADUZENJA.TabIndex = 1;
            this.label1KOLICINAZADUZENJA.Tag = "labelKOLICINAZADUZENJA";
            this.label1KOLICINAZADUZENJA.Text = "Količina:";
            this.label1KOLICINAZADUZENJA.StyleSetName = "FieldUltraLabel";
            this.label1KOLICINAZADUZENJA.AutoSize = true;
            this.label1KOLICINAZADUZENJA.Anchor = AnchorStyles.Left;
            this.label1KOLICINAZADUZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1KOLICINAZADUZENJA.Appearance.ForeColor = Color.Black;
            this.label1KOLICINAZADUZENJA.BackColor = Color.Transparent;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.label1KOLICINAZADUZENJA, 0, 2);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.label1KOLICINAZADUZENJA, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.label1KOLICINAZADUZENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KOLICINAZADUZENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KOLICINAZADUZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x44, 0x17);
            this.label1KOLICINAZADUZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textKOLICINAZADUZENJA.Location = point;
            this.textKOLICINAZADUZENJA.Name = "textKOLICINAZADUZENJA";
            this.textKOLICINAZADUZENJA.Tag = "KOLICINAZADUZENJA";
            this.textKOLICINAZADUZENJA.TabIndex = 0;
            this.textKOLICINAZADUZENJA.Anchor = AnchorStyles.Left;
            this.textKOLICINAZADUZENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textKOLICINAZADUZENJA.ReadOnly = false;
            this.textKOLICINAZADUZENJA.PromptChar = ' ';
            this.textKOLICINAZADUZENJA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textKOLICINAZADUZENJA.DataBindings.Add(new Binding("Value", this.bindingSourcePARTNERZADUZENJE, "KOLICINAZADUZENJA"));
            this.textKOLICINAZADUZENJA.NumericType = NumericType.Double;
            this.textKOLICINAZADUZENJA.MaxValue = 79228162514264337593543950335M;
            this.textKOLICINAZADUZENJA.MinValue = -79228162514264337593543950335M;
            this.textKOLICINAZADUZENJA.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.textKOLICINAZADUZENJA, 1, 2);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.textKOLICINAZADUZENJA, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.textKOLICINAZADUZENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textKOLICINAZADUZENJA.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textKOLICINAZADUZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textKOLICINAZADUZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1CIJENAZADUZENJA.Location = point;
            this.label1CIJENAZADUZENJA.Name = "label1CIJENAZADUZENJA";
            this.label1CIJENAZADUZENJA.TabIndex = 1;
            this.label1CIJENAZADUZENJA.Tag = "labelCIJENAZADUZENJA";
            this.label1CIJENAZADUZENJA.Text = "Cijena:";
            this.label1CIJENAZADUZENJA.StyleSetName = "FieldUltraLabel";
            this.label1CIJENAZADUZENJA.AutoSize = true;
            this.label1CIJENAZADUZENJA.Anchor = AnchorStyles.Left;
            this.label1CIJENAZADUZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1CIJENAZADUZENJA.Appearance.ForeColor = Color.Black;
            this.label1CIJENAZADUZENJA.BackColor = Color.Transparent;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.label1CIJENAZADUZENJA, 0, 3);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.label1CIJENAZADUZENJA, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.label1CIJENAZADUZENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1CIJENAZADUZENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1CIJENAZADUZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x3a, 0x17);
            this.label1CIJENAZADUZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textCIJENAZADUZENJA.Location = point;
            this.textCIJENAZADUZENJA.Name = "textCIJENAZADUZENJA";
            this.textCIJENAZADUZENJA.Tag = "CIJENAZADUZENJA";
            this.textCIJENAZADUZENJA.TabIndex = 0;
            this.textCIJENAZADUZENJA.Anchor = AnchorStyles.Left;
            this.textCIJENAZADUZENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textCIJENAZADUZENJA.ReadOnly = false;
            this.textCIJENAZADUZENJA.PromptChar = ' ';
            this.textCIJENAZADUZENJA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textCIJENAZADUZENJA.DataBindings.Add(new Binding("Value", this.bindingSourcePARTNERZADUZENJE, "CIJENAZADUZENJA"));
            this.textCIJENAZADUZENJA.NumericType = NumericType.Double;
            this.textCIJENAZADUZENJA.MaxValue = 79228162514264337593543950335M;
            this.textCIJENAZADUZENJA.MinValue = -79228162514264337593543950335M;
            this.textCIJENAZADUZENJA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.textCIJENAZADUZENJA, 1, 3);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.textCIJENAZADUZENJA, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.textCIJENAZADUZENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textCIJENAZADUZENJA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textCIJENAZADUZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textCIJENAZADUZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IZNOSZADUZENJA.Location = point;
            this.label1IZNOSZADUZENJA.Name = "label1IZNOSZADUZENJA";
            this.label1IZNOSZADUZENJA.TabIndex = 1;
            this.label1IZNOSZADUZENJA.Tag = "labelIZNOSZADUZENJA";
            this.label1IZNOSZADUZENJA.Text = "Iznos:";
            this.label1IZNOSZADUZENJA.StyleSetName = "FieldUltraLabel";
            this.label1IZNOSZADUZENJA.AutoSize = true;
            this.label1IZNOSZADUZENJA.Anchor = AnchorStyles.Left;
            this.label1IZNOSZADUZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IZNOSZADUZENJA.Appearance.ForeColor = Color.Black;
            this.label1IZNOSZADUZENJA.BackColor = Color.Transparent;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.label1IZNOSZADUZENJA, 0, 4);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.label1IZNOSZADUZENJA, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.label1IZNOSZADUZENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IZNOSZADUZENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IZNOSZADUZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1IZNOSZADUZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelIZNOSZADUZENJA.Location = point;
            this.labelIZNOSZADUZENJA.Name = "labelIZNOSZADUZENJA";
            this.labelIZNOSZADUZENJA.Tag = "IZNOSZADUZENJA";
            this.labelIZNOSZADUZENJA.TabIndex = 0;
            this.labelIZNOSZADUZENJA.Anchor = AnchorStyles.Left;
            this.labelIZNOSZADUZENJA.BackColor = Color.Transparent;
            this.labelIZNOSZADUZENJA.Appearance.TextHAlign = HAlign.Left;
            this.labelIZNOSZADUZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.labelIZNOSZADUZENJA, 1, 4);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.labelIZNOSZADUZENJA, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.labelIZNOSZADUZENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelIZNOSZADUZENJA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelIZNOSZADUZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelIZNOSZADUZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RABATZADUZENJA.Location = point;
            this.label1RABATZADUZENJA.Name = "label1RABATZADUZENJA";
            this.label1RABATZADUZENJA.TabIndex = 1;
            this.label1RABATZADUZENJA.Tag = "labelRABATZADUZENJA";
            this.label1RABATZADUZENJA.Text = "Rabat %:";
            this.label1RABATZADUZENJA.StyleSetName = "FieldUltraLabel";
            this.label1RABATZADUZENJA.AutoSize = true;
            this.label1RABATZADUZENJA.Anchor = AnchorStyles.Left;
            this.label1RABATZADUZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1RABATZADUZENJA.Appearance.ForeColor = Color.Black;
            this.label1RABATZADUZENJA.BackColor = Color.Transparent;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.label1RABATZADUZENJA, 0, 5);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.label1RABATZADUZENJA, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.label1RABATZADUZENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RABATZADUZENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RABATZADUZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x4a, 0x17);
            this.label1RABATZADUZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRABATZADUZENJA.Location = point;
            this.textRABATZADUZENJA.Name = "textRABATZADUZENJA";
            this.textRABATZADUZENJA.Tag = "RABATZADUZENJA";
            this.textRABATZADUZENJA.TabIndex = 0;
            this.textRABATZADUZENJA.Anchor = AnchorStyles.Left;
            this.textRABATZADUZENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRABATZADUZENJA.ReadOnly = false;
            this.textRABATZADUZENJA.PromptChar = ' ';
            this.textRABATZADUZENJA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textRABATZADUZENJA.DataBindings.Add(new Binding("Value", this.bindingSourcePARTNERZADUZENJE, "RABATZADUZENJA"));
            this.textRABATZADUZENJA.NumericType = NumericType.Double;
            this.textRABATZADUZENJA.MaxValue = 79228162514264337593543950335M;
            this.textRABATZADUZENJA.MinValue = -79228162514264337593543950335M;
            this.textRABATZADUZENJA.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.textRABATZADUZENJA, 1, 5);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.textRABATZADUZENJA, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.textRABATZADUZENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRABATZADUZENJA.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textRABATZADUZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textRABATZADUZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IZNOSRABATAZADUZENJE.Location = point;
            this.label1IZNOSRABATAZADUZENJE.Name = "label1IZNOSRABATAZADUZENJE";
            this.label1IZNOSRABATAZADUZENJE.TabIndex = 1;
            this.label1IZNOSRABATAZADUZENJE.Tag = "labelIZNOSRABATAZADUZENJE";
            this.label1IZNOSRABATAZADUZENJE.Text = "Iznos rabata:";
            this.label1IZNOSRABATAZADUZENJE.StyleSetName = "FieldUltraLabel";
            this.label1IZNOSRABATAZADUZENJE.AutoSize = true;
            this.label1IZNOSRABATAZADUZENJE.Anchor = AnchorStyles.Left;
            this.label1IZNOSRABATAZADUZENJE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IZNOSRABATAZADUZENJE.Appearance.ForeColor = Color.Black;
            this.label1IZNOSRABATAZADUZENJE.BackColor = Color.Transparent;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.label1IZNOSRABATAZADUZENJE, 0, 6);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.label1IZNOSRABATAZADUZENJE, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.label1IZNOSRABATAZADUZENJE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IZNOSRABATAZADUZENJE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IZNOSRABATAZADUZENJE.MinimumSize = size;
            size = new System.Drawing.Size(0x61, 0x17);
            this.label1IZNOSRABATAZADUZENJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelIZNOSRABATAZADUZENJE.Location = point;
            this.labelIZNOSRABATAZADUZENJE.Name = "labelIZNOSRABATAZADUZENJE";
            this.labelIZNOSRABATAZADUZENJE.Tag = "IZNOSRABATAZADUZENJE";
            this.labelIZNOSRABATAZADUZENJE.TabIndex = 0;
            this.labelIZNOSRABATAZADUZENJE.Anchor = AnchorStyles.Left;
            this.labelIZNOSRABATAZADUZENJE.BackColor = Color.Transparent;
            this.labelIZNOSRABATAZADUZENJE.Appearance.TextHAlign = HAlign.Left;
            this.labelIZNOSRABATAZADUZENJE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.labelIZNOSRABATAZADUZENJE, 1, 6);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.labelIZNOSRABATAZADUZENJE, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.labelIZNOSRABATAZADUZENJE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelIZNOSRABATAZADUZENJE.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelIZNOSRABATAZADUZENJE.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelIZNOSRABATAZADUZENJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1CIJENAZAFAKTURU.Location = point;
            this.label1CIJENAZAFAKTURU.Name = "label1CIJENAZAFAKTURU";
            this.label1CIJENAZAFAKTURU.TabIndex = 1;
            this.label1CIJENAZAFAKTURU.Tag = "labelCIJENAZAFAKTURU";
            this.label1CIJENAZAFAKTURU.Text = "Iznos umanjen za rabat:";
            this.label1CIJENAZAFAKTURU.StyleSetName = "FieldUltraLabel";
            this.label1CIJENAZAFAKTURU.AutoSize = true;
            this.label1CIJENAZAFAKTURU.Anchor = AnchorStyles.Left;
            this.label1CIJENAZAFAKTURU.Appearance.TextVAlign = VAlign.Middle;
            this.label1CIJENAZAFAKTURU.Appearance.ForeColor = Color.Black;
            this.label1CIJENAZAFAKTURU.BackColor = Color.Transparent;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.label1CIJENAZAFAKTURU, 0, 7);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.label1CIJENAZAFAKTURU, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.label1CIJENAZAFAKTURU, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1CIJENAZAFAKTURU.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1CIJENAZAFAKTURU.MinimumSize = size;
            size = new System.Drawing.Size(0xa6, 0x17);
            this.label1CIJENAZAFAKTURU.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelCIJENAZAFAKTURU.Location = point;
            this.labelCIJENAZAFAKTURU.Name = "labelCIJENAZAFAKTURU";
            this.labelCIJENAZAFAKTURU.Tag = "CIJENAZAFAKTURU";
            this.labelCIJENAZAFAKTURU.TabIndex = 0;
            this.labelCIJENAZAFAKTURU.Anchor = AnchorStyles.Left;
            this.labelCIJENAZAFAKTURU.BackColor = Color.Transparent;
            this.labelCIJENAZAFAKTURU.Appearance.TextHAlign = HAlign.Left;
            this.labelCIJENAZAFAKTURU.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.labelCIJENAZAFAKTURU, 1, 7);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.labelCIJENAZAFAKTURU, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.labelCIJENAZAFAKTURU, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelCIJENAZAFAKTURU.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelCIJENAZAFAKTURU.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelCIJENAZAFAKTURU.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1UGOVORBROJ.Location = point;
            this.label1UGOVORBROJ.Name = "label1UGOVORBROJ";
            this.label1UGOVORBROJ.TabIndex = 1;
            this.label1UGOVORBROJ.Tag = "labelUGOVORBROJ";
            this.label1UGOVORBROJ.Text = "Ugovor:";
            this.label1UGOVORBROJ.StyleSetName = "FieldUltraLabel";
            this.label1UGOVORBROJ.AutoSize = true;
            this.label1UGOVORBROJ.Anchor = AnchorStyles.Left;
            this.label1UGOVORBROJ.Appearance.TextVAlign = VAlign.Middle;
            this.label1UGOVORBROJ.Appearance.ForeColor = Color.Black;
            this.label1UGOVORBROJ.BackColor = Color.Transparent;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.label1UGOVORBROJ, 0, 8);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.label1UGOVORBROJ, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.label1UGOVORBROJ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1UGOVORBROJ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1UGOVORBROJ.MinimumSize = size;
            size = new System.Drawing.Size(0x40, 0x17);
            this.label1UGOVORBROJ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textUGOVORBROJ.Location = point;
            this.textUGOVORBROJ.Name = "textUGOVORBROJ";
            this.textUGOVORBROJ.Tag = "UGOVORBROJ";
            this.textUGOVORBROJ.TabIndex = 0;
            this.textUGOVORBROJ.Anchor = AnchorStyles.Left;
            this.textUGOVORBROJ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textUGOVORBROJ.ReadOnly = false;
            this.textUGOVORBROJ.DataBindings.Add(new Binding("Text", this.bindingSourcePARTNERZADUZENJE, "UGOVORBROJ"));
            this.textUGOVORBROJ.MaxLength = 200;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.textUGOVORBROJ, 1, 8);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.textUGOVORBROJ, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.textUGOVORBROJ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textUGOVORBROJ.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textUGOVORBROJ.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textUGOVORBROJ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DATUMUGOVORA.Location = point;
            this.label1DATUMUGOVORA.Name = "label1DATUMUGOVORA";
            this.label1DATUMUGOVORA.TabIndex = 1;
            this.label1DATUMUGOVORA.Tag = "labelDATUMUGOVORA";
            this.label1DATUMUGOVORA.Text = "Datum:";
            this.label1DATUMUGOVORA.StyleSetName = "FieldUltraLabel";
            this.label1DATUMUGOVORA.AutoSize = true;
            this.label1DATUMUGOVORA.Anchor = AnchorStyles.Left;
            this.label1DATUMUGOVORA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMUGOVORA.Appearance.ForeColor = Color.Black;
            this.label1DATUMUGOVORA.BackColor = Color.Transparent;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.label1DATUMUGOVORA, 0, 9);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.label1DATUMUGOVORA, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.label1DATUMUGOVORA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DATUMUGOVORA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUMUGOVORA.MinimumSize = size;
            size = new System.Drawing.Size(0x3d, 0x17);
            this.label1DATUMUGOVORA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUMUGOVORA.Location = point;
            this.datePickerDATUMUGOVORA.Name = "datePickerDATUMUGOVORA";
            this.datePickerDATUMUGOVORA.Tag = "DATUMUGOVORA";
            this.datePickerDATUMUGOVORA.TabIndex = 0;
            this.datePickerDATUMUGOVORA.Anchor = AnchorStyles.Left;
            this.datePickerDATUMUGOVORA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUMUGOVORA.Enabled = true;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.datePickerDATUMUGOVORA, 1, 9);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.datePickerDATUMUGOVORA, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.datePickerDATUMUGOVORA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUMUGOVORA.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMUGOVORA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMUGOVORA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1AKTIVNO.Location = point;
            this.label1AKTIVNO.Name = "label1AKTIVNO";
            this.label1AKTIVNO.TabIndex = 1;
            this.label1AKTIVNO.Tag = "labelAKTIVNO";
            this.label1AKTIVNO.Text = "AKTIVNO:";
            this.label1AKTIVNO.StyleSetName = "FieldUltraLabel";
            this.label1AKTIVNO.AutoSize = true;
            this.label1AKTIVNO.Anchor = AnchorStyles.Left;
            this.label1AKTIVNO.Appearance.TextVAlign = VAlign.Middle;
            this.label1AKTIVNO.Appearance.ForeColor = Color.Black;
            this.label1AKTIVNO.BackColor = Color.Transparent;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.label1AKTIVNO, 0, 10);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.label1AKTIVNO, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.label1AKTIVNO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1AKTIVNO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1AKTIVNO.MinimumSize = size;
            size = new System.Drawing.Size(0x4d, 0x17);
            this.label1AKTIVNO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkAKTIVNO.Location = point;
            this.checkAKTIVNO.Name = "checkAKTIVNO";
            this.checkAKTIVNO.Tag = "AKTIVNO";
            this.checkAKTIVNO.TabIndex = 0;
            this.checkAKTIVNO.Anchor = AnchorStyles.Left;
            this.checkAKTIVNO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkAKTIVNO.Enabled = true;
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.checkAKTIVNO, 1, 10);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.checkAKTIVNO, 1);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.checkAKTIVNO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkAKTIVNO.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkAKTIVNO.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkAKTIVNO.Size = size;
            this.Controls.Add(this.layoutManagerformPARTNERZADUZENJE);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourcePARTNERZADUZENJE;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "PARTNERFormPARTNERZADUZENJEUserControl";
            this.Text = " Zaduzenja partnera";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.PARTNERFormUserControl_Load);
            this.layoutManagerformPARTNERZADUZENJE.ResumeLayout(false);
            this.layoutManagerformPARTNERZADUZENJE.PerformLayout();
            ((ISupportInitialize) this.bindingSourcePARTNERZADUZENJE).EndInit();
            ((ISupportInitialize) this.textKOLICINAZADUZENJA).EndInit();
            ((ISupportInitialize) this.textCIJENAZADUZENJA).EndInit();
            ((ISupportInitialize) this.textRABATZADUZENJA).EndInit();
            ((ISupportInitialize) this.textUGOVORBROJ).EndInit();
            this.dsPARTNERDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.PARTNERController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourcePARTNERZADUZENJE, this.PARTNERController.WorkItem, this))
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
            this.label1IDPROIZVOD.Text = StringResources.PARTNERIDPROIZVODDescription;
            this.label1CIJENA.Text = StringResources.PARTNERCIJENADescription;
            this.label1KOLICINAZADUZENJA.Text = StringResources.PARTNERKOLICINAZADUZENJADescription;
            this.label1CIJENAZADUZENJA.Text = StringResources.PARTNERCIJENAZADUZENJADescription;
            this.label1IZNOSZADUZENJA.Text = StringResources.PARTNERIZNOSZADUZENJADescription;
            this.label1RABATZADUZENJA.Text = StringResources.PARTNERRABATZADUZENJADescription;
            this.label1IZNOSRABATAZADUZENJE.Text = StringResources.PARTNERIZNOSRABATAZADUZENJEDescription;
            this.label1CIJENAZAFAKTURU.Text = StringResources.PARTNERCIJENAZAFAKTURUDescription;
            this.label1UGOVORBROJ.Text = StringResources.PARTNERUGOVORBROJDescription;
            this.label1DATUMUGOVORA.Text = StringResources.PARTNERDATUMUGOVORADescription;
            this.label1AKTIVNO.Text = StringResources.PARTNERAKTIVNODescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewGKSTAVKA")]
        public void NewGKSTAVKAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.NewGKSTAVKA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewIRA")]
        public void NewIRAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.NewIRA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewRACUN")]
        public void NewRACUNHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.NewRACUN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewSHEMAURA")]
        public void NewSHEMAURAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.NewSHEMAURA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewURA")]
        public void NewURAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.NewURA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PARTNERFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.PARTNERPARTNERZADUZENJELevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void PictureBoxClickedIDPROIZVOD(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("PROIZVOD", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.PARTNERController.WorkItem.Items.Contains("PARTNERZADUZENJE|PARTNERZADUZENJE"))
            {
                this.PARTNERController.WorkItem.Items.Add(this.bindingSourcePARTNERZADUZENJE, "PARTNERZADUZENJE|PARTNERZADUZENJE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("PARTNERZADUZENJESaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedIDPROIZVOD(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDPROIZVOD.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDPROIZVOD.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourcePARTNERZADUZENJE.Current).Row["IDPROIZVOD"] = RuntimeHelpers.GetObjectValue(row["IDPROIZVOD"]);
                    ((DataRowView) this.bindingSourcePARTNERZADUZENJE.Current).Row["NAZIVPROIZVOD"] = RuntimeHelpers.GetObjectValue(row["NAZIVPROIZVOD"]);
                    ((DataRowView) this.bindingSourcePARTNERZADUZENJE.Current).Row["CIJENA"] = RuntimeHelpers.GetObjectValue(row["CIJENA"]);
                    this.bindingSourcePARTNERZADUZENJE.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboIDPROIZVOD.Focus();
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

        [LocalCommandHandler("ViewGKSTAVKA")]
        public void ViewGKSTAVKAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.ViewGKSTAVKA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewIRA")]
        public void ViewIRAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.ViewIRA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewRACUN")]
        public void ViewRACUNHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.ViewRACUN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewSHEMAURA")]
        public void ViewSHEMAURAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.ViewSHEMAURA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewURA")]
        public void ViewURAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.ViewURA(this.m_CurrentRow);
            }
        }

        protected virtual UltraCheckEditor checkAKTIVNO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkAKTIVNO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkAKTIVNO = value;
            }
        }

        protected virtual PROIZVODComboBox comboIDPROIZVOD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDPROIZVOD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDPROIZVOD = value;
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

        protected virtual UltraLabel label1AKTIVNO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1AKTIVNO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1AKTIVNO = value;
            }
        }

        protected virtual UltraLabel label1CIJENA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1CIJENA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1CIJENA = value;
            }
        }

        protected virtual UltraLabel label1CIJENAZADUZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1CIJENAZADUZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1CIJENAZADUZENJA = value;
            }
        }

        protected virtual UltraLabel label1CIJENAZAFAKTURU
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1CIJENAZAFAKTURU;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1CIJENAZAFAKTURU = value;
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

        protected virtual UltraLabel label1IDPROIZVOD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDPROIZVOD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDPROIZVOD = value;
            }
        }

        protected virtual UltraLabel label1IZNOSRABATAZADUZENJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IZNOSRABATAZADUZENJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IZNOSRABATAZADUZENJE = value;
            }
        }

        protected virtual UltraLabel label1IZNOSZADUZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IZNOSZADUZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IZNOSZADUZENJA = value;
            }
        }

        protected virtual UltraLabel label1KOLICINAZADUZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KOLICINAZADUZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KOLICINAZADUZENJA = value;
            }
        }

        protected virtual UltraLabel label1RABATZADUZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RABATZADUZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RABATZADUZENJA = value;
            }
        }

        protected virtual UltraLabel label1UGOVORBROJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1UGOVORBROJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1UGOVORBROJ = value;
            }
        }

        protected virtual UltraLabel labelCIJENA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelCIJENA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelCIJENA = value;
            }
        }

        protected virtual UltraLabel labelCIJENAZAFAKTURU
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelCIJENAZAFAKTURU;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelCIJENAZAFAKTURU = value;
            }
        }

        protected virtual UltraLabel labelIZNOSRABATAZADUZENJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelIZNOSRABATAZADUZENJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelIZNOSRABATAZADUZENJE = value;
            }
        }

        protected virtual UltraLabel labelIZNOSZADUZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelIZNOSZADUZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelIZNOSZADUZENJA = value;
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
        public NetAdvantage.Controllers.PARTNERController PARTNERController { get; set; }

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

        protected virtual UltraNumericEditor textCIJENAZADUZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textCIJENAZADUZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textCIJENAZADUZENJA = value;
            }
        }

        protected virtual UltraNumericEditor textKOLICINAZADUZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textKOLICINAZADUZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textKOLICINAZADUZENJA = value;
            }
        }

        protected virtual UltraNumericEditor textRABATZADUZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRABATZADUZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRABATZADUZENJA = value;
            }
        }

        protected virtual UltraTextEditor textUGOVORBROJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textUGOVORBROJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textUGOVORBROJ = value;
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

