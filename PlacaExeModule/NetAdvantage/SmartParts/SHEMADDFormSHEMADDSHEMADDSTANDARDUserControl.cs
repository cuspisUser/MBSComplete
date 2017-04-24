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
    public class SHEMADDFormSHEMADDSHEMADDSTANDARDUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboKONTODDVRSTAIZNOSAIDKONTO")]
        private KONTOComboBox _comboKONTODDVRSTAIZNOSAIDKONTO;
        [AccessedThroughProperty("comboMTDDVRSTAIZNOSAIDMJESTOTROSKA")]
        private MJESTOTROSKAComboBox _comboMTDDVRSTAIZNOSAIDMJESTOTROSKA;
        [AccessedThroughProperty("comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA")]
        private STRANEKNJIZENJAComboBox _comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDDDVRSTEIZNOSA")]
        private UltraLabel _label1IDDDVRSTEIZNOSA;
        [AccessedThroughProperty("label1KONTODDVRSTAIZNOSAIDKONTO")]
        private UltraLabel _label1KONTODDVRSTAIZNOSAIDKONTO;
        [AccessedThroughProperty("label1MTDDVRSTAIZNOSAIDMJESTOTROSKA")]
        private UltraLabel _label1MTDDVRSTAIZNOSAIDMJESTOTROSKA;
        [AccessedThroughProperty("label1NAZIVDDVRSTEIZNOSA")]
        private UltraLabel _label1NAZIVDDVRSTEIZNOSA;
        [AccessedThroughProperty("label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA")]
        private UltraLabel _label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA;
        [AccessedThroughProperty("labelNAZIVDDVRSTEIZNOSA")]
        private UltraLabel _labelNAZIVDDVRSTEIZNOSA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDDDVRSTEIZNOSA")]
        private UltraNumericEditor _textIDDDVRSTEIZNOSA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSHEMADDSHEMADDSTANDARD;
        private IContainer components = null;
        private SHEMADDDataSet dsSHEMADDDataSet1;
        protected TableLayoutPanel layoutManagerformSHEMADDSHEMADDSTANDARD;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "SHEMADDSHEMADDSTANDARD";
        private string m_FrameworkDescription = StringResources.SHEMADDDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public SHEMADDFormSHEMADDSHEMADDSTANDARDUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("SHEMADDSHEMADDSTANDARDAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SHEMADDSHEMADDSTANDARDAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow) ((DataRowView) this.bindingSourceSHEMADDSHEMADDSTANDARD.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CallPromptDDVRSTEIZNOSAIDDDVRSTEIZNOSA(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.Controller.SelectDDVRSTEIZNOSAIDDDVRSTEIZNOSA(fillMethod, fillByRow);
            this.UpdateValuesDDVRSTEIZNOSAIDDDVRSTEIZNOSA(result);
        }

        private void CallViewDDVRSTEIZNOSAIDDDVRSTEIZNOSA(object sender, EventArgs e)
        {
            DataRow result = this.Controller.ShowDDVRSTEIZNOSAIDDDVRSTEIZNOSA(this.m_CurrentRow);
            this.UpdateValuesDDVRSTEIZNOSAIDDDVRSTEIZNOSA(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsSHEMADDDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceSHEMADDSHEMADDSTANDARD.DataSource = this.Controller.DataSet;
            this.dsSHEMADDDataSet1 = this.Controller.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void comboKONTODDVRSTAIZNOSAIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            this.comboKONTODDVRSTAIZNOSAIDKONTO.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/MJESTOTROSKA", Thread=ThreadOption.UserInterface)]
        public void comboMTDDVRSTAIZNOSAIDMJESTOTROSKA_Add(object sender, ComponentEventArgs e)
        {
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRANEKNJIZENJA", Thread=ThreadOption.UserInterface)]
        public void comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA_Add(object sender, ComponentEventArgs e)
        {
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Fill();
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
            this.bindingSourceSHEMADDSHEMADDSTANDARD.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsSHEMADDDataSet1.Tables["SHEMADDSHEMADDSTANDARD"]);
            this.bindingSourceSHEMADDSHEMADDSTANDARD.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "SHEMADD", this.m_Mode, this.dsSHEMADDDataSet1, this.dsSHEMADDDataSet1.SHEMADDSHEMADDSTANDARD.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow) ((DataRowView) this.bindingSourceSHEMADDSHEMADDSTANDARD.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (SHEMADDDataSet.SHEMADDSHEMADDSTANDARDRow) ((DataRowView) this.bindingSourceSHEMADDSHEMADDSTANDARD.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(SHEMADDFormSHEMADDSHEMADDSTANDARDUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSHEMADDSHEMADDSTANDARD = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMADDSHEMADDSTANDARD).BeginInit();
            this.layoutManagerformSHEMADDSHEMADDSTANDARD = new TableLayoutPanel();
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SuspendLayout();
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.AutoSize = true;
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.Dock = DockStyle.Fill;
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.Size = size;
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.ColumnCount = 2;
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.RowCount = 6;
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.RowStyles.Add(new RowStyle());
            this.label1IDDDVRSTEIZNOSA = new UltraLabel();
            this.textIDDDVRSTEIZNOSA = new UltraNumericEditor();
            this.label1KONTODDVRSTAIZNOSAIDKONTO = new UltraLabel();
            this.comboKONTODDVRSTAIZNOSAIDKONTO = new KONTOComboBox();
            this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA = new UltraLabel();
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA = new MJESTOTROSKAComboBox();
            this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA = new UltraLabel();
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA = new STRANEKNJIZENJAComboBox();
            this.label1NAZIVDDVRSTEIZNOSA = new UltraLabel();
            this.labelNAZIVDDVRSTEIZNOSA = new UltraLabel();
            ((ISupportInitialize) this.textIDDDVRSTEIZNOSA).BeginInit();
            this.dsSHEMADDDataSet1 = new SHEMADDDataSet();
            this.dsSHEMADDDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSHEMADDDataSet1.DataSetName = "dsSHEMADD";
            this.dsSHEMADDDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSHEMADDSHEMADDSTANDARD.DataSource = this.dsSHEMADDDataSet1;
            this.bindingSourceSHEMADDSHEMADDSTANDARD.DataMember = "SHEMADDSHEMADDSTANDARD";
            ((ISupportInitialize) this.bindingSourceSHEMADDSHEMADDSTANDARD).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDDDVRSTEIZNOSA.Location = point;
            this.label1IDDDVRSTEIZNOSA.Name = "label1IDDDVRSTEIZNOSA";
            this.label1IDDDVRSTEIZNOSA.TabIndex = 1;
            this.label1IDDDVRSTEIZNOSA.Tag = "labelIDDDVRSTEIZNOSA";
            this.label1IDDDVRSTEIZNOSA.Text = "Šifra iznosa:";
            this.label1IDDDVRSTEIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1IDDDVRSTEIZNOSA.AutoSize = true;
            this.label1IDDDVRSTEIZNOSA.Anchor = AnchorStyles.Left;
            this.label1IDDDVRSTEIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDDDVRSTEIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1IDDDVRSTEIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.Controls.Add(this.label1IDDDVRSTEIZNOSA, 0, 0);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetColumnSpan(this.label1IDDDVRSTEIZNOSA, 1);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetRowSpan(this.label1IDDDVRSTEIZNOSA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDDDVRSTEIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDDDVRSTEIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x5b, 0x17);
            this.label1IDDDVRSTEIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDDDVRSTEIZNOSA.Location = point;
            this.textIDDDVRSTEIZNOSA.Name = "textIDDDVRSTEIZNOSA";
            this.textIDDDVRSTEIZNOSA.Tag = "IDDDVRSTEIZNOSA";
            this.textIDDDVRSTEIZNOSA.TabIndex = 0;
            this.textIDDDVRSTEIZNOSA.Anchor = AnchorStyles.Left;
            this.textIDDDVRSTEIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDDDVRSTEIZNOSA.ReadOnly = false;
            this.textIDDDVRSTEIZNOSA.PromptChar = ' ';
            this.textIDDDVRSTEIZNOSA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDDDVRSTEIZNOSA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMADDSHEMADDSTANDARD, "IDDDVRSTEIZNOSA"));
            this.textIDDDVRSTEIZNOSA.NumericType = NumericType.Integer;
            this.textIDDDVRSTEIZNOSA.MaskInput = "{LOC}-nnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonDDVRSTEIZNOSAIDDDVRSTEIZNOSA",
                Tag = "editorButtonDDVRSTEIZNOSAIDDDVRSTEIZNOSA",
                Text = "..."
            };
            this.textIDDDVRSTEIZNOSA.ButtonsRight.Add(button);
            this.textIDDDVRSTEIZNOSA.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptDDVRSTEIZNOSAIDDDVRSTEIZNOSA);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.Controls.Add(this.textIDDDVRSTEIZNOSA, 1, 0);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetColumnSpan(this.textIDDDVRSTEIZNOSA, 1);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetRowSpan(this.textIDDDVRSTEIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDDDVRSTEIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDDDVRSTEIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDDDVRSTEIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KONTODDVRSTAIZNOSAIDKONTO.Location = point;
            this.label1KONTODDVRSTAIZNOSAIDKONTO.Name = "label1KONTODDVRSTAIZNOSAIDKONTO";
            this.label1KONTODDVRSTAIZNOSAIDKONTO.TabIndex = 1;
            this.label1KONTODDVRSTAIZNOSAIDKONTO.Tag = "labelKONTODDVRSTAIZNOSAIDKONTO";
            this.label1KONTODDVRSTAIZNOSAIDKONTO.Text = "Konto:";
            this.label1KONTODDVRSTAIZNOSAIDKONTO.StyleSetName = "FieldUltraLabel";
            this.label1KONTODDVRSTAIZNOSAIDKONTO.AutoSize = true;
            this.label1KONTODDVRSTAIZNOSAIDKONTO.Anchor = AnchorStyles.Left;
            this.label1KONTODDVRSTAIZNOSAIDKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1KONTODDVRSTAIZNOSAIDKONTO.Appearance.ForeColor = Color.Black;
            this.label1KONTODDVRSTAIZNOSAIDKONTO.BackColor = Color.Transparent;
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.Controls.Add(this.label1KONTODDVRSTAIZNOSAIDKONTO, 0, 1);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetColumnSpan(this.label1KONTODDVRSTAIZNOSAIDKONTO, 1);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetRowSpan(this.label1KONTODDVRSTAIZNOSAIDKONTO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KONTODDVRSTAIZNOSAIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KONTODDVRSTAIZNOSAIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x38, 0x17);
            this.label1KONTODDVRSTAIZNOSAIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboKONTODDVRSTAIZNOSAIDKONTO.Location = point;
            this.comboKONTODDVRSTAIZNOSAIDKONTO.Name = "comboKONTODDVRSTAIZNOSAIDKONTO";
            this.comboKONTODDVRSTAIZNOSAIDKONTO.Tag = "KONTODDVRSTAIZNOSAIDKONTO";
            this.comboKONTODDVRSTAIZNOSAIDKONTO.TabIndex = 0;
            this.comboKONTODDVRSTAIZNOSAIDKONTO.Anchor = AnchorStyles.Left;
            this.comboKONTODDVRSTAIZNOSAIDKONTO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboKONTODDVRSTAIZNOSAIDKONTO.DropDownStyle = DropDownStyle.DropDown;
            this.comboKONTODDVRSTAIZNOSAIDKONTO.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboKONTODDVRSTAIZNOSAIDKONTO.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboKONTODDVRSTAIZNOSAIDKONTO.Enabled = true;
            this.comboKONTODDVRSTAIZNOSAIDKONTO.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMADDSHEMADDSTANDARD, "KONTODDVRSTAIZNOSAIDKONTO"));
            this.comboKONTODDVRSTAIZNOSAIDKONTO.ShowPictureBox = true;
            this.comboKONTODDVRSTAIZNOSAIDKONTO.PictureBoxClicked += new EventHandler(this.PictureBoxClickedKONTODDVRSTAIZNOSAIDKONTO);
            this.comboKONTODDVRSTAIZNOSAIDKONTO.ValueMember = "IDKONTO";
            this.comboKONTODDVRSTAIZNOSAIDKONTO.SelectionChanged += new EventHandler(this.SelectedIndexChangedKONTODDVRSTAIZNOSAIDKONTO);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.Controls.Add(this.comboKONTODDVRSTAIZNOSAIDKONTO, 1, 1);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetColumnSpan(this.comboKONTODDVRSTAIZNOSAIDKONTO, 1);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetRowSpan(this.comboKONTODDVRSTAIZNOSAIDKONTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboKONTODDVRSTAIZNOSAIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboKONTODDVRSTAIZNOSAIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboKONTODDVRSTAIZNOSAIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA.Location = point;
            this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA.Name = "label1MTDDVRSTAIZNOSAIDMJESTOTROSKA";
            this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA.TabIndex = 1;
            this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA.Tag = "labelMTDDVRSTAIZNOSAIDMJESTOTROSKA";
            this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA.Text = "Šifra MT:";
            this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA.StyleSetName = "FieldUltraLabel";
            this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA.AutoSize = true;
            this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA.Appearance.ForeColor = Color.Black;
            this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.Controls.Add(this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA, 0, 2);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetColumnSpan(this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA, 1);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetRowSpan(this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(70, 0x17);
            this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.Location = point;
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.Name = "comboMTDDVRSTAIZNOSAIDMJESTOTROSKA";
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.Tag = "MTDDVRSTAIZNOSAIDMJESTOTROSKA";
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.TabIndex = 0;
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.DropDownStyle = DropDownStyle.DropDown;
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.Enabled = true;
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMADDSHEMADDSTANDARD, "MTDDVRSTAIZNOSAIDMJESTOTROSKA"));
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.ShowPictureBox = true;
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedMTDDVRSTAIZNOSAIDMJESTOTROSKA);
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.ValueMember = "IDMJESTOTROSKA";
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.SelectionChanged += new EventHandler(this.SelectedIndexChangedMTDDVRSTAIZNOSAIDMJESTOTROSKA);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.Controls.Add(this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA, 1, 2);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetColumnSpan(this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA, 1);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetRowSpan(this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Location = point;
            this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Name = "label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA";
            this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.TabIndex = 1;
            this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Tag = "labelSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA";
            this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Text = "Šifra strane:";
            this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.StyleSetName = "FieldUltraLabel";
            this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.AutoSize = true;
            this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Appearance.ForeColor = Color.Black;
            this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.Controls.Add(this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA, 0, 3);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetColumnSpan(this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA, 1);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetRowSpan(this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x5b, 0x17);
            this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Location = point;
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Name = "comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA";
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Tag = "STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA";
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.TabIndex = 0;
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.DropDownStyle = DropDownStyle.DropDown;
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Enabled = true;
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMADDSHEMADDSTANDARD, "STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"));
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ShowPictureBox = true;
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA);
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.ValueMember = "IDSTRANEKNJIZENJA";
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.SelectionChanged += new EventHandler(this.SelectedIndexChangedSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.Controls.Add(this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA, 1, 3);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetColumnSpan(this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA, 1);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetRowSpan(this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVDDVRSTEIZNOSA.Location = point;
            this.label1NAZIVDDVRSTEIZNOSA.Name = "label1NAZIVDDVRSTEIZNOSA";
            this.label1NAZIVDDVRSTEIZNOSA.TabIndex = 1;
            this.label1NAZIVDDVRSTEIZNOSA.Tag = "labelNAZIVDDVRSTEIZNOSA";
            this.label1NAZIVDDVRSTEIZNOSA.Text = "Vrsta iznosa:";
            this.label1NAZIVDDVRSTEIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVDDVRSTEIZNOSA.AutoSize = true;
            this.label1NAZIVDDVRSTEIZNOSA.Anchor = AnchorStyles.Left;
            this.label1NAZIVDDVRSTEIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVDDVRSTEIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVDDVRSTEIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.Controls.Add(this.label1NAZIVDDVRSTEIZNOSA, 0, 4);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetColumnSpan(this.label1NAZIVDDVRSTEIZNOSA, 1);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetRowSpan(this.label1NAZIVDDVRSTEIZNOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVDDVRSTEIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVDDVRSTEIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x5f, 0x17);
            this.label1NAZIVDDVRSTEIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVDDVRSTEIZNOSA.Location = point;
            this.labelNAZIVDDVRSTEIZNOSA.Name = "labelNAZIVDDVRSTEIZNOSA";
            this.labelNAZIVDDVRSTEIZNOSA.Tag = "NAZIVDDVRSTEIZNOSA";
            this.labelNAZIVDDVRSTEIZNOSA.TabIndex = 0;
            this.labelNAZIVDDVRSTEIZNOSA.Anchor = AnchorStyles.Left;
            this.labelNAZIVDDVRSTEIZNOSA.BackColor = Color.Transparent;
            this.labelNAZIVDDVRSTEIZNOSA.DataBindings.Add(new Binding("Text", this.bindingSourceSHEMADDSHEMADDSTANDARD, "NAZIVDDVRSTEIZNOSA"));
            this.labelNAZIVDDVRSTEIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.Controls.Add(this.labelNAZIVDDVRSTEIZNOSA, 1, 4);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetColumnSpan(this.labelNAZIVDDVRSTEIZNOSA, 1);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.SetRowSpan(this.labelNAZIVDDVRSTEIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVDDVRSTEIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVDDVRSTEIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVDDVRSTEIZNOSA.Size = size;
            this.Controls.Add(this.layoutManagerformSHEMADDSHEMADDSTANDARD);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSHEMADDSHEMADDSTANDARD;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "SHEMADDFormSHEMADDSHEMADDSTANDARDUserControl";
            this.Text = " SHEMADDSTANDARD";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.SHEMADDFormUserControl_Load);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.ResumeLayout(false);
            this.layoutManagerformSHEMADDSHEMADDSTANDARD.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSHEMADDSHEMADDSTANDARD).EndInit();
            ((ISupportInitialize) this.textIDDDVRSTEIZNOSA).EndInit();
            this.dsSHEMADDDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.Controller.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMADDSHEMADDSTANDARD, this.Controller.WorkItem, this))
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
            this.label1IDDDVRSTEIZNOSA.Text = StringResources.SHEMADDIDDDVRSTEIZNOSADescription;
            this.label1KONTODDVRSTAIZNOSAIDKONTO.Text = StringResources.SHEMADDKONTODDVRSTAIZNOSAIDKONTODescription;
            this.label1MTDDVRSTAIZNOSAIDMJESTOTROSKA.Text = StringResources.SHEMADDMTDDVRSTAIZNOSAIDMJESTOTROSKADescription;
            this.label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.Text = StringResources.SHEMADDSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJADescription;
            this.label1NAZIVDDVRSTEIZNOSA.Text = StringResources.SHEMADDNAZIVDDVRSTEIZNOSADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedKONTODDVRSTAIZNOSAIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedMTDDVRSTAIZNOSAIDMJESTOTROSKA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("MJESTOTROSKA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("STRANEKNJIZENJA", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.Controller.WorkItem.Items.Contains("SHEMADDSHEMADDSTANDARD|SHEMADDSHEMADDSTANDARD"))
            {
                this.Controller.WorkItem.Items.Add(this.bindingSourceSHEMADDSHEMADDSTANDARD, "SHEMADDSHEMADDSTANDARD|SHEMADDSHEMADDSTANDARD");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("SHEMADDSHEMADDSTANDARDSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedKONTODDVRSTAIZNOSAIDKONTO(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboKONTODDVRSTAIZNOSAIDKONTO.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboKONTODDVRSTAIZNOSAIDKONTO.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMADDSHEMADDSTANDARD.Current).Row["KONTODDVRSTAIZNOSAIDKONTO"] = RuntimeHelpers.GetObjectValue(row["IDKONTO"]);
                    this.bindingSourceSHEMADDSHEMADDSTANDARD.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedMTDDVRSTAIZNOSAIDMJESTOTROSKA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboMTDDVRSTAIZNOSAIDMJESTOTROSKA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMADDSHEMADDSTANDARD.Current).Row["MTDDVRSTAIZNOSAIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["IDMJESTOTROSKA"]);
                    this.bindingSourceSHEMADDSHEMADDSTANDARD.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMADDSHEMADDSTANDARD.Current).Row["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(row["IDSTRANEKNJIZENJA"]);
                    this.bindingSourceSHEMADDSHEMADDSTANDARD.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDDDVRSTEIZNOSA.Focus();
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
            this.Text = StringResources.SHEMADDSHEMADDSHEMADDSTANDARDLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.m_FrameworkDescription, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void UpdateValuesDDVRSTEIZNOSAIDDDVRSTEIZNOSA(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceSHEMADDSHEMADDSTANDARD.Current).Row["IDDDVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(result["IDDDVRSTEIZNOSA"]);
                ((DataRowView) this.bindingSourceSHEMADDSHEMADDSTANDARD.Current).Row["NAZIVDDVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(result["NAZIVDDVRSTEIZNOSA"]);
                this.bindingSourceSHEMADDSHEMADDSTANDARD.ResetCurrentItem();
            }
        }

        protected virtual KONTOComboBox comboKONTODDVRSTAIZNOSAIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboKONTODDVRSTAIZNOSAIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboKONTODDVRSTAIZNOSAIDKONTO = value;
            }
        }

        protected virtual MJESTOTROSKAComboBox comboMTDDVRSTAIZNOSAIDMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboMTDDVRSTAIZNOSAIDMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboMTDDVRSTAIZNOSAIDMJESTOTROSKA = value;
            }
        }

        protected virtual STRANEKNJIZENJAComboBox comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA = value;
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

        protected virtual UltraLabel label1IDDDVRSTEIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDDDVRSTEIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDDDVRSTEIZNOSA = value;
            }
        }

        protected virtual UltraLabel label1KONTODDVRSTAIZNOSAIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KONTODDVRSTAIZNOSAIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KONTODDVRSTAIZNOSAIDKONTO = value;
            }
        }

        protected virtual UltraLabel label1MTDDVRSTAIZNOSAIDMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MTDDVRSTAIZNOSAIDMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MTDDVRSTAIZNOSAIDMJESTOTROSKA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVDDVRSTEIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVDDVRSTEIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVDDVRSTEIZNOSA = value;
            }
        }

        protected virtual UltraLabel label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA = value;
            }
        }

        protected virtual UltraLabel labelNAZIVDDVRSTEIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVDDVRSTEIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVDDVRSTEIZNOSA = value;
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

        protected virtual UltraNumericEditor textIDDDVRSTEIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDDDVRSTEIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDDDVRSTEIZNOSA = value;
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

