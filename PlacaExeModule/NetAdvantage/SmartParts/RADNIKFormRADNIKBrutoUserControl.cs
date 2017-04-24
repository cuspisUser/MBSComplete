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
    using Microsoft.VisualBasic.CompilerServices;
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
    public class RADNIKFormRADNIKBrutoUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboBRUTOELEMENTIDELEMENT")]
        private PROVIDER_BRUTOComboBox _comboBRUTOELEMENTIDELEMENT;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1BRUTOELEMENTIDELEMENT")]
        private UltraLabel _label1BRUTOELEMENTIDELEMENT;
        [AccessedThroughProperty("label1BRUTOIZNOS")]
        private UltraLabel _label1BRUTOIZNOS;
        [AccessedThroughProperty("label1BRUTOPOSTOTAK")]
        private UltraLabel _label1BRUTOPOSTOTAK;
        [AccessedThroughProperty("label1BRUTOSATI")]
        private UltraLabel _label1BRUTOSATI;
        [AccessedThroughProperty("label1BRUTOSATNICA")]
        private UltraLabel _label1BRUTOSATNICA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textBRUTOIZNOS")]
        private UltraNumericEditor _textBRUTOIZNOS;
        [AccessedThroughProperty("textBRUTOPOSTOTAK")]
        private UltraNumericEditor _textBRUTOPOSTOTAK;
        [AccessedThroughProperty("textBRUTOSATI")]
        private UltraNumericEditor _textBRUTOSATI;
        [AccessedThroughProperty("textBRUTOSATNICA")]
        private UltraNumericEditor _textBRUTOSATNICA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRADNIKBruto;
        private IContainer components;
        private RADNIKDataSet dsRADNIKDataSet1;
        protected TableLayoutPanel layoutManagerformRADNIKBruto;
        private bool m_AutoNumber;
        private GenericFormClass m_BaseMethods;
        private RADNIKDataSet.RADNIKBrutoRow m_CurrentRow;
        private ArrayList m_DataGrids;
        private string m_FirstLevelName;
        private string m_FrameworkDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public RADNIKFormRADNIKBrutoUserControl()
        {
            base.Load += new EventHandler(this.RADNIKFormRADNIKBrutoUserControl_Load);
            this.components = null;
            this.m_FrameworkDescription = StringResources.RADNIKDescription;
            this.m_DataGrids = new ArrayList();
            this.m_FirstLevelName = "RADNIKBruto";
            this.m_AutoNumber = false;
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("RADNIKBrutoAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("RADNIKBrutoAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (RADNIKDataSet.RADNIKBrutoRow) ((DataRowView) this.bindingSourceRADNIKBruto.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsRADNIKDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceRADNIKBruto.DataSource = this.RADNIKController.DataSet;
            this.dsRADNIKDataSet1 = this.RADNIKController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ELEMENT", Thread=ThreadOption.UserInterface)]
        public void comboBRUTOELEMENTIDELEMENT_Add(object sender, ComponentEventArgs e)
        {
            this.comboBRUTOELEMENTIDELEMENT.Fill();
        }

        private void comboBRUTOELEMENTIDELEMENT_Validating(object sender, CancelEventArgs e)
        {
            decimal num = DB.RoundUpDecimale(placa.Test(Conversions.ToInteger(this.m_ParentRow["idradnik"]), Conversions.ToInteger(this.comboBRUTOELEMENTIDELEMENT.Value), Configuration.ConnectionString, decimal.Zero, decimal.Zero), 2);
            this.textBRUTOSATNICA.Value = num;
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

        private void FillProviderCombocomboBRUTOELEMENTIDELEMENT()
        {
            object objectValue = RuntimeHelpers.GetObjectValue(this.comboBRUTOELEMENTIDELEMENT.Value);
            this.comboBRUTOELEMENTIDELEMENT.Fill();
            if (objectValue != null)
            {
                this.comboBRUTOELEMENTIDELEMENT.Value = RuntimeHelpers.GetObjectValue(objectValue);
            }
        }

        public void Initialize(DeklaritMode mode, DataRow parentRow, bool isCopy)
        {
            this.m_ParentRow = parentRow;
            this.dsRADNIKDataSet1 = (RADNIKDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceRADNIKBruto.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsRADNIKDataSet1.Tables["RADNIKBruto"]);
            this.bindingSourceRADNIKBruto.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RADNIK", this.m_Mode, this.dsRADNIKDataSet1, this.dsRADNIKDataSet1.RADNIKBruto.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (RADNIKDataSet.RADNIKBrutoRow) ((DataRowView) this.bindingSourceRADNIKBruto.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RADNIKDataSet.RADNIKBrutoRow) ((DataRowView) this.bindingSourceRADNIKBruto.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.FillProviderCombocomboBRUTOELEMENTIDELEMENT();
            if (this.m_BaseMethods.IsInsert())
            {
                this.comboBRUTOELEMENTIDELEMENT.SelectedIndex = -1;
            }
            if (this.comboBRUTOELEMENTIDELEMENT.DataBindings["Value"] != null)
            {
                this.comboBRUTOELEMENTIDELEMENT.DataBindings.Remove(this.comboBRUTOELEMENTIDELEMENT.DataBindings["Value"]);
            }
            this.comboBRUTOELEMENTIDELEMENT.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKBruto, "BRUTOELEMENTIDELEMENT"));
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(RADNIKFormRADNIKBrutoUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRADNIKBruto = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIKBruto).BeginInit();
            this.layoutManagerformRADNIKBruto = new TableLayoutPanel();
            this.layoutManagerformRADNIKBruto.SuspendLayout();
            this.layoutManagerformRADNIKBruto.AutoSize = true;
            this.layoutManagerformRADNIKBruto.Dock = DockStyle.Fill;
            this.layoutManagerformRADNIKBruto.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRADNIKBruto.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRADNIKBruto.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRADNIKBruto.Size = size;
            this.layoutManagerformRADNIKBruto.ColumnCount = 2;
            this.layoutManagerformRADNIKBruto.RowCount = 6;
            this.layoutManagerformRADNIKBruto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIKBruto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIKBruto.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKBruto.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKBruto.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKBruto.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKBruto.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKBruto.RowStyles.Add(new RowStyle());
            this.label1BRUTOELEMENTIDELEMENT = new UltraLabel();
            this.comboBRUTOELEMENTIDELEMENT = new PROVIDER_BRUTOComboBox();
            this.label1BRUTOSATNICA = new UltraLabel();
            this.textBRUTOSATNICA = new UltraNumericEditor();
            this.label1BRUTOSATI = new UltraLabel();
            this.textBRUTOSATI = new UltraNumericEditor();
            this.label1BRUTOPOSTOTAK = new UltraLabel();
            this.textBRUTOPOSTOTAK = new UltraNumericEditor();
            this.label1BRUTOIZNOS = new UltraLabel();
            this.textBRUTOIZNOS = new UltraNumericEditor();
            ((ISupportInitialize) this.textBRUTOSATNICA).BeginInit();
            ((ISupportInitialize) this.textBRUTOSATI).BeginInit();
            ((ISupportInitialize) this.textBRUTOPOSTOTAK).BeginInit();
            ((ISupportInitialize) this.textBRUTOIZNOS).BeginInit();
            this.dsRADNIKDataSet1 = new RADNIKDataSet();
            this.dsRADNIKDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRADNIKDataSet1.DataSetName = "dsRADNIK";
            this.dsRADNIKDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRADNIKBruto.DataSource = this.dsRADNIKDataSet1;
            this.bindingSourceRADNIKBruto.DataMember = "RADNIKBruto";
            ((ISupportInitialize) this.bindingSourceRADNIKBruto).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1BRUTOELEMENTIDELEMENT.Location = point;
            this.label1BRUTOELEMENTIDELEMENT.Name = "label1BRUTOELEMENTIDELEMENT";
            this.label1BRUTOELEMENTIDELEMENT.TabIndex = 1;
            this.label1BRUTOELEMENTIDELEMENT.Tag = "labelBRUTOELEMENTIDELEMENT";
            this.label1BRUTOELEMENTIDELEMENT.Text = "Šifra:";
            this.label1BRUTOELEMENTIDELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1BRUTOELEMENTIDELEMENT.AutoSize = true;
            this.label1BRUTOELEMENTIDELEMENT.Anchor = AnchorStyles.Left;
            this.label1BRUTOELEMENTIDELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1BRUTOELEMENTIDELEMENT.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1BRUTOELEMENTIDELEMENT.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1BRUTOELEMENTIDELEMENT.ImageSize = size;
            this.label1BRUTOELEMENTIDELEMENT.Appearance.ForeColor = Color.Black;
            this.label1BRUTOELEMENTIDELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKBruto.Controls.Add(this.label1BRUTOELEMENTIDELEMENT, 0, 0);
            this.layoutManagerformRADNIKBruto.SetColumnSpan(this.label1BRUTOELEMENTIDELEMENT, 1);
            this.layoutManagerformRADNIKBruto.SetRowSpan(this.label1BRUTOELEMENTIDELEMENT, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1BRUTOELEMENTIDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BRUTOELEMENTIDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1BRUTOELEMENTIDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboBRUTOELEMENTIDELEMENT.Location = point;
            this.comboBRUTOELEMENTIDELEMENT.Name = "comboBRUTOELEMENTIDELEMENT";
            this.comboBRUTOELEMENTIDELEMENT.Tag = "BRUTOELEMENTIDELEMENT";
            this.comboBRUTOELEMENTIDELEMENT.TabIndex = 0;
            this.comboBRUTOELEMENTIDELEMENT.Anchor = AnchorStyles.Left;
            this.comboBRUTOELEMENTIDELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboBRUTOELEMENTIDELEMENT.DropDownStyle = DropDownStyle.DropDown;
            this.comboBRUTOELEMENTIDELEMENT.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboBRUTOELEMENTIDELEMENT.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboBRUTOELEMENTIDELEMENT.Enabled = true;
            this.comboBRUTOELEMENTIDELEMENT.FillAtStartup = false;
            this.comboBRUTOELEMENTIDELEMENT.ShowPictureBox = true;
            this.comboBRUTOELEMENTIDELEMENT.PictureBoxClicked += new EventHandler(this.PictureBoxClickedBRUTOELEMENTIDELEMENT);
            this.comboBRUTOELEMENTIDELEMENT.ValueMember = "IDELEMENT";
            this.comboBRUTOELEMENTIDELEMENT.SelectionChanged += new EventHandler(this.SelectedIndexChangedBRUTOELEMENTIDELEMENT);
            this.layoutManagerformRADNIKBruto.Controls.Add(this.comboBRUTOELEMENTIDELEMENT, 1, 0);
            this.layoutManagerformRADNIKBruto.SetColumnSpan(this.comboBRUTOELEMENTIDELEMENT, 1);
            this.layoutManagerformRADNIKBruto.SetRowSpan(this.comboBRUTOELEMENTIDELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboBRUTOELEMENTIDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboBRUTOELEMENTIDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboBRUTOELEMENTIDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1BRUTOSATNICA.Location = point;
            this.label1BRUTOSATNICA.Name = "label1BRUTOSATNICA";
            this.label1BRUTOSATNICA.TabIndex = 1;
            this.label1BRUTOSATNICA.Tag = "labelBRUTOSATNICA";
            this.label1BRUTOSATNICA.Text = "Satnica:";
            this.label1BRUTOSATNICA.StyleSetName = "FieldUltraLabel";
            this.label1BRUTOSATNICA.AutoSize = true;
            this.label1BRUTOSATNICA.Anchor = AnchorStyles.Left;
            this.label1BRUTOSATNICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1BRUTOSATNICA.Appearance.ForeColor = Color.Black;
            this.label1BRUTOSATNICA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKBruto.Controls.Add(this.label1BRUTOSATNICA, 0, 1);
            this.layoutManagerformRADNIKBruto.SetColumnSpan(this.label1BRUTOSATNICA, 1);
            this.layoutManagerformRADNIKBruto.SetRowSpan(this.label1BRUTOSATNICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1BRUTOSATNICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BRUTOSATNICA.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x17);
            this.label1BRUTOSATNICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textBRUTOSATNICA.Location = point;
            this.textBRUTOSATNICA.Name = "textBRUTOSATNICA";
            this.textBRUTOSATNICA.Tag = "BRUTOSATNICA";
            this.textBRUTOSATNICA.TabIndex = 0;
            this.textBRUTOSATNICA.Anchor = AnchorStyles.Left;
            this.textBRUTOSATNICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textBRUTOSATNICA.ReadOnly = false;
            this.textBRUTOSATNICA.PromptChar = ' ';
            this.textBRUTOSATNICA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textBRUTOSATNICA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKBruto, "BRUTOSATNICA"));
            this.textBRUTOSATNICA.NumericType = NumericType.Double;
            this.textBRUTOSATNICA.MaxValue = 79228162514264337593543950335M;
            this.textBRUTOSATNICA.MinValue = -79228162514264337593543950335M;
            this.textBRUTOSATNICA.MaskInput = "{LOC}-nnnn.nnnnnnnn";
            this.layoutManagerformRADNIKBruto.Controls.Add(this.textBRUTOSATNICA, 1, 1);
            this.layoutManagerformRADNIKBruto.SetColumnSpan(this.textBRUTOSATNICA, 1);
            this.layoutManagerformRADNIKBruto.SetRowSpan(this.textBRUTOSATNICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBRUTOSATNICA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textBRUTOSATNICA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textBRUTOSATNICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1BRUTOSATI.Location = point;
            this.label1BRUTOSATI.Name = "label1BRUTOSATI";
            this.label1BRUTOSATI.TabIndex = 1;
            this.label1BRUTOSATI.Tag = "labelBRUTOSATI";
            this.label1BRUTOSATI.Text = "Sati:";
            this.label1BRUTOSATI.StyleSetName = "FieldUltraLabel";
            this.label1BRUTOSATI.AutoSize = true;
            this.label1BRUTOSATI.Anchor = AnchorStyles.Left;
            this.label1BRUTOSATI.Appearance.TextVAlign = VAlign.Middle;
            this.label1BRUTOSATI.Appearance.ForeColor = Color.Black;
            this.label1BRUTOSATI.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKBruto.Controls.Add(this.label1BRUTOSATI, 0, 2);
            this.layoutManagerformRADNIKBruto.SetColumnSpan(this.label1BRUTOSATI, 1);
            this.layoutManagerformRADNIKBruto.SetRowSpan(this.label1BRUTOSATI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1BRUTOSATI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BRUTOSATI.MinimumSize = size;
            size = new System.Drawing.Size(0x2b, 0x17);
            this.label1BRUTOSATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textBRUTOSATI.Location = point;
            this.textBRUTOSATI.Name = "textBRUTOSATI";
            this.textBRUTOSATI.Tag = "BRUTOSATI";
            this.textBRUTOSATI.TabIndex = 0;
            this.textBRUTOSATI.Anchor = AnchorStyles.Left;
            this.textBRUTOSATI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textBRUTOSATI.ReadOnly = false;
            this.textBRUTOSATI.PromptChar = ' ';
            this.textBRUTOSATI.Enter += new EventHandler(this.numericEditor_Enter);
            this.textBRUTOSATI.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKBruto, "BRUTOSATI"));
            this.textBRUTOSATI.NumericType = NumericType.Double;
            this.textBRUTOSATI.MaxValue = 79228162514264337593543950335M;
            this.textBRUTOSATI.MinValue = -79228162514264337593543950335M;
            this.textBRUTOSATI.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformRADNIKBruto.Controls.Add(this.textBRUTOSATI, 1, 2);
            this.layoutManagerformRADNIKBruto.SetColumnSpan(this.textBRUTOSATI, 1);
            this.layoutManagerformRADNIKBruto.SetRowSpan(this.textBRUTOSATI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBRUTOSATI.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textBRUTOSATI.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textBRUTOSATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1BRUTOPOSTOTAK.Location = point;
            this.label1BRUTOPOSTOTAK.Name = "label1BRUTOPOSTOTAK";
            this.label1BRUTOPOSTOTAK.TabIndex = 1;
            this.label1BRUTOPOSTOTAK.Tag = "labelBRUTOPOSTOTAK";
            this.label1BRUTOPOSTOTAK.Text = "Postotak:";
            this.label1BRUTOPOSTOTAK.StyleSetName = "FieldUltraLabel";
            this.label1BRUTOPOSTOTAK.AutoSize = true;
            this.label1BRUTOPOSTOTAK.Anchor = AnchorStyles.Left;
            this.label1BRUTOPOSTOTAK.Appearance.TextVAlign = VAlign.Middle;
            this.label1BRUTOPOSTOTAK.Appearance.ForeColor = Color.Black;
            this.label1BRUTOPOSTOTAK.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKBruto.Controls.Add(this.label1BRUTOPOSTOTAK, 0, 3);
            this.layoutManagerformRADNIKBruto.SetColumnSpan(this.label1BRUTOPOSTOTAK, 1);
            this.layoutManagerformRADNIKBruto.SetRowSpan(this.label1BRUTOPOSTOTAK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1BRUTOPOSTOTAK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BRUTOPOSTOTAK.MinimumSize = size;
            size = new System.Drawing.Size(0x4a, 0x17);
            this.label1BRUTOPOSTOTAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textBRUTOPOSTOTAK.Location = point;
            this.textBRUTOPOSTOTAK.Name = "textBRUTOPOSTOTAK";
            this.textBRUTOPOSTOTAK.Tag = "BRUTOPOSTOTAK";
            this.textBRUTOPOSTOTAK.TabIndex = 0;
            this.textBRUTOPOSTOTAK.Anchor = AnchorStyles.Left;
            this.textBRUTOPOSTOTAK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textBRUTOPOSTOTAK.ReadOnly = false;
            this.textBRUTOPOSTOTAK.PromptChar = ' ';
            this.textBRUTOPOSTOTAK.Enter += new EventHandler(this.numericEditor_Enter);
            this.textBRUTOPOSTOTAK.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKBruto, "BRUTOPOSTOTAK"));
            this.textBRUTOPOSTOTAK.NumericType = NumericType.Double;
            this.textBRUTOPOSTOTAK.MaxValue = 79228162514264337593543950335M;
            this.textBRUTOPOSTOTAK.MinValue = -79228162514264337593543950335M;
            this.textBRUTOPOSTOTAK.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformRADNIKBruto.Controls.Add(this.textBRUTOPOSTOTAK, 1, 3);
            this.layoutManagerformRADNIKBruto.SetColumnSpan(this.textBRUTOPOSTOTAK, 1);
            this.layoutManagerformRADNIKBruto.SetRowSpan(this.textBRUTOPOSTOTAK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBRUTOPOSTOTAK.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textBRUTOPOSTOTAK.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textBRUTOPOSTOTAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1BRUTOIZNOS.Location = point;
            this.label1BRUTOIZNOS.Name = "label1BRUTOIZNOS";
            this.label1BRUTOIZNOS.TabIndex = 1;
            this.label1BRUTOIZNOS.Tag = "labelBRUTOIZNOS";
            this.label1BRUTOIZNOS.Text = "Iznos:";
            this.label1BRUTOIZNOS.StyleSetName = "FieldUltraLabel";
            this.label1BRUTOIZNOS.AutoSize = true;
            this.label1BRUTOIZNOS.Anchor = AnchorStyles.Left;
            this.label1BRUTOIZNOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1BRUTOIZNOS.Appearance.ForeColor = Color.Black;
            this.label1BRUTOIZNOS.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKBruto.Controls.Add(this.label1BRUTOIZNOS, 0, 4);
            this.layoutManagerformRADNIKBruto.SetColumnSpan(this.label1BRUTOIZNOS, 1);
            this.layoutManagerformRADNIKBruto.SetRowSpan(this.label1BRUTOIZNOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1BRUTOIZNOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BRUTOIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1BRUTOIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textBRUTOIZNOS.Location = point;
            this.textBRUTOIZNOS.Name = "textBRUTOIZNOS";
            this.textBRUTOIZNOS.Tag = "BRUTOIZNOS";
            this.textBRUTOIZNOS.TabIndex = 0;
            this.textBRUTOIZNOS.Anchor = AnchorStyles.Left;
            this.textBRUTOIZNOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textBRUTOIZNOS.ReadOnly = false;
            this.textBRUTOIZNOS.PromptChar = ' ';
            this.textBRUTOIZNOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textBRUTOIZNOS.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKBruto, "BRUTOIZNOS"));
            this.textBRUTOIZNOS.NumericType = NumericType.Double;
            this.textBRUTOIZNOS.MaxValue = 79228162514264337593543950335M;
            this.textBRUTOIZNOS.MinValue = -79228162514264337593543950335M;
            this.textBRUTOIZNOS.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformRADNIKBruto.Controls.Add(this.textBRUTOIZNOS, 1, 4);
            this.layoutManagerformRADNIKBruto.SetColumnSpan(this.textBRUTOIZNOS, 1);
            this.layoutManagerformRADNIKBruto.SetRowSpan(this.textBRUTOIZNOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBRUTOIZNOS.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textBRUTOIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textBRUTOIZNOS.Size = size;
            this.Controls.Add(this.layoutManagerformRADNIKBruto);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRADNIKBruto;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RADNIKFormRADNIKBrutoUserControl";
            this.Text = " Bruto elementi";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RADNIKFormUserControl_Load);
            this.layoutManagerformRADNIKBruto.ResumeLayout(false);
            this.layoutManagerformRADNIKBruto.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRADNIKBruto).EndInit();
            ((ISupportInitialize) this.textBRUTOSATNICA).EndInit();
            ((ISupportInitialize) this.textBRUTOSATI).EndInit();
            ((ISupportInitialize) this.textBRUTOPOSTOTAK).EndInit();
            ((ISupportInitialize) this.textBRUTOIZNOS).EndInit();
            this.dsRADNIKDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RADNIKController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIKBruto, this.RADNIKController.WorkItem, this))
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
            this.label1BRUTOELEMENTIDELEMENT.Text = StringResources.RADNIKBRUTOELEMENTIDELEMENTDescription;
            this.label1BRUTOSATNICA.Text = StringResources.RADNIKBRUTOSATNICADescription;
            this.label1BRUTOSATI.Text = StringResources.RADNIKBRUTOSATIDescription;
            this.label1BRUTOPOSTOTAK.Text = StringResources.RADNIKBRUTOPOSTOTAKDescription;
            this.label1BRUTOIZNOS.Text = StringResources.RADNIKBRUTOIZNOSDescription;
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

        private void PictureBoxClickedBRUTOELEMENTIDELEMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ELEMENT", null, DeklaritMode.Insert));
            }
        }

        private void RADNIKFormRADNIKBrutoUserControl_Load(object sender, EventArgs e)
        {
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
            InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
        }

        private void RADNIKFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RADNIKRADNIKBrutoLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIKBruto|RADNIKBruto"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIKBruto, "RADNIKBruto|RADNIKBruto");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("RADNIKBrutoSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedBRUTOELEMENTIDELEMENT(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboBRUTOELEMENTIDELEMENT.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboBRUTOELEMENTIDELEMENT.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRADNIKBruto.Current).Row["BRUTOELEMENTIDELEMENT"] = RuntimeHelpers.GetObjectValue(row["IDELEMENT"]);
                    ((DataRowView) this.bindingSourceRADNIKBruto.Current).Row["BRUTOELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(row["NAZIVELEMENT"]);
                    ((DataRowView) this.bindingSourceRADNIKBruto.Current).Row["BRUTOELEMENTPOSTOTAK"] = RuntimeHelpers.GetObjectValue(row["POSTOTAK"]);
                    this.bindingSourceRADNIKBruto.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboBRUTOELEMENTIDELEMENT.Focus();
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

        private void textBRUTOELEMENTIDELEMENT_ValueChanged(object sender, EventArgs e)
        {
            if (this.comboBRUTOELEMENTIDELEMENT.Value != DBNull.Value)
            {
                decimal num = DB.RoundUpDecimale(placa.Test(Conversions.ToInteger(this.m_ParentRow["idradnik"]), Conversions.ToInteger(this.comboBRUTOELEMENTIDELEMENT.Value), Configuration.ConnectionString, decimal.Zero, decimal.Zero), 2);
            }
        }

        private void textBRUTOPOSTOTAK_Validating(object sender, CancelEventArgs e)
        {
            if (this.comboBRUTOELEMENTIDELEMENT.Value != DBNull.Value)
            {
                decimal num = Conversions.ToDecimal(this.textBRUTOIZNOS.Value != DBNull.Value ? this.textBRUTOIZNOS.Value : 0);
                decimal num3 = Conversions.ToDecimal(this.textBRUTOSATI.Value != DBNull.Value ? this.textBRUTOSATI.Value : 0);
                decimal num4 = Conversions.ToDecimal(this.textBRUTOSATNICA.Value != DBNull.Value ? this.textBRUTOSATNICA.Value : 0);
                decimal num2 = Conversions.ToDecimal(this.textBRUTOPOSTOTAK.Value != DBNull.Value ? this.textBRUTOPOSTOTAK.Value : 0);
                this.textBRUTOIZNOS.Value = DB.RoundUpDecimale(decimal.Divide(decimal.Multiply(decimal.Multiply(num3, num4), num2), 100M), 2);
            }
        }

        private void textBRUTOPOSTOTAK_ValueChanged(object sender, EventArgs e)
        {
        }

        private void textBRUTOSATI_Validating(object sender, CancelEventArgs e)
        {
            if (this.comboBRUTOELEMENTIDELEMENT.Value != DBNull.Value)
            {
                decimal num = Conversions.ToDecimal(this.textBRUTOIZNOS.Value != DBNull.Value ? this.textBRUTOIZNOS.Value : 0);
                decimal num3 = Conversions.ToDecimal(this.textBRUTOSATI.Value != DBNull.Value ? this.textBRUTOSATI.Value : 0);
                decimal num4 = Conversions.ToDecimal(this.textBRUTOSATNICA.Value != DBNull.Value ? this.textBRUTOSATNICA.Value : 0);
                decimal num2 = Conversions.ToDecimal(this.textBRUTOPOSTOTAK.Value != DBNull.Value ? this.textBRUTOPOSTOTAK.Value : 0);
                this.textBRUTOIZNOS.Value = DB.RoundUpDecimale(decimal.Divide(decimal.Multiply(decimal.Multiply(num3, num4), num2), 100M), 2);
            }
        }

        private void textBRUTOSATI_ValueChanged(object sender, EventArgs e)
        {
        }

        private void textBRUTOSATNICA_Validating(object sender, CancelEventArgs e)
        {
            if (this.comboBRUTOELEMENTIDELEMENT.Value != DBNull.Value)
            {
                decimal num = Conversions.ToDecimal(this.textBRUTOIZNOS.Value != DBNull.Value ? this.textBRUTOIZNOS.Value : 0);
                decimal num3 = Conversions.ToDecimal(this.textBRUTOSATI.Value != DBNull.Value ? this.textBRUTOSATI.Value : 0);
                decimal num4 = Conversions.ToDecimal(this.textBRUTOSATNICA.Value != DBNull.Value ? this.textBRUTOSATNICA.Value : 0);
                decimal num2 = Conversions.ToDecimal(this.textBRUTOPOSTOTAK.Value != DBNull.Value ? this.textBRUTOPOSTOTAK.Value : 0);
                this.textBRUTOIZNOS.Value = DB.RoundUpDecimale(decimal.Divide(decimal.Multiply(decimal.Multiply(num3, num4), num2), 100M), 2);
            }
        }

        private void textBRUTOSATNICA_ValueChanged(object sender, EventArgs e)
        {
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

        protected virtual PROVIDER_BRUTOComboBox comboBRUTOELEMENTIDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboBRUTOELEMENTIDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                CancelEventHandler handler = new CancelEventHandler(this.comboBRUTOELEMENTIDELEMENT_Validating);
                EventHandler handler2 = new EventHandler(this.textBRUTOELEMENTIDELEMENT_ValueChanged);
                if (this._comboBRUTOELEMENTIDELEMENT != null)
                {
                    this._comboBRUTOELEMENTIDELEMENT.Validating -= handler;
                    this._comboBRUTOELEMENTIDELEMENT.SelectionChanged -= handler2;
                }
                this._comboBRUTOELEMENTIDELEMENT = value;
                if (this._comboBRUTOELEMENTIDELEMENT != null)
                {
                    this._comboBRUTOELEMENTIDELEMENT.Validating += handler;
                    this._comboBRUTOELEMENTIDELEMENT.SelectionChanged += handler2;
                }
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

        protected virtual UltraLabel label1BRUTOELEMENTIDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BRUTOELEMENTIDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BRUTOELEMENTIDELEMENT = value;
            }
        }

        protected virtual UltraLabel label1BRUTOIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BRUTOIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BRUTOIZNOS = value;
            }
        }

        protected virtual UltraLabel label1BRUTOPOSTOTAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BRUTOPOSTOTAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BRUTOPOSTOTAK = value;
            }
        }

        protected virtual UltraLabel label1BRUTOSATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BRUTOSATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BRUTOSATI = value;
            }
        }

        protected virtual UltraLabel label1BRUTOSATNICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BRUTOSATNICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BRUTOSATNICA = value;
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

        protected virtual UltraNumericEditor textBRUTOIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBRUTOIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textBRUTOIZNOS = value;
            }
        }

        protected virtual UltraNumericEditor textBRUTOPOSTOTAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBRUTOPOSTOTAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                CancelEventHandler handler = new CancelEventHandler(this.textBRUTOPOSTOTAK_Validating);
                EventHandler handler2 = new EventHandler(this.textBRUTOPOSTOTAK_ValueChanged);
                if (this._textBRUTOPOSTOTAK != null)
                {
                    this._textBRUTOPOSTOTAK.Validating -= handler;
                    this._textBRUTOPOSTOTAK.ValueChanged -= handler2;
                }
                this._textBRUTOPOSTOTAK = value;
                if (this._textBRUTOPOSTOTAK != null)
                {
                    this._textBRUTOPOSTOTAK.Validating += handler;
                    this._textBRUTOPOSTOTAK.ValueChanged += handler2;
                }
            }
        }

        protected virtual UltraNumericEditor textBRUTOSATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBRUTOSATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                CancelEventHandler handler = new CancelEventHandler(this.textBRUTOSATI_Validating);
                EventHandler handler2 = new EventHandler(this.textBRUTOSATI_ValueChanged);
                if (this._textBRUTOSATI != null)
                {
                    this._textBRUTOSATI.Validating -= handler;
                    this._textBRUTOSATI.ValueChanged -= handler2;
                }
                this._textBRUTOSATI = value;
                if (this._textBRUTOSATI != null)
                {
                    this._textBRUTOSATI.Validating += handler;
                    this._textBRUTOSATI.ValueChanged += handler2;
                }
            }
        }

        protected virtual UltraNumericEditor textBRUTOSATNICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBRUTOSATNICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.textBRUTOSATNICA_ValueChanged);
                CancelEventHandler handler2 = new CancelEventHandler(this.textBRUTOSATNICA_Validating);
                if (this._textBRUTOSATNICA != null)
                {
                    this._textBRUTOSATNICA.ValueChanged -= handler;
                    this._textBRUTOSATNICA.Validating -= handler2;
                }
                this._textBRUTOSATNICA = value;
                if (this._textBRUTOSATNICA != null)
                {
                    this._textBRUTOSATNICA.ValueChanged += handler;
                    this._textBRUTOSATNICA.Validating += handler2;
                }
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

