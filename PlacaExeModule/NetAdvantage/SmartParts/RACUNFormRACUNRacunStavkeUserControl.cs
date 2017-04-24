namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Win;
    using Hlp;
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
    public class RACUNFormRACUNRacunStavkeUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDPROIZVOD")]
        private PROIZVODComboBox _comboIDPROIZVOD;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1BROJSTAVKE")]
        private UltraLabel _label1BROJSTAVKE;
        [AccessedThroughProperty("label1CIJENARACUN")]
        private UltraLabel _label1CIJENARACUN;
        [AccessedThroughProperty("label1IDPROIZVOD")]
        private UltraLabel _label1IDPROIZVOD;
        [AccessedThroughProperty("label1KOLICINA")]
        private UltraLabel _label1KOLICINA;
        [AccessedThroughProperty("label1NAZIVPROIZVODRACUN")]
        private UltraLabel _label1NAZIVPROIZVODRACUN;
        [AccessedThroughProperty("label1RABAT")]
        private UltraLabel _label1RABAT;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textBROJSTAVKE")]
        private UltraNumericEditor _textBROJSTAVKE;
        [AccessedThroughProperty("textCIJENARACUN")]
        private UltraNumericEditor _textCIJENARACUN;
        [AccessedThroughProperty("textKOLICINA")]
        private UltraNumericEditor _textKOLICINA;
        [AccessedThroughProperty("textNAZIVPROIZVODRACUN")]
        private UltraTextEditor _textNAZIVPROIZVODRACUN;
        [AccessedThroughProperty("textRABAT")]
        private UltraNumericEditor _textRABAT;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRACUNRacunStavke;
        private IContainer components = null;
        private RACUNDataSet dsRACUNDataSet1;
        protected TableLayoutPanel layoutManagerformRACUNRacunStavke;
        private bool m_AutoNumber = true;
        private GenericFormClass m_BaseMethods;
        private RACUNDataSet.RACUNRacunStavkeRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RACUNRacunStavke";
        private string m_FrameworkDescription = StringResources.RACUNDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public RACUNFormRACUNRacunStavkeUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("RACUNRacunStavkeAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("RACUNRacunStavkeAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (RACUNDataSet.RACUNRacunStavkeRow) ((DataRowView) this.bindingSourceRACUNRacunStavke.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsRACUNDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceRACUNRacunStavke.DataSource = this.RACUNController.DataSet;
            this.dsRACUNDataSet1 = this.RACUNController.DataSet;
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

        [OnBuiltUp]
        public void Dodatno()
        {
        }

        private void EndEditCurrentRow()
        {
        }

        public void Initialize(DeklaritMode mode, DataRow parentRow, bool isCopy)
        {
            this.m_ParentRow = parentRow;
            this.dsRACUNDataSet1 = (RACUNDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceRACUNRacunStavke.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsRACUNDataSet1.Tables["RACUNRacunStavke"]);
            this.bindingSourceRACUNRacunStavke.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RACUN", this.m_Mode, this.dsRACUNDataSet1, this.dsRACUNDataSet1.RACUNRacunStavke.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (RACUNDataSet.RACUNRacunStavkeRow) ((DataRowView) this.bindingSourceRACUNRacunStavke.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RACUNDataSet.RACUNRacunStavkeRow) ((DataRowView) this.bindingSourceRACUNRacunStavke.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(RACUNFormRACUNRacunStavkeUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRACUNRacunStavke = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRACUNRacunStavke).BeginInit();
            this.layoutManagerformRACUNRacunStavke = new TableLayoutPanel();
            this.layoutManagerformRACUNRacunStavke.SuspendLayout();
            this.layoutManagerformRACUNRacunStavke.AutoSize = true;
            this.layoutManagerformRACUNRacunStavke.Dock = DockStyle.Fill;
            this.layoutManagerformRACUNRacunStavke.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRACUNRacunStavke.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRACUNRacunStavke.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRACUNRacunStavke.Size = size;
            this.layoutManagerformRACUNRacunStavke.ColumnCount = 2;
            this.layoutManagerformRACUNRacunStavke.RowCount = 7;
            this.layoutManagerformRACUNRacunStavke.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRACUNRacunStavke.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRACUNRacunStavke.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUNRacunStavke.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUNRacunStavke.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUNRacunStavke.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUNRacunStavke.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUNRacunStavke.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUNRacunStavke.RowStyles.Add(new RowStyle());
            this.label1BROJSTAVKE = new UltraLabel();
            this.textBROJSTAVKE = new UltraNumericEditor();
            this.label1IDPROIZVOD = new UltraLabel();
            this.comboIDPROIZVOD = new PROIZVODComboBox();
            this.label1NAZIVPROIZVODRACUN = new UltraLabel();
            this.textNAZIVPROIZVODRACUN = new UltraTextEditor();
            this.label1CIJENARACUN = new UltraLabel();
            this.textCIJENARACUN = new UltraNumericEditor();
            this.label1KOLICINA = new UltraLabel();
            this.textKOLICINA = new UltraNumericEditor();
            this.label1RABAT = new UltraLabel();
            this.textRABAT = new UltraNumericEditor();
            ((ISupportInitialize) this.textBROJSTAVKE).BeginInit();
            ((ISupportInitialize) this.textNAZIVPROIZVODRACUN).BeginInit();
            ((ISupportInitialize) this.textCIJENARACUN).BeginInit();
            ((ISupportInitialize) this.textKOLICINA).BeginInit();
            ((ISupportInitialize) this.textRABAT).BeginInit();
            this.dsRACUNDataSet1 = new RACUNDataSet();
            this.dsRACUNDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRACUNDataSet1.DataSetName = "dsRACUN";
            this.dsRACUNDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRACUNRacunStavke.DataSource = this.dsRACUNDataSet1;
            this.bindingSourceRACUNRacunStavke.DataMember = "RACUNRacunStavke";
            ((ISupportInitialize) this.bindingSourceRACUNRacunStavke).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1BROJSTAVKE.Location = point;
            this.label1BROJSTAVKE.Name = "label1BROJSTAVKE";
            this.label1BROJSTAVKE.TabIndex = 1;
            this.label1BROJSTAVKE.Tag = "labelBROJSTAVKE";
            this.label1BROJSTAVKE.Text = "Stavka:";
            this.label1BROJSTAVKE.StyleSetName = "FieldUltraLabel";
            this.label1BROJSTAVKE.AutoSize = true;
            this.label1BROJSTAVKE.Anchor = AnchorStyles.Left;
            this.label1BROJSTAVKE.Appearance.TextVAlign = VAlign.Middle;
            this.label1BROJSTAVKE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1BROJSTAVKE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1BROJSTAVKE.ImageSize = size;
            this.label1BROJSTAVKE.Appearance.ForeColor = Color.Black;
            this.label1BROJSTAVKE.BackColor = Color.Transparent;
            this.layoutManagerformRACUNRacunStavke.Controls.Add(this.label1BROJSTAVKE, 0, 0);
            this.layoutManagerformRACUNRacunStavke.SetColumnSpan(this.label1BROJSTAVKE, 1);
            this.layoutManagerformRACUNRacunStavke.SetRowSpan(this.label1BROJSTAVKE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1BROJSTAVKE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BROJSTAVKE.MinimumSize = size;
            size = new System.Drawing.Size(0x3a, 0x17);
            this.label1BROJSTAVKE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textBROJSTAVKE.Location = point;
            this.textBROJSTAVKE.Name = "textBROJSTAVKE";
            this.textBROJSTAVKE.Tag = "BROJSTAVKE";
            this.textBROJSTAVKE.TabIndex = 0;
            this.textBROJSTAVKE.Anchor = AnchorStyles.Left;
            this.textBROJSTAVKE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textBROJSTAVKE.ReadOnly = true;
            this.textBROJSTAVKE.TabStop = false;
            this.textBROJSTAVKE.PromptChar = ' ';
            this.textBROJSTAVKE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textBROJSTAVKE.DataBindings.Add(new Binding("Value", this.bindingSourceRACUNRacunStavke, "BROJSTAVKE"));
            this.textBROJSTAVKE.NumericType = NumericType.Integer;
            this.textBROJSTAVKE.MaskInput = "{LOC}-nnnnnn";
            this.layoutManagerformRACUNRacunStavke.Controls.Add(this.textBROJSTAVKE, 1, 0);
            this.layoutManagerformRACUNRacunStavke.SetColumnSpan(this.textBROJSTAVKE, 1);
            this.layoutManagerformRACUNRacunStavke.SetRowSpan(this.textBROJSTAVKE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBROJSTAVKE.Margin = padding;
            size = new System.Drawing.Size(0x3a, 0x16);
            this.textBROJSTAVKE.MinimumSize = size;
            size = new System.Drawing.Size(0x3a, 0x16);
            this.textBROJSTAVKE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDPROIZVOD.Location = point;
            this.label1IDPROIZVOD.Name = "label1IDPROIZVOD";
            this.label1IDPROIZVOD.TabIndex = 1;
            this.label1IDPROIZVOD.Tag = "labelIDPROIZVOD";
            this.label1IDPROIZVOD.Text = "Šif. pro:";
            this.label1IDPROIZVOD.StyleSetName = "FieldUltraLabel";
            this.label1IDPROIZVOD.AutoSize = true;
            this.label1IDPROIZVOD.Anchor = AnchorStyles.Left;
            this.label1IDPROIZVOD.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDPROIZVOD.Appearance.ForeColor = Color.Black;
            this.label1IDPROIZVOD.BackColor = Color.Transparent;
            this.layoutManagerformRACUNRacunStavke.Controls.Add(this.label1IDPROIZVOD, 0, 1);
            this.layoutManagerformRACUNRacunStavke.SetColumnSpan(this.label1IDPROIZVOD, 1);
            this.layoutManagerformRACUNRacunStavke.SetRowSpan(this.label1IDPROIZVOD, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDPROIZVOD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDPROIZVOD.MinimumSize = size;
            size = new System.Drawing.Size(0x40, 0x17);
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
            this.comboIDPROIZVOD.DataBindings.Add(new Binding("Value", this.bindingSourceRACUNRacunStavke, "IDPROIZVOD"));
            this.comboIDPROIZVOD.ShowPictureBox = true;
            this.comboIDPROIZVOD.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDPROIZVOD);
            this.comboIDPROIZVOD.ValueMember = "IDPROIZVOD";
            this.comboIDPROIZVOD.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDPROIZVOD);
            this.layoutManagerformRACUNRacunStavke.Controls.Add(this.comboIDPROIZVOD, 1, 1);
            this.layoutManagerformRACUNRacunStavke.SetColumnSpan(this.comboIDPROIZVOD, 1);
            this.layoutManagerformRACUNRacunStavke.SetRowSpan(this.comboIDPROIZVOD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDPROIZVOD.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDPROIZVOD.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDPROIZVOD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVPROIZVODRACUN.Location = point;
            this.label1NAZIVPROIZVODRACUN.Name = "label1NAZIVPROIZVODRACUN";
            this.label1NAZIVPROIZVODRACUN.TabIndex = 1;
            this.label1NAZIVPROIZVODRACUN.Tag = "labelNAZIVPROIZVODRACUN";
            this.label1NAZIVPROIZVODRACUN.Text = "Proizvod:";
            this.label1NAZIVPROIZVODRACUN.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVPROIZVODRACUN.AutoSize = true;
            this.label1NAZIVPROIZVODRACUN.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1NAZIVPROIZVODRACUN.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVPROIZVODRACUN.Appearance.ForeColor = Color.Black;
            this.label1NAZIVPROIZVODRACUN.BackColor = Color.Transparent;
            this.layoutManagerformRACUNRacunStavke.Controls.Add(this.label1NAZIVPROIZVODRACUN, 0, 2);
            this.layoutManagerformRACUNRacunStavke.SetColumnSpan(this.label1NAZIVPROIZVODRACUN, 1);
            this.layoutManagerformRACUNRacunStavke.SetRowSpan(this.label1NAZIVPROIZVODRACUN, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVPROIZVODRACUN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVPROIZVODRACUN.MinimumSize = size;
            size = new System.Drawing.Size(0x49, 0x17);
            this.label1NAZIVPROIZVODRACUN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVPROIZVODRACUN.Location = point;
            this.textNAZIVPROIZVODRACUN.Name = "textNAZIVPROIZVODRACUN";
            this.textNAZIVPROIZVODRACUN.Tag = "NAZIVPROIZVODRACUN";
            this.textNAZIVPROIZVODRACUN.TabIndex = 0;
            this.textNAZIVPROIZVODRACUN.Anchor = AnchorStyles.Left;
            this.textNAZIVPROIZVODRACUN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVPROIZVODRACUN.ReadOnly = false;
            this.textNAZIVPROIZVODRACUN.DataBindings.Add(new Binding("Text", this.bindingSourceRACUNRacunStavke, "NAZIVPROIZVODRACUN"));
            this.textNAZIVPROIZVODRACUN.Multiline = true;
            this.textNAZIVPROIZVODRACUN.MaxLength = 500;
            this.layoutManagerformRACUNRacunStavke.Controls.Add(this.textNAZIVPROIZVODRACUN, 1, 2);
            this.layoutManagerformRACUNRacunStavke.SetColumnSpan(this.textNAZIVPROIZVODRACUN, 1);
            this.layoutManagerformRACUNRacunStavke.SetRowSpan(this.textNAZIVPROIZVODRACUN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVPROIZVODRACUN.Margin = padding;
            size = new System.Drawing.Size(0x240, 110);
            this.textNAZIVPROIZVODRACUN.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 110);
            this.textNAZIVPROIZVODRACUN.Size = size;
            this.textNAZIVPROIZVODRACUN.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.label1CIJENARACUN.Location = point;
            this.label1CIJENARACUN.Name = "label1CIJENARACUN";
            this.label1CIJENARACUN.TabIndex = 1;
            this.label1CIJENARACUN.Tag = "labelCIJENARACUN";
            this.label1CIJENARACUN.Text = "Cijena:";
            this.label1CIJENARACUN.StyleSetName = "FieldUltraLabel";
            this.label1CIJENARACUN.AutoSize = true;
            this.label1CIJENARACUN.Anchor = AnchorStyles.Left;
            this.label1CIJENARACUN.Appearance.TextVAlign = VAlign.Middle;
            this.label1CIJENARACUN.Appearance.ForeColor = Color.Black;
            this.label1CIJENARACUN.BackColor = Color.Transparent;
            this.layoutManagerformRACUNRacunStavke.Controls.Add(this.label1CIJENARACUN, 0, 3);
            this.layoutManagerformRACUNRacunStavke.SetColumnSpan(this.label1CIJENARACUN, 1);
            this.layoutManagerformRACUNRacunStavke.SetRowSpan(this.label1CIJENARACUN, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1CIJENARACUN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1CIJENARACUN.MinimumSize = size;
            size = new System.Drawing.Size(0x3a, 0x17);
            this.label1CIJENARACUN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textCIJENARACUN.Location = point;
            this.textCIJENARACUN.Name = "textCIJENARACUN";
            this.textCIJENARACUN.Tag = "CIJENARACUN";
            this.textCIJENARACUN.TabIndex = 0;
            this.textCIJENARACUN.Anchor = AnchorStyles.Left;
            this.textCIJENARACUN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textCIJENARACUN.ReadOnly = false;
            this.textCIJENARACUN.PromptChar = ' ';
            this.textCIJENARACUN.Enter += new EventHandler(this.numericEditor_Enter);
            this.textCIJENARACUN.DataBindings.Add(new Binding("Value", this.bindingSourceRACUNRacunStavke, "CIJENARACUN"));
            this.textCIJENARACUN.NumericType = NumericType.Double;
            this.textCIJENARACUN.MaxValue = 79228162514264337593543950335M;
            this.textCIJENARACUN.MinValue = -79228162514264337593543950335M;
            this.textCIJENARACUN.MaskInput = "{LOC}-nnnnn.nnnn";
            this.layoutManagerformRACUNRacunStavke.Controls.Add(this.textCIJENARACUN, 1, 3);
            this.layoutManagerformRACUNRacunStavke.SetColumnSpan(this.textCIJENARACUN, 1);
            this.layoutManagerformRACUNRacunStavke.SetRowSpan(this.textCIJENARACUN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textCIJENARACUN.Margin = padding;
            size = new System.Drawing.Size(0x52, 0x16);
            this.textCIJENARACUN.MinimumSize = size;
            size = new System.Drawing.Size(0x52, 0x16);
            this.textCIJENARACUN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KOLICINA.Location = point;
            this.label1KOLICINA.Name = "label1KOLICINA";
            this.label1KOLICINA.TabIndex = 1;
            this.label1KOLICINA.Tag = "labelKOLICINA";
            this.label1KOLICINA.Text = "Količina:";
            this.label1KOLICINA.StyleSetName = "FieldUltraLabel";
            this.label1KOLICINA.AutoSize = true;
            this.label1KOLICINA.Anchor = AnchorStyles.Left;
            this.label1KOLICINA.Appearance.TextVAlign = VAlign.Middle;
            this.label1KOLICINA.Appearance.ForeColor = Color.Black;
            this.label1KOLICINA.BackColor = Color.Transparent;
            this.layoutManagerformRACUNRacunStavke.Controls.Add(this.label1KOLICINA, 0, 4);
            this.layoutManagerformRACUNRacunStavke.SetColumnSpan(this.label1KOLICINA, 1);
            this.layoutManagerformRACUNRacunStavke.SetRowSpan(this.label1KOLICINA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KOLICINA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KOLICINA.MinimumSize = size;
            size = new System.Drawing.Size(0x44, 0x17);
            this.label1KOLICINA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textKOLICINA.Location = point;
            this.textKOLICINA.Name = "textKOLICINA";
            this.textKOLICINA.Tag = "KOLICINA";
            this.textKOLICINA.TabIndex = 0;
            this.textKOLICINA.Anchor = AnchorStyles.Left;
            this.textKOLICINA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textKOLICINA.ReadOnly = false;
            this.textKOLICINA.PromptChar = ' ';
            this.textKOLICINA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textKOLICINA.DataBindings.Add(new Binding("Value", this.bindingSourceRACUNRacunStavke, "KOLICINA"));
            this.textKOLICINA.NumericType = NumericType.Double;
            this.textKOLICINA.MaxValue = 79228162514264337593543950335M;
            this.textKOLICINA.MinValue = -79228162514264337593543950335M;
            this.textKOLICINA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformRACUNRacunStavke.Controls.Add(this.textKOLICINA, 1, 4);
            this.layoutManagerformRACUNRacunStavke.SetColumnSpan(this.textKOLICINA, 1);
            this.layoutManagerformRACUNRacunStavke.SetRowSpan(this.textKOLICINA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textKOLICINA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textKOLICINA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textKOLICINA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RABAT.Location = point;
            this.label1RABAT.Name = "label1RABAT";
            this.label1RABAT.TabIndex = 1;
            this.label1RABAT.Tag = "labelRABAT";
            this.label1RABAT.Text = "% Rabat:";
            this.label1RABAT.StyleSetName = "FieldUltraLabel";
            this.label1RABAT.AutoSize = true;
            this.label1RABAT.Anchor = AnchorStyles.Left;
            this.label1RABAT.Appearance.TextVAlign = VAlign.Middle;
            this.label1RABAT.Appearance.ForeColor = Color.Black;
            this.label1RABAT.BackColor = Color.Transparent;
            this.layoutManagerformRACUNRacunStavke.Controls.Add(this.label1RABAT, 0, 5);
            this.layoutManagerformRACUNRacunStavke.SetColumnSpan(this.label1RABAT, 1);
            this.layoutManagerformRACUNRacunStavke.SetRowSpan(this.label1RABAT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RABAT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RABAT.MinimumSize = size;
            size = new System.Drawing.Size(0x4a, 0x17);
            this.label1RABAT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRABAT.Location = point;
            this.textRABAT.Name = "textRABAT";
            this.textRABAT.Tag = "RABAT";
            this.textRABAT.TabIndex = 0;
            this.textRABAT.Anchor = AnchorStyles.Left;
            this.textRABAT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRABAT.ReadOnly = false;
            this.textRABAT.PromptChar = ' ';
            this.textRABAT.Enter += new EventHandler(this.numericEditor_Enter);
            this.textRABAT.DataBindings.Add(new Binding("Value", this.bindingSourceRACUNRacunStavke, "RABAT"));
            this.textRABAT.NumericType = NumericType.Double;
            this.textRABAT.MaxValue = 79228162514264337593543950335M;
            this.textRABAT.MinValue = -79228162514264337593543950335M;
            this.textRABAT.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformRACUNRacunStavke.Controls.Add(this.textRABAT, 1, 5);
            this.layoutManagerformRACUNRacunStavke.SetColumnSpan(this.textRABAT, 1);
            this.layoutManagerformRACUNRacunStavke.SetRowSpan(this.textRABAT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRABAT.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textRABAT.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textRABAT.Size = size;
            this.Controls.Add(this.layoutManagerformRACUNRacunStavke);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRACUNRacunStavke;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RACUNFormRACUNRacunStavkeUserControl";
            this.Text = " Stavke racuna";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RACUNFormUserControl_Load);
            this.layoutManagerformRACUNRacunStavke.ResumeLayout(false);
            this.layoutManagerformRACUNRacunStavke.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRACUNRacunStavke).EndInit();
            ((ISupportInitialize) this.textBROJSTAVKE).EndInit();
            ((ISupportInitialize) this.textNAZIVPROIZVODRACUN).EndInit();
            ((ISupportInitialize) this.textCIJENARACUN).EndInit();
            ((ISupportInitialize) this.textKOLICINA).EndInit();
            ((ISupportInitialize) this.textRABAT).EndInit();
            this.dsRACUNDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RACUNController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRACUNRacunStavke, this.RACUNController.WorkItem, this))
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
            this.label1BROJSTAVKE.Text = StringResources.RACUNBROJSTAVKEDescription;
            this.label1IDPROIZVOD.Text = StringResources.RACUNIDPROIZVODDescription;
            this.label1NAZIVPROIZVODRACUN.Text = StringResources.RACUNNAZIVPROIZVODRACUNDescription;
            this.label1CIJENARACUN.Text = StringResources.RACUNCIJENARACUNDescription;
            this.label1KOLICINA.Text = StringResources.RACUNKOLICINADescription;
            this.label1RABAT.Text = StringResources.RACUNRABATDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIDPROIZVOD(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("PROIZVOD", null, DeklaritMode.Insert));
            }
        }

        private void RACUNFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RACUNRACUNRacunStavkeLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RACUNController.WorkItem.Items.Contains("RACUNRacunStavke|RACUNRacunStavke"))
            {
                this.RACUNController.WorkItem.Items.Add(this.bindingSourceRACUNRacunStavke, "RACUNRacunStavke|RACUNRacunStavke");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("RACUNRacunStavkeSaveAndClose")]
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
                    ((DataRowView) this.bindingSourceRACUNRacunStavke.Current).Row["IDPROIZVOD"] = RuntimeHelpers.GetObjectValue(row["IDPROIZVOD"]);
                    ((DataRowView) this.bindingSourceRACUNRacunStavke.Current).Row["NAZIVPROIZVOD"] = RuntimeHelpers.GetObjectValue(row["NAZIVPROIZVOD"]);
                    ((DataRowView) this.bindingSourceRACUNRacunStavke.Current).Row["CIJENA"] = RuntimeHelpers.GetObjectValue(row["CIJENA"]);
                    ((DataRowView) this.bindingSourceRACUNRacunStavke.Current).Row["IDJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(row["IDJEDINICAMJERE"]);
                    ((DataRowView) this.bindingSourceRACUNRacunStavke.Current).Row["FINPOREZSTOPA"] = RuntimeHelpers.GetObjectValue(row["FINPOREZSTOPA"]);
                    ((DataRowView) this.bindingSourceRACUNRacunStavke.Current).Row["NAZIVJEDINICAMJERE"] = RuntimeHelpers.GetObjectValue(row["NAZIVJEDINICAMJERE"]);
                    this.bindingSourceRACUNRacunStavke.ResetCurrentItem();
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

        private void textNAZIVPROIZVODRACUN_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (this.comboIDPROIZVOD.SelectedItem == null)
                return;

            DataRow row = ((DataRowView) this.comboIDPROIZVOD.SelectedItem.ListObject).Row;
            if (row != null)
            {
                if (((DataRowView) this.bindingSourceRACUNRacunStavke.Current).Row["NAZIVPROIZVODRACUN"].ToString() == "")
                {
                    ((DataRowView) this.bindingSourceRACUNRacunStavke.Current).Row["NAZIVPROIZVODRACUN"] = RuntimeHelpers.GetObjectValue(row["NAZIVPROIZVOD"]);
                }
                if (decimal.Compare(DB.N20(RuntimeHelpers.GetObjectValue(this.textCIJENARACUN.Value)), decimal.Zero) == 0)
                {
                    ((DataRowView) this.bindingSourceRACUNRacunStavke.Current).Row["CIJENARACUN"] = RuntimeHelpers.GetObjectValue(row["CIJENA"]);
                }
                ((DataRowView) this.bindingSourceRACUNRacunStavke.Current).Row["FINPOREZSTOPARACUN"] = RuntimeHelpers.GetObjectValue(row["FINPOREZSTOPA"]);
                this.bindingSourceRACUNRacunStavke.ResetCurrentItem();
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

        protected virtual UltraLabel label1BROJSTAVKE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BROJSTAVKE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BROJSTAVKE = value;
            }
        }

        protected virtual UltraLabel label1CIJENARACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1CIJENARACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1CIJENARACUN = value;
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

        protected virtual UltraLabel label1KOLICINA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KOLICINA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KOLICINA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVPROIZVODRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVPROIZVODRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVPROIZVODRACUN = value;
            }
        }

        protected virtual UltraLabel label1RABAT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RABAT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RABAT = value;
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
        public NetAdvantage.Controllers.RACUNController RACUNController { get; set; }

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

        protected virtual UltraNumericEditor textBROJSTAVKE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBROJSTAVKE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textBROJSTAVKE = value;
            }
        }

        protected virtual UltraNumericEditor textCIJENARACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textCIJENARACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textCIJENARACUN = value;
            }
        }

        protected virtual UltraNumericEditor textKOLICINA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textKOLICINA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textKOLICINA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVPROIZVODRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVPROIZVODRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                CancelEventHandler handler = new CancelEventHandler(this.textNAZIVPROIZVODRACUN_BeforeEnterEditMode);
                if (this._textNAZIVPROIZVODRACUN != null)
                {
                    this._textNAZIVPROIZVODRACUN.BeforeEnterEditMode -= handler;
                }
                this._textNAZIVPROIZVODRACUN = value;
                if (this._textNAZIVPROIZVODRACUN != null)
                {
                    this._textNAZIVPROIZVODRACUN.BeforeEnterEditMode += handler;
                }
            }
        }

        protected virtual UltraNumericEditor textRABAT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRABAT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRABAT = value;
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

