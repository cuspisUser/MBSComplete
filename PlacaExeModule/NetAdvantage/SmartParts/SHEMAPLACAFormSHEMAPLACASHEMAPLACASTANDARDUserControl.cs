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
    public class SHEMAPLACAFormSHEMAPLACASHEMAPLACASTANDARDUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDPLVRSTEIZNOSA")]
        private PLVRSTEIZNOSAComboBox _comboIDPLVRSTEIZNOSA;
        [AccessedThroughProperty("comboKONTOPLACAVRSTAIZNOSAIDKONTO")]
        private KONTOComboBox _comboKONTOPLACAVRSTAIZNOSAIDKONTO;
        [AccessedThroughProperty("comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA")]
        private MJESTOTROSKAComboBox _comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA;
        [AccessedThroughProperty("comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA")]
        private STRANEKNJIZENJAComboBox _comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDPLVRSTEIZNOSA")]
        private UltraLabel _label1IDPLVRSTEIZNOSA;
        [AccessedThroughProperty("label1KONTOPLACAVRSTAIZNOSAIDKONTO")]
        private UltraLabel _label1KONTOPLACAVRSTAIZNOSAIDKONTO;
        [AccessedThroughProperty("label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA")]
        private UltraLabel _label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA;
        [AccessedThroughProperty("label1NAZIVPLVRSTEIZNOSA")]
        private UltraLabel _label1NAZIVPLVRSTEIZNOSA;
        [AccessedThroughProperty("label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA")]
        private UltraLabel _label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA;
        [AccessedThroughProperty("labelNAZIVPLVRSTEIZNOSA")]
        private UltraLabel _labelNAZIVPLVRSTEIZNOSA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSHEMAPLACASHEMAPLACASTANDARD;
        private IContainer components = null;
        private SHEMAPLACADataSet dsSHEMAPLACADataSet1;
        protected TableLayoutPanel layoutManagerformSHEMAPLACASHEMAPLACASTANDARD;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "SHEMAPLACASHEMAPLACASTANDARD";
        private string m_FrameworkDescription = StringResources.SHEMAPLACADescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public SHEMAPLACAFormSHEMAPLACASHEMAPLACASTANDARDUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("SHEMAPLACASHEMAPLACASTANDARDAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SHEMAPLACASHEMAPLACASTANDARDAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow) ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsSHEMAPLACADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.DataSource = this.SHEMAPLACAController.DataSet;
            this.dsSHEMAPLACADataSet1 = this.SHEMAPLACAController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/PLVRSTEIZNOSA", Thread=ThreadOption.UserInterface)]
        public void comboIDPLVRSTEIZNOSA_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDPLVRSTEIZNOSA.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void comboKONTOPLACAVRSTAIZNOSAIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/MJESTOTROSKA", Thread=ThreadOption.UserInterface)]
        public void comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA_Add(object sender, ComponentEventArgs e)
        {
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRANEKNJIZENJA", Thread=ThreadOption.UserInterface)]
        public void comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA_Add(object sender, ComponentEventArgs e)
        {
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Fill();
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
            this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsSHEMAPLACADataSet1.Tables["SHEMAPLACASHEMAPLACASTANDARD"]);
            this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "SHEMAPLACA", this.m_Mode, this.dsSHEMAPLACADataSet1, this.dsSHEMAPLACADataSet1.SHEMAPLACASHEMAPLACASTANDARD.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow) ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (SHEMAPLACADataSet.SHEMAPLACASHEMAPLACASTANDARDRow) ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(SHEMAPLACAFormSHEMAPLACASHEMAPLACASTANDARDUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD).BeginInit();
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD = new TableLayoutPanel();
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SuspendLayout();
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.AutoSize = true;
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.Dock = DockStyle.Fill;
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.Size = size;
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.ColumnCount = 2;
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.RowCount = 6;
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.RowStyles.Add(new RowStyle());
            this.label1IDPLVRSTEIZNOSA = new UltraLabel();
            this.comboIDPLVRSTEIZNOSA = new PLVRSTEIZNOSAComboBox();
            this.label1KONTOPLACAVRSTAIZNOSAIDKONTO = new UltraLabel();
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO = new KONTOComboBox();
            this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA = new UltraLabel();
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA = new MJESTOTROSKAComboBox();
            this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA = new UltraLabel();
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA = new STRANEKNJIZENJAComboBox();
            this.label1NAZIVPLVRSTEIZNOSA = new UltraLabel();
            this.labelNAZIVPLVRSTEIZNOSA = new UltraLabel();
            this.dsSHEMAPLACADataSet1 = new SHEMAPLACADataSet();
            this.dsSHEMAPLACADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSHEMAPLACADataSet1.DataSetName = "dsSHEMAPLACA";
            this.dsSHEMAPLACADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.DataSource = this.dsSHEMAPLACADataSet1;
            this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.DataMember = "SHEMAPLACASHEMAPLACASTANDARD";
            ((ISupportInitialize) this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDPLVRSTEIZNOSA.Location = point;
            this.label1IDPLVRSTEIZNOSA.Name = "label1IDPLVRSTEIZNOSA";
            this.label1IDPLVRSTEIZNOSA.TabIndex = 1;
            this.label1IDPLVRSTEIZNOSA.Tag = "labelIDPLVRSTEIZNOSA";
            this.label1IDPLVRSTEIZNOSA.Text = "Šifra iznosa:";
            this.label1IDPLVRSTEIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1IDPLVRSTEIZNOSA.AutoSize = true;
            this.label1IDPLVRSTEIZNOSA.Anchor = AnchorStyles.Left;
            this.label1IDPLVRSTEIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDPLVRSTEIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1IDPLVRSTEIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.Controls.Add(this.label1IDPLVRSTEIZNOSA, 0, 0);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetColumnSpan(this.label1IDPLVRSTEIZNOSA, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetRowSpan(this.label1IDPLVRSTEIZNOSA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDPLVRSTEIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDPLVRSTEIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x5b, 0x17);
            this.label1IDPLVRSTEIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDPLVRSTEIZNOSA.Location = point;
            this.comboIDPLVRSTEIZNOSA.Name = "comboIDPLVRSTEIZNOSA";
            this.comboIDPLVRSTEIZNOSA.Tag = "IDPLVRSTEIZNOSA";
            this.comboIDPLVRSTEIZNOSA.TabIndex = 0;
            this.comboIDPLVRSTEIZNOSA.Anchor = AnchorStyles.Left;
            this.comboIDPLVRSTEIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDPLVRSTEIZNOSA.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDPLVRSTEIZNOSA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDPLVRSTEIZNOSA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDPLVRSTEIZNOSA.Enabled = true;
            this.comboIDPLVRSTEIZNOSA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD, "IDPLVRSTEIZNOSA"));
            this.comboIDPLVRSTEIZNOSA.ShowPictureBox = true;
            this.comboIDPLVRSTEIZNOSA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDPLVRSTEIZNOSA);
            this.comboIDPLVRSTEIZNOSA.ValueMember = "IDPLVRSTEIZNOSA";
            this.comboIDPLVRSTEIZNOSA.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDPLVRSTEIZNOSA);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.Controls.Add(this.comboIDPLVRSTEIZNOSA, 1, 0);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetColumnSpan(this.comboIDPLVRSTEIZNOSA, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetRowSpan(this.comboIDPLVRSTEIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDPLVRSTEIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDPLVRSTEIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDPLVRSTEIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KONTOPLACAVRSTAIZNOSAIDKONTO.Location = point;
            this.label1KONTOPLACAVRSTAIZNOSAIDKONTO.Name = "label1KONTOPLACAVRSTAIZNOSAIDKONTO";
            this.label1KONTOPLACAVRSTAIZNOSAIDKONTO.TabIndex = 1;
            this.label1KONTOPLACAVRSTAIZNOSAIDKONTO.Tag = "labelKONTOPLACAVRSTAIZNOSAIDKONTO";
            this.label1KONTOPLACAVRSTAIZNOSAIDKONTO.Text = "Konto:";
            this.label1KONTOPLACAVRSTAIZNOSAIDKONTO.StyleSetName = "FieldUltraLabel";
            this.label1KONTOPLACAVRSTAIZNOSAIDKONTO.AutoSize = true;
            this.label1KONTOPLACAVRSTAIZNOSAIDKONTO.Anchor = AnchorStyles.Left;
            this.label1KONTOPLACAVRSTAIZNOSAIDKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1KONTOPLACAVRSTAIZNOSAIDKONTO.Appearance.ForeColor = Color.Black;
            this.label1KONTOPLACAVRSTAIZNOSAIDKONTO.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.Controls.Add(this.label1KONTOPLACAVRSTAIZNOSAIDKONTO, 0, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetColumnSpan(this.label1KONTOPLACAVRSTAIZNOSAIDKONTO, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetRowSpan(this.label1KONTOPLACAVRSTAIZNOSAIDKONTO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KONTOPLACAVRSTAIZNOSAIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KONTOPLACAVRSTAIZNOSAIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x38, 0x17);
            this.label1KONTOPLACAVRSTAIZNOSAIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.Location = point;
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.Name = "comboKONTOPLACAVRSTAIZNOSAIDKONTO";
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.Tag = "KONTOPLACAVRSTAIZNOSAIDKONTO";
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.TabIndex = 0;
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.Anchor = AnchorStyles.Left;
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.DropDownStyle = DropDownStyle.DropDown;
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.Enabled = true;
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD, "KONTOPLACAVRSTAIZNOSAIDKONTO"));
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.ShowPictureBox = true;
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.PictureBoxClicked += new EventHandler(this.PictureBoxClickedKONTOPLACAVRSTAIZNOSAIDKONTO);
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.ValueMember = "IDKONTO";
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.SelectionChanged += new EventHandler(this.SelectedIndexChangedKONTOPLACAVRSTAIZNOSAIDKONTO);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.Controls.Add(this.comboKONTOPLACAVRSTAIZNOSAIDKONTO, 1, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetColumnSpan(this.comboKONTOPLACAVRSTAIZNOSAIDKONTO, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetRowSpan(this.comboKONTOPLACAVRSTAIZNOSAIDKONTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Location = point;
            this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Name = "label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA";
            this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA.TabIndex = 1;
            this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Tag = "labelMTPLACAVRSTAIZNOSAIDMJESTOTROSKA";
            this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Text = "Mjesto troška:";
            this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA.StyleSetName = "FieldUltraLabel";
            this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA.AutoSize = true;
            this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Appearance.ForeColor = Color.Black;
            this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.Controls.Add(this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA, 0, 2);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetColumnSpan(this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetRowSpan(this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(0x68, 0x17);
            this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Location = point;
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Name = "comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA";
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Tag = "MTPLACAVRSTAIZNOSAIDMJESTOTROSKA";
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.TabIndex = 0;
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.DropDownStyle = DropDownStyle.DropDown;
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Enabled = true;
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD, "MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"));
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ShowPictureBox = true;
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedMTPLACAVRSTAIZNOSAIDMJESTOTROSKA);
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.ValueMember = "IDMJESTOTROSKA";
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.SelectionChanged += new EventHandler(this.SelectedIndexChangedMTPLACAVRSTAIZNOSAIDMJESTOTROSKA);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.Controls.Add(this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA, 1, 2);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetColumnSpan(this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetRowSpan(this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Location = point;
            this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Name = "label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA";
            this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.TabIndex = 1;
            this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Tag = "labelSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA";
            this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Text = "Strana kniženja:";
            this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.StyleSetName = "FieldUltraLabel";
            this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.AutoSize = true;
            this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Appearance.ForeColor = Color.Black;
            this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.Controls.Add(this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA, 0, 3);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetColumnSpan(this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetRowSpan(this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x74, 0x17);
            this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Location = point;
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Name = "comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA";
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Tag = "STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA";
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.TabIndex = 0;
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.DropDownStyle = DropDownStyle.DropDown;
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Enabled = true;
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD, "STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"));
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ShowPictureBox = true;
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA);
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.ValueMember = "IDSTRANEKNJIZENJA";
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.SelectionChanged += new EventHandler(this.SelectedIndexChangedSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.Controls.Add(this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA, 1, 3);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetColumnSpan(this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetRowSpan(this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVPLVRSTEIZNOSA.Location = point;
            this.label1NAZIVPLVRSTEIZNOSA.Name = "label1NAZIVPLVRSTEIZNOSA";
            this.label1NAZIVPLVRSTEIZNOSA.TabIndex = 1;
            this.label1NAZIVPLVRSTEIZNOSA.Tag = "labelNAZIVPLVRSTEIZNOSA";
            this.label1NAZIVPLVRSTEIZNOSA.Text = "Naziv:";
            this.label1NAZIVPLVRSTEIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVPLVRSTEIZNOSA.AutoSize = true;
            this.label1NAZIVPLVRSTEIZNOSA.Anchor = AnchorStyles.Left;
            this.label1NAZIVPLVRSTEIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVPLVRSTEIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVPLVRSTEIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.Controls.Add(this.label1NAZIVPLVRSTEIZNOSA, 0, 4);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetColumnSpan(this.label1NAZIVPLVRSTEIZNOSA, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetRowSpan(this.label1NAZIVPLVRSTEIZNOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVPLVRSTEIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVPLVRSTEIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1NAZIVPLVRSTEIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVPLVRSTEIZNOSA.Location = point;
            this.labelNAZIVPLVRSTEIZNOSA.Name = "labelNAZIVPLVRSTEIZNOSA";
            this.labelNAZIVPLVRSTEIZNOSA.Tag = "NAZIVPLVRSTEIZNOSA";
            this.labelNAZIVPLVRSTEIZNOSA.TabIndex = 0;
            this.labelNAZIVPLVRSTEIZNOSA.Anchor = AnchorStyles.Left;
            this.labelNAZIVPLVRSTEIZNOSA.BackColor = Color.Transparent;
            this.labelNAZIVPLVRSTEIZNOSA.DataBindings.Add(new Binding("Text", this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD, "NAZIVPLVRSTEIZNOSA"));
            this.labelNAZIVPLVRSTEIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.Controls.Add(this.labelNAZIVPLVRSTEIZNOSA, 1, 4);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetColumnSpan(this.labelNAZIVPLVRSTEIZNOSA, 1);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.SetRowSpan(this.labelNAZIVPLVRSTEIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVPLVRSTEIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVPLVRSTEIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVPLVRSTEIZNOSA.Size = size;
            this.Controls.Add(this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "SHEMAPLACAFormSHEMAPLACASHEMAPLACASTANDARDUserControl";
            this.Text = " SHEMAPLACASTANDARD";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.SHEMAPLACAFormUserControl_Load);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.ResumeLayout(false);
            this.layoutManagerformSHEMAPLACASHEMAPLACASTANDARD.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD).EndInit();
            this.dsSHEMAPLACADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.SHEMAPLACAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD, this.SHEMAPLACAController.WorkItem, this))
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
            this.label1IDPLVRSTEIZNOSA.Text = StringResources.SHEMAPLACAIDPLVRSTEIZNOSADescription;
            this.label1KONTOPLACAVRSTAIZNOSAIDKONTO.Text = StringResources.SHEMAPLACAKONTOPLACAVRSTAIZNOSAIDKONTODescription;
            this.label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA.Text = StringResources.SHEMAPLACAMTPLACAVRSTAIZNOSAIDMJESTOTROSKADescription;
            this.label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.Text = StringResources.SHEMAPLACASTRANEVRSTEIZNOSAIDSTRANEKNJIZENJADescription;
            this.label1NAZIVPLVRSTEIZNOSA.Text = StringResources.SHEMAPLACANAZIVPLVRSTEIZNOSADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIDPLVRSTEIZNOSA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("PLVRSTEIZNOSA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedKONTOPLACAVRSTAIZNOSAIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedMTPLACAVRSTAIZNOSAIDMJESTOTROSKA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("MJESTOTROSKA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("STRANEKNJIZENJA", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.SHEMAPLACAController.WorkItem.Items.Contains("SHEMAPLACASHEMAPLACASTANDARD|SHEMAPLACASHEMAPLACASTANDARD"))
            {
                this.SHEMAPLACAController.WorkItem.Items.Add(this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD, "SHEMAPLACASHEMAPLACASTANDARD|SHEMAPLACASHEMAPLACASTANDARD");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("SHEMAPLACASHEMAPLACASTANDARDSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedIDPLVRSTEIZNOSA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDPLVRSTEIZNOSA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDPLVRSTEIZNOSA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.Current).Row["IDPLVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(row["IDPLVRSTEIZNOSA"]);
                    ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.Current).Row["NAZIVPLVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(row["NAZIVPLVRSTEIZNOSA"]);
                    this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedKONTOPLACAVRSTAIZNOSAIDKONTO(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboKONTOPLACAVRSTAIZNOSAIDKONTO.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.Current).Row["KONTOPLACAVRSTAIZNOSAIDKONTO"] = RuntimeHelpers.GetObjectValue(row["IDKONTO"]);
                    this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedMTPLACAVRSTAIZNOSAIDMJESTOTROSKA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.Current).Row["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["IDMJESTOTROSKA"]);
                    this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.Current).Row["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(row["IDSTRANEKNJIZENJA"]);
                    this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboIDPLVRSTEIZNOSA.Focus();
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
            this.Text = StringResources.SHEMAPLACASHEMAPLACASHEMAPLACASTANDARDLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.m_FrameworkDescription, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        protected virtual PLVRSTEIZNOSAComboBox comboIDPLVRSTEIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDPLVRSTEIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDPLVRSTEIZNOSA = value;
            }
        }

        protected virtual KONTOComboBox comboKONTOPLACAVRSTAIZNOSAIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboKONTOPLACAVRSTAIZNOSAIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboKONTOPLACAVRSTAIZNOSAIDKONTO = value;
            }
        }

        protected virtual MJESTOTROSKAComboBox comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboMTPLACAVRSTAIZNOSAIDMJESTOTROSKA = value;
            }
        }

        protected virtual STRANEKNJIZENJAComboBox comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA = value;
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

        protected virtual UltraLabel label1IDPLVRSTEIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDPLVRSTEIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDPLVRSTEIZNOSA = value;
            }
        }

        protected virtual UltraLabel label1KONTOPLACAVRSTAIZNOSAIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KONTOPLACAVRSTAIZNOSAIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KONTOPLACAVRSTAIZNOSAIDKONTO = value;
            }
        }

        protected virtual UltraLabel label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MTPLACAVRSTAIZNOSAIDMJESTOTROSKA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVPLVRSTEIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVPLVRSTEIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVPLVRSTEIZNOSA = value;
            }
        }

        protected virtual UltraLabel label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA = value;
            }
        }

        protected virtual UltraLabel labelNAZIVPLVRSTEIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVPLVRSTEIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVPLVRSTEIZNOSA = value;
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

