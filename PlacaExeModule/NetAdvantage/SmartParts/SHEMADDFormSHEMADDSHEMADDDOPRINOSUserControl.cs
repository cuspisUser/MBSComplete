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
    public class SHEMADDFormSHEMADDSHEMADDDOPRINOSUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboKONTODOPIDKONTO")]
        private KONTOComboBox _comboKONTODOPIDKONTO;
        [AccessedThroughProperty("comboMTDOPIDMJESTOTROSKA")]
        private MJESTOTROSKAComboBox _comboMTDOPIDMJESTOTROSKA;
        [AccessedThroughProperty("comboSTRANEDOPIDSTRANEKNJIZENJA")]
        private STRANEKNJIZENJAComboBox _comboSTRANEDOPIDSTRANEKNJIZENJA;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1KONTODOPIDKONTO")]
        private UltraLabel _label1KONTODOPIDKONTO;
        [AccessedThroughProperty("label1MTDOPIDMJESTOTROSKA")]
        private UltraLabel _label1MTDOPIDMJESTOTROSKA;
        [AccessedThroughProperty("label1SHEMADDDOPRINOSIDDOPRINOS")]
        private UltraLabel _label1SHEMADDDOPRINOSIDDOPRINOS;
        [AccessedThroughProperty("label1SHEMADDDOPRINOSNAZIVDOPRINOS")]
        private UltraLabel _label1SHEMADDDOPRINOSNAZIVDOPRINOS;
        [AccessedThroughProperty("label1STRANEDOPIDSTRANEKNJIZENJA")]
        private UltraLabel _label1STRANEDOPIDSTRANEKNJIZENJA;
        [AccessedThroughProperty("labelSHEMADDDOPRINOSNAZIVDOPRINOS")]
        private UltraLabel _labelSHEMADDDOPRINOSNAZIVDOPRINOS;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textSHEMADDDOPRINOSIDDOPRINOS")]
        private UltraNumericEditor _textSHEMADDDOPRINOSIDDOPRINOS;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSHEMADDSHEMADDDOPRINOS;
        private IContainer components = null;
        private SHEMADDDataSet dsSHEMADDDataSet1;
        protected TableLayoutPanel layoutManagerformSHEMADDSHEMADDDOPRINOS;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "SHEMADDSHEMADDDOPRINOS";
        private string m_FrameworkDescription = StringResources.SHEMADDDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public SHEMADDFormSHEMADDSHEMADDDOPRINOSUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("SHEMADDSHEMADDDOPRINOSAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SHEMADDSHEMADDDOPRINOSAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow) ((DataRowView) this.bindingSourceSHEMADDSHEMADDDOPRINOS.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CallPromptDOPRINOSSHEMADDDOPRINOSIDDOPRINOS(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.Controller.SelectDOPRINOSSHEMADDDOPRINOSIDDOPRINOS(fillMethod, fillByRow);
            this.UpdateValuesDOPRINOSSHEMADDDOPRINOSIDDOPRINOS(result);
        }

        private void CallViewDOPRINOSSHEMADDDOPRINOSIDDOPRINOS(object sender, EventArgs e)
        {
            DataRow result = this.Controller.ShowDOPRINOSSHEMADDDOPRINOSIDDOPRINOS(this.m_CurrentRow);
            this.UpdateValuesDOPRINOSSHEMADDDOPRINOSIDDOPRINOS(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsSHEMADDDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceSHEMADDSHEMADDDOPRINOS.DataSource = this.Controller.DataSet;
            this.dsSHEMADDDataSet1 = this.Controller.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void comboKONTODOPIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            this.comboKONTODOPIDKONTO.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/MJESTOTROSKA", Thread=ThreadOption.UserInterface)]
        public void comboMTDOPIDMJESTOTROSKA_Add(object sender, ComponentEventArgs e)
        {
            this.comboMTDOPIDMJESTOTROSKA.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRANEKNJIZENJA", Thread=ThreadOption.UserInterface)]
        public void comboSTRANEDOPIDSTRANEKNJIZENJA_Add(object sender, ComponentEventArgs e)
        {
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.Fill();
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
            this.dsSHEMADDDataSet1 = (SHEMADDDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceSHEMADDSHEMADDDOPRINOS.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsSHEMADDDataSet1.Tables["SHEMADDSHEMADDDOPRINOS"]);
            this.bindingSourceSHEMADDSHEMADDDOPRINOS.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "SHEMADD", this.m_Mode, this.dsSHEMADDDataSet1, this.dsSHEMADDDataSet1.SHEMADDSHEMADDDOPRINOS.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow) ((DataRowView) this.bindingSourceSHEMADDSHEMADDDOPRINOS.Current).Row;
                this.textSHEMADDDOPRINOSIDDOPRINOS.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textSHEMADDDOPRINOSIDDOPRINOS.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (SHEMADDDataSet.SHEMADDSHEMADDDOPRINOSRow) ((DataRowView) this.bindingSourceSHEMADDSHEMADDDOPRINOS.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(SHEMADDFormSHEMADDSHEMADDDOPRINOSUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSHEMADDSHEMADDDOPRINOS = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMADDSHEMADDDOPRINOS).BeginInit();
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS = new TableLayoutPanel();
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SuspendLayout();
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.AutoSize = true;
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.Dock = DockStyle.Fill;
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.Size = size;
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.ColumnCount = 2;
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.RowCount = 6;
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.RowStyles.Add(new RowStyle());
            this.label1SHEMADDDOPRINOSIDDOPRINOS = new UltraLabel();
            this.textSHEMADDDOPRINOSIDDOPRINOS = new UltraNumericEditor();
            this.label1KONTODOPIDKONTO = new UltraLabel();
            this.comboKONTODOPIDKONTO = new KONTOComboBox();
            this.label1MTDOPIDMJESTOTROSKA = new UltraLabel();
            this.comboMTDOPIDMJESTOTROSKA = new MJESTOTROSKAComboBox();
            this.label1STRANEDOPIDSTRANEKNJIZENJA = new UltraLabel();
            this.comboSTRANEDOPIDSTRANEKNJIZENJA = new STRANEKNJIZENJAComboBox();
            this.label1SHEMADDDOPRINOSNAZIVDOPRINOS = new UltraLabel();
            this.labelSHEMADDDOPRINOSNAZIVDOPRINOS = new UltraLabel();
            ((ISupportInitialize) this.textSHEMADDDOPRINOSIDDOPRINOS).BeginInit();
            this.dsSHEMADDDataSet1 = new SHEMADDDataSet();
            this.dsSHEMADDDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSHEMADDDataSet1.DataSetName = "dsSHEMADD";
            this.dsSHEMADDDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSHEMADDSHEMADDDOPRINOS.DataSource = this.dsSHEMADDDataSet1;
            this.bindingSourceSHEMADDSHEMADDDOPRINOS.DataMember = "SHEMADDSHEMADDDOPRINOS";
            ((ISupportInitialize) this.bindingSourceSHEMADDSHEMADDDOPRINOS).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMADDDOPRINOSIDDOPRINOS.Location = point;
            this.label1SHEMADDDOPRINOSIDDOPRINOS.Name = "label1SHEMADDDOPRINOSIDDOPRINOS";
            this.label1SHEMADDDOPRINOSIDDOPRINOS.TabIndex = 1;
            this.label1SHEMADDDOPRINOSIDDOPRINOS.Tag = "labelSHEMADDDOPRINOSIDDOPRINOS";
            this.label1SHEMADDDOPRINOSIDDOPRINOS.Text = "Šifra doprinosa:";
            this.label1SHEMADDDOPRINOSIDDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1SHEMADDDOPRINOSIDDOPRINOS.AutoSize = true;
            this.label1SHEMADDDOPRINOSIDDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1SHEMADDDOPRINOSIDDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMADDDOPRINOSIDDOPRINOS.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1SHEMADDDOPRINOSIDDOPRINOS.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1SHEMADDDOPRINOSIDDOPRINOS.ImageSize = size;
            this.label1SHEMADDDOPRINOSIDDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1SHEMADDDOPRINOSIDDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.Controls.Add(this.label1SHEMADDDOPRINOSIDDOPRINOS, 0, 0);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetColumnSpan(this.label1SHEMADDDOPRINOSIDDOPRINOS, 1);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetRowSpan(this.label1SHEMADDDOPRINOSIDDOPRINOS, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1SHEMADDDOPRINOSIDDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMADDDOPRINOSIDDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(110, 0x17);
            this.label1SHEMADDDOPRINOSIDDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSHEMADDDOPRINOSIDDOPRINOS.Location = point;
            this.textSHEMADDDOPRINOSIDDOPRINOS.Name = "textSHEMADDDOPRINOSIDDOPRINOS";
            this.textSHEMADDDOPRINOSIDDOPRINOS.Tag = "SHEMADDDOPRINOSIDDOPRINOS";
            this.textSHEMADDDOPRINOSIDDOPRINOS.TabIndex = 0;
            this.textSHEMADDDOPRINOSIDDOPRINOS.Anchor = AnchorStyles.Left;
            this.textSHEMADDDOPRINOSIDDOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSHEMADDDOPRINOSIDDOPRINOS.ReadOnly = false;
            this.textSHEMADDDOPRINOSIDDOPRINOS.PromptChar = ' ';
            this.textSHEMADDDOPRINOSIDDOPRINOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textSHEMADDDOPRINOSIDDOPRINOS.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMADDSHEMADDDOPRINOS, "SHEMADDDOPRINOSIDDOPRINOS"));
            this.textSHEMADDDOPRINOSIDDOPRINOS.NumericType = NumericType.Integer;
            this.textSHEMADDDOPRINOSIDDOPRINOS.MaskInput = "{LOC}-nnnnnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonDOPRINOSSHEMADDDOPRINOSIDDOPRINOS",
                Tag = "editorButtonDOPRINOSSHEMADDDOPRINOSIDDOPRINOS",
                Text = "..."
            };
            this.textSHEMADDDOPRINOSIDDOPRINOS.ButtonsRight.Add(button);
            this.textSHEMADDDOPRINOSIDDOPRINOS.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptDOPRINOSSHEMADDDOPRINOSIDDOPRINOS);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.Controls.Add(this.textSHEMADDDOPRINOSIDDOPRINOS, 1, 0);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetColumnSpan(this.textSHEMADDDOPRINOSIDDOPRINOS, 1);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetRowSpan(this.textSHEMADDDOPRINOSIDDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSHEMADDDOPRINOSIDDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textSHEMADDDOPRINOSIDDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textSHEMADDDOPRINOSIDDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KONTODOPIDKONTO.Location = point;
            this.label1KONTODOPIDKONTO.Name = "label1KONTODOPIDKONTO";
            this.label1KONTODOPIDKONTO.TabIndex = 1;
            this.label1KONTODOPIDKONTO.Tag = "labelKONTODOPIDKONTO";
            this.label1KONTODOPIDKONTO.Text = "Konto:";
            this.label1KONTODOPIDKONTO.StyleSetName = "FieldUltraLabel";
            this.label1KONTODOPIDKONTO.AutoSize = true;
            this.label1KONTODOPIDKONTO.Anchor = AnchorStyles.Left;
            this.label1KONTODOPIDKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1KONTODOPIDKONTO.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1KONTODOPIDKONTO.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1KONTODOPIDKONTO.ImageSize = size;
            this.label1KONTODOPIDKONTO.Appearance.ForeColor = Color.Black;
            this.label1KONTODOPIDKONTO.BackColor = Color.Transparent;
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.Controls.Add(this.label1KONTODOPIDKONTO, 0, 1);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetColumnSpan(this.label1KONTODOPIDKONTO, 1);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetRowSpan(this.label1KONTODOPIDKONTO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KONTODOPIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KONTODOPIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1KONTODOPIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboKONTODOPIDKONTO.Location = point;
            this.comboKONTODOPIDKONTO.Name = "comboKONTODOPIDKONTO";
            this.comboKONTODOPIDKONTO.Tag = "KONTODOPIDKONTO";
            this.comboKONTODOPIDKONTO.TabIndex = 0;
            this.comboKONTODOPIDKONTO.Anchor = AnchorStyles.Left;
            this.comboKONTODOPIDKONTO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboKONTODOPIDKONTO.DropDownStyle = DropDownStyle.DropDown;
            this.comboKONTODOPIDKONTO.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboKONTODOPIDKONTO.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboKONTODOPIDKONTO.Enabled = true;
            this.comboKONTODOPIDKONTO.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMADDSHEMADDDOPRINOS, "KONTODOPIDKONTO"));
            this.comboKONTODOPIDKONTO.ShowPictureBox = true;
            this.comboKONTODOPIDKONTO.PictureBoxClicked += new EventHandler(this.PictureBoxClickedKONTODOPIDKONTO);
            this.comboKONTODOPIDKONTO.ValueMember = "IDKONTO";
            this.comboKONTODOPIDKONTO.SelectionChanged += new EventHandler(this.SelectedIndexChangedKONTODOPIDKONTO);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.Controls.Add(this.comboKONTODOPIDKONTO, 1, 1);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetColumnSpan(this.comboKONTODOPIDKONTO, 1);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetRowSpan(this.comboKONTODOPIDKONTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboKONTODOPIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboKONTODOPIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboKONTODOPIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MTDOPIDMJESTOTROSKA.Location = point;
            this.label1MTDOPIDMJESTOTROSKA.Name = "label1MTDOPIDMJESTOTROSKA";
            this.label1MTDOPIDMJESTOTROSKA.TabIndex = 1;
            this.label1MTDOPIDMJESTOTROSKA.Tag = "labelMTDOPIDMJESTOTROSKA";
            this.label1MTDOPIDMJESTOTROSKA.Text = "Šifra MT:";
            this.label1MTDOPIDMJESTOTROSKA.StyleSetName = "FieldUltraLabel";
            this.label1MTDOPIDMJESTOTROSKA.AutoSize = true;
            this.label1MTDOPIDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.label1MTDOPIDMJESTOTROSKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MTDOPIDMJESTOTROSKA.Appearance.ForeColor = Color.Black;
            this.label1MTDOPIDMJESTOTROSKA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.Controls.Add(this.label1MTDOPIDMJESTOTROSKA, 0, 2);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetColumnSpan(this.label1MTDOPIDMJESTOTROSKA, 1);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetRowSpan(this.label1MTDOPIDMJESTOTROSKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MTDOPIDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MTDOPIDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(70, 0x17);
            this.label1MTDOPIDMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboMTDOPIDMJESTOTROSKA.Location = point;
            this.comboMTDOPIDMJESTOTROSKA.Name = "comboMTDOPIDMJESTOTROSKA";
            this.comboMTDOPIDMJESTOTROSKA.Tag = "MTDOPIDMJESTOTROSKA";
            this.comboMTDOPIDMJESTOTROSKA.TabIndex = 0;
            this.comboMTDOPIDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.comboMTDOPIDMJESTOTROSKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboMTDOPIDMJESTOTROSKA.DropDownStyle = DropDownStyle.DropDown;
            this.comboMTDOPIDMJESTOTROSKA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboMTDOPIDMJESTOTROSKA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboMTDOPIDMJESTOTROSKA.Enabled = true;
            this.comboMTDOPIDMJESTOTROSKA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMADDSHEMADDDOPRINOS, "MTDOPIDMJESTOTROSKA"));
            this.comboMTDOPIDMJESTOTROSKA.ShowPictureBox = true;
            this.comboMTDOPIDMJESTOTROSKA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedMTDOPIDMJESTOTROSKA);
            this.comboMTDOPIDMJESTOTROSKA.ValueMember = "IDMJESTOTROSKA";
            this.comboMTDOPIDMJESTOTROSKA.SelectionChanged += new EventHandler(this.SelectedIndexChangedMTDOPIDMJESTOTROSKA);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.Controls.Add(this.comboMTDOPIDMJESTOTROSKA, 1, 2);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetColumnSpan(this.comboMTDOPIDMJESTOTROSKA, 1);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetRowSpan(this.comboMTDOPIDMJESTOTROSKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboMTDOPIDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboMTDOPIDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboMTDOPIDMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1STRANEDOPIDSTRANEKNJIZENJA.Location = point;
            this.label1STRANEDOPIDSTRANEKNJIZENJA.Name = "label1STRANEDOPIDSTRANEKNJIZENJA";
            this.label1STRANEDOPIDSTRANEKNJIZENJA.TabIndex = 1;
            this.label1STRANEDOPIDSTRANEKNJIZENJA.Tag = "labelSTRANEDOPIDSTRANEKNJIZENJA";
            this.label1STRANEDOPIDSTRANEKNJIZENJA.Text = "Šifra strane:";
            this.label1STRANEDOPIDSTRANEKNJIZENJA.StyleSetName = "FieldUltraLabel";
            this.label1STRANEDOPIDSTRANEKNJIZENJA.AutoSize = true;
            this.label1STRANEDOPIDSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.label1STRANEDOPIDSTRANEKNJIZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1STRANEDOPIDSTRANEKNJIZENJA.Appearance.ForeColor = Color.Black;
            this.label1STRANEDOPIDSTRANEKNJIZENJA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.Controls.Add(this.label1STRANEDOPIDSTRANEKNJIZENJA, 0, 3);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetColumnSpan(this.label1STRANEDOPIDSTRANEKNJIZENJA, 1);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetRowSpan(this.label1STRANEDOPIDSTRANEKNJIZENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1STRANEDOPIDSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1STRANEDOPIDSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x5b, 0x17);
            this.label1STRANEDOPIDSTRANEKNJIZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.Location = point;
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.Name = "comboSTRANEDOPIDSTRANEKNJIZENJA";
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.Tag = "STRANEDOPIDSTRANEKNJIZENJA";
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.TabIndex = 0;
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.DropDownStyle = DropDownStyle.DropDown;
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.Enabled = true;
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMADDSHEMADDDOPRINOS, "STRANEDOPIDSTRANEKNJIZENJA"));
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.ShowPictureBox = true;
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSTRANEDOPIDSTRANEKNJIZENJA);
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.ValueMember = "IDSTRANEKNJIZENJA";
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.SelectionChanged += new EventHandler(this.SelectedIndexChangedSTRANEDOPIDSTRANEKNJIZENJA);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.Controls.Add(this.comboSTRANEDOPIDSTRANEKNJIZENJA, 1, 3);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetColumnSpan(this.comboSTRANEDOPIDSTRANEKNJIZENJA, 1);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetRowSpan(this.comboSTRANEDOPIDSTRANEKNJIZENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMADDDOPRINOSNAZIVDOPRINOS.Location = point;
            this.label1SHEMADDDOPRINOSNAZIVDOPRINOS.Name = "label1SHEMADDDOPRINOSNAZIVDOPRINOS";
            this.label1SHEMADDDOPRINOSNAZIVDOPRINOS.TabIndex = 1;
            this.label1SHEMADDDOPRINOSNAZIVDOPRINOS.Tag = "labelSHEMADDDOPRINOSNAZIVDOPRINOS";
            this.label1SHEMADDDOPRINOSNAZIVDOPRINOS.Text = "Naziv doprinosa:";
            this.label1SHEMADDDOPRINOSNAZIVDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1SHEMADDDOPRINOSNAZIVDOPRINOS.AutoSize = true;
            this.label1SHEMADDDOPRINOSNAZIVDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1SHEMADDDOPRINOSNAZIVDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMADDDOPRINOSNAZIVDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1SHEMADDDOPRINOSNAZIVDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.Controls.Add(this.label1SHEMADDDOPRINOSNAZIVDOPRINOS, 0, 4);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetColumnSpan(this.label1SHEMADDDOPRINOSNAZIVDOPRINOS, 1);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetRowSpan(this.label1SHEMADDDOPRINOSNAZIVDOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SHEMADDDOPRINOSNAZIVDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMADDDOPRINOSNAZIVDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x77, 0x17);
            this.label1SHEMADDDOPRINOSNAZIVDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelSHEMADDDOPRINOSNAZIVDOPRINOS.Location = point;
            this.labelSHEMADDDOPRINOSNAZIVDOPRINOS.Name = "labelSHEMADDDOPRINOSNAZIVDOPRINOS";
            this.labelSHEMADDDOPRINOSNAZIVDOPRINOS.Tag = "SHEMADDDOPRINOSNAZIVDOPRINOS";
            this.labelSHEMADDDOPRINOSNAZIVDOPRINOS.TabIndex = 0;
            this.labelSHEMADDDOPRINOSNAZIVDOPRINOS.Anchor = AnchorStyles.Left;
            this.labelSHEMADDDOPRINOSNAZIVDOPRINOS.BackColor = Color.Transparent;
            this.labelSHEMADDDOPRINOSNAZIVDOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceSHEMADDSHEMADDDOPRINOS, "SHEMADDDOPRINOSNAZIVDOPRINOS"));
            this.labelSHEMADDDOPRINOSNAZIVDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.Controls.Add(this.labelSHEMADDDOPRINOSNAZIVDOPRINOS, 1, 4);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetColumnSpan(this.labelSHEMADDDOPRINOSNAZIVDOPRINOS, 1);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.SetRowSpan(this.labelSHEMADDDOPRINOSNAZIVDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelSHEMADDDOPRINOSNAZIVDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelSHEMADDDOPRINOSNAZIVDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelSHEMADDDOPRINOSNAZIVDOPRINOS.Size = size;
            this.Controls.Add(this.layoutManagerformSHEMADDSHEMADDDOPRINOS);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSHEMADDSHEMADDDOPRINOS;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "SHEMADDFormSHEMADDSHEMADDDOPRINOSUserControl";
            this.Text = " Doprinosi";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.SHEMADDFormUserControl_Load);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.ResumeLayout(false);
            this.layoutManagerformSHEMADDSHEMADDDOPRINOS.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSHEMADDSHEMADDDOPRINOS).EndInit();
            ((ISupportInitialize) this.textSHEMADDDOPRINOSIDDOPRINOS).EndInit();
            this.dsSHEMADDDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.Controller.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMADDSHEMADDDOPRINOS, this.Controller.WorkItem, this))
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
            this.label1SHEMADDDOPRINOSIDDOPRINOS.Text = StringResources.SHEMADDSHEMADDDOPRINOSIDDOPRINOSDescription;
            this.label1KONTODOPIDKONTO.Text = StringResources.SHEMADDKONTODOPIDKONTODescription;
            this.label1MTDOPIDMJESTOTROSKA.Text = StringResources.SHEMADDMTDOPIDMJESTOTROSKADescription;
            this.label1STRANEDOPIDSTRANEKNJIZENJA.Text = StringResources.SHEMADDSTRANEDOPIDSTRANEKNJIZENJADescription;
            this.label1SHEMADDDOPRINOSNAZIVDOPRINOS.Text = StringResources.SHEMADDSHEMADDDOPRINOSNAZIVDOPRINOSDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedKONTODOPIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedMTDOPIDMJESTOTROSKA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("MJESTOTROSKA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedSTRANEDOPIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("STRANEKNJIZENJA", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.Controller.WorkItem.Items.Contains("SHEMADDSHEMADDDOPRINOS|SHEMADDSHEMADDDOPRINOS"))
            {
                this.Controller.WorkItem.Items.Add(this.bindingSourceSHEMADDSHEMADDDOPRINOS, "SHEMADDSHEMADDDOPRINOS|SHEMADDSHEMADDDOPRINOS");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("SHEMADDSHEMADDDOPRINOSSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedKONTODOPIDKONTO(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboKONTODOPIDKONTO.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboKONTODOPIDKONTO.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMADDSHEMADDDOPRINOS.Current).Row["KONTODOPIDKONTO"] = RuntimeHelpers.GetObjectValue(row["IDKONTO"]);
                    this.bindingSourceSHEMADDSHEMADDDOPRINOS.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedMTDOPIDMJESTOTROSKA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboMTDOPIDMJESTOTROSKA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboMTDOPIDMJESTOTROSKA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMADDSHEMADDDOPRINOS.Current).Row["MTDOPIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["IDMJESTOTROSKA"]);
                    this.bindingSourceSHEMADDSHEMADDDOPRINOS.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedSTRANEDOPIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSTRANEDOPIDSTRANEKNJIZENJA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSTRANEDOPIDSTRANEKNJIZENJA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMADDSHEMADDDOPRINOS.Current).Row["STRANEDOPIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(row["IDSTRANEKNJIZENJA"]);
                    this.bindingSourceSHEMADDSHEMADDDOPRINOS.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.textSHEMADDDOPRINOSIDDOPRINOS.Focus();
        }

        private void SetNullItem_Click(object sender, EventArgs e)
        {
            this.m_BaseMethods.SetNullItemClickBase(RuntimeHelpers.GetObjectValue(sender), this.m_CurrentRow);
        }

        private void SetSize()
        {
        }

        private void SHEMADDFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.SHEMADDSHEMADDSHEMADDDOPRINOSLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.m_FrameworkDescription, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void UpdateValuesDOPRINOSSHEMADDDOPRINOSIDDOPRINOS(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceSHEMADDSHEMADDDOPRINOS.Current).Row["SHEMADDDOPRINOSIDDOPRINOS"] = RuntimeHelpers.GetObjectValue(result["IDDOPRINOS"]);
                ((DataRowView) this.bindingSourceSHEMADDSHEMADDDOPRINOS.Current).Row["SHEMADDDOPRINOSNAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(result["NAZIVDOPRINOS"]);
                this.bindingSourceSHEMADDSHEMADDDOPRINOS.ResetCurrentItem();
            }
        }

        protected virtual KONTOComboBox comboKONTODOPIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboKONTODOPIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboKONTODOPIDKONTO = value;
            }
        }

        protected virtual MJESTOTROSKAComboBox comboMTDOPIDMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboMTDOPIDMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboMTDOPIDMJESTOTROSKA = value;
            }
        }

        protected virtual STRANEKNJIZENJAComboBox comboSTRANEDOPIDSTRANEKNJIZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSTRANEDOPIDSTRANEKNJIZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSTRANEDOPIDSTRANEKNJIZENJA = value;
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

        protected virtual UltraLabel label1KONTODOPIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KONTODOPIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KONTODOPIDKONTO = value;
            }
        }

        protected virtual UltraLabel label1MTDOPIDMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MTDOPIDMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MTDOPIDMJESTOTROSKA = value;
            }
        }

        protected virtual UltraLabel label1SHEMADDDOPRINOSIDDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMADDDOPRINOSIDDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMADDDOPRINOSIDDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1SHEMADDDOPRINOSNAZIVDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMADDDOPRINOSNAZIVDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMADDDOPRINOSNAZIVDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1STRANEDOPIDSTRANEKNJIZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1STRANEDOPIDSTRANEKNJIZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1STRANEDOPIDSTRANEKNJIZENJA = value;
            }
        }

        protected virtual UltraLabel labelSHEMADDDOPRINOSNAZIVDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelSHEMADDDOPRINOSNAZIVDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelSHEMADDDOPRINOSNAZIVDOPRINOS = value;
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.SHEMADDController Controller { get; set; }

        protected virtual UltraNumericEditor textSHEMADDDOPRINOSIDDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSHEMADDDOPRINOSIDDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSHEMADDDOPRINOSIDDOPRINOS = value;
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

