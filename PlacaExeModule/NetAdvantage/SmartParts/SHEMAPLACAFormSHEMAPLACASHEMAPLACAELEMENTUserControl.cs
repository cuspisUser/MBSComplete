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
    public class SHEMAPLACAFormSHEMAPLACASHEMAPLACAELEMENTUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboKONTOELEMENTIDKONTO")]
        private KONTOComboBox _comboKONTOELEMENTIDKONTO;
        [AccessedThroughProperty("comboMTELEMENTIDMJESTOTROSKA")]
        private MJESTOTROSKAComboBox _comboMTELEMENTIDMJESTOTROSKA;
        [AccessedThroughProperty("comboSHEMAPLELEMENTIDELEMENT")]
        private ELEMENTComboBox _comboSHEMAPLELEMENTIDELEMENT;
        [AccessedThroughProperty("comboSTRANEELEMENTIDSTRANEKNJIZENJA")]
        private STRANEKNJIZENJAComboBox _comboSTRANEELEMENTIDSTRANEKNJIZENJA;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1KONTOELEMENTIDKONTO")]
        private UltraLabel _label1KONTOELEMENTIDKONTO;
        [AccessedThroughProperty("label1MTELEMENTIDMJESTOTROSKA")]
        private UltraLabel _label1MTELEMENTIDMJESTOTROSKA;
        [AccessedThroughProperty("label1SHEMAPLELEMENTIDELEMENT")]
        private UltraLabel _label1SHEMAPLELEMENTIDELEMENT;
        [AccessedThroughProperty("label1SHEMAPLELEMENTNAZIVELEMENT")]
        private UltraLabel _label1SHEMAPLELEMENTNAZIVELEMENT;
        [AccessedThroughProperty("label1STRANEELEMENTIDSTRANEKNJIZENJA")]
        private UltraLabel _label1STRANEELEMENTIDSTRANEKNJIZENJA;
        [AccessedThroughProperty("labelSHEMAPLELEMENTNAZIVELEMENT")]
        private UltraLabel _labelSHEMAPLELEMENTNAZIVELEMENT;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSHEMAPLACASHEMAPLACAELEMENT;
        private IContainer components = null;
        private SHEMAPLACADataSet dsSHEMAPLACADataSet1;
        protected TableLayoutPanel layoutManagerformSHEMAPLACASHEMAPLACAELEMENT;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "SHEMAPLACASHEMAPLACAELEMENT";
        private string m_FrameworkDescription = StringResources.SHEMAPLACADescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public SHEMAPLACAFormSHEMAPLACASHEMAPLACAELEMENTUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("SHEMAPLACASHEMAPLACAELEMENTAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SHEMAPLACASHEMAPLACAELEMENTAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow) ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsSHEMAPLACADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.DataSource = this.SHEMAPLACAController.DataSet;
            this.dsSHEMAPLACADataSet1 = this.SHEMAPLACAController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void comboKONTOELEMENTIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            this.comboKONTOELEMENTIDKONTO.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/MJESTOTROSKA", Thread=ThreadOption.UserInterface)]
        public void comboMTELEMENTIDMJESTOTROSKA_Add(object sender, ComponentEventArgs e)
        {
            this.comboMTELEMENTIDMJESTOTROSKA.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ELEMENT", Thread=ThreadOption.UserInterface)]
        public void comboSHEMAPLELEMENTIDELEMENT_Add(object sender, ComponentEventArgs e)
        {
            this.comboSHEMAPLELEMENTIDELEMENT.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRANEKNJIZENJA", Thread=ThreadOption.UserInterface)]
        public void comboSTRANEELEMENTIDSTRANEKNJIZENJA_Add(object sender, ComponentEventArgs e)
        {
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.Fill();
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
            this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsSHEMAPLACADataSet1.Tables["SHEMAPLACASHEMAPLACAELEMENT"]);
            this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "SHEMAPLACA", this.m_Mode, this.dsSHEMAPLACADataSet1, this.dsSHEMAPLACADataSet1.SHEMAPLACASHEMAPLACAELEMENT.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow) ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACAELEMENTRow) ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(SHEMAPLACAFormSHEMAPLACASHEMAPLACAELEMENTUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT).BeginInit();
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT = new TableLayoutPanel();
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SuspendLayout();
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.AutoSize = true;
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.Dock = DockStyle.Fill;
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.Size = size;
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.ColumnCount = 2;
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.RowCount = 6;
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.RowStyles.Add(new RowStyle());
            this.label1SHEMAPLELEMENTIDELEMENT = new UltraLabel();
            this.comboSHEMAPLELEMENTIDELEMENT = new ELEMENTComboBox();
            this.label1KONTOELEMENTIDKONTO = new UltraLabel();
            this.comboKONTOELEMENTIDKONTO = new KONTOComboBox();
            this.label1MTELEMENTIDMJESTOTROSKA = new UltraLabel();
            this.comboMTELEMENTIDMJESTOTROSKA = new MJESTOTROSKAComboBox();
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA = new UltraLabel();
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA = new STRANEKNJIZENJAComboBox();
            this.label1SHEMAPLELEMENTNAZIVELEMENT = new UltraLabel();
            this.labelSHEMAPLELEMENTNAZIVELEMENT = new UltraLabel();
            this.dsSHEMAPLACADataSet1 = new SHEMAPLACADataSet();
            this.dsSHEMAPLACADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSHEMAPLACADataSet1.DataSetName = "dsSHEMAPLACA";
            this.dsSHEMAPLACADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.DataSource = this.dsSHEMAPLACADataSet1;
            this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.DataMember = "SHEMAPLACASHEMAPLACAELEMENT";
            ((ISupportInitialize) this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMAPLELEMENTIDELEMENT.Location = point;
            this.label1SHEMAPLELEMENTIDELEMENT.Name = "label1SHEMAPLELEMENTIDELEMENT";
            this.label1SHEMAPLELEMENTIDELEMENT.TabIndex = 1;
            this.label1SHEMAPLELEMENTIDELEMENT.Tag = "labelSHEMAPLELEMENTIDELEMENT";
            this.label1SHEMAPLELEMENTIDELEMENT.Text = "Šifra elementa:";
            this.label1SHEMAPLELEMENTIDELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1SHEMAPLELEMENTIDELEMENT.AutoSize = true;
            this.label1SHEMAPLELEMENTIDELEMENT.Anchor = AnchorStyles.Left;
            this.label1SHEMAPLELEMENTIDELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMAPLELEMENTIDELEMENT.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1SHEMAPLELEMENTIDELEMENT.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1SHEMAPLELEMENTIDELEMENT.ImageSize = size;
            this.label1SHEMAPLELEMENTIDELEMENT.Appearance.ForeColor = Color.Black;
            this.label1SHEMAPLELEMENTIDELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.Controls.Add(this.label1SHEMAPLELEMENTIDELEMENT, 0, 0);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetColumnSpan(this.label1SHEMAPLELEMENTIDELEMENT, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetRowSpan(this.label1SHEMAPLELEMENTIDELEMENT, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1SHEMAPLELEMENTIDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMAPLELEMENTIDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x17);
            this.label1SHEMAPLELEMENTIDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSHEMAPLELEMENTIDELEMENT.Location = point;
            this.comboSHEMAPLELEMENTIDELEMENT.Name = "comboSHEMAPLELEMENTIDELEMENT";
            this.comboSHEMAPLELEMENTIDELEMENT.Tag = "SHEMAPLELEMENTIDELEMENT";
            this.comboSHEMAPLELEMENTIDELEMENT.TabIndex = 0;
            this.comboSHEMAPLELEMENTIDELEMENT.Anchor = AnchorStyles.Left;
            this.comboSHEMAPLELEMENTIDELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSHEMAPLELEMENTIDELEMENT.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAPLELEMENTIDELEMENT.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAPLELEMENTIDELEMENT.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSHEMAPLELEMENTIDELEMENT.Enabled = true;
            this.comboSHEMAPLELEMENTIDELEMENT.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT, "SHEMAPLELEMENTIDELEMENT"));
            this.comboSHEMAPLELEMENTIDELEMENT.ShowPictureBox = true;
            this.comboSHEMAPLELEMENTIDELEMENT.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSHEMAPLELEMENTIDELEMENT);
            this.comboSHEMAPLELEMENTIDELEMENT.ValueMember = "IDELEMENT";
            this.comboSHEMAPLELEMENTIDELEMENT.SelectionChanged += new EventHandler(this.SelectedIndexChangedSHEMAPLELEMENTIDELEMENT);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.Controls.Add(this.comboSHEMAPLELEMENTIDELEMENT, 1, 0);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetColumnSpan(this.comboSHEMAPLELEMENTIDELEMENT, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetRowSpan(this.comboSHEMAPLELEMENTIDELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSHEMAPLELEMENTIDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMAPLELEMENTIDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMAPLELEMENTIDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KONTOELEMENTIDKONTO.Location = point;
            this.label1KONTOELEMENTIDKONTO.Name = "label1KONTOELEMENTIDKONTO";
            this.label1KONTOELEMENTIDKONTO.TabIndex = 1;
            this.label1KONTOELEMENTIDKONTO.Tag = "labelKONTOELEMENTIDKONTO";
            this.label1KONTOELEMENTIDKONTO.Text = "Konto:";
            this.label1KONTOELEMENTIDKONTO.StyleSetName = "FieldUltraLabel";
            this.label1KONTOELEMENTIDKONTO.AutoSize = true;
            this.label1KONTOELEMENTIDKONTO.Anchor = AnchorStyles.Left;
            this.label1KONTOELEMENTIDKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1KONTOELEMENTIDKONTO.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1KONTOELEMENTIDKONTO.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1KONTOELEMENTIDKONTO.ImageSize = size;
            this.label1KONTOELEMENTIDKONTO.Appearance.ForeColor = Color.Black;
            this.label1KONTOELEMENTIDKONTO.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.Controls.Add(this.label1KONTOELEMENTIDKONTO, 0, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetColumnSpan(this.label1KONTOELEMENTIDKONTO, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetRowSpan(this.label1KONTOELEMENTIDKONTO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KONTOELEMENTIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KONTOELEMENTIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1KONTOELEMENTIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboKONTOELEMENTIDKONTO.Location = point;
            this.comboKONTOELEMENTIDKONTO.Name = "comboKONTOELEMENTIDKONTO";
            this.comboKONTOELEMENTIDKONTO.Tag = "KONTOELEMENTIDKONTO";
            this.comboKONTOELEMENTIDKONTO.TabIndex = 0;
            this.comboKONTOELEMENTIDKONTO.Anchor = AnchorStyles.Left;
            this.comboKONTOELEMENTIDKONTO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboKONTOELEMENTIDKONTO.DropDownStyle = DropDownStyle.DropDown;
            this.comboKONTOELEMENTIDKONTO.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboKONTOELEMENTIDKONTO.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboKONTOELEMENTIDKONTO.Enabled = true;
            this.comboKONTOELEMENTIDKONTO.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT, "KONTOELEMENTIDKONTO"));
            this.comboKONTOELEMENTIDKONTO.ShowPictureBox = true;
            this.comboKONTOELEMENTIDKONTO.PictureBoxClicked += new EventHandler(this.PictureBoxClickedKONTOELEMENTIDKONTO);
            this.comboKONTOELEMENTIDKONTO.ValueMember = "IDKONTO";
            this.comboKONTOELEMENTIDKONTO.SelectionChanged += new EventHandler(this.SelectedIndexChangedKONTOELEMENTIDKONTO);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.Controls.Add(this.comboKONTOELEMENTIDKONTO, 1, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetColumnSpan(this.comboKONTOELEMENTIDKONTO, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetRowSpan(this.comboKONTOELEMENTIDKONTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboKONTOELEMENTIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboKONTOELEMENTIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboKONTOELEMENTIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MTELEMENTIDMJESTOTROSKA.Location = point;
            this.label1MTELEMENTIDMJESTOTROSKA.Name = "label1MTELEMENTIDMJESTOTROSKA";
            this.label1MTELEMENTIDMJESTOTROSKA.TabIndex = 1;
            this.label1MTELEMENTIDMJESTOTROSKA.Tag = "labelMTELEMENTIDMJESTOTROSKA";
            this.label1MTELEMENTIDMJESTOTROSKA.Text = "Mjesto troška:";
            this.label1MTELEMENTIDMJESTOTROSKA.StyleSetName = "FieldUltraLabel";
            this.label1MTELEMENTIDMJESTOTROSKA.AutoSize = true;
            this.label1MTELEMENTIDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.label1MTELEMENTIDMJESTOTROSKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MTELEMENTIDMJESTOTROSKA.Appearance.ForeColor = Color.Black;
            this.label1MTELEMENTIDMJESTOTROSKA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.Controls.Add(this.label1MTELEMENTIDMJESTOTROSKA, 0, 2);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetColumnSpan(this.label1MTELEMENTIDMJESTOTROSKA, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetRowSpan(this.label1MTELEMENTIDMJESTOTROSKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MTELEMENTIDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MTELEMENTIDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(0x68, 0x17);
            this.label1MTELEMENTIDMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboMTELEMENTIDMJESTOTROSKA.Location = point;
            this.comboMTELEMENTIDMJESTOTROSKA.Name = "comboMTELEMENTIDMJESTOTROSKA";
            this.comboMTELEMENTIDMJESTOTROSKA.Tag = "MTELEMENTIDMJESTOTROSKA";
            this.comboMTELEMENTIDMJESTOTROSKA.TabIndex = 0;
            this.comboMTELEMENTIDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.comboMTELEMENTIDMJESTOTROSKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboMTELEMENTIDMJESTOTROSKA.DropDownStyle = DropDownStyle.DropDown;
            this.comboMTELEMENTIDMJESTOTROSKA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboMTELEMENTIDMJESTOTROSKA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboMTELEMENTIDMJESTOTROSKA.Enabled = true;
            this.comboMTELEMENTIDMJESTOTROSKA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT, "MTELEMENTIDMJESTOTROSKA"));
            this.comboMTELEMENTIDMJESTOTROSKA.ShowPictureBox = true;
            this.comboMTELEMENTIDMJESTOTROSKA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedMTELEMENTIDMJESTOTROSKA);
            this.comboMTELEMENTIDMJESTOTROSKA.ValueMember = "IDMJESTOTROSKA";
            this.comboMTELEMENTIDMJESTOTROSKA.SelectionChanged += new EventHandler(this.SelectedIndexChangedMTELEMENTIDMJESTOTROSKA);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.Controls.Add(this.comboMTELEMENTIDMJESTOTROSKA, 1, 2);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetColumnSpan(this.comboMTELEMENTIDMJESTOTROSKA, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetRowSpan(this.comboMTELEMENTIDMJESTOTROSKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboMTELEMENTIDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboMTELEMENTIDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboMTELEMENTIDMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.Location = point;
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.Name = "label1STRANEELEMENTIDSTRANEKNJIZENJA";
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.TabIndex = 1;
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.Tag = "labelSTRANEELEMENTIDSTRANEKNJIZENJA";
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.Text = "Strana knjiženja:";
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.StyleSetName = "FieldUltraLabel";
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.AutoSize = true;
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.ImageSize = size;
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.Appearance.ForeColor = Color.Black;
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.Controls.Add(this.label1STRANEELEMENTIDSTRANEKNJIZENJA, 0, 3);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetColumnSpan(this.label1STRANEELEMENTIDSTRANEKNJIZENJA, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetRowSpan(this.label1STRANEELEMENTIDSTRANEKNJIZENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x76, 0x17);
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.Location = point;
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.Name = "comboSTRANEELEMENTIDSTRANEKNJIZENJA";
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.Tag = "STRANEELEMENTIDSTRANEKNJIZENJA";
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.TabIndex = 0;
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.DropDownStyle = DropDownStyle.DropDown;
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.Enabled = true;
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT, "STRANEELEMENTIDSTRANEKNJIZENJA"));
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.ShowPictureBox = true;
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSTRANEELEMENTIDSTRANEKNJIZENJA);
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.ValueMember = "IDSTRANEKNJIZENJA";
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.SelectionChanged += new EventHandler(this.SelectedIndexChangedSTRANEELEMENTIDSTRANEKNJIZENJA);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.Controls.Add(this.comboSTRANEELEMENTIDSTRANEKNJIZENJA, 1, 3);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetColumnSpan(this.comboSTRANEELEMENTIDSTRANEKNJIZENJA, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetRowSpan(this.comboSTRANEELEMENTIDSTRANEKNJIZENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMAPLELEMENTNAZIVELEMENT.Location = point;
            this.label1SHEMAPLELEMENTNAZIVELEMENT.Name = "label1SHEMAPLELEMENTNAZIVELEMENT";
            this.label1SHEMAPLELEMENTNAZIVELEMENT.TabIndex = 1;
            this.label1SHEMAPLELEMENTNAZIVELEMENT.Tag = "labelSHEMAPLELEMENTNAZIVELEMENT";
            this.label1SHEMAPLELEMENTNAZIVELEMENT.Text = "Naziv elementa:";
            this.label1SHEMAPLELEMENTNAZIVELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1SHEMAPLELEMENTNAZIVELEMENT.AutoSize = true;
            this.label1SHEMAPLELEMENTNAZIVELEMENT.Anchor = AnchorStyles.Left;
            this.label1SHEMAPLELEMENTNAZIVELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMAPLELEMENTNAZIVELEMENT.Appearance.ForeColor = Color.Black;
            this.label1SHEMAPLELEMENTNAZIVELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.Controls.Add(this.label1SHEMAPLELEMENTNAZIVELEMENT, 0, 4);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetColumnSpan(this.label1SHEMAPLELEMENTNAZIVELEMENT, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetRowSpan(this.label1SHEMAPLELEMENTNAZIVELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SHEMAPLELEMENTNAZIVELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMAPLELEMENTNAZIVELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x73, 0x17);
            this.label1SHEMAPLELEMENTNAZIVELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelSHEMAPLELEMENTNAZIVELEMENT.Location = point;
            this.labelSHEMAPLELEMENTNAZIVELEMENT.Name = "labelSHEMAPLELEMENTNAZIVELEMENT";
            this.labelSHEMAPLELEMENTNAZIVELEMENT.Tag = "SHEMAPLELEMENTNAZIVELEMENT";
            this.labelSHEMAPLELEMENTNAZIVELEMENT.TabIndex = 0;
            this.labelSHEMAPLELEMENTNAZIVELEMENT.Anchor = AnchorStyles.Left;
            this.labelSHEMAPLELEMENTNAZIVELEMENT.BackColor = Color.Transparent;
            this.labelSHEMAPLELEMENTNAZIVELEMENT.DataBindings.Add(new Binding("Text", this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT, "SHEMAPLELEMENTNAZIVELEMENT"));
            this.labelSHEMAPLELEMENTNAZIVELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.Controls.Add(this.labelSHEMAPLELEMENTNAZIVELEMENT, 1, 4);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetColumnSpan(this.labelSHEMAPLELEMENTNAZIVELEMENT, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.SetRowSpan(this.labelSHEMAPLELEMENTNAZIVELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelSHEMAPLELEMENTNAZIVELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelSHEMAPLELEMENTNAZIVELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelSHEMAPLELEMENTNAZIVELEMENT.Size = size;
            this.Controls.Add(this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "SHEMAPLACAFormSHEMAPLACASHEMAPLACAELEMENTUserControl";
            this.Text = " SHEMAPLACAELEMENT";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.SHEMAPLACAFormUserControl_Load);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.ResumeLayout(false);
            this.layoutManagerformSHEMAPLACASHEMAPLACAELEMENT.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT).EndInit();
            this.dsSHEMAPLACADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.SHEMAPLACAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT, this.SHEMAPLACAController.WorkItem, this))
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
            this.label1SHEMAPLELEMENTIDELEMENT.Text = StringResources.SHEMAPLACASHEMAPLELEMENTIDELEMENTDescription;
            this.label1KONTOELEMENTIDKONTO.Text = StringResources.SHEMAPLACAKONTOELEMENTIDKONTODescription;
            this.label1MTELEMENTIDMJESTOTROSKA.Text = StringResources.SHEMAPLACAMTELEMENTIDMJESTOTROSKADescription;
            this.label1STRANEELEMENTIDSTRANEKNJIZENJA.Text = StringResources.SHEMAPLACASTRANEELEMENTIDSTRANEKNJIZENJADescription;
            this.label1SHEMAPLELEMENTNAZIVELEMENT.Text = StringResources.SHEMAPLACASHEMAPLELEMENTNAZIVELEMENTDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedKONTOELEMENTIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedMTELEMENTIDMJESTOTROSKA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("MJESTOTROSKA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedSHEMAPLELEMENTIDELEMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ELEMENT", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedSTRANEELEMENTIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("STRANEKNJIZENJA", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.SHEMAPLACAController.WorkItem.Items.Contains("SHEMAPLACASHEMAPLACAELEMENT|SHEMAPLACASHEMAPLACAELEMENT"))
            {
                this.SHEMAPLACAController.WorkItem.Items.Add(this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT, "SHEMAPLACASHEMAPLACAELEMENT|SHEMAPLACASHEMAPLACAELEMENT");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("SHEMAPLACASHEMAPLACAELEMENTSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedKONTOELEMENTIDKONTO(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboKONTOELEMENTIDKONTO.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboKONTOELEMENTIDKONTO.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.Current).Row["KONTOELEMENTIDKONTO"] = RuntimeHelpers.GetObjectValue(row["IDKONTO"]);
                    this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedMTELEMENTIDMJESTOTROSKA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboMTELEMENTIDMJESTOTROSKA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboMTELEMENTIDMJESTOTROSKA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.Current).Row["MTELEMENTIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["IDMJESTOTROSKA"]);
                    this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedSHEMAPLELEMENTIDELEMENT(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSHEMAPLELEMENTIDELEMENT.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSHEMAPLELEMENTIDELEMENT.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.Current).Row["SHEMAPLELEMENTIDELEMENT"] = RuntimeHelpers.GetObjectValue(row["IDELEMENT"]);
                    ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.Current).Row["SHEMAPLELEMENTNAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(row["NAZIVELEMENT"]);
                    ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.Current).Row["SHEMAPLELEMENTIDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(row["IDVRSTAELEMENTA"]);
                    this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedSTRANEELEMENTIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSTRANEELEMENTIDSTRANEKNJIZENJA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.Current).Row["STRANEELEMENTIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(row["IDSTRANEKNJIZENJA"]);
                    this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboSHEMAPLELEMENTIDELEMENT.Focus();
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
            this.Text = StringResources.SHEMAPLACASHEMAPLACASHEMAPLACAELEMENTLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.m_FrameworkDescription, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        protected virtual KONTOComboBox comboKONTOELEMENTIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboKONTOELEMENTIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboKONTOELEMENTIDKONTO = value;
            }
        }

        protected virtual MJESTOTROSKAComboBox comboMTELEMENTIDMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboMTELEMENTIDMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboMTELEMENTIDMJESTOTROSKA = value;
            }
        }

        protected virtual ELEMENTComboBox comboSHEMAPLELEMENTIDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSHEMAPLELEMENTIDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSHEMAPLELEMENTIDELEMENT = value;
            }
        }

        protected virtual STRANEKNJIZENJAComboBox comboSTRANEELEMENTIDSTRANEKNJIZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSTRANEELEMENTIDSTRANEKNJIZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSTRANEELEMENTIDSTRANEKNJIZENJA = value;
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

        protected virtual UltraLabel label1KONTOELEMENTIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KONTOELEMENTIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KONTOELEMENTIDKONTO = value;
            }
        }

        protected virtual UltraLabel label1MTELEMENTIDMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MTELEMENTIDMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MTELEMENTIDMJESTOTROSKA = value;
            }
        }

        protected virtual UltraLabel label1SHEMAPLELEMENTIDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMAPLELEMENTIDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMAPLELEMENTIDELEMENT = value;
            }
        }

        protected virtual UltraLabel label1SHEMAPLELEMENTNAZIVELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMAPLELEMENTNAZIVELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMAPLELEMENTNAZIVELEMENT = value;
            }
        }

        protected virtual UltraLabel label1STRANEELEMENTIDSTRANEKNJIZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1STRANEELEMENTIDSTRANEKNJIZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1STRANEELEMENTIDSTRANEKNJIZENJA = value;
            }
        }

        protected virtual UltraLabel labelSHEMAPLELEMENTNAZIVELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelSHEMAPLELEMENTNAZIVELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelSHEMAPLELEMENTNAZIVELEMENT = value;
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

