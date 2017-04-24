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
    public class SHEMAURAFormSHEMAURASHEMAURAKONTIRANJEUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDURAVRSTAIZNOSA")]
        private URAVRSTAIZNOSAComboBox _comboIDURAVRSTAIZNOSA;
        [AccessedThroughProperty("comboSHEMAURAKONTOIDKONTO")]
        private KONTOComboBox _comboSHEMAURAKONTOIDKONTO;
        [AccessedThroughProperty("comboSHEMAURAMTIDMJESTOTROSKA")]
        private MJESTOTROSKAComboBox _comboSHEMAURAMTIDMJESTOTROSKA;
        [AccessedThroughProperty("comboSHEMAURAOJIDORGJED")]
        private ORGJEDComboBox _comboSHEMAURAOJIDORGJED;
        [AccessedThroughProperty("comboSHEMAURASTRANEIDSTRANEKNJIZENJA")]
        private STRANEKNJIZENJAComboBox _comboSHEMAURASTRANEIDSTRANEKNJIZENJA;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDURAVRSTAIZNOSA")]
        private UltraLabel _label1IDURAVRSTAIZNOSA;
        [AccessedThroughProperty("label1SHEMAURAKONTOIDKONTO")]
        private UltraLabel _label1SHEMAURAKONTOIDKONTO;
        [AccessedThroughProperty("label1SHEMAURAMTIDMJESTOTROSKA")]
        private UltraLabel _label1SHEMAURAMTIDMJESTOTROSKA;
        [AccessedThroughProperty("label1SHEMAURAOJIDORGJED")]
        private UltraLabel _label1SHEMAURAOJIDORGJED;
        [AccessedThroughProperty("label1SHEMAURASTRANEIDSTRANEKNJIZENJA")]
        private UltraLabel _label1SHEMAURASTRANEIDSTRANEKNJIZENJA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSHEMAURASHEMAURAKONTIRANJE;
        private IContainer components = null;
        private SHEMAURADataSet dsSHEMAURADataSet1;
        protected TableLayoutPanel layoutManagerformSHEMAURASHEMAURAKONTIRANJE;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "SHEMAURASHEMAURAKONTIRANJE";
        private string m_FrameworkDescription = StringResources.SHEMAURADescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public SHEMAURAFormSHEMAURASHEMAURAKONTIRANJEUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("SHEMAURASHEMAURAKONTIRANJEAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SHEMAURASHEMAURAKONTIRANJEAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow) ((DataRowView) this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsSHEMAURADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.DataSource = this.SHEMAURAController.DataSet;
            this.dsSHEMAURADataSet1 = this.SHEMAURAController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/URAVRSTAIZNOSA", Thread=ThreadOption.UserInterface)]
        public void comboIDURAVRSTAIZNOSA_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDURAVRSTAIZNOSA.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void comboSHEMAURAKONTOIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            this.comboSHEMAURAKONTOIDKONTO.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/MJESTOTROSKA", Thread=ThreadOption.UserInterface)]
        public void comboSHEMAURAMTIDMJESTOTROSKA_Add(object sender, ComponentEventArgs e)
        {
            this.comboSHEMAURAMTIDMJESTOTROSKA.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ORGJED", Thread=ThreadOption.UserInterface)]
        public void comboSHEMAURAOJIDORGJED_Add(object sender, ComponentEventArgs e)
        {
            this.comboSHEMAURAOJIDORGJED.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRANEKNJIZENJA", Thread=ThreadOption.UserInterface)]
        public void comboSHEMAURASTRANEIDSTRANEKNJIZENJA_Add(object sender, ComponentEventArgs e)
        {
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.Fill();
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
            this.dsSHEMAURADataSet1 = (SHEMAURADataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsSHEMAURADataSet1.Tables["SHEMAURASHEMAURAKONTIRANJE"]);
            this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "SHEMAURA", this.m_Mode, this.dsSHEMAURADataSet1, this.dsSHEMAURADataSet1.SHEMAURASHEMAURAKONTIRANJE.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow) ((DataRowView) this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (SHEMAURADataSet.SHEMAURASHEMAURAKONTIRANJERow) ((DataRowView) this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(SHEMAURAFormSHEMAURASHEMAURAKONTIRANJEUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSHEMAURASHEMAURAKONTIRANJE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMAURASHEMAURAKONTIRANJE).BeginInit();
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE = new TableLayoutPanel();
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SuspendLayout();
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.AutoSize = true;
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.Dock = DockStyle.Fill;
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.Size = size;
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.ColumnCount = 2;
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.RowCount = 6;
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.RowStyles.Add(new RowStyle());
            this.label1SHEMAURAKONTOIDKONTO = new UltraLabel();
            this.comboSHEMAURAKONTOIDKONTO = new KONTOComboBox();
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA = new UltraLabel();
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA = new STRANEKNJIZENJAComboBox();
            this.label1IDURAVRSTAIZNOSA = new UltraLabel();
            this.comboIDURAVRSTAIZNOSA = new URAVRSTAIZNOSAComboBox();
            this.label1SHEMAURAMTIDMJESTOTROSKA = new UltraLabel();
            this.comboSHEMAURAMTIDMJESTOTROSKA = new MJESTOTROSKAComboBox();
            this.label1SHEMAURAOJIDORGJED = new UltraLabel();
            this.comboSHEMAURAOJIDORGJED = new ORGJEDComboBox();
            this.dsSHEMAURADataSet1 = new SHEMAURADataSet();
            this.dsSHEMAURADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSHEMAURADataSet1.DataSetName = "dsSHEMAURA";
            this.dsSHEMAURADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.DataSource = this.dsSHEMAURADataSet1;
            this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.DataMember = "SHEMAURASHEMAURAKONTIRANJE";
            ((ISupportInitialize) this.bindingSourceSHEMAURASHEMAURAKONTIRANJE).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMAURAKONTOIDKONTO.Location = point;
            this.label1SHEMAURAKONTOIDKONTO.Name = "label1SHEMAURAKONTOIDKONTO";
            this.label1SHEMAURAKONTOIDKONTO.TabIndex = 1;
            this.label1SHEMAURAKONTOIDKONTO.Tag = "labelSHEMAURAKONTOIDKONTO";
            this.label1SHEMAURAKONTOIDKONTO.Text = "Konto:";
            this.label1SHEMAURAKONTOIDKONTO.StyleSetName = "FieldUltraLabel";
            this.label1SHEMAURAKONTOIDKONTO.AutoSize = true;
            this.label1SHEMAURAKONTOIDKONTO.Anchor = AnchorStyles.Left;
            this.label1SHEMAURAKONTOIDKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMAURAKONTOIDKONTO.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1SHEMAURAKONTOIDKONTO.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1SHEMAURAKONTOIDKONTO.ImageSize = size;
            this.label1SHEMAURAKONTOIDKONTO.Appearance.ForeColor = Color.Black;
            this.label1SHEMAURAKONTOIDKONTO.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.Controls.Add(this.label1SHEMAURAKONTOIDKONTO, 0, 0);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetColumnSpan(this.label1SHEMAURAKONTOIDKONTO, 1);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetRowSpan(this.label1SHEMAURAKONTOIDKONTO, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1SHEMAURAKONTOIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMAURAKONTOIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1SHEMAURAKONTOIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSHEMAURAKONTOIDKONTO.Location = point;
            this.comboSHEMAURAKONTOIDKONTO.Name = "comboSHEMAURAKONTOIDKONTO";
            this.comboSHEMAURAKONTOIDKONTO.Tag = "SHEMAURAKONTOIDKONTO";
            this.comboSHEMAURAKONTOIDKONTO.TabIndex = 0;
            this.comboSHEMAURAKONTOIDKONTO.Anchor = AnchorStyles.Left;
            this.comboSHEMAURAKONTOIDKONTO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSHEMAURAKONTOIDKONTO.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAURAKONTOIDKONTO.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAURAKONTOIDKONTO.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSHEMAURAKONTOIDKONTO.Enabled = true;
            this.comboSHEMAURAKONTOIDKONTO.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAURASHEMAURAKONTIRANJE, "SHEMAURAKONTOIDKONTO"));
            this.comboSHEMAURAKONTOIDKONTO.ShowPictureBox = true;
            this.comboSHEMAURAKONTOIDKONTO.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSHEMAURAKONTOIDKONTO);
            this.comboSHEMAURAKONTOIDKONTO.ValueMember = "IDKONTO";
            this.comboSHEMAURAKONTOIDKONTO.SelectionChanged += new EventHandler(this.SelectedIndexChangedSHEMAURAKONTOIDKONTO);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.Controls.Add(this.comboSHEMAURAKONTOIDKONTO, 1, 0);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetColumnSpan(this.comboSHEMAURAKONTOIDKONTO, 1);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetRowSpan(this.comboSHEMAURAKONTOIDKONTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSHEMAURAKONTOIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMAURAKONTOIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMAURAKONTOIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.Location = point;
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.Name = "label1SHEMAURASTRANEIDSTRANEKNJIZENJA";
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.TabIndex = 1;
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.Tag = "labelSHEMAURASTRANEIDSTRANEKNJIZENJA";
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.Text = "Strana knjiženja:";
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.StyleSetName = "FieldUltraLabel";
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.AutoSize = true;
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.ImageSize = size;
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.Appearance.ForeColor = Color.Black;
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.Controls.Add(this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA, 0, 1);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetColumnSpan(this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA, 1);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetRowSpan(this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x76, 0x17);
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.Location = point;
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.Name = "comboSHEMAURASTRANEIDSTRANEKNJIZENJA";
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.Tag = "SHEMAURASTRANEIDSTRANEKNJIZENJA";
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.TabIndex = 0;
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.Enabled = true;
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAURASHEMAURAKONTIRANJE, "SHEMAURASTRANEIDSTRANEKNJIZENJA"));
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.ShowPictureBox = true;
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSHEMAURASTRANEIDSTRANEKNJIZENJA);
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.ValueMember = "IDSTRANEKNJIZENJA";
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.SelectionChanged += new EventHandler(this.SelectedIndexChangedSHEMAURASTRANEIDSTRANEKNJIZENJA);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.Controls.Add(this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA, 1, 1);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetColumnSpan(this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA, 1);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetRowSpan(this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDURAVRSTAIZNOSA.Location = point;
            this.label1IDURAVRSTAIZNOSA.Name = "label1IDURAVRSTAIZNOSA";
            this.label1IDURAVRSTAIZNOSA.TabIndex = 1;
            this.label1IDURAVRSTAIZNOSA.Tag = "labelIDURAVRSTAIZNOSA";
            this.label1IDURAVRSTAIZNOSA.Text = "Vrsta iznosa:";
            this.label1IDURAVRSTAIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1IDURAVRSTAIZNOSA.AutoSize = true;
            this.label1IDURAVRSTAIZNOSA.Anchor = AnchorStyles.Left;
            this.label1IDURAVRSTAIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDURAVRSTAIZNOSA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDURAVRSTAIZNOSA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDURAVRSTAIZNOSA.ImageSize = size;
            this.label1IDURAVRSTAIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1IDURAVRSTAIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.Controls.Add(this.label1IDURAVRSTAIZNOSA, 0, 2);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetColumnSpan(this.label1IDURAVRSTAIZNOSA, 1);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetRowSpan(this.label1IDURAVRSTAIZNOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDURAVRSTAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDURAVRSTAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x5c, 0x17);
            this.label1IDURAVRSTAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDURAVRSTAIZNOSA.Location = point;
            this.comboIDURAVRSTAIZNOSA.Name = "comboIDURAVRSTAIZNOSA";
            this.comboIDURAVRSTAIZNOSA.Tag = "IDURAVRSTAIZNOSA";
            this.comboIDURAVRSTAIZNOSA.TabIndex = 0;
            this.comboIDURAVRSTAIZNOSA.Anchor = AnchorStyles.Left;
            this.comboIDURAVRSTAIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDURAVRSTAIZNOSA.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDURAVRSTAIZNOSA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDURAVRSTAIZNOSA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDURAVRSTAIZNOSA.Enabled = true;
            this.comboIDURAVRSTAIZNOSA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAURASHEMAURAKONTIRANJE, "IDURAVRSTAIZNOSA"));
            this.comboIDURAVRSTAIZNOSA.ShowPictureBox = true;
            this.comboIDURAVRSTAIZNOSA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDURAVRSTAIZNOSA);
            this.comboIDURAVRSTAIZNOSA.ValueMember = "IDURAVRSTAIZNOSA";
            this.comboIDURAVRSTAIZNOSA.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDURAVRSTAIZNOSA);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.Controls.Add(this.comboIDURAVRSTAIZNOSA, 1, 2);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetColumnSpan(this.comboIDURAVRSTAIZNOSA, 1);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetRowSpan(this.comboIDURAVRSTAIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDURAVRSTAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboIDURAVRSTAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboIDURAVRSTAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMAURAMTIDMJESTOTROSKA.Location = point;
            this.label1SHEMAURAMTIDMJESTOTROSKA.Name = "label1SHEMAURAMTIDMJESTOTROSKA";
            this.label1SHEMAURAMTIDMJESTOTROSKA.TabIndex = 1;
            this.label1SHEMAURAMTIDMJESTOTROSKA.Tag = "labelSHEMAURAMTIDMJESTOTROSKA";
            this.label1SHEMAURAMTIDMJESTOTROSKA.Text = "Šifra MT:";
            this.label1SHEMAURAMTIDMJESTOTROSKA.StyleSetName = "FieldUltraLabel";
            this.label1SHEMAURAMTIDMJESTOTROSKA.AutoSize = true;
            this.label1SHEMAURAMTIDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.label1SHEMAURAMTIDMJESTOTROSKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMAURAMTIDMJESTOTROSKA.Appearance.ForeColor = Color.Black;
            this.label1SHEMAURAMTIDMJESTOTROSKA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.Controls.Add(this.label1SHEMAURAMTIDMJESTOTROSKA, 0, 3);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetColumnSpan(this.label1SHEMAURAMTIDMJESTOTROSKA, 1);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetRowSpan(this.label1SHEMAURAMTIDMJESTOTROSKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SHEMAURAMTIDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMAURAMTIDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(70, 0x17);
            this.label1SHEMAURAMTIDMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSHEMAURAMTIDMJESTOTROSKA.Location = point;
            this.comboSHEMAURAMTIDMJESTOTROSKA.Name = "comboSHEMAURAMTIDMJESTOTROSKA";
            this.comboSHEMAURAMTIDMJESTOTROSKA.Tag = "SHEMAURAMTIDMJESTOTROSKA";
            this.comboSHEMAURAMTIDMJESTOTROSKA.TabIndex = 0;
            this.comboSHEMAURAMTIDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.comboSHEMAURAMTIDMJESTOTROSKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSHEMAURAMTIDMJESTOTROSKA.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAURAMTIDMJESTOTROSKA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAURAMTIDMJESTOTROSKA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSHEMAURAMTIDMJESTOTROSKA.Enabled = true;
            this.comboSHEMAURAMTIDMJESTOTROSKA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAURASHEMAURAKONTIRANJE, "SHEMAURAMTIDMJESTOTROSKA"));
            this.comboSHEMAURAMTIDMJESTOTROSKA.ShowPictureBox = true;
            this.comboSHEMAURAMTIDMJESTOTROSKA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSHEMAURAMTIDMJESTOTROSKA);
            this.comboSHEMAURAMTIDMJESTOTROSKA.ValueMember = "IDMJESTOTROSKA";
            this.comboSHEMAURAMTIDMJESTOTROSKA.SelectionChanged += new EventHandler(this.SelectedIndexChangedSHEMAURAMTIDMJESTOTROSKA);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.Controls.Add(this.comboSHEMAURAMTIDMJESTOTROSKA, 1, 3);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetColumnSpan(this.comboSHEMAURAMTIDMJESTOTROSKA, 1);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetRowSpan(this.comboSHEMAURAMTIDMJESTOTROSKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSHEMAURAMTIDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMAURAMTIDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMAURAMTIDMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMAURAOJIDORGJED.Location = point;
            this.label1SHEMAURAOJIDORGJED.Name = "label1SHEMAURAOJIDORGJED";
            this.label1SHEMAURAOJIDORGJED.TabIndex = 1;
            this.label1SHEMAURAOJIDORGJED.Tag = "labelSHEMAURAOJIDORGJED";
            this.label1SHEMAURAOJIDORGJED.Text = "Šifra OJ:";
            this.label1SHEMAURAOJIDORGJED.StyleSetName = "FieldUltraLabel";
            this.label1SHEMAURAOJIDORGJED.AutoSize = true;
            this.label1SHEMAURAOJIDORGJED.Anchor = AnchorStyles.Left;
            this.label1SHEMAURAOJIDORGJED.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMAURAOJIDORGJED.Appearance.ForeColor = Color.Black;
            this.label1SHEMAURAOJIDORGJED.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.Controls.Add(this.label1SHEMAURAOJIDORGJED, 0, 4);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetColumnSpan(this.label1SHEMAURAOJIDORGJED, 1);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetRowSpan(this.label1SHEMAURAOJIDORGJED, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SHEMAURAOJIDORGJED.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMAURAOJIDORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x43, 0x17);
            this.label1SHEMAURAOJIDORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSHEMAURAOJIDORGJED.Location = point;
            this.comboSHEMAURAOJIDORGJED.Name = "comboSHEMAURAOJIDORGJED";
            this.comboSHEMAURAOJIDORGJED.Tag = "SHEMAURAOJIDORGJED";
            this.comboSHEMAURAOJIDORGJED.TabIndex = 0;
            this.comboSHEMAURAOJIDORGJED.Anchor = AnchorStyles.Left;
            this.comboSHEMAURAOJIDORGJED.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSHEMAURAOJIDORGJED.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAURAOJIDORGJED.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAURAOJIDORGJED.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSHEMAURAOJIDORGJED.Enabled = true;
            this.comboSHEMAURAOJIDORGJED.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAURASHEMAURAKONTIRANJE, "SHEMAURAOJIDORGJED"));
            this.comboSHEMAURAOJIDORGJED.ShowPictureBox = true;
            this.comboSHEMAURAOJIDORGJED.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSHEMAURAOJIDORGJED);
            this.comboSHEMAURAOJIDORGJED.ValueMember = "IDORGJED";
            this.comboSHEMAURAOJIDORGJED.SelectionChanged += new EventHandler(this.SelectedIndexChangedSHEMAURAOJIDORGJED);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.Controls.Add(this.comboSHEMAURAOJIDORGJED, 1, 4);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetColumnSpan(this.comboSHEMAURAOJIDORGJED, 1);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.SetRowSpan(this.comboSHEMAURAOJIDORGJED, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSHEMAURAOJIDORGJED.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMAURAOJIDORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMAURAOJIDORGJED.Size = size;
            this.Controls.Add(this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSHEMAURASHEMAURAKONTIRANJE;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "SHEMAURAFormSHEMAURASHEMAURAKONTIRANJEUserControl";
            this.Text = " SHEMAURAKONTIRANJE";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.SHEMAURAFormUserControl_Load);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.ResumeLayout(false);
            this.layoutManagerformSHEMAURASHEMAURAKONTIRANJE.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSHEMAURASHEMAURAKONTIRANJE).EndInit();
            this.dsSHEMAURADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.SHEMAURAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAURASHEMAURAKONTIRANJE, this.SHEMAURAController.WorkItem, this))
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
            this.label1SHEMAURAKONTOIDKONTO.Text = StringResources.SHEMAURASHEMAURAKONTOIDKONTODescription;
            this.label1SHEMAURASTRANEIDSTRANEKNJIZENJA.Text = StringResources.SHEMAURASHEMAURASTRANEIDSTRANEKNJIZENJADescription;
            this.label1IDURAVRSTAIZNOSA.Text = StringResources.SHEMAURAIDURAVRSTAIZNOSADescription;
            this.label1SHEMAURAMTIDMJESTOTROSKA.Text = StringResources.SHEMAURASHEMAURAMTIDMJESTOTROSKADescription;
            this.label1SHEMAURAOJIDORGJED.Text = StringResources.SHEMAURASHEMAURAOJIDORGJEDDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIDURAVRSTAIZNOSA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("URAVRSTAIZNOSA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedSHEMAURAKONTOIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedSHEMAURAMTIDMJESTOTROSKA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("MJESTOTROSKA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedSHEMAURAOJIDORGJED(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ORGJED", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedSHEMAURASTRANEIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("STRANEKNJIZENJA", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.SHEMAURAController.WorkItem.Items.Contains("SHEMAURASHEMAURAKONTIRANJE|SHEMAURASHEMAURAKONTIRANJE"))
            {
                this.SHEMAURAController.WorkItem.Items.Add(this.bindingSourceSHEMAURASHEMAURAKONTIRANJE, "SHEMAURASHEMAURAKONTIRANJE|SHEMAURASHEMAURAKONTIRANJE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("SHEMAURASHEMAURAKONTIRANJESaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedIDURAVRSTAIZNOSA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDURAVRSTAIZNOSA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDURAVRSTAIZNOSA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.Current).Row["IDURAVRSTAIZNOSA"] = RuntimeHelpers.GetObjectValue(row["IDURAVRSTAIZNOSA"]);
                    this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedSHEMAURAKONTOIDKONTO(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSHEMAURAKONTOIDKONTO.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSHEMAURAKONTOIDKONTO.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.Current).Row["SHEMAURAKONTOIDKONTO"] = RuntimeHelpers.GetObjectValue(row["IDKONTO"]);
                    this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedSHEMAURAMTIDMJESTOTROSKA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSHEMAURAMTIDMJESTOTROSKA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSHEMAURAMTIDMJESTOTROSKA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.Current).Row["SHEMAURAMTIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["IDMJESTOTROSKA"]);
                    this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedSHEMAURAOJIDORGJED(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSHEMAURAOJIDORGJED.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSHEMAURAOJIDORGJED.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.Current).Row["SHEMAURAOJIDORGJED"] = RuntimeHelpers.GetObjectValue(row["IDORGJED"]);
                    this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedSHEMAURASTRANEIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSHEMAURASTRANEIDSTRANEKNJIZENJA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.Current).Row["SHEMAURASTRANEIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(row["IDSTRANEKNJIZENJA"]);
                    this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboSHEMAURAKONTOIDKONTO.Focus();
        }

        private void SetNullItem_Click(object sender, EventArgs e)
        {
            this.m_BaseMethods.SetNullItemClickBase(RuntimeHelpers.GetObjectValue(sender), this.m_CurrentRow);
        }

        private void SetSize()
        {
        }

        private void SHEMAURAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.SHEMAURASHEMAURASHEMAURAKONTIRANJELevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.m_FrameworkDescription, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        protected virtual URAVRSTAIZNOSAComboBox comboIDURAVRSTAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDURAVRSTAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDURAVRSTAIZNOSA = value;
            }
        }

        protected virtual KONTOComboBox comboSHEMAURAKONTOIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSHEMAURAKONTOIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSHEMAURAKONTOIDKONTO = value;
            }
        }

        protected virtual MJESTOTROSKAComboBox comboSHEMAURAMTIDMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSHEMAURAMTIDMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSHEMAURAMTIDMJESTOTROSKA = value;
            }
        }

        protected virtual ORGJEDComboBox comboSHEMAURAOJIDORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSHEMAURAOJIDORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSHEMAURAOJIDORGJED = value;
            }
        }

        protected virtual STRANEKNJIZENJAComboBox comboSHEMAURASTRANEIDSTRANEKNJIZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSHEMAURASTRANEIDSTRANEKNJIZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSHEMAURASTRANEIDSTRANEKNJIZENJA = value;
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

        protected virtual UltraLabel label1IDURAVRSTAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDURAVRSTAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDURAVRSTAIZNOSA = value;
            }
        }

        protected virtual UltraLabel label1SHEMAURAKONTOIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMAURAKONTOIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMAURAKONTOIDKONTO = value;
            }
        }

        protected virtual UltraLabel label1SHEMAURAMTIDMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMAURAMTIDMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMAURAMTIDMJESTOTROSKA = value;
            }
        }

        protected virtual UltraLabel label1SHEMAURAOJIDORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMAURAOJIDORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMAURAOJIDORGJED = value;
            }
        }

        protected virtual UltraLabel label1SHEMAURASTRANEIDSTRANEKNJIZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMAURASTRANEIDSTRANEKNJIZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMAURASTRANEIDSTRANEKNJIZENJA = value;
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
        public NetAdvantage.Controllers.SHEMAURAController SHEMAURAController { get; set; }

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

