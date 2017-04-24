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
    public class SHEMAIRAFormSHEMAIRASHEMAIRAKONTIRANJEUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDIRAVRSTAIZNOSA")]
        private IRAVRSTAIZNOSAComboBox _comboIDIRAVRSTAIZNOSA;
        [AccessedThroughProperty("comboSHEMAIRAKONTOIDKONTO")]
        private KONTOComboBox _comboSHEMAIRAKONTOIDKONTO;
        [AccessedThroughProperty("comboSHEMAIRAMTIDMJESTOTROSKA")]
        private MJESTOTROSKAComboBox _comboSHEMAIRAMTIDMJESTOTROSKA;
        [AccessedThroughProperty("comboSHEMAIRAOJIDORGJED")]
        private ORGJEDComboBox _comboSHEMAIRAOJIDORGJED;
        [AccessedThroughProperty("comboSHEMAIRASTRANEIDSTRANEKNJIZENJA")]
        private STRANEKNJIZENJAComboBox _comboSHEMAIRASTRANEIDSTRANEKNJIZENJA;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDIRAVRSTAIZNOSA")]
        private UltraLabel _label1IDIRAVRSTAIZNOSA;
        [AccessedThroughProperty("label1SHEMAIRAKONTOIDKONTO")]
        private UltraLabel _label1SHEMAIRAKONTOIDKONTO;
        [AccessedThroughProperty("label1SHEMAIRAMTIDMJESTOTROSKA")]
        private UltraLabel _label1SHEMAIRAMTIDMJESTOTROSKA;
        [AccessedThroughProperty("label1SHEMAIRAOJIDORGJED")]
        private UltraLabel _label1SHEMAIRAOJIDORGJED;
        [AccessedThroughProperty("label1SHEMAIRASTRANEIDSTRANEKNJIZENJA")]
        private UltraLabel _label1SHEMAIRASTRANEIDSTRANEKNJIZENJA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSHEMAIRASHEMAIRAKONTIRANJE;
        private IContainer components = null;
        private SHEMAIRADataSet dsSHEMAIRADataSet1;
        protected TableLayoutPanel layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "SHEMAIRASHEMAIRAKONTIRANJE";
        private string m_FrameworkDescription = StringResources.SHEMAIRADescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public SHEMAIRAFormSHEMAIRASHEMAIRAKONTIRANJEUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("SHEMAIRASHEMAIRAKONTIRANJEAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SHEMAIRASHEMAIRAKONTIRANJEAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow) ((DataRowView) this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsSHEMAIRADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.DataSource = this.SHEMAIRAController.DataSet;
            this.dsSHEMAIRADataSet1 = this.SHEMAIRAController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/IRAVRSTAIZNOSA", Thread=ThreadOption.UserInterface)]
        public void comboIDIRAVRSTAIZNOSA_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDIRAVRSTAIZNOSA.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void comboSHEMAIRAKONTOIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            this.comboSHEMAIRAKONTOIDKONTO.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/MJESTOTROSKA", Thread=ThreadOption.UserInterface)]
        public void comboSHEMAIRAMTIDMJESTOTROSKA_Add(object sender, ComponentEventArgs e)
        {
            this.comboSHEMAIRAMTIDMJESTOTROSKA.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ORGJED", Thread=ThreadOption.UserInterface)]
        public void comboSHEMAIRAOJIDORGJED_Add(object sender, ComponentEventArgs e)
        {
            this.comboSHEMAIRAOJIDORGJED.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRANEKNJIZENJA", Thread=ThreadOption.UserInterface)]
        public void comboSHEMAIRASTRANEIDSTRANEKNJIZENJA_Add(object sender, ComponentEventArgs e)
        {
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.Fill();
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
            this.dsSHEMAIRADataSet1 = (SHEMAIRADataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsSHEMAIRADataSet1.Tables["SHEMAIRASHEMAIRAKONTIRANJE"]);
            this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "SHEMAIRA", this.m_Mode, this.dsSHEMAIRADataSet1, this.dsSHEMAIRADataSet1.SHEMAIRASHEMAIRAKONTIRANJE.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow) ((DataRowView) this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (SHEMAIRADataSet.SHEMAIRASHEMAIRAKONTIRANJERow) ((DataRowView) this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(SHEMAIRAFormSHEMAIRASHEMAIRAKONTIRANJEUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE).BeginInit();
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE = new TableLayoutPanel();
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SuspendLayout();
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.AutoSize = true;
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.Dock = DockStyle.Fill;
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.Size = size;
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.ColumnCount = 2;
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.RowCount = 6;
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.RowStyles.Add(new RowStyle());
            this.label1SHEMAIRAKONTOIDKONTO = new UltraLabel();
            this.comboSHEMAIRAKONTOIDKONTO = new KONTOComboBox();
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA = new UltraLabel();
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA = new STRANEKNJIZENJAComboBox();
            this.label1IDIRAVRSTAIZNOSA = new UltraLabel();
            this.comboIDIRAVRSTAIZNOSA = new IRAVRSTAIZNOSAComboBox();
            this.label1SHEMAIRAMTIDMJESTOTROSKA = new UltraLabel();
            this.comboSHEMAIRAMTIDMJESTOTROSKA = new MJESTOTROSKAComboBox();
            this.label1SHEMAIRAOJIDORGJED = new UltraLabel();
            this.comboSHEMAIRAOJIDORGJED = new ORGJEDComboBox();
            this.dsSHEMAIRADataSet1 = new SHEMAIRADataSet();
            this.dsSHEMAIRADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSHEMAIRADataSet1.DataSetName = "dsSHEMAIRA";
            this.dsSHEMAIRADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.DataSource = this.dsSHEMAIRADataSet1;
            this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.DataMember = "SHEMAIRASHEMAIRAKONTIRANJE";
            ((ISupportInitialize) this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMAIRAKONTOIDKONTO.Location = point;
            this.label1SHEMAIRAKONTOIDKONTO.Name = "label1SHEMAIRAKONTOIDKONTO";
            this.label1SHEMAIRAKONTOIDKONTO.TabIndex = 1;
            this.label1SHEMAIRAKONTOIDKONTO.Tag = "labelSHEMAIRAKONTOIDKONTO";
            this.label1SHEMAIRAKONTOIDKONTO.Text = "Konto:";
            this.label1SHEMAIRAKONTOIDKONTO.StyleSetName = "FieldUltraLabel";
            this.label1SHEMAIRAKONTOIDKONTO.AutoSize = true;
            this.label1SHEMAIRAKONTOIDKONTO.Anchor = AnchorStyles.Left;
            this.label1SHEMAIRAKONTOIDKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMAIRAKONTOIDKONTO.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1SHEMAIRAKONTOIDKONTO.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1SHEMAIRAKONTOIDKONTO.ImageSize = size;
            this.label1SHEMAIRAKONTOIDKONTO.Appearance.ForeColor = Color.Black;
            this.label1SHEMAIRAKONTOIDKONTO.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.Controls.Add(this.label1SHEMAIRAKONTOIDKONTO, 0, 0);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetColumnSpan(this.label1SHEMAIRAKONTOIDKONTO, 1);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetRowSpan(this.label1SHEMAIRAKONTOIDKONTO, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1SHEMAIRAKONTOIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMAIRAKONTOIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1SHEMAIRAKONTOIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSHEMAIRAKONTOIDKONTO.Location = point;
            this.comboSHEMAIRAKONTOIDKONTO.Name = "comboSHEMAIRAKONTOIDKONTO";
            this.comboSHEMAIRAKONTOIDKONTO.Tag = "SHEMAIRAKONTOIDKONTO";
            this.comboSHEMAIRAKONTOIDKONTO.TabIndex = 0;
            this.comboSHEMAIRAKONTOIDKONTO.Anchor = AnchorStyles.Left;
            this.comboSHEMAIRAKONTOIDKONTO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSHEMAIRAKONTOIDKONTO.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAIRAKONTOIDKONTO.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAIRAKONTOIDKONTO.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSHEMAIRAKONTOIDKONTO.Enabled = true;
            this.comboSHEMAIRAKONTOIDKONTO.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE, "SHEMAIRAKONTOIDKONTO"));
            this.comboSHEMAIRAKONTOIDKONTO.ShowPictureBox = true;
            this.comboSHEMAIRAKONTOIDKONTO.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSHEMAIRAKONTOIDKONTO);
            this.comboSHEMAIRAKONTOIDKONTO.ValueMember = "IDKONTO";
            this.comboSHEMAIRAKONTOIDKONTO.SelectionChanged += new EventHandler(this.SelectedIndexChangedSHEMAIRAKONTOIDKONTO);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.Controls.Add(this.comboSHEMAIRAKONTOIDKONTO, 1, 0);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetColumnSpan(this.comboSHEMAIRAKONTOIDKONTO, 1);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetRowSpan(this.comboSHEMAIRAKONTOIDKONTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSHEMAIRAKONTOIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMAIRAKONTOIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMAIRAKONTOIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.Location = point;
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.Name = "label1SHEMAIRASTRANEIDSTRANEKNJIZENJA";
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.TabIndex = 1;
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.Tag = "labelSHEMAIRASTRANEIDSTRANEKNJIZENJA";
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.Text = "Strana knjiženja:";
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.StyleSetName = "FieldUltraLabel";
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.AutoSize = true;
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.ImageSize = size;
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.Appearance.ForeColor = Color.Black;
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.Controls.Add(this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA, 0, 1);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetColumnSpan(this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA, 1);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetRowSpan(this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x76, 0x17);
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.Location = point;
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.Name = "comboSHEMAIRASTRANEIDSTRANEKNJIZENJA";
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.Tag = "SHEMAIRASTRANEIDSTRANEKNJIZENJA";
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.TabIndex = 0;
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.Enabled = true;
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE, "SHEMAIRASTRANEIDSTRANEKNJIZENJA"));
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.ShowPictureBox = true;
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSHEMAIRASTRANEIDSTRANEKNJIZENJA);
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.ValueMember = "IDSTRANEKNJIZENJA";
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.SelectionChanged += new EventHandler(this.SelectedIndexChangedSHEMAIRASTRANEIDSTRANEKNJIZENJA);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.Controls.Add(this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA, 1, 1);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetColumnSpan(this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA, 1);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetRowSpan(this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDIRAVRSTAIZNOSA.Location = point;
            this.label1IDIRAVRSTAIZNOSA.Name = "label1IDIRAVRSTAIZNOSA";
            this.label1IDIRAVRSTAIZNOSA.TabIndex = 1;
            this.label1IDIRAVRSTAIZNOSA.Tag = "labelIDIRAVRSTAIZNOSA";
            this.label1IDIRAVRSTAIZNOSA.Text = "Vrsta iznosa:";
            this.label1IDIRAVRSTAIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1IDIRAVRSTAIZNOSA.AutoSize = true;
            this.label1IDIRAVRSTAIZNOSA.Anchor = AnchorStyles.Left;
            this.label1IDIRAVRSTAIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDIRAVRSTAIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1IDIRAVRSTAIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.Controls.Add(this.label1IDIRAVRSTAIZNOSA, 0, 2);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetColumnSpan(this.label1IDIRAVRSTAIZNOSA, 1);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetRowSpan(this.label1IDIRAVRSTAIZNOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDIRAVRSTAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDIRAVRSTAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x5f, 0x17);
            this.label1IDIRAVRSTAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDIRAVRSTAIZNOSA.Location = point;
            this.comboIDIRAVRSTAIZNOSA.Name = "comboIDIRAVRSTAIZNOSA";
            this.comboIDIRAVRSTAIZNOSA.Tag = "IDIRAVRSTAIZNOSA";
            this.comboIDIRAVRSTAIZNOSA.TabIndex = 0;
            this.comboIDIRAVRSTAIZNOSA.Anchor = AnchorStyles.Left;
            this.comboIDIRAVRSTAIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDIRAVRSTAIZNOSA.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDIRAVRSTAIZNOSA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDIRAVRSTAIZNOSA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDIRAVRSTAIZNOSA.Enabled = true;
            this.comboIDIRAVRSTAIZNOSA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE, "IDIRAVRSTAIZNOSA"));
            this.comboIDIRAVRSTAIZNOSA.ShowPictureBox = true;
            this.comboIDIRAVRSTAIZNOSA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDIRAVRSTAIZNOSA);
            this.comboIDIRAVRSTAIZNOSA.ValueMember = "IDIRAVRSTAIZNOSA";
            this.comboIDIRAVRSTAIZNOSA.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDIRAVRSTAIZNOSA);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.Controls.Add(this.comboIDIRAVRSTAIZNOSA, 1, 2);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetColumnSpan(this.comboIDIRAVRSTAIZNOSA, 1);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetRowSpan(this.comboIDIRAVRSTAIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDIRAVRSTAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboIDIRAVRSTAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x10a, 0x17);
            this.comboIDIRAVRSTAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMAIRAMTIDMJESTOTROSKA.Location = point;
            this.label1SHEMAIRAMTIDMJESTOTROSKA.Name = "label1SHEMAIRAMTIDMJESTOTROSKA";
            this.label1SHEMAIRAMTIDMJESTOTROSKA.TabIndex = 1;
            this.label1SHEMAIRAMTIDMJESTOTROSKA.Tag = "labelSHEMAIRAMTIDMJESTOTROSKA";
            this.label1SHEMAIRAMTIDMJESTOTROSKA.Text = "Šifra MT:";
            this.label1SHEMAIRAMTIDMJESTOTROSKA.StyleSetName = "FieldUltraLabel";
            this.label1SHEMAIRAMTIDMJESTOTROSKA.AutoSize = true;
            this.label1SHEMAIRAMTIDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.label1SHEMAIRAMTIDMJESTOTROSKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMAIRAMTIDMJESTOTROSKA.Appearance.ForeColor = Color.Black;
            this.label1SHEMAIRAMTIDMJESTOTROSKA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.Controls.Add(this.label1SHEMAIRAMTIDMJESTOTROSKA, 0, 3);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetColumnSpan(this.label1SHEMAIRAMTIDMJESTOTROSKA, 1);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetRowSpan(this.label1SHEMAIRAMTIDMJESTOTROSKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SHEMAIRAMTIDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMAIRAMTIDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(70, 0x17);
            this.label1SHEMAIRAMTIDMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSHEMAIRAMTIDMJESTOTROSKA.Location = point;
            this.comboSHEMAIRAMTIDMJESTOTROSKA.Name = "comboSHEMAIRAMTIDMJESTOTROSKA";
            this.comboSHEMAIRAMTIDMJESTOTROSKA.Tag = "SHEMAIRAMTIDMJESTOTROSKA";
            this.comboSHEMAIRAMTIDMJESTOTROSKA.TabIndex = 0;
            this.comboSHEMAIRAMTIDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.comboSHEMAIRAMTIDMJESTOTROSKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSHEMAIRAMTIDMJESTOTROSKA.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAIRAMTIDMJESTOTROSKA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAIRAMTIDMJESTOTROSKA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSHEMAIRAMTIDMJESTOTROSKA.Enabled = true;
            this.comboSHEMAIRAMTIDMJESTOTROSKA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE, "SHEMAIRAMTIDMJESTOTROSKA"));
            this.comboSHEMAIRAMTIDMJESTOTROSKA.ShowPictureBox = true;
            this.comboSHEMAIRAMTIDMJESTOTROSKA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSHEMAIRAMTIDMJESTOTROSKA);
            this.comboSHEMAIRAMTIDMJESTOTROSKA.ValueMember = "IDMJESTOTROSKA";
            this.comboSHEMAIRAMTIDMJESTOTROSKA.SelectionChanged += new EventHandler(this.SelectedIndexChangedSHEMAIRAMTIDMJESTOTROSKA);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.Controls.Add(this.comboSHEMAIRAMTIDMJESTOTROSKA, 1, 3);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetColumnSpan(this.comboSHEMAIRAMTIDMJESTOTROSKA, 1);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetRowSpan(this.comboSHEMAIRAMTIDMJESTOTROSKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSHEMAIRAMTIDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMAIRAMTIDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMAIRAMTIDMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMAIRAOJIDORGJED.Location = point;
            this.label1SHEMAIRAOJIDORGJED.Name = "label1SHEMAIRAOJIDORGJED";
            this.label1SHEMAIRAOJIDORGJED.TabIndex = 1;
            this.label1SHEMAIRAOJIDORGJED.Tag = "labelSHEMAIRAOJIDORGJED";
            this.label1SHEMAIRAOJIDORGJED.Text = "Šifra OJ:";
            this.label1SHEMAIRAOJIDORGJED.StyleSetName = "FieldUltraLabel";
            this.label1SHEMAIRAOJIDORGJED.AutoSize = true;
            this.label1SHEMAIRAOJIDORGJED.Anchor = AnchorStyles.Left;
            this.label1SHEMAIRAOJIDORGJED.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMAIRAOJIDORGJED.Appearance.ForeColor = Color.Black;
            this.label1SHEMAIRAOJIDORGJED.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.Controls.Add(this.label1SHEMAIRAOJIDORGJED, 0, 4);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetColumnSpan(this.label1SHEMAIRAOJIDORGJED, 1);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetRowSpan(this.label1SHEMAIRAOJIDORGJED, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SHEMAIRAOJIDORGJED.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMAIRAOJIDORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x43, 0x17);
            this.label1SHEMAIRAOJIDORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSHEMAIRAOJIDORGJED.Location = point;
            this.comboSHEMAIRAOJIDORGJED.Name = "comboSHEMAIRAOJIDORGJED";
            this.comboSHEMAIRAOJIDORGJED.Tag = "SHEMAIRAOJIDORGJED";
            this.comboSHEMAIRAOJIDORGJED.TabIndex = 0;
            this.comboSHEMAIRAOJIDORGJED.Anchor = AnchorStyles.Left;
            this.comboSHEMAIRAOJIDORGJED.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSHEMAIRAOJIDORGJED.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAIRAOJIDORGJED.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAIRAOJIDORGJED.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSHEMAIRAOJIDORGJED.Enabled = true;
            this.comboSHEMAIRAOJIDORGJED.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE, "SHEMAIRAOJIDORGJED"));
            this.comboSHEMAIRAOJIDORGJED.ShowPictureBox = true;
            this.comboSHEMAIRAOJIDORGJED.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSHEMAIRAOJIDORGJED);
            this.comboSHEMAIRAOJIDORGJED.ValueMember = "IDORGJED";
            this.comboSHEMAIRAOJIDORGJED.SelectionChanged += new EventHandler(this.SelectedIndexChangedSHEMAIRAOJIDORGJED);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.Controls.Add(this.comboSHEMAIRAOJIDORGJED, 1, 4);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetColumnSpan(this.comboSHEMAIRAOJIDORGJED, 1);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.SetRowSpan(this.comboSHEMAIRAOJIDORGJED, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSHEMAIRAOJIDORGJED.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMAIRAOJIDORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMAIRAOJIDORGJED.Size = size;
            this.Controls.Add(this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "SHEMAIRAFormSHEMAIRASHEMAIRAKONTIRANJEUserControl";
            this.Text = " SHEMAIRAKONTIRANJE";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.SHEMAIRAFormUserControl_Load);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.ResumeLayout(false);
            this.layoutManagerformSHEMAIRASHEMAIRAKONTIRANJE.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE).EndInit();
            this.dsSHEMAIRADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.SHEMAIRAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE, this.SHEMAIRAController.WorkItem, this))
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
            this.label1SHEMAIRAKONTOIDKONTO.Text = StringResources.SHEMAIRASHEMAIRAKONTOIDKONTODescription;
            this.label1SHEMAIRASTRANEIDSTRANEKNJIZENJA.Text = StringResources.SHEMAIRASHEMAIRASTRANEIDSTRANEKNJIZENJADescription;
            this.label1IDIRAVRSTAIZNOSA.Text = StringResources.SHEMAIRAIDIRAVRSTAIZNOSADescription;
            this.label1SHEMAIRAMTIDMJESTOTROSKA.Text = StringResources.SHEMAIRASHEMAIRAMTIDMJESTOTROSKADescription;
            this.label1SHEMAIRAOJIDORGJED.Text = StringResources.SHEMAIRASHEMAIRAOJIDORGJEDDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIDIRAVRSTAIZNOSA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("IRAVRSTAIZNOSA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedSHEMAIRAKONTOIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedSHEMAIRAMTIDMJESTOTROSKA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("MJESTOTROSKA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedSHEMAIRAOJIDORGJED(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ORGJED", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedSHEMAIRASTRANEIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("STRANEKNJIZENJA", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.SHEMAIRAController.WorkItem.Items.Contains("SHEMAIRASHEMAIRAKONTIRANJE|SHEMAIRASHEMAIRAKONTIRANJE"))
            {
                this.SHEMAIRAController.WorkItem.Items.Add(this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE, "SHEMAIRASHEMAIRAKONTIRANJE|SHEMAIRASHEMAIRAKONTIRANJE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("SHEMAIRASHEMAIRAKONTIRANJESaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedIDIRAVRSTAIZNOSA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDIRAVRSTAIZNOSA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDIRAVRSTAIZNOSA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.Current).Row["IDIRAVRSTAIZNOSA"] = RuntimeHelpers.GetObjectValue(row["IDIRAVRSTAIZNOSA"]);
                    this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedSHEMAIRAKONTOIDKONTO(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSHEMAIRAKONTOIDKONTO.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSHEMAIRAKONTOIDKONTO.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.Current).Row["SHEMAIRAKONTOIDKONTO"] = RuntimeHelpers.GetObjectValue(row["IDKONTO"]);
                    this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedSHEMAIRAMTIDMJESTOTROSKA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSHEMAIRAMTIDMJESTOTROSKA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSHEMAIRAMTIDMJESTOTROSKA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.Current).Row["SHEMAIRAMTIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["IDMJESTOTROSKA"]);
                    this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedSHEMAIRAOJIDORGJED(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSHEMAIRAOJIDORGJED.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSHEMAIRAOJIDORGJED.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.Current).Row["SHEMAIRAOJIDORGJED"] = RuntimeHelpers.GetObjectValue(row["IDORGJED"]);
                    this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedSHEMAIRASTRANEIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSHEMAIRASTRANEIDSTRANEKNJIZENJA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.Current).Row["SHEMAIRASTRANEIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(row["IDSTRANEKNJIZENJA"]);
                    this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboSHEMAIRAKONTOIDKONTO.Focus();
        }

        private void SetNullItem_Click(object sender, EventArgs e)
        {
            this.m_BaseMethods.SetNullItemClickBase(RuntimeHelpers.GetObjectValue(sender), this.m_CurrentRow);
        }

        private void SetSize()
        {
        }

        private void SHEMAIRAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.SHEMAIRASHEMAIRASHEMAIRAKONTIRANJELevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.m_FrameworkDescription, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        protected virtual IRAVRSTAIZNOSAComboBox comboIDIRAVRSTAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDIRAVRSTAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDIRAVRSTAIZNOSA = value;
            }
        }

        protected virtual KONTOComboBox comboSHEMAIRAKONTOIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSHEMAIRAKONTOIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSHEMAIRAKONTOIDKONTO = value;
            }
        }

        protected virtual MJESTOTROSKAComboBox comboSHEMAIRAMTIDMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSHEMAIRAMTIDMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSHEMAIRAMTIDMJESTOTROSKA = value;
            }
        }

        protected virtual ORGJEDComboBox comboSHEMAIRAOJIDORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSHEMAIRAOJIDORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSHEMAIRAOJIDORGJED = value;
            }
        }

        protected virtual STRANEKNJIZENJAComboBox comboSHEMAIRASTRANEIDSTRANEKNJIZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSHEMAIRASTRANEIDSTRANEKNJIZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSHEMAIRASTRANEIDSTRANEKNJIZENJA = value;
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

        protected virtual UltraLabel label1IDIRAVRSTAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDIRAVRSTAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDIRAVRSTAIZNOSA = value;
            }
        }

        protected virtual UltraLabel label1SHEMAIRAKONTOIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMAIRAKONTOIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMAIRAKONTOIDKONTO = value;
            }
        }

        protected virtual UltraLabel label1SHEMAIRAMTIDMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMAIRAMTIDMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMAIRAMTIDMJESTOTROSKA = value;
            }
        }

        protected virtual UltraLabel label1SHEMAIRAOJIDORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMAIRAOJIDORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMAIRAOJIDORGJED = value;
            }
        }

        protected virtual UltraLabel label1SHEMAIRASTRANEIDSTRANEKNJIZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMAIRASTRANEIDSTRANEKNJIZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMAIRASTRANEIDSTRANEKNJIZENJA = value;
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
        public NetAdvantage.Controllers.SHEMAIRAController SHEMAIRAController { get; set; }

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

