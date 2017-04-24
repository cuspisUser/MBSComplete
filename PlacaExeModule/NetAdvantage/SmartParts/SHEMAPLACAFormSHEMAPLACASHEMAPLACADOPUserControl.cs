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
    public class SHEMAPLACAFormSHEMAPLACASHEMAPLACADOPUserControl : UserControl, IBusinessComponentUserControl
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
        [AccessedThroughProperty("label1SHEMAPLDOPIDDOPRINOS")]
        private UltraLabel _label1SHEMAPLDOPIDDOPRINOS;
        [AccessedThroughProperty("label1SHEMAPLDOPNAZIVDOPRINOS")]
        private UltraLabel _label1SHEMAPLDOPNAZIVDOPRINOS;
        [AccessedThroughProperty("label1STRANEDOPIDSTRANEKNJIZENJA")]
        private UltraLabel _label1STRANEDOPIDSTRANEKNJIZENJA;
        [AccessedThroughProperty("labelSHEMAPLDOPNAZIVDOPRINOS")]
        private UltraLabel _labelSHEMAPLDOPNAZIVDOPRINOS;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textSHEMAPLDOPIDDOPRINOS")]
        private UltraNumericEditor _textSHEMAPLDOPIDDOPRINOS;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSHEMAPLACASHEMAPLACADOP;
        private IContainer components = null;
        private SHEMAPLACADataSet dsSHEMAPLACADataSet1;
        protected TableLayoutPanel layoutManagerformSHEMAPLACASHEMAPLACADOP;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "SHEMAPLACASHEMAPLACADOP";
        private string m_FrameworkDescription = StringResources.SHEMAPLACADescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public SHEMAPLACAFormSHEMAPLACASHEMAPLACADOPUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("SHEMAPLACASHEMAPLACADOPAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SHEMAPLACASHEMAPLACADOPAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow) ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACADOP.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CallPromptDOPRINOSSHEMAPLDOPIDDOPRINOS(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.SHEMAPLACAController.SelectDOPRINOSSHEMAPLDOPIDDOPRINOS(fillMethod, fillByRow);
            this.UpdateValuesDOPRINOSSHEMAPLDOPIDDOPRINOS(result);
        }

        private void CallViewDOPRINOSSHEMAPLDOPIDDOPRINOS(object sender, EventArgs e)
        {
            DataRow result = this.SHEMAPLACAController.ShowDOPRINOSSHEMAPLDOPIDDOPRINOS(this.m_CurrentRow);
            this.UpdateValuesDOPRINOSSHEMAPLDOPIDDOPRINOS(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsSHEMAPLACADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceSHEMAPLACASHEMAPLACADOP.DataSource = this.SHEMAPLACAController.DataSet;
            this.dsSHEMAPLACADataSet1 = this.SHEMAPLACAController.DataSet;
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
            this.dsSHEMAPLACADataSet1 = (SHEMAPLACADataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceSHEMAPLACASHEMAPLACADOP.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsSHEMAPLACADataSet1.Tables["SHEMAPLACASHEMAPLACADOP"]);
            this.bindingSourceSHEMAPLACASHEMAPLACADOP.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "SHEMAPLACA", this.m_Mode, this.dsSHEMAPLACADataSet1, this.dsSHEMAPLACADataSet1.SHEMAPLACASHEMAPLACADOP.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow) ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACADOP.Current).Row;
                this.textSHEMAPLDOPIDDOPRINOS.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textSHEMAPLDOPIDDOPRINOS.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACADOPRow) ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACADOP.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(SHEMAPLACAFormSHEMAPLACASHEMAPLACADOPUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSHEMAPLACASHEMAPLACADOP = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMAPLACASHEMAPLACADOP).BeginInit();
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP = new TableLayoutPanel();
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SuspendLayout();
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.AutoSize = true;
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.Dock = DockStyle.Fill;
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.Size = size;
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.ColumnCount = 2;
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.RowCount = 6;
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.RowStyles.Add(new RowStyle());
            this.label1SHEMAPLDOPIDDOPRINOS = new UltraLabel();
            this.textSHEMAPLDOPIDDOPRINOS = new UltraNumericEditor();
            this.label1KONTODOPIDKONTO = new UltraLabel();
            this.comboKONTODOPIDKONTO = new KONTOComboBox();
            this.label1MTDOPIDMJESTOTROSKA = new UltraLabel();
            this.comboMTDOPIDMJESTOTROSKA = new MJESTOTROSKAComboBox();
            this.label1STRANEDOPIDSTRANEKNJIZENJA = new UltraLabel();
            this.comboSTRANEDOPIDSTRANEKNJIZENJA = new STRANEKNJIZENJAComboBox();
            this.label1SHEMAPLDOPNAZIVDOPRINOS = new UltraLabel();
            this.labelSHEMAPLDOPNAZIVDOPRINOS = new UltraLabel();
            ((ISupportInitialize) this.textSHEMAPLDOPIDDOPRINOS).BeginInit();
            this.dsSHEMAPLACADataSet1 = new SHEMAPLACADataSet();
            this.dsSHEMAPLACADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSHEMAPLACADataSet1.DataSetName = "dsSHEMAPLACA";
            this.dsSHEMAPLACADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSHEMAPLACASHEMAPLACADOP.DataSource = this.dsSHEMAPLACADataSet1;
            this.bindingSourceSHEMAPLACASHEMAPLACADOP.DataMember = "SHEMAPLACASHEMAPLACADOP";
            ((ISupportInitialize) this.bindingSourceSHEMAPLACASHEMAPLACADOP).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMAPLDOPIDDOPRINOS.Location = point;
            this.label1SHEMAPLDOPIDDOPRINOS.Name = "label1SHEMAPLDOPIDDOPRINOS";
            this.label1SHEMAPLDOPIDDOPRINOS.TabIndex = 1;
            this.label1SHEMAPLDOPIDDOPRINOS.Tag = "labelSHEMAPLDOPIDDOPRINOS";
            this.label1SHEMAPLDOPIDDOPRINOS.Text = "Šifra doprinosa:";
            this.label1SHEMAPLDOPIDDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1SHEMAPLDOPIDDOPRINOS.AutoSize = true;
            this.label1SHEMAPLDOPIDDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1SHEMAPLDOPIDDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMAPLDOPIDDOPRINOS.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1SHEMAPLDOPIDDOPRINOS.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1SHEMAPLDOPIDDOPRINOS.ImageSize = size;
            this.label1SHEMAPLDOPIDDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1SHEMAPLDOPIDDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.Controls.Add(this.label1SHEMAPLDOPIDDOPRINOS, 0, 0);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetColumnSpan(this.label1SHEMAPLDOPIDDOPRINOS, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetRowSpan(this.label1SHEMAPLDOPIDDOPRINOS, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1SHEMAPLDOPIDDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMAPLDOPIDDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(110, 0x17);
            this.label1SHEMAPLDOPIDDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSHEMAPLDOPIDDOPRINOS.Location = point;
            this.textSHEMAPLDOPIDDOPRINOS.Name = "textSHEMAPLDOPIDDOPRINOS";
            this.textSHEMAPLDOPIDDOPRINOS.Tag = "SHEMAPLDOPIDDOPRINOS";
            this.textSHEMAPLDOPIDDOPRINOS.TabIndex = 0;
            this.textSHEMAPLDOPIDDOPRINOS.Anchor = AnchorStyles.Left;
            this.textSHEMAPLDOPIDDOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSHEMAPLDOPIDDOPRINOS.ReadOnly = false;
            this.textSHEMAPLDOPIDDOPRINOS.PromptChar = ' ';
            this.textSHEMAPLDOPIDDOPRINOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textSHEMAPLDOPIDDOPRINOS.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAPLACASHEMAPLACADOP, "SHEMAPLDOPIDDOPRINOS"));
            this.textSHEMAPLDOPIDDOPRINOS.NumericType = NumericType.Integer;
            this.textSHEMAPLDOPIDDOPRINOS.MaskInput = "{LOC}-nnnnnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonDOPRINOSSHEMAPLDOPIDDOPRINOS",
                Tag = "editorButtonDOPRINOSSHEMAPLDOPIDDOPRINOS",
                Text = "..."
            };
            this.textSHEMAPLDOPIDDOPRINOS.ButtonsRight.Add(button);
            this.textSHEMAPLDOPIDDOPRINOS.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptDOPRINOSSHEMAPLDOPIDDOPRINOS);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.Controls.Add(this.textSHEMAPLDOPIDDOPRINOS, 1, 0);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetColumnSpan(this.textSHEMAPLDOPIDDOPRINOS, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetRowSpan(this.textSHEMAPLDOPIDDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSHEMAPLDOPIDDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textSHEMAPLDOPIDDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textSHEMAPLDOPIDDOPRINOS.Size = size;
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
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.Controls.Add(this.label1KONTODOPIDKONTO, 0, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetColumnSpan(this.label1KONTODOPIDKONTO, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetRowSpan(this.label1KONTODOPIDKONTO, 1);
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
            this.comboKONTODOPIDKONTO.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAPLACASHEMAPLACADOP, "KONTODOPIDKONTO"));
            this.comboKONTODOPIDKONTO.ShowPictureBox = true;
            this.comboKONTODOPIDKONTO.PictureBoxClicked += new EventHandler(this.PictureBoxClickedKONTODOPIDKONTO);
            this.comboKONTODOPIDKONTO.ValueMember = "IDKONTO";
            this.comboKONTODOPIDKONTO.SelectionChanged += new EventHandler(this.SelectedIndexChangedKONTODOPIDKONTO);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.Controls.Add(this.comboKONTODOPIDKONTO, 1, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetColumnSpan(this.comboKONTODOPIDKONTO, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetRowSpan(this.comboKONTODOPIDKONTO, 1);
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
            this.label1MTDOPIDMJESTOTROSKA.Text = "Mjesto troška:";
            this.label1MTDOPIDMJESTOTROSKA.StyleSetName = "FieldUltraLabel";
            this.label1MTDOPIDMJESTOTROSKA.AutoSize = true;
            this.label1MTDOPIDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.label1MTDOPIDMJESTOTROSKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MTDOPIDMJESTOTROSKA.Appearance.ForeColor = Color.Black;
            this.label1MTDOPIDMJESTOTROSKA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.Controls.Add(this.label1MTDOPIDMJESTOTROSKA, 0, 2);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetColumnSpan(this.label1MTDOPIDMJESTOTROSKA, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetRowSpan(this.label1MTDOPIDMJESTOTROSKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MTDOPIDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MTDOPIDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(0x68, 0x17);
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
            this.comboMTDOPIDMJESTOTROSKA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAPLACASHEMAPLACADOP, "MTDOPIDMJESTOTROSKA"));
            this.comboMTDOPIDMJESTOTROSKA.ShowPictureBox = true;
            this.comboMTDOPIDMJESTOTROSKA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedMTDOPIDMJESTOTROSKA);
            this.comboMTDOPIDMJESTOTROSKA.ValueMember = "IDMJESTOTROSKA";
            this.comboMTDOPIDMJESTOTROSKA.SelectionChanged += new EventHandler(this.SelectedIndexChangedMTDOPIDMJESTOTROSKA);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.Controls.Add(this.comboMTDOPIDMJESTOTROSKA, 1, 2);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetColumnSpan(this.comboMTDOPIDMJESTOTROSKA, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetRowSpan(this.comboMTDOPIDMJESTOTROSKA, 1);
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
            this.label1STRANEDOPIDSTRANEKNJIZENJA.Text = "Strana knjiženja:";
            this.label1STRANEDOPIDSTRANEKNJIZENJA.StyleSetName = "FieldUltraLabel";
            this.label1STRANEDOPIDSTRANEKNJIZENJA.AutoSize = true;
            this.label1STRANEDOPIDSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.label1STRANEDOPIDSTRANEKNJIZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1STRANEDOPIDSTRANEKNJIZENJA.Appearance.ForeColor = Color.Black;
            this.label1STRANEDOPIDSTRANEKNJIZENJA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.Controls.Add(this.label1STRANEDOPIDSTRANEKNJIZENJA, 0, 3);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetColumnSpan(this.label1STRANEDOPIDSTRANEKNJIZENJA, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetRowSpan(this.label1STRANEDOPIDSTRANEKNJIZENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1STRANEDOPIDSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1STRANEDOPIDSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x79, 0x17);
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
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAPLACASHEMAPLACADOP, "STRANEDOPIDSTRANEKNJIZENJA"));
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.ShowPictureBox = true;
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSTRANEDOPIDSTRANEKNJIZENJA);
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.ValueMember = "IDSTRANEKNJIZENJA";
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.SelectionChanged += new EventHandler(this.SelectedIndexChangedSTRANEDOPIDSTRANEKNJIZENJA);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.Controls.Add(this.comboSTRANEDOPIDSTRANEKNJIZENJA, 1, 3);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetColumnSpan(this.comboSTRANEDOPIDSTRANEKNJIZENJA, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetRowSpan(this.comboSTRANEDOPIDSTRANEKNJIZENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboSTRANEDOPIDSTRANEKNJIZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMAPLDOPNAZIVDOPRINOS.Location = point;
            this.label1SHEMAPLDOPNAZIVDOPRINOS.Name = "label1SHEMAPLDOPNAZIVDOPRINOS";
            this.label1SHEMAPLDOPNAZIVDOPRINOS.TabIndex = 1;
            this.label1SHEMAPLDOPNAZIVDOPRINOS.Tag = "labelSHEMAPLDOPNAZIVDOPRINOS";
            this.label1SHEMAPLDOPNAZIVDOPRINOS.Text = "Naziv doprinosa:";
            this.label1SHEMAPLDOPNAZIVDOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1SHEMAPLDOPNAZIVDOPRINOS.AutoSize = true;
            this.label1SHEMAPLDOPNAZIVDOPRINOS.Anchor = AnchorStyles.Left;
            this.label1SHEMAPLDOPNAZIVDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMAPLDOPNAZIVDOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1SHEMAPLDOPNAZIVDOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.Controls.Add(this.label1SHEMAPLDOPNAZIVDOPRINOS, 0, 4);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetColumnSpan(this.label1SHEMAPLDOPNAZIVDOPRINOS, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetRowSpan(this.label1SHEMAPLDOPNAZIVDOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SHEMAPLDOPNAZIVDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMAPLDOPNAZIVDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x77, 0x17);
            this.label1SHEMAPLDOPNAZIVDOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelSHEMAPLDOPNAZIVDOPRINOS.Location = point;
            this.labelSHEMAPLDOPNAZIVDOPRINOS.Name = "labelSHEMAPLDOPNAZIVDOPRINOS";
            this.labelSHEMAPLDOPNAZIVDOPRINOS.Tag = "SHEMAPLDOPNAZIVDOPRINOS";
            this.labelSHEMAPLDOPNAZIVDOPRINOS.TabIndex = 0;
            this.labelSHEMAPLDOPNAZIVDOPRINOS.Anchor = AnchorStyles.Left;
            this.labelSHEMAPLDOPNAZIVDOPRINOS.BackColor = Color.Transparent;
            this.labelSHEMAPLDOPNAZIVDOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceSHEMAPLACASHEMAPLACADOP, "SHEMAPLDOPNAZIVDOPRINOS"));
            this.labelSHEMAPLDOPNAZIVDOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.Controls.Add(this.labelSHEMAPLDOPNAZIVDOPRINOS, 1, 4);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetColumnSpan(this.labelSHEMAPLDOPNAZIVDOPRINOS, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.SetRowSpan(this.labelSHEMAPLDOPNAZIVDOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelSHEMAPLDOPNAZIVDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelSHEMAPLDOPNAZIVDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelSHEMAPLDOPNAZIVDOPRINOS.Size = size;
            this.Controls.Add(this.layoutManagerformSHEMAPLACASHEMAPLACADOP);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSHEMAPLACASHEMAPLACADOP;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "SHEMAPLACAFormSHEMAPLACASHEMAPLACADOPUserControl";
            this.Text = " Doprinosi";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.SHEMAPLACAFormUserControl_Load);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.ResumeLayout(false);
            this.layoutManagerformSHEMAPLACASHEMAPLACADOP.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSHEMAPLACASHEMAPLACADOP).EndInit();
            ((ISupportInitialize) this.textSHEMAPLDOPIDDOPRINOS).EndInit();
            this.dsSHEMAPLACADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.SHEMAPLACAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAPLACASHEMAPLACADOP, this.SHEMAPLACAController.WorkItem, this))
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
            this.label1SHEMAPLDOPIDDOPRINOS.Text = StringResources.SHEMAPLACASHEMAPLDOPIDDOPRINOSDescription;
            this.label1KONTODOPIDKONTO.Text = StringResources.SHEMAPLACAKONTODOPIDKONTODescription;
            this.label1MTDOPIDMJESTOTROSKA.Text = StringResources.SHEMAPLACAMTDOPIDMJESTOTROSKADescription;
            this.label1STRANEDOPIDSTRANEKNJIZENJA.Text = StringResources.SHEMAPLACASTRANEDOPIDSTRANEKNJIZENJADescription;
            this.label1SHEMAPLDOPNAZIVDOPRINOS.Text = StringResources.SHEMAPLACASHEMAPLDOPNAZIVDOPRINOSDescription;
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
            if (!this.SHEMAPLACAController.WorkItem.Items.Contains("SHEMAPLACASHEMAPLACADOP|SHEMAPLACASHEMAPLACADOP"))
            {
                this.SHEMAPLACAController.WorkItem.Items.Add(this.bindingSourceSHEMAPLACASHEMAPLACADOP, "SHEMAPLACASHEMAPLACADOP|SHEMAPLACASHEMAPLACADOP");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("SHEMAPLACASHEMAPLACADOPSaveAndClose")]
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
                    ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACADOP.Current).Row["KONTODOPIDKONTO"] = RuntimeHelpers.GetObjectValue(row["IDKONTO"]);
                    this.bindingSourceSHEMAPLACASHEMAPLACADOP.ResetCurrentItem();
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
                    ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACADOP.Current).Row["MTDOPIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["IDMJESTOTROSKA"]);
                    this.bindingSourceSHEMAPLACASHEMAPLACADOP.ResetCurrentItem();
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
                    ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACADOP.Current).Row["STRANEDOPIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(row["IDSTRANEKNJIZENJA"]);
                    this.bindingSourceSHEMAPLACASHEMAPLACADOP.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.textSHEMAPLDOPIDDOPRINOS.Focus();
        }

        private void SetNullItem_Click(object sender, EventArgs e)
        {
            this.m_BaseMethods.SetNullItemClickBase(RuntimeHelpers.GetObjectValue(sender), this.m_CurrentRow);
        }

        private void SetSize()
        {
        }

        private void SHEMAPLACAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.SHEMAPLACASHEMAPLACASHEMAPLACADOPLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.m_FrameworkDescription, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void UpdateValuesDOPRINOSSHEMAPLDOPIDDOPRINOS(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACADOP.Current).Row["SHEMAPLDOPIDDOPRINOS"] = RuntimeHelpers.GetObjectValue(result["IDDOPRINOS"]);
                ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACADOP.Current).Row["SHEMAPLDOPNAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(result["NAZIVDOPRINOS"]);
                this.bindingSourceSHEMAPLACASHEMAPLACADOP.ResetCurrentItem();
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

        protected virtual UltraLabel label1SHEMAPLDOPIDDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMAPLDOPIDDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMAPLDOPIDDOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1SHEMAPLDOPNAZIVDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMAPLDOPNAZIVDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMAPLDOPNAZIVDOPRINOS = value;
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

        protected virtual UltraLabel labelSHEMAPLDOPNAZIVDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelSHEMAPLDOPNAZIVDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelSHEMAPLDOPNAZIVDOPRINOS = value;
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.SHEMAPLACAController SHEMAPLACAController { get; set; }

        protected virtual UltraNumericEditor textSHEMAPLDOPIDDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSHEMAPLDOPIDDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSHEMAPLDOPIDDOPRINOS = value;
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

