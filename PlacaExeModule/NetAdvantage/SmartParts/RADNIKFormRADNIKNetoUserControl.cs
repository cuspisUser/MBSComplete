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
    public class RADNIKFormRADNIKNetoUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboNETOELEMENTIDELEMENT")]
        private PROVIDER_NETOComboBox _comboNETOELEMENTIDELEMENT;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1NETOELEMENTIDELEMENT")]
        private UltraLabel _label1NETOELEMENTIDELEMENT;
        [AccessedThroughProperty("label1NETOIZNOS")]
        private UltraLabel _label1NETOIZNOS;
        [AccessedThroughProperty("label1NETOPOSTOTAK")]
        private UltraLabel _label1NETOPOSTOTAK;
        [AccessedThroughProperty("label1NETOSATI")]
        private UltraLabel _label1NETOSATI;
        [AccessedThroughProperty("label1NETOSATNICA")]
        private UltraLabel _label1NETOSATNICA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textNETOIZNOS")]
        private UltraNumericEditor _textNETOIZNOS;
        [AccessedThroughProperty("textNETOPOSTOTAK")]
        private UltraNumericEditor _textNETOPOSTOTAK;
        [AccessedThroughProperty("textNETOSATI")]
        private UltraNumericEditor _textNETOSATI;
        [AccessedThroughProperty("textNETOSATNICA")]
        private UltraNumericEditor _textNETOSATNICA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRADNIKNeto;
        private IContainer components = null;
        private RADNIKDataSet dsRADNIKDataSet1;
        protected TableLayoutPanel layoutManagerformRADNIKNeto;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RADNIKDataSet.RADNIKNetoRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RADNIKNeto";
        private string m_FrameworkDescription = StringResources.RADNIKDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public RADNIKFormRADNIKNetoUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("RADNIKNetoAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("RADNIKNetoAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (RADNIKDataSet.RADNIKNetoRow) ((DataRowView) this.bindingSourceRADNIKNeto.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsRADNIKDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceRADNIKNeto.DataSource = this.RADNIKController.DataSet;
            this.dsRADNIKDataSet1 = this.RADNIKController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ELEMENT", Thread=ThreadOption.UserInterface)]
        public void comboNETOELEMENTIDELEMENT_Add(object sender, ComponentEventArgs e)
        {
            this.comboNETOELEMENTIDELEMENT.Fill();
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

        private void FillProviderCombocomboNETOELEMENTIDELEMENT()
        {
            object objectValue = RuntimeHelpers.GetObjectValue(this.comboNETOELEMENTIDELEMENT.Value);
            this.comboNETOELEMENTIDELEMENT.Fill();
            if (objectValue != null)
            {
                this.comboNETOELEMENTIDELEMENT.Value = RuntimeHelpers.GetObjectValue(objectValue);
            }
        }

        public void Initialize(DeklaritMode mode, DataRow parentRow, bool isCopy)
        {
            this.m_ParentRow = parentRow;
            this.dsRADNIKDataSet1 = (RADNIKDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceRADNIKNeto.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsRADNIKDataSet1.Tables["RADNIKNeto"]);
            this.bindingSourceRADNIKNeto.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RADNIK", this.m_Mode, this.dsRADNIKDataSet1, this.dsRADNIKDataSet1.RADNIKNeto.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (RADNIKDataSet.RADNIKNetoRow) ((DataRowView) this.bindingSourceRADNIKNeto.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RADNIKDataSet.RADNIKNetoRow) ((DataRowView) this.bindingSourceRADNIKNeto.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.FillProviderCombocomboNETOELEMENTIDELEMENT();
            if (this.m_BaseMethods.IsInsert())
            {
                this.comboNETOELEMENTIDELEMENT.SelectedIndex = -1;
            }
            if (this.comboNETOELEMENTIDELEMENT.DataBindings["Value"] != null)
            {
                this.comboNETOELEMENTIDELEMENT.DataBindings.Remove(this.comboNETOELEMENTIDELEMENT.DataBindings["Value"]);
            }
            this.comboNETOELEMENTIDELEMENT.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKNeto, "NETOELEMENTIDELEMENT"));
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(RADNIKFormRADNIKNetoUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRADNIKNeto = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIKNeto).BeginInit();
            this.layoutManagerformRADNIKNeto = new TableLayoutPanel();
            this.layoutManagerformRADNIKNeto.SuspendLayout();
            this.layoutManagerformRADNIKNeto.AutoSize = true;
            this.layoutManagerformRADNIKNeto.Dock = DockStyle.Fill;
            this.layoutManagerformRADNIKNeto.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRADNIKNeto.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRADNIKNeto.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRADNIKNeto.Size = size;
            this.layoutManagerformRADNIKNeto.ColumnCount = 2;
            this.layoutManagerformRADNIKNeto.RowCount = 6;
            this.layoutManagerformRADNIKNeto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIKNeto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIKNeto.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKNeto.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKNeto.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKNeto.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKNeto.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKNeto.RowStyles.Add(new RowStyle());
            this.label1NETOELEMENTIDELEMENT = new UltraLabel();
            this.comboNETOELEMENTIDELEMENT = new PROVIDER_NETOComboBox();
            this.label1NETOSATNICA = new UltraLabel();
            this.textNETOSATNICA = new UltraNumericEditor();
            this.label1NETOSATI = new UltraLabel();
            this.textNETOSATI = new UltraNumericEditor();
            this.label1NETOPOSTOTAK = new UltraLabel();
            this.textNETOPOSTOTAK = new UltraNumericEditor();
            this.label1NETOIZNOS = new UltraLabel();
            this.textNETOIZNOS = new UltraNumericEditor();
            ((ISupportInitialize) this.textNETOSATNICA).BeginInit();
            ((ISupportInitialize) this.textNETOSATI).BeginInit();
            ((ISupportInitialize) this.textNETOPOSTOTAK).BeginInit();
            ((ISupportInitialize) this.textNETOIZNOS).BeginInit();
            this.dsRADNIKDataSet1 = new RADNIKDataSet();
            this.dsRADNIKDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRADNIKDataSet1.DataSetName = "dsRADNIK";
            this.dsRADNIKDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRADNIKNeto.DataSource = this.dsRADNIKDataSet1;
            this.bindingSourceRADNIKNeto.DataMember = "RADNIKNeto";
            ((ISupportInitialize) this.bindingSourceRADNIKNeto).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1NETOELEMENTIDELEMENT.Location = point;
            this.label1NETOELEMENTIDELEMENT.Name = "label1NETOELEMENTIDELEMENT";
            this.label1NETOELEMENTIDELEMENT.TabIndex = 1;
            this.label1NETOELEMENTIDELEMENT.Tag = "labelNETOELEMENTIDELEMENT";
            this.label1NETOELEMENTIDELEMENT.Text = "Šifra:";
            this.label1NETOELEMENTIDELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1NETOELEMENTIDELEMENT.AutoSize = true;
            this.label1NETOELEMENTIDELEMENT.Anchor = AnchorStyles.Left;
            this.label1NETOELEMENTIDELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1NETOELEMENTIDELEMENT.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1NETOELEMENTIDELEMENT.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1NETOELEMENTIDELEMENT.ImageSize = size;
            this.label1NETOELEMENTIDELEMENT.Appearance.ForeColor = Color.Black;
            this.label1NETOELEMENTIDELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKNeto.Controls.Add(this.label1NETOELEMENTIDELEMENT, 0, 0);
            this.layoutManagerformRADNIKNeto.SetColumnSpan(this.label1NETOELEMENTIDELEMENT, 1);
            this.layoutManagerformRADNIKNeto.SetRowSpan(this.label1NETOELEMENTIDELEMENT, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1NETOELEMENTIDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NETOELEMENTIDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1NETOELEMENTIDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboNETOELEMENTIDELEMENT.Location = point;
            this.comboNETOELEMENTIDELEMENT.Name = "comboNETOELEMENTIDELEMENT";
            this.comboNETOELEMENTIDELEMENT.Tag = "NETOELEMENTIDELEMENT";
            this.comboNETOELEMENTIDELEMENT.TabIndex = 0;
            this.comboNETOELEMENTIDELEMENT.Anchor = AnchorStyles.Left;
            this.comboNETOELEMENTIDELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboNETOELEMENTIDELEMENT.DropDownStyle = DropDownStyle.DropDown;
            this.comboNETOELEMENTIDELEMENT.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboNETOELEMENTIDELEMENT.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboNETOELEMENTIDELEMENT.Enabled = true;
            this.comboNETOELEMENTIDELEMENT.FillAtStartup = false;
            this.comboNETOELEMENTIDELEMENT.ShowPictureBox = true;
            this.comboNETOELEMENTIDELEMENT.PictureBoxClicked += new EventHandler(this.PictureBoxClickedNETOELEMENTIDELEMENT);
            this.comboNETOELEMENTIDELEMENT.ValueMember = "IDELEMENT";
            this.comboNETOELEMENTIDELEMENT.SelectionChanged += new EventHandler(this.SelectedIndexChangedNETOELEMENTIDELEMENT);
            this.layoutManagerformRADNIKNeto.Controls.Add(this.comboNETOELEMENTIDELEMENT, 1, 0);
            this.layoutManagerformRADNIKNeto.SetColumnSpan(this.comboNETOELEMENTIDELEMENT, 1);
            this.layoutManagerformRADNIKNeto.SetRowSpan(this.comboNETOELEMENTIDELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboNETOELEMENTIDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboNETOELEMENTIDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboNETOELEMENTIDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NETOSATNICA.Location = point;
            this.label1NETOSATNICA.Name = "label1NETOSATNICA";
            this.label1NETOSATNICA.TabIndex = 1;
            this.label1NETOSATNICA.Tag = "labelNETOSATNICA";
            this.label1NETOSATNICA.Text = "Satnica:";
            this.label1NETOSATNICA.StyleSetName = "FieldUltraLabel";
            this.label1NETOSATNICA.AutoSize = true;
            this.label1NETOSATNICA.Anchor = AnchorStyles.Left;
            this.label1NETOSATNICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NETOSATNICA.Appearance.ForeColor = Color.Black;
            this.label1NETOSATNICA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKNeto.Controls.Add(this.label1NETOSATNICA, 0, 1);
            this.layoutManagerformRADNIKNeto.SetColumnSpan(this.label1NETOSATNICA, 1);
            this.layoutManagerformRADNIKNeto.SetRowSpan(this.label1NETOSATNICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NETOSATNICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NETOSATNICA.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x17);
            this.label1NETOSATNICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNETOSATNICA.Location = point;
            this.textNETOSATNICA.Name = "textNETOSATNICA";
            this.textNETOSATNICA.Tag = "NETOSATNICA";
            this.textNETOSATNICA.TabIndex = 0;
            this.textNETOSATNICA.Anchor = AnchorStyles.Left;
            this.textNETOSATNICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNETOSATNICA.ReadOnly = false;
            this.textNETOSATNICA.PromptChar = ' ';
            this.textNETOSATNICA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textNETOSATNICA.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKNeto, "NETOSATNICA"));
            this.textNETOSATNICA.NumericType = NumericType.Double;
            this.textNETOSATNICA.MaxValue = 79228162514264337593543950335M;
            this.textNETOSATNICA.MinValue = -79228162514264337593543950335M;
            this.textNETOSATNICA.MaskInput = "{LOC}-nnnn.nnnnnnnn";
            this.layoutManagerformRADNIKNeto.Controls.Add(this.textNETOSATNICA, 1, 1);
            this.layoutManagerformRADNIKNeto.SetColumnSpan(this.textNETOSATNICA, 1);
            this.layoutManagerformRADNIKNeto.SetRowSpan(this.textNETOSATNICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNETOSATNICA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textNETOSATNICA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textNETOSATNICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NETOSATI.Location = point;
            this.label1NETOSATI.Name = "label1NETOSATI";
            this.label1NETOSATI.TabIndex = 1;
            this.label1NETOSATI.Tag = "labelNETOSATI";
            this.label1NETOSATI.Text = "Sati:";
            this.label1NETOSATI.StyleSetName = "FieldUltraLabel";
            this.label1NETOSATI.AutoSize = true;
            this.label1NETOSATI.Anchor = AnchorStyles.Left;
            this.label1NETOSATI.Appearance.TextVAlign = VAlign.Middle;
            this.label1NETOSATI.Appearance.ForeColor = Color.Black;
            this.label1NETOSATI.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKNeto.Controls.Add(this.label1NETOSATI, 0, 2);
            this.layoutManagerformRADNIKNeto.SetColumnSpan(this.label1NETOSATI, 1);
            this.layoutManagerformRADNIKNeto.SetRowSpan(this.label1NETOSATI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NETOSATI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NETOSATI.MinimumSize = size;
            size = new System.Drawing.Size(0x2b, 0x17);
            this.label1NETOSATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNETOSATI.Location = point;
            this.textNETOSATI.Name = "textNETOSATI";
            this.textNETOSATI.Tag = "NETOSATI";
            this.textNETOSATI.TabIndex = 0;
            this.textNETOSATI.Anchor = AnchorStyles.Left;
            this.textNETOSATI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNETOSATI.ReadOnly = false;
            this.textNETOSATI.PromptChar = ' ';
            this.textNETOSATI.Enter += new EventHandler(this.numericEditor_Enter);
            this.textNETOSATI.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKNeto, "NETOSATI"));
            this.textNETOSATI.NumericType = NumericType.Double;
            this.textNETOSATI.MaxValue = 79228162514264337593543950335M;
            this.textNETOSATI.MinValue = -79228162514264337593543950335M;
            this.textNETOSATI.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformRADNIKNeto.Controls.Add(this.textNETOSATI, 1, 2);
            this.layoutManagerformRADNIKNeto.SetColumnSpan(this.textNETOSATI, 1);
            this.layoutManagerformRADNIKNeto.SetRowSpan(this.textNETOSATI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNETOSATI.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textNETOSATI.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textNETOSATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NETOPOSTOTAK.Location = point;
            this.label1NETOPOSTOTAK.Name = "label1NETOPOSTOTAK";
            this.label1NETOPOSTOTAK.TabIndex = 1;
            this.label1NETOPOSTOTAK.Tag = "labelNETOPOSTOTAK";
            this.label1NETOPOSTOTAK.Text = "Postotak:";
            this.label1NETOPOSTOTAK.StyleSetName = "FieldUltraLabel";
            this.label1NETOPOSTOTAK.AutoSize = true;
            this.label1NETOPOSTOTAK.Anchor = AnchorStyles.Left;
            this.label1NETOPOSTOTAK.Appearance.TextVAlign = VAlign.Middle;
            this.label1NETOPOSTOTAK.Appearance.ForeColor = Color.Black;
            this.label1NETOPOSTOTAK.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKNeto.Controls.Add(this.label1NETOPOSTOTAK, 0, 3);
            this.layoutManagerformRADNIKNeto.SetColumnSpan(this.label1NETOPOSTOTAK, 1);
            this.layoutManagerformRADNIKNeto.SetRowSpan(this.label1NETOPOSTOTAK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NETOPOSTOTAK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NETOPOSTOTAK.MinimumSize = size;
            size = new System.Drawing.Size(0x4a, 0x17);
            this.label1NETOPOSTOTAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNETOPOSTOTAK.Location = point;
            this.textNETOPOSTOTAK.Name = "textNETOPOSTOTAK";
            this.textNETOPOSTOTAK.Tag = "NETOPOSTOTAK";
            this.textNETOPOSTOTAK.TabIndex = 0;
            this.textNETOPOSTOTAK.Anchor = AnchorStyles.Left;
            this.textNETOPOSTOTAK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNETOPOSTOTAK.ReadOnly = false;
            this.textNETOPOSTOTAK.PromptChar = ' ';
            this.textNETOPOSTOTAK.Enter += new EventHandler(this.numericEditor_Enter);
            this.textNETOPOSTOTAK.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKNeto, "NETOPOSTOTAK"));
            this.textNETOPOSTOTAK.NumericType = NumericType.Double;
            this.textNETOPOSTOTAK.MaxValue = 79228162514264337593543950335M;
            this.textNETOPOSTOTAK.MinValue = -79228162514264337593543950335M;
            this.textNETOPOSTOTAK.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformRADNIKNeto.Controls.Add(this.textNETOPOSTOTAK, 1, 3);
            this.layoutManagerformRADNIKNeto.SetColumnSpan(this.textNETOPOSTOTAK, 1);
            this.layoutManagerformRADNIKNeto.SetRowSpan(this.textNETOPOSTOTAK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNETOPOSTOTAK.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textNETOPOSTOTAK.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textNETOPOSTOTAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NETOIZNOS.Location = point;
            this.label1NETOIZNOS.Name = "label1NETOIZNOS";
            this.label1NETOIZNOS.TabIndex = 1;
            this.label1NETOIZNOS.Tag = "labelNETOIZNOS";
            this.label1NETOIZNOS.Text = "Iznos:";
            this.label1NETOIZNOS.StyleSetName = "FieldUltraLabel";
            this.label1NETOIZNOS.AutoSize = true;
            this.label1NETOIZNOS.Anchor = AnchorStyles.Left;
            this.label1NETOIZNOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1NETOIZNOS.Appearance.ForeColor = Color.Black;
            this.label1NETOIZNOS.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKNeto.Controls.Add(this.label1NETOIZNOS, 0, 4);
            this.layoutManagerformRADNIKNeto.SetColumnSpan(this.label1NETOIZNOS, 1);
            this.layoutManagerformRADNIKNeto.SetRowSpan(this.label1NETOIZNOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NETOIZNOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NETOIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1NETOIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNETOIZNOS.Location = point;
            this.textNETOIZNOS.Name = "textNETOIZNOS";
            this.textNETOIZNOS.Tag = "NETOIZNOS";
            this.textNETOIZNOS.TabIndex = 0;
            this.textNETOIZNOS.Anchor = AnchorStyles.Left;
            this.textNETOIZNOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNETOIZNOS.ReadOnly = false;
            this.textNETOIZNOS.PromptChar = ' ';
            this.textNETOIZNOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textNETOIZNOS.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKNeto, "NETOIZNOS"));
            this.textNETOIZNOS.NumericType = NumericType.Double;
            this.textNETOIZNOS.MaxValue = 79228162514264337593543950335M;
            this.textNETOIZNOS.MinValue = -79228162514264337593543950335M;
            this.textNETOIZNOS.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformRADNIKNeto.Controls.Add(this.textNETOIZNOS, 1, 4);
            this.layoutManagerformRADNIKNeto.SetColumnSpan(this.textNETOIZNOS, 1);
            this.layoutManagerformRADNIKNeto.SetRowSpan(this.textNETOIZNOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNETOIZNOS.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textNETOIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textNETOIZNOS.Size = size;
            this.Controls.Add(this.layoutManagerformRADNIKNeto);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRADNIKNeto;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RADNIKFormRADNIKNetoUserControl";
            this.Text = " Neto elementi";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RADNIKFormUserControl_Load);
            this.layoutManagerformRADNIKNeto.ResumeLayout(false);
            this.layoutManagerformRADNIKNeto.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRADNIKNeto).EndInit();
            ((ISupportInitialize) this.textNETOSATNICA).EndInit();
            ((ISupportInitialize) this.textNETOSATI).EndInit();
            ((ISupportInitialize) this.textNETOPOSTOTAK).EndInit();
            ((ISupportInitialize) this.textNETOIZNOS).EndInit();
            this.dsRADNIKDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RADNIKController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIKNeto, this.RADNIKController.WorkItem, this))
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
            this.label1NETOELEMENTIDELEMENT.Text = StringResources.RADNIKNETOELEMENTIDELEMENTDescription;
            this.label1NETOSATNICA.Text = StringResources.RADNIKNETOSATNICADescription;
            this.label1NETOSATI.Text = StringResources.RADNIKNETOSATIDescription;
            this.label1NETOPOSTOTAK.Text = StringResources.RADNIKNETOPOSTOTAKDescription;
            this.label1NETOIZNOS.Text = StringResources.RADNIKNETOIZNOSDescription;
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

        private void PictureBoxClickedNETOELEMENTIDELEMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ELEMENT", null, DeklaritMode.Insert));
            }
        }

        private void RADNIKFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RADNIKRADNIKNetoLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIKNeto|RADNIKNeto"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIKNeto, "RADNIKNeto|RADNIKNeto");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("RADNIKNetoSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedNETOELEMENTIDELEMENT(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboNETOELEMENTIDELEMENT.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboNETOELEMENTIDELEMENT.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRADNIKNeto.Current).Row["NETOELEMENTIDELEMENT"] = RuntimeHelpers.GetObjectValue(row["IDELEMENT"]);
                    ((DataRowView) this.bindingSourceRADNIKNeto.Current).Row["NETOELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(row["NAZIVELEMENT"]);
                    this.bindingSourceRADNIKNeto.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboNETOELEMENTIDELEMENT.Focus();
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

        protected virtual PROVIDER_NETOComboBox comboNETOELEMENTIDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboNETOELEMENTIDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboNETOELEMENTIDELEMENT = value;
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

        protected virtual UltraLabel label1NETOELEMENTIDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NETOELEMENTIDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NETOELEMENTIDELEMENT = value;
            }
        }

        protected virtual UltraLabel label1NETOIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NETOIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NETOIZNOS = value;
            }
        }

        protected virtual UltraLabel label1NETOPOSTOTAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NETOPOSTOTAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NETOPOSTOTAK = value;
            }
        }

        protected virtual UltraLabel label1NETOSATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NETOSATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NETOSATI = value;
            }
        }

        protected virtual UltraLabel label1NETOSATNICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NETOSATNICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NETOSATNICA = value;
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

        protected virtual UltraNumericEditor textNETOIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNETOIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNETOIZNOS = value;
            }
        }

        protected virtual UltraNumericEditor textNETOPOSTOTAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNETOPOSTOTAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNETOPOSTOTAK = value;
            }
        }

        protected virtual UltraNumericEditor textNETOSATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNETOSATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNETOSATI = value;
            }
        }

        protected virtual UltraNumericEditor textNETOSATNICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNETOSATNICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNETOSATNICA = value;
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

